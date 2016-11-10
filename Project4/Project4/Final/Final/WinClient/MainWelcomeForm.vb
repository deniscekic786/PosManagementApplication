Option Explicit On
Option Strict On
Imports BusinessObjects

Public Class MainWelcomeForm

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbackend.Click

        objbackendmngmt = New BackEndManagement
        objbackendmngmt.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadminportal.Click
        objadminport = New ApplicationAdministrationPortal
        objadminport.ShowDialog()
    End Sub


    Private Sub MainWelcomeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

   
    Private Sub VideoPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoPOS.Click
        objVideoPosSystem = New VideoPointOfSales
        objVideoPosSystem.ShowDialog()
    End Sub
End Class