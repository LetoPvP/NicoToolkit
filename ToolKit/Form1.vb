Imports System.IO
Imports System.Net
Imports System.Management.Instrumentation
Imports System.Management
'' Para comilla " extra escribir esto  ->  Chr(34)

Public Class Form1
    'moverventana
    Dim NewPoint As New System.Drawing.Point()
    Dim X, Y, x_update As Integer
    Dim obj As New Process
    Dim WithEvents CLIENTE As New WebClient 'descarga asincrona
    Dim DAY As String

    ''MOVER VENTANA
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

    'ACTUALIZACION
    Public Sub Comprobar_version()
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString("http://projectzero.es/Downloads/datos.txt")
        My.Settings.version_remote = reply
        If My.Settings.version_local <> My.Settings.version_remote Then Actualizar()
    End Sub
    Public Sub Actualizar()
        'LIMPIO
        Try
            If File.Exists("C:\GrupoICS\NicoToolkitUpdater.exe") = True Then
                My.Computer.FileSystem.DeleteFile("C:\GrupoICS\NicoToolkitUpdater.exe")
            End If
            x_update = 1
            ProgressBar1.Visible = True
            CLIENTE.DownloadFileAsync(New Uri("http://www.projectzero.es/Downloads/NicoToolkitUpdater.exe"), "C:\GrupoICS\NicoToolkitUpdater.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
            My.Settings.version_local = My.Settings.version_remote
        Catch ex As Exception
            My.Settings.error_code = "G001"
            codigos.MailErrorCode()
            Me.Close()
        End Try

    End Sub
    Private Sub CLIENTE_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles CLIENTE.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage 'VA INDICANDO EN EL PROGRESSBAR EL PORCENTAJE DESCARGADO.
    End Sub
    Private Sub CLIENTE_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles CLIENTE.DownloadFileCompleted
        If x_update = 1 Then

            Process.Start("C:\GrupoICS\NicoToolkitUpdater.exe")
            Me.Close()
        End If
        If x_update = 2 Then
            ComboBox1.Visible = True
            ComboBox2.Visible = True
            ComboBox3.Visible = True
            Label21.Visible = True
        End If
    End Sub

    'PROGRAMADOR TAREAS
    Private Sub ChkRevTask_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRevTask.CheckedChanged
        If ChkRevTask.CheckState = CheckState.Checked Then
            Try
                If File.Exists("C:\GrupoICS\NicoToolkitTask.exe") = True Then
                    My.Computer.FileSystem.DeleteFile("C:\GrupoICS\NicoToolkitTask.exe")
                    ProgressBar1.Visible = True
                    CLIENTE.DownloadFileAsync(New Uri("http://www.projectzero.es/Downloads/NicoToolkitTask.exe"), "C:\GrupoICS\NicoToolkitTask.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    x_update = 2
                    ComboBox1.Visible = True
                    ComboBox2.Visible = True
                    ComboBox3.Visible = True
                    Label21.Visible = True
                Else
                    ProgressBar1.Visible = True
                    CLIENTE.DownloadFileAsync(New Uri("http://www.projectzero.es/Downloads/NicoToolkitTask.exe"), "C:\GrupoICS\NicoToolkitTask.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
                    x_update = 2
                End If

            Catch ex As Exception
                My.Settings.error_code = "G002"
                codigos.MailErrorCode()
                Me.Close()
            End Try
        Else
            ComboBox1.Visible = False
            ComboBox2.Visible = False
            ComboBox3.Visible = False
            Label21.Visible = False
        End If

    End Sub
    Private Sub LbInformeTask_Click(sender As Object, e As EventArgs) Handles LbInformeTask.Click
        'PANEL PROGRAMADOR REVISIONES
        Panel6.BringToFront()
        ComboBox1.SelectedItem = My.Settings.day_program
        ComboBox2.SelectedItem = My.Settings.hour_program
        ComboBox3.SelectedItem = My.Settings.min_program
        If My.Settings.task_win = True Then
            ChkRevTask.CheckState = CheckState.Checked
        Else
            ChkRevTask.CheckState = CheckState.Unchecked
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Lunes" Then DAY = "MON"
        If ComboBox1.SelectedItem = "Martes" Then DAY = "TUE"
        If ComboBox1.SelectedItem = "Miercoles" Then DAY = "WED"
        If ComboBox1.SelectedItem = "Jueves" Then DAY = "THU"
        If ComboBox1.SelectedItem = "Viernes" Then DAY = "FRI"
    End Sub
    Private Sub BtSaveRev_Click(sender As Object, e As EventArgs) Handles BtSaveRevTask.Click
        If ChkRevTask.CheckState = CheckState.Checked Then
            Shell("SCHTASKS /Delete /TN " & Chr(34) & "NicoToolkit - Revisión automática" & Chr(34) & " /F")
            Shell("schtasks /create /TN " & Chr(34) & "NicoToolkit - Revisión automática" & Chr(34) & " /TR " & Chr(34) & "C:\GrupoICS\NicoToolkitTask.exe" & Chr(34) & " /SC MONTHLY /MO first /D " & DAY & " /ST " & ComboBox2.SelectedItem & ":" & ComboBox3.SelectedItem & ":00")
            'schtasks /create /TN “Ejecutar el Bloc de notas” /TR notepad.exe /SC MONTHLY /MO first /D TUE /ST 13:55:00
            My.Settings.task_win = True
            My.Settings.day_program = ComboBox1.SelectedItem
            My.Settings.hour_program = ComboBox2.SelectedItem
            My.Settings.min_program = ComboBox3.SelectedItem
        End If
        If ChkRevTask.CheckState = CheckState.Unchecked Then
            Shell("SCHTASKS /Delete /TN " & Chr(34) & "NicoToolkit - Revisión automática" & Chr(34) & " /F")
            My.Settings.task_win = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtExit.Click
        codigos.Ocultar_form()
    End Sub
    Private Sub LbHome_Click(sender As Object, e As EventArgs) Handles LbHome.Click
        Panel1.BringToFront()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles LbTools.Click
        Panel2.BringToFront()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles LbSupport.Click
        Panel3.BringToFront()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles LbRev.Click
        Panel4.BringToFront()
        codigos.APP_list()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Panel5.BringToFront()
    End Sub

    Private Sub LbInforme_Click(sender As Object, e As EventArgs) Handles LbInforme.Click
        'codigos.Revision_nfo()
        informe_lock.Show()
    End Sub
    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        codigos.Revision_ics()
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        settings_toolkit.Show()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        screen_shot.Show()
    End Sub
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        'MENU
        menu_notifications.Show()
        menu_notifications.Activate()
        menu_notifications.menu_programacion()
    End Sub

    Private Sub panic_button_Click(sender As Object, e As EventArgs) Handles panic_button.Click
        Me.Close()
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Comprobar_version()
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        codigos.Revision_ics()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        codigos.fastpc()
        codigos.temp_clear()
    End Sub
    Private Sub Tmr_infopc_Tick(sender As Object, e As EventArgs) Handles Tmr_infopc.Tick
        codigos.checkstate_pc()
        codigos.statepc()
    End Sub

    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles PictureBox22.Click
        codigos.fastpc()
    End Sub

    Private Sub PictureBox22_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox22.MouseEnter
        PictureBox22.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox22_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox22.MouseLeave
        PictureBox22.BorderStyle = BorderStyle.None
        PictureBox24.BorderStyle = BorderStyle.None
        PictureBox27.BorderStyle = BorderStyle.None
        PictureBox26.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox24_Click(sender As Object, e As EventArgs) Handles PictureBox24.Click
        codigos.temp_clear()
    End Sub

    Private Sub PictureBox26_Click(sender As Object, e As EventArgs) Handles PictureBox26.Click
        codigos.outlook_panel()
    End Sub

    Private Sub PictureBox27_Click(sender As Object, e As EventArgs) Handles PictureBox27.Click
        Shell("SC STOP Spooler")
        Shell("SC START Spooler")
    End Sub

    Private Sub PictureBox24_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox24.MouseEnter
        PictureBox24.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox24_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox24.MouseLeave
        PictureBox22.BorderStyle = BorderStyle.None
        PictureBox24.BorderStyle = BorderStyle.None
        PictureBox27.BorderStyle = BorderStyle.None
        PictureBox26.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox26_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox26.MouseEnter
        PictureBox26.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox26_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox26.MouseLeave
        PictureBox22.BorderStyle = BorderStyle.None
        PictureBox24.BorderStyle = BorderStyle.None
        PictureBox27.BorderStyle = BorderStyle.None
        PictureBox26.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox27_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox27.MouseEnter
        PictureBox27.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox27_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox27.MouseLeave
        PictureBox22.BorderStyle = BorderStyle.None
        PictureBox24.BorderStyle = BorderStyle.None
        PictureBox27.BorderStyle = BorderStyle.None
        PictureBox26.BorderStyle = BorderStyle.None
    End Sub

    Private Sub TmrUpdate_Tick(sender As Object, e As EventArgs) Handles TmrUpdate.Tick
        Comprobar_version()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'comprobar
        codigos.LoadHome()
        codigos.migration()
        Tmr_infopc.Start()
        TmrUpdate.Start()
        'If My.Settings.new_instance = False Then Comprobar_version()
    End Sub

End Class