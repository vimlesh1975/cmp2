Imports System.IO

Public Class UcCommandSchedulerDateWise

    Private Const SchedulerFolderPath As String = "c:\casparcg\mydata\scheduler_datewise\"
    Private Const CommandSeparator As String = ",,"
    Private Const RowSeparator As String = Chr(2)
    Private Const DateWiseFormat As String = "dd-MM-yyyy HH:mm:ss"

    'Dim g_int_ChannelNumber As Integer = 1
    Dim ofd2 As New OpenFileDialog
    Dim osd2 As New SaveFileDialog
    Dim startingtimeofrecordingoal As DateTime

    Public Function IntervalTill(ByVal d As DateTime) As Integer
        On Error Resume Next
        Dim Difference As TimeSpan = d.Subtract(Now)
        Return Difference.TotalMilliseconds
    End Function

    Private Sub InitializeSchedulerColumns()
        Dim col1 As New CalendarColumnDateWise()
        Dim col3 As New DataGridViewTextBoxColumn
        Dim col4 As New DataGridViewTextBoxColumn

        col1.HeaderText = "Start Time"
        col1.Width = 200
        col3.HeaderText = "Tick Time (ms)"
        col4.HeaderText = "Command"
        col4.Width = 2000

        With dgvscheduler
            .Columns.Add(col1)
            .Columns.Add(col3)
            .Columns.Add(col4)
            col3.Frozen = True
            col3.ReadOnly = True
            col3.Width = 0
        End With
    End Sub

    Private Sub ResetScheduler(Optional labelText As String = "new")
        dgvscheduler.Rows.Clear()
        lblscheduleList.Text = "Sheduler= " & labelText
    End Sub

    Private Sub AddSchedulerRow(startTime As DateTime, commandText As String)
        Dim rowIndex = dgvscheduler.Rows.Add()
        dgvscheduler.Rows(rowIndex).Cells(0).Value = startTime
        dgvscheduler.Rows(rowIndex).Cells(2).Value = commandText
    End Sub

    Private Sub LoadDefaultScheduleRows()
        AddSchedulerRow(Now.AddSeconds(10), "play 1-1 amb loop,,mixer 1-2 fill .5 .2 .3 .6,, play 1-2 red,, mixer 1-2 opacity 0.5")
        AddSchedulerRow(Now.AddSeconds(30), "stop 1-1,,stop 1-2,, mixer 1 clear")
        AddSchedulerRow(Now.AddSeconds(50), "play 1-1 go1080p25 loop")
        AddSchedulerRow(Now.AddSeconds(70), "stop 1-1")
    End Sub

    Private Function ShowSchedulerOpenDialog() As Boolean
        ofd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ofd2.InitialDirectory = SchedulerFolderPath
        Return ofd2.ShowDialog() = Windows.Forms.DialogResult.OK
    End Function

    Private Function ShowSchedulerSaveDialog() As Boolean
        osd2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        osd2.InitialDirectory = SchedulerFolderPath
        osd2.FileName = ""
        Return osd2.ShowDialog() = Windows.Forms.DialogResult.OK
    End Function

    Private Sub LoadScheduleFromFile(fileName As String)
        ResetScheduler()

        Using sr As New StreamReader(fileName)
            Do Until sr.EndOfStream = True
                Dim line = sr.ReadLine()
                Dim values As Array = Split(line, RowSeparator)
                If values.Length > 1 Then
                    AddSchedulerRow(CDate(values(0)), values(1).ToString())
                End If
            Loop
        End Using

        lblscheduleList.Text = "Shedule= " & fileName
    End Sub

    Private Sub SaveScheduleToFile(fileName As String)
        Using sw As New StreamWriter(fileName)
            If dgvscheduler.Rows.Count = 0 Then
                sw.Write("")
            Else
                For rowIndex = 0 To dgvscheduler.Rows.Count - 1
                    sw.WriteLine(Format(CType(dgvscheduler.Rows(rowIndex).Cells(0).Value, DateTime), DateWiseFormat) & RowSeparator & dgvscheduler.Rows(rowIndex).Cells(2).Value)
                Next
            End If
        End Using

        lblscheduleList.Text = "Shedule=  " & fileName
    End Sub

    Private Sub ExecuteSchedulerCommand(commandText As String)
        Dim commands() = Split(commandText, CommandSeparator)
        For commandIndex = 0 To commands.Count - 1
            CasparDevice.SendString(commands(commandIndex))
        Next
    End Sub

    Private Sub StartScheduler()
        sortschedule()
        tmrcommandschedulestart.Interval = IntervalTill(CType(dgvscheduler.Rows(0).Cells(0).Value, DateTime))
        tmrcommandschedulestart.Enabled = True
        lbltestshedulerecording.Text = "Sheduled Started"
        lbltestshedulerecording.BackColor = Color.Green
    End Sub

    Private Sub StopScheduler()
        tmrcommandschedulestart.Enabled = False
        lbltestshedulerecording.Text = "Schedule Stoped"
        lbltestshedulerecording.BackColor = Color.Red
    End Sub

    Sub sortschedule()
        On Error Resume Next
        With dgvscheduler
            For iticktime = 0 To .Rows.Count - 1
                .Rows(iticktime).Cells(1).Value = IntervalTill(CType(.Rows(iticktime).Cells(0).Value, DateTime))
            Next
            For iticktime = .Rows.Count - 1 To 0 Step -1
                If .Rows(iticktime).Cells(1).Value < 0 Then
                    .Rows.RemoveAt(iticktime)
                End If
            Next

            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            .CurrentCell = .Rows(0).Cells(0)
        End With
    End Sub

    Private Sub UcCommandScheduler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialisedataforscheduler()
    End Sub
    Sub initialisedataforscheduler()
        On Error Resume Next
        InitializeSchedulerColumns()
        LoadDefaultScheduleRows()
    End Sub

    Private Sub cmdStartSchedule_Click(sender As Object, e As EventArgs) Handles cmdStartSchedule.Click
        On Error Resume Next
        StartScheduler()
    End Sub

    Private Sub tmrcommandschedulestart_Tick(sender As Object, e As EventArgs) Handles tmrcommandschedulestart.Tick
        On Error Resume Next
        ExecuteSchedulerCommand(dgvscheduler.Rows(0).Cells(2).Value.ToString())
        startingtimeofrecordingoal = Now
        sortschedule()
        tmrcommandschedulestart.Interval = IntervalTill(CType(dgvscheduler.Rows(0).Cells(0).Value, DateTime))
    End Sub

    Private Sub cmdStopSchedule_Click(sender As Object, e As EventArgs) Handles cmdStopSchedule.Click
        StopScheduler()
    End Sub

    Private Sub newtsschedule_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        ResetScheduler()
    End Sub

    Private Sub opentsschedule_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        If ShowSchedulerOpenDialog() Then
            LoadScheduleFromFile(ofd2.FileName)
        End If
    End Sub

    Private Sub savetsschedule_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub addschedule_Click(sender As Object, e As EventArgs) Handles addschedule.Click
        On Error Resume Next
        With dgvscheduler
            .Rows.Insert(.CurrentRow.Index)
            .Rows(.CurrentRow.Index - 1).Cells(0).Value = Now
        End With
    End Sub

    Private Sub deleteschedule_Click(sender As Object, e As EventArgs) Handles deleteschedule.Click
        On Error Resume Next
        With dgvscheduler
            .Rows.RemoveAt(.CurrentRow.Index)
        End With
    End Sub

    Private Sub cmdhideCommandSheduler_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub cmdmanualPlaycmdPlayNoe_Click(sender As Object, e As EventArgs) Handles cmdmanualPlaycmdPlayNoe.Click
        ExecuteSchedulerCommand(dgvscheduler.CurrentRow.Cells(2).Value.ToString())
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        ResetScheduler()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        If ShowSchedulerOpenDialog() Then
            LoadScheduleFromFile(ofd2.FileName)
        End If
    End Sub
    Private Sub MenuStrip1_MouseHover(sender As Object, e As EventArgs) Handles MenuStrip1.MouseHover
        MakeMenuDropDownWhenParrented(sender)
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        If ShowSchedulerSaveDialog() Then
            SaveScheduleToFile(osd2.FileName)
        End If
    End Sub
End Class
