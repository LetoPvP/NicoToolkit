Public Class screen_shot
    Dim CONTADOR As Integer
    Private Sub screen_shot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Label1.BackColor = Color.Red Then
            MsgBox("HAS ASIGNADO EL COLOR ROJO A LA ETIQUETA Y PUEDES TENER PROBLEMAS PARA PARAR LA CAPTURA DE IMAGENES")
        End If
        Me.TransparencyKey = Label1.BackColor
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim BM As Bitmap
        BM = New Bitmap(Label1.Width, Label1.Height)
        Dim DIBUJO As Graphics
        DIBUJO = Graphics.FromImage(BM)
        DIBUJO.CopyFromScreen(Me.Location.X + Label1.Location.X + 8, Me.Location.Y + Label1.Location.Y + 30, 0, 0, Label1.Size)
        DIBUJO.DrawImage(BM, 0, 0, BM.Width, BM.Height)
        BM.Save(FolderBrowserDialog1.SelectedPath & "\" & CONTADOR & ".jpg", Imaging.ImageFormat.Jpeg)
        CONTADOR += 1
    End Sub

    Private Sub ButtonCAPTURA_Click(sender As Object, e As EventArgs) Handles ButtonCAPTURA.Click
        SaveFileDialog1.DefaultExt = ".jpg"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Threading.Thread.Sleep(1000)
            Dim BM As Bitmap
            BM = New Bitmap(Label1.Width, Label1.Height)
            Dim DIBUJO As Graphics
            DIBUJO = Graphics.FromImage(BM)
            DIBUJO.CopyFromScreen(Me.Location.X + Label1.Location.X, Me.Location.Y + Label1.Location.Y, 0, 0, Label1.Size)
            'DIBUJO.CopyFromScreen(Me.Location.X + Label1.Location.X + 8, Me.Location.Y + Label1.Location.Y + 30, 0, 0, Label1.Size)
            DIBUJO.DrawImage(BM, 0, 0, BM.Width, BM.Height)
            BM.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
        End If
        task_send.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class