Imports System.Drawing
Imports MySql.Data.MySqlClient
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Auth") = True Then

        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub
End Class