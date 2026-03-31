Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class ucHTML
    Private Const YoutubeHtmlPath As String = "file:///C:/casparcg/mydata/youtube/youtube.html"

    Private Function GetHtmlLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayerhtml.Text
    End Function

    Private Sub PlayHtmlSource(sourceUrl As String)
        CasparDevice.SendString("play " & GetHtmlLayerAddress() & " [HTML] " & """" & sourceUrl & """")
    End Sub

    Private Sub CallHtml(functionCall As String)
        CasparDevice.SendString("Call " & GetHtmlLayerAddress() & " " & functionCall)
    End Sub

    Private Sub SetHtmlOpacity(opacityValue As Integer)
        CasparDevice.SendString("mixer " & GetHtmlLayerAddress() & " opacity " & opacityValue)
    End Sub

    Private Function BuildFacebookVideoUrl(baseUrl As String, autoplay As Boolean, mute As Boolean) As String
        Dim url = baseUrl & "/?&autoplay=" & If(autoplay, "1", "0")
        url &= "&mute=" & If(mute, "1", "0")
        Return url
    End Function

    Private Sub SendYoutubePlayerCommand(commandName As String, ParamArray args() As String)
        Dim formattedArgs As String = ""
        For argumentIndex = 0 To args.Length - 1
            If argumentIndex > 0 Then
                formattedArgs &= ","
            End If
            formattedArgs &= "'" & args(argumentIndex) & "'"
        Next

        Dim commandText = "player." & commandName & "(" & formattedArgs & ")"
        CallHtml(commandText)
    End Sub

    Private Function OpenHtmlFile() As String
        Dim ofd2 As New OpenFileDialog
        ofd2.Filter = "All files (*.*)|*.*"
        If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return "file:///" & Replace(ofd2.FileName, "\", "/")
        End If

        Return ""
    End Function

    Private Function GetYoutubeDurationJson(videoId As String) As String
        Using webClient As New System.Net.WebClient
            Return webClient.DownloadString("https://www.googleapis.com/youtube/v3/videos?id=" & videoId & "&part=contentDetails&key=AIzaSyA7uT2JcYKG6g4aULmp9KiSGFsHu-uEP6I")
        End Using
    End Function

    Private Function GetYoutubeLiveStreamUrl(liveYoutubeUrl As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("c:/casparcg/mydata/ffmpeg/youtube-dl", " -g " & liveYoutubeUrl)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()

        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            Return Split(oStreamReader.ReadToEnd(), vbLf)(0)
        End Using
    End Function

    Private Sub cmdplayhtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplayhtml.Click
        On Error Resume Next
        playhtml()
    End Sub
    Sub playhtml()
        On Error Resume Next
        PlayHtmlSource(txturlhtml.Text)
    End Sub

    Private Sub cmdstophtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstophtml.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & GetHtmlLayerAddress())
    End Sub
    Private Sub cmdhidegbhtml_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdreplaceurlforyoutubehtml_Click(sender As Object, e As EventArgs) Handles cmdreplaceurlforyoutubehtml.Click
        On Error Resume Next
        txturlhtml.Text = Replace(txturlhtml.Text, "watch?v=", "embed/") & "?autoplay=true"
    End Sub
    Private Sub cmdhtmlopen_Click(sender As Object, e As EventArgs) Handles cmdhtmlopen.Click
        On Error Resume Next
        Dim fileUrl = OpenHtmlFile()
        If fileUrl <> "" Then
            txturlhtml.Text = fileUrl
        End If
    End Sub
    Function replacestring(str As String) As String
        str = Replace(str, vbCrLf, "<br />")
        str = Replace(str, " ", "xxx")
        str = Replace(str, "'", "yyy")
        str = Replace(str, """", "zzz")
        Return str
    End Function

    Private Sub cmdLoadVideo_Click(sender As Object, e As EventArgs) Handles cmdLoadVideo.Click
        PlayHtmlSource(YoutubeHtmlPath)
        SetHtmlOpacity(0)
        Threading.Thread.Sleep(1000)
        SendYoutubePlayerCommand("loadVideoById", txtvideoId.Text)
        SendYoutubePlayerCommand("setSize", txtwidth.Text, txtheight.Text)
        Threading.Thread.Sleep(1000)
        SetHtmlOpacity(1)
    End Sub
    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        CallHtml("player.pauseVideo()")
    End Sub

    Private Sub cmdResume_Click(sender As Object, e As EventArgs) Handles cmdResume.Click
        CallHtml("player.playVideo()")
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        SendYoutubePlayerCommand("seekTo", TrackBar1.Value.ToString(), "True")
        lblCurrentTime.Text = TrackBar1.Value
    End Sub

    Private Sub cmdSetDuration_Click(sender As Object, e As EventArgs) Handles cmdSetDuration.Click
        TrackBar1.Maximum = txtduration.Text
    End Sub
    Private Sub cmdGetDuration_Click(sender As Object, e As EventArgs) Handles cmdGetDuration.Click
        Dim result As String = GetYoutubeDurationJson(txtvideoId.Text)
        Threading.Thread.Sleep(2000)
        lblDuration.Text = JObject.Parse(result).Item("items")(0).Item("contentDetails").Item("duration")
    End Sub
    Private Sub cdOpenremoteDebugging_Click(sender As Object, e As EventArgs) Handles cdOpenremoteDebugging.Click
        On Error Resume Next
        Process.Start("http://localhost:" & txtDebugPort.Text)
    End Sub
    Private Sub ucHTML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdPlayfacebook_Click(sender As Object, e As EventArgs) Handles cmdPlayfacebook.Click
        On Error Resume Next
        PlayHtmlSource("https://www.facebook.com/plugins/video.php?href=" & BuildFacebookVideoUrl(txtFacebookvideoURl.Text, chkAutoplay.Checked, chkmute.Checked))
    End Sub

    Private Sub Cmdplayhttpmethod_Click(sender As Object, e As EventArgs) Handles cmdplayhttpmethod.Click
        PlayHtmlSource(txthttpfbContainer.Text)
        CallHtml("changehref('" & BuildFacebookVideoUrl(txtfburlhttpmethod.Text, chkautoplayhttp.Checked, chkMutehttp.Checked) & "')")
    End Sub

    Private Sub Cmdpausehttp_Click(sender As Object, e As EventArgs) Handles cmdpausehttp.Click
        On Error Resume Next
        CallHtml("mypause()")
    End Sub

    Private Sub Cmdmutehttp_Click(sender As Object, e As EventArgs) Handles cmdmutehttp.Click
        On Error Resume Next
        CallHtml("mymute()")
    End Sub

    Private Sub Cmdresumehttp_Click(sender As Object, e As EventArgs) Handles cmdresumehttp.Click
        On Error Resume Next
        CallHtml("myplay()")
    End Sub

    Private Sub Cmdunmutehttp_Click(sender As Object, e As EventArgs) Handles cmdunmutehttp.Click
        On Error Resume Next
        CallHtml("myunmute()")
    End Sub

    Private Sub cmdplayliveyoutube_Click(sender As Object, e As EventArgs) Handles cmdplayliveyoutube.Click
        On Error Resume Next
        CasparDevice.SendString("play " & GetHtmlLayerAddress() & " " & txtm3u8.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error Resume Next
        txtm3u8.Text = GetYoutubeLiveStreamUrl(txtliveyoutubeurl.Text)
    End Sub
End Class
