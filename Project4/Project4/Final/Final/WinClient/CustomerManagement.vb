
Option Explicit On
Option Strict On
Imports BusinessObjects


Public Class CustomerManagement


    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        objCustomerList.Add(txtID.Text, txtFirstName.Text, txtLastName.Text, txtSSN.Text, txtBirthdate.Text, txtAddress.Text, txtPhonenumber.Text, txtEmail.Text)
        objCustomerList.Save()
        txtID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtSSN.Text = ""
        txtBirthdate.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtPhonenumber.Text = ""
        txtEmail.Text = ""
        MessageBox.Show("Successfully added a new Customer record.")
    End Sub

    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            objCustomer = New BusinessObjects.Customer
            objCustomer.Load(txtID.Text.Trim)
            With objCustomer
                txtFirstName.Text = .FirstName
                txtLastName.Text = .LastName
                txtSSN.Text = .SSNumber
                txtBirthdate.Text = Format(.Birthdate, "MM/dd/yyyy")
                txtAge.Text = CStr(.Age)
                txtAddress.Text = .Address
                txtPhonenumber.Text = .PhoneNumber
                txtEmail.Text = .Email
                txtID.Text = .IDNumber
            End With
        Catch objAppEx As ApplicationException
            MessageBox.Show("Customer Not Found! " & objAppEx.Message)
            txtSSN.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtBirthdate.Text = ""
            txtAddress.Text = ""
            txtPhonenumber.Text = ""
            txtEmail.Text = ""
            txtAge.Text = ""
            txtID.Text = ""
        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)
            'Step D-Traps for general exceptions.
        Catch objE As Exception
            'Step E-Inform User
            MessageBox.Show(objE.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim checkingEmployeeStatus As Boolean = objCustomerList.Edit(txtID.Text, txtFirstName.Text, txtLastName.Text, txtBirthdate.Text, txtAddress.Text, txtPhonenumber.Text, txtEmail.Text)
        If (checkingEmployeeStatus = True) Then
            objCustomerList.Save()
            MessageBox.Show("Record found and edited")
            txtSSN.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtBirthdate.Text = ""
            txtAge.Text = ""
            txtAddress.Text = ""
            txtPhonenumber.Text = ""
            txtEmail.Text = ""
            txtID.Text = ""
        Else
            MessageBox.Show("Customer record not found!")
        End If
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim bolResults As Boolean
            objCustomerList.DeferredDelete(txtID.Text.Trim)
            objCustomerList.Save()
            txtSSN.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtBirthdate.Text = ""
            txtAge.Text = ""
            txtAddress.Text = ""
            txtPhonenumber.Text = ""
            txtEmail.Text = ""
            txtID.Text = ""
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

    Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim printresults As Boolean = objCustomerList.Print(txtID.Text)

        If (printresults = False) Then
            MessageBox.Show("Customer record not found!")
        Else
        End If
    End Sub

    Private Sub btnPrintall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintall.Click

        objCustomerList.PrintAllCustomer()
    End Sub

    Private Sub btnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        objCustomerList.Clear()
    End Sub

    Private Sub CustomerManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            objCustomerList.Load()
        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)
        Catch objE As Exception
            MessageBox.Show(objE.Message)
        End Try
    End Sub




    Private Sub btnCustList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustList.Click
        Try
            lstCustomers.Items.Clear()
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Customer
            For Each objDictionaryEntry In objCustomerList
                objItem = CType(objDictionaryEntry.Value, Customer)
                Dim strLine As String = ( _
                     objItem.IDNumber & "," & _
                    objItem.FirstName & "," & _
                    objItem.LastName & "," & _
                    objItem.SSNumber & "," & _
                    objItem.Birthdate & "," & _
                    objItem.Age & "," & _
                    objItem.Address & "," & _
                    objItem.PhoneNumber & "," & _
                    objItem.Email)
                lstCustomers.Items.Add(strLine)
            Next
        Catch objE As Exception
            MessageBox.Show(objE.Message)

        End Try
    End Sub


End Class