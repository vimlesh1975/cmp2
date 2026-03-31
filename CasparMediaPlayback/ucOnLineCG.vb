Public Class ucOnLineCG
    Private Const OnlineCgHost As String = "https://vimlesh1975.github.io/ReactCasparClient/"
    Private Const OnlineCgHtmlRoot As String = "https://vimlesh1975.github.io/ReactCasparClient/html/"

    Private Sub cmdinitialize_Click(sender As Object, e As EventArgs) Handles cmdinitialize.Click
        CasparDevice.SendString("play " & GetOnlineCgLayerAddress() & " [html] " & OnlineCgHtmlRoot & txtCLientId.Text)
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        CasparDevice.SendString("stop " & GetOnlineCgLayerAddress())
    End Sub

    Private Sub cmdOpenOnlineCG_Click(sender As Object, e As EventArgs) Handles cmdOpenOnlineCG.Click
        Process.Start(OnlineCgHost)
    End Sub

    Private Function GetOnlineCgLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayercgOnline.Text
    End Function
End Class
