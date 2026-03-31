Public Class frmXDCamContoller
    Private Sub SetDefaultServiceAddress()
        UcXdcamController2.txtipaddress.Text = "http://192.168.1.134/webservice/"
    End Sub

    Private Sub frmXDCamContoller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDefaultServiceAddress()
    End Sub
End Class
