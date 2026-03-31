Public Class ucOffAirLogger
    Private Sub ucOffAirLogger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureOffAirLogger(UcnewOffAirLogger1, g_int_ChannelNumber)
    End Sub

    Private Sub UcnewOffAirLogger1_Load(sender As Object, e As EventArgs) Handles UcnewOffAirLogger1.Load
    End Sub

    Private Sub cmdhideoffairlogger_Click(sender As Object, e As EventArgs)
        CloseOffAirLogger(UcnewOffAirLogger1, False)
        Parent.Controls.Remove(Me)
    End Sub

    Private Sub ucOffAirLogger_Load_1(sender As Object, e As EventArgs)
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

    Private Sub CloseOffAirLogger(logger As ucnewOffAirLogger, hideOnly As Boolean)
        logger.stoprecordoal()
        logger.cmdoutcasparcgwindowrecording.PerformClick()
        logger.stoposcserver()

        If hideOnly Then
            logger.Hide()
        End If
    End Sub
End Class
