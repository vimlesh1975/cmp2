Public Class UcCaption
    Private Sub UcCaption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub event1(sender As Object, e As EventArgs) Handles Me.LocationChanged, Me.Resize
        On Error Resume Next
        UpdateCaptionFill(sender)
        ResizeCaptionLabel()

        If elementmove = False Then
            Form1.UcMixernew1.cmbvideolayerformixer.Text = Label1.Text
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        On Error Resume Next
        CasparDevice.SendString("clear " & GetCaptionLayerAddress())
        Me.Dispose()
    End Sub

    Private Sub UcCaption_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        elementmove = False
    End Sub

    Private Function GetCaptionLayerAddress() As String
        Return g_int_ChannelNumber & "-" & Label1.Text
    End Function

    Private Sub UpdateCaptionFill(target As Object)
        CasparDevice.SendString("mixer " & GetCaptionLayerAddress() & " fill " & fillcommandCaption(target)(0))
    End Sub

    Private Sub ResizeCaptionLabel()
        Label2.Size = New Size(Me.Width - 2, Me.Height - 2)
    End Sub
End Class
