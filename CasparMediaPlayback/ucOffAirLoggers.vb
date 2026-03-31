Public Class ucOffAirLoggers
    Private Sub UcOffAirLoggers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim loggers() As ucnewOffAirLogger = {UcnewOffAirLogger1, UcnewOffAirLogger2, UcnewOffAirLogger3, UcnewOffAirLogger4}
        For index As Integer = 0 To loggers.Length - 1
            ConfigureOffAirLogger(loggers(index), index + 1)
        Next
    End Sub

    Private Sub cmdhideoffairlogger1_Click(sender As Object, e As EventArgs) Handles cmdhideoffairlogger1.Click
        HideOffAirLogger(UcnewOffAirLogger1, DirectCast(sender, Control))
    End Sub

    Private Sub cmdhideoffairlogger2_Click(sender As Object, e As EventArgs) Handles cmdhideoffairlogger2.Click
        HideOffAirLogger(UcnewOffAirLogger2, DirectCast(sender, Control))
    End Sub

    Private Sub cmdhideoffairlogger4_Click(sender As Object, e As EventArgs) Handles cmdhideoffairlogger4.Click
        HideOffAirLogger(UcnewOffAirLogger4, DirectCast(sender, Control))
    End Sub

    Private Sub cmdhideoffairlogger3_Click(sender As Object, e As EventArgs) Handles cmdhideoffairlogger3.Click
        HideOffAirLogger(UcnewOffAirLogger3, DirectCast(sender, Control))
    End Sub

    Private Sub Cmdhideoffairlogger_Click(sender As Object, e As EventArgs)
        Dim loggers() As ucnewOffAirLogger = {UcnewOffAirLogger1, UcnewOffAirLogger2, UcnewOffAirLogger3, UcnewOffAirLogger4}
        For Each logger As ucnewOffAirLogger In loggers
            CloseOffAirLogger(logger, False)
        Next

        Me.Parent.Controls("ucOffAirLoggers1").Dispose()
    End Sub

    Private Sub ConfigureOffAirLogger(logger As ucnewOffAirLogger, channelNumber As Integer)
        With logger
            .ichannel = channelNumber
            .cmbscreenConsumres.Text = "Screen consumer [" & .ichannel & "|1080i5000]"
            .oscstartandregister(.ichannel, 6250 + .ichannel)
            .txtmediadirectoryoal.Text = mediafullpath & "ch" & .ichannel & "/"
            .cmbliveoal.Text = .ichannel
            .lblChannel.Text = "Channel " & .ichannel
        End With
    End Sub

    Private Sub HideOffAirLogger(logger As ucnewOffAirLogger, hideButton As Control)
        CloseOffAirLogger(logger, True)
        hideButton.Hide()
    End Sub

    Private Sub CloseOffAirLogger(logger As ucnewOffAirLogger, hideOnly As Boolean)
        logger.stoprecordoal()
        logger.cmdoutcasparcgwindowrecording.PerformClick()
        logger.stoposcserver()

        If hideOnly Then
            logger.Hide()
        End If
    End Sub
End Class
