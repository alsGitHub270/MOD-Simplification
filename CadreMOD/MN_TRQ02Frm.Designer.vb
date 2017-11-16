<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MN_TRQ02_frm
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        isInitializingComponent = True
        InitializeComponent()
        isInitializingComponent = False
        ReLoadForm(False)
    End Sub
    Private visualControls() As String = New String() {"components", "ToolTipMain", "RequiredKVA_cmb", "RequiredKVA_lbl", "Autotransformer_fra", "SoftwareLevel_txt", "SoftwareLevel_lbl", "Software_fra", "NominalMotorHP_cmb", "NominalMotorHP_lbl", "ACMotor_fra", "DriveModel_cmb", "DriveModel_lbl", "MotorDrive_fra", "CarWeightCalculated_txt", "Counterweight_txt", "CarWeightCalculated_lbl", "Counterweight_lbl", "SystemData_fra", "DeflectorSheave_txt", "DeflectorSheaveJ_txt", "DeflectorSheave_lbl", "DeflectorSheaveJ_lbl", "DeflectorSecondarySheave_fra", "RopeGrade_cmb", "len1_txt", "len3_txt", "len2_txt", "RopeGrade_lbl", "len1_lbl", "len3_lbl", "len2_lbl", "RopeModifiers_fra", "IdlerSheaveDiameter_txt", "OverheadSheaveInertia_txt", "OverheadSheaveInertia_lbl", "IdlerSheaveDiameter_lbl", "OnlyBasement_fra", "CompSheaveWeight_txt", "SheaveDiameter_txt", "CompensationWeight_txt", "CompSheaveJ_txt", "CompSheaveWeight_lbl", "SheaveDiameter_lbl", "CompensationWeight_lbl", "CompSheaveJ_lbl", "CompensationData_fra", "RopeDrop_txt", "RopeOffset_txt", "X1_txt", "Y1_txt", "WrapAngle_txt", "Refer_lbl", "RopeDrop_lbl", "RopeOffset_lbl", "X1_lbl", "Y1_lbl", "WrapAngle_lbl", "WrapAngleCalc_fra", "GrooveNumber_cmb", "GrooveNumber_lbl", "RopingAndRelatedData_fra", "CwtSheaveDiameter_txt", "CarSheaveDiameter_txt", "CwtSheaveJ_txt", "CarSheaveJ_txt", "CarSheaveJ_lbl", "CwtSheaveJ_lbl", "CwtSheaveDiameter_lbl", "CarSheaveDiameter_lbl", "Only2To1Roping_fra", "MaxShaftSheaveLoad_txt", "HiSpeedShaftInertia_txt", "MachineSheaveJ_txt", "ReverseGearEfficiency_txt", "ForwardGearEfficiency_txt", "GearRatio1_txt", "GearRatio2_txt", "MaxShaftSheaveLoad_lbl", "MachineSheaveJ_lbl", "HiSpeedShaftInertia_lbl", "ReverseGearEfficiency_lbl", "GearRatio2_lbl", "GearRatio1_lbl", "ForwardGearEfficiency_lbl", "SheaveData_fra"}
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Public WithEvents RequiredKVA_lbl As System.Windows.Forms.Label
    Public WithEvents Autotransformer_fra As System.Windows.Forms.GroupBox
    Public WithEvents SoftwareLevel_txt As System.Windows.Forms.TextBox
    Public WithEvents SoftwareLevel_lbl As System.Windows.Forms.Label
    Public WithEvents Software_fra As System.Windows.Forms.GroupBox
    Public WithEvents NominalMotorHP_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NominalMotorHP_lbl As System.Windows.Forms.Label
    Public WithEvents ACMotor_fra As System.Windows.Forms.GroupBox
    Public WithEvents DriveModel_cmb As System.Windows.Forms.ComboBox
    Public WithEvents DriveModel_lbl As System.Windows.Forms.Label
    Public WithEvents MotorDrive_fra As System.Windows.Forms.GroupBox
    Public WithEvents CarWeightCalculated_txt As System.Windows.Forms.TextBox
    Public WithEvents Counterweight_txt As System.Windows.Forms.TextBox
    Public WithEvents CarWeightCalculated_lbl As System.Windows.Forms.Label
    Public WithEvents Counterweight_lbl As System.Windows.Forms.Label
    Public WithEvents SystemData_fra As System.Windows.Forms.GroupBox
    Public WithEvents DeflectorSheave_txt As System.Windows.Forms.TextBox
    Public WithEvents DeflectorSheaveJ_txt As System.Windows.Forms.TextBox
    Public WithEvents DeflectorSheave_lbl As System.Windows.Forms.Label
    Public WithEvents DeflectorSheaveJ_lbl As System.Windows.Forms.Label
    Public WithEvents DeflectorSecondarySheave_fra As System.Windows.Forms.GroupBox
    Public WithEvents RopeGrade_cmb As System.Windows.Forms.ComboBox
    Public WithEvents len1_txt As System.Windows.Forms.TextBox
    Public WithEvents len3_txt As System.Windows.Forms.TextBox
    Public WithEvents len2_txt As System.Windows.Forms.TextBox
    Public WithEvents RopeGrade_lbl As System.Windows.Forms.Label
    Public WithEvents len1_lbl As System.Windows.Forms.Label
    Public WithEvents len3_lbl As System.Windows.Forms.Label
    Public WithEvents len2_lbl As System.Windows.Forms.Label
    Public WithEvents RopeModifiers_fra As System.Windows.Forms.GroupBox
    Public WithEvents IdlerSheaveDiameter_txt As System.Windows.Forms.TextBox
    Public WithEvents OverheadSheaveInertia_txt As System.Windows.Forms.TextBox
    Public WithEvents OverheadSheaveInertia_lbl As System.Windows.Forms.Label
    Public WithEvents IdlerSheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents OnlyBasement_fra As System.Windows.Forms.GroupBox
    Public WithEvents CompSheaveWeight_txt As System.Windows.Forms.TextBox
    Public WithEvents SheaveDiameter_txt As System.Windows.Forms.TextBox
    Public WithEvents CompensationWeight_txt As System.Windows.Forms.TextBox
    Public WithEvents CompSheaveJ_txt As System.Windows.Forms.TextBox
    Public WithEvents CompSheaveWeight_lbl As System.Windows.Forms.Label
    Public WithEvents SheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents CompensationWeight_lbl As System.Windows.Forms.Label
    Public WithEvents CompSheaveJ_lbl As System.Windows.Forms.Label
    Public WithEvents CompensationData_fra As System.Windows.Forms.GroupBox
    Public WithEvents RopeDrop_txt As System.Windows.Forms.TextBox
    Public WithEvents RopeOffset_txt As System.Windows.Forms.TextBox
    Public WithEvents X1_txt As System.Windows.Forms.TextBox
    Public WithEvents Y1_txt As System.Windows.Forms.TextBox
    Public WithEvents WrapAngle_txt As System.Windows.Forms.TextBox
    Public WithEvents Refer_lbl As System.Windows.Forms.Label
    Public WithEvents RopeDrop_lbl As System.Windows.Forms.Label
    Public WithEvents RopeOffset_lbl As System.Windows.Forms.Label
    Public WithEvents X1_lbl As System.Windows.Forms.Label
    Public WithEvents Y1_lbl As System.Windows.Forms.Label
    Public WithEvents WrapAngle_lbl As System.Windows.Forms.Label
    Public WithEvents WrapAngleCalc_fra As System.Windows.Forms.GroupBox
    Public WithEvents GrooveNumber_cmb As System.Windows.Forms.ComboBox
    Public WithEvents GrooveNumber_lbl As System.Windows.Forms.Label
    Public WithEvents RopingAndRelatedData_fra As System.Windows.Forms.GroupBox
    Public WithEvents CwtSheaveDiameter_txt As System.Windows.Forms.TextBox
    Public WithEvents CarSheaveDiameter_txt As System.Windows.Forms.TextBox
    Public WithEvents CwtSheaveJ_txt As System.Windows.Forms.TextBox
    Public WithEvents CarSheaveJ_txt As System.Windows.Forms.TextBox
    Public WithEvents CarSheaveJ_lbl As System.Windows.Forms.Label
    Public WithEvents CwtSheaveJ_lbl As System.Windows.Forms.Label
    Public WithEvents CwtSheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents CarSheaveDiameter_lbl As System.Windows.Forms.Label
    Public WithEvents Only2To1Roping_fra As System.Windows.Forms.GroupBox
    Public WithEvents MaxShaftSheaveLoad_txt As System.Windows.Forms.TextBox
    Public WithEvents HiSpeedShaftInertia_txt As System.Windows.Forms.TextBox
    Public WithEvents MachineSheaveJ_txt As System.Windows.Forms.TextBox
    Public WithEvents ReverseGearEfficiency_txt As System.Windows.Forms.TextBox
    Public WithEvents ForwardGearEfficiency_txt As System.Windows.Forms.TextBox
    Public WithEvents GearRatio1_txt As System.Windows.Forms.TextBox
    Public WithEvents GearRatio2_txt As System.Windows.Forms.TextBox
    Public WithEvents MaxShaftSheaveLoad_lbl As System.Windows.Forms.Label
    Public WithEvents MachineSheaveJ_lbl As System.Windows.Forms.Label
    Public WithEvents HiSpeedShaftInertia_lbl As System.Windows.Forms.Label
    Public WithEvents ReverseGearEfficiency_lbl As System.Windows.Forms.Label
    Public WithEvents GearRatio2_lbl As System.Windows.Forms.Label
    Public WithEvents GearRatio1_lbl As System.Windows.Forms.Label
    Public WithEvents ForwardGearEfficiency_lbl As System.Windows.Forms.Label
    Public WithEvents SheaveData_fra As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ComboBoxCellType1 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType2 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType3 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType4 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType5 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType6 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType7 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType8 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.Autotransformer_fra = New System.Windows.Forms.GroupBox()
        Me.RequiredKVA_cmb = New System.Windows.Forms.ComboBox()
        Me.RequiredKVA_lbl = New System.Windows.Forms.Label()
        Me.Software_fra = New System.Windows.Forms.GroupBox()
        Me.SoftwareLevel_txt = New System.Windows.Forms.TextBox()
        Me.SoftwareLevel_lbl = New System.Windows.Forms.Label()
        Me.ACMotor_fra = New System.Windows.Forms.GroupBox()
        Me.NominalMotorHP_cmb = New System.Windows.Forms.ComboBox()
        Me.NominalMotorHP_lbl = New System.Windows.Forms.Label()
        Me.MotorDrive_fra = New System.Windows.Forms.GroupBox()
        Me.DriveModel_cmb = New System.Windows.Forms.ComboBox()
        Me.DriveModel_lbl = New System.Windows.Forms.Label()
        Me.SystemData_fra = New System.Windows.Forms.GroupBox()
        Me.CarWeightCalculated_txt = New System.Windows.Forms.TextBox()
        Me.Counterweight_txt = New System.Windows.Forms.TextBox()
        Me.CarWeightCalculated_lbl = New System.Windows.Forms.Label()
        Me.Counterweight_lbl = New System.Windows.Forms.Label()
        Me.DeflectorSecondarySheave_fra = New System.Windows.Forms.GroupBox()
        Me.DeflectorSheave_txt = New System.Windows.Forms.TextBox()
        Me.DeflectorSheaveJ_txt = New System.Windows.Forms.TextBox()
        Me.DeflectorSheave_lbl = New System.Windows.Forms.Label()
        Me.DeflectorSheaveJ_lbl = New System.Windows.Forms.Label()
        Me.RopeModifiers_fra = New System.Windows.Forms.GroupBox()
        Me.RopeGrade_cmb = New System.Windows.Forms.ComboBox()
        Me.len1_txt = New System.Windows.Forms.TextBox()
        Me.len3_txt = New System.Windows.Forms.TextBox()
        Me.len2_txt = New System.Windows.Forms.TextBox()
        Me.RopeGrade_lbl = New System.Windows.Forms.Label()
        Me.len1_lbl = New System.Windows.Forms.Label()
        Me.len3_lbl = New System.Windows.Forms.Label()
        Me.len2_lbl = New System.Windows.Forms.Label()
        Me.OnlyBasement_fra = New System.Windows.Forms.GroupBox()
        Me.IdlerSheaveDiameter_txt = New System.Windows.Forms.TextBox()
        Me.OverheadSheaveInertia_txt = New System.Windows.Forms.TextBox()
        Me.OverheadSheaveInertia_lbl = New System.Windows.Forms.Label()
        Me.IdlerSheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.CompensationData_fra = New System.Windows.Forms.GroupBox()
        Me.CompSheaveWeight_txt = New System.Windows.Forms.TextBox()
        Me.SheaveDiameter_txt = New System.Windows.Forms.TextBox()
        Me.CompensationWeight_txt = New System.Windows.Forms.TextBox()
        Me.CompSheaveJ_txt = New System.Windows.Forms.TextBox()
        Me.CompSheaveWeight_lbl = New System.Windows.Forms.Label()
        Me.SheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.CompensationWeight_lbl = New System.Windows.Forms.Label()
        Me.CompSheaveJ_lbl = New System.Windows.Forms.Label()
        Me.WrapAngleCalc_fra = New System.Windows.Forms.GroupBox()
        Me.RopeDrop_txt = New System.Windows.Forms.TextBox()
        Me.RopeOffset_txt = New System.Windows.Forms.TextBox()
        Me.X1_txt = New System.Windows.Forms.TextBox()
        Me.Y1_txt = New System.Windows.Forms.TextBox()
        Me.WrapAngle_txt = New System.Windows.Forms.TextBox()
        Me.Refer_lbl = New System.Windows.Forms.Label()
        Me.RopeDrop_lbl = New System.Windows.Forms.Label()
        Me.RopeOffset_lbl = New System.Windows.Forms.Label()
        Me.X1_lbl = New System.Windows.Forms.Label()
        Me.Y1_lbl = New System.Windows.Forms.Label()
        Me.WrapAngle_lbl = New System.Windows.Forms.Label()
        Me.RopingAndRelatedData_fra = New System.Windows.Forms.GroupBox()
        Me.GrooveNumber_cmb = New System.Windows.Forms.ComboBox()
        Me.GrooveNumber_lbl = New System.Windows.Forms.Label()
        Me.Only2To1Roping_fra = New System.Windows.Forms.GroupBox()
        Me.CwtSheaveDiameter_txt = New System.Windows.Forms.TextBox()
        Me.CarSheaveDiameter_txt = New System.Windows.Forms.TextBox()
        Me.CwtSheaveJ_txt = New System.Windows.Forms.TextBox()
        Me.CarSheaveJ_txt = New System.Windows.Forms.TextBox()
        Me.CarSheaveJ_lbl = New System.Windows.Forms.Label()
        Me.CwtSheaveJ_lbl = New System.Windows.Forms.Label()
        Me.CwtSheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.CarSheaveDiameter_lbl = New System.Windows.Forms.Label()
        Me.SheaveData_fra = New System.Windows.Forms.GroupBox()
        Me.MaxShaftSheaveLoad_txt = New System.Windows.Forms.TextBox()
        Me.HiSpeedShaftInertia_txt = New System.Windows.Forms.TextBox()
        Me.MachineSheaveJ_txt = New System.Windows.Forms.TextBox()
        Me.ReverseGearEfficiency_txt = New System.Windows.Forms.TextBox()
        Me.ForwardGearEfficiency_txt = New System.Windows.Forms.TextBox()
        Me.GearRatio1_txt = New System.Windows.Forms.TextBox()
        Me.GearRatio2_txt = New System.Windows.Forms.TextBox()
        Me.MaxShaftSheaveLoad_lbl = New System.Windows.Forms.Label()
        Me.MachineSheaveJ_lbl = New System.Windows.Forms.Label()
        Me.HiSpeedShaftInertia_lbl = New System.Windows.Forms.Label()
        Me.ReverseGearEfficiency_lbl = New System.Windows.Forms.Label()
        Me.GearRatio2_lbl = New System.Windows.Forms.Label()
        Me.GearRatio1_lbl = New System.Windows.Forms.Label()
        Me.ForwardGearEfficiency_lbl = New System.Windows.Forms.Label()
        Me.FMM200_fra = New System.Windows.Forms.GroupBox()
        Me.VariableMagneticDiscBrake_cmb = New System.Windows.Forms.ComboBox()
        Me.VariableMagneticDiscBrake_lbl = New System.Windows.Forms.Label()
        Me.HoistMotorType_cmb = New System.Windows.Forms.ComboBox()
        Me.HoistMotorType_lbl = New System.Windows.Forms.Label()
        Me.STMLengthM_lbl = New System.Windows.Forms.Label()
        Me.STMLength_txt = New System.Windows.Forms.TextBox()
        Me.STMLength_lbl = New System.Windows.Forms.Label()
        Me.STMQty_txt = New System.Windows.Forms.TextBox()
        Me.STMQty_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamLengthCwtIn_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamLengthCarIn_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamLengthIn_lbl = New System.Windows.Forms.Label()
        Me.HoistMotorCurrentA_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamSize_cmb = New System.Windows.Forms.ComboBox()
        Me.BlockingBeamLengthCwt_txt = New System.Windows.Forms.TextBox()
        Me.BlockingBeamLength_txt = New System.Windows.Forms.TextBox()
        Me.BlockingBeamLengthCar_txt = New System.Windows.Forms.TextBox()
        Me.BlockingBeamLengthCar_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamSize_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamLengthCwt_lbl = New System.Windows.Forms.Label()
        Me.BlockingBeamLength_lbl = New System.Windows.Forms.Label()
        Me.HoistMotorCurrent_txt = New System.Windows.Forms.TextBox()
        Me.HoistMotorCurrent_lbl = New System.Windows.Forms.Label()
        Me.DriveCalcValues_fra = New System.Windows.Forms.GroupBox()
        Me.FZ2N_lbl = New System.Windows.Forms.Label()
        Me.FZ2_txt = New System.Windows.Forms.TextBox()
        Me.FZ2_lbl = New System.Windows.Forms.Label()
        Me.FZ1N_lbl = New System.Windows.Forms.Label()
        Me.FZ1_txt = New System.Windows.Forms.TextBox()
        Me.FZ1_lbl = New System.Windows.Forms.Label()
        Me.UN_txt = New System.Windows.Forms.TextBox()
        Me.UN_lbl = New System.Windows.Forms.Label()
        Me.TMENm_lbl = New System.Windows.Forms.Label()
        Me.TME_txt = New System.Windows.Forms.TextBox()
        Me.TME_lbl = New System.Windows.Forms.Label()
        Me.PC1AG_KW_lbl = New System.Windows.Forms.Label()
        Me.PC1EG_KW_lbl = New System.Windows.Forms.Label()
        Me.INA_A_lbl = New System.Windows.Forms.Label()
        Me.INE_A_lbl = New System.Windows.Forms.Label()
        Me.PME_KW_lbl = New System.Windows.Forms.Label()
        Me.PC1AG_txt = New System.Windows.Forms.TextBox()
        Me.PC1AG_lbl = New System.Windows.Forms.Label()
        Me.PC1EG_txt = New System.Windows.Forms.TextBox()
        Me.PC1EG_lbl = New System.Windows.Forms.Label()
        Me.INA_txt = New System.Windows.Forms.TextBox()
        Me.INA_lbl = New System.Windows.Forms.Label()
        Me.INE_txt = New System.Windows.Forms.TextBox()
        Me.INE_lbl = New System.Windows.Forms.Label()
        Me.PME_txt = New System.Windows.Forms.TextBox()
        Me.PME_lbl = New System.Windows.Forms.Label()
        Me.MachineHand_fra = New System.Windows.Forms.GroupBox()
        Me.MachineHand_spr = New FarPoint.Win.Spread.FpSpread()
        Me.MachineHand_spr_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Autotransformer_fra.SuspendLayout()
        Me.Software_fra.SuspendLayout()
        Me.ACMotor_fra.SuspendLayout()
        Me.MotorDrive_fra.SuspendLayout()
        Me.SystemData_fra.SuspendLayout()
        Me.DeflectorSecondarySheave_fra.SuspendLayout()
        Me.RopeModifiers_fra.SuspendLayout()
        Me.OnlyBasement_fra.SuspendLayout()
        Me.CompensationData_fra.SuspendLayout()
        Me.WrapAngleCalc_fra.SuspendLayout()
        Me.RopingAndRelatedData_fra.SuspendLayout()
        Me.Only2To1Roping_fra.SuspendLayout()
        Me.SheaveData_fra.SuspendLayout()
        Me.FMM200_fra.SuspendLayout()
        Me.DriveCalcValues_fra.SuspendLayout()
        Me.MachineHand_fra.SuspendLayout()
        CType(Me.MachineHand_spr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MachineHand_spr_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Autotransformer_fra
        '
        Me.Autotransformer_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Autotransformer_fra.Controls.Add(Me.RequiredKVA_cmb)
        Me.Autotransformer_fra.Controls.Add(Me.RequiredKVA_lbl)
        Me.Autotransformer_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Autotransformer_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Autotransformer_fra.Location = New System.Drawing.Point(683, 226)
        Me.Autotransformer_fra.Name = "Autotransformer_fra"
        Me.Autotransformer_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Autotransformer_fra.Size = New System.Drawing.Size(330, 48)
        Me.Autotransformer_fra.TabIndex = 82
        Me.Autotransformer_fra.TabStop = False
        Me.Autotransformer_fra.Tag = "Left"
        Me.Autotransformer_fra.Text = "Autotransformer"
        '
        'RequiredKVA_cmb
        '
        Me.RequiredKVA_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RequiredKVA_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RequiredKVA_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RequiredKVA_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredKVA_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredKVA_cmb.Location = New System.Drawing.Point(198, 16)
        Me.RequiredKVA_cmb.Name = "RequiredKVA_cmb"
        Me.RequiredKVA_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RequiredKVA_cmb.Size = New System.Drawing.Size(121, 21)
        Me.RequiredKVA_cmb.TabIndex = 43
        '
        'RequiredKVA_lbl
        '
        Me.RequiredKVA_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RequiredKVA_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RequiredKVA_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RequiredKVA_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredKVA_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredKVA_lbl.Location = New System.Drawing.Point(6, 22)
        Me.RequiredKVA_lbl.Name = "RequiredKVA_lbl"
        Me.RequiredKVA_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RequiredKVA_lbl.Size = New System.Drawing.Size(151, 18)
        Me.RequiredKVA_lbl.TabIndex = 83
        Me.RequiredKVA_lbl.Text = "Required KVA"
        '
        'Software_fra
        '
        Me.Software_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Software_fra.Controls.Add(Me.SoftwareLevel_txt)
        Me.Software_fra.Controls.Add(Me.SoftwareLevel_lbl)
        Me.Software_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Software_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Software_fra.Location = New System.Drawing.Point(4, 424)
        Me.Software_fra.Name = "Software_fra"
        Me.Software_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Software_fra.Size = New System.Drawing.Size(328, 43)
        Me.Software_fra.TabIndex = 80
        Me.Software_fra.TabStop = False
        Me.Software_fra.Text = "Software"
        '
        'SoftwareLevel_txt
        '
        Me.SoftwareLevel_txt.AcceptsReturn = True
        Me.SoftwareLevel_txt.BackColor = System.Drawing.SystemColors.Window
        Me.SoftwareLevel_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SoftwareLevel_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftwareLevel_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SoftwareLevel_txt.Location = New System.Drawing.Point(198, 14)
        Me.SoftwareLevel_txt.MaxLength = 0
        Me.SoftwareLevel_txt.Name = "SoftwareLevel_txt"
        Me.SoftwareLevel_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SoftwareLevel_txt.Size = New System.Drawing.Size(120, 20)
        Me.SoftwareLevel_txt.TabIndex = 12
        '
        'SoftwareLevel_lbl
        '
        Me.SoftwareLevel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SoftwareLevel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SoftwareLevel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SoftwareLevel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftwareLevel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SoftwareLevel_lbl.Location = New System.Drawing.Point(6, 16)
        Me.SoftwareLevel_lbl.Name = "SoftwareLevel_lbl"
        Me.SoftwareLevel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SoftwareLevel_lbl.Size = New System.Drawing.Size(185, 19)
        Me.SoftwareLevel_lbl.TabIndex = 81
        Me.SoftwareLevel_lbl.Text = "Software Level"
        '
        'ACMotor_fra
        '
        Me.ACMotor_fra.BackColor = System.Drawing.SystemColors.Window
        Me.ACMotor_fra.Controls.Add(Me.NominalMotorHP_cmb)
        Me.ACMotor_fra.Controls.Add(Me.NominalMotorHP_lbl)
        Me.ACMotor_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACMotor_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ACMotor_fra.Location = New System.Drawing.Point(683, 176)
        Me.ACMotor_fra.Name = "ACMotor_fra"
        Me.ACMotor_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ACMotor_fra.Size = New System.Drawing.Size(330, 48)
        Me.ACMotor_fra.TabIndex = 45
        Me.ACMotor_fra.TabStop = False
        Me.ACMotor_fra.Tag = "Left"
        Me.ACMotor_fra.Text = "AC Motor"
        '
        'NominalMotorHP_cmb
        '
        Me.NominalMotorHP_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NominalMotorHP_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NominalMotorHP_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NominalMotorHP_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NominalMotorHP_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NominalMotorHP_cmb.Location = New System.Drawing.Point(198, 20)
        Me.NominalMotorHP_cmb.Name = "NominalMotorHP_cmb"
        Me.NominalMotorHP_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NominalMotorHP_cmb.Size = New System.Drawing.Size(121, 21)
        Me.NominalMotorHP_cmb.TabIndex = 42
        '
        'NominalMotorHP_lbl
        '
        Me.NominalMotorHP_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NominalMotorHP_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NominalMotorHP_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NominalMotorHP_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NominalMotorHP_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NominalMotorHP_lbl.Location = New System.Drawing.Point(6, 22)
        Me.NominalMotorHP_lbl.Name = "NominalMotorHP_lbl"
        Me.NominalMotorHP_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NominalMotorHP_lbl.Size = New System.Drawing.Size(151, 18)
        Me.NominalMotorHP_lbl.TabIndex = 79
        Me.NominalMotorHP_lbl.Text = "Nominal Motor HP"
        '
        'MotorDrive_fra
        '
        Me.MotorDrive_fra.BackColor = System.Drawing.SystemColors.Window
        Me.MotorDrive_fra.Controls.Add(Me.DriveModel_cmb)
        Me.MotorDrive_fra.Controls.Add(Me.DriveModel_lbl)
        Me.MotorDrive_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MotorDrive_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MotorDrive_fra.Location = New System.Drawing.Point(683, 126)
        Me.MotorDrive_fra.Name = "MotorDrive_fra"
        Me.MotorDrive_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MotorDrive_fra.Size = New System.Drawing.Size(330, 48)
        Me.MotorDrive_fra.TabIndex = 44
        Me.MotorDrive_fra.TabStop = False
        Me.MotorDrive_fra.Tag = "Left"
        Me.MotorDrive_fra.Text = "Motor Drive"
        '
        'DriveModel_cmb
        '
        Me.DriveModel_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DriveModel_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveModel_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DriveModel_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveModel_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DriveModel_cmb.Location = New System.Drawing.Point(198, 20)
        Me.DriveModel_cmb.Name = "DriveModel_cmb"
        Me.DriveModel_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveModel_cmb.Size = New System.Drawing.Size(121, 21)
        Me.DriveModel_cmb.TabIndex = 41
        '
        'DriveModel_lbl
        '
        Me.DriveModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DriveModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveModel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DriveModel_lbl.Location = New System.Drawing.Point(6, 22)
        Me.DriveModel_lbl.Name = "DriveModel_lbl"
        Me.DriveModel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveModel_lbl.Size = New System.Drawing.Size(151, 17)
        Me.DriveModel_lbl.TabIndex = 78
        Me.DriveModel_lbl.Text = "Drive Model"
        '
        'SystemData_fra
        '
        Me.SystemData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.SystemData_fra.Controls.Add(Me.CarWeightCalculated_txt)
        Me.SystemData_fra.Controls.Add(Me.Counterweight_txt)
        Me.SystemData_fra.Controls.Add(Me.CarWeightCalculated_lbl)
        Me.SystemData_fra.Controls.Add(Me.Counterweight_lbl)
        Me.SystemData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SystemData_fra.Location = New System.Drawing.Point(4, 0)
        Me.SystemData_fra.Name = "SystemData_fra"
        Me.SystemData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SystemData_fra.Size = New System.Drawing.Size(328, 74)
        Me.SystemData_fra.TabIndex = 35
        Me.SystemData_fra.TabStop = False
        Me.SystemData_fra.Text = "System Data"
        '
        'CarWeightCalculated_txt
        '
        Me.CarWeightCalculated_txt.AcceptsReturn = True
        Me.CarWeightCalculated_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeightCalculated_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarWeightCalculated_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeightCalculated_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeightCalculated_txt.Location = New System.Drawing.Point(199, 44)
        Me.CarWeightCalculated_txt.MaxLength = 5
        Me.CarWeightCalculated_txt.Name = "CarWeightCalculated_txt"
        Me.CarWeightCalculated_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeightCalculated_txt.Size = New System.Drawing.Size(120, 20)
        Me.CarWeightCalculated_txt.TabIndex = 1
        Me.CarWeightCalculated_txt.Tag = "1"
        '
        'Counterweight_txt
        '
        Me.Counterweight_txt.AcceptsReturn = True
        Me.Counterweight_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Counterweight_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Counterweight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Counterweight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Counterweight_txt.Location = New System.Drawing.Point(199, 20)
        Me.Counterweight_txt.MaxLength = 5
        Me.Counterweight_txt.Name = "Counterweight_txt"
        Me.Counterweight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Counterweight_txt.Size = New System.Drawing.Size(120, 20)
        Me.Counterweight_txt.TabIndex = 0
        Me.Counterweight_txt.Tag = "Geared and Gearless"
        '
        'CarWeightCalculated_lbl
        '
        Me.CarWeightCalculated_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeightCalculated_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarWeightCalculated_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarWeightCalculated_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeightCalculated_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeightCalculated_lbl.Location = New System.Drawing.Point(6, 46)
        Me.CarWeightCalculated_lbl.Name = "CarWeightCalculated_lbl"
        Me.CarWeightCalculated_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeightCalculated_lbl.Size = New System.Drawing.Size(180, 18)
        Me.CarWeightCalculated_lbl.TabIndex = 72
        Me.CarWeightCalculated_lbl.Text = "Car Weight Calculated (lbs) "
        '
        'Counterweight_lbl
        '
        Me.Counterweight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Counterweight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Counterweight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Counterweight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Counterweight_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Counterweight_lbl.Location = New System.Drawing.Point(6, 22)
        Me.Counterweight_lbl.Name = "Counterweight_lbl"
        Me.Counterweight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Counterweight_lbl.Size = New System.Drawing.Size(189, 18)
        Me.Counterweight_lbl.TabIndex = 71
        Me.Counterweight_lbl.Text = "% Counterweight (40-50) "
        '
        'DeflectorSecondarySheave_fra
        '
        Me.DeflectorSecondarySheave_fra.BackColor = System.Drawing.SystemColors.Window
        Me.DeflectorSecondarySheave_fra.Controls.Add(Me.DeflectorSheave_txt)
        Me.DeflectorSecondarySheave_fra.Controls.Add(Me.DeflectorSheaveJ_txt)
        Me.DeflectorSecondarySheave_fra.Controls.Add(Me.DeflectorSheave_lbl)
        Me.DeflectorSecondarySheave_fra.Controls.Add(Me.DeflectorSheaveJ_lbl)
        Me.DeflectorSecondarySheave_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeflectorSecondarySheave_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DeflectorSecondarySheave_fra.Location = New System.Drawing.Point(344, 200)
        Me.DeflectorSecondarySheave_fra.Name = "DeflectorSecondarySheave_fra"
        Me.DeflectorSecondarySheave_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeflectorSecondarySheave_fra.Size = New System.Drawing.Size(328, 72)
        Me.DeflectorSecondarySheave_fra.TabIndex = 40
        Me.DeflectorSecondarySheave_fra.TabStop = False
        Me.DeflectorSecondarySheave_fra.Text = "Deflector/Secondary Sheave"
        '
        'DeflectorSheave_txt
        '
        Me.DeflectorSheave_txt.AcceptsReturn = True
        Me.DeflectorSheave_txt.BackColor = System.Drawing.SystemColors.Window
        Me.DeflectorSheave_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeflectorSheave_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeflectorSheave_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeflectorSheave_txt.Location = New System.Drawing.Point(243, 20)
        Me.DeflectorSheave_txt.MaxLength = 0
        Me.DeflectorSheave_txt.Name = "DeflectorSheave_txt"
        Me.DeflectorSheave_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeflectorSheave_txt.Size = New System.Drawing.Size(76, 20)
        Me.DeflectorSheave_txt.TabIndex = 20
        Me.DeflectorSheave_txt.Tag = "Geared And Gearless"
        '
        'DeflectorSheaveJ_txt
        '
        Me.DeflectorSheaveJ_txt.AcceptsReturn = True
        Me.DeflectorSheaveJ_txt.BackColor = System.Drawing.SystemColors.Window
        Me.DeflectorSheaveJ_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DeflectorSheaveJ_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeflectorSheaveJ_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeflectorSheaveJ_txt.Location = New System.Drawing.Point(243, 44)
        Me.DeflectorSheaveJ_txt.MaxLength = 0
        Me.DeflectorSheaveJ_txt.Name = "DeflectorSheaveJ_txt"
        Me.DeflectorSheaveJ_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeflectorSheaveJ_txt.Size = New System.Drawing.Size(76, 20)
        Me.DeflectorSheaveJ_txt.TabIndex = 21
        Me.DeflectorSheaveJ_txt.Tag = "Geared And Gearless"
        '
        'DeflectorSheave_lbl
        '
        Me.DeflectorSheave_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DeflectorSheave_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeflectorSheave_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DeflectorSheave_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeflectorSheave_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeflectorSheave_lbl.Location = New System.Drawing.Point(6, 22)
        Me.DeflectorSheave_lbl.Name = "DeflectorSheave_lbl"
        Me.DeflectorSheave_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeflectorSheave_lbl.Size = New System.Drawing.Size(239, 18)
        Me.DeflectorSheave_lbl.TabIndex = 74
        Me.DeflectorSheave_lbl.Text = "Deflector Sheave Dia Calculated (in)"
        '
        'DeflectorSheaveJ_lbl
        '
        Me.DeflectorSheaveJ_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DeflectorSheaveJ_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeflectorSheaveJ_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DeflectorSheaveJ_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeflectorSheaveJ_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeflectorSheaveJ_lbl.Location = New System.Drawing.Point(6, 46)
        Me.DeflectorSheaveJ_lbl.Name = "DeflectorSheaveJ_lbl"
        Me.DeflectorSheaveJ_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeflectorSheaveJ_lbl.Size = New System.Drawing.Size(234, 18)
        Me.DeflectorSheaveJ_lbl.TabIndex = 69
        Me.DeflectorSheaveJ_lbl.Text = "Deflector Sheave Inertia (lbs-ft-sec^2)"
        '
        'RopeModifiers_fra
        '
        Me.RopeModifiers_fra.BackColor = System.Drawing.SystemColors.Window
        Me.RopeModifiers_fra.Controls.Add(Me.RopeGrade_cmb)
        Me.RopeModifiers_fra.Controls.Add(Me.len1_txt)
        Me.RopeModifiers_fra.Controls.Add(Me.len3_txt)
        Me.RopeModifiers_fra.Controls.Add(Me.len2_txt)
        Me.RopeModifiers_fra.Controls.Add(Me.RopeGrade_lbl)
        Me.RopeModifiers_fra.Controls.Add(Me.len1_lbl)
        Me.RopeModifiers_fra.Controls.Add(Me.len3_lbl)
        Me.RopeModifiers_fra.Controls.Add(Me.len2_lbl)
        Me.RopeModifiers_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeModifiers_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopeModifiers_fra.Location = New System.Drawing.Point(683, 0)
        Me.RopeModifiers_fra.Name = "RopeModifiers_fra"
        Me.RopeModifiers_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeModifiers_fra.Size = New System.Drawing.Size(330, 124)
        Me.RopeModifiers_fra.TabIndex = 43
        Me.RopeModifiers_fra.TabStop = False
        Me.RopeModifiers_fra.Text = "Rope Modifiers"
        '
        'RopeGrade_cmb
        '
        Me.RopeGrade_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGrade_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGrade_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopeGrade_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGrade_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGrade_cmb.Location = New System.Drawing.Point(198, 92)
        Me.RopeGrade_cmb.Name = "RopeGrade_cmb"
        Me.RopeGrade_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGrade_cmb.Size = New System.Drawing.Size(121, 21)
        Me.RopeGrade_cmb.TabIndex = 40
        Me.RopeGrade_cmb.Tag = "Geared And Gearless"
        '
        'len1_txt
        '
        Me.len1_txt.AcceptsReturn = True
        Me.len1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.len1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.len1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len1_txt.Location = New System.Drawing.Point(198, 20)
        Me.len1_txt.MaxLength = 0
        Me.len1_txt.Name = "len1_txt"
        Me.len1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len1_txt.Size = New System.Drawing.Size(121, 20)
        Me.len1_txt.TabIndex = 37
        Me.len1_txt.Tag = "Geared And Gearless"
        '
        'len3_txt
        '
        Me.len3_txt.AcceptsReturn = True
        Me.len3_txt.BackColor = System.Drawing.SystemColors.Window
        Me.len3_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.len3_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len3_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len3_txt.Location = New System.Drawing.Point(198, 68)
        Me.len3_txt.MaxLength = 0
        Me.len3_txt.Name = "len3_txt"
        Me.len3_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len3_txt.Size = New System.Drawing.Size(121, 20)
        Me.len3_txt.TabIndex = 39
        Me.len3_txt.Tag = "Geared And Gearless"
        '
        'len2_txt
        '
        Me.len2_txt.AcceptsReturn = True
        Me.len2_txt.BackColor = System.Drawing.SystemColors.Window
        Me.len2_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.len2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len2_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len2_txt.Location = New System.Drawing.Point(198, 44)
        Me.len2_txt.MaxLength = 0
        Me.len2_txt.Name = "len2_txt"
        Me.len2_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len2_txt.Size = New System.Drawing.Size(121, 20)
        Me.len2_txt.TabIndex = 38
        Me.len2_txt.Tag = "Geared And Gearless"
        '
        'RopeGrade_lbl
        '
        Me.RopeGrade_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeGrade_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeGrade_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeGrade_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeGrade_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeGrade_lbl.Location = New System.Drawing.Point(6, 94)
        Me.RopeGrade_lbl.Name = "RopeGrade_lbl"
        Me.RopeGrade_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeGrade_lbl.Size = New System.Drawing.Size(148, 18)
        Me.RopeGrade_lbl.TabIndex = 67
        Me.RopeGrade_lbl.Text = "Rope Grade"
        '
        'len1_lbl
        '
        Me.len1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.len1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.len1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.len1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len1_lbl.Location = New System.Drawing.Point(6, 22)
        Me.len1_lbl.Name = "len1_lbl"
        Me.len1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len1_lbl.Size = New System.Drawing.Size(133, 18)
        Me.len1_lbl.TabIndex = 66
        Me.len1_lbl.Text = "len 1 (hoist adder)"
        '
        'len3_lbl
        '
        Me.len3_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.len3_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.len3_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.len3_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len3_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len3_lbl.Location = New System.Drawing.Point(6, 70)
        Me.len3_lbl.Name = "len3_lbl"
        Me.len3_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len3_lbl.Size = New System.Drawing.Size(148, 18)
        Me.len3_lbl.TabIndex = 65
        Me.len3_lbl.Text = "len 3 (T.C. adder)"
        '
        'len2_lbl
        '
        Me.len2_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.len2_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.len2_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.len2_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.len2_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.len2_lbl.Location = New System.Drawing.Point(6, 46)
        Me.len2_lbl.Name = "len2_lbl"
        Me.len2_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.len2_lbl.Size = New System.Drawing.Size(148, 18)
        Me.len2_lbl.TabIndex = 64
        Me.len2_lbl.Text = "len 2 (comp adder)"
        '
        'OnlyBasement_fra
        '
        Me.OnlyBasement_fra.BackColor = System.Drawing.SystemColors.Window
        Me.OnlyBasement_fra.Controls.Add(Me.IdlerSheaveDiameter_txt)
        Me.OnlyBasement_fra.Controls.Add(Me.OverheadSheaveInertia_txt)
        Me.OnlyBasement_fra.Controls.Add(Me.OverheadSheaveInertia_lbl)
        Me.OnlyBasement_fra.Controls.Add(Me.IdlerSheaveDiameter_lbl)
        Me.OnlyBasement_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OnlyBasement_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OnlyBasement_fra.Location = New System.Drawing.Point(344, 272)
        Me.OnlyBasement_fra.Name = "OnlyBasement_fra"
        Me.OnlyBasement_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OnlyBasement_fra.Size = New System.Drawing.Size(328, 72)
        Me.OnlyBasement_fra.TabIndex = 41
        Me.OnlyBasement_fra.TabStop = False
        Me.OnlyBasement_fra.Text = "Basement/Semi-Basement"
        '
        'IdlerSheaveDiameter_txt
        '
        Me.IdlerSheaveDiameter_txt.AcceptsReturn = True
        Me.IdlerSheaveDiameter_txt.BackColor = System.Drawing.SystemColors.Window
        Me.IdlerSheaveDiameter_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.IdlerSheaveDiameter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdlerSheaveDiameter_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IdlerSheaveDiameter_txt.Location = New System.Drawing.Point(243, 20)
        Me.IdlerSheaveDiameter_txt.MaxLength = 0
        Me.IdlerSheaveDiameter_txt.Name = "IdlerSheaveDiameter_txt"
        Me.IdlerSheaveDiameter_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.IdlerSheaveDiameter_txt.Size = New System.Drawing.Size(76, 20)
        Me.IdlerSheaveDiameter_txt.TabIndex = 22
        Me.IdlerSheaveDiameter_txt.Tag = "Geared And Gearless"
        '
        'OverheadSheaveInertia_txt
        '
        Me.OverheadSheaveInertia_txt.AcceptsReturn = True
        Me.OverheadSheaveInertia_txt.BackColor = System.Drawing.SystemColors.Window
        Me.OverheadSheaveInertia_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OverheadSheaveInertia_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverheadSheaveInertia_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OverheadSheaveInertia_txt.Location = New System.Drawing.Point(243, 44)
        Me.OverheadSheaveInertia_txt.MaxLength = 0
        Me.OverheadSheaveInertia_txt.Name = "OverheadSheaveInertia_txt"
        Me.OverheadSheaveInertia_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OverheadSheaveInertia_txt.Size = New System.Drawing.Size(76, 20)
        Me.OverheadSheaveInertia_txt.TabIndex = 23
        Me.OverheadSheaveInertia_txt.Tag = "Geared And Gearless"
        '
        'OverheadSheaveInertia_lbl
        '
        Me.OverheadSheaveInertia_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.OverheadSheaveInertia_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.OverheadSheaveInertia_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OverheadSheaveInertia_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverheadSheaveInertia_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OverheadSheaveInertia_lbl.Location = New System.Drawing.Point(6, 46)
        Me.OverheadSheaveInertia_lbl.Name = "OverheadSheaveInertia_lbl"
        Me.OverheadSheaveInertia_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OverheadSheaveInertia_lbl.Size = New System.Drawing.Size(194, 18)
        Me.OverheadSheaveInertia_lbl.TabIndex = 60
        Me.OverheadSheaveInertia_lbl.Text = "Idler Sheave Inertia (lbs-ft-sec^2)"
        '
        'IdlerSheaveDiameter_lbl
        '
        Me.IdlerSheaveDiameter_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.IdlerSheaveDiameter_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.IdlerSheaveDiameter_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.IdlerSheaveDiameter_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdlerSheaveDiameter_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IdlerSheaveDiameter_lbl.Location = New System.Drawing.Point(6, 22)
        Me.IdlerSheaveDiameter_lbl.Name = "IdlerSheaveDiameter_lbl"
        Me.IdlerSheaveDiameter_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.IdlerSheaveDiameter_lbl.Size = New System.Drawing.Size(214, 18)
        Me.IdlerSheaveDiameter_lbl.TabIndex = 59
        Me.IdlerSheaveDiameter_lbl.Text = "Idler Sheave Diameter Calculated (in)"
        '
        'CompensationData_fra
        '
        Me.CompensationData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationData_fra.Controls.Add(Me.CompSheaveWeight_txt)
        Me.CompensationData_fra.Controls.Add(Me.SheaveDiameter_txt)
        Me.CompensationData_fra.Controls.Add(Me.CompensationWeight_txt)
        Me.CompensationData_fra.Controls.Add(Me.CompSheaveJ_txt)
        Me.CompensationData_fra.Controls.Add(Me.CompSheaveWeight_lbl)
        Me.CompensationData_fra.Controls.Add(Me.SheaveDiameter_lbl)
        Me.CompensationData_fra.Controls.Add(Me.CompensationWeight_lbl)
        Me.CompensationData_fra.Controls.Add(Me.CompSheaveJ_lbl)
        Me.CompensationData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CompensationData_fra.Location = New System.Drawing.Point(4, 298)
        Me.CompensationData_fra.Name = "CompensationData_fra"
        Me.CompensationData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationData_fra.Size = New System.Drawing.Size(328, 120)
        Me.CompensationData_fra.TabIndex = 38
        Me.CompensationData_fra.TabStop = False
        Me.CompensationData_fra.Text = "Compensation Data"
        '
        'CompSheaveWeight_txt
        '
        Me.CompSheaveWeight_txt.AcceptsReturn = True
        Me.CompSheaveWeight_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveWeight_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CompSheaveWeight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveWeight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveWeight_txt.Location = New System.Drawing.Point(199, 94)
        Me.CompSheaveWeight_txt.MaxLength = 0
        Me.CompSheaveWeight_txt.Name = "CompSheaveWeight_txt"
        Me.CompSheaveWeight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveWeight_txt.Size = New System.Drawing.Size(120, 20)
        Me.CompSheaveWeight_txt.TabIndex = 11
        Me.CompSheaveWeight_txt.Tag = "Geared And Gearless"
        '
        'SheaveDiameter_txt
        '
        Me.SheaveDiameter_txt.AcceptsReturn = True
        Me.SheaveDiameter_txt.BackColor = System.Drawing.SystemColors.Window
        Me.SheaveDiameter_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SheaveDiameter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SheaveDiameter_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SheaveDiameter_txt.Location = New System.Drawing.Point(199, 20)
        Me.SheaveDiameter_txt.MaxLength = 0
        Me.SheaveDiameter_txt.Name = "SheaveDiameter_txt"
        Me.SheaveDiameter_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SheaveDiameter_txt.Size = New System.Drawing.Size(120, 20)
        Me.SheaveDiameter_txt.TabIndex = 8
        Me.SheaveDiameter_txt.Text = " "
        '
        'CompensationWeight_txt
        '
        Me.CompensationWeight_txt.AcceptsReturn = True
        Me.CompensationWeight_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationWeight_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CompensationWeight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationWeight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationWeight_txt.Location = New System.Drawing.Point(199, 44)
        Me.CompensationWeight_txt.MaxLength = 0
        Me.CompensationWeight_txt.Name = "CompensationWeight_txt"
        Me.CompensationWeight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationWeight_txt.Size = New System.Drawing.Size(120, 20)
        Me.CompensationWeight_txt.TabIndex = 9
        Me.CompensationWeight_txt.Tag = "Geared And Gearless"
        '
        'CompSheaveJ_txt
        '
        Me.CompSheaveJ_txt.AcceptsReturn = True
        Me.CompSheaveJ_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveJ_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CompSheaveJ_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveJ_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveJ_txt.Location = New System.Drawing.Point(199, 70)
        Me.CompSheaveJ_txt.MaxLength = 0
        Me.CompSheaveJ_txt.Name = "CompSheaveJ_txt"
        Me.CompSheaveJ_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveJ_txt.Size = New System.Drawing.Size(120, 20)
        Me.CompSheaveJ_txt.TabIndex = 10
        Me.CompSheaveJ_txt.Tag = "Geared And Gearless"
        '
        'CompSheaveWeight_lbl
        '
        Me.CompSheaveWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompSheaveWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompSheaveWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveWeight_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveWeight_lbl.Location = New System.Drawing.Point(6, 94)
        Me.CompSheaveWeight_lbl.Name = "CompSheaveWeight_lbl"
        Me.CompSheaveWeight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveWeight_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompSheaveWeight_lbl.TabIndex = 77
        Me.CompSheaveWeight_lbl.Text = "Comp Sheave Weight (lbs)"
        '
        'SheaveDiameter_lbl
        '
        Me.SheaveDiameter_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SheaveDiameter_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SheaveDiameter_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SheaveDiameter_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SheaveDiameter_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SheaveDiameter_lbl.Location = New System.Drawing.Point(6, 22)
        Me.SheaveDiameter_lbl.Name = "SheaveDiameter_lbl"
        Me.SheaveDiameter_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SheaveDiameter_lbl.Size = New System.Drawing.Size(188, 17)
        Me.SheaveDiameter_lbl.TabIndex = 76
        Me.SheaveDiameter_lbl.Text = "Comp Sheave Dia calculated (in)"
        '
        'CompensationWeight_lbl
        '
        Me.CompensationWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompensationWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompensationWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompensationWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompensationWeight_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompensationWeight_lbl.Location = New System.Drawing.Point(6, 46)
        Me.CompensationWeight_lbl.Name = "CompensationWeight_lbl"
        Me.CompensationWeight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompensationWeight_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompensationWeight_lbl.TabIndex = 75
        Me.CompensationWeight_lbl.Text = "Total Comp Unit Weight (lbs)"
        '
        'CompSheaveJ_lbl
        '
        Me.CompSheaveJ_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CompSheaveJ_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CompSheaveJ_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CompSheaveJ_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompSheaveJ_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CompSheaveJ_lbl.Location = New System.Drawing.Point(6, 70)
        Me.CompSheaveJ_lbl.Name = "CompSheaveJ_lbl"
        Me.CompSheaveJ_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CompSheaveJ_lbl.Size = New System.Drawing.Size(168, 18)
        Me.CompSheaveJ_lbl.TabIndex = 68
        Me.CompSheaveJ_lbl.Text = "Comp Sheave J (lbs-ft-sec^2)"
        '
        'WrapAngleCalc_fra
        '
        Me.WrapAngleCalc_fra.BackColor = System.Drawing.SystemColors.Window
        Me.WrapAngleCalc_fra.Controls.Add(Me.RopeDrop_txt)
        Me.WrapAngleCalc_fra.Controls.Add(Me.RopeOffset_txt)
        Me.WrapAngleCalc_fra.Controls.Add(Me.X1_txt)
        Me.WrapAngleCalc_fra.Controls.Add(Me.Y1_txt)
        Me.WrapAngleCalc_fra.Controls.Add(Me.WrapAngle_txt)
        Me.WrapAngleCalc_fra.Controls.Add(Me.Refer_lbl)
        Me.WrapAngleCalc_fra.Controls.Add(Me.RopeDrop_lbl)
        Me.WrapAngleCalc_fra.Controls.Add(Me.RopeOffset_lbl)
        Me.WrapAngleCalc_fra.Controls.Add(Me.X1_lbl)
        Me.WrapAngleCalc_fra.Controls.Add(Me.Y1_lbl)
        Me.WrapAngleCalc_fra.Controls.Add(Me.WrapAngle_lbl)
        Me.WrapAngleCalc_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrapAngleCalc_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WrapAngleCalc_fra.Location = New System.Drawing.Point(4, 78)
        Me.WrapAngleCalc_fra.Name = "WrapAngleCalc_fra"
        Me.WrapAngleCalc_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WrapAngleCalc_fra.Size = New System.Drawing.Size(328, 168)
        Me.WrapAngleCalc_fra.TabIndex = 36
        Me.WrapAngleCalc_fra.TabStop = False
        Me.WrapAngleCalc_fra.Text = "Wrap Angle Calculations"
        '
        'RopeDrop_txt
        '
        Me.RopeDrop_txt.AcceptsReturn = True
        Me.RopeDrop_txt.BackColor = System.Drawing.SystemColors.Window
        Me.RopeDrop_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RopeDrop_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeDrop_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeDrop_txt.Location = New System.Drawing.Point(199, 20)
        Me.RopeDrop_txt.MaxLength = 5
        Me.RopeDrop_txt.Name = "RopeDrop_txt"
        Me.RopeDrop_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeDrop_txt.Size = New System.Drawing.Size(120, 20)
        Me.RopeDrop_txt.TabIndex = 2
        Me.RopeDrop_txt.Tag = "Geared"
        '
        'RopeOffset_txt
        '
        Me.RopeOffset_txt.AcceptsReturn = True
        Me.RopeOffset_txt.BackColor = System.Drawing.SystemColors.Window
        Me.RopeOffset_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RopeOffset_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeOffset_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeOffset_txt.Location = New System.Drawing.Point(199, 116)
        Me.RopeOffset_txt.MaxLength = 0
        Me.RopeOffset_txt.Name = "RopeOffset_txt"
        Me.RopeOffset_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeOffset_txt.Size = New System.Drawing.Size(120, 20)
        Me.RopeOffset_txt.TabIndex = 6
        Me.RopeOffset_txt.Tag = "Geared And Gearless"
        '
        'X1_txt
        '
        Me.X1_txt.AcceptsReturn = True
        Me.X1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.X1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.X1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.X1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.X1_txt.Location = New System.Drawing.Point(199, 68)
        Me.X1_txt.MaxLength = 0
        Me.X1_txt.Name = "X1_txt"
        Me.X1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.X1_txt.Size = New System.Drawing.Size(120, 20)
        Me.X1_txt.TabIndex = 4
        Me.X1_txt.Tag = "Geared And Gearless"
        '
        'Y1_txt
        '
        Me.Y1_txt.AcceptsReturn = True
        Me.Y1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Y1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Y1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Y1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Y1_txt.Location = New System.Drawing.Point(199, 92)
        Me.Y1_txt.MaxLength = 0
        Me.Y1_txt.Name = "Y1_txt"
        Me.Y1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Y1_txt.Size = New System.Drawing.Size(120, 20)
        Me.Y1_txt.TabIndex = 5
        Me.Y1_txt.Tag = "Geared And Gearless"
        '
        'WrapAngle_txt
        '
        Me.WrapAngle_txt.AcceptsReturn = True
        Me.WrapAngle_txt.BackColor = System.Drawing.SystemColors.Window
        Me.WrapAngle_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WrapAngle_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrapAngle_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WrapAngle_txt.Location = New System.Drawing.Point(199, 44)
        Me.WrapAngle_txt.MaxLength = 0
        Me.WrapAngle_txt.Name = "WrapAngle_txt"
        Me.WrapAngle_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WrapAngle_txt.Size = New System.Drawing.Size(120, 20)
        Me.WrapAngle_txt.TabIndex = 3
        Me.WrapAngle_txt.Tag = "Geared And Gearless"
        '
        'Refer_lbl
        '
        Me.Refer_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Refer_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Refer_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Refer_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refer_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Refer_lbl.Location = New System.Drawing.Point(46, 142)
        Me.Refer_lbl.Name = "Refer_lbl"
        Me.Refer_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Refer_lbl.Size = New System.Drawing.Size(248, 18)
        Me.Refer_lbl.TabIndex = 73
        Me.Refer_lbl.Text = "* Refers to the Centerline to Centerline"
        '
        'RopeDrop_lbl
        '
        Me.RopeDrop_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeDrop_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeDrop_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeDrop_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeDrop_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeDrop_lbl.Location = New System.Drawing.Point(6, 22)
        Me.RopeDrop_lbl.Name = "RopeDrop_lbl"
        Me.RopeDrop_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeDrop_lbl.Size = New System.Drawing.Size(148, 18)
        Me.RopeDrop_lbl.TabIndex = 70
        Me.RopeDrop_lbl.Text = "Rope Drop (in)"
        '
        'RopeOffset_lbl
        '
        Me.RopeOffset_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopeOffset_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopeOffset_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopeOffset_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopeOffset_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopeOffset_lbl.Location = New System.Drawing.Point(6, 118)
        Me.RopeOffset_lbl.Name = "RopeOffset_lbl"
        Me.RopeOffset_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopeOffset_lbl.Size = New System.Drawing.Size(148, 18)
        Me.RopeOffset_lbl.TabIndex = 63
        Me.RopeOffset_lbl.Text = "Rope Offset (in)"
        '
        'X1_lbl
        '
        Me.X1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.X1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.X1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.X1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.X1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.X1_lbl.Location = New System.Drawing.Point(6, 70)
        Me.X1_lbl.Name = "X1_lbl"
        Me.X1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.X1_lbl.Size = New System.Drawing.Size(148, 18)
        Me.X1_lbl.TabIndex = 57
        Me.X1_lbl.Text = "Horizontal distance* (in) "
        '
        'Y1_lbl
        '
        Me.Y1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Y1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Y1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Y1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Y1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Y1_lbl.Location = New System.Drawing.Point(6, 94)
        Me.Y1_lbl.Name = "Y1_lbl"
        Me.Y1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Y1_lbl.Size = New System.Drawing.Size(148, 18)
        Me.Y1_lbl.TabIndex = 56
        Me.Y1_lbl.Text = "Vertical distance* (in)"
        '
        'WrapAngle_lbl
        '
        Me.WrapAngle_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.WrapAngle_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.WrapAngle_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.WrapAngle_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrapAngle_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WrapAngle_lbl.Location = New System.Drawing.Point(6, 46)
        Me.WrapAngle_lbl.Name = "WrapAngle_lbl"
        Me.WrapAngle_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WrapAngle_lbl.Size = New System.Drawing.Size(148, 18)
        Me.WrapAngle_lbl.TabIndex = 55
        Me.WrapAngle_lbl.Text = "Wrap Angle (deg)"
        '
        'RopingAndRelatedData_fra
        '
        Me.RopingAndRelatedData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.RopingAndRelatedData_fra.Controls.Add(Me.GrooveNumber_cmb)
        Me.RopingAndRelatedData_fra.Controls.Add(Me.GrooveNumber_lbl)
        Me.RopingAndRelatedData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingAndRelatedData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RopingAndRelatedData_fra.Location = New System.Drawing.Point(4, 248)
        Me.RopingAndRelatedData_fra.Name = "RopingAndRelatedData_fra"
        Me.RopingAndRelatedData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingAndRelatedData_fra.Size = New System.Drawing.Size(328, 48)
        Me.RopingAndRelatedData_fra.TabIndex = 37
        Me.RopingAndRelatedData_fra.TabStop = False
        Me.RopingAndRelatedData_fra.Text = "Roping And Related Data"
        '
        'GrooveNumber_cmb
        '
        Me.GrooveNumber_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.GrooveNumber_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrooveNumber_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GrooveNumber_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrooveNumber_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GrooveNumber_cmb.Location = New System.Drawing.Point(199, 20)
        Me.GrooveNumber_cmb.Name = "GrooveNumber_cmb"
        Me.GrooveNumber_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrooveNumber_cmb.Size = New System.Drawing.Size(120, 21)
        Me.GrooveNumber_cmb.TabIndex = 7
        Me.GrooveNumber_cmb.Tag = "Geared And Gearless"
        '
        'GrooveNumber_lbl
        '
        Me.GrooveNumber_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.GrooveNumber_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.GrooveNumber_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GrooveNumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrooveNumber_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GrooveNumber_lbl.Location = New System.Drawing.Point(6, 22)
        Me.GrooveNumber_lbl.Name = "GrooveNumber_lbl"
        Me.GrooveNumber_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GrooveNumber_lbl.Size = New System.Drawing.Size(133, 19)
        Me.GrooveNumber_lbl.TabIndex = 54
        Me.GrooveNumber_lbl.Text = "Groove Number"
        '
        'Only2To1Roping_fra
        '
        Me.Only2To1Roping_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Only2To1Roping_fra.Controls.Add(Me.CwtSheaveDiameter_txt)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveDiameter_txt)
        Me.Only2To1Roping_fra.Controls.Add(Me.CwtSheaveJ_txt)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveJ_txt)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveJ_lbl)
        Me.Only2To1Roping_fra.Controls.Add(Me.CwtSheaveJ_lbl)
        Me.Only2To1Roping_fra.Controls.Add(Me.CwtSheaveDiameter_lbl)
        Me.Only2To1Roping_fra.Controls.Add(Me.CarSheaveDiameter_lbl)
        Me.Only2To1Roping_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Only2To1Roping_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Only2To1Roping_fra.Location = New System.Drawing.Point(344, 346)
        Me.Only2To1Roping_fra.Name = "Only2To1Roping_fra"
        Me.Only2To1Roping_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Only2To1Roping_fra.Size = New System.Drawing.Size(328, 118)
        Me.Only2To1Roping_fra.TabIndex = 42
        Me.Only2To1Roping_fra.TabStop = False
        Me.Only2To1Roping_fra.Text = "2 : 1 Roping/Underslung"
        '
        'CwtSheaveDiameter_txt
        '
        Me.CwtSheaveDiameter_txt.AcceptsReturn = True
        Me.CwtSheaveDiameter_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveDiameter_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CwtSheaveDiameter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveDiameter_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtSheaveDiameter_txt.Location = New System.Drawing.Point(243, 68)
        Me.CwtSheaveDiameter_txt.MaxLength = 0
        Me.CwtSheaveDiameter_txt.Name = "CwtSheaveDiameter_txt"
        Me.CwtSheaveDiameter_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveDiameter_txt.Size = New System.Drawing.Size(76, 20)
        Me.CwtSheaveDiameter_txt.TabIndex = 26
        Me.CwtSheaveDiameter_txt.Tag = "Geared And Gearless"
        '
        'CarSheaveDiameter_txt
        '
        Me.CarSheaveDiameter_txt.AcceptsReturn = True
        Me.CarSheaveDiameter_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveDiameter_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarSheaveDiameter_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveDiameter_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveDiameter_txt.Location = New System.Drawing.Point(243, 20)
        Me.CarSheaveDiameter_txt.MaxLength = 0
        Me.CarSheaveDiameter_txt.Name = "CarSheaveDiameter_txt"
        Me.CarSheaveDiameter_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveDiameter_txt.Size = New System.Drawing.Size(76, 20)
        Me.CarSheaveDiameter_txt.TabIndex = 24
        Me.CarSheaveDiameter_txt.Tag = "Geared And Gearless"
        '
        'CwtSheaveJ_txt
        '
        Me.CwtSheaveJ_txt.AcceptsReturn = True
        Me.CwtSheaveJ_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveJ_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CwtSheaveJ_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveJ_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtSheaveJ_txt.Location = New System.Drawing.Point(243, 92)
        Me.CwtSheaveJ_txt.MaxLength = 0
        Me.CwtSheaveJ_txt.Name = "CwtSheaveJ_txt"
        Me.CwtSheaveJ_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveJ_txt.Size = New System.Drawing.Size(76, 20)
        Me.CwtSheaveJ_txt.TabIndex = 27
        Me.CwtSheaveJ_txt.Tag = "Geared And Gearless"
        '
        'CarSheaveJ_txt
        '
        Me.CarSheaveJ_txt.AcceptsReturn = True
        Me.CarSheaveJ_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveJ_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarSheaveJ_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveJ_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveJ_txt.Location = New System.Drawing.Point(243, 44)
        Me.CarSheaveJ_txt.MaxLength = 0
        Me.CarSheaveJ_txt.Name = "CarSheaveJ_txt"
        Me.CarSheaveJ_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveJ_txt.Size = New System.Drawing.Size(76, 20)
        Me.CarSheaveJ_txt.TabIndex = 25
        Me.CarSheaveJ_txt.Tag = "Geared And Gearless"
        '
        'CarSheaveJ_lbl
        '
        Me.CarSheaveJ_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveJ_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveJ_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarSheaveJ_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveJ_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveJ_lbl.Location = New System.Drawing.Point(6, 46)
        Me.CarSheaveJ_lbl.Name = "CarSheaveJ_lbl"
        Me.CarSheaveJ_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveJ_lbl.Size = New System.Drawing.Size(190, 18)
        Me.CarSheaveJ_lbl.TabIndex = 62
        Me.CarSheaveJ_lbl.Text = "Car Top Sheave J (lbs-ft-sec^2)"
        '
        'CwtSheaveJ_lbl
        '
        Me.CwtSheaveJ_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveJ_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtSheaveJ_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CwtSheaveJ_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveJ_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtSheaveJ_lbl.Location = New System.Drawing.Point(6, 94)
        Me.CwtSheaveJ_lbl.Name = "CwtSheaveJ_lbl"
        Me.CwtSheaveJ_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveJ_lbl.Size = New System.Drawing.Size(190, 18)
        Me.CwtSheaveJ_lbl.TabIndex = 61
        Me.CwtSheaveJ_lbl.Text = "Cwt Top Sheave J (lbs-ft-sec^2)"
        '
        'CwtSheaveDiameter_lbl
        '
        Me.CwtSheaveDiameter_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveDiameter_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtSheaveDiameter_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CwtSheaveDiameter_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveDiameter_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtSheaveDiameter_lbl.Location = New System.Drawing.Point(6, 70)
        Me.CwtSheaveDiameter_lbl.Name = "CwtSheaveDiameter_lbl"
        Me.CwtSheaveDiameter_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveDiameter_lbl.Size = New System.Drawing.Size(234, 18)
        Me.CwtSheaveDiameter_lbl.TabIndex = 58
        Me.CwtSheaveDiameter_lbl.Text = "Cwt Top Sheave Diameter Calculated (in)"
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
        Me.CarSheaveDiameter_lbl.Size = New System.Drawing.Size(233, 18)
        Me.CarSheaveDiameter_lbl.TabIndex = 49
        Me.CarSheaveDiameter_lbl.Text = "Car Top Sheave Diameter Calculated (in)"
        '
        'SheaveData_fra
        '
        Me.SheaveData_fra.BackColor = System.Drawing.SystemColors.Window
        Me.SheaveData_fra.Controls.Add(Me.MaxShaftSheaveLoad_txt)
        Me.SheaveData_fra.Controls.Add(Me.HiSpeedShaftInertia_txt)
        Me.SheaveData_fra.Controls.Add(Me.MachineSheaveJ_txt)
        Me.SheaveData_fra.Controls.Add(Me.ReverseGearEfficiency_txt)
        Me.SheaveData_fra.Controls.Add(Me.ForwardGearEfficiency_txt)
        Me.SheaveData_fra.Controls.Add(Me.GearRatio1_txt)
        Me.SheaveData_fra.Controls.Add(Me.GearRatio2_txt)
        Me.SheaveData_fra.Controls.Add(Me.MaxShaftSheaveLoad_lbl)
        Me.SheaveData_fra.Controls.Add(Me.MachineSheaveJ_lbl)
        Me.SheaveData_fra.Controls.Add(Me.HiSpeedShaftInertia_lbl)
        Me.SheaveData_fra.Controls.Add(Me.ReverseGearEfficiency_lbl)
        Me.SheaveData_fra.Controls.Add(Me.GearRatio2_lbl)
        Me.SheaveData_fra.Controls.Add(Me.GearRatio1_lbl)
        Me.SheaveData_fra.Controls.Add(Me.ForwardGearEfficiency_lbl)
        Me.SheaveData_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SheaveData_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SheaveData_fra.Location = New System.Drawing.Point(344, 0)
        Me.SheaveData_fra.Name = "SheaveData_fra"
        Me.SheaveData_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SheaveData_fra.Size = New System.Drawing.Size(328, 196)
        Me.SheaveData_fra.TabIndex = 39
        Me.SheaveData_fra.TabStop = False
        Me.SheaveData_fra.Text = "Machine"
        '
        'MaxShaftSheaveLoad_txt
        '
        Me.MaxShaftSheaveLoad_txt.AcceptsReturn = True
        Me.MaxShaftSheaveLoad_txt.BackColor = System.Drawing.SystemColors.Window
        Me.MaxShaftSheaveLoad_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MaxShaftSheaveLoad_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxShaftSheaveLoad_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxShaftSheaveLoad_txt.Location = New System.Drawing.Point(230, 164)
        Me.MaxShaftSheaveLoad_txt.MaxLength = 0
        Me.MaxShaftSheaveLoad_txt.Name = "MaxShaftSheaveLoad_txt"
        Me.MaxShaftSheaveLoad_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaxShaftSheaveLoad_txt.Size = New System.Drawing.Size(88, 20)
        Me.MaxShaftSheaveLoad_txt.TabIndex = 19
        Me.MaxShaftSheaveLoad_txt.Tag = "Geared And Gearless"
        '
        'HiSpeedShaftInertia_txt
        '
        Me.HiSpeedShaftInertia_txt.AcceptsReturn = True
        Me.HiSpeedShaftInertia_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HiSpeedShaftInertia_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HiSpeedShaftInertia_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HiSpeedShaftInertia_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HiSpeedShaftInertia_txt.Location = New System.Drawing.Point(230, 140)
        Me.HiSpeedShaftInertia_txt.MaxLength = 0
        Me.HiSpeedShaftInertia_txt.Name = "HiSpeedShaftInertia_txt"
        Me.HiSpeedShaftInertia_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HiSpeedShaftInertia_txt.Size = New System.Drawing.Size(88, 20)
        Me.HiSpeedShaftInertia_txt.TabIndex = 18
        Me.HiSpeedShaftInertia_txt.Tag = "Geared"
        '
        'MachineSheaveJ_txt
        '
        Me.MachineSheaveJ_txt.AcceptsReturn = True
        Me.MachineSheaveJ_txt.BackColor = System.Drawing.SystemColors.Window
        Me.MachineSheaveJ_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MachineSheaveJ_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineSheaveJ_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineSheaveJ_txt.Location = New System.Drawing.Point(230, 20)
        Me.MachineSheaveJ_txt.MaxLength = 0
        Me.MachineSheaveJ_txt.Name = "MachineSheaveJ_txt"
        Me.MachineSheaveJ_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineSheaveJ_txt.Size = New System.Drawing.Size(88, 20)
        Me.MachineSheaveJ_txt.TabIndex = 13
        Me.MachineSheaveJ_txt.Tag = "Geared And Gearless"
        '
        'ReverseGearEfficiency_txt
        '
        Me.ReverseGearEfficiency_txt.AcceptsReturn = True
        Me.ReverseGearEfficiency_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ReverseGearEfficiency_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ReverseGearEfficiency_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReverseGearEfficiency_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReverseGearEfficiency_txt.Location = New System.Drawing.Point(230, 116)
        Me.ReverseGearEfficiency_txt.MaxLength = 0
        Me.ReverseGearEfficiency_txt.Name = "ReverseGearEfficiency_txt"
        Me.ReverseGearEfficiency_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReverseGearEfficiency_txt.Size = New System.Drawing.Size(88, 20)
        Me.ReverseGearEfficiency_txt.TabIndex = 17
        Me.ReverseGearEfficiency_txt.Tag = "Geared"
        '
        'ForwardGearEfficiency_txt
        '
        Me.ForwardGearEfficiency_txt.AcceptsReturn = True
        Me.ForwardGearEfficiency_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ForwardGearEfficiency_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ForwardGearEfficiency_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForwardGearEfficiency_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ForwardGearEfficiency_txt.Location = New System.Drawing.Point(230, 92)
        Me.ForwardGearEfficiency_txt.MaxLength = 0
        Me.ForwardGearEfficiency_txt.Name = "ForwardGearEfficiency_txt"
        Me.ForwardGearEfficiency_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ForwardGearEfficiency_txt.Size = New System.Drawing.Size(88, 20)
        Me.ForwardGearEfficiency_txt.TabIndex = 16
        Me.ForwardGearEfficiency_txt.Tag = "Geared"
        '
        'GearRatio1_txt
        '
        Me.GearRatio1_txt.AcceptsReturn = True
        Me.GearRatio1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.GearRatio1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GearRatio1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GearRatio1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GearRatio1_txt.Location = New System.Drawing.Point(230, 68)
        Me.GearRatio1_txt.MaxLength = 0
        Me.GearRatio1_txt.Name = "GearRatio1_txt"
        Me.GearRatio1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GearRatio1_txt.Size = New System.Drawing.Size(88, 20)
        Me.GearRatio1_txt.TabIndex = 15
        Me.GearRatio1_txt.Tag = "Geared"
        '
        'GearRatio2_txt
        '
        Me.GearRatio2_txt.AcceptsReturn = True
        Me.GearRatio2_txt.BackColor = System.Drawing.SystemColors.Window
        Me.GearRatio2_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GearRatio2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GearRatio2_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GearRatio2_txt.Location = New System.Drawing.Point(230, 44)
        Me.GearRatio2_txt.MaxLength = 0
        Me.GearRatio2_txt.Name = "GearRatio2_txt"
        Me.GearRatio2_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GearRatio2_txt.Size = New System.Drawing.Size(88, 20)
        Me.GearRatio2_txt.TabIndex = 14
        Me.GearRatio2_txt.Tag = "Geared"
        '
        'MaxShaftSheaveLoad_lbl
        '
        Me.MaxShaftSheaveLoad_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MaxShaftSheaveLoad_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MaxShaftSheaveLoad_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MaxShaftSheaveLoad_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxShaftSheaveLoad_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxShaftSheaveLoad_lbl.Location = New System.Drawing.Point(6, 166)
        Me.MaxShaftSheaveLoad_lbl.Name = "MaxShaftSheaveLoad_lbl"
        Me.MaxShaftSheaveLoad_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaxShaftSheaveLoad_lbl.Size = New System.Drawing.Size(205, 18)
        Me.MaxShaftSheaveLoad_lbl.TabIndex = 53
        Me.MaxShaftSheaveLoad_lbl.Text = "Allowable Sheave Load (lbs)"
        '
        'MachineSheaveJ_lbl
        '
        Me.MachineSheaveJ_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineSheaveJ_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineSheaveJ_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineSheaveJ_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineSheaveJ_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineSheaveJ_lbl.Location = New System.Drawing.Point(6, 22)
        Me.MachineSheaveJ_lbl.Name = "MachineSheaveJ_lbl"
        Me.MachineSheaveJ_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineSheaveJ_lbl.Size = New System.Drawing.Size(205, 18)
        Me.MachineSheaveJ_lbl.TabIndex = 52
        Me.MachineSheaveJ_lbl.Text = "Mach Sheave Inertia (lbs-ft-sec^2)"
        '
        'HiSpeedShaftInertia_lbl
        '
        Me.HiSpeedShaftInertia_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HiSpeedShaftInertia_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HiSpeedShaftInertia_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HiSpeedShaftInertia_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HiSpeedShaftInertia_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HiSpeedShaftInertia_lbl.Location = New System.Drawing.Point(6, 142)
        Me.HiSpeedShaftInertia_lbl.Name = "HiSpeedShaftInertia_lbl"
        Me.HiSpeedShaftInertia_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HiSpeedShaftInertia_lbl.Size = New System.Drawing.Size(205, 18)
        Me.HiSpeedShaftInertia_lbl.TabIndex = 51
        Me.HiSpeedShaftInertia_lbl.Text = "Hi-Speed Shaft Inertia (lbs-ft-sec^2)"
        '
        'ReverseGearEfficiency_lbl
        '
        Me.ReverseGearEfficiency_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ReverseGearEfficiency_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReverseGearEfficiency_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ReverseGearEfficiency_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReverseGearEfficiency_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReverseGearEfficiency_lbl.Location = New System.Drawing.Point(6, 118)
        Me.ReverseGearEfficiency_lbl.Name = "ReverseGearEfficiency_lbl"
        Me.ReverseGearEfficiency_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReverseGearEfficiency_lbl.Size = New System.Drawing.Size(205, 18)
        Me.ReverseGearEfficiency_lbl.TabIndex = 50
        Me.ReverseGearEfficiency_lbl.Text = "Reverse Gear Efficiency"
        '
        'GearRatio2_lbl
        '
        Me.GearRatio2_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.GearRatio2_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.GearRatio2_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GearRatio2_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GearRatio2_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GearRatio2_lbl.Location = New System.Drawing.Point(6, 46)
        Me.GearRatio2_lbl.Name = "GearRatio2_lbl"
        Me.GearRatio2_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GearRatio2_lbl.Size = New System.Drawing.Size(205, 18)
        Me.GearRatio2_lbl.TabIndex = 46
        Me.GearRatio2_lbl.Text = "Gear Ratio (eg 79:2) "
        '
        'GearRatio1_lbl
        '
        Me.GearRatio1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.GearRatio1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.GearRatio1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GearRatio1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GearRatio1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GearRatio1_lbl.Location = New System.Drawing.Point(6, 70)
        Me.GearRatio1_lbl.Name = "GearRatio1_lbl"
        Me.GearRatio1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GearRatio1_lbl.Size = New System.Drawing.Size(205, 19)
        Me.GearRatio1_lbl.TabIndex = 47
        Me.GearRatio1_lbl.Text = "Gear Ratio (eg 39.5) "
        '
        'ForwardGearEfficiency_lbl
        '
        Me.ForwardGearEfficiency_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ForwardGearEfficiency_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForwardGearEfficiency_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ForwardGearEfficiency_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForwardGearEfficiency_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ForwardGearEfficiency_lbl.Location = New System.Drawing.Point(6, 94)
        Me.ForwardGearEfficiency_lbl.Name = "ForwardGearEfficiency_lbl"
        Me.ForwardGearEfficiency_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ForwardGearEfficiency_lbl.Size = New System.Drawing.Size(205, 18)
        Me.ForwardGearEfficiency_lbl.TabIndex = 48
        Me.ForwardGearEfficiency_lbl.Text = "Forward Gear Efficiency"
        '
        'FMM200_fra
        '
        Me.FMM200_fra.Controls.Add(Me.VariableMagneticDiscBrake_cmb)
        Me.FMM200_fra.Controls.Add(Me.VariableMagneticDiscBrake_lbl)
        Me.FMM200_fra.Controls.Add(Me.HoistMotorType_cmb)
        Me.FMM200_fra.Controls.Add(Me.HoistMotorType_lbl)
        Me.FMM200_fra.Controls.Add(Me.STMLengthM_lbl)
        Me.FMM200_fra.Controls.Add(Me.STMLength_txt)
        Me.FMM200_fra.Controls.Add(Me.STMLength_lbl)
        Me.FMM200_fra.Controls.Add(Me.STMQty_txt)
        Me.FMM200_fra.Controls.Add(Me.STMQty_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCwtIn_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCarIn_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthIn_lbl)
        Me.FMM200_fra.Controls.Add(Me.HoistMotorCurrentA_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamSize_cmb)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCwt_txt)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLength_txt)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCar_txt)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCar_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamSize_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLengthCwt_lbl)
        Me.FMM200_fra.Controls.Add(Me.BlockingBeamLength_lbl)
        Me.FMM200_fra.Controls.Add(Me.HoistMotorCurrent_txt)
        Me.FMM200_fra.Controls.Add(Me.HoistMotorCurrent_lbl)
        Me.FMM200_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FMM200_fra.ForeColor = System.Drawing.Color.Black
        Me.FMM200_fra.Location = New System.Drawing.Point(683, 278)
        Me.FMM200_fra.Name = "FMM200_fra"
        Me.FMM200_fra.Size = New System.Drawing.Size(330, 238)
        Me.FMM200_fra.TabIndex = 83
        Me.FMM200_fra.TabStop = False
        Me.FMM200_fra.Text = "FMM 200"
        '
        'VariableMagneticDiscBrake_cmb
        '
        Me.VariableMagneticDiscBrake_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VariableMagneticDiscBrake_cmb.FormattingEnabled = True
        Me.VariableMagneticDiscBrake_cmb.Location = New System.Drawing.Point(198, 186)
        Me.VariableMagneticDiscBrake_cmb.Name = "VariableMagneticDiscBrake_cmb"
        Me.VariableMagneticDiscBrake_cmb.Size = New System.Drawing.Size(126, 21)
        Me.VariableMagneticDiscBrake_cmb.TabIndex = 51
        '
        'VariableMagneticDiscBrake_lbl
        '
        Me.VariableMagneticDiscBrake_lbl.AutoSize = True
        Me.VariableMagneticDiscBrake_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VariableMagneticDiscBrake_lbl.Location = New System.Drawing.Point(6, 188)
        Me.VariableMagneticDiscBrake_lbl.Name = "VariableMagneticDiscBrake_lbl"
        Me.VariableMagneticDiscBrake_lbl.Size = New System.Drawing.Size(175, 13)
        Me.VariableMagneticDiscBrake_lbl.TabIndex = 109
        Me.VariableMagneticDiscBrake_lbl.Text = "Variable Magnetic Disc Brake"
        '
        'HoistMotorType_cmb
        '
        Me.HoistMotorType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorType_cmb.FormattingEnabled = True
        Me.HoistMotorType_cmb.Location = New System.Drawing.Point(198, 210)
        Me.HoistMotorType_cmb.Name = "HoistMotorType_cmb"
        Me.HoistMotorType_cmb.Size = New System.Drawing.Size(126, 21)
        Me.HoistMotorType_cmb.TabIndex = 52
        '
        'HoistMotorType_lbl
        '
        Me.HoistMotorType_lbl.AutoSize = True
        Me.HoistMotorType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorType_lbl.Location = New System.Drawing.Point(6, 213)
        Me.HoistMotorType_lbl.Name = "HoistMotorType_lbl"
        Me.HoistMotorType_lbl.Size = New System.Drawing.Size(104, 13)
        Me.HoistMotorType_lbl.TabIndex = 107
        Me.HoistMotorType_lbl.Text = "Hoist Motor Type"
        '
        'STMLengthM_lbl
        '
        Me.STMLengthM_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.STMLengthM_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.STMLengthM_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.STMLengthM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STMLengthM_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.STMLengthM_lbl.Location = New System.Drawing.Point(304, 68)
        Me.STMLengthM_lbl.Name = "STMLengthM_lbl"
        Me.STMLengthM_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STMLengthM_lbl.Size = New System.Drawing.Size(20, 18)
        Me.STMLengthM_lbl.TabIndex = 97
        Me.STMLengthM_lbl.Text = "M"
        '
        'STMLength_txt
        '
        Me.STMLength_txt.AcceptsReturn = True
        Me.STMLength_txt.BackColor = System.Drawing.SystemColors.Window
        Me.STMLength_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.STMLength_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STMLength_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.STMLength_txt.Location = New System.Drawing.Point(225, 66)
        Me.STMLength_txt.MaxLength = 0
        Me.STMLength_txt.Name = "STMLength_txt"
        Me.STMLength_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STMLength_txt.Size = New System.Drawing.Size(76, 20)
        Me.STMLength_txt.TabIndex = 46
        Me.STMLength_txt.Tag = "Geared And Gearless"
        '
        'STMLength_lbl
        '
        Me.STMLength_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.STMLength_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.STMLength_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.STMLength_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STMLength_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.STMLength_lbl.Location = New System.Drawing.Point(9, 68)
        Me.STMLength_lbl.Name = "STMLength_lbl"
        Me.STMLength_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STMLength_lbl.Size = New System.Drawing.Size(214, 18)
        Me.STMLength_lbl.TabIndex = 96
        Me.STMLength_lbl.Text = "STM Length"
        '
        'STMQty_txt
        '
        Me.STMQty_txt.AcceptsReturn = True
        Me.STMQty_txt.BackColor = System.Drawing.SystemColors.Window
        Me.STMQty_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.STMQty_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STMQty_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.STMQty_txt.Location = New System.Drawing.Point(225, 42)
        Me.STMQty_txt.MaxLength = 0
        Me.STMQty_txt.Name = "STMQty_txt"
        Me.STMQty_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STMQty_txt.Size = New System.Drawing.Size(76, 20)
        Me.STMQty_txt.TabIndex = 45
        Me.STMQty_txt.Tag = "Geared And Gearless"
        '
        'STMQty_lbl
        '
        Me.STMQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.STMQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.STMQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.STMQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STMQty_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.STMQty_lbl.Location = New System.Drawing.Point(9, 44)
        Me.STMQty_lbl.Name = "STMQty_lbl"
        Me.STMQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STMQty_lbl.Size = New System.Drawing.Size(214, 18)
        Me.STMQty_lbl.TabIndex = 94
        Me.STMQty_lbl.Text = "STM Qty                                  ZZ="
        '
        'BlockingBeamLengthCwtIn_lbl
        '
        Me.BlockingBeamLengthCwtIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCwtIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLengthCwtIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLengthCwtIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCwtIn_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCwtIn_lbl.Location = New System.Drawing.Point(304, 140)
        Me.BlockingBeamLengthCwtIn_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLengthCwtIn_lbl.Name = "BlockingBeamLengthCwtIn_lbl"
        Me.BlockingBeamLengthCwtIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCwtIn_lbl.Size = New System.Drawing.Size(20, 22)
        Me.BlockingBeamLengthCwtIn_lbl.TabIndex = 92
        Me.BlockingBeamLengthCwtIn_lbl.Text = "In"
        '
        'BlockingBeamLengthCarIn_lbl
        '
        Me.BlockingBeamLengthCarIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCarIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLengthCarIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLengthCarIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCarIn_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCarIn_lbl.Location = New System.Drawing.Point(304, 116)
        Me.BlockingBeamLengthCarIn_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLengthCarIn_lbl.Name = "BlockingBeamLengthCarIn_lbl"
        Me.BlockingBeamLengthCarIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCarIn_lbl.Size = New System.Drawing.Size(20, 22)
        Me.BlockingBeamLengthCarIn_lbl.TabIndex = 91
        Me.BlockingBeamLengthCarIn_lbl.Text = "In"
        '
        'BlockingBeamLengthIn_lbl
        '
        Me.BlockingBeamLengthIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLengthIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLengthIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthIn_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthIn_lbl.Location = New System.Drawing.Point(304, 92)
        Me.BlockingBeamLengthIn_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLengthIn_lbl.Name = "BlockingBeamLengthIn_lbl"
        Me.BlockingBeamLengthIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthIn_lbl.Size = New System.Drawing.Size(20, 22)
        Me.BlockingBeamLengthIn_lbl.TabIndex = 90
        Me.BlockingBeamLengthIn_lbl.Text = "In"
        '
        'HoistMotorCurrentA_lbl
        '
        Me.HoistMotorCurrentA_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorCurrentA_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorCurrentA_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorCurrentA_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorCurrentA_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorCurrentA_lbl.Location = New System.Drawing.Point(304, 20)
        Me.HoistMotorCurrentA_lbl.Name = "HoistMotorCurrentA_lbl"
        Me.HoistMotorCurrentA_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorCurrentA_lbl.Size = New System.Drawing.Size(20, 18)
        Me.HoistMotorCurrentA_lbl.TabIndex = 88
        Me.HoistMotorCurrentA_lbl.Text = "A"
        '
        'BlockingBeamSize_cmb
        '
        Me.BlockingBeamSize_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamSize_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamSize_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BlockingBeamSize_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamSize_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamSize_cmb.Location = New System.Drawing.Point(225, 162)
        Me.BlockingBeamSize_cmb.Margin = New System.Windows.Forms.Padding(4)
        Me.BlockingBeamSize_cmb.Name = "BlockingBeamSize_cmb"
        Me.BlockingBeamSize_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamSize_cmb.Size = New System.Drawing.Size(76, 21)
        Me.BlockingBeamSize_cmb.TabIndex = 50
        '
        'BlockingBeamLengthCwt_txt
        '
        Me.BlockingBeamLengthCwt_txt.AcceptsReturn = True
        Me.BlockingBeamLengthCwt_txt.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCwt_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BlockingBeamLengthCwt_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCwt_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCwt_txt.Location = New System.Drawing.Point(225, 138)
        Me.BlockingBeamLengthCwt_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.BlockingBeamLengthCwt_txt.MaxLength = 0
        Me.BlockingBeamLengthCwt_txt.Name = "BlockingBeamLengthCwt_txt"
        Me.BlockingBeamLengthCwt_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCwt_txt.Size = New System.Drawing.Size(76, 20)
        Me.BlockingBeamLengthCwt_txt.TabIndex = 49
        Me.BlockingBeamLengthCwt_txt.Tag = "Geared And Gearless"
        '
        'BlockingBeamLength_txt
        '
        Me.BlockingBeamLength_txt.AcceptsReturn = True
        Me.BlockingBeamLength_txt.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLength_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BlockingBeamLength_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLength_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLength_txt.Location = New System.Drawing.Point(225, 90)
        Me.BlockingBeamLength_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.BlockingBeamLength_txt.MaxLength = 0
        Me.BlockingBeamLength_txt.Name = "BlockingBeamLength_txt"
        Me.BlockingBeamLength_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLength_txt.Size = New System.Drawing.Size(76, 20)
        Me.BlockingBeamLength_txt.TabIndex = 47
        Me.BlockingBeamLength_txt.Tag = "Geared And Gearless"
        '
        'BlockingBeamLengthCar_txt
        '
        Me.BlockingBeamLengthCar_txt.AcceptsReturn = True
        Me.BlockingBeamLengthCar_txt.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCar_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BlockingBeamLengthCar_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCar_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCar_txt.Location = New System.Drawing.Point(225, 114)
        Me.BlockingBeamLengthCar_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.BlockingBeamLengthCar_txt.MaxLength = 0
        Me.BlockingBeamLengthCar_txt.Name = "BlockingBeamLengthCar_txt"
        Me.BlockingBeamLengthCar_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCar_txt.Size = New System.Drawing.Size(76, 20)
        Me.BlockingBeamLengthCar_txt.TabIndex = 48
        Me.BlockingBeamLengthCar_txt.Tag = "Geared And Gearless"
        '
        'BlockingBeamLengthCar_lbl
        '
        Me.BlockingBeamLengthCar_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCar_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLengthCar_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLengthCar_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCar_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCar_lbl.Location = New System.Drawing.Point(9, 116)
        Me.BlockingBeamLengthCar_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLengthCar_lbl.Name = "BlockingBeamLengthCar_lbl"
        Me.BlockingBeamLengthCar_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCar_lbl.Size = New System.Drawing.Size(214, 22)
        Me.BlockingBeamLengthCar_lbl.TabIndex = 78
        Me.BlockingBeamLengthCar_lbl.Text = "Blocking Beam Length - Car      BL1="
        '
        'BlockingBeamSize_lbl
        '
        Me.BlockingBeamSize_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamSize_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamSize_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamSize_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamSize_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamSize_lbl.Location = New System.Drawing.Point(9, 164)
        Me.BlockingBeamSize_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamSize_lbl.Name = "BlockingBeamSize_lbl"
        Me.BlockingBeamSize_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamSize_lbl.Size = New System.Drawing.Size(214, 22)
        Me.BlockingBeamSize_lbl.TabIndex = 77
        Me.BlockingBeamSize_lbl.Text = "Blocking Beam Size                   BS="
        '
        'BlockingBeamLengthCwt_lbl
        '
        Me.BlockingBeamLengthCwt_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLengthCwt_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLengthCwt_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLengthCwt_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLengthCwt_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLengthCwt_lbl.Location = New System.Drawing.Point(9, 140)
        Me.BlockingBeamLengthCwt_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLengthCwt_lbl.Name = "BlockingBeamLengthCwt_lbl"
        Me.BlockingBeamLengthCwt_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLengthCwt_lbl.Size = New System.Drawing.Size(214, 22)
        Me.BlockingBeamLengthCwt_lbl.TabIndex = 76
        Me.BlockingBeamLengthCwt_lbl.Text = "Blocking Beam Length - Cwt     BL2="
        '
        'BlockingBeamLength_lbl
        '
        Me.BlockingBeamLength_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BlockingBeamLength_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockingBeamLength_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BlockingBeamLength_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockingBeamLength_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockingBeamLength_lbl.Location = New System.Drawing.Point(9, 92)
        Me.BlockingBeamLength_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlockingBeamLength_lbl.Name = "BlockingBeamLength_lbl"
        Me.BlockingBeamLength_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockingBeamLength_lbl.Size = New System.Drawing.Size(214, 22)
        Me.BlockingBeamLength_lbl.TabIndex = 75
        Me.BlockingBeamLength_lbl.Text = "Blocking Beam Length               BL="
        '
        'HoistMotorCurrent_txt
        '
        Me.HoistMotorCurrent_txt.AcceptsReturn = True
        Me.HoistMotorCurrent_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorCurrent_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HoistMotorCurrent_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorCurrent_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorCurrent_txt.Location = New System.Drawing.Point(225, 18)
        Me.HoistMotorCurrent_txt.MaxLength = 0
        Me.HoistMotorCurrent_txt.Name = "HoistMotorCurrent_txt"
        Me.HoistMotorCurrent_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorCurrent_txt.Size = New System.Drawing.Size(76, 20)
        Me.HoistMotorCurrent_txt.TabIndex = 44
        Me.HoistMotorCurrent_txt.Tag = "Geared And Gearless"
        '
        'HoistMotorCurrent_lbl
        '
        Me.HoistMotorCurrent_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorCurrent_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorCurrent_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorCurrent_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorCurrent_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorCurrent_lbl.Location = New System.Drawing.Point(9, 20)
        Me.HoistMotorCurrent_lbl.Name = "HoistMotorCurrent_lbl"
        Me.HoistMotorCurrent_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorCurrent_lbl.Size = New System.Drawing.Size(214, 18)
        Me.HoistMotorCurrent_lbl.TabIndex = 70
        Me.HoistMotorCurrent_lbl.Text = "Hoist Motor Current                  IME="
        '
        'DriveCalcValues_fra
        '
        Me.DriveCalcValues_fra.BackColor = System.Drawing.SystemColors.Window
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ2N_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ2_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ2_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ1N_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ1_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.FZ1_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.UN_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.UN_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.TMENm_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.TME_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.TME_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1AG_KW_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1EG_KW_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.INA_A_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.INE_A_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PME_KW_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1AG_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1AG_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1EG_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.PC1EG_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.INA_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.INA_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.INE_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.INE_lbl)
        Me.DriveCalcValues_fra.Controls.Add(Me.PME_txt)
        Me.DriveCalcValues_fra.Controls.Add(Me.PME_lbl)
        Me.DriveCalcValues_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveCalcValues_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DriveCalcValues_fra.Location = New System.Drawing.Point(4, 471)
        Me.DriveCalcValues_fra.Name = "DriveCalcValues_fra"
        Me.DriveCalcValues_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveCalcValues_fra.Size = New System.Drawing.Size(660, 142)
        Me.DriveCalcValues_fra.TabIndex = 84
        Me.DriveCalcValues_fra.TabStop = False
        Me.DriveCalcValues_fra.Text = "Drive Calc Values"
        '
        'FZ2N_lbl
        '
        Me.FZ2N_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FZ2N_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FZ2N_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FZ2N_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ2N_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ2N_lbl.Location = New System.Drawing.Point(636, 115)
        Me.FZ2N_lbl.Name = "FZ2N_lbl"
        Me.FZ2N_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ2N_lbl.Size = New System.Drawing.Size(22, 19)
        Me.FZ2N_lbl.TabIndex = 105
        Me.FZ2N_lbl.Text = "N"
        '
        'FZ2_txt
        '
        Me.FZ2_txt.AcceptsReturn = True
        Me.FZ2_txt.BackColor = System.Drawing.SystemColors.Window
        Me.FZ2_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FZ2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ2_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ2_txt.Location = New System.Drawing.Point(531, 113)
        Me.FZ2_txt.MaxLength = 0
        Me.FZ2_txt.Name = "FZ2_txt"
        Me.FZ2_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ2_txt.Size = New System.Drawing.Size(99, 20)
        Me.FZ2_txt.TabIndex = 36
        '
        'FZ2_lbl
        '
        Me.FZ2_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FZ2_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FZ2_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FZ2_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ2_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ2_lbl.Location = New System.Drawing.Point(347, 115)
        Me.FZ2_lbl.Name = "FZ2_lbl"
        Me.FZ2_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ2_lbl.Size = New System.Drawing.Size(185, 18)
        Me.FZ2_lbl.TabIndex = 104
        Me.FZ2_lbl.Text = "FZ2"
        '
        'FZ1N_lbl
        '
        Me.FZ1N_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FZ1N_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FZ1N_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FZ1N_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ1N_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ1N_lbl.Location = New System.Drawing.Point(636, 89)
        Me.FZ1N_lbl.Name = "FZ1N_lbl"
        Me.FZ1N_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ1N_lbl.Size = New System.Drawing.Size(22, 19)
        Me.FZ1N_lbl.TabIndex = 102
        Me.FZ1N_lbl.Text = "N"
        '
        'FZ1_txt
        '
        Me.FZ1_txt.AcceptsReturn = True
        Me.FZ1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.FZ1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FZ1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ1_txt.Location = New System.Drawing.Point(531, 87)
        Me.FZ1_txt.MaxLength = 0
        Me.FZ1_txt.Name = "FZ1_txt"
        Me.FZ1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ1_txt.Size = New System.Drawing.Size(99, 20)
        Me.FZ1_txt.TabIndex = 35
        '
        'FZ1_lbl
        '
        Me.FZ1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FZ1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FZ1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FZ1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FZ1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FZ1_lbl.Location = New System.Drawing.Point(347, 89)
        Me.FZ1_lbl.Name = "FZ1_lbl"
        Me.FZ1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FZ1_lbl.Size = New System.Drawing.Size(185, 18)
        Me.FZ1_lbl.TabIndex = 101
        Me.FZ1_lbl.Text = "FZ1"
        '
        'UN_txt
        '
        Me.UN_txt.AcceptsReturn = True
        Me.UN_txt.BackColor = System.Drawing.SystemColors.Window
        Me.UN_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UN_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UN_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.UN_txt.Location = New System.Drawing.Point(198, 86)
        Me.UN_txt.MaxLength = 0
        Me.UN_txt.Name = "UN_txt"
        Me.UN_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UN_txt.Size = New System.Drawing.Size(99, 20)
        Me.UN_txt.TabIndex = 31
        '
        'UN_lbl
        '
        Me.UN_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.UN_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.UN_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UN_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UN_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.UN_lbl.Location = New System.Drawing.Point(6, 88)
        Me.UN_lbl.Name = "UN_lbl"
        Me.UN_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UN_lbl.Size = New System.Drawing.Size(185, 18)
        Me.UN_lbl.TabIndex = 99
        Me.UN_lbl.Text = "UN"
        '
        'TMENm_lbl
        '
        Me.TMENm_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TMENm_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TMENm_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TMENm_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMENm_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TMENm_lbl.Location = New System.Drawing.Point(636, 64)
        Me.TMENm_lbl.Name = "TMENm_lbl"
        Me.TMENm_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TMENm_lbl.Size = New System.Drawing.Size(22, 19)
        Me.TMENm_lbl.TabIndex = 97
        Me.TMENm_lbl.Text = "Nm"
        '
        'TME_txt
        '
        Me.TME_txt.AcceptsReturn = True
        Me.TME_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TME_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TME_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TME_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TME_txt.Location = New System.Drawing.Point(531, 62)
        Me.TME_txt.MaxLength = 0
        Me.TME_txt.Name = "TME_txt"
        Me.TME_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TME_txt.Size = New System.Drawing.Size(99, 20)
        Me.TME_txt.TabIndex = 34
        '
        'TME_lbl
        '
        Me.TME_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TME_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TME_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TME_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TME_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TME_lbl.Location = New System.Drawing.Point(347, 64)
        Me.TME_lbl.Name = "TME_lbl"
        Me.TME_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TME_lbl.Size = New System.Drawing.Size(185, 18)
        Me.TME_lbl.TabIndex = 96
        Me.TME_lbl.Text = "TME"
        '
        'PC1AG_KW_lbl
        '
        Me.PC1AG_KW_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PC1AG_KW_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PC1AG_KW_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PC1AG_KW_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1AG_KW_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1AG_KW_lbl.Location = New System.Drawing.Point(636, 40)
        Me.PC1AG_KW_lbl.Name = "PC1AG_KW_lbl"
        Me.PC1AG_KW_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1AG_KW_lbl.Size = New System.Drawing.Size(22, 19)
        Me.PC1AG_KW_lbl.TabIndex = 94
        Me.PC1AG_KW_lbl.Text = "KW"
        '
        'PC1EG_KW_lbl
        '
        Me.PC1EG_KW_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PC1EG_KW_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PC1EG_KW_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PC1EG_KW_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1EG_KW_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1EG_KW_lbl.Location = New System.Drawing.Point(636, 16)
        Me.PC1EG_KW_lbl.Name = "PC1EG_KW_lbl"
        Me.PC1EG_KW_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1EG_KW_lbl.Size = New System.Drawing.Size(22, 19)
        Me.PC1EG_KW_lbl.TabIndex = 93
        Me.PC1EG_KW_lbl.Text = "KW"
        '
        'INA_A_lbl
        '
        Me.INA_A_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.INA_A_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.INA_A_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.INA_A_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INA_A_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INA_A_lbl.Location = New System.Drawing.Point(303, 64)
        Me.INA_A_lbl.Name = "INA_A_lbl"
        Me.INA_A_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INA_A_lbl.Size = New System.Drawing.Size(24, 17)
        Me.INA_A_lbl.TabIndex = 92
        Me.INA_A_lbl.Text = "A"
        '
        'INE_A_lbl
        '
        Me.INE_A_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.INE_A_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.INE_A_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.INE_A_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INE_A_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INE_A_lbl.Location = New System.Drawing.Point(303, 40)
        Me.INE_A_lbl.Name = "INE_A_lbl"
        Me.INE_A_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INE_A_lbl.Size = New System.Drawing.Size(24, 19)
        Me.INE_A_lbl.TabIndex = 91
        Me.INE_A_lbl.Text = "A"
        '
        'PME_KW_lbl
        '
        Me.PME_KW_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PME_KW_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PME_KW_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PME_KW_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PME_KW_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PME_KW_lbl.Location = New System.Drawing.Point(303, 16)
        Me.PME_KW_lbl.Name = "PME_KW_lbl"
        Me.PME_KW_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PME_KW_lbl.Size = New System.Drawing.Size(24, 19)
        Me.PME_KW_lbl.TabIndex = 90
        Me.PME_KW_lbl.Text = "KW"
        '
        'PC1AG_txt
        '
        Me.PC1AG_txt.AcceptsReturn = True
        Me.PC1AG_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PC1AG_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PC1AG_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1AG_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1AG_txt.Location = New System.Drawing.Point(531, 37)
        Me.PC1AG_txt.MaxLength = 0
        Me.PC1AG_txt.Name = "PC1AG_txt"
        Me.PC1AG_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1AG_txt.Size = New System.Drawing.Size(99, 20)
        Me.PC1AG_txt.TabIndex = 33
        '
        'PC1AG_lbl
        '
        Me.PC1AG_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PC1AG_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PC1AG_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PC1AG_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1AG_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1AG_lbl.Location = New System.Drawing.Point(347, 39)
        Me.PC1AG_lbl.Name = "PC1AG_lbl"
        Me.PC1AG_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1AG_lbl.Size = New System.Drawing.Size(185, 19)
        Me.PC1AG_lbl.TabIndex = 89
        Me.PC1AG_lbl.Text = "PC1AG"
        '
        'PC1EG_txt
        '
        Me.PC1EG_txt.AcceptsReturn = True
        Me.PC1EG_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PC1EG_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PC1EG_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1EG_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1EG_txt.Location = New System.Drawing.Point(531, 13)
        Me.PC1EG_txt.MaxLength = 0
        Me.PC1EG_txt.Name = "PC1EG_txt"
        Me.PC1EG_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1EG_txt.Size = New System.Drawing.Size(99, 20)
        Me.PC1EG_txt.TabIndex = 32
        '
        'PC1EG_lbl
        '
        Me.PC1EG_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PC1EG_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PC1EG_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PC1EG_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PC1EG_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PC1EG_lbl.Location = New System.Drawing.Point(347, 15)
        Me.PC1EG_lbl.Name = "PC1EG_lbl"
        Me.PC1EG_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PC1EG_lbl.Size = New System.Drawing.Size(185, 19)
        Me.PC1EG_lbl.TabIndex = 87
        Me.PC1EG_lbl.Text = "PC1EG"
        '
        'INA_txt
        '
        Me.INA_txt.AcceptsReturn = True
        Me.INA_txt.BackColor = System.Drawing.SystemColors.Window
        Me.INA_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INA_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INA_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INA_txt.Location = New System.Drawing.Point(198, 62)
        Me.INA_txt.MaxLength = 0
        Me.INA_txt.Name = "INA_txt"
        Me.INA_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INA_txt.Size = New System.Drawing.Size(99, 20)
        Me.INA_txt.TabIndex = 30
        '
        'INA_lbl
        '
        Me.INA_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.INA_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.INA_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.INA_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INA_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INA_lbl.Location = New System.Drawing.Point(6, 64)
        Me.INA_lbl.Name = "INA_lbl"
        Me.INA_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INA_lbl.Size = New System.Drawing.Size(185, 18)
        Me.INA_lbl.TabIndex = 85
        Me.INA_lbl.Text = "INA"
        '
        'INE_txt
        '
        Me.INE_txt.AcceptsReturn = True
        Me.INE_txt.BackColor = System.Drawing.SystemColors.Window
        Me.INE_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INE_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INE_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INE_txt.Location = New System.Drawing.Point(198, 38)
        Me.INE_txt.MaxLength = 0
        Me.INE_txt.Name = "INE_txt"
        Me.INE_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INE_txt.Size = New System.Drawing.Size(99, 20)
        Me.INE_txt.TabIndex = 29
        '
        'INE_lbl
        '
        Me.INE_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.INE_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.INE_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.INE_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INE_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INE_lbl.Location = New System.Drawing.Point(6, 40)
        Me.INE_lbl.Name = "INE_lbl"
        Me.INE_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INE_lbl.Size = New System.Drawing.Size(185, 19)
        Me.INE_lbl.TabIndex = 83
        Me.INE_lbl.Text = "INE"
        '
        'PME_txt
        '
        Me.PME_txt.AcceptsReturn = True
        Me.PME_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PME_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PME_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PME_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PME_txt.Location = New System.Drawing.Point(198, 14)
        Me.PME_txt.MaxLength = 0
        Me.PME_txt.Name = "PME_txt"
        Me.PME_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PME_txt.Size = New System.Drawing.Size(99, 20)
        Me.PME_txt.TabIndex = 28
        '
        'PME_lbl
        '
        Me.PME_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PME_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PME_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PME_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PME_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PME_lbl.Location = New System.Drawing.Point(6, 16)
        Me.PME_lbl.Name = "PME_lbl"
        Me.PME_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PME_lbl.Size = New System.Drawing.Size(185, 19)
        Me.PME_lbl.TabIndex = 81
        Me.PME_lbl.Text = "PME"
        '
        'MachineHand_fra
        '
        Me.MachineHand_fra.BackColor = System.Drawing.SystemColors.Window
        Me.MachineHand_fra.Controls.Add(Me.MachineHand_spr)
        Me.MachineHand_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineHand_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineHand_fra.Location = New System.Drawing.Point(683, 522)
        Me.MachineHand_fra.Name = "MachineHand_fra"
        Me.MachineHand_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineHand_fra.Size = New System.Drawing.Size(330, 91)
        Me.MachineHand_fra.TabIndex = 85
        Me.MachineHand_fra.TabStop = False
        Me.MachineHand_fra.Tag = "Left"
        Me.MachineHand_fra.Text = "Machine Hand"
        '
        'MachineHand_spr
        '
        Me.MachineHand_spr.AccessibleDescription = "MachineHand_spr, Sheet1, Row 0, Column 0, "
        Me.MachineHand_spr.Location = New System.Drawing.Point(6, 20)
        Me.MachineHand_spr.Name = "MachineHand_spr"
        Me.MachineHand_spr.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.MachineHand_spr_Sheet1})
        Me.MachineHand_spr.Size = New System.Drawing.Size(318, 62)
        Me.MachineHand_spr.TabIndex = 53
        Me.MachineHand_spr.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'MachineHand_spr_Sheet1
        '
        Me.MachineHand_spr_Sheet1.Reset()
        Me.MachineHand_spr_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.MachineHand_spr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.MachineHand_spr_Sheet1.ColumnCount = 8
        Me.MachineHand_spr_Sheet1.RowCount = 1
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Car 01"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Car 02"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Car 03"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Car 04"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Car 05"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Car 06"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Car 07"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Car 08"
        Me.MachineHand_spr_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType1.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(0).CellType = ComboBoxCellType1
        Me.MachineHand_spr_Sheet1.Columns.Get(0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(0).Label = "Car 01"
        Me.MachineHand_spr_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType2.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(1).CellType = ComboBoxCellType2
        Me.MachineHand_spr_Sheet1.Columns.Get(1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(1).Label = "Car 02"
        Me.MachineHand_spr_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType3.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(2).CellType = ComboBoxCellType3
        Me.MachineHand_spr_Sheet1.Columns.Get(2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(2).Label = "Car 03"
        Me.MachineHand_spr_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType4.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(3).CellType = ComboBoxCellType4
        Me.MachineHand_spr_Sheet1.Columns.Get(3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(3).Label = "Car 04"
        Me.MachineHand_spr_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType5.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(4).CellType = ComboBoxCellType5
        Me.MachineHand_spr_Sheet1.Columns.Get(4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(4).Label = "Car 05"
        Me.MachineHand_spr_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType6.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(5).CellType = ComboBoxCellType6
        Me.MachineHand_spr_Sheet1.Columns.Get(5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(5).Label = "Car 06"
        Me.MachineHand_spr_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType7.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(6).CellType = ComboBoxCellType7
        Me.MachineHand_spr_Sheet1.Columns.Get(6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(6).Label = "Car 07"
        Me.MachineHand_spr_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        ComboBoxCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType8.Items = New String() {"Left", "Right"}
        Me.MachineHand_spr_Sheet1.Columns.Get(7).CellType = ComboBoxCellType8
        Me.MachineHand_spr_Sheet1.Columns.Get(7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MachineHand_spr_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.MachineHand_spr_Sheet1.Columns.Get(7).Label = "Car 08"
        Me.MachineHand_spr_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.MachineHand_spr_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.MachineHand_spr_Sheet1.RowHeader.Visible = False
        Me.MachineHand_spr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'MN_TRQ02_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1019, 616)
        Me.ControlBox = False
        Me.Controls.Add(Me.MachineHand_fra)
        Me.Controls.Add(Me.DriveCalcValues_fra)
        Me.Controls.Add(Me.FMM200_fra)
        Me.Controls.Add(Me.Autotransformer_fra)
        Me.Controls.Add(Me.Software_fra)
        Me.Controls.Add(Me.ACMotor_fra)
        Me.Controls.Add(Me.MotorDrive_fra)
        Me.Controls.Add(Me.SystemData_fra)
        Me.Controls.Add(Me.DeflectorSecondarySheave_fra)
        Me.Controls.Add(Me.RopeModifiers_fra)
        Me.Controls.Add(Me.OnlyBasement_fra)
        Me.Controls.Add(Me.CompensationData_fra)
        Me.Controls.Add(Me.WrapAngleCalc_fra)
        Me.Controls.Add(Me.RopingAndRelatedData_fra)
        Me.Controls.Add(Me.Only2To1Roping_fra)
        Me.Controls.Add(Me.SheaveData_fra)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(-189, 11)
        Me.Name = "MN_TRQ02_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = " Torque Override"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Autotransformer_fra.ResumeLayout(False)
        Me.Software_fra.ResumeLayout(False)
        Me.Software_fra.PerformLayout()
        Me.ACMotor_fra.ResumeLayout(False)
        Me.MotorDrive_fra.ResumeLayout(False)
        Me.SystemData_fra.ResumeLayout(False)
        Me.SystemData_fra.PerformLayout()
        Me.DeflectorSecondarySheave_fra.ResumeLayout(False)
        Me.DeflectorSecondarySheave_fra.PerformLayout()
        Me.RopeModifiers_fra.ResumeLayout(False)
        Me.RopeModifiers_fra.PerformLayout()
        Me.OnlyBasement_fra.ResumeLayout(False)
        Me.OnlyBasement_fra.PerformLayout()
        Me.CompensationData_fra.ResumeLayout(False)
        Me.CompensationData_fra.PerformLayout()
        Me.WrapAngleCalc_fra.ResumeLayout(False)
        Me.WrapAngleCalc_fra.PerformLayout()
        Me.RopingAndRelatedData_fra.ResumeLayout(False)
        Me.Only2To1Roping_fra.ResumeLayout(False)
        Me.Only2To1Roping_fra.PerformLayout()
        Me.SheaveData_fra.ResumeLayout(False)
        Me.SheaveData_fra.PerformLayout()
        Me.FMM200_fra.ResumeLayout(False)
        Me.FMM200_fra.PerformLayout()
        Me.DriveCalcValues_fra.ResumeLayout(False)
        Me.DriveCalcValues_fra.PerformLayout()
        Me.MachineHand_fra.ResumeLayout(False)
        CType(Me.MachineHand_spr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MachineHand_spr_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
        '    AddHandler MyBase.Load, AddressOf Me.MN_TRQ02_frm_Load
        '    AddHandler MyBase.Resize, AddressOf Me.MN_TRQ02_frm_Resize
        '    AddHandler MyBase.Closed, AddressOf Me.MN_TRQ02_frm_Closed
        'End If
    End Sub
    Public WithEvents RequiredKVA_cmb As System.Windows.Forms.ComboBox
    Friend WithEvents FMM200_fra As System.Windows.Forms.GroupBox
    Public WithEvents BlockingBeamLengthCwt_txt As System.Windows.Forms.TextBox
    Public WithEvents BlockingBeamLength_txt As System.Windows.Forms.TextBox
    Public WithEvents BlockingBeamLengthCar_txt As System.Windows.Forms.TextBox
    Public WithEvents BlockingBeamLengthCar_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamSize_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamLengthCwt_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamLength_lbl As System.Windows.Forms.Label
    Public WithEvents HoistMotorCurrent_txt As System.Windows.Forms.TextBox
    Public WithEvents HoistMotorCurrent_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamLengthCwtIn_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamLengthCarIn_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamLengthIn_lbl As System.Windows.Forms.Label
    Public WithEvents HoistMotorCurrentA_lbl As System.Windows.Forms.Label
    Public WithEvents BlockingBeamSize_cmb As System.Windows.Forms.ComboBox
    Public WithEvents STMQty_txt As System.Windows.Forms.TextBox
    Public WithEvents STMQty_lbl As System.Windows.Forms.Label
    Public WithEvents STMLength_txt As System.Windows.Forms.TextBox
    Public WithEvents STMLength_lbl As System.Windows.Forms.Label
    Public WithEvents DriveCalcValues_fra As System.Windows.Forms.GroupBox
    Public WithEvents PME_txt As System.Windows.Forms.TextBox
    Public WithEvents PME_lbl As System.Windows.Forms.Label
    Public WithEvents PC1AG_txt As System.Windows.Forms.TextBox
    Public WithEvents PC1AG_lbl As System.Windows.Forms.Label
    Public WithEvents PC1EG_txt As System.Windows.Forms.TextBox
    Public WithEvents PC1EG_lbl As System.Windows.Forms.Label
    Public WithEvents INA_txt As System.Windows.Forms.TextBox
    Public WithEvents INA_lbl As System.Windows.Forms.Label
    Public WithEvents INE_txt As System.Windows.Forms.TextBox
    Public WithEvents INE_lbl As System.Windows.Forms.Label
    Public WithEvents PC1AG_KW_lbl As System.Windows.Forms.Label
    Public WithEvents PC1EG_KW_lbl As System.Windows.Forms.Label
    Public WithEvents INA_A_lbl As System.Windows.Forms.Label
    Public WithEvents INE_A_lbl As System.Windows.Forms.Label
    Public WithEvents PME_KW_lbl As System.Windows.Forms.Label
    Public WithEvents STMLengthM_lbl As System.Windows.Forms.Label
    Public WithEvents TMENm_lbl As System.Windows.Forms.Label
    Public WithEvents TME_txt As System.Windows.Forms.TextBox
    Public WithEvents TME_lbl As System.Windows.Forms.Label
    Friend WithEvents VariableMagneticDiscBrake_cmb As System.Windows.Forms.ComboBox
    Friend WithEvents VariableMagneticDiscBrake_lbl As System.Windows.Forms.Label
    Friend WithEvents HoistMotorType_cmb As System.Windows.Forms.ComboBox
    Friend WithEvents HoistMotorType_lbl As System.Windows.Forms.Label
    Public WithEvents UN_txt As System.Windows.Forms.TextBox
    Public WithEvents UN_lbl As System.Windows.Forms.Label
    Public WithEvents MachineHand_fra As System.Windows.Forms.GroupBox
    Public WithEvents FZ2N_lbl As System.Windows.Forms.Label
    Public WithEvents FZ2_txt As System.Windows.Forms.TextBox
    Public WithEvents FZ2_lbl As System.Windows.Forms.Label
    Public WithEvents FZ1N_lbl As System.Windows.Forms.Label
    Public WithEvents FZ1_txt As System.Windows.Forms.TextBox
    Public WithEvents FZ1_lbl As System.Windows.Forms.Label
    Friend WithEvents MachineHand_spr As FarPoint.Win.Spread.FpSpread
    Friend WithEvents MachineHand_spr_Sheet1 As FarPoint.Win.Spread.SheetView
#End Region
End Class