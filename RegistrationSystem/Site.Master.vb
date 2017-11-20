Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        master_username.InnerText = "Welcome " & Session("fullname")
    End Sub

    Protected Sub LogoutClick(sender As Object, e As EventArgs)
        Session("Auth") = False
        Session("Username") = ""
        Response.Redirect("~/Login.aspx")
    End Sub
End Class