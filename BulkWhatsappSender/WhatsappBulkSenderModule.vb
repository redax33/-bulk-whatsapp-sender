Module WhatsappBulkSenderModule
    Public ApplicationTitle As String = "Whatsapp Bulk Sender"
    Public CurrentSendingID As Long
    Public CurrentPercentage As Integer
    Public CurrentSendingStatus As Boolean
    Public IsPaused As Boolean
    Public StopCampaign As Boolean
    Public IsBulkFinish As Boolean
    Public BulkFileName As String
    Public CurrentLog As String
    Public LastLog As String
    Public IsImg As Boolean
    Public TxtImg As String
    Public DelayBetweenSend As Integer
    Public DeleteAfterSend As Boolean
    Public Class Messages
        Public Shared DELETE_NUMBER As String = "Are you sure you want to delete numbers?"
        Public Shared CLEAR_LIST As String = "Are you sure you want clear list?"
        Public Shared NEW_BULK As String = "Are you sure you want create new Whatsapp bulk?"
        Public Shared NO_NUMBERS As String = "There is no mobile numbers in the number list , add or import numbers."
        Public Shared NO_MESSAGE As String = "There is noo message to send, enter your message"
        Public Shared STOP_BULK As String = "Are you sure you want to stop bulk?,if you stop you will be unable to resume"
    End Class
    Public Structure ValidateMobileNumberResult
        Public IsValid As Boolean
        Public MobileNumber As String
    End Structure
    Public Function ValidateMobileNumber(ByVal Number As String) As ValidateMobileNumberResult
        Dim _result As New ValidateMobileNumberResult

        If Number.StartsWith("+") Then
            Number = Number.Replace(" ", "")
            Number = Number.Replace("+", "")
            Number = Number.Replace("\", "")
            Number = Number.Replace("/", "")
            Number = Number.Replace("-", "")
            Number = Number.Replace("_", "")
            Number = Number.Replace(".", "")
        Else
            _result.IsValid = False
            _result.MobileNumber = Number
            Exit Function
        End If

        If IsNumeric(Number) Then
            If Number.Length > 5 And Number.Length < 27 Then

                _result.IsValid = True
                _result.MobileNumber = "+" & Number

                Return _result
            Else
                _result.IsValid = False
                _result.MobileNumber = "+" & Number
            End If
        Else
            _result.IsValid = False
            _result.MobileNumber = "+" & Number
        End If
    End Function
    Public Delegate Sub AppendTextBoxDelegate(ByVal TB As TextBox, ByVal txt As String)

    Public Sub AppendTextBox(ByVal TB As TextBox, ByVal txt As String)
        On Error Resume Next
        If TB.InvokeRequired Then
            TB.Invoke(New AppendTextBoxDelegate(AddressOf AppendTextBox), New Object() {TB, txt})
        Else
            TB.AppendText(txt)
        End If
    End Sub
End Module
