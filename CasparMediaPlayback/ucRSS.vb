'for rss
Imports System.Data.DataSet
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Net
'for rss ends
Public Class ucRssFeed
    Dim ibreakingnews As Integer
    Dim jbreakingnews As Integer
    Dim kbreakingnews As Integer

    'Dim ar1() As String
    Dim ar2() As String
    'Dim ar3() As String
    Dim ar4() As String
    'Dim ar5() As String
    Dim ar6() As String

    Dim tempspeed = 2
    Dim paused As Boolean = False
    Private Sub PrepareRssGrid()
        dgvrss.Rows.Clear()
        dgvrss.Columns.Clear()
    End Sub

    Private Sub EnsureManualRssColumns()
        If dgvrss.Columns.Count < 2 Then
            dgvrss.Columns.Add("title", "title")
            dgvrss.Columns.Add("description", "description")
            Dim chkBox As New DataGridViewCheckBoxColumn(False)
            dgvrss.Columns.Insert(0, chkBox)
            dgvrss.Columns(0).Width = 40
            dgvrss.Columns(1).Width = 500
            dgvrss.Rows.Add(1)
        End If
    End Sub

    Private Sub SetAllRssSelections(isSelected As Boolean)
        For irss = 0 To dgvrss.Rows.Count - 1
            dgvrss.Rows(irss).Cells(0).Value = isSelected
        Next
    End Sub

    Private Function GetSelectedRssText() As String
        Dim output As String = ""

        For jrss = 0 To dgvrss.RowCount - 1
            If dgvrss.Rows(jrss).Cells(0).Value = vbTrue Then
                If chkrsstitle.Checked = True Then
                    output &= Replace(dgvrss.Rows(jrss).Cells("title").Value, vbLf, vbNullString) & txtrssdelemeter.Text
                End If
                If chkrssdescription.Checked = True Then
                    output &= Replace(dgvrss.Rows(jrss).Cells("description").Value, vbLf, vbNullString) & txtrssdelemeter.Text
                End If
            End If
        Next

        Return output
    End Function

    Private Sub UpdateRssTemplateData()
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("speed", nrssspeed.Value)
        CasparCGDataCollection.SetData("scrolldata", GetSelectedRssText())
    End Sub

    Private Function LoadRssDataSet(feedAddress As String) As DataSet
        Dim feedXml As String
        Dim rssDataSet As New DataSet()

        Using client As New WebClient()
            client.Encoding = System.Text.Encoding.UTF8
            client.Headers(HttpRequestHeader.UserAgent) = "Mozilla/5.0 CMP RSS Reader"
            feedXml = client.DownloadString(feedAddress.Trim())
        End Using

        Using reader As New StringReader(feedXml)
            rssDataSet.ReadXml(reader, XmlReadMode.Auto)
        End Using

        Return rssDataSet
    End Function

    Private Function GetPreferredRssTable(rssDataSet As DataSet) As DataTable
        If rssDataSet Is Nothing OrElse rssDataSet.Tables.Count = 0 Then
            Return Nothing
        End If

        If rssDataSet.Tables.Contains("item") Then
            Return rssDataSet.Tables("item")
        End If

        Dim requestedIndex As Integer = CInt(nrsstable.Value)
        If requestedIndex >= 0 AndAlso requestedIndex < rssDataSet.Tables.Count Then
            Return rssDataSet.Tables(requestedIndex)
        End If

        For Each table As DataTable In rssDataSet.Tables
            If table.Columns.Contains("title") AndAlso table.Columns.Contains("description") Then
                Return table
            End If
        Next

        Return rssDataSet.Tables(0)
    End Function
    Private Sub cmdhidegbrssfeed_Click(sender As Object, e As EventArgs) 
        Me.Hide()
    End Sub
    Private Sub cmdrssmanuallyadd_Click(sender As Object, e As EventArgs) Handles cmdrssmanuallyadd.Click
        On Error Resume Next
        PrepareRssGrid()
        EnsureManualRssColumns()

    End Sub

    Private Sub cmdrssread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrssread.Click
        On Error Resume Next
        readrssdata()
    End Sub
    Sub readrssdata()
        On Error Resume Next
        PrepareRssGrid()

        If Me.txtrssaddress.Text.Trim <> vbNullString Then
            Using objDataset As DataSet = LoadRssDataSet(Me.txtrssaddress.Text.Trim)
                Dim preferredTable As DataTable = GetPreferredRssTable(objDataset)

                If preferredTable IsNot Nothing Then
                    dgvrss.DataSource = preferredTable
                Else
                    dgvrss.DataSource = Nothing
                End If
            End Using
        End If
        Dim chkBox As New DataGridViewCheckBoxColumn(False)

        dgvrss.Columns.Insert(0, chkBox)

        SetAllRssSelections(True)
        dgvrss.Columns(0).Width = 25
        dgvrss.Columns(1).Width = 500
    End Sub

    Private Sub cmdselectallrssfeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectallrssfeed.Click
        On Error Resume Next
        SetAllRssSelections(True)
    End Sub

    Private Sub cmddeselectallrssfedd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddeselectallrssfedd.Click
        On Error Resume Next
        SetAllRssSelections(False)
    End Sub
    Private Sub cmdrssplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrssplay.Click
        On Error Resume Next
        setdataofrss()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), txtRSSTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
        tmrshowdatarss.Interval = txtrsstimerinterval.Text
        tmrshowdatarss.Enabled = True

    End Sub
    Private Sub dgvrss_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvrss.DataError
        ' dummy code 
    End Sub
    Sub setdataofrss()
        UpdateRssTemplateData()
    End Sub



    Sub updatedatarss()
        On Error Resume Next
        setdataofrss()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), CasparCGDataCollection)

    End Sub

    Private Sub cmdrsspause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrsspause.Click
        On Error Resume Next
        If paused = False Then
            tempspeed = nrssspeed.Value
            nrssspeed.Value = 0
            paused = True
        Else
            nrssspeed.Value = tempspeed
            paused = False
        End If

    End Sub

    Private Sub cmdrssresume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next


    End Sub

    Private Sub cmdrssstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrssstop.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text))
        tmrshowdatarss.Enabled = False
    End Sub

    Private Sub nrssspeed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nrssspeed.ValueChanged
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("speed", nrssspeed.Value)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), CasparCGDataCollection)
    End Sub

   
    Private Sub tmrshowdatarss_Tick(sender As Object, e As EventArgs) Handles tmrshowdatarss.Tick
       On Error Resume Next
        If chkautomaticupdaterss.Checked Then updatedatarss()
        If chkautomaticreadrss.Checked Then readrssdata()
    End Sub

    Private Sub cmdplaybreakingnews_Click(sender As Object, e As EventArgs) Handles cmdplaybreakingnews.Click
        On Error Resume Next
        makearray()
        setdataofbreakingnews()
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), txtbnTemplate.Text, True, CasparCGDataCollection.ToAMCPEscapedXml)
        tmrshowdata.Interval = Val(txtbreakingnewsupdateinterval.Text)
        tmrshowdata.Enabled = True
    End Sub
    Sub makearray()
        On Error Resume Next
        ibreakingnews = 0
        jbreakingnews = 0
        kbreakingnews = 0
        Dim ar1(dgvrss.Rows.Count - 1) As String
        Dim ar3(dgvrss.Rows.Count - 1) As String
        Dim ar5(dgvrss.Rows.Count - 1) As String

        For Me.ibreakingnews = 0 To dgvrss.Rows.Count - 1
            If dgvrss.Rows(ibreakingnews).Cells(0).Value = True Then

                ar1(jbreakingnews) = dgvrss.Rows(ibreakingnews).Cells(1).Value
                ar3(jbreakingnews) = dgvrss.Rows(ibreakingnews).Cells(2).Value
                ar5(jbreakingnews) = dgvrss.Rows(ibreakingnews).Cells(3).Value

                jbreakingnews = jbreakingnews + 1
            End If
        Next
        ar2 = ar1
        ar4 = ar3
        ar6 = ar5
    End Sub

    Sub setdataofbreakingnews()
        On Error Resume Next
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("xf0", (ar4(kbreakingnews)))
        CasparCGDataCollection.SetData("xf1", (ar6(kbreakingnews)))
        CasparCGDataCollection.SetData("xf2", (ar2(kbreakingnews)))
    End Sub
    Private Sub gbrss_Enter(sender As Object, e As EventArgs) Handles gbrss.Enter

    End Sub

    Private Sub tmrshowdata_Tick(sender As Object, e As EventArgs) Handles tmrshowdata.Tick
        On Error Resume Next
        If chkautomaticupdaterss.Checked Then updatedatarss()
        If chkautomaticreadrss.Checked Then readrssdata()

        kbreakingnews = kbreakingnews + 1
        If ar2(kbreakingnews) = "" Then
            makearray()
        End If
        updatedata()
    End Sub
    Sub updatedata()
        On Error Resume Next
        setdataofbreakingnews()
        'CasparDevice.Channels(cmbchannel.Text-1).CG.Invoke(Int(cmblayerbreakingnews.Text), Int(cmblayerbreakingnews.Text), "loop")
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Update(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), CasparCGDataCollection)
    End Sub

    Private Sub cmdstopbrekingnews_Click(sender As Object, e As EventArgs) Handles cmdstopbrekingnews.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Invoke(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text), "out")
        Threading.Thread.Sleep(500)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmbrssvideoflashlayer.Text), Int(cmbrssvideoflashlayer.Text))
        tmrshowdata.Enabled = False
    End Sub

    Private Sub cmdshowtime_Click(sender As Object, e As EventArgs) Handles cmdshowtime.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(Int(cmblayertimerss.Text), Int(cmblayertimerss.Text), (txtclockTemplate.Text), True, CasparCGDataCollection.ToAMCPEscapedXml)

    End Sub

    Private Sub cmdhidetime_Click(sender As Object, e As EventArgs) Handles cmdhidetime.Click
        On Error Resume Next
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(Int(cmblayertimerss.Text), Int(cmblayertimerss.Text))

    End Sub

    Private Sub chkautomaticreadrss_CheckedChanged(sender As Object, e As EventArgs) Handles chkautomaticreadrss.CheckedChanged

    End Sub

    Private Sub chkautomaticupdaterss_CheckedChanged(sender As Object, e As EventArgs) Handles chkautomaticupdaterss.CheckedChanged

    End Sub
End Class
