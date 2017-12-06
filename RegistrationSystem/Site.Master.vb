Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class SiteMaster
    Inherits MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        master_username.InnerText = "Welcome " & Session("fullname")
        FooterLabel.ForeColor = Color.White
        FooterLabel.Text = DateTime.Now.Year & " - KULAC Registration System"
        If Session("isAdmin") = True Then
            HomeMaster.Visible = False
        Else
            AdminMaster.Visible = False
        End If
    End Sub


    Protected Sub LogoutClick(sender As Object, e As EventArgs)
        Try
            delete_temp_tables()
        Catch ex As Exception

        End Try
        Session("Auth") = False
        Session("Username") = ""
        Response.Redirect("~/Login.aspx")
    End Sub

    Private Sub delete_temp_tables()
        Dim connectionString As [String] = "Datasource=localhost;Database=student_database;user=root;"
        Dim mcon As New MySqlConnection(connectionString)
        Dim mcd As New MySqlCommand
        Dim mdr As MySqlDataReader

        mcon.Open()
        Dim Action = "Drop table relevant_courses_for_" & Session("id")
        mcd = New MySqlCommand(Action, mcon)
        mdr = mcd.ExecuteReader()
        mcon.Close()
        mcon.Open()
        Action = "Drop table final_relevant_courses_for_" & Session("id")
        mcd = New MySqlCommand(Action, mcon)
        mdr = mcd.ExecuteReader()
        mcon.Close()
    End Sub
End Class