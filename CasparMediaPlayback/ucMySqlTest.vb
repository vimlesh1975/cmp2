Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Public Class ucMySqlTest
    Private Const SqlServerType As String = "SQL"
    Private Const MySqlServerType As String = "MySql"
    Private Const CasparHtmlPath As String = "C:\casparcg\mydata\MySqlToCasparcg\html1.html"

    Dim conn
    Dim servertype As String

    Private Sub cmdsetserver_Click(sender As Object, e As EventArgs) Handles cmdsetserver.Click
        SetConnection(New SqlConnection With {
            .ConnectionString = "server=" & txtserver.Text & ";user=" & txtuser.Text & ";database=" & txtdatabase.Text & ";password=" & txtpassword.Text & ";integrated security=" & chkIntegratedSecurity.Checked},
            SqlServerType)
    End Sub

    Private Sub cmdFillTablenames_Click(sender As Object, e As EventArgs) Handles cmdFillTablenames.Click
        Try
            conn.Open()
            Dim dt = conn.GetSchema("TABLES")
            cmbTables.DataSource = dt
            cmbTables.DisplayMember = "table_name"
            cmbTables.ValueMember = "table_name"
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmdShowContents_Click(sender As Object, e As EventArgs) Handles cmdShowContents.Click
        Try
            conn.Open()
            Dim adp = CreateDataAdapter("Select * from " & GetQuotedTableName(cmbTables.Text) & ";")
            Dim ds As DataSet = New DataSet()
            adp.Fill(ds)
            dgvContents.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ucMySqlTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enumeratefontsforall()
    End Sub

    Sub enumeratefontsforall()
        On Error Resume Next
        Dim InstalledFonts As New Drawing.Text.InstalledFontCollection
        Dim fontfamilies() As FontFamily = InstalledFonts.Families()
        For Each fontFamily As FontFamily In fontfamilies
            cmbfontsql.Items.Add(fontFamily.Name)
        Next
    End Sub

    Private Sub cmdhideMySqlTest_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Sub executequery(aa As String)
        Try
            conn.Open()
            Dim sqlc = CreateCommand(aa)
            sqlc.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmdInsert_Click(sender As Object, e As EventArgs) Handles cmdInsert.Click
        executequery(txtInsert.Text)
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        executequery(txtDelete.Text)
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        executequery(txtUpdate.Text)
    End Sub

    Private Sub cmdAny_Click(sender As Object, e As EventArgs) Handles cmdAny.Click
        executequery(txtAnyCommand.Text)
    End Sub

    Private Sub cmdShowincasparcg_Click(sender As Object, e As EventArgs) Handles cmdShowincasparcg.Click
        Dim rowCount As Integer = GetVisibleRowCount()
        Dim columnCount As Integer = GetVisibleColumnCount()
        Dim htmlTable As String = BuildHtmlTable(rowCount, columnCount)

        CreatePage("html1", htmlTable, CasparHtmlPath)
        CasparDevice.SendString("play " & g_int_ChannelNumber & "-" & cmblayerSqlhtml.Text & " [HTML] file:///" & Replace(CasparHtmlPath, "\", "/"))
    End Sub

    Public Sub CreatePage(ByVal HTMLTitle As String, ByVal HTMLText As String, ByVal HTMLFileName As String)
        Dim strFile As String
        strFile = "<!DOCTYPE html>" & vbNewLine
        strFile = "<html>" & vbNewLine
        strFile = strFile & "<head>" & vbNewLine
        strFile = strFile & "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>"
        strFile = strFile & "</head>" & vbNewLine & "<body>" & vbNewLine
        strFile = strFile & "<div style ='transform: translate(0px, 300px)'>" & vbNewLine
        strFile = strFile & HTMLText & vbNewLine
        strFile = strFile & "</div>" & vbNewLine
        strFile = strFile & "</body>" & vbNewLine & "</html>"

        Dim aa As IO.StreamWriter = New IO.StreamWriter(HTMLFileName)
        aa.Write(strFile)
        aa.Close()
    End Sub

    Private Sub cmdStopSqlLayer_Click(sender As Object, e As EventArgs) Handles cmdStopSqlLayer.Click
        On Error Resume Next
        CasparDevice.SendString("stop " & g_int_ChannelNumber & "-" & cmblayerSqlhtml.Text)
    End Sub

    Private Sub cmdbgcolorsql_Click(sender As Object, e As EventArgs) Handles cmdbgcolorsql.Click
        ApplySelectedColor(AddressOf ApplyBackgroundColor)
    End Sub

    Private Sub cmdfontcolorsql_Click(sender As Object, e As EventArgs) Handles cmdfontcolorsql.Click
        ApplySelectedColor(AddressOf ApplyFontColor)
    End Sub

    Private Sub cmdSetServerMySql_Click(sender As Object, e As EventArgs) Handles cmdSetServerMySql.Click
        SetConnection(New MySqlConnection With {
            .ConnectionString = "server=" & txtservermysql.Text & ";user=" & txtusemysql.Text & ";database=" & txtdatabasemysql.Text & ";port=" & txtport.Text & ";password=" & txtpasswordMysql.Text},
            MySqlServerType)
    End Sub

    Private Sub SetConnection(connectionObject As Object, serverTypeValue As String)
        Try
            conn = connectionObject
            servertype = serverTypeValue
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Function CreateDataAdapter(query As String) As Object
        If servertype = MySqlServerType Then
            Return New MySqlDataAdapter(query, CType(conn, MySqlConnection))
        End If

        Return New SqlDataAdapter(query, CType(conn, SqlConnection))
    End Function

    Private Function CreateCommand(query As String) As Object
        If servertype = MySqlServerType Then
            Return New MySqlCommand With {
                .Connection = CType(conn, MySqlConnection),
                .CommandText = query}
        End If

        Return New SqlCommand With {
            .Connection = CType(conn, SqlConnection),
            .CommandText = query}
    End Function

    Private Function GetQuotedTableName(tableName As String) As String
        If servertype = MySqlServerType Then
            Return "`" & tableName & "`"
        End If

        Return """" & tableName & """"
    End Function

    Private Function GetVisibleRowCount() As Integer
        If chkAllRow.Checked Then
            Return dgvContents.Rows.Count
        End If

        Return txtrows.Text
    End Function

    Private Function GetVisibleColumnCount() As Integer
        If chkAllColumns.Checked Then
            Return dgvContents.Columns.Count
        End If

        Return txtcolumns.Text
    End Function

    Private Function BuildHtmlTable(rowCount As Integer, columnCount As Integer) As String
        Dim aa As String = "<table style='font-size:" + nFontSizesql.Value.ToString + "px; background-color: " + System.Drawing.ColorTranslator.ToHtml(cmdbgcolorsql.BackColor) & "; color: " & System.Drawing.ColorTranslator.ToHtml(cmdfontcolorsql.ForeColor) & "; font-family: " & cmbfontsql.Text & "' border='2px' align='center' >" & vbNewLine

        For columnIndex As Integer = 0 To columnCount - 1
            aa = aa & "<th>" & dgvContents.Columns(columnIndex).HeaderText & "</th>"
        Next
        aa = aa & vbNewLine

        For rowIndex As Integer = 0 To rowCount - 1
            aa = aa & "<tr>"
            For columnIndex As Integer = 0 To columnCount - 1
                aa = aa & "<td>" & dgvContents.Rows(rowIndex).Cells(columnIndex).Value & "</td>"
            Next
            aa = aa & "</tr>" & vbNewLine
        Next

        Return aa & "</table>"
    End Function

    Private Sub ApplySelectedColor(applyColor As Action(Of Color))
        Dim aa As New ColorDialog
        If aa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            applyColor(aa.Color)
        End If
    End Sub

    Private Sub ApplyBackgroundColor(selectedColor As Color)
        cmdfontcolorsql.BackColor = selectedColor
        cmdbgcolorsql.BackColor = selectedColor
    End Sub

    Private Sub ApplyFontColor(selectedColor As Color)
        cmdfontcolorsql.ForeColor = selectedColor
        cmdbgcolorsql.ForeColor = selectedColor
    End Sub
End Class
