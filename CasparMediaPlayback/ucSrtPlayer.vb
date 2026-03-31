Imports System.IO

Public Class ucSrtPlayer
    Private Sub ConfigureSrtFileDialog(dialog As OpenFileDialog, Optional defaultFile As String = "")
        dialog.Filter = "srt files (*.srt)|*.srt|All files (*.*)|*.*"
        dialog.InitialDirectory = "c:\casparcg\mydata\srt"
        If defaultFile <> "" Then
            dialog.FileName = defaultFile
        End If
    End Sub

    Private Function EncodeSrtText() As String
        Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(dgvsrt.CurrentRow.Cells(3).Value & vbCr & dgvsrt.CurrentRow.Cells(4).Value)
        Return System.Convert.ToBase64String(array)
    End Function

    Private Sub ShiftSrtTimings(direction As Integer)
        For isrt = 0 To dgvsrt.Rows.Count - 1
            dgvsrt.Rows(isrt).Cells(1).Value = FToHMSF(Val(HMSFtoF(dgvsrt.Rows(isrt).Cells(1).Value)) + direction * Val(HMSFtoF(txtvtrstarttime.Text)))
            dgvsrt.Rows(isrt).Cells(2).Value = FToHMSF(Val(HMSFtoF(dgvsrt.Rows(isrt).Cells(2).Value)) + direction * Val(HMSFtoF(txtvtrstarttime.Text)))
        Next
    End Sub

    Private Sub cmdhidesrtplayer_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
    Private Sub cmdstartsrt_Click(sender As System.Object, e As System.EventArgs) Handles cmdstartsrt.Click
        On Error Resume Next
        tmrsrt.Enabled = True
    End Sub
    Private Sub cmdstopsrt_Click(sender As System.Object, e As System.EventArgs) Handles cmdstopsrt.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayersrt.Text), Int(cmblayersrt.Text))
        tmrsrt.Enabled = False
    End Sub

    Private Sub cmdopensrtfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdopensrtfile.Click
        openfilesrtnew()
    End Sub
    Sub openfilesrtnew()
        Dim ofd2 As New OpenFileDialog
        ConfigureSrtFileDialog(ofd2)
        If (ofd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Dim sr As StreamReader = New StreamReader(ofd2.FileName)
            dgvsrt.Rows.Clear()

            Dim aa As String = sr.ReadToEnd()

            Dim bb As Array = Split(aa, vbCrLf + vbNewLine)
            dgvsrt.Rows.Add(bb.Length)
            For ii = 0 To bb.Length - 1
                Dim cc As Array = Split(bb(ii), vbNewLine)
                For isrt = 0 To cc.Length - 1
                    If isrt > 1 Then
                        dgvsrt.Rows(ii).Cells(isrt + 1).Value = cc(isrt)
                    ElseIf isrt = 0 Then
                        dgvsrt.Rows(ii).Cells(isrt).Value = cc(isrt)
                    ElseIf isrt = 1 Then
                        dgvsrt.Rows(ii).Cells(1).Value = Mid(Replace(Split(cc(isrt), "-->")(0), ",", ":"), 1, 9) & Format(Split(Replace(Split(cc(isrt), "-->")(0), ",", ":"), ":")(3) / (25), "00")
                        dgvsrt.Rows(ii).Cells(2).Value = Mid(Replace(Split(cc(isrt), "-->")(1), ",", ":"), 2, 9) & Format(Split(Replace(Split(cc(isrt), "-->")(1), ",", ":"), ":")(3) / (25), "00")
                    End If
                Next
            Next
        End If
        lblfilenamesrt.Text = ofd2.FileName
    End Sub
    Sub openfilesrt()
        Dim ofd2 As New OpenFileDialog
        ConfigureSrtFileDialog(ofd2, "c:\casparcg\mydata\srt\od_hindi.srt")
        Dim sr As StreamReader = New StreamReader(ofd2.FileName)
        dgvsrt.Rows.Clear()

        Dim aa As String = sr.ReadToEnd()

        Dim bb As Array = Split(aa, vbCrLf + vbNewLine)
        dgvsrt.Rows.Add(bb.Length)
        For ii = 0 To bb.Length - 1
            Dim cc As Array = Split(bb(ii), vbNewLine)
            For isrt = 0 To cc.Length - 1
                If isrt > 1 Then
                    dgvsrt.Rows(ii).Cells(isrt + 1).Value = cc(isrt)
                ElseIf isrt = 0 Then
                    dgvsrt.Rows(ii).Cells(isrt).Value = cc(isrt)
                ElseIf isrt = 1 Then
                    dgvsrt.Rows(ii).Cells(1).Value = Mid(Replace(Split(cc(isrt), "-->")(0), ",", ":"), 1, 9) & Format(Split(Replace(Split(cc(isrt), "-->")(0), ",", ":"), ":")(3) / (25), "00")
                    dgvsrt.Rows(ii).Cells(2).Value = Mid(Replace(Split(cc(isrt), "-->")(1), ",", ":"), 2, 9) & Format(Split(Replace(Split(cc(isrt), "-->")(1), ",", ":"), ":")(3) / (25), "00")
                End If
            Next
        Next
        lblfilenamesrt.Text = ofd2.FileName
    End Sub

    Private Sub tmrsrt_Tick(sender As System.Object, e As System.EventArgs) Handles tmrsrt.Tick
        On Error Resume Next
        For isrt = 0 To dgvsrt.Rows.Count - 1
            If Mid((frmmediaplayer.ucCasparcgWindow1.lblhmsf.Text), 1, 9) = Mid(FToHMSF(HMSFtoF(dgvsrt.Rows(isrt).Cells(1).Value) - HMSFtoF((txttemplateresponseframe.Text))), 1, 9) Then
                dgvsrt.CurrentCell = dgvsrt.Rows(isrt).Cells(0)
                playsrt()
            End If
            If Mid((frmmediaplayer.ucCasparcgWindow1.lblhmsf.Text), 1, 9) = Mid(FToHMSF(HMSFtoF(dgvsrt.Rows(isrt).Cells(2).Value) - HMSFtoF((txttemplateresponseframe.Text))), 1, 9) Then
                dgvsrt.CurrentCell = dgvsrt.Rows(isrt).Cells(0)
                stopsrtr()
            End If
        Next
    End Sub
    Private Sub playsrt()
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("xf0", EncodeSrtText())
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayersrt.Text), Int(cmblayersrt.Text), txtSRTTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub stopsrtr()
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayersrt.Text), Int(cmblayersrt.Text))
    End Sub

    Private Sub cmdaddtime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdaddtime.Click
        On Error Resume Next
        ShiftSrtTimings(1)
    End Sub


    Private Sub cmdsubstracttime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsubstracttime.Click
        On Error Resume Next
        ShiftSrtTimings(-1)
    End Sub

    Private Sub ucSrtPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openfilesrt()
    End Sub

End Class
