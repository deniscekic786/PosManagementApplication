<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoGameManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnVideoList = New System.Windows.Forms.Button()
        Me.lstVideo = New System.Windows.Forms.ListBox()
        Me.txtLateFee = New System.Windows.Forms.TextBox()
        Me.txtRentalRate = New System.Windows.Forms.TextBox()
        Me.txtSalesPrice = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPrintall = New System.Windows.Forms.Button()
        Me.btnAddVideoGame = New System.Windows.Forms.Button()
        Me.cboxRating = New System.Windows.Forms.ComboBox()
        Me.cboxCategories = New System.Windows.Forms.ComboBox()
        Me.cboxSystems = New System.Windows.Forms.ComboBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbYes = New System.Windows.Forms.CheckBox()
        Me.cbNo = New System.Windows.Forms.CheckBox()
        Me.gbAvailibility = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbAvailibility.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVideoList
        '
        Me.btnVideoList.Location = New System.Drawing.Point(543, 285)
        Me.btnVideoList.Name = "btnVideoList"
        Me.btnVideoList.Size = New System.Drawing.Size(126, 35)
        Me.btnVideoList.TabIndex = 111
        Me.btnVideoList.Text = "Video List"
        Me.btnVideoList.UseVisualStyleBackColor = True
        '
        'lstVideo
        '
        Me.lstVideo.FormattingEnabled = True
        Me.lstVideo.Location = New System.Drawing.Point(382, 41)
        Me.lstVideo.Name = "lstVideo"
        Me.lstVideo.Size = New System.Drawing.Size(437, 238)
        Me.lstVideo.TabIndex = 110
        '
        'txtLateFee
        '
        Me.txtLateFee.Location = New System.Drawing.Point(86, 202)
        Me.txtLateFee.Name = "txtLateFee"
        Me.txtLateFee.Size = New System.Drawing.Size(145, 20)
        Me.txtLateFee.TabIndex = 107
        '
        'txtRentalRate
        '
        Me.txtRentalRate.Location = New System.Drawing.Point(86, 177)
        Me.txtRentalRate.Name = "txtRentalRate"
        Me.txtRentalRate.Size = New System.Drawing.Size(145, 20)
        Me.txtRentalRate.TabIndex = 106
        '
        'txtSalesPrice
        '
        Me.txtSalesPrice.Location = New System.Drawing.Point(86, 148)
        Me.txtSalesPrice.Name = "txtSalesPrice"
        Me.txtSalesPrice.Size = New System.Drawing.Size(145, 20)
        Me.txtSalesPrice.TabIndex = 105
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(86, 38)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(145, 20)
        Me.txtID.TabIndex = 102
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(86, 90)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(145, 20)
        Me.txtDescription.TabIndex = 104
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(86, 64)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(145, 20)
        Me.txtTitle.TabIndex = 103
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(246, 154)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 99
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(246, 125)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 98
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(246, 96)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 97
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(246, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 95
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(246, 244)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 101
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPrintall
        '
        Me.btnPrintall.Location = New System.Drawing.Point(246, 183)
        Me.btnPrintall.Name = "btnPrintall"
        Me.btnPrintall.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintall.TabIndex = 100
        Me.btnPrintall.Text = "Print All"
        Me.btnPrintall.UseVisualStyleBackColor = True
        '
        'btnAddVideoGame
        '
        Me.btnAddVideoGame.Location = New System.Drawing.Point(246, 67)
        Me.btnAddVideoGame.Name = "btnAddVideoGame"
        Me.btnAddVideoGame.Size = New System.Drawing.Size(75, 23)
        Me.btnAddVideoGame.TabIndex = 96
        Me.btnAddVideoGame.Text = "Add"
        Me.btnAddVideoGame.UseVisualStyleBackColor = True
        '
        'cboxRating
        '
        Me.cboxRating.AutoCompleteCustomSource.AddRange(New String() {"G", "PG", "PG_13", "NC_17", "R", "None"})
        Me.cboxRating.FormattingEnabled = True
        Me.cboxRating.Items.AddRange(New Object() {"G", "PG", "PG_13", "NC_17", "R", "None"})
        Me.cboxRating.Location = New System.Drawing.Point(86, 116)
        Me.cboxRating.Name = "cboxRating"
        Me.cboxRating.Size = New System.Drawing.Size(145, 21)
        Me.cboxRating.TabIndex = 113
        '
        'cboxCategories
        '
        Me.cboxCategories.AutoCompleteCustomSource.AddRange(New String() {"Action", "Roleplaying", "Shooting", "Fighting", "Racing", "Sports", "Strategy", "Horror", "Flight_Simulators", "Online", "Rhythm", "None"})
        Me.cboxCategories.FormattingEnabled = True
        Me.cboxCategories.Items.AddRange(New Object() {"Action", "Role_Playing", "Shooting", "Fighting", "Racing", "Sports", "Strategy", "Horror", "Flight_Simulators", "Online", "Rhythm", "None"})
        Me.cboxCategories.Location = New System.Drawing.Point(86, 228)
        Me.cboxCategories.Name = "cboxCategories"
        Me.cboxCategories.Size = New System.Drawing.Size(145, 21)
        Me.cboxCategories.TabIndex = 114
        '
        'cboxSystems
        '
        Me.cboxSystems.AutoCompleteCustomSource.AddRange(New String() {"XBox", "XBox_360", "PS3", "PS2", "GameCube", "DS", "Wii", "PC", "None"})
        Me.cboxSystems.FormattingEnabled = True
        Me.cboxSystems.Items.AddRange(New Object() {"XBox", "XBox_360", "PS3", "PS2", "GameCube", "DS", "Wii", "PC", "None"})
        Me.cboxSystems.Location = New System.Drawing.Point(86, 258)
        Me.cboxSystems.Name = "cboxSystems"
        Me.cboxSystems.Size = New System.Drawing.Size(145, 21)
        Me.cboxSystems.TabIndex = 115
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(246, 211)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 27)
        Me.btnClear.TabIndex = 116
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Is this video game available?"
        '
        'cbYes
        '
        Me.cbYes.AutoSize = True
        Me.cbYes.Location = New System.Drawing.Point(21, 24)
        Me.cbYes.Name = "cbYes"
        Me.cbYes.Size = New System.Drawing.Size(44, 17)
        Me.cbYes.TabIndex = 118
        Me.cbYes.Text = "Yes"
        Me.cbYes.UseVisualStyleBackColor = True
        '
        'cbNo
        '
        Me.cbNo.AutoSize = True
        Me.cbNo.Location = New System.Drawing.Point(71, 24)
        Me.cbNo.Name = "cbNo"
        Me.cbNo.Size = New System.Drawing.Size(40, 17)
        Me.cbNo.TabIndex = 119
        Me.cbNo.Text = "No"
        Me.cbNo.UseVisualStyleBackColor = True
        '
        'gbAvailibility
        '
        Me.gbAvailibility.Controls.Add(Me.cbYes)
        Me.gbAvailibility.Controls.Add(Me.cbNo)
        Me.gbAvailibility.Location = New System.Drawing.Point(86, 318)
        Me.gbAvailibility.Name = "gbAvailibility"
        Me.gbAvailibility.Size = New System.Drawing.Size(140, 58)
        Me.gbAvailibility.TabIndex = 120
        Me.gbAvailibility.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Game ID:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Title:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Description:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Rating:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Sales Price:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Rental Rate:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "Late Fee:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Category:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(36, 266)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Format:"
        '
        'VideoGameManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 388)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbAvailibility)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboxSystems)
        Me.Controls.Add(Me.cboxCategories)
        Me.Controls.Add(Me.cboxRating)
        Me.Controls.Add(Me.btnVideoList)
        Me.Controls.Add(Me.lstVideo)
        Me.Controls.Add(Me.txtLateFee)
        Me.Controls.Add(Me.txtRentalRate)
        Me.Controls.Add(Me.txtSalesPrice)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrintall)
        Me.Controls.Add(Me.btnAddVideoGame)
        Me.Name = "VideoGameManagement"
        Me.Text = "VideoGameManagement"
        Me.gbAvailibility.ResumeLayout(False)
        Me.gbAvailibility.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVideoList As System.Windows.Forms.Button
    Friend WithEvents lstVideo As System.Windows.Forms.ListBox
    Friend WithEvents txtLateFee As System.Windows.Forms.TextBox
    Friend WithEvents txtRentalRate As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrintall As System.Windows.Forms.Button
    Friend WithEvents btnAddVideoGame As System.Windows.Forms.Button
    Friend WithEvents cboxRating As System.Windows.Forms.ComboBox
    Friend WithEvents cboxCategories As System.Windows.Forms.ComboBox
    Friend WithEvents cboxSystems As System.Windows.Forms.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbYes As System.Windows.Forms.CheckBox
    Friend WithEvents cbNo As System.Windows.Forms.CheckBox
    Friend WithEvents gbAvailibility As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
