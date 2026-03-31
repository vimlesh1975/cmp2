Public Class ucElement
    Private Const BorderFilter As String = "vf drawbox=x=y:w=h:color=white:t=20"
    Private Const YoutubeHtmlPath As String = "file:///C:/casparcg/mydata/youtube/youtube.html"
    Private Const CaptionHtmlPath As String = "c:/casparcg/CMP/Composition/SourceName/gwd_preview_SourceName/index.html"
    Private Const DecklinkPreviewPath As String = "c:/casparcg/_media/decklink_card.jpg"
    Private Const BluefishPreviewPath As String = "c:/casparcg/_media/bluefish_card.jpg"
    Private Const HttpPreviewPath As String = "c:/casparcg/_media/http.png"
    Private Const YoutubePreviewPath As String = "c:/casparcg/_media/youtube.png"
    Private Const NdiPreviewPath As String = "c:/casparcg/_media/ndi.jpg"

    Private Sub UserControl1_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        On Error Resume Next

        Dim ss As New OpenFileDialog
        If ss.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        SetElementInfo("file", ss.FileName, "")
        PlayFileSource(ss.FileName)
        ApplyElementFill(Me)
    End Sub

    Private Sub event1(sender As Object, e As EventArgs) Handles Me.LocationChanged, Me.Resize
        On Error Resume Next
        elementmove = True
        ApplyElementFill(sender)
        VlcControl1.Size = New Size(Me.Width - 20, Me.Height - 30)

        Form1.UcMixernew1.cmbvideolayerformixer.Text = Label1.Text

        For Each control1 As Control In Me.Controls
            If control1.Name.Contains("media") Then
                Dim captionControl = CType(control1, UcCaption)
                captionControl.event1(captionControl, e)
            End If
        Next
    End Sub

    Private Sub UserControl1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        On Error Resume Next

        Dim droppedFile As String = e.Data.GetData(DataFormats.FileDrop)(0)
        SetElementInfo("file", droppedFile, "")
        PlayFileSource(droppedFile)
        ApplyElementFill(Me)
    End Sub

    Private Sub UserControl1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        On Error Resume Next
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Element_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        On Error Resume Next
        CasparDevice.SendString("clear " & GetLayerAddress())
        Me.Dispose()
    End Sub

    Private Sub UriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UriToolStripMenuItem.Click
        On Error Resume Next

        Dim ff As String = InputBox("Change MRL", "", VlcControl1.VlcMediaPlayer.GetMedia.Mrl)
        If ff = "" Then
            Exit Sub
        End If

        SetElementInfo("file", ff, "")
        VlcControl1.Play(New Uri(ff), params)
        PlayMediaCommand(GetQuotedMrlPath(), True)
    End Sub

    Private Async Sub ghfgh(sender As Object, e As EventArgs) Handles Me.MouseHover
    End Sub

    Private Sub Decklink2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Decklink2ToolStripMenuItem.Click
        On Error Resume Next

        Dim ff = InputBox("decklink card", "", "Decklink 2")
        If ff = "" Then
            Exit Sub
        End If

        SetElementInfo("decklink", ff, "")
        CasparDevice.SendString("play " & GetLayerAddress() & " " & ff)
        PlayPreviewImage(DecklinkPreviewPath)
    End Sub

    Private Sub BluefishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BluefishToolStripMenuItem.Click
        On Error Resume Next

        Dim ff = InputBox("bluefish card", "", "Bluefish 2")
        If ff = "" Then
            Exit Sub
        End If

        SetElementInfo("bluefish", ff, "")
        CasparDevice.SendString("play " & GetLayerAddress() & " " & ff)
        PlayPreviewImage(BluefishPreviewPath)
    End Sub

    Private Sub StreamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StreamToolStripMenuItem.Click
        On Error Resume Next

        Dim ff As String = InputBox("Put Stream Address", "", "udp://@224.0.0.1:5004")
        If ff = "" Then
            Exit Sub
        End If

        SetElementInfo("stream", ff, "")
        VlcControl1.Play(New Uri(ff), params)
        CasparDevice.SendString("play " & GetLayerAddress() & " " & ff)
    End Sub

    Private Sub HtmlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HtmlToolStripMenuItem.Click
        On Error Resume Next

        Dim ff As String = InputBox("Put web Address", "", "http://casparcgforum.com")
        If ff = "" Then
            Exit Sub
        End If

        SetElementInfo("html", ff, "")
        PlayPreviewImage(HttpPreviewPath)
        CasparDevice.SendString("play " & GetLayerAddress() & " [html] " & ff)
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        On Error Resume Next

        Dim ff As String = InputBox("Put youtube Video ID", "", "plxV00PcX28")
        If ff = "" Then
            Exit Sub
        End If

        Dim ff1 As String = InputBox("Put Size of Channel", "", "1024x576")
        If ff1 = "" Then
            Exit Sub
        End If

        SetElementInfo("youtube", ff, ff1)
        PlayPreviewImage(YoutubePreviewPath)
        VlcControl1.Tag = ff
        PlayYoutubeSource(ff, ff1, "")
    End Sub

    Private Sub SendToBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToBackToolStripMenuItem.Click
        Me.SendToBack()
    End Sub

    Private Sub BringToFrontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BringToFrontToolStripMenuItem.Click
        Me.BringToFront()
    End Sub

    Private Sub AddCaptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCaptionToolStripMenuItem.Click
        Dim ss As String = InputBox("Source name", "", "SOURCE 1")
        If ss = "" Then
            Exit Sub
        End If

        intElements += 1
        Dim media As New UcCaption
        Me.Controls.Add(media)
        media.Label1.Text = intElements
        media.Name = "media" & intElements
        Form1.UcMixernew1.cmbvideolayerformixer.Text = media.Label1.Text
        media.Location = New Point((Me.Width - media.Width) / 2, (Me.Height - media.Height))
        Dim rs1 = New clsResizeableControlnew(media)

        media.Label2.Text = ss
        CasparDevice.SendString("play " & g_int_ChannelNumber & "-" & media.Label1.Text & " [html] " & """" & CaptionHtmlPath & """")
        CasparDevice.SendString("call " & g_int_ChannelNumber & "-" & media.Label1.Text & " updatestring('" & replacestring1("ccgf0") & "','" & replacestring1(ss) & "')")
        CasparDevice.SendString("mixer " & g_int_ChannelNumber & "-" & media.Label1.Text & " fill " & fillcommandCaption(media)(0))
        media.BringToFront()

        Form1.ElementInfo1.Type1 = "caption"
        Form1.ElementInfo1.url1 = ss
        Form1.ElementInfo1.url2 = Me.Name
        media.Tag = BuildElementTag(Form1.ElementInfo1.Type1, Form1.ElementInfo1.url1, Form1.ElementInfo1.url2)
    End Sub

    Private Sub ucElement_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        elementmove = False
    End Sub

    Private Sub NDIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NDIToolStripMenuItem.Click
        On Error Resume Next

        Dim aa As New Form
        Dim bb As New ucNDISource
        aa.Controls.Add(bb)
        aa.ShowDialog()

        SetElementInfo("ndi", ndi1, "")
        PlayPreviewImage(NdiPreviewPath)
        CasparDevice.SendString("play " & GetLayerAddress() & " [ndi] " & ndi1)
    End Sub

    Private Sub ucElement_Click(sender As Object, e As EventArgs) Handles Me.Click
        Label2.Text = Me.Tag.Split(Chr(3))(1)
    End Sub

    Private Sub AddBorderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBorderToolStripMenuItem.Click
        CasparDevice.SendString("stop " & GetLayerAddress())

        Select Case GetTagPart(0)
            Case "file"
                PlayMediaCommand("""" & Replace(Replace(GetTagPart(1), "\", "/"), ":/", "://") & """", False, BorderFilter)
            Case "ndi"
                CasparDevice.SendString("play " & GetLayerAddress() & " [ndi] " & GetTagPart(1) & " " & BorderFilter)
            Case "html"
                CasparDevice.SendString("play " & GetLayerAddress() & " [html] " & GetTagPart(1) & " " & BorderFilter)
            Case "youtube"
                PlayYoutubeSource(GetTagPart(1), GetTagPart(2), BorderFilter)
            Case Else
                CasparDevice.SendString("play " & GetLayerAddress() & " " & GetTagPart(1) & " " & BorderFilter)
        End Select
    End Sub

    Private Function GetLayerAddress() As String
        Return g_int_ChannelNumber & "-" & Me.Label1.Text
    End Function

    Private Sub SetElementInfo(typeName As String, url1 As String, url2 As String)
        Form1.ElementInfo1.Type1 = typeName
        Form1.ElementInfo1.url1 = url1
        Form1.ElementInfo1.url2 = url2
        Me.Tag = BuildElementTag(typeName, url1, url2)
    End Sub

    Private Function BuildElementTag(typeName As String, url1 As String, url2 As String) As String
        Return typeName & Chr(3) & url1 & Chr(3) & url2
    End Function

    Private Function GetTagPart(index As Integer) As String
        Return Me.Tag.Split(Chr(3))(index)
    End Function

    Private Sub ApplyElementFill(target As Object)
        CasparDevice.SendString("mixer " & GetLayerAddress() & " fill " & fillcommand(target)(0))
    End Sub

    Private Sub PlayFileSource(filePath As String)
        VlcControl1.Play(New Uri(filePath), params)

        If ServerVersion > 2.1 AndAlso IsValidImage(filePath) Then
            CasparDevice.SendString("play " & GetLayerAddress() & " [html] " & """" & Replace(filePath, "\", "/") & """")
        Else
            PlayMediaCommand(GetQuotedMrlPath(), True)
        End If
    End Sub

    Private Function GetQuotedMrlPath() As String
        Return """" & Replace(Replace(Split(VlcControl1.VlcMediaPlayer.GetMedia.Mrl, "///")(1), ":/", "://"), "%20", " ") & """"
    End Function

    Private Sub PlayMediaCommand(source As String, includeLoop As Boolean, Optional extraArgs As String = "")
        Dim command As String = "play " & GetLayerAddress() & " " & source

        If includeLoop Then
            command &= " loop"
        End If

        If extraArgs <> "" Then
            command &= " " & extraArgs
        End If

        CasparDevice.SendString(command)
    End Sub

    Private Sub PlayPreviewImage(previewPath As String)
        VlcControl1.Play(New Uri(previewPath), params)
    End Sub

    Private Sub PlayYoutubeSource(videoId As String, sizeText As String, borderSuffix As String)
        CasparDevice.SendString("play " & GetLayerAddress() & " [HTML]  " & YoutubeHtmlPath & If(borderSuffix <> "", " " & borderSuffix, ""))
        CasparDevice.SendString("mixer " & GetLayerAddress() & " opacity 0")
        Threading.Thread.Sleep(1000)
        CasparDevice.SendString("Call " & GetLayerAddress() & " player.loadVideoById('" & videoId & "')")
        CasparDevice.SendString("Call " & GetLayerAddress() & " player.setSize('" & Split(sizeText, "x")(0) & "','" & Split(sizeText, "x")(1) & "')")
        Threading.Thread.Sleep(1000)
        CasparDevice.SendString("mixer " & GetLayerAddress() & " opacity 1")
    End Sub
End Class
