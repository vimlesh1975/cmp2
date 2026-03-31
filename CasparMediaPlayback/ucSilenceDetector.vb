Imports AudioSwitcher.AudioApi
Imports AudioSwitcher.AudioApi.CoreAudio
Public Class ucSilenceDetector
    Dim aa As Integer = 1
    Dim bb As Double

    Private Function GetSilenceOscRow() As Integer
        If ServerVersion > 2.1 Then
            Return 57
        End If
        Return 30
    End Function

    Private Function IsSilentLevel(levelValue As Double) As Boolean
        If ServerVersion > 2.1 Then
            Return levelValue = 0
        End If
        Return levelValue < -190
    End Function

    Private Sub ResetSilenceDetectorState()
        chkSilenceDetect.Checked = False
        tmrSilenceDetect.Enabled = False
        aa = 1
    End Sub

    Private Sub SendSourceCommand(commandText As String)
        CasparDevice.SendString(commandText)
    End Sub

    Private Sub PlaySilenceTone()
        Dim defaultPlaybackDevice As CoreAudioDevice = New CoreAudioController().DefaultPlaybackDevice
        defaultPlaybackDevice.SetMuteAsync(False)
        defaultPlaybackDevice.SetVolumeAsync(100)
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = vlcplayerpath()
        startInfo.Arguments = "c:\casparcg\_media\tone.mp4 --directx-volume=2 --loop"
        Process.Start(startInfo)
    End Sub

    Private Sub TmrSilenceDetect_Tick(sender As Object, e As EventArgs) Handles tmrSilenceDetect.Tick
        On Error Resume Next
        bb = ucOSC.dgvosc.Rows(GetSilenceOscRow()).Cells(1).Value
        If IsSilentLevel(bb) And aa < Val(txtSilenceDuration.Text) Then
            aa = aa + 1
        ElseIf IsSilentLevel(bb) And aa = Val(txtSilenceDuration.Text) Then
            sendotherinfo()
        Else
            aa = 1
        End If
    End Sub
    Sub sendotherinfo()
        On Error Resume Next
        If chkPlayToneinVLC.Checked Then
            PlaySilenceTone()
        End If
        If chkSendMail.Checked Then
            Dim aa As New mailtest.clsSendMail
            aa.sendmail(txtTo.Text, txtMessage.Text, "Problem in Casparcg")
        End If
        If chkSwitchTo2ndInput.Checked Then
            SendSourceCommand(txtSecondSource.Text)
        End If

        ResetSilenceDetectorState()

        If chkSendCustomCommand.Checked Then
            SendSourceCommand(txtCustomCommand.Text)
            If chkEnableSilenceDetectionAgain.Checked Then
                chkSilenceDetect.Checked = True
                tmrSilenceDetect.Enabled = True
            End If
        End If

    End Sub
    Private Sub cmdhideSilenceDetector_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ChkSilenceDetect_CheckedChanged(sender As Object, e As EventArgs) Handles chkSilenceDetect.CheckedChanged
        On Error Resume Next
        tmrSilenceDetect.Enabled = chkSilenceDetect.Checked
    End Sub

    Private Sub cmdFirstSource_Click(sender As Object, e As EventArgs) Handles cmdFirstSource.Click
        On Error Resume Next
        SendSourceCommand(txtFirstSource.Text)
    End Sub

    Private Sub cmdSecondSource_Click(sender As Object, e As EventArgs) Handles cmdSecondSource.Click
        On Error Resume Next
        SendSourceCommand(txtSecondSource.Text)
    End Sub

    Private Sub cmdOutputSource_Click(sender As Object, e As EventArgs) Handles cmdOutputSource.Click
        On Error Resume Next
        SendSourceCommand(txtOutputSource.Text)
    End Sub

    Private Sub UcSilenceDetector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
