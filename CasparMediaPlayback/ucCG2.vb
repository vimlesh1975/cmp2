Imports System.IO

Public Class ucCG2
    Private Const GameLogoKey As String = "loader5"
    Private Const EventLogoKey As String = "loader6"
    Private Const DefaultCg2Directory As String = "c:\casparcg\mydata\cg2\"
    Private Const EventLogoDirectory As String = "C:\casparcg\mydata\games\event logo\"
    Private Const GameLogoDirectory As String = "C:\casparcg\mydata\games\Games logo\"
    Private Const AnimationDuration As String = "50 easeoutexpo"

    Private Enum AnimationDirection
        None
        Left
        Right
        Up
        Down
        Fade
    End Enum

    Private Sub cmd10linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10linercg2.Click
        PlayLineTemplate(10)
    End Sub

    Private Sub cmd9linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9linercg2.Click
        PlayLineTemplate(9)
    End Sub

    Private Sub cmd8linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8linercg2.Click
        PlayLineTemplate(8)
    End Sub

    Private Sub cmd7linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7linercg2.Click
        PlayLineTemplate(7)
    End Sub

    Private Sub cmd6linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6linercg2.Click
        PlayLineTemplate(6)
    End Sub

    Private Sub cmd5linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5linercg2.Click
        PlayLineTemplate(5)
    End Sub

    Private Sub cmd4linercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4linercg2.Click
        PlayLineTemplate(4)
    End Sub

    Private Sub cmdthreelinercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthreelinercg2.Click
        PlayLineTemplate(3)
    End Sub

    Private Sub cmdtwolinercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtwolinercg2.Click
        PlayLineTemplate(2)
    End Sub

    Private Sub cmdonelinercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdonelinercg2.Click
        PlayLineTemplate(1)
    End Sub

    Private Sub cmdrefreshdatacg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefreshdatacg2.Click
        refreshdatacg2()
    End Sub

    Private Sub cmd3linercentercg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3linercentercg2.Click
        PlayTemplateWithCurrentData("3linecenter", GetSequentialRowValues(3))
    End Sub

    Private Sub cmdstopcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopcg2.Click
        On Error Resume Next

        If chkanimationcg2.Checked Then
            animation2()
        End If

        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetLayerNumber(), GetLayerNumber())
        Threading.Thread.Sleep(1000)

        If chkanimationcg2.Checked Then
            animationtoscreen()
        End If
    End Sub

    Private Sub dgvinfocg2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvinfocg2.CellClick
        On Error Resume Next

        For rowIndex As Integer = 0 To dgvinfocg2.RowCount - 1
            dgvinfocg2.Rows(rowIndex).Cells(1).Value = ""
        Next

        For marker As Integer = 1 To 20
            dgvinfocg2.Rows(dgvinfocg2.CurrentRow.Index + marker - 1).Cells(1).Value = marker
        Next
    End Sub

    Private Sub cmdhidecg2_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub eventlogoforcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eventlogoforcg2.Click
        SelectLogo(eventlogoforcg2, EventLogoDirectory)
    End Sub

    Private Sub gamelogoforcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gamelogoforcg2.Click
        SelectLogo(gamelogoforcg2, GameLogoDirectory)
    End Sub

    Private Sub cmdsaveasnewfilecg2_Click(sender As Object, e As EventArgs) Handles cmdsaveasnewfilecg2.Click
        On Error Resume Next

        osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        osd2.InitialDirectory = DefaultCg2Directory

        If osd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveGridToFile(osd2.FileName)
            lblfilenamecg2.Text = osd2.FileName
        End If
    End Sub

    Private Sub cmdnewcg2_Click(sender As Object, e As EventArgs)
        ClearGrid()
    End Sub

    Private Sub cmdopencg2_Click(sender As Object, e As EventArgs)
        OpenCg2File()
    End Sub

    Private Sub cmdsavecg2_Click(sender As Object, e As EventArgs)
        On Error Resume Next

        osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        osd2.InitialDirectory = DefaultCg2Directory
        SaveGridToFile(lblfilenamecg2.Text)
    End Sub

    Private Sub cmduprowcg2_Click(sender As Object, e As EventArgs) Handles cmduprowcg2.Click
        up(dgvinfocg2)
    End Sub

    Private Sub cmddownrowcg2_Click(sender As Object, e As EventArgs) Handles cmddownrowcg2.Click
        down(dgvinfocg2)
    End Sub

    Private Sub cmdaddrowcg2_Click(sender As Object, e As EventArgs) Handles cmdaddrowcg2.Click
        insert(dgvinfocg2)
    End Sub

    Private Sub cmdremoverowcg2_Click(sender As Object, e As EventArgs) Handles cmdremoverowcg2.Click
        delete(dgvinfocg2)
    End Sub

    Private Sub cmdvenueidcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvenueidcg2.Click
        PlayTemplateWithCurrentData("venue_id", GetSequentialRowValues(1))
    End Sub

    Private Sub cmdeventidcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdeventidcg2.Click
        PlayTemplateWithCurrentData("event_id", GetSequentialRowValues(2))
    End Sub

    Private Sub cmdEventShedulecg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEventShedulecg2.Click
        PlayTemplateWithCurrentData("event_shedule", GetSequentialRowValues(16))
    End Sub

    Private Sub cmdvictoryidcg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvictoryidcg2.Click
        PlayTemplateWithCurrentData("victory_id", GetSequentialRowValues(2))
    End Sub

    Private Sub cmdOfficialID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOfficialID.Click
        PlayTemplateWithCurrentData("official_id", GetSequentialRowValues(2))
    End Sub

    Private Sub ucCG2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdatacg2()
    End Sub

    Private Sub cmdNextStepCG2_Click(sender As Object, e As EventArgs) Handles cmdNextStepCG2.Click
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Next(GetLayerNumber(), GetLayerNumber())
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRightIN.CheckedChanged
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub

    Private Sub gbcg2_Enter(sender As Object, e As EventArgs) Handles gbcg2.Enter
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ClearGrid()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenCg2File()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next

        osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        osd2.InitialDirectory = DefaultCg2Directory
        osd2.FileName = ""
        SaveGridToFile(lblfilenamecg2.Text)
    End Sub

    Private Sub PlayLineTemplate(lineCount As Integer)
        PlayTemplateWithCurrentData(lineCount & "line", GetSequentialRowValues(lineCount))
    End Sub

    Private Sub PlayTemplateWithCurrentData(templateName As String, values As List(Of String))
        On Error Resume Next

        If chkanimationcg2.Checked Then
            animation1()
        End If

        PopulateTemplateData(values)
        AddSharedTemplateAssets()

        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(
            GetLayerNumber(),
            GetLayerNumber(),
            BuildTemplatePath(templateName),
            True,
            CasparCGDataCollection.ToAMCPEscapedXml)

        If chkanimationcg2.Checked Then
            animationtoscreen()
        End If
    End Sub

    Private Sub PopulateTemplateData(values As IEnumerable(Of String))
        CasparCGDataCollection.Clear()

        Dim fieldIndex As Integer = 0
        For Each value In values
            CasparCGDataCollection.SetData("f" & fieldIndex, value)
            fieldIndex += 1
        Next
    End Sub

    Private Sub AddSharedTemplateAssets()
        CasparCGDataCollection.SetData(GameLogoKey, gamelogoforcg2.ImageLocation)
        CasparCGDataCollection.SetData(EventLogoKey, eventlogoforcg2.ImageLocation)
    End Sub

    Private Function GetSequentialRowValues(count As Integer) As List(Of String)
        Dim values As New List(Of String)
        Dim startIndex = GetCurrentRowIndex()

        For offset As Integer = 0 To count - 1
            values.Add(dgvinfocg2.Rows(startIndex + offset).Cells(0).Value)
        Next

        Return values
    End Function

    Private Function GetCurrentRowIndex() As Integer
        Return dgvinfocg2.CurrentRow.Index
    End Function

    Private Function GetLayerNumber() As Integer
        Return Int(cmblayercg2.Text)
    End Function

    Private Function BuildTemplatePath(templateName As String) As String
        Return txtTemplateDirectoryCg2.Text.TrimEnd("/"c) & "/" & templateName
    End Function

    Sub cg2dataandtemplate(ByVal cg2 As Integer)
        PlayLineTemplate(cg2)
    End Sub

    Sub animation1()
        Dim direction = GetInAnimationDirection()

        If direction = AnimationDirection.Fade Then
            SendMixerCommand("opacity  0")
            Exit Sub
        End If

        Dim fill = GetAnimationFill(direction)
        If fill IsNot Nothing Then
            SendMixerCommand("fill " & fill & " 1 1 " & AnimationDuration)
        End If
    End Sub

    Sub animationtoscreen()
        If rdoFedIN.Checked Or rdoFedOut.Checked Then
            SendMixerCommand("opacity 1 " & AnimationDuration)

            If chkanimationforhdvancg2.Checked Then
                SendMixerCommand("fill .1 0 .8 1 " & AnimationDuration)
            End If

            Exit Sub
        End If

        If chkanimationforhdvancg2.Checked Then
            SendMixerCommand("fill .12 0 .76 1 " & AnimationDuration)
        Else
            SendMixerCommand("fill 0 0 1 1 " & AnimationDuration)
        End If
    End Sub

    Sub animation2()
        Dim direction = GetOutAnimationDirection()

        If direction = AnimationDirection.Fade Then
            SendMixerCommand("opacity 0 " & AnimationDuration)
            Exit Sub
        End If

        Dim fill = GetAnimationFill(direction)
        If fill IsNot Nothing Then
            SendMixerCommand("fill " & fill & " 1 1 " & AnimationDuration)
        End If
    End Sub

    Private Function GetInAnimationDirection() As AnimationDirection
        If rdoLeftIN.Checked Then
            Return AnimationDirection.Left
        ElseIf rdoRightIN.Checked Then
            Return AnimationDirection.Right
        ElseIf rdoUpIN.Checked Then
            Return AnimationDirection.Up
        ElseIf rdoDownIN.Checked Then
            Return AnimationDirection.Down
        ElseIf rdoFedIN.Checked Then
            Return AnimationDirection.Fade
        End If

        Return AnimationDirection.None
    End Function

    Private Function GetOutAnimationDirection() As AnimationDirection
        If rdoleftOut.Checked Then
            Return AnimationDirection.Left
        ElseIf rdoRightOut.Checked Then
            Return AnimationDirection.Right
        ElseIf rdoUpOut.Checked Then
            Return AnimationDirection.Up
        ElseIf rdoDownOut.Checked Then
            Return AnimationDirection.Down
        ElseIf rdoFedOut.Checked Then
            Return AnimationDirection.Fade
        End If

        Return AnimationDirection.None
    End Function

    Private Function GetAnimationFill(direction As AnimationDirection) As String
        Select Case direction
            Case AnimationDirection.Left
                Return "-1 0"
            Case AnimationDirection.Right
                Return "1 0"
            Case AnimationDirection.Up
                Return "0 -1"
            Case AnimationDirection.Down
                Return "0 1"
            Case Else
                Return Nothing
        End Select
    End Function

    Private Sub SendMixerCommand(commandSuffix As String)
        CasparDevice.SendString("mixer " & g_int_ChannelNumber & "-" & cmblayercg2.Text & " " & commandSuffix)
    End Sub

    Sub refreshdatacg2()
        On Error Resume Next

        Using sr As StreamReader = New StreamReader(lblfilenamecg2.Text)
            dgvinfocg2.Rows.Clear()

            Dim rowIndex As Integer = 0
            Do Until sr.EndOfStream = True
                Dim line = sr.ReadLine()
                dgvinfocg2.Rows.Add()

                Dim parts As Array = Split(line, Chr(2))
                dgvinfocg2.Rows(rowIndex).Cells(0).Value = parts(0)
                rowIndex += 1
            Loop
        End Using
    End Sub

    Private Sub SaveGridToFile(fileName As String)
        Using sw As StreamWriter = New StreamWriter(fileName)
            If dgvinfocg2.Rows.Count = 0 Then
                sw.Write("")
            Else
                For rowIndex As Integer = 0 To dgvinfocg2.Rows.Count - 1
                    sw.WriteLine(dgvinfocg2.Rows(rowIndex).Cells(0).Value)
                Next
            End If
        End Using
    End Sub

    Private Sub OpenCg2File()
        Dim dialog As New OpenFileDialog
        dialog.InitialDirectory = DefaultCg2Directory

        If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblfilenamecg2.Text = dialog.FileName
            refreshdatacg2()
            dialog.Dispose()
        End If
    End Sub

    Private Sub ClearGrid()
        On Error Resume Next
        dgvinfocg2.Rows.Clear()
        lblfilenamecg2.Text = "New"
    End Sub

    Private Sub SelectLogo(target As PictureBox, initialDirectory As String)
        On Error Resume Next

        Dim dialog As New OpenFileDialog
        dialog.InitialDirectory = initialDirectory

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            target.ImageLocation = dialog.FileName
        End If
    End Sub
End Class
