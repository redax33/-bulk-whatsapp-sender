Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports System
Public Class SendingClass
    Private drv As New ChromeDriver
    Public lst As String
    Public Message As String
    Private thr As System.Threading.Thread
    Private Function CheckLoggedIn() As Boolean
        Try
            Return drv.FindElement(By.ClassName("_2Uo0Z")).Displayed
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub SendMessage(ByVal Number As String, ByVal Message As String)
        '  On Error Resume Next

        drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000)
        drv.Navigate().GoToUrl("https://api.whatsapp.com/send?phone=" + Number + "&text=" + Uri.EscapeDataString(Message))
        drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15000)
        Try
            drv.FindElement(By.Id("action-button")).Click()
        Catch ex As Exception

        End Try

        If StopCampaign Then Exit Sub


        drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15000)
        System.Threading.Thread.Sleep(DelayBetweenSend)
        If StopCampaign Then Exit Sub

        '  drv.FindElement(By.CssSelector("button._2lkdt>span")).Click()
retry:

        Try

            drv.FindElement(By.ClassName("_35EW6")).Click()
        Catch ex As Exception
            System.Threading.Thread.Sleep(1000)
            If StopCampaign Then Exit Sub
            GoTo retry
        End Try



        If IsImg Then
            Try

                AddLog("Sending Image to:+" & Number)
                System.Threading.Thread.Sleep(1000)
                If StopCampaign Then Exit Sub
                drv.FindElementByClassName("_2S1VP").SendKeys(Keys.LeftShift & Keys.Insert)
                System.Threading.Thread.Sleep(1000)
                If StopCampaign Then Exit Sub
                drv.FindElementByClassName("_2S1VP").SendKeys(TxtImg)
                drv.FindElementByClassName("_3hV1n").Click()
                AddLog("Image Sent to:+" & Number)
                System.Threading.Thread.Sleep(1000)
                If StopCampaign Then Exit Sub

            Catch ex As Exception

            End Try
        End If


        If DeleteAfterSend Then
            Try
                AddLog("Deleting message sent to:+" & Number)
                System.Threading.Thread.Sleep(1000)
                If StopCampaign Then Exit Sub
                drv.FindElement(By.ClassName("_18tv-")).Click()
                System.Threading.Thread.Sleep(4000)
                If StopCampaign Then Exit Sub
                drv.FindElementsByClassName("_2QrOO")(2).Click()
                System.Threading.Thread.Sleep(4000)
                If StopCampaign Then Exit Sub
                drv.FindElement(By.ClassName("PNlAR")).Click()
                AddLog("Message deleted")
            Catch ex As Exception

            End Try
        End If


        If StopCampaign Then Exit Sub
        System.Threading.Thread.Sleep(DelayBetweenSend)
        If StopCampaign Then Exit Sub
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'drv.Navigate().GoToUrl("https://web.whatsapp.com")

        'While True

        '    If CheckLoggedIn() Then
        '        Exit While
        '    End If
        '    Application.DoEvents()
        'End While
        'Dim tt() As String = Split(TextBox1.Text, vbNewLine)
        'Dim t As String
        'For Each t In tt
        '    SendMessage(t, TextBox2.Text)
        'Next


    End Sub
    Public Sub StartSending()
        thr = New System.Threading.Thread(AddressOf DoSending)
        thr.Start()
    End Sub
    Private Sub DoSending()
        AddLog("Start Whatsapp web session...")
        drv.Navigate().GoToUrl("https://web.whatsapp.com")
        System.Threading.Thread.Sleep(1000)
        AddLog("Waiting to login into whatsapp web...")
        While True
            If StopCampaign Then
                GoTo EndBulk
            End If
            If CheckLoggedIn() Then
                Exit While
            End If
            Application.DoEvents()
        End While
        System.Threading.Thread.Sleep(1000)
        AddLog("Logged in to Whatsapp web")
        System.Threading.Thread.Sleep(1000)
        Dim t As String
        Dim a() As String = Split(lst, ",")
        Dim b() As String
        Dim MaxNum As Long = UBound(a)
        Dim PercentageCounter As Integer = 0
        For Each t In a
            If StopCampaign Then
                GoTo EndBulk
            End If
            While IsPaused
                If StopCampaign Then
                    GoTo EndBulk
                End If
            End While
            If t.Contains("|") Then
                b = Split(t, "|")
                CurrentSendingID = b(0)
                AddLog("Sending Message to:" & b(1))
                SendMessage(b(1).Replace("+", ""), Message)
                AddLog("Message Sent to:" & b(1))
                PercentageCounter = PercentageCounter + 1
                CurrentPercentage = (100 * PercentageCounter) \ MaxNum

            End If
            System.Threading.Thread.Sleep(10)
        Next

        CurrentSendingStatus = False
        IsBulkFinish = True
        MsgBox("Bulk has been finish", vbInformation, ApplicationTitle)

        Exit Sub
EndBulk:
        StopCampaign = False
        MsgBox("Bulk has been stopped explicitly", vbInformation, ApplicationTitle)
        Exit Sub
    End Sub
    Public Sub AddLog(ByVal Log As String)
        CurrentLog = "<" & Now.ToString("yyyy-MM-dd hh:mm:ss") & ">" & Log & vbNewLine
    End Sub
End Class
