Public Class ucImageScroll
    Dim ipauseresume As Integer = 0

    Private Function GetImageScrollLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayervideoforimage.Text
    End Function

    Private Function GetSelectedImageScrollFlags() As String
        Dim flags As New List(Of String)
        If chkPREMULTIPLY.Checked Then flags.Add("PREMULTIPLY")
        If chkPROGRESSIVE.Checked Then flags.Add("PROGRESSIVE")
        Return String.Join(" ", flags)
    End Function

    Private Sub SendImageScrollCall(commandName As String, commandValue As String)
        CasparDevice.SendString("call " & GetImageScrollLayerAddress() & " " & commandName & " " & commandValue)
    End Sub

    Private Sub PlayImageScroll(speedValue As String, blurValue As String)
        CasparDevice.SendString("clear " & GetImageScrollLayerAddress())
        CasparDevice.SendString("loadbg " & GetImageScrollLayerAddress() & " " & """" & cmbimageforimagescroll.Text & """" & " speed " & speedValue & " blur " & blurValue & " " & GetSelectedImageScrollFlags())
        Threading.Thread.Sleep(1000)
        CasparDevice.SendString("Play " & GetImageScrollLayerAddress())
    End Sub

    Private Sub ToggleImageScrollBoolean(optionName As String, isEnabled As Boolean)
        SendImageScrollCall(optionName, If(isEnabled, "1", "0"))
    End Sub

    Private Sub SendImageScrollPauseResume()
        If Mid(frmmediaplayer.lblserverversion.Text, 1, 3) = "2.1" Then
            SendImageScrollCall("speed", If(ipauseresume = 0, "0", cmbimagescrollspeed.Text))
        Else
            CasparDevice.SendString(If(ipauseresume = 0, "pause ", "resume ") & GetImageScrollLayerAddress())
        End If
    End Sub

    Sub mediafilesforimagescroll()
        On Error Resume Next
        cmbimageforimagescroll.Items.Clear()

        CasparDevice.RefreshMediafiles()
        Threading.Thread.Sleep(250)
        For Each File In CasparDevice.Mediafiles
            If File.Type = Svt.Caspar.MediaType.STILL Then
                cmbimageforimagescroll.Items.Add(Replace(File.ToString, "\", "/"))
            End If
        Next
    End Sub

    Private Sub cmdimagescrollplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdimagescrollplay.Click
        On Error Resume Next
        PlayImageScroll(cmbimagescrollspeed.Text, cmbimagescrollblur.Text)
        ipauseresume = 0
    End Sub

    Private Sub cmdrefreshimagefilesforimagescroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefreshimagefilesforimagescroll.Click
        On Error Resume Next
        mediafilesforimagescroll()
    End Sub

    Private Sub chkPREMULTIPLY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPREMULTIPLY.CheckedChanged
        On Error Resume Next
        ToggleImageScrollBoolean("PREMULTIPLY", chkPREMULTIPLY.Checked)
    End Sub

    Private Sub chkPROGRESSIVE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPROGRESSIVE.CheckedChanged
        On Error Resume Next
        ToggleImageScrollBoolean("PROGRESSIVE", chkPROGRESSIVE.Checked)
    End Sub

    Private Sub cmbimagescrollblur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbimagescrollblur.SelectedIndexChanged
        On Error Resume Next
        SendImageScrollCall("blur", cmbimagescrollblur.Text)
    End Sub

    Private Sub cmbimagescrollspeed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbimagescrollspeed.SelectedIndexChanged
        On Error Resume Next
        SendImageScrollCall("speed", cmbimagescrollspeed.Text)
    End Sub
    Private Sub cmdimagestop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdimagestop.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & GetImageScrollLayerAddress())
        ipauseresume = 0
    End Sub


    Private Sub cmdhidegbimagescroll_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdPauseResume_Click(sender As Object, e As EventArgs) Handles cmdPauseResume.Click
        SendImageScrollPauseResume()
        ipauseresume = ipauseresume + 1
        If ipauseresume > 1 Then ipauseresume = 0
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        On Error Resume Next
        Process.Start("https://drive.google.com/open?id=1DlMkTGOlqAMhw0eRReyPwv85ow6FVTBn")
    End Sub
    Private Sub ucImageScroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
