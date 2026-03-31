Imports System.IO

Public Class ucHS
    Private Const CrawlFlashLayer As Integer = 15
    Private Const MiddleFlashLayer As Integer = 16
    Private Const RightLogoFlashLayer As Integer = 17
    Private Const LeftLogoFlashLayer As Integer = 18
    Private Const LeftLogoTemplate As String = "CMP/left/left"
    Private Const MiddleTemplate As String = "CMP/middle/middle"
    Private Const RightLogoTemplate As String = "CMP/right/right"
    Private Const HorizontalScrollDirectory As String = "c:\casparcg\mydata\HorizontalScroll1\"
    Private Const FontsDirectory As String = "c:/casparcg/mydata/fonts"

    Private Sub cmdresume1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresume1.Click
        On Error Resume Next
        UpdateCrawlData("speed", nspeed.Value)
    End Sub

    Private Sub cmbfonths1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfonths1.SelectedIndexChanged
        On Error Resume Next
        Dim fs As New Font(cmbfonths1.Text, frmmediaplayer.nfontsizeforall.Value, FontStyle.Regular)
        txtcrawl.Font = fs
        UpdateCrawlData("font", cmbfonths1.Text)
    End Sub

    Private Sub cmdhidehs1_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdleftlogoopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdleftlogoopen.Click
        On Error Resume Next
        OpenLogoIntoControl(picleftlogo, txtleftlogo)
    End Sub

    Private Sub cmdleftlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdleftlogo.Click
        On Error Resume Next
        PlayLogoTemplate(LeftLogoTemplate, LeftLogoFlashLayer, txtleftlogo.Text)
    End Sub

    Private Sub cmdstopleft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopleft.Click
        On Error Resume Next
        StopTemplateLayer(LeftLogoFlashLayer)
    End Sub

    Private Sub cmdmiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmiddle.Click
        On Error Resume Next
        PlayLogoTemplate(MiddleTemplate, MiddleFlashLayer, txtmiddle.Text)
    End Sub

    Private Sub cmdstopmiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopmiddle.Click
        On Error Resume Next
        StopTemplateLayer(MiddleFlashLayer)
    End Sub

    Private Sub cmdrightlogoopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrightlogoopen.Click
        On Error Resume Next
        OpenLogoIntoControl(picrightlogo, txtrightlogo)
    End Sub

    Private Sub cmdrightlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrightlogo.Click
        On Error Resume Next
        PlayLogoTemplate(RightLogoTemplate, RightLogoFlashLayer, txtrightlogo.Text)
    End Sub

    Private Sub cmdstopright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopright.Click
        On Error Resume Next
        StopTemplateLayer(RightLogoFlashLayer)
    End Sub

    Private Sub cmdfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfile.Click
        On Error Resume Next
        ofd1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ofd1.InitialDirectory = HorizontalScrollDirectory

        If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso ofd1.FileName <> "" Then
            ReadTextFile(New FileInfo(ofd1.FileName).FullName, txtcrawl)
        End If
    End Sub

    Private Sub cmdshowcrawl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowcrawl.Click
        crawl()
    End Sub

    Sub crawl()
        On Error Resume Next

        SetCrawlMainData()

        If chkltrhs1.Checked Then
            AddTemplateLayer(txths1TemplateLtoR.Text, CrawlFlashLayer)
        Else
            AddTemplateLayer(txths1Template.Text, CrawlFlashLayer)
        End If
    End Sub

    Private Sub cmdpause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpause.Click
        On Error Resume Next
        UpdateCrawlData("speed", "0")
    End Sub

    Private Sub nopacityhs1_ValueChanged(sender As Object, e As EventArgs) Handles nopacityhs1.ValueChanged
        On Error Resume Next
        UpdateCrawlData("opacity", nopacityhs1.Value)
    End Sub

    Private Sub cmdstopcrawl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopcrawl.Click
        On Error Resume Next
        StopTemplateLayer(CrawlFlashLayer)
    End Sub

    Private Sub picleftlogo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picleftlogo.Enter
        On Error Resume Next
        OpenLogoIntoControl(picleftlogo, txtleftlogo)
    End Sub

    Private Sub picmiddle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picmiddle.Enter
        On Error Resume Next
        OpenLogoIntoControl(picmiddle, txtmiddle)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        OpenLogoIntoControl(picmiddle, txtmiddle)
    End Sub

    Private Sub picrightlogo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picrightlogo.Enter
        On Error Resume Next
        OpenLogoIntoControl(picrightlogo, txtrightlogo)
    End Sub

    Private Sub nsize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nsize.ValueChanged
        On Error Resume Next
        UpdateCrawlData("size", nsize.Value)
    End Sub

    Private Sub nspeed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nspeed.ValueChanged
        On Error Resume Next
        UpdateCrawlData("speed", nspeed.Value)
    End Sub

    Private Sub ny_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ny.ValueChanged
        On Error Resume Next
        UpdateCrawlData("y", ny.Value)
    End Sub

    Private Sub cmdcolor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcolor.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdcolor.ForeColor = cd1.Color
            cmdstripcolor.ForeColor = cd1.Color
            UpdateCrawlData("color", ColorToCasparHex(cmdstripcolor.ForeColor))
        End If
    End Sub

    Private Sub txtcrawl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcrawl.TextChanged
        On Error Resume Next
        SetCrawlTextData(False)
        UpdateTemplateLayer(CrawlFlashLayer)
    End Sub

    Private Sub cmdstripcolor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstripcolor.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdstripcolor.BackColor = cd1.Color
            cmdcolor.BackColor = cd1.Color
            UpdateCrawlData("stripcolor", ColorToCasparHex(cmdstripcolor.BackColor))
        End If
    End Sub

    Private Sub chkclock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclock.CheckedChanged
        On Error Resume Next
        UpdateCrawlData("alfa", If(chkclock.Checked, 1, 0))
    End Sub

    Sub enumfonts()
        On Error Resume Next
        For Each fileFound As String In Directory.GetFiles(FontsDirectory, "*.swf")
            Dim filefound1 = Split(Mid(fileFound, 26), ".")
            cmbfonths1.Items.Add(filefound1(0))
        Next
    End Sub

    Private Sub ucHS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enumfonts()
    End Sub

    Private Function GetChannelLayerNumber() As Integer
        Return Int(cmblayerhs1.Text)
    End Function

    Private Sub ClearCrawlData()
        CasparCGDataCollection.Clear()
    End Sub

    Private Sub AddTemplateLayer(templatePath As String, flashLayer As Integer)
        Dim channelLayer As Integer = GetChannelLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(channelLayer, flashLayer, templatePath, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub UpdateTemplateLayer(flashLayer As Integer)
        Dim channelLayer As Integer = GetChannelLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(channelLayer, flashLayer, CasparCGDataCollection)
    End Sub

    Private Sub StopTemplateLayer(flashLayer As Integer)
        Dim channelLayer As Integer = GetChannelLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(channelLayer, flashLayer)
    End Sub

    Private Sub PlayLogoTemplate(templatePath As String, flashLayer As Integer, mediaPath As String)
        ClearCrawlData()
        CasparCGDataCollection.SetData("a", Replace(mediaPath, "\", "/"))
        AddTemplateLayer(templatePath, flashLayer)
    End Sub

    Private Sub OpenLogoIntoControl(flashControl As AxShockwaveFlashObjects.AxShockwaveFlash, pathTextBox As TextBox)
        If picofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim moviePath As String = "file:///" & Replace(picofd.FileName, "\", "/")
            flashControl.Movie = moviePath
            pathTextBox.Text = moviePath
        End If
    End Sub

    Private Sub UpdateCrawlData(key As String, value As Object)
        ClearCrawlData()
        CasparCGDataCollection.SetData(key, value)
        UpdateTemplateLayer(CrawlFlashLayer)
    End Sub

    Private Sub SetCrawlMainData()
        ClearCrawlData()
        SetCrawlTextData(True)
        CasparCGDataCollection.SetData("speed", Int(nspeed.Value))
        CasparCGDataCollection.SetData("size", nsize.Value)
        CasparCGDataCollection.SetData("color", ColorToCasparHex(cmdstripcolor.ForeColor))
        CasparCGDataCollection.SetData("y", ny.Text)
        CasparCGDataCollection.SetData("stripcolor", ColorToCasparHex(cmdstripcolor.BackColor))
        CasparCGDataCollection.SetData("opacity", nopacityhs1.Value)
        CasparCGDataCollection.SetData("alfa", If(chkclock.Checked, 1, 0))
    End Sub

    Private Sub SetCrawlTextData(useDoubleSeparator As Boolean)
        Dim crawlText As String = BuildCrawlText(useDoubleSeparator)

        If chkbas64hs1.Checked Then
            Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(crawlText)
            CasparCGDataCollection.SetData("base64", System.Convert.ToBase64String(array))
        Else
            CasparCGDataCollection.SetData("xf0", crawlText)
            CasparCGDataCollection.SetData("font", cmbfonths1.Text)
        End If
    End Sub

    Private Function BuildCrawlText(useDoubleSeparator As Boolean) As String
        Dim lines As Array = Split(txtcrawl.Text, vbCrLf)
        Dim separator As String = If(useDoubleSeparator, " ** ", " ")
        Dim result As String = ""

        For ii = LBound(lines) To UBound(lines)
            result &= separator & lines(ii)
        Next

        Return result
    End Function

    Private Function ColorToCasparHex(colorValue As Color) As String
        Return "0x" & String.Format("{0:X2}{1:X2}{2:X2}", colorValue.R, colorValue.G, colorValue.B)
    End Function
End Class
