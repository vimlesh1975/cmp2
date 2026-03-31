Public Class ucCG
    Private Const MainCgLayer As Integer = 8
    Private Const PhoneInLayer As Integer = 9
    Private Const HtmlClockLayer As Integer = 9999
    Private Const HtmlClockPath As String = "c:/casparcg/CMP/cg_template/html/clock/gwd_preview_clock/index.html"

    Private ReadOnly TemplateDirectorySeparator As Char() = {"/"c}

    Private Sub cmdclockplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclockplay.Click
        PlayTemplate(MainCgLayer, "clock")
    End Sub

    Private Sub cmdplaytwolinecenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaytwolinecenter.Click
        PlayTemplate(
            MainCgLayer,
            "twoline_center",
            ("f0", txttwolinecenter1.Text),
            ("f1", txttwolinecenter2.Text))
    End Sub

    Private Sub cmdplaythreelinecenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaythreelinecenter.Click
        PlayTemplate(
            MainCgLayer,
            "threeline_center",
            ("f0", txtthreelinecenter1.Text),
            ("f1", txtthreelinecenter2.Text),
            ("f2", txtthreelinecenter3.Text))
    End Sub

    Private Sub cmdplayfourlinecenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplayfourlinecenter.Click
        PlayTemplate(
            MainCgLayer,
            "fourline_center",
            ("f0", txtfourlinecenter1.Text),
            ("f1", txtfourlinecenter2.Text),
            ("f2", txtfourlinecenter3.Text),
            ("f3", txtfourlinecenter4.Text))
    End Sub

    Private Sub cmdplaytopleft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaytopleft.Click
        PlayTemplate(MainCgLayer, "top_left", ("f0", txttopleft.Text))
    End Sub

    Private Sub cmdplaytopright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaytopright.Click
        PlayTemplate(MainCgLayer, "top_right", ("f0", txttopright.Text))
    End Sub

    Private Sub cmdclocktotoprightstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclocktotoprightstop.Click
        StopTemplate(MainCgLayer)
    End Sub

    Private Sub cmdplaylivephonein1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaylivephonein1.Click
        PlayTemplate(PhoneInLayer, "live_phonein", ("f0", txtlivephonein1.Text))
    End Sub

    Private Sub cmdplaylivephonein2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaylivephonein2.Click
        PlayTemplate(PhoneInLayer, "live_phonein", ("f0", txtlivephonein2.Text))
    End Sub

    Private Sub cmdstoplivephonein_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstoplivephonein.Click
        StopTemplate(PhoneInLayer)
    End Sub

    Private Sub cmdhidecg_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ucCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub cmdPlayHtmlClock_Click(sender As Object, e As EventArgs) Handles cmdPlayHtmlClock.Click
        SendAmcpCommand("play " & g_int_ChannelNumber & "-" & HtmlClockLayer & " [HTML] " & HtmlClockPath)
    End Sub

    Private Sub cmdstophtmlcgtemplate_Click(sender As Object, e As EventArgs) Handles cmdstophtmlcgtemplate.Click
        SendAmcpCommand("stop " & g_int_ChannelNumber & "-" & HtmlClockLayer)
    End Sub

    Private Sub cmdPlayHtmlTwolineCenter_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub PlayTemplate(layer As Integer, templateName As String, ParamArray templateData() As (Key As String, Value As String))
        On Error Resume Next

        CasparCGDataCollection.Clear()

        For Each item In templateData
            CasparCGDataCollection.SetData(item.Key, item.Value)
        Next

        With CasparDevice.Channels(g_int_ChannelNumber - 1).CG
            .Add(layer, BuildTemplatePath(templateName), True, CasparCGDataCollection.ToAMCPEscapedXml)
            .Play(layer)
        End With
    End Sub

    Private Sub StopTemplate(layer As Integer)
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(layer)
    End Sub

    Private Sub SendAmcpCommand(commandText As String)
        On Error Resume Next
        CasparDevice.SendString(commandText)
    End Sub

    Private Function BuildTemplatePath(templateName As String) As String
        Dim templateRoot = txtTemplateDirectoryCg.Text.TrimEnd(TemplateDirectorySeparator)
        Return templateRoot & "/" & templateName
    End Function
End Class
