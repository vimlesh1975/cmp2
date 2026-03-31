Imports System.IO
Imports System.Net
Imports Google.Cloud.Translation.V2
Imports Newtonsoft.Json
Public Class ucOneLiner
    Private Const OnelinerDirectory As String = "c:\casparcg\mydata\oneliner\"
    Private Const OnelinerHtmlPath As String = "file:///C:/casparcg/mydata/html/oneliner.html"
    Dim client As TranslationClient

    Dim client1 As New WebClient()

    Sub newdgvoneliner()
        On Error Resume Next
        dgvonelinesuper.Rows.Clear()
        dgvonelinesuper.Rows.Add(7)
        Me.dgvonelinesuper.Columns(0).HeaderText = "new playlist"
    End Sub
    Private Sub opentsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Sub openfileoneliner()
        On Error Resume Next
        ConfigureOnelinerDialog(ofd2)
        If (ofd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Using sr As StreamReader = New StreamReader(ofd2.FileName)
                dgvonelinesuper.Rows.Clear()
                Dim g As Integer = 0
                Dim li As String
                Do Until sr.EndOfStream = True
                    li = sr.ReadLine()
                    dgvonelinesuper.Rows.Add()
                    Dim xyz As Array = Split(li, Chr(2))
                    dgvonelinesuper.Rows(g).Cells(0).Value = xyz(0)

                    g = g + 1
                Loop
                sr.Close()
            End Using
            Me.dgvonelinesuper.Columns(0).HeaderText = ofd2.FileName
        End If
    End Sub

    Private Sub savetsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub savefileoneliner()

        On Error Resume Next

        ConfigureOnelinerDialog(osd2)
        osd2.FileName = ""
        If (osd2.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Using sw As StreamWriter = New StreamWriter(osd2.FileName)
                If dgvonelinesuper.Rows.Count = 0 Then
                    sw.Write("")
                Else

                    Dim f As Integer = 0
                    Do Until f = dgvonelinesuper.Rows.Count

                        sw.WriteLine(dgvonelinesuper.Rows(f).Cells(0).Value & Chr(2))
                        f = f + 1
                    Loop
                End If
                sw.Close()
            End Using
            Me.dgvonelinesuper.Columns(0).HeaderText = osd2.FileName
        End If
    End Sub


    Sub deletecliponeliner()
        On Error Resume Next
        dgvonelinesuper.Rows.RemoveAt(dgvonelinesuper.CurrentRow.Index)
    End Sub

    Private Sub copytsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub copyoneliner()
        On Error Resume Next
        tempRow = Me.dgvonelinesuper.CurrentRow
    End Sub
    Private Sub pasteoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub insertcopiedoneliner()
        On Error Resume Next
        Dim curRow As Integer = Me.dgvonelinesuper.CurrentCell.RowIndex
        dgvonelinesuper.Rows.Insert(dgvonelinesuper.CurrentRow.Index)
        dgvonelinesuper.CurrentCell = dgvonelinesuper.Rows(curRow).Cells(0)
        Me.dgvonelinesuper.Item(0, curRow).Value = tempRow.Cells(0).Value
        Me.dgvonelinesuper.Item(1, curRow).Value = tempRow.Cells(1).Value
    End Sub

    Private Sub uptsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uptsoneliner.Click
        On Error Resume Next
        clipmoveuponeliner()
    End Sub


    Private Sub downtsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downtsoneliner.Click
        On Error Resume Next
        clipmovedownoneliner()
    End Sub
    Sub clipmovedownoneliner()
        On Error Resume Next
        If Me.dgvonelinesuper.CurrentCell.RowIndex <> dgvonelinesuper.Rows.Count - 2 Then
            Dim curRow As Integer = Me.dgvonelinesuper.CurrentCell.RowIndex
            Dim myRow As DataGridViewRow = Me.dgvonelinesuper.CurrentRow
            Me.dgvonelinesuper.Rows.Remove(myRow)
            Me.dgvonelinesuper.Rows.Insert(curRow + 1, myRow)
            dgvonelinesuper.CurrentCell = dgvonelinesuper.Rows(curRow + 1).Cells(0)

        End If
    End Sub

    Private Sub addtsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addtsoneliner.Click
        On Error Resume Next
        clipinsertoneliner()
    End Sub
    Sub clipinsertoneliner()
        On Error Resume Next
        dgvonelinesuper.Rows.Insert(dgvonelinesuper.CurrentRow.Index)

    End Sub

    Private Sub removetsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removetsoneliner.Click
        On Error Resume Next
        deletecliponeliner()
    End Sub


    Sub clipmoveuponeliner()
        On Error Resume Next
        If Me.dgvonelinesuper.CurrentCell.RowIndex <> 0 Then
            Dim curRow As Integer = Me.dgvonelinesuper.CurrentCell.RowIndex
            Dim myRow As DataGridViewRow = Me.dgvonelinesuper.CurrentRow
            Me.dgvonelinesuper.Rows.Remove(myRow)
            Me.dgvonelinesuper.Rows.Insert(curRow - 1, myRow)
            dgvonelinesuper.CurrentCell = dgvonelinesuper.Rows(curRow - 1).Cells(0)
        End If
    End Sub


    Private Sub deletetsoneliner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmdonelinesuperstop_Click(sender As Object, e As EventArgs) Handles cmdonelinesuperstop.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayeronelinesuper.Text), Int(cmblayeronelinesuper.Text))

    End Sub
    Private Sub cmdonelinesupernext_Click(sender As Object, e As EventArgs) Handles cmdonelinesupernext.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Next(Int(cmblayeronelinesuper.Text), Int(cmblayeronelinesuper.Text))

    End Sub
    Private Sub cmdonelinesuperplay_Click(sender As Object, e As EventArgs) Handles cmdonelinesuperplay.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        Dim selectedText As String = GetSelectedOnelinerText(chkPlayFromTraslatedGrigFlash.Checked)
        Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(selectedText)
        CasparCGDataCollection.SetData("base64", System.Convert.ToBase64String(array))
        CasparCGDataCollection.SetData(txtvariable1.Text, selectedText)

        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayeronelinesuper.Text), Int(cmblayeronelinesuper.Text), (cmbTemplateOneliner.Text), True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub


    Private Sub ucOneLiner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialiseonelinerdata()
        enumeratefontsforall()

        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\casparcg\mydata\GoogleTranslate\Quickstart-4d2796c29251.json")
        client = TranslationClient.Create()
        ListLanguageNames()
    End Sub
    Public Function ListLanguageNames() As IList(Of Language)
        cmblanguage.Items.Clear()
        Dim languages As IList(Of Language)
        Try
            languages = client.ListLanguages(target:="en")
            For Each language In languages
                cmblanguage.Items.Add(language.Code & " (" & language.Name & ")")
            Next
            Return languages
        Catch ex As Exception
            'Return ""
        End Try

    End Function


    Sub enumeratefontsforall()
        On Error Resume Next
        Dim InstalledFonts As New Drawing.Text.InstalledFontCollection
        Dim fontfamilies() As FontFamily = InstalledFonts.Families()
        For Each fontFamily As FontFamily In fontfamilies
            cmbfonthtmloneliner.Items.Add(fontFamily.Name)
        Next
    End Sub
    Sub initialiseonelinerdata()
        On Error Resume Next
        dgvonelinesuper.Rows.Add(8)
        dgvonelinesuperTranslated.Rows.Add(8)
        Me.dgvonelinesuper.Item(0, 0).Value = "When nothing is sure, Everything is possible."
        Me.dgvonelinesuper.Item(0, 1).Value = "People lie, Actions don't."
        Me.dgvonelinesuper.Item(0, 2).Value = "Hurt me with the truth but don't comfort me with a lie"
        Me.dgvonelinesuper.Item(0, 3).Value = "When you start believing, it seems to happen."
        Me.dgvonelinesuper.Item(0, 4).Value = "The best apology Is Changed Behavior."
        Me.dgvonelinesuper.Item(0, 5).Value = "our mind knows everything, you learn to ask."
    End Sub

    Private Sub cmdhidegboneliner_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
    Private Sub cmdonelinesuperstophtml_Click(sender As Object, e As EventArgs) Handles cmdonelinesuperstophtml.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & GetOnelinerLayerAddress())

    End Sub

    Function replacestring(str As String) As String
        str = Replace(str, " ", Chr(2))
        str = Replace(str, "\", Chr(5))
        Return str
    End Function
    Private Sub cmdonelinesuperplayhtml_Click(sender As Object, e As EventArgs) Handles cmdonelinesuperplayhtml.Click
        On Error Resume Next

        CasparDevice.SendString("play " & GetOnelinerLayerAddress() & " [HTML] " & """" & OnelinerHtmlPath & """")
        SendOnelinerHtmlData(GetSelectedOnelinerText(chkPlayFromTraslatedGrigHTML.Checked))
        SendOnelinerHtmlCall("stripy('" & nyhtmloneliner.Value & "%')")
        SendOnelinerHtmlCall("Tickery('" & nyhtmltextoneliner.Value & "%')")
        SendOnelinerHtmlCall("fontsize('" & nsizehtmloneliner.Value & "')")
        SendOnelinerHtmlCall("font('" & Replace(cmbfonthtmloneliner.Text, " ", Chr(2)) & "')")
        SendOnelinerHtmlCall("fontitalic('" & If(chkitalic.Checked, "italic", "normal") & "')")
        SendOnelinerHtmlCall("fontbold('" & If(chkBold.Checked, "bold", "normal") & "')")
        SendOnelinerHtmlCall("fontcolor('" & ColorTranslator.ToHtml(cmdstripcolorhtmloneliner.ForeColor) & "')")
        SendOnelinerHtmlCall("stripcolor('" & ColorTranslator.ToHtml(cmdstripcolorhtmloneliner.BackColor) & "')")
        SendOnelinerHtmlCall("stripheight('" & nheighthtmloneliner.Value & "')")

    End Sub

    Private Sub nyhtmloneliner_ValueChanged(sender As Object, e As EventArgs) Handles nyhtmloneliner.ValueChanged
        On Error Resume Next
        SendOnelinerHtmlCall("stripy('" & nyhtmloneliner.Value & "%')")

    End Sub

    Private Sub nyhtmltextoneliner_ValueChanged(sender As Object, e As EventArgs) Handles nyhtmltextoneliner.ValueChanged
        On Error Resume Next
        SendOnelinerHtmlCall("Tickery('" & nyhtmltextoneliner.Value & "%')")

    End Sub

    Private Sub nsizehtmloneliner_ValueChanged(sender As Object, e As EventArgs) Handles nsizehtmloneliner.ValueChanged
        On Error Resume Next
        SendOnelinerHtmlCall("fontsize('" & nsizehtmloneliner.Value & "')")


    End Sub

    Private Sub cmbfonthtmloneliner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfonthtmloneliner.SelectedIndexChanged
        On Error Resume Next
        SendOnelinerHtmlCall("font('" & Replace(cmbfonthtmloneliner.Text, " ", Chr(2)) & "')")

    End Sub

    Private Sub chkitalic_CheckedChanged(sender As Object, e As EventArgs) Handles chkitalic.CheckedChanged
        On Error Resume Next
        SendOnelinerHtmlCall("fontitalic('" & If(chkitalic.Checked, "italic", "normal") & "')")

    End Sub

    Private Sub chkBold_CheckedChanged(sender As Object, e As EventArgs) Handles chkBold.CheckedChanged
        On Error Resume Next
        SendOnelinerHtmlCall("fontbold('" & If(chkBold.Checked, "bold", "normal") & "')")
    End Sub

    Private Sub cmdcolorhtmloneliner_Click(sender As Object, e As EventArgs) Handles cmdcolorhtmloneliner.Click
        On Error Resume Next

        Dim aa As New ColorDialog
        If (aa.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            cmdcolorhtmloneliner.ForeColor = aa.Color
            cmdstripcolorhtmloneliner.ForeColor = aa.Color

            SendOnelinerHtmlCall("fontcolor('" & ColorTranslator.ToHtml(cmdstripcolorhtmloneliner.ForeColor) & "')")
        End If
    End Sub

    Private Sub cmdstripcolorhtmloneliner_Click(sender As Object, e As EventArgs) Handles cmdstripcolorhtmloneliner.Click
        On Error Resume Next

        Dim aa As New ColorDialog
        If (aa.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            cmdcolorhtmloneliner.BackColor = aa.Color
            cmdstripcolorhtmloneliner.BackColor = aa.Color

            SendOnelinerHtmlCall("stripcolor('" & ColorTranslator.ToHtml(cmdstripcolorhtmloneliner.BackColor) & "')")
        End If
    End Sub

    Private Sub nheighthtmloneliner_ValueChanged(sender As Object, e As EventArgs) Handles nheighthtmloneliner.ValueChanged
        On Error Resume Next
        SendOnelinerHtmlCall("stripheight('" & nheighthtmloneliner.Value & "')")

    End Sub

    Private Sub chkbase64htmloneliner_CheckedChanged(sender As Object, e As EventArgs) Handles chkbase64htmloneliner.CheckedChanged
        On Error Resume Next
        SendOnelinerHtmlData(GetSelectedOnelinerText(False))
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        newdgvoneliner()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        openfileoneliner()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        savefileoneliner()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        On Error Resume Next
        deletecliponeliner()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        On Error Resume Next
        copyoneliner()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        insertcopiedoneliner()
    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub

    Private Async Sub cmdTranslate_Click(sender As Object, e As EventArgs) Handles cmdTranslate.Click
        dgvonelinesuperTranslated.Rows.Clear()
        dgvonelinesuperTranslated.Rows.Add(dgvonelinesuper.RowCount)
        Try
            For i = 0 To dgvonelinesuper.RowCount - 1
                dgvonelinesuperTranslated.Rows(i).Cells(0).Value = Await translate(dgvonelinesuper.Rows(i).Cells(0).Value)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Async Function translate(bb As String) As Threading.Tasks.Task(Of String)
        Dim aa As String = (Await client.TranslateTextAsync(bb, Split(cmblanguage.Text, " ")(0))).TranslatedText
        Return aa
    End Function

    Private Sub cmdGetLanguage_Click(sender As Object, e As EventArgs) Handles cmdGetLanguage.Click
        ListLanguageNames()
    End Sub

    Private Async Sub dgvonelinesuper_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvonelinesuper.CellContentClick
        Try
            If dgvonelinesuper.Columns(e.ColumnIndex).Name = "colTranslate" Then
                dgvonelinesuperTranslated.Rows(dgvonelinesuper.CurrentRow.Index).Cells(0).Value = Await translate(dgvonelinesuper.CurrentRow.Cells(0).Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdfittextoneliner_Click(sender As Object, e As EventArgs) Handles cmdfittextoneliner.Click
        On Error Resume Next
        SendOnelinerHtmlCall("fit1()")

    End Sub

    Private Sub cmdRCCPlayer1_Click(sender As Object, e As EventArgs) Handles cmdRCCPlayer1.Click
        On Error Resume Next
        CasparCGDataCollection.Clear()
        If chkPlayFromTraslatedGrigRCC.Checked Then
            CasparCGDataCollection.SetData("f0", dgvonelinesuperTranslated.CurrentRow.Cells(0).Value)
        Else
            CasparCGDataCollection.SetData("f0", dgvonelinesuper.CurrentRow.Cells(0).Value)
        End If
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayeronelinesuper.Text), Int(cmblayeronelinesuper.Text), txtTemplatename.Text, False, CasparCGDataCollection)
        CasparDevice.SendString("call " & (g_int_ChannelNumber) & "-" & Int(cmblayeronelinesuper.Text) & " " & """" & "sheet.sequence.play({ range: [0,0.5] })" & """")

    End Sub


    Private Sub cmdRCCStop1_Click(sender As Object, e As EventArgs) Handles cmdRCCStop1.Click
        On Error Resume Next
        'CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayeronelinesuper.Text), Int(cmblayeronelinesuper.Text))
        CasparDevice.SendString("call " & (g_int_ChannelNumber) & "-" & Int(cmblayeronelinesuper.Text) & " " & """" & "sheet.sequence.play({ direction: 'reverse' })" & """")
    End Sub

    Private Sub ConfigureOnelinerDialog(dialog As FileDialog)
        dialog.InitialDirectory = OnelinerDirectory
        dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
    End Sub

    Private Function GetOnelinerLayerAddress() As String
        Return g_int_ChannelNumber & "-" & Int(cmblayeronelinesuper.Text)
    End Function

    Private Function GetSelectedOnelinerText(useTranslatedGrid As Boolean) As String
        If useTranslatedGrid Then
            Return dgvonelinesuperTranslated.CurrentRow.Cells(0).Value
        End If

        Return dgvonelinesuper.CurrentRow.Cells(0).Value
    End Function

    Private Sub SendOnelinerHtmlCall(commandText As String)
        CasparDevice.SendString("call " & GetOnelinerLayerAddress() & " " & commandText)
    End Sub

    Private Sub SendOnelinerHtmlData(textValue As String)
        If chkbase64htmloneliner.Checked Then
            Dim array() As Byte = System.Text.Encoding.UTF8.GetBytes(replacestring(textValue))
            SendOnelinerHtmlCall("marqueedatabase64('" & System.Convert.ToBase64String(array) & "')")
        Else
            SendOnelinerHtmlCall("marqueedata('" & replacestring1(textValue) & "')")
        End If
    End Sub
End Class
