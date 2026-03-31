Public Class frmfileinformation
    Private Sub PositionWindow()
        Me.Left = 400
        Me.Top = 20
    End Sub

    Private Sub frmfileinformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PositionWindow()
    End Sub
End Class
