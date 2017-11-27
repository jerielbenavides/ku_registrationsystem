Imports System.Drawing

Public Class SiteMaster
    Inherits MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        master_username.InnerText = "Welcome " & Session("fullname")
        FooterLabel.ForeColor = Color.White
        FooterLabel.Text = DateTime.Now.Year & " - KULAC Registration System"
    End Sub

    Protected Sub LogoutClick(sender As Object, e As EventArgs)
        Session("Auth") = False
        Session("Username") = ""
        Response.Redirect("~/Login.aspx")
    End Sub
End Class