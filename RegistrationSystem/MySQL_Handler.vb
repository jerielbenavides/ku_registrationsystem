Imports MySql.Data.MySqlClient

Public Class MySQL_Handler

    Public Shared connectionString As [String] = "Datasource=localhost;Database=student_database;user=root;"
    Public Shared mcon As New MySqlConnection(connectionString)
    Public Shared mcd As New MySqlCommand
    Public Shared mdr As MySqlDataReader
    Public Shared student_major As String
    Public Shared nextsemestercourses_table As String = "courses_spring_2018"
    Public Shared requirements_table As String = "requirements"
    Public Shared student_major_courses_table As String
    Public Shared temporary_table1 As String
    Public Shared final_table As String
    Public Shared classes As New List(Of Class_Object)

    Public Shared Sub create_classes_objects()
        Dim mcon As New MySqlConnection(connectionString)
        Dim Query As String = "select * from " + final_table + ";"
        mcon.Open()
        Dim mcd As New MySqlCommand(Query, mcon)
        Dim MyAdapter As New MySqlDataAdapter()
        MyAdapter.SelectCommand = mcd
        Dim dTable As New DataTable()
        MyAdapter.Fill(dTable)

        For Each row As DataRow In dTable.Rows
            Dim objClass As New Class_Object(row.Item("courseid"), row.Item("coursecode").ToString(), row.Item("coursename").ToString(), row.Item("timein"),
                                             row.Item("timeout"), row.Item("instructor").ToString(), row.Item("room").ToString(), row.Item("mode").ToString(),
                                             Convert.ToBoolean(Integer.Parse(row.Item("monday"))), Convert.ToBoolean(Integer.Parse(row.Item("tuesday"))), Convert.ToBoolean(Integer.Parse(row.Item("wednesday"))), Convert.ToBoolean(Integer.Parse(row.Item("thursday"))),
                                             Convert.ToBoolean(Integer.Parse(row.Item("friday"))), Convert.ToBoolean(Integer.Parse(row.Item("saturday"))), Convert.ToBoolean(Integer.Parse(row.Item("sunday"))), Convert.ToBoolean(Integer.Parse(row.Item("credits"))))
            classes.Add(objClass)
        Next
    End Sub

    Public Shared Sub destroy_tables()
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

    Public Shared Sub getcourses()
        'CREATE THE TABLES NEEDED
        Dim Action As String
        mcon = New MySqlConnection(connectionString)
        mcon.Open()
        Action = "CREATE TABLE " & temporary_table1 & " select * from " & nextsemestercourses_table & " where exists (select 1 from `" & student_major &
                 "` where coursecode = " & nextsemestercourses_table & ".coursecode) AND (select 1 from `" & student_major_courses_table & "` where coursecode= " &
                 nextsemestercourses_table & ".coursecode AND `" & student_major_courses_table & "`.taken=0);"

        mcd = New MySqlCommand(Action, mcon)
        mdr = mcd.ExecuteReader()
        If mdr.Read() Then

        Else

        End If
        mcon.Close()
    End Sub

    Public Shared Sub filter_by_requirement()
        Dim Action As String
        mcon = New MySqlConnection(connectionString)
        mcon.Open()
        Action = "CREATE TABLE " & final_table & " select * from " & nextsemestercourses_table &
                 " where coursecode In (select * from (Select coursecode from (Select " & temporary_table1 &
                 ".coursecode, " & temporary_table1 & ".coursename, " & requirements_table & ".requirement, " &
                 "`" & student_major_courses_table & "`.taken" & " from " & temporary_table1 & " INNER Join " &
                 requirements_table & " ON " & temporary_table1 & ".coursecode = " & requirements_table & ".coursecode" &
                 " INNER Join `" & student_major_courses_table & "` ON `" & student_major_courses_table & "`.coursecode = " &
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
End Class
