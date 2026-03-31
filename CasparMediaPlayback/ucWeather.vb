Public Class ucWeather
    Private Sub AddWeatherIconData(index As Integer, movie As String, widthValue As Decimal, heightValue As Decimal, xValue As Decimal, yValue As Decimal, textValue As String)
        CasparCGDataCollection.SetData("logofilename" & index, Replace(movie, "\", "/"))
        CasparCGDataCollection.SetData("logowidth" & index, widthValue)
        CasparCGDataCollection.SetData("logoheight" & index, heightValue)
        CasparCGDataCollection.SetData("logox" & index, xValue)
        CasparCGDataCollection.SetData("logoy" & index, yValue)
        CasparCGDataCollection.SetData("f" & index, textValue)
    End Sub

    Private Sub LoadWeatherTemplateData()
        CasparCGDataCollection.Clear()
        AddWeatherIconData(1, weathericon1.Movie, nweathericon1width.Value, nweathericon1height.Value, nweathericon1x.Value, nweathericon1y.Value, txtweathericon1.Text)
        AddWeatherIconData(2, weathericon2.Movie, nweathericon2width.Value, nweathericon2height.Value, nweathericon2x.Value, nweathericon2y.Value, txtweathericon2.Text)
        AddWeatherIconData(3, weathericon3.Movie, nweathericon3width.Value, nweathericon3height.Value, nweathericon3x.Value, nweathericon3y.Value, txtweathericon3.Text)
        AddWeatherIconData(4, weathericon4.Movie, nweathericon4width.Value, nweathericon4height.Value, nweathericon4x.Value, nweathericon4y.Value, txtweathericon4.Text)
    End Sub

    Private Sub ConfigureWeatherDialog(dialog As FileDialog)
        dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        dialog.InitialDirectory = "c:\casparcg\mydata\weather\weather list\"
    End Sub

    Private Sub weathericon4_Enter(sender As Object, e As EventArgs) Handles weathericon4.Enter
    End Sub

    Private Sub weathericon3_Enter(sender As Object, e As EventArgs) Handles weathericon3.Enter
    End Sub

    Private Sub weathericon2_Enter(sender As Object, e As EventArgs) Handles weathericon2.Enter
    End Sub

    Private Sub weathericon1_Enter(sender As Object, e As EventArgs) Handles weathericon1.Enter
    End Sub

    Private Sub cmdhideweather_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ucWeather_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enumweathericons()
    End Sub

    Sub enumweathericons()
        On Error Resume Next

        Me.cmbweathericon1.Items.Clear()
        Me.cmbweathericon2.Items.Clear()
        Me.cmbweathericon3.Items.Clear()
        Me.cmbweathericon4.Items.Clear()

        For Each Filefound As String In IO.Directory.GetFiles("c:/casparcg/mydata/weather", "*.*")
            Dim stringtocut As Integer = 28
            Dim filefound1 = Mid(Filefound, stringtocut)
            Me.cmbweathericon1.Items.Add(filefound1)
            Me.cmbweathericon2.Items.Add(filefound1)
            Me.cmbweathericon3.Items.Add(filefound1)
            Me.cmbweathericon4.Items.Add(filefound1)
        Next
    End Sub

    Sub playweather()
        On Error Resume Next
        LoadWeatherTemplateData()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmbweathericon1videolayer.Text), Int(cmbweathericon1videolayer.Text), txtWeatherTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub cmdweathericon1play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweathericon1play.Click
        On Error Resume Next
        playweather()
    End Sub

    Private Sub nweathericonvaluechange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        nweathericon1x.ValueChanged, nweathericon1y.ValueChanged, nweathericon1width.ValueChanged, nweathericon1height.ValueChanged,
        nweathericon2x.ValueChanged, nweathericon2y.ValueChanged, nweathericon2width.ValueChanged, nweathericon2height.ValueChanged,
        nweathericon3x.ValueChanged, nweathericon3y.ValueChanged, nweathericon3width.ValueChanged, nweathericon3height.ValueChanged,
        nweathericon4x.ValueChanged, nweathericon4y.ValueChanged, nweathericon4width.ValueChanged, nweathericon4height.ValueChanged
        On Error Resume Next
        LoadWeatherTemplateData()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmbweathericon1videolayer.Text), Int(cmbweathericon1videolayer.Text), CasparCGDataCollection)
    End Sub

    Private Sub cmdweathericon1stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweathericon1stop.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmbweathericon1videolayer.Text), Int(cmbweathericon1videolayer.Text))
    End Sub

    Private Sub cmbweathericonchange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbweathericon1.SelectedIndexChanged, cmbweathericon2.SelectedIndexChanged, cmbweathericon3.SelectedIndexChanged, cmbweathericon4.SelectedIndexChanged
        On Error Resume Next
        weathericon1.Movie = "file:///c:/casparcg/mydata/weather/" & cmbweathericon1.Text
        weathericon2.Movie = "file:///c:/casparcg/mydata/weather/" & cmbweathericon2.Text
        weathericon3.Movie = "file:///c:/casparcg/mydata/weather/" & cmbweathericon3.Text
        weathericon4.Movie = "file:///c:/casparcg/mydata/weather/" & cmbweathericon4.Text
    End Sub

    Private Sub savetsweather_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub opentsweather_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Sub readfileforweather(ByVal str As String)
        On Error Resume Next
        Dim i As Integer
        Dim a As Array

        a = Split(My.Computer.FileSystem.ReadAllText(str), Chr(2) + "=")
        Dim b As Array

        For i = 0 To Me.gbweather.Controls.Count - 1
            b = Split(a(i + 1), vbCrLf)
            Me.gbweather.Controls(i).Text = b(0)
        Next
    End Sub

    Private Sub cmdrefreshmedaiforweather_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefreshmedaiforweather.Click
        On Error Resume Next
        enumweathericons()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        ConfigureWeatherDialog(ofd2)
        If (ofd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            readfileforweather(ofd2.FileName)
            lblweatherfilename.Text = ofd2.FileName
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        ConfigureWeatherDialog(osd2)
        osd2.FileName = ""
        If (osd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Dim i As Integer
            Dim a As String = ""
            For i = 0 To Me.gbweather.Controls.Count - 1
                a = a + Me.gbweather.Controls(i).Name + Chr(2) + "=" + Me.gbweather.Controls(i).Text + vbCrLf
            Next
            a = a + Chr(2) + "=  "
            My.Computer.FileSystem.WriteAllText(osd2.FileName, a, False)
            lblweatherfilename.Text = osd2.FileName
        End If
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub
End Class
