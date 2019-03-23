Public Class informe_lock
    Private Sub informe_lock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        codigos.Revision_nfo()
    End Sub
End Class