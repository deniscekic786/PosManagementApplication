Option Explicit On
Option Strict On
Imports BusinessObjects


Public Class BackEndManagement

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnempmngmnt.Click

        objempmanagement = New EmployeeManagement
        objempmanagement.ShowDialog()
    End Sub

    Private Sub BackEndManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncustomermanagement.Click
        objcustomermanagement = New CustomerManagement
        objcustomermanagement.ShowDialog()
    End Sub

    Private Sub video_management_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles video_management.Click
        VideoGameManagementFRM = New VideoGameManagement
        VideoGameManagementFRM.ShowDialog()
    End Sub

    Private Sub dvd_management_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dvd_management.Click
        DVDManagementFRM = New DVD_Management
        DVDManagementFRM.ShowDialog()
    End Sub
End Class
