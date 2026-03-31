
Imports System.Net
Public Class ucnewSM2
    Dim WithEvents spv As clsShuttleProV2.clsShuttleProV2
    Private Const SlowMotionLayer As Integer = 1
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        On Error Resume Next
        Process.Start("http://casparcg.com/builds/CasparCG%20Server/2.1.0/")
    End Sub
    Private Sub cmdspeed25sm2_Click(sender As Object, e As EventArgs) Handles cmdspeed25sm2.Click
        On Error Resume Next
        SetPlaybackSpeed(0.25)
    End Sub
    Private Sub nSlowMotionforwardsm2_ValueChanged(sender As Object, e As EventArgs) Handles nSlowMotionforwardsm2.ValueChanged
        On Error Resume Next
        SetPlaybackSpeed(nSlowMotionforwardsm2.Value)
    End Sub
    Private Sub cmdspeed100sm2_Click(sender As Object, e As EventArgs) Handles cmdspeed100sm2.Click
        On Error Resume Next
        SetPlaybackSpeed(1)
    End Sub
    Private Sub cmdspeed75sm2_Click(sender As Object, e As EventArgs) Handles cmdspeed75sm2.Click
        On Error Resume Next
        SetPlaybackSpeed(0.75)
    End Sub
    Private Sub cmdspeed50sm2_Click(sender As Object, e As EventArgs) Handles cmdspeed50sm2.Click
        On Error Resume Next
        SetPlaybackSpeed(0.5)

    End Sub
    Private Sub nSm2_ValueChanged(sender As Object, e As EventArgs) Handles nSm2.ValueChanged
        On Error Resume Next
        SetPlaybackSpeed(nSm2.Value)

    End Sub
    Private Sub cmdspeed0sm2_Click(sender As Object, e As EventArgs) Handles cmdspeed0sm2.Click
        On Error Resume Next
        SetPlaybackSpeed(0)
    End Sub

    Private Sub cmdhidesm2_Click(sender As Object, e As EventArgs) Handles cmdhidesm2.Click
        Me.Hide()
    End Sub

    Private Sub cmdshowcasparcgwindowrecording_Click(sender As Object, e As EventArgs) Handles cmdshowcasparcgwindowrecording.Click
        On Error Resume Next
        SetProcessParentrecorder("casparcg", cmbscreenConsumres, pnlrecording)
    End Sub
    Private Sub cmdoutcasparcgwindowrecording_Click(sender As Object, e As EventArgs) Handles cmdoutcasparcgwindowrecording.Click
        On Error Resume Next
        If Not parentedProcess1 Is Nothing Then
            SetParent(parentedProcess1.MainWindowHandle, Nothing)
        End If
    End Sub
    Public parentedProcess1 As Process
    Public Sub SetProcessParentrecorder(ByVal processName As String, ByVal cmb As ComboBox, ByVal pnl As Panel)
        On Error Resume Next
        'Retrieve an array of running processes with the given name
        Dim processes() As Process = Process.GetProcessesByName(processName)
        Dim iprocess As Integer

        For iprocess = 0 To processes.GetUpperBound(0)
            If processes(iprocess).MainWindowTitle = cmb.Text Then Exit For
        Next
        parentedProcess1 = processes(iprocess)
        SetParent(parentedProcess1.MainWindowHandle, pnl.Handle)
        SendMessage(parentedProcess1.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

    End Sub

    Private Sub TrackBarseek_Scroll(sender As Object, e As EventArgs) Handles TrackBarseek.Scroll
        'no code
    End Sub
    Private Sub tmrpreview_Tick(sender As Object, e As EventArgs) Handles tmrpreview.Tick
        On Error Resume Next
        SendLoadSeekCommand(TrackBarseek.Value)
    End Sub
    Private Sub TrackBarseek_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBarseek.MouseDown
        On Error Resume Next
        tmrpreview.Interval = 100 '
        tmrpreview.Enabled = True
    End Sub

    Private Sub TrackBarseek_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBarseek.MouseUp
        On Error Resume Next
        SendLoadSeekCommand(TrackBarseek.Value)
        lblcurrentframe.Text = TrackBarseek.Value '
        tmrpreview.Enabled = False

        ucPlaylist.tmrduration.Enabled = True
    End Sub

    Private Sub ucnewSM2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbscreenConsumres.DataSource = New BindingSource(screenConsumres, "")
    End Sub
    Private Sub cmbChannel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChannel.SelectedIndexChanged
        Label2.Text = "Channel " & cmbChannel.Text
        cmbscreenConsumres.Text = "Screen consumer [" & cmbChannel.Text & "|1080i5000]"
    End Sub

    Private Sub ucnewSM2_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                lblmax.Text = HMStoF(getdurationofclip(path))
                path = Replace(Replace(path, ":", ":\"), "\", "/")
                SendLoadCommand(path)
                lblplaying.Text = path
                TrackBarseek.Maximum = lblmax.Text
                TrackBarseek.Value = 0
            Next
        End If
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim filename As String = e.Data.GetData(DataFormats.Text).ToString
            lblmax.Text = HMStoF(getdurationofclip(filename))
            filename = Replace(Replace(filename, ":", ":\"), "\", "/")

            SendLoadCommand(filename)
            lblplaying.Text = filename
            TrackBarseek.Maximum = lblmax.Text
            TrackBarseek.Value = 0
        End If
    End Sub
    Private Sub ucnewSM2_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub
    Private Sub cmdCustomSpeed1_Click(sender As Object, e As EventArgs) Handles cmdCustomSpeed1.Click
        On Error Resume Next
        SetPlaybackSpeed(txtCustomeSpped1.Text)
    End Sub

    Private Sub cmdCustomSpeed2_Click(sender As Object, e As EventArgs) Handles cmdCustomSpeed2.Click
        On Error Resume Next
        SetPlaybackSpeed(txtCustomeSpped2.Text)

    End Sub

    Private Sub chkUseShuttleProV2_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseShuttleProV2.CheckedChanged
        If chkUseShuttleProV2.Checked Then
            spv = New clsShuttleProV2.clsShuttleProV2
        Else
            spv = Nothing
        End If
    End Sub

    Private Sub spv_ShuttleR1() Handles spv.ShuttleR1
        On Error Resume Next
        SetPlaybackSpeed(0.25)
    End Sub

    Private Sub spv_ShuttleR2() Handles spv.ShuttleR2
        SetPlaybackSpeed(0.5)
    End Sub

    Private Sub spv_ShuttleR3() Handles spv.ShuttleR3
        SetPlaybackSpeed(0.75)
    End Sub

    Private Sub spv_ShuttleR4() Handles spv.ShuttleR4
        SetPlaybackSpeed(1.0)
    End Sub

    Private Sub spv_ShuttleR5() Handles spv.ShuttleR5
        SetPlaybackSpeed(1.25)
    End Sub

    Private Sub spv_ShuttleR6() Handles spv.ShuttleR6
        SetPlaybackSpeed(1.5)
    End Sub

    Private Sub spv_ShuttleR7() Handles spv.ShuttleR7
        SetPlaybackSpeed(1.75)
    End Sub

    Private Sub spv_ShuttleL1() Handles spv.ShuttleL1
        SetPlaybackSpeed(0)
    End Sub

    Private Sub spv_JogR(value As Integer) Handles spv.JogR
        TrackBarseek.Value += 1
        SendLoadSeekCommand(TrackBarseek.Value)
    End Sub

    Private Sub spv_JogL(value As Integer) Handles spv.JogL
        TrackBarseek.Value -= 1
        SendLoadSeekCommand(TrackBarseek.Value)

    End Sub

    Private Sub gbSm2_Enter(sender As Object, e As EventArgs) Handles gbSm2.Enter

    End Sub

    Private Sub ucnewSM2_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Function GetSmLayerAddress() As String
        Return cmbChannel.Text & "-" & SlowMotionLayer
    End Function

    Private Sub SetPlaybackSpeed(speedValue As Object)
        CasparDevice.SendString("play " & GetSmLayerAddress())
        CasparDevice.SendString("call " & GetSmLayerAddress() & " framerate speed " & speedValue)
    End Sub

    Private Sub SendLoadCommand(path As String)
        CasparDevice.SendString("load " & GetSmLayerAddress() & " " & """" & path & """")
    End Sub

    Private Sub SendLoadSeekCommand(frameNumber As Integer)
        CasparDevice.SendString("load " & GetSmLayerAddress() & " " & """" & ModifyFilename(lblplaying.Text) & """" + " seek " & Int(frameNumber))
    End Sub
End Class
