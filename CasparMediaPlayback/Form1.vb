Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
    Private Const DefaultCompositionFile As String = "C:\casparcg\mydata\composition\test1.txt"
    Private Const CompositionDirectory As String = "C:\casparcg\mydata\composition"
    Private Const DefaultMediaPath As String = "c:/casparcg/_media/kabhi_kabhi.mp4"
    Private Const DefaultDummyMediaPath As String = "C:/casparcg/mydata/games/event logo/BLK.png"
    Private Const CaptionPreviewPath As String = "c:/casparcg/CMP/Composition/SourceName/gwd_preview_SourceName/index.html"
    Private Const YoutubeHtmlPath As String = "file:///C:/casparcg/mydata/youtube/youtube.html"

    Dim savefilename As String = DefaultCompositionFile

    <DllImport("winmm.dll")>
    Private Shared Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As UInteger
    End Function

    Public Structure ElementInfo
        Public Property Type1 As String
        Public Property url1 As String
        Public Property url2 As String
        Public Property Width As Integer
        Public Property Height As Integer
        Public Property Note As String
    End Structure

    Public ElementInfo1 As New ElementInfo

    Private Sub cmdAddMedia_Click(sender As Object, e As EventArgs) Handles cmdAddMedia.Click
        On Error Resume Next

        Dim media As ucElement = CreateElement("file", DefaultMediaPath, String.Empty)
        AddElementToCanvas(media)
        PlayElementLocally(media, DefaultMediaPath)
        SendFilePlayback(media, True)
        ApplyElementFill(media)
        media.BringToFront()
    End Sub

    Private Sub cmdClearChannel_Click(sender As Object, e As EventArgs) Handles cmdClearChannel.Click
        On Error Resume Next

        CasparDevice.SendString("clear " & g_int_ChannelNumber)
        CasparDevice.SendString("mixer " & g_int_ChannelNumber & " clear")

        Dim elementsToDispose As New List(Of Control)
        For Each child As Control In Panel1.Controls
            If TypeOf child Is ucElement Then
                elementsToDispose.Add(child)
            End If
        Next

        For Each elementControl As Control In elementsToDispose
            elementControl.Dispose()
        Next

        intElements = 1
        xx = 0
        yy = 0
    End Sub

    Private Sub cmdPlayAllfromBegining_Click(sender As Object, e As EventArgs) Handles cmdPlayAllfromBegining.Click
        On Error Resume Next

        For Each element As ucElement In GetCompositionElements()
            element.VlcControl1.Time = 0
            element.VlcControl1.Play()

            If element.VlcControl1.Tag <> "" Then
                CasparDevice.SendString("Call " & GetLayerAddress(element.Label1.Text) & " player.loadVideoById('" & element.VlcControl1.Tag & "')")
            Else
                SendFilePlayback(element, True)
            End If

            ApplyElementFill(element)
        Next
    End Sub

    Private Sub cmdPauseAll_Click(sender As Object, e As EventArgs) Handles cmdPauseAll.Click
        On Error Resume Next

        For Each element As ucElement In GetCompositionElements()
            element.VlcControl1.Pause()
            If element.VlcControl1.Tag <> "" Then
                CasparDevice.SendString("Call " & GetLayerAddress(element.Label1.Text) & " player.pauseVideo()")
            Else
                CasparDevice.SendString("pause " & GetLayerAddress(element.Label1.Text))
            End If
        Next
    End Sub

    Private Sub CmdResumeAll_Click(sender As Object, e As EventArgs) Handles cmdResumeAll.Click
        On Error Resume Next

        For Each element As ucElement In GetCompositionElements()
            element.VlcControl1.Play()
            If element.VlcControl1.Tag <> "" Then
                CasparDevice.SendString("Call " & GetLayerAddress(element.Label1.Text) & " player.playVideo()")
            Else
                CasparDevice.SendString("resume " & GetLayerAddress(element.Label1.Text))
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub CmdAddDummyMedia_Click(sender As Object, e As EventArgs) Handles cmdAddDummyMedia.Click
        On Error Resume Next

        Dim media As ucElement = CreateElement("empty1", "empty1", String.Empty, InputBox("Input layer Number", "", "96").ToString())
        AddElementToCanvas(media)
        PlayElementLocally(media, DefaultDummyMediaPath)
        ApplyElementFill(media)
        media.BringToFront()
    End Sub

    Private Sub CmdSaveFile_Click(sender As Object, e As EventArgs) Handles cmdSaveFile.Click
        On Error Resume Next

        Using sw As New StreamWriter(savefilename)
            For Each cControl1 As Control In Panel1.Controls
                Dim tb As ucElement = CType(cControl1, ucElement)
                sw.WriteLine(BuildElementSaveLine(tb))

                For Each cControl2 As Control In tb.Controls
                    If TypeOf cControl2 Is UcCaption Then
                        Dim caption As UcCaption = CType(cControl2, UcCaption)
                        sw.WriteLine(BuildCaptionSaveLine(caption))
                    End If
                Next
            Next
        End Using
    End Sub

    Private Sub CmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        Dim aa As New OpenFileDialog
        aa.InitialDirectory = CompositionDirectory
        aa.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*"

        If aa.ShowDialog <> DialogResult.OK Then
            Exit Sub
        End If

        savefilename = aa.FileName
        lblFileName.Text = savefilename
        cmdClearChannel.PerformClick()

        intElements = 0

        Using sr As New StreamReader(savefilename)
            Do Until sr.EndOfStream
                Dim line As String = sr.ReadLine()
                LoadSavedElement(line)
            Loop
        End Using
    End Sub

    Private Sub cmdSaveFileAs_Click(sender As Object, e As EventArgs) Handles cmdSaveFileAs.Click
        Dim aa As New SaveFileDialog
        aa.InitialDirectory = CompositionDirectory
        aa.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*"

        If aa.ShowDialog = DialogResult.OK Then
            savefilename = aa.FileName
            cmdSaveFile.PerformClick()
        End If
    End Sub

    Private Sub chkMuteAudio_CheckedChanged(sender As Object, e As EventArgs) Handles chkMuteAudio.CheckedChanged
        If chkMuteAudio.Checked Then
            waveOutSetVolume(IntPtr.Zero, 0)
        Else
            waveOutSetVolume(IntPtr.Zero, CUInt(UShort.MaxValue))
        End If
    End Sub

    Private Function CreateElement(typeName As String, url1 As String, url2 As String, Optional layerLabel As String = Nothing) As ucElement
        intElements += 1

        Dim media As New ucElement
        media.Name = "media" & intElements
        Dim rs2 = New clsResizeableControlnew(media)

        If String.IsNullOrWhiteSpace(layerLabel) Then
            media.Label1.Text = intElements.ToString()
        Else
            media.Label1.Text = layerLabel
        End If

        ElementInfo1.Type1 = typeName
        ElementInfo1.url1 = url1
        ElementInfo1.url2 = url2
        media.Tag = BuildElementTag(typeName, url1, url2)

        UcMixernew1.cmbvideolayerformixer.Text = media.Label1.Text
        Return media
    End Function

    Private Sub AddElementToCanvas(media As ucElement)
        media.Location = GetNextElementLocation(media)
        Panel1.Controls.Add(media)
        AdvancePlacementCursor(media)
    End Sub

    Private Function GetNextElementLocation(media As ucElement) As Point
        Return New Point(media.Width * xx, media.Height * yy)
    End Function

    Private Sub AdvancePlacementCursor(media As ucElement)
        If media.Location.X < (Panel1.Width - media.Width) Then
            xx += 1
        Else
            xx = 0
            yy += 1
        End If

        If intElements = 10 Then
            xx = 0
            yy = 0
        End If
    End Sub

    Private Iterator Function GetCompositionElements() As IEnumerable(Of ucElement)
        For Each child As Control In Panel1.Controls
            If TypeOf child Is ucElement Then
                Yield CType(child, ucElement)
            End If
        Next
    End Function

    Private Sub PlayElementLocally(media As ucElement, mediaPath As String)
        media.VlcControl1.Play(New Uri(mediaPath), params)
    End Sub

    Private Function BuildElementTag(typeName As String, url1 As String, url2 As String) As String
        Return typeName & Chr(3) & url1 & Chr(3) & url2
    End Function

    Private Function GetLayerAddress(layerText As String) As String
        Return g_int_ChannelNumber & "-" & layerText
    End Function

    Private Function GetElementMediaPath(element As ucElement) As String
        Return Replace(Replace(Split(element.VlcControl1.VlcMediaPlayer.GetMedia.Mrl, "///")(1), ":/", "://"), "%20", " ")
    End Function

    Private Sub SendFilePlayback(element As ucElement, includeLoop As Boolean)
        Dim command As String = "play " & GetLayerAddress(element.Label1.Text) & " " & """" & GetElementMediaPath(element) & """"
        If includeLoop Then
            command &= " loop"
        End If
        CasparDevice.SendString(command)
    End Sub

    Private Sub ApplyElementFill(element As ucElement)
        CasparDevice.SendString("mixer " & GetLayerAddress(element.Label1.Text) & " fill " & fillcommand(element)(0))
    End Sub

    Private Sub ApplyCaptionFill(caption As UcCaption)
        CasparDevice.SendString("mixer " & GetLayerAddress(caption.Label1.Text) & " fill " & fillcommandCaption(caption)(0))
    End Sub

    Private Function BuildElementSaveLine(element As ucElement) As String
        Return element.Name & Chr(2) &
               element.Label1.Text & Chr(2) &
               element.Tag & Chr(2) &
               element.Location.ToString() & Chr(2) &
               element.Size.ToString() & Chr(2) &
               element.VlcControl1.VlcMediaPlayer.GetMedia.Mrl
    End Function

    Private Function BuildCaptionSaveLine(caption As UcCaption) As String
        Return caption.Name & Chr(2) &
               caption.Label1.Text & Chr(2) &
               caption.Tag & Chr(2) &
               caption.Location.ToString() & Chr(2) &
               caption.Size.ToString() & Chr(2) &
               "file:///" & CaptionPreviewPath
    End Function

    Private Sub LoadSavedElement(line As String)
        Dim xyz As String() = Split(line, Chr(2))
        Dim layerNumber As Integer = CInt(Val(xyz(1)))

        If layerNumber > intElements Then
            intElements = layerNumber
        End If

        ElementInfo1.Type1 = Split(xyz(2), Chr(3))(0)
        ElementInfo1.url1 = Split(xyz(2), Chr(3))(1)
        ElementInfo1.url2 = Split(xyz(2), Chr(3))(2)

        If ElementInfo1.Type1 = "caption" Then
            LoadSavedCaption(xyz)
        Else
            LoadSavedMediaElement(xyz)
        End If
    End Sub

    Private Sub LoadSavedCaption(xyz As String())
        Dim caption As New UcCaption
        Panel1.Controls(ElementInfo1.url2).Controls.Add(caption)
        caption.label2.text = ElementInfo1.url1
        caption.Location = New Point((Panel1.Controls(ElementInfo1.url2).Width - caption.Width) / 2, (Panel1.Controls(ElementInfo1.url2).Height - caption.Height))
        caption.BringToFront()
        caption.Name = xyz(0)
        caption.Label1.Text = xyz(1)
        caption.Tag = xyz(2)
        caption.Size = stringtopoint(xyz(4))

        CasparDevice.SendString("play " & GetLayerAddress(caption.Label1.Text) & " [html] " & """" & CaptionPreviewPath & """")
        CasparDevice.SendString("call " & GetLayerAddress(caption.Label1.Text) & " updatestring('" & replacestring1("ccgf0") & "','" & replacestring1(caption.label2.text) & "')")
        ApplyCaptionFill(caption)
    End Sub

    Private Sub LoadSavedMediaElement(xyz As String())
        Dim media As New ucElement
        Panel1.Controls.Add(media)
        media.Location = stringtopoint(xyz(3))
        media.VlcControl1.VlcMediaPlayer.SetMedia(New Uri(xyz(5)))
        media.VlcControl1.Play(New Uri(xyz(5)), params)
        media.SendToBack()
        media.Name = xyz(0)
        Dim rs2 = New clsResizeableControlnew(media)
        media.Label1.Text = xyz(1)
        media.Tag = xyz(2)
        media.Size = stringtopoint(xyz(4))

        PlayLoadedMediaByType(media)
        ApplyElementFill(media)
    End Sub

    Private Sub PlayLoadedMediaByType(media As ucElement)
        Select Case ElementInfo1.Type1
            Case "file"
                Dim mediaPath As String = GetElementMediaPath(media)
                If ServerVersion > 2.1 And IsValidImage(mediaPath) Then
                    CasparDevice.SendString("play " & GetLayerAddress(media.Label1.Text) & " [html] " & """" & mediaPath & """")
                Else
                    SendFilePlayback(media, True)
                End If
            Case "decklink", "bluefish", "stream"
                CasparDevice.SendString("play " & GetLayerAddress(media.Label1.Text) & " " & ElementInfo1.url1)
            Case "ndi"
                CasparDevice.SendString("play " & GetLayerAddress(media.Label1.Text) & " [ndi] " & ElementInfo1.url1)
            Case "html"
                CasparDevice.SendString("play " & GetLayerAddress(media.Label1.Text) & " [html] " & ElementInfo1.url1)
            Case "youtube"
                CasparDevice.SendString("play " & GetLayerAddress(media.Label1.Text) & " [HTML]  " & YoutubeHtmlPath)
                CasparDevice.SendString("mixer " & GetLayerAddress(media.Label1.Text) & " opacity 0")
                Threading.Thread.Sleep(1000)
                CasparDevice.SendString("Call " & GetLayerAddress(media.Label1.Text) & " player.loadVideoById('" & ElementInfo1.url1 & "')")
                CasparDevice.SendString("Call " & GetLayerAddress(media.Label1.Text) & " player.setSize('" & Split(ElementInfo1.url2, "x")(0) & "','" & Split(ElementInfo1.url2, "x")(1) & "')")
                Threading.Thread.Sleep(1000)
                CasparDevice.SendString("mixer " & GetLayerAddress(media.Label1.Text) & " opacity 1")
            Case "empty", "empty1"
                ' Intentionally empty placeholders.
        End Select
    End Sub
End Class
