Imports Microsoft.Win32
Public Class Main
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Zhenboro\RMTDSK IDFTP"
    Dim threadActualiza As Threading.Thread
    Dim ftpUser As String = Nothing
    Dim ftpPass As String = Nothing
    Dim ftpHost As String = Nothing
    Dim httpHost As String = Nothing
    Dim RESOLUCIONX As Integer
    Dim RESOLUCIONY As Integer
    Dim POSICIONX As Integer
    Dim POSICIONY As Integer
    Dim ServerURL As String
    Public ENVIO As String
    Dim refreshDelay As Integer = 3000
    Sub LoadMemory()
        Try
            Dim llaveReg As String = "SOFTWARE\\Zhenboro\\RMTDSK IDFTP"
            Dim registerKey As RegistryKey = Registry.CurrentUser.OpenSubKey(llaveReg, True)
            If registerKey Is Nothing Then
                SaveMemory()
            Else
                ftpUser = registerKey.GetValue("ftpUser")
                ftpPass = registerKey.GetValue("ftpPass")
                ftpHost = registerKey.GetValue("ftpHost")
                httpHost = registerKey.GetValue("httpHost")
                refreshDelay = registerKey.GetValue("refreshDelay")
                TextBox1.Text = httpHost
            End If
        Catch ex As Exception
            Console.WriteLine("LoadMemory Error: " & ex.Message)
        End Try
    End Sub
    Sub SaveMemory()
        Try
            Dim llaveReg As String = "SOFTWARE\\Zhenboro\\RMTDSK IDFTP"
            Dim registerKey As RegistryKey = Registry.CurrentUser.OpenSubKey(llaveReg, True)
            If registerKey Is Nothing Then
                Registry.CurrentUser.CreateSubKey(llaveReg, True)
                registerKey = Registry.CurrentUser.OpenSubKey(llaveReg, True)
            End If
            registerKey.SetValue("ftpUser", ftpUser)
            registerKey.SetValue("ftpPass", ftpPass)
            registerKey.SetValue("ftpHost", ftpHost)
            registerKey.SetValue("httpHost", TextBox1.Text)
            registerKey.SetValue("refreshDelay", refreshDelay)
        Catch ex As Exception
            Console.WriteLine("SaveMemory Error: " & ex.Message)
        End Try
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMemory()
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            threadActualiza.Abort()
        Catch
        End Try
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Iniciar()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            threadActualiza.Abort()
        Catch
        End Try
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub
    Sub Iniciar()
        Try
            If ftpHost = Nothing Or ftpUser = Nothing Or ftpPass = Nothing Then
                ftpHost = InputBox("Ingrese la direccion host: ")
                ftpUser = InputBox("Ingrese el nombre de usuario: ")
                ftpPass = InputBox("Ingrese la contraseña: ")
            End If
            SaveMemory()
            Button1.Enabled = False
            TextBox1.Enabled = False
            CheckForIllegalCrossThreadCalls = False
            ServerURL = TextBox1.Text
            threadActualiza = New Threading.Thread(AddressOf Actualizar)
            threadActualiza.Start()
            Button2.Enabled = True
        Catch ex As Exception
            Console.WriteLine("Iniciar Error: " & ex.Message)
        End Try
    End Sub

    Sub Actualizar()
        While True
            Try
                MostrarPantalazo()
                EnviarControles()
                Threading.Thread.Sleep(refreshDelay)
            Catch ex As Exception
                Console.WriteLine("Actualizar Error: " & ex.Message)
            End Try
        End While
    End Sub

    Sub EnviarControles()
        Try
            If ENVIO <> Nothing Then
                Dim filePath As String = DIRCommons & "\serverMessages.str"
                If My.Computer.FileSystem.FileExists(filePath) Then
                    My.Computer.FileSystem.DeleteFile(filePath)
                End If
                Dim contenidoEnvio As String = "# RMTDSK IDFTP Edition" &
                        vbCrLf & "Server>" & ENVIO &
                        vbCrLf & "[Response]"
                My.Computer.FileSystem.WriteAllText(filePath, contenidoEnvio, False)
                My.Computer.Network.UploadFile(filePath, ServerURL & "\fileUpload.php")
            End If
        Catch ex As Exception
            Console.WriteLine("EnviarControles Error: " & ex.Message)
        End Try
    End Sub
    Sub MostrarPantalazo()
        Try
            Dim filePath As String = DIRCommons & "\screenshot.png"
            If My.Computer.FileSystem.FileExists(filePath) Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If
            My.Computer.Network.DownloadFile(ftpHost & "\screenshot.png", filePath, ftpUser, ftpPass, False, 3000, True)
            Using fs As New System.IO.FileStream(filePath, IO.FileMode.Open)
                PictureBox1.Image = New Bitmap(Image.FromStream(fs))
            End Using
            RESOLUCIONX = PictureBox1.Image.Width
            RESOLUCIONY = PictureBox1.Image.Height
        Catch ex As Exception
            Console.WriteLine("MostrarPantalazo Error: " & ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Try
            POSICIONX = (Cursor.Position.X - Me.Location.X - 10) * RESOLUCIONX / PictureBox1.Width
            POSICIONY = (Cursor.Position.Y - Me.Location.Y - 30) * RESOLUCIONY / PictureBox1.Height
            ENVIO = "IZQUIERDO:" & POSICIONX & ":" & POSICIONY
        Catch ex As Exception
            Console.WriteLine("PictureBox1_Click Error: " & ex.Message)
        End Try
    End Sub
    Private Sub PictureBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox1.DoubleClick
        Try
            POSICIONX = (Cursor.Position.X - Me.Location.X - 10) * RESOLUCIONX / PictureBox1.Width
            POSICIONY = (Cursor.Position.Y - Me.Location.Y - 30) * RESOLUCIONY / PictureBox1.Height
            ENVIO = "DOBLE:" & POSICIONX & ":" & POSICIONY
        Catch ex As Exception
            Console.WriteLine("PictureBox1_DoubleClick Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TaskBar(0)
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TaskBar(1)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TaskBar(2)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ClickIzquierdo()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ClickDerecho()
    End Sub

    Sub ClickIzquierdo()
        Try
            ENVIO = "IZQUIERDO:" & POSICIONX & ":" & POSICIONY
        Catch ex As Exception
            Console.WriteLine("ClickIzquierdo Error: " & ex.Message)
        End Try
    End Sub
    Sub ClickDerecho()
        Try
            ENVIO = "DERECHO:" & POSICIONX & ":" & POSICIONY
        Catch ex As Exception
            Console.WriteLine("ClickDerecho Error: " & ex.Message)
        End Try
    End Sub

    Sub TaskBar(ByVal op As SByte)
        Try
            If op = 0 Then
                ENVIO = "HIDETAREAS:NA:NA"
            ElseIf op = 1 Then
                ENVIO = "SHOWTAREAS:NA:NA"
            ElseIf op = 2 Then
                ENVIO = "WINDOWS:NA:NA"
            End If
        Catch ex As Exception
            Console.WriteLine("TaskBar Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SendKeys.Show()
        SendKeys.Focus()
    End Sub

    Dim EsPantallaCompleta As Boolean = False
    Private Sub PantallaCompletaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PantallaCompletaToolStripMenuItem.Click

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub MostrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem.Click
        TaskBar(1)
    End Sub
    Private Sub ClickDerechoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClickDerechoToolStripMenuItem.Click
        ClickDerecho()
    End Sub
    Private Sub ClickIzquierdoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClickIzquierdoToolStripMenuItem.Click
        ClickIzquierdo()
    End Sub

    Private Sub OcultarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OcultarToolStripMenuItem.Click
        TaskBar(0)
    End Sub
    Private Sub MostrarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem1.Click
        TaskBar(1)
    End Sub
    Private Sub InicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InicioToolStripMenuItem.Click
        TaskBar(2)
    End Sub
End Class