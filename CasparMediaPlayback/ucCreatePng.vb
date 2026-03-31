Public Class ucCreatePng
    Private Sub AddImageToPlaylist(imageName As String)
        With ucPlaylist
            .dgv1.Rows.Insert(.dgv1.CurrentRow.Index + 1)
            .dgv1.CurrentCell = .dgv1.Rows(.dgv1.CurrentRow.Index + 1).Cells("File_Name")
            .dgv1.Rows(.dgv1.CurrentRow.Index).Cells("File_Name").Value = imageName & ".png"
            .dgv1.Rows(.dgv1.CurrentRow.Index).Cells("x").Value = 1
            .dgv1.Rows(.dgv1.CurrentRow.Index).Cells("Transition").Value = "CUT"
            .dgv1.Rows(.dgv1.CurrentRow.Index).Cells("T_Duration").Value = 10
        End With
    End Sub

    Private Sub SendAddImageCommand(imageName As String)
        CasparDevice.SendString("add " & g_int_ChannelNumber & " image " & """" & imageName & """")
    End Sub

    Private Sub IncrementImageName()
        iaddimage = iaddimage + 1

        Dim nameParts = Split(txtaddimagename.Text, "_")
        If nameParts.Length > 1 AndAlso nameParts(1) = "" Then
            iaddimage = 1
        End If

        txtaddimagename.Text = nameParts(0) & "_" & iaddimage
    End Sub

    Private Sub cmdaddimage_Click(sender As Object, e As EventArgs) Handles cmdaddimage.Click
        On Error Resume Next

        If chkaaddimagetoplaylist.Checked Then
            AddImageToPlaylist(txtaddimagename.Text)
        End If

        SendAddImageCommand(txtaddimagename.Text)
        IncrementImageName()
    End Sub

    Private Sub ucCreatePng_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
