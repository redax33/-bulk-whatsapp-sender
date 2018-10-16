Public Class FrmManualImports
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmManualImports_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim t As New FrmMain

        Try
            Dim li As ListViewItem
            Dim Number As String
            Dim Numbers() As String = Split(TxtNumbers.Text, vbNewLine)
            For Each Number In Numbers
                If ValidateMobileNumber(Number).IsValid Then
                    li = New ListViewItem
                    li.Tag = FrmMain.LstNumbers.Items.Count + 1
                    li.Text = ValidateMobileNumber(Number).MobileNumber
                    li.SubItems.Add("Pending")
                    li.ImageIndex = 0

                    FrmMain.LstNumbers.Items.Add(li)
                End If

                Application.DoEvents()
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, ApplicationTitle)
        End Try
        Me.Close()

    End Sub
End Class