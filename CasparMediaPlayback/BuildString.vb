Imports System.Text

Public Class BuildString
    Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public Event StringOK(ByVal Result As String)

    Private hwnd As Integer = 0
    Private wMsg As Integer = 0
    Private wParam As Integer = 0
    Private lParam As String = ""
    Private tempA(-1) As Byte
    Private enc As Encoding = Encoding.UTF8

    Public Property Encode() As Encoding
        Get
            Return enc
        End Get
        Set(ByVal value As Encoding)
            enc = value
        End Set
    End Property

    Private Function DecodeBytes(bytes As Byte()) As String
        If enc Is Encoding.UTF8 Then
            Return Encoding.UTF8.GetString(bytes)
        ElseIf enc Is Encoding.Unicode Then
            Return Encoding.Unicode.GetString(bytes)
        ElseIf enc Is Encoding.ASCII Then
            Return Encoding.ASCII.GetString(bytes)
        End If

        Return Encoding.Default.GetString(bytes)
    End Function

    Private Function EncodeString(value As String) As Byte()
        If enc Is Encoding.UTF8 Then
            Return Encoding.UTF8.GetBytes(value)
        ElseIf enc Is Encoding.Unicode Then
            Return Encoding.Unicode.GetBytes(value)
        ElseIf enc Is Encoding.ASCII Then
            Return Encoding.ASCII.GetBytes(value)
        End If

        Return Encoding.Default.GetBytes(value)
    End Function

    Public Sub BuildString(ByVal b As IntPtr)
        If b <> 0 Then
            Dim tempB(tempA.Length) As Byte
            tempA.CopyTo(tempB, 0)
            tempB(tempA.Length) = b
            ReDim tempA(tempB.Length - 1)
            tempB.CopyTo(tempA, 0)
        Else
            RaiseEvent StringOK(DecodeBytes(tempA))
            ReDim tempA(-1)
        End If
    End Sub

    Public Sub PostString(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String)
        Me.hwnd = hwnd
        Me.wMsg = wMsg
        Me.wParam = wParam
        Me.lParam = lParam

        Dim t As Threading.Thread = New Threading.Thread(AddressOf SendString)
        t.Start()
    End Sub

    Private Sub SendString()
        Dim ba() As Byte = EncodeString(lParam)

        For i As Integer = 0 To ba.Length - 1
            PostMessage(hwnd, wMsg, wParam, ba(i))
        Next

        PostMessage(hwnd, wMsg, wParam, 0)
    End Sub
End Class
