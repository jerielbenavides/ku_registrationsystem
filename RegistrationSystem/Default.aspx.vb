﻿Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page

#Region "Variables"

#Region "MYSQL Variables"

    Public Shared connectionString As [String] = "Datasource=localhost;Database=student_database;user=root;"
    Dim mcon As New MySqlConnection(connectionString)
    Dim mcd As New MySqlCommand
    Dim mdr As MySqlDataReader
    Dim student_major As String
    ReadOnly nextsemestercourses_table As String = "courses_spring_2018"
    ReadOnly requirements_table As String = "requirements"
    Dim student_major_courses_table As String
    Dim temporary_table1 As String
    Dim final_table As String

#End Region

    Public classes As New List(Of Class_Object)
    'Not the best name, but...
    Public strings_for_panels As New List(Of String)

#End Region

#Region "Init methods"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Get values
        Get_Values()
        If Session("Auth") = True Then
            temporary_table1 = "relevant_courses_for_" & Session("id")
            final_table = "final_" & temporary_table1
            student_major = Session("major")
            student_major_courses_table = "courses_" & Session("id") & "_" & student_major
            process_courses()
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    Private Sub Get_Values()
        If ViewState("strings_for_panels") Is Nothing Then

        Else
            strings_for_panels = ViewState("strings_for_panels")
        End If
    End Sub

    Private Sub process_courses()
        'Destroy the tables if they exist
        destroy_tables()
        'Get relevant courses filtering by major and discard courses already taken
        getcourses()
        'Filter courses by requirement (those that do not have requirements and those that have a requirement but the
        'student has already taken it will be saved to a table
        filter_by_requirement()
        ' Create objects
        create_classes_objects()
        'Add objects to panel
        add_to_panel()
        'Show this in a grid (temporary)
        'showingrid()
    End Sub

#End Region

#Region "User Interface Methods"

    Private Sub add_to_panel()
        Dim offset = 10
        choose_courses_label.ForeColor = Color.White
        selected_courses_label.ForeColor = Color.White
        ChosenCourses_Panel.BorderColor = Color.Black
        ChosenCourses_Panel.BorderWidth = 5
        ChosenCourses_Panel.BackColor = Color.FromArgb(31, 103, 166)
        AvailableCourses_Panel.BorderColor = Color.Black
        AvailableCourses_Panel.BorderWidth = 5
        AvailableCourses_Panel.BackColor = Color.FromArgb(31, 103, 166)
        For Each _class As Class_Object In classes

            Dim checkBox = New CheckBox()
            checkBox.BorderWidth = 5
            checkBox.AutoPostBack = True
            checkBox.Text = " Code: " & _class.get_coursecode()
            checkBox.BorderColor = Color.FromArgb(31, 103, 166)
            checkBox.ForeColor = Color.White
            checkBox.Checked = False
            checkBox.ID = classes.IndexOf(_class) & _class.get_coursecode()
            AddHandler checkBox.CheckedChanged, Sub()
                                                    handle_checkbox(_class, checkBox.Checked, checkBox)
                                                End Sub
            offset = offset + 30

            Dim pan_classname As New Panel
            pan_classname.BackColor = Color.Azure
            Dim classname As New Label With {
                    .Text = _class.get_coursename()
                    }
            pan_classname.Controls.Add(classname)

            Dim pan_instructor As New Panel
            pan_instructor.BackColor = Color.Azure
            Dim classinstructor As New Label With {
                    .Text = "Instructor: " & _class.get_instructor()
                    }
            pan_instructor.Controls.Add(classinstructor)

            Dim pan_classloc As New Panel
            pan_classloc.BackColor = Color.Azure

            Dim classloc As New Label With {
                    .Text =
                    "Days: " & _class.get_days() & vbTab & vbTab & "   ///   Time: " & _class.get_timein() & " - " &
                    _class.get_timeout() & vbTab & vbTab & "   ///   Room: " & _class.get_room()
                    }
            pan_classloc.Controls.Add(classloc)


            Dim separator As New Panel
            separator.BackColor = Color.FromArgb(31, 103, 166)
            separator.Height = 15
            separator.Width = 400

            Dim class_panel As New Panel
            class_panel.BorderWidth = 5
            class_panel.BorderColor = Color.FromArgb(31, 103, 166)

            Dim superclass_panel As New Panel
            superclass_panel.BorderWidth = 5
            superclass_panel.BorderColor = Color.FromArgb(31, 103, 166)

            class_panel.Controls.Add(pan_classname)
            class_panel.Controls.Add(pan_instructor)
            class_panel.Controls.Add(pan_classloc)

            superclass_panel.Controls.Add(separator)
            superclass_panel.Controls.Add(checkBox)
            superclass_panel.Controls.Add(class_panel)
            AvailableCourses_Panel.Controls.Add(superclass_panel)
        Next
        ChosenCourses_Panel.Width = AvailableCourses_Panel.Width
    End Sub

    Private Function handle_checkbox(_class As Class_Object, isChecked As Boolean, checkbox As CheckBox) As EventHandler
        'A string to identify the course in the array
        Dim arrayidentify As String = _class.get_coursecode() & _class.get_days() & _class.get_timein() &
                                      _class.get_timeout()
        If isChecked Then
            add_course_to_list(_class, arrayidentify, checkbox)
        Else
            For value = 0 To (strings_for_panels.Count - 11) Step 11
                If strings_for_panels(value) = arrayidentify Then
                    strings_for_panels.RemoveRange(value, 11)
                    'Save the array, again...
                    ViewState("strings_for_panels") = strings_for_panels
                    'Get out of the for loop. Deleting an element changes the arrays' count and the code breaks. 
                    'Leaving the for loop is a must.
                    GoTo end_of_for
                End If
            Next
            ' A place where IndexOutOfBounds is not known. 
end_of_for:
        End If
        'Redraw the controls at the right of the AvailableCourses Panel (Courses have been chosen or deleted by the user)
        redraw_rightpanel()
    End Function

    Private Sub add_course_to_list(_class As Class_Object, string_id As String, checkbox As CheckBox)
        'Boolean to check if the user already selected a similar class
        Dim same_course = False
        'Boolean to check if a class cannot be added because of the schedule
        Dim schedule_problem = False
        'Boolean to check if the user tried to add more credits than allowed.
        Dim credits_problem = False
        same_course = Helper.check_samecourses(_class, string_id, strings_for_panels)
        schedule_problem = Helper.check_scheduleproblem(_class, string_id, strings_for_panels, classes)
        credits_problem = Helper.check_credits(_class, string_id, strings_for_panels, classes)


        If same_course = False And schedule_problem = False And credits_problem = False Then
            Dim pan_classname As New Panel
            pan_classname.BackColor = Color.Azure
            Dim classname As New Label With {
                    .Text = _class.get_coursename()
                    }
            pan_classname.Controls.Add(classname)

            Dim pan_instructor As New Panel
            pan_instructor.BackColor = Color.Azure
            Dim classinstructor As New Label With {
                    .Text = "Instructor: " & _class.get_instructor()
                    }
            pan_instructor.Controls.Add(classinstructor)

            Dim pan_classloc As New Panel
            pan_classloc.BackColor = Color.Azure

            Dim classloc As New Label With {
                    .Text =
                    "Days: " & _class.get_days() & vbTab & vbTab & "   ///   Time: " & _class.get_timein() & " - " &
                    _class.get_timeout() & vbTab & vbTab & "   ///   Room: " & _class.get_room()
                    }
            pan_classloc.Controls.Add(classloc)


            Dim separator As New Panel
            separator.BackColor = Color.FromArgb(31, 103, 166)
            separator.Height = 15
            separator.Width = 400

            Dim class_panel As New Panel
            class_panel.BorderWidth = 5
            class_panel.BorderColor = Color.FromArgb(31, 103, 166)

            Dim superclass_panel As New Panel
            superclass_panel.BorderWidth = 5
            superclass_panel.BorderColor = Color.FromArgb(31, 103, 166)

            class_panel.Controls.Add(pan_classname)
            class_panel.Controls.Add(pan_instructor)
            class_panel.Controls.Add(pan_classloc)

            superclass_panel.Controls.Add(separator)
            superclass_panel.Controls.Add(class_panel)
            superclass_panel.ID = "Panel " & classes.IndexOf(_class) & _class.get_coursecode()
            'Maybe it is a better idea to add only _class.getcourseid and find the objects using that to recreate the panels.
            'It would save some memory. 
            strings_for_panels.Add(string_id)
            strings_for_panels.Add(_class.get_coursename())
            strings_for_panels.Add(_class.get_coursecode())
            strings_for_panels.Add(_class.get_credits())
            strings_for_panels.Add(_class.get_days())
            strings_for_panels.Add(_class.get_instructor())
            strings_for_panels.Add(_class.get_mode())
            strings_for_panels.Add(_class.get_room())
            strings_for_panels.Add(_class.get_timein())
            strings_for_panels.Add(_class.get_timeout())
            strings_for_panels.Add(_class.get_courseid())
            'Save the array to a viewstate
            ViewState("strings_for_panels") = strings_for_panels
            ChosenCourses_Panel.Controls.Add(superclass_panel)
            ChosenCourses_Panel.ViewStateMode = ViewStateMode.Enabled
            checkbox.Checked = True
        Else

            checkbox.Checked = False
            'Display error message
            Response.Write("<script>alert('" & Helper.error_message & "');</script>")
            'Remember to save the array
        End If
    End Sub

    Private Sub redraw_rightpanel()
        ChosenCourses_Panel.Controls.Clear()
        For value = 0 To (strings_for_panels.Count - 11) Step 11

            Dim pan_classname As New Panel
            pan_classname.BackColor = Color.Azure
            Dim classname As New Label With {
                    .Text = strings_for_panels(value + 1).ToString()
                    }
            pan_classname.Controls.Add(classname)

            Dim pan_instructor As New Panel
            pan_instructor.BackColor = Color.Azure
            Dim classinstructor As New Label With {
                    .Text = "Instructor: " & strings_for_panels(value + 5).ToString()
                    }
            pan_instructor.Controls.Add(classinstructor)

            Dim pan_classloc As New Panel
            pan_classloc.BackColor = Color.Azure

            Dim classloc As New Label With {
                    .Text =
                    "Days: " & strings_for_panels(value + 4).ToString() & vbTab & vbTab & "   ///   Time: " &
                    strings_for_panels(value + 8).ToString() & " - " & strings_for_panels(value + 9).ToString() & vbTab &
                    vbTab & "   ///   Room: " & strings_for_panels(value + 7).ToString()
                    }
            pan_classloc.Controls.Add(classloc)

            Dim separator As New Panel
            separator.BackColor = Color.FromArgb(31, 103, 166)
            separator.Height = 15
            separator.Width = 400

            Dim class_panel As New Panel
            class_panel.BorderWidth = 5
            class_panel.BorderColor = Color.FromArgb(31, 103, 166)

            Dim superclass_panel As New Panel
            superclass_panel.BorderWidth = 5
            superclass_panel.BorderColor = Color.FromArgb(31, 103, 166)

            class_panel.Controls.Add(pan_classname)
            class_panel.Controls.Add(pan_instructor)
            class_panel.Controls.Add(pan_classloc)

            superclass_panel.Controls.Add(separator)
            superclass_panel.Controls.Add(class_panel)
            superclass_panel.ID = "Panel " & strings_for_panels(value)
            ChosenCourses_Panel.Controls.Add(superclass_panel)
            ChosenCourses_Panel.ViewStateMode = ViewStateMode.Enabled
        Next
    End Sub

#End Region

#Region "MySQL"

    Private Sub create_classes_objects()
        Dim mcon As New MySqlConnection(connectionString)
        Dim Query As String = "select * from " + final_table + ";"
        mcon.Open()
        Dim mcd As New MySqlCommand(Query, mcon)
        Dim MyAdapter As New MySqlDataAdapter()
        MyAdapter.SelectCommand = mcd
        Dim dTable As New DataTable()
        MyAdapter.Fill(dTable)

        For Each row As DataRow In dTable.Rows
            Dim _
                objClass As _
                    New Class_Object(row.Item("courseid"), row.Item("coursecode").ToString(),
                                     row.Item("coursename").ToString(), row.Item("timein"),
                                     row.Item("timeout"), row.Item("instructor").ToString(), row.Item("room").ToString(),
                                     row.Item("mode").ToString(),
                                     Convert.ToBoolean(Integer.Parse(row.Item("monday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("tuesday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("wednesday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("thursday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("friday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("saturday"))),
                                     Convert.ToBoolean(Integer.Parse(row.Item("sunday"))),
                                     Integer.Parse(row.Item("credits")))
            classes.Add(objClass)
        Next
    End Sub

    Private Sub destroy_tables()
        Try
            Dim Action As String
            mcon = New MySqlConnection(connectionString)
            mcon.Open()
            Action = "DROP TABLE IF EXISTS " & temporary_table1 & ";"
            mcd = New MySqlCommand(Action, mcon)
            mdr = mcd.ExecuteReader()
            If mdr.Read() Then

            Else

            End If
            mcon.Close()

            mcon = New MySqlConnection(connectionString)
            mcon.Open()
            Action = "DROP TABLE IF EXISTS " & final_table & ";"
            mcd = New MySqlCommand(Action, mcon)
            mdr = mcd.ExecuteReader()
            If mdr.Read() Then

            Else

            End If
            mcon.Close()
        Catch ex As Exception
            mcon.Close()
        End Try
    End Sub

    'Private Sub showingrid()
    '    Dim mcon As New MySqlConnection(connectionString)
    '    Dim Query As String = "select * from " + final_table + ";"
    '    mcon.Open()
    '    Dim mcd As New MySqlCommand(Query, mcon)
    '    Dim MyAdapter As New MySqlDataAdapter()
    '    MyAdapter.SelectCommand = mcd
    '    Dim dTable As New DataTable()
    '    MyAdapter.Fill(dTable)
    '    GridView1.DataSource = dTable
    '    GridView1.DataBind()
    'End Sub

    Private Sub getcourses()
        'CREATE THE TABLES NEEDED
        Dim Action As String
        mcon = New MySqlConnection(connectionString)
        mcon.Open()
        Action = "CREATE TABLE " & temporary_table1 & " select * from " & nextsemestercourses_table &
                 " where exists (select 1 from `" & student_major &
                 "` where coursecode = " & nextsemestercourses_table & ".coursecode) AND (select 1 from `" &
                 student_major_courses_table & "` where coursecode= " &
                 nextsemestercourses_table & ".coursecode AND `" & student_major_courses_table & "`.taken=0);"

        mcd = New MySqlCommand(Action, mcon)
        mdr = mcd.ExecuteReader()
        If mdr.Read() Then

        Else

        End If
        mcon.Close()
    End Sub

    Private Sub filter_by_requirement()
        Dim Action As String
        mcon = New MySqlConnection(connectionString)
        mcon.Open()
        Action = "CREATE TABLE " & final_table & " select * from " & nextsemestercourses_table &
                 " where coursecode In (select * from (Select coursecode from (Select " & temporary_table1 &
                 ".coursecode, " & temporary_table1 & ".coursename, " & requirements_table & ".requirement, " &
                 "`" & student_major_courses_table & "`.taken" & " from " & temporary_table1 & " INNER Join " &
                 requirements_table & " ON " & temporary_table1 & ".coursecode = " & requirements_table & ".coursecode" &
                 " INNER Join `" & student_major_courses_table & "` ON `" & student_major_courses_table &
                 "`.coursecode = " &
                 requirements_table & ".requirement WHERE `" &
                 student_major_courses_table & "`.taken=1) AS tablex) AS supertable) " &
                 "UNION " &
                 "Select * from " & temporary_table1 & " WHERE NOT exists (select 1 from " & requirements_table &
                 " where coursecode=" & temporary_table1 & ".coursecode);"

        mcd = New MySqlCommand(Action, mcon)
        mdr = mcd.ExecuteReader()
        If mdr.Read() Then

        Else

        End If
        mcon.Close()
    End Sub

#End Region
End Class