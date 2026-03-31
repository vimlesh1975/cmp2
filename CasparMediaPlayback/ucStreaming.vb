Public Class ucStreaming
    Private Function BuildStreamingTarget(address As String, applicationName As String, streamName As String) As String
        If applicationName = "" Then
            Return address & streamName
        End If

        Return address & "/" & applicationName & "/" & streamName
    End Function

    Private Sub SendStreamingCommand(commandText As String, address As String, applicationName As String, streamName As String, Optional options As String = "")
        Dim fullCommand As String = commandText & " " & BuildStreamingTarget(address, applicationName, streamName)
        If options <> "" Then
            fullCommand &= " " & options
        End If
        CasparDevice.SendString(fullCommand)
    End Sub

    Private Sub RemoveStreamingCommand(commandText As String, address As String, applicationName As String, streamName As String, Optional options As String = "")
        SendStreamingCommand("remove " & Mid(commandText, 4), address, applicationName, streamName, options)
    End Sub

    Private Sub cmdsendhlsstreaming_Click(sender As Object, e As EventArgs) Handles cmdsendhlsstreaming.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandhlstreaming.Text, txtaddresshlsstreaming.Text, txtapplicationamehlsstreaming.Text, txtstreamnamehlsstreaming.Text, txtoptionshlsstreaming.Text)
    End Sub
    Private Sub cmdstophlsstreaming_Click(sender As Object, e As EventArgs) Handles cmdstophlsstreaming.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandhlstreaming.Text, txtaddresshlsstreaming.Text, txtapplicationamehlsstreaming.Text, txtstreamnamehlsstreaming.Text, txtoptionshlsstreaming.Text)
    End Sub
    Private Sub cmdsendwsstreaming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsendwsstreaming.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandwsstreaming.Text, txtaddresswsstreaming.Text, txtapplicationamewsstreaming.Text, txtstreamnamewsstreaming.Text, txtoptionswsstreaming.Text)
    End Sub

    Private Sub cmdsendytstreaming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsendytstreaming.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandytstreaming.Text, txtaddressytstreaming.Text, txtapplicationameytstreaming.Text, txtstreamnameytstreaming.Text, txtoptionsytstreaming.Text)
    End Sub
    Private Sub cmdstopwsstreaming_Click(sender As Object, e As EventArgs) Handles cmdstopwsstreaming.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandwsstreaming.Text, txtaddresswsstreaming.Text, txtapplicationamewsstreaming.Text, txtstreamnamewsstreaming.Text, txtoptionswsstreaming.Text)

    End Sub
    Private Sub cmdstopytstreaming_Click(sender As Object, e As EventArgs) Handles cmdstopytstreaming.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandytstreaming.Text, txtaddressytstreaming.Text, txtapplicationameytstreaming.Text, txtstreamnameytstreaming.Text)

    End Sub

    Private Sub cmdhidegbstreaming_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdsendfbstreaming_Click(sender As Object, e As EventArgs) Handles cmdsendfbstreaming.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandfbstreaming.Text, txtaddressfbstreaming.Text, "", txtstreamnamefbstreaming.Text, txtoptionsfbstreaming.Text)

    End Sub

    Private Sub cmdstopfbstreaming_Click(sender As Object, e As EventArgs) Handles cmdstopfbstreaming.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandfbstreaming.Text, txtaddressfbstreaming.Text, "", txtstreamnamefbstreaming.Text)

    End Sub

    Private Sub cmdplaystreamingcosumer_Click(sender As Object, e As EventArgs) Handles cmdplaystreamingcosumer.Click
        On Error Resume Next
        CasparDevice.SendString(txtudp.Text)
    End Sub

    Private Sub cmdStopUDP_Click(sender As Object, e As EventArgs) Handles cmdStopUDP.Click
        CasparDevice.SendString("remove " & Split(txtudp.Text, " ")(1) & " " & Split(txtudp.Text, " ")(2) & " " & Split(txtudp.Text, " ")(3))
    End Sub

    Private Sub cmdRemoveNDI_Click(sender As Object, e As EventArgs) Handles cmdRemoveNDI.Click
        CasparDevice.SendString("remove " & Split(txtndi.Text, " ")(1) & " ndi")
    End Sub

    Private Sub cmdAddNDI_Click(sender As Object, e As EventArgs) Handles cmdAddNDI.Click
        CasparDevice.SendString(txtndi.Text)
    End Sub

    Private Sub cmdinput_Click(sender As Object, e As EventArgs) Handles cmdinput.Click
        On Error Resume Next
        If frmmediaplayer.cmdconnect.BackColor = Color.Green Then
            CasparDevice.SendString("play " & g_int_ChannelNumber & "-" & g_int_PlaylistLayer & " decklink " & cmbdecklinkforrecording.Text)
        End If
    End Sub

    Private Sub cmdremove_input_Click(sender As Object, e As EventArgs) Handles cmdremove_input.Click
        On Error Resume Next
        If frmmediaplayer.cmdconnect.BackColor = Color.Green Then
            CasparDevice.SendString("stop " & g_int_ChannelNumber & "-" & g_int_PlaylistLayer)
        End If
    End Sub

    Private Sub cmdPlayTestSignal_Click(sender As Object, e As EventArgs) Handles cmdPlayTestSignal.Click
        On Error Resume Next
        SendString(NetStream, txtPlayTestSignal.Text & vbCrLf)
    End Sub

    Private Sub cmdStopTestSignal_Click(sender As Object, e As EventArgs) Handles cmdStopTestSignal.Click
        On Error Resume Next
        SendString(NetStream, txtStopTestSignal.Text & vbCrLf)
    End Sub

    Private Sub cmdsendytstreaming23_Click(sender As Object, e As EventArgs) Handles cmdsendytstreaming23.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandytstreaming23.Text, txtaddressytstreaming23.Text, txtapplicationameytstreaming23.Text, txtstreamnameytstreaming23.Text, txtoptionsytstreaming23.Text)

    End Sub

    Private Sub cmdstopytstreaming23_Click(sender As Object, e As EventArgs) Handles cmdstopytstreaming23.Click
        RemoveStreamingCommand(txtcommandytstreaming23.Text, txtaddressytstreaming23.Text, txtapplicationameytstreaming23.Text, txtstreamnameytstreaming23.Text)

    End Sub

    Private Sub cmdsendfbstreaming23_Click(sender As Object, e As EventArgs) Handles cmdsendfbstreaming23.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandfbstreaming23.Text, txtaddressfbstreaming23.Text, "", txtstreamnamefbstreaming23.Text, txtoptionsfbstreaming23.Text)

    End Sub

    Private Sub cmdstopfbstreaming23_Click(sender As Object, e As EventArgs) Handles cmdstopfbstreaming23.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandfbstreaming23.Text, txtaddressfbstreaming23.Text, "", txtstreamnamefbstreaming23.Text)

    End Sub

    Private Sub cmdsendpipe_Click(sender As Object, e As EventArgs) Handles cmdsendpipe.Click
        On Error Resume Next
        CasparDevice.SendString(txtcommandpipe.Text)

    End Sub

    Private Sub cmdstoppipe_Click(sender As Object, e As EventArgs) Handles cmdstoppipe.Click
        On Error Resume Next
        CasparDevice.SendString(txtremovepipe.Text)
    End Sub

    Private Sub cmduseinffmpeg_Click(sender As Object, e As EventArgs) Handles cmduseinffmpeg.Click
        On Error Resume Next

        Dim ff As String = "/K " & txtuseinffmpeg.Text
        Process.Start("CMD", ff)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub cmdsendIGstreaming_Click(sender As Object, e As EventArgs) Handles cmdsendIGstreaming.Click
        On Error Resume Next
        SendStreamingCommand(txtcommandIGstreaming.Text, txtaddressIGstreaming.Text, "", txtstreamnameIGstreaming.Text, txtoptionsIGstreaming.Text)

    End Sub

    Private Sub cmdstopIGstreaming_Click(sender As Object, e As EventArgs) Handles cmdstopIGstreaming.Click
        On Error Resume Next
        RemoveStreamingCommand(txtcommandIGstreaming.Text, txtaddressIGstreaming.Text, "", txtstreamnameIGstreaming.Text)

    End Sub
End Class
