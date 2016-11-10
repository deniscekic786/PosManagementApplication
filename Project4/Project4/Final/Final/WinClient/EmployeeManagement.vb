Option Explicit On
Option Strict On
Imports BusinessObjects


Public Class EmployeeManagement


    Private Sub btnAddemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddemployee.Click
        objEmployeeList.Add(txtSSN.Text, txtFirstName.Text, txtLastName.Text, txtBirthdate.Text, txtAddress.Text, txtPhonenumber.Text, txtEmail.Text, txtJobtitle.Text)
        objEmployeeList.Save()
        txtSSN.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtBirthdate.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtPhonenumber.Text = ""
        txtJobtitle.Text = ""
        txtEmail.Text = ""
        MessageBox.Show("Successfully added a new employee record.")
    End Sub
    Private Sub btnPrintall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintall.Click

        objEmployeeList.PrintAllEmployees()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        objEmployeeList.Clear()
    End Sub

    Private Sub EmployeeManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objEmployeeList.Load()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            objEmployee = New BusinessObjects.Employee
            objEmployee.Load(txtSSN.Text.Trim)
            With objEmployee
                txtFirstName.Text = .FirstName
                txtLastName.Text = .LastName
                txtBirthdate.Text = Format(.Birthdate, "MM/dd/yyyy")
                txtAge.Text = CStr(.Age)
                txtAddress.Text = .Address
                txtPhonenumber.Text = .PhoneNumber
                txtEmail.Text = .Email
                txtJobtitle.Text = .JobTitle
            End With
         
        Catch objAppEx As ApplicationException
            MessageBox.Show("Employee Not Found! " & objAppEx.Message)
            txtSSN.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtBirthdate.Text = ""
            txtAge.Text = ""
            txtAddress.Text = ""
            txtPhonenumber.Text = ""
            txtJobtitle.Text = ""
            txtEmail.Text = ""
        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)
            'Step D-Traps for general exceptions.
        Catch objE As Exception
            'Step E-Inform User
            MessageBox.Show(objE.Message)
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim checkingEmployeeStatus As Boolean = objEmployeeList.Edit(txtSSN.Text, txtFirstName.Text, txtLastName.Text, txtBirthdate.Text, txtAddress.Text, txtPhonenumber.Text, txtEmail.Text, txtJobtitle.Text)
        If (checkingEmployeeStatus = True) Then
            objEmployeeList.Save()
            MessageBox.Show("Record found and edited")
            txtSSN.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtBirthdate.Text = ""
            txtAddress.Text = ""
            txtPhonenumber.Text = ""
            txtEmail.Text = ""
            txtAge.Text = ""
            txtJobtitle.Text = ""
        Else
            MessageBox.Show("Employee record not found!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim deleteobject As Boolean
            objEmployeeList.DeferredDelete(txtSSN.Text.Trim)
            objEmployeeList.Save()
                txtSSN.Text = ""
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtBirthdate.Text = ""
                txtAge.Text = ""
                txtAddress.Text = ""
                txtPhonenumber.Text = ""
                txtJobtitle.Text = ""
                txtEmail.Text = ""
            If deleteobject <> True Then
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
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim printresults As Boolean = objEmployeeList.Print(txtSSN.Text)

        If (printresults = False) Then
            MessageBox.Show("Employee record not found!")
        Else
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtSSN.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtBirthdate.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtPhonenumber.Text = ""
        txtJobtitle.Text = ""
        txtEmail.Text = ""
    End Sub


    Private Sub btnEmpList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpList.Click
        Try
            lstEmployees.Items.Clear()
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Employee
            For Each objDictionaryEntry In objEmployeeList
                objItem = CType(objDictionaryEntry.Value, Employee)
                Dim strLine As String = ( _
                    objItem.SSNumber & "," & _
                    objItem.FirstName & "," & _
                    objItem.LastName & "," & _
                    objItem.Birthdate & "," & _
                    objItem.Age & "," & _
                    objItem.Address & "," & _
                    objItem.PhoneNumber & "," & _
                    objItem.Email & "," &
                    objItem.JobTitle)
                lstEmployees.Items.Add(strLine)


            Next
        Catch objE As Exception
            MessageBox.Show(objE.Message)

        End Try
    End Sub



    Private Sub lstEmployees_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEmployees.SelectedIndexChanged

    End Sub
End Class