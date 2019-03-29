<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class empres
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
        Me.txt_empresa = New System.Windows.Forms.TextBox()
        Me.btn_empresa = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PbLogo = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_empresa
        '
        Me.txt_empresa.Font = New System.Drawing.Font("Bahnschrift", 9.0!)
        Me.txt_empresa.Location = New System.Drawing.Point(149, 127)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.Size = New System.Drawing.Size(323, 22)
        Me.txt_empresa.TabIndex = 1
        '
        'btn_empresa
        '
        Me.btn_empresa.BackColor = System.Drawing.Color.Green
        Me.btn_empresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_empresa.Font = New System.Drawing.Font("Bahnschrift", 9.75!)
        Me.btn_empresa.ForeColor = System.Drawing.Color.White
        Me.btn_empresa.Location = New System.Drawing.Point(272, 155)
        Me.btn_empresa.Name = "btn_empresa"
        Me.btn_empresa.Size = New System.Drawing.Size(81, 23)
        Me.btn_empresa.TabIndex = 2
        Me.btn_empresa.Text = "GUARDAR"
        Me.btn_empresa.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(622, 2)
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'PbLogo
        '
        Me.PbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PbLogo.Image = Global.NicoToolKit.My.Resources.Resources.logo_ics
        Me.PbLogo.Location = New System.Drawing.Point(175, 8)
        Me.PbLogo.Name = "PbLogo"
        Me.PbLogo.Size = New System.Drawing.Size(275, 94)
        Me.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PbLogo.TabIndex = 69
        Me.PbLogo.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Location = New System.Drawing.Point(624, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(2, 190)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox4.Location = New System.Drawing.Point(2, 190)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(624, 2)
        Me.PictureBox4.TabIndex = 67
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(2, 192)
        Me.PictureBox2.TabIndex = 66
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(193, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 16)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "¿A que empresa pertenece este equipo?"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'empres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(626, 192)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PbLogo)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_empresa)
        Me.Controls.Add(Me.txt_empresa)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "empres"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "empres"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_empresa As TextBox
    Friend WithEvents btn_empresa As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PbLogo As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
End Class
