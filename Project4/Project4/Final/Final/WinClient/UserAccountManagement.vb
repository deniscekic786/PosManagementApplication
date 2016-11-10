Option Explicit On
Option Strict On
Imports BusinessObjects


Public Class UserAccountManagement

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        objUserAccountList.Add(txtusername.Text, txtpassword.Text, txtemail.Text)
        objUserAccountList.Save()
        txtusername.Text = ""
        txtpassword.Text = ""
        txtemail.Text = ""
        MessageBox.Show("Successfully added a new employee record.")


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        objUserAccountList.Clear()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try

            Dim gettinguid As String
            gettinguid = objUserAccountList.ReturnGuid(txtusername.Text)
            objUseraccountpointer = New BusinessObjects.UserAccount
            objUseraccountpointer.Load(gettinguid)
            objUserAccountList.lastguid = gettinguid
            objUserAccountList.GettingGuid = ""
            With objUseraccountpointer
                txtusername.Text = .Username
                txtpassword.Text = .Password
                txtemail.Text = .Email
            End With
        Catch objAppEx As ApplicationException
            MessageBox.Show("User Not Found! " & objAppEx.Message)
            txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)
            'Step D-Traps for general exceptions.
        Catch objE As Exception
            'Step E-Inform User
            MessageBox.Show(objE.Message)
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim gettingguid As String
        gettingguid = objUserAccountList.lastguid
        objUserAccountList.GettingGuid = ""
        Dim checkinguserStatus As Boolean = objUserAccountList.Edit(objUserAccountList.lastguid, txtusername.Text, txtpassword.Text, txtemail.Text)
        If checkinguserStatus = True Then
            objUserAccountList.Save()
            MessageBox.Show("Successfully edited")
            txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
        Else
            MessageBox.Show("User account record not found!")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim bolResults As Boolean
            Dim gettingGuid As String
            gettingGuid = objUserAccountList.lastguid
            objUserAccountList.GettingGuid = ""
            objUserAccountList.DeferredDelete(objUserAccountList.lastguid)
            objUserAccountList.Save()
           txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
            If bolResults <> True Then
                MessageBox.Show("Record has been successfully deleted")
            End If

        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)

        Catch objX As ArgumentNullException
            MessageBox.Show(objX.Message)

        Catch objE As Exception
            'Step F-Inform User
            MessageBox.Show(objE.Message)

        End Try
    End Sub

    Private Sub btnChangeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeUser.Click
        Dim gettingguid As String
        gettingguid = objUserAccountList.lastguid
        objUserAccountList.GettingGuid = ""
        Dim changeusernameresults As Boolean = objUserAccountList.ChangeUsername(gettingguid, txtusername.Text)
        If (changeusernameresults = True) Then
            objUserAccountList.Save()
            MessageBox.Show("Successfully changed username")
            txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
        Else
            MessageBox.Show("User account record not found!")
        End If
    End Sub

    Private Sub btnChangePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePass.Click

        Dim changepasswordresults As Boolean = objUserAccountList.ChangePassword(txtusername.Text, txtpassword.Text)
        If (changepasswordresults = True) Then
            objUserAccountList.Save()
            MessageBox.Show("Successfully changed password")
            txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
        Else
            MessageBox.Show("User account record not found!")

        End If
    End Sub

    Private Sub btnChangeEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeEmail.Click
        Dim changemailresults As Boolean = objUserAccountList.ChangeEmail(txtusername.Text, txtemail.Text)
        If (changemailresults = True) Then
            objUserAccountList.Save()
            MessageBox.Show("Successfully changed email")
            txtusername.Text = ""
            txtpassword.Text = ""
            txtemail.Text = ""
        Else
            MessageBox.Show("User account record not found!")
        End If
    End Sub

    Private Sub UserAccountManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub


End Class