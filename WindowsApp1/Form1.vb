Imports System.IO.Ports
Imports System.Diagnostics
Imports System.Threading.Tasks
Imports System.Timers

Public Class SmartUPS
    Dim ComPortList As New ArrayList
    Dim mySerialPort As New SerialPort()
    Dim indata As String
    Dim timer As New Timer(1000)
    Dim retimer As New Timer(2000)
    Dim Contimer As New Timer(21000)
    Dim hybertimer As New Timer(300000)
    Dim fullcharge As Boolean
    Dim firstporttime As Boolean = True
    Dim UPScon As Boolean
    Dim lastlive As Date = TimeOfDay()
    Dim contimeconcheck As Boolean
    Dim hyberchecked As Boolean = Settings2.Default.hibernate
    Dim hybertimecount As Integer = 0


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortBox.SelectedIndexChanged

    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings2.Default.LastAction = "A"
        Con_Lable.CheckForIllegalCrossThreadCalls = False
        PortBox.CheckForIllegalCrossThreadCalls = False





        GetSerialPortNames()

        PortBox.SelectedItem = Settings2.Default.ConComPortName
        ' AddHandler timer.Elapsed, AddressOf HandleTimer
        'AddHandler retimer.Elapsed, AddressOf HandlereTimer
        ActTime.Value = Settings2.Default.ActTime
        hyber_chck.Checked = hyberchecked
        Try
            If (mySerialPort.IsOpen = False) Then
                firstporttime = True
                If (openport(PortBox.SelectedItem()) = "Port Opened") Then

                End If
                Settings2.Default.ActTime = ActTime.Value
            End If
            'firstporttime = True
            'openport(Settings2.Default.ConComPortName)
            'Dim ss As EventArgs = Nothing
            'Button1_Click("send", ss)
            'If (UPScon = False) Then
            '    mySerialPort.Close()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error in Last Configured Port")
        End Try
        Settings2.Default.Powerleft = 0
        AddHandler Contimer.Elapsed, AddressOf ConTimerHndl
        AddHandler hybertimer.Elapsed, AddressOf hyberTimerHndl
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = SystemIcons.Application
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Smart UPS"
        NotifyIcon1.BalloonTipText = "Starting"
        NotifyIcon1.ShowBalloonTip(5000)
        NotifyIcon1.Icon = Icon
        NotifyIcon1.Text = "Smart UPS"
        Contimer.Start()
    End Sub
    Sub GetSerialPortNames()
        ' Show all available COM ports.

        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComPortList.Add(sp)
            PortBox.Items.Add(sp)
        Next
        PortBox.SelectedItem = PortBox.Items(0)
    End Sub

    Function ConSPort(prt As String)
        mySerialPort.Close()
        Settings2.Default.ConComPortName = prt

        If (mySerialPort.IsOpen = False) Then
            With mySerialPort
                .BaudRate = 115200
                .Parity = Parity.None
                .StopBits = StopBits.One
                .DataBits = 8
                .Handshake = Handshake.None

                .RtsEnable = True
                .PortName = prt
                AddHandler mySerialPort.DataReceived, AddressOf DataReceviedHandler

                .Open()

            End With
            Contimer.Start()
            If (mySerialPort.IsOpen = True) Then
                CreateObject("WScript.Shell").Popup("Port Opened", 5, "Smart UPS", 64)

                Contimer.Start()
            End If
            mySerialPort.Write("U")
            firstporttime = True
        Else
            Return "PO"
        End If





    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (mySerialPort.IsOpen = False) Then
            firstporttime = True
            If (openport(PortBox.SelectedItem()) = "Port Opened") Then

            End If
            Settings2.Default.ActTime = ActTime.Value
        End If


    End Sub

    Public Sub DataReceviedHandler(sender As Object, e As SerialDataReceivedEventArgs)

        Dim procstatinfo As New System.Diagnostics.ProcessStartInfo("shutdown")
        procstatinfo.WindowStyle = ProcessWindowStyle.Hidden
        Dim Lastact As Char = Settings2.Default.LastAction
        Try
            If (mySerialPort.IsOpen = True) Then
                indata = mySerialPort.ReadLine()
                If (indata = "L") Then


                    contimeconcheck = True

                End If
                If ((indata = "Z") AndAlso (Lastact = "A")) Then
                    If (hyber_chck.Checked = False) Then
                        procstatinfo.Arguments = "/s /f /t 1200"
                        Process.Start(procstatinfo)
                    Else
                        hybertimer.Start()



                    End If



                    ' timer.Start()
                    ' Settings2.Default.Powerleft = 0
                    Settings2.Default.LastAction = "Z"
                    Settings2.Default.Save()
                    ' retimer.Stop()



                End If
                If ((indata = "A") AndAlso (Lastact = "Z")) Then
                    procstatinfo.Arguments = "/a"
                    Process.Start(procstatinfo)
                    'timer.Stop()
                    hybertimer.Stop()
                    Settings2.Default.LastAction = "A"
                    Settings2.Default.Save()


                    ' If (Settings2.Default.LastAction = "A") Then
                    '         retimer.Start()
                    ' End If
                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error In Data Recevie")
        End Try




    End Sub



    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Settings2.Default.Save()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (mySerialPort.IsOpen = True) Then
            mySerialPort.Close()
        End If
        Settings2.Default.Save()


    End Sub
    Function openport(opnprt)
        Try
            ConSPort(opnprt)
            Return "Port Opened"
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error in Openning Port")
        End Try

    End Function
    Private Async Sub HandleTimer(sender As Object, e As EventArgs)
        Dim lpdt As String = Settings2.Default.Powerleft
        Dim procstatinfo As New System.Diagnostics.ProcessStartInfo("shutdown")
        procstatinfo.WindowStyle = ProcessWindowStyle.Hidden
        If (lpdt >= 15) Then
            timer.Stop()
            procstatinfo.Arguments = "/s /f /t " & ActTime.Value
            Process.Start(procstatinfo)

            MsgBox(timer.Enabled,, "timer enabled shutdown")
        End If
        'Await Task.Run(Sub()



        If (Settings2.Default.LastAction = "Z") Then
            Settings2.Default.Powerleft = lpdt + 0.5
            Settings2.Default.Save()
        End If
        If (lpdt >= 15) Then
            timer.Stop()
        End If

        MsgBox(lpdt)

        '  End Sub)
    End Sub
    Private Async Sub HandlereTimer(sender As Object, e As EventArgs)

        Dim lpdt As String = Settings2.Default.Powerleft
        If (lpdt <= 1) Then
            retimer.Stop()
            MsgBox("retimer " & retimer.Enabled)
        End If

        ' Await Task.Run(Sub()


        Settings2.Default.Powerleft = lpdt - 0.5
        Settings2.Default.Save()
        MsgBox(lpdt,, "retimer")

        '     End Sub)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        MsgBox(Settings2.Default.Powerleft)
    End Sub

    Private Sub Rescan_Btn_Click(sender As Object, e As EventArgs) Handles Rescan_Btn.Click
        PortBox.Items.Clear()
        GetSerialPortNames()


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Con_Lable.Click

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Settings2.Default.Save()
    End Sub

    Private Sub Form1_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BTN_MINIMIZE.Click

        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = SystemIcons.Application
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Smart UPS"
        NotifyIcon1.BalloonTipText = "Still Running | Minimized To Tray"
        NotifyIcon1.ShowBalloonTip(50000)
        NotifyIcon1.Icon = Icon
        NotifyIcon1.Text = "Smart UPS"
        Me.Hide()
        ShowInTaskbar = True

    End Sub

    Private Sub PortGrp_Enter(sender As Object, e As EventArgs) Handles PortGrp.Enter

    End Sub

    Private Sub ActTime_ValueChanged(sender As Object, e As EventArgs) Handles ActTime.ValueChanged

    End Sub
    Private Async Sub ConTimerHndl(sender As Object, e As EventArgs)
        If (contimeconcheck = False) Then
            MsgBox("Smart UPS Not Responding", 16, "Smart UPS")
            Con_Lable.BackColor = Color.Red
            Con_Lable.ForeColor = Color.White
            Con_Lable.Text = "Disconnected"
        End If
        If (contimeconcheck = True) Then

            Con_Lable.BackColor = Color.Green
            Con_Lable.ForeColor = Color.White
            Con_Lable.Text = "Connected"
        End If
        If (mySerialPort.IsOpen = True) Then

        End If
        If (mySerialPort.IsOpen = False) Then
            If (openport(PortBox.SelectedItem()) = "Port Opened") Then

            End If
        End If
        contimeconcheck = False
    End Sub

    Private Sub hyber_chck_CheckedChanged(sender As Object, e As EventArgs) Handles hyber_chck.CheckedChanged
        Settings2.Default.hibernate = hyber_chck.Checked
        hyberchecked = hyber_chck.Checked
    End Sub
    Private Async Sub hyberTimerHndl(sender As Object, e As EventArgs)
        If (hyber_chck.Checked = True) Then
            If (hybertimecount >= 3) Then
                hybertimecount = 0
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Warning
                NotifyIcon1.BalloonTipTitle = "Smart UPS"
                NotifyIcon1.BalloonTipText = "Hybernating in 30sec"
                NotifyIcon1.ShowBalloonTip(1000)
                'CreateObject("WScript.Shell").Popup(hybertimecount & " eqaul 4", 5, "Smart UPS", 36)
                Dim hyberwarningreturn As Integer = CreateObject("WScript.Shell").Popup("Hybernating in 25 Sec" & vbCrLf & " Proceed?", 25, "Smart UPS", 52)
                If (hyberwarningreturn = 6) Or (hyberwarningreturn = -1) Then

                    Dim hybertatinfo As New System.Diagnostics.ProcessStartInfo("shutdown")
                    hybertatinfo.WindowStyle = ProcessWindowStyle.Hidden
                    hybertatinfo.Arguments = "/h"
                    Process.Start(hybertatinfo)
                End If


                If (hyberwarningreturn = 7) Then
                        CreateObject("WScript.Shell").Popup("Hibernating Postponed by 5mins", 5, "Smart UPS", 16)
                    End If

                End If
                hybertimecount = hybertimecount + 1
            'CreateObject("WScript.Shell").Popup(hybertimecount & " less than 4", 5, "Smart UPS", 64)
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Warning
            NotifyIcon1.BalloonTipTitle = "Smart UPS"
            NotifyIcon1.BalloonTipText = "Hibernating in " & Math.Round(((hybertimecount * 300000) / 60) / 60) & " Sec"
            NotifyIcon1.ShowBalloonTip(1000)
        End If

    End Sub
End Class
