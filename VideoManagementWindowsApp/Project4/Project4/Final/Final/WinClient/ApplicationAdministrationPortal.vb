Option Explicit On
Option Strict On
Imports BusinessObjects


Public Class ApplicationAdministrationPortal

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnuseraccmngmnt.Click

        objuseraccnt = New UserAccountManagement
        objuseraccnt.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub ApplicationAdministrationPortal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class