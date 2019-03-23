Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.Win32
Public Class settings_toolkit
    'moverventana
    Dim NewPoint As New System.Drawing.Point()
    Dim X, Y, x_update As Integer
    Dim WithEvents CLIENTE As New WebClient
    Dim WithEvents CLIENTE2 As New WebClient
    Private Sub bar_move_MouseDown(sender As Object, e As MouseEventArgs) Handles bar_move.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub
    Private Sub bar_move_MouseMove(sender As Object, e As MouseEventArgs) Handles bar_move.MouseMove
        If e.Button = MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.X -= (X)
            NewPoint.Y -= (Y)
            Me.Location = NewPoint
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Comprobar_version()
    End Sub

    Private Sub check_hola_win_CheckedChanged(sender As Object, e As EventArgs) Handles check_hola_win.CheckedChanged
        Comprobar_hola_win()
    End Sub

    Private Sub settings_toolkit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        label_version_app.Text = "Versión " & My.Settings.version_local
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Validado", Nothing) = "TRUE" Then
            serial_box.Text = "Serial validado."
            check_GOD.Visible = True
        End If

        If My.Settings.hola_win = True Then
            check_hola_win.CheckState = CheckState.Checked
        Else
            check_hola_win.CheckState = CheckState.Unchecked
        End If
        If My.Settings.min_interface = True Then
            check_min_interface.CheckState = CheckState.Checked
        Else
            check_min_interface.CheckState = CheckState.Unchecked
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "ServerMode", Nothing) = "TRUE" Then
            check_srv.CheckState = CheckState.Checked
        Else
            check_srv.CheckState = CheckState.Unchecked
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "GodMode", Nothing) = "TRUE" Then
            check_GOD.CheckState = CheckState.Checked
        Else
            check_GOD.CheckState = CheckState.Unchecked
        End If

    End Sub

    Private Sub check_min_interface_CheckedChanged(sender As Object, e As EventArgs) Handles check_min_interface.CheckedChanged
        If check_min_interface.CheckState = CheckState.Checked Then
            My.Settings.min_interface = True
        Else
            My.Settings.min_interface = False
        End If
    End Sub

    Private Sub check_srv_CheckedChanged(sender As Object, e As EventArgs) Handles check_srv.CheckedChanged
        If check_srv.CheckState = CheckState.Checked Then
            Shell("SCHTASKS /Delete /TN " & Chr(34) & "BackupERROR" & Chr(34) & " /F")
            Shell("SCHTASKS /Delete /TN " & Chr(34) & "BackupOK" & Chr(34) & " /F")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "ServerMode", "TRUE")
            If File.Exists("C:\GrupoICS\NicoToolkitBackup.exe") = True Then My.Computer.FileSystem.DeleteFile("C:\GrupoICS\NicoToolkitBackup.exe")
            codigos.SRV_modeON()
        End If
        If check_srv.CheckState = CheckState.Unchecked Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "ServerMode", "FALSE")
            codigos.SRV_modeOFF()
        End If
    End Sub

    Private Sub check_GOD_CheckedChanged(sender As Object, e As EventArgs) Handles check_GOD.CheckedChanged
        If check_GOD.CheckState = CheckState.Checked Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "GodMode", "TRUE")
            codigos.GOD_modeON()
        End If
        If check_GOD.CheckState = CheckState.Unchecked Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "GodMode", "FALSE")
            codigos.GOD_modeOFF()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString("http://projectzero.es/Downloads/serial.txt")
        If serial_box.Text = reply Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Serial", reply)
            serial_box.Text = "Serial validado."
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Validado", "TRUE")
        Else
            MsgBox("Serial incorrecto")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Validado", "FALSE")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub Comprobar_hola_win()
        If check_hola_win.CheckState = CheckState.Checked Then
            My.Settings.hola_win = True
            codigos.Hola_win()
        End If

        If check_hola_win.CheckState = CheckState.Unchecked Then
            My.Settings.hola_win = False
            codigos.Adios_win()
        End If
    End Sub
End Class