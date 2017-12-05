Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class Contact
    Inherits Page
    Private mcon As MySqlConnection
    Private mcd As MySqlCommand
    Private mdr As MySqlDataReader
    Private action As String
    ReadOnly credentials_table As String = "student_information"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("isAdmin") = True Then
            Try
                setvisibility()
                mcon = New MySqlConnection("Datasource=localhost;Database=student_database;user=root;")
            Catch x As Exception
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Something went wrong with the connection')", True)
                Throw
            End Try
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    Private Sub setvisibility()

    End Sub

    Protected Sub AddStudent_bttn_OnClick(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(id_tb.Text) And Not String.IsNullOrEmpty(username_tb.Text) And Not String.IsNullOrEmpty(first_tb.Text) And
                Not String.IsNullOrEmpty(middle_tb.Text) And Not String.IsNullOrEmpty(last_tb.Text) And Not String.IsNullOrEmpty(address_tb.Text) And
           Not String.IsNullOrEmpty(country_tb.Text) And Not String.IsNullOrEmpty(phone_tb.Text) And Not String.IsNullOrEmpty(city_tb.Text) And
           Not String.IsNullOrEmpty(state_tb.Text) And Not String.IsNullOrEmpty(ZIP_tb.Text) And Not String.IsNullOrEmpty(BirthDate_tb.Text) And
           Not major_tb.SelectedValue.Length < 1 Then
            'Stuff goes here
            mcon.Open()
            action = "select * from " & credentials_table & " where ID='" & id_tb.Text & "'AND username='" &
                     username_tb.Text & "';"
            mcd = New MySqlCommand(action, mcon)
            mdr = mcd.ExecuteReader()
            If mdr.Read() Then
                Alert_.BootstrapAlert(MessageLabel, "The student already exists",
                                      Alert_.BootstrapAlertType.Warning, True)
                mcon.Close()
            Else
                mcon.Close()
                Try
                    mcon.Open()
                    Dim Query As String = "insert into " & credentials_table & "(ID, username, first, middle, last, address, phone, country, city, state, zip, birthdate, major) values('" + id_tb.Text & "','" + username_tb.Text & "','" &
                        first_tb.Text & "','" & middle_tb.Text & "','" + last_tb.Text & "','" + address_tb.Text & "','" + phone_tb.Text & "','" + country_tb.Text & "','" + city_tb.Text &
                                                                  "','" + state_tb.Text & "','" + ZIP_tb.Text & "', str_to_date('" + BirthDate_tb.Text & "','%m/%d/%Y'),'" + major_tb.Text & "');"
                    Dim MyReader2 As MySqlDataReader
                    mcd = New MySqlCommand(Query, mcon)
                    MyReader2 = mcd.ExecuteReader()

                    If MyReader2.Read() Then
                    End If
                    mcon.Close()
                    Add_Tables()
                    Clear_Controls()
                Catch x As Exception
                    Alert_.BootstrapAlert(MessageLabel, x.ToString(),
                                          Alert_.BootstrapAlertType.Success, True)
                End Try
            End If
        Else
            Alert_.BootstrapAlert(MessageLabel, "Please complete all the required fields ",
                                  Alert_.BootstrapAlertType.Warning, True)
        End If
    End Sub

    Private Sub Clear_Controls()
        id_tb.Text = ""
        username_tb.Text = ""
        first_tb.Text = ""
        middle_tb.Text = ""
        last_tb.Text = ""
        address_tb.Text = ""
        phone_tb.Text = ""
        country_tb.Text = ""
        city_tb.Text = ""
        state_tb.Text = ""
        ZIP_tb.Text = ""
        major_tb.SelectedIndex = 0
    End Sub

    Private Sub Add_Tables()
        'Stuff goes here
        mcon.Open()
        ' CREATE TABLE `student_database`.`courses_6055411_bachelor of science in software engineering` ( `coursecode` VARCHAR(15) NULL DEFAULT NULL , `taken` BIT(1) NOT NULL DEFAULT b'0' , UNIQUE `coursecode` (`coursecode`(15))) ENGINE = MyISAM;
        action = "CREATE TABLE `student_database`.`courses_" & id_tb.Text & "_" & major_tb.Text & "` (`coursecode` VARCHAR(15) NULL DEFAULT NULL , `taken` BIT(1) NOT NULL DEFAULT b'0' , UNIQUE `coursecode` (`coursecode`(15))) ENGINE = MyISAM;"
        mcd = New MySqlCommand(action, mcon)
        mdr = mcd.ExecuteReader()
        mcon.Close()
        mcon.Open()
        'INSERT INTO `courses_6055411_bachelor of science in software engineering` (coursecode, coursename) SELECT coursecode, coursename FROM `bachelor of science in software engineering`
        Dim query As String = "INSERT INTO `courses_" & id_tb.Text & "_" & major_tb.Text & "` (coursecode) SELECT coursecode FROM `" & major_tb.Text & "`"
        mcd = New MySqlCommand(query, mcon)
        Dim MyReader2 As MySqlDataReader
        MyReader2 = mcd.ExecuteReader()
        Alert_.BootstrapAlert(MessageLabel, "Student Added",
                                      Alert_.BootstrapAlertType.Success, True)
        mcon.Close()
    End Sub

    Protected Sub DeleteStudent_OnClickStudent_bttn_OnClick(sender As Object, e As EventArgs)
        Dim major As String = ""
        Dim id_ As String = ""
        Try
            If (Not String.IsNullOrWhiteSpace(id_tb0.Text)) AndAlso (Not String.IsNullOrWhiteSpace(username_tb0.Text)) Then
                mcon.Open()
                action = "select * from " & credentials_table & " where id='" + id_tb0.Text & "' && username='" + username_tb0.Text & "';"
                mcd = New MySqlCommand(action, mcon)
                mdr = mcd.ExecuteReader()
                If mdr.Read() Then
                    major = mdr("major").ToString()
                    id_ = mdr("id").ToString()
                    mcon.Close()
                    mcon.Open()
                    Dim Query As String = "delete from " & credentials_table & " where id='" + id_ & "' && username='" + username_tb0.Text & "';"
                    Dim mcd3 As MySqlCommand = New MySqlCommand(Query, mcon)
                    mdr = mcd3.ExecuteReader()
                    mcon.Close()
                    mcon.Open()
                    Dim query2 As String = "DROP TABLE `courses_" & id_ & "_" & major & "`"
                    Dim mcd4 As MySqlCommand = New MySqlCommand(query2, mcon)
                    Dim MyReader2 As MySqlDataReader
                    MyReader2 = mcd4.ExecuteReader()
                    If MyReader2.Read() Then
                        mcon.Close()
                    Else
                        mcon.Close()
                    End If
                    Alert_.BootstrapAlert(MessageLabel2, "Student Deleted",
                                          Alert_.BootstrapAlertType.Success, True)
                Else
                    Alert_.BootstrapAlert(MessageLabel2, "Student Not Found",
                                          Alert_.BootstrapAlertType.Success, True)
                    mcon.Close()
                End If
            Else
                Alert_.BootstrapAlert(MessageLabel2, "Please complete the required fields",
                                      Alert_.BootstrapAlertType.Success, True)
            End If
        Catch ex As Exception
            Alert_.BootstrapAlert(MessageLabel2, "Something went wrong" & ex.ToString(),
                                  Alert_.BootstrapAlertType.Success, True)
        End Try
    End Sub


    Protected Sub Print_bttn_OnClick(sender As Object, e As EventArgs) Handles Print_bttn.Click
        If TableComboBox.SelectedItem Is Nothing Then
            Alert_.BootstrapAlert(MessageLabel3, "Please choose a table",
                                  Alert_.BootstrapAlertType.Success, True)
        Else
            Dim dtable As New Data.DataTable("table_courses")
            dtable = getDataTable(TableComboBox.SelectedValue)
            'Building an HTML string.
            Dim html As New StringBuilder()

            'Table start.
            html.Append("<table border = '1'>")

            'Building the Header row.
            html.Append("<tr>")
            For Each column As DataColumn In dtable.Columns
                html.Append("<th>")
                html.Append(column.ColumnName)
                html.Append("</th>")
            Next
            html.Append("</tr>")

            'Building the Data rows.
            For Each row As DataRow In dtable.Rows
                html.Append("<tr>")
                For Each column As DataColumn In dtable.Columns
                    html.Append("<td>")
                    html.Append(row(column.ColumnName))
                    html.Append("</td>")
                Next
                html.Append("</tr>")
            Next

            'Table end.
            html.Append("</table>")

            'Append the HTML string to Placeholder.
            Dim header_string As String = "<div id='Table_div' align='center'> <p> Keiser University </p> <p>" & TableComboBox.SelectedItem.ToString() & "</p> <br> </div>"
            PlaceHolder2.Controls.Add(New Literal() With {
                                         .Text = header_string.ToString()
                                         })
            PlaceHolder2.Controls.Add(New Literal() With {
                                         .Text = html.ToString()
                                         })
            PlaceHolder2.Visible = True
            Print_PDF()
            PlaceHolder2.Visible = False
        End If
    End Sub

    Private Function getDataTable(selectedValue As String) As DataTable
        Dim mcon As New MySqlConnection("Datasource=localhost;Database=student_database;user=root;")
        Dim Query As String = "select * from " + selectedValue + ";"
        mcon.Open()
        Dim mcd As New MySqlCommand(Query, mcon)
        Dim MyAdapter As New MySqlDataAdapter()
        MyAdapter.SelectCommand = mcd
        Dim dTable As New DataTable()
        MyAdapter.Fill(dTable)
        Return dTable
    End Function

    Private Sub Print_PDF()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=" & Session("Username") & " Schedule.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        PlaceHolder2.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New iTextSharp.text.Document(PageSize.A4.Rotate(), 10.0F, 10.0F, 100.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub

    Protected Sub AddStudent_Label_OnClick(sender As Object, e As EventArgs)
        ID_lb.Visible = Not ID_lb.Visible
        id_tb.Visible = Not id_tb.Visible
        username_tb.Visible = Not username_tb.Visible
        Username_lb.Visible = Not Username_lb.Visible
        First_lb.Visible = Not First_lb.Visible
        first_tb.Visible = Not first_tb.Visible
        Middle_lb.Visible = Not Middle_lb.Visible
        middle_tb.Visible = Not middle_tb.Visible
        Last_lb.Visible = Not Last_lb.Visible
        last_tb.Visible = Not last_tb.Visible
        Address_lb.Visible = Not Address_lb.Visible
        address_tb.Visible = Not address_tb.Visible
        Phone_lb.Visible = Not Phone_lb.Visible
        phone_tb.Visible = Not phone_tb.Visible
        country_lb.Visible = Not country_lb.Visible
        country_tb.Visible = Not country_tb.Visible
        City_lb.Visible = Not City_lb.Visible
        city_tb.Visible = Not city_tb.Visible
        State_lb.Visible = Not State_lb.Visible
        state_tb.Visible = Not state_tb.Visible
        ZIP_lb.Visible = Not ZIP_lb.Visible
        ZIP_tb.Visible = Not ZIP_tb.Visible
        BD_lb.Visible = Not BD_lb.Visible
        BirthDate_tb.Visible = Not BirthDate_tb.Visible
        Major_lb.Visible = Not Major_lb.Visible
        major_tb.Visible = Not major_tb.Visible
        AddStudent_bttn.Visible = Not AddStudent_bttn.Visible
    End Sub

    Protected Sub DeleteStudent_Label_OnClick(sender As Object, e As EventArgs)
        ID_lb2.Visible = Not ID_lb2.Visible
        id_tb0.Visible = Not id_tb0.Visible
        username_tb0.Visible = Not username_tb0.Visible
        Username_lb2.Visible = Not Username_lb2.Visible
        DeleteStudent_bttn.Visible = Not DeleteStudent_bttn.Visible
    End Sub

    Protected Sub DisplayTables_lb_OnClick(sender As Object, e As EventArgs)
        ID_lb3.Visible = Not ID_lb3.Visible
        TableComboBox.Visible = Not TableComboBox.Visible
        Print_bttn.Visible = Not Print_bttn.Visible
    End Sub
End Class