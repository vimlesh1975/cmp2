
Public Class ucUtility
    Private Sub SetUtilityRow(rowIndex As Integer, name As String, value As String)
        dgvutility.Rows(rowIndex).Cells(0).Value = name
        dgvutility.Rows(rowIndex).Cells(1).Value = value
    End Sub
    Private Sub OpenUtilityPath(pathValue As String)
        Process.Start("explorer.exe", Replace(pathValue, "/", "\"))
    End Sub
    Private Sub OpenUtilityLog(pathValue As String, fileName As String)
        Process.Start("notepad.exe", Replace(pathValue, "/", "\") & fileName)
    End Sub

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
        If dgvutility.Columns(e.ColumnIndex).Name = "Open" Then
            OpenUtilityPath(dgvutility.CurrentRow.Cells(1).Value)
        End If
        If e.ColumnIndex = 3 And e.RowIndex = 6 Then
            OpenUtilityLog("c:/casparcg/mydata/asrunlog/", "asrunlog_" & DateTime.Now.ToString("ddMMyy") & ".txt")
        End If
        If e.ColumnIndex = 3 And e.RowIndex = 4 Then
            OpenUtilityLog(dgvutility.CurrentRow.Cells(1).Value, "caspar_" & DateTime.Now.ToString("yyyy-MM-dd") & ".log")
        End If
    End Sub

    Private Sub gbutility_Enter(sender As Object, e As EventArgs) Handles gbutility.Enter

    End Sub
End Class
