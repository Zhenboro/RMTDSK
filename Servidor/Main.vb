Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
Imports System.Runtime.Serialization.Formatters.Binary
Public Class Main
    Dim YO As TcpListener
    Dim REMOTO As TcpClient
    Dim RECIBE As Thread
    Dim NS As NetworkStream

    Dim RESOLUCIONX As Integer
    Dim RESOLUCIONY As Integer
    Dim POSICIONX As Integer
    Dim POSICIONY As Integer
    Dim ENVIO As Byte()

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NS.Dispose()
            YO.Stop()
            RECIBE.Abort()
        Catch
        End Try
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Iniciar()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            NS.Dispose()
            YO.Stop()
            RECIBE.Abort()
        Catch
        End Try
        End
    End Sub
    Sub Iniciar()
        Try
            Button1.Enabled = False
            TextBox1.Enabled = False
            CheckForIllegalCrossThreadCalls = False
            Dim args As String() = TextBox1.Text.Split(":")
            YO = New TcpListener(IPAddress.Any, args(1))
            YO.Start()
            RECIBE = New Thread(AddressOf RECIBIR)
            RECIBE.Start()
            TimerONE.Start()
        Catch ex As Exception
            Console.WriteLine("Iniciar Error: " & ex.Message)
        End Try
    End Sub

    Sub RECIBIR()
        Dim BF As New BinaryFormatter
        Try
            While True
                REMOTO = YO.AcceptTcpClient()
                NS = REMOTO.GetStream
                While REMOTO.Connected = True
                    PictureBox1.Image = BF.Deserialize(NS)
                    RESOLUCIONX = PictureBox1.Image.Width
                    RESOLUCIONY = PictureBox1.Image.Height
                End While
            End While
        Catch ex As Exception
            Console.WriteLine("RECIBIR Error: " & ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Try
            POSICIONX = (Cursor.Position.X - Me.Location.X - 10) * RESOLUCIONX / PictureBox1.Width
            POSICIONY = (Cursor.Position.Y - Me.Location.Y - 30) * RESOLUCIONY / PictureBox1.Height
            Dim MENSAJE As String = "IZQUIERDO:" & POSICIONX & ":" & POSICIONY
            ENVIO = System.Text.Encoding.UTF7.GetBytes(MENSAJE)
        Catch ex As Exception
            Console.WriteLine("PictureBox1_Click Error: " & ex.Message)
        End Try
    End Sub
    Private Sub PictureBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox1.DoubleClick
        Try
            POSICIONX = (Cursor.Position.X - Me.Location.X - 10) * RESOLUCIONX / PictureBox1.Width
            POSICIONY = (Cursor.Position.Y - Me.Location.Y - 30) * RESOLUCIONY / PictureBox1.Height
            Dim MENSAJE As String = "DOBLE:" & POSICIONX & ":" & POSICIONY
            ENVIO = System.Text.Encoding.UTF7.GetBytes(MENSAJE)
        Catch ex As Exception
            Console.WriteLine("PictureBox1_DoubleClick Error: " & ex.Message)
        End Try
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            Dim MENSAJE As String = "TAREAS:500:" & RESOLUCIONY
            ENVIO = System.Text.Encoding.UTF7.GetBytes(MENSAJE)
        Catch ex As Exception
            Console.WriteLine("Button3_Click Error: " & ex.Message)
        End Try
    End Sub
    Private Sub TimerONE_Tick(sender As Object, e As EventArgs) Handles TimerONE.Tick
        Dim BF As New BinaryFormatter
        Try
            NS = REMOTO.GetStream
            BF.Serialize(NS, ENVIO)
            ENVIO = Nothing
        Catch ex As Exception
            'Console.WriteLine("TimerONE_Tick Error: " & ex.Message)
        End Try
    End Sub
End Class