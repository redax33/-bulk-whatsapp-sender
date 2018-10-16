<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportFromFiles
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
        Me.TxtFileName = New System.Windows.Forms.TextBox()
        Me.BtnOpenDialog = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LblInffo = New System.Windows.Forms.Label()
        Me.LstNumbers = New System.Windows.Forms.ListBox()
        Me.OpenFileDlg = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblImportFiles = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblInvalidNumbers = New System.Windows.Forms.Label()
        Me.LblDuplicatedNumber = New System.Windows.Forms.Label()
        Me.LblTotalNumbers = New System.Windows.Forms.Label()
        Me.Sep1 = New System.Windows.Forms.Label()
        Me.sep2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtFileName
        '
        Me.TxtFileName.Location = New System.Drawing.Point(12, 23)
        Me.TxtFileName.Name = "TxtFileName"
        Me.TxtFileName.ReadOnly = True
        Me.TxtFileName.Size = New System.Drawing.Size(347, 20)
        Me.TxtFileName.TabIndex = 0
        '
        'BtnOpenDialog
        '
        Me.BtnOpenDialog.Location = New System.Drawing.Point(365, 21)
        Me.BtnOpenDialog.Name = "BtnOpenDialog"
        Me.BtnOpenDialog.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpenDialog.TabIndex = 1
        Me.BtnOpenDialog.Text = "Browse"
        Me.BtnOpenDialog.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Location = New System.Drawing.Point(363, 269)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(75, 23)
        Me.BtnImport.TabIndex = 3
        Me.BtnImport.Text = "Import"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(282, 269)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'LblInffo
        '
        Me.LblInffo.Location = New System.Drawing.Point(3, 2)
        Me.LblInffo.Name = "LblInffo"
        Me.LblInffo.Size = New System.Drawing.Size(221, 45)
        Me.LblInffo.TabIndex = 5
        Me.LblInffo.Text = "File must be in txt or csv format with  one number  per line , and mobile number " &
    "must start with +"
        '
        'LstNumbers
        '
        Me.LstNumbers.FormattingEnabled = True
        Me.LstNumbers.Location = New System.Drawing.Point(12, 49)
        Me.LstNumbers.Name = "LstNumbers"
        Me.LstNumbers.Size = New System.Drawing.Size(194, 251)
        Me.LstNumbers.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblInffo)
        Me.Panel1.Location = New System.Drawing.Point(211, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(227, 48)
        Me.Panel1.TabIndex = 7
        '
        'LblImportFiles
        '
        Me.LblImportFiles.AutoSize = True
        Me.LblImportFiles.Location = New System.Drawing.Point(9, 7)
        Me.LblImportFiles.Name = "LblImportFiles"
        Me.LblImportFiles.Size = New System.Drawing.Size(96, 13)
        Me.LblImportFiles.TabIndex = 6
        Me.LblImportFiles.Text = "Select file to import"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LblTotalNumbers)
        Me.Panel2.Controls.Add(Me.LblDuplicatedNumber)
        Me.Panel2.Controls.Add(Me.LblInvalidNumbers)
        Me.Panel2.Location = New System.Drawing.Point(212, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(226, 55)
        Me.Panel2.TabIndex = 8
        '
        'LblInvalidNumbers
        '
        Me.LblInvalidNumbers.AutoSize = True
        Me.LblInvalidNumbers.Location = New System.Drawing.Point(2, 6)
        Me.LblInvalidNumbers.Name = "LblInvalidNumbers"
        Me.LblInvalidNumbers.Size = New System.Drawing.Size(74, 13)
        Me.LblInvalidNumbers.TabIndex = 0
        Me.LblInvalidNumbers.Text = "Total Invalid:0"
        '
        'LblDuplicatedNumber
        '
        Me.LblDuplicatedNumber.AutoSize = True
        Me.LblDuplicatedNumber.Location = New System.Drawing.Point(2, 22)
        Me.LblDuplicatedNumber.Name = "LblDuplicatedNumber"
        Me.LblDuplicatedNumber.Size = New System.Drawing.Size(94, 13)
        Me.LblDuplicatedNumber.TabIndex = 1
        Me.LblDuplicatedNumber.Text = "Total Duplicated:0"
        '
        'LblTotalNumbers
        '
        Me.LblTotalNumbers.AutoSize = True
        Me.LblTotalNumbers.Location = New System.Drawing.Point(2, 37)
        Me.LblTotalNumbers.Name = "LblTotalNumbers"
        Me.LblTotalNumbers.Size = New System.Drawing.Size(85, 13)
        Me.LblTotalNumbers.TabIndex = 2
        Me.LblTotalNumbers.Text = "Total Numbers:0"
        '
        'Sep1
        '
        Me.Sep1.BackColor = System.Drawing.Color.Black
        Me.Sep1.Location = New System.Drawing.Point(216, 262)
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Size = New System.Drawing.Size(221, 1)
        Me.Sep1.TabIndex = 9
        '
        'sep2
        '
        Me.sep2.BackColor = System.Drawing.Color.Black
        Me.sep2.Location = New System.Drawing.Point(214, 100)
        Me.sep2.Name = "sep2"
        Me.sep2.Size = New System.Drawing.Size(221, 1)
        Me.sep2.TabIndex = 10
        '
        'FrmImportFromFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(452, 309)
        Me.Controls.Add(Me.sep2)
        Me.Controls.Add(Me.Sep1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblImportFiles)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LstNumbers)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnImport)
        Me.Controls.Add(Me.BtnOpenDialog)
        Me.Controls.Add(Me.TxtFileName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImportFromFiles"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import From File"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtFileName As TextBox
    Friend WithEvents BtnOpenDialog As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents LblInffo As Label
    Friend WithEvents LstNumbers As ListBox
    Friend WithEvents OpenFileDlg As OpenFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblImportFiles As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblTotalNumbers As Label
    Friend WithEvents LblDuplicatedNumber As Label
    Friend WithEvents LblInvalidNumbers As Label
    Friend WithEvents Sep1 As Label
    Friend WithEvents sep2 As Label
End Class
