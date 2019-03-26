Public Class empres
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_empresa.Click
        If txt_empresa.Text = "" Then
            btn_empresa.BackColor = Color.Red
        Else
            btn_empresa.BackColor = Color.Green
            My.Settings.empresa = txt_empresa.Text
            My.Settings.empresa_exist = True
            My.Settings.Save()
            Me.Close()
        End If

        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Empresa", My.Settings.empresa)
        Form1.username_text.Text = My.Settings.username_pc & "   [" & My.Settings.empresa & "]"
        My.Settings.new_instalation = "FALSE"
        codigos.Instalacion_win()
        'Dim filew As System.IO.StreamWriter
        'filew = My.Computer.FileSystem.OpenTextFileWriter("C:\GrupoICS\data.txt", True)
        'filew.WriteLine(My.Settings.empresa)
        'filew.Close()

    End Sub
End Class