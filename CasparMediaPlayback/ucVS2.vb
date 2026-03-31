Public Class ucVS2
    Dim iPauseResumeVs2 As Integer = 0

    Private Function GetVs2LayerNumber() As Integer
        Return Int(cmblayervs2.Text)
    End Function

    Private Function GetVs2LayerAddress() As String
        Return g_int_ChannelNumber & "-" & GetVs2LayerNumber()
    End Function

    Private Sub UpdateVs2Speed(speedValue As String)
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("speed", speedValue)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(GetVs2LayerNumber(), GetVs2LayerNumber(), CasparCGDataCollection)
    End Sub

    Private Sub SendVs2HtmlCall(callText As String)
        CasparDevice.SendString("call " & GetVs2LayerAddress() & " " & callText)
    End Sub

    Private Sub cmdshowcrawlVs2_Click(sender As Object, e As EventArgs) Handles cmdshowcrawlVs2.Click
        On Error Resume Next
        crawlvs2()
    End Sub

    Sub crawlvs2()
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("speed", Int(nspeedVs2.Value))
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetVs2LayerNumber(), GetVs2LayerNumber(), txtvs2Template.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
        If nspeedVs2.Value <> 0 Then iPauseResumeVs2 = 1
    End Sub

    Private Sub cmdstopcrawlVs2_Click(sender As Object, e As EventArgs) Handles cmdstopcrawlVs2.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetVs2LayerNumber(), GetVs2LayerNumber())
    End Sub

    Private Sub nspeedVs2_ValueChanged(sender As Object, e As EventArgs) Handles nspeedVs2.ValueChanged
        On Error Resume Next
        UpdateVs2Speed(nspeedVs2.Value)
        If nspeedVs2.Value <> 0 Then iPauseResumeVs2 = 1
    End Sub

    Private Sub cmdpausevs2_Click(sender As Object, e As EventArgs) Handles cmdpausevs2.Click
        On Error Resume Next
        PauseResumeVs2()
    End Sub

    Sub PauseResumeVs2()
        On Error Resume Next
        If iPauseResumeVs2 = 1 Then
            UpdateVs2Speed("0")
        Else
            UpdateVs2Speed(nspeedVs2.Value)
        End If
        iPauseResumeVs2 = iPauseResumeVs2 + 1
        If iPauseResumeVs2 > 1 Then iPauseResumeVs2 = 0
    End Sub

    Private Sub cmdhidevs2_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdshowcrawlVs2html_Click(sender As Object, e As EventArgs) Handles cmdshowcrawlVs2html.Click
        On Error Resume Next
        CasparDevice.SendString("mixer " & GetVs2LayerAddress() & " opacity 0")
        CasparDevice.SendString("play " & GetVs2LayerAddress() & " [HTML] " & """" & txtvs2Templatehtml.Text & """")
        Threading.Thread.Sleep(300)
        SendVs2HtmlCall("speed('" & nspeedVs2html.Value & "')")
        SendVs2HtmlCall("start1()")
        Threading.Thread.Sleep(300)
        CasparDevice.SendString("mixer " & GetVs2LayerAddress() & " opacity 1")
        iPauseResumeVs2 = 0
    End Sub

    Private Sub nspeedVs2html_ValueChanged(sender As Object, e As EventArgs) Handles nspeedVs2html.ValueChanged
        On Error Resume Next
        SendVs2HtmlCall("speed('" & nspeedVs2html.Value & "')")
    End Sub

    Private Sub cmdstopcrawlVs2html_Click(sender As Object, e As EventArgs) Handles cmdstopcrawlVs2html.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & GetVs2LayerAddress())
    End Sub

    Private Sub cmdpausevs2html_Click(sender As Object, e As EventArgs) Handles cmdpausevs2html.Click
        On Error Resume Next
        If iPauseResumeVs2 = 0 Then
            SendVs2HtmlCall("pause()")
        Else
            SendVs2HtmlCall("resume()")
        End If
        iPauseResumeVs2 = iPauseResumeVs2 + 1
        If iPauseResumeVs2 > 1 Then iPauseResumeVs2 = 0
    End Sub

    Private Sub UcVS2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
