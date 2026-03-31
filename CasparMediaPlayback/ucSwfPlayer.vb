Public Class ucSwfPlayer
    Private Function GetSwfLayerNumber() As Integer
        Return Int(cmbflashlayerforswf.Text)
    End Function

    Private Function GetSwfMoviePath() As String
        Return Replace(picswf.Movie, "\", "/")
    End Function

    Private Sub cmdswfplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdswfplay.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("loader1", GetSwfMoviePath())
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetSwfLayerNumber(), GetSwfLayerNumber(), "CMP/swf/swf", True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub
    Private Sub cmdswfstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdswfstop.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetSwfLayerNumber(), GetSwfLayerNumber())
    End Sub
    Private Sub picswf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdswfopen.Click
        On Error Resume Next

        If (picofd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            picswf.Movie = "file:///" & Replace(picofd.FileName, "\", "/")
        End If
    End Sub

    Private Sub UcSwfPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
