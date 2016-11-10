Option Explicit On
Option Strict On
Imports BusinessObjects

Public Class frmlogin

    Public WithEvents objUserAccount As UserAccount


    Private Sub Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok.Click
        Me.Hide()
       
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        txt_username.Text = ""
        txt_password.Text = ""
    End Sub

    Public Sub GetUserInfoAndDisplayForm(ByRef U As String, ByRef P As String)

        Me.ShowDialog()
        U = objLoginForm.txt_username.Text
        P = objLoginForm.txt_password.Text
        objUserAccount_SecurityAlert(U, P)
    End Sub



    Private Sub frmlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub objUserAccount_SecurityAlert(ByVal U As String, ByVal P As String) Handles objUserAccount.SecurityAlert
        If U = "sam" And P = "333" Then
            MessageBox.Show("This is a security breach! This employee has been fired!")
            End
        End If
    End Sub
End Class