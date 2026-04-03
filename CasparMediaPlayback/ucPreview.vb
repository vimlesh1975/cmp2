Public Class ucPreview
    Dim isplaying As Boolean = False

    Private Function NormalizePreviewOptions(options As String) As String
        Dim normalizedOptions = options.Trim()

        If ServerVersion > 2.1 Then
            Dim lowerOptions = normalizedOptions.ToLowerInvariant()
            Dim hasAudioOption = lowerOptions.Contains("-an") OrElse
                                 lowerOptions.Contains("-acodec") OrElse
                                 lowerOptions.Contains("-codec:a") OrElse
                                 lowerOptions.Contains("-filter:a") OrElse
                                 lowerOptions.Contains("-af ") OrElse
                                 lowerOptions.Contains("-ac ")

            If Not hasAudioOption Then
                normalizedOptions &= " -filter:a pan=stereo|c0=c0|c1=c1"
            End If
        End If

        Return normalizedOptions.Trim()
    End Function

    Private Function GetPreviewStreamAddress() As String
        Return "udp://" & cmbippreview.Text
    End Function

    Private Function BuildPreviewAddCommand(Optional extraOptions As String = "") As String
        Dim options As String = txtoptionspreview.Text
        If extraOptions <> "" Then
            options &= " " & extraOptions
        End If

        Return "ADD " & g_int_ChannelNumber & " STREAM " & GetPreviewStreamAddress() & " " & NormalizePreviewOptions(options)
    End Function

    Private Sub RemovePreviewStream()
        CasparDevice.SendString("remove " & g_int_ChannelNumber & " stream " & GetPreviewStreamAddress())
    End Sub

    Private Sub StartPreviewPlayback()
        If isplaying = True Then vlcpreview.VlcMediaPlayer.Stop()
        vlcpreview.VlcMediaPlayer.SetMedia(New Uri("udp://@" & cmbippreview.Text))
        vlcpreview.VlcMediaPlayer.Play()
        isplaying = True
    End Sub

    Private Sub RestartPreviewStream(waitAfterAddMs As Integer, waitAfterRemoveMs As Integer)
        CasparDevice.SendString(BuildPreviewAddCommand())
        Threading.Thread.Sleep(waitAfterAddMs)
        RemovePreviewStream()
        Threading.Thread.Sleep(waitAfterRemoveMs)
    End Sub

    Private Sub cmdWaveformluma_Click(sender As Object, e As EventArgs) Handles cmdWaveformluma.Click
        On Error Resume Next

        CasparDevice.SendString(BuildPreviewAddCommand())
        Threading.Thread.Sleep(2000)

        Process.Start("CMD", "/K " & "C:/casparcg/mydata/ffmpeg/ffplay.exe " & GetPreviewStreamAddress() & " " & "-vf waveform=filter=lowpass:scale=ire:graticule=green:flags=numbers+dots")
        Threading.Thread.Sleep(2000)

        RestartPreviewStream(4000, 4000)
        RestartPreviewStream(4000, 4000)
        RestartPreviewStream(4000, 4000)
        RestartPreviewStream(4000, 4000)
        CasparDevice.SendString(BuildPreviewAddCommand())
        Threading.Thread.Sleep(4000)
    End Sub

    Private Sub cmdpreviewkey_Click(sender As Object, e As EventArgs) Handles cmdpreviewkey.Click
        On Error Resume Next
        If ServerVersion > 2.1 Then
            CasparDevice.SendString(BuildPreviewAddCommand("-filter:v alphaextract"))
        Else
            CasparDevice.SendString(BuildPreviewAddCommand("-vf alphaextract"))
        End If

        StartPreviewPlayback()
    End Sub

    Private Sub cmdpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpreview.Click
        On Error Resume Next
        CasparDevice.SendString(BuildPreviewAddCommand())
        StartPreviewPlayback()
    End Sub

    Private Sub cmdremovepreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremovepreview.Click
        On Error Resume Next
        RemovePreviewStream()
        vlcpreview.VlcMediaPlayer.Stop()
        isplaying = False
    End Sub
End Class
