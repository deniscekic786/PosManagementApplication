<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DVD_Management
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbAvailibility = New System.Windows.Forms.GroupBox()
        Me.cbYes = New System.Windows.Forms.CheckBox()
        Me.cbNo = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cboxSystems = New System.Windows.Forms.ComboBox()
        Me.cboxCategories = New System.Windows.Forms.ComboBox()
        Me.cboxRating = New System.Windows.Forms.ComboBox()
        Me.btnDvdList = New System.Windows.Forms.Button()
        Me.lstDVD = New System.Windows.Forms.ListBox()
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbAvailibility.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(-131, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "SSN:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-131, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Email:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-177, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Phone Number:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(-144, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Address:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-126, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-149, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Birthdate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-157, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "ID Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-157, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Last Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-157, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "First Name:"
        '
        'gbAvailibility
        '
        Me.gbAvailibility.Controls.Add(Me.cbYes)
        Me.gbAvailibility.Controls.Add(Me.cbNo)
        Me.gbAvailibility.Location = New System.Drawing.Point(76, 333)
        Me.gbAvailibility.Name = "gbAvailibility"
        Me.gbAvailibility.Size = New System.Drawing.Size(140, 58)
        Me.gbAvailibility.TabIndex = 141
        Me.gbAvailibility.TabStop = False
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(94, 317)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "Is this DVD available?"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(236, 226)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 27)
        Me.btnClear.TabIndex = 139
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'cboxSystems
        '
        Me.cboxSystems.AutoCompleteCustomSource.AddRange(New String() {"XBox", "XBox_360", "PS3", "PS2", "GameCube", "DS", "Wii", "PC", "None"})
        Me.cboxSystems.FormattingEnabled = True
        Me.cboxSystems.Items.AddRange(New Object() {"DVD", "HD_DVD", "BLU_RAY", "DISC", "None"})
        Me.cboxSystems.Location = New System.Drawing.Point(76, 273)
        Me.cboxSystems.Name = "cboxSystems"
        Me.cboxSystems.Size = New System.Drawing.Size(145, 21)
        Me.cboxSystems.TabIndex = 138
        '
        'cboxCategories
        '
        Me.cboxCategories.AutoCompleteCustomSource.AddRange(New String() {"Action", "Roleplaying", "Shooting", "Fighting", "Racing", "Sports", "Strategy", "Horror", "Flight_Simulators", "Online", "Rhythm", "None"})
        Me.cboxCategories.FormattingEnabled = True
        Me.cboxCategories.Items.AddRange(New Object() {"Action_Adventure", "Drama", "Family_Kids", "Horror", "Sci_Fi_Fantasy", "Music", "Sports", "Romance", "Comedy", "Western", "None"})
        Me.cboxCategories.Location = New System.Drawing.Point(76, 243)
        Me.cboxCategories.Name = "cboxCategories"
        Me.cboxCategories.Size = New System.Drawing.Size(145, 21)
        Me.cboxCategories.TabIndex = 137
        '
        'cboxRating
        '
        Me.cboxRating.AutoCompleteCustomSource.AddRange(New String() {"G", "PG", "PG_13", "NC_17", "R", "None"})
        Me.cboxRating.FormattingEnabled = True
        Me.cboxRating.Items.AddRange(New Object() {"G", "PG", "PG_13", "NC_17", "R", "None"})
        Me.cboxRating.Location = New System.Drawing.Point(76, 131)
        Me.cboxRating.Name = "cboxRating"
        Me.cboxRating.Size = New System.Drawing.Size(145, 21)
        Me.cboxRating.TabIndex = 136
        '
        'btnDvdList
        '
        Me.btnDvdList.Location = New System.Drawing.Point(533, 300)
        Me.btnDvdList.Name = "btnDvdList"
        Me.btnDvdList.Size = New System.Drawing.Size(126, 35)
        Me.btnDvdList.TabIndex = 135
        Me.btnDvdList.Text = "DVD List"
        Me.btnDvdList.UseVisualStyleBackColor = True
        '
        'lstDVD
        '
        Me.lstDVD.FormattingEnabled = True
        Me.lstDVD.Location = New System.Drawing.Point(372, 56)
        Me.lstDVD.Name = "lstDVD"
        Me.lstDVD.Size = New System.Drawing.Size(437, 238)
        Me.lstDVD.TabIndex = 134
        '
        'txtLateFee
        '
        Me.txtLateFee.Location = New System.Drawing.Point(76, 217)
        Me.txtLateFee.Name = "txtLateFee"
        Me.txtLateFee.Size = New System.Drawing.Size(145, 20)
        Me.txtLateFee.TabIndex = 133
        '
        'txtRentalRate
        '
        Me.txtRentalRate.Location = New System.Drawing.Point(76, 192)
        Me.txtRentalRate.Name = "txtRentalRate"
        Me.txtRentalRate.Size = New System.Drawing.Size(145, 20)
        Me.txtRentalRate.TabIndex = 132
        '
        'txtSalesPrice
        '
        Me.txtSalesPrice.Location = New System.Drawing.Point(76, 163)
        Me.txtSalesPrice.Name = "txtSalesPrice"
        Me.txtSalesPrice.Size = New System.Drawing.Size(145, 20)
        Me.txtSalesPrice.TabIndex = 131
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(76, 53)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(145, 20)
        Me.txtID.TabIndex = 128
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(76, 105)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(145, 20)
        Me.txtDescription.TabIndex = 130
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(76, 79)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(145, 20)
        Me.txtTitle.TabIndex = 129
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(236, 169)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 125
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(236, 140)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 124
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(236, 111)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 123
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(236, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 121
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(236, 259)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 127
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPrintall
        '
        Me.btnPrintall.Location = New System.Drawing.Point(236, 198)
        Me.btnPrintall.Name = "btnPrintall"
        Me.btnPrintall.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintall.TabIndex = 126
        Me.btnPrintall.Text = "Print All"
        Me.btnPrintall.UseVisualStyleBackColor = True
        '
        'btnAddVideoGame
        '
        Me.btnAddVideoGame.Location = New System.Drawing.Point(236, 82)
        Me.btnAddVideoGame.Name = "btnAddVideoGame"
        Me.btnAddVideoGame.Size = New System.Drawing.Size(75, 23)
        Me.btnAddVideoGame.TabIndex = 122
        Me.btnAddVideoGame.Text = "Add"
        Me.btnAddVideoGame.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 150
        Me.Label11.Text = "Format:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 243)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Category:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 217)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "Late Fee:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 147
        Me.Label14.Text = "Rental Rate:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "Sales Price:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 145
        Me.Label16.Text = "Rating:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 144
        Me.Label17.Text = "Description:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(40, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 143
        Me.Label18.Text = "Title:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 142
        Me.Label19.Text = "DVD ID:"
        '
        'DVD_Management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 444)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.gbAvailibility)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboxSystems)
        Me.Controls.Add(Me.cboxCategories)
        Me.Controls.Add(Me.cboxRating)
        Me.Controls.Add(Me.btnDvdList)
        Me.Controls.Add(Me.lstDVD)
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
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DVD_Management"
        Me.Text = "DVD_Management"
        Me.gbAvailibility.ResumeLayout(False)
        Me.gbAvailibility.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbAvailibility As System.Windows.Forms.GroupBox
    Friend WithEvents cbYes As System.Windows.Forms.CheckBox
    Friend WithEvents cbNo As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cboxSystems As System.Windows.Forms.ComboBox
    Friend WithEvents cboxCategories As System.Windows.Forms.ComboBox
    Friend WithEvents cboxRating As System.Windows.Forms.ComboBox
    Friend WithEvents btnDvdList As System.Windows.Forms.Button
    Friend WithEvents lstDVD As System.Windows.Forms.ListBox
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
