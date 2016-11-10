<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoPointOfSales
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
        Me.btn_Rent = New System.Windows.Forms.Button()
        Me.btn_Return = New System.Windows.Forms.Button()
        Me.btn_CustomerInformation = New System.Windows.Forms.Button()
        Me.btn_CustomerRegistration = New System.Windows.Forms.Button()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Rent
        '
        Me.btn_Rent.Location = New System.Drawing.Point(49, 31)
        Me.btn_Rent.Name = "btn_Rent"
        Me.btn_Rent.Size = New System.Drawing.Size(141, 77)
        Me.btn_Rent.TabIndex = 0
        Me.btn_Rent.Text = "Rent"
        Me.btn_Rent.UseVisualStyleBackColor = True
        '
        'btn_Return
        '
        Me.btn_Return.Location = New System.Drawing.Point(49, 129)
        Me.btn_Return.Name = "btn_Return"
        Me.btn_Return.Size = New System.Drawing.Size(141, 77)
        Me.btn_Return.TabIndex = 1
        Me.btn_Return.Text = "Return"
        Me.btn_Return.UseVisualStyleBackColor = True
        '
        'btn_CustomerInformation
        '
        Me.btn_CustomerInformation.Location = New System.Drawing.Point(215, 31)
        Me.btn_CustomerInformation.Name = "btn_CustomerInformation"
        Me.btn_CustomerInformation.Size = New System.Drawing.Size(141, 77)
        Me.btn_CustomerInformation.TabIndex = 2
        Me.btn_CustomerInformation.Text = "Customer Information"
        Me.btn_CustomerInformation.UseVisualStyleBackColor = True
        '
        'btn_CustomerRegistration
        '
        Me.btn_CustomerRegistration.Location = New System.Drawing.Point(215, 129)
        Me.btn_CustomerRegistration.Name = "btn_CustomerRegistration"
        Me.btn_CustomerRegistration.Size = New System.Drawing.Size(141, 77)
        Me.btn_CustomerRegistration.TabIndex = 3
        Me.btn_CustomerRegistration.Text = "Customer Registration"
        Me.btn_CustomerRegistration.UseVisualStyleBackColor = True
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(128, 226)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(141, 77)
        Me.btn_Exit.TabIndex = 4
        Me.btn_Exit.Text = "Exit"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'VideoPointOfSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 360)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.btn_CustomerRegistration)
        Me.Controls.Add(Me.btn_CustomerInformation)
        Me.Controls.Add(Me.btn_Return)
        Me.Controls.Add(Me.btn_Rent)
        Me.Name = "VideoPointOfSales"
        Me.Text = "Video PointOfSales"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Rent As System.Windows.Forms.Button
    Friend WithEvents btn_Return As System.Windows.Forms.Button
    Friend WithEvents btn_CustomerInformation As System.Windows.Forms.Button
    Friend WithEvents btn_CustomerRegistration As System.Windows.Forms.Button
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
End Class
