Imports BusinessObjects


Public Class EmployeeMngmt
    Inherits System.Web.UI.Page

    Private objEmployee As Employee
    Private objEmployeeList As EmployeeList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'ASP.NET CODE REQUIRED TO DETERMINE IF THIS IS FIRST TIME PAGE IS LOADED
            '(FIRST TRIP POSTBACK = False) OR IS THIS SECOND TRIP AND FORWARD (POSTBACK = True)
            ' or POSTBACK/REVISIT OF THE PAGE AFTER IT HAS TRAVELLED BACK FROM CLIENT BROWSER.
            'PAGE CLASS PROPERTY Page.IsPostBack IS True if POSTBACK OR REVISIT
            'OR False IF FIRST TIME PAGE IS LOADED.
            If Not Page.IsPostBack Then
                'FIRST TRIP WE Create the Collecton object 
                objEmployeeList = New BusinessObjects.EmployeeList
                'FIRST TRIP WE Load collection from database 
                objEmployeeList.Load()
                'SECOND TRIP WE Place collection in Page.Session Collection to Save State in server 'NOW THE COLLECTION WITH OUR CUSTOMER OBJECTS IS AVAILABLE DURING EACH TRIP 
                Me.Session.Item("objEmployeeList") = objEmployeeList
            Else
                'SECOND + TRIPS (PostBack = True) 'Hide & Reset Message Label 
                lblMessage.Visible = False
                lblMessage.Text = ""
                'SECOND + TRIPS (PostBack = True) 'Get Pointer to Collection stored in Session Object for USE Trought 
                objEmployeeList = Me.Session.Item("objEmployeeList")
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
            objEmployee = objEmployeeList.item(txtIDNumber.Text.Trim)
            'Step 2-If result of search is Nothing, then display customer is not found
            If objEmployee Is Nothing Then 'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "Employee Not Found" 'Step 3-Clear all controls 
                txtIDNumber.Text = ""
                txtFname.Text = ""
                txtLname.Text = ""
                txtbirthdate.Text = ""
                txtaddre.Text = ""
                txtpnum.Text = ""
                txtema.Text = ""
                txtJobtitle.Text = ""


            Else
                'Step 4-Then Data is extracted from customer object & placed on textboxes
                With objEmployee
                    txtIDNumber.Text = .SSNumber
                    txtFname.Text = .FirstName
                    txtLname.Text = .LastName
                    txtbirthdate.Text = CStr(.Birthdate)
                    txtaddre.Text = .Address
                    txtpnum.Text = .PhoneNumber
                    txtema.Text = .Email
                    txtJobtitle.Text = .JobTitle
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



            objEmployeeList.Add(txtIDNumber.Text.Trim, txtFname.Text.Trim, txtLname.Text.Trim, txtbirthdate.Text, txtaddre.Text.Trim, txtpnum.Text.Trim, txtema.Text.Trim, txtJobtitle.Text.Trim)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully added a Employee."
            txtIDNumber.Text = ""
            txtFname.Text = ""
            txtLname.Text = ""
            txtbirthdate.Text = ""
            txtaddre.Text = ""
            txtpnum.Text = ""
            txtema.Text = ""
            txtJobtitle.Text = ""

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
            bolResults = objEmployeeList.Edit(txtIDNumber.Text.Trim, txtFname.Text.Trim, txtLname.Text.Trim, CDate(txtbirthdate.Text), txtaddre.Text.Trim, txtpnum.Text.Trim, txtema.Text.Trim, txtJobtitle.Text.Trim)
            'Step 2-If not found display Message & clear all controls 

            If bolResults = True Then
                'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "Successfully Edited Employee!"

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

            objEmployeeList.DeferredDelete(txtIDNumber.Text.Trim)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully deleted a Employee."
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
            bolResults = objEmployeeList.Print(txtIDNumber.Text.Trim)
            'Step 2-If not found display Message & clear all controls
            If bolResults <> True Then
                lblMessage.Visible = True
                lblMessage.Text = "Employee Not Found!"
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
            objEmployeeList.PrintAllEmployees()
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
            gvCustomers.DataSource = objEmployeeList.ToArray
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
            objEmployee = Nothing
            'Step 2-Save objects from Collection to file 
            objEmployeeList.Save()
            'Step 3-Clear the Collection 
            objEmployeeList.Clear()
            'Step 4-Remove objCustomerList from ASP.NET.Page.Session Collection 
            Session.Remove("objEmployeeList")
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