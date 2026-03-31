Imports System.ComponentModel

Public Class uc4ChannelPlayer
    Private Function GetVideoPlayers() As IEnumerable(Of UcVideoPlayer)
        Return {UcVideoPlayer1, UcVideoPlayer2, UcVideoPlayer3, UcVideoPlayer4}
    End Function

    Private Sub ConfigureVideoPlayer(player As UcVideoPlayer, channelNumber As Integer)
        With player
            .channelNumber = channelNumber
            .cmbcasparcgwindowtitle.Text = "Screen consumer [" & .channelNumber & "|1080i5000]"
            .oscstartandregister(.channelNumber, 6250 + .channelNumber)
            .lblChannel.Text = "Channel " & .channelNumber
        End With
    End Sub

    Private Sub uc4ChannelPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        Dim channelNumber = 1
        For Each player In GetVideoPlayers()
            ConfigureVideoPlayer(player, channelNumber)
            channelNumber += 1
        Next

        Threading.Thread.Sleep(2000)
        For Each player In GetVideoPlayers()
            player.inWindow()
        Next
    End Sub

    Private Sub uc4ChannelPlayer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        For Each player In GetVideoPlayers()
            player.cmdoutcasparcgwindowrecording.PerformClick()
        Next
    End Sub
End Class
