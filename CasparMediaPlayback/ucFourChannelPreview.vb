Public Class ucFourChannelPreview
    Private Function GetPreviewControls() As ucnewPreview()
        Return {UcnewPreview1, UcnewPreview2, UcnewPreview3, UcnewPreview4}
    End Function

    Private Sub ConfigurePreviewControl(previewControl As ucnewPreview, channelNumber As Integer)
        previewControl.cmbippreview.Text = "229.0.0.1:500" & channelNumber
        previewControl.lblchannelnumber.Text = "Channel " & channelNumber
        previewControl.chnumber = channelNumber
    End Sub

    Private Sub ucFourChannelPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim channelNumber = 1
        For Each previewControl In GetPreviewControls()
            ConfigurePreviewControl(previewControl, channelNumber)
            channelNumber += 1
        Next
    End Sub
    Private Sub Cmdhide_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
End Class
