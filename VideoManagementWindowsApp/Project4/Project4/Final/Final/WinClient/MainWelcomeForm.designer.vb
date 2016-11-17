<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWelcomeForm
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
        Me.btnbackend = New System.Windows.Forms.Button()
        Me.btnadminportal = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.VideoPOS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnbackend
        '
        Me.btnbackend.Location = New System.Drawing.Point(26, 23)
        Me.btnbackend.Name = "btnbackend"
        Me.btnbackend.Size = New System.Drawing.Size(100, 61)
        Me.btnbackend.TabIndex = 0
        Me.btnbackend.Text = "Back End"
        Me.btnbackend.UseVisualStyleBackColor = True
        '
        'btnadminportal
        '
        Me.btnadminportal.Location = New System.Drawing.Point(26, 100)
        Me.btnadminportal.Name = "btnadminportal"
        Me.btnadminportal.Size = New System.Drawing.Size(100, 61)
        Me.btnadminportal.TabIndex = 1
        Me.btnadminportal.Text = "Admin Portal"
        Me.btnadminportal.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(148, 100)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 61)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'VideoPOS
        '
        Me.VideoPOS.Location = New System.Drawing.Point(148, 23)
        Me.VideoPOS.Name = "VideoPOS"
        Me.VideoPOS.Size = New System.Drawing.Size(100, 61)
        Me.VideoPOS.TabIndex = 3
        Me.VideoPOS.Text = "Video POS"
        Me.VideoPOS.UseVisualStyleBackColor = True
        '
        'MainWelcomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 186)
        Me.Controls.Add(Me.VideoPOS)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnadminportal)
        Me.Controls.Add(Me.btnbackend)
        Me.Name = "MainWelcomeForm"
        Me.Text = "MainWelcomeForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnbackend As System.Windows.Forms.Button
    Friend WithEvents btnadminportal As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents VideoPOS As System.Windows.Forms.Button
End Class
