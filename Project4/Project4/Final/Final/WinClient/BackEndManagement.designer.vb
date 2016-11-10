<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackEndManagement
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
        Me.btnempmngmnt = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.btncustomermanagement = New System.Windows.Forms.Button()
        Me.dvd_management = New System.Windows.Forms.Button()
        Me.video_management = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnempmngmnt
        '
        Me.btnempmngmnt.Location = New System.Drawing.Point(66, 23)
        Me.btnempmngmnt.Name = "btnempmngmnt"
        Me.btnempmngmnt.Size = New System.Drawing.Size(152, 68)
        Me.btnempmngmnt.TabIndex = 0
        Me.btnempmngmnt.Text = "Employee Management"
        Me.btnempmngmnt.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(164, 180)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(152, 68)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btncustomermanagement
        '
        Me.btncustomermanagement.Location = New System.Drawing.Point(66, 97)
        Me.btncustomermanagement.Name = "btncustomermanagement"
        Me.btncustomermanagement.Size = New System.Drawing.Size(152, 68)
        Me.btncustomermanagement.TabIndex = 2
        Me.btncustomermanagement.Text = "Customer Management"
        Me.btncustomermanagement.UseVisualStyleBackColor = True
        '
        'dvd_management
        '
        Me.dvd_management.Location = New System.Drawing.Point(262, 23)
        Me.dvd_management.Name = "dvd_management"
        Me.dvd_management.Size = New System.Drawing.Size(152, 68)
        Me.dvd_management.TabIndex = 3
        Me.dvd_management.Text = "DVD Management"
        Me.dvd_management.UseVisualStyleBackColor = True
        '
        'video_management
        '
        Me.video_management.Location = New System.Drawing.Point(262, 97)
        Me.video_management.Name = "video_management"
        Me.video_management.Size = New System.Drawing.Size(152, 68)
        Me.video_management.TabIndex = 4
        Me.video_management.Text = "Video Management"
        Me.video_management.UseVisualStyleBackColor = True
        '
        'BackEndManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 260)
        Me.Controls.Add(Me.video_management)
        Me.Controls.Add(Me.dvd_management)
        Me.Controls.Add(Me.btncustomermanagement)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnempmngmnt)
        Me.Name = "BackEndManagement"
        Me.Text = "BackEnd"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnempmngmnt As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btncustomermanagement As System.Windows.Forms.Button
    Friend WithEvents dvd_management As System.Windows.Forms.Button
    Friend WithEvents video_management As System.Windows.Forms.Button
End Class
