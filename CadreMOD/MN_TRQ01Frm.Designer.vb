<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MN_TRQ01_frm
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        isInitializingComponent = True
        InitializeComponent()
        isInitializingComponent = False
        ReLoadForm(False)
    End Sub
    Private visualControls() As String = New String() {"components", "ToolTipMain", "MainTravelingCable_cmb", "Qty1_cmb", "MainTravelingCable_lbl", "Qty1_lbl", "AdditionalTravelingCableWeight_lbl", "Frame2", "HWCwtSheaveDia_Cmb", "CarSheaveDiameter_cmb", "CarSheaveQty_Cmb", "CarSheaveDiameter_lbl", "HWCwtSheaveDia_lbl", "CarSheaveQty_lbl", "Only2To1Roping_fra", "CompensationSize_cmb", "CompensationType_cmb", "CompensationQty_cmb", "CompSheaveDiameter_txt", "CompensationQty_lbl", "CompensationSize_lbl", "CompensationType_lbl", "CompSheaveDiameter_lbl", "Compensation_fra", "IDC1_txt", "Iff_txt", "Ifan_txt", "Vfan_txt", "VFLU_txt", "VFF_txt", "BuildingVoltage_cmb", "IDC1_lbl", "Iff_lbl", "Ifan_lbl", "Vfan_lbl", "VFLU_lbl", "VFF_lbl", "BuildingVoltage_lbl", "ElectricalData_fra", "MeasuredCarSpeed_txt", "GLSurveyData_cmb", "GLSurveyData_lbl", "MeasuredCarSpeed_lbl", "GLSurveyData_fra", "NumberOfRopes_cmb", "RopeSize_cmb", "Wrap_cmb", "Roping_cmb", "ExistingRopes_lbl", "NumberOfRopes_lbl", "RopeSize_lbl", "Wrap_lbl", "Roping_lbl", "Frame7", "CarWeight_txt", "TravelIn_txt", "Performance_cmb", "Capacity_cmb", "HoistwaySheave_cmb", "TravelFt_txt", "BrakeType_cmb", "CarWeight_lbl", "TravelIn_lbl", "Performance_lbl", "HoistwaySheave_lbl", "Capacity_lbl", "TravelFt_lbl", "BrakeType_lbl", "SystemData_fra", "MachineSheaveDia_cmb", "DriveType_cmb", "Manufacturer_cmb", "ShoeType_cmb", "MachineRoomLocation_cmb", "MotorRPM_cmb", "MachineType_cmb", "Speed_cmb", "MachineSheaveDia_lbl", "DriveType_lbl", "Manufacturer_lbl", "ShoeType_lbl", "MachineRoomLocation_lbl", "MotorRPM_lbl", "MachineType_lbl", "Speed_lbl", "GeneralData_fra"}
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Public WithEvents MainTravelingCable_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Qty1_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MainTravelingCable_lbl As System.Windows.Forms.Label
    Public WithEvents Qty1_lbl As System.Windows.Forms.Label
    Public WithEvents AdditionalTravelingCableWeight_lbl As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents HWCwtSheaveDia_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarSheaveDiameter_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarSheaveQty_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarSheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents HWCwtSheaveDia_lbl As System.Windows.Forms.Label
    Public WithEvents CarSheaveQty_lbl As System.Windows.Forms.Label
    Public WithEvents Only2To1Roping_fra As System.Windows.Forms.GroupBox
    Public WithEvents CompensationSize_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CompensationType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CompensationQty_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CompSheaveDiameter_txt As System.Windows.Forms.TextBox
    Public WithEvents CompensationQty_lbl As System.Windows.Forms.Label
    Public WithEvents CompensationSize_lbl As System.Windows.Forms.Label
    Public WithEvents CompensationType_lbl As System.Windows.Forms.Label
    Public WithEvents CompSheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents Compensation_fra As System.Windows.Forms.GroupBox
    Public WithEvents NamePlateArmatureFullLoadCurrent_txt As System.Windows.Forms.TextBox
    Public WithEvents Iff_txt As System.Windows.Forms.TextBox
    Public WithEvents Ifan_txt As System.Windows.Forms.TextBox
    Public WithEvents Vfan_txt As System.Windows.Forms.TextBox
    Public WithEvents NamePlateArmatureFullLoadVoltage_txt As System.Windows.Forms.TextBox
    Public WithEvents VFF_txt As System.Windows.Forms.TextBox
    Public WithEvents BuildingVoltage_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NamePlateArmatureFullLoadCurrent_lbl As System.Windows.Forms.Label
    Public WithEvents Iff_lbl As System.Windows.Forms.Label
    Public WithEvents Ifan_lbl As System.Windows.Forms.Label
    Public WithEvents Vfan_lbl As System.Windows.Forms.Label
    Public WithEvents NamePlateArmatureFullLoadVoltage_lbl As System.Windows.Forms.Label
    Public WithEvents VFF_lbl As System.Windows.Forms.Label
    Public WithEvents BuildingVoltage_lbl As System.Windows.Forms.Label
    Public WithEvents ElectricalData_fra As System.Windows.Forms.GroupBox
    Public WithEvents NumberOfRopes_cmb As System.Windows.Forms.ComboBox
    Public WithEvents RopeSize_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Wrap_cmb As System.Windows.Forms.ComboBox
    Public WithEvents RopingNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents ExistingRopes_lbl As System.Windows.Forms.Label
    Public WithEvents NumberOfRopes_lbl As System.Windows.Forms.Label
    Public WithEvents RopeSize_lbl As System.Windows.Forms.Label
    Public WithEvents Wrap_lbl As System.Windows.Forms.Label
    Public WithEvents RopingNew_lbl As System.Windows.Forms.Label
    Public WithEvents Frame7 As System.Windows.Forms.GroupBox
    Public WithEvents CarWeight_txt As System.Windows.Forms.TextBox
    Public WithEvents TravelIn_txt As System.Windows.Forms.TextBox
    Public WithEvents Performance_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Capacity_cmb As System.Windows.Forms.ComboBox
    Public WithEvents HoistwaySheave_cmb As System.Windows.Forms.ComboBox
    Public WithEvents TravelFt_txt As System.Windows.Forms.TextBox
    Public WithEvents BrakeType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarWeight_lbl As System.Windows.Forms.Label
    Public WithEvents TravelIn_lbl As System.Windows.Forms.Label
    Public WithEvents Performance_lbl As System.Windows.Forms.Label
    Public WithEvents HoistwaySheave_lbl As System.Windows.Forms.Label
    Public WithEvents Capacity_lbl As System.Windows.Forms.Label
    Public WithEvents TravelFt_lbl As System.Windows.Forms.Label
    Public WithEvents BrakeType_lbl As System.Windows.Forms.Label
    Public WithEvents SystemData_fra As System.Windows.Forms.GroupBox
    Public WithEvents MachineSheaveDia_cmb As System.Windows.Forms.ComboBox
    Public WithEvents DriveType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents ManufacturerNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents ShoeType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineRoomLocation_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MotorRPM_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineTypeNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Speed_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineSheaveDia_lbl As System.Windows.Forms.Label
    Public WithEvents DriveType_lbl As System.Windows.Forms.Label
    Public WithEvents ManufacturerNew_lbl As System.Windows.Forms.Label
    Public WithEvents ShoeType_lbl As System.Windows.Forms.Label
    Public WithEvents MachineRoomLocation_lbl As System.Windows.Forms.Label
    Public WithEvents MotorRPM_lbl As System.Windows.Forms.Label
    Public WithEvents MachineTypeNew_lbl As System.Windows.Forms.Label
    Public WithEvents Speed_lbl As System.Windows.Forms.Label
    Public WithEvents GeneralData_fra As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.AdditionalShieldPairsQty_cmb = New System.Windows.Forms.ComboBox()
        Me.AdditionalShieldPairsQty_lbl = New System.Windows.Forms.Label()
        Me.AdditionalCoaxCableQty_cmb = New System.Windows.Forms.ComboBox()
        Me.AdditionalCoaxCableQty_lbl = New System.Windows.Forms.Label()
        Me.MainTravelingCable_cmb = New System.Windows.Forms.ComboBox()
        Me.Qty1_cmb = New System.Windows.Forms.ComboBox()
        Me.MainTravelingCable_lbl = New System.Windows.Forms.Label()
        Me.Qty1_lbl = New System.Windows.Forms.Label()
        Me.AdditionalTravelingCableWeight_lbl = New System.Windows.Forms.Label()
        Me.Only2To1Roping_fra = New System.Windows.Forms.GroupBox()
        Me.HWCwtSheaveDia_Cmb = New System.Windows.Forms.ComboBox()
        Me.CarSheaveDiameter_cmb = New System.Windows.Forms.ComboBox()
        Me.CarSheaveQty_Cmb = New System.Windows.Forms.ComboBox()
        Me.CarSheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.HWCwtSheaveDia_lbl = New System.Windows.Forms.Label()
        Me.CarSheaveQty_lbl = New System.Windows.Forms.Label()
        Me.Compensation_fra = New System.Windows.Forms.GroupBox()
        Me.CompensationSize_cmb = New System.Windows.Forms.ComboBox()
        Me.CompensationType_cmb = New System.Windows.Forms.ComboBox()
        Me.CompensationQty_cmb = New System.Windows.Forms.ComboBox()
        Me.CompSheaveDiameter_txt = New System.Windows.Forms.TextBox()
        Me.CompensationQty_lbl = New System.Windows.Forms.Label()
        Me.CompensationSize_lbl = New System.Windows.Forms.Label()
        Me.CompensationType_lbl = New System.Windows.Forms.Label()
        Me.CompSheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.ElectricalData_fra = New System.Windows.Forms.GroupBox()
        Me.ResetElectricalDataToDefault_cmd = New System.Windows.Forms.Button()
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl = New System.Windows.Forms.Label()
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl = New System.Windows.Forms.Label()
        Me.NamePlateArmatureFullLoadCurrent_txt = New System.Windows.Forms.TextBox()
        Me.Iff_txt = New System.Windows.Forms.TextBox()
        Me.Ifan_txt = New System.Windows.Forms.TextBox()
        Me.Vfan_txt = New System.Windows.Forms.TextBox()
        Me.NamePlateArmatureFullLoadVoltage_txt = New System.Windows.Forms.TextBox()
        Me.VFF_txt = New System.Windows.Forms.TextBox()
        Me.BuildingVoltage_cmb = New System.Windows.Forms.ComboBox()
        Me.NamePlateArmatureFullLoadCurrent_lbl = New System.Windows.Forms.Label()
        Me.Iff_lbl = New System.Windows.Forms.Label()
        Me.Ifan_lbl = New System.Windows.Forms.Label()
        Me.Vfan_lbl = New System.Windows.Forms.Label()
        Me.NamePlateArmatureFullLoadVoltage_lbl = New System.Windows.Forms.Label()
        Me.VFF_lbl = New System.Windows.Forms.Label()
        Me.BuildingVoltage_lbl = New System.Windows.Forms.Label()
        Me.Frame7 = New System.Windows.Forms.GroupBox()
        Me.NumberOfRopes_cmb = New System.Windows.Forms.ComboBox()
        Me.RopeSize_cmb = New System.Windows.Forms.ComboBox()
        Me.Wrap_cmb = New System.Windows.Forms.ComboBox()
        Me.RopingNew_cmb = New System.Windows.Forms.ComboBox()
        Me.ExistingRopes_lbl = New System.Windows.Forms.Label()
        Me.NumberOfRopes_lbl = New System.Windows.Forms.Label()
        Me.RopeSize_lbl = New System.Windows.Forms.Label()
        Me.Wrap_lbl = New System.Windows.Forms.Label()
        Me.RopingNew_lbl = New System.Windows.Forms.Label()
        Me.SystemData_fra = New System.Windows.Forms.GroupBox()
        Me.CarWeight_txt = New System.Windows.Forms.TextBox()
        Me.TravelIn_txt = New System.Windows.Forms.TextBox()
        Me.Performance_cmb = New System.Windows.Forms.ComboBox()
        Me.Capacity_cmb = New System.Windows.Forms.ComboBox()
        Me.HoistwaySheave_cmb = New System.Windows.Forms.ComboBox()
        Me.TravelFt_txt = New System.Windows.Forms.TextBox()
        Me.BrakeType_cmb = New System.Windows.Forms.ComboBox()
        Me.CarWeight_lbl = New System.Windows.Forms.Label()
        Me.TravelIn_lbl = New System.Windows.Forms.Label()
        Me.Performance_lbl = New System.Windows.Forms.Label()
        Me.HoistwaySheave_lbl = New System.Windows.Forms.Label()
        Me.Capacity_lbl = New System.Windows.Forms.Label()
        Me.TravelFt_lbl = New System.Windows.Forms.Label()
        Me.BrakeType_lbl = New System.Windows.Forms.Label()
        Me.GeneralData_fra = New System.Windows.Forms.GroupBox()
        Me.MachineModelExisting_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineVendorExisting_Cmb = New System.Windows.Forms.ComboBox()
        Me.MachineModelExisting_lbl = New System.Windows.Forms.Label()
        Me.MachineVendorExisting_lbl = New System.Windows.Forms.Label()
        Me.MachineSheaveDia_cmb = New System.Windows.Forms.ComboBox()
        Me.DriveType_cmb = New System.Windows.Forms.ComboBox()
        Me.ManufacturerNew_cmb = New System.Windows.Forms.ComboBox()
        Me.ShoeType_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineRoomLocation_cmb = New System.Windows.Forms.ComboBox()
        Me.MotorRPM_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineTypeNew_cmb = New System.Windows.Forms.ComboBox()
        Me.Speed_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineSheaveDia_lbl = New System.Windows.Forms.Label()
        Me.DriveType_lbl = New System.Windows.Forms.Label()
        Me.ManufacturerNew_lbl = New System.Windows.Forms.Label()
        Me.ShoeType_lbl = New System.Windows.Forms.Label()
        Me.MachineRoomLocation_lbl = New System.Windows.Forms.Label()
        Me.MotorRPM_lbl = New System.Windows.Forms.Label()
        Me.MachineTypeNew_lbl = New System.Windows.Forms.Label()
        Me.Speed_lbl = New System.Windows.Forms.Label()
        Me.TopOfCarDevices_fra = New System.Windows.Forms.GroupBox()
        Me.LoadWeighType_cmb = New System.Windows.Forms.ComboBox()
        Me.LoadWeighType_lbl = New System.Windows.Forms.Label()
        Me.RopeGripper_fra = New System.Windows.Forms.GroupBox()
        Me.RopeSplayKitMounting_cmb = New System.Windows.Forms.ComboBox()
        Me.RopeSplayKitMounting_lbl = New System.Windows.Forms.Label()
        Me.MountingToOuterMBflanges_chk = New System.Windows.Forms.CheckBox()
        Me.RopeGripperMount_cmb = New System.Windows.Forms.ComboBox()
        Me.RopeGripperMount_lbl = New System.Windows.Forms.Label()
        Me.RopeGripper_cmb = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RopeGripperModel_cmb = New System.Windows.Forms.ComboBox()
        Me.RopeGripperModelDetails_cmd = New System.Windows.Forms.Button()
        Me.RopeGripper_lbl = New System.Windows.Forms.Label()
        Me.RopeGripperModel_lbl = New System.Windows.Forms.Label()
        Me.Governor_fra = New System.Windows.Forms.GroupBox()
        Me.CwtGovernorFastening_cmb = New System.Windows.Forms.ComboBox()
        Me.CwtGovernorFastening_lbl = New System.Windows.Forms.Label()
        Me.CarGovernorFastening_cmb = New System.Windows.Forms.ComboBox()
        Me.CarGovernorFastening_lbl = New System.Windows.Forms.Label()
        Me.CwtGovernorNewModel_cmb = New System.Windows.Forms.ComboBox()
        Me.CwtGovernorNewModel_lbl = New System.Windows.Forms.Label()
        Me.CarGovernorNewModel_cmb = New System.Windows.Forms.ComboBox()
        Me.CarGovernorNewModel_lbl = New System.Windows.Forms.Label()
        Me.LobbyVision_fra = New System.Windows.Forms.GroupBox()
        Me.QtyStarRepeater_cmb = New System.Windows.Forms.ComboBox()
        Me.QtyStarRepeater_lbl = New System.Windows.Forms.Label()
        Me.Frame2.SuspendLayout()
        Me.Only2To1Roping_fra.SuspendLayout()
        Me.Compensation_fra.SuspendLayout()
        Me.ElectricalData_fra.SuspendLayout()
        Me.Frame7.SuspendLayout()
        Me.SystemData_fra.SuspendLayout()
        Me.GeneralData_fra.SuspendLayout()
        Me.TopOfCarDevices_fra.SuspendLayout()
        Me.RopeGripper_fra.SuspendLayout()
        Me.Governor_fra.SuspendLayout()
        Me.LobbyVision_fra.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Window
        Me.Frame2.Controls.Add(Me.AdditionalShieldPairsQty_cmb)
        Me.Frame2.Controls.Add(Me.AdditionalShieldPairsQty_lbl)
        Me.Frame2.Controls.Add(Me.AdditionalCoaxCableQty_cmb)
        Me.Frame2.Controls.Add(Me.AdditionalCoaxCableQty_lbl)
        Me.Frame2.Controls.Add(Me.MainTravelingCable_cmb)
        Me.Frame2.Controls.Add(Me.Qty1_cmb)
        Me.Frame2.Controls.Add(Me.MainTravelingCable_lbl)
        Me.Frame2.Controls.Add(Me.Qty1_lbl)
        Me.Frame2.Controls.Add(Me.AdditionalTravelingCableWeight_lbl)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(639, 0)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(308, 105)
        Me.Frame2.TabIndex = 80
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Travel Cable"
        '
        'AdditionalShieldPairsQty_cmb
        '
        Me.AdditionalShieldPairsQty_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.AdditionalShieldPairsQty_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.AdditionalShieldPairsQty_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdditionalShieldPairsQty_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdditionalShieldPairsQty_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AdditionalShieldPairsQty_cmb.Location = New System.Drawing.Point(256, 68)
        Me.AdditionalShieldPairsQty_cmb.Name = "AdditionalShieldPairsQty_cmb"
        Me.AdditionalShieldPairsQty_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AdditionalShieldPairsQty_cmb.Size = New System.Drawing.Size(40, 21)
        Me.AdditionalShieldPairsQty_cmb.TabIndex = 86
        Me.AdditionalShieldPairsQty_cmb.Tag = "Geared And Gearless"
        '
        'AdditionalShieldPairsQty_lbl
        '
        Me.AdditionalShieldPairsQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.AdditionalShieldPairsQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AdditionalShieldPairsQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdditionalShieldPairsQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdditionalShieldPairsQty_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AdditionalShieldPairsQty_lbl.Location = New System.Drawing.Point(99, 72)
        Me.AdditionalShieldPairsQty_lbl.Name = "AdditionalShieldPairsQty_lbl"
        Me.AdditionalShieldPairsQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AdditionalShieldPairsQty_lbl.Size = New System.Drawing.Size(151, 18)
        Me.AdditionalShieldPairsQty_lbl.TabIndex = 87
        Me.AdditionalShieldPairsQty_lbl.Text = "Additional Shield Pairs Qty"
        '
        'AdditionalCoaxCableQty_cmb
        '
        Me.AdditionalCoaxCableQty_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.AdditionalCoaxCableQty_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.AdditionalCoaxCableQty_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdditionalCoaxCableQty_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdditionalCoaxCableQty_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AdditionalCoaxCableQty_cmb.Location = New System.Drawing.Point(256, 44)
        Me.AdditionalCoaxCableQty_cmb.Name = "AdditionalCoaxCableQty_cmb"
        Me.AdditionalCoaxCableQty_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AdditionalCoaxCableQty_cmb.Size = New System.Drawing.Size(40, 21)
        Me.AdditionalCoaxCableQty_cmb.TabIndex = 84
        Me.AdditionalCoaxCableQty_cmb.Tag = "Geared And Gearless"
        '
        'AdditionalCoaxCableQty_lbl
        '
        Me.AdditionalCoaxCableQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.AdditionalCoaxCableQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AdditionalCoaxCableQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdditionalCoaxCableQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdditionalCoaxCableQty_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AdditionalCoaxCableQty_lbl.Location = New System.Drawing.Point(99, 48)
        Me.AdditionalCoaxCableQty_lbl.Name = "AdditionalCoaxCableQty_lbl"
        Me.AdditionalCoaxCableQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AdditionalCoaxCableQty_lbl.Size = New System.Drawing.Size(151, 18)
        Me.AdditionalCoaxCableQty_lbl.TabIndex = 85
        Me.AdditionalCoaxCableQty_lbl.Text = "Additional Coax Cable Qty"
        '
        'MainTravelingCable_cmb
        '
        Me.MainTravelingCable_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MainTravelingCable_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MainTravelingCable_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MainTravelingCable_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTravelingCable_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MainTravelingCable_cmb.Location = New System.Drawing.Point(68, 20)
        Me.MainTravelingCable_cmb.Name = "MainTravelingCable_cmb"
        Me.MainTravelingCable_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MainTravelingCable_cmb.Size = New System.Drawing.Size(148, 21)
        Me.MainTravelingCable_cmb.TabIndex = 33
        Me.MainTravelingCable_cmb.Tag = "Geared And Gearless"
        '
        'Qty1_cmb
        '
        Me.Qty1_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Qty1_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Qty1_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Qty1_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty1_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Qty1_cmb.Location = New System.Drawing.Point(256, 20)
        Me.Qty1_cmb.Name = "Qty1_cmb"
        Me.Qty1_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Qty1_cmb.Size = New System.Drawing.Size(40, 21)
        Me.Qty1_cmb.TabIndex = 34
        Me.Qty1_cmb.Tag = "Geared And Gearless"
        '
        'MainTravelingCable_lbl
        '
        Me.MainTravelingCable_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MainTravelingCable_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MainTravelingCable_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MainTravelingCable_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainTravelingCable_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MainTravelingCable_lbl.Location = New System.Drawing.Point(6, 22)
        Me.MainTravelingCable_lbl.Name = "MainTravelingCable_lbl"
        Me.MainTravelingCable_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MainTravelingCable_lbl.Size = New System.Drawing.Size(54, 18)
        Me.MainTravelingCable_lbl.TabIndex = 83
        Me.MainTravelingCable_lbl.Text = "Standard"
        '
        'Qty1_lbl
        '
        Me.Qty1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Qty1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Qty1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Qty1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Qty1_lbl.Location = New System.Drawing.Point(228, 22)
        Me.Qty1_lbl.Name = "Qty1_lbl"
        Me.Qty1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Qty1_lbl.Size = New System.Drawing.Size(20, 18)
        Me.Qty1_lbl.TabIndex = 82
        Me.Qty1_lbl.Text = "Qty"
        '
        'AdditionalTravelingCableWeight_lbl
        '
        Me.AdditionalTravelingCableWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.AdditionalTravelingCableWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AdditionalTravelingCableWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdditionalTravelingCableWeight_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AdditionalTravelingCableWeight_lbl.Location = New System.Drawing.Point(282, 93)
        Me.AdditionalTravelingCableWeight_lbl.Name = "AdditionalTravelingCableWeight_lbl"
        Me.AdditionalTravelingCableWeight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AdditionalTravelingCableWeight_lbl.Size = New System.Drawing.Size(42, 4)
        Me.AdditionalTravelingCableWeight_lbl.TabIndex = 81
        Me.AdditionalTravelingCableWeight_lbl.Text = "Weight"
        Me.AdditionalTravelingCableWeight_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.AdditionalTravelingCableWeight_lbl.Visible = False
        '
        'Only2To1Roping_fra
        '
        Me.Only2To1Roping_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Only2To1Roping_fra.Controls.Add(Me.HWCwtSheaveDia_Cmb)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveDiameter_cmb)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveQty_Cmb)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveDiameter_lbl)
        Me.Only2To1Roping_fra.Controls.Add(Me.HWCwtSheaveDia_lbl)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveQty_lbl)
        Me.Only2To1Roping_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Only2To1Roping_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Only2To1Roping_fra.Location = New System.Drawing.Point(320, 122)
        Me.Only2To1Roping_fra.Name = "Only2To1Roping_fra"
        Me.Only2To1Roping_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Only2To1Roping_fra.Size = New System.Drawing.Size(308, 94)
        Me.Only2To1Roping_fra.TabIndex = 76
        Me.Only2To1Roping_fra.TabStop = False
        Me.Only2To1Roping_fra.Text = "2 : 1 Roping"
        '
        'HWCwtSheaveDia_Cmb
        '
        Me.HWCwtSheaveDia_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.HWCwtSheaveDia_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.HWCwtSheaveDia_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HWCwtSheaveDia_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HWCwtSheaveDia_Cmb.Location = New System.Drawing.Point(180, 68)
        Me.HWCwtSheaveDia_Cmb.Name = "HWCwtSheaveDia_Cmb"
        Me.HWCwtSheaveDia_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HWCwtSheaveDia_Cmb.Size = New System.Drawing.Size(120, 21)
        Me.HWCwtSheaveDia_Cmb.TabIndex = 23
        '
        'CarSheaveDiameter_cmb
        '
        Me.CarSheaveDiameter_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveDiameter_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveDiameter_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveDiameter_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveDiameter_cmb.Location = New System.Drawing.Point(180, 20)
        Me.CarSheaveDiameter_cmb.Name = "CarSheaveDiameter_cmb"
        Me.CarSheaveDiameter_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveDiameter_cmb.Size = New System.Drawing.Size(120, 21)
        Me.CarSheaveDiameter_cmb.TabIndex = 21
        '
        'CarSheaveQty_Cmb
        '
        Me.CarSheaveQty_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveQty_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveQty_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CarSheaveQty_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveQty_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveQty_Cmb.Location = New System.Drawing.Point(180, 44)
        Me.CarSheaveQty_Cmb.Name = "CarSheaveQty_Cmb"
        Me.CarSheaveQty_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveQty_Cmb.Size = New System.Drawing.Size(120, 21)
        Me.CarSheaveQty_Cmb.TabIndex = 22
        Me.CarSheaveQty_Cmb.Tag = "Geared And Gearless"
        '
        'CarSheaveDiameter_lbl
        '
        Me.CarSheaveDiameter_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveDiameter_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveDiameter_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarSheaveDiameter_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveDiameter_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveDiameter_lbl.Location = New System.Drawing.Point(6, 22)
        Me.CarSheaveDiameter_lbl.Name = "CarSheaveDiameter_lbl"
        Me.CarSheaveDiameter_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveDiameter_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CarSheaveDiameter_lbl.TabIndex = 79
        Me.CarSheaveDiameter_lbl.Text = "Top of Car Sheave Dia. (in)"
        '
        'HWCwtSheaveDia_lbl
        '
        Me.HWCwtSheaveDia_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HWCwtSheaveDia_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HWCwtSheaveDia_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HWCwtSheaveDia_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HWCwtSheaveDia_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HWCwtSheaveDia_lbl.Location = New System.Drawing.Point(6, 70)
        Me.HWCwtSheaveDia_lbl.Name = "HWCwtSheaveDia_lbl"
        Me.HWCwtSheaveDia_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HWCwtSheaveDia_lbl.Size = New System.Drawing.Size(168, 18)
        Me.HWCwtSheaveDia_lbl.TabIndex = 78
        Me.HWCwtSheaveDia_lbl.Text = "Cwt Sheave Diameter (in)"
        '
        'CarSheaveQty_lbl
        '
        Me.CarSheaveQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarSheaveQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveQty_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveQty_lbl.Location = New System.Drawing.Point(6, 46)
        Me.CarSheaveQty_lbl.Name = "CarSheaveQty_lbl"
        Me.CarSheaveQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveQty_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CarSheaveQty_lbl.TabIndex = 77
        Me.CarSheaveQty_lbl.Text = "Top of Car Sheave Quantity"
        '
        'Compensation_fra
        '
        Me.Compensation_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Compensation_fra.Controls.Add(Me.CompensationSize_cmb)
        Me.Compensation_fra.Controls.Add(Me.CompensationType_cmb)
        Me.Compensation_fra.Controls.Add(Me.CompensationQty_cmb)
        Me.Compensation_fra.Controls.Add(Me.CompSheaveDiameter_txt)
        Me.Compensation_fra.Controls.Add(Me.CompensationQty_lbl)
        Me.Compensation_fra.Controls.Add(Me.CompensationSize_lbl)
        Me.Compensation_fra.Controls.Add(Me.CompensationType_lbl)
        Me.Compensation_fra.Controls.Add(Me.CompSheaveDiameter_lbl)
        Me.Compensation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Compensation_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Compensation_fra.Location = New System.Drawing.Point(639, 108)
        Me.Compensation_fra.Name = "Compensation_fra"
        Me.Compensation_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Compensation_fra.Size = New System.Drawing.Size(308, 120)
        Me.Compensation_fra.TabIndex = 39
        Me.Compensation_fra.TabStop = False
        Me.Compensation_fra.Text = "Compensation Data"
        '
        'CompensationSize_cmb
        '
        Me.CompensationSize_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationSize_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationSize_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CompensationSize_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationSize_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationSize_cmb.Location = New System.Drawing.Point(165, 44)
        Me.CompensationSize_cmb.Name = "CompensationSize_cmb"
        Me.CompensationSize_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationSize_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CompensationSize_cmb.TabIndex = 36
        Me.CompensationSize_cmb.Tag = "1"
        '
        'CompensationType_cmb
        '
        Me.CompensationType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CompensationType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationType_cmb.Location = New System.Drawing.Point(165, 20)
        Me.CompensationType_cmb.Name = "CompensationType_cmb"
        Me.CompensationType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationType_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CompensationType_cmb.TabIndex = 35
        Me.CompensationType_cmb.Tag = "1"
        '
        'CompensationQty_cmb
        '
        Me.CompensationQty_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationQty_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationQty_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CompensationQty_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationQty_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationQty_cmb.Location = New System.Drawing.Point(165, 68)
        Me.CompensationQty_cmb.Name = "CompensationQty_cmb"
        Me.CompensationQty_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationQty_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CompensationQty_cmb.TabIndex = 37
        Me.CompensationQty_cmb.Tag = "1"
        '
        'CompSheaveDiameter_txt
        '
        Me.CompSheaveDiameter_txt.AcceptsReturn = True
        Me.CompSheaveDiameter_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveDiameter_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CompSheaveDiameter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveDiameter_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveDiameter_txt.Location = New System.Drawing.Point(166, 92)
        Me.CompSheaveDiameter_txt.MaxLength = 0
        Me.CompSheaveDiameter_txt.Name = "CompSheaveDiameter_txt"
        Me.CompSheaveDiameter_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveDiameter_txt.Size = New System.Drawing.Size(134, 20)
        Me.CompSheaveDiameter_txt.TabIndex = 38
        Me.CompSheaveDiameter_txt.Tag = "1"
        '
        'CompensationQty_lbl
        '
        Me.CompensationQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompensationQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationQty_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationQty_lbl.Location = New System.Drawing.Point(6, 70)
        Me.CompensationQty_lbl.Name = "CompensationQty_lbl"
        Me.CompensationQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationQty_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompensationQty_lbl.TabIndex = 75
        Me.CompensationQty_lbl.Text = "Compensation Quantity"
        '
        'CompensationSize_lbl
        '
        Me.CompensationSize_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationSize_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationSize_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompensationSize_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationSize_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationSize_lbl.Location = New System.Drawing.Point(6, 46)
        Me.CompensationSize_lbl.Name = "CompensationSize_lbl"
        Me.CompensationSize_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationSize_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompensationSize_lbl.TabIndex = 74
        Me.CompensationSize_lbl.Text = "Compensation Size"
        '
        'CompensationType_lbl
        '
        Me.CompensationType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompensationType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationType_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationType_lbl.Location = New System.Drawing.Point(6, 22)
        Me.CompensationType_lbl.Name = "CompensationType_lbl"
        Me.CompensationType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationType_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompensationType_lbl.TabIndex = 73
        Me.CompensationType_lbl.Text = "Compensation Type"
        '
        'CompSheaveDiameter_lbl
        '
        Me.CompSheaveDiameter_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveDiameter_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompSheaveDiameter_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompSheaveDiameter_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveDiameter_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveDiameter_lbl.Location = New System.Drawing.Point(6, 94)
        Me.CompSheaveDiameter_lbl.Name = "CompSheaveDiameter_lbl"
        Me.CompSheaveDiameter_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveDiameter_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompSheaveDiameter_lbl.TabIndex = 72
        Me.CompSheaveDiameter_lbl.Text = "Comp Sheave Diameter (in)"
        '
        'ElectricalData_fra
        '
        Me.ElectricalData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.ElectricalData_fra.Controls.Add(Me.ResetElectricalDataToDefault_cmd)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadCurrentAmps_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadVoltageVolts_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadCurrent_txt)
        Me.ElectricalData_fra.Controls.Add(Me.Iff_txt)
        Me.ElectricalData_fra.Controls.Add(Me.Ifan_txt)
        Me.ElectricalData_fra.Controls.Add(Me.Vfan_txt)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadVoltage_txt)
        Me.ElectricalData_fra.Controls.Add(Me.VFF_txt)
        Me.ElectricalData_fra.Controls.Add(Me.BuildingVoltage_cmb)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadCurrent_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.Iff_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.Ifan_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.Vfan_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.NamePlateArmatureFullLoadVoltage_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.VFF_lbl)
        Me.ElectricalData_fra.Controls.Add(Me.BuildingVoltage_lbl)
        Me.ElectricalData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElectricalData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ElectricalData_fra.Location = New System.Drawing.Point(321, 218)
        Me.ElectricalData_fra.Name = "ElectricalData_fra"
        Me.ElectricalData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ElectricalData_fra.Size = New System.Drawing.Size(308, 220)
        Me.ElectricalData_fra.TabIndex = 42
        Me.ElectricalData_fra.TabStop = False
        Me.ElectricalData_fra.Text = "Electrical Data"
        '
        'ResetElectricalDataToDefault_cmd
        '
        Me.ResetElectricalDataToDefault_cmd.BackColor = System.Drawing.SystemColors.Control
        Me.ResetElectricalDataToDefault_cmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.ResetElectricalDataToDefault_cmd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ResetElectricalDataToDefault_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetElectricalDataToDefault_cmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ResetElectricalDataToDefault_cmd.Location = New System.Drawing.Point(94, 192)
        Me.ResetElectricalDataToDefault_cmd.Name = "ResetElectricalDataToDefault_cmd"
        Me.ResetElectricalDataToDefault_cmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ResetElectricalDataToDefault_cmd.Size = New System.Drawing.Size(120, 21)
        Me.ResetElectricalDataToDefault_cmd.TabIndex = 31
        Me.ResetElectricalDataToDefault_cmd.Text = "Reset to Default"
        Me.ResetElectricalDataToDefault_cmd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ResetElectricalDataToDefault_cmd.UseVisualStyleBackColor = False
        '
        'NamePlateArmatureFullLoadCurrentAmps_lbl
        '
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Location = New System.Drawing.Point(260, 168)
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Name = "NamePlateArmatureFullLoadCurrentAmps_lbl"
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Size = New System.Drawing.Size(36, 19)
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.TabIndex = 84
        Me.NamePlateArmatureFullLoadCurrentAmps_lbl.Text = "AMPS"
        '
        'NamePlateArmatureFullLoadVoltageVolts_lbl
        '
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Location = New System.Drawing.Point(260, 144)
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Name = "NamePlateArmatureFullLoadVoltageVolts_lbl"
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Size = New System.Drawing.Size(42, 19)
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.TabIndex = 85
        Me.NamePlateArmatureFullLoadVoltageVolts_lbl.Text = "VOLTS"
        '
        'NamePlateArmatureFullLoadCurrent_txt
        '
        Me.NamePlateArmatureFullLoadCurrent_txt.AcceptsReturn = True
        Me.NamePlateArmatureFullLoadCurrent_txt.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadCurrent_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NamePlateArmatureFullLoadCurrent_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadCurrent_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadCurrent_txt.Location = New System.Drawing.Point(180, 166)
        Me.NamePlateArmatureFullLoadCurrent_txt.MaxLength = 0
        Me.NamePlateArmatureFullLoadCurrent_txt.Name = "NamePlateArmatureFullLoadCurrent_txt"
        Me.NamePlateArmatureFullLoadCurrent_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadCurrent_txt.Size = New System.Drawing.Size(73, 20)
        Me.NamePlateArmatureFullLoadCurrent_txt.TabIndex = 30
        Me.NamePlateArmatureFullLoadCurrent_txt.Tag = "1 Geared"
        '
        'Iff_txt
        '
        Me.Iff_txt.AcceptsReturn = True
        Me.Iff_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Iff_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Iff_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Iff_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Iff_txt.Location = New System.Drawing.Point(180, 70)
        Me.Iff_txt.MaxLength = 0
        Me.Iff_txt.Name = "Iff_txt"
        Me.Iff_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Iff_txt.Size = New System.Drawing.Size(120, 20)
        Me.Iff_txt.TabIndex = 26
        Me.Iff_txt.Tag = "1 Geared"
        '
        'Ifan_txt
        '
        Me.Ifan_txt.AcceptsReturn = True
        Me.Ifan_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Ifan_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ifan_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ifan_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ifan_txt.Location = New System.Drawing.Point(180, 118)
        Me.Ifan_txt.MaxLength = 0
        Me.Ifan_txt.Name = "Ifan_txt"
        Me.Ifan_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ifan_txt.Size = New System.Drawing.Size(120, 20)
        Me.Ifan_txt.TabIndex = 28
        Me.Ifan_txt.Tag = "1 Geared"
        '
        'Vfan_txt
        '
        Me.Vfan_txt.AcceptsReturn = True
        Me.Vfan_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Vfan_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Vfan_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vfan_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Vfan_txt.Location = New System.Drawing.Point(180, 94)
        Me.Vfan_txt.MaxLength = 0
        Me.Vfan_txt.Name = "Vfan_txt"
        Me.Vfan_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Vfan_txt.Size = New System.Drawing.Size(120, 20)
        Me.Vfan_txt.TabIndex = 27
        Me.Vfan_txt.Tag = "1 Geared"
        '
        'NamePlateArmatureFullLoadVoltage_txt
        '
        Me.NamePlateArmatureFullLoadVoltage_txt.AcceptsReturn = True
        Me.NamePlateArmatureFullLoadVoltage_txt.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadVoltage_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NamePlateArmatureFullLoadVoltage_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadVoltage_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadVoltage_txt.Location = New System.Drawing.Point(180, 142)
        Me.NamePlateArmatureFullLoadVoltage_txt.MaxLength = 0
        Me.NamePlateArmatureFullLoadVoltage_txt.Name = "NamePlateArmatureFullLoadVoltage_txt"
        Me.NamePlateArmatureFullLoadVoltage_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadVoltage_txt.Size = New System.Drawing.Size(73, 20)
        Me.NamePlateArmatureFullLoadVoltage_txt.TabIndex = 29
        Me.NamePlateArmatureFullLoadVoltage_txt.Tag = "1 Geared"
        '
        'VFF_txt
        '
        Me.VFF_txt.AcceptsReturn = True
        Me.VFF_txt.BackColor = System.Drawing.SystemColors.Window
        Me.VFF_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VFF_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VFF_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.VFF_txt.Location = New System.Drawing.Point(180, 46)
        Me.VFF_txt.MaxLength = 0
        Me.VFF_txt.Name = "VFF_txt"
        Me.VFF_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.VFF_txt.Size = New System.Drawing.Size(120, 20)
        Me.VFF_txt.TabIndex = 25
        Me.VFF_txt.Tag = "1 Geared"
        '
        'BuildingVoltage_cmb
        '
        Me.BuildingVoltage_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingVoltage_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.BuildingVoltage_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuildingVoltage_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingVoltage_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BuildingVoltage_cmb.Location = New System.Drawing.Point(180, 22)
        Me.BuildingVoltage_cmb.Name = "BuildingVoltage_cmb"
        Me.BuildingVoltage_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingVoltage_cmb.Size = New System.Drawing.Size(120, 21)
        Me.BuildingVoltage_cmb.TabIndex = 24
        Me.BuildingVoltage_cmb.Tag = "1"
        '
        'NamePlateArmatureFullLoadCurrent_lbl
        '
        Me.NamePlateArmatureFullLoadCurrent_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadCurrent_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NamePlateArmatureFullLoadCurrent_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NamePlateArmatureFullLoadCurrent_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadCurrent_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadCurrent_lbl.Location = New System.Drawing.Point(6, 168)
        Me.NamePlateArmatureFullLoadCurrent_lbl.Name = "NamePlateArmatureFullLoadCurrent_lbl"
        Me.NamePlateArmatureFullLoadCurrent_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadCurrent_lbl.Size = New System.Drawing.Size(146, 18)
        Me.NamePlateArmatureFullLoadCurrent_lbl.TabIndex = 70
        Me.NamePlateArmatureFullLoadCurrent_lbl.Text = "Full Load Current (IDC1)"
        '
        'Iff_lbl
        '
        Me.Iff_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Iff_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Iff_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Iff_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Iff_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Iff_lbl.Location = New System.Drawing.Point(6, 72)
        Me.Iff_lbl.Name = "Iff_lbl"
        Me.Iff_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Iff_lbl.Size = New System.Drawing.Size(130, 18)
        Me.Iff_lbl.TabIndex = 69
        Me.Iff_lbl.Text = "Full Field Current (I ff)"
        '
        'Ifan_lbl
        '
        Me.Ifan_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Ifan_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ifan_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Ifan_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ifan_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ifan_lbl.Location = New System.Drawing.Point(6, 120)
        Me.Ifan_lbl.Name = "Ifan_lbl"
        Me.Ifan_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ifan_lbl.Size = New System.Drawing.Size(130, 18)
        Me.Ifan_lbl.TabIndex = 68
        Me.Ifan_lbl.Text = "Fan Current (I fan)"
        '
        'Vfan_lbl
        '
        Me.Vfan_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Vfan_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Vfan_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Vfan_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vfan_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Vfan_lbl.Location = New System.Drawing.Point(6, 96)
        Me.Vfan_lbl.Name = "Vfan_lbl"
        Me.Vfan_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Vfan_lbl.Size = New System.Drawing.Size(130, 18)
        Me.Vfan_lbl.TabIndex = 67
        Me.Vfan_lbl.Text = "Fan Voltage (V fan)"
        '
        'NamePlateArmatureFullLoadVoltage_lbl
        '
        Me.NamePlateArmatureFullLoadVoltage_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NamePlateArmatureFullLoadVoltage_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NamePlateArmatureFullLoadVoltage_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NamePlateArmatureFullLoadVoltage_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePlateArmatureFullLoadVoltage_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NamePlateArmatureFullLoadVoltage_lbl.Location = New System.Drawing.Point(6, 144)
        Me.NamePlateArmatureFullLoadVoltage_lbl.Name = "NamePlateArmatureFullLoadVoltage_lbl"
        Me.NamePlateArmatureFullLoadVoltage_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NamePlateArmatureFullLoadVoltage_lbl.Size = New System.Drawing.Size(150, 18)
        Me.NamePlateArmatureFullLoadVoltage_lbl.TabIndex = 66
        Me.NamePlateArmatureFullLoadVoltage_lbl.Text = "Armature Voltage (VFLU)"
        '
        'VFF_lbl
        '
        Me.VFF_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.VFF_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.VFF_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.VFF_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VFF_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.VFF_lbl.Location = New System.Drawing.Point(6, 48)
        Me.VFF_lbl.Name = "VFF_lbl"
        Me.VFF_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.VFF_lbl.Size = New System.Drawing.Size(132, 18)
        Me.VFF_lbl.TabIndex = 65
        Me.VFF_lbl.Text = "Full Field Voltage ( Vff)"
        '
        'BuildingVoltage_lbl
        '
        Me.BuildingVoltage_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingVoltage_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BuildingVoltage_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BuildingVoltage_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingVoltage_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BuildingVoltage_lbl.Location = New System.Drawing.Point(6, 24)
        Me.BuildingVoltage_lbl.Name = "BuildingVoltage_lbl"
        Me.BuildingVoltage_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingVoltage_lbl.Size = New System.Drawing.Size(130, 18)
        Me.BuildingVoltage_lbl.TabIndex = 58
        Me.BuildingVoltage_lbl.Text = "Building Voltage (vAC)"
        '
        'Frame7
        '
        Me.Frame7.BackColor = System.Drawing.SystemColors.Window
        Me.Frame7.Controls.Add(Me.NumberOfRopes_cmb)
        Me.Frame7.Controls.Add(Me.RopeSize_cmb)
        Me.Frame7.Controls.Add(Me.Wrap_cmb)
        Me.Frame7.Controls.Add(Me.RopingNew_cmb)
        Me.Frame7.Controls.Add(Me.ExistingRopes_lbl)
        Me.Frame7.Controls.Add(Me.NumberOfRopes_lbl)
        Me.Frame7.Controls.Add(Me.RopeSize_lbl)
        Me.Frame7.Controls.Add(Me.Wrap_lbl)
        Me.Frame7.Controls.Add(Me.RopingNew_lbl)
        Me.Frame7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7.Location = New System.Drawing.Point(321, 0)
        Me.Frame7.Name = "Frame7"
        Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7.Size = New System.Drawing.Size(308, 120)
        Me.Frame7.TabIndex = 40
        Me.Frame7.TabStop = False
        Me.Frame7.Text = "Roping And Related Data"
        '
        'NumberOfRopes_cmb
        '
        Me.NumberOfRopes_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberOfRopes_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberOfRopes_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfRopes_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberOfRopes_cmb.Location = New System.Drawing.Point(180, 71)
        Me.NumberOfRopes_cmb.Name = "NumberOfRopes_cmb"
        Me.NumberOfRopes_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberOfRopes_cmb.Size = New System.Drawing.Size(120, 21)
        Me.NumberOfRopes_cmb.TabIndex = 19
        Me.NumberOfRopes_cmb.Tag = "1"
        Me.NumberOfRopes_cmb.Text = "NumberOfRopes_cmb"
        '
        'RopeSize_cmb
        '
        Me.RopeSize_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeSize_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeSize_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeSize_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeSize_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeSize_cmb.Location = New System.Drawing.Point(180, 95)
        Me.RopeSize_cmb.Name = "RopeSize_cmb"
        Me.RopeSize_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeSize_cmb.Size = New System.Drawing.Size(120, 21)
        Me.RopeSize_cmb.TabIndex = 20
        Me.RopeSize_cmb.Tag = "1"
        '
        'Wrap_cmb
        '
        Me.Wrap_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Wrap_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Wrap_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Wrap_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wrap_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Wrap_cmb.Location = New System.Drawing.Point(180, 47)
        Me.Wrap_cmb.Name = "Wrap_cmb"
        Me.Wrap_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Wrap_cmb.Size = New System.Drawing.Size(120, 21)
        Me.Wrap_cmb.TabIndex = 18
        Me.Wrap_cmb.Tag = "1"
        '
        'RopingNew_cmb
        '
        Me.RopingNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopingNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopingNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopingNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopingNew_cmb.Location = New System.Drawing.Point(180, 22)
        Me.RopingNew_cmb.Name = "RopingNew_cmb"
        Me.RopingNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNew_cmb.Size = New System.Drawing.Size(120, 21)
        Me.RopingNew_cmb.TabIndex = 17
        Me.RopingNew_cmb.Tag = "1"
        '
        'ExistingRopes_lbl
        '
        Me.ExistingRopes_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingRopes_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingRopes_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingRopes_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingRopes_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingRopes_lbl.Location = New System.Drawing.Point(6, 72)
        Me.ExistingRopes_lbl.Name = "ExistingRopes_lbl"
        Me.ExistingRopes_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingRopes_lbl.Size = New System.Drawing.Size(106, 18)
        Me.ExistingRopes_lbl.TabIndex = 64
        Me.ExistingRopes_lbl.Text = "Existing Ropes"
        '
        'NumberOfRopes_lbl
        '
        Me.NumberOfRopes_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberOfRopes_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberOfRopes_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberOfRopes_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfRopes_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberOfRopes_lbl.Location = New System.Drawing.Point(46, 73)
        Me.NumberOfRopes_lbl.Name = "NumberOfRopes_lbl"
        Me.NumberOfRopes_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberOfRopes_lbl.Size = New System.Drawing.Size(106, 18)
        Me.NumberOfRopes_lbl.TabIndex = 54
        Me.NumberOfRopes_lbl.Text = "Qty"
        Me.NumberOfRopes_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'RopeSize_lbl
        '
        Me.RopeSize_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeSize_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeSize_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeSize_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeSize_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeSize_lbl.Location = New System.Drawing.Point(46, 97)
        Me.RopeSize_lbl.Name = "RopeSize_lbl"
        Me.RopeSize_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeSize_lbl.Size = New System.Drawing.Size(106, 18)
        Me.RopeSize_lbl.TabIndex = 53
        Me.RopeSize_lbl.Text = "Size (in)"
        Me.RopeSize_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Wrap_lbl
        '
        Me.Wrap_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Wrap_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Wrap_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Wrap_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wrap_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Wrap_lbl.Location = New System.Drawing.Point(6, 49)
        Me.Wrap_lbl.Name = "Wrap_lbl"
        Me.Wrap_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Wrap_lbl.Size = New System.Drawing.Size(106, 18)
        Me.Wrap_lbl.TabIndex = 52
        Me.Wrap_lbl.Text = "Wrap"
        '
        'RopingNew_lbl
        '
        Me.RopingNew_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopingNew_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopingNew_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopingNew_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingNew_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopingNew_lbl.Location = New System.Drawing.Point(5, 24)
        Me.RopingNew_lbl.Name = "RopingNew_lbl"
        Me.RopingNew_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNew_lbl.Size = New System.Drawing.Size(106, 18)
        Me.RopingNew_lbl.TabIndex = 51
        Me.RopingNew_lbl.Text = "Roping New"
        '
        'SystemData_fra
        '
        Me.SystemData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.SystemData_fra.Controls.Add(Me.CarWeight_txt)
        Me.SystemData_fra.Controls.Add(Me.TravelIn_txt)
        Me.SystemData_fra.Controls.Add(Me.Performance_cmb)
        Me.SystemData_fra.Controls.Add(Me.Capacity_cmb)
        Me.SystemData_fra.Controls.Add(Me.HoistwaySheave_cmb)
        Me.SystemData_fra.Controls.Add(Me.TravelFt_txt)
        Me.SystemData_fra.Controls.Add(Me.BrakeType_cmb)
        Me.SystemData_fra.Controls.Add(Me.CarWeight_lbl)
        Me.SystemData_fra.Controls.Add(Me.TravelIn_lbl)
        Me.SystemData_fra.Controls.Add(Me.Performance_lbl)
        Me.SystemData_fra.Controls.Add(Me.HoistwaySheave_lbl)
        Me.SystemData_fra.Controls.Add(Me.Capacity_lbl)
        Me.SystemData_fra.Controls.Add(Me.TravelFt_lbl)
        Me.SystemData_fra.Controls.Add(Me.BrakeType_lbl)
        Me.SystemData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SystemData_fra.Location = New System.Drawing.Point(4, 268)
        Me.SystemData_fra.Name = "SystemData_fra"
        Me.SystemData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SystemData_fra.Size = New System.Drawing.Size(308, 196)
        Me.SystemData_fra.TabIndex = 38
        Me.SystemData_fra.TabStop = False
        Me.SystemData_fra.Text = "System Data"
        '
        'CarWeight_txt
        '
        Me.CarWeight_txt.AcceptsReturn = True
        Me.CarWeight_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeight_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarWeight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeight_txt.Location = New System.Drawing.Point(180, 166)
        Me.CarWeight_txt.MaxLength = 5
        Me.CarWeight_txt.Name = "CarWeight_txt"
        Me.CarWeight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeight_txt.Size = New System.Drawing.Size(120, 20)
        Me.CarWeight_txt.TabIndex = 16
        Me.CarWeight_txt.Tag = "1"
        '
        'TravelIn_txt
        '
        Me.TravelIn_txt.AcceptsReturn = True
        Me.TravelIn_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TravelIn_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TravelIn_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelIn_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelIn_txt.Location = New System.Drawing.Point(180, 70)
        Me.TravelIn_txt.MaxLength = 2
        Me.TravelIn_txt.Name = "TravelIn_txt"
        Me.TravelIn_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelIn_txt.Size = New System.Drawing.Size(120, 20)
        Me.TravelIn_txt.TabIndex = 12
        Me.TravelIn_txt.Tag = "1"
        '
        'Performance_cmb
        '
        Me.Performance_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Performance_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Performance_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Performance_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Performance_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Performance_cmb.Location = New System.Drawing.Point(180, 118)
        Me.Performance_cmb.Name = "Performance_cmb"
        Me.Performance_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Performance_cmb.Size = New System.Drawing.Size(120, 21)
        Me.Performance_cmb.TabIndex = 14
        Me.Performance_cmb.Tag = "1"
        '
        'Capacity_cmb
        '
        Me.Capacity_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Capacity_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Capacity_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capacity_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Capacity_cmb.Location = New System.Drawing.Point(180, 22)
        Me.Capacity_cmb.Name = "Capacity_cmb"
        Me.Capacity_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Capacity_cmb.Size = New System.Drawing.Size(120, 21)
        Me.Capacity_cmb.TabIndex = 10
        Me.Capacity_cmb.Tag = "1"
        Me.Capacity_cmb.Text = "Capacity_cmb"
        '
        'HoistwaySheave_cmb
        '
        Me.HoistwaySheave_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.HoistwaySheave_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistwaySheave_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistwaySheave_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistwaySheave_cmb.Location = New System.Drawing.Point(180, 142)
        Me.HoistwaySheave_cmb.Name = "HoistwaySheave_cmb"
        Me.HoistwaySheave_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistwaySheave_cmb.Size = New System.Drawing.Size(120, 21)
        Me.HoistwaySheave_cmb.TabIndex = 15
        Me.HoistwaySheave_cmb.Tag = "1"
        '
        'TravelFt_txt
        '
        Me.TravelFt_txt.AcceptsReturn = True
        Me.TravelFt_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TravelFt_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TravelFt_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelFt_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelFt_txt.Location = New System.Drawing.Point(180, 46)
        Me.TravelFt_txt.MaxLength = 5
        Me.TravelFt_txt.Name = "TravelFt_txt"
        Me.TravelFt_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelFt_txt.Size = New System.Drawing.Size(120, 20)
        Me.TravelFt_txt.TabIndex = 11
        Me.TravelFt_txt.Tag = "1"
        '
        'BrakeType_cmb
        '
        Me.BrakeType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.BrakeType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.BrakeType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BrakeType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrakeType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BrakeType_cmb.Location = New System.Drawing.Point(180, 94)
        Me.BrakeType_cmb.Name = "BrakeType_cmb"
        Me.BrakeType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BrakeType_cmb.Size = New System.Drawing.Size(120, 21)
        Me.BrakeType_cmb.TabIndex = 13
        Me.BrakeType_cmb.Tag = "1"
        '
        'CarWeight_lbl
        '
        Me.CarWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeight_lbl.Location = New System.Drawing.Point(6, 168)
        Me.CarWeight_lbl.Name = "CarWeight_lbl"
        Me.CarWeight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeight_lbl.Size = New System.Drawing.Size(140, 18)
        Me.CarWeight_lbl.TabIndex = 71
        Me.CarWeight_lbl.Text = "Car Weight (lbs) "
        '
        'TravelIn_lbl
        '
        Me.TravelIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TravelIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelIn_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelIn_lbl.Location = New System.Drawing.Point(6, 72)
        Me.TravelIn_lbl.Name = "TravelIn_lbl"
        Me.TravelIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelIn_lbl.Size = New System.Drawing.Size(140, 18)
        Me.TravelIn_lbl.TabIndex = 63
        Me.TravelIn_lbl.Text = "Travel (in) "
        '
        'Performance_lbl
        '
        Me.Performance_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Performance_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Performance_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Performance_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Performance_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Performance_lbl.Location = New System.Drawing.Point(6, 120)
        Me.Performance_lbl.Name = "Performance_lbl"
        Me.Performance_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Performance_lbl.Size = New System.Drawing.Size(140, 18)
        Me.Performance_lbl.TabIndex = 56
        Me.Performance_lbl.Text = "Performance"
        '
        'HoistwaySheave_lbl
        '
        Me.HoistwaySheave_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistwaySheave_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistwaySheave_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistwaySheave_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistwaySheave_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistwaySheave_lbl.Location = New System.Drawing.Point(6, 144)
        Me.HoistwaySheave_lbl.Name = "HoistwaySheave_lbl"
        Me.HoistwaySheave_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistwaySheave_lbl.Size = New System.Drawing.Size(174, 18)
        Me.HoistwaySheave_lbl.TabIndex = 55
        Me.HoistwaySheave_lbl.Text = "Hoistway Sheave Diameter (in)"
        '
        'Capacity_lbl
        '
        Me.Capacity_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Capacity_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Capacity_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Capacity_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capacity_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Capacity_lbl.Location = New System.Drawing.Point(6, 24)
        Me.Capacity_lbl.Name = "Capacity_lbl"
        Me.Capacity_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Capacity_lbl.Size = New System.Drawing.Size(140, 18)
        Me.Capacity_lbl.TabIndex = 50
        Me.Capacity_lbl.Text = "Capacity (lbs)"
        '
        'TravelFt_lbl
        '
        Me.TravelFt_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TravelFt_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelFt_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelFt_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelFt_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelFt_lbl.Location = New System.Drawing.Point(6, 48)
        Me.TravelFt_lbl.Name = "TravelFt_lbl"
        Me.TravelFt_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelFt_lbl.Size = New System.Drawing.Size(140, 18)
        Me.TravelFt_lbl.TabIndex = 49
        Me.TravelFt_lbl.Text = "Travel (ft) "
        '
        'BrakeType_lbl
        '
        Me.BrakeType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BrakeType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BrakeType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BrakeType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrakeType_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BrakeType_lbl.Location = New System.Drawing.Point(6, 96)
        Me.BrakeType_lbl.Name = "BrakeType_lbl"
        Me.BrakeType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BrakeType_lbl.Size = New System.Drawing.Size(140, 18)
        Me.BrakeType_lbl.TabIndex = 48
        Me.BrakeType_lbl.Text = "Brake Type"
        '
        'GeneralData_fra
        '
        Me.GeneralData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.GeneralData_fra.Controls.Add(Me.MachineModelExisting_cmb)
        Me.GeneralData_fra.Controls.Add(Me.MachineVendorExisting_Cmb)
        Me.GeneralData_fra.Controls.Add(Me.MachineModelExisting_lbl)
        Me.GeneralData_fra.Controls.Add(Me.MachineVendorExisting_lbl)
        Me.GeneralData_fra.Controls.Add(Me.MachineSheaveDia_cmb)
        Me.GeneralData_fra.Controls.Add(Me.DriveType_cmb)
        Me.GeneralData_fra.Controls.Add(Me.ManufacturerNew_cmb)
        Me.GeneralData_fra.Controls.Add(Me.ShoeType_cmb)
        Me.GeneralData_fra.Controls.Add(Me.MachineRoomLocation_cmb)
        Me.GeneralData_fra.Controls.Add(Me.MotorRPM_cmb)
        Me.GeneralData_fra.Controls.Add(Me.MachineTypeNew_cmb)
        Me.GeneralData_fra.Controls.Add(Me.Speed_cmb)
        Me.GeneralData_fra.Controls.Add(Me.MachineSheaveDia_lbl)
        Me.GeneralData_fra.Controls.Add(Me.DriveType_lbl)
        Me.GeneralData_fra.Controls.Add(Me.ManufacturerNew_lbl)
        Me.GeneralData_fra.Controls.Add(Me.ShoeType_lbl)
        Me.GeneralData_fra.Controls.Add(Me.MachineRoomLocation_lbl)
        Me.GeneralData_fra.Controls.Add(Me.MotorRPM_lbl)
        Me.GeneralData_fra.Controls.Add(Me.MachineTypeNew_lbl)
        Me.GeneralData_fra.Controls.Add(Me.Speed_lbl)
        Me.GeneralData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GeneralData_fra.Location = New System.Drawing.Point(4, 0)
        Me.GeneralData_fra.Name = "GeneralData_fra"
        Me.GeneralData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GeneralData_fra.Size = New System.Drawing.Size(308, 267)
        Me.GeneralData_fra.TabIndex = 0
        Me.GeneralData_fra.TabStop = False
        Me.GeneralData_fra.Text = "General Data"
        '
        'MachineModelExisting_cmb
        '
        Me.MachineModelExisting_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineModelExisting_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineModelExisting_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineModelExisting_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineModelExisting_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineModelExisting_cmb.Location = New System.Drawing.Point(180, 45)
        Me.MachineModelExisting_cmb.Name = "MachineModelExisting_cmb"
        Me.MachineModelExisting_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineModelExisting_cmb.Size = New System.Drawing.Size(120, 21)
        Me.MachineModelExisting_cmb.Sorted = True
        Me.MachineModelExisting_cmb.TabIndex = 1
        '
        'MachineVendorExisting_Cmb
        '
        Me.MachineVendorExisting_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineVendorExisting_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineVendorExisting_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineVendorExisting_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineVendorExisting_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineVendorExisting_Cmb.Location = New System.Drawing.Point(180, 21)
        Me.MachineVendorExisting_Cmb.Name = "MachineVendorExisting_Cmb"
        Me.MachineVendorExisting_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineVendorExisting_Cmb.Size = New System.Drawing.Size(120, 21)
        Me.MachineVendorExisting_Cmb.Sorted = True
        Me.MachineVendorExisting_Cmb.TabIndex = 0
        '
        'MachineModelExisting_lbl
        '
        Me.MachineModelExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineModelExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineModelExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineModelExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineModelExisting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineModelExisting_lbl.Location = New System.Drawing.Point(6, 47)
        Me.MachineModelExisting_lbl.Name = "MachineModelExisting_lbl"
        Me.MachineModelExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineModelExisting_lbl.Size = New System.Drawing.Size(140, 16)
        Me.MachineModelExisting_lbl.TabIndex = 68
        Me.MachineModelExisting_lbl.Text = "Existing Machine Model"
        '
        'MachineVendorExisting_lbl
        '
        Me.MachineVendorExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineVendorExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineVendorExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineVendorExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineVendorExisting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineVendorExisting_lbl.Location = New System.Drawing.Point(6, 23)
        Me.MachineVendorExisting_lbl.Name = "MachineVendorExisting_lbl"
        Me.MachineVendorExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineVendorExisting_lbl.Size = New System.Drawing.Size(140, 16)
        Me.MachineVendorExisting_lbl.TabIndex = 67
        Me.MachineVendorExisting_lbl.Text = "Existing Machine Vendor"
        '
        'MachineSheaveDia_cmb
        '
        Me.MachineSheaveDia_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineSheaveDia_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineSheaveDia_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineSheaveDia_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineSheaveDia_cmb.Location = New System.Drawing.Point(180, 120)
        Me.MachineSheaveDia_cmb.Name = "MachineSheaveDia_cmb"
        Me.MachineSheaveDia_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineSheaveDia_cmb.Size = New System.Drawing.Size(120, 21)
        Me.MachineSheaveDia_cmb.TabIndex = 4
        Me.MachineSheaveDia_cmb.Tag = "1"
        Me.MachineSheaveDia_cmb.Text = "MachineSheaveDia_cmb"
        '
        'DriveType_cmb
        '
        Me.DriveType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DriveType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DriveType_cmb.Location = New System.Drawing.Point(180, 240)
        Me.DriveType_cmb.Name = "DriveType_cmb"
        Me.DriveType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveType_cmb.Size = New System.Drawing.Size(120, 21)
        Me.DriveType_cmb.TabIndex = 9
        Me.DriveType_cmb.Tag = "1"
        '
        'ManufacturerNew_cmb
        '
        Me.ManufacturerNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.ManufacturerNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.ManufacturerNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ManufacturerNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManufacturerNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ManufacturerNew_cmb.Location = New System.Drawing.Point(180, 70)
        Me.ManufacturerNew_cmb.Name = "ManufacturerNew_cmb"
        Me.ManufacturerNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ManufacturerNew_cmb.Size = New System.Drawing.Size(120, 21)
        Me.ManufacturerNew_cmb.TabIndex = 2
        Me.ManufacturerNew_cmb.Tag = "1"
        '
        'ShoeType_cmb
        '
        Me.ShoeType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.ShoeType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.ShoeType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ShoeType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShoeType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ShoeType_cmb.Location = New System.Drawing.Point(180, 216)
        Me.ShoeType_cmb.Name = "ShoeType_cmb"
        Me.ShoeType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShoeType_cmb.Size = New System.Drawing.Size(120, 21)
        Me.ShoeType_cmb.TabIndex = 8
        Me.ShoeType_cmb.Tag = "1"
        '
        'MachineRoomLocation_cmb
        '
        Me.MachineRoomLocation_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineRoomLocation_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineRoomLocation_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineRoomLocation_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineRoomLocation_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineRoomLocation_cmb.Location = New System.Drawing.Point(180, 192)
        Me.MachineRoomLocation_cmb.Name = "MachineRoomLocation_cmb"
        Me.MachineRoomLocation_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineRoomLocation_cmb.Size = New System.Drawing.Size(120, 21)
        Me.MachineRoomLocation_cmb.TabIndex = 7
        Me.MachineRoomLocation_cmb.Tag = "1"
        '
        'MotorRPM_cmb
        '
        Me.MotorRPM_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MotorRPM_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MotorRPM_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MotorRPM_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MotorRPM_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MotorRPM_cmb.Location = New System.Drawing.Point(180, 168)
        Me.MotorRPM_cmb.Name = "MotorRPM_cmb"
        Me.MotorRPM_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MotorRPM_cmb.Size = New System.Drawing.Size(120, 21)
        Me.MotorRPM_cmb.TabIndex = 6
        Me.MotorRPM_cmb.Tag = "1"
        '
        'MachineTypeNew_cmb
        '
        Me.MachineTypeNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineTypeNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineTypeNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineTypeNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineTypeNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineTypeNew_cmb.Location = New System.Drawing.Point(180, 96)
        Me.MachineTypeNew_cmb.Name = "MachineTypeNew_cmb"
        Me.MachineTypeNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineTypeNew_cmb.Size = New System.Drawing.Size(120, 21)
        Me.MachineTypeNew_cmb.TabIndex = 3
        Me.MachineTypeNew_cmb.Tag = "1"
        '
        'Speed_cmb
        '
        Me.Speed_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Speed_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Speed_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Speed_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Speed_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Speed_cmb.Location = New System.Drawing.Point(180, 144)
        Me.Speed_cmb.Name = "Speed_cmb"
        Me.Speed_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Speed_cmb.Size = New System.Drawing.Size(120, 21)
        Me.Speed_cmb.TabIndex = 5
        Me.Speed_cmb.Tag = "1"
        '
        'MachineSheaveDia_lbl
        '
        Me.MachineSheaveDia_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineSheaveDia_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineSheaveDia_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineSheaveDia_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineSheaveDia_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineSheaveDia_lbl.Location = New System.Drawing.Point(6, 122)
        Me.MachineSheaveDia_lbl.Name = "MachineSheaveDia_lbl"
        Me.MachineSheaveDia_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineSheaveDia_lbl.Size = New System.Drawing.Size(180, 19)
        Me.MachineSheaveDia_lbl.TabIndex = 62
        Me.MachineSheaveDia_lbl.Text = "Machine Sheave Diameter (in)"
        '
        'DriveType_lbl
        '
        Me.DriveType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DriveType_lbl.Location = New System.Drawing.Point(6, 242)
        Me.DriveType_lbl.Name = "DriveType_lbl"
        Me.DriveType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveType_lbl.Size = New System.Drawing.Size(120, 18)
        Me.DriveType_lbl.TabIndex = 59
        Me.DriveType_lbl.Text = "Drive Type"
        '
        'ManufacturerNew_lbl
        '
        Me.ManufacturerNew_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ManufacturerNew_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ManufacturerNew_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ManufacturerNew_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManufacturerNew_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ManufacturerNew_lbl.Location = New System.Drawing.Point(6, 72)
        Me.ManufacturerNew_lbl.Name = "ManufacturerNew_lbl"
        Me.ManufacturerNew_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ManufacturerNew_lbl.Size = New System.Drawing.Size(140, 18)
        Me.ManufacturerNew_lbl.TabIndex = 57
        Me.ManufacturerNew_lbl.Text = "New Machine Vendor"
        '
        'ShoeType_lbl
        '
        Me.ShoeType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ShoeType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ShoeType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ShoeType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShoeType_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ShoeType_lbl.Location = New System.Drawing.Point(6, 218)
        Me.ShoeType_lbl.Name = "ShoeType_lbl"
        Me.ShoeType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShoeType_lbl.Size = New System.Drawing.Size(140, 18)
        Me.ShoeType_lbl.TabIndex = 47
        Me.ShoeType_lbl.Text = "Car Guides Type"
        '
        'MachineRoomLocation_lbl
        '
        Me.MachineRoomLocation_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineRoomLocation_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineRoomLocation_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineRoomLocation_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineRoomLocation_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineRoomLocation_lbl.Location = New System.Drawing.Point(6, 194)
        Me.MachineRoomLocation_lbl.Name = "MachineRoomLocation_lbl"
        Me.MachineRoomLocation_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineRoomLocation_lbl.Size = New System.Drawing.Size(140, 18)
        Me.MachineRoomLocation_lbl.TabIndex = 46
        Me.MachineRoomLocation_lbl.Text = "Machine Room Location"
        '
        'MotorRPM_lbl
        '
        Me.MotorRPM_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MotorRPM_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MotorRPM_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MotorRPM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MotorRPM_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MotorRPM_lbl.Location = New System.Drawing.Point(6, 170)
        Me.MotorRPM_lbl.Name = "MotorRPM_lbl"
        Me.MotorRPM_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MotorRPM_lbl.Size = New System.Drawing.Size(140, 18)
        Me.MotorRPM_lbl.TabIndex = 45
        Me.MotorRPM_lbl.Text = "Nominal Motor RPM"
        '
        'MachineTypeNew_lbl
        '
        Me.MachineTypeNew_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineTypeNew_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineTypeNew_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineTypeNew_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineTypeNew_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineTypeNew_lbl.Location = New System.Drawing.Point(6, 98)
        Me.MachineTypeNew_lbl.Name = "MachineTypeNew_lbl"
        Me.MachineTypeNew_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineTypeNew_lbl.Size = New System.Drawing.Size(140, 18)
        Me.MachineTypeNew_lbl.TabIndex = 44
        Me.MachineTypeNew_lbl.Text = "New Machine Model"
        '
        'Speed_lbl
        '
        Me.Speed_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Speed_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Speed_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Speed_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Speed_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Speed_lbl.Location = New System.Drawing.Point(6, 146)
        Me.Speed_lbl.Name = "Speed_lbl"
        Me.Speed_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Speed_lbl.Size = New System.Drawing.Size(140, 18)
        Me.Speed_lbl.TabIndex = 43
        Me.Speed_lbl.Text = "Speed (ft/min) "
        '
        'TopOfCarDevices_fra
        '
        Me.TopOfCarDevices_fra.BackColor = System.Drawing.SystemColors.Window
        Me.TopOfCarDevices_fra.Controls.Add(Me.LoadWeighType_cmb)
        Me.TopOfCarDevices_fra.Controls.Add(Me.LoadWeighType_lbl)
        Me.TopOfCarDevices_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopOfCarDevices_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TopOfCarDevices_fra.Location = New System.Drawing.Point(639, 228)
        Me.TopOfCarDevices_fra.Name = "TopOfCarDevices_fra"
        Me.TopOfCarDevices_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopOfCarDevices_fra.Size = New System.Drawing.Size(308, 57)
        Me.TopOfCarDevices_fra.TabIndex = 81
        Me.TopOfCarDevices_fra.TabStop = False
        Me.TopOfCarDevices_fra.Text = "Top Of Car Devices"
        '
        'LoadWeighType_cmb
        '
        Me.LoadWeighType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.LoadWeighType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.LoadWeighType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LoadWeighType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadWeighType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LoadWeighType_cmb.Location = New System.Drawing.Point(165, 20)
        Me.LoadWeighType_cmb.Name = "LoadWeighType_cmb"
        Me.LoadWeighType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LoadWeighType_cmb.Size = New System.Drawing.Size(135, 21)
        Me.LoadWeighType_cmb.TabIndex = 39
        '
        'LoadWeighType_lbl
        '
        Me.LoadWeighType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.LoadWeighType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.LoadWeighType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LoadWeighType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadWeighType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LoadWeighType_lbl.Location = New System.Drawing.Point(6, 26)
        Me.LoadWeighType_lbl.Name = "LoadWeighType_lbl"
        Me.LoadWeighType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LoadWeighType_lbl.Size = New System.Drawing.Size(168, 18)
        Me.LoadWeighType_lbl.TabIndex = 61
        Me.LoadWeighType_lbl.Text = "Car Load Weigh Type"
        '
        'RopeGripper_fra
        '
        Me.RopeGripper_fra.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripper_fra.Controls.Add(Me.RopeSplayKitMounting_cmb)
        Me.RopeGripper_fra.Controls.Add(Me.RopeSplayKitMounting_lbl)
        Me.RopeGripper_fra.Controls.Add(Me.MountingToOuterMBflanges_chk)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripperMount_cmb)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripperMount_lbl)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripper_cmb)
        Me.RopeGripper_fra.Controls.Add(Me.Label1)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripperModel_cmb)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripperModelDetails_cmd)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripper_lbl)
        Me.RopeGripper_fra.Controls.Add(Me.RopeGripperModel_lbl)
        Me.RopeGripper_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripper_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopeGripper_fra.Location = New System.Drawing.Point(639, 288)
        Me.RopeGripper_fra.Name = "RopeGripper_fra"
        Me.RopeGripper_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripper_fra.Size = New System.Drawing.Size(308, 164)
        Me.RopeGripper_fra.TabIndex = 91
        Me.RopeGripper_fra.TabStop = False
        Me.RopeGripper_fra.Text = "Rope Gripper"
        '
        'RopeSplayKitMounting_cmb
        '
        Me.RopeSplayKitMounting_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeSplayKitMounting_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeSplayKitMounting_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeSplayKitMounting_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeSplayKitMounting_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeSplayKitMounting_cmb.Location = New System.Drawing.Point(165, 118)
        Me.RopeSplayKitMounting_cmb.Name = "RopeSplayKitMounting_cmb"
        Me.RopeSplayKitMounting_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeSplayKitMounting_cmb.Size = New System.Drawing.Size(135, 21)
        Me.RopeSplayKitMounting_cmb.TabIndex = 44
        '
        'RopeSplayKitMounting_lbl
        '
        Me.RopeSplayKitMounting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeSplayKitMounting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeSplayKitMounting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeSplayKitMounting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeSplayKitMounting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopeSplayKitMounting_lbl.Location = New System.Drawing.Point(6, 120)
        Me.RopeSplayKitMounting_lbl.Name = "RopeSplayKitMounting_lbl"
        Me.RopeSplayKitMounting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeSplayKitMounting_lbl.Size = New System.Drawing.Size(153, 16)
        Me.RopeSplayKitMounting_lbl.TabIndex = 91
        Me.RopeSplayKitMounting_lbl.Text = "Rope Splay Kit Mounting"
        '
        'MountingToOuterMBflanges_chk
        '
        Me.MountingToOuterMBflanges_chk.BackColor = System.Drawing.SystemColors.Window
        Me.MountingToOuterMBflanges_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MountingToOuterMBflanges_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.MountingToOuterMBflanges_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MountingToOuterMBflanges_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MountingToOuterMBflanges_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MountingToOuterMBflanges_chk.Location = New System.Drawing.Point(6, 141)
        Me.MountingToOuterMBflanges_chk.Name = "MountingToOuterMBflanges_chk"
        Me.MountingToOuterMBflanges_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MountingToOuterMBflanges_chk.Size = New System.Drawing.Size(294, 17)
        Me.MountingToOuterMBflanges_chk.TabIndex = 45
        Me.MountingToOuterMBflanges_chk.Text = "Mounting to outer MB flanges"
        Me.MountingToOuterMBflanges_chk.UseVisualStyleBackColor = False
        '
        'RopeGripperMount_cmb
        '
        Me.RopeGripperMount_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripperMount_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripperMount_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeGripperMount_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripperMount_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGripperMount_cmb.Location = New System.Drawing.Point(165, 92)
        Me.RopeGripperMount_cmb.Name = "RopeGripperMount_cmb"
        Me.RopeGripperMount_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripperMount_cmb.Size = New System.Drawing.Size(135, 21)
        Me.RopeGripperMount_cmb.Sorted = True
        Me.RopeGripperMount_cmb.TabIndex = 43
        '
        'RopeGripperMount_lbl
        '
        Me.RopeGripperMount_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripperMount_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripperMount_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeGripperMount_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripperMount_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopeGripperMount_lbl.Location = New System.Drawing.Point(6, 94)
        Me.RopeGripperMount_lbl.Name = "RopeGripperMount_lbl"
        Me.RopeGripperMount_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripperMount_lbl.Size = New System.Drawing.Size(123, 16)
        Me.RopeGripperMount_lbl.TabIndex = 89
        Me.RopeGripperMount_lbl.Text = "Rope Gripper Mount*"
        '
        'RopeGripper_cmb
        '
        Me.RopeGripper_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripper_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripper_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeGripper_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripper_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGripper_cmb.Location = New System.Drawing.Point(165, 20)
        Me.RopeGripper_cmb.Name = "RopeGripper_cmb"
        Me.RopeGripper_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripper_cmb.Size = New System.Drawing.Size(135, 21)
        Me.RopeGripper_cmb.Sorted = True
        Me.RopeGripper_cmb.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Rope Gripper"
        '
        'RopeGripperModel_cmb
        '
        Me.RopeGripperModel_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripperModel_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripperModel_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeGripperModel_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripperModel_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGripperModel_cmb.Location = New System.Drawing.Point(165, 44)
        Me.RopeGripperModel_cmb.Name = "RopeGripperModel_cmb"
        Me.RopeGripperModel_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripperModel_cmb.Size = New System.Drawing.Size(135, 21)
        Me.RopeGripperModel_cmb.TabIndex = 41
        Me.RopeGripperModel_cmb.Tag = "Print Me"
        '
        'RopeGripperModelDetails_cmd
        '
        Me.RopeGripperModelDetails_cmd.BackColor = System.Drawing.SystemColors.Control
        Me.RopeGripperModelDetails_cmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripperModelDetails_cmd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeGripperModelDetails_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripperModelDetails_cmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopeGripperModelDetails_cmd.Location = New System.Drawing.Point(165, 68)
        Me.RopeGripperModelDetails_cmd.Name = "RopeGripperModelDetails_cmd"
        Me.RopeGripperModelDetails_cmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripperModelDetails_cmd.Size = New System.Drawing.Size(135, 21)
        Me.RopeGripperModelDetails_cmd.TabIndex = 42
        Me.RopeGripperModelDetails_cmd.Text = "Details"
        Me.RopeGripperModelDetails_cmd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.RopeGripperModelDetails_cmd.UseVisualStyleBackColor = False
        '
        'RopeGripper_lbl
        '
        Me.RopeGripper_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripper_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripper_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeGripper_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripper_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGripper_lbl.Location = New System.Drawing.Point(368, 24)
        Me.RopeGripper_lbl.Name = "RopeGripper_lbl"
        Me.RopeGripper_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripper_lbl.Size = New System.Drawing.Size(183, 18)
        Me.RopeGripper_lbl.TabIndex = 20
        Me.RopeGripper_lbl.Tag = "Print Me"
        Me.RopeGripper_lbl.Text = "Rope Gripper Questions"
        '
        'RopeGripperModel_lbl
        '
        Me.RopeGripperModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGripperModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGripperModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeGripperModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGripperModel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGripperModel_lbl.Location = New System.Drawing.Point(6, 46)
        Me.RopeGripperModel_lbl.Name = "RopeGripperModel_lbl"
        Me.RopeGripperModel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGripperModel_lbl.Size = New System.Drawing.Size(143, 18)
        Me.RopeGripperModel_lbl.TabIndex = 16
        Me.RopeGripperModel_lbl.Text = "Rope Gripper Model: "
        '
        'Governor_fra
        '
        Me.Governor_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Governor_fra.Controls.Add(Me.CwtGovernorFastening_cmb)
        Me.Governor_fra.Controls.Add(Me.CwtGovernorFastening_lbl)
        Me.Governor_fra.Controls.Add(Me.CarGovernorFastening_cmb)
        Me.Governor_fra.Controls.Add(Me.CarGovernorFastening_lbl)
        Me.Governor_fra.Controls.Add(Me.CwtGovernorNewModel_cmb)
        Me.Governor_fra.Controls.Add(Me.CwtGovernorNewModel_lbl)
        Me.Governor_fra.Controls.Add(Me.CarGovernorNewModel_cmb)
        Me.Governor_fra.Controls.Add(Me.CarGovernorNewModel_lbl)
        Me.Governor_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Governor_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Governor_fra.Location = New System.Drawing.Point(639, 459)
        Me.Governor_fra.Name = "Governor_fra"
        Me.Governor_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Governor_fra.Size = New System.Drawing.Size(308, 120)
        Me.Governor_fra.TabIndex = 92
        Me.Governor_fra.TabStop = False
        Me.Governor_fra.Text = "Governors"
        '
        'CwtGovernorFastening_cmb
        '
        Me.CwtGovernorFastening_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CwtGovernorFastening_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtGovernorFastening_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CwtGovernorFastening_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtGovernorFastening_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtGovernorFastening_cmb.Location = New System.Drawing.Point(166, 92)
        Me.CwtGovernorFastening_cmb.Name = "CwtGovernorFastening_cmb"
        Me.CwtGovernorFastening_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtGovernorFastening_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CwtGovernorFastening_cmb.TabIndex = 49
        '
        'CwtGovernorFastening_lbl
        '
        Me.CwtGovernorFastening_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CwtGovernorFastening_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtGovernorFastening_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CwtGovernorFastening_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtGovernorFastening_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CwtGovernorFastening_lbl.Location = New System.Drawing.Point(7, 94)
        Me.CwtGovernorFastening_lbl.Name = "CwtGovernorFastening_lbl"
        Me.CwtGovernorFastening_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtGovernorFastening_lbl.Size = New System.Drawing.Size(168, 21)
        Me.CwtGovernorFastening_lbl.TabIndex = 67
        Me.CwtGovernorFastening_lbl.Text = "Cwt Governor Fastening"
        '
        'CarGovernorFastening_cmb
        '
        Me.CarGovernorFastening_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CarGovernorFastening_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarGovernorFastening_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CarGovernorFastening_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarGovernorFastening_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarGovernorFastening_cmb.Location = New System.Drawing.Point(166, 44)
        Me.CarGovernorFastening_cmb.Name = "CarGovernorFastening_cmb"
        Me.CarGovernorFastening_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarGovernorFastening_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CarGovernorFastening_cmb.TabIndex = 47
        '
        'CarGovernorFastening_lbl
        '
        Me.CarGovernorFastening_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarGovernorFastening_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarGovernorFastening_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarGovernorFastening_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarGovernorFastening_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarGovernorFastening_lbl.Location = New System.Drawing.Point(7, 46)
        Me.CarGovernorFastening_lbl.Name = "CarGovernorFastening_lbl"
        Me.CarGovernorFastening_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarGovernorFastening_lbl.Size = New System.Drawing.Size(168, 21)
        Me.CarGovernorFastening_lbl.TabIndex = 65
        Me.CarGovernorFastening_lbl.Text = "Car Governor Fastening"
        '
        'CwtGovernorNewModel_cmb
        '
        Me.CwtGovernorNewModel_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CwtGovernorNewModel_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtGovernorNewModel_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CwtGovernorNewModel_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtGovernorNewModel_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtGovernorNewModel_cmb.Location = New System.Drawing.Point(166, 68)
        Me.CwtGovernorNewModel_cmb.Name = "CwtGovernorNewModel_cmb"
        Me.CwtGovernorNewModel_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtGovernorNewModel_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CwtGovernorNewModel_cmb.TabIndex = 48
        '
        'CwtGovernorNewModel_lbl
        '
        Me.CwtGovernorNewModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CwtGovernorNewModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtGovernorNewModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CwtGovernorNewModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtGovernorNewModel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CwtGovernorNewModel_lbl.Location = New System.Drawing.Point(7, 70)
        Me.CwtGovernorNewModel_lbl.Name = "CwtGovernorNewModel_lbl"
        Me.CwtGovernorNewModel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtGovernorNewModel_lbl.Size = New System.Drawing.Size(168, 21)
        Me.CwtGovernorNewModel_lbl.TabIndex = 63
        Me.CwtGovernorNewModel_lbl.Text = "Cwt Governor New Model"
        '
        'CarGovernorNewModel_cmb
        '
        Me.CarGovernorNewModel_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CarGovernorNewModel_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarGovernorNewModel_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CarGovernorNewModel_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarGovernorNewModel_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarGovernorNewModel_cmb.Location = New System.Drawing.Point(165, 20)
        Me.CarGovernorNewModel_cmb.Name = "CarGovernorNewModel_cmb"
        Me.CarGovernorNewModel_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarGovernorNewModel_cmb.Size = New System.Drawing.Size(135, 21)
        Me.CarGovernorNewModel_cmb.TabIndex = 46
        '
        'CarGovernorNewModel_lbl
        '
        Me.CarGovernorNewModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarGovernorNewModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarGovernorNewModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarGovernorNewModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarGovernorNewModel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarGovernorNewModel_lbl.Location = New System.Drawing.Point(6, 22)
        Me.CarGovernorNewModel_lbl.Name = "CarGovernorNewModel_lbl"
        Me.CarGovernorNewModel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarGovernorNewModel_lbl.Size = New System.Drawing.Size(168, 21)
        Me.CarGovernorNewModel_lbl.TabIndex = 61
        Me.CarGovernorNewModel_lbl.Text = "Car Governor New Model"
        '
        'LobbyVision_fra
        '
        Me.LobbyVision_fra.BackColor = System.Drawing.SystemColors.Window
        Me.LobbyVision_fra.Controls.Add(Me.QtyStarRepeater_cmb)
        Me.LobbyVision_fra.Controls.Add(Me.QtyStarRepeater_lbl)
        Me.LobbyVision_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LobbyVision_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LobbyVision_fra.Location = New System.Drawing.Point(322, 444)
        Me.LobbyVision_fra.Name = "LobbyVision_fra"
        Me.LobbyVision_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LobbyVision_fra.Size = New System.Drawing.Size(307, 55)
        Me.LobbyVision_fra.TabIndex = 100
        Me.LobbyVision_fra.TabStop = False
        Me.LobbyVision_fra.Tag = "Left"
        Me.LobbyVision_fra.Text = "Lobby Vision"
        '
        'QtyStarRepeater_cmb
        '
        Me.QtyStarRepeater_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.QtyStarRepeater_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.QtyStarRepeater_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.QtyStarRepeater_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QtyStarRepeater_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.QtyStarRepeater_cmb.Location = New System.Drawing.Point(180, 21)
        Me.QtyStarRepeater_cmb.Name = "QtyStarRepeater_cmb"
        Me.QtyStarRepeater_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.QtyStarRepeater_cmb.Size = New System.Drawing.Size(120, 21)
        Me.QtyStarRepeater_cmb.TabIndex = 32
        Me.QtyStarRepeater_cmb.Tag = "1"
        '
        'QtyStarRepeater_lbl
        '
        Me.QtyStarRepeater_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.QtyStarRepeater_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.QtyStarRepeater_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.QtyStarRepeater_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QtyStarRepeater_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.QtyStarRepeater_lbl.Location = New System.Drawing.Point(6, 24)
        Me.QtyStarRepeater_lbl.Name = "QtyStarRepeater_lbl"
        Me.QtyStarRepeater_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.QtyStarRepeater_lbl.Size = New System.Drawing.Size(130, 18)
        Me.QtyStarRepeater_lbl.TabIndex = 72
        Me.QtyStarRepeater_lbl.Tag = "Print Me"
        Me.QtyStarRepeater_lbl.Text = "Qty Star Repeater"
        '
        'MN_TRQ01_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(951, 584)
        Me.ControlBox = False
        Me.Controls.Add(Me.LobbyVision_fra)
        Me.Controls.Add(Me.Governor_fra)
        Me.Controls.Add(Me.RopeGripper_fra)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Only2To1Roping_fra)
        Me.Controls.Add(Me.Compensation_fra)
        Me.Controls.Add(Me.ElectricalData_fra)
        Me.Controls.Add(Me.Frame7)
        Me.Controls.Add(Me.SystemData_fra)
        Me.Controls.Add(Me.GeneralData_fra)
        Me.Controls.Add(Me.TopOfCarDevices_fra)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(-189, 11)
        Me.Name = "MN_TRQ01_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Specs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Frame2.ResumeLayout(False)
        Me.Only2To1Roping_fra.ResumeLayout(False)
        Me.Compensation_fra.ResumeLayout(False)
        Me.Compensation_fra.PerformLayout()
        Me.ElectricalData_fra.ResumeLayout(False)
        Me.ElectricalData_fra.PerformLayout()
        Me.Frame7.ResumeLayout(False)
        Me.SystemData_fra.ResumeLayout(False)
        Me.SystemData_fra.PerformLayout()
        Me.GeneralData_fra.ResumeLayout(False)
        Me.TopOfCarDevices_fra.ResumeLayout(False)
        Me.RopeGripper_fra.ResumeLayout(False)
        Me.Governor_fra.ResumeLayout(False)
        Me.LobbyVision_fra.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Sub ReLoadForm(ByVal addEvents As Boolean)
        'This form is an MDI child.
        'This code simulates the VB6 
        ' functionality of automatically
        ' loading and showing an MDI
        ' child's parent.
        'Me.MdiParent = CadreMO.Main_MDI_frm
        'If Not FromCM Then
        '    CadreMO.Main_MDI_frm.Show()
        'End If
        'If addEvents Then
        '    AddHandler MyBase.Paint, AddressOf Me.MN_TRQ01_frm_Paint
        '    AddHandler MyBase.Load, AddressOf Me.MN_TRQ01_frm_Load
        '    AddHandler MyBase.Resize, AddressOf Me.MN_TRQ01_frm_Resize
        '    AddHandler MyBase.Closed, AddressOf Me.MN_TRQ01_frm_Closed
        'End If
    End Sub
    Public WithEvents MachineModelExisting_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineVendorExisting_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineModelExisting_lbl As System.Windows.Forms.Label
    Public WithEvents MachineVendorExisting_lbl As System.Windows.Forms.Label
    Public WithEvents TopOfCarDevices_fra As System.Windows.Forms.GroupBox
    Public WithEvents LoadWeighType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents LoadWeighType_lbl As System.Windows.Forms.Label
    Public WithEvents NamePlateArmatureFullLoadCurrentAmps_lbl As System.Windows.Forms.Label
    Public WithEvents NamePlateArmatureFullLoadVoltageVolts_lbl As System.Windows.Forms.Label
    Public WithEvents RopeGripper_fra As System.Windows.Forms.GroupBox
    Public WithEvents RopeGripperModel_cmb As System.Windows.Forms.ComboBox
    Public WithEvents RopeGripperModelDetails_cmd As System.Windows.Forms.Button
    Public WithEvents RopeGripper_lbl As System.Windows.Forms.Label
    Private WithEvents RopeGripperModel_lbl As System.Windows.Forms.Label
    Public WithEvents RopeGripper_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents RopeGripperMount_cmb As System.Windows.Forms.ComboBox
    Public WithEvents RopeGripperMount_lbl As System.Windows.Forms.Label
    Public WithEvents MountingToOuterMBflanges_chk As System.Windows.Forms.CheckBox
    Public WithEvents ResetElectricalDataToDefault_cmd As System.Windows.Forms.Button
    Public WithEvents Governor_fra As System.Windows.Forms.GroupBox
    Public WithEvents CwtGovernorNewModel_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CwtGovernorNewModel_lbl As System.Windows.Forms.Label
    Public WithEvents CarGovernorNewModel_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarGovernorNewModel_lbl As System.Windows.Forms.Label
    Public WithEvents RopeSplayKitMounting_cmb As System.Windows.Forms.ComboBox
    Public WithEvents RopeSplayKitMounting_lbl As System.Windows.Forms.Label
    Public WithEvents CwtGovernorFastening_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CwtGovernorFastening_lbl As System.Windows.Forms.Label
    Public WithEvents CarGovernorFastening_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarGovernorFastening_lbl As System.Windows.Forms.Label
    Public WithEvents LobbyVision_fra As System.Windows.Forms.GroupBox
    Public WithEvents QtyStarRepeater_lbl As System.Windows.Forms.Label
    Public WithEvents QtyStarRepeater_cmb As System.Windows.Forms.ComboBox
    Public WithEvents AdditionalCoaxCableQty_cmb As System.Windows.Forms.ComboBox
    Public WithEvents AdditionalCoaxCableQty_lbl As System.Windows.Forms.Label
    Public WithEvents AdditionalShieldPairsQty_cmb As System.Windows.Forms.ComboBox
    Public WithEvents AdditionalShieldPairsQty_lbl As System.Windows.Forms.Label
#End Region
End Class