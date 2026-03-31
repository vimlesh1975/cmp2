Public Class ucSlowMotion21
    Dim WithEvents spv As clsShuttleProV2.clsShuttleProV2

    Private Sub ConfigureSmRecorder(recorder As ucSMRecorder, channelText As String, labelText As String, screenText As String, destinationChannel As String, decklinkText As String)
        recorder.cmbChannel.Text = channelText
        recorder.Label2.Text = labelText
        recorder.cmbscreenConsumres.Text = screenText
        recorder.cmbChannelDestination.Text = destinationChannel
        recorder.cmbdecklinkforrecording.Text = decklinkText
    End Sub

    Private Sub ConfigureSmPlayer(player As ucnewSM2, channelText As String, labelText As String, screenText As String)
        player.cmbChannel.Text = channelText
        player.Label2.Text = labelText
        player.cmbscreenConsumres.Text = screenText
    End Sub

    Private Sub frmSlowMotion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim rs1 = New clsResizeableControlnew(UcnewSM21)
        Dim rs2 = New clsResizeableControlnew(UcnewSM22)
        Dim rs3 = New clsResizeableControlnew(UcSMRecorder1)
        Dim rs4 = New clsResizeableControlnew(UcSMRecorder2)
        Dim rs5 = New clsResizeableControlnew(UcClipGrid1)

        ConfigureSmRecorder(UcSMRecorder2, "3", "Channel 3", "Screen consumer [3|1080i5000]", "4", "3")
        ConfigureSmPlayer(UcnewSM21, "2", "Channel 2", "Screen consumer [2|1080i5000]")
        ConfigureSmPlayer(UcnewSM22, "4", "Channel 4", "Screen consumer [4|1080i5000]")
    End Sub

    Private Sub ucSlowMotion21_Load(sender As Object, e As EventArgs)

    End Sub
End Class
