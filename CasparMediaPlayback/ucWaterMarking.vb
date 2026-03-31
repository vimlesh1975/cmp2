Public Class ucWaterMarking
    Private Function GetWaterMarkLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmbvideolayerwm.Text
    End Function

    Private Function FormatMixerValue(value As Decimal) As String
        Return Replace(value, ",", ".")
    End Function

    Private Sub SendWaterMarkMixer(commandName As String, commandValue As String)
        CasparDevice.SendString("mixer " & GetWaterMarkLayerAddress() & " " & commandName & " " & commandValue)
    End Sub

    Private Sub nfillxwm_ValueChanged(sender As Object, e As EventArgs) Handles nfillxwm.ValueChanged, nfillywm.ValueChanged, nfillwidthwm.ValueChanged, nfillheightwm.ValueChanged
        On Error Resume Next
        SendWaterMarkMixer("fill", FormatMixerValue(nfillxwm.Value) & " " & FormatMixerValue(nfillywm.Value) & " " & FormatMixerValue(nfillwidthwm.Value) & " " & FormatMixerValue(nfillheightwm.Value))
    End Sub

    Private Sub cmdfillwm_Click(sender As Object, e As EventArgs) Handles cmdfillwm.Click
        On Error Resume Next
        mixerfillresetwm()
    End Sub

    Sub mixerfillresetwm()
        On Error Resume Next
        nfillxwm.Value = 0
        nfillywm.Value = 0
        nfillwidthwm.Value = 1
        nfillheightwm.Value = 1
    End Sub

    Private Sub nopacitywm_ValueChanged(sender As Object, e As EventArgs) Handles nopacitywm.ValueChanged
        On Error Resume Next
        SendWaterMarkMixer("opacity", FormatMixerValue(nopacitywm.Value))
    End Sub

    Private Sub cmdhidegbwm_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        Me.Hide()
    End Sub

    Private Sub cmdstopwm_Click(sender As Object, e As EventArgs) Handles cmdstopwm.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmbvideolayerwm.Text), Int(cmbvideolayerwm.Text))
    End Sub

    Private Sub cmdplaywm_Click(sender As Object, e As EventArgs) Handles cmdplaywm.Click
        On Error Resume Next
        SendWaterMarkMixer("opacity", FormatMixerValue(nopacitywm.Value))
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("f0", cmbwm.Text)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmbvideolayerwm.Text), Int(cmbvideolayerwm.Text), txtWaterMarkingTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Play(Int(cmbvideolayerwm.Text), Int(cmbvideolayerwm.Text))
    End Sub

    Private Sub cmdopacitywm_Click(sender As Object, e As EventArgs) Handles cmdopacitywm.Click
        On Error Resume Next
        nopacitywm.Value = 1.0
    End Sub

    Private Sub ucWaterMarking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub

    Private Sub chkRandomePosition_CheckedChanged(sender As Object, e As EventArgs) Handles chkRandomePosition.CheckedChanged
        If chkRandomePosition.Checked Then
            tmrRandome.Interval = 1000 * (txtTimerInterval.Text)
            tmrRandome.Enabled = True
        Else
            tmrRandome.Enabled = False
        End If
    End Sub

    Private Sub tmrRandome_Tick(sender As Object, e As EventArgs) Handles tmrRandome.Tick
        Dim valuex As Decimal = (Val(txtmaxX.Text - txtminX.Text)) * Rnd() + txtminX.Text
        Dim valuey As Decimal = (Val(txtmaxY.Text - txtminY.Text)) * Rnd() + txtminY.Text
        nfillxwm.Value = valuex
        nfillywm.Value = valuey
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub txtTimerInterval_TextChanged(sender As Object, e As EventArgs) Handles txtTimerInterval.TextChanged
        On Error Resume Next
        tmrRandome.Interval = 1000 * (txtTimerInterval.Text)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub

    Private Sub cmdSetMaxY_Click(sender As Object, e As EventArgs) Handles cmdSetMaxY.Click
        txtmaxY.Text = nfillywm.Value
    End Sub

    Private Sub cmdSetMaxX_Click(sender As Object, e As EventArgs) Handles cmdSetMaxX.Click
        txtmaxX.Text = nfillxwm.Value
    End Sub

    Private Sub cmdSetMinY_Click(sender As Object, e As EventArgs) Handles cmdSetMinY.Click
        txtminY.Text = nfillywm.Value
    End Sub

    Private Sub cmdSetMinX_Click(sender As Object, e As EventArgs) Handles cmdSetMinX.Click
        txtminX.Text = nfillxwm.Value
    End Sub
End Class
