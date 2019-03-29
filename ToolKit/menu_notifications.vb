Public Class menu_notifications


    Private Sub menu_notifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As Rectangle = My.Computer.Screen.WorkingArea
        Location = New Point(r.Width - Width, r.Height - Height)
        label_version_app.Text = "Revisión " & My.Settings.version_local
        menu_programacion()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles menu_update.Click
        Form1.Comprobar_version()
    End Sub
    Private Sub menu_info_Click(sender As Object, e As EventArgs) Handles menu_info.Click
        settings_toolkit.Show()
    End Sub

    Private Sub menu_abrir_Click(sender As Object, e As EventArgs) Handles menu_abrir.Click
        codigos.Mostrar_form()
    End Sub

    Private Sub menu_notifications_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub

    Public Sub menu_programacion()
        If My.Settings.task_win = True Then
            Label2.Text = "Revisión automática activada.
Primer " & My.Settings.day_program & " de cada mes 
a las " & My.Settings.hour_program & ":" & My.Settings.min_program & "h"
        Else
            Label2.Text = "Revisión automática no activada."
        End If
    End Sub
End Class
