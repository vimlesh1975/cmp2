Imports System.IO
Imports Svt.Caspar
Imports Svt.Network
Public Class ucSceneScroller

    Dim casparcgdatacollection As New CasparCGDataCollection
    Dim g_int_ChannelNumber As Integer = 1

    Private Sub ConfigureSceneScrollerDialog(dialog As OpenFileDialog)
        dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        dialog.InitialDirectory = "c:\casparcg\mydata\HorizontalScroll2\"
    End Sub

    Private Function BuildSceneScrollerText() As String
        Dim lines As Array = Split(txtcrawl2.Text, vbCrLf)
        Dim output As String = ""
        For ii = LBound(lines) To UBound(lines)
            output &= " ** " & lines(ii)
        Next
        Return output
    End Function

    Private Sub UpdateSceneScrollerData(dataKey As String, dataValue As Object)
        casparcgdatacollection.Clear()
        casparcgdatacollection.SetData(dataKey, dataValue)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmblayerhs2.Text), Int(cmblayerhs2.Text), casparcgdatacollection)
    End Sub

    Private Sub cmdhidegbhs2_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdfile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfile2.Click
        On Error Resume Next
        ConfigureSceneScrollerDialog(ofd1)
        If (ofd1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If (ofd1.FileName <> "") Then
                ReadTextFile(ofd1.FileName, txtcrawl2)
            End If
        End If
    End Sub
    Public Sub ReadTextFile(ByVal sFileName As String, ByVal ttt As TextBox)
        On Error Resume Next
        Using objTextReader As System.IO.TextReader = New StreamReader(sFileName)
            ttt.Text = objTextReader.ReadToEnd()
        End Using
    End Sub
    Private Sub cmdshowcrawl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowcrawl2.Click
        On Error Resume Next
        casparcgdatacollection.Clear()
        casparcgdatacollection.SetData("text", BuildSceneScrollerText())
        casparcgdatacollection.SetData("speed", Int(nspeed2.Value))
        casparcgdatacollection.SetData("iterations", 1000000)
        casparcgdatacollection.SetData("plateposition", ny2.Text)
        casparcgdatacollection.SetData("stripcolor", lblstripcolor2.Text)
        casparcgdatacollection.SetData("opacity", nopacity.Value)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayerhs2.Text), Int(cmblayerhs2.Text), txtSceneTemplate.Text, True, casparcgdatacollection.ToAMCPEscapedXml)
    End Sub

    Private Sub cmdstopcrawl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopcrawl2.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayerhs2.Text), Int(cmblayerhs2.Text))
    End Sub
    Private Sub nspeed2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nspeed2.ValueChanged
        On Error Resume Next
        UpdateSceneScrollerData("speed", nspeed2.Value)
    End Sub
    Private Sub txtcrawl2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcrawl2.TextChanged
        On Error Resume Next
        UpdateSceneScrollerData("xf0", Replace(BuildSceneScrollerText(), " ** ", " "))
    End Sub
    Private Sub ny2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ny2.ValueChanged
        On Error Resume Next
        UpdateSceneScrollerData("plateposition", ny2.Text)
    End Sub
    Private Sub nopacity_ValueChanged(sender As Object, e As EventArgs) Handles nopacity.ValueChanged
        On Error Resume Next
        UpdateSceneScrollerData("opacity", nopacity.Value)
    End Sub
End Class
