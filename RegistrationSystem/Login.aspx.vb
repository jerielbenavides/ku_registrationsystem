Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class Login
    Inherits Page

    Public Shared connectionString As [String] = "Datasource=localhost;Database=student_database;user=root;"
    Dim mcon As New MySqlConnection(connectionString)
    Dim mcd As New MySqlCommand
    Dim mdr As MySqlDataReader
    Dim ReadOnly credentials_table As String = "student_information"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Auth") = True Then
            Response.Redirect("~/Default.aspx")
        Else

        End If
    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Action As String
        If (String.IsNullOrWhiteSpace(usernametb.Text) Or String.IsNullOrWhiteSpace(passwordtb.Text)) Then
            login_result.Text = "Please complete the fields"
        Else
            mcon = New MySqlConnection(connectionString)
            mcon.Open()
            Action = "select * from " & credentials_table & " where ID='" & passwordtb.Text & "'AND username='" &
                     usernametb.Text & "';"
            mcd = New MySqlCommand(Action, mcon)
            mdr = mcd.ExecuteReader()
            If mdr.Read() Then
                login_result.Text = "Please wait..."
                login_result.ForeColor = Color.White
                Session("Auth") = True
                Session("username") = usernametb.Text
                Session("id") = passwordtb.Text
                Session("fullname") = mdr("first").ToString() & " " & mdr("last").ToString()
                Session("major") = mdr("major").ToString()
                Response.Redirect("Default.aspx")
            Else
                login_result.Text = "The username or password is invalid."
                login_result.ForeColor = Color.Red
                Session("Auth") = False
            End If
            mcon.Close()
        End If
    End Sub
End Class