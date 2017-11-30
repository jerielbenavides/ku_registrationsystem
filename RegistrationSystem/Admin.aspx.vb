Imports System.Diagnostics.Eventing.Reader

Public Class Contact
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub AddStudent_bttn_OnClick(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(id_tb.Text) And Not String.IsNullOrEmpty(username_tb.Text) And Not String.IsNullOrEmpty(first_tb.Text) And
                Not String.IsNullOrEmpty(middle_tb.Text) And Not String.IsNullOrEmpty(last_tb.Text) And Not String.IsNullOrEmpty(address_tb.Text) And
           Not String.IsNullOrEmpty(country_tb.Text) And Not String.IsNullOrEmpty(phone_tb.Text) And Not String.IsNullOrEmpty(city_tb.Text) And
           Not String.IsNullOrEmpty(state_tb.Text) And Not String.IsNullOrEmpty(ZIP_tb.Text) And Not String.IsNullOrEmpty(BirthDate_tb.Text) And
           Not major_tb.SelectedValue.Length < 1 Then
            'Stuff goes here
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('This will be implemented soon')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Complete everything')", True)

        End If
    End Sub
End Class