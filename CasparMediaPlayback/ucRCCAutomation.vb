Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Public Class ucRCCAutomation
    Private Const RccBaseUrl As String = "http://localhost:8080"
    Dim client As New WebClient()

    Private Function GetFlagUrls() As String()
        Return {
            RccBaseUrl & "/img/flag/Afghanistan.png",
            RccBaseUrl & "/img/flag/Albania.png",
            RccBaseUrl & "/img/flag/Belgium.png",
            RccBaseUrl & "/img/flag/Mauritania.png",
            RccBaseUrl & "/img/flag/Morocco.png"
        }
    End Function

    Private Sub LoadFlagRows()
        Dim flagUrls() As String = GetFlagUrls()
        dgv1.RowTemplate.MinimumHeight = 50
        dgv1.Rows.Clear()
        dgv1.Rows.Add(flagUrls.Length)
        For index As Integer = 0 To flagUrls.Length - 1
            dgv1.Rows(index).Cells(0).Value = GetImageFromUrl(flagUrls(index))
            dgv1.Rows(index).Cells(1).Value = flagUrls(index)
        Next
    End Sub

    Private Function BuildRccPayload() As String
        Dim data1 = New rccData With {.key = txtKeyName.Text, .value = dgv1.CurrentRow.Cells(1).Value, .type = "text"}
        Dim data2 = New rccData With {.key = txtKeyImage.Text, .value = dgv1.CurrentRow.Cells(1).Value, .type = "image"}
        Dim allData = {data1, data2}
        Return "layerNumber=" & txtLayerNumber.Text & "&pageName=" & txtPageName.Text & "&data=" & JsonConvert.SerializeObject(allData)
    End Function

    Private Sub UploadRccRequest(endpoint As String, postData As String)
        Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(postData)
        client.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
        client.UploadData(RccBaseUrl & endpoint, data)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        On Error Resume Next
        Process.Start("https://bit.ly/3jRrhDL")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        On Error Resume Next
        Process.Start("https://casparcgforum.org/t/react-caspar-client/4375")

    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ucRCCAutomation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            LoadFlagRows()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click
        Try
            UploadRccRequest("/recallPage", BuildRccPayload())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Try
            UploadRccRequest("/updateData", BuildRccPayload())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdStop_Click_1(sender As Object, e As EventArgs) Handles cmdStop.Click
        Try
            UploadRccRequest("/stopGraphics", "layerNumber=" & txtLayerNumber.Text)
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function GetImageFromUrl(ByVal url As String) As Image
        Dim httpWebRequest As HttpWebRequest = CType(httpWebRequest.Create(url), HttpWebRequest)

        Using httpWebReponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

            Using stream As Stream = httpWebReponse.GetResponseStream()
                Return Image.FromStream(stream)
            End Using
        End Using
    End Function

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        LoadFlagRows()
    End Sub
    Private Class rccData
        Public key As String
        Public value As String
        Public type As String
    End Class
End Class
