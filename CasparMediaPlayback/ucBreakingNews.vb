Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient

Public Class ucBreakingNews
    Private Const BreakingNewsDirectory As String = "c:\casparcg\mydata\breakingnews\"
    Private Const DefaultBreakingNewsFile As String = "c:\casparcg\mydata\breakingnews\04.08.17.txt"
    Private Const BreakingNewsHtmlTemplate As String = "c:/casparcg/CMP/BreakingNews/gwd3/gwd_preview_gwd3/index.html"

    Dim ibreakingnews As Integer
    Dim jbreakingnews As Integer
    Dim kbreakingnews As Integer

    Dim ar1() As String
    Dim ar2() As String
    Dim ar3() As String
    Dim ar4() As String
    Dim ar5() As String
    Dim ar6() As String

    Dim flash As Integer
    Dim ff As Integer = 1

    Dim conn
    Dim servertype As String

    Private Sub cmdhidebreakingnews_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub

    Private Sub ucBreakingNews_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ff = 1 Then
            initialisebreakingnewsdata()
            ff = 2
        End If
    End Sub

    Sub initialisebreakingnewsdata()
        On Error Resume Next
        LoadBreakingNewsRows(DefaultBreakingNewsFile, False)
        lblbnfilename.Text = DefaultBreakingNewsFile
    End Sub

    Private Sub cmdplaybreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplaybreakingnews.Click
        On Error Resume Next
        flash = 1
        StartBreakingNewsPlayback()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayerbreakingnews.Text), Int(cmblayerbreakingnews.Text), txtbnTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub cmdbreakingnewsselectall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbreakingnewsselectall.Click
        On Error Resume Next
        SetAllBreakingNewsSelectionValues(1)
    End Sub

    Private Sub cmdbreakingnewssdeelectall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbreakingnewssdeelectall.Click
        On Error Resume Next
        SetAllBreakingNewsSelectionValues(0)
    End Sub

    Sub makearray()
        On Error Resume Next

        ibreakingnews = 0
        jbreakingnews = 0
        kbreakingnews = 0

        Dim localAr1(dgvbreakingnews.Rows.Count - 1) As String
        Dim localAr3(dgvbreakingnews.Rows.Count - 1) As String
        Dim localAr5(dgvbreakingnews.Rows.Count - 1) As String

        For ibreakingnews = 0 To dgvbreakingnews.Rows.Count - 1
            If ShouldIncludeBreakingNewsRow(ibreakingnews) Then
                localAr1(jbreakingnews) = dgvbreakingnews.Rows(ibreakingnews).Cells(0).Value
                localAr3(jbreakingnews) = dgvbreakingnews.Rows(ibreakingnews).Cells(2).Value
                localAr5(jbreakingnews) = dgvbreakingnews.Rows(ibreakingnews).Cells(3).Value
                jbreakingnews += 1
            End If
        Next

        ar2 = localAr1
        ar4 = localAr3
        ar6 = localAr5
    End Sub

    Sub updatedata()
        On Error Resume Next
        setdataofbreakingnews()

        If flash = 1 Then
            CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmblayerbreakingnews.Text), Int(cmblayerbreakingnews.Text), CasparCGDataCollection)
        Else
            SendBreakingNewsHtmlCommand("gwd.actions.timeline.gotoAndPlay('document.body','loop')")
            SendBreakingNewsHtmlCommand("updatestring('" & replacestring1("ccgf0") & "','" & replacestring1(ar2(kbreakingnews)) & "')")
            SendBreakingNewsHtmlCommand("updatestring('" & replacestring1("ccgf1") & "','" & replacestring1(ar4(kbreakingnews)) & "')")
            SendBreakingNewsHtmlCommand("stf('" & replacestring1("ccgf0") & "')")
        End If
    End Sub

    Sub setdataofbreakingnews()
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData(dgvbreakingnews.Columns(2).HeaderText, ar4(kbreakingnews))
        CasparCGDataCollection.SetData(dgvbreakingnews.Columns(3).HeaderText, ar6(kbreakingnews))
        CasparCGDataCollection.SetData(dgvbreakingnews.Columns(0).HeaderText, ar2(kbreakingnews))
    End Sub

    Private Sub cmdstopbrekingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopbrekingnews.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Invoke(Int(cmblayerbreakingnews.Text), Int(cmblayerbreakingnews.Text), "out")
        Threading.Thread.Sleep(500)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayerbreakingnews.Text), Int(cmblayerbreakingnews.Text))
        tmrshowdata.Enabled = False
        CasparDevice.SendString("Stop " & GetBreakingNewsLayerAddress())
    End Sub

    Private Sub tmrshowdata_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrshowdata.Tick
        On Error Resume Next
        kbreakingnews += 1
        If ar2(kbreakingnews) = "" Then
            makearray()
        End If
        updatedata()
    End Sub

    Private Sub newtsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        newdgvbreakingnews()
    End Sub

    Sub newdgvbreakingnews()
        On Error Resume Next
        dgvbreakingnews.Rows.Clear()
        dgvbreakingnews.Rows.Add(7)
        lblbnfilename.Text = "new playlist"
    End Sub

    Private Sub opentsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        openfilebreakingnews()
    End Sub

    Sub openfilebreakingnews()
        On Error Resume Next

        Dim fileName As String = PromptForBreakingNewsFile(False)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        LoadBreakingNewsRows(fileName, False)
        lblbnfilename.Text = fileName
    End Sub

    Sub insertfilebreakingnews()
        Dim fileName As String = PromptForBreakingNewsFile(False)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        LoadBreakingNewsRows(fileName, True)
    End Sub

    Private Sub savetsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        saveasfilebreakingnews()
    End Sub

    Sub saveasfilebreakingnews()
        On Error Resume Next

        Dim fileName As String = PromptForBreakingNewsFile(True)
        If String.IsNullOrWhiteSpace(fileName) Then
            Exit Sub
        End If

        SaveBreakingNewsRows(fileName)
        lblbnfilename.Text = fileName
    End Sub

    Sub savefilebreakingnews()
        On Error Resume Next
        SaveBreakingNewsRows(lblbnfilename.Text)
    End Sub

    Private Sub cuttsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        deleteclipbreakingnews()
    End Sub

    Sub deleteclipbreakingnews()
        On Error Resume Next
        dgvbreakingnews.Rows.RemoveAt(dgvbreakingnews.CurrentRow.Index)
    End Sub

    Private Sub copytsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        copybreakingnews()
    End Sub

    Sub copybreakingnews()
        On Error Resume Next
        tempRow = dgvbreakingnews.CurrentRow
    End Sub

    Private Sub pastetsbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        insertcopiedbreakingnews()
    End Sub

    Sub insertcopiedbreakingnews()
        On Error Resume Next
        Dim curRow As Integer = dgvbreakingnews.CurrentCell.RowIndex
        dgvbreakingnews.Rows.Insert(dgvbreakingnews.CurrentRow.Index)
        dgvbreakingnews.CurrentCell = dgvbreakingnews.Rows(curRow).Cells(0)
        dgvbreakingnews.Item(0, curRow).Value = tempRow.Cells(0).Value
        dgvbreakingnews.Item(1, curRow).Value = tempRow.Cells(1).Value
    End Sub

    Private Sub cmdmovedownbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmovedownbreakingnews.Click
        On Error Resume Next
        clipmovedownbreakingnews()
    End Sub

    Sub clipmovedownbreakingnews()
        On Error Resume Next
        If dgvbreakingnews.CurrentCell.RowIndex <> dgvbreakingnews.Rows.Count - 2 Then
            MoveCurrentBreakingNewsRow(1)
        End If
    End Sub

    Private Sub cmdmoveupbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmoveupbreakingnews.Click
        On Error Resume Next
        clipmoveupbrekingnews()
    End Sub

    Sub clipmoveupbrekingnews()
        On Error Resume Next
        If dgvbreakingnews.CurrentCell.RowIndex <> 0 Then
            MoveCurrentBreakingNewsRow(-1)
        End If
    End Sub

    Private Sub cmdinsertbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinsertbreakingnews.Click
        On Error Resume Next
        clipinsertbreakingnews()
    End Sub

    Sub clipinsertbreakingnews()
        On Error Resume Next
        dgvbreakingnews.Rows.Insert(dgvbreakingnews.CurrentRow.Index)
        dgvbreakingnews.Rows(dgvbreakingnews.CurrentRow.Index - 1).Cells(3).Value = 1
    End Sub

    Private Sub cmddeleteclipbreakingnews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddeleteclipbreakingnews.Click
        On Error Resume Next
        deleteclipbreakingnews()
    End Sub

    Private Sub cmdshowtime_Click(sender As Object, e As EventArgs) Handles cmdshowtime.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayertime.Text), Int(cmblayertime.Text), txtclockTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub cmdhidetime_Click(sender As Object, e As EventArgs) Handles cmdhidetime.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayertime.Text), Int(cmblayertime.Text))
    End Sub

    Private Sub NewToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        newdgvbreakingnews()
    End Sub

    Private Sub OpenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        openfilebreakingnews()
    End Sub

    Private Sub SaveToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        savefilebreakingnews()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        On Error Resume Next
        deleteclipbreakingnews()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        On Error Resume Next
        copybreakingnews()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        On Error Resume Next
        insertcopiedbreakingnews()
    End Sub

    Private Sub cmdPlayHTML_Click(sender As Object, e As EventArgs) Handles cmdPlayHTML.Click
        On Error Resume Next
        flash = 0
        StartBreakingNewsPlayback()
        CasparDevice.SendString("play " & GetBreakingNewsLayerAddress() & " [HTML] " & BreakingNewsHtmlTemplate)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        On Error Resume Next
        saveasfilebreakingnews()
    End Sub

    Private Sub InsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.Click
        insertfilebreakingnews()
    End Sub

    Private Sub Dgvbreakingnews_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvbreakingnews.CellContentClick
    End Sub

    Private Sub dgvbreakingnews_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvbreakingnews.DataError
        'dont delete
    End Sub

    Private Sub txtcurrentstory_TextChanged(sender As Object, e As EventArgs) Handles txtcurrentstory.TextChanged
        On Error Resume Next
        makearray()
    End Sub

    Private Sub tmrsn_Tick(sender As Object, e As EventArgs) Handles tmrsn.Tick
        Try
            conn = New MySqlConnection With {
                .ConnectionString = "server=" & txtservermysql.Text & ";user=" & txtusemysql.Text & ";database=" & txtdatabasemysql.Text & ";port=" & txtport.Text & ";password=" & txtpasswordMysql.Text
            }

            servertype = "MySql"
            Dim adp
            conn.Open()
            adp = New MySqlDataAdapter(txtcommand.Text, CType(conn, MySqlConnection))
            Dim ds As New DataSet()
            adp.Fill(ds)
            txtcurrentstory.Text = ds.Tables(0).Rows(0).Item(0)
            conn.Close()
        Catch ex As Exception
            ' MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub cmdSetServerMySql_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub chkusecurrentstory_CheckedChanged(sender As Object, e As EventArgs) Handles chkusecurrentstory.CheckedChanged
        If chkusecurrentstory.Checked Then
            tmrsn.Enabled = True
        Else
            tmrsn.Enabled = False
        End If
        makearray()
    End Sub

    Private Sub StartBreakingNewsPlayback()
        makearray()
        setdataofbreakingnews()
        tmrshowdata.Interval = Val(txtbreakingnewsupdateinterval.Text)
        tmrshowdata.Enabled = True
    End Sub

    Private Function ShouldIncludeBreakingNewsRow(rowIndex As Integer) As Boolean
        If dgvbreakingnews.Rows(rowIndex).Cells(1).Value <> 1 Then
            Return False
        End If

        If chkusecurrentstory.Checked Then
            Return dgvbreakingnews.Rows(rowIndex).Cells(4).Value = txtcurrentstory.Text
        End If

        Return True
    End Function

    Private Function GetBreakingNewsLayerAddress() As String
        Return g_int_ChannelNumber & "-" & cmblayerbreakingnews.Text
    End Function

    Private Sub SendBreakingNewsHtmlCommand(commandText As String)
        CasparDevice.SendString("call " & GetBreakingNewsLayerAddress() & " " & commandText)
    End Sub

    Private Function PromptForBreakingNewsFile(forSave As Boolean) As String
        If forSave Then
            osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            osd2.InitialDirectory = BreakingNewsDirectory
            osd2.FileName = ""
            If osd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return osd2.FileName
            End If
        Else
            Dim ofd2 As New OpenFileDialog
            ofd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            ofd2.InitialDirectory = BreakingNewsDirectory
            If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return ofd2.FileName
            End If
        End If

        Return String.Empty
    End Function

    Private Sub LoadBreakingNewsRows(fileName As String, insertAtCurrentRow As Boolean)
        Using sr As New StreamReader(fileName)
            If Not insertAtCurrentRow Then
                dgvbreakingnews.Rows.Clear()
            End If

            Dim rowIndex As Integer = If(insertAtCurrentRow AndAlso dgvbreakingnews.CurrentRow IsNot Nothing, dgvbreakingnews.CurrentRow.Index, 0)
            Dim line As String

            Do Until sr.EndOfStream = True
                line = sr.ReadLine()
                Dim xyz As Array = Split(line, Chr(2))

                If insertAtCurrentRow Then
                    dgvbreakingnews.Rows.Insert(rowIndex)
                Else
                    dgvbreakingnews.Rows.Add()
                End If

                dgvbreakingnews.Rows(rowIndex).Cells(0).Value = CleanBreakingNewsText(xyz(0))
                dgvbreakingnews.Rows(rowIndex).Cells(1).Value = xyz(1)
                dgvbreakingnews.Rows(rowIndex).Cells(2).Value = CleanBreakingNewsText(xyz(2))
                dgvbreakingnews.Rows(rowIndex).Cells(3).Value = CleanBreakingNewsText(xyz(3))
                rowIndex += 1
            Loop
        End Using
    End Sub

    Private Sub SaveBreakingNewsRows(fileName As String)
        Using sw As New StreamWriter(fileName)
            If dgvbreakingnews.Rows.Count = 0 Then
                sw.Write("")
                Exit Sub
            End If

            For rowIndex As Integer = 0 To dgvbreakingnews.Rows.Count - 1
                NormalizeBreakingNewsSelection(rowIndex)
                sw.WriteLine(CleanBreakingNewsText(dgvbreakingnews.Rows(rowIndex).Cells(0).Value) & Chr(2) &
                             dgvbreakingnews.Rows(rowIndex).Cells(1).Value & Chr(2) &
                             CleanBreakingNewsText(dgvbreakingnews.Rows(rowIndex).Cells(2).Value) & Chr(2) &
                             CleanBreakingNewsText(dgvbreakingnews.Rows(rowIndex).Cells(3).Value))
            Next
        End Using
    End Sub

    Private Function CleanBreakingNewsText(value As Object) As String
        Return Replace(CStr(value), Chr(2), " ")
    End Function

    Private Sub NormalizeBreakingNewsSelection(rowIndex As Integer)
        If dgvbreakingnews.Rows(rowIndex).Cells(1).Value = False Then
            dgvbreakingnews.Rows(rowIndex).Cells(1).Value = "0"
        End If
    End Sub

    Private Sub SetAllBreakingNewsSelectionValues(value As Integer)
        For rowIndex As Integer = 0 To dgvbreakingnews.RowCount - 1
            dgvbreakingnews.Rows(rowIndex).Cells(1).Value = value
        Next
    End Sub

    Private Sub MoveCurrentBreakingNewsRow(direction As Integer)
        Dim curRow As Integer = dgvbreakingnews.CurrentCell.RowIndex
        Dim myRow As DataGridViewRow = dgvbreakingnews.CurrentRow
        dgvbreakingnews.Rows.Remove(myRow)
        dgvbreakingnews.Rows.Insert(curRow + direction, myRow)
        dgvbreakingnews.CurrentCell = dgvbreakingnews.Rows(curRow + direction).Cells(0)
    End Sub
End Class
