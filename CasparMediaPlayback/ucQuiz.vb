Imports System.IO

Public Class ucQuiz
    Private Function GetQuizLayerOffset(offset As Integer) As Integer
        Return Int(cmbvideolayerquiz.Text) + offset
    End Function

    Private Function EncodeQuizText(value As String) As String
        Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(value)
        Return Convert.ToBase64String(data)
    End Function

    Private Sub ConfigureQuizFileDialog(dialog As FileDialog)
        dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        dialog.InitialDirectory = "c:\casparcg\mydata\quiz\"
    End Sub

    Private Sub ResetQuizGrid(defaultRows As Integer)
        dgvquiz.Rows.Clear()
        dgvquiz.Rows.Add(defaultRows)
    End Sub

    Private Function GetQuizAnswerOption(answerOffset As Integer) As String
        Return Chr(Asc("A"c) + answerOffset - 1)
    End Function

    Private Sub MoveQuizRow(offset As Integer)
        Dim currentIndex As Integer = dgvquiz.CurrentCell.RowIndex
        Dim targetIndex As Integer = currentIndex + offset
        If targetIndex < 0 OrElse targetIndex > dgvquiz.Rows.Count - 2 Then Return

        Dim currentRow As DataGridViewRow = dgvquiz.CurrentRow
        dgvquiz.Rows.Remove(currentRow)
        dgvquiz.Rows.Insert(targetIndex, currentRow)
        dgvquiz.CurrentCell = dgvquiz.Rows(targetIndex).Cells(0)
    End Sub

    Private Sub cmdplayquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdplayquiz.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        Dim cr As Integer = dgvquiz.CurrentRow.Index
        CasparCGDataCollection.SetData("xf0", EncodeQuizText(dgvquiz.Rows(cr).Cells(0).Value))
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetQuizLayerOffset(0), GetQuizLayerOffset(0), txtQuizTemplate.Text & "/quiz", True, CasparCGDataCollection.ToAMCPEscapedXml)

    End Sub
    Private Sub cmdstopquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdstopquiz.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetQuizLayerOffset(0), GetQuizLayerOffset(0))
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetQuizLayerOffset(1), GetQuizLayerOffset(1))
    End Sub

    Private Sub cmdanswerquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdanswerquiz.Click
        On Error Resume Next
        Dim cr As Integer = dgvquiz.CurrentRow.Index
        For answerOffset As Integer = 1 To 4
            If dgvquiz.Rows(cr + answerOffset).Cells(1).Value = 1 Then
                CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Invoke(GetQuizLayerOffset(1), GetQuizLayerOffset(1), GetQuizAnswerOption(answerOffset))
                Exit For
            End If
        Next
    End Sub

    Private Sub tsnewquiz_Click(sender As System.Object, e As System.EventArgs)
    End Sub
    Sub newdgvquiz()

        On Error Resume Next
        ResetQuizGrid(10)
        lblfilenamequiz.Text = "new"
    End Sub

    Private Sub tsopenquiz_Click(sender As System.Object, e As System.EventArgs)
    End Sub
    Sub openfilequiz()
        On Error Resume Next
        Dim ofd2 As New OpenFileDialog
        ConfigureQuizFileDialog(ofd2)
        If (ofd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Using sr As StreamReader = New StreamReader(ofd2.FileName)
                'clear list
                dgvquiz.Rows.Clear()
                'Loop through and add list to the file.
                Dim g As Integer = 0
                Dim li As String
                Do Until sr.EndOfStream = True
                    li = sr.ReadLine()
                    dgvquiz.Rows.Add()
                    Dim xyz As Array = Split(li, Chr(2))
                    dgvquiz.Rows(g).Cells(0).Value = xyz(0)
                    dgvquiz.Rows(g).Cells(1).Value = xyz(1)
                    g = g + 1
                Loop
                sr.Close()
            End Using
            lblfilenamequiz.Text = ofd2.FileName
        End If
    End Sub

    Private Sub tssavequiz_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Sub savefilequiz()
        On Error Resume Next
        ConfigureQuizFileDialog(osd2)
        osd2.FileName = ""
        If (osd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Using sw As StreamWriter = New StreamWriter(osd2.FileName)
                If dgvquiz.Rows.Count = 0 Then
                    sw.Write("")
                Else
                    'Loop through and add list to the file.
                    Dim f As Integer = 0
                    Do Until f = dgvquiz.Rows.Count
                        If dgvquiz.Rows(f).Cells(1).Value = False Then dgvquiz.Rows(f).Cells(1).Value = "0"
                        sw.WriteLine(dgvquiz.Rows(f).Cells(0).Value & Chr(2) & dgvquiz.Rows(f).Cells(1).Value)
                        f = f + 1
                    Loop
                End If
                sw.Close()
            End Using
            lblfilenamequiz.Text = osd2.FileName
        End If
    End Sub
    Private Sub tscutquiz_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Sub deleteclipquiz()
        On Error Resume Next
        dgvquiz.Rows.RemoveAt(dgvquiz.CurrentRow.Index)
    End Sub

    Private Sub cmdaddquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdaddquiz.Click
        On Error Resume Next
        clipinsertquiz()
    End Sub
    Sub clipinsertquiz()
        On Error Resume Next
        dgvquiz.Rows.Insert(dgvquiz.CurrentRow.Index)
        dgvquiz.Rows(dgvquiz.CurrentRow.Index - 1).Cells(3).Value = 1
    End Sub

    Private Sub cmddownquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmddownquiz.Click
        On Error Resume Next
        clipmovedownquiz()
    End Sub
    Sub clipmovedownquiz()
        On Error Resume Next
        MoveQuizRow(1)
    End Sub

    Private Sub cmdupquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdupquiz.Click
        On Error Resume Next
        clipmoveupquiz()
    End Sub
    Sub clipmoveupquiz()
        On Error Resume Next
        MoveQuizRow(-1)
    End Sub

    Private Sub tspastequiz_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Sub insertcopiedquiz()
        On Error Resume Next
        Dim curRow As Integer = Me.dgvquiz.CurrentCell.RowIndex
        dgvquiz.Rows.Insert(dgvquiz.CurrentRow.Index)
        dgvquiz.CurrentCell = dgvquiz.Rows(curRow).Cells(0)
        Me.dgvquiz.Item(0, curRow).Value = tempRow.Cells(0).Value
        Me.dgvquiz.Item(1, curRow).Value = tempRow.Cells(1).Value
    End Sub
    Private Sub cmdcutquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdcutquiz.Click
        On Error Resume Next
        deleteclipquiz()
    End Sub

    Private Sub tscopyquiz_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Sub copyquiz()
        On Error Resume Next
        tempRow = Me.dgvquiz.CurrentRow
    End Sub

    Private Sub cmdplaytimerquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdplaytimerquiz.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetQuizLayerOffset(2), GetQuizLayerOffset(2), txtQuizTemplate.Text & "/timer", True, CasparCGDataCollection.ToAMCPEscapedXml)

    End Sub

    Private Sub cmdstoptimerquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdstoptimerquiz.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(GetQuizLayerOffset(2), GetQuizLayerOffset(2))

    End Sub

    Private Sub cmdpausetimerquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdpausetimerquiz.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("stoptimer", "")
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(GetQuizLayerOffset(2), GetQuizLayerOffset(2), CasparCGDataCollection)

    End Sub
    Private Sub cmdplayanswerquiz_Click(sender As System.Object, e As System.EventArgs) Handles cmdplayanswerquiz.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()

        Dim cr As Integer = dgvquiz.CurrentRow.Index
        CasparCGDataCollection.SetData("xf1", EncodeQuizText("A: " & dgvquiz.Rows(cr + 1).Cells(0).Value))
        CasparCGDataCollection.SetData("xf2", EncodeQuizText("B: " & dgvquiz.Rows(cr + 2).Cells(0).Value))
        CasparCGDataCollection.SetData("xf3", EncodeQuizText("C: " & dgvquiz.Rows(cr + 3).Cells(0).Value))
        CasparCGDataCollection.SetData("xf4", EncodeQuizText("D: " & dgvquiz.Rows(cr + 4).Cells(0).Value))

        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetQuizLayerOffset(1), GetQuizLayerOffset(1), txtQuizTemplate.Text & "/quiz1", True, CasparCGDataCollection.ToAMCPEscapedXml)

    End Sub

    Private Sub cmdhidequiz_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
    Sub initialisquizdata()
        On Error Resume Next
        dgvquiz.Rows.Add(10)
        dgvquiz.Item(0, 0).Value = "Where is Mumbai? "
        dgvquiz.Item(0, 1).Value = "America"
        dgvquiz.Item(0, 2).Value = "England"
        dgvquiz.Item(0, 3).Value = "India"
        dgvquiz.Item(0, 4).Value = "Japan"
        dgvquiz.Item(1, 3).Value = 1
    End Sub

    Private Sub ucQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialisquizdata()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        newdgvquiz()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        openfilequiz()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        savefilequiz()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        On Error Resume Next
        deleteclipquiz()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        On Error Resume Next
        copyquiz()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        On Error Resume Next
        insertcopiedquiz()
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub
End Class
