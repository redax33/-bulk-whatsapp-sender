Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports System
Imports System.ComponentModel

Public Class FrmMain
    Private Sub FromFilesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromFilesToolStripMenuItem1.Click, FromFileToolStripMenuItemFromFile.Click, MnStrpItemFromFiles.Click, FromFilesToolStripMenuItem.Click
        FrmImportFromFiles.ShowDialog()
        GetCount()
        CalcInfo()
    End Sub
    Private Sub ManualImportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualImportsToolStripMenuItem.Click, ManualImportsToolStripMenuItemManual.Click, MnStrpItemMaunalImports.Click, ManualToolStripMenuItem.Click
        FrmManualImports.ShowDialog()
        GetCount()
        CalcInfo()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click, ClearListToolStripMenuItem.Click
        If LstNumbers.Items.Count = 0 Then
            Exit Sub
        End If
        If MsgBox(Messages.CLEAR_LIST, MsgBoxStyle.Question + MsgBoxStyle.YesNo, ApplicationTitle) = vbYes Then
            LstNumbers.Items.Clear()
        End If
        GetCount()

    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripBtnDeleteNumber.Click, DeleteToolStripMenuItem.Click
        If LstNumbers.SelectedItems.Count > 0 Then
            If MsgBox(Messages.DELETE_NUMBER, MsgBoxStyle.Question + vbYesNo, ApplicationTitle) = vbYes Then

                Dim li As ListViewItem
                For Each li In LstNumbers.SelectedItems
                    LstNumbers.Items.Remove(li)
                Next


            End If
        End If
        GetCount()
    End Sub
    Private Sub ManualImportsToolStripMenuItemManual_DropDownOpening(sender As Object, e As EventArgs) Handles ManualImportsToolStripMenuItemManual.DropDownOpening

    End Sub
    Private Sub MnStrpImports_Opening(sender As Object, e As ComponentModel.CancelEventArgs) Handles MnStrpImports.Opening
        If LstNumbers.SelectedItems.Count > 0 Then
            DeleteToolStripMenuItem.Visible = True
            ToolStripMenuItem11.Visible = True
        Else
            DeleteToolStripMenuItem.Visible = False
            ToolStripMenuItem11.Visible = False
        End If
        If LstNumbers.Items.Count > 0 Then
            ToolStripMenuItem12.Visible = True
            ClearListToolStripMenuItem.Visible = True
        Else
            ToolStripMenuItem12.Visible = False
            ClearListToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub BtnSending_Click(sender As Object, e As EventArgs) Handles BtnSending.Click
        If LstNumbers.Items.Count = 0 Then
            MsgBox(Messages.NO_NUMBERS, vbCritical, ApplicationTitle)
            Exit Sub
        End If

        If TxtMessage.Text.Trim = "" Then
            MsgBox(Messages.NO_MESSAGE, vbCritical, ApplicationTitle)
            Exit Sub
        End If

        If CheckBoxِAddImg.Checked Then
            If TxtImgFile.Text = "" Then
                MsgBox("Please add Image or uncheck the Adding image ", vbInformation, ApplicationTitle)
                Exit Sub
            End If
            IsImg = True
            TxtImg = txtImgText.Text
        Else
            TxtImg = ""
            IsImg = False
        End If

        Select Case BtnSending.Text
            Case "Send"
                BtnSending.Text = "Pause"
                BtnSending.BackColor = Color.FromArgb(224, 129, 5)
                BtnSending.Image = PicPause.Image
                IsPaused = False
                Dim lii As ListViewItem
                For Each lii In LstNumbers.Items
                    lii.ImageIndex = 0
                    lii.SubItems(1).Text = "Pending"
                Next
            Case "Pause"
                BtnSending.Text = "Resume"
                BtnSending.BackColor = Color.FromArgb(43, 151, 206)
                BtnSending.Image = PicResume.Image
                IsPaused = True
                Exit Sub
            Case "Resume"
                BtnSending.Text = "Pause"
                BtnSending.BackColor = Color.FromArgb(224, 129, 5)
                BtnSending.Image = PicPause.Image
                IsPaused = False
                Exit Sub
        End Select
        Application.DoEvents()
        resetListItems()
        TimerStatus.Enabled = True
        CurrentSendingStatus = True
        IsBulkFinish = False
        ToolStripStatusLabel2.Visible = True
        ToolStripProgressBar1.Visible = True
        Button2.Visible = True
        DisableControls()

        Dim li As ListViewItem
        Dim numberstream As String = ""
        For Each li In LstNumbers.Items
            numberstream = numberstream & li.Tag & "|" & li.Text & ","
        Next

        Dim k As New SendingClass
        k.lst = numberstream
        k.Message = TxtMessage.Text
        k.StartSending()
    End Sub

    Private Sub TimerStatus_Tick(sender As Object, e As EventArgs) Handles TimerStatus.Tick
        ToolStripProgressBar1.Value = CurrentPercentage
        Dim li As ListViewItem
        For Each li In LstNumbers.Items
            If li.Tag = CurrentSendingID And li.SubItems(1).Text = "Pending" Then
                li.SubItems(1).Text = "Sent"
                li.ImageIndex = 1
            End If
        Next
        If CurrentLog <> LastLog Then
            LastLog = CurrentLog
            TxtLog.AppendText(CurrentLog)
        End If

        If IsBulkFinish Then
            IsBulkFinish = False
            RestSendButton()
            EnableControls()
            Button2.Visible = False
        End If

        If CurrentSendingStatus = False Then
            RestSendButton()
            EnableControls()
            Button2.Visible = False
            TimerStatus.Enabled = False
            ToolStripStatusLabel2.Visible = False
            ToolStripProgressBar1.Visible = False
        End If

        If CheckBoxِAddImg.Checked Then
            If TxtImgFile.Text <> "" Then
                Clipboard.SetImage(Image.FromFile(TxtImgFile.Text))
            End If
        End If
    End Sub
    Private Sub RestSendButton()
        BtnSending.Text = "Send"
        BtnSending.BackColor = Color.FromArgb(46, 156, 12)
        BtnSending.Image = PicSend.Image
    End Sub
    Private Sub DisableControls()
        ToolStripButtonNewBulk.Enabled = False
        FromFilesToolStripMenuItem1.Enabled = False
        ManualImportsToolStripMenuItem.Enabled = False
        FromFileToolStripMenuItemFromFile.Enabled = False
        ManualImportsToolStripMenuItemManual.Enabled = False
        ToolStripBtnDeleteNumber.Enabled = False
        ToolStripButton3.Enabled = False
        NewBulkToolStripMenuItem.Enabled = False
        OpenBulkToolStripMenuItem.Enabled = False
        SaveBulkToolStripMenuItem.Enabled = False
        SaveBulkAsToolStripMenuItem.Enabled = False
        FromFilesToolStripMenuItem.Enabled = False
        ManualToolStripMenuItem.Enabled = False
        ClearNumbersListToolStripMenuItem.Enabled = False
        ClearMessageToolStripMenuItem.Enabled = False
        TxtMessage.Enabled = False
        SendingOptionsToolStripMenuItem.Enabled = False


        MnStrpImports.Enabled = False

        TxtImgFile.Enabled = False
        txtImgText.Enabled = False
        BtnImgBrowse.Enabled = False
        CheckBoxِAddImg.Enabled = False
    End Sub
    Private Sub EnableControls()
        ToolStripButtonNewBulk.Enabled = True
        FromFilesToolStripMenuItem1.Enabled = True
        ManualImportsToolStripMenuItem.Enabled = True
        MnStrpImports.Enabled = True
        FromFileToolStripMenuItemFromFile.Enabled = True
        ManualImportsToolStripMenuItemManual.Enabled = True
        ToolStripBtnDeleteNumber.Enabled = True
        ToolStripButton3.Enabled = True
        NewBulkToolStripMenuItem.Enabled = True
        OpenBulkToolStripMenuItem.Enabled = True
        SaveBulkToolStripMenuItem.Enabled = True
        SaveBulkAsToolStripMenuItem.Enabled = True
        FromFilesToolStripMenuItem.Enabled = True
        ManualToolStripMenuItem.Enabled = True
        ClearNumbersListToolStripMenuItem.Enabled = True
        ClearMessageToolStripMenuItem.Enabled = True
        TxtMessage.Enabled = True
        SendingOptionsToolStripMenuItem.Enabled = True
        TxtImgFile.Enabled = True
        txtImgText.Enabled = True
        BtnImgBrowse.Enabled = True
        CheckBoxِAddImg.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox(Messages.STOP_BULK, vbYesNo + vbQuestion, ApplicationTitle) = vbYes Then
            StopCampaign = True
            EnableControls()
            Button2.Visible = False
            RestSendButton()
        End If
    End Sub



    Private Sub ExportNumbersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportNumbersToolStripMenuItem.Click
        If LstNumbers.Items.Count > 0 Then
            SaveFileDialog1.Filter = "*.txt|*.txt"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim li As ListViewItem
                Dim t As String = ""
                For Each li In LstNumbers.Items
                    t = t & li.Text & vbNewLine
                Next
                Dim sw As New IO.StreamWriter(SaveFileDialog1.FileName)
                sw.Write(t)
                sw.Close()
                sw.Dispose()
            End If


        End If


    End Sub

    Private Sub SaveMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMessageToolStripMenuItem.Click
        If TxtMessage.Text.Trim <> "" Then
            SaveFileDialog1.Filter = "*.txt|*.txt"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim sw As New IO.StreamWriter(SaveFileDialog1.FileName)
                sw.Write(TxtMessage.Text)
                sw.Close()
                sw.Dispose()
            End If
        End If
    End Sub

    Private Sub ImportMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMessageToolStripMenuItem.Click
        Dim da As New OpenFileDialog
        da.Filter = "*.txt|*.txt"
        If da.ShowDialog = DialogResult.OK Then
            Try
                Dim sr As New IO.StreamReader(da.FileName)
                TxtMessage.Text = sr.ReadToEnd
                sr.Close()
                sr.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, ApplicationTitle)
            End Try

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click, ToolStripButton6.Click
        If MsgBox("Are you sure you want to close application?", vbYesNo + vbQuestion, ApplicationTitle) = vbYes Then
            End
        End If

    End Sub

    Private Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        e.Cancel = 1
        If MsgBox("Are you sure you want to close application?", vbYesNo + vbQuestion, ApplicationTitle) = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub NewBulkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewBulkToolStripMenuItem.Click, ToolStripButtonNewBulk.Click
        If MsgBox("Are you sure you want create new bulk?", vbYesNo + vbQuestion, ApplicationTitle) = vbYes Then
            LstNumbers.Items.Clear()
            TxtMessage.Text = ""
            TxtLog.Text = ""
            BulkFileName = ""
        End If
    End Sub

    Private Sub SaveBulkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBulkToolStripMenuItem.Click
        If BulkFileName = "" Then
            Dim da As New SaveFileDialog
            da.Filter = "*.blk|*.blk"
            If da.ShowDialog = DialogResult.OK Then
                BulkFileName = da.FileName
                SaveBulk(BulkFileName)
            Else
                Exit Sub
            End If
        Else
            SaveBulk(BulkFileName)
        End If

    End Sub
    Private Sub SaveBulk(ByVal FileName As String)
        Dim ds As New DataSet
        Dim NumbersTable As New DataTable
        NumbersTable.Columns.Add("Numbers")
        NumbersTable.TableName = "NumbersList"
        Dim li As ListViewItem
        Dim dr As DataRow
        For Each li In LstNumbers.Items
            dr = NumbersTable.NewRow()
            dr("Numbers") = li.Text
            NumbersTable.Rows.Add(dr)
        Next
        ds.Tables.Add(NumbersTable)
        Dim MessageTable As New DataTable
        MessageTable.TableName = "MessageBody"
        MessageTable.Columns.Add("Message")
        dr = MessageTable.NewRow
        dr("Message") = TxtMessage.Text
        MessageTable.Rows.Add(dr)
        ds.Tables.Add(MessageTable)
        ds.DataSetName = "Bulk"
        ds.WriteXml(FileName)
    End Sub

    Private Sub SaveBulkAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBulkAsToolStripMenuItem.Click

        Dim da As New SaveFileDialog
            da.Filter = "*.blk|*.blk"
            If da.ShowDialog = DialogResult.OK Then
                BulkFileName = da.FileName
                SaveBulk(BulkFileName)
            Else
                Exit Sub
            End If

    End Sub

    Private Sub OpenBulkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenBulkToolStripMenuItem.Click
        On Error Resume Next
        Dim da As New OpenFileDialog
        da.Filter = "*.blk|*.blk"
        If da.ShowDialog = DialogResult.OK Then
            LstNumbers.Items.Clear()
            TxtMessage.Text = ""
            TxtLog.Text = ""
            Dim ds As New DataSet
            ds.ReadXml(da.FileName)
            BulkFileName = da.FileName
            Dim li As ListViewItem
            Dim dr As DataRow
            Dim i As Long
            For Each dr In ds.Tables("NumbersList").Rows
                li = New ListViewItem
                li.Tag = i
                li.Text = dr("Numbers")
                li.SubItems.Add("Pending")
                LstNumbers.Items.Add(li)
                i = i + 1

            Next
            dr = ds.Tables("MessageBody").Rows(0)
            TxtMessage.Text = dr("Message")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ClearLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearLogToolStripMenuItem.Click
        TxtLog.Text = ""
    End Sub

    Private Sub LstNumbers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstNumbers.SelectedIndexChanged

    End Sub
    Public Sub GetCount()
        ToolStripStatusLabel1.Text = "Total Numbers:" & LstNumbers.Items.Count
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetCount()
    End Sub



    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click, ToolStripButton5.Click
        MsgBox("Bulk Whatsapp Sender " & vbNewLine & " version 1 " & vbNewLine & "Devloped by Khaldoun Baz", vbInformation, ApplicationTitle)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnImgBrowse.Click
        Dim t As New OpenFileDialog
        t.Filter = "*.JPG;*.PNG;*.GIF|*.JPG;*.PNG;*.GIF"
        If t.ShowDialog = DialogResult.OK Then
            TxtImgFile.Text = t.FileName
            Clipboard.SetImage(Image.FromFile(TxtImgFile.Text))
        End If
    End Sub

    Private Sub CheckBoxِAddImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxِAddImg.CheckedChanged, Me.Load
        If CheckBoxِAddImg.Checked Then
            TxtImgFile.Enabled = True
            BtnImgBrowse.Enabled = True
            txtImgText.Enabled = True
        Else
            TxtImgFile.Enabled = False
            BtnImgBrowse.Enabled = False
            txtImgText.Enabled = False
            TxtImgFile.Text = ""
            txtImgText.Text = ""

        End If

        DeleteAfterSend = CBool(GetSetting(ApplicationTitle, "Sending", "DeleteAfterSending", "True"))
        DelayBetweenSend = Val(GetSetting(ApplicationTitle, "Sending", "Delay", "6")) * 1000
    End Sub
    Private Sub CalcInfo() Handles txtImgText.TextChanged, TxtImgFile.TextChanged, TxtMessage.TextChanged

        lblDestinationCount.Text = "Numbers Count:" & LstNumbers.Items.Count
        LblMessageLenght.Text = "Message Lenght:" & TxtMessage.Text.Length
        Dim fSize As Double = 0
        If IO.File.Exists(TxtImgFile.Text) Then
            Dim t As New IO.FileInfo(TxtImgFile.Text)
            fSize = FormatNumber(t.Length / 1000, 1)
        Else
            fSize = 0
        End If
        LblImageSize.Text = "Image Size:" & fSize & " KB"
        lblImageMsgSize.Text = "Image Message Length:" & txtImgText.Text.Length
    End Sub
    Private Sub resetListItems()
        Dim li As ListViewItem
        For Each li In LstNumbers.Items
            If li.SubItems(1).Text = "Sent" Then
                li.SubItems(1).Text = "Pending"
                li.ImageIndex = 1
            End If
        Next
    End Sub

    Private Sub TxtLog_TextChanged(sender As Object, e As EventArgs) Handles TxtLog.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FrmOptions.ShowDialog()

    End Sub

    Private Sub SendingOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendingOptionsToolStripMenuItem.Click
        FrmOptions.ShowDialog()
    End Sub

    Private Sub CalcInfo(sender As Object, e As EventArgs) Handles TxtMessage.TextChanged, txtImgText.TextChanged, TxtImgFile.TextChanged

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TxtLog.Text = "" Then
            Exit Sub
        End If
        Dim sd As New SaveFileDialog
        sd.Filter = "*.txt|*.txt"
        If sd.ShowDialog = DialogResult.OK Then
            Try
                Dim sw As New IO.StreamWriter(sd.FileName)
                sw.Write(TxtLog.Text)
                sw.Close()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, ApplicationTitle)
            End Try
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to clear the log", vbQuestion + vbYesNo, ApplicationTitle) = vbYes Then
            TxtLog.Text = ""
        End If
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        Process.Start("https://codecanyon.net/item/bulk-whatsapp-sender/22552903")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Designed and Developed by Khaldoun Baz", vbInformation, ApplicationTitle)
    End Sub
End Class
