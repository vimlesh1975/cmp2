Imports System.IO

Public Class ucHtmlScroller
    Dim iPauseResumeV As Integer = 0

    Private Sub cmdhidegbhtmlscroller_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmbfonthtmlscroll_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfonthtmlscroll.SelectedIndexChanged
        On Error Resume Next
        txtcrawlhtmlscroll.Font = New Font(cmbfonthtmlscroll.Text, frmmediaplayer.nfontsizeforall.Value)
        SendScrollerCall("font", Replace(cmbfonthtmlscroll.Text, " ", Chr(2)))
    End Sub

    Private Sub nsizehtmlscroll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nsizehtmlscroll.ValueChanged
        On Error Resume Next
        SendScrollerCall("fontsize", nsizehtmlscroll.Value)
    End Sub

    Private Sub nspeedhtmlscroll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nspeedhtmlscroll.ValueChanged
        On Error Resume Next
        SendScrollerCall("speed", nspeedhtmlscroll.Value)
    End Sub

    Private Sub nyhtmlscroll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nyhtmlscroll.ValueChanged
        On Error Resume Next
        SendScrollerCall("stripy", nyhtmlscroll.Value)
    End Sub

    Private Sub cmdcolorhtmlscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcolorhtmlscroll.Click
        On Error Resume Next

        Dim aa As New ColorDialog
        If aa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdcolorhtmlscroll.ForeColor = aa.Color
            cmdstripcolorhtmlscroll.ForeColor = aa.Color
            SendScrollerCall("fontcolor", ColorTranslator.ToHtml(cmdstripcolorhtmlscroll.ForeColor))
        End If
    End Sub

    Private Sub cmdstripcolorhtmlscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstripcolorhtmlscroll.Click
        On Error Resume Next

        Dim aa As New ColorDialog
        If aa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdstripcolorhtmlscroll.BackColor = aa.Color
            cmdcolorhtmlscroll.BackColor = aa.Color
            SendScrollerCall("stripcolor", ColorTranslator.ToHtml(cmdstripcolorhtmlscroll.BackColor))
        End If
    End Sub

    Private Sub cmdstopcrawlhtmlscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopcrawlhtmlscroll.Click
        On Error Resume Next
        CasparDevice.SendString("play " & GetScrollerLayerAddress() & " empty mix 20")
    End Sub

    Private Sub chkltrhtmlscroll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkltrhtmlscroll.CheckedChanged
        If chkltrhtmlscroll.Checked Then
            SendScrollerCommand("start2()")
        Else
            SendScrollerCommand("start1()")
        End If
    End Sub

    Private Sub cmdfilehtmlscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfilehtmlscroll.Click
        On Error Resume Next

        ofd1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ofd1.InitialDirectory = "C:\casparcg\mydata\html_scroll\"
        If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso ofd1.FileName <> "" Then
            ReadTextFile(New FileInfo(ofd1.FileName).FullName, txtcrawlhtmlscroll)
        End If
    End Sub

    Private Sub pichtmlscroller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pichtmlscroller.Click
        On Error Resume Next
        Dim aa As New OpenFileDialog

        If aa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            pichtmlscroller.ImageLocation = aa.FileName
            SendScrollerCall("bullet", Replace(pichtmlscroller.ImageLocation, "\", "/"))
        End If
    End Sub

    Private Sub cmdshowhtmlscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowhtmlscroll.Click
        On Error Resume Next
        iPauseResumeV = 0

        CasparDevice.SendString("play " & GetScrollerLayerAddress() & " [HTML] " & """" & txthtmlscollerTemplate.Text & """" & " mix 40")
        SendScrollerText(GetScrollerText(txtcrawlhtmlscroll.Text, False))
        SendHorizontalScrollerSettings()
    End Sub

    Private Sub nyhtmlscrollticker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nyhtmlscrollticker.ValueChanged
        On Error Resume Next
        SendScrollerCall("Tickery", nyhtmlscrollticker.Value)
    End Sub

    Sub enumeratefontsforall()
        On Error Resume Next
        Dim installedFonts As New Drawing.Text.InstalledFontCollection
        For Each fontFamily As FontFamily In installedFonts.Families()
            cmbfonthtmlscroll.Items.Add(fontFamily.Name)
        Next
    End Sub

    Private Sub ucHtmlScroller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enumeratefontsforall()
    End Sub

    Private Sub cmdupodateverticalscroll_Click(sender As Object, e As EventArgs) Handles cmdupodateverticalscroll.Click
        Finaltextforverticalscroll()
    End Sub

    Sub Finaltextforverticalscroll()
        On Error Resume Next
        Dim sourceText As String = If(txtcrawlhtmlscroll.SelectedText = "", txtcrawlhtmlscroll.Text, txtcrawlhtmlscroll.SelectedText)
        SendScrollerText(GetScrollerText(sourceText, True))
    End Sub

    Private Sub txtcrawlhtmlscroll_TextChanged(sender As Object, e As EventArgs) Handles txtcrawlhtmlscroll.TextChanged
    End Sub

    Private Sub txtcrawlhtmlscroll_DoubleClick(sender As Object, e As EventArgs) Handles txtcrawlhtmlscroll.DoubleClick
        txtcrawlhtmlscroll.SelectionStart = txtcrawlhtmlscroll.GetFirstCharIndexOfCurrentLine
        txtcrawlhtmlscroll.SelectionLength = txtcrawlhtmlscroll.Text.Length
    End Sub

    Private Sub cmdpauseresumehtmlscroller_Click(sender As Object, e As EventArgs) Handles cmdpauseresumehtmlscroller.Click
        pauseresumev()
    End Sub

    Sub pauseresumev()
        iPauseResumeV += 1
        If iPauseResumeV = 1 Then
            SendScrollerCommand("pause()")
        Else
            SendScrollerCall("speed", nspeedhtmlscroll.Value)
            iPauseResumeV = 0
        End If
    End Sub

    Sub pauseresumeh()
        iPauseResumeV += 1
        If iPauseResumeV = 1 Then
            SendScrollerCommand("pause()")
        Else
            SendScrollerCommand("resume()")
            iPauseResumeV = 0
        End If
    End Sub

    Sub senddata()
        CasparDevice.SendString("play " & GetScrollerLayerAddress() & " [HTML] " & """" & txthtmlscollerTemplatevertical.Text & """")
        Finaltextforverticalscroll()
        SendVerticalScrollerSettings()
    End Sub

    Private Sub cmdCueFromButtom_Click(sender As Object, e As EventArgs) Handles cmdCueFromButtom.Click
        On Error Resume Next
        iPauseResumeV = 1
        senddata()
        SendScrollerCommand("pause()")
        SendScrollerCommand("cuefrombuttom()")
    End Sub

    Private Sub cmdCueFromMiddle_Click(sender As Object, e As EventArgs) Handles cmdCueFromMiddle.Click
        iPauseResumeV = 1
        senddata()
        SendScrollerCommand("pause()")
        SendScrollerCommand("cuefrommiddle()")
    End Sub

    Private Sub cmdStartFromButtom_Click(sender As Object, e As EventArgs) Handles cmdStartFromButtom.Click
        On Error Resume Next
        iPauseResumeV = 0
        senddata()
        SendScrollerCommand("cuefrombuttom()")
    End Sub

    Private Sub cmdstartFromMiddle_Click(sender As Object, e As EventArgs) Handles cmdstartFromMiddle.Click
        On Error Resume Next
        iPauseResumeV = 0
        senddata()
        SendScrollerCommand("cuefrommiddle()")
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        shuttleproRotate()
    End Sub

    Sub shuttleproRotate()
        On Error Resume Next
        SendScrollerCall("speed", TrackBar1.Value)
    End Sub

    Private Sub TrackBar1_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseUp
        On Error Resume Next
        TrackBar1.Value = 0
        SendScrollerCall("speed", 0)
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
    End Sub

    Private Sub cmdpauseresumehtmlscrollerhorizontal_Click(sender As Object, e As EventArgs) Handles cmdpauseresumehtmlscrollerhorizontal.Click
        pauseresumeh()
    End Sub

    Private Sub cmdFlip2ndChannel_Click(sender As Object, e As EventArgs) Handles cmdFlip2ndChannel.Click
        On Error Resume Next
        CasparDevice.SendString("play 2-210 route://1")
    End Sub

    Private Sub chkFlip_CheckedChanged(sender As Object, e As EventArgs) Handles chkFlip.CheckedChanged
        On Error Resume Next
        If chkFlip.Checked Then
            CasparDevice.SendString("mixer 2-210 fill 1 0 -1 1")
        Else
            CasparDevice.SendString("mixer 2-210 fill 0 0 1 1")
        End If
    End Sub

    Private Sub chkShuttlePro_CheckedChanged(sender As Object, e As EventArgs) Handles chkShuttlePro.CheckedChanged
    End Sub

    Private Sub ucHtmlScroller_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If chkShuttlePro.Checked Then
            If e.KeyCode = Keys.F7 Then
                SendScrollerCall("speed", 0)
            End If
            If e.KeyCode = Keys.F14 Then
                cmdCueFromMiddle.PerformClick()
            End If
            If e.KeyCode = Keys.F15 Then
                pauseresumev()
            End If
            If e.KeyCode = Keys.F16 Then nspeedhtmlscroll.Value = 3
            If e.KeyCode = Keys.F17 Then nspeedhtmlscroll.Value = 4
            If e.KeyCode = Keys.F18 Then nspeedhtmlscroll.Value = 5
            If e.KeyCode = Keys.F19 Then nspeedhtmlscroll.Value = 6
            If e.KeyCode = Keys.F20 Then nspeedhtmlscroll.Value = 10
            If e.KeyCode = Keys.F21 Then nspeedhtmlscroll.Value = -3
            If e.KeyCode = Keys.F22 Then nspeedhtmlscroll.Value = -4
            If e.KeyCode = Keys.F23 Then nspeedhtmlscroll.Value = -5
            If e.KeyCode = Keys.F24 Then nspeedhtmlscroll.Value = -10
        End If
    End Sub

    Private Sub nscalexfromCenter_ValueChanged(sender As Object, e As EventArgs) Handles nscalexfromCenter.ValueChanged, nscaleyfromCenter.ValueChanged
        On Error Resume Next
        CasparDevice.SendString("mixer " & GetScrollerLayerAddress() & " fill " &
                                ((1 - nscalexfromCenter.Value) / 2).ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
                                ((1 - nscaleyfromCenter.Value) / 2).ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
                                nscalexfromCenter.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
                                nscaleyfromCenter.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))
    End Sub

    Private Sub cmdResetScalefromCenter_Click(sender As Object, e As EventArgs) Handles cmdResetScalefromCenter.Click
        On Error Resume Next
        nscalexfromCenter.Value = 1
        nscaleyfromCenter.Value = 1
    End Sub

    Private Function GetScrollerLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayerhtmlscroll.Text
    End Function

    Private Sub SendScrollerCommand(commandText As String)
        CasparDevice.SendString("call " & GetScrollerLayerAddress() & " " & commandText)
    End Sub

    Private Sub SendScrollerCall(functionName As String, value As Object)
        SendScrollerCommand(functionName & "('" & value.ToString() & "')")
    End Sub

    Private Function GetScrollerText(sourceText As String, preserveLineBreaks As Boolean) As String
        Dim preparedText As String = If(preserveLineBreaks, sourceText, Replace(sourceText, vbCrLf, ""))
        Return replacestring1(preparedText)
    End Function

    Private Sub SendScrollerText(preparedText As String)
        If chkbase64htmlscroller.Checked Then
            Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(preparedText)
            SendScrollerCall("marqueedatabase64", System.Convert.ToBase64String(array))
        Else
            SendScrollerCall("marqueedata", preparedText)
        End If
    End Sub

    Private Sub SendScrollerStartDirection()
        If chkltrhtmlscroll.Checked Then
            SendScrollerCommand("start2()")
        Else
            SendScrollerCommand("start1()")
        End If
    End Sub

    Private Sub SendHorizontalScrollerSettings()
        SendScrollerCall("bullet", Replace(pichtmlscroller.ImageLocation, "\", "/"))
        SendScrollerStartDirection()
        SendScrollerCall("fontcolor", ColorTranslator.ToHtml(cmdstripcolorhtmlscroll.ForeColor))
        SendScrollerCall("stripcolor", ColorTranslator.ToHtml(cmdstripcolorhtmlscroll.BackColor))
        SendScrollerCall("stripy", nyhtmlscroll.Value)
        SendScrollerCall("fontsize", nsizehtmlscroll.Value)
        SendScrollerCall("font", Replace(cmbfonthtmlscroll.Text, " ", Chr(2)))
        SendScrollerCall("Tickery", nyhtmlscrollticker.Value)
        SendScrollerCall("speed", nspeedhtmlscroll.Value)
    End Sub

    Private Sub SendVerticalScrollerSettings()
        SendScrollerStartDirection()
        SendScrollerCall("fontcolor", ColorTranslator.ToHtml(cmdstripcolorhtmlscroll.ForeColor))
        SendScrollerCall("font", Replace(cmbfonthtmlscroll.Text, " ", Chr(2)))
        SendScrollerCall("fontsize", nsizehtmlscroll.Value)
        SendScrollerCall("speed", nspeedhtmlscroll.Value)
    End Sub
End Class
