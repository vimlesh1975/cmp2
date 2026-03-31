Imports caspar_media_playback.My

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucdBFSMeter
    'Inherits System.Windows.Forms.UserControl
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucdBFSMeter))
        Dim MySettings1 As caspar_media_playback.My.MySettings = New caspar_media_playback.My.MySettings()
        Me.DBFS_Meter1 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter2 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter3 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter4 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter5 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter6 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter7 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter8 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter9 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter10 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter11 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter12 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter13 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter14 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter15 = New dBFS_Meter.dBFS_Meter()
        Me.DBFS_Meter16 = New dBFS_Meter.dBFS_Meter()
        Me.lblucdbfmeter = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tmraudio = New System.Windows.Forms.Timer(Me.components)
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdL_to_Both = New System.Windows.Forms.Button()
        Me.cmdR_to_Both = New System.Windows.Forms.Button()
        Me.cmdrefreshmediaforaudiotest = New System.Windows.Forms.Button()
        Me.cmbmediaforaudiotest = New System.Windows.Forms.ComboBox()
        Me.cmdaudiotest = New System.Windows.Forms.Button()
        Me.cmbchannel_layout = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cmdMix = New System.Windows.Forms.Button()
        Me.cmdOnly_L = New System.Windows.Forms.Button()
        Me.cmdOnly_R = New System.Windows.Forms.Button()
        Me.tbAudioControl0 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl0 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl1 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl1 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl3 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl3 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl2 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl7 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl7 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl6 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl5 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl5 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl4 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl2 = New System.Windows.Forms.TrackBar()
        Me.tbAudioControl4 = New System.Windows.Forms.TrackBar()
        Me.tbAudioControl6 = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbAudioControl14 = New System.Windows.Forms.TrackBar()
        Me.tbAudioControl12 = New System.Windows.Forms.TrackBar()
        Me.tbAudioControl10 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl15 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl15 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl14 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl13 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl13 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl12 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl11 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl11 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl10 = New System.Windows.Forms.ComboBox()
        Me.cmbAudioControl9 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl9 = New System.Windows.Forms.TrackBar()
        Me.cmbAudioControl8 = New System.Windows.Forms.ComboBox()
        Me.tbAudioControl8 = New System.Windows.Forms.TrackBar()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.DBFS_Meter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBFS_Meter16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tbAudioControl14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DBFS_Meter1
        '
        Me.DBFS_Meter1.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter1.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter1.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter1.DBFS_ScaleVisible = True
        Me.DBFS_Meter1.DBFS_Value = -17.0!
        Me.DBFS_Meter1.Location = New System.Drawing.Point(9, 26)
        Me.DBFS_Meter1.Name = "DBFS_Meter1"
        Me.DBFS_Meter1.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter1.TabIndex = 0
        Me.DBFS_Meter1.TabStop = False
        '
        'DBFS_Meter2
        '
        Me.DBFS_Meter2.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter2.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter2.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter2.DBFS_ScaleVisible = True
        Me.DBFS_Meter2.DBFS_Value = -17.0!
        Me.DBFS_Meter2.Location = New System.Drawing.Point(47, 26)
        Me.DBFS_Meter2.Name = "DBFS_Meter2"
        Me.DBFS_Meter2.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter2.TabIndex = 1
        Me.DBFS_Meter2.TabStop = False
        '
        'DBFS_Meter3
        '
        Me.DBFS_Meter3.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter3.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter3.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter3.DBFS_ScaleVisible = True
        Me.DBFS_Meter3.DBFS_Value = -17.0!
        Me.DBFS_Meter3.Location = New System.Drawing.Point(85, 26)
        Me.DBFS_Meter3.Name = "DBFS_Meter3"
        Me.DBFS_Meter3.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter3.TabIndex = 2
        Me.DBFS_Meter3.TabStop = False
        '
        'DBFS_Meter4
        '
        Me.DBFS_Meter4.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter4.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter4.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter4.DBFS_ScaleVisible = True
        Me.DBFS_Meter4.DBFS_Value = -17.0!
        Me.DBFS_Meter4.Location = New System.Drawing.Point(123, 26)
        Me.DBFS_Meter4.Name = "DBFS_Meter4"
        Me.DBFS_Meter4.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter4.TabIndex = 3
        Me.DBFS_Meter4.TabStop = False
        '
        'DBFS_Meter5
        '
        Me.DBFS_Meter5.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter5.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter5.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter5.DBFS_ScaleVisible = True
        Me.DBFS_Meter5.DBFS_Value = -17.0!
        Me.DBFS_Meter5.Location = New System.Drawing.Point(161, 26)
        Me.DBFS_Meter5.Name = "DBFS_Meter5"
        Me.DBFS_Meter5.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter5.TabIndex = 4
        Me.DBFS_Meter5.TabStop = False
        '
        'DBFS_Meter6
        '
        Me.DBFS_Meter6.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter6.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter6.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter6.DBFS_ScaleVisible = True
        Me.DBFS_Meter6.DBFS_Value = -17.0!
        Me.DBFS_Meter6.Location = New System.Drawing.Point(199, 26)
        Me.DBFS_Meter6.Name = "DBFS_Meter6"
        Me.DBFS_Meter6.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter6.TabIndex = 5
        Me.DBFS_Meter6.TabStop = False
        '
        'DBFS_Meter7
        '
        Me.DBFS_Meter7.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter7.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter7.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter7.DBFS_ScaleVisible = True
        Me.DBFS_Meter7.DBFS_Value = -17.0!
        Me.DBFS_Meter7.Location = New System.Drawing.Point(238, 26)
        Me.DBFS_Meter7.Name = "DBFS_Meter7"
        Me.DBFS_Meter7.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter7.TabIndex = 6
        Me.DBFS_Meter7.TabStop = False
        '
        'DBFS_Meter8
        '
        Me.DBFS_Meter8.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter8.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter8.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter8.DBFS_ScaleVisible = True
        Me.DBFS_Meter8.DBFS_Value = -17.0!
        Me.DBFS_Meter8.Location = New System.Drawing.Point(276, 26)
        Me.DBFS_Meter8.Name = "DBFS_Meter8"
        Me.DBFS_Meter8.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter8.TabIndex = 7
        Me.DBFS_Meter8.TabStop = False
        '
        'DBFS_Meter9
        '
        Me.DBFS_Meter9.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter9.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter9.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter9.DBFS_ScaleVisible = True
        Me.DBFS_Meter9.DBFS_Value = -17.0!
        Me.DBFS_Meter9.Location = New System.Drawing.Point(315, 26)
        Me.DBFS_Meter9.Name = "DBFS_Meter9"
        Me.DBFS_Meter9.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter9.TabIndex = 8
        Me.DBFS_Meter9.TabStop = False
        '
        'DBFS_Meter10
        '
        Me.DBFS_Meter10.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter10.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter10.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter10.DBFS_ScaleVisible = True
        Me.DBFS_Meter10.DBFS_Value = -17.0!
        Me.DBFS_Meter10.Location = New System.Drawing.Point(354, 26)
        Me.DBFS_Meter10.Name = "DBFS_Meter10"
        Me.DBFS_Meter10.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter10.TabIndex = 9
        Me.DBFS_Meter10.TabStop = False
        '
        'DBFS_Meter11
        '
        Me.DBFS_Meter11.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter11.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter11.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter11.DBFS_ScaleVisible = True
        Me.DBFS_Meter11.DBFS_Value = -17.0!
        Me.DBFS_Meter11.Location = New System.Drawing.Point(393, 26)
        Me.DBFS_Meter11.Name = "DBFS_Meter11"
        Me.DBFS_Meter11.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter11.TabIndex = 10
        Me.DBFS_Meter11.TabStop = False
        '
        'DBFS_Meter12
        '
        Me.DBFS_Meter12.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter12.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter12.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter12.DBFS_ScaleVisible = True
        Me.DBFS_Meter12.DBFS_Value = -17.0!
        Me.DBFS_Meter12.Location = New System.Drawing.Point(432, 26)
        Me.DBFS_Meter12.Name = "DBFS_Meter12"
        Me.DBFS_Meter12.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter12.TabIndex = 11
        Me.DBFS_Meter12.TabStop = False
        '
        'DBFS_Meter13
        '
        Me.DBFS_Meter13.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter13.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter13.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter13.DBFS_ScaleVisible = True
        Me.DBFS_Meter13.DBFS_Value = -17.0!
        Me.DBFS_Meter13.Location = New System.Drawing.Point(471, 26)
        Me.DBFS_Meter13.Name = "DBFS_Meter13"
        Me.DBFS_Meter13.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter13.TabIndex = 12
        Me.DBFS_Meter13.TabStop = False
        '
        'DBFS_Meter14
        '
        Me.DBFS_Meter14.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter14.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter14.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter14.DBFS_ScaleVisible = True
        Me.DBFS_Meter14.DBFS_Value = -17.0!
        Me.DBFS_Meter14.Location = New System.Drawing.Point(510, 26)
        Me.DBFS_Meter14.Name = "DBFS_Meter14"
        Me.DBFS_Meter14.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter14.TabIndex = 13
        Me.DBFS_Meter14.TabStop = False
        '
        'DBFS_Meter15
        '
        Me.DBFS_Meter15.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter15.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter15.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter15.DBFS_ScaleVisible = True
        Me.DBFS_Meter15.DBFS_Value = -17.0!
        Me.DBFS_Meter15.Location = New System.Drawing.Point(549, 26)
        Me.DBFS_Meter15.Name = "DBFS_Meter15"
        Me.DBFS_Meter15.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter15.TabIndex = 14
        Me.DBFS_Meter15.TabStop = False
        '
        'DBFS_Meter16
        '
        Me.DBFS_Meter16.DBFS_LED_Size = dBFS_Meter.dBFS_Meter.LED_SIZE.LARGE
        Me.DBFS_Meter16.DBFS_Orientation = dBFS_Meter.dBFS_Meter.ORIENTATION.VERTICAL
        Me.DBFS_Meter16.DBFS_ScaleTextColor = System.Drawing.Color.Black
        Me.DBFS_Meter16.DBFS_ScaleVisible = True
        Me.DBFS_Meter16.DBFS_Value = -17.0!
        Me.DBFS_Meter16.Location = New System.Drawing.Point(588, 26)
        Me.DBFS_Meter16.Name = "DBFS_Meter16"
        Me.DBFS_Meter16.Size = New System.Drawing.Size(35, 254)
        Me.DBFS_Meter16.TabIndex = 15
        Me.DBFS_Meter16.TabStop = False
        '
        'lblucdbfmeter
        '
        Me.lblucdbfmeter.AutoSize = True
        Me.lblucdbfmeter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblucdbfmeter.Location = New System.Drawing.Point(190, -3)
        Me.lblucdbfmeter.Name = "lblucdbfmeter"
        Me.lblucdbfmeter.Size = New System.Drawing.Size(263, 25)
        Me.lblucdbfmeter.TabIndex = 710
        Me.lblucdbfmeter.Text = "16 Channel dBFS Meter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 25)
        Me.Label1.TabIndex = 711
        Me.Label1.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 25)
        Me.Label2.TabIndex = 712
        Me.Label2.Text = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(160, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 25)
        Me.Label3.TabIndex = 714
        Me.Label3.Text = "4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(124, 285)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 25)
        Me.Label4.TabIndex = 713
        Me.Label4.Text = "3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 285)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 25)
        Me.Label5.TabIndex = 718
        Me.Label5.Text = "8"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(277, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 25)
        Me.Label6.TabIndex = 717
        Me.Label6.Text = "7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(238, 285)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 25)
        Me.Label7.TabIndex = 716
        Me.Label7.Text = "6"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(199, 285)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 25)
        Me.Label8.TabIndex = 715
        Me.Label8.Text = "5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(584, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 25)
        Me.Label10.TabIndex = 725
        Me.Label10.Text = "15"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(545, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 25)
        Me.Label11.TabIndex = 724
        Me.Label11.Text = "14"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(509, 285)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 25)
        Me.Label12.TabIndex = 723
        Me.Label12.Text = "13"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(467, 285)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 25)
        Me.Label13.TabIndex = 722
        Me.Label13.Text = "12"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(428, 285)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 25)
        Me.Label14.TabIndex = 721
        Me.Label14.Text = "11"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(388, 285)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 25)
        Me.Label15.TabIndex = 720
        Me.Label15.Text = "10"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(355, 285)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 25)
        Me.Label16.TabIndex = 719
        Me.Label16.Text = "9"
        '
        'tmraudio
        '
        Me.tmraudio.Enabled = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 404)
        Me.Label17.MaximumSize = New System.Drawing.Size(150, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(149, 26)
        Me.Label17.TabIndex = 742
        Me.Label17.Text = "Put Audio setting in config file for srver 2.07" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 433)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(461, 481)
        Me.TextBox1.TabIndex = 741
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'cmdL_to_Both
        '
        Me.cmdL_to_Both.Location = New System.Drawing.Point(996, 747)
        Me.cmdL_to_Both.Name = "cmdL_to_Both"
        Me.cmdL_to_Both.Size = New System.Drawing.Size(96, 22)
        Me.cmdL_to_Both.TabIndex = 740
        Me.cmdL_to_Both.Text = "Audio L_to_Both"
        Me.cmdL_to_Both.UseVisualStyleBackColor = True
        '
        'cmdR_to_Both
        '
        Me.cmdR_to_Both.Location = New System.Drawing.Point(996, 771)
        Me.cmdR_to_Both.Name = "cmdR_to_Both"
        Me.cmdR_to_Both.Size = New System.Drawing.Size(96, 22)
        Me.cmdR_to_Both.TabIndex = 739
        Me.cmdR_to_Both.Text = "Audio R_to_Both"
        Me.cmdR_to_Both.UseVisualStyleBackColor = True
        '
        'cmdrefreshmediaforaudiotest
        '
        Me.cmdrefreshmediaforaudiotest.Location = New System.Drawing.Point(491, 708)
        Me.cmdrefreshmediaforaudiotest.Name = "cmdrefreshmediaforaudiotest"
        Me.cmdrefreshmediaforaudiotest.Size = New System.Drawing.Size(89, 23)
        Me.cmdrefreshmediaforaudiotest.TabIndex = 735
        Me.cmdrefreshmediaforaudiotest.Text = "Refresh Media"
        Me.cmdrefreshmediaforaudiotest.UseVisualStyleBackColor = True
        '
        'cmbmediaforaudiotest
        '
        MySettings1.chkaspectratio = False
        MySettings1.chkautomaticreadrss = False
        MySettings1.chkautomaticupdaterss = False
        MySettings1.chkcapitalised = False
        MySettings1.chkclock = False
        MySettings1.chkclock2 = False
        MySettings1.chkltrhs1 = False
        MySettings1.chkltrhs2 = False
        MySettings1.chkmovingbackground = False
        MySettings1.chkplaylistlock = False
        MySettings1.chkPREMULTIPLY = True
        MySettings1.chkPROGRESSIVE = True
        MySettings1.chkrssdescription = False
        MySettings1.chkrsstitle = True
        MySettings1.chkshowtimeofl = False
        MySettings1.chksinglecliprecord = True
        MySettings1.chktemplateforvideo = False
        MySettings1.cmbalign = "center"
        MySettings1.cmbcapturedevices = ""
        MySettings1.cmbcasparcgwindowtitle = "Screen consumer [1|PAL]"
        MySettings1.cmbchannel = 0
        MySettings1.cmbchannel_layout = "smpte:L R C LFE Ls Rs"
        MySettings1.cmbchanneltext = "1"
        MySettings1.cmbchromacolor = "BLUE"
        MySettings1.cmbdirection = "RIGHT"
        MySettings1.cmbdirectionforppt = "LEFT"
        MySettings1.cmbfileformateoal = "cmbfileformateoal"
        MySettings1.cmbflashlayerforlogo = 41
        MySettings1.cmbflashlayerforswf = 16
        MySettings1.cmbfonths1 = "Times New Roman"
        MySettings1.cmbfonths2 = "Impact"
        MySettings1.cmbfontsforall = "Font"
        MySettings1.cmbfonttemplate = "Calibri"
        MySettings1.cmbfontvs = "Impact"
        MySettings1.cmbimageforimagescroll = "vertical"
        MySettings1.cmbimagescrollblur = 0
        MySettings1.cmbimagescrollspeed = 3
        MySettings1.cmblayerbreakingnews = 46
        MySettings1.cmblayerfacebook = "86"
        MySettings1.cmblayerhs1 = 36
        MySettings1.cmblayerhs2 = 31
        MySettings1.cmblayerhtml = "101"
        MySettings1.cmblayeronelinesuper = 61
        MySettings1.cmblayerosd = "106"
        MySettings1.cmblayerscroll = 51
        MySettings1.cmblayerSqlhtml = "201"
        MySettings1.cmblayertemplate = 96
        MySettings1.cmblayertime = 56
        MySettings1.cmblayertwitter = "81"
        MySettings1.cmblayertwolinesuper = 66
        MySettings1.cmblayervideo = 1
        MySettings1.cmblayervideo1 = "1"
        MySettings1.cmblayervideoforimage = 6
        MySettings1.cmblayervideoforppt = 11
        MySettings1.cmblayervs = 26
        MySettings1.cmblive = 2
        MySettings1.cmbliveoal = 1
        MySettings1.cmbmediaforaudiotest = "go1080p25"
        MySettings1.cmbMiscellaneous = "info 1-1"
        MySettings1.cmboscport = 6250
        MySettings1.cmbrecordformat = "mp4"
        MySettings1.cmbrssvideoflashlayer = 76
        MySettings1.cmbslowmotionrecordquality = 90
        MySettings1.cmbslowmotionrecordsubsampling = 422
        MySettings1.cmbsource1 = "decklink 1"
        MySettings1.cmbsource2 = "decklink 2"
        MySettings1.cmbsource3 = "decklink 3"
        MySettings1.cmbsource4 = "decklink 4"
        MySettings1.cmbtransition = "slide"
        MySettings1.cmbtransitionforppt = "CUT"
        MySettings1.cmbtransporttype = "Udp"
        MySettings1.cmbtweentype = "easenone"
        MySettings1.cmbtweentypeforppt = "easenone"
        MySettings1.cmbvideolayerformixer = 1
        MySettings1.cmbvideolayerfortemplate = 96
        MySettings1.cmbweathericon1videolayer = 71
        MySettings1.cmdcolor = System.Drawing.Color.Yellow
        MySettings1.cmdcolor2 = System.Drawing.Color.Yellow
        MySettings1.cmdcolorV = System.Drawing.Color.Yellow
        MySettings1.cmdstripcolor = System.Drawing.Color.DarkGreen
        MySettings1.cmdstripcolor2 = System.Drawing.Color.DarkGreen
        MySettings1.DateTimePicker1 = New Date(2014, 10, 3, 0, 0, 0, 0)
        MySettings1.decklink_live = 2
        MySettings1.labelcolorborderv = "0xFF0000"
        MySettings1.lblcolor = "0xFFFF00"
        MySettings1.lblcolor2 = "0xFFFF00"
        MySettings1.lblcolorV = "0xFFFF00"
        MySettings1.lblfilenameamcp = "Default File"
        MySettings1.lbllogofilename = "Default file"
        MySettings1.lblshedulerecordingplaylist = "filename=default"
        MySettings1.lblstripcolor = "0x005500"
        MySettings1.lblstripcolor2 = "0x005500"
        MySettings1.nchromaspread = New Decimal(New Integer() {4, 0, 0, 131072})
        MySettings1.nchromathresholdcenter = New Decimal(New Integer() {1, 0, 0, 65536})
        MySettings1.newdelemterforscrollandclock = "   *   "
        MySettings1.nfontsizeforall = 10
        MySettings1.nlogoheight = 120
        MySettings1.nlogowidth = 160
        MySettings1.nlogox = 592
        MySettings1.nlogoy = 6
        MySettings1.nmixermastervolume = New Decimal(New Integer() {10, 0, 0, 65536})
        MySettings1.nnewspeed = New Decimal(New Integer() {20, 0, 0, 65536})
        MySettings1.nopacitylogo = New Decimal(New Integer() {10, 0, 0, 65536})
        MySettings1.nrssspeed = 3
        MySettings1.nsize = 35
        MySettings1.nsize2 = 35
        MySettings1.nsizeV = 35
        MySettings1.nspeed = 6
        MySettings1.nspeed2 = 3
        MySettings1.nspeedscroll = 2.5R
        MySettings1.nspeedV = New Decimal(New Integer() {11, 0, 0, 65536})
        MySettings1.ntransitionduration = 10
        MySettings1.ntransitiondurationforppt = 10
        MySettings1.ny = 510
        MySettings1.ny2 = 410
        MySettings1.png = False
        MySettings1.rdojpg = True
        MySettings1.rss = "http://news.google.com/news?pz=1&cf=all&ned=hi_in&hl=hi&output=rss"
        MySettings1.rss_delimeter = "   *   "
        MySettings1.rss_speed = 3
        MySettings1.rss_update_interval = 10000
        MySettings1.rssdescription = True
        MySettings1.rsstitle = True
        MySettings1.SettingsKey = ""
        MySettings1.txtaccesstoken = ""
        MySettings1.txtAccesstokensecret = ""
        MySettings1.txtAccesstokentwitter = ""
        MySettings1.txtaddtemplate = 3
        MySettings1.txtanyamcpcommand = "Play 1-1 go1080p25 loop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "cg 1-2 add 2 cmp/cg_template/clock 1"
        MySettings1.txtbitrate = New Decimal(New Integer() {8, 0, 0, 0})
        MySettings1.txtbitrateofl = New Decimal(New Integer() {1, 0, 0, 0})
        MySettings1.txtbreakingnewstag0 = "xf0"
        MySettings1.txtbreakingnewstag1 = "xf1"
        MySettings1.txtbreakingnewstag2 = "xf2"
        MySettings1.txtbreakingnewsupdateinterval = 4000
        MySettings1.txtbreakingnewsvalue0 = "Breaking News"
        MySettings1.txtbreakingnewsvalue1 = "Breaking News"
        MySettings1.txtcasparcgwindowtitle = "Screen consumer [1|PAL]"
        MySettings1.txtchannelproducer = "play 2-1 route://1"
        MySettings1.txtchromakey = "MIXER 1-22 CHROMA"
        MySettings1.txtchromamixerclear = "mixer 1 clear"
        MySettings1.txtConsumerkey = ""
        MySettings1.txtConsumersecret = ""
        MySettings1.txtcrawl = "Welcome To Doordarshan . This is Horizonal scroll line 1 testing. All are welcome" &
    " to contribute."
        MySettings1.txtcrawl2 = "Welcome To Doordarshan . This is Horizonal scroll line 2 testing. All are welcome" &
    " to contribute."
        MySettings1.txtcrawlv = resources.GetString("MySettings1.txtcrawlv")
        MySettings1.txtdatetodeleteoal = 180
        MySettings1.txtdelemeterforscroll = "   *   "
        MySettings1.txtdirectshowproducer = "play 1-1"
        MySettings1.txtextraoptionoal = "-s 1280:720"
        MySettings1.txtextrarecordoptions = ""
        MySettings1.txtfilelengthofl = 1800
        MySettings1.txtfilename = "test"
        MySettings1.txtfourlinecenter1 = "A"
        MySettings1.txtfourlinecenter2 = "DDK Mumbai"
        MySettings1.txtfourlinecenter3 = "Presentation"
        MySettings1.txtfourlinecenter4 = "Live from Mumbai"
        MySettings1.txtfps = New Decimal(New Integer() {25, 0, 0, 0})
        MySettings1.txtgraphfacebook = "https://graph.facebook.com/"
        MySettings1.txthockeyip = "127.0.0.1"
        MySettings1.txthockeyport = 5250
        MySettings1.txthost = "127.0.0.1"
        MySettings1.txthostnamebadminton = "127.0.0.1"
        MySettings1.txtinterval = 3600
        MySettings1.txtlayerproducer1 = "play 1-21 go1080p25 loop"
        MySettings1.txtlayerproducer2 = "play 1-2 route://1-1"
        MySettings1.txtleftlogo = "file:///C:/Casparcg/mydata/left/clock1.swf"
        MySettings1.txtlivephonein1 = "Vimlesh Kumar from Mumbai"
        MySettings1.txtlivephonein2 = "Suresh Paswan from Patna "
        MySettings1.txtlogolocation = "file:///C:/Casparcg/mydata/logo/time.png"
        MySettings1.txtmarkin1 = 100
        MySettings1.txtmarkin2 = 100
        MySettings1.txtmarkin3 = 100
        MySettings1.txtmarkin4 = 100
        MySettings1.txtmediadirectoryoal = "H:/casparcg/_media"
        MySettings1.txtmiddle = "file:///C:/Casparcg/mydata/middle/MovieBackground1.swf"
        MySettings1.txtplaycolorbar = "play 1-22 color_bar"
        MySettings1.txtplaydecklinksm = "play 1 decklink 1"
        MySettings1.txtplayforslowmotion = "play 2-1 test-replay"
        MySettings1.txtporip = "127.0.0.1"
        MySettings1.txtporport = 5250
        MySettings1.txtport = 5250
        MySettings1.txtportbadminton = "5250"
        MySettings1.txtquery = "feed?id=casparcg"
        MySettings1.txtrecordforslowmotion = "add 1 replay test-replay"
        MySettings1.txtremovetemplate = 5
        MySettings1.txtrightlogo = "file:///C:/Casparcg/mydata/right/Royal.jpg"
        MySettings1.txtrsstimerinterval = 10000
        MySettings1.txtsearch = ""
        MySettings1.txtsearchtemplate = ""
        MySettings1.txtslowmotionmaxframe = 10000
        MySettings1.txtsqldatabase = "lto"
        MySettings1.txtsqlpassword = "ddkm"
        MySettings1.txtsqlport = "3306"
        MySettings1.txtsqlserver = "localhost\sqlexpress"
        MySettings1.txtsqluser = "hp"
        MySettings1.txtstoprecordforslowmotion = "remove 1 replay"
        MySettings1.txtstreamingcosumer = "ADD 1 STREAM udp://localhost:5004 -codec:v libx264 -tune:v zerolatency -preset:v " &
    "ultrafast -crf 25 -format mpegts -vf scale=240:180"
        MySettings1.txtstreamingproducer = "play 1-1 ""http://localhost:8080/"""
        MySettings1.txtthreelinecenter1 = "A"
        MySettings1.txtthreelinecenter2 = "DDK MUMBAI"
        MySettings1.txtthreelinecenter3 = "PRESENTATION"
        MySettings1.txttopleft = "Live From Mumbai"
        MySettings1.txttopright = "Recorded"
        MySettings1.txttwolinecenter1 = "Next Program"
        MySettings1.txttwolinecenter2 = "Discovery of India(Jawaharlal Nehru)"
        MySettings1.txturlhtml = "file:///C:/casparcg/CMP/games/HtmlCricket/cricket_bottom_score/gwd_preview_cricke" &
    "t_bottom_score/index.html"
        MySettings1.txtvideoheight = 576
        MySettings1.txtvideowidth = 768
        MySettings1.Vborercolor = System.Drawing.Color.Red
        MySettings1.xdcamaddress1 = "http://192.168.20.54/webservice/"
        MySettings1.xdcampassword = "xds-pd1000"
        MySettings1.xdcamusername = "admin"
        Me.cmbmediaforaudiotest.DataBindings.Add(New System.Windows.Forms.Binding("Text", MySettings1, "cmbmediaforaudiotest", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cmbmediaforaudiotest.FormattingEnabled = True
        Me.cmbmediaforaudiotest.Location = New System.Drawing.Point(586, 710)
        Me.cmbmediaforaudiotest.Name = "cmbmediaforaudiotest"
        Me.cmbmediaforaudiotest.Size = New System.Drawing.Size(194, 21)
        Me.cmbmediaforaudiotest.TabIndex = 738
        Me.cmbmediaforaudiotest.Text = "go1080p25"
        '
        'cmdaudiotest
        '
        Me.cmdaudiotest.Location = New System.Drawing.Point(997, 710)
        Me.cmdaudiotest.Name = "cmdaudiotest"
        Me.cmdaudiotest.Size = New System.Drawing.Size(95, 23)
        Me.cmdaudiotest.TabIndex = 737
        Me.cmdaudiotest.Text = "Audio Test"
        Me.cmdaudiotest.UseVisualStyleBackColor = True
        '
        'cmbchannel_layout
        '
        Me.cmbchannel_layout.DataBindings.Add(New System.Windows.Forms.Binding("Text", MySettings1, "cmbchannel_layout", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cmbchannel_layout.FormattingEnabled = True
        Me.cmbchannel_layout.Items.AddRange(New Object() {"mono:C", "stereo:L R", "dts:C L R Ls Rs LFE", "dolbye:L R C LFE Ls Rs Lmix Rmix", "dolbydigital:L C R Ls Rs LFE", "smpte:L R C LFE Ls Rs", "passthru", "", "", "matrix", "film", "ebu_r123_8a", "ebu_r123_8b", "8ch", "16ch"})
        Me.cmbchannel_layout.Location = New System.Drawing.Point(786, 710)
        Me.cmbchannel_layout.Name = "cmbchannel_layout"
        Me.cmbchannel_layout.Size = New System.Drawing.Size(205, 21)
        Me.cmbchannel_layout.TabIndex = 736
        Me.cmbchannel_layout.Text = "smpte:L R C LFE Ls Rs"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(513, 739)
        Me.Label18.MaximumSize = New System.Drawing.Size(150, 0)
        Me.Label18.MinimumSize = New System.Drawing.Size(150, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(150, 39)
        Me.Label18.TabIndex = 744
        Me.Label18.Text = "Put Audio setting in config file for srver 2.1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(479, 784)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(503, 130)
        Me.TextBox2.TabIndex = 743
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'cmdMix
        '
        Me.cmdMix.Location = New System.Drawing.Point(996, 799)
        Me.cmdMix.Name = "cmdMix"
        Me.cmdMix.Size = New System.Drawing.Size(96, 22)
        Me.cmdMix.TabIndex = 745
        Me.cmdMix.Text = "Audio Mix"
        Me.cmdMix.UseVisualStyleBackColor = True
        '
        'cmdOnly_L
        '
        Me.cmdOnly_L.Location = New System.Drawing.Point(996, 827)
        Me.cmdOnly_L.Name = "cmdOnly_L"
        Me.cmdOnly_L.Size = New System.Drawing.Size(96, 22)
        Me.cmdOnly_L.TabIndex = 746
        Me.cmdOnly_L.Text = "Audio Only_L"
        Me.cmdOnly_L.UseVisualStyleBackColor = True
        '
        'cmdOnly_R
        '
        Me.cmdOnly_R.Location = New System.Drawing.Point(996, 855)
        Me.cmdOnly_R.Name = "cmdOnly_R"
        Me.cmdOnly_R.Size = New System.Drawing.Size(96, 22)
        Me.cmdOnly_R.TabIndex = 747
        Me.cmdOnly_R.Text = "Audio Only_R"
        Me.cmdOnly_R.UseVisualStyleBackColor = True
        '
        'tbAudioControl0
        '
        Me.tbAudioControl0.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl0.Location = New System.Drawing.Point(26, 13)
        Me.tbAudioControl0.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl0.Name = "tbAudioControl0"
        Me.tbAudioControl0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl0.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl0.TabIndex = 748
        Me.tbAudioControl0.TickFrequency = 10
        Me.tbAudioControl0.Value = 10
        '
        'cmbAudioControl0
        '
        Me.cmbAudioControl0.FormattingEnabled = True
        Me.cmbAudioControl0.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl0.Location = New System.Drawing.Point(24, 270)
        Me.cmbAudioControl0.Name = "cmbAudioControl0"
        Me.cmbAudioControl0.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl0.TabIndex = 749
        Me.cmbAudioControl0.Text = "c0"
        '
        'cmbAudioControl1
        '
        Me.cmbAudioControl1.FormattingEnabled = True
        Me.cmbAudioControl1.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl1.Location = New System.Drawing.Point(81, 270)
        Me.cmbAudioControl1.Name = "cmbAudioControl1"
        Me.cmbAudioControl1.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl1.TabIndex = 751
        Me.cmbAudioControl1.Text = "c1"
        '
        'tbAudioControl1
        '
        Me.tbAudioControl1.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl1.Location = New System.Drawing.Point(80, 13)
        Me.tbAudioControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl1.Name = "tbAudioControl1"
        Me.tbAudioControl1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl1.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl1.TabIndex = 750
        Me.tbAudioControl1.TickFrequency = 10
        Me.tbAudioControl1.Value = 10
        '
        'cmbAudioControl3
        '
        Me.cmbAudioControl3.FormattingEnabled = True
        Me.cmbAudioControl3.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl3.Location = New System.Drawing.Point(197, 270)
        Me.cmbAudioControl3.Name = "cmbAudioControl3"
        Me.cmbAudioControl3.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl3.TabIndex = 755
        Me.cmbAudioControl3.Text = "c3"
        '
        'tbAudioControl3
        '
        Me.tbAudioControl3.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl3.Location = New System.Drawing.Point(197, 13)
        Me.tbAudioControl3.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl3.Name = "tbAudioControl3"
        Me.tbAudioControl3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl3.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl3.TabIndex = 754
        Me.tbAudioControl3.TickFrequency = 10
        Me.tbAudioControl3.Value = 10
        '
        'cmbAudioControl2
        '
        Me.cmbAudioControl2.FormattingEnabled = True
        Me.cmbAudioControl2.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl2.Location = New System.Drawing.Point(140, 270)
        Me.cmbAudioControl2.Name = "cmbAudioControl2"
        Me.cmbAudioControl2.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl2.TabIndex = 753
        Me.cmbAudioControl2.Text = "c2"
        '
        'cmbAudioControl7
        '
        Me.cmbAudioControl7.FormattingEnabled = True
        Me.cmbAudioControl7.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl7.Location = New System.Drawing.Point(420, 270)
        Me.cmbAudioControl7.Name = "cmbAudioControl7"
        Me.cmbAudioControl7.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl7.TabIndex = 763
        Me.cmbAudioControl7.Text = "c7"
        '
        'tbAudioControl7
        '
        Me.tbAudioControl7.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl7.Location = New System.Drawing.Point(420, 13)
        Me.tbAudioControl7.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl7.Name = "tbAudioControl7"
        Me.tbAudioControl7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl7.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl7.TabIndex = 762
        Me.tbAudioControl7.TickFrequency = 10
        Me.tbAudioControl7.Value = 10
        '
        'cmbAudioControl6
        '
        Me.cmbAudioControl6.FormattingEnabled = True
        Me.cmbAudioControl6.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl6.Location = New System.Drawing.Point(363, 270)
        Me.cmbAudioControl6.Name = "cmbAudioControl6"
        Me.cmbAudioControl6.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl6.TabIndex = 761
        Me.cmbAudioControl6.Text = "c6"
        '
        'cmbAudioControl5
        '
        Me.cmbAudioControl5.FormattingEnabled = True
        Me.cmbAudioControl5.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl5.Location = New System.Drawing.Point(304, 270)
        Me.cmbAudioControl5.Name = "cmbAudioControl5"
        Me.cmbAudioControl5.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl5.TabIndex = 759
        Me.cmbAudioControl5.Text = "c5"
        '
        'tbAudioControl5
        '
        Me.tbAudioControl5.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl5.Location = New System.Drawing.Point(304, 13)
        Me.tbAudioControl5.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl5.Name = "tbAudioControl5"
        Me.tbAudioControl5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl5.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl5.TabIndex = 758
        Me.tbAudioControl5.TickFrequency = 10
        Me.tbAudioControl5.Value = 10
        '
        'cmbAudioControl4
        '
        Me.cmbAudioControl4.FormattingEnabled = True
        Me.cmbAudioControl4.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl4.Location = New System.Drawing.Point(247, 270)
        Me.cmbAudioControl4.Name = "cmbAudioControl4"
        Me.cmbAudioControl4.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl4.TabIndex = 757
        Me.cmbAudioControl4.Text = "c4"
        '
        'tbAudioControl2
        '
        Me.tbAudioControl2.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl2.Location = New System.Drawing.Point(134, 13)
        Me.tbAudioControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl2.Name = "tbAudioControl2"
        Me.tbAudioControl2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl2.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl2.TabIndex = 764
        Me.tbAudioControl2.TickFrequency = 10
        Me.tbAudioControl2.Value = 10
        '
        'tbAudioControl4
        '
        Me.tbAudioControl4.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl4.Location = New System.Drawing.Point(246, 13)
        Me.tbAudioControl4.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl4.Name = "tbAudioControl4"
        Me.tbAudioControl4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl4.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl4.TabIndex = 765
        Me.tbAudioControl4.TickFrequency = 10
        Me.tbAudioControl4.Value = 10
        '
        'tbAudioControl6
        '
        Me.tbAudioControl6.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl6.Location = New System.Drawing.Point(366, 13)
        Me.tbAudioControl6.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl6.Name = "tbAudioControl6"
        Me.tbAudioControl6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl6.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl6.TabIndex = 766
        Me.tbAudioControl6.TickFrequency = 10
        Me.tbAudioControl6.Value = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSalmon
        Me.GroupBox1.Controls.Add(Me.tbAudioControl6)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl4)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl2)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl7)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl7)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl6)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl5)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl5)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl4)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl3)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl3)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl2)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl1)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl1)
        Me.GroupBox1.Controls.Add(Me.cmbAudioControl0)
        Me.GroupBox1.Controls.Add(Me.tbAudioControl0)
        Me.GroupBox1.Location = New System.Drawing.Point(644, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 296)
        Me.GroupBox1.TabIndex = 767
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "For Server 2.3"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightSalmon
        Me.GroupBox2.Controls.Add(Me.tbAudioControl14)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl12)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl10)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl15)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl15)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl14)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl13)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl13)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl12)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl11)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl11)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl10)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl9)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl9)
        Me.GroupBox2.Controls.Add(Me.cmbAudioControl8)
        Me.GroupBox2.Controls.Add(Me.tbAudioControl8)
        Me.GroupBox2.Location = New System.Drawing.Point(644, 315)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(497, 296)
        Me.GroupBox2.TabIndex = 768
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "For Server 2.5"
        '
        'tbAudioControl14
        '
        Me.tbAudioControl14.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl14.Location = New System.Drawing.Point(366, 13)
        Me.tbAudioControl14.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl14.Name = "tbAudioControl14"
        Me.tbAudioControl14.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl14.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl14.TabIndex = 766
        Me.tbAudioControl14.TickFrequency = 10
        Me.tbAudioControl14.Value = 10
        '
        'tbAudioControl12
        '
        Me.tbAudioControl12.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl12.Location = New System.Drawing.Point(246, 13)
        Me.tbAudioControl12.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl12.Name = "tbAudioControl12"
        Me.tbAudioControl12.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl12.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl12.TabIndex = 765
        Me.tbAudioControl12.TickFrequency = 10
        Me.tbAudioControl12.Value = 10
        '
        'tbAudioControl10
        '
        Me.tbAudioControl10.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl10.Location = New System.Drawing.Point(134, 13)
        Me.tbAudioControl10.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl10.Name = "tbAudioControl10"
        Me.tbAudioControl10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl10.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl10.TabIndex = 764
        Me.tbAudioControl10.TickFrequency = 10
        Me.tbAudioControl10.Value = 10
        '
        'cmbAudioControl15
        '
        Me.cmbAudioControl15.FormattingEnabled = True
        Me.cmbAudioControl15.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl15.Location = New System.Drawing.Point(422, 270)
        Me.cmbAudioControl15.Name = "cmbAudioControl15"
        Me.cmbAudioControl15.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl15.TabIndex = 763
        Me.cmbAudioControl15.Text = "c7"
        '
        'tbAudioControl15
        '
        Me.tbAudioControl15.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl15.Location = New System.Drawing.Point(420, 13)
        Me.tbAudioControl15.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl15.Name = "tbAudioControl15"
        Me.tbAudioControl15.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl15.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl15.TabIndex = 762
        Me.tbAudioControl15.TickFrequency = 10
        Me.tbAudioControl15.Value = 10
        '
        'cmbAudioControl14
        '
        Me.cmbAudioControl14.FormattingEnabled = True
        Me.cmbAudioControl14.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl14.Location = New System.Drawing.Point(365, 270)
        Me.cmbAudioControl14.Name = "cmbAudioControl14"
        Me.cmbAudioControl14.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl14.TabIndex = 761
        Me.cmbAudioControl14.Text = "c6"
        '
        'cmbAudioControl13
        '
        Me.cmbAudioControl13.FormattingEnabled = True
        Me.cmbAudioControl13.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl13.Location = New System.Drawing.Point(306, 270)
        Me.cmbAudioControl13.Name = "cmbAudioControl13"
        Me.cmbAudioControl13.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl13.TabIndex = 759
        Me.cmbAudioControl13.Text = "c5"
        '
        'tbAudioControl13
        '
        Me.tbAudioControl13.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl13.Location = New System.Drawing.Point(304, 13)
        Me.tbAudioControl13.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl13.Name = "tbAudioControl13"
        Me.tbAudioControl13.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl13.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl13.TabIndex = 758
        Me.tbAudioControl13.TickFrequency = 10
        Me.tbAudioControl13.Value = 10
        '
        'cmbAudioControl12
        '
        Me.cmbAudioControl12.FormattingEnabled = True
        Me.cmbAudioControl12.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl12.Location = New System.Drawing.Point(249, 270)
        Me.cmbAudioControl12.Name = "cmbAudioControl12"
        Me.cmbAudioControl12.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl12.TabIndex = 757
        Me.cmbAudioControl12.Text = "c4"
        '
        'cmbAudioControl11
        '
        Me.cmbAudioControl11.FormattingEnabled = True
        Me.cmbAudioControl11.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl11.Location = New System.Drawing.Point(199, 270)
        Me.cmbAudioControl11.Name = "cmbAudioControl11"
        Me.cmbAudioControl11.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl11.TabIndex = 755
        Me.cmbAudioControl11.Text = "c3"
        '
        'tbAudioControl11
        '
        Me.tbAudioControl11.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl11.Location = New System.Drawing.Point(197, 13)
        Me.tbAudioControl11.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl11.Name = "tbAudioControl11"
        Me.tbAudioControl11.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl11.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl11.TabIndex = 754
        Me.tbAudioControl11.TickFrequency = 10
        Me.tbAudioControl11.Value = 10
        '
        'cmbAudioControl10
        '
        Me.cmbAudioControl10.FormattingEnabled = True
        Me.cmbAudioControl10.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl10.Location = New System.Drawing.Point(142, 270)
        Me.cmbAudioControl10.Name = "cmbAudioControl10"
        Me.cmbAudioControl10.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl10.TabIndex = 753
        Me.cmbAudioControl10.Text = "c2"
        '
        'cmbAudioControl9
        '
        Me.cmbAudioControl9.FormattingEnabled = True
        Me.cmbAudioControl9.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl9.Location = New System.Drawing.Point(83, 270)
        Me.cmbAudioControl9.Name = "cmbAudioControl9"
        Me.cmbAudioControl9.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl9.TabIndex = 751
        Me.cmbAudioControl9.Text = "c1"
        '
        'tbAudioControl9
        '
        Me.tbAudioControl9.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl9.Location = New System.Drawing.Point(80, 13)
        Me.tbAudioControl9.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl9.Name = "tbAudioControl9"
        Me.tbAudioControl9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl9.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl9.TabIndex = 750
        Me.tbAudioControl9.TickFrequency = 10
        Me.tbAudioControl9.Value = 10
        '
        'cmbAudioControl8
        '
        Me.cmbAudioControl8.FormattingEnabled = True
        Me.cmbAudioControl8.Items.AddRange(New Object() {"c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"})
        Me.cmbAudioControl8.Location = New System.Drawing.Point(26, 270)
        Me.cmbAudioControl8.Name = "cmbAudioControl8"
        Me.cmbAudioControl8.Size = New System.Drawing.Size(45, 21)
        Me.cmbAudioControl8.TabIndex = 749
        Me.cmbAudioControl8.Text = "c0"
        '
        'tbAudioControl8
        '
        Me.tbAudioControl8.BackColor = System.Drawing.SystemColors.Control
        Me.tbAudioControl8.Location = New System.Drawing.Point(26, 13)
        Me.tbAudioControl8.Margin = New System.Windows.Forms.Padding(0)
        Me.tbAudioControl8.Name = "tbAudioControl8"
        Me.tbAudioControl8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudioControl8.Size = New System.Drawing.Size(45, 254)
        Me.tbAudioControl8.TabIndex = 748
        Me.tbAudioControl8.TickFrequency = 10
        Me.tbAudioControl8.Value = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 25)
        Me.Label9.TabIndex = 769
        Me.Label9.Text = "0"
        '
        'ucdBFSMeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.ClientSize = New System.Drawing.Size(1208, 921)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOnly_R)
        Me.Controls.Add(Me.cmdOnly_L)
        Me.Controls.Add(Me.cmdMix)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdL_to_Both)
        Me.Controls.Add(Me.cmdR_to_Both)
        Me.Controls.Add(Me.cmdrefreshmediaforaudiotest)
        Me.Controls.Add(Me.cmbmediaforaudiotest)
        Me.Controls.Add(Me.cmdaudiotest)
        Me.Controls.Add(Me.cmbchannel_layout)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblucdbfmeter)
        Me.Controls.Add(Me.DBFS_Meter16)
        Me.Controls.Add(Me.DBFS_Meter15)
        Me.Controls.Add(Me.DBFS_Meter14)
        Me.Controls.Add(Me.DBFS_Meter13)
        Me.Controls.Add(Me.DBFS_Meter12)
        Me.Controls.Add(Me.DBFS_Meter11)
        Me.Controls.Add(Me.DBFS_Meter10)
        Me.Controls.Add(Me.DBFS_Meter9)
        Me.Controls.Add(Me.DBFS_Meter8)
        Me.Controls.Add(Me.DBFS_Meter7)
        Me.Controls.Add(Me.DBFS_Meter6)
        Me.Controls.Add(Me.DBFS_Meter5)
        Me.Controls.Add(Me.DBFS_Meter4)
        Me.Controls.Add(Me.DBFS_Meter3)
        Me.Controls.Add(Me.DBFS_Meter2)
        Me.Controls.Add(Me.DBFS_Meter1)
        Me.HideOnClose = True
        Me.Name = "ucdBFSMeter"
        Me.Text = "16 Channel dBFS Meter"
        AddHandler Load, AddressOf Me.ucdBFSMeter_Load_1
        CType(Me.DBFS_Meter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBFS_Meter16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tbAudioControl14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAudioControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DBFS_Meter1 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter2 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter3 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter4 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter5 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter6 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter7 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter8 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter9 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter10 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter11 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter12 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter13 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter14 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter15 As dBFS_Meter.dBFS_Meter
    Friend WithEvents DBFS_Meter16 As dBFS_Meter.dBFS_Meter
    Friend WithEvents lblucdbfmeter As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents tmraudio As Timer
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmdL_to_Both As Button
    Friend WithEvents cmdR_to_Both As Button
    Friend WithEvents cmdrefreshmediaforaudiotest As Button
    Friend WithEvents cmbmediaforaudiotest As ComboBox
    Friend WithEvents cmdaudiotest As Button
    Friend WithEvents cmbchannel_layout As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents cmdMix As Button
    Friend WithEvents cmdOnly_L As Button
    Friend WithEvents cmdOnly_R As Button
    Friend WithEvents tbAudioControl0 As TrackBar
    Friend WithEvents cmbAudioControl0 As ComboBox
    Friend WithEvents cmbAudioControl1 As ComboBox
    Friend WithEvents tbAudioControl1 As TrackBar
    Friend WithEvents cmbAudioControl3 As ComboBox
    Friend WithEvents tbAudioControl3 As TrackBar
    Friend WithEvents cmbAudioControl2 As ComboBox
    Friend WithEvents cmbAudioControl7 As ComboBox
    Friend WithEvents tbAudioControl7 As TrackBar
    Friend WithEvents cmbAudioControl6 As ComboBox
    Friend WithEvents cmbAudioControl5 As ComboBox
    Friend WithEvents tbAudioControl5 As TrackBar
    Friend WithEvents cmbAudioControl4 As ComboBox
    Friend WithEvents tbAudioControl2 As TrackBar
    Friend WithEvents tbAudioControl4 As TrackBar
    Friend WithEvents tbAudioControl6 As TrackBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbAudioControl14 As TrackBar
    Friend WithEvents tbAudioControl12 As TrackBar
    Friend WithEvents tbAudioControl10 As TrackBar
    Friend WithEvents cmbAudioControl15 As ComboBox
    Friend WithEvents tbAudioControl15 As TrackBar
    Friend WithEvents cmbAudioControl14 As ComboBox
    Friend WithEvents cmbAudioControl13 As ComboBox
    Friend WithEvents tbAudioControl13 As TrackBar
    Friend WithEvents cmbAudioControl12 As ComboBox
    Friend WithEvents cmbAudioControl11 As ComboBox
    Friend WithEvents tbAudioControl11 As TrackBar
    Friend WithEvents cmbAudioControl10 As ComboBox
    Friend WithEvents cmbAudioControl9 As ComboBox
    Friend WithEvents tbAudioControl9 As TrackBar
    Friend WithEvents cmbAudioControl8 As ComboBox
    Friend WithEvents tbAudioControl8 As TrackBar
    Friend WithEvents Label9 As Label
End Class
