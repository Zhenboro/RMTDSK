<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Viewer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClickDerechoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClickIzquierdoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MostrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PantallaCompletaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TimerONE = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Viewer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.Viewer
        Me.PictureBox1.Location = New System.Drawing.Point(14, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(820, 560)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Viewer
        '
        Me.Viewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClickDerechoToolStripMenuItem, Me.ClickIzquierdoToolStripMenuItem, Me.TaskbarToolStripMenuItem, Me.ToolStripMenuItem3, Me.MostrarToolStripMenuItem, Me.PantallaCompletaToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.Viewer.Name = "ContextMenuStrip1"
        Me.Viewer.Size = New System.Drawing.Size(190, 148)
        '
        'ClickDerechoToolStripMenuItem
        '
        Me.ClickDerechoToolStripMenuItem.Name = "ClickDerechoToolStripMenuItem"
        Me.ClickDerechoToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ClickDerechoToolStripMenuItem.Text = "Click derecho"
        '
        'ClickIzquierdoToolStripMenuItem
        '
        Me.ClickIzquierdoToolStripMenuItem.Name = "ClickIzquierdoToolStripMenuItem"
        Me.ClickIzquierdoToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ClickIzquierdoToolStripMenuItem.Text = "Click izquierdo"
        '
        'TaskbarToolStripMenuItem
        '
        Me.TaskbarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarToolStripMenuItem1, Me.OcultarToolStripMenuItem, Me.ToolStripMenuItem2, Me.InicioToolStripMenuItem})
        Me.TaskbarToolStripMenuItem.Name = "TaskbarToolStripMenuItem"
        Me.TaskbarToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.TaskbarToolStripMenuItem.Text = "Taskbar"
        '
        'MostrarToolStripMenuItem1
        '
        Me.MostrarToolStripMenuItem1.Name = "MostrarToolStripMenuItem1"
        Me.MostrarToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.MostrarToolStripMenuItem1.Text = "Mostrar"
        '
        'OcultarToolStripMenuItem
        '
        Me.OcultarToolStripMenuItem.Name = "OcultarToolStripMenuItem"
        Me.OcultarToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.OcultarToolStripMenuItem.Text = "Ocultar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(112, 6)
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.InicioToolStripMenuItem.Text = "Inicio"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(186, 6)
        '
        'MostrarToolStripMenuItem
        '
        Me.MostrarToolStripMenuItem.Name = "MostrarToolStripMenuItem"
        Me.MostrarToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.MostrarToolStripMenuItem.Text = "Mostrar/Ocultar barra"
        '
        'PantallaCompletaToolStripMenuItem
        '
        Me.PantallaCompletaToolStripMenuItem.Name = "PantallaCompletaToolStripMenuItem"
        Me.PantallaCompletaToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.PantallaCompletaToolStripMenuItem.Text = "Pantalla completa"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(279, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 27)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Disconnect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(639, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(57, 35)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Taskbar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mostrar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TimerONE
        '
        Me.TimerONE.Interval = 500
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(186, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Connect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(3, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(177, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "localhost:15243"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(465, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(168, 27)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Send Keys"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(765, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(57, 27)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Inicio"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(702, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(57, 35)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Taskbar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ocultar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button7.Location = New System.Drawing.Point(416, 7)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(30, 27)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "R"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button8.Location = New System.Drawing.Point(380, 7)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(30, 27)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "L"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(12, 579)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(825, 41)
        Me.Panel1.TabIndex = 9
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 632)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimumSize = New System.Drawing.Size(865, 658)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remote Desktop Viewer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Viewer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TimerONE As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Viewer As ContextMenuStrip
    Friend WithEvents PantallaCompletaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ClickDerechoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClickIzquierdoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskbarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OcultarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents InicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
