Public Class SendKeys

    Private Sub SendKeys_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main.ENVIO = "[SEND_KEYS]|" & RichTextBox1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.AppendText(vbCrLf & "%WIN%: Windows" &
                                vbCrLf & "%CTRL%: Control" &
                                vbCrLf & "%ALT%: ALT (menu)" &
                                vbCrLf & "%SHIFT%: Shift" &
                                vbCrLf & "%BACKSPACE%: Backspace (retroceso)" &
                                vbCrLf & "%ENTER%: ENTER (intro)" &
                                vbCrLf & "%SPACE%: SPACE (espacio)" &
                                vbCrLf & "%TAB%: TAB (tabulador)" &
                                vbCrLf & "%ESC%: ESC (escape)" &
                                vbCrLf & "%SUPR%: SUPR (suprimir)" &
                                vbCrLf & "%INSERT%: INSERT (insertar)" &
                                vbCrLf & "%CONTEXT%: CONTEXT (contexto)" &
                                vbCrLf & "%CAPITAL%: CAPITAL (Bloq. Mayus)" &
                                vbCrLf & "%LCLICK%: Left Click" &
                                vbCrLf & "%RCLICK%: Right Click" &
                                vbCrLf & "%MCLICK%: Middle button (mouse)" & vbCrLf)
    End Sub
End Class