Public Class FrmOptions
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        DeleteAfterSend = CheckBoxDeleteAfterSending.Checked
        DelayBetweenSend = Val(TrackBarDelay.Value) * 1000
        SaveSetting(ApplicationTitle, "Sending", "Delay", TrackBarDelay.Value.ToString)
        SaveSetting(ApplicationTitle, "Sending", "DeleteAfterSending", CheckBoxDeleteAfterSending.Checked.ToString)
        Me.Close()
    End Sub

    Private Sub FrmOptions_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TrackBarDelay.Value = Val(GetSetting(ApplicationTitle, "Sending", "Delay", "6"))
        CheckBoxDeleteAfterSending.Checked = CBool(GetSetting(ApplicationTitle, "Sending", "DeleteAfterSending", "True"))

    End Sub
End Class