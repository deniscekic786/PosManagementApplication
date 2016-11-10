Imports BusinessObjects
Public Class DVD_Management

  



    Private Sub DVD_Management_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        objDVDMNGMlist.load()
    End Sub

    Private Sub btnDVDList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAddVideoGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVideoGame.Click
        Dim enumRatingval As Rating
        Dim enumCategoryval As Movie_Category
        Dim enumSystemval As DVD_Format
        Dim selectedrating = cboxRating.Text.Trim()

        enumRatingval = CType(System.Enum.Parse(GetType(Rating), selectedrating.ToString()), Rating)
        enumCategoryval = CType(System.Enum.Parse(GetType(Movie_Category), cboxCategories.SelectedItem.ToString()), Movie_Category)
        enumSystemval = CType(System.Enum.Parse(GetType(DVD_Format), cboxSystems.SelectedItem.ToString()), DVD_Format)


        Dim avail As Boolean


        If cbYes.Checked = True Then
            cbNo.Checked = False
            avail = True
        ElseIf cbNo.Checked = True Then
            cbYes.Checked = False
            avail = False
        End If

        objDVDMNGMlist.add(txtID.Text, txtTitle.Text, txtDescription.Text, enumRatingval, txtSalesPrice.Text, txtRentalRate.Text, txtLateFee.Text, enumCategoryval, enumSystemval, avail)
        objDVDMNGMlist.Save()
        txtID.Text = ""
        txtTitle.Text = ""
        txtDescription.Text = ""
        cboxRating.Text = ""
        txtSalesPrice.Text = ""
        txtRentalRate.Text = ""
        txtLateFee.Text = ""
        cboxCategories.Text = ""
        cboxSystems.Text = ""
        MessageBox.Show("Successfully added a new DVD record.")


    End Sub

    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
       
        Try
            objDVDMNGM = New BusinessObjects.DVD
            objDVDMNGM.Load(txtID.Text.Trim)
                With objDVDMNGM
                    Dim results As Boolean = .Availability
                    txtID.Text = .ID_Number
                    txtTitle.Text = .Title
                    txtDescription.Text = .Description
                    cboxRating.Text = objDVDMNGM.EnumRating.ToString()
                    txtSalesPrice.Text = .Sale_Price
                    txtRentalRate.Text = .Rental_Rate
                    txtLateFee.Text = .Late_Fee
                    cboxCategories.Text = objDVDMNGM.Enum_Movie_Category.ToString()
                cboxSystems.Text = objDVDMNGM.DVD_Formats.ToString()
            If results = True Then
                cbYes.Checked = True
                cbNo.Checked = False
            Else
                cbYes.Checked = False
                cbNo.Checked = True
                End If
            End With
        Catch objAppEx As ApplicationException
            MessageBox.Show("DVD Not Found! " & objAppEx.Message)
            txtID.Text = ""
            txtTitle.Text = ""
            txtDescription.Text = ""
            cboxRating.SelectedText = ""
            txtSalesPrice.Text = ""
            txtRentalRate.Text = ""
            txtLateFee.Text = ""
            cboxCategories.SelectedText = ""
            cboxSystems.SelectedText = ""
        Catch objNSE As NotSupportedException
            MessageBox.Show("Business Rule violation! " & objNSE.Message)
            'Step D-Traps for general exceptions.
        Catch objE As Exception
            'Step E-Inform User
            MessageBox.Show(objE.Message)
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim enumRatingval As Rating
        Dim enumCategoryval As Movie_Category
        Dim enumSystemval As DVD_Format
        Dim selectedrating = cboxRating.Text.Trim()
        enumRatingval = CType(System.Enum.Parse(GetType(Rating), selectedrating.ToString()), Rating)
        enumCategoryval = CType(System.Enum.Parse(GetType(Movie_Category), cboxCategories.SelectedItem.ToString()), Movie_Category)
        enumSystemval = CType(System.Enum.Parse(GetType(DVD_Format), cboxSystems.SelectedItem.ToString()), DVD_Format)

        Dim avail As Boolean


        If cbYes.Checked = True Then
            cbNo.Checked = False
            avail = True
        ElseIf cbNo.Checked = True Then
            cbYes.Checked = False
            avail = False
        End If

        Dim istru As Boolean = objDVDMNGMlist.Edit(txtID.Text, txtTitle.Text, txtDescription.Text, enumRatingval, txtSalesPrice.Text, txtRentalRate.Text, txtLateFee.Text, enumCategoryval, enumSystemval, avail)
        If istru = True Then
            objDVDMNGMlist.Save()

            MessageBox.Show("Record found and edited")
            txtID.Text = ""
            txtTitle.Text = ""
            txtDescription.Text = ""
            cboxRating.Text = ""
            txtSalesPrice.Text = ""
            txtRentalRate.Text = ""
            txtLateFee.Text = ""
            cboxCategories.Text = ""
            cboxSystems.Text = ""
        Else
            MessageBox.Show("Video Game record not found!")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim bolResults As Boolean
            objDVDMNGMlist.DeferredDelete(txtID.Text.Trim)
            objDVDMNGMlist.Save()
            txtID.Text = ""
            txtTitle.Text = ""
            txtDescription.Text = ""
            cboxRating.Text = ""
            txtSalesPrice.Text = ""
            txtRentalRate.Text = ""
            txtLateFee.Text = ""
            cboxCategories.Text = ""
            cboxSystems.Text = ""
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim printresults As Boolean = objDVDMNGMlist.Print(txtID.Text)
        If (printresults = False) Then
            MessageBox.Show("DVD record not found!")
        Else
            MessageBox.Show("Succesfully printed record!")
        End If
    End Sub

    Private Sub btnPrintall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintall.Click
        objDVDMNGMlist.PrintAll()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        txtID.Text = ""
        txtTitle.Text = ""
        txtDescription.Text = ""
        cboxRating.Text = ""
        txtSalesPrice.Text = ""
        txtRentalRate.Text = ""
        txtLateFee.Text = ""
        cboxCategories.Text = ""
        cboxSystems.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        objDVDMNGMlist.Clear()
    End Sub

    Private Sub btnDvdList_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDvdList.Click

        Try
            lstDVD.Items.Clear()
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As DVD
            For Each objDictionaryEntry In objDVDMNGMlist
                objItem = CType(objDictionaryEntry.Value, DVD)
                Dim strLine As String = ( _
                    objItem.ID_Number & "," & _
                    objItem.Title & "," & _
                    objItem.Description & "," & _
                    objItem.EnumRating.ToString() & "," & _
                    objItem.Sale_Price & "," & _
                    objItem.Rental_Rate & "," & _
                    objItem.Late_Fee & "," & _
                    objItem.Enum_Movie_Category.ToString() & "," &
                    objItem.DVD_Formats.ToString() & "," & _
                objItem.Availability.ToString())
                lstDVD.Items.Add(strLine)
            Next
        Catch objE As Exception

            MessageBox.Show(objE.Message)
        End Try
    End Sub
End Class