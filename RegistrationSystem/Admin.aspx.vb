Imports System.Diagnostics.Eventing.Reader
Imports MySql.Data.MySqlClient

Public Class Contact
    Inherits Page
    Private mcon As MySqlConnection
    Private mcd As MySqlCommand
    Private mdr As MySqlDataReader
    Private action As String
    ReadOnly credentials_table As String = "student_information"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            mcon = New MySqlConnection("Datasource=localhost;Database=student_database;user=root;")
        Catch x As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('Something went wrong with the connection')", True)
            Throw
        End Try
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
End Class