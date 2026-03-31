Imports System.IO

Public Class ucHS2
    Private Const HorizontalScrollDirectory As String = "c:\casparcg\mydata\HorizontalScroll2\"
    Private Const FontsDirectory As String = "c:/casparcg/mydata/fonts"

    Private Sub cmdhidegbhs2_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmbfonths2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfonths2.SelectedIndexChanged
        On Error Resume Next

        Dim fs As New Font(cmbfonths2.Text, frmmediaplayer.nfontsizeforall.Value, FontStyle.Regular)
        txtcrawl2.Font = fs

        If chkbase64.Checked = False Then
            UpdateCrawlData("font", cmbfonths2.Text)
        End If
    End Sub

    Private Sub cmdfile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfile2.Click
        On Error Resume Next
        ofd1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ofd1.InitialDirectory = HorizontalScrollDirectory

        If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso ofd1.FileName <> "" Then
            ReadTextFile(New FileInfo(ofd1.FileName).FullName, txtcrawl2)
        End If
    End Sub

    Private Sub cmdshowcrawl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowcrawl2.Click
        On Error Resume Next
        SetCrawlMainData()

        If chkltrhs2.Checked Then
            AddTemplateLayer(txths2TemplateLtoR.Text)
        Else
            AddTemplateLayer(txths2Template.Text)
        End If
    End Sub

    Private Sub cmdpause2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpause2.Click
        On Error Resume Next
        UpdateCrawlData("speed", "0")
    End Sub

    Private Sub cmdresume2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresume2.Click
        On Error Resume Next
        UpdateCrawlData("speed", nspeed2.Value)
    End Sub

    Private Sub cmdstopcrawl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopcrawl2.Click
        On Error Resume Next
        StopTemplateLayer()
    End Sub

    Private Sub chkclock2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclock2.CheckedChanged
        On Error Resume Next
        UpdateCrawlData("alfa", If(chkclock2.Checked, 1, 0))
    End Sub

    Private Sub cmdstripcolor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstripcolor2.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdstripcolor2.BackColor = cd1.Color
            cmdcolor2.BackColor = cd1.Color
            UpdateCrawlData("stripcolor", ColorToCasparHex(cmdcolor2.BackColor))
        End If
    End Sub

    Private Sub nsize2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nsize2.ValueChanged
        On Error Resume Next
        UpdateCrawlData("size", nsize2.Value)
    End Sub

    Private Sub nspeed2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nspeed2.ValueChanged
        On Error Resume Next
        UpdateCrawlData("speed", nspeed2.Value)
    End Sub

    Private Sub txtcrawl2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcrawl2.TextChanged
        On Error Resume Next
        SetCrawlTextData(False)
        UpdateTemplateLayer()
    End Sub

    Private Sub cmdcolor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcolor2.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdcolor2.ForeColor = cd1.Color
            cmdstripcolor2.ForeColor = cd1.Color
            UpdateCrawlData("color", ColorToCasparHex(cmdcolor2.ForeColor))
        End If
    End Sub

    Private Sub ny2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ny2.ValueChanged
        On Error Resume Next
        UpdateCrawlData("y", ny2.Value)
    End Sub

    Sub enumfonts()
        On Error Resume Next
        For Each fileFound As String In Directory.GetFiles(FontsDirectory, "*.swf")
            Dim filefound1 = Split(Mid(fileFound, 26), ".")
            cmbfonths2.Items.Add(filefound1(0))
        Next
    End Sub

    Private Sub ucHS2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enumfonts()
    End Sub

    Private Function GetLayerNumber() As Integer
        Return Int(cmblayerhs2.Text)
    End Function

    Private Sub ClearCrawlData()
        CasparCGDataCollection.Clear()
    End Sub

    Private Sub AddTemplateLayer(templatePath As String)
        Dim layerNumber As Integer = GetLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(layerNumber, layerNumber, templatePath, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub UpdateTemplateLayer()
        Dim layerNumber As Integer = GetLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(layerNumber, layerNumber, CasparCGDataCollection)
    End Sub

    Private Sub StopTemplateLayer()
        Dim layerNumber As Integer = GetLayerNumber()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(layerNumber, layerNumber)
    End Sub

    Private Sub UpdateCrawlData(key As String, value As Object)
        ClearCrawlData()
        CasparCGDataCollection.SetData(key, value)
        UpdateTemplateLayer()
    End Sub

    Private Sub SetCrawlMainData()
        ClearCrawlData()
        SetCrawlTextData(True)
        CasparCGDataCollection.SetData("speed", Int(nspeed2.Value))
        CasparCGDataCollection.SetData("size", nsize2.Value)
        CasparCGDataCollection.SetData("y", ny2.Text)
        CasparCGDataCollection.SetData("color", ColorToCasparHex(cmdcolor2.ForeColor))
        CasparCGDataCollection.SetData("stripcolor", ColorToCasparHex(cmdcolor2.BackColor))
        CasparCGDataCollection.SetData("alfa", If(chkclock2.Checked, 1, 0))
    End Sub

    Private Sub SetCrawlTextData(useDoubleSeparator As Boolean)
        Dim crawlText As String = BuildCrawlText(useDoubleSeparator)

        If chkbase64.Checked Then
            Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(crawlText)
            CasparCGDataCollection.SetData("base64", System.Convert.ToBase64String(array))
        Else
            CasparCGDataCollection.SetData("xf0", crawlText)
            CasparCGDataCollection.SetData("font", cmbfonths2.Text)
        End If
    End Sub

    Private Function BuildCrawlText(useDoubleSeparator As Boolean) As String
        Dim lines As Array = Split(txtcrawl2.Text, vbCrLf)
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
