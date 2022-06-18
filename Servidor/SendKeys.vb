Public Class SendKeys

    Private Sub SendKeys_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub SendKeys_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        If MessageBox.Show("'SendKeys' es parte de 'RMTDSK' y este fue creado y desarrollado por Zhenboro." & vbCrLf & "¿Desea visitar el sitio oficial?", "Not-A-Virus Series", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Process.Start("https://github.com/Zhenboro/RMTDSK")
            Threading.Thread.Sleep(500)
            Process.Start("https://github.com/Zhenboro")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MENSAJE As String = "[SEND_KEYS]|" & RichTextBox1.Text
        Main.ENVIO = System.Text.Encoding.UTF7.GetBytes(MENSAJE)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("¿Desea ver los codigos de cada tecla?", "Ayuda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Process.Start("https://chemic-jug.000webhostapp.com/Borocito/Mapeo_Teclas_Kiloger.txt")
        End If
    End Sub
End Class