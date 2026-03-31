Imports MasaSam.Forms.Controls
Public Class ucPlayFromAnyWhere
    Dim WithEvents aa As MasaSam.Forms.Controls.FileSystemTree

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        RefreshFileTree()
    End Sub

    Sub addcontrol()
        On Error Resume Next
        aa = New MasaSam.Forms.Controls.FileSystemTree
        aa.Size = New Size(600, 450)
        aa.Location = New Point(10, 100)
        Me.Controls.Add(aa)
        aa.Show()
    End Sub

    Private Sub aa_FileSelected(sender As Object, e As FileInfoEventArgs) Handles aa.FileSelected
        On Error Resume Next
        lblFileName.Text = NormalizeFilePath(aa.GetSelectedFiles(0).FullName)
    End Sub

    Private Sub cmdPlayFromAnywhere_Click(sender As Object, e As EventArgs) Handles cmdPlayFromAnywhere.Click
        On Error Resume Next
        CasparDevice.SendString(BuildTransportCommand("Play", chkloop.Checked))
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        On Error Resume Next
        RefreshFileTree()
    End Sub

    Private Sub cmdCue_Click(sender As Object, e As EventArgs) Handles cmdCue.Click
        On Error Resume Next
        CasparDevice.SendString(BuildTransportCommand("load"))
    End Sub

    Private Sub cmdOpenFromAnyWhere_Click(sender As Object, e As EventArgs) Handles cmdOpenFromAnyWhere.Click
        On Error Resume Next
        Dim aa As New OpenFileDialog
        If aa.ShowDialog() = DialogResult.OK Then
            lblFileName.Text = NormalizeFilePath(aa.FileName)
        End If
    End Sub

    Private Sub cmdfileinfo_Click(sender As Object, e As EventArgs) Handles cmdfileinfo.Click
        On Error Resume Next
        showfileinformation(Replace(lblFileName.Text, "//", "/"))
    End Sub

    Private Sub RefreshFileTree()
        If aa IsNot Nothing Then
            Me.Controls.Remove(aa)
        End If
        addcontrol()
    End Sub

    Private Function BuildTransportCommand(commandName As String, Optional includeLoop As Boolean = False) As String
        Dim commandText As String = commandName & " " & g_int_ChannelNumber & "-" & g_int_PlaylistLayer & " " & """" & lblFileName.Text & """"
        If includeLoop Then
            commandText = commandText & " loop"
        End If

        Return commandText
    End Function

    Private Function NormalizeFilePath(filePath As String) As String
        Return Replace(Replace(filePath, ":", ":\"), "\", "/")
    End Function
End Class
