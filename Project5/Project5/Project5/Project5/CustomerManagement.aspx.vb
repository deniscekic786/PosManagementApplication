﻿Imports BusinessObjects


Public Class CustomerManagement
    Inherits System.Web.UI.Page


    Private objCustomer As Customer
    Private objCustomerList As CustomerList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Step A-Begins Exeception handling.
        Try
            'ASP.NET CODE REQUIRED TO DETERMINE IF THIS IS FIRST TIME PAGE IS LOADED
            '(FIRST TRIP POSTBACK = False) OR IS THIS SECOND TRIP AND FORWARD (POSTBACK = True)
            ' or POSTBACK/REVISIT OF THE PAGE AFTER IT HAS TRAVELLED BACK FROM CLIENT BROWSER.
            'PAGE CLASS PROPERTY Page.IsPostBack IS True if POSTBACK OR REVISIT
            'OR False IF FIRST TIME PAGE IS LOADED.
            If Not Page.IsPostBack Then
                'FIRST TRIP WE Create the Collecton object 
                objCustomerList = New BusinessObjects.CustomerList
                'FIRST TRIP WE Load collection from database 
                objCustomerList.Load()
                'SECOND TRIP WE Place collection in Page.Session Collection to Save State in server 'NOW THE COLLECTION WITH OUR CUSTOMER OBJECTS IS AVAILABLE DURING EACH TRIP 
                Me.Session.Item("objCustomerList") = objCustomerList
            Else
                'SECOND + TRIPS (PostBack = True) 'Hide & Reset Message Label 
                lblMessage.Visible = False
                lblMessage.Text = ""
                'SECOND + TRIPS (PostBack = True) 'Get Pointer to Collection stored in Session Object for USE Trought 
                objCustomerList = Me.Session.Item("objCustomerList")
            End If
            'Step B-Traps for general exceptions.
        Catch objE As Exception
            'Step C-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        'Step A-Begins Exeception handling.
        Try 'Step 1-Call Calls Collection.Item() Property to return pointer to object 'in Collection 
            objCustomer = objCustomerList.item(txtIDNumber.Text.Trim)
            'Step 2-If result of search is Nothing, then display customer is not found
            If objCustomer Is Nothing Then 'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "Customer Not Found" 'Step 3-Clear all controls 
                txtIDNumber.Text = ""
                txtFname.Text = ""
                txtLname.Text = ""
                txtSSN.Text = ""
                txtBdate.Text = ""
                txtaddy.Text = ""
                txtPhoneNumber.Text = ""
                txtEmail.Text = ""


            Else
                'Step 4-Then Data is extracted from customer object & placed on textboxes
                With objCustomer
                    txtIDNumber.Text = .IDNumber
                    txtFname.Text = .FirstName
                    txtLname.Text = .LastName
                    txtSSN.Text = .SSNumber
                    txtBdate.Text = CStr(.Birthdate)
                    txtaddy.Text = .Address
                    txtPhoneNumber.Text = .PhoneNumber
                    txtEmail.Text = .Email
                End With
            End If
            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException 'Write Message to Form 
            lblMessage.Visible = True
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException
            'Step D-Inform User
            'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objX.Message
            'Step E-Traps for general exceptions.
        Catch objE As Exception
            'Step F-Inform User
            'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
        
            'Step 3-Calls Collection Add(Value1,Value2,.) pass text control arguments 
            


            objCustomerList.Add(txtIDNumber.Text.Trim, txtFname.Text.Trim, txtLname.Text.Trim, txtSSN.Text.Trim, txtBdate.Text, txtaddy.Text.Trim, txtPhoneNumber.Text.Trim, txtEmail.Text.Trim)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully added a customer."
            txtIDNumber.Text = ""
            txtFname.Text = ""
            txtLname.Text = ""
            txtSSN.Text = ""
            txtBdate.Text = ""
            txtaddy.Text = ""
            txtPhoneNumber.Text = ""
            txtEmail.Text = ""

            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException
            'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException
            'Step D-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objX.Message
            'Step E-Traps for ArgumentExecption when KEY is duplicate.
        Catch objY As ArgumentException
            'Step F-Inform User 'Write Message to Form 
            lblMessage.Visible = True
            lblMessage.Text = objY.Message
            'Step G-Traps for general exceptions.
        Catch objE As Exception
            'Step H-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        Try
            Dim bolResults As Boolean

            'Step 3-Call Module EditItem(index,x,y,z,...) method with textbox data 
            bolResults = objCustomerList.Edit(txtIDNumber.Text.Trim, txtFname.Text.Trim, txtLname.Text.Trim, CDate(txtBdate.Text), txtaddy.Text.Trim, txtPhoneNumber.Text.Trim, txtEmail.Text.Trim)
            'Step 2-If not found display Message & clear all controls 

            If bolResults = True Then
                'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "Successfully Edited Customer!"

            End If
            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step B-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException 'Step C-Inform User 'Write Message to Web Form
            lblMessage.Visible = True
            lblMessage.Text = objX.Message
            'Step D-Traps for general exceptions.
        Catch objE As Exception 'Step E-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Try
            ''Step 1-Mark The Object for Deletion 

            objCustomerList.DeferredDelete(txtIDNumber.Text.Trim)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully deleted a customer."
        Catch objX As ArgumentNullException 'Step D-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objX.Message
            'Step B-Traps for general exceptions.
        Catch objE As Exception 'Step C-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try
            Dim bolResults As Boolean
            'Step 1-Calls Print(Key) method of module 
            bolResults = objCustomerList.Print(txtIDNumber.Text.Trim)
            'Step 2-If not found display Message & clear all controls
            If bolResults <> True Then
                lblMessage.Visible = True
                lblMessage.Text = "Customer Not Found!"
            End If
            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException 'Step D-Inform User 'Write Message to Web Form
            lblMessage.Visible = True
            lblMessage.Text = objX.Message
            'Step E-Traps for general exceptions.
        Catch objE As Exception 'Step F-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnPrintAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrintAll.Click
        Try 'Step 1-Calls PrintAllCustomers() method of module.
            objCustomerList.PrintAllCustomer()
            'Step B-Traps for general exceptions.
        Catch objE As Exception 'Step B-Inform User 'Write Message to Web Form
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnList.Click
        Try
            'Implementation of the Data Binding the GridView Control to the CustomerList Collection
            'SET GridView DataSource Property to Array with all objects, returned by ToArray method 
            gvCustomers.DataSource = objCustomerList.ToArray
            'Call GridView DataBind() method to perform the binding
            gvCustomers.DataBind()
            'Step B-Traps for general exceptions.
        Catch objE As Exception
            'Step C-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        'Submit Button commits all changes to database and removes the collection
        'from the Session Object
        'Step A-Begins Exeception handling.
        Try
            'Step 1-Destroy Form-Level Objects
            objCustomer = Nothing
            'Step 2-Save objects from Collection to file 
            objCustomerList.Save()
            'Step 3-Clear the Collection 
            objCustomerList.Clear()
            'Step 4-Remove objCustomerList from ASP.NET.Page.Session Collection 
            Session.Remove("objCustomerList")
            'Step 5-Navigate back to main form 
            Response.Redirect("Default.aspx")
            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException 'Write Message to Web Form
            lblMessage.Visible = True
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for general exceptions.
        Catch objE As Exception 'Step D-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub
End Class