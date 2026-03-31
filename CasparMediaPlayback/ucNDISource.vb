Public Class ucNDISource
    Private Const NdiListCommand As String = "ndi list"
    Private Const NdiResponseBufferSize As Integer = 10024
    Private Const NdiResponseDelayMilliseconds As Integer = 250

    Private Sub CmbNDI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNDI.SelectedIndexChanged
    End Sub

    Sub getresponse()
        On Error Resume Next
        Threading.Thread.Sleep(NdiResponseDelayMilliseconds)

        Dim data(NdiResponseBufferSize) As Byte
        NetStream.Read(data, 0, NdiResponseBufferSize)

        Dim returndata As String = System.Text.Encoding.UTF8.GetString(data)
        PopulateNdiItems(Split(returndata, vbNewLine))
    End Sub

    Private Sub cmbNDI_Click(sender As Object, e As EventArgs) Handles cmbNDI.Click
        SendString(NetStream, NdiListCommand & vbCrLf)
        getresponse()
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        ndi1 = cmbNDI.Text
        CloseParentDialog()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        CloseParentDialog()
    End Sub

    Private Sub UcNDISource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PopulateNdiItems(lines As String())
        cmbNDI.Items.Clear()

        For i As Integer = 1 To lines.Count - 3
            cmbNDI.Items.Add(ParseNdiItem(lines(i)))
        Next
    End Sub

    Private Function ParseNdiItem(line As String) As String
        Return Split(Mid(line, 3), ")")(0) & ")" & """"
    End Function

    Private Sub CloseParentDialog()
        Me.Parent.Dispose()
    End Sub
End Class
