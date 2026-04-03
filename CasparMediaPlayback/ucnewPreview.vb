Public Class ucnewPreview
    Public chnumber As Integer = 1
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

    Private Sub cmdpreviewkey_Click(sender As Object, e As EventArgs) Handles cmdpreviewkey.Click
        On Error Resume Next
        SendPreviewCommand(True)
        PlayPreviewStream()
    End Sub

    Private Sub cmdpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpreview.Click
        On Error Resume Next
        SendPreviewCommand(False)
        PlayPreviewStream()
    End Sub

    Private Sub cmdremovepreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremovepreview.Click
        On Error Resume Next
        CasparDevice.SendString("remove " & chnumber & " stream " & GetPreviewStreamUri())
        vlcpreview.VlcMediaPlayer.Stop()
        isplaying = False
    End Sub

    Private Sub Cmdhid_Click(sender As Object, e As EventArgs) Handles cmdhid.Click
        Hide()
    End Sub

    Private Function GetPreviewStreamUri() As String
        Return "udp://" & cmbippreview.Text
    End Function

    Private Function GetVlcPreviewUri() As String
        Return "udp://@" & cmbippreview.Text
    End Function

    Private Sub SendPreviewCommand(includeAlphaKey As Boolean)
        Dim commandText As String = "ADD " & chnumber & " STREAM " & GetPreviewStreamUri() & " " & NormalizePreviewOptions(txtoptionspreview.Text)
        If includeAlphaKey Then
            commandText = commandText & If(ServerVersion > 2.1, " -filter:v alphaextract", " -vf alphaextract")
        End If

        CasparDevice.SendString(commandText)
    End Sub

    Private Sub PlayPreviewStream()
        If isplaying = True Then
            vlcpreview.VlcMediaPlayer.Stop()
        End If

        vlcpreview.VlcMediaPlayer.SetMedia(New Uri(GetVlcPreviewUri()))
        vlcpreview.VlcMediaPlayer.Play()
        isplaying = True
    End Sub
End Class
