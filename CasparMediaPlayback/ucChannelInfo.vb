Imports System.Xml
Public Class ucChannelInfo
    Private Function ReadChannelInfoDocument() As XmlDocument
        Dim command = "info " & g_int_ChannelNumber
        SendString(NetStream, command & vbCrLf)

        Threading.Thread.Sleep(100)

        Dim data(10024) As Byte
        NetStream.Read(data, 0, 10024)

        Dim xmlString As String = System.Text.Encoding.UTF8.GetString(data)
        xmlString = xmlString.Substring(xmlString.IndexOf("<"))

        Dim document As New XmlDocument()
        document.LoadXml(xmlString)
        Return document
    End Function

    Private Function GetNodeText(node As XmlNode, xPath As String, Optional fallback As String = "") As String
        Dim selectedNode = node.SelectSingleNode(xPath)
        If selectedNode Is Nothing Then
            Return fallback
        End If

        Return selectedNode.InnerText
    End Function

    Private Function EnsureChannelInfoTypeName(baseName As String, suffix As String) As String
        If baseName.Contains(suffix) Then
            Return baseName
        End If

        Return baseName & suffix
    End Function

    Private Sub AddChannelInfoRow(rowIndex As Integer, itemType As String, itemValue As String)
        dgvchannelinfo.Rows.Add()
        dgvchannelinfo.Rows(rowIndex).Cells(1).Value = itemType
        dgvchannelinfo.Rows(rowIndex).Cells(2).Value = itemValue
    End Sub

    Private Sub ApplyNodeIndexes(nodeList As XmlNodeList, startRowIndex As Integer, indexSelector As Func(Of XmlNode, String))
        Dim rowIndex = startRowIndex
        For Each node As XmlNode In nodeList
            dgvchannelinfo.Rows(rowIndex).Cells(0).Value = indexSelector(node)
            rowIndex += 1
        Next
    End Sub

    Private Sub LoadChannelInfo20(document As XmlDocument)
        Dim rowIndex As Integer = 0

        For Each node As XmlNode In document.SelectNodes("/channel/stage/layers/layer/foreground/producer")
            AddChannelInfoRow(rowIndex, EnsureChannelInfoTypeName(node.ChildNodes.Item(0).InnerText, "-producer"), node.ChildNodes.Item(1).InnerText)
            rowIndex += 1
        Next

        For Each node As XmlNode In document.SelectNodes("/channel/output/consumers/consumer")
            Dim consumerType = EnsureChannelInfoTypeName(node.ChildNodes.Item(0).InnerText, "-consumer")
            Dim consumerValue = If(node.ChildNodes.Item(0).InnerText.Contains("-consumer"), GetNodeText(node, "device"), GetNodeText(node, "filename"))
            AddChannelInfoRow(rowIndex, consumerType, consumerValue)
            rowIndex += 1
        Next

        ApplyNodeIndexes(document.SelectNodes("/channel/stage/layers/layer/index"), 0, Function(node) node.InnerText)
        ApplyNodeIndexes(document.SelectNodes("/channel/output/consumers/consumer/index"), rowIndex - document.SelectNodes("/channel/output/consumers/consumer/index").Count, Function(node) node.InnerText)
    End Sub

    Private Sub LoadChannelInfo21(document As XmlDocument)
        Dim rowIndex As Integer = 0

        For Each node As XmlNode In document.SelectNodes("/channel/stage/layers/layer/foreground/producer")
            AddChannelInfoRow(rowIndex, EnsureChannelInfoTypeName(node.ChildNodes.Item(0).InnerText, "-producer"), node.ChildNodes.Item(1).InnerText)
            rowIndex += 1
        Next

        For Each node As XmlNode In document.SelectNodes("/channel/output/consumers/consumer")
            Dim consumerName = node.ChildNodes.Item(0).InnerText
            Dim consumerType = EnsureChannelInfoTypeName(consumerName, "-consumer")
            Dim consumerValue = If(consumerName.Contains("decklink"), GetNodeText(node, "device"), GetNodeText(node, "path"))
            AddChannelInfoRow(rowIndex, consumerType, consumerValue)
            rowIndex += 1
        Next

        ApplyNodeIndexes(document.SelectNodes("/channel/stage/layers/layer/index"), 0, Function(node) node.InnerText)
        ApplyNodeIndexes(document.SelectNodes("/channel/output/consumers/consumer/index"), rowIndex - document.SelectNodes("/channel/output/consumers/consumer/index").Count, Function(node) node.InnerText)
    End Sub

    Private Sub LoadChannelInfo23(document As XmlDocument)
        Dim rowIndex As Integer = 0

        For Each node As XmlNode In document.SelectNodes("/channel/stage/layer/*/foreground")
            AddChannelInfoRow(rowIndex, EnsureChannelInfoTypeName(GetNodeText(node, "producer"), "-producer"), GetNodeText(node, "file/path"))
            rowIndex += 1
        Next

        For Each node As XmlNode In document.SelectNodes("/channel/output/port/*")
            Dim consumerPath = GetNodeText(node, "file/path")
            Dim childNodeName = node.ChildNodes(0).Name
            Dim consumerType = If(consumerPath.Contains("://"), "streaming-consumer", EnsureChannelInfoTypeName(childNodeName, "-consumer"))
            AddChannelInfoRow(rowIndex, consumerType, consumerPath)
            rowIndex += 1
        Next

        ApplyNodeIndexes(document.SelectNodes("/channel/stage/layer/*"), 0, Function(node) Split(node.Name, "_")(1))
        ApplyNodeIndexes(document.SelectNodes("/channel/output/port/*"), rowIndex - document.SelectNodes("/channel/output/port/*").Count, Function(node) Split(node.Name, "_")(1))
    End Sub

    Private Sub RemoveSelectedChannelInfoRow()
        With dgvchannelinfo
            Dim typeParts = Split(.CurrentRow.Cells(1).Value, "-")
            Dim commandName = "remove"
            If typeParts.Count > 1 AndAlso typeParts(1) = "producer" Then
                commandName = "stop"
            End If

            CasparDevice.SendString(commandName & " " & g_int_ChannelNumber & "-" & .CurrentRow.Cells(0).Value)
        End With
    End Sub

    Private Sub cmdgetchannelinfo_Click(sender As Object, e As EventArgs) Handles cmdgetchannelinfo.Click
        getchannelinfo()
    End Sub
    Sub getchannelinfo()
        On Error Resume Next
        dgvchannelinfo.Rows.Clear()

        Dim document = ReadChannelInfoDocument()

        Select Case ServerVersion
            Case 2.0
                LoadChannelInfo20(document)
            Case 2.1
                LoadChannelInfo21(document)
            Case 2.2, 2.3
                LoadChannelInfo23(document)
        End Select
    End Sub

    Private Sub cmdhidegbchannelinfo_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ucChannelInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub dgvchannelinfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvchannelinfo.CellContentClick
        On Error Resume Next
        If e.ColumnIndex = 3 Then
            RemoveSelectedChannelInfoRow()
            getchannelinfo()
        End If
    End Sub
End Class
