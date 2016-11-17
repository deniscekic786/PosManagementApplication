<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeManagement
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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJobtitle = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhonenumber = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPrintall = New System.Windows.Forms.Button()
        Me.btnAddemployee = New System.Windows.Forms.Button()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtBirthdate = New System.Windows.Forms.TextBox()
        Me.txtSSN = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lstEmployees = New System.Windows.Forms.ListBox()
        Me.btnEmpList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(297, 205)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 28
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(297, 147)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(297, 118)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(297, 89)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 24
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(297, 31)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(50, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Job Title:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(66, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Email:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Phone Number:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Address:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Birthdate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "SSN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Last Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "First Name:"
        '
        'txtJobtitle
        '
        Me.txtJobtitle.Location = New System.Drawing.Point(107, 245)
        Me.txtJobtitle.Name = "txtJobtitle"
        Me.txtJobtitle.Size = New System.Drawing.Size(145, 20)
        Me.txtJobtitle.TabIndex = 42
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(107, 219)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(145, 20)
        Me.txtEmail.TabIndex = 40
        '
        'txtPhonenumber
        '
        Me.txtPhonenumber.Location = New System.Drawing.Point(107, 193)
        Me.txtPhonenumber.Name = "txtPhonenumber"
        Me.txtPhonenumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPhonenumber.TabIndex = 39
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(107, 166)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(145, 20)
        Me.txtAddress.TabIndex = 36
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(297, 234)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 29
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPrintall
        '
        Me.btnPrintall.Location = New System.Drawing.Point(297, 176)
        Me.btnPrintall.Name = "btnPrintall"
        Me.btnPrintall.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintall.TabIndex = 27
        Me.btnPrintall.Text = "Print All"
        Me.btnPrintall.UseVisualStyleBackColor = True
        '
        'btnAddemployee
        '
        Me.btnAddemployee.Location = New System.Drawing.Point(297, 60)
        Me.btnAddemployee.Name = "btnAddemployee"
        Me.btnAddemployee.Size = New System.Drawing.Size(75, 23)
        Me.btnAddemployee.TabIndex = 23
        Me.btnAddemployee.Text = "Add"
        Me.btnAddemployee.UseVisualStyleBackColor = True
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(107, 141)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(145, 20)
        Me.txtAge.TabIndex = 34
        '
        'txtBirthdate
        '
        Me.txtBirthdate.Location = New System.Drawing.Point(107, 112)
        Me.txtBirthdate.Name = "txtBirthdate"
        Me.txtBirthdate.Size = New System.Drawing.Size(145, 20)
        Me.txtBirthdate.TabIndex = 33
        '
        'txtSSN
        '
        Me.txtSSN.Location = New System.Drawing.Point(107, 34)
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.Size = New System.Drawing.Size(145, 20)
        Me.txtSSN.TabIndex = 21
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(107, 86)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(145, 20)
        Me.txtLastName.TabIndex = 31
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(107, 60)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(145, 20)
        Me.txtFirstName.TabIndex = 30
        '
        'lstEmployees
        '
        Me.lstEmployees.FormattingEnabled = True
        Me.lstEmployees.Location = New System.Drawing.Point(416, 34)
        Me.lstEmployees.Name = "lstEmployees"
        Me.lstEmployees.Size = New System.Drawing.Size(437, 225)
        Me.lstEmployees.TabIndex = 66
        '
        'btnEmpList
        '
        Me.btnEmpList.Location = New System.Drawing.Point(568, 265)
        Me.btnEmpList.Name = "btnEmpList"
        Me.btnEmpList.Size = New System.Drawing.Size(126, 35)
        Me.btnEmpList.TabIndex = 67
        Me.btnEmpList.Text = "Employee List"
        Me.btnEmpList.UseVisualStyleBackColor = True
        '
        'EmployeeManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 330)
        Me.Controls.Add(Me.btnEmpList)
        Me.Controls.Add(Me.lstEmployees)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtJobtitle)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtPhonenumber)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrintall)
        Me.Controls.Add(Me.btnAddemployee)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtBirthdate)
        Me.Controls.Add(Me.txtSSN)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Name = "EmployeeManagement"
        Me.Text = "EmployeeManagement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtJobtitle As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtPhonenumber As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrintall As System.Windows.Forms.Button
    Friend WithEvents btnAddemployee As System.Windows.Forms.Button
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthdate As System.Windows.Forms.TextBox
    Friend WithEvents txtSSN As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lstEmployees As System.Windows.Forms.ListBox
    Friend WithEvents btnEmpList As System.Windows.Forms.Button
End Class
