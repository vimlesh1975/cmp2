Public Class ucCasparcgWindow
    Private Function GetChannelLayerAddress() As String
        Return g_int_ChannelNumber & "-" & g_int_PlaylistLayer
    End Function

    Private Function GetPlayingMediaPath() As String
        Return """" & ModifyFilename(lblplaying.Text) & """"
    End Function

    Private Function GetServerFrameValue(frameValue As Integer) As Integer
        If ServerVersion > 2.1 Then
            Return frameValue * 2
        End If

        Return frameValue
    End Function

    Private Function GetLoadSeekAdjustment(baseFrame As Integer) As Integer
        If Mid(frmmediaplayer.lblserverversion.Text, 1, 3) = "2.0" Then
            Return baseFrame - 2
        End If

        If ServerVersion > 2.1 Then
            Return baseFrame
        End If

        Return baseFrame - 3
    End Function

    Private Function GetSelectedCasparProcess(processName As String) As Process
        Dim processes() As Process = Process.GetProcessesByName(processName)
        If (processes.Length = 0) And (frmmediaplayer.BackColor = Color.Red) Then
            MessageBox.Show("Casparcg is not running")
            Return Nothing
        End If

        For Each process In processes
            If process.MainWindowTitle = cmbcasparcgwindowtitle.Text Then
                Return process
            End If
        Next

        If processes.Length > 0 Then
            Return processes(0)
        End If

        Return Nothing
    End Function

    Private Sub SendPlaySeekCommand(seekFrame As Integer, Optional lengthFrame As Integer? = Nothing)
        Dim command = "play " & GetChannelLayerAddress() & " " & GetPlayingMediaPath() & " seek " & GetServerFrameValue(seekFrame)
        If lengthFrame.HasValue Then
            command &= " length " & GetServerFrameValue(lengthFrame.Value)
        End If

        CasparDevice.SendString(command)
    End Sub

    Private Sub SendLoadSeekCommand(seekFrame As Integer)
        CasparDevice.SendString("load " & GetChannelLayerAddress() & " " & GetPlayingMediaPath() & " seek " & GetServerFrameValue(seekFrame))
    End Sub

    Private Sub SendPreviewSeekCommand(seekFrame As Integer)
        If ServerVersion > 2.1 Then
            CasparDevice.SendString("call " & GetChannelLayerAddress() & " seek " & GetServerFrameValue(seekFrame))
        Else
            SendLoadSeekCommand(seekFrame)
        End If
    End Sub

    Private Sub PauseClipAfterSeek()
        iclippauseresume = 2
    End Sub

    Private Sub UpdatePanelLayoutForAspectRatio()
        If chkaspectratio.Checked Then
            Panel1.Size = New Size(600, 337)
            ProgressBar1.Size = New Size(11, 337)
            ProgressBar2.Size = New Size(11, 337)
            gbplayer.Location = New Point(44, 375)
            picaudiometer.Height = 345
        Else
            Panel1.Size = New Size(600, 450)
            ProgressBar1.Size = New Size(11, 450)
            ProgressBar2.Size = New Size(11, 450)
            gbplayer.Location = New Point(44, 488)
            picaudiometer.Height = 459
        End If
    End Sub

    Private Sub UpdateAudioMeterColor(progressBar As Object)
        If progressBar.Value > 38 Then
            progressBar.Color = Color.Red
        ElseIf progressBar.Value > 34 And progressBar.Value < 38 Then
            progressBar.Color = Color.Yellow
        ElseIf progressBar.Value < 34 Then
            progressBar.Color = Color.Green
        End If
    End Sub

    Private Sub SetMasterVolume()
        CasparDevice.SendString("mixer " & g_int_ChannelNumber & " mastervolume " & tbAudioConytrol.Value / 100)
    End Sub

    Private Sub EnsureMavPlaybackForFrameStep()
        If Microsoft.VisualBasic.Strings.Right(lblplaying.Text, 3) = "mav" Then
            CasparDevice.SendString("play " & GetChannelLayerAddress())
        End If
    End Sub

    Private Sub cmdplayfromin_Click(sender As Object, e As EventArgs) Handles cmdplayfromin.Click
        On Error Resume Next
        SendPlaySeekCommand(Val(txtmarkin.Text))
    End Sub

    Private Sub cmdoutcasparcgwindow_Click(sender As Object, e As EventArgs) Handles cmdoutcasparcgwindow.Click
        outcasparcgwindown()
    End Sub

    Public Sub outcasparcgwindown()
        On Error Resume Next
        'This is important! If you have a child process on your form, it will terminate along with your form if you do not set its parent to Nothing
        If Not parentedProcess Is Nothing Then
            SetParent(parentedProcess.MainWindowHandle, Nothing)
        End If
    End Sub

    Private Sub chkaspectratio_CheckedChanged(sender As Object, e As EventArgs) Handles chkaspectratio.CheckedChanged
        On Error Resume Next
        UpdatePanelLayoutForAspectRatio()
        SetProcessParent("casparcg")
    End Sub

    'This is the API that does all the hard work
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    End Function

    'This is the API used to maximize the window
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    Dim parentedProcess As Process

    Public Sub SetProcessParent(ByVal processName As String)
        On Error Resume Next

        Dim selectedProcess = GetSelectedCasparProcess(processName)
        If selectedProcess Is Nothing Then Exit Sub

        If Not parentedProcess Is Nothing Then
            SetParent(parentedProcess.MainWindowHandle, Nothing)
        End If

        parentedProcess = selectedProcess
        SetParent(parentedProcess.MainWindowHandle, Me.Panel1.Handle)
        SendMessage(parentedProcess.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
    End Sub

    Private Sub cmdshowcasparcgwindow_Click(sender As Object, e As EventArgs) Handles cmdshowcasparcgwindow.Click
        On Error Resume Next
        SetProcessParent("casparcg")
    End Sub

    Private Sub cmdmarkout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmarkout.Click
        On Error Resume Next
        txtmarkout.Text = lblcurrentframe.Text 'TrackBarseek.Value
    End Sub

    Private Sub cmdgotoout_Click(sender As Object, e As EventArgs) Handles cmdgotoout.Click
        On Error Resume Next
        SendLoadSeekCommand(Val(txtmarkout.Text))
        PauseClipAfterSeek()
    End Sub

    Private Sub cmdgotoin_Click(sender As Object, e As EventArgs) Handles cmdgotoin.Click
        On Error Resume Next
        SendLoadSeekCommand(Val(txtmarkin.Text))
        PauseClipAfterSeek()
    End Sub

    Private Sub cmdplaylast5seccasaprcgwindow_Click(sender As Object, e As EventArgs) Handles cmdplaylast5seccasaprcgwindow.Click
        On Error Resume Next
        If System.IO.Path.GetExtension(mediafullpath & ucPlaylist.dgv1.CurrentRow.Cells(0).Value.ToString) = ".txt" Then
            readsubclip(mediafullpath & ucPlaylist.dgv1.CurrentRow.Cells(0).Value.ToString)
            SendPlaySeekCommand(cliplength + clipseek - fps * 5, fps * 5)
        Else
            SendPlaySeekCommand(Val(lblmax.Text) - fps * 5)
        End If
    End Sub

    Private Sub TrackBarseek_Scroll(sender As Object, e As EventArgs) Handles TrackBarseek.Scroll
        'no code
    End Sub
    Private Sub tmrpreview_Tick(sender As Object, e As EventArgs) Handles tmrpreview.Tick
        On Error Resume Next
        SendPreviewSeekCommand(Int(TrackBarseek.Value))
    End Sub
    Private Sub TrackBarseek_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBarseek.MouseDown
        On Error Resume Next
        ucPlaylist.tmrduration.Enabled = False

        tmrpreview.Interval = Val(frmmediaplayer.ucTab1.UcPlaylistSetting1.txtscrubbingtimerinterval.Text)
        tmrpreview.Enabled = True

        PauseClipAfterSeek()
    End Sub

    Private Sub TrackBarseek_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBarseek.MouseUp
        On Error Resume Next

        SendPreviewSeekCommand(Int(TrackBarseek.Value))
        lblcurrentframe.Text = ucOSC.dgvosc.Rows(6).Cells(1).Value 'for Current Frame Number

        tmrpreview.Enabled = False

        ucPlaylist.tmrduration.Enabled = True
    End Sub
    Private Sub cmdmarkin_Click(sender As Object, e As EventArgs) Handles cmdmarkin.Click
        On Error Resume Next
        txtmarkin.Text = lblcurrentframe.Text 'TrackBarseek.Value
    End Sub

    Private Sub cmdgototccasparcgwindow_Click_1(sender As Object, e As EventArgs) Handles cmdgototccasparcgwindow.Click
        On Error Resume Next
        SendLoadSeekCommand(HMSFtoF(txtgototccasparcgwindow.Text))
        PauseClipAfterSeek()
    End Sub

    Private Sub ucCasparcgWindow_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            SendString(NetStream, "Play " & GetChannelLayerAddress() & " " & """" & Replace(Replace(path, ":", ":\"), "\", "/") & """" & vbCrLf)
        Next
    End Sub
    Private Sub ucCasparcgWindow_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ucCasparcgWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbcasparcgwindowtitle.DataSource = New BindingSource(screenConsumres, "")
        cmbcasparcgwindowtitle.Text = "Screen consumer [1|1080i5000]"
    End Sub
    Private Sub tbAudioConytrol_Scroll(sender As Object, e As EventArgs) Handles tbAudioConytrol.Scroll
        On Error Resume Next
        SetMasterVolume()
    End Sub
    Private Sub mdResetAudio_Click(sender As Object, e As EventArgs) Handles mdResetAudio.Click
        On Error Resume Next
        tbAudioConytrol.Value = 100
        SetMasterVolume()
    End Sub
    Private Sub gbcasparcgwindow_DoubleClick(sender As Object, e As EventArgs) Handles gbcasparcgwindow.DoubleClick
        Changebackcolor(sender)
    End Sub

    Private Sub cmdhidecasparcgWindow_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub CmdplayfroInToOut_Click(sender As Object, e As EventArgs) Handles cmdplayfroInToOut.Click
        On Error Resume Next
        SendPlaySeekCommand(Val(txtmarkin.Text), Val(txtmarkout.Text) - Val(txtmarkin.Text))
    End Sub
    Private Sub Cmdcueclip_Click(sender As Object, e As EventArgs) Handles cmdcueclip.Click
        On Error Resume Next
        ucPlaylist.cueclip()
    End Sub
    Private Sub Cmdbackoneframe_Click_1(sender As Object, e As EventArgs) Handles cmdbackoneframe.Click
        On Error Resume Next
        EnsureMavPlaybackForFrameStep()
        SendLoadSeekCommand(GetLoadSeekAdjustment(Val(lblcurrentframe.Text) - 1))
        PauseClipAfterSeek()
    End Sub

    Private Sub CmdPlaySingleClip_Click_1(sender As Object, e As EventArgs) Handles cmdPlaySingleClip.Click
        On Error Resume Next
        ucPlaylist.PlaySingleClip()
    End Sub

    Private Sub Cmdforwardoneframe_Click_1(sender As Object, e As EventArgs) Handles cmdforwardoneframe.Click
        On Error Resume Next
        EnsureMavPlaybackForFrameStep()
        SendLoadSeekCommand(GetLoadSeekAdjustment(Val(lblcurrentframe.Text) + 1))
        PauseClipAfterSeek()
    End Sub

    Private Sub Cmdresume_Click_1(sender As Object, e As EventArgs) Handles cmdresume.Click
        On Error Resume Next
        ucPlaylist.clipresume()

    End Sub

    Private Sub Cmdstop_Click(sender As Object, e As EventArgs) Handles cmdstop.Click
        On Error Resume Next
        ucPlaylist.clipstop()
    End Sub
    Private Sub Cmdcuenext_Click(sender As Object, e As EventArgs) Handles cmdcuenext.Click
        On Error Resume Next
        'if nothing is selected
        Dim bbb As Integer = 0
        For aaa = 0 To ucPlaylist.dgv1.RowCount - 1
            bbb = bbb + ucPlaylist.dgv1.Item("x", aaa).Value

        Next
        If bbb = 0 Then MsgBox("no clip is selected") : Exit Sub
        ucPlaylist.nextclip()
    End Sub

    Private Sub Cmdnextplay_Click_1(sender As Object, e As EventArgs) Handles cmdnextplay.Click
        On Error Resume Next
        ucPlaylist.nextclipplay()
    End Sub

    Private Sub CmdGoToEnd_Click(sender As Object, e As EventArgs) Handles cmdGoToEnd.Click
        On Error Resume Next
        SendLoadSeekCommand(Val(lblmax.Text))
    End Sub

    Private Sub CmdFastReverse_Click(sender As Object, e As EventArgs) Handles cmdFastReverse.Click
        On Error Resume Next
        SendLoadSeekCommand(Int(TrackBarseek.Value) - (Val(txtforwardsecond.Text) * fps))
        PauseClipAfterSeek()
    End Sub
    Private Sub CmdFastFarward_Click(sender As Object, e As EventArgs) Handles cmdFastFarward.Click
        On Error Resume Next
        SendLoadSeekCommand(Int(TrackBarseek.Value) + (Val(txtforwardsecond.Text) * fps))
        PauseClipAfterSeek()
    End Sub

    Private Sub tmraudio_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmraudio.Tick
        On Error Resume Next
        ProgressBar1.Value = (40 + (audiovalue1))
        ProgressBar2.Value = (40 + (audiovalue2))

        UpdateAudioMeterColor(ProgressBar1)
        UpdateAudioMeterColor(ProgressBar2)
    End Sub

    Private Sub tbAudioConytrol_ValueChanged(sender As Object, e As EventArgs) Handles tbAudioConytrol.ValueChanged
        lblMasterVolume.Text = (tbAudioConytrol.Value) / 100
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
