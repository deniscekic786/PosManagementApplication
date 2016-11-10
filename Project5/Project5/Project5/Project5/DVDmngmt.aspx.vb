Imports BusinessObjects

Public Class DVDmngmt
    Inherits System.Web.UI.Page

    Private objDVD As DVD
    Private objDVDList As DVD_List
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ASP.NET CODE REQUIRED TO DETERMINE IF THIS IS FIRST TIME PAGE IS LOADED
            '(FIRST TRIP POSTBACK = False) OR IS THIS SECOND TRIP AND FORWARD (POSTBACK = True)
            ' or POSTBACK/REVISIT OF THE PAGE AFTER IT HAS TRAVELLED BACK FROM CLIENT BROWSER.
            'PAGE CLASS PROPERTY Page.IsPostBack IS True if POSTBACK OR REVISIT
            'OR False IF FIRST TIME PAGE IS LOADED.
            If Not Page.IsPostBack Then
                'FIRST TRIP WE Create the Collecton object 
                objDVDList = New BusinessObjects.DVD_List
                'FIRST TRIP WE Load collection from database 
                objDVDList.Load()
                'SECOND TRIP WE Place collection in Page.Session Collection to Save State in server 'NOW THE COLLECTION WITH OUR CUSTOMER OBJECTS IS AVAILABLE DURING EACH TRIP 
                Me.Session.Item("objDVDList") = objDVDList
            Else
                'SECOND + TRIPS (PostBack = True) 'Hide & Reset Message Label 
                lblMessage.Visible = False
                lblMessage.Text = ""
                'SECOND + TRIPS (PostBack = True) 'Get Pointer to Collection stored in Session Object for USE Trought 
                objDVDList = Me.Session.Item("objDVDList")
            End If
            'Step B-Traps for general exceptions.
        Catch objE As Exception
            'Step C-Inform User 'Write Message to Web Form 
            lblMessage.Visible = True
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try

            'Step 3-Calls Collection Add(Value1,Value2,.) pass text control arguments 

            Dim getavailability As Boolean

            Dim enumRatingval As Rating
            Dim enumCategoryval As Movie_Category
            Dim enumSystemval As DVD_Format

            enumRatingval = CType(System.Enum.Parse(GetType(Rating), dlEnumRating.SelectedItem.ToString()), Rating)
            enumCategoryval = CType(System.Enum.Parse(GetType(Movie_Category), dlEnumCategory.SelectedItem.ToString()), Movie_Category)
            enumSystemval = CType(System.Enum.Parse(GetType(DVD_Format), dlEnumFormat.SelectedItem.ToString()), DVD_Format)
            If radYes.Checked = True Then
                radNo.Checked = False
                getavailability = True
            ElseIf radNo.Checked = True Then
                radYes.Checked = False
                getavailability = False
            End If


            objDVDList.add(txtIDNumber.Text.Trim, txtTitle.Text.Trim, txtDesc.Text.Trim, enumRatingval, txtSale.Text.Trim, txtRent.Text.Trim, txtLatefee.Text.Trim, enumCategoryval, enumSystemval, getavailability)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully added a DVD."

       
           

            txtIDNumber.Text = ""
            txtTitle.Text = ""
            txtDesc.Text = ""
            dlEnumRating.Text = ""
            txtSale.Text = ""
            txtRent.Text = ""
            txtLatefee.Text = ""
            dlEnumCategory.Text = ""
            dlEnumFormat.Text = ""

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

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        'Step A-Begins Exeception handling.
        Try 'Step 1-Call Calls Collection.Item() Property to return pointer to object 'in Collection 
       


            objDVD = objDVDList.item(txtIDNumber.Text.Trim)
            'Step 2-If result of search is Nothing, then display customer is not found
            If objDVD Is Nothing Then 'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "DVD Not Found" 'Step 3-Clear all controls 
                txtIDNumber.Text = ""
                txtTitle.Text = ""
                txtDesc.Text = ""
                dlEnumRating.Text = ""
                txtSale.Text = ""
                txtRent.Text = ""
                txtLatefee.Text = ""
                dlEnumCategory.Text = ""
                dlEnumFormat.Text = ""
            Else
                'Step 4-Then Data is extracted from customer object & placed on textboxes
                With objDVD
                    txtIDNumber.Text = .ID_Number
                    txtTitle.Text = .Title
                    txtDesc.Text = .Description
                    dlEnumRating.Text = objDVD.EnumRating.ToString()
                    txtSale.Text = .Sale_Price
                    txtRent.Text = .Rental_Rate
                    txtLatefee.Text = .Late_Fee
                    dlEnumCategory.Text = objDVD.Enum_Movie_Category.ToString()
                    dlEnumFormat.Text = objDVD.DVD_Formats.ToString()
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

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        Try
            Dim bolResults As Boolean
            Dim getavailability As Boolean
            Dim enumRatingval As Rating
            Dim enumCategoryval As Movie_Category
            Dim enumSystemval As DVD_Format
            'Step 3-Call Module EditItem(index,x,y,z,...) method with textbox data 
            enumRatingval = CType(System.Enum.Parse(GetType(Rating), dlEnumRating.SelectedItem.ToString()), Rating)
            enumCategoryval = CType(System.Enum.Parse(GetType(Movie_Category), dlEnumCategory.SelectedItem.ToString()), Movie_Category)
            enumSystemval = CType(System.Enum.Parse(GetType(DVD_Format), dlEnumFormat.SelectedItem.ToString()), DVD_Format)
            bolResults = objDVDList.Edit(txtIDNumber.Text.Trim, txtTitle.Text.Trim, txtDesc.Text.Trim, enumRatingval, txtSale.Text.Trim, txtRent.Text.Trim, txtLatefee.Text.Trim, enumCategoryval, enumSystemval, getavailability)
            'Step 2-If not found display Message & clear all controls 
            If radYes.Checked = True Then
                getavailability = True
            Else
                getavailability = False
            End If
            If bolResults = True Then
                'Write Message to Web Form 
                lblMessage.Visible = True
                lblMessage.Text = "Successfully Edited DVD!"

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

            objDVDList.DeferredDelete(txtIDNumber.Text.Trim)
            lblMessage.Visible = True
            lblMessage.Text = "Successfully deleted a DVD."
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
            bolResults = objDVDList.Print(txtIDNumber.Text.Trim)
            'Step 2-If not found display Message & clear all controls
            If bolResults <> True Then
                lblMessage.Visible = True
                lblMessage.Text = "DVD Not Found!"
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
            objDVDList.PrintAll()
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
            gvCustomers.DataSource = objDVDList.ToArray
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
            objDVD = Nothing
            'Step 2-Save objects from Collection to file 
            objDVDList.Save()
            'Step 3-Clear the Collection 
            objDVDList.Clear()
            'Step 4-Remove objCustomerList from ASP.NET.Page.Session Collection 
            Session.Remove("objDVDList")
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