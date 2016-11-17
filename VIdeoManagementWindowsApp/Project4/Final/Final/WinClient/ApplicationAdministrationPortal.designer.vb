<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApplicationAdministrationPortal
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
        Me.btnuseraccmngmnt = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnuseraccmngmnt
        '
        Me.btnuseraccmngmnt.Location = New System.Drawing.Point(51, 53)
        Me.btnuseraccmngmnt.Name = "btnuseraccmngmnt"
        Me.btnuseraccmngmnt.Size = New System.Drawing.Size(184, 61)
        Me.btnuseraccmngmnt.TabIndex = 0
        Me.btnuseraccmngmnt.Text = "User Account Management"
        Me.btnuseraccmngmnt.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(51, 129)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(184, 59)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'ApplicationAdministrationPortal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnuseraccmngmnt)
        Me.Name = "ApplicationAdministrationPortal"
        Me.Text = "ApplicationAdministrationPortal"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnuseraccmngmnt As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
End Class
