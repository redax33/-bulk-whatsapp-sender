<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
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
        Me.TrackBarDelay = New System.Windows.Forms.TrackBar()
        Me.CheckBoxDeleteAfterSending = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        CType(Me.TrackBarDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrackBarDelay
        '
        Me.TrackBarDelay.Location = New System.Drawing.Point(6, 19)
        Me.TrackBarDelay.Maximum = 50
        Me.TrackBarDelay.Minimum = 6
        Me.TrackBarDelay.Name = "TrackBarDelay"
        Me.TrackBarDelay.Size = New System.Drawing.Size(354, 45)
        Me.TrackBarDelay.TabIndex = 0
        Me.TrackBarDelay.Value = 6
        '
        'CheckBoxDeleteAfterSending
        '
        Me.CheckBoxDeleteAfterSending.AutoSize = True
        Me.CheckBoxDeleteAfterSending.Location = New System.Drawing.Point(12, 119)
        Me.CheckBoxDeleteAfterSending.Name = "CheckBoxDeleteAfterSending"
        Me.CheckBoxDeleteAfterSending.Size = New System.Drawing.Size(169, 17)
        Me.CheckBoxDeleteAfterSending.TabIndex = 1
        Me.CheckBoxDeleteAfterSending.Text = "Delete message after sending "
        Me.CheckBoxDeleteAfterSending.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TrackBarDelay)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 76)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delay between messages"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(275, 172)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(115, 33)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(154, 172)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(115, 33)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 217)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBoxDeleteAfterSending)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        CType(Me.TrackBarDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TrackBarDelay As TrackBar
    Friend WithEvents CheckBoxDeleteAfterSending As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnOK As Button
    Friend WithEvents BtnCancel As Button
End Class
