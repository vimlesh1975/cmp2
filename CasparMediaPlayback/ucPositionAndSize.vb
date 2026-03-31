Public Class ucPositionAndSize
    Private Sub cmdfill_Click(sender As Object, e As EventArgs) Handles cmdfill.Click
        On Error Resume Next
        mixerfillreset()
    End Sub

    Sub mixerfillreset()
        On Error Resume Next
        nfillx.Value = 0
        nfilly.Value = 0
        nfillwidth.Value = 1
        nfillheight.Value = 1
    End Sub

    Private Sub nfillx_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nfillx.ValueChanged, nfilly.ValueChanged, nfillwidth.ValueChanged, nfillheight.ValueChanged
        On Error Resume Next
        CasparDevice.SendString("mixer " & GetPositionAndSizeLayerAddress() & " fill " & GetFillCommandValues())
    End Sub

    Private Sub cmdhidegboscmonitor_Click(sender As Object, e As EventArgs) Handles cmdhidegboscmonitor.Click
        Parent.Controls.Remove(Me)
    End Sub

    Private Function GetPositionAndSizeLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmbVideoLayerforPositionAndSize.Text
    End Function

    Private Function GetFillCommandValues() As String
        Return NormalizeMixerValue(nfillx.Value) & " " &
               NormalizeMixerValue(nfilly.Value) & " " &
               NormalizeMixerValue(nfillwidth.Value) & " " &
               NormalizeMixerValue(nfillheight.Value)
    End Function

    Private Function NormalizeMixerValue(value As Object) As String
        Return Replace(value, ",", ".")
    End Function
End Class
