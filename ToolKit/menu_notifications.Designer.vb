<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class menu_notifications
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.menu_info = New System.Windows.Forms.Button()
        Me.menu_update = New System.Windows.Forms.Button()
        Me.label_version_app = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.menu_abrir = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.bar_move = New System.Windows.Forms.PictureBox()
        Me.Timer_notification = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bar_move, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menu_info
        '
        Me.menu_info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menu_info.BackColor = System.Drawing.Color.White
        Me.menu_info.FlatAppearance.BorderSize = 0
        Me.menu_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_info.Font = New System.Drawing.Font("Bahnschrift", 9.75!)
        Me.menu_info.ForeColor = System.Drawing.Color.Black
        Me.menu_info.Location = New System.Drawing.Point(4, 281)
        Me.menu_info.Name = "menu_info"
        Me.menu_info.Size = New System.Drawing.Size(253, 27)
        Me.menu_info.TabIndex = 48
        Me.menu_info.Text = "Acerca de NicoToolkit"
        Me.menu_info.UseVisualStyleBackColor = False
        '
        'menu_update
        '
        Me.menu_update.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menu_update.BackColor = System.Drawing.Color.White
        Me.menu_update.FlatAppearance.BorderSize = 0
        Me.menu_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_update.Font = New System.Drawing.Font("Bahnschrift", 9.75!)
        Me.menu_update.ForeColor = System.Drawing.Color.Black
        Me.menu_update.Location = New System.Drawing.Point(4, 248)
        Me.menu_update.Name = "menu_update"
        Me.menu_update.Size = New System.Drawing.Size(253, 27)
        Me.menu_update.TabIndex = 50
        Me.menu_update.Text = "Buscar actualizaciones"
        Me.menu_update.UseVisualStyleBackColor = False
        '
        'label_version_app
        '
        Me.label_version_app.AutoSize = True
        Me.label_version_app.Font = New System.Drawing.Font("Bahnschrift", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.label_version_app.ForeColor = System.Drawing.Color.Gray
        Me.label_version_app.Location = New System.Drawing.Point(88, 50)
        Me.label_version_app.Name = "label_version_app"
        Me.label_version_app.Size = New System.Drawing.Size(78, 16)
        Me.label_version_app.TabIndex = 55
        Me.label_version_app.Text = "version 1.3.3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift", 16.0!)
        Me.Label1.Location = New System.Drawing.Point(87, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 27)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "NicoToolkit"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.NicoToolKit.My.Resources.Resources.antivirus0
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 76)
        Me.PictureBox1.TabIndex = 53
        Me.PictureBox1.TabStop = False
        '
        'menu_abrir
        '
        Me.menu_abrir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menu_abrir.BackColor = System.Drawing.Color.White
        Me.menu_abrir.FlatAppearance.BorderSize = 0
        Me.menu_abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_abrir.Font = New System.Drawing.Font("Bahnschrift", 9.75!)
        Me.menu_abrir.ForeColor = System.Drawing.Color.Black
        Me.menu_abrir.Location = New System.Drawing.Point(4, 215)
        Me.menu_abrir.Name = "menu_abrir"
        Me.menu_abrir.Size = New System.Drawing.Size(253, 27)
        Me.menu_abrir.TabIndex = 56
        Me.menu_abrir.Text = "Abrir NicoToolkit"
        Me.menu_abrir.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gray
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Location = New System.Drawing.Point(256, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(2, 320)
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(2, 320)
        Me.PictureBox2.TabIndex = 57
        Me.PictureBox2.TabStop = False
        '
        'bar_move
        '
        Me.bar_move.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.bar_move.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.bar_move.Dock = System.Windows.Forms.DockStyle.Top
        Me.bar_move.Location = New System.Drawing.Point(2, 0)
        Me.bar_move.Name = "bar_move"
        Me.bar_move.Size = New System.Drawing.Size(254, 2)
        Me.bar_move.TabIndex = 59
        Me.bar_move.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(17, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Label2"
        '
        'menu_notifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(258, 320)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bar_move)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.menu_abrir)
        Me.Controls.Add(Me.label_version_app)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.menu_update)
        Me.Controls.Add(Me.menu_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "menu_notifications"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "menu_notifications"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bar_move, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menu_info As Button
    Friend WithEvents menu_update As Button
    Friend WithEvents label_version_app As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents menu_abrir As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents bar_move As PictureBox
    Friend WithEvents Timer_notification As Timer
    Friend WithEvents Label2 As Label
End Class
