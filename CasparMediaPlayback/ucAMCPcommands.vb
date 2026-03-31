Imports System.IO

Public Class ucAMCPcommands
    Private Const AmcpFolderPath As String = "c:\casparcg\mydata\amcp\"

    Private Sub ResetAmcpCommand()
        txtanyamcpcommand.Text = ""
        lblfilenameamcp.Text = "New"
    End Sub

    Private Function ShowAmcpOpenDialog() As String
        Dim openDialog As New OpenFileDialog
        openDialog.InitialDirectory = AmcpFolderPath
        openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

        If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso openDialog.FileName <> "" Then
            Return openDialog.FileName
        End If

        Return ""
    End Function

    Private Function ShowAmcpSaveDialog() As String
        Dim saveDialog As New SaveFileDialog
        saveDialog.InitialDirectory = AmcpFolderPath
        saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveDialog.FileName = ""

        If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso saveDialog.FileName <> "" Then
            Return saveDialog.FileName
        End If

        Return ""
    End Function

    Private Sub LoadAmcpFile(fileName As String)
        Dim fileInfo As New FileInfo(fileName)
        ReadTextFile(fileInfo.FullName, txtanyamcpcommand)
        lblfilenameamcp.Text = fileInfo.FullName
    End Sub

    Private Sub SaveAmcpFile(fileName As String)
        Dim fileInfo As New FileInfo(fileName)
        Using writer As New StreamWriter(fileInfo.FullName)
            writer.Write(txtanyamcpcommand.Text)
        End Using
        lblfilenameamcp.Text = fileInfo.FullName
    End Sub

    Private Sub SendAmcpCommand(commandText As String)
        SendString(NetStream, commandText & vbCrLf)
        getresponse()
    End Sub

    Private Sub newtsamcp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        ResetAmcpCommand()
    End Sub

    Private Sub opentsamcp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        openfileamcp()
    End Sub

    Sub openfileamcp()
        On Error Resume Next
        Dim fileName = ShowAmcpOpenDialog()
        If fileName <> "" Then
            LoadAmcpFile(fileName)
        End If
    End Sub

    Private Sub savetsamcp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        savefileamcp()
    End Sub

    Sub savefileamcp()
        On Error Resume Next
        Dim fileName = ShowAmcpSaveDialog()
        If fileName <> "" Then
            SaveAmcpFile(fileName)
        End If
    End Sub

    Private Sub cmdMiscellaneous_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMiscellaneous.Click
        On Error Resume Next
        SendAmcpCommand(cmbMiscellaneous.Text)
    End Sub

    Private Sub cmdanyamcpcommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanyamcpcommand.Click
        On Error Resume Next
        SendAmcpCommand(txtanyamcpcommand.Text)
    End Sub

    Sub getresponse()
        On Error Resume Next
        Threading.Thread.Sleep(250)
        Dim data(10024) As Byte
        NetStream.Read(data, 0, 10024)
        Dim returndata As String = ""
        returndata = System.Text.Encoding.UTF8.GetString(data)
        txtresponse.Text = returndata
    End Sub

    Private Sub ucAMCPcommands_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        ResetAmcpCommand()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        openfileamcp()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        savefileamcp()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub
End Class
