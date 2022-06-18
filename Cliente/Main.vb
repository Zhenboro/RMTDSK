Imports System.Net.Sockets
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
        Init()
        ReadParameters()
        Iniciar()
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NS.Dispose()
            YO.Close()
        Catch
        End Try
    End Sub

    Sub ReadParameters()
        Try
            If My.Application.CommandLineArgs.Count = 0 Then
                End
            Else
                For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
                    Dim parameter As String = My.Application.CommandLineArgs(i)
                    If parameter.ToLower Like "*--serverip*" Then
                        Dim args As String() = parameter.Split("-")
                        ServerIP = args(3)
                    ElseIf parameter.ToLower Like "*--serverport*" Then
                        Dim args As String() = parameter.Split("-")
                        ServerPort = Integer.Parse(args(3))
                    End If
                Next
            End If
        Catch ex As Exception
            AddToLog("ReadParameters@Main", "Error: " & ex.Message, True)
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
            AddToLog("Iniciar@Main", "Error: " & ex.Message, True)
            End
        End Try
    End Sub
    Sub TimerUNO()
        Dim BF As New BinaryFormatter
        Dim IMAGEN As Bitmap
        Try
            Dim BM As Bitmap
            BM = New Bitmap(Screen.AllScreens.Sum(Function(s As Screen) s.Bounds.Width), Screen.AllScreens.Max(Function(s As Screen) s.Bounds.Height))
            Dim DIBUJO As Graphics
            DIBUJO = Graphics.FromImage(BM)
            DIBUJO.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, SystemInformation.VirtualScreen.Size)
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
            AddToLog("TimerUNO@Main", "Error: " & ex.Message, True)
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
            AddToLog("TimerDOS@Main", "Error: " & ex.Message, True)
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
            AddToLog("ORDENES@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As IntPtr, ByVal bScan As IntPtr, ByVal dwFlags As IntPtr, ByVal dwExtraInfo As IntPtr)
    Const KEYEVENTF_KEYUP = &H2 'Soltar
    Const VK_STARTKEY = &H5B 'Win key

    Sub ProcessKeys(ByVal orden As String)
        Try
            Dim args As String() = orden.Split("|")
            Dim contenido As String = args(1)

            Dim procesador As String() = contenido.Split(" ")

            Dim KeyProc As KeyProcessor
            KeyProc = New KeyProcessor
            Dim threadKeyProc As Threading.Thread = New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf KeyProc.ProcesarTeclas))
            threadKeyProc.Start(contenido.TrimEnd)

        Catch ex As Exception
            AddToLog("ProcessKeys@Main", "Error: " & ex.Message, True)
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
Public Class KeyProcessor
    Public Sub New()
    End Sub
    <DllImport("user32.dll")>
    Public Shared Sub keybd_event(bVk As Byte, bScan As Byte, dwFlags As UInteger, dwExtraInfo As UInteger)
    End Sub
    Sub ProcesarTeclas(ByVal listaTeclas As String)
        Try
            Const KEYEVENTF_KEYUP = &H2
            For Each ky As String In listaTeclas.Split(" ")
                Dim Key As Keys = [Enum].Parse(GetType(Keys), ky, True)
                keybd_event(Key, 0, 0, 0)
                keybd_event(Key, 0, KEYEVENTF_KEYUP, 0)
                Threading.Thread.Sleep(500)
            Next
        Catch ex As Exception
            AddToLog("ProcesarTeclas@KeyProcessor", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class