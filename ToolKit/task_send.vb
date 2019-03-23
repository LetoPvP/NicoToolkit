Public Class task_send

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        codigos.Mail_task()
        Me.Close()
        screen_shot.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub task_send_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        label_usr_mail.Text = "Enviado como " & My.Settings.username_pc & " [" & My.Settings.empresa & "]"
    End Sub
End Class