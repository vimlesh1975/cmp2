Imports System.IO

Public Class ucUtility
    Private Sub SetUtilityRow(rowIndex As Integer, name As String, value As String)
        dgvutility.Rows(rowIndex).Cells(0).Value = name
        dgvutility.Rows(rowIndex).Cells(1).Value = value
    End Sub

    Private Sub OpenUtilityPath(pathValue As String)
        Dim resolvedPath As String = NormalizeUtilityPath(pathValue)

        If Not Directory.Exists(resolvedPath) Then
            MessageBox.Show("Folder not found: " & resolvedPath, "Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Process.Start(New ProcessStartInfo() With {
            .FileName = resolvedPath,
            .UseShellExecute = True
        })
    End Sub

    Private Sub OpenUtilityLog(pathValue As String, fileName As String)
        OpenUtilityFile(Path.Combine(NormalizeUtilityPath(pathValue), fileName))
    End Sub

    Private Sub OpenLatestUtilityLog(pathValue As String, searchPattern As String)
        Dim normalizedPath As String = NormalizeUtilityPath(pathValue)

        If Not Directory.Exists(normalizedPath) Then
            MessageBox.Show("Folder not found: " & normalizedPath, "Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim latestFile = Directory.GetFiles(normalizedPath, searchPattern).
            Select(Function(filePath) New FileInfo(filePath)).
            OrderByDescending(Function(fileInfo) fileInfo.LastWriteTime).
            FirstOrDefault()

        If latestFile Is Nothing Then
            MessageBox.Show("No matching file found in: " & normalizedPath, "Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        OpenUtilityFile(latestFile.FullName)
    End Sub

    Private Sub OpenUtilityFile(filePath As String)
        If Not File.Exists(filePath) Then
            MessageBox.Show("File not found: " & filePath, "Utility", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Process.Start("notepad.exe", filePath)
    End Sub

    Private Function NormalizeUtilityPath(pathValue As String) As String
        Dim normalizedPath As String = Replace(pathValue, "/", "\").Trim()

        If String.IsNullOrWhiteSpace(normalizedPath) Then
            Return normalizedPath
        End If

        If ShouldPrefixServerPath(normalizedPath) Then
            Return Path.Combine(initialpath.TrimEnd("\"c), normalizedPath.TrimStart("\"c)).TrimEnd("\"c)
        End If

        Return normalizedPath.TrimEnd("\"c)
    End Function

    Private Function ShouldPrefixServerPath(pathValue As String) As Boolean
        If String.IsNullOrWhiteSpace(pathValue) Then
            Return False
        End If

        If pathValue.StartsWith("\\") Then
            Return False
        End If

        If pathValue.Contains(":") Then
            Return False
        End If

        Return True
    End Function

    Sub initialiseutilitydata()
        On Error Resume Next
        dgvutility.Rows.Add(7)
        SetUtilityRow(0, "Media", mediafullpath)
        SetUtilityRow(1, "Template", templatefullpath)
        SetUtilityRow(2, "Thumbnail", thumbnailsfullpath)
        SetUtilityRow(3, "Server", initialpath)
        SetUtilityRow(4, "Log", logpath)
        SetUtilityRow(5, "Data", datapath)
        SetUtilityRow(6, "As Run Log", "C:\casparcg\mydata\asrunlog")
        SetUtilityRow(7, "Font", fontpath)

    End Sub

    Private Sub ucUtility_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialiseutilitydata()
    End Sub
    Private Sub dgvutility_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvutility.CellContentClick
        On Error Resume Next
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If dgvutility.Columns(e.ColumnIndex).Name = "Open" Then
            OpenUtilityPath(dgvutility.CurrentRow.Cells(1).Value)
        End If
        If e.ColumnIndex = 3 And e.RowIndex = 6 Then
            OpenLatestUtilityLog("c:/casparcg/mydata/asrunlog/", "asrunlog_*.txt")
        End If
        If e.ColumnIndex = 3 And e.RowIndex = 4 Then
            OpenLatestUtilityLog(dgvutility.CurrentRow.Cells(1).Value, "caspar_*.log")
        End If
    End Sub

    Private Sub gbutility_Enter(sender As Object, e As EventArgs) Handles gbutility.Enter

    End Sub
End Class
