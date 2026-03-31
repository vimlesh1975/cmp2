Public Class ucSystemAudio
    Private Sub ApplySystemAudioState(channelNumber As Integer, isEnabled As Boolean)
        If isEnabled Then
            CasparDevice.SendString("add " & channelNumber & " audio")
        Else
            CasparDevice.SendString("remove " & channelNumber & " audio")
        End If
    End Sub

    Private Sub cmdSystemAudio_Click(sender As Object, e As EventArgs) Handles cmdSystemAudio.Click
        On Error Resume Next
        If g_int_NumberOfChannels >= 1 Then
            ApplySystemAudioState(1, chkSystemAudioch1.Checked)
        End If
        If g_int_NumberOfChannels >= 2 Then
            ApplySystemAudioState(2, chkSystemAudioch2.Checked)
        End If
        If g_int_NumberOfChannels >= 3 Then
            ApplySystemAudioState(3, chkSystemAudioch3.Checked)
        End If
        If g_int_NumberOfChannels >= 4 Then
            ApplySystemAudioState(4, chkSystemAudioch4.Checked)
        End If

    End Sub
    Private Sub cmdcloseRecorder_Click(sender As Object, e As EventArgs) Handles cmdcloseRecorder.Click
        Parent.Controls.Remove(Me)
    End Sub
    Private Sub GbSystemAudio_Enter(sender As Object, e As EventArgs) Handles gbSystemAudio.Enter

    End Sub
End Class
