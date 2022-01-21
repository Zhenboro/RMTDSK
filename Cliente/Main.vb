﻿Imports System.Net.Sockets
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Timers
Public Class Main
    Dim WithEvents TimerONE As New System.Timers.Timer
    Dim WithEvents TimerTWO As New System.Timers.Timer
    Dim YO As New TcpClient
    Dim NS As NetworkStream
    Dim ServerIP As String ' = "localhost"
    Dim ServerPort As Integer ' = 15243

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeerParametros()
        Iniciar()
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NS.Dispose()
            YO.Close()
        Catch
        End Try
    End Sub

    Sub LeerParametros()
        Try
            If My.Application.CommandLineArgs.Count = 0 Then
                End
            Else
                For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
                    Dim parameter As String = My.Application.CommandLineArgs(i)
                    If parameter Like "*-ServerIP=*" Then
                        Dim args As String() = parameter.Split("=")
                        ServerIP = args(1)
                    ElseIf parameter Like "*-ServerPort=*" Then
                        Dim args As String() = parameter.Split("=")
                        ServerPort = Integer.Parse(args(1))
                    End If
                Next
            End If
        Catch ex As Exception
            Console.WriteLine("TimerUNO Error: " & ex.Message)
            End
        End Try
    End Sub

    Sub Iniciar()
        Try
            YO.Connect(ServerIP, ServerPort)
            TimerONE = New System.Timers.Timer(555)
            AddHandler TimerONE.Elapsed, New ElapsedEventHandler(AddressOf TimerUNO)
            TimerONE.Start()
            TimerTWO = New System.Timers.Timer(555)
            AddHandler TimerTWO.Elapsed, New ElapsedEventHandler(AddressOf TimerDOS)
            TimerTWO.Start()
        Catch ex As Exception
            Console.WriteLine("Iniciar Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub TimerUNO()
        Dim BF As New BinaryFormatter
        Dim IMAGEN As Bitmap
        Try
            Dim BM As Bitmap
            BM = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Dim DIBUJO As Graphics
            DIBUJO = Graphics.FromImage(BM)
            DIBUJO.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size)
            DIBUJO.DrawImage(BM, 0, 0, BM.Width, BM.Height)
            IMAGEN = New Bitmap(BM)
            Dim DIBUJO2 As Graphics
            DIBUJO2 = Graphics.FromImage(IMAGEN)
            Dim MICURSOR As Cursor = Cursors.Hand
            Dim RECTANGULO As New Rectangle(Cursor.Position.X, Cursor.Position.Y, MICURSOR.Size.Width, MICURSOR.Size.Height)
            MICURSOR.Draw(DIBUJO2, RECTANGULO)
            Dim MS As New MemoryStream
            IMAGEN.Save(MS, Imaging.ImageFormat.Jpeg)
            IMAGEN = Image.FromStream(MS)
            NS = YO.GetStream
            BF.Serialize(NS, IMAGEN)
        Catch ex As Exception
            Console.WriteLine("TimerUNO Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub TimerDOS()
        Try
            NS = YO.GetStream
            Dim BF As New BinaryFormatter
            If NS.DataAvailable Then
                Dim MENSAJE As String = System.Text.Encoding.UTF7.GetString(BF.Deserialize(NS))
                ORDENES(MENSAJE)
            End If
        Catch ex As Exception
            Console.WriteLine("TimerDOS Error: " & ex.Message)
            End
        End Try
    End Sub
    Sub ORDENES(ByVal ORDEN As String)
        Try
            If ORDEN.StartsWith("[SEND_KEYS]") Then
                ProcessKeys(ORDEN)
            Else
                Dim PARTES As String() = ORDEN.Split(":")
                If PARTES(1) <> "NA" Then
                    POSICIONX = PARTES(1)
                    POSICIONY = PARTES(2)
                    Cursor.Position = New Point(POSICIONX, POSICIONY)
                End If
                Select Case PARTES(0)
                    Case "DERECHO"
                        CLICKDCHO()
                    Case "IZQUIERDO"
                        CLICKIZDO()
                    Case "DOBLE"
                        CLICKIZDO()
                        CLICKIZDO()
                    Case "SHOWTAREAS"
                        MUESTRABARRA()
                    Case "HIDETAREAS"
                        OCULTABARRA()
                    Case "WINDOWS"
                        MUESTRAINICIO()
                End Select
            End If
        Catch ex As Exception
            Console.WriteLine("ORDENES Error: " & ex.Message)
        End Try
    End Sub

    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As IntPtr, ByVal bScan As IntPtr, ByVal dwFlags As IntPtr, ByVal dwExtraInfo As IntPtr)
    Const KEYEVENTF_KEYUP = &H2 'Soltar
    Const VK_BACK = &H8 'Backspace
    Const VK_TAB = &H9 'TAB
    Const VK_RETURN = &HD 'ENTER
    Const VK_SHIFT = &H10 'SHIFT
    Const VK_CONTROL = &H11 'CTRL
    Const VK_MENU = &H12 'ALT
    Const VK_CAPITAL = &H14 'CapLock
    Const VK_ESCAPE = &H1B 'ESC
    Const VK_SPACE = &H20 'Spacebar
    Const VK_INSERT = &H2D 'Insert
    Const VK_DELETE = &H2E 'SUPR
    Const VK_STARTKEY = &H5B 'Win key
    Const VK_CONTEXTKEY = &H5D
    Const VK_LBUTTON = &H1
    Const VK_RBUTTON = &H2
    Const VK_MBUTTON = &H4
    Const VK_F1 = &H70
    Const VK_F2 = &H71
    Const VK_F3 = &H72
    Const VK_F4 = &H73
    Const VK_F5 = &H74
    Const VK_F6 = &H75
    Const VK_F7 = &H76
    Const VK_F8 = &H77
    Const VK_F9 = &H78
    Const VK_F10 = &H79
    Const VK_F11 = &H7A
    Const VK_F12 = &H7B

    Sub ProcessKeys(ByVal orden As String)
        Try
            Dim args As String() = orden.Split("|")
            Dim contenido As String = args(1)

            Dim procesador As String() = contenido.Split(" ")

            For Each palabra As String In procesador
                Threading.Thread.Sleep(850)
                If palabra Like "*%WIN%*" Then 'PROCESO TECLA WIN
                    keybd_event(VK_STARTKEY, 0, 0, 0)
                    keybd_event(VK_STARTKEY, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%CTRL%*" Then
                    keybd_event(VK_CONTROL, 0, 0, 0)
                    keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%ALT%*" Then
                    keybd_event(VK_MENU, 0, 0, 0)
                    keybd_event(VK_MENU, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%SHIFT%*" Then
                    keybd_event(VK_SHIFT, 0, 0, 0)
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%BACKSPACE%*" Then
                    keybd_event(VK_BACK, 0, 0, 0)
                    keybd_event(VK_BACK, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%ENTER%*" Then
                    keybd_event(VK_RETURN, 0, 0, 0)
                    keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%SPACE%*" Then
                    keybd_event(VK_SPACE, 0, 0, 0)
                    keybd_event(VK_SPACE, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%TAB%*" Then
                    keybd_event(VK_TAB, 0, 0, 0)
                    keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%ESC%*" Then
                    keybd_event(VK_DELETE, 0, 0, 0)
                    keybd_event(VK_DELETE, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%SUPR%*" Then
                    keybd_event(VK_DELETE, 0, 0, 0)
                    keybd_event(VK_DELETE, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%INSERT%*" Then
                    keybd_event(VK_INSERT, 0, 0, 0)
                    keybd_event(VK_INSERT, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%CONTEXT%*" Then
                    keybd_event(VK_CONTEXTKEY, 0, 0, 0)
                    keybd_event(VK_CONTEXTKEY, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%CAPITAL%*" Then
                    keybd_event(VK_CAPITAL, 0, 0, 0)
                    keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%LCLICK%*" Then
                    keybd_event(VK_LBUTTON, 0, 0, 0)
                    keybd_event(VK_LBUTTON, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%RCLICK%*" Then
                    keybd_event(VK_RBUTTON, 0, 0, 0)
                    keybd_event(VK_RBUTTON, 0, KEYEVENTF_KEYUP, 0)
                ElseIf palabra Like "*%MCLICK%*" Then
                    keybd_event(VK_MBUTTON, 0, 0, 0)
                    keybd_event(VK_MBUTTON, 0, KEYEVENTF_KEYUP, 0)
                Else
                    My.Computer.Keyboard.SendKeys(palabra, True)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("ORDENES Error: " & ex.Message)
        End Try
    End Sub

#Region "Cursor Orders"
    Dim POSICIONX As Integer
    Dim POSICIONY As Integer
    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Sub mouse_event(dwFlags As Integer, dx As Integer, dy As Integer, cButtons As Integer, dwExtraInfo As Integer)
    End Sub
    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 1
    Private Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Private Const MOUSEEVENTF_LEFTUP As Integer = &H4
    Private Const MOUSEEVENTF_RIGHTDOWN As Integer = &H8
    Private Const MOUSEEVENTF_RIGHTUP As Integer = &H10
    Public Sub CLICKIZDO()
        mouse_event(MOUSEEVENTF_LEFTDOWN, POSICIONX, POSICIONY, 0, 0)
        mouse_event(MOUSEEVENTF_LEFTUP, POSICIONX, POSICIONY, 0, 0)
    End Sub
    Public Sub CLICKDCHO()
        mouse_event(MOUSEEVENTF_RIGHTDOWN, POSICIONX, POSICIONY, 0, 0)
        mouse_event(MOUSEEVENTF_RIGHTUP, POSICIONX, POSICIONY, 0, 0)
    End Sub
    <DllImport("user32.dll")>
    Private Shared Function FindWindow(className As String, windowText As String) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(hwnd As IntPtr, command As Integer) As Boolean
    End Function
    Function OCULTABARRA() As Boolean
        Dim retval = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval = ShowWindow(hwndTaskBar, SW_HIDE)
        End If
        Return retval
    End Function
    Function MUESTRABARRA() As Boolean
        Dim retval2 = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval2 = ShowWindow(hwndTaskBar, SW_SHOW)
        End If
        Return retval2
    End Function
    Function MUESTRAINICIO() As Boolean
        Dim retval1 = False
        MUESTRABARRA()
        Dim hwndstartbutton = FindWindow("Button", "Start")
        If hwndstartbutton <> IntPtr.Zero Then
            retval1 = ShowWindow(hwndstartbutton, SW_SHOW)
        End If
        keybd_event(VK_STARTKEY, 0, 0, 0)
        keybd_event(VK_STARTKEY, 0, KEYEVENTF_KEYUP, 0)
        Return retval1
    End Function
#End Region
End Class