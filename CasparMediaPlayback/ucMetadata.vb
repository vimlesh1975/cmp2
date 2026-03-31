Imports System.IO
Public Class ucMetadata
    Private Const FfmpegExecutablePath As String = "c:/casparcg/mydata/ffmpeg/ffmpeg.exe"
    Private Const ReadMetadataPath As String = "c:/casparcg/mydata/ffmpeg/readmetadata.txt"
    Private Const WriteMetadataPath As String = "c:/casparcg/mydata/ffmpeg/metadataforwrite.txt"

    Private Sub cmdreadmetadata_Click(sender As Object, e As EventArgs) Handles cmdreadmetadata.Click
        On Error Resume Next
        Dim ofdmetadata As New OpenFileDialog
        If ofdmetadata.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        lblfilenamemetadata.Text = ofdmetadata.FileName
        ResetMetadataGrid()
        RunFfmpegCommand("-y -i " & QuoteArgument(ofdmetadata.FileName) & " -f ffmetadata " & QuoteArgument(ReadMetadataPath))
        Threading.Thread.Sleep(5000)
        LoadMetadataGrid(ReadMetadataPath)
    End Sub

    Private Sub cmdwritemetadata_Click(sender As Object, e As EventArgs) Handles cmdwritemetadata.Click
        On Error Resume Next
        Dim osdmetadata As New SaveFileDialog
        SaveMetadataFile()
        If osdmetadata.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        RunFfmpegCommand("-y -i " & QuoteArgument(lblfilenamemetadata.Text) &
                         " -i " & QuoteArgument(WriteMetadataPath) &
                         " -map_metadata 1 -c copy -id3v2_version 3 " &
                         QuoteArgument(osdmetadata.FileName))
    End Sub

    Private Sub cmdclearfieldmetadata_Click(sender As Object, e As EventArgs) Handles cmdclearfieldmetadata.Click
        On Error Resume Next
        dgvmetadata.Rows.Clear()
    End Sub

    Private Sub cmdhidegbmetadata_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub ResetMetadataGrid()
        dgvmetadata.Rows.Clear()
        dgvmetadata.Rows.Add(1)
    End Sub

    Private Sub RunFfmpegCommand(arguments As String)
        Process.Start("CMD", "/K " & FfmpegExecutablePath & " " & arguments)
    End Sub

    Private Sub LoadMetadataGrid(metadataFilePath As String)
        Using sr As StreamReader = New StreamReader(metadataFilePath)
            Dim rowIndex As Integer = 0
            Dim li As String

            Do Until sr.EndOfStream = True
                li = sr.ReadLine()
                dgvmetadata.Rows.Insert(rowIndex, 1)
                PopulateMetadataRow(rowIndex, li)
                rowIndex = rowIndex + 1
            Loop
        End Using
    End Sub

    Private Sub PopulateMetadataRow(rowIndex As Integer, line As String)
        Dim xyz As Array = Split(line, "=")
        dgvmetadata.Rows(rowIndex).Cells(0).Value = xyz(0)
        If xyz.Length > 1 Then
            dgvmetadata.Rows(rowIndex).Cells(1).Value = xyz(1)
        End If
    End Sub

    Private Sub SaveMetadataFile()
        Using sw As StreamWriter = New StreamWriter(WriteMetadataPath)
            If dgvmetadata.Rows.Count = 0 Then
                sw.Write("")
                Exit Sub
            End If

            Dim rowIndex As Integer = 0
            Do Until rowIndex = dgvmetadata.Rows.Count - 2
                If rowIndex = 0 Then
                    sw.WriteLine(dgvmetadata.Rows(rowIndex).Cells(0).Value)
                Else
                    sw.WriteLine(dgvmetadata.Rows(rowIndex).Cells(0).Value & "=" & dgvmetadata.Rows(rowIndex).Cells(1).Value)
                End If
                rowIndex = rowIndex + 1
            Loop
        End Using
    End Sub

    Private Function QuoteArgument(value As String) As String
        Return """" & value & """"
    End Function
End Class
