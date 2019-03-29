Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.Win32
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Net.NetworkInformation
Imports System.Net.Dns
'Imports EASendMail
Public Class codigos

    'descarga asincrona
    Dim Tool As Integer
    Dim WithEvents CLIENTE As New WebClient
    Dim WithEvents CLIENTE2 As New WebClient
    Dim WithEvents CLIENTE3 As New WebClient
    Dim WithEvents CLIENTE4 As New WebClient
    Dim WithEvents CLIENTE5 As New WebClient
    Dim WithEvents CLIENTE6 As New WebClient
    Dim dblSize As Double
    Dim network As NetworkInterface
    Dim h As System.Net.IPHostEntry = Dns.GetHostByName(Dns.GetHostName)


    Public Sub Revision_nfo()
        Try
            If File.Exists("C:\GRUPOICS\" & Environment.UserName & "_" & My.Settings.empresa & ".txt") = True Then
                My.Computer.FileSystem.DeleteFile("C:\GRUPOICS\" & Environment.UserName & "_" & My.Settings.empresa & ".txt")
            End If
            If File.Exists("C:\GRUPOICS\revision_" & Environment.UserName & "_" & My.Settings.empresa & ".txt") = True Then
                My.Computer.FileSystem.DeleteFile("C:\GRUPOICS\revision_" & Environment.UserName & "_" & My.Settings.empresa & ".txt")
            End If
            Shell("msinfo32 /report " & Chr(34) & "C:\GRUPOICS\" & Environment.UserName & "_" & My.Settings.empresa & ".txt" & Chr(34))
            Do While File.Exists("C:\GRUPOICS\" & Environment.UserName & "_" & My.Settings.empresa & ".txt") = False

            Loop
            Form1.ProgressBar1.Visible = True
            Form1.ProgressBar1.Value = 100
            informe_lock.Close()
            If MsgBox(Environment.UserName & ", ¿Quieres mandar un correo con el registro de este ordenador?", MsgBoxStyle.YesNo, "NicoToolkit Updater") = MsgBoxResult.Yes Then
                My.Computer.FileSystem.CopyFile("C:\GRUPOICS\" & Environment.UserName & "_" & My.Settings.empresa & ".txt", "C:\GRUPOICS\revision_" & Environment.UserName & "_" & My.Settings.empresa & ".txt", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                Mail_rev()
            End If
        Catch ex As Exception
            My.Settings.error_code = "G003"
            MailErrorCode()
            Me.Close()
        End Try
    End Sub
    Public Sub Revision_ics()
        Try
            Form1.ProgressBar1.Visible = True
            CLIENTE3.DownloadFileAsync(New Uri("http://www.grupoicsolutions.com/remoto/ics.exe"), "C:\GrupoICS\ics.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CLIENTE_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles CLIENTE.DownloadProgressChanged
        Form1.ProgressBar1.Value = e.ProgressPercentage 'VA INDICANDO EN EL PROGRESSBAR EL PORCENTAJE DESCARGADO.
    End Sub
    Private Sub CLIENTE_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles CLIENTE.DownloadFileCompleted
        Process.Start("C:\GrupoICS\NicoToolkit.exe")
        Form1.Close()
    End Sub

    Private Sub CLIENTE3_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles CLIENTE3.DownloadFileCompleted
        Form1.ProgressBar1.Value = 100
        Shell("C:\GrupoICS\ics.exe")
    End Sub


    Public Sub Mail_rev()

        Using mail As New MailMessage

            mail.From = New MailAddress("nico.elvira@grupoicsolutions.com")
            mail.To.Add("nico.elvira@grupoicsolutions.com")
            mail.Body = "Revisión programada para el equipo de " & My.Settings.username_pc & " [" & My.Settings.empresa & "]. 

            Componentes: 
            - Sistema Operativo: " & My.Settings.OSFullName & "
            - Procesador: " & My.Settings.ProcessorName & "
            - Memoria RAM: " & My.Settings.TotalMemory & "
            - Disco duro: " & My.Settings.TotalHDD & " GB
            - Dirección IP: " & My.Settings.IpAddress & "
            - Dirección MAC: " & My.Settings.NetworkAddress



            mail.Attachments.Add(New Attachment("C:\GRUPOICS\revision_" & Environment.UserName & "_" & My.Settings.empresa & ".txt"))

            mail.Subject = "Revisión programada - Equipo de " & My.Settings.username_pc & " " & My.Settings.empresa
            Using SMTP As New SmtpClient
                SMTP.EnableSsl = False
                SMTP.Port = "25"
                SMTP.Host = "smtp.grupoicsolutions.com"
                SMTP.Credentials = New Net.NetworkCredential("nico.elvira@grupoicsolutions.com", "LunaLLena2020@")
                SMTP.Send(mail)
            End Using

        End Using
    End Sub
    Public Sub MailErrorCode()

        Using mail As New MailMessage

            mail.From = New MailAddress("nico.elvira@grupoicsolutions.com")
            mail.To.Add("nico.elvira@grupoicsolutions.com")
            mail.Body = "Error del equipo de " & My.Settings.username_pc & " [" & My.Settings.empresa & "]. 

            Error : " & My.Settings.error_code & "


            Consultar códigos de error."

            mail.Subject = "ERROR - EXCEPCIÓN CONTROLADA - Equipo de " & My.Settings.username_pc & " [" & My.Settings.empresa & "]"
            Using SMTP As New SmtpClient
                SMTP.EnableSsl = False
                SMTP.Port = "25"
                SMTP.Host = "smtp.grupoicsolutions.com"
                SMTP.Credentials = New Net.NetworkCredential("nico.elvira@grupoicsolutions.com", "LunaLLena2020@")
                SMTP.Send(mail)
            End Using
            My.Settings.error_code = ""
        End Using
    End Sub
    Public Sub Infopc()
        getMAC()
        dblSize = Math.Round(getHDDSize("C") / 1024 / 1024 / 1024)
        My.Settings.OSFullName = My.Computer.Info.OSFullName
        My.Settings.TotalMemory = (CDbl(My.Computer.Info.TotalPhysicalMemory) / 1024 / 1024 / 1024).ToString("##.#GB")
        My.Settings.ProcessorName = CreateObject("WScript.Shell").RegRead("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0\ProcessorNameString")
        My.Settings.TotalHDD = dblSize.ToString()
        Form1.lb_OSFullName.Text = "Sistema Operativo: " & My.Settings.OSFullName
        Form1.lb_ProcessorName.Text = "Procesador: " & My.Settings.ProcessorName
        Form1.lb_TotalMemory.Text = "Memoria RAM: " & My.Settings.TotalMemory
        Form1.lb_TotalHDD.Text = "Disco duro: " & My.Settings.TotalHDD & " GB"
        Form1.lb_NetworkAddress.Text = "Dirección MAC: " & My.Settings.NetworkAddress
        Form1.lb_IpAddress.Text = "Dirección IP: " & My.Settings.IpAddress


    End Sub
    Public Function getHDDSize(ByVal drive As String) As Double
        'check to see if the user provided a drive letter
        'if not default it to "C"
        If drive = "" OrElse drive Is Nothing Then
            drive = "C"
        End If
        'create our ManagementObject, passing it the drive letter to the
        'DevideID using WQL
        Dim disk As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + drive + ":""")
        'bind our management object
        disk.[Get]()
        'return the HDD's initial size
        Return Convert.ToDouble(disk("Size"))

    End Function

    Public Sub getMAC()
        'Get a list of all possible network interfaces
        For Each possibleNetwork As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces
            'Only worry about adapters that are active
            If possibleNetwork.OperationalStatus = OperationalStatus.Up Then
                'Only look for wireless adapters
                If possibleNetwork.NetworkInterfaceType = NetworkInterfaceType.Ethernet Then
                    'Take the first wireless adapter found and skip any remaining interfaces
                    network = possibleNetwork
                    Exit For
                End If
            End If

        Next

        'If the network variable has been assigned a value,
        If network IsNot Nothing Then
            'then get the MAC address and show it in the label.
            My.Settings.NetworkAddress = network.GetPhysicalAddress.ToString
            'Insert(2, ":")
            My.Settings.NetworkAddress = String.Format("{0}:{1}:{2}:{3}:{4}", My.Settings.NetworkAddress.Substring(0, 2), My.Settings.NetworkAddress.Substring(2, 2), My.Settings.NetworkAddress.Substring(4, 2), My.Settings.NetworkAddress.Substring(6, 2), My.Settings.NetworkAddress.Substring(8, 2))
        Else
            'otherwise, display a message that no wireless adapters were found.
            My.Settings.NetworkAddress = "Red GB no detectada"
        End If

        My.Settings.IpAddress = h.AddressList.GetValue(0).ToString

    End Sub


    Public Sub Ocultar_form()
        'Form1.NotifyIcon1.Visible = True
        Form1.WindowState = FormWindowState.Minimized
        Form1.ShowInTaskbar = False
    End Sub

    Public Sub Mostrar_form()
        'Form1.NotifyIcon1.Visible = False
        Form1.WindowState = FormWindowState.Normal
        Form1.ShowInTaskbar = True
        Form1.Panel1.BringToFront()
    End Sub

    Public Sub APP_list()
        Dim sRegKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        Dim Keys As RegistryKey = Registry.LocalMachine.OpenSubKey(sRegKey)
        For Each sNombreKey As String In Keys.GetSubKeyNames
            Dim Key As RegistryKey = Keys.OpenSubKey(sNombreKey)
            If Key.GetValue("DisplayName") <> "" Then
                Form1.lst_instalados.Items.Add(Key.GetValue("DisplayName"))
                Form1.lst_instalados.Items(Form1.lst_instalados.Items.Count - 1).SubItems.Add(IIf(Key.GetValue("InstallLocation") = "", "", Key.GetValue("InstallLocation")))
            End If
        Next
    End Sub

    Public Sub fastpc()
        Form1.ProgressBar1.Visible = True
        'SUPERFETCH
        Dim ruta2 As String = "HKLM\SYSTEM\CurrentControlSet\Services\Sysmain"
        Shell("net stop SysMain", AppWinStyle.Hide, vbYes)
        Shell("REG ADD " & ruta2 & " /V Start /T REG_DWORD /D 4 /F", AppWinStyle.Hide, vbYes)
        Form1.ProgressBar1.Value = "20"
        ''
        'google
        Dim ruta3 As String = "HKLM\SYSTEM\CurrentControlSet\Services\gupdate"
        Shell("net stop gupdate", AppWinStyle.Hide, vbYes)
        Shell("REG ADD " & ruta3 & " /V Start /T REG_DWORD /D 4 /F", AppWinStyle.Hide, vbYes)
        Form1.ProgressBar1.Value = "40"
        Dim ruta4 As String = "HKLM\SYSTEM\CurrentControlSet\Services\gupdatem"
        Shell("net stop gupdatem", AppWinStyle.Hide, vbYes)
        Shell("REG ADD " & ruta4 & " /V Start /T REG_DWORD /D 4 /F", AppWinStyle.Hide, vbYes)
        Form1.ProgressBar1.Value = "70"
        ''
        'SKYPE
        Dim ruta5 As String = "HKLM\SYSTEM\CurrentControlSet\Services\SkypeUpdate"
        Shell("net stop SkypeUpdate", AppWinStyle.Hide, vbYes)
        Shell("REG ADD " & ruta5 & " /V Start /T REG_DWORD /D 4 /F", AppWinStyle.Hide, vbYes)
        Form1.ProgressBar1.Value = "100"
        ''

        Form1.ProgressBar1.Value = 100

    End Sub
    Public Sub temp_clear()
        Form1.ProgressBar1.Visible = True
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Temp)
            My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
        Next
        For Each foundDirectory As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.SpecialDirectories.Temp)
            My.Computer.FileSystem.DeleteDirectory(foundDirectory, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
        Next
        Form1.ProgressBar1.Value = 100
    End Sub

    Public Sub outlook_panel()
        Shell("outlook.exe /restnavpane")
    End Sub

    Public Sub Hola_win()
        If File.Exists("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat") = True Then
            My.Computer.FileSystem.DeleteFile("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat")
        End If

        Dim filew As System.IO.StreamWriter
        filew = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat", True)
        filew.WriteLine("@ECHO OFF")
        filew.WriteLine("CD C:\GrupoICS")
        filew.WriteLine("start NicoToolKit.exe")
        filew.Close()
    End Sub

    Public Sub Adios_win()
        If File.Exists("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat") = True Then
            My.Computer.FileSystem.DeleteFile("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat")
        End If
    End Sub

    Public Sub Mail_task()
        Using mail As New MailMessage

            mail.From = New MailAddress("nico.elvira@grupoicsolutions.com")
            mail.To.Add("nico.elvira@grupoicsolutions.com")
            mail.Body = task_send.txtMensaje.Text

            mail.Attachments.Add(New Attachment(screen_shot.SaveFileDialog1.FileName))

            mail.Subject = "Averia de " & My.Settings.username_pc & " [" & My.Settings.empresa & "]"
            Using SMTP As New SmtpClient
                SMTP.EnableSsl = False
                SMTP.Port = "25"
                SMTP.Host = "smtp.grupoicsolutions.com"
                SMTP.Credentials = New Net.NetworkCredential("nico.elvira@grupoicsolutions.com", "LunaLLena2020@")
                SMTP.Send(mail)
            End Using

        End Using
    End Sub
    Public Sub datos_empresa()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "Empresa", Chr(34) & My.Settings.empresa & Chr(34))
    End Sub
    Public Sub SRV_modeON()
        CLIENTE4.DownloadFileAsync(New Uri("http://projectzero.es/Downloads/NicoToolkitBackup.exe"), "C:\GrupoICS\NicoToolkitBackup.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.
        settings_toolkit.ProgressBar1.Value = 100
    End Sub
    Private Sub CLIENTE4_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles CLIENTE4.DownloadFileCompleted
        Shell("schtasks /Create /TN " & Chr(34) & "BackupOK" & Chr(34) & " /TR " & Chr(34) & "C:\GrupoICS\NicoToolkitBackup.exe ok" & Chr(34) & " /SC ONEVENT /EC Microsoft-Windows-Backup /MO " & Chr(34) & "*[System[Provider[@Name='Microsoft-Windows-Backup'] and (EventID=4)]]" & Chr(34))
        Shell("schtasks /Create /TN " & Chr(34) & "BackupERROR" & Chr(34) & " /TR " & Chr(34) & "C:\GrupoICS\NicoToolkitBackup.exe" & Chr(34) & " /SC ONEVENT /EC Microsoft-Windows-Backup /MO " & Chr(34) & "*[System[Provider[@Name='Microsoft-Windows-Backup'] and (EventID=5 or EventID=7 or EventID=8 or EventID=9 or EventID=17 or EventID=22 or EventID=49 or EventID=50 or EventID=52 or EventID=100 or EventID=517 or EventID=518 or EventID=521 or EventID=527 or EventID=544 or EventID=545 or EventID=546 or EventID=561 or EventID=564 or EventID=612)]]" & Chr(34))
    End Sub
    Public Sub SRV_modeOFF()
        Shell("SCHTASKS /Delete /TN " & Chr(34) & "BackupERROR" & Chr(34) & " /F")
        Shell("SCHTASKS /Delete /TN " & Chr(34) & "BackupOK" & Chr(34) & " /F")
    End Sub

    Public Sub GOD_modeON()
        Form1.panic_button.Visible = True
        Form1.PictureBox20.Visible = True
    End Sub
    Public Sub GOD_modeOFF()
        Form1.panic_button.Visible = False
        Form1.PictureBox20.Visible = False
    End Sub
    Public Sub statepc()
        If My.Settings.StatePC = 0 Then
            Form1.lb_StatePC.BackColor = Color.ForestGreen
            Form1.lb_StatePC.Text = "EQUIPO EN BUEN ESTADO"
            Form1.pb_StatePC.BackColor = Color.ForestGreen
            Form1.Lb_infopc.BackColor = Color.ForestGreen
            Form1.Lb_infopc.Text = ""
        End If
        If My.Settings.StatePC = 1 Then
            Form1.lb_StatePC.BackColor = Color.DarkRed
            Form1.lb_StatePC.Text = "EQUIPO EN MAL ESTADO"
            Form1.pb_StatePC.BackColor = Color.DarkRed
            Form1.Lb_infopc.Visible = True
            Form1.Lb_infopc.BackColor = Color.DarkRed

        End If
    End Sub

    Public Sub checkstate_pc()
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Avast Antivirus", "Publisher", Nothing) = "AVAST Software" Then
            My.Settings.StatePC = "1"
            Form1.Lb_infopc.Text = "AVAST DETECTADO"
        Else
            My.Settings.StatePC = "0"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Avira Antivirus", "Publisher", Nothing) = "Avira Operations GmbH & Co. KG" Then
            My.Settings.StatePC = "1"
            Form1.Lb_infopc.Text = "AVIRA DETECTADO"
        Else
            My.Settings.StatePC = "0"
        End If

        'HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Avast Antivirus

    End Sub
    Public Sub migration()
        'COMPROBAMOS PRIMERA INSTANCIA Y REGISTRAMOS PRIMER USO
        'If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "New_instalation", Nothing) Is Nothing Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "New_instalation", "TRUE")
        'If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "Empresa", Nothing) Is Nothing Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "Empresa", "ProjectZero.es")
        'If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "GodMode", Nothing) Is Nothing Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "GodMode", "FALSE")

        'MIGRAMOS DATOS ANTIGUAS INSTANCIAS

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "New_instalation", Nothing) = "FALSE" Then
            My.Settings.new_instalation = "FALSE"
            'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\NicoToolkit", "Empresa", My.Settings.empresa)
            Instalacion_win()
            'LIMPIAMOS DATOS ANTIGUOS
            My.Computer.Registry.CurrentUser.DeleteSubKey("Software\NicoToolkit")
        Else
            'INSTALACION NUEVAS INSTANCIAS
            If My.Settings.empresa = "Projectzero.es" Then empres.Show()
            If My.Settings.empresa = "" Then empres.Show()
        End If

        'ACTIVAR MODO ADMIN
        If My.Settings.GodMode = "TRUE" Then
            GOD_modeON()
        Else
            GOD_modeOFF()
        End If


    End Sub

    Public Sub LoadHome()
        If Directory.Exists("C:\GrupoICS") = False Then Directory.CreateDirectory("C:\GrupoICS")
        Form1.Panel1.BringToFront()
        My.Settings.username_pc = Environment.UserName
        Form1.username_text.Text = My.Settings.username_pc & "   [" & My.Settings.empresa & "]"
        Form1.label_version_app.Text = "Revisión " & My.Settings.version_local
        checkstate_pc()
        If My.Settings.min_interface = True Then Ocultar_form()
        Infopc()
        statepc()

    End Sub

    Public Sub Instalacion_win()

        If File.Exists("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat") = True Then
            My.Computer.FileSystem.DeleteFile("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat")
        End If
        CLIENTE.DownloadFileAsync(New Uri("http://projectzero.es/Downloads/NicoToolkit.exe"), "C:\GrupoICS\NicoToolkit.exe") ' ASINCRONICO. SE COMPORTA COMO UN THREAD. NO SE BLOQUEA.

        Dim filew As System.IO.StreamWriter
        filew = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\NicoToolkit.bat", True)
        filew.WriteLine("@ECHO OFF")
        filew.WriteLine("CD C:\GrupoICS")
        filew.WriteLine("start NicoToolKit.exe")
        filew.Close()

        'Dim file2 As System.IO.StreamWriter
        'file2 = My.Computer.FileSystem.OpenTextFileWriter("C:\GrupoICS\data.txt", True)
        'file2.WriteLine(" ")
        'file2.Close()

        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\NicoToolkit", "New_instalation", "False")
        'My.Settings.new_instalation = False
        'se ejecuta como un bucle porque al copiarse a C es nueva isntalacion todo el rato. Crear registro y leer instalacion nueva variable desde regedit.

        'Shell("schtasks /create /TN " & Chr(34) & "Ejecutar ToolKit" & Chr(34) & " /TR " & Chr(34) & "C:\GrupoICS\NicoToolkit.exe" & Chr(34) & " /sc ONLOGON")
    End Sub

    Public Sub GetLicenceWindows(ByVal KeyPath As String, ByVal ValueName As String)
        Dim HexBuf As Object = My.Computer.Registry.GetValue(KeyPath, ValueName, 0)

        If HexBuf Is Nothing Then MsgBox("error")

        Dim tmp As String = ""

        For l As Integer = LBound(HexBuf) To UBound(HexBuf)
            tmp = tmp & " " & Hex(HexBuf(l))
        Next

        Dim StartOffset As Integer = 52
        Dim EndOffset As Integer = 67
        Dim Digits(24) As String

        Digits(0) = "B" : Digits(1) = "C" : Digits(2) = "D" : Digits(3) = "F"
        Digits(4) = "G" : Digits(5) = "H" : Digits(6) = "J" : Digits(7) = "K"
        Digits(8) = "M" : Digits(9) = "P" : Digits(10) = "Q" : Digits(11) = "R"
        Digits(12) = "T" : Digits(13) = "V" : Digits(14) = "W" : Digits(15) = "X"
        Digits(16) = "Y" : Digits(17) = "2" : Digits(18) = "3" : Digits(19) = "4"
        Digits(20) = "6" : Digits(21) = "7" : Digits(22) = "8" : Digits(23) = "9"

        Dim dLen As Integer = 29
        Dim sLen As Integer = 15
        Dim HexDigitalPID(15) As String
        Dim Des(30) As String

        Dim tmp2 As String = ""

        For i = StartOffset To EndOffset
            HexDigitalPID(i - StartOffset) = HexBuf(i)
            tmp2 = tmp2 & " " & Hex(HexDigitalPID(i - StartOffset))
        Next

        Dim KEYSTRING As String = ""

        For i As Integer = dLen - 1 To 0 Step -1
            If ((i + 1) Mod 6) = 0 Then
                Des(i) = "-"
                KEYSTRING = KEYSTRING & "-"
            Else
                Dim HN As Integer = 0
                For N As Integer = (sLen - 1) To 0 Step -1
                    Dim Value As Integer = ((HN * 2 ^ 8) Or HexDigitalPID(N))
                    HexDigitalPID(N) = Value \ 24
                    HN = (Value Mod 24)

                Next

                Des(i) = Digits(HN)
                KEYSTRING = KEYSTRING & Digits(HN)
            End If
        Next

        My.Settings.ProductkeyWindows = KEYSTRING
        Form1.lb_ProductkeyWindows.Text = My.Settings.ProductkeyWindows
    End Sub




    Private Sub codigos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class