Imports System.IO

Public Class ucScroll
    Private Const ScrollDirectory As String = "c:\casparcg\mydata\scroll\"
    Private Const DefaultScrollFile As String = "c:\casparcg\mydata\scroll\04.08.17.txt"

    Dim tempspeed As Double
    Dim paused As Boolean = False

    Sub newdgvscroll()
        On Error Resume Next
        dgvscroll.Rows.Clear()
        dgvscroll.Rows.Add(7)
        dgvscroll.Columns(0).HeaderText = "new playlist"
    End Sub

    Sub openfilescroll()
        On Error Resume Next

        Dim fileName As String = PromptForScrollFile(False)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        LoadScrollRows(fileName, False)
        dgvscroll.Columns(0).HeaderText = fileName
    End Sub

    Sub insertfilescroll()
        On Error Resume Next

        Dim fileName As String = PromptForScrollFile(False)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        LoadScrollRows(fileName, True)
    End Sub

    Sub saveasfilescroll()
        On Error Resume Next

        Dim fileName As String = PromptForScrollFile(True)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        SaveScrollRows(fileName)
        dgvscroll.Columns(0).HeaderText = fileName
    End Sub

    Sub savefilescroll()
        On Error Resume Next
        SaveScrollRows(dgvscroll.Columns(0).HeaderText)
    End Sub

    Private Sub cuttsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Sub deleteclipscroll()
        On Error Resume Next
        dgvscroll.Rows.RemoveAt(dgvscroll.CurrentRow.Index)
    End Sub

    Private Sub copytsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Sub copyscroll()
        tempRow = dgvscroll.CurrentRow
    End Sub

    Sub insertcopiedscroll()
        On Error Resume Next
        Dim curRow As Integer = dgvscroll.CurrentCell.RowIndex
        dgvscroll.Rows.Insert(dgvscroll.CurrentRow.Index)
        dgvscroll.CurrentCell = dgvscroll.Rows(curRow).Cells(0)
        dgvscroll.Item(0, curRow).Value = tempRow.Cells(0).Value
        dgvscroll.Item(1, curRow).Value = tempRow.Cells(1).Value
    End Sub

    Private Sub cmduptsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmduptsscroll.Click
        clipmoveupscroll()
    End Sub

    Sub clipmoveupscroll()
        On Error Resume Next
        If dgvscroll.CurrentCell.RowIndex <> 0 Then
            MoveCurrentRow(-1)
        End If
    End Sub

    Private Sub cmddowntsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddowntsscroll.Click
        On Error Resume Next
        clipmovedownscroll()
    End Sub

    Sub clipmovedownscroll()
        On Error Resume Next
        If dgvscroll.CurrentCell.RowIndex <> dgvscroll.Rows.Count - 2 Then
            MoveCurrentRow(1)
        End If
    End Sub

    Private Sub cmdinserttsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinserttsscroll.Click
        On Error Resume Next
        clipinsertscroll()
    End Sub

    Sub clipinsertscroll()
        On Error Resume Next
        dgvscroll.Rows.Insert(dgvscroll.CurrentRow.Index)
        dgvscroll.Rows(dgvscroll.CurrentRow.Index - 1).Cells(3).Value = 1
    End Sub

    Private Sub cmddeletetsscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddeletetsscroll.Click
        On Error Resume Next
        deleteclipscroll()
    End Sub

    Private Sub nspeedscroll_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nspeedscroll.ValueChanged
        On Error Resume Next
        If nspeedscroll.Value <> 0 Then
            tempspeed = nspeedscroll.Value
        End If

        UpdateScrollData("speed", nspeedscroll.Value)
    End Sub

    Private Sub picscrollbullet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picscrollbullet.Click
        On Error Resume Next

        Dim aa As New OpenFileDialog
        If aa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            picscrollbullet.ImageLocation = aa.FileName
        End If
    End Sub

    Private Sub cmdplayscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplayscroll.Click
        On Error Resume Next

        nspeedscroll.Value = tempspeed
        setdataofscroll()
        CasparCGDataCollection.SetData("speed", nspeedscroll.Value)
        CasparCGDataCollection.SetData("division", ndivision.Value)
        CasparCGDataCollection.SetData("bordercolor", ColorToCasparHex(cmdbordercolor.BackColor))
        CasparCGDataCollection.SetData("stripcolor", ColorToCasparHex(cmdstripcolor.BackColor))
        CasparCGDataCollection.SetData("fontcolor", ColorToCasparHex(cmdstripcolor.ForeColor))

        If chkCapitalise.Checked Then
            CasparCGDataCollection.SetData("scrolldatacapitalised", "")
        End If

        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayerscroll.Text), Int(cmblayerscroll.Text), txtScrollTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
        tmrshowdatascroll.Enabled = True
        paused = False

        UpdateScrollData("fontcolor1", ColorToCasparHex(cmdstripcolor.ForeColor))
    End Sub

    Private Sub cmdpausescroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpausescroll.Click
        On Error Resume Next

        If paused = False Then
            If nspeedscroll.Value <> 0 Then
                tempspeed = nspeedscroll.Value
            End If
            nspeedscroll.Value = 0
            paused = True
        Else
            nspeedscroll.Value = tempspeed
            UpdateScrollData("speed", nspeedscroll.Value)
            paused = False
        End If
    End Sub

    Private Sub cmdresumescroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub cmdselectallforscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectallforscroll.Click
        On Error Resume Next
        SetAllRowSelectionValues(1)
    End Sub

    Private Sub cmddeselectallforscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddeselectallforscroll.Click
        On Error Resume Next
        SetAllRowSelectionValues(0)
    End Sub

    Sub setdataofscroll()
        On Error Resume Next

        CasparCGDataCollection.Clear()

        Dim ff As Integer = 0
        For jscroll = 0 To dgvscroll.Rows.Count - 1
            If RowIsSelected(jscroll) AndAlso RowHasContent(jscroll) Then
                CasparCGDataCollection.SetData("scrolldata" & ff, CleanScrollText(dgvscroll.Rows(jscroll).Cells(0).Value) & txtdelemeterforscroll.Text)
                ff += 1
            End If
        Next

        CasparCGDataCollection.SetData("n", ff)
        CasparCGDataCollection.SetData("loader1", picscrollbullet.ImageLocation)
    End Sub

    Private Sub cmdstopscroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopscroll.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayerscroll.Text), Int(cmblayerscroll.Text))
        tmrshowdatascroll.Enabled = False
    End Sub

    Private Sub tmrshowdatascroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrshowdatascroll.Tick
        On Error Resume Next
        updatedatascroll()
    End Sub

    Sub updatedatascroll()
        setdataofscroll()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmblayerscroll.Text), Int(cmblayerscroll.Text), CasparCGDataCollection)
    End Sub

    Private Sub ucScroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialisescrolldata()
        tempspeed = nspeedscroll.Value
    End Sub

    Sub initialisescrolldata()
        On Error Resume Next
        LoadScrollRows(DefaultScrollFile, False)
        dgvscroll.Columns(0).HeaderText = DefaultScrollFile
    End Sub

    Private Sub cmdhidegbscrollandclock_Click(sender As Object, e As EventArgs) Handles cmdhidegbscrollandclock.Click
        Me.Hide()
    End Sub

    Private Sub chkCapitalise_CheckedChanged(sender As Object, e As EventArgs) Handles chkCapitalise.CheckedChanged
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        newdgvscroll()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        openfilescroll()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        savefilescroll()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        On Error Resume Next
        deleteclipscroll()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        copyscroll()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        insertcopiedscroll()
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        On Error Resume Next
        saveasfilescroll()
    End Sub

    Private Sub InsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.Click
        insertfilescroll()
    End Sub

    Private Sub Dgvscroll_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvscroll.CellContentClick
    End Sub

    Private Sub dgvscroll_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvscroll.DataError
        'dont delete it
    End Sub

    Private Sub cmdstripcolor_Click(sender As Object, e As EventArgs) Handles cmdstripcolor.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdstripcolor.BackColor = cd1.Color
            cmdcolor.BackColor = cd1.Color
            UpdateScrollData("stripcolor", ColorToCasparHex(cmdstripcolor.BackColor))
        End If
    End Sub

    Private Sub cmdcolor_Click(sender As Object, e As EventArgs) Handles cmdcolor.Click
        On Error Resume Next
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdcolor.ForeColor = cd1.Color
            cmdstripcolor.ForeColor = cd1.Color
            UpdateScrollData("fontcolor1", ColorToCasparHex(cmdstripcolor.ForeColor))
        End If
    End Sub

    Private Sub cmdbordercolor_Click(sender As Object, e As EventArgs) Handles cmdbordercolor.Click
        If cd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmdbordercolor.BackColor = cd1.Color
            UpdateScrollData("bordercolor", ColorToCasparHex(cd1.Color))
        End If
    End Sub

    Private Sub dgvscroll_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvscroll.RowsAdded
        updaterownumber()
    End Sub

    Private Sub dgvscroll_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvscroll.RowsRemoved
        updaterownumber()
    End Sub

    Sub updaterownumber()
        On Error Resume Next
        For irownumberupdate = 0 To dgvscroll.Rows.Count - 1
            dgvscroll.Rows(irownumberupdate).HeaderCell.Value = irownumberupdate.ToString()
        Next
    End Sub

    Private Function PromptForScrollFile(forSave As Boolean) As String
        If forSave Then
            osd2.InitialDirectory = ScrollDirectory
            osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            osd2.FileName = ""
            If osd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return osd2.FileName
            End If
        Else
            Dim ofd2 As New OpenFileDialog
            ofd2.InitialDirectory = ScrollDirectory
            ofd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return ofd2.FileName
            End If
        End If

        Return String.Empty
    End Function

    Private Sub LoadScrollRows(fileName As String, insertAtCurrentRow As Boolean)
        Using sr As New StreamReader(fileName)
            If Not insertAtCurrentRow Then
                dgvscroll.Rows.Clear()
            End If

            Dim rowIndex As Integer = If(insertAtCurrentRow AndAlso dgvscroll.CurrentRow IsNot Nothing, dgvscroll.CurrentRow.Index, 0)
            Dim currentLine As String

            Do Until sr.EndOfStream = True
                currentLine = sr.ReadLine()
                Dim xyz As Array = Split(currentLine, Chr(2))

                If insertAtCurrentRow Then
                    dgvscroll.Rows.Insert(rowIndex)
                Else
                    dgvscroll.Rows.Add()
                End If

                dgvscroll.Rows(rowIndex).Cells(0).Value = CleanScrollText(xyz(0))
                dgvscroll.Rows(rowIndex).Cells(1).Value = xyz(1)
                rowIndex += 1
            Loop
        End Using
    End Sub

    Private Sub SaveScrollRows(fileName As String)
        Using sw As New StreamWriter(fileName)
            If dgvscroll.Rows.Count = 0 Then
                sw.Write("")
                Exit Sub
            End If

            For rowIndex As Integer = 0 To dgvscroll.Rows.Count - 1
                NormalizeSelectionCell(rowIndex)
                sw.WriteLine(CleanScrollText(dgvscroll.Rows(rowIndex).Cells(0).Value) & Chr(2) & dgvscroll.Rows(rowIndex).Cells(1).Value)
            Next
        End Using
    End Sub

    Private Sub MoveCurrentRow(direction As Integer)
        Dim curRow As Integer = dgvscroll.CurrentCell.RowIndex
        Dim myRow As DataGridViewRow = dgvscroll.CurrentRow
        dgvscroll.Rows.Remove(myRow)
        dgvscroll.Rows.Insert(curRow + direction, myRow)
        dgvscroll.CurrentCell = dgvscroll.Rows(curRow + direction).Cells(0)
    End Sub

    Private Sub SetAllRowSelectionValues(value As Integer)
        For rowIndex As Integer = 0 To dgvscroll.RowCount - 1
            dgvscroll.Rows(rowIndex).Cells(1).Value = value
        Next
    End Sub

    Private Function RowIsSelected(rowIndex As Integer) As Boolean
        Return dgvscroll.Rows(rowIndex).Cells(1).Value = 1
    End Function

    Private Function RowHasContent(rowIndex As Integer) As Boolean
        Return dgvscroll.Rows(rowIndex).Cells(0).Value <> ""
    End Function

    Private Sub NormalizeSelectionCell(rowIndex As Integer)
        If dgvscroll.Rows(rowIndex).Cells(1).Value = False Then
            dgvscroll.Rows(rowIndex).Cells(1).Value = "0"
        End If
    End Sub

    Private Function CleanScrollText(value As Object) As String
        Return Replace(Replace(CStr(value), Chr(2), " "), vbNewLine, "")
    End Function

    Private Function ColorToCasparHex(colorValue As Color) As String
        Return "0x" & String.Format("{0:X2}{1:X2}{2:X2}", colorValue.R, colorValue.G, colorValue.B)
    End Function

    Private Sub UpdateScrollData(key As String, value As Object)
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData(key, value)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmblayerscroll.Text), Int(cmblayerscroll.Text), CasparCGDataCollection)
    End Sub
End Class
