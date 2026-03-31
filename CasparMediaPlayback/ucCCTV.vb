Imports Svt.Caspar

Public Class ucCCTV
    Private Const CameraListDirectory As String = "c:\casparcg\mydata\cctv\"
    Private Const DefaultCameraListFile As String = "c:\casparcg\mydata\cctv\cctv1.txt"
    Private Const MainChannel As Integer = 1
    Private Const SingleCameraLayer As Integer = 1

    Dim bb = 1
    Dim cc = 1

    Sub sendCommand(intIP As Integer)
        On Error Resume Next
        CasparDevice.SendString("play " & MainChannel & "-" & SingleCameraLayer & " " & BuildRtspUrl(intIP))
    End Sub

    Private Sub ucCCTV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        openbydefalt()
    End Sub

    Sub clearall()
        On Error Resume Next
        CasparDevice.SendString("clear " & MainChannel)
        CasparDevice.SendString("mixer " & MainChannel & " clear")
    End Sub

    Private Sub Cmd20_Click(sender As Object, e As EventArgs) Handles _
           cmd20.Click _
         , cmd21.Click _
         , cmd22.Click _
         , cmd23.Click _
         , cmd24.Click _
         , cmd25.Click _
         , cmd26.Click _
         , cmd27.Click _
         , cmd28.Click _
         , cmd29.Click _
         , cmd30.Click _
         , cmd31.Click _
         , cmd32.Click _
         , cmd33.Click _
         , cmd34.Click _
         , cmd35.Click _
         , cmd36.Click _
         , cmd37.Click _
         , cmd38.Click _
         , cmd39.Click _
         , cmd40.Click _
         , cmd41.Click _
         , cmd42.Click _
         , cmd43.Click _
         , cmd44.Click _
         , cmd45.Click _
         , cmd46.Click _
         , cmd47.Click _
         , cmd48.Click _
         , cmd49.Click _
         , cmd50.Click _
         , cmd51.Click _
         , cmd52.Click _
         , cmd53.Click _
         , cmd54.Click _
         , cmd55.Click _
         , cmd56.Click _
         , cmd57.Click _
         , cmd58.Click _
         , cmd59.Click _
         , cmd60.Click _
         , cmd61.Click _
         , cmd62.Click _
         , cmd63.Click
        On Error Resume Next
        sendCommand(CInt(sender.tag))
    End Sub

    Sub fourcamera(ip1 As Integer, ip2 As Integer, ip3 As Integer, ip4 As Integer)
        On Error Resume Next
        PlayCameraOnLayer(1, ip1)
        PlayCameraOnLayer(2, ip2)
        PlayCameraOnLayer(3, ip3)
        PlayCameraOnLayer(4, ip4)
        CasparDevice.SendString("mixer " & MainChannel & " grid 2")
    End Sub

    Private Sub Send1_Click(sender As Object, e As EventArgs) Handles Send1.Click
        On Error Resume Next
        PlayCameraGroup(1)
    End Sub

    Private Sub Send2_Click(sender As Object, e As EventArgs) Handles Send2.Click
        On Error Resume Next
        PlayCameraGroup(2)
    End Sub

    Private Sub Send3_Click(sender As Object, e As EventArgs) Handles Send3.Click
        On Error Resume Next
        PlayCameraGroup(3)
    End Sub

    Private Sub Send4_Click(sender As Object, e As EventArgs) Handles Send4.Click
        On Error Resume Next
        PlayCameraGroup(4)
    End Sub

    Private Sub Send5_Click(sender As Object, e As EventArgs) Handles Send5.Click
        On Error Resume Next
        PlayCameraGroup(5)
    End Sub

    Private Sub Send6_Click(sender As Object, e As EventArgs) Handles Send6.Click
        On Error Resume Next
        PlayCameraGroup(6)
    End Sub

    Private Sub Send7_Click(sender As Object, e As EventArgs) Handles Send7.Click
        On Error Resume Next
        PlayCameraGroup(7)
    End Sub

    Private Sub Send8_Click(sender As Object, e As EventArgs) Handles Send8.Click
        On Error Resume Next
        PlayCameraGroup(8)
    End Sub

    Private Sub send9_Click(sender As Object, e As EventArgs) Handles Send9.Click
        On Error Resume Next
        PlayCameraGroup(9)
    End Sub

    Private Sub send10_Click(sender As Object, e As EventArgs) Handles send10.Click
        On Error Resume Next
        PlayCameraGroup(10)
    End Sub

    Private Sub Send11_Click(sender As Object, e As EventArgs) Handles Send11.Click
        On Error Resume Next
        PlayCameraGroup(11)
    End Sub

    Private Sub TmrSwitch_Tick(sender As Object, e As EventArgs) Handles tmrSwitch.Tick
        On Error Resume Next

        If rdo1Camera.Checked Then
            sendCommand(19 + cc)
            cc += 1
            If cc > Val(txtTotalCameras.Text) Then cc = 1
        Else
            CasparDevice.SendString("mixer " & MainChannel & " grid 2")
            PlayCameraGroup(bb)
            bb += 1
            If bb > Math.Ceiling(Val(txtTotalCameras.Text) / 4) Then bb = 1
        End If
    End Sub

    Private Sub chkSwitch_CheckedChanged(sender As Object, e As EventArgs) Handles chkSwitch.CheckedChanged
        On Error Resume Next
        tmrSwitch.Interval = Val(txtInterval.Text) * 1000
        tmrSwitch.Enabled = chkSwitch.Checked
    End Sub

    Private Sub cmdStopall_Click(sender As Object, e As EventArgs) Handles cmdStopall.Click
        On Error Resume Next
        clearall()
    End Sub

    Private Sub txtInterval_TextChanged(sender As Object, e As EventArgs) Handles txtInterval.TextChanged
        On Error Resume Next
        tmrSwitch.Interval = Val(txtInterval.Text) * 1000
    End Sub

    Private Sub Rdo4Camera_CheckedChanged(sender As Object, e As EventArgs) Handles rdo4Camera.CheckedChanged, rdo1Camera.CheckedChanged
        On Error Resume Next
        If rdo4Camera.Checked Then
            CasparDevice.SendString("mixer " & MainChannel & " grid 2")
        Else
            CasparDevice.SendString("mixer " & MainChannel & " clear")
        End If
    End Sub

    Private Sub cmdOpenCameraList_Click(sender As Object, e As EventArgs) Handles cmdOpenCameraList.Click
        Dim ofd1 As New OpenFileDialog
        ofd1.InitialDirectory = CameraListDirectory
        If ofd1.ShowDialog = DialogResult.OK Then
            LoadCameraList(ofd1.FileName)
        End If
    End Sub

    Sub openbydefalt()
        On Error Resume Next
        LoadCameraList(DefaultCameraListFile)
    End Sub

    Private Sub CmdEditCameraList_Click(sender As Object, e As EventArgs) Handles cmdEditCameraList.Click
        On Error Resume Next
        Process.Start(DefaultCameraListFile)
    End Sub

    Private Sub Cmdhide_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(cmd20.Parent.ToString)
    End Sub

    Private Function BuildRtspUrl(cameraIpSuffix As Integer) As String
        Return "rtsp://" & txtUserName.Text & ":" & txtPassword.Text & "@" & txtIpNetwork.Text & cameraIpSuffix & ":" & txtipport.Text
    End Function

    Private Sub PlayCameraOnLayer(layerNumber As Integer, cameraIpSuffix As Integer)
        CasparDevice.SendString("play " & MainChannel & "-" & layerNumber & " " & BuildRtspUrl(cameraIpSuffix))
    End Sub

    Private Sub PlayCameraGroup(groupIndex As Integer)
        Dim startCamera As Integer = 20 + ((groupIndex - 1) * 4)
        fourcamera(GetCameraTag(startCamera), GetCameraTag(startCamera + 1), GetCameraTag(startCamera + 2), GetCameraTag(startCamera + 3))
    End Sub

    Private Function GetCameraTag(cameraButtonNumber As Integer) As Integer
        Return CInt(GroupBox1.Controls("cmd" & cameraButtonNumber).Tag)
    End Function

    Private Sub LoadCameraList(fileName As String)
        Dim objReader As New System.IO.StreamReader(fileName)
        For i As Integer = 1 To 44
            Dim ss As String = objReader.ReadLine()
            ApplyCameraButtonData(19 + i, ss)
        Next
        objReader.Dispose()
    End Sub

    Private Sub ApplyCameraButtonData(buttonNumber As Integer, cameraDefinition As String)
        GroupBox1.Controls("cmd" & buttonNumber).Text = Split(cameraDefinition, "(")(0)
        GroupBox1.Controls("cmd" & buttonNumber).Tag = Split(Split(cameraDefinition, "(")(1), ")")(0)
    End Sub
End Class
