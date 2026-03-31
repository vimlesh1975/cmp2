Public Class ucOSD
    Dim selectedcolor As String = "yellow"

    Private Sub cmdStartDrawing_Click(sender As Object, e As EventArgs) Handles cmdStartDrawing.Click
        On Error Resume Next
        CasparDevice.SendString("play " & GetOsdLayerAddress() & " [HTML] " & """" & txOSDlTemplate.Text & """")
        SendOsdCall("color(" & selectedcolor & ")")
        SendOsdCall("sety(" & nBrushWidth.Value & ")")
        SendOsdCall("resizecanvas()")
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        On Error Resume Next
        SendOsdCall("erase()")
    End Sub

    Private Sub myevent(sender As Object, e As EventArgs) Handles rdoBlack.CheckedChanged, rdoBlue.CheckedChanged, rdoGreen.CheckedChanged, rdoOrange.CheckedChanged, rdoRed.CheckedChanged, rdoWhite.CheckedChanged, rdoYellow.CheckedChanged, rdoNone.CheckedChanged
        selectedcolor = GetSelectedOsdColor()
        SendOsdCall("color(" & selectedcolor & ")")
    End Sub

    Private Sub cmdhideOSD_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdStopDrawing_Click(sender As Object, e As EventArgs) Handles cmdStopDrawing.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & GetOsdLayerAddress())
    End Sub

    Private Sub nBrushWidth_ValueChanged(sender As Object, e As EventArgs) Handles nBrushWidth.ValueChanged
        SendOsdCall("sety(" & nBrushWidth.Value & ")")
    End Sub

    Private Function GetOsdLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayerOSD.Text
    End Function

    Private Sub SendOsdCall(commandText As String)
        CasparDevice.SendString("call " & GetOsdLayerAddress() & " " & commandText)
    End Sub

    Private Function GetSelectedOsdColor() As String
        If rdoBlack.Checked Then Return "black"
        If rdoBlue.Checked Then Return "blue"
        If rdoGreen.Checked Then Return "green"
        If rdoOrange.Checked Then Return "orange"
        If rdoRed.Checked Then Return "red"
        If rdoWhite.Checked Then Return "white"
        If rdoNone.Checked Then Return "none"
        Return "yellow"
    End Function
End Class
