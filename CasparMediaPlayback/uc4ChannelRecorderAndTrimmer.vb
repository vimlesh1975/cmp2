Public Class uc4ChannelRecorderAndTrimmer
    Private Function GetRecorders() As IEnumerable(Of ucnewRecorder)
        Return {UcnewRecorder1, UcnewRecorder2, UcnewRecorder3, UcnewRecorder4}
    End Function

    Private Sub ConfigureRecorder(recorder As ucnewRecorder, channelNumber As Integer)
        With recorder
            .chnumber = channelNumber
            .oscportnumber = 6250 + .chnumber
            .cmbdecklinkforrecording.Text = .chnumber
            .txtfilename.Text = "test" & .chnumber
            .Label2.Text = "Channel " & .chnumber
            .cmbcasparcgwindowtitle.Text = "Screen consumer [" & .chnumber & "|1080i5000]"
            .oscstartandregister(.chnumber, .oscportnumber)
        End With
    End Sub

    Private Sub InitializeResizeHelpers()
        For Each recorder In GetRecorders()
            Dim resizeHelper = New clsResizeableControlnew(recorder)
        Next

        Dim systemAudioResizeHelper = New clsResizeableControlnew(UcSystemAudio1)
        Dim trimmerResizeHelper = New clsResizeableControlnew(UcnewTrimmer11)
    End Sub

    Private Sub Uc4ChannelRecorderAndTrimmer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim channelNumber = 1
        For Each recorder In GetRecorders()
            ConfigureRecorder(recorder, channelNumber)
            channelNumber += 1
        Next

        InitializeResizeHelpers()
    End Sub

    Private Sub Cmdhide_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        If Not parentedProcess Is Nothing Then
            For Each recorder In GetRecorders()
                SetParent(recorder.parentedProcess1.MainWindowHandle, Nothing)
            Next
        End If

        For Each recorder In GetRecorders()
            recorder.stoposcserver()
        Next

        'Me.Hide()
        Me.Parent.Controls("uc4ChannelRecorderAndTrimmer1").Dispose()
    End Sub
End Class
