Public Class FrmImportFromFiles
    Private Sub FrmImportFromFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnOpenDialog_Click(sender As Object, e As EventArgs) Handles BtnOpenDialog.Click
        OpenFileDlg.Filter = "Text Files|*.txt|Comma-separated values files|*.csv"
        If OpenFileDlg.ShowDialog = DialogResult.OK Then
            TxtFileName.Text = OpenFileDlg.FileName
            Try
                Dim _streamReader As New IO.StreamReader(OpenFileDlg.FileName)
                Dim _NumbersList As String = _streamReader.ReadToEnd()
                Dim _Numbers() As String = Split(_NumbersList, vbNewLine)
                Dim Number As String
                Dim CountInValid As Long = 0
                Dim CountDuplicated As Long = 0
                Dim CountTotal As Long = 0

                LstNumbers.Items.Clear()
                For Each Number In _Numbers
                    If ValidateMobileNumber(Number).IsValid Then
                        If Not LstNumbers.Items.Contains(ValidateMobileNumber(Number).MobileNumber) Then
                            LstNumbers.Items.Add(ValidateMobileNumber(Number).MobileNumber)
                            CountTotal = CountTotal + 1
                        Else
                            CountDuplicated = CountDuplicated + 1
                        End If
                    Else
                        CountInValid = CountInValid + 1
                    End If
                Next
                LblTotalNumbers.Text = "Total Numbers:" & CountTotal
                LblInvalidNumbers.Text = "Total Invalid:" & CountInValid
                LblDuplicatedNumber.Text = "Total Duplicated:" & CountDuplicated

                _streamReader.Close()
                _streamReader.Dispose()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, ApplicationTitle)
                Exit Sub
            End Try




        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Try


            Dim li As ListViewItem
            Dim Number As String
            For Each Number In LstNumbers.Items
                li = New ListViewItem
                li.Tag = FrmMain.LstNumbers.Items.Count + 1
                li.Text = Number
                li.SubItems.Add("Pending")
                li.ImageIndex = 0
                FrmMain.LstNumbers.Items.Add(li)
                Application.DoEvents()
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, ApplicationTitle)
        End Try
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmImportFromFiles_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class