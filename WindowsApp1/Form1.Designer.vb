<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmartUPS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmartUPS))
        Me.PortBox = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Rescan_Btn = New System.Windows.Forms.Button()
        Me.Con_Lable = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BTN_MINIMIZE = New System.Windows.Forms.Button()
        Me.PortGrp = New System.Windows.Forms.GroupBox()
        Me.ActTime = New System.Windows.Forms.NumericUpDown()
        Me.hyber_chck = New System.Windows.Forms.CheckBox()
        Me.PortGrp.SuspendLayout()
        CType(Me.ActTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PortBox
        '
        Me.PortBox.FormattingEnabled = True
        Me.PortBox.Location = New System.Drawing.Point(52, 24)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(121, 21)
        Me.PortBox.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(210, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Open"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(210, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 37)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Port:"
        '
        'Rescan_Btn
        '
        Me.Rescan_Btn.Location = New System.Drawing.Point(20, 86)
        Me.Rescan_Btn.Name = "Rescan_Btn"
        Me.Rescan_Btn.Size = New System.Drawing.Size(75, 36)
        Me.Rescan_Btn.TabIndex = 7
        Me.Rescan_Btn.Text = "Rescan"
        Me.Rescan_Btn.UseVisualStyleBackColor = True
        '
        'Con_Lable
        '
        Me.Con_Lable.AutoSize = True
        Me.Con_Lable.BackColor = System.Drawing.SystemColors.Control
        Me.Con_Lable.Location = New System.Drawing.Point(12, 165)
        Me.Con_Lable.Name = "Con_Lable"
        Me.Con_Lable.Size = New System.Drawing.Size(59, 13)
        Me.Con_Lable.TabIndex = 8
        Me.Con_Lable.Text = "Connected"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'BTN_MINIMIZE
        '
        Me.BTN_MINIMIZE.Location = New System.Drawing.Point(200, 160)
        Me.BTN_MINIMIZE.Name = "BTN_MINIMIZE"
        Me.BTN_MINIMIZE.Size = New System.Drawing.Size(121, 23)
        Me.BTN_MINIMIZE.TabIndex = 9
        Me.BTN_MINIMIZE.Text = "Minimize To Tray"
        Me.BTN_MINIMIZE.UseVisualStyleBackColor = True
        '
        'PortGrp
        '
        Me.PortGrp.Controls.Add(Me.ActTime)
        Me.PortGrp.Controls.Add(Me.PortBox)
        Me.PortGrp.Controls.Add(Me.Label1)
        Me.PortGrp.Controls.Add(Me.Rescan_Btn)
        Me.PortGrp.Controls.Add(Me.Button1)
        Me.PortGrp.Controls.Add(Me.Button2)
        Me.PortGrp.Location = New System.Drawing.Point(12, 12)
        Me.PortGrp.Name = "PortGrp"
        Me.PortGrp.Size = New System.Drawing.Size(330, 128)
        Me.PortGrp.TabIndex = 10
        Me.PortGrp.TabStop = False
        Me.PortGrp.Text = "Port"
        '
        'ActTime
        '
        Me.ActTime.Location = New System.Drawing.Point(52, 51)
        Me.ActTime.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.ActTime.Name = "ActTime"
        Me.ActTime.Size = New System.Drawing.Size(120, 20)
        Me.ActTime.TabIndex = 11
        '
        'hyber_chck
        '
        Me.hyber_chck.AutoSize = True
        Me.hyber_chck.Location = New System.Drawing.Point(94, 164)
        Me.hyber_chck.Name = "hyber_chck"
        Me.hyber_chck.Size = New System.Drawing.Size(75, 17)
        Me.hyber_chck.TabIndex = 11
        Me.hyber_chck.Text = "Hibernate "
        Me.hyber_chck.UseVisualStyleBackColor = True
        '
        'SmartUPS
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 201)
        Me.Controls.Add(Me.hyber_chck)
        Me.Controls.Add(Me.BTN_MINIMIZE)
        Me.Controls.Add(Me.Con_Lable)
        Me.Controls.Add(Me.PortGrp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SmartUPS"
        Me.Text = "Smart UPS"
        Me.PortGrp.ResumeLayout(False)
        Me.PortGrp.PerformLayout()
        CType(Me.ActTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PortBox As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Rescan_Btn As Button
    Friend WithEvents Con_Lable As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents BTN_MINIMIZE As Button
    Friend WithEvents PortGrp As GroupBox
    Friend WithEvents ActTime As NumericUpDown
    Friend WithEvents hyber_chck As CheckBox
End Class
