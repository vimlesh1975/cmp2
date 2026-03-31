Imports Microsoft.Win32 'for number of processor


Public Class ucTranscodingProfile
    Public strFileExtension As String
    Public cmdtranscodingcommand As String = ""
    Public ofdtrimmer As New OpenFileDialog
    Public osdcutfilename As New SaveFileDialog
    Dim threadstousefortranscoding As String
    Public strinout As String = ""

    Public startinfofilename As String
    Dim openlogoforexport As New OpenFileDialog
    Private Sub LoadCodecList(combo As ComboBox, fileName As String)
        combo.Items.AddRange(System.IO.File.ReadAllLines(fileName))
    End Sub

    Private Function BuildTranscodeExtension(enabled As Boolean, extensionValue As String) As String
        If enabled Then
            Return extensionValue
        End If
        Return strFileExtension
    End Function
    Private Sub ucTranscodingProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        getnumberofprocessors()
        LoadCodecList(cmbvideocodec, "C:\casparcg\mydata\ffmpeg\video_codecs.txt")
        LoadCodecList(cmbaudiocodec, "C:\casparcg\mydata\ffmpeg\audio_codecs.txt")
        LoadCodecList(cmbvideocodec5, "C:\casparcg\mydata\ffmpeg\video_codecs.txt")
        LoadCodecList(cmbaudiocodec5, "C:\casparcg\mydata\ffmpeg\audio_codecs.txt")

        openlogoforexport.FileName = "c:\casparcg\_media\sd_frame.png"

    End Sub
    Sub getnumberofprocessors()
        On Error Resume Next
        Dim rk As RegistryKey = Registry.LocalMachine
        Dim subKeys As Array = rk.OpenSubKey("HARDWARE").OpenSubKey("DESCRIPTION").OpenSubKey("System").OpenSubKey("CentralProcessor").GetSubKeyNames()
        lblnumberofprocessors.Text = "Total number of cores:" + subKeys.Length.ToString()
        txtnumberofprocessors.Text = subKeys.Length - 1
        threadstousefortranscoding = " -threads " & txtnumberofprocessors.Text
    End Sub

    Private Sub txtnumberofprocessors_TextChanged(sender As Object, e As EventArgs) Handles txtnumberofprocessors.TextChanged
        On Error Resume Next
        threadstousefortranscoding = " -threads " & txtnumberofprocessors.Text
    End Sub
    Sub getextensionfortranscoding()
        On Error Resume Next
        strFileExtension = ""
        strFileExtension = BuildTranscodeExtension(rdoSDtoXDcamHD422Mxf.Checked, "_SDtoXdcam.mxf")
        strFileExtension = BuildTranscodeExtension(rdoanytoAnamorphicXDcamHD422Mxf.Checked, "_AnamorphicXdcam.mxf")
        strFileExtension = BuildTranscodeExtension(rdoHD1920x1080tosdCenterCutmxf.Checked, "_HDtocentercutSD.mxf")
        strFileExtension = BuildTranscodeExtension(rdoHDtoXDCAMHD422mxfwithFFMBC.Checked, "_HDtoXdcam.mxf")
        strFileExtension = BuildTranscodeExtension(rdoNX5CameraMTSHDtoCenterCutSDmpg.Checked, "_NX5HDtoCentercut.mpg")
        strFileExtension = BuildTranscodeExtension(rdoTrancodemp4.Checked, "_toMP4.mp4")
        strFileExtension = BuildTranscodeExtension(rdoTrancodemp4hevc.Checked, "_toMP4HEVC.mp4")
        strFileExtension = BuildTranscodeExtension(rdoHDtoCenterCutSDmov.Checked, "_HDtoCenterCutSD" & cmbextensionhdtocentercutdv.Text)
        strFileExtension = BuildTranscodeExtension(rdoHDtoLetterBoxSDmov.Checked, "_HDtoLetterBoxSD" & cmbextensionhdtoLetterBoxdv.Text)
        strFileExtension = BuildTranscodeExtension(rdoHDtoAnamorphicmov.Checked, "_HDtoAnamorphic" & cmbextensionhdtoAnamprphicdv.Text)
        strFileExtension = BuildTranscodeExtension(rdodvcpro50dv.Checked, "_SDtoDV" & cmbextensiondvcpro50.Text)
        strFileExtension = BuildTranscodeExtension(rdoCodecBased.Checked, "_" & cmbvideocodec.Text & "_" & cmbaudiocodec.Text & cmbextensioncodecbased.Text)
        strFileExtension = BuildTranscodeExtension(rdoTranscodeWithLogo.Checked, "_" & cmbvideocodec5.Text & "_" & cmbaudiocodec5.Text & "_with_logo" & cmbextension5.Text)
        strFileExtension = BuildTranscodeExtension(rdoCustomTranscode.Checked, "_CustomTranscoded" & cmbextensioncustom.Text)
        strFileExtension = BuildTranscodeExtension(rdoSDtoSDoverBlurVideo.Checked, "_VideoOverBlurred.mp4")
        strFileExtension = BuildTranscodeExtension(rdoHDblacktoHDoverBlurVideo.Checked, "_VideoOverBlurred.mp4")

        If ckkUseSuffix.Checked = False Then
            strFileExtension = "." + strFileExtension.Split(".")(1)
        End If

    End Sub
    Sub getstartinfofilename()
        On Error Resume Next

        If rdoHDtoXDCAMHD422mxfwithFFMBC.Checked Or rdoHDtoCenterCutSDmov.Checked Or rdoHDtoLetterBoxSDmov.Checked Or rdoHDtoAnamorphicmov.Checked Or rdodvcpro50dv.Checked Or (rdoCustomTranscode.Checked And rdocustomtranscodeffmbc.Checked) Then
            startinfofilename = "c:/casparcg/mydata/ffmbc/ffmbc-0.7.4-x64.exe"
        Else
            If rdoSDtoXDcamHD422Mxf.Checked Or rdoanytoAnamorphicXDcamHD422Mxf.Checked Then
                startinfofilename = "c:\casparcg\mydata\ffmpeg\ffmpeg.exe"
            Else
                startinfofilename = "c:/casparcg/mydata/ffmpeg/ffmpeg.exe"
            End If
        End If
    End Sub

    Sub gettranscodingcommand()
        On Error Resume Next

        If rdoSDtoXDcamHD422Mxf.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec mpeg2video -acodec pcm_s24le -vf scale=1440:1080,pad=1920:1080:240:0,setfield=tff -pix_fmt yuv422p -alternate_scan 1 -ar 48000 -r 25 -g 12 -bf 2 -b:v 50000k -minrate 50000k -maxrate 50000k -aspect 16:9 -ac 1 -map 0:0 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -timecode 00:02:00:00 -metadata creation_time=now -color_primaries bt709 -color_trc 1  -colorspace 1 -f mxf pipe:1 | " & """" & "c:/casparcg/mydata/ffmbc/ffmbc-0.7.4-x64.exe" & """" & " -i -  -tff  -target xdcamhd422 -f mxf -y -an " & """" & osdcutfilename.FileName & """" & " " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
             "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
             "-map_audio_channel 0:1:0:0:1:0 " &
             "-map_audio_channel 0:1:0:0:2:0 " &
             "-map_audio_channel 0:1:0:0:3:0 " &
             "-map_audio_channel 0:1:0:0:4:0 " &
             "-map_audio_channel 0:1:0:0:5:0 " &
             "-map_audio_channel 0:1:0:0:6:0 " &
             "-map_audio_channel 0:1:0:0:7:0 " &
             "-map_audio_channel 0:1:0:0:8:0"
        End If
        If rdoanytoAnamorphicXDcamHD422Mxf.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec mpeg2video -acodec pcm_s24le -vf scale=1920:1080,setfield=tff -pix_fmt yuv422p -alternate_scan 1 -ar 48000 -r " & txtFPS.Text & " -g 12 -bf 2 -b:v 50000k -minrate 50000k -maxrate 50000k -aspect 16:9 -ac 1 -map 0:0 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -timecode 00:02:00:00 -metadata creation_time=now -color_primaries bt709 -color_trc 1  -colorspace 1 -f mxf pipe:1 | " & """" & "c:/casparcg/mydata/ffmbc/ffmbc-0.7.4-x64.exe" & """" & " -i -  -tff  -target xdcamhd422 -f mxf -y -an " & """" & osdcutfilename.FileName & """" & " " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
             "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
            "-acodec pcm_s24le -ar 48000 -newaudio " &
             "-map_audio_channel 0:1:0:0:1:0 " &
             "-map_audio_channel 0:1:0:0:2:0 " &
             "-map_audio_channel 0:1:0:0:3:0 " &
             "-map_audio_channel 0:1:0:0:4:0 " &
             "-map_audio_channel 0:1:0:0:5:0 " &
             "-map_audio_channel 0:1:0:0:6:0 " &
             "-map_audio_channel 0:1:0:0:7:0 " &
             "-map_audio_channel 0:1:0:0:8:0"
        End If



        If rdoHD1920x1080tosdCenterCutmxf.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec mpeg2video -acodec pcm_s24le -vf scale=960:576,crop=720:576:120:0,setfield=tff -pix_fmt yuv422p -alternate_scan 1  -g 12 -bf 2 -b:v 50000k -minrate 50000k -maxrate 50000k -aspect 4:3 -ac 1 -map 0:0 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -map 0:1 -timecode 00:02:00:00 -metadata creation_time=now -color_primaries bt709 -color_trc 1  -colorspace 1 -f mxf  " & """" & osdcutfilename.FileName & """"
        End If



        If rdoHDtoXDCAMHD422mxfwithFFMBC.Checked Then

            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -tff  -target xdcamhd422  -f mxf -an " & """" & osdcutfilename.FileName & """" & " " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
         "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
        "-acodec pcm_s24le -ar 48000 -newaudio " &
         "-map_audio_channel 0:1:0:0:1:0 " &
         "-map_audio_channel 0:1:0:0:2:0 " &
         "-map_audio_channel 0:1:0:0:3:0 " &
         "-map_audio_channel 0:1:0:0:4:0 " &
         "-map_audio_channel 0:1:0:0:5:0 " &
         "-map_audio_channel 0:1:0:0:6:0 " &
         "-map_audio_channel 0:1:0:0:7:0 " &
         "-map_audio_channel 0:1:0:0:8:0"

        End If

        If rdoTrancodemp4.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec libx264 -acodec aac -b:v " & ntranscodeinmp4bitrate.Value & "M  " & """" & osdcutfilename.FileName & """"
        End If

        If rdoTrancodemp4hevc.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec libx265 -acodec aac -b:v " & ntranscodeinmp4bitrate.Value & "M  " & """" & osdcutfilename.FileName & """"
        End If


        If rdoNX5CameraMTSHDtoCenterCutSDmpg.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec mpeg2video -acodec mp2 -vf scale=960:576,crop=720:576:120:0,setfield=tff -pix_fmt yuv422p -alternate_scan 1  -g 1 -b:v 30000k -minrate 30000k -maxrate 30000k -b:a 224k -aspect 4:3 -ac 2 -map 0:0 -map 0:1 -map 0:1 -timecode 17:28:07:10 -metadata creation_time=now " & """" & osdcutfilename.FileName & """"
        End If


        If rdoHDtoCenterCutSDmov.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -tff -vf scale=960:576,crop=720:576:120:0 -target " & cmbformatforhdtocentercutdv.Text & " " & """" & osdcutfilename.FileName & """"
        End If

        If rdoHDtoLetterBoxSDmov.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -tff -vf scale=720:430,pad=720:576:0:73 -target " & cmbformatforhdtoLetterBoxdv.Text & " " & """" & osdcutfilename.FileName & """"
        End If


        If rdoHDtoAnamorphicmov.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -aspect 4:3 -tff -vf scale=720:576 -target " & cmbformatforhdtoAnamorphicdv.Text & " " & """" & osdcutfilename.FileName & """"
        End If


        If rdodvcpro50dv.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -tff -target " & cmbformatedvcpro50.Text & " " & """" & osdcutfilename.FileName & """"
        End If

        If rdoCodecBased.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -vcodec " & cmbvideocodec.Text & " -acodec " & cmbaudiocodec.Text & " -b " & cmbbitrate.Text & "M " & """" & osdcutfilename.FileName & """"
        End If

        If rdoTranscodeWithLogo.Checked Then
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & " -stream_loop -1 -i " & """" & openlogoforexport.FileName & """" & " -filter_complex " &
                                  """" & "[1:v]scale=" & nlogowidthforexport.Value & ":" & nlogoheightforexport.Value & " [ovrl],[0:v][ovrl]overlay=shortest=1:x=" &
                                  nlogoxposition.Value & ":y=" & nlogoyposition.Value & """" & threadstousefortranscoding & " -vcodec " & cmbvideocodec5.Text & " -acodec " & cmbaudiocodec5.Text & " -b " & cmbbitrate5.Text & "M " & """" & osdcutfilename.FileName & """"
        End If

        If rdoCustomTranscode.Checked Then

            If rdocustomtranscodeffmpeg.Checked Then
                cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " " & txtoptionstrimmercustom.Text & " " & """" & osdcutfilename.FileName & """"
            Else
                cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " " & txtoptionstrimmercustom.Text & " " & """" & osdcutfilename.FileName & """"
            End If

        End If
        If rdoSDtoSDoverBlurVideo.Checked Then
            Dim xposition As String = (Split(txtTotalSize.Text, ":")(0) - Split(txtBoxSize.Text, ":")(0)) / 2
            ' cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -filter_complex " & """" & "[0:v]boxblur=50:1,scale=" & txtTotalSize.Text & "[aa];[0:v]scale=" & txtBoxSize.Text & ",pad=w=" & 4 * nborderwidth.Value & "+iw:x=" & 2 * nborderwidth.Value & ":color=" & bordercolor & "[bb];[aa][bb]overlay=x=" & xposition & "[cc]" & """" & " -aspect 16:9 -map [cc] -map 0:a -b:v 10M " & """" & osdcutfilename.FileName & """"
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -filter_complex " & """" & "[0]scale=" & (720 + Int(txtExtraCrop.Text)) & ":576,crop=720:576[dd];[dd]split[dd1][dd2];[dd1]boxblur=50:1,scale=" & txtTotalSize.Text & "[aa];[dd2]scale=" & txtBoxSize.Text & ",pad=w=" & 4 * nborderwidth.Value & "+iw:x=" & 2 * nborderwidth.Value & ":color=" & bordercolor & "[bb];[aa][bb]overlay=x=" & xposition & "[cc]" & """" & " -aspect 16:9 -map [cc] -map 0:a? -b:v 10M " & """" & osdcutfilename.FileName & """"
        End If

        If rdoHDblacktoHDoverBlurVideo.Checked Then
            Dim xposition As String = (Split(txtTotalSize.Text, ":")(0) - Split(txtBoxSize.Text, ":")(0)) / 2
            'cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -filter_complex " & """" & "[0]scale=960:576,crop=720:576[dd];[dd]split[dd1][dd2];[dd1]boxblur=50:1,scale=" & txtTotalSize.Text & "[aa];[dd2]scale=" & txtBoxSize.Text & ",pad=w=" & 4 * nborderwidth.Value & "+iw:x=" & 2 * nborderwidth.Value & ":color=" & bordercolor & "[bb];[aa][bb]overlay=x=" & xposition & "[cc]" & """" & " -aspect 16:9 -map [cc] -map 0:a -b:v 10M " & """" & osdcutfilename.FileName & """"
            cmdtranscodingcommand = " -y " & strinout & " -i " & """" & ofdtrimmer.FileName & """" & threadstousefortranscoding & " -filter_complex " & """" & "[0]scale=" & (960 + Int(txtExtraCrop.Text)) & ":576,crop=720:576[dd];[dd]split[dd1][dd2];[dd1]boxblur=50:1,scale=" & txtTotalSize.Text & "[aa];[dd2]scale=" & txtBoxSize.Text & ",pad=w=" & 4 * nborderwidth.Value & "+iw:x=" & 2 * nborderwidth.Value & ":color=" & bordercolor & "[bb];[aa][bb]overlay=x=" & xposition & "[cc]" & """" & " -aspect 16:9 -map [cc] -map 0:a? -b:v 10M " & """" & osdcutfilename.FileName & """"

        End If


    End Sub


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CmdOpenLogo_Click(sender As Object, e As EventArgs) Handles cmdOpenLogo.Click
        On Error Resume Next

        If openlogoforexport.ShowDialog = Windows.Forms.DialogResult.OK Then
            vlcLogo.VlcMediaPlayer.SetMedia(New Uri(openlogoforexport.FileName))
            vlcLogo.VlcMediaPlayer.Play()
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
    Dim bordercolor As String = "0xff0000"
    Private Sub cmdBorderColor_Click(sender As Object, e As EventArgs) Handles cmdBorderColor.Click
        On Error Resume Next
        If (cd1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            cmdBorderColor.BackColor = cd1.Color

            bordercolor = "0x" & String.Format("{0:X2}{1:X2}{2:X2}", cmdBorderColor.BackColor.R, cmdBorderColor.BackColor.G, cmdBorderColor.BackColor.B)

        End If
    End Sub


End Class
