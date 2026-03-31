Public Class ucdBFSMeter
    Private Const DefaultDbfsValue As Integer = -40

    Private Function GetDbfsMeters() As Object()
        Return {DBFS_Meter1, DBFS_Meter2, DBFS_Meter3, DBFS_Meter4, DBFS_Meter5, DBFS_Meter6, DBFS_Meter7, DBFS_Meter8,
                DBFS_Meter9, DBFS_Meter10, DBFS_Meter11, DBFS_Meter12, DBFS_Meter13, DBFS_Meter14, DBFS_Meter15, DBFS_Meter16}
    End Function

    Private Function GetAudioTrackBars() As TrackBar()
        Return {tbAudioControl0, tbAudioControl1, tbAudioControl2, tbAudioControl3, tbAudioControl4, tbAudioControl5, tbAudioControl6, tbAudioControl7,
                tbAudioControl8, tbAudioControl9, tbAudioControl10, tbAudioControl11, tbAudioControl12, tbAudioControl13, tbAudioControl14, tbAudioControl15}
    End Function

    Private Function GetAudioControlCombos() As ComboBox()
        Return {cmbAudioControl0, cmbAudioControl1, cmbAudioControl2, cmbAudioControl3, cmbAudioControl4, cmbAudioControl5, cmbAudioControl6, cmbAudioControl7,
                cmbAudioControl8, cmbAudioControl9, cmbAudioControl10, cmbAudioControl11, cmbAudioControl12, cmbAudioControl13, cmbAudioControl14, cmbAudioControl15}
    End Function

    Private Function GetOscAudioValue(serverRowIndex As Integer, cellIndex As Integer) As String
        Return ucOSC.dgvosc.Rows(serverRowIndex).Cells(cellIndex).Value
    End Function

    Private Function GetMeterValueFromOsc(serverRowIndex As Integer, cellIndex As Integer, convertToDbfs As Boolean) As Integer
        Dim oscValue = GetOscAudioValue(serverRowIndex, cellIndex)
        If oscValue <> "" Then
            If convertToDbfs Then
                Return ValuetodBFS(oscValue)
            End If

            Return oscValue
        End If

        Return DefaultDbfsValue
    End Function

    Private Sub UpdateMetersForServer23()
        Dim meterIndex = 1
        For Each meter In GetDbfsMeters()
            meter.DBFS_Value = GetMeterValueFromOsc(57, meterIndex, True)
            meterIndex += 1
        Next
    End Sub

    Private Sub UpdateMetersForLegacyServer()
        Dim rowIndex = 30
        For Each meter In GetDbfsMeters()
            meter.DBFS_Value = GetMeterValueFromOsc(rowIndex, 1, False)
            rowIndex += 1
        Next
    End Sub

    Private Function GetCurrentPreviewMedia() As String
        If ServerVersion > 2.1 Then
            Return ModifyFilename(ucOSC.dgvosc.Rows(56).Cells(1).Value)
        End If

        Return ModifyFilename(ucOSC.dgvosc.Rows(8).Cells(1).Value)
    End Function

    Private Function GetCurrentPreviewSeek() As Integer
        If ServerVersion > 2.1 Then
            Return (ucOSC.dgvosc.Rows(6).Cells(1).Value + 3) * 2
        End If

        Return ucOSC.dgvosc.Rows(6).Cells(1).Value + 12
    End Function

    Private Sub ReplayPreviewWithAudioFilter(server23Filter As String, legacyChannelLayout As String)
        With frmmediaplayer
            If ServerVersion > 2.1 Then
                CasparDevice.SendString("play " & .cmbchannel.Text & "-" & .cmblayervideo.Text & " " & """" & GetCurrentPreviewMedia() & """" & " seek " & GetCurrentPreviewSeek() & " af " & server23Filter)
            Else
                CasparDevice.SendString("play " & .cmbchannel.Text & "-" & .cmblayervideo.Text & " " & """" & GetCurrentPreviewMedia() & """" & " seek " & GetCurrentPreviewSeek() & " channel_layout " & legacyChannelLayout)
            End If
        End With
    End Sub

    Private Function BuildPanHexadecagonalFilter() As String
        Dim filter = "pan=hexadecagonal"
        Dim index = 0
        Dim audioCombos = GetAudioControlCombos()

        For Each trackBar In GetAudioTrackBars()
            Dim combo = audioCombos(index)
            filter &= "|c" & index & "=" & (trackBar.Value / 10) & combo.Text
            index += 1
        Next

        Return filter
    End Function

    Private Sub InitializeAudioControlCombos()
        Dim index = 0
        For Each combo In GetAudioControlCombos()
            combo.DataSource = New BindingSource(audio1, "")
            combo.Text = "c" & index
            index += 1
        Next
    End Sub

    Private Sub cmdhidedbfsmeter1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Sub ucdBFSMeter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub tmraudio_Tick(sender As Object, e As EventArgs) Handles tmraudio.Tick
        On Error Resume Next
        If ServerVersion > 2.1 Then
            UpdateMetersForServer23()
        Else
            UpdateMetersForLegacyServer()
        End If
    End Sub

    Private Sub cmdL_to_Both_Click(sender As Object, e As EventArgs) Handles cmdL_to_Both.Click
        On Error Resume Next
        ReplayPreviewWithAudioFilter("pan=stereo|c0=c0|c1=c0", "L_to_Both")
    End Sub

    Private Sub cmdR_to_Both_Click(sender As Object, e As EventArgs) Handles cmdR_to_Both.Click
        On Error Resume Next
        ReplayPreviewWithAudioFilter("pan=stereo|c0=c1|c1=c1", "R_to_Both")
    End Sub
    Private Sub cmdrefreshmediaforaudiotest_Click(sender As Object, e As EventArgs) Handles cmdrefreshmediaforaudiotest.Click
        On Error Resume Next
        frmmediaplayer.mediafilesforvisionmixer()
    End Sub

    Private Sub cmdaudiotest_Click(sender As Object, e As EventArgs) Handles cmdaudiotest.Click
        On Error Resume Next
        CasparDevice.SendString("play " & g_int_ChannelNumber & "-" & g_int_PlaylistLayer & " " & """" & cmbmediaforaudiotest.Text & """" & " CHANNEL_LAYOUT " & """" & cmbchannel_layout.Text & """" & " loop")
    End Sub

    Private Sub CmdMix_Click(sender As Object, e As EventArgs) Handles cmdMix.Click
        On Error Resume Next
        ReplayPreviewWithAudioFilter("pan=stereo|c0=0.7c0+0.7c1|c1=0.7c0+0.7c1", "Mix")
    End Sub

    Private Sub CmdOnly_L_Click(sender As Object, e As EventArgs) Handles cmdOnly_L.Click
        On Error Resume Next
        ReplayPreviewWithAudioFilter("pan=stereo|c0=c0|c1=0c1", "Only_L")
    End Sub

    Private Sub CmdOnly_R_Click(sender As Object, e As EventArgs) Handles cmdOnly_R.Click
        On Error Resume Next
        ReplayPreviewWithAudioFilter("pan=stereo|c0=0c0|c1=c1", "Only_R")
    End Sub

    Private Sub TbAudioControl_Scroll(sender As Object, e As EventArgs) Handles _
    tbAudioControl0.Scroll, tbAudioControl1.Scroll, tbAudioControl2.Scroll, tbAudioControl3.Scroll,
    tbAudioControl4.Scroll, tbAudioControl5.Scroll, tbAudioControl6.Scroll, tbAudioControl7.Scroll,
    tbAudioControl8.Scroll, tbAudioControl9.Scroll, tbAudioControl10.Scroll, tbAudioControl11.Scroll,
    tbAudioControl12.Scroll, tbAudioControl13.Scroll, tbAudioControl14.Scroll, tbAudioControl15.Scroll,
    cmbAudioControl0.SelectedIndexChanged, cmbAudioControl1.SelectedIndexChanged, cmbAudioControl2.SelectedIndexChanged, cmbAudioControl3.SelectedIndexChanged,
    cmbAudioControl4.SelectedIndexChanged, cmbAudioControl5.SelectedIndexChanged, cmbAudioControl6.SelectedIndexChanged, cmbAudioControl7.SelectedIndexChanged,
    cmbAudioControl8.SelectedIndexChanged, cmbAudioControl9.SelectedIndexChanged, cmbAudioControl10.SelectedIndexChanged, cmbAudioControl11.SelectedIndexChanged,
    cmbAudioControl12.SelectedIndexChanged, cmbAudioControl13.SelectedIndexChanged, cmbAudioControl14.SelectedIndexChanged, cmbAudioControl15.SelectedIndexChanged
        On Error Resume Next
        If ServerVersion > 2.1 Then
            ReplayPreviewWithAudioFilter(BuildPanHexadecagonalFilter(), "")
        End If
    End Sub

    Private Sub ucdBFSMeter_Load_1(sender As Object, e As EventArgs)
        InitializeAudioControlCombos()
    End Sub
End Class
