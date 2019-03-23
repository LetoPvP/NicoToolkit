<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class task_send
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
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.label_usr_mail = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.bar_move = New System.Windows.Forms.PictureBox()
        Me.version_textbox = New System.Windows.Forms.Label()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bar_move, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMensaje
        '
        Me.txtMensaje.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.txtMensaje.Location = New System.Drawing.Point(85, 45)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(445, 140)
        Me.txtMensaje.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Mensaje"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gray
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Location = New System.Drawing.Point(532, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(2, 199)
        Me.PictureBox3.TabIndex = 50
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Location = New System.Drawing.Point(0, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(2, 199)
        Me.PictureBox2.TabIndex = 49
        Me.PictureBox2.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Gray
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox4.Location = New System.Drawing.Point(0, 218)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(534, 2)
        Me.PictureBox4.TabIndex = 48
        Me.PictureBox4.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Bahnschrift", 10.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(397, 189)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 27)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Enviar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'label_usr_mail
        '
        Me.label_usr_mail.AutoSize = True
        Me.label_usr_mail.Font = New System.Drawing.Font("Bahnschrift", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.label_usr_mail.ForeColor = System.Drawing.Color.Gray
        Me.label_usr_mail.Location = New System.Drawing.Point(5, 23)
        Me.label_usr_mail.Name = "label_usr_mail"
        Me.label_usr_mail.Size = New System.Drawing.Size(400, 16)
        Me.label_usr_mail.TabIndex = 46
        Me.label_usr_mail.Text = "Enviado como "" & My.Settings.username_pc & "" de "" & My.Settings.empresa"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(512, -1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 45
        Me.Button3.Text = "X"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'bar_move
        '
        Me.bar_move.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.bar_move.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.bar_move.Dock = System.Windows.Forms.DockStyle.Top
        Me.bar_move.Location = New System.Drawing.Point(0, 0)
        Me.bar_move.Name = "bar_move"
        Me.bar_move.Size = New System.Drawing.Size(534, 19)
        Me.bar_move.TabIndex = 44
        Me.bar_move.TabStop = False
        '
        'version_textbox
        '
        Me.version_textbox.AutoSize = True
        Me.version_textbox.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.version_textbox.Font = New System.Drawing.Font("Bahnschrift", 9.75!)
        Me.version_textbox.ForeColor = System.Drawing.Color.White
        Me.version_textbox.Location = New System.Drawing.Point(4, 1)
        Me.version_textbox.Name = "version_textbox"
        Me.version_textbox.Size = New System.Drawing.Size(161, 16)
        Me.version_textbox.TabIndex = 51
        Me.version_textbox.Text = "Envio de correo con avería."
        '
        'task_send
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 220)
        Me.Controls.Add(Me.version_textbox)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.label_usr_mail)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.bar_move)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "task_send"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "task_send"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bar_move, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMensaje As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents label_usr_mail As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents bar_move As PictureBox
    Friend WithEvents version_textbox As Label
End Class
