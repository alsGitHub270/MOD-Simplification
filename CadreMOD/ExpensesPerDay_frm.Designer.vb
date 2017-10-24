<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpensesPerDay_frm
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        isInitializingComponent = True
        InitializeComponent()
        isInitializingComponent = False
        ReLoadForm(False)
    End Sub
    Private visualControls() As String = New String() {"components", "ToolTipMain", "Total_txt", "_Action_btn_1", "_Action_btn_0", "Cost_lbl", "Description_lbl", "Total_lbl", "Action_btn", "ExpensesPerDayTravelTime_txt", "ExpensesPerDayOutOfTownExpenses_txt", "ExpensesPerDayParking_txt", "ExpensesPerDayZone_txt", "ExpensesPerDayMiscellaneous_txt"}
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Private WithEvents ExpensesPerDayTravelTime_txt As System.Windows.Forms.TextBox
    Private WithEvents ExpensesPerDayOutOfTownExpenses_txt As System.Windows.Forms.TextBox
    Private WithEvents ExpensesPerDayParking_txt As System.Windows.Forms.TextBox
    Private WithEvents ExpensesPerDayZone_txt As System.Windows.Forms.TextBox
    Private WithEvents ExpensesPerDayMiscellaneous_txt As System.Windows.Forms.TextBox
    Public WithEvents ExpensesPerDayTotal_txt As System.Windows.Forms.TextBox
    Private WithEvents _Action_btn_1 As System.Windows.Forms.Button
    Private WithEvents _Action_btn_0 As System.Windows.Forms.Button
    Public WithEvents Cost_lbl As System.Windows.Forms.Label
    Public WithEvents Total_lbl As System.Windows.Forms.Label
    Public Action_btn(1) As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.ExpensesPerDayTravelTime_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDayOutOfTownExpenses_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDayParking_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDayZone_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDayMiscellaneous_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDayTotal_txt = New System.Windows.Forms.TextBox()
        Me._Action_btn_1 = New System.Windows.Forms.Button()
        Me._Action_btn_0 = New System.Windows.Forms.Button()
        Me.Cost_lbl = New System.Windows.Forms.Label()
        Me.Total_lbl = New System.Windows.Forms.Label()
        Me.Zone_lbl = New System.Windows.Forms.Label()
        Me.Parking_lbl = New System.Windows.Forms.Label()
        Me.OutOfTownExpenses_lbl = New System.Windows.Forms.Label()
        Me.TravelTime_lbl = New System.Windows.Forms.Label()
        Me.Miscellaneous_lbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ExpensesPerDayTravelTime_txt
        '
        Me.ExpensesPerDayTravelTime_txt.AcceptsReturn = True
        Me.ExpensesPerDayTravelTime_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayTravelTime_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayTravelTime_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayTravelTime_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayTravelTime_txt.Location = New System.Drawing.Point(157, 105)
        Me.ExpensesPerDayTravelTime_txt.MaxLength = 10
        Me.ExpensesPerDayTravelTime_txt.Name = "ExpensesPerDayTravelTime_txt"
        Me.ExpensesPerDayTravelTime_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayTravelTime_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayTravelTime_txt.TabIndex = 3
        Me.ExpensesPerDayTravelTime_txt.Tag = ""
        Me.ExpensesPerDayTravelTime_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDayOutOfTownExpenses_txt
        '
        Me.ExpensesPerDayOutOfTownExpenses_txt.AcceptsReturn = True
        Me.ExpensesPerDayOutOfTownExpenses_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayOutOfTownExpenses_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayOutOfTownExpenses_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayOutOfTownExpenses_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayOutOfTownExpenses_txt.Location = New System.Drawing.Point(157, 81)
        Me.ExpensesPerDayOutOfTownExpenses_txt.MaxLength = 10
        Me.ExpensesPerDayOutOfTownExpenses_txt.Name = "ExpensesPerDayOutOfTownExpenses_txt"
        Me.ExpensesPerDayOutOfTownExpenses_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayOutOfTownExpenses_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayOutOfTownExpenses_txt.TabIndex = 2
        Me.ExpensesPerDayOutOfTownExpenses_txt.Tag = ""
        Me.ExpensesPerDayOutOfTownExpenses_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDayParking_txt
        '
        Me.ExpensesPerDayParking_txt.AcceptsReturn = True
        Me.ExpensesPerDayParking_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayParking_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayParking_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayParking_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayParking_txt.Location = New System.Drawing.Point(157, 57)
        Me.ExpensesPerDayParking_txt.MaxLength = 10
        Me.ExpensesPerDayParking_txt.Name = "ExpensesPerDayParking_txt"
        Me.ExpensesPerDayParking_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayParking_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayParking_txt.TabIndex = 1
        Me.ExpensesPerDayParking_txt.Tag = ""
        Me.ExpensesPerDayParking_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDayZone_txt
        '
        Me.ExpensesPerDayZone_txt.AcceptsReturn = True
        Me.ExpensesPerDayZone_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayZone_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayZone_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayZone_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayZone_txt.Location = New System.Drawing.Point(157, 33)
        Me.ExpensesPerDayZone_txt.MaxLength = 10
        Me.ExpensesPerDayZone_txt.Name = "ExpensesPerDayZone_txt"
        Me.ExpensesPerDayZone_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayZone_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayZone_txt.TabIndex = 0
        Me.ExpensesPerDayZone_txt.Tag = ""
        Me.ExpensesPerDayZone_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDayMiscellaneous_txt
        '
        Me.ExpensesPerDayMiscellaneous_txt.AcceptsReturn = True
        Me.ExpensesPerDayMiscellaneous_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayMiscellaneous_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayMiscellaneous_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayMiscellaneous_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayMiscellaneous_txt.Location = New System.Drawing.Point(157, 129)
        Me.ExpensesPerDayMiscellaneous_txt.MaxLength = 10
        Me.ExpensesPerDayMiscellaneous_txt.Name = "ExpensesPerDayMiscellaneous_txt"
        Me.ExpensesPerDayMiscellaneous_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayMiscellaneous_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayMiscellaneous_txt.TabIndex = 4
        Me.ExpensesPerDayMiscellaneous_txt.Tag = ""
        Me.ExpensesPerDayMiscellaneous_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDayTotal_txt
        '
        Me.ExpensesPerDayTotal_txt.AcceptsReturn = True
        Me.ExpensesPerDayTotal_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDayTotal_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDayTotal_txt.Enabled = False
        Me.ExpensesPerDayTotal_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayTotal_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDayTotal_txt.Location = New System.Drawing.Point(157, 153)
        Me.ExpensesPerDayTotal_txt.MaxLength = 10
        Me.ExpensesPerDayTotal_txt.Name = "ExpensesPerDayTotal_txt"
        Me.ExpensesPerDayTotal_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDayTotal_txt.Size = New System.Drawing.Size(97, 20)
        Me.ExpensesPerDayTotal_txt.TabIndex = 5
        Me.ExpensesPerDayTotal_txt.Tag = ""
        Me.ExpensesPerDayTotal_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Action_btn_1
        '
        Me._Action_btn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Action_btn_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Action_btn_1.Location = New System.Drawing.Point(260, 148)
        Me._Action_btn_1.Name = "_Action_btn_1"
        Me._Action_btn_1.Size = New System.Drawing.Size(80, 25)
        Me._Action_btn_1.TabIndex = 7
        Me._Action_btn_1.TabStop = False
        Me._Action_btn_1.Text = "&Close"
        '
        '_Action_btn_0
        '
        Me._Action_btn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Action_btn_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Action_btn_0.Location = New System.Drawing.Point(260, 112)
        Me._Action_btn_0.Name = "_Action_btn_0"
        Me._Action_btn_0.Size = New System.Drawing.Size(80, 25)
        Me._Action_btn_0.TabIndex = 6
        Me._Action_btn_0.TabStop = False
        Me._Action_btn_0.Text = "C&lear Form"
        '
        'Cost_lbl
        '
        Me.Cost_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Cost_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cost_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cost_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cost_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cost_lbl.Location = New System.Drawing.Point(157, 9)
        Me.Cost_lbl.Name = "Cost_lbl"
        Me.Cost_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cost_lbl.Size = New System.Drawing.Size(97, 17)
        Me.Cost_lbl.TabIndex = 15
        Me.Cost_lbl.Text = "Cost"
        Me.Cost_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Total_lbl
        '
        Me.Total_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Total_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Total_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Total_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Total_lbl.Location = New System.Drawing.Point(8, 157)
        Me.Total_lbl.Name = "Total_lbl"
        Me.Total_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Total_lbl.Size = New System.Drawing.Size(143, 17)
        Me.Total_lbl.TabIndex = 13
        Me.Total_lbl.Text = "Total  "
        Me.Total_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Zone_lbl
        '
        Me.Zone_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Zone_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zone_lbl.Location = New System.Drawing.Point(8, 33)
        Me.Zone_lbl.Name = "Zone_lbl"
        Me.Zone_lbl.Size = New System.Drawing.Size(143, 17)
        Me.Zone_lbl.TabIndex = 16
        Me.Zone_lbl.Text = "Zone"
        Me.Zone_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Parking_lbl
        '
        Me.Parking_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Parking_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Parking_lbl.Location = New System.Drawing.Point(8, 57)
        Me.Parking_lbl.Name = "Parking_lbl"
        Me.Parking_lbl.Size = New System.Drawing.Size(143, 17)
        Me.Parking_lbl.TabIndex = 17
        Me.Parking_lbl.Text = "Parking"
        Me.Parking_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OutOfTownExpenses_lbl
        '
        Me.OutOfTownExpenses_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.OutOfTownExpenses_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutOfTownExpenses_lbl.Location = New System.Drawing.Point(8, 81)
        Me.OutOfTownExpenses_lbl.Name = "OutOfTownExpenses_lbl"
        Me.OutOfTownExpenses_lbl.Size = New System.Drawing.Size(143, 17)
        Me.OutOfTownExpenses_lbl.TabIndex = 18
        Me.OutOfTownExpenses_lbl.Text = "Out Of Town Expenses"
        Me.OutOfTownExpenses_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TravelTime_lbl
        '
        Me.TravelTime_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.TravelTime_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelTime_lbl.Location = New System.Drawing.Point(8, 105)
        Me.TravelTime_lbl.Name = "TravelTime_lbl"
        Me.TravelTime_lbl.Size = New System.Drawing.Size(143, 17)
        Me.TravelTime_lbl.TabIndex = 19
        Me.TravelTime_lbl.Text = "Travel Time"
        Me.TravelTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Miscellaneous_lbl
        '
        Me.Miscellaneous_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Miscellaneous_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Miscellaneous_lbl.Location = New System.Drawing.Point(8, 129)
        Me.Miscellaneous_lbl.Name = "Miscellaneous_lbl"
        Me.Miscellaneous_lbl.Size = New System.Drawing.Size(143, 17)
        Me.Miscellaneous_lbl.TabIndex = 20
        Me.Miscellaneous_lbl.Text = "Miscellaneous"
        Me.Miscellaneous_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExpensesPerDay_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(349, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.Miscellaneous_lbl)
        Me.Controls.Add(Me.TravelTime_lbl)
        Me.Controls.Add(Me.OutOfTownExpenses_lbl)
        Me.Controls.Add(Me.Parking_lbl)
        Me.Controls.Add(Me.Zone_lbl)
        Me.Controls.Add(Me.ExpensesPerDayTravelTime_txt)
        Me.Controls.Add(Me.ExpensesPerDayOutOfTownExpenses_txt)
        Me.Controls.Add(Me.ExpensesPerDayParking_txt)
        Me.Controls.Add(Me.ExpensesPerDayZone_txt)
        Me.Controls.Add(Me.ExpensesPerDayMiscellaneous_txt)
        Me.Controls.Add(Me.ExpensesPerDayTotal_txt)
        Me.Controls.Add(Me._Action_btn_1)
        Me.Controls.Add(Me._Action_btn_0)
        Me.Controls.Add(Me.Cost_lbl)
        Me.Controls.Add(Me.Total_lbl)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(355, 211)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(355, 211)
        Me.Name = "ExpensesPerDay_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expenses per Day Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Sub ReLoadForm(ByVal addEvents As Boolean)
        InitializeAction_btn()
        If addEvents Then
            AddHandler MyBase.Load, AddressOf Me.ExpensesPerDay_frm_Load
            AddHandler MyBase.Closed, AddressOf Me.ExpensesPerDay_frm_Closed
        End If
    End Sub
    Sub InitializeAction_btn()
        ReDim Action_btn(1)
        Me.Action_btn(1) = _Action_btn_1
        Me.Action_btn(0) = _Action_btn_0
    End Sub
    Friend WithEvents Zone_lbl As System.Windows.Forms.Label
    Friend WithEvents Parking_lbl As System.Windows.Forms.Label
    Friend WithEvents OutOfTownExpenses_lbl As System.Windows.Forms.Label
    Friend WithEvents TravelTime_lbl As System.Windows.Forms.Label
    Friend WithEvents Miscellaneous_lbl As System.Windows.Forms.Label
#End Region
End Class