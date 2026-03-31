Imports Facebook
Imports System.ComponentModel
Public Class ucFaceBook
    Private Const FacebookTemplatePath As String = "CMP/facebook/facebook"
    Private Const FacebookPictureUrlFormat As String = "https://graph.facebook.com/{0}/picture?type=square&width=75&height=75"
    Private Const FacebookKeyFilePath As String = "d:/key.txt"

    Private Function GetFacebookLayer() As Integer
        Return Int(cmblayerfacebook.Text)
    End Function

    Private Function BuildFacebookPictureUrl(facebookId As String) As String
        Return String.Format(FacebookPictureUrlFormat, facebookId)
    End Function

    Private Sub PlayFacebookTemplate(loaderUrl As String, displayName As String, messageText As String)
        CasparCGDataCollection.Clear()
        CasparCGDataCollection.SetData("loader1", loaderUrl)
        CasparCGDataCollection.SetData("f0", displayName)
        CasparCGDataCollection.SetData("f1", messageText)
        CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Add(GetFacebookLayer(), GetFacebookLayer(), FacebookTemplatePath, True, CasparCGDataCollection.ToAMCPEscapedXml)
    End Sub

    Private Sub RunFacebookTemplateAction(action As Action(Of Integer, Integer))
        action(GetFacebookLayer(), GetFacebookLayer())
    End Sub

    Private Function BuildFacebookGraphQuery() As String
        Return txtgraphfacebook.Text & txtquery.Text & "&access_token=" & txtaccesstoken.Text
    End Function

    Private Sub ResetFacebookGrid()
        dgvfacebook.Rows.Clear()
        dgvfacebook.RowTemplate.Height = 75
    End Sub

    Private Sub AddFacebookRow(rowIndex As Integer, picture As Image, displayName As String, messageText As String, pictureUrl As String)
        dgvfacebook.Rows.Add()
        dgvfacebook.Rows(rowIndex).Cells(0).Value = picture
        dgvfacebook.Rows(rowIndex).Cells(1).Value = displayName
        dgvfacebook.Rows(rowIndex).Cells(2).Value = messageText
        dgvfacebook.Rows(rowIndex).Cells(3).Value = pictureUrl
    End Sub

    Private Function ReadFacebookProfileImage(pictureUrl As String) As Image
        Using response = System.Net.HttpWebRequest.Create(pictureUrl).GetResponse(),
              responseStream = response.GetResponseStream()
            Return Image.FromStream(responseStream)
        End Using
    End Function

    Private Sub LoadFacebookAccessTokenFromKeyFile()
        Using sr As New IO.StreamReader(FacebookKeyFilePath)
            Dim lineIndex As Integer = 0
            Do Until sr.EndOfStream = True
                Dim line = sr.ReadLine()
                Dim values As Array = Split(line, ",")

                If lineIndex = 4 AndAlso values.Length > 1 Then
                    txtaccesstoken.Text = values(1)
                    Exit Do
                End If
                lineIndex += 1
            Loop
        End Using
    End Sub

    Private Sub cmdsearchqueryfacebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsearchqueryfacebook.Click
        On Error Resume Next
        bwfacebook.RunWorkerAsync()
    End Sub
    Private Sub cmdplayfacebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdplayfacebook.Click
        On Error Resume Next
        PlayFacebookTemplate(dgvfacebook.CurrentRow.Cells(3).Value, dgvfacebook.CurrentRow.Cells(1).Value, dgvfacebook.CurrentRow.Cells(2).Value)
    End Sub
    Private Sub cmdnextstepfacebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnextstepfacebook.Click
        On Error Resume Next
        RunFacebookTemplateAction(Sub(layer, flashLayer) CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Next(layer, flashLayer))
    End Sub
    Private Sub cmdstopfacebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdstopfacebook.Click
        On Error Resume Next
        RunFacebookTemplateAction(Sub(layer, flashLayer) CasparDevice.Channels(g_int_ChannelNumber - 1).CG.Stop(layer, flashLayer))
    End Sub
    Private Sub bwfacebook_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwfacebook.DoWork
        On Error Resume Next
        Control.CheckForIllegalCrossThreadCalls = False
        ResetFacebookGrid()

        Dim fbc As New FacebookClient
        Dim result = fbc.Get(BuildFacebookGraphQuery())
        Threading.Thread.Sleep(2000)

        Dim rowIndex As Integer = 0
        pbfacebook.Maximum = result.data.count
        For Each fdata In result.data
            Dim pictureUrl = BuildFacebookPictureUrl(fdata.from.id)
            AddFacebookRow(rowIndex, ReadFacebookProfileImage(pictureUrl), fdata.from.name, fdata.message, pictureUrl)
            rowIndex += 1
            pbfacebook.Value = rowIndex
        Next
    End Sub

    Private Sub bwfacebook_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwfacebook.RunWorkerCompleted
        On Error Resume Next
        dgvfacebook.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub cmdhidegbfacebook_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub
    Private Sub cmdreadkeyforfacebook_Click(sender As Object, e As EventArgs) Handles cmdreadkeyforfacebook.Click
        On Error Resume Next
        LoadFacebookAccessTokenFromKeyFile()
    End Sub
    Private Sub ucFaceBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
