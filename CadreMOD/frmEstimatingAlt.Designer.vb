Partial Class frmEstimatingAlt
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstimatingAlt))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GeneralInformationBase_fra = New System.Windows.Forms.GroupBox()
        Me.DestinationBase_cmb = New System.Windows.Forms.Label()
        Me.PitDepthBase_txt = New System.Windows.Forms.Label()
        Me.TravelBase_txt = New System.Windows.Forms.Label()
        Me.TopFloorToOverheadBase_txt = New System.Windows.Forms.Label()
        Me.RopingNewBase_Cmb = New System.Windows.Forms.Label()
        Me.DriveTypeBase_cmb = New System.Windows.Forms.Label()
        Me.MachineTypeBase_cmb = New System.Windows.Forms.Label()
        Me.NumberofStopsTotalBase_cmb = New System.Windows.Forms.Label()
        Me.NumberofStopsFrontBase_cmb = New System.Windows.Forms.Label()
        Me.NumberofStopsRearBase_cmb = New System.Windows.Forms.Label()
        Me.SpeedNewBase_cmb = New System.Windows.Forms.Label()
        Me.CapacityNewBase_cmb = New System.Windows.Forms.Label()
        Me.DestinationBase_lbl = New System.Windows.Forms.Label()
        Me.PitDepthBase_lbl = New System.Windows.Forms.Label()
        Me.TravelBase_lbl = New System.Windows.Forms.Label()
        Me.TopFloorToOverheadBase_lbl = New System.Windows.Forms.Label()
        Me.RopingNewBase_lbl = New System.Windows.Forms.Label()
        Me.DriveTypeBase_lbl = New System.Windows.Forms.Label()
        Me.MachineTypeBase_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsTotalBase_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsFrontBase_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsRearBase_lbl = New System.Windows.Forms.Label()
        Me.SpeedNewBase_lbl = New System.Windows.Forms.Label()
        Me.CapacityNewBase_lbl = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.CarTab = New System.Windows.Forms.TabPage()
        Me.CarData_fra = New System.Windows.Forms.GroupBox()
        Me.Torque_fra = New System.Windows.Forms.GroupBox()
        Me.NominalMotorRPM_txt = New System.Windows.Forms.TextBox()
        Me.ArmatureFullLoadVoltageVFLU_txt = New System.Windows.Forms.TextBox()
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl = New System.Windows.Forms.Label()
        Me.ArmatureFullLoadVoltageVFLU_lbl = New System.Windows.Forms.Label()
        Me.FullLoadCurrentIDC1_txt = New System.Windows.Forms.TextBox()
        Me.FullLoadCurrentIDC1Amps_lbl = New System.Windows.Forms.Label()
        Me.FullLoadCurrentIDC1_lbl = New System.Windows.Forms.Label()
        Me.CwtSheaveQty_Cmb = New System.Windows.Forms.ComboBox()
        Me.CwtSheaveQty_lbl = New System.Windows.Forms.Label()
        Me.CarSheaveQty_Cmb = New System.Windows.Forms.ComboBox()
        Me.CarSheaveQty_lbl = New System.Windows.Forms.Label()
        Me.Compensation_cmb = New System.Windows.Forms.ComboBox()
        Me.Compensation_lbl = New System.Windows.Forms.Label()
        Me.HoistRopeSizeIn_lbl = New System.Windows.Forms.Label()
        Me.CarToCwtRopeDrop_txt = New System.Windows.Forms.TextBox()
        Me.CarToCwtRopeDrop_lbl = New System.Windows.Forms.Label()
        Me.CarToCwtRopeDropIn_lbl = New System.Windows.Forms.Label()
        Me.HoistRopeQty_Cmb = New System.Windows.Forms.ComboBox()
        Me.HoistRopeSize_Cmb = New System.Windows.Forms.ComboBox()
        Me.HoistRopeQty_lbl = New System.Windows.Forms.Label()
        Me.HoistRopeSize_lbl = New System.Windows.Forms.Label()
        Me.BrakeType_cmb = New System.Windows.Forms.ComboBox()
        Me.BrakeType_lbl = New System.Windows.Forms.Label()
        Me.NominalMotorRPM_lbl = New System.Windows.Forms.Label()
        Me.ExistingMachineSheaveDia_cmb = New System.Windows.Forms.ComboBox()
        Me.ExistingMachineSheaveDia_lbl = New System.Windows.Forms.Label()
        Me.ExistingMachineSheaveDiaIn_lbl = New System.Windows.Forms.Label()
        Me.ExpandCollapseTorqueFrame_btn = New System.Windows.Forms.Button()
        Me.MachineModelExisting_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineVendorExisting_Cmb = New System.Windows.Forms.ComboBox()
        Me.MachineModelExisting_lbl = New System.Windows.Forms.Label()
        Me.MachineVendorExisting_lbl = New System.Windows.Forms.Label()
        Me.GeneralInformation_fra = New System.Windows.Forms.GroupBox()
        Me.SpeedExisting_cmb = New System.Windows.Forms.ComboBox()
        Me.SpeedExisting_lbl = New System.Windows.Forms.Label()
        Me.CapacityExisting_cmb = New System.Windows.Forms.ComboBox()
        Me.CapacityExisting_lbl = New System.Windows.Forms.Label()
        Me.ChangeInSpeed_chk = New System.Windows.Forms.CheckBox()
        Me.ChangeInCapacity_chk = New System.Windows.Forms.CheckBox()
        Me.TravelExisting_txt = New System.Windows.Forms.TextBox()
        Me.TravelExisting_lbl = New System.Windows.Forms.Label()
        Me.ChangeInTravel_chk = New System.Windows.Forms.CheckBox()
        Me.Destination_cmb = New System.Windows.Forms.ComboBox()
        Me.Destination_lbl = New System.Windows.Forms.Label()
        Me.GatewayReviewRequired_chk = New System.Windows.Forms.CheckBox()
        Me.ExpensesPerDayDetails_btn = New System.Windows.Forms.Button()
        Me.ExpensesPerDay_txt = New System.Windows.Forms.TextBox()
        Me.ExpensesPerDay_lbl = New System.Windows.Forms.Label()
        Me.Bonds_txt = New System.Windows.Forms.TextBox()
        Me.Bonds_lbl = New System.Windows.Forms.Label()
        Me.ShortFloorOperation_chk = New System.Windows.Forms.CheckBox()
        Me.Permits_txt = New System.Windows.Forms.TextBox()
        Me.Permits_lbl = New System.Windows.Forms.Label()
        Me.PEStampRequired_cmb = New System.Windows.Forms.ComboBox()
        Me.PEStampRequired_lbl = New System.Windows.Forms.Label()
        Me.OriginalGONumberAvailable_cmb = New System.Windows.Forms.ComboBox()
        Me.OriginalGOnumber_txt = New System.Windows.Forms.TextBox()
        Me.OriginalGONumberAvailable_lbl = New System.Windows.Forms.Label()
        Me.OriginalGOnumber_lbl = New System.Windows.Forms.Label()
        Me.ExistingControlModel_lst = New System.Windows.Forms.ComboBox()
        Me.ExistingControlVendor_lst = New System.Windows.Forms.ComboBox()
        Me.ExistingControlModel_lbl = New System.Windows.Forms.Label()
        Me.ExistingControlVendor_lbl = New System.Windows.Forms.Label()
        Me.BankCompleteDate_txt = New System.Windows.Forms.DateTimePicker()
        Me.DTRequestedShipDate = New System.Windows.Forms.DateTimePicker()
        Me.lblBankCompleteDate = New System.Windows.Forms.Label()
        Me.lblRequestedShipDate = New System.Windows.Forms.Label()
        Me.FixtureFinish_cmb = New System.Windows.Forms.ComboBox()
        Me.FixtureFinish_lbl = New System.Windows.Forms.Label()
        Me.RiserQtyFront_Cmb = New System.Windows.Forms.ComboBox()
        Me.RiserQtyRear_Cmb = New System.Windows.Forms.ComboBox()
        Me.FinalRisers_lbl = New System.Windows.Forms.Label()
        Me.RiserQtyFront_lbl = New System.Windows.Forms.Label()
        Me.RiserQtyRear_lbl = New System.Windows.Forms.Label()
        Me.PitDepth_txt = New System.Windows.Forms.TextBox()
        Me.PitDepth_lbl = New System.Windows.Forms.Label()
        Me.TravelNew_txt = New System.Windows.Forms.TextBox()
        Me.TravelNew_lbl = New System.Windows.Forms.Label()
        Me.TopFloorToOverhead_txt = New System.Windows.Forms.TextBox()
        Me.TopFloorToOverhead_lbl = New System.Windows.Forms.Label()
        Me.RopingNew_Cmb = New System.Windows.Forms.ComboBox()
        Me.Roping_lbl = New System.Windows.Forms.Label()
        Me.MachineLocation_Cmb = New System.Windows.Forms.ComboBox()
        Me.MachineLocation_lbl = New System.Windows.Forms.Label()
        Me.HoistMotorRpm_txt = New System.Windows.Forms.TextBox()
        Me.HoistMotorRpm_lbl = New System.Windows.Forms.Label()
        Me.HoistMotorHP_txt = New System.Windows.Forms.TextBox()
        Me.HoistMotorHP_lbl = New System.Windows.Forms.Label()
        Me.CarWeight_txt = New System.Windows.Forms.TextBox()
        Me.CarWeight_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightFtRear_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningHeightInRear_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningWidthFtRear_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningWidthInRear_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningHeightFtRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightInRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthFtRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthInRear_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthInFront_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningWidthFtFront_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningHeightInFront_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningHeightFtFront_txt = New System.Windows.Forms.TextBox()
        Me.CarDoorOpeningWidthInFront_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthFtFront_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningWidthFront_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightFront_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightInFront_lbl = New System.Windows.Forms.Label()
        Me.CarDoorOpeningHeightFtFront_lbl = New System.Windows.Forms.Label()
        Me.Application_lbl = New System.Windows.Forms.Label()
        Me.PowerSupply_cmb = New System.Windows.Forms.ComboBox()
        Me.PowerSupply_lbl = New System.Windows.Forms.Label()
        Me.Application_cmb = New System.Windows.Forms.ComboBox()
        Me.LayoutRequirements_cmb = New System.Windows.Forms.ComboBox()
        Me.LayoutRequirements_lbl = New System.Windows.Forms.Label()
        Me.DoorOperatorTypeRear_lbl = New System.Windows.Forms.Label()
        Me.DoorOperatorTypeFront_cmb = New System.Windows.Forms.ComboBox()
        Me.DoorOperatorTypeFront_lbl = New System.Windows.Forms.Label()
        Me.DoorOperatorTypeRear_cmb = New System.Windows.Forms.ComboBox()
        Me.DriveType_cmb = New System.Windows.Forms.ComboBox()
        Me.DriveType_lbl = New System.Windows.Forms.Label()
        Me.MachineType_cmb = New System.Windows.Forms.ComboBox()
        Me.MachineType_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsTotal_cmb = New System.Windows.Forms.ComboBox()
        Me.NumberofStopsTotal_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsFront_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsRear_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsFront_cmb = New System.Windows.Forms.ComboBox()
        Me.NumberofStopsRear_cmb = New System.Windows.Forms.ComboBox()
        Me.SpeedNew_cmb = New System.Windows.Forms.ComboBox()
        Me.CapacityNew_cmb = New System.Windows.Forms.ComboBox()
        Me.SpeedLabel_lbl = New System.Windows.Forms.Label()
        Me.CapacityLabel_lbl = New System.Windows.Forms.Label()
        Me.ExpandCollapseGeneralInfoFrame_btn = New System.Windows.Forms.Button()
        Me.BillofMaterialsandTaskList_fra = New System.Windows.Forms.GroupBox()
        Me.ExpandAll_cmd = New System.Windows.Forms.Button()
        Me.BillOfMaterials_spr = New FarPoint.Win.Spread.FpSpread()
        Me.BillOfMaterials_spr_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.CollapseAll_cmd = New System.Windows.Forms.Button()
        Me.MDI_pic = New System.Windows.Forms.PictureBox()
        Me.fraHdrJobInfo = New System.Windows.Forms.GroupBox()
        Me.txtHdrBnkLetter = New System.Windows.Forms.TextBox()
        Me.Units_txt = New System.Windows.Forms.TextBox()
        Me.txtHdrEstimateNum = New System.Windows.Forms.TextBox()
        Me.HdrGONum_txt = New System.Windows.Forms.TextBox()
        Me.txtHdrBldgName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHdrEstimateNum = New System.Windows.Forms.Label()
        Me.HdrGONum_lbl = New System.Windows.Forms.Label()
        Me.lblHdrBldgNme = New System.Windows.Forms.Label()
        Me.fraHdrIcons = New System.Windows.Forms.GroupBox()
        Me.btnLaborRates = New System.Windows.Forms.Button()
        Me.btnTorque = New System.Windows.Forms.Button()
        Me.Exit_cmd = New System.Windows.Forms.Button()
        Me.Save_cmd = New System.Windows.Forms.Button()
        Me.CMMain_cmd = New System.Windows.Forms.Button()
        Me.Screen_cmd = New System.Windows.Forms.Button()
        Me.Forms_cmd = New System.Windows.Forms.Button()
        Me.LaborRate_txt = New System.Windows.Forms.TextBox()
        Me.LaborRate_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GeneralInformationBase_fra.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.CarTab.SuspendLayout()
        Me.CarData_fra.SuspendLayout()
        Me.Torque_fra.SuspendLayout()
        Me.GeneralInformation_fra.SuspendLayout()
        Me.BillofMaterialsandTaskList_fra.SuspendLayout()
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MDI_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MDI_pic.SuspendLayout()
        Me.fraHdrJobInfo.SuspendLayout()
        Me.fraHdrIcons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.GeneralInformationBase_fra)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1593, 700)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'GeneralInformationBase_fra
        '
        Me.GeneralInformationBase_fra.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GeneralInformationBase_fra.Controls.Add(Me.DestinationBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.PitDepthBase_txt)
        Me.GeneralInformationBase_fra.Controls.Add(Me.TravelBase_txt)
        Me.GeneralInformationBase_fra.Controls.Add(Me.TopFloorToOverheadBase_txt)
        Me.GeneralInformationBase_fra.Controls.Add(Me.RopingNewBase_Cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.DriveTypeBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.MachineTypeBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsTotalBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsFrontBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsRearBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.SpeedNewBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.CapacityNewBase_cmb)
        Me.GeneralInformationBase_fra.Controls.Add(Me.DestinationBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.PitDepthBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.TravelBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.TopFloorToOverheadBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.RopingNewBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.DriveTypeBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.MachineTypeBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsTotalBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsFrontBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.NumberofStopsRearBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.SpeedNewBase_lbl)
        Me.GeneralInformationBase_fra.Controls.Add(Me.CapacityNewBase_lbl)
        Me.GeneralInformationBase_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralInformationBase_fra.ForeColor = System.Drawing.Color.Green
        Me.GeneralInformationBase_fra.Location = New System.Drawing.Point(1314, 0)
        Me.GeneralInformationBase_fra.Name = "GeneralInformationBase_fra"
        Me.GeneralInformationBase_fra.Size = New System.Drawing.Size(280, 37)
        Me.GeneralInformationBase_fra.TabIndex = 1
        Me.GeneralInformationBase_fra.TabStop = False
        Me.GeneralInformationBase_fra.Text = "Base Value"
        Me.GeneralInformationBase_fra.Visible = False
        '
        'DestinationBase_cmb
        '
        Me.DestinationBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DestinationBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DestinationBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DestinationBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DestinationBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.DestinationBase_cmb.Location = New System.Drawing.Point(142, 292)
        Me.DestinationBase_cmb.Name = "DestinationBase_cmb"
        Me.DestinationBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DestinationBase_cmb.Size = New System.Drawing.Size(134, 16)
        Me.DestinationBase_cmb.TabIndex = 196
        Me.DestinationBase_cmb.Visible = False
        '
        'PitDepthBase_txt
        '
        Me.PitDepthBase_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepthBase_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PitDepthBase_txt.Cursor = System.Windows.Forms.Cursors.Default
        Me.PitDepthBase_txt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PitDepthBase_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepthBase_txt.ForeColor = System.Drawing.Color.YellowGreen
        Me.PitDepthBase_txt.Location = New System.Drawing.Point(142, 266)
        Me.PitDepthBase_txt.Name = "PitDepthBase_txt"
        Me.PitDepthBase_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepthBase_txt.Size = New System.Drawing.Size(134, 16)
        Me.PitDepthBase_txt.TabIndex = 195
        Me.PitDepthBase_txt.Visible = False
        '
        'TravelBase_txt
        '
        Me.TravelBase_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TravelBase_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TravelBase_txt.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelBase_txt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelBase_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelBase_txt.ForeColor = System.Drawing.Color.YellowGreen
        Me.TravelBase_txt.Location = New System.Drawing.Point(142, 242)
        Me.TravelBase_txt.Name = "TravelBase_txt"
        Me.TravelBase_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelBase_txt.Size = New System.Drawing.Size(134, 16)
        Me.TravelBase_txt.TabIndex = 194
        Me.TravelBase_txt.Visible = False
        '
        'TopFloorToOverheadBase_txt
        '
        Me.TopFloorToOverheadBase_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TopFloorToOverheadBase_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TopFloorToOverheadBase_txt.Cursor = System.Windows.Forms.Cursors.Default
        Me.TopFloorToOverheadBase_txt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TopFloorToOverheadBase_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopFloorToOverheadBase_txt.ForeColor = System.Drawing.Color.YellowGreen
        Me.TopFloorToOverheadBase_txt.Location = New System.Drawing.Point(142, 217)
        Me.TopFloorToOverheadBase_txt.Name = "TopFloorToOverheadBase_txt"
        Me.TopFloorToOverheadBase_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopFloorToOverheadBase_txt.Size = New System.Drawing.Size(134, 17)
        Me.TopFloorToOverheadBase_txt.TabIndex = 193
        Me.TopFloorToOverheadBase_txt.Visible = False
        '
        'RopingNewBase_Cmb
        '
        Me.RopingNewBase_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopingNewBase_Cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RopingNewBase_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopingNewBase_Cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopingNewBase_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingNewBase_Cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.RopingNewBase_Cmb.Location = New System.Drawing.Point(142, 193)
        Me.RopingNewBase_Cmb.Name = "RopingNewBase_Cmb"
        Me.RopingNewBase_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNewBase_Cmb.Size = New System.Drawing.Size(134, 16)
        Me.RopingNewBase_Cmb.TabIndex = 192
        Me.RopingNewBase_Cmb.Visible = False
        '
        'DriveTypeBase_cmb
        '
        Me.DriveTypeBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DriveTypeBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DriveTypeBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveTypeBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveTypeBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveTypeBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.DriveTypeBase_cmb.Location = New System.Drawing.Point(142, 165)
        Me.DriveTypeBase_cmb.Name = "DriveTypeBase_cmb"
        Me.DriveTypeBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveTypeBase_cmb.Size = New System.Drawing.Size(134, 15)
        Me.DriveTypeBase_cmb.TabIndex = 191
        Me.DriveTypeBase_cmb.Visible = False
        '
        'MachineTypeBase_cmb
        '
        Me.MachineTypeBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineTypeBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MachineTypeBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineTypeBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineTypeBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineTypeBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.MachineTypeBase_cmb.Location = New System.Drawing.Point(142, 141)
        Me.MachineTypeBase_cmb.Name = "MachineTypeBase_cmb"
        Me.MachineTypeBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineTypeBase_cmb.Size = New System.Drawing.Size(134, 16)
        Me.MachineTypeBase_cmb.TabIndex = 190
        Me.MachineTypeBase_cmb.Visible = False
        '
        'NumberofStopsTotalBase_cmb
        '
        Me.NumberofStopsTotalBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotalBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumberofStopsTotalBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotalBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsTotalBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotalBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsTotalBase_cmb.Location = New System.Drawing.Point(142, 65)
        Me.NumberofStopsTotalBase_cmb.Name = "NumberofStopsTotalBase_cmb"
        Me.NumberofStopsTotalBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotalBase_cmb.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsTotalBase_cmb.TabIndex = 187
        Me.NumberofStopsTotalBase_cmb.Visible = False
        '
        'NumberofStopsFrontBase_cmb
        '
        Me.NumberofStopsFrontBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsFrontBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumberofStopsFrontBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsFrontBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsFrontBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsFrontBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsFrontBase_cmb.Location = New System.Drawing.Point(142, 90)
        Me.NumberofStopsFrontBase_cmb.Name = "NumberofStopsFrontBase_cmb"
        Me.NumberofStopsFrontBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFrontBase_cmb.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsFrontBase_cmb.TabIndex = 188
        Me.NumberofStopsFrontBase_cmb.Visible = False
        '
        'NumberofStopsRearBase_cmb
        '
        Me.NumberofStopsRearBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRearBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumberofStopsRearBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRearBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsRearBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRearBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsRearBase_cmb.Location = New System.Drawing.Point(142, 115)
        Me.NumberofStopsRearBase_cmb.Name = "NumberofStopsRearBase_cmb"
        Me.NumberofStopsRearBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRearBase_cmb.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsRearBase_cmb.TabIndex = 189
        Me.NumberofStopsRearBase_cmb.Visible = False
        '
        'SpeedNewBase_cmb
        '
        Me.SpeedNewBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedNewBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SpeedNewBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedNewBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedNewBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedNewBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.SpeedNewBase_cmb.Location = New System.Drawing.Point(142, 39)
        Me.SpeedNewBase_cmb.Name = "SpeedNewBase_cmb"
        Me.SpeedNewBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedNewBase_cmb.Size = New System.Drawing.Size(134, 17)
        Me.SpeedNewBase_cmb.TabIndex = 186
        Me.SpeedNewBase_cmb.Visible = False
        '
        'CapacityNewBase_cmb
        '
        Me.CapacityNewBase_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityNewBase_cmb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CapacityNewBase_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityNewBase_cmb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CapacityNewBase_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityNewBase_cmb.ForeColor = System.Drawing.Color.YellowGreen
        Me.CapacityNewBase_cmb.Location = New System.Drawing.Point(142, 13)
        Me.CapacityNewBase_cmb.Name = "CapacityNewBase_cmb"
        Me.CapacityNewBase_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityNewBase_cmb.Size = New System.Drawing.Size(134, 17)
        Me.CapacityNewBase_cmb.TabIndex = 185
        Me.CapacityNewBase_cmb.Visible = False
        '
        'DestinationBase_lbl
        '
        Me.DestinationBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DestinationBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DestinationBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DestinationBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.DestinationBase_lbl.Location = New System.Drawing.Point(7, 292)
        Me.DestinationBase_lbl.Name = "DestinationBase_lbl"
        Me.DestinationBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DestinationBase_lbl.Size = New System.Drawing.Size(134, 16)
        Me.DestinationBase_lbl.TabIndex = 184
        Me.DestinationBase_lbl.Text = "Destination"
        Me.DestinationBase_lbl.Visible = False
        '
        'PitDepthBase_lbl
        '
        Me.PitDepthBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepthBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PitDepthBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PitDepthBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepthBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.PitDepthBase_lbl.Location = New System.Drawing.Point(7, 266)
        Me.PitDepthBase_lbl.Name = "PitDepthBase_lbl"
        Me.PitDepthBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepthBase_lbl.Size = New System.Drawing.Size(134, 16)
        Me.PitDepthBase_lbl.TabIndex = 158
        Me.PitDepthBase_lbl.Text = "Pit Depth"
        Me.PitDepthBase_lbl.Visible = False
        '
        'TravelBase_lbl
        '
        Me.TravelBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TravelBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.TravelBase_lbl.Location = New System.Drawing.Point(7, 242)
        Me.TravelBase_lbl.Name = "TravelBase_lbl"
        Me.TravelBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelBase_lbl.Size = New System.Drawing.Size(134, 16)
        Me.TravelBase_lbl.TabIndex = 156
        Me.TravelBase_lbl.Text = "Travel"
        Me.TravelBase_lbl.Visible = False
        '
        'TopFloorToOverheadBase_lbl
        '
        Me.TopFloorToOverheadBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TopFloorToOverheadBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TopFloorToOverheadBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TopFloorToOverheadBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopFloorToOverheadBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.TopFloorToOverheadBase_lbl.Location = New System.Drawing.Point(7, 217)
        Me.TopFloorToOverheadBase_lbl.Name = "TopFloorToOverheadBase_lbl"
        Me.TopFloorToOverheadBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopFloorToOverheadBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.TopFloorToOverheadBase_lbl.TabIndex = 154
        Me.TopFloorToOverheadBase_lbl.Text = "Top floor to overhead"
        Me.TopFloorToOverheadBase_lbl.Visible = False
        '
        'RopingNewBase_lbl
        '
        Me.RopingNewBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RopingNewBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopingNewBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RopingNewBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingNewBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.RopingNewBase_lbl.Location = New System.Drawing.Point(7, 193)
        Me.RopingNewBase_lbl.Name = "RopingNewBase_lbl"
        Me.RopingNewBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNewBase_lbl.Size = New System.Drawing.Size(134, 16)
        Me.RopingNewBase_lbl.TabIndex = 152
        Me.RopingNewBase_lbl.Text = "Roping New"
        Me.RopingNewBase_lbl.Visible = False
        '
        'DriveTypeBase_lbl
        '
        Me.DriveTypeBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DriveTypeBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveTypeBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveTypeBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveTypeBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.DriveTypeBase_lbl.Location = New System.Drawing.Point(7, 165)
        Me.DriveTypeBase_lbl.Name = "DriveTypeBase_lbl"
        Me.DriveTypeBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveTypeBase_lbl.Size = New System.Drawing.Size(134, 15)
        Me.DriveTypeBase_lbl.TabIndex = 106
        Me.DriveTypeBase_lbl.Text = "Drive Type"
        Me.DriveTypeBase_lbl.Visible = False
        '
        'MachineTypeBase_lbl
        '
        Me.MachineTypeBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineTypeBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineTypeBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineTypeBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineTypeBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.MachineTypeBase_lbl.Location = New System.Drawing.Point(7, 141)
        Me.MachineTypeBase_lbl.Name = "MachineTypeBase_lbl"
        Me.MachineTypeBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineTypeBase_lbl.Size = New System.Drawing.Size(134, 16)
        Me.MachineTypeBase_lbl.TabIndex = 104
        Me.MachineTypeBase_lbl.Text = "Machine Type"
        Me.MachineTypeBase_lbl.Visible = False
        '
        'NumberofStopsTotalBase_lbl
        '
        Me.NumberofStopsTotalBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotalBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotalBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsTotalBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotalBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsTotalBase_lbl.Location = New System.Drawing.Point(7, 65)
        Me.NumberofStopsTotalBase_lbl.Name = "NumberofStopsTotalBase_lbl"
        Me.NumberofStopsTotalBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotalBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsTotalBase_lbl.TabIndex = 45
        Me.NumberofStopsTotalBase_lbl.Text = "Qty of Total Stops "
        Me.NumberofStopsTotalBase_lbl.Visible = False
        '
        'NumberofStopsFrontBase_lbl
        '
        Me.NumberofStopsFrontBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsFrontBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsFrontBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsFrontBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsFrontBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsFrontBase_lbl.Location = New System.Drawing.Point(7, 90)
        Me.NumberofStopsFrontBase_lbl.Name = "NumberofStopsFrontBase_lbl"
        Me.NumberofStopsFrontBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFrontBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsFrontBase_lbl.TabIndex = 46
        Me.NumberofStopsFrontBase_lbl.Text = "Qty of Front Openings "
        Me.NumberofStopsFrontBase_lbl.Visible = False
        '
        'NumberofStopsRearBase_lbl
        '
        Me.NumberofStopsRearBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRearBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRearBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsRearBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRearBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.NumberofStopsRearBase_lbl.Location = New System.Drawing.Point(7, 115)
        Me.NumberofStopsRearBase_lbl.Name = "NumberofStopsRearBase_lbl"
        Me.NumberofStopsRearBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRearBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsRearBase_lbl.TabIndex = 47
        Me.NumberofStopsRearBase_lbl.Text = "Qty of Rear Openings "
        Me.NumberofStopsRearBase_lbl.Visible = False
        '
        'SpeedNewBase_lbl
        '
        Me.SpeedNewBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedNewBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedNewBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedNewBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedNewBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.SpeedNewBase_lbl.Location = New System.Drawing.Point(7, 39)
        Me.SpeedNewBase_lbl.Name = "SpeedNewBase_lbl"
        Me.SpeedNewBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedNewBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.SpeedNewBase_lbl.TabIndex = 41
        Me.SpeedNewBase_lbl.Text = "Speed"
        Me.SpeedNewBase_lbl.Visible = False
        '
        'CapacityNewBase_lbl
        '
        Me.CapacityNewBase_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityNewBase_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityNewBase_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CapacityNewBase_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityNewBase_lbl.ForeColor = System.Drawing.Color.YellowGreen
        Me.CapacityNewBase_lbl.Location = New System.Drawing.Point(7, 13)
        Me.CapacityNewBase_lbl.Name = "CapacityNewBase_lbl"
        Me.CapacityNewBase_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityNewBase_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CapacityNewBase_lbl.TabIndex = 40
        Me.CapacityNewBase_lbl.Text = "Capacity"
        Me.CapacityNewBase_lbl.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.CarTab)
        Me.TabControl1.Location = New System.Drawing.Point(6, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1581, 673)
        Me.TabControl1.TabIndex = 11
        '
        'CarTab
        '
        Me.CarTab.Controls.Add(Me.CarData_fra)
        Me.CarTab.Location = New System.Drawing.Point(4, 25)
        Me.CarTab.Name = "CarTab"
        Me.CarTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CarTab.Size = New System.Drawing.Size(1573, 644)
        Me.CarTab.TabIndex = 2
        Me.CarTab.UseVisualStyleBackColor = True
        '
        'CarData_fra
        '
        Me.CarData_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CarData_fra.Controls.Add(Me.Torque_fra)
        Me.CarData_fra.Controls.Add(Me.GeneralInformation_fra)
        Me.CarData_fra.Controls.Add(Me.BillofMaterialsandTaskList_fra)
        Me.CarData_fra.Location = New System.Drawing.Point(1, -6)
        Me.CarData_fra.Name = "CarData_fra"
        Me.CarData_fra.Size = New System.Drawing.Size(1566, 646)
        Me.CarData_fra.TabIndex = 0
        Me.CarData_fra.TabStop = False
        '
        'Torque_fra
        '
        Me.Torque_fra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Torque_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Torque_fra.Controls.Add(Me.NominalMotorRPM_txt)
        Me.Torque_fra.Controls.Add(Me.ArmatureFullLoadVoltageVFLU_txt)
        Me.Torque_fra.Controls.Add(Me.ArmatureFullLoadVoltageVFLUVolts_lbl)
        Me.Torque_fra.Controls.Add(Me.ArmatureFullLoadVoltageVFLU_lbl)
        Me.Torque_fra.Controls.Add(Me.FullLoadCurrentIDC1_txt)
        Me.Torque_fra.Controls.Add(Me.FullLoadCurrentIDC1Amps_lbl)
        Me.Torque_fra.Controls.Add(Me.FullLoadCurrentIDC1_lbl)
        Me.Torque_fra.Controls.Add(Me.CwtSheaveQty_Cmb)
        Me.Torque_fra.Controls.Add(Me.CwtSheaveQty_lbl)
        Me.Torque_fra.Controls.Add(Me.CarSheaveQty_Cmb)
        Me.Torque_fra.Controls.Add(Me.CarSheaveQty_lbl)
        Me.Torque_fra.Controls.Add(Me.Compensation_cmb)
        Me.Torque_fra.Controls.Add(Me.Compensation_lbl)
        Me.Torque_fra.Controls.Add(Me.HoistRopeSizeIn_lbl)
        Me.Torque_fra.Controls.Add(Me.CarToCwtRopeDrop_txt)
        Me.Torque_fra.Controls.Add(Me.CarToCwtRopeDrop_lbl)
        Me.Torque_fra.Controls.Add(Me.CarToCwtRopeDropIn_lbl)
        Me.Torque_fra.Controls.Add(Me.HoistRopeQty_Cmb)
        Me.Torque_fra.Controls.Add(Me.HoistRopeSize_Cmb)
        Me.Torque_fra.Controls.Add(Me.HoistRopeQty_lbl)
        Me.Torque_fra.Controls.Add(Me.HoistRopeSize_lbl)
        Me.Torque_fra.Controls.Add(Me.BrakeType_cmb)
        Me.Torque_fra.Controls.Add(Me.BrakeType_lbl)
        Me.Torque_fra.Controls.Add(Me.NominalMotorRPM_lbl)
        Me.Torque_fra.Controls.Add(Me.ExistingMachineSheaveDia_cmb)
        Me.Torque_fra.Controls.Add(Me.ExistingMachineSheaveDia_lbl)
        Me.Torque_fra.Controls.Add(Me.ExistingMachineSheaveDiaIn_lbl)
        Me.Torque_fra.Controls.Add(Me.ExpandCollapseTorqueFrame_btn)
        Me.Torque_fra.Controls.Add(Me.MachineModelExisting_cmb)
        Me.Torque_fra.Controls.Add(Me.MachineVendorExisting_Cmb)
        Me.Torque_fra.Controls.Add(Me.MachineModelExisting_lbl)
        Me.Torque_fra.Controls.Add(Me.MachineVendorExisting_lbl)
        Me.Torque_fra.Location = New System.Drawing.Point(5, 229)
        Me.Torque_fra.Name = "Torque_fra"
        Me.Torque_fra.Size = New System.Drawing.Size(1561, 91)
        Me.Torque_fra.TabIndex = 81
        Me.Torque_fra.TabStop = False
        Me.Torque_fra.Text = "   Torque Data"
        '
        'NominalMotorRPM_txt
        '
        Me.NominalMotorRPM_txt.AcceptsReturn = True
        Me.NominalMotorRPM_txt.BackColor = System.Drawing.SystemColors.Window
        Me.NominalMotorRPM_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NominalMotorRPM_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NominalMotorRPM_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NominalMotorRPM_txt.Location = New System.Drawing.Point(412, 14)
        Me.NominalMotorRPM_txt.MaxLength = 0
        Me.NominalMotorRPM_txt.Name = "NominalMotorRPM_txt"
        Me.NominalMotorRPM_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NominalMotorRPM_txt.Size = New System.Drawing.Size(92, 20)
        Me.NominalMotorRPM_txt.TabIndex = 55
        '
        'ArmatureFullLoadVoltageVFLU_txt
        '
        Me.ArmatureFullLoadVoltageVFLU_txt.AcceptsReturn = True
        Me.ArmatureFullLoadVoltageVFLU_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ArmatureFullLoadVoltageVFLU_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ArmatureFullLoadVoltageVFLU_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArmatureFullLoadVoltageVFLU_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ArmatureFullLoadVoltageVFLU_txt.Location = New System.Drawing.Point(1191, 40)
        Me.ArmatureFullLoadVoltageVFLU_txt.MaxLength = 0
        Me.ArmatureFullLoadVoltageVFLU_txt.Name = "ArmatureFullLoadVoltageVFLU_txt"
        Me.ArmatureFullLoadVoltageVFLU_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ArmatureFullLoadVoltageVFLU_txt.Size = New System.Drawing.Size(58, 20)
        Me.ArmatureFullLoadVoltageVFLU_txt.TabIndex = 64
        '
        'ArmatureFullLoadVoltageVFLUVolts_lbl
        '
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Location = New System.Drawing.Point(1254, 43)
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Name = "ArmatureFullLoadVoltageVFLUVolts_lbl"
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Size = New System.Drawing.Size(42, 19)
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.TabIndex = 126
        Me.ArmatureFullLoadVoltageVFLUVolts_lbl.Text = "VOLTS"
        '
        'ArmatureFullLoadVoltageVFLU_lbl
        '
        Me.ArmatureFullLoadVoltageVFLU_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ArmatureFullLoadVoltageVFLU_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ArmatureFullLoadVoltageVFLU_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ArmatureFullLoadVoltageVFLU_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArmatureFullLoadVoltageVFLU_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ArmatureFullLoadVoltageVFLU_lbl.Location = New System.Drawing.Point(1048, 43)
        Me.ArmatureFullLoadVoltageVFLU_lbl.Name = "ArmatureFullLoadVoltageVFLU_lbl"
        Me.ArmatureFullLoadVoltageVFLU_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ArmatureFullLoadVoltageVFLU_lbl.Size = New System.Drawing.Size(145, 19)
        Me.ArmatureFullLoadVoltageVFLU_lbl.TabIndex = 125
        Me.ArmatureFullLoadVoltageVFLU_lbl.Text = "Armature Voltage (VFLU)"
        '
        'FullLoadCurrentIDC1_txt
        '
        Me.FullLoadCurrentIDC1_txt.AcceptsReturn = True
        Me.FullLoadCurrentIDC1_txt.BackColor = System.Drawing.SystemColors.Window
        Me.FullLoadCurrentIDC1_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FullLoadCurrentIDC1_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullLoadCurrentIDC1_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FullLoadCurrentIDC1_txt.Location = New System.Drawing.Point(1191, 14)
        Me.FullLoadCurrentIDC1_txt.MaxLength = 0
        Me.FullLoadCurrentIDC1_txt.Name = "FullLoadCurrentIDC1_txt"
        Me.FullLoadCurrentIDC1_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FullLoadCurrentIDC1_txt.Size = New System.Drawing.Size(58, 20)
        Me.FullLoadCurrentIDC1_txt.TabIndex = 63
        '
        'FullLoadCurrentIDC1Amps_lbl
        '
        Me.FullLoadCurrentIDC1Amps_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FullLoadCurrentIDC1Amps_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FullLoadCurrentIDC1Amps_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FullLoadCurrentIDC1Amps_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullLoadCurrentIDC1Amps_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FullLoadCurrentIDC1Amps_lbl.Location = New System.Drawing.Point(1254, 17)
        Me.FullLoadCurrentIDC1Amps_lbl.Name = "FullLoadCurrentIDC1Amps_lbl"
        Me.FullLoadCurrentIDC1Amps_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FullLoadCurrentIDC1Amps_lbl.Size = New System.Drawing.Size(36, 19)
        Me.FullLoadCurrentIDC1Amps_lbl.TabIndex = 123
        Me.FullLoadCurrentIDC1Amps_lbl.Text = "AMPS"
        '
        'FullLoadCurrentIDC1_lbl
        '
        Me.FullLoadCurrentIDC1_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FullLoadCurrentIDC1_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FullLoadCurrentIDC1_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FullLoadCurrentIDC1_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullLoadCurrentIDC1_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FullLoadCurrentIDC1_lbl.Location = New System.Drawing.Point(1048, 17)
        Me.FullLoadCurrentIDC1_lbl.Name = "FullLoadCurrentIDC1_lbl"
        Me.FullLoadCurrentIDC1_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FullLoadCurrentIDC1_lbl.Size = New System.Drawing.Size(145, 19)
        Me.FullLoadCurrentIDC1_lbl.TabIndex = 122
        Me.FullLoadCurrentIDC1_lbl.Text = "Full Load Current (IDC1)"
        '
        'CwtSheaveQty_Cmb
        '
        Me.CwtSheaveQty_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveQty_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtSheaveQty_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CwtSheaveQty_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveQty_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CwtSheaveQty_Cmb.Location = New System.Drawing.Point(966, 66)
        Me.CwtSheaveQty_Cmb.Name = "CwtSheaveQty_Cmb"
        Me.CwtSheaveQty_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveQty_Cmb.Size = New System.Drawing.Size(58, 21)
        Me.CwtSheaveQty_Cmb.TabIndex = 62
        '
        'CwtSheaveQty_lbl
        '
        Me.CwtSheaveQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CwtSheaveQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CwtSheaveQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CwtSheaveQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CwtSheaveQty_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CwtSheaveQty_lbl.Location = New System.Drawing.Point(796, 69)
        Me.CwtSheaveQty_lbl.Name = "CwtSheaveQty_lbl"
        Me.CwtSheaveQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CwtSheaveQty_lbl.Size = New System.Drawing.Size(168, 15)
        Me.CwtSheaveQty_lbl.TabIndex = 120
        Me.CwtSheaveQty_lbl.Text = "Cwt Overhead Sheave Qty"
        '
        'CarSheaveQty_Cmb
        '
        Me.CarSheaveQty_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveQty_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveQty_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CarSheaveQty_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveQty_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarSheaveQty_Cmb.Location = New System.Drawing.Point(966, 40)
        Me.CarSheaveQty_Cmb.Name = "CarSheaveQty_Cmb"
        Me.CarSheaveQty_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveQty_Cmb.Size = New System.Drawing.Size(58, 21)
        Me.CarSheaveQty_Cmb.TabIndex = 61
        '
        'CarSheaveQty_lbl
        '
        Me.CarSheaveQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarSheaveQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarSheaveQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarSheaveQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarSheaveQty_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarSheaveQty_lbl.Location = New System.Drawing.Point(796, 43)
        Me.CarSheaveQty_lbl.Name = "CarSheaveQty_lbl"
        Me.CarSheaveQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarSheaveQty_lbl.Size = New System.Drawing.Size(168, 15)
        Me.CarSheaveQty_lbl.TabIndex = 118
        Me.CarSheaveQty_lbl.Text = "Car Overhead Sheave Qty"
        '
        'Compensation_cmb
        '
        Me.Compensation_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Compensation_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Compensation_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Compensation_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Compensation_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Compensation_cmb.Location = New System.Drawing.Point(932, 14)
        Me.Compensation_cmb.Name = "Compensation_cmb"
        Me.Compensation_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Compensation_cmb.Size = New System.Drawing.Size(92, 21)
        Me.Compensation_cmb.TabIndex = 60
        '
        'Compensation_lbl
        '
        Me.Compensation_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Compensation_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Compensation_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Compensation_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Compensation_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Compensation_lbl.Location = New System.Drawing.Point(796, 17)
        Me.Compensation_lbl.Name = "Compensation_lbl"
        Me.Compensation_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Compensation_lbl.Size = New System.Drawing.Size(134, 17)
        Me.Compensation_lbl.TabIndex = 116
        Me.Compensation_lbl.Text = "Compensation"
        '
        'HoistRopeSizeIn_lbl
        '
        Me.HoistRopeSizeIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistRopeSizeIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistRopeSizeIn_lbl.Enabled = False
        Me.HoistRopeSizeIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistRopeSizeIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistRopeSizeIn_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistRopeSizeIn_lbl.Location = New System.Drawing.Point(757, 43)
        Me.HoistRopeSizeIn_lbl.Name = "HoistRopeSizeIn_lbl"
        Me.HoistRopeSizeIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistRopeSizeIn_lbl.Size = New System.Drawing.Size(17, 19)
        Me.HoistRopeSizeIn_lbl.TabIndex = 102
        Me.HoistRopeSizeIn_lbl.Text = "In"
        '
        'CarToCwtRopeDrop_txt
        '
        Me.CarToCwtRopeDrop_txt.AcceptsReturn = True
        Me.CarToCwtRopeDrop_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarToCwtRopeDrop_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarToCwtRopeDrop_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarToCwtRopeDrop_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarToCwtRopeDrop_txt.Location = New System.Drawing.Point(662, 66)
        Me.CarToCwtRopeDrop_txt.MaxLength = 0
        Me.CarToCwtRopeDrop_txt.Name = "CarToCwtRopeDrop_txt"
        Me.CarToCwtRopeDrop_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarToCwtRopeDrop_txt.Size = New System.Drawing.Size(92, 20)
        Me.CarToCwtRopeDrop_txt.TabIndex = 59
        '
        'CarToCwtRopeDrop_lbl
        '
        Me.CarToCwtRopeDrop_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarToCwtRopeDrop_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarToCwtRopeDrop_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarToCwtRopeDrop_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarToCwtRopeDrop_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarToCwtRopeDrop_lbl.Location = New System.Drawing.Point(526, 69)
        Me.CarToCwtRopeDrop_lbl.Name = "CarToCwtRopeDrop_lbl"
        Me.CarToCwtRopeDrop_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarToCwtRopeDrop_lbl.Size = New System.Drawing.Size(134, 19)
        Me.CarToCwtRopeDrop_lbl.TabIndex = 101
        Me.CarToCwtRopeDrop_lbl.Text = "Car to Cwt Rope Drop"
        '
        'CarToCwtRopeDropIn_lbl
        '
        Me.CarToCwtRopeDropIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarToCwtRopeDropIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarToCwtRopeDropIn_lbl.Enabled = False
        Me.CarToCwtRopeDropIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarToCwtRopeDropIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarToCwtRopeDropIn_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarToCwtRopeDropIn_lbl.Location = New System.Drawing.Point(757, 69)
        Me.CarToCwtRopeDropIn_lbl.Name = "CarToCwtRopeDropIn_lbl"
        Me.CarToCwtRopeDropIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarToCwtRopeDropIn_lbl.Size = New System.Drawing.Size(17, 19)
        Me.CarToCwtRopeDropIn_lbl.TabIndex = 100
        Me.CarToCwtRopeDropIn_lbl.Text = "In"
        '
        'HoistRopeQty_Cmb
        '
        Me.HoistRopeQty_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.HoistRopeQty_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistRopeQty_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HoistRopeQty_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistRopeQty_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistRopeQty_Cmb.Location = New System.Drawing.Point(662, 14)
        Me.HoistRopeQty_Cmb.Name = "HoistRopeQty_Cmb"
        Me.HoistRopeQty_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistRopeQty_Cmb.Size = New System.Drawing.Size(92, 21)
        Me.HoistRopeQty_Cmb.TabIndex = 57
        '
        'HoistRopeSize_Cmb
        '
        Me.HoistRopeSize_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.HoistRopeSize_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistRopeSize_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HoistRopeSize_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistRopeSize_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistRopeSize_Cmb.Location = New System.Drawing.Point(662, 40)
        Me.HoistRopeSize_Cmb.Name = "HoistRopeSize_Cmb"
        Me.HoistRopeSize_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistRopeSize_Cmb.Size = New System.Drawing.Size(92, 21)
        Me.HoistRopeSize_Cmb.TabIndex = 58
        '
        'HoistRopeQty_lbl
        '
        Me.HoistRopeQty_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistRopeQty_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistRopeQty_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistRopeQty_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistRopeQty_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistRopeQty_lbl.Location = New System.Drawing.Point(526, 17)
        Me.HoistRopeQty_lbl.Name = "HoistRopeQty_lbl"
        Me.HoistRopeQty_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistRopeQty_lbl.Size = New System.Drawing.Size(134, 17)
        Me.HoistRopeQty_lbl.TabIndex = 98
        Me.HoistRopeQty_lbl.Text = "Hoist Rope Qty"
        '
        'HoistRopeSize_lbl
        '
        Me.HoistRopeSize_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistRopeSize_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistRopeSize_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistRopeSize_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistRopeSize_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistRopeSize_lbl.Location = New System.Drawing.Point(526, 43)
        Me.HoistRopeSize_lbl.Name = "HoistRopeSize_lbl"
        Me.HoistRopeSize_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistRopeSize_lbl.Size = New System.Drawing.Size(134, 15)
        Me.HoistRopeSize_lbl.TabIndex = 97
        Me.HoistRopeSize_lbl.Text = "Hoist Rope Size"
        '
        'BrakeType_cmb
        '
        Me.BrakeType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.BrakeType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.BrakeType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BrakeType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrakeType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BrakeType_cmb.Location = New System.Drawing.Point(412, 40)
        Me.BrakeType_cmb.Name = "BrakeType_cmb"
        Me.BrakeType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BrakeType_cmb.Size = New System.Drawing.Size(92, 21)
        Me.BrakeType_cmb.TabIndex = 56
        '
        'BrakeType_lbl
        '
        Me.BrakeType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BrakeType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BrakeType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BrakeType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrakeType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BrakeType_lbl.Location = New System.Drawing.Point(276, 43)
        Me.BrakeType_lbl.Name = "BrakeType_lbl"
        Me.BrakeType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BrakeType_lbl.Size = New System.Drawing.Size(134, 15)
        Me.BrakeType_lbl.TabIndex = 87
        Me.BrakeType_lbl.Text = "Brake Type"
        '
        'NominalMotorRPM_lbl
        '
        Me.NominalMotorRPM_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NominalMotorRPM_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NominalMotorRPM_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NominalMotorRPM_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NominalMotorRPM_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NominalMotorRPM_lbl.Location = New System.Drawing.Point(276, 17)
        Me.NominalMotorRPM_lbl.Name = "NominalMotorRPM_lbl"
        Me.NominalMotorRPM_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NominalMotorRPM_lbl.Size = New System.Drawing.Size(134, 18)
        Me.NominalMotorRPM_lbl.TabIndex = 77
        Me.NominalMotorRPM_lbl.Text = "Nominal Motor RPM"
        '
        'ExistingMachineSheaveDia_cmb
        '
        Me.ExistingMachineSheaveDia_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingMachineSheaveDia_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingMachineSheaveDia_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingMachineSheaveDia_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingMachineSheaveDia_cmb.Location = New System.Drawing.Point(169, 66)
        Me.ExistingMachineSheaveDia_cmb.Name = "ExistingMachineSheaveDia_cmb"
        Me.ExistingMachineSheaveDia_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingMachineSheaveDia_cmb.Size = New System.Drawing.Size(81, 21)
        Me.ExistingMachineSheaveDia_cmb.TabIndex = 53
        Me.ExistingMachineSheaveDia_cmb.Tag = "1"
        '
        'ExistingMachineSheaveDia_lbl
        '
        Me.ExistingMachineSheaveDia_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingMachineSheaveDia_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingMachineSheaveDia_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingMachineSheaveDia_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingMachineSheaveDia_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingMachineSheaveDia_lbl.Location = New System.Drawing.Point(8, 69)
        Me.ExistingMachineSheaveDia_lbl.Name = "ExistingMachineSheaveDia_lbl"
        Me.ExistingMachineSheaveDia_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingMachineSheaveDia_lbl.Size = New System.Drawing.Size(158, 19)
        Me.ExistingMachineSheaveDia_lbl.TabIndex = 73
        Me.ExistingMachineSheaveDia_lbl.Text = "Existing Mach. Sheave Dia."
        '
        'ExistingMachineSheaveDiaIn_lbl
        '
        Me.ExistingMachineSheaveDiaIn_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingMachineSheaveDiaIn_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingMachineSheaveDiaIn_lbl.Enabled = False
        Me.ExistingMachineSheaveDiaIn_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingMachineSheaveDiaIn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingMachineSheaveDiaIn_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingMachineSheaveDiaIn_lbl.Location = New System.Drawing.Point(252, 69)
        Me.ExistingMachineSheaveDiaIn_lbl.Name = "ExistingMachineSheaveDiaIn_lbl"
        Me.ExistingMachineSheaveDiaIn_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingMachineSheaveDiaIn_lbl.Size = New System.Drawing.Size(12, 15)
        Me.ExistingMachineSheaveDiaIn_lbl.TabIndex = 72
        Me.ExistingMachineSheaveDiaIn_lbl.Text = "In"
        Me.ExistingMachineSheaveDiaIn_lbl.Visible = False
        '
        'ExpandCollapseTorqueFrame_btn
        '
        Me.ExpandCollapseTorqueFrame_btn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ExpandCollapseTorqueFrame_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExpandCollapseTorqueFrame_btn.Location = New System.Drawing.Point(1, -1)
        Me.ExpandCollapseTorqueFrame_btn.Name = "ExpandCollapseTorqueFrame_btn"
        Me.ExpandCollapseTorqueFrame_btn.Size = New System.Drawing.Size(20, 19)
        Me.ExpandCollapseTorqueFrame_btn.TabIndex = 69
        Me.ExpandCollapseTorqueFrame_btn.UseVisualStyleBackColor = True
        '
        'MachineModelExisting_cmb
        '
        Me.MachineModelExisting_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineModelExisting_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineModelExisting_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineModelExisting_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineModelExisting_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineModelExisting_cmb.Location = New System.Drawing.Point(144, 40)
        Me.MachineModelExisting_cmb.Name = "MachineModelExisting_cmb"
        Me.MachineModelExisting_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineModelExisting_cmb.Size = New System.Drawing.Size(119, 21)
        Me.MachineModelExisting_cmb.Sorted = True
        Me.MachineModelExisting_cmb.TabIndex = 52
        '
        'MachineVendorExisting_Cmb
        '
        Me.MachineVendorExisting_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineVendorExisting_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineVendorExisting_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineVendorExisting_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineVendorExisting_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineVendorExisting_Cmb.Location = New System.Drawing.Point(144, 14)
        Me.MachineVendorExisting_Cmb.Name = "MachineVendorExisting_Cmb"
        Me.MachineVendorExisting_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineVendorExisting_Cmb.Size = New System.Drawing.Size(119, 21)
        Me.MachineVendorExisting_Cmb.Sorted = True
        Me.MachineVendorExisting_Cmb.TabIndex = 51
        '
        'MachineModelExisting_lbl
        '
        Me.MachineModelExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineModelExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineModelExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineModelExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineModelExisting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineModelExisting_lbl.Location = New System.Drawing.Point(8, 43)
        Me.MachineModelExisting_lbl.Name = "MachineModelExisting_lbl"
        Me.MachineModelExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineModelExisting_lbl.Size = New System.Drawing.Size(134, 16)
        Me.MachineModelExisting_lbl.TabIndex = 68
        Me.MachineModelExisting_lbl.Text = "Existing Mach. Model"
        '
        'MachineVendorExisting_lbl
        '
        Me.MachineVendorExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineVendorExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineVendorExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineVendorExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineVendorExisting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineVendorExisting_lbl.Location = New System.Drawing.Point(8, 17)
        Me.MachineVendorExisting_lbl.Name = "MachineVendorExisting_lbl"
        Me.MachineVendorExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineVendorExisting_lbl.Size = New System.Drawing.Size(134, 16)
        Me.MachineVendorExisting_lbl.TabIndex = 67
        Me.MachineVendorExisting_lbl.Text = "Existing Mach. Vendor"
        '
        'GeneralInformation_fra
        '
        Me.GeneralInformation_fra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneralInformation_fra.BackColor = System.Drawing.SystemColors.Window
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedExisting_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedExisting_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityExisting_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityExisting_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ChangeInSpeed_chk)
        Me.GeneralInformation_fra.Controls.Add(Me.ChangeInCapacity_chk)
        Me.GeneralInformation_fra.Controls.Add(Me.TravelExisting_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.TravelExisting_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ChangeInTravel_chk)
        Me.GeneralInformation_fra.Controls.Add(Me.Destination_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.Destination_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.GatewayReviewRequired_chk)
        Me.GeneralInformation_fra.Controls.Add(Me.ExpensesPerDayDetails_btn)
        Me.GeneralInformation_fra.Controls.Add(Me.ExpensesPerDay_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.ExpensesPerDay_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.Bonds_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.Bonds_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ShortFloorOperation_chk)
        Me.GeneralInformation_fra.Controls.Add(Me.Permits_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.Permits_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.PEStampRequired_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.PEStampRequired_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.OriginalGONumberAvailable_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.OriginalGOnumber_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.OriginalGONumberAvailable_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.OriginalGOnumber_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ExistingControlModel_lst)
        Me.GeneralInformation_fra.Controls.Add(Me.ExistingControlVendor_lst)
        Me.GeneralInformation_fra.Controls.Add(Me.ExistingControlModel_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ExistingControlVendor_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.BankCompleteDate_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.DTRequestedShipDate)
        Me.GeneralInformation_fra.Controls.Add(Me.lblBankCompleteDate)
        Me.GeneralInformation_fra.Controls.Add(Me.lblRequestedShipDate)
        Me.GeneralInformation_fra.Controls.Add(Me.FixtureFinish_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.FixtureFinish_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyFront_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyRear_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.FinalRisers_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.PitDepth_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.PitDepth_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.TravelNew_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.TravelNew_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.TopFloorToOverhead_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.TopFloorToOverhead_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RopingNew_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.Roping_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.MachineLocation_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.MachineLocation_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.HoistMotorRpm_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.HoistMotorRpm_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.HoistMotorHP_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.HoistMotorHP_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarWeight_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarWeight_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightFtRear_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightInRear_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthFtRear_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthInRear_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightFtRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightInRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthFtRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthInRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthInFront_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthFtFront_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightInFront_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightFtFront_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthInFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthFtFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningWidthFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightInFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CarDoorOpeningHeightFtFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.Application_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.PowerSupply_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.PowerSupply_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.Application_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.LayoutRequirements_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.LayoutRequirements_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.DoorOperatorTypeRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.DoorOperatorTypeFront_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.DoorOperatorTypeFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.DoorOperatorTypeRear_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.DriveType_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.DriveType_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.MachineType_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.MachineType_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsTotal_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsTotal_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsFront_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsRear_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedNew_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityNew_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedLabel_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityLabel_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.ExpandCollapseGeneralInfoFrame_btn)
        Me.GeneralInformation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralInformation_fra.Location = New System.Drawing.Point(5, 11)
        Me.GeneralInformation_fra.Name = "GeneralInformation_fra"
        Me.GeneralInformation_fra.Size = New System.Drawing.Size(1561, 218)
        Me.GeneralInformation_fra.TabIndex = 25
        Me.GeneralInformation_fra.TabStop = False
        Me.GeneralInformation_fra.Text = "   General Information"
        '
        'SpeedExisting_cmb
        '
        Me.SpeedExisting_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedExisting_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedExisting_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpeedExisting_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedExisting_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedExisting_cmb.Location = New System.Drawing.Point(144, 141)
        Me.SpeedExisting_cmb.Name = "SpeedExisting_cmb"
        Me.SpeedExisting_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedExisting_cmb.Size = New System.Drawing.Size(92, 21)
        Me.SpeedExisting_cmb.TabIndex = 5
        '
        'SpeedExisting_lbl
        '
        Me.SpeedExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedExisting_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedExisting_lbl.Location = New System.Drawing.Point(40, 143)
        Me.SpeedExisting_lbl.Name = "SpeedExisting_lbl"
        Me.SpeedExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedExisting_lbl.Size = New System.Drawing.Size(101, 17)
        Me.SpeedExisting_lbl.TabIndex = 191
        Me.SpeedExisting_lbl.Text = "Existing Speed"
        '
        'CapacityExisting_cmb
        '
        Me.CapacityExisting_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityExisting_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityExisting_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityExisting_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityExisting_cmb.Location = New System.Drawing.Point(144, 66)
        Me.CapacityExisting_cmb.Name = "CapacityExisting_cmb"
        Me.CapacityExisting_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityExisting_cmb.Size = New System.Drawing.Size(92, 21)
        Me.CapacityExisting_cmb.TabIndex = 2
        '
        'CapacityExisting_lbl
        '
        Me.CapacityExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CapacityExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityExisting_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityExisting_lbl.Location = New System.Drawing.Point(40, 69)
        Me.CapacityExisting_lbl.Name = "CapacityExisting_lbl"
        Me.CapacityExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityExisting_lbl.Size = New System.Drawing.Size(101, 17)
        Me.CapacityExisting_lbl.TabIndex = 189
        Me.CapacityExisting_lbl.Text = "Existing Capacity"
        '
        'ChangeInSpeed_chk
        '
        Me.ChangeInSpeed_chk.BackColor = System.Drawing.SystemColors.Window
        Me.ChangeInSpeed_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChangeInSpeed_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChangeInSpeed_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ChangeInSpeed_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeInSpeed_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChangeInSpeed_chk.Location = New System.Drawing.Point(8, 119)
        Me.ChangeInSpeed_chk.Name = "ChangeInSpeed_chk"
        Me.ChangeInSpeed_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChangeInSpeed_chk.Size = New System.Drawing.Size(227, 15)
        Me.ChangeInSpeed_chk.TabIndex = 4
        Me.ChangeInSpeed_chk.Text = "Change in Speed"
        Me.ChangeInSpeed_chk.UseVisualStyleBackColor = False
        '
        'ChangeInCapacity_chk
        '
        Me.ChangeInCapacity_chk.BackColor = System.Drawing.SystemColors.Window
        Me.ChangeInCapacity_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChangeInCapacity_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChangeInCapacity_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ChangeInCapacity_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeInCapacity_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChangeInCapacity_chk.Location = New System.Drawing.Point(8, 43)
        Me.ChangeInCapacity_chk.Name = "ChangeInCapacity_chk"
        Me.ChangeInCapacity_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChangeInCapacity_chk.Size = New System.Drawing.Size(227, 15)
        Me.ChangeInCapacity_chk.TabIndex = 1
        Me.ChangeInCapacity_chk.Text = "Change in Capacity"
        Me.ChangeInCapacity_chk.UseVisualStyleBackColor = False
        '
        'TravelExisting_txt
        '
        Me.TravelExisting_txt.AcceptsReturn = True
        Me.TravelExisting_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TravelExisting_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TravelExisting_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelExisting_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelExisting_txt.Location = New System.Drawing.Point(412, 91)
        Me.TravelExisting_txt.MaxLength = 0
        Me.TravelExisting_txt.Name = "TravelExisting_txt"
        Me.TravelExisting_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelExisting_txt.Size = New System.Drawing.Size(92, 20)
        Me.TravelExisting_txt.TabIndex = 11
        Me.TravelExisting_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TravelExisting_lbl
        '
        Me.TravelExisting_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TravelExisting_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelExisting_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelExisting_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelExisting_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TravelExisting_lbl.Location = New System.Drawing.Point(309, 94)
        Me.TravelExisting_lbl.Name = "TravelExisting_lbl"
        Me.TravelExisting_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelExisting_lbl.Size = New System.Drawing.Size(101, 16)
        Me.TravelExisting_lbl.TabIndex = 185
        Me.TravelExisting_lbl.Text = "Existing Travel"
        '
        'ChangeInTravel_chk
        '
        Me.ChangeInTravel_chk.BackColor = System.Drawing.SystemColors.Window
        Me.ChangeInTravel_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChangeInTravel_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChangeInTravel_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ChangeInTravel_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeInTravel_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChangeInTravel_chk.Location = New System.Drawing.Point(277, 68)
        Me.ChangeInTravel_chk.Name = "ChangeInTravel_chk"
        Me.ChangeInTravel_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChangeInTravel_chk.Size = New System.Drawing.Size(227, 15)
        Me.ChangeInTravel_chk.TabIndex = 10
        Me.ChangeInTravel_chk.Text = "Change in Travel"
        Me.ChangeInTravel_chk.UseVisualStyleBackColor = False
        '
        'Destination_cmb
        '
        Me.Destination_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Destination_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Destination_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Destination_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Destination_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Destination_cmb.Location = New System.Drawing.Point(662, 190)
        Me.Destination_cmb.Name = "Destination_cmb"
        Me.Destination_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Destination_cmb.Size = New System.Drawing.Size(119, 21)
        Me.Destination_cmb.TabIndex = 23
        '
        'Destination_lbl
        '
        Me.Destination_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Destination_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Destination_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Destination_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Destination_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Destination_lbl.Location = New System.Drawing.Point(526, 192)
        Me.Destination_lbl.Name = "Destination_lbl"
        Me.Destination_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Destination_lbl.Size = New System.Drawing.Size(134, 16)
        Me.Destination_lbl.TabIndex = 182
        Me.Destination_lbl.Text = "Destination"
        '
        'GatewayReviewRequired_chk
        '
        Me.GatewayReviewRequired_chk.BackColor = System.Drawing.SystemColors.Window
        Me.GatewayReviewRequired_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.GatewayReviewRequired_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.GatewayReviewRequired_chk.Enabled = False
        Me.GatewayReviewRequired_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GatewayReviewRequired_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GatewayReviewRequired_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GatewayReviewRequired_chk.Location = New System.Drawing.Point(526, 167)
        Me.GatewayReviewRequired_chk.Name = "GatewayReviewRequired_chk"
        Me.GatewayReviewRequired_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GatewayReviewRequired_chk.Size = New System.Drawing.Size(227, 15)
        Me.GatewayReviewRequired_chk.TabIndex = 22
        Me.GatewayReviewRequired_chk.Text = "Gateway Review Required"
        Me.GatewayReviewRequired_chk.UseVisualStyleBackColor = False
        '
        'ExpensesPerDayDetails_btn
        '
        Me.ExpensesPerDayDetails_btn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExpensesPerDayDetails_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayDetails_btn.Location = New System.Drawing.Point(1436, 141)
        Me.ExpensesPerDayDetails_btn.Name = "ExpensesPerDayDetails_btn"
        Me.ExpensesPerDayDetails_btn.Size = New System.Drawing.Size(92, 23)
        Me.ExpensesPerDayDetails_btn.TabIndex = 50
        Me.ExpensesPerDayDetails_btn.Text = "Details"
        Me.ExpensesPerDayDetails_btn.UseVisualStyleBackColor = True
        '
        'ExpensesPerDay_txt
        '
        Me.ExpensesPerDay_txt.AcceptsReturn = True
        Me.ExpensesPerDay_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDay_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ExpensesPerDay_txt.Enabled = False
        Me.ExpensesPerDay_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDay_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExpensesPerDay_txt.Location = New System.Drawing.Point(1454, 116)
        Me.ExpensesPerDay_txt.MaxLength = 0
        Me.ExpensesPerDay_txt.Name = "ExpensesPerDay_txt"
        Me.ExpensesPerDay_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDay_txt.Size = New System.Drawing.Size(92, 20)
        Me.ExpensesPerDay_txt.TabIndex = 49
        Me.ExpensesPerDay_txt.Text = " "
        Me.ExpensesPerDay_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDay_lbl
        '
        Me.ExpensesPerDay_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDay_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpensesPerDay_lbl.Enabled = False
        Me.ExpensesPerDay_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExpensesPerDay_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDay_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExpensesPerDay_lbl.Location = New System.Drawing.Point(1318, 119)
        Me.ExpensesPerDay_lbl.Name = "ExpensesPerDay_lbl"
        Me.ExpensesPerDay_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDay_lbl.Size = New System.Drawing.Size(134, 17)
        Me.ExpensesPerDay_lbl.TabIndex = 178
        Me.ExpensesPerDay_lbl.Text = "Expenses per Day"
        '
        'Bonds_txt
        '
        Me.Bonds_txt.AcceptsReturn = True
        Me.Bonds_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Bonds_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Bonds_txt.Enabled = False
        Me.Bonds_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bonds_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Bonds_txt.Location = New System.Drawing.Point(1454, 91)
        Me.Bonds_txt.MaxLength = 0
        Me.Bonds_txt.Name = "Bonds_txt"
        Me.Bonds_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Bonds_txt.Size = New System.Drawing.Size(92, 20)
        Me.Bonds_txt.TabIndex = 48
        Me.Bonds_txt.Text = " "
        Me.Bonds_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Bonds_lbl
        '
        Me.Bonds_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Bonds_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Bonds_lbl.Enabled = False
        Me.Bonds_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Bonds_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bonds_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Bonds_lbl.Location = New System.Drawing.Point(1318, 94)
        Me.Bonds_lbl.Name = "Bonds_lbl"
        Me.Bonds_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Bonds_lbl.Size = New System.Drawing.Size(134, 17)
        Me.Bonds_lbl.TabIndex = 176
        Me.Bonds_lbl.Text = "Bonds"
        '
        'ShortFloorOperation_chk
        '
        Me.ShortFloorOperation_chk.BackColor = System.Drawing.SystemColors.Window
        Me.ShortFloorOperation_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShortFloorOperation_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.ShortFloorOperation_chk.Enabled = False
        Me.ShortFloorOperation_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ShortFloorOperation_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShortFloorOperation_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ShortFloorOperation_chk.Location = New System.Drawing.Point(1317, 45)
        Me.ShortFloorOperation_chk.Name = "ShortFloorOperation_chk"
        Me.ShortFloorOperation_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShortFloorOperation_chk.Size = New System.Drawing.Size(227, 15)
        Me.ShortFloorOperation_chk.TabIndex = 46
        Me.ShortFloorOperation_chk.Text = "Short Floor Operation <14.75"""
        Me.ShortFloorOperation_chk.UseVisualStyleBackColor = False
        '
        'Permits_txt
        '
        Me.Permits_txt.AcceptsReturn = True
        Me.Permits_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Permits_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Permits_txt.Enabled = False
        Me.Permits_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Permits_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Permits_txt.Location = New System.Drawing.Point(1454, 66)
        Me.Permits_txt.MaxLength = 0
        Me.Permits_txt.Name = "Permits_txt"
        Me.Permits_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Permits_txt.Size = New System.Drawing.Size(92, 20)
        Me.Permits_txt.TabIndex = 47
        Me.Permits_txt.Text = " "
        Me.Permits_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Permits_lbl
        '
        Me.Permits_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Permits_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Permits_lbl.Enabled = False
        Me.Permits_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Permits_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Permits_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Permits_lbl.Location = New System.Drawing.Point(1318, 69)
        Me.Permits_lbl.Name = "Permits_lbl"
        Me.Permits_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Permits_lbl.Size = New System.Drawing.Size(134, 17)
        Me.Permits_lbl.TabIndex = 173
        Me.Permits_lbl.Text = "Permit Fee per Car"
        '
        'PEStampRequired_cmb
        '
        Me.PEStampRequired_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.PEStampRequired_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.PEStampRequired_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PEStampRequired_cmb.Enabled = False
        Me.PEStampRequired_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PEStampRequired_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PEStampRequired_cmb.Location = New System.Drawing.Point(1454, 14)
        Me.PEStampRequired_cmb.Name = "PEStampRequired_cmb"
        Me.PEStampRequired_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PEStampRequired_cmb.Size = New System.Drawing.Size(92, 21)
        Me.PEStampRequired_cmb.TabIndex = 45
        '
        'PEStampRequired_lbl
        '
        Me.PEStampRequired_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PEStampRequired_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PEStampRequired_lbl.Enabled = False
        Me.PEStampRequired_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PEStampRequired_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PEStampRequired_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PEStampRequired_lbl.Location = New System.Drawing.Point(1318, 17)
        Me.PEStampRequired_lbl.Name = "PEStampRequired_lbl"
        Me.PEStampRequired_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PEStampRequired_lbl.Size = New System.Drawing.Size(134, 18)
        Me.PEStampRequired_lbl.TabIndex = 171
        Me.PEStampRequired_lbl.Text = "PE Stamp Required"
        '
        'OriginalGONumberAvailable_cmb
        '
        Me.OriginalGONumberAvailable_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGONumberAvailable_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.OriginalGONumberAvailable_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OriginalGONumberAvailable_cmb.Enabled = False
        Me.OriginalGONumberAvailable_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGONumberAvailable_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGONumberAvailable_cmb.Location = New System.Drawing.Point(1184, 166)
        Me.OriginalGONumberAvailable_cmb.Name = "OriginalGONumberAvailable_cmb"
        Me.OriginalGONumberAvailable_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGONumberAvailable_cmb.Size = New System.Drawing.Size(92, 21)
        Me.OriginalGONumberAvailable_cmb.TabIndex = 43
        '
        'OriginalGOnumber_txt
        '
        Me.OriginalGOnumber_txt.AcceptsReturn = True
        Me.OriginalGOnumber_txt.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGOnumber_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OriginalGOnumber_txt.Enabled = False
        Me.OriginalGOnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGOnumber_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGOnumber_txt.Location = New System.Drawing.Point(1184, 190)
        Me.OriginalGOnumber_txt.MaxLength = 6
        Me.OriginalGOnumber_txt.Name = "OriginalGOnumber_txt"
        Me.OriginalGOnumber_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGOnumber_txt.Size = New System.Drawing.Size(92, 20)
        Me.OriginalGOnumber_txt.TabIndex = 44
        Me.OriginalGOnumber_txt.Text = " "
        Me.OriginalGOnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'OriginalGONumberAvailable_lbl
        '
        Me.OriginalGONumberAvailable_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGONumberAvailable_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.OriginalGONumberAvailable_lbl.Enabled = False
        Me.OriginalGONumberAvailable_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OriginalGONumberAvailable_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGONumberAvailable_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGONumberAvailable_lbl.Location = New System.Drawing.Point(1048, 168)
        Me.OriginalGONumberAvailable_lbl.Name = "OriginalGONumberAvailable_lbl"
        Me.OriginalGONumberAvailable_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGONumberAvailable_lbl.Size = New System.Drawing.Size(134, 17)
        Me.OriginalGONumberAvailable_lbl.TabIndex = 169
        Me.OriginalGONumberAvailable_lbl.Text = "Existing Info Available"
        '
        'OriginalGOnumber_lbl
        '
        Me.OriginalGOnumber_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGOnumber_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.OriginalGOnumber_lbl.Enabled = False
        Me.OriginalGOnumber_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OriginalGOnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGOnumber_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OriginalGOnumber_lbl.Location = New System.Drawing.Point(1128, 192)
        Me.OriginalGOnumber_lbl.Name = "OriginalGOnumber_lbl"
        Me.OriginalGOnumber_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGOnumber_lbl.Size = New System.Drawing.Size(54, 17)
        Me.OriginalGOnumber_lbl.TabIndex = 168
        Me.OriginalGOnumber_lbl.Text = "GO #"
        '
        'ExistingControlModel_lst
        '
        Me.ExistingControlModel_lst.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlModel_lst.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlModel_lst.Enabled = False
        Me.ExistingControlModel_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlModel_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingControlModel_lst.Location = New System.Drawing.Point(1184, 141)
        Me.ExistingControlModel_lst.Name = "ExistingControlModel_lst"
        Me.ExistingControlModel_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlModel_lst.Size = New System.Drawing.Size(119, 21)
        Me.ExistingControlModel_lst.Sorted = True
        Me.ExistingControlModel_lst.TabIndex = 42
        '
        'ExistingControlVendor_lst
        '
        Me.ExistingControlVendor_lst.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlVendor_lst.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlVendor_lst.Enabled = False
        Me.ExistingControlVendor_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlVendor_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingControlVendor_lst.Location = New System.Drawing.Point(1184, 116)
        Me.ExistingControlVendor_lst.Name = "ExistingControlVendor_lst"
        Me.ExistingControlVendor_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlVendor_lst.Size = New System.Drawing.Size(119, 21)
        Me.ExistingControlVendor_lst.Sorted = True
        Me.ExistingControlVendor_lst.TabIndex = 41
        '
        'ExistingControlModel_lbl
        '
        Me.ExistingControlModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlModel_lbl.Enabled = False
        Me.ExistingControlModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingControlModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlModel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingControlModel_lbl.Location = New System.Drawing.Point(1048, 143)
        Me.ExistingControlModel_lbl.Name = "ExistingControlModel_lbl"
        Me.ExistingControlModel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlModel_lbl.Size = New System.Drawing.Size(134, 17)
        Me.ExistingControlModel_lbl.TabIndex = 165
        Me.ExistingControlModel_lbl.Text = "Existing Control Model"
        '
        'ExistingControlVendor_lbl
        '
        Me.ExistingControlVendor_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlVendor_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlVendor_lbl.Enabled = False
        Me.ExistingControlVendor_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingControlVendor_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlVendor_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingControlVendor_lbl.Location = New System.Drawing.Point(1048, 119)
        Me.ExistingControlVendor_lbl.Name = "ExistingControlVendor_lbl"
        Me.ExistingControlVendor_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlVendor_lbl.Size = New System.Drawing.Size(134, 17)
        Me.ExistingControlVendor_lbl.TabIndex = 164
        Me.ExistingControlVendor_lbl.Text = "Existing Control Vendor"
        '
        'BankCompleteDate_txt
        '
        Me.BankCompleteDate_txt.Checked = False
        Me.BankCompleteDate_txt.CustomFormat = "MM/dd/yyyy"
        Me.BankCompleteDate_txt.Enabled = False
        Me.BankCompleteDate_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BankCompleteDate_txt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BankCompleteDate_txt.Location = New System.Drawing.Point(1184, 91)
        Me.BankCompleteDate_txt.Name = "BankCompleteDate_txt"
        Me.BankCompleteDate_txt.Size = New System.Drawing.Size(119, 20)
        Me.BankCompleteDate_txt.TabIndex = 40
        '
        'DTRequestedShipDate
        '
        Me.DTRequestedShipDate.Checked = False
        Me.DTRequestedShipDate.CustomFormat = "MM/dd/yyyy"
        Me.DTRequestedShipDate.Enabled = False
        Me.DTRequestedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTRequestedShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTRequestedShipDate.Location = New System.Drawing.Point(1184, 66)
        Me.DTRequestedShipDate.Name = "DTRequestedShipDate"
        Me.DTRequestedShipDate.Size = New System.Drawing.Size(119, 20)
        Me.DTRequestedShipDate.TabIndex = 39
        '
        'lblBankCompleteDate
        '
        Me.lblBankCompleteDate.BackColor = System.Drawing.SystemColors.Window
        Me.lblBankCompleteDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBankCompleteDate.Enabled = False
        Me.lblBankCompleteDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBankCompleteDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankCompleteDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBankCompleteDate.Location = New System.Drawing.Point(1048, 94)
        Me.lblBankCompleteDate.Name = "lblBankCompleteDate"
        Me.lblBankCompleteDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBankCompleteDate.Size = New System.Drawing.Size(134, 17)
        Me.lblBankCompleteDate.TabIndex = 161
        Me.lblBankCompleteDate.Text = "Bank Complete Date"
        '
        'lblRequestedShipDate
        '
        Me.lblRequestedShipDate.BackColor = System.Drawing.SystemColors.Window
        Me.lblRequestedShipDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRequestedShipDate.Enabled = False
        Me.lblRequestedShipDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblRequestedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestedShipDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRequestedShipDate.Location = New System.Drawing.Point(1048, 69)
        Me.lblRequestedShipDate.Name = "lblRequestedShipDate"
        Me.lblRequestedShipDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRequestedShipDate.Size = New System.Drawing.Size(134, 17)
        Me.lblRequestedShipDate.TabIndex = 160
        Me.lblRequestedShipDate.Text = "Delivery Date (NOD)"
        '
        'FixtureFinish_cmb
        '
        Me.FixtureFinish_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.FixtureFinish_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.FixtureFinish_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FixtureFinish_cmb.Enabled = False
        Me.FixtureFinish_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixtureFinish_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FixtureFinish_cmb.Location = New System.Drawing.Point(1184, 40)
        Me.FixtureFinish_cmb.Name = "FixtureFinish_cmb"
        Me.FixtureFinish_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FixtureFinish_cmb.Size = New System.Drawing.Size(119, 21)
        Me.FixtureFinish_cmb.TabIndex = 38
        '
        'FixtureFinish_lbl
        '
        Me.FixtureFinish_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FixtureFinish_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FixtureFinish_lbl.Enabled = False
        Me.FixtureFinish_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FixtureFinish_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixtureFinish_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FixtureFinish_lbl.Location = New System.Drawing.Point(1048, 43)
        Me.FixtureFinish_lbl.Name = "FixtureFinish_lbl"
        Me.FixtureFinish_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FixtureFinish_lbl.Size = New System.Drawing.Size(134, 15)
        Me.FixtureFinish_lbl.TabIndex = 157
        Me.FixtureFinish_lbl.Text = "Fixture Finish"
        '
        'RiserQtyFront_Cmb
        '
        Me.RiserQtyFront_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyFront_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyFront_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RiserQtyFront_Cmb.Enabled = False
        Me.RiserQtyFront_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyFront_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiserQtyFront_Cmb.Location = New System.Drawing.Point(1194, 14)
        Me.RiserQtyFront_Cmb.Name = "RiserQtyFront_Cmb"
        Me.RiserQtyFront_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyFront_Cmb.Size = New System.Drawing.Size(45, 21)
        Me.RiserQtyFront_Cmb.TabIndex = 36
        '
        'RiserQtyRear_Cmb
        '
        Me.RiserQtyRear_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyRear_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyRear_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RiserQtyRear_Cmb.Enabled = False
        Me.RiserQtyRear_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyRear_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiserQtyRear_Cmb.Location = New System.Drawing.Point(1258, 14)
        Me.RiserQtyRear_Cmb.Name = "RiserQtyRear_Cmb"
        Me.RiserQtyRear_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyRear_Cmb.Size = New System.Drawing.Size(45, 21)
        Me.RiserQtyRear_Cmb.TabIndex = 37
        '
        'FinalRisers_lbl
        '
        Me.FinalRisers_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FinalRisers_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FinalRisers_lbl.Enabled = False
        Me.FinalRisers_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FinalRisers_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalRisers_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FinalRisers_lbl.Location = New System.Drawing.Point(1048, 17)
        Me.FinalRisers_lbl.Name = "FinalRisers_lbl"
        Me.FinalRisers_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FinalRisers_lbl.Size = New System.Drawing.Size(134, 15)
        Me.FinalRisers_lbl.TabIndex = 155
        Me.FinalRisers_lbl.Text = "Final Riser Quantity"
        '
        'RiserQtyFront_lbl
        '
        Me.RiserQtyFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyFront_lbl.Enabled = False
        Me.RiserQtyFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RiserQtyFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RiserQtyFront_lbl.Location = New System.Drawing.Point(1184, 17)
        Me.RiserQtyFront_lbl.Name = "RiserQtyFront_lbl"
        Me.RiserQtyFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyFront_lbl.Size = New System.Drawing.Size(9, 15)
        Me.RiserQtyFront_lbl.TabIndex = 154
        Me.RiserQtyFront_lbl.Text = "F"
        '
        'RiserQtyRear_lbl
        '
        Me.RiserQtyRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyRear_lbl.Enabled = False
        Me.RiserQtyRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RiserQtyRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RiserQtyRear_lbl.Location = New System.Drawing.Point(1245, 17)
        Me.RiserQtyRear_lbl.Name = "RiserQtyRear_lbl"
        Me.RiserQtyRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyRear_lbl.Size = New System.Drawing.Size(9, 15)
        Me.RiserQtyRear_lbl.TabIndex = 153
        Me.RiserQtyRear_lbl.Text = "R"
        '
        'PitDepth_txt
        '
        Me.PitDepth_txt.AcceptsReturn = True
        Me.PitDepth_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepth_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PitDepth_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepth_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PitDepth_txt.Location = New System.Drawing.Point(412, 116)
        Me.PitDepth_txt.MaxLength = 0
        Me.PitDepth_txt.Name = "PitDepth_txt"
        Me.PitDepth_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepth_txt.Size = New System.Drawing.Size(92, 20)
        Me.PitDepth_txt.TabIndex = 12
        Me.PitDepth_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PitDepth_lbl
        '
        Me.PitDepth_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepth_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PitDepth_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PitDepth_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepth_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PitDepth_lbl.Location = New System.Drawing.Point(276, 119)
        Me.PitDepth_lbl.Name = "PitDepth_lbl"
        Me.PitDepth_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepth_lbl.Size = New System.Drawing.Size(134, 16)
        Me.PitDepth_lbl.TabIndex = 150
        Me.PitDepth_lbl.Text = "Pit Depth"
        '
        'TravelNew_txt
        '
        Me.TravelNew_txt.AcceptsReturn = True
        Me.TravelNew_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TravelNew_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TravelNew_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelNew_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TravelNew_txt.Location = New System.Drawing.Point(412, 40)
        Me.TravelNew_txt.MaxLength = 0
        Me.TravelNew_txt.Name = "TravelNew_txt"
        Me.TravelNew_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelNew_txt.Size = New System.Drawing.Size(92, 20)
        Me.TravelNew_txt.TabIndex = 9
        Me.TravelNew_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TravelNew_lbl
        '
        Me.TravelNew_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TravelNew_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TravelNew_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TravelNew_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TravelNew_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TravelNew_lbl.Location = New System.Drawing.Point(276, 43)
        Me.TravelNew_lbl.Name = "TravelNew_lbl"
        Me.TravelNew_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TravelNew_lbl.Size = New System.Drawing.Size(134, 16)
        Me.TravelNew_lbl.TabIndex = 148
        Me.TravelNew_lbl.Text = "Travel"
        '
        'TopFloorToOverhead_txt
        '
        Me.TopFloorToOverhead_txt.AcceptsReturn = True
        Me.TopFloorToOverhead_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TopFloorToOverhead_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TopFloorToOverhead_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopFloorToOverhead_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TopFloorToOverhead_txt.Location = New System.Drawing.Point(412, 14)
        Me.TopFloorToOverhead_txt.MaxLength = 0
        Me.TopFloorToOverhead_txt.Name = "TopFloorToOverhead_txt"
        Me.TopFloorToOverhead_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopFloorToOverhead_txt.Size = New System.Drawing.Size(92, 20)
        Me.TopFloorToOverhead_txt.TabIndex = 8
        Me.TopFloorToOverhead_txt.Text = " "
        Me.TopFloorToOverhead_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TopFloorToOverhead_lbl
        '
        Me.TopFloorToOverhead_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TopFloorToOverhead_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TopFloorToOverhead_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TopFloorToOverhead_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopFloorToOverhead_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TopFloorToOverhead_lbl.Location = New System.Drawing.Point(276, 17)
        Me.TopFloorToOverhead_lbl.Name = "TopFloorToOverhead_lbl"
        Me.TopFloorToOverhead_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopFloorToOverhead_lbl.Size = New System.Drawing.Size(134, 17)
        Me.TopFloorToOverhead_lbl.TabIndex = 146
        Me.TopFloorToOverhead_lbl.Text = "Top floor to overhead"
        '
        'RopingNew_Cmb
        '
        Me.RopingNew_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RopingNew_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RopingNew_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RopingNew_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RopingNew_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RopingNew_Cmb.Location = New System.Drawing.Point(662, 141)
        Me.RopingNew_Cmb.Name = "RopingNew_Cmb"
        Me.RopingNew_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNew_Cmb.Size = New System.Drawing.Size(119, 21)
        Me.RopingNew_Cmb.TabIndex = 21
        '
        'Roping_lbl
        '
        Me.Roping_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Roping_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Roping_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Roping_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Roping_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Roping_lbl.Location = New System.Drawing.Point(526, 143)
        Me.Roping_lbl.Name = "Roping_lbl"
        Me.Roping_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Roping_lbl.Size = New System.Drawing.Size(134, 16)
        Me.Roping_lbl.TabIndex = 144
        Me.Roping_lbl.Text = "Roping New"
        '
        'MachineLocation_Cmb
        '
        Me.MachineLocation_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineLocation_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineLocation_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineLocation_Cmb.Enabled = False
        Me.MachineLocation_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineLocation_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineLocation_Cmb.Location = New System.Drawing.Point(662, 116)
        Me.MachineLocation_Cmb.Name = "MachineLocation_Cmb"
        Me.MachineLocation_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineLocation_Cmb.Size = New System.Drawing.Size(119, 21)
        Me.MachineLocation_Cmb.TabIndex = 20
        '
        'MachineLocation_lbl
        '
        Me.MachineLocation_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineLocation_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineLocation_lbl.Enabled = False
        Me.MachineLocation_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineLocation_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineLocation_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineLocation_lbl.Location = New System.Drawing.Point(526, 119)
        Me.MachineLocation_lbl.Name = "MachineLocation_lbl"
        Me.MachineLocation_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineLocation_lbl.Size = New System.Drawing.Size(134, 15)
        Me.MachineLocation_lbl.TabIndex = 142
        Me.MachineLocation_lbl.Text = "Machine Location"
        '
        'HoistMotorRpm_txt
        '
        Me.HoistMotorRpm_txt.AcceptsReturn = True
        Me.HoistMotorRpm_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorRpm_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HoistMotorRpm_txt.Enabled = False
        Me.HoistMotorRpm_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorRpm_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorRpm_txt.Location = New System.Drawing.Point(662, 91)
        Me.HoistMotorRpm_txt.MaxLength = 0
        Me.HoistMotorRpm_txt.Name = "HoistMotorRpm_txt"
        Me.HoistMotorRpm_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorRpm_txt.Size = New System.Drawing.Size(92, 20)
        Me.HoistMotorRpm_txt.TabIndex = 19
        Me.HoistMotorRpm_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HoistMotorRpm_lbl
        '
        Me.HoistMotorRpm_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorRpm_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorRpm_lbl.Enabled = False
        Me.HoistMotorRpm_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorRpm_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorRpm_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistMotorRpm_lbl.Location = New System.Drawing.Point(526, 94)
        Me.HoistMotorRpm_lbl.Name = "HoistMotorRpm_lbl"
        Me.HoistMotorRpm_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorRpm_lbl.Size = New System.Drawing.Size(134, 16)
        Me.HoistMotorRpm_lbl.TabIndex = 140
        Me.HoistMotorRpm_lbl.Text = "Existing Motor RPM"
        '
        'HoistMotorHP_txt
        '
        Me.HoistMotorHP_txt.AcceptsReturn = True
        Me.HoistMotorHP_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorHP_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HoistMotorHP_txt.Enabled = False
        Me.HoistMotorHP_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorHP_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorHP_txt.Location = New System.Drawing.Point(662, 66)
        Me.HoistMotorHP_txt.MaxLength = 0
        Me.HoistMotorHP_txt.Name = "HoistMotorHP_txt"
        Me.HoistMotorHP_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorHP_txt.Size = New System.Drawing.Size(92, 20)
        Me.HoistMotorHP_txt.TabIndex = 18
        Me.HoistMotorHP_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HoistMotorHP_lbl
        '
        Me.HoistMotorHP_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorHP_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorHP_lbl.Enabled = False
        Me.HoistMotorHP_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorHP_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorHP_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistMotorHP_lbl.Location = New System.Drawing.Point(526, 69)
        Me.HoistMotorHP_lbl.Name = "HoistMotorHP_lbl"
        Me.HoistMotorHP_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorHP_lbl.Size = New System.Drawing.Size(134, 16)
        Me.HoistMotorHP_lbl.TabIndex = 138
        Me.HoistMotorHP_lbl.Text = "Motor HP"
        '
        'CarWeight_txt
        '
        Me.CarWeight_txt.AcceptsReturn = True
        Me.CarWeight_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeight_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarWeight_txt.Enabled = False
        Me.CarWeight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeight_txt.Location = New System.Drawing.Point(932, 14)
        Me.CarWeight_txt.MaxLength = 0
        Me.CarWeight_txt.Name = "CarWeight_txt"
        Me.CarWeight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeight_txt.Size = New System.Drawing.Size(92, 20)
        Me.CarWeight_txt.TabIndex = 24
        Me.CarWeight_txt.Text = " "
        Me.CarWeight_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarWeight_lbl
        '
        Me.CarWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarWeight_lbl.Enabled = False
        Me.CarWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarWeight_lbl.Location = New System.Drawing.Point(796, 17)
        Me.CarWeight_lbl.Name = "CarWeight_lbl"
        Me.CarWeight_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeight_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CarWeight_lbl.TabIndex = 134
        Me.CarWeight_lbl.Text = "Car Weight"
        '
        'CarDoorOpeningHeightFtRear_txt
        '
        Me.CarDoorOpeningHeightFtRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightFtRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFtRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightFtRear_txt.Enabled = False
        Me.CarDoorOpeningHeightFtRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightFtRear_txt.Location = New System.Drawing.Point(932, 166)
        Me.CarDoorOpeningHeightFtRear_txt.MaxLength = 0
        Me.CarDoorOpeningHeightFtRear_txt.Name = "CarDoorOpeningHeightFtRear_txt"
        Me.CarDoorOpeningHeightFtRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightFtRear_txt.TabIndex = 33
        Me.CarDoorOpeningHeightFtRear_txt.Text = " "
        Me.CarDoorOpeningHeightFtRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightInRear_txt
        '
        Me.CarDoorOpeningHeightInRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightInRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightInRear_txt.Enabled = False
        Me.CarDoorOpeningHeightInRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightInRear_txt.Location = New System.Drawing.Point(984, 166)
        Me.CarDoorOpeningHeightInRear_txt.MaxLength = 0
        Me.CarDoorOpeningHeightInRear_txt.Name = "CarDoorOpeningHeightInRear_txt"
        Me.CarDoorOpeningHeightInRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightInRear_txt.TabIndex = 34
        Me.CarDoorOpeningHeightInRear_txt.Text = " "
        Me.CarDoorOpeningHeightInRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthFtRear_txt
        '
        Me.CarDoorOpeningWidthFtRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthFtRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthFtRear_txt.Enabled = False
        Me.CarDoorOpeningWidthFtRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthFtRear_txt.Location = New System.Drawing.Point(932, 141)
        Me.CarDoorOpeningWidthFtRear_txt.MaxLength = 0
        Me.CarDoorOpeningWidthFtRear_txt.Name = "CarDoorOpeningWidthFtRear_txt"
        Me.CarDoorOpeningWidthFtRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthFtRear_txt.TabIndex = 31
        Me.CarDoorOpeningWidthFtRear_txt.Text = " "
        Me.CarDoorOpeningWidthFtRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthInRear_txt
        '
        Me.CarDoorOpeningWidthInRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthInRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthInRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthInRear_txt.Enabled = False
        Me.CarDoorOpeningWidthInRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthInRear_txt.Location = New System.Drawing.Point(984, 141)
        Me.CarDoorOpeningWidthInRear_txt.MaxLength = 0
        Me.CarDoorOpeningWidthInRear_txt.Name = "CarDoorOpeningWidthInRear_txt"
        Me.CarDoorOpeningWidthInRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthInRear_txt.TabIndex = 32
        Me.CarDoorOpeningWidthInRear_txt.Text = " "
        Me.CarDoorOpeningWidthInRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightFtRear_lbl
        '
        Me.CarDoorOpeningHeightFtRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFtRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightFtRear_lbl.Enabled = False
        Me.CarDoorOpeningHeightFtRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFtRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFtRear_lbl.Location = New System.Drawing.Point(970, 168)
        Me.CarDoorOpeningHeightFtRear_lbl.Name = "CarDoorOpeningHeightFtRear_lbl"
        Me.CarDoorOpeningHeightFtRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightFtRear_lbl.TabIndex = 132
        Me.CarDoorOpeningHeightFtRear_lbl.Text = "Ft"
        '
        'CarDoorOpeningHeightInRear_lbl
        '
        Me.CarDoorOpeningHeightInRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightInRear_lbl.Enabled = False
        Me.CarDoorOpeningHeightInRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightInRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightInRear_lbl.Location = New System.Drawing.Point(1022, 168)
        Me.CarDoorOpeningHeightInRear_lbl.Name = "CarDoorOpeningHeightInRear_lbl"
        Me.CarDoorOpeningHeightInRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightInRear_lbl.TabIndex = 131
        Me.CarDoorOpeningHeightInRear_lbl.Text = "In"
        '
        'CarDoorOpeningHeightRear_lbl
        '
        Me.CarDoorOpeningHeightRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightRear_lbl.Enabled = False
        Me.CarDoorOpeningHeightRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightRear_lbl.Location = New System.Drawing.Point(796, 168)
        Me.CarDoorOpeningHeightRear_lbl.Name = "CarDoorOpeningHeightRear_lbl"
        Me.CarDoorOpeningHeightRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightRear_lbl.Size = New System.Drawing.Size(134, 19)
        Me.CarDoorOpeningHeightRear_lbl.TabIndex = 130
        Me.CarDoorOpeningHeightRear_lbl.Text = "Rear Door Height"
        '
        'CarDoorOpeningWidthRear_lbl
        '
        Me.CarDoorOpeningWidthRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthRear_lbl.Enabled = False
        Me.CarDoorOpeningWidthRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthRear_lbl.Location = New System.Drawing.Point(796, 143)
        Me.CarDoorOpeningWidthRear_lbl.Name = "CarDoorOpeningWidthRear_lbl"
        Me.CarDoorOpeningWidthRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthRear_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CarDoorOpeningWidthRear_lbl.TabIndex = 129
        Me.CarDoorOpeningWidthRear_lbl.Text = "Rear Door Width"
        '
        'CarDoorOpeningWidthFtRear_lbl
        '
        Me.CarDoorOpeningWidthFtRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthFtRear_lbl.Enabled = False
        Me.CarDoorOpeningWidthFtRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFtRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFtRear_lbl.Location = New System.Drawing.Point(970, 143)
        Me.CarDoorOpeningWidthFtRear_lbl.Name = "CarDoorOpeningWidthFtRear_lbl"
        Me.CarDoorOpeningWidthFtRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthFtRear_lbl.TabIndex = 128
        Me.CarDoorOpeningWidthFtRear_lbl.Text = "Ft"
        '
        'CarDoorOpeningWidthInRear_lbl
        '
        Me.CarDoorOpeningWidthInRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthInRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthInRear_lbl.Enabled = False
        Me.CarDoorOpeningWidthInRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthInRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthInRear_lbl.Location = New System.Drawing.Point(1022, 143)
        Me.CarDoorOpeningWidthInRear_lbl.Name = "CarDoorOpeningWidthInRear_lbl"
        Me.CarDoorOpeningWidthInRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthInRear_lbl.TabIndex = 127
        Me.CarDoorOpeningWidthInRear_lbl.Text = "In"
        '
        'CarDoorOpeningWidthInFront_txt
        '
        Me.CarDoorOpeningWidthInFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthInFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthInFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthInFront_txt.Enabled = False
        Me.CarDoorOpeningWidthInFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthInFront_txt.Location = New System.Drawing.Point(984, 66)
        Me.CarDoorOpeningWidthInFront_txt.MaxLength = 0
        Me.CarDoorOpeningWidthInFront_txt.Name = "CarDoorOpeningWidthInFront_txt"
        Me.CarDoorOpeningWidthInFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthInFront_txt.TabIndex = 27
        Me.CarDoorOpeningWidthInFront_txt.Text = " "
        Me.CarDoorOpeningWidthInFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthFtFront_txt
        '
        Me.CarDoorOpeningWidthFtFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthFtFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthFtFront_txt.Enabled = False
        Me.CarDoorOpeningWidthFtFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthFtFront_txt.Location = New System.Drawing.Point(932, 66)
        Me.CarDoorOpeningWidthFtFront_txt.MaxLength = 0
        Me.CarDoorOpeningWidthFtFront_txt.Name = "CarDoorOpeningWidthFtFront_txt"
        Me.CarDoorOpeningWidthFtFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthFtFront_txt.TabIndex = 26
        Me.CarDoorOpeningWidthFtFront_txt.Text = " "
        Me.CarDoorOpeningWidthFtFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightInFront_txt
        '
        Me.CarDoorOpeningHeightInFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightInFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightInFront_txt.Enabled = False
        Me.CarDoorOpeningHeightInFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightInFront_txt.Location = New System.Drawing.Point(984, 91)
        Me.CarDoorOpeningHeightInFront_txt.MaxLength = 0
        Me.CarDoorOpeningHeightInFront_txt.Name = "CarDoorOpeningHeightInFront_txt"
        Me.CarDoorOpeningHeightInFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightInFront_txt.TabIndex = 29
        Me.CarDoorOpeningHeightInFront_txt.Text = " "
        Me.CarDoorOpeningHeightInFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightFtFront_txt
        '
        Me.CarDoorOpeningHeightFtFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightFtFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFtFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightFtFront_txt.Enabled = False
        Me.CarDoorOpeningHeightFtFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightFtFront_txt.Location = New System.Drawing.Point(932, 91)
        Me.CarDoorOpeningHeightFtFront_txt.MaxLength = 0
        Me.CarDoorOpeningHeightFtFront_txt.Name = "CarDoorOpeningHeightFtFront_txt"
        Me.CarDoorOpeningHeightFtFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightFtFront_txt.TabIndex = 28
        Me.CarDoorOpeningHeightFtFront_txt.Text = " "
        Me.CarDoorOpeningHeightFtFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthInFront_lbl
        '
        Me.CarDoorOpeningWidthInFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthInFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthInFront_lbl.Enabled = False
        Me.CarDoorOpeningWidthInFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthInFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthInFront_lbl.Location = New System.Drawing.Point(1022, 69)
        Me.CarDoorOpeningWidthInFront_lbl.Name = "CarDoorOpeningWidthInFront_lbl"
        Me.CarDoorOpeningWidthInFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthInFront_lbl.TabIndex = 122
        Me.CarDoorOpeningWidthInFront_lbl.Text = "In"
        '
        'CarDoorOpeningWidthFtFront_lbl
        '
        Me.CarDoorOpeningWidthFtFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthFtFront_lbl.Enabled = False
        Me.CarDoorOpeningWidthFtFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFtFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFtFront_lbl.Location = New System.Drawing.Point(970, 69)
        Me.CarDoorOpeningWidthFtFront_lbl.Name = "CarDoorOpeningWidthFtFront_lbl"
        Me.CarDoorOpeningWidthFtFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthFtFront_lbl.TabIndex = 121
        Me.CarDoorOpeningWidthFtFront_lbl.Text = "Ft"
        '
        'CarDoorOpeningWidthFront_lbl
        '
        Me.CarDoorOpeningWidthFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthFront_lbl.Enabled = False
        Me.CarDoorOpeningWidthFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFront_lbl.Location = New System.Drawing.Point(796, 69)
        Me.CarDoorOpeningWidthFront_lbl.Name = "CarDoorOpeningWidthFront_lbl"
        Me.CarDoorOpeningWidthFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFront_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CarDoorOpeningWidthFront_lbl.TabIndex = 120
        Me.CarDoorOpeningWidthFront_lbl.Text = "Front Door Width"
        '
        'CarDoorOpeningHeightFront_lbl
        '
        Me.CarDoorOpeningHeightFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightFront_lbl.Enabled = False
        Me.CarDoorOpeningHeightFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFront_lbl.Location = New System.Drawing.Point(796, 94)
        Me.CarDoorOpeningHeightFront_lbl.Name = "CarDoorOpeningHeightFront_lbl"
        Me.CarDoorOpeningHeightFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFront_lbl.Size = New System.Drawing.Size(134, 19)
        Me.CarDoorOpeningHeightFront_lbl.TabIndex = 119
        Me.CarDoorOpeningHeightFront_lbl.Text = "Front Door Height"
        '
        'CarDoorOpeningHeightInFront_lbl
        '
        Me.CarDoorOpeningHeightInFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightInFront_lbl.Enabled = False
        Me.CarDoorOpeningHeightInFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightInFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightInFront_lbl.Location = New System.Drawing.Point(1022, 94)
        Me.CarDoorOpeningHeightInFront_lbl.Name = "CarDoorOpeningHeightInFront_lbl"
        Me.CarDoorOpeningHeightInFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightInFront_lbl.TabIndex = 118
        Me.CarDoorOpeningHeightInFront_lbl.Text = "In"
        '
        'CarDoorOpeningHeightFtFront_lbl
        '
        Me.CarDoorOpeningHeightFtFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFtFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightFtFront_lbl.Enabled = False
        Me.CarDoorOpeningHeightFtFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFtFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFtFront_lbl.Location = New System.Drawing.Point(970, 94)
        Me.CarDoorOpeningHeightFtFront_lbl.Name = "CarDoorOpeningHeightFtFront_lbl"
        Me.CarDoorOpeningHeightFtFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightFtFront_lbl.TabIndex = 117
        Me.CarDoorOpeningHeightFtFront_lbl.Text = "Ft"
        '
        'Application_lbl
        '
        Me.Application_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Application_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Application_lbl.Enabled = False
        Me.Application_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Application_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Application_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Application_lbl.Location = New System.Drawing.Point(8, 192)
        Me.Application_lbl.Name = "Application_lbl"
        Me.Application_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Application_lbl.Size = New System.Drawing.Size(134, 15)
        Me.Application_lbl.TabIndex = 111
        Me.Application_lbl.Text = "Application"
        '
        'PowerSupply_cmb
        '
        Me.PowerSupply_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.PowerSupply_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.PowerSupply_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PowerSupply_cmb.Enabled = False
        Me.PowerSupply_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerSupply_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PowerSupply_cmb.Location = New System.Drawing.Point(144, 166)
        Me.PowerSupply_cmb.Name = "PowerSupply_cmb"
        Me.PowerSupply_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PowerSupply_cmb.Size = New System.Drawing.Size(92, 21)
        Me.PowerSupply_cmb.TabIndex = 6
        '
        'PowerSupply_lbl
        '
        Me.PowerSupply_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PowerSupply_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PowerSupply_lbl.Enabled = False
        Me.PowerSupply_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PowerSupply_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerSupply_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PowerSupply_lbl.Location = New System.Drawing.Point(8, 168)
        Me.PowerSupply_lbl.Name = "PowerSupply_lbl"
        Me.PowerSupply_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PowerSupply_lbl.Size = New System.Drawing.Size(134, 15)
        Me.PowerSupply_lbl.TabIndex = 112
        Me.PowerSupply_lbl.Text = "Power Supply Voltage"
        '
        'Application_cmb
        '
        Me.Application_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Application_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Application_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Application_cmb.Enabled = False
        Me.Application_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Application_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Application_cmb.Location = New System.Drawing.Point(144, 190)
        Me.Application_cmb.Name = "Application_cmb"
        Me.Application_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Application_cmb.Size = New System.Drawing.Size(119, 21)
        Me.Application_cmb.TabIndex = 7
        '
        'LayoutRequirements_cmb
        '
        Me.LayoutRequirements_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.LayoutRequirements_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.LayoutRequirements_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LayoutRequirements_cmb.Enabled = False
        Me.LayoutRequirements_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutRequirements_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LayoutRequirements_cmb.Location = New System.Drawing.Point(932, 190)
        Me.LayoutRequirements_cmb.Name = "LayoutRequirements_cmb"
        Me.LayoutRequirements_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LayoutRequirements_cmb.Size = New System.Drawing.Size(92, 21)
        Me.LayoutRequirements_cmb.TabIndex = 35
        '
        'LayoutRequirements_lbl
        '
        Me.LayoutRequirements_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.LayoutRequirements_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.LayoutRequirements_lbl.Enabled = False
        Me.LayoutRequirements_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LayoutRequirements_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutRequirements_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LayoutRequirements_lbl.Location = New System.Drawing.Point(796, 192)
        Me.LayoutRequirements_lbl.Name = "LayoutRequirements_lbl"
        Me.LayoutRequirements_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LayoutRequirements_lbl.Size = New System.Drawing.Size(134, 17)
        Me.LayoutRequirements_lbl.TabIndex = 108
        Me.LayoutRequirements_lbl.Text = "Layout Requirements"
        '
        'DoorOperatorTypeRear_lbl
        '
        Me.DoorOperatorTypeRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DoorOperatorTypeRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoorOperatorTypeRear_lbl.Enabled = False
        Me.DoorOperatorTypeRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DoorOperatorTypeRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DoorOperatorTypeRear_lbl.Location = New System.Drawing.Point(796, 119)
        Me.DoorOperatorTypeRear_lbl.Name = "DoorOperatorTypeRear_lbl"
        Me.DoorOperatorTypeRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeRear_lbl.Size = New System.Drawing.Size(134, 15)
        Me.DoorOperatorTypeRear_lbl.TabIndex = 105
        Me.DoorOperatorTypeRear_lbl.Text = "Rear Door Type"
        '
        'DoorOperatorTypeFront_cmb
        '
        Me.DoorOperatorTypeFront_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DoorOperatorTypeFront_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoorOperatorTypeFront_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DoorOperatorTypeFront_cmb.Enabled = False
        Me.DoorOperatorTypeFront_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeFront_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoorOperatorTypeFront_cmb.Location = New System.Drawing.Point(932, 40)
        Me.DoorOperatorTypeFront_cmb.Name = "DoorOperatorTypeFront_cmb"
        Me.DoorOperatorTypeFront_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeFront_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DoorOperatorTypeFront_cmb.TabIndex = 25
        '
        'DoorOperatorTypeFront_lbl
        '
        Me.DoorOperatorTypeFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DoorOperatorTypeFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoorOperatorTypeFront_lbl.Enabled = False
        Me.DoorOperatorTypeFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DoorOperatorTypeFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DoorOperatorTypeFront_lbl.Location = New System.Drawing.Point(796, 43)
        Me.DoorOperatorTypeFront_lbl.Name = "DoorOperatorTypeFront_lbl"
        Me.DoorOperatorTypeFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeFront_lbl.Size = New System.Drawing.Size(134, 15)
        Me.DoorOperatorTypeFront_lbl.TabIndex = 106
        Me.DoorOperatorTypeFront_lbl.Text = "Front Door Type"
        '
        'DoorOperatorTypeRear_cmb
        '
        Me.DoorOperatorTypeRear_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DoorOperatorTypeRear_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoorOperatorTypeRear_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DoorOperatorTypeRear_cmb.Enabled = False
        Me.DoorOperatorTypeRear_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeRear_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoorOperatorTypeRear_cmb.Location = New System.Drawing.Point(932, 116)
        Me.DoorOperatorTypeRear_cmb.Name = "DoorOperatorTypeRear_cmb"
        Me.DoorOperatorTypeRear_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeRear_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DoorOperatorTypeRear_cmb.TabIndex = 30
        '
        'DriveType_cmb
        '
        Me.DriveType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DriveType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DriveType_cmb.Location = New System.Drawing.Point(662, 40)
        Me.DriveType_cmb.Name = "DriveType_cmb"
        Me.DriveType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveType_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DriveType_cmb.TabIndex = 17
        '
        'DriveType_lbl
        '
        Me.DriveType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DriveType_lbl.Location = New System.Drawing.Point(526, 43)
        Me.DriveType_lbl.Name = "DriveType_lbl"
        Me.DriveType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveType_lbl.Size = New System.Drawing.Size(134, 15)
        Me.DriveType_lbl.TabIndex = 102
        Me.DriveType_lbl.Text = "Drive Type"
        '
        'MachineType_cmb
        '
        Me.MachineType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.MachineType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MachineType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineType_cmb.Location = New System.Drawing.Point(662, 14)
        Me.MachineType_cmb.Name = "MachineType_cmb"
        Me.MachineType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineType_cmb.Size = New System.Drawing.Size(92, 21)
        Me.MachineType_cmb.Sorted = True
        Me.MachineType_cmb.TabIndex = 16
        '
        'MachineType_lbl
        '
        Me.MachineType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineType_lbl.Location = New System.Drawing.Point(526, 17)
        Me.MachineType_lbl.Name = "MachineType_lbl"
        Me.MachineType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineType_lbl.Size = New System.Drawing.Size(134, 16)
        Me.MachineType_lbl.TabIndex = 100
        Me.MachineType_lbl.Text = "Machine Type"
        '
        'NumberofStopsTotal_cmb
        '
        Me.NumberofStopsTotal_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotal_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotal_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotal_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsTotal_cmb.Location = New System.Drawing.Point(412, 141)
        Me.NumberofStopsTotal_cmb.Name = "NumberofStopsTotal_cmb"
        Me.NumberofStopsTotal_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotal_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsTotal_cmb.TabIndex = 13
        '
        'NumberofStopsTotal_lbl
        '
        Me.NumberofStopsTotal_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotal_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotal_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsTotal_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotal_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsTotal_lbl.Location = New System.Drawing.Point(276, 143)
        Me.NumberofStopsTotal_lbl.Name = "NumberofStopsTotal_lbl"
        Me.NumberofStopsTotal_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotal_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsTotal_lbl.TabIndex = 35
        Me.NumberofStopsTotal_lbl.Text = "Qty of Total Stops "
        '
        'NumberofStopsFront_lbl
        '
        Me.NumberofStopsFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsFront_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsFront_lbl.Location = New System.Drawing.Point(276, 168)
        Me.NumberofStopsFront_lbl.Name = "NumberofStopsFront_lbl"
        Me.NumberofStopsFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFront_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsFront_lbl.TabIndex = 36
        Me.NumberofStopsFront_lbl.Text = "Qty of Front Openings "
        '
        'NumberofStopsRear_lbl
        '
        Me.NumberofStopsRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRear_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsRear_lbl.Location = New System.Drawing.Point(276, 192)
        Me.NumberofStopsRear_lbl.Name = "NumberofStopsRear_lbl"
        Me.NumberofStopsRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRear_lbl.Size = New System.Drawing.Size(134, 17)
        Me.NumberofStopsRear_lbl.TabIndex = 37
        Me.NumberofStopsRear_lbl.Text = "Qty of Rear Openings "
        '
        'NumberofStopsFront_cmb
        '
        Me.NumberofStopsFront_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsFront_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsFront_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsFront_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsFront_cmb.Location = New System.Drawing.Point(412, 166)
        Me.NumberofStopsFront_cmb.Name = "NumberofStopsFront_cmb"
        Me.NumberofStopsFront_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFront_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsFront_cmb.TabIndex = 14
        '
        'NumberofStopsRear_cmb
        '
        Me.NumberofStopsRear_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRear_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRear_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRear_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsRear_cmb.Location = New System.Drawing.Point(412, 190)
        Me.NumberofStopsRear_cmb.Name = "NumberofStopsRear_cmb"
        Me.NumberofStopsRear_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRear_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsRear_cmb.TabIndex = 15
        '
        'SpeedNew_cmb
        '
        Me.SpeedNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpeedNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedNew_cmb.Location = New System.Drawing.Point(144, 91)
        Me.SpeedNew_cmb.Name = "SpeedNew_cmb"
        Me.SpeedNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedNew_cmb.Size = New System.Drawing.Size(92, 21)
        Me.SpeedNew_cmb.TabIndex = 3
        '
        'CapacityNew_cmb
        '
        Me.CapacityNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityNew_cmb.Location = New System.Drawing.Point(144, 14)
        Me.CapacityNew_cmb.Name = "CapacityNew_cmb"
        Me.CapacityNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityNew_cmb.Size = New System.Drawing.Size(92, 21)
        Me.CapacityNew_cmb.TabIndex = 0
        '
        'SpeedLabel_lbl
        '
        Me.SpeedLabel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedLabel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedLabel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedLabel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedLabel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedLabel_lbl.Location = New System.Drawing.Point(8, 94)
        Me.SpeedLabel_lbl.Name = "SpeedLabel_lbl"
        Me.SpeedLabel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedLabel_lbl.Size = New System.Drawing.Size(134, 17)
        Me.SpeedLabel_lbl.TabIndex = 26
        Me.SpeedLabel_lbl.Text = "Speed"
        '
        'CapacityLabel_lbl
        '
        Me.CapacityLabel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityLabel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityLabel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CapacityLabel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityLabel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityLabel_lbl.Location = New System.Drawing.Point(8, 17)
        Me.CapacityLabel_lbl.Name = "CapacityLabel_lbl"
        Me.CapacityLabel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityLabel_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CapacityLabel_lbl.TabIndex = 25
        Me.CapacityLabel_lbl.Text = "Capacity"
        '
        'ExpandCollapseGeneralInfoFrame_btn
        '
        Me.ExpandCollapseGeneralInfoFrame_btn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ExpandCollapseGeneralInfoFrame_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExpandCollapseGeneralInfoFrame_btn.Location = New System.Drawing.Point(1, -1)
        Me.ExpandCollapseGeneralInfoFrame_btn.Name = "ExpandCollapseGeneralInfoFrame_btn"
        Me.ExpandCollapseGeneralInfoFrame_btn.Size = New System.Drawing.Size(20, 19)
        Me.ExpandCollapseGeneralInfoFrame_btn.TabIndex = 3
        Me.ExpandCollapseGeneralInfoFrame_btn.UseVisualStyleBackColor = True
        '
        'BillofMaterialsandTaskList_fra
        '
        Me.BillofMaterialsandTaskList_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.ExpandAll_cmd)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.BillOfMaterials_spr)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.CollapseAll_cmd)
        Me.BillofMaterialsandTaskList_fra.Location = New System.Drawing.Point(4, 321)
        Me.BillofMaterialsandTaskList_fra.Name = "BillofMaterialsandTaskList_fra"
        Me.BillofMaterialsandTaskList_fra.Size = New System.Drawing.Size(1561, 311)
        Me.BillofMaterialsandTaskList_fra.TabIndex = 80
        Me.BillofMaterialsandTaskList_fra.TabStop = False
        Me.BillofMaterialsandTaskList_fra.Text = "Bill of Materials and Task List"
        '
        'ExpandAll_cmd
        '
        Me.ExpandAll_cmd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExpandAll_cmd.Location = New System.Drawing.Point(596, 14)
        Me.ExpandAll_cmd.Name = "ExpandAll_cmd"
        Me.ExpandAll_cmd.Size = New System.Drawing.Size(113, 23)
        Me.ExpandAll_cmd.TabIndex = 65
        Me.ExpandAll_cmd.Text = "Expand All"
        Me.ExpandAll_cmd.UseVisualStyleBackColor = True
        '
        'BillOfMaterials_spr
        '
        Me.BillOfMaterials_spr.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.BillOfMaterials_spr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillOfMaterials_spr.EditModeReplace = True
        Me.BillOfMaterials_spr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillOfMaterials_spr.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.BillOfMaterials_spr.Location = New System.Drawing.Point(6, 41)
        Me.BillOfMaterials_spr.Name = "BillOfMaterials_spr"
        Me.BillOfMaterials_spr.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.BillOfMaterials_spr_Sheet1})
        Me.BillOfMaterials_spr.Size = New System.Drawing.Size(1551, 264)
        Me.BillOfMaterials_spr.TabIndex = 64
        Me.BillOfMaterials_spr.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'BillOfMaterials_spr_Sheet1
        '
        Me.BillOfMaterials_spr_Sheet1.Reset()
        Me.BillOfMaterials_spr_Sheet1.SheetName = "Sheet1"
        '
        'CollapseAll_cmd
        '
        Me.CollapseAll_cmd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CollapseAll_cmd.Location = New System.Drawing.Point(852, 14)
        Me.CollapseAll_cmd.Name = "CollapseAll_cmd"
        Me.CollapseAll_cmd.Size = New System.Drawing.Size(113, 23)
        Me.CollapseAll_cmd.TabIndex = 66
        Me.CollapseAll_cmd.Text = "Collapse All"
        Me.CollapseAll_cmd.UseVisualStyleBackColor = True
        '
        'MDI_pic
        '
        Me.MDI_pic.BackColor = System.Drawing.SystemColors.Control
        Me.MDI_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MDI_pic.Controls.Add(Me.fraHdrJobInfo)
        Me.MDI_pic.Controls.Add(Me.fraHdrIcons)
        Me.MDI_pic.Cursor = System.Windows.Forms.Cursors.Default
        Me.MDI_pic.Dock = System.Windows.Forms.DockStyle.Top
        Me.MDI_pic.Location = New System.Drawing.Point(0, 0)
        Me.MDI_pic.Name = "MDI_pic"
        Me.MDI_pic.Size = New System.Drawing.Size(1593, 99)
        Me.MDI_pic.TabIndex = 24
        Me.MDI_pic.TabStop = False
        '
        'fraHdrJobInfo
        '
        Me.fraHdrJobInfo.BackColor = System.Drawing.SystemColors.Control
        Me.fraHdrJobInfo.Controls.Add(Me.LaborRate_txt)
        Me.fraHdrJobInfo.Controls.Add(Me.LaborRate_lbl)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrBnkLetter)
        Me.fraHdrJobInfo.Controls.Add(Me.Units_txt)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrEstimateNum)
        Me.fraHdrJobInfo.Controls.Add(Me.HdrGONum_txt)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrBldgName)
        Me.fraHdrJobInfo.Controls.Add(Me.Label1)
        Me.fraHdrJobInfo.Controls.Add(Me.Label2)
        Me.fraHdrJobInfo.Controls.Add(Me.lblHdrEstimateNum)
        Me.fraHdrJobInfo.Controls.Add(Me.HdrGONum_lbl)
        Me.fraHdrJobInfo.Controls.Add(Me.lblHdrBldgNme)
        Me.fraHdrJobInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraHdrJobInfo.Font = New System.Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHdrJobInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHdrJobInfo.Location = New System.Drawing.Point(0, 60)
        Me.fraHdrJobInfo.Name = "fraHdrJobInfo"
        Me.fraHdrJobInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHdrJobInfo.Size = New System.Drawing.Size(1589, 30)
        Me.fraHdrJobInfo.TabIndex = 25
        Me.fraHdrJobInfo.TabStop = False
        '
        'txtHdrBnkLetter
        '
        Me.txtHdrBnkLetter.AcceptsReturn = True
        Me.txtHdrBnkLetter.BackColor = System.Drawing.SystemColors.Window
        Me.txtHdrBnkLetter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHdrBnkLetter.Enabled = False
        Me.txtHdrBnkLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHdrBnkLetter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHdrBnkLetter.Location = New System.Drawing.Point(623, 6)
        Me.txtHdrBnkLetter.MaxLength = 0
        Me.txtHdrBnkLetter.Name = "txtHdrBnkLetter"
        Me.txtHdrBnkLetter.ReadOnly = True
        Me.txtHdrBnkLetter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHdrBnkLetter.Size = New System.Drawing.Size(20, 20)
        Me.txtHdrBnkLetter.TabIndex = 81
        Me.txtHdrBnkLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Units_txt
        '
        Me.Units_txt.AcceptsReturn = True
        Me.Units_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Units_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Units_txt.Enabled = False
        Me.Units_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Units_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Units_txt.Location = New System.Drawing.Point(698, 6)
        Me.Units_txt.MaxLength = 0
        Me.Units_txt.Name = "Units_txt"
        Me.Units_txt.ReadOnly = True
        Me.Units_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Units_txt.Size = New System.Drawing.Size(65, 20)
        Me.Units_txt.TabIndex = 82
        Me.Units_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHdrEstimateNum
        '
        Me.txtHdrEstimateNum.AcceptsReturn = True
        Me.txtHdrEstimateNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtHdrEstimateNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHdrEstimateNum.Enabled = False
        Me.txtHdrEstimateNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHdrEstimateNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHdrEstimateNum.Location = New System.Drawing.Point(451, 6)
        Me.txtHdrEstimateNum.MaxLength = 0
        Me.txtHdrEstimateNum.Name = "txtHdrEstimateNum"
        Me.txtHdrEstimateNum.ReadOnly = True
        Me.txtHdrEstimateNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHdrEstimateNum.Size = New System.Drawing.Size(105, 20)
        Me.txtHdrEstimateNum.TabIndex = 80
        '
        'HdrGONum_txt
        '
        Me.HdrGONum_txt.AcceptsReturn = True
        Me.HdrGONum_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HdrGONum_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HdrGONum_txt.Enabled = False
        Me.HdrGONum_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HdrGONum_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HdrGONum_txt.Location = New System.Drawing.Point(48, 6)
        Me.HdrGONum_txt.MaxLength = 0
        Me.HdrGONum_txt.Name = "HdrGONum_txt"
        Me.HdrGONum_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HdrGONum_txt.Size = New System.Drawing.Size(49, 20)
        Me.HdrGONum_txt.TabIndex = 78
        '
        'txtHdrBldgName
        '
        Me.txtHdrBldgName.AcceptsReturn = True
        Me.txtHdrBldgName.BackColor = System.Drawing.SystemColors.Window
        Me.txtHdrBldgName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHdrBldgName.Enabled = False
        Me.txtHdrBldgName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHdrBldgName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHdrBldgName.Location = New System.Drawing.Point(158, 6)
        Me.txtHdrBldgName.MaxLength = 0
        Me.txtHdrBldgName.Name = "txtHdrBldgName"
        Me.txtHdrBldgName.ReadOnly = True
        Me.txtHdrBldgName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHdrBldgName.Size = New System.Drawing.Size(217, 20)
        Me.txtHdrBldgName.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Enabled = False
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(560, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Bank"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Enabled = False
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(660, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(35, 19)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Units"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHdrEstimateNum
        '
        Me.lblHdrEstimateNum.BackColor = System.Drawing.SystemColors.Control
        Me.lblHdrEstimateNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHdrEstimateNum.Enabled = False
        Me.lblHdrEstimateNum.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblHdrEstimateNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHdrEstimateNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHdrEstimateNum.Location = New System.Drawing.Point(384, 8)
        Me.lblHdrEstimateNum.Name = "lblHdrEstimateNum"
        Me.lblHdrEstimateNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHdrEstimateNum.Size = New System.Drawing.Size(67, 19)
        Me.lblHdrEstimateNum.TabIndex = 31
        Me.lblHdrEstimateNum.Text = "Estimate # "
        Me.lblHdrEstimateNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'HdrGONum_lbl
        '
        Me.HdrGONum_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.HdrGONum_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HdrGONum_lbl.Enabled = False
        Me.HdrGONum_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HdrGONum_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HdrGONum_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HdrGONum_lbl.Location = New System.Drawing.Point(8, 8)
        Me.HdrGONum_lbl.Name = "HdrGONum_lbl"
        Me.HdrGONum_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HdrGONum_lbl.Size = New System.Drawing.Size(41, 19)
        Me.HdrGONum_lbl.TabIndex = 29
        Me.HdrGONum_lbl.Text = "GO # :"
        '
        'lblHdrBldgNme
        '
        Me.lblHdrBldgNme.BackColor = System.Drawing.SystemColors.Control
        Me.lblHdrBldgNme.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHdrBldgNme.Enabled = False
        Me.lblHdrBldgNme.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblHdrBldgNme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHdrBldgNme.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHdrBldgNme.Location = New System.Drawing.Point(103, 8)
        Me.lblHdrBldgNme.Name = "lblHdrBldgNme"
        Me.lblHdrBldgNme.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHdrBldgNme.Size = New System.Drawing.Size(55, 17)
        Me.lblHdrBldgNme.TabIndex = 27
        Me.lblHdrBldgNme.Text = "Building :"
        '
        'fraHdrIcons
        '
        Me.fraHdrIcons.BackColor = System.Drawing.SystemColors.Control
        Me.fraHdrIcons.Controls.Add(Me.btnLaborRates)
        Me.fraHdrIcons.Controls.Add(Me.btnTorque)
        Me.fraHdrIcons.Controls.Add(Me.Exit_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Save_cmd)
        Me.fraHdrIcons.Controls.Add(Me.CMMain_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Screen_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Forms_cmd)
        Me.fraHdrIcons.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraHdrIcons.Font = New System.Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHdrIcons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHdrIcons.Location = New System.Drawing.Point(0, 0)
        Me.fraHdrIcons.Name = "fraHdrIcons"
        Me.fraHdrIcons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHdrIcons.Size = New System.Drawing.Size(1589, 60)
        Me.fraHdrIcons.TabIndex = 24
        Me.fraHdrIcons.TabStop = False
        '
        'btnLaborRates
        '
        Me.btnLaborRates.BackColor = System.Drawing.SystemColors.Control
        Me.btnLaborRates.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.btnLaborRates.Image = CType(resources.GetObject("btnLaborRates.Image"), System.Drawing.Image)
        Me.btnLaborRates.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLaborRates.Location = New System.Drawing.Point(592, 8)
        Me.btnLaborRates.Name = "btnLaborRates"
        Me.btnLaborRates.Size = New System.Drawing.Size(46, 46)
        Me.btnLaborRates.TabIndex = 103
        Me.btnLaborRates.TabStop = False
        Me.btnLaborRates.Text = "Labor Rates"
        Me.btnLaborRates.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLaborRates.UseVisualStyleBackColor = True
        '
        'btnTorque
        '
        Me.btnTorque.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTorque.Location = New System.Drawing.Point(1039, 8)
        Me.btnTorque.Name = "btnTorque"
        Me.btnTorque.Size = New System.Drawing.Size(46, 46)
        Me.btnTorque.TabIndex = 77
        Me.btnTorque.TabStop = False
        Me.btnTorque.Text = "Torque"
        '
        'Exit_cmd
        '
        Me.Exit_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_cmd.Image = CType(resources.GetObject("Exit_cmd.Image"), System.Drawing.Image)
        Me.Exit_cmd.Location = New System.Drawing.Point(0, 8)
        Me.Exit_cmd.Name = "Exit_cmd"
        Me.Exit_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Exit_cmd.TabIndex = 67
        Me.Exit_cmd.TabStop = False
        Me.Exit_cmd.Tag = "Exit System"
        Me.Exit_cmd.Text = "Exit"
        Me.Exit_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Save_cmd
        '
        Me.Save_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_cmd.Image = CType(resources.GetObject("Save_cmd.Image"), System.Drawing.Image)
        Me.Save_cmd.Location = New System.Drawing.Point(48, 8)
        Me.Save_cmd.Name = "Save_cmd"
        Me.Save_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Save_cmd.TabIndex = 68
        Me.Save_cmd.TabStop = False
        Me.Save_cmd.Tag = "Save Changes"
        Me.Save_cmd.Text = "Save"
        Me.Save_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'CMMain_cmd
        '
        Me.CMMain_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMMain_cmd.Image = CType(resources.GetObject("CMMain_cmd.Image"), System.Drawing.Image)
        Me.CMMain_cmd.Location = New System.Drawing.Point(96, 8)
        Me.CMMain_cmd.Name = "CMMain_cmd"
        Me.CMMain_cmd.Size = New System.Drawing.Size(46, 46)
        Me.CMMain_cmd.TabIndex = 69
        Me.CMMain_cmd.TabStop = False
        Me.CMMain_cmd.Tag = "Return to Contract Manager"
        Me.CMMain_cmd.Text = "Main"
        Me.CMMain_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Screen_cmd
        '
        Me.Screen_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Screen_cmd.Image = CType(resources.GetObject("Screen_cmd.Image"), System.Drawing.Image)
        Me.Screen_cmd.Location = New System.Drawing.Point(440, 8)
        Me.Screen_cmd.Name = "Screen_cmd"
        Me.Screen_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Screen_cmd.TabIndex = 73
        Me.Screen_cmd.TabStop = False
        Me.Screen_cmd.Tag = "Print Screen"
        Me.Screen_cmd.Text = "Screen"
        Me.Screen_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Forms_cmd
        '
        Me.Forms_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Forms_cmd.Image = CType(resources.GetObject("Forms_cmd.Image"), System.Drawing.Image)
        Me.Forms_cmd.Location = New System.Drawing.Point(145, 8)
        Me.Forms_cmd.Name = "Forms_cmd"
        Me.Forms_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Forms_cmd.TabIndex = 70
        Me.Forms_cmd.TabStop = False
        Me.Forms_cmd.Tag = "Print Forms"
        Me.Forms_cmd.Text = "Forms"
        Me.Forms_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LaborRate_txt
        '
        Me.LaborRate_txt.AcceptsReturn = True
        Me.LaborRate_txt.BackColor = System.Drawing.SystemColors.Window
        Me.LaborRate_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.LaborRate_txt.Enabled = False
        Me.LaborRate_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborRate_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LaborRate_txt.Location = New System.Drawing.Point(879, 6)
        Me.LaborRate_txt.MaxLength = 0
        Me.LaborRate_txt.Name = "LaborRate_txt"
        Me.LaborRate_txt.ReadOnly = True
        Me.LaborRate_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LaborRate_txt.Size = New System.Drawing.Size(65, 20)
        Me.LaborRate_txt.TabIndex = 86
        Me.LaborRate_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LaborRate_lbl
        '
        Me.LaborRate_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.LaborRate_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.LaborRate_lbl.Enabled = False
        Me.LaborRate_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LaborRate_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborRate_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LaborRate_lbl.Location = New System.Drawing.Point(808, 8)
        Me.LaborRate_lbl.Name = "LaborRate_lbl"
        Me.LaborRate_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LaborRate_lbl.Size = New System.Drawing.Size(67, 19)
        Me.LaborRate_lbl.TabIndex = 85
        Me.LaborRate_lbl.Text = "Labor Rate"
        Me.LaborRate_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmEstimatingAlt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1593, 799)
        Me.ControlBox = False
        Me.Controls.Add(Me.MDI_pic)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstimatingAlt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MOD Estimating"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GeneralInformationBase_fra.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.CarTab.ResumeLayout(False)
        Me.CarData_fra.ResumeLayout(False)
        Me.Torque_fra.ResumeLayout(False)
        Me.Torque_fra.PerformLayout()
        Me.GeneralInformation_fra.ResumeLayout(False)
        Me.GeneralInformation_fra.PerformLayout()
        Me.BillofMaterialsandTaskList_fra.ResumeLayout(False)
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MDI_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MDI_pic.ResumeLayout(False)
        Me.fraHdrJobInfo.ResumeLayout(False)
        Me.fraHdrJobInfo.PerformLayout()
        Me.fraHdrIcons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents MDI_pic As System.Windows.Forms.PictureBox
    Public WithEvents fraHdrJobInfo As System.Windows.Forms.GroupBox
    Public WithEvents txtHdrBnkLetter As System.Windows.Forms.TextBox
    Public WithEvents Units_txt As System.Windows.Forms.TextBox
    Public WithEvents txtHdrEstimateNum As System.Windows.Forms.TextBox
    Public WithEvents HdrGONum_txt As System.Windows.Forms.TextBox
    Public WithEvents txtHdrBldgName As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblHdrEstimateNum As System.Windows.Forms.Label
    Public WithEvents HdrGONum_lbl As System.Windows.Forms.Label
    Public WithEvents lblHdrBldgNme As System.Windows.Forms.Label
    Public WithEvents fraHdrIcons As System.Windows.Forms.GroupBox
    Private WithEvents Exit_cmd As System.Windows.Forms.Button
    Private WithEvents Save_cmd As System.Windows.Forms.Button
    Private WithEvents CMMain_cmd As System.Windows.Forms.Button
    Private WithEvents Screen_cmd As System.Windows.Forms.Button
    Private WithEvents Forms_cmd As System.Windows.Forms.Button
    Friend WithEvents GeneralInformation_fra As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ExpandCollapseGeneralInfoFrame_btn As System.Windows.Forms.Button
    Friend WithEvents BillofMaterialsandTaskList_fra As System.Windows.Forms.GroupBox
    Friend WithEvents ExpandAll_cmd As System.Windows.Forms.Button
    Friend WithEvents BillOfMaterials_spr As FarPoint.Win.Spread.FpSpread
    Friend WithEvents BillOfMaterials_spr_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents CollapseAll_cmd As System.Windows.Forms.Button
    Public WithEvents NumberofStopsTotal_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NumberofStopsTotal_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFront_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsRear_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFront_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NumberofStopsRear_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SpeedNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CapacityNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SpeedLabel_lbl As System.Windows.Forms.Label
    Public WithEvents CapacityLabel_lbl As System.Windows.Forms.Label
    Public WithEvents DriveType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents DriveType_lbl As System.Windows.Forms.Label
    Public WithEvents MachineType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineType_lbl As System.Windows.Forms.Label
    Public WithEvents LayoutRequirements_cmb As System.Windows.Forms.ComboBox
    Public WithEvents LayoutRequirements_lbl As System.Windows.Forms.Label
    Public WithEvents DoorOperatorTypeRear_lbl As System.Windows.Forms.Label
    Public WithEvents DoorOperatorTypeFront_cmb As System.Windows.Forms.ComboBox
    Public WithEvents DoorOperatorTypeFront_lbl As System.Windows.Forms.Label
    Public WithEvents DoorOperatorTypeRear_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Application_lbl As System.Windows.Forms.Label
    Public WithEvents PowerSupply_cmb As System.Windows.Forms.ComboBox
    Public WithEvents PowerSupply_lbl As System.Windows.Forms.Label
    Public WithEvents Application_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarDoorOpeningHeightFtRear_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningHeightInRear_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningWidthFtRear_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningWidthInRear_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningHeightFtRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningHeightInRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningHeightRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthFtRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthInRear_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthInFront_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningWidthFtFront_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningHeightInFront_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningHeightFtFront_txt As System.Windows.Forms.TextBox
    Public WithEvents CarDoorOpeningWidthInFront_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthFtFront_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningWidthFront_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningHeightFront_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningHeightInFront_lbl As System.Windows.Forms.Label
    Public WithEvents CarDoorOpeningHeightFtFront_lbl As System.Windows.Forms.Label
    Public WithEvents MachineLocation_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineLocation_lbl As System.Windows.Forms.Label
    Public WithEvents HoistMotorRpm_txt As System.Windows.Forms.TextBox
    Public WithEvents HoistMotorRpm_lbl As System.Windows.Forms.Label
    Public WithEvents HoistMotorHP_txt As System.Windows.Forms.TextBox
    Public WithEvents HoistMotorHP_lbl As System.Windows.Forms.Label
    Public WithEvents CarWeight_txt As System.Windows.Forms.TextBox
    Public WithEvents CarWeight_lbl As System.Windows.Forms.Label
    Public WithEvents RopingNew_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents Roping_lbl As System.Windows.Forms.Label
    Public WithEvents PitDepth_txt As System.Windows.Forms.TextBox
    Public WithEvents PitDepth_lbl As System.Windows.Forms.Label
    Public WithEvents TravelNew_txt As System.Windows.Forms.TextBox
    Public WithEvents TravelNew_lbl As System.Windows.Forms.Label
    Public WithEvents TopFloorToOverhead_txt As System.Windows.Forms.TextBox
    Public WithEvents TopFloorToOverhead_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyFront_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents RiserQtyRear_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents FinalRisers_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyFront_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyRear_lbl As System.Windows.Forms.Label
    Public WithEvents FixtureFinish_cmb As System.Windows.Forms.ComboBox
    Public WithEvents FixtureFinish_lbl As System.Windows.Forms.Label
    Public WithEvents BankCompleteDate_txt As System.Windows.Forms.DateTimePicker
    Public WithEvents DTRequestedShipDate As System.Windows.Forms.DateTimePicker
    Public WithEvents lblBankCompleteDate As System.Windows.Forms.Label
    Public WithEvents lblRequestedShipDate As System.Windows.Forms.Label
    Friend WithEvents CarData_fra As System.Windows.Forms.GroupBox
    Public WithEvents OriginalGONumberAvailable_cmb As System.Windows.Forms.ComboBox
    Public WithEvents OriginalGOnumber_txt As System.Windows.Forms.TextBox
    Public WithEvents OriginalGONumberAvailable_lbl As System.Windows.Forms.Label
    Public WithEvents OriginalGOnumber_lbl As System.Windows.Forms.Label
    Public WithEvents ExistingControlModel_lst As System.Windows.Forms.ComboBox
    Public WithEvents ExistingControlVendor_lst As System.Windows.Forms.ComboBox
    Public WithEvents ExistingControlModel_lbl As System.Windows.Forms.Label
    Public WithEvents ExistingControlVendor_lbl As System.Windows.Forms.Label
    Public WithEvents Permits_txt As System.Windows.Forms.TextBox
    Public WithEvents Permits_lbl As System.Windows.Forms.Label
    Public WithEvents PEStampRequired_cmb As System.Windows.Forms.ComboBox
    Public WithEvents PEStampRequired_lbl As System.Windows.Forms.Label
    Public WithEvents ExpensesPerDay_txt As System.Windows.Forms.TextBox
    Public WithEvents ExpensesPerDay_lbl As System.Windows.Forms.Label
    Public WithEvents Bonds_txt As System.Windows.Forms.TextBox
    Public WithEvents Bonds_lbl As System.Windows.Forms.Label
    Public WithEvents ShortFloorOperation_chk As System.Windows.Forms.CheckBox
    Friend WithEvents ExpensesPerDayDetails_btn As System.Windows.Forms.Button
    Public WithEvents GatewayReviewRequired_chk As System.Windows.Forms.CheckBox
    Friend WithEvents CarTab As System.Windows.Forms.TabPage
    Public WithEvents Destination_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Destination_lbl As System.Windows.Forms.Label
    Friend WithEvents GeneralInformationBase_fra As System.Windows.Forms.GroupBox
    Public WithEvents DestinationBase_lbl As System.Windows.Forms.Label
    Public WithEvents PitDepthBase_lbl As System.Windows.Forms.Label
    Public WithEvents TravelBase_lbl As System.Windows.Forms.Label
    Public WithEvents TopFloorToOverheadBase_lbl As System.Windows.Forms.Label
    Public WithEvents RopingNewBase_lbl As System.Windows.Forms.Label
    Public WithEvents DriveTypeBase_lbl As System.Windows.Forms.Label
    Public WithEvents MachineTypeBase_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsTotalBase_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFrontBase_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsRearBase_lbl As System.Windows.Forms.Label
    Public WithEvents SpeedNewBase_lbl As System.Windows.Forms.Label
    Public WithEvents CapacityNewBase_lbl As System.Windows.Forms.Label
    Public WithEvents DestinationBase_cmb As System.Windows.Forms.Label
    Public WithEvents PitDepthBase_txt As System.Windows.Forms.Label
    Public WithEvents TravelBase_txt As System.Windows.Forms.Label
    Public WithEvents TopFloorToOverheadBase_txt As System.Windows.Forms.Label
    Public WithEvents RopingNewBase_Cmb As System.Windows.Forms.Label
    Public WithEvents DriveTypeBase_cmb As System.Windows.Forms.Label
    Public WithEvents MachineTypeBase_cmb As System.Windows.Forms.Label
    Public WithEvents NumberofStopsTotalBase_cmb As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFrontBase_cmb As System.Windows.Forms.Label
    Public WithEvents NumberofStopsRearBase_cmb As System.Windows.Forms.Label
    Public WithEvents SpeedNewBase_cmb As System.Windows.Forms.Label
    Public WithEvents CapacityNewBase_cmb As System.Windows.Forms.Label
    Public WithEvents btnTorque As System.Windows.Forms.Button
    Friend WithEvents Torque_fra As System.Windows.Forms.GroupBox
    Public WithEvents MachineModelExisting_cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineVendorExisting_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents MachineModelExisting_lbl As System.Windows.Forms.Label
    Public WithEvents MachineVendorExisting_lbl As System.Windows.Forms.Label
    Friend WithEvents ExpandCollapseTorqueFrame_btn As System.Windows.Forms.Button
    Public WithEvents ChangeInTravel_chk As System.Windows.Forms.CheckBox
    Public WithEvents ChangeInSpeed_chk As System.Windows.Forms.CheckBox
    Public WithEvents ChangeInCapacity_chk As System.Windows.Forms.CheckBox
    Public WithEvents TravelExisting_txt As System.Windows.Forms.TextBox
    Public WithEvents TravelExisting_lbl As System.Windows.Forms.Label
    Public WithEvents SpeedExisting_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SpeedExisting_lbl As System.Windows.Forms.Label
    Public WithEvents CapacityExisting_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CapacityExisting_lbl As System.Windows.Forms.Label
    Public WithEvents FullLoadCurrentIDC1_txt As System.Windows.Forms.TextBox
    Public WithEvents FullLoadCurrentIDC1Amps_lbl As System.Windows.Forms.Label
    Public WithEvents FullLoadCurrentIDC1_lbl As System.Windows.Forms.Label
    Public WithEvents CwtSheaveQty_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents CwtSheaveQty_lbl As System.Windows.Forms.Label
    Public WithEvents CarSheaveQty_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents CarSheaveQty_lbl As System.Windows.Forms.Label
    Public WithEvents Compensation_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Compensation_lbl As System.Windows.Forms.Label
    Private WithEvents HoistRopeSizeIn_lbl As System.Windows.Forms.Label
    Public WithEvents CarToCwtRopeDrop_txt As System.Windows.Forms.TextBox
    Private WithEvents CarToCwtRopeDrop_lbl As System.Windows.Forms.Label
    Private WithEvents CarToCwtRopeDropIn_lbl As System.Windows.Forms.Label
    Public WithEvents HoistRopeQty_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents HoistRopeSize_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents HoistRopeQty_lbl As System.Windows.Forms.Label
    Public WithEvents HoistRopeSize_lbl As System.Windows.Forms.Label
    Public WithEvents BrakeType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents BrakeType_lbl As System.Windows.Forms.Label
    Public WithEvents NominalMotorRPM_lbl As System.Windows.Forms.Label
    Public WithEvents ExistingMachineSheaveDia_cmb As System.Windows.Forms.ComboBox
    Private WithEvents ExistingMachineSheaveDia_lbl As System.Windows.Forms.Label
    Private WithEvents ExistingMachineSheaveDiaIn_lbl As System.Windows.Forms.Label
    Public WithEvents ArmatureFullLoadVoltageVFLU_txt As System.Windows.Forms.TextBox
    Public WithEvents ArmatureFullLoadVoltageVFLUVolts_lbl As System.Windows.Forms.Label
    Public WithEvents ArmatureFullLoadVoltageVFLU_lbl As System.Windows.Forms.Label
    Public WithEvents NominalMotorRPM_txt As System.Windows.Forms.TextBox
    Private WithEvents btnLaborRates As System.Windows.Forms.Button
    Public WithEvents LaborRate_txt As System.Windows.Forms.TextBox
    Public WithEvents LaborRate_lbl As System.Windows.Forms.Label

#End Region
End Class
