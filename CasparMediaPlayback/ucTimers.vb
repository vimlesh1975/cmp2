Public Class ucTimers
    Private Const TemplateCountdown As String = "/count_down_timer/count_down_timer"
    Private Const TemplateQuiz As String = "/quiz_time/timer"
    Private Const TemplateFullTime As String = "/full_time/off_air_logger_clock"
    Private Const TemplateCountUp As String = "/count_up_timer/count_up_timer"
    Private Const TemplateClock As String = "/time/clock"
    Private Const TemplateClipCountdown As String = "/ClipCountDown/ClipCountDown2"
    Private Const TemplateProgramCountdown As String = "/ProgramCountDown/ProgramCountDown1"
    Private Const TemplateBackIn As String = "/backin/backin"
    Private Const LoopVideoStopCommand As String = "Stop 1-499"

    Private Sub cmdstoptimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdstoptimer.Click
        On Error Resume Next
        StopTimerLayer()
        tmrclipcountdown.Enabled = False
    End Sub

    Private Sub cmdplaycountdowntimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdplaycountdowntimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateCountdown, Sub()
                                                 CasparCGDataCollection.SetData("initialvalue", txtintialvaluecdt.Text)
                                             End Sub)
    End Sub

    Private Sub cmdplayquiztimetimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdplayquiztimetimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateQuiz)
    End Sub

    Private Sub cmdplayfulltimetimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdplayfulltimetimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateFullTime)
    End Sub

    Private Sub cmdplaycountuptimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdplaycountuptimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateCountUp, Sub()
                                               CasparCGDataCollection.SetData("initialvalue", txtintialvaluecut.Text)
                                           End Sub)
    End Sub

    Private Sub cmdplayclocktimer_Click(sender As System.Object, e As System.EventArgs) Handles cmdplayclocktimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateClock)
    End Sub

    Private Sub cmdhidetimers_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub tmrclipcountdown_Tick(sender As Object, e As EventArgs) Handles tmrclipcountdown.Tick
        On Error Resume Next
        UpdateClipCountdownData()
    End Sub

    Private Sub cmdplayclipCountDowntimer_Click(sender As Object, e As EventArgs) Handles cmdplayclipCountDowntimer.Click
        On Error Resume Next
        SetClipCountdownData()
        AddTimerTemplate(TemplateClipCountdown)
        tmrclipcountdown.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateProgramCountdown, Sub()
                                                        CasparCGDataCollection.SetData("ProgramName", txtProgramName.Text)
                                                        CasparCGDataCollection.SetData("someDate", txtsheduleTime.Text)
                                                        CasparCGDataCollection.SetData("ExactTime", txtExactTime.Text)
                                                    End Sub)
    End Sub

    Private Sub cmdloopvideo_Click(sender As Object, e As EventArgs) Handles cmdloopvideo.Click
        On Error Resume Next
        CasparDevice.SendString(txtloopvideo.Text)
    End Sub

    Private Sub cmdStoploop_Click(sender As Object, e As EventArgs) Handles cmdStoploop.Click
        On Error Resume Next
        CasparDevice.SendString(LoopVideoStopCommand)
    End Sub

    Private Sub cmdStopBoth_Click(sender As Object, e As EventArgs) Handles cmdStopBoth.Click
        On Error Resume Next
        CasparDevice.SendString(LoopVideoStopCommand)
        StopTimerLayer()
    End Sub

    Private Sub ucTimers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtsheduleTime.Text = MonthName(Now.Month, 1) & " " & Now.Day & " " & "20:30:00 GMT+" & Replace(Mid(DateTimeOffset.Now.Offset.ToString, 1, 5), ":", "") & " " & Now.Year
    End Sub

    Private Sub cmdplayBackinTimer_Click(sender As Object, e As EventArgs) Handles cmdplayBackinTimer.Click
        On Error Resume Next
        PlayTimerTemplate(TemplateBackIn, Sub()
                                              CasparCGDataCollection.SetData("f0", "Back In")
                                              CasparCGDataCollection.SetData("initialvalue", (Val(txtInitialValueofBackinTimer.Text) * 1000) + 2000)
                                          End Sub)
    End Sub

    Private Function GetTimerLayerNumber() As Integer
        Return Int(cmbvflayertimers.Text)
    End Function

    Private Function BuildTimerTemplatePath(relativeTemplatePath As String) As String
        Return txttimersTemplate.Text & relativeTemplatePath
    End Function

    Private Sub ClearTimerData()
        CasparCGDataCollection.Clear()
    End Sub

    Private Sub AddTimerTemplate(relativeTemplatePath As String)
        Dim layerNumber As Integer = GetTimerLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(layerNumber, layerNumber, BuildTimerTemplatePath(relativeTemplatePath), True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub UpdateTimerTemplate()
        Dim layerNumber As Integer = GetTimerLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(layerNumber, layerNumber, CasparCGDataCollection)
    End Sub

    Private Sub StopTimerLayer()
        Dim layerNumber As Integer = GetTimerLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(layerNumber, layerNumber)
    End Sub

    Private Sub PlayTimerTemplate(relativeTemplatePath As String, Optional configureData As Action = Nothing)
        ClearTimerData()
        If configureData IsNot Nothing Then
            configureData()
        End If
        AddTimerTemplate(relativeTemplatePath)
    End Sub

    Private Sub SetClipCountdownData()
        ClearTimerData()
        CasparCGDataCollection.SetData("time", frmmediaplayer.lblremainintime.Text)
        CasparCGDataCollection.SetData("filename", GetCurrentClipFileName())
    End Sub

    Private Sub UpdateClipCountdownData()
        SetClipCountdownData()
        UpdateTimerTemplate()
    End Sub

    Private Function GetCurrentClipFileName() As String
        Dim pathParts As Array = Split(Replace(frmmediaplayer.ucCasparcgWindow1.lblplaying.Text, "\", "/"), "/")
        Return Split(pathParts(pathParts.Length - 1), ".")(0)
    End Function
End Class
