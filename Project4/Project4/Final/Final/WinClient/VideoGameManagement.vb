Imports BusinessObjects
Public Class VideoGameManagement


    Private Sub VideoGameManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objVideoMNGMlist.load()
    End Sub



    Private Sub btnAddVideoGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVideoGame.Click
        Dim enumRatingval As Rating
        Dim enumCategoryval As VideoGame_Category
        Dim enumSystemval As VideoGame_System
        Dim selectedrating = cboxRating.Text.Trim()




        enumRatingval = CType(System.Enum.Parse(GetType(Rating), selectedrating.ToString()), Rating)
        enumCategoryval = CType(System.Enum.Parse(GetType(VideoGame_Category), cboxCategories.SelectedItem.ToString()), VideoGame_Category)
        enumSystemval = CType(System.Enum.Parse(GetType(VideoGame_System), cboxSystems.SelectedItem.ToString()), VideoGame_System)
        Dim avail As Boolean
      If cbYes.Checked = True Then
            cbNo.Checked = False
            avail = True
        ElseIf cbNo.Checked = True Then
            cbYes.Checked = False
            avail = False
        End If

        objVideoMNGMlist.add(txtID.Text, txtTitle.Text, txtDescription.Text, enumRatingval, txtSalesPrice.Text, txtRentalRate.Text, txtLateFee.Text, enumCategoryval, enumSystemval, avail)
        objVideoMNGMlist.Save()
        txtID.Text = ""
        txtTitle.Text = ""
        txtDescription.Text = ""
        cboxRating.Text = ""
        txtSalesPrice.Text = ""
        txtRentalRate.Text = ""
        txtLateFee.Text = ""
        cboxCategories.Text = ""
        cboxSystems.Text = ""
        MessageBox.Show("Successfully added a new video game record.")


    End Sub

    Private Sub cboxRating_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxRating.SelectedIndexChanged


    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        objVideoMNGMlist.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try
            objVideoMNGM = New BusinessObjects.VideoGame
            objVideoMNGM.Load(txtID.Text.Trim)
            With objVideoMNGM
                Dim results As Boolean = .Availability
                txtID.Text = .ID_Number
                txtTitle.Text = .Title
                txtDescription.Text = .Description
                cboxRating.Text = objVideoMNGM.EnumRating.ToString()
                txtSalesPrice.Text = .Sale_Price
                txtRentalRate.Text = .Rental_Rate
                txtLateFee.Text = .Late_Fee
                cboxCategories.Text = objVideoMNGM.category.ToString()
                cboxSystems.Text = objVideoMNGM.Format.ToString()
                If results = True Then
                    cbYes.Checked = True
                    cbNo.Checked = False
                Else
                    cbYes.Checked = False
                    cbNo.Checked = True
                End If
            End With
        Catch objAppEx As ApplicationException
            MessageBox.Show("VideoGame Not Found! " & objAppEx.Message)
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
        Dim enumCategoryval As VideoGame_Category
        Dim enumSystemval As VideoGame_System
        Dim selectedrating = cboxRating.Text.Trim()
        enumRatingval = CType(System.Enum.Parse(GetType(Rating), selectedrating.ToString()), Rating)
        enumCategoryval = CType(System.Enum.Parse(GetType(VideoGame_Category), cboxCategories.SelectedItem.ToString()), VideoGame_Category)
        enumSystemval = CType(System.Enum.Parse(GetType(VideoGame_System), cboxSystems.SelectedItem.ToString()), VideoGame_System)

        Dim avail As Boolean


        If cbYes.Checked = True Then
            cbNo.Checked = False
            avail = True
        ElseIf cbNo.Checked = True Then
            cbYes.Checked = False
            avail = False
        End If

        Dim istru As Boolean = objVideoMNGMlist.Edit(txtID.Text, txtTitle.Text, txtDescription.Text, enumRatingval, txtSalesPrice.Text, txtRentalRate.Text, txtLateFee.Text, enumCategoryval, enumSystemval, avail)
        If istru = True Then
            objVideoMNGMlist.Save()
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
            objVideoMNGMlist.DeferredDelete(txtID.Text.Trim)
            objVideoMNGMlist.Save()
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
        Dim printresults As Boolean = objVideoMNGMlist.Print(txtID.Text)
        If (printresults = False) Then
            MessageBox.Show("Video Game record not found!")

        Else
            MessageBox.Show("Succesfully printed record!")

        End If
    End Sub

    Private Sub btnPrintall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintall.Click
        objVideoMNGMlist.PrintAll()
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

    Private Sub btnVideoList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVideoList.Click


        Try
            lstVideo.Items.Clear()
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As VideoGame
            For Each objDictionaryEntry In objVideoMNGMlist
                objItem = CType(objDictionaryEntry.Value, VideoGame)
                Dim strLine As String = ( _
                    objItem.ID_Number & "," & _
                    objItem.Title & "," & _
                    objItem.Description & "," & _
                    objItem.EnumRating.ToString() & "," & _
                    objItem.Sale_Price & "," & _
                    objItem.Rental_Rate & "," & _
                    objItem.Late_Fee & "," & _
                    objItem.category.ToString() & "," &
                    objItem.Format.ToString() & "," & _
                    objItem.Availability.ToString())

                lstVideo.Items.Add(strLine)

            Next
        Catch objE As Exception
            MessageBox.Show(objE.Message)

        End Try
    End Sub





    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
End Class