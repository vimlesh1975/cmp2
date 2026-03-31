Imports System.Xml

Public Class ucMixer
    Private Const MixerSettingsDirectory As String = "c:\casparcg\mydata\mixer\"
    Private Const MixerStatusReadDelayMilliseconds As Integer = 150
    Private Const MixerStatusBufferSize As Integer = 10024

    Private Sub cmdresetcropmixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresetcropmixer.Click
        On Error Resume Next
        resetcropmixer()
    End Sub

    Sub resetcropmixer()
        On Error Resume Next
        SetControlValue(ncroptlx, 0D)
        SetControlValue(ncroptly, 0D)
        SetControlValue(ncropbrx, 1D)
        SetControlValue(ncropbry, 1D)
    End Sub

    Sub mixercrop() Handles ncroptlx.ValueChanged, ncroptly.ValueChanged, ncropbrx.ValueChanged, ncropbry.ValueChanged
        On Error Resume Next
        SendLayerMixerCommand("crop", GetControlText(ncroptlx), GetControlText(ncroptly), GetControlText(ncropbrx), GetControlText(ncropbry))
    End Sub

    Private Sub chkmipmapmixer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmipmapmixer.CheckedChanged
        SendLayerMixerCommand("mipmap", If(chkmipmapmixer.Checked, "1", "0"))
    End Sub

    Private Sub cmdresetperspectivemixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresetperspectivemixer.Click
        On Error Resume Next
        resetperpectivemixer()
    End Sub

    Sub resetperpectivemixer()
        On Error Resume Next
        SetControlValue(nperspectivetlx, 0D)
        SetControlValue(nperspectivetly, 0D)
        SetControlValue(nperspectivetrx, 1D)
        SetControlValue(nperspectivetry, 0D)
        SetControlValue(nperspectivebrx, 1D)
        SetControlValue(nperspectivebry, 1D)
        SetControlValue(nperspectiveblx, 0D)
        SetControlValue(nperspectivebly, 1D)
    End Sub

    Private Sub cmdmixerclearformixemodule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmixerclearformixemodule.Click
        On Error Resume Next
        SendChannelMixerCommand("clear")
    End Sub

    Private Sub nopacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nopacity.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("opacity", nopacity)
    End Sub

    Private Sub cmdopacity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdopacity.Click
        On Error Resume Next
        SetControlValue(nopacity, 1D)
    End Sub

    Private Sub nbrightness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbrightness.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("brightness", nbrightness)
    End Sub

    Private Sub cmdbrightness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbrightness.Click
        On Error Resume Next
        SetControlValue(nbrightness, 1D)
    End Sub

    Private Sub nSaturation_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nSaturation.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("saturation", nSaturation)
    End Sub

    Private Sub cmdSaturation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaturation.Click
        On Error Resume Next
        SetControlValue(nSaturation, 1D)
    End Sub

    Private Sub nContrast_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nContrast.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("contrast", nContrast)
    End Sub

    Private Sub cmdContrast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContrast.Click
        On Error Resume Next
        SetControlValue(nContrast, 1D)
    End Sub

    Private Sub nmin_input_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nmin_input.ValueChanged, nmax_input.ValueChanged, ngamma.ValueChanged, nmin_output.ValueChanged, nmax_output.ValueChanged
        On Error Resume Next
        SendLayerMixerCommand("levels", GetControlText(nmin_input), GetControlText(nmax_input), GetControlText(ngamma), GetControlText(nmin_output), GetControlText(nmax_output))
    End Sub

    Private Sub cmdrefreshmediaforfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefreshmediaforfilter.Click
        frmmediaplayer.mediafilesforvisionmixer()
    End Sub

    Private Sub cmdplayfilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplayfilter.Click
        If ServerVersion > 2.1 Then
            CasparDevice.SendString("play " & GetLayerAddress() & " " & cmbmediaforfilter.Text & " loop vf " & cmbfilter.Text)
        Else
            CasparDevice.SendString("play " & GetLayerAddress() & " " & cmbmediaforfilter.Text & " loop filter " & cmbfilter.Text)
        End If
    End Sub

    Private Sub cmdmixersettingopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmixersettingopen.Click
        mixersettingopen()
    End Sub

    Private Sub mixersettingopen()
        On Error Resume Next

        Dim ofd2 As New OpenFileDialog
        ofd2.InitialDirectory = MixerSettingsDirectory
        ofd2.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"

        If ofd2.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim response As New MSXML2.DOMDocument60
        response.load(ofd2.FileName)

        LoadGroupControls(response, "mixer", gbMixer)
        LoadGroupControls(response, "Others", gbothers)
        LoadGroupControls(response, "clip", gbclip)
        LoadGroupControls(response, "levels", gblevels)
        LoadGroupControls(response, "fill", gbfill)
        LoadGroupControls(response, "rotation", gbrotationmixer)
        LoadGroupControls(response, "anchor", gbanchormixer)
        LoadGroupControls(response, "perspective", gbperspectivemixer)
        LoadGroupControls(response, "crop", gbcropmixer)

        Dim mipmapElement = TryCast(response.getElementsByTagName("chkmipmapmixer").item(0), MSXML2.IXMLDOMElement)
        If mipmapElement IsNot Nothing Then
            chkmipmapmixer.CheckState = CType(CInt(Val(mipmapElement.getAttribute("chkmipmapmixer").ToString())), CheckState)
        End If
    End Sub

    Private Sub cmdmixersettingsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmixersettingsave.Click
        mixersettingsave()
    End Sub

    Sub mixersettingsave()
        On Error Resume Next

        Dim osd2 As New SaveFileDialog
        osd2.InitialDirectory = MixerSettingsDirectory
        osd2.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"

        If osd2.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim xmlsetting As New XmlWriterSettings
        xmlsetting.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(osd2.FileName, xmlsetting)
            writer.WriteStartDocument()
            writer.WriteStartElement("mixerdata")

            WriteGroupControls(writer, "mixer", gbMixer)
            WriteGroupControls(writer, "Others", gbothers)
            WriteGroupControls(writer, "clip", gbclip)
            WriteGroupControls(writer, "levels", gblevels)
            WriteGroupControls(writer, "fill", gbfill)
            WriteGroupControls(writer, "rotation", gbrotationmixer)
            WriteGroupControls(writer, "anchor", gbanchormixer)
            WriteGroupControls(writer, "perspective", gbperspectivemixer)
            WriteGroupControls(writer, "crop", gbcropmixer)

            writer.WriteStartElement("chkmipmapmixer")
            writer.WriteAttributeString("chkmipmapmixer", CInt(chkmipmapmixer.CheckState).ToString())
            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Private Sub cmdmixerclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmixerclear.Click
        On Error Resume Next

        SendLayerMixerCommand("clear")

        mixerlevesreset()
        mixerclipreset()
        mixerfillreset()

        SetControlValue(nVolume, 1D)
        SetControlValue(nopacity, 1D)
        SetControlValue(nbrightness, 1D)
        SetControlValue(nSaturation, 1D)
        SetControlValue(nContrast, 1D)

        cmbblend.Text = "Normal"

        SetControlValue(nmixermastervolume, 1D)
        SetControlValue(nanchorx, 0D)
        SetControlValue(nanchory, 0D)
        SetControlValue(nrotationz, 0D)

        resetperpectivemixer()
        resetcropmixer()
    End Sub

    Private Sub cmdLevels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLevels.Click
        On Error Resume Next
        mixerlevesreset()
    End Sub

    Sub mixerlevesreset()
        On Error Resume Next
        SetControlValue(nmin_input, 0D)
        SetControlValue(nmax_input, 1D)
        SetControlValue(ngamma, 1D)
        SetControlValue(nmin_output, 0D)
        SetControlValue(nmax_output, 1D)
    End Sub

    Private Sub nmixermastervolume_ValueChanged(sender As Object, e As EventArgs) Handles nmixermastervolume.ValueChanged
        On Error Resume Next
        SendChannelMixerCommand("mastervolume", GetControlText(nmixermastervolume))
    End Sub

    Private Sub nVolume_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nVolume.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("volume", nVolume)
    End Sub

    Private Sub cmdmastervolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmastervolume.Click
        On Error Resume Next
        SetControlValue(nmixermastervolume, 1D)
    End Sub

    Private Sub cmdVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolume.Click
        On Error Resume Next
        SetControlValue(nVolume, 1D)
    End Sub

    Private Sub nfillx_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nfillx.ValueChanged, nfilly.ValueChanged, nfillwidth.ValueChanged, nfillheight.ValueChanged
        On Error Resume Next
        SendFillValues(nfillx.Value, nfilly.Value, nfillwidth.Value, nfillheight.Value)
    End Sub

    Private Sub cmdfill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfill.Click
        On Error Resume Next
        mixerfillreset()
    End Sub

    Sub mixerfillreset()
        On Error Resume Next
        SetControlValue(nfillx, 0D)
        SetControlValue(nfilly, 0D)
        SetControlValue(nfillwidth, 1D)
        SetControlValue(nfillheight, 1D)
    End Sub

    Private Sub nclipx_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nclipx.ValueChanged, nclipy.ValueChanged, nclipxsclae.ValueChanged, nclipyscale.ValueChanged
        On Error Resume Next
        SendLayerMixerCommand("clip", GetControlText(nclipx), GetControlText(nclipy), GetControlText(nclipxsclae), GetControlText(nclipyscale))
    End Sub

    Private Sub cmdclipreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclipreset.Click
        On Error Resume Next
        mixerclipreset()
    End Sub

    Sub mixerclipreset()
        On Error Resume Next
        SetControlValue(nclipx, 0D)
        SetControlValue(nclipy, 0D)
        SetControlValue(nclipxsclae, 1D)
        SetControlValue(nclipyscale, 1D)
    End Sub

    Sub perspectivemixer() Handles nperspectivetlx.ValueChanged, nperspectivetly.ValueChanged, nperspectivetrx.ValueChanged, nperspectivetry.ValueChanged, nperspectivebrx.ValueChanged, nperspectivebry.ValueChanged, nperspectiveblx.ValueChanged, nperspectivebly.ValueChanged
        On Error Resume Next
        SendLayerMixerCommand("perspective",
                              GetControlText(nperspectivetlx),
                              GetControlText(nperspectivetly),
                              GetControlText(nperspectivetrx),
                              GetControlText(nperspectivetry),
                              GetControlText(nperspectivebrx),
                              GetControlText(nperspectivebry),
                              GetControlText(nperspectiveblx),
                              GetControlText(nperspectivebly))
    End Sub

    Private Sub cmbblend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbblend.SelectedIndexChanged
        On Error Resume Next
        SendLayerMixerCommand("blend", cmbblend.Text)
    End Sub

    Private Sub nanchorx_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nanchorx.ValueChanged, nanchory.ValueChanged
        On Error Resume Next
        SendLayerMixerCommand("anchor", GetControlText(nanchorx), GetControlText(nanchory))
    End Sub

    Private Sub nrotationz_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nrotationz.ValueChanged
        On Error Resume Next
        SendSingleValueCommand("rotation", nrotationz)
    End Sub

    Private Sub cmdresetanchormixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresetanchormixer.Click
        On Error Resume Next
        SetControlValue(nanchorx, 0D)
        SetControlValue(nanchory, 0D)
    End Sub

    Private Sub cmdresetrotationmixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdresetrotationmixer.Click
        On Error Resume Next
        SetControlValue(nrotationz, 0D)
    End Sub

    Private Sub cmdgetstatusofmixer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgetstatusofmixer.Click
        On Error Resume Next
        getstausofmixer()
    End Sub

    Sub getstausofmixer()
        On Error Resume Next

        ApplyQueryValues("fill", nfillx, nfilly, nfillwidth, nfillheight)
        ApplyQueryValues("clip", nclipx, nclipy, nclipxsclae, nclipyscale)
        ApplyQueryValues("levels", nmin_input, nmax_input, ngamma, nmin_output, nmax_output)
        ApplyQueryValues("volume", nVolume)
        ApplyQueryValues("opacity", nopacity)
        ApplyQueryValues("brightness", nbrightness)
        ApplyQueryValues("saturation", nSaturation)
        ApplyQueryValues("contrast", nContrast)
        ApplyQueryValues("anchor", nanchorx, nanchory)
        ApplyQueryValues("rotation", nrotationz)
        ApplyQueryValues("mastervolume", True, nmixermastervolume)

        Dim blendValues As String() = QueryMixerValues("blend")
        If blendValues.Length > 0 Then
            cmbblend.Text = blendValues(0)
        End If

        ApplyQueryValues("perspective", nperspectivetlx, nperspectivetly, nperspectivetrx, nperspectivetry, nperspectivebrx, nperspectivebry, nperspectiveblx, nperspectivebly)
        ApplyQueryValues("crop", ncroptlx, ncroptly, ncropbrx, ncropbry)

        Dim mipmapValues As String() = QueryMixerValues("mipmap")
        If mipmapValues.Length > 0 Then
            chkmipmapmixer.Checked = (mipmapValues(0) <> "0")
        End If
    End Sub

    Private Sub cmbvideolayerformixer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvideolayerformixer.TextChanged
        On Error Resume Next
        'getstausofmixer()
    End Sub

    Private Sub cmdhidegbmixer_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ucMixer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub nscalexfromCenter_ValueChanged(sender As Object, e As EventArgs) Handles nscalexfromCenter.ValueChanged, nscaleyfromCenter.ValueChanged
        On Error Resume Next
        SendFillValues((1D - nscalexfromCenter.Value) / 2D, (1D - nscaleyfromCenter.Value) / 2D, nscalexfromCenter.Value, nscaleyfromCenter.Value)
    End Sub

    Private Sub cmdResetScalefromCenter_Click(sender As Object, e As EventArgs) Handles cmdResetScalefromCenter.Click
        On Error Resume Next
        SetControlValue(nscalexfromCenter, 1D)
        SetControlValue(nscaleyfromCenter, 1D)
    End Sub

    Private Sub cmdVerticalMobileToFullScreen_Click(sender As Object, e As EventArgs) Handles cmdVerticalMobileToFullScreen.Click
        On Error Resume Next
        SendLayerMixerCommand("fill", "0.5", "0.5", "0.57", "1.78")
        SendLayerMixerCommand("anchor", "0.5", "0.5")
        SendLayerMixerCommand("rotation", "90")
    End Sub

    Private Function GetLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmbvideolayerformixer.Text
    End Function

    Private Function GetChannelAddress() As String
        Return g_int_ChannelNumber.ToString()
    End Function

    Private Sub SendLayerMixerCommand(commandName As String, ParamArray values() As String)
        SendMixerCommand(GetLayerAddress(), commandName, values)
    End Sub

    Private Sub SendChannelMixerCommand(commandName As String, ParamArray values() As String)
        SendMixerCommand(GetChannelAddress(), commandName, values)
    End Sub

    Private Sub SendMixerCommand(address As String, commandName As String, ParamArray values() As String)
        Dim parts As New List(Of String)
        parts.Add("mixer")
        parts.Add(address)
        parts.Add(commandName)

        For Each value As String In values
            parts.Add(value)
        Next

        CasparDevice.SendString(String.Join(" ", parts.ToArray()))
    End Sub

    Private Sub SendSingleValueCommand(commandName As String, control As NumericUpDown)
        SendLayerMixerCommand(commandName, GetControlText(control))
    End Sub

    Private Function GetControlText(control As NumericUpDown) As String
        Return control.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
    End Function

    Private Sub SetControlValue(control As NumericUpDown, value As Decimal)
        control.Value = value
    End Sub

    Private Sub SendFillValues(x As Decimal, y As Decimal, width As Decimal, height As Decimal)
        SendLayerMixerCommand("fill",
                              x.ToString(System.Globalization.CultureInfo.InvariantCulture),
                              y.ToString(System.Globalization.CultureInfo.InvariantCulture),
                              width.ToString(System.Globalization.CultureInfo.InvariantCulture),
                              height.ToString(System.Globalization.CultureInfo.InvariantCulture))
    End Sub

    Private Sub LoadGroupControls(document As MSXML2.DOMDocument60, tagName As String, group As GroupBox)
        Dim instance = TryCast(document.getElementsByTagName(tagName).item(0), MSXML2.IXMLDOMElement)
        If instance Is Nothing Then
            Exit Sub
        End If

        For Each control As Control In group.Controls
            control.Text = instance.getAttribute(control.Name)
        Next
    End Sub

    Private Sub WriteGroupControls(writer As XmlWriter, elementName As String, group As GroupBox)
        writer.WriteStartElement(elementName)
        For Each control As Control In group.Controls
            writer.WriteAttributeString(control.Name, control.Text)
        Next
        writer.WriteEndElement()
    End Sub

    Private Function QueryMixerValues(commandName As String, Optional channelOnly As Boolean = False) As String()
        Dim address As String = If(channelOnly, GetChannelAddress(), GetLayerAddress())
        SendString(NetStream, "mixer " & address & " " & commandName & vbCrLf)
        Threading.Thread.Sleep(MixerStatusReadDelayMilliseconds)

        Dim data(MixerStatusBufferSize) As Byte
        NetStream.Read(data, 0, MixerStatusBufferSize)

        Dim response As String = System.Text.Encoding.UTF8.GetString(data)
        Dim lines As String() = Split(response, vbNewLine)
        If lines.Length < 2 Then
            Return New String() {}
        End If

        Return Split(lines(1).Trim(), " ")
    End Function

    Private Sub ApplyQueryValues(commandName As String, ParamArray controls() As NumericUpDown)
        ApplyQueryValues(commandName, False, controls)
    End Sub

    Private Sub ApplyQueryValues(commandName As String, channelOnly As Boolean, ParamArray controls() As NumericUpDown)
        Dim values As String() = QueryMixerValues(commandName, channelOnly)

        For index As Integer = 0 To Math.Min(values.Length, controls.Length) - 1
            SetControlValue(controls(index), CDec(Val(values(index))))
        Next
    End Sub
End Class
