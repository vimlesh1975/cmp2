Public Class ucLogo
    Private Const LogoTemplatePath As String = "CMP/logo/logo"
    Private Const LogoMediaDirectory As String = "c:\casparcg\mydata\logo"
    Private Const LogoListDirectory As String = "c:\casparcg\mydata\logo\logo_list\"

    Private Sub cmdhidegblogo_Click(sender As Object, e As EventArgs) Handles cmdhidegblogo.Click
        Me.Hide()
    End Sub

    Private Sub cmdplaylogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaylogo.Click
        playlogo()
    End Sub

    Sub playlogo()
        On Error Resume Next
        SetLogoData()
        SetLogoOpacity()
        AddOrUpdateLogo(True)
    End Sub

    Private Sub cmdresetlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresetlogo.Click
        On Error Resume Next
        nlogox.Value = 592
        nlogoy.Value = 6
        nlogowidth.Value = 160
        nlogoheight.Value = 120
        nopacitylogo.Value = 1.0
    End Sub

    Private Sub nlogox_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nlogox.ValueChanged, nlogoy.ValueChanged, nlogowidth.ValueChanged, nlogoheight.ValueChanged, nopacitylogo.ValueChanged
        On Error Resume Next
        SetLogoData()
        SetLogoOpacity()
        AddOrUpdateLogo(False)
    End Sub

    Private Sub cmdstoplogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstoplogo.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetLogoLayerNumber(), GetLogoLayerNumber())
    End Sub

    Private Sub cmdlogoopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogoopen.Click, piclogo.Enter
        On Error Resume Next
        picofd.InitialDirectory = LogoMediaDirectory
        If picofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            UpdateLogoMovieLocation(picofd.FileName)
        End If
    End Sub

    Sub readfileforlogo(ByVal str As String)
        On Error Resume Next
        Dim a As Array = Split(My.Computer.FileSystem.ReadAllText(str), Chr(2) + "=")

        For i As Integer = 0 To gblogo.Controls.Count - 1
            Dim b As Array = Split(a(i + 1), Chr(3) + Chr(3))
            gblogo.Controls(i).Text = b(0)
        Next
    End Sub

    Private Sub savetslogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub txtlogolocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlogolocation.TextChanged
        On Error Resume Next
        piclogo.Movie = txtlogolocation.Text
    End Sub

    Private Sub cmdvideoloopaslogo_Click(sender As Object, e As EventArgs) Handles cmdvideoloopaslogo.Click
        On Error Resume Next
        CasparDevice.SendString(txtvideoloopaslogo.Text)
    End Sub

    Private Sub stopvideoloopaslogo_Click(sender As Object, e As EventArgs) Handles stopvideoloopaslogo.Click
        On Error Resume Next
        CasparDevice.SendString(txtvideoloopaslogostop.Text)
    End Sub

    Private Sub ucLogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        piclogo.Movie = txtlogolocation.Text
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        ofd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ofd2.InitialDirectory = LogoListDirectory
        If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            readfileforlogo(ofd2.FileName)
            lbllogofilename.Text = ofd2.FileName
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        osd2.InitialDirectory = LogoListDirectory
        osd2.FileName = ""

        If osd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(osd2.FileName, BuildLogoSettingsText(), False)
            lbllogofilename.Text = osd2.FileName
        End If
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub

    Private Function GetLogoLayerNumber() As Integer
        Return Int(cmbflashlayerforlogo.Text)
    End Function

    Private Function GetLogoMoviePath() As String
        Return Replace(piclogo.Movie, "\", "/")
    End Function

    Private Sub SetLogoData()
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("logofilename", GetLogoMoviePath())
        CasparCGDataCollection.SetData("logowidth", nlogowidth.Value)
        CasparCGDataCollection.SetData("logoheight", nlogoheight.Value)
        CasparCGDataCollection.SetData("logox", nlogox.Value)
        CasparCGDataCollection.SetData("logoy", nlogoy.Value)
    End Sub

    Private Sub SetLogoOpacity()
        CasparDevice.SendString("mixer " & g_int_ChannelNumber & "-" & cmbflashlayerforlogo.Text & " opacity " & nopacitylogo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))
    End Sub

    Private Sub AddOrUpdateLogo(isNewPlay As Boolean)
        Dim layerNumber As Integer = GetLogoLayerNumber()
        If isNewPlay Then
            CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(layerNumber, layerNumber, LogoTemplatePath, True, CasparCGDataCollection.ToAMCPEscapedXml)
        Else
            CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(layerNumber, layerNumber, CasparCGDataCollection)
        End If
    End Sub

    Private Sub UpdateLogoMovieLocation(fileName As String)
        Dim moviePath As String = "file:///" & Replace(fileName, "\", "/")
        piclogo.Movie = moviePath
        piclogo.CtlScale = "ShowAll"
        txtlogolocation.Text = moviePath
    End Sub

    Private Function BuildLogoSettingsText() As String
        Dim settingsText As String = ""

        For i As Integer = 0 To gblogo.Controls.Count - 1
            settingsText &= gblogo.Controls(i).Name & Chr(2) & "=" & gblogo.Controls(i).Text & Chr(3) & Chr(3)
        Next

        Return settingsText & Chr(2) & "=  "
    End Function
End Class
