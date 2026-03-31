Public Class ucPlaylistSetting
    Private Sub ucPlaylistSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Sub resizeoptions() Handles rdocentercutsetting.CheckedChanged, rdoletterboxsettings.CheckedChanged, rdopillarboxsettings.CheckedChanged, rdocentercutsetting.CheckedChanged, rdoanamorphic.CheckedChanged
        On Error Resume Next
        Dim fillSettings As String = GetSelectedResizeFillSettings()
        If fillSettings <> "" Then
            CasparDevice.SendString("mixer " & g_int_ChannelNumber & "-" & g_int_PlaylistLayer & " fill " & fillSettings)
        End If
    End Sub

    Function folderbrowsing(originaldirectory As String)
        On Error Resume Next
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return fbd.SelectedPath & "\"
        Else
            Return originaldirectory
        End If
    End Function

    Private Sub SetChannel_Click(sender As Object, e As EventArgs) Handles SetChannel.Click
        On Error Resume Next
        setchannelnumber(cmbchannelnewinstance.Text)
    End Sub

    Public Sub setchannelnumber(chn As Integer)
        With frmmediaplayer
            .cmbchannel.Text = chn
            .cmbchannel.Enabled = False
            ucOSC.stoposcserver()
            ucOSC.cmboscport.Text = GetOscPortForChannel(chn)
            ucOSC.cmboscport.Enabled = False
            ucOSC.oscstartandregister()
            .ucCasparcgWindow1.cmbcasparcgwindowtitle.Text = GetScreenConsumerTitle(chn)
        End With
    End Sub

    Private Sub chkSendFileNameWithoutExtension_CheckedChanged(sender As Object, e As EventArgs) Handles chkSendFileNameWithoutExtension.CheckedChanged
        filenamewithoutextensioncheck = chkSendFileNameWithoutExtension.Checked
    End Sub

    Private Function GetSelectedResizeFillSettings() As String
        If rdocentercutsetting.Checked And rdocentercutsetting.IsHandleCreated Then
            Return txtcentercutsetting.Text
        ElseIf rdoletterboxsettings.Checked Then
            Return txtletterboxsettings.Text
        ElseIf rdopillarboxsettings.Checked Then
            Return txtpillarboxsettings.Text
        ElseIf rdocropsettings.Checked Then
            Return txtcropsettings.Text
        ElseIf rdoanamorphic.Checked Then
            Return txtanamorphic.Text
        End If

        Return ""
    End Function

    Private Function GetOscPortForChannel(channelNumber As Integer) As Integer
        Return 6249 + channelNumber
    End Function

    Private Function GetScreenConsumerTitle(channelNumber As Integer) As String
        Return "Screen consumer [" & channelNumber & "|PAL]"
    End Function
End Class
