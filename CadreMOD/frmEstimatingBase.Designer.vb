Partial Class frmEstimatingBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstimatingBase))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.CarTab = New System.Windows.Forms.TabPage()
        Me.CarData_fra = New System.Windows.Forms.GroupBox()
        Me.GeneralInformation_fra = New System.Windows.Forms.GroupBox()
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
        Me.RiserQtyExistingFront_Cmb = New System.Windows.Forms.ComboBox()
        Me.RiserQtyExistingRear_Cmb = New System.Windows.Forms.ComboBox()
        Me.ExistingRisers_lbl = New System.Windows.Forms.Label()
        Me.RiserQtyExistingFront_lbl = New System.Windows.Forms.Label()
        Me.RiserQtyExistingRear_lbl = New System.Windows.Forms.Label()
        Me.PitDepth_txt = New System.Windows.Forms.TextBox()
        Me.PitDepth_lbl = New System.Windows.Forms.Label()
        Me.Travel_txt = New System.Windows.Forms.TextBox()
        Me.Travel_lbl = New System.Windows.Forms.Label()
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
        Me.ExpandCollapseFrame_btn = New System.Windows.Forms.Button()
        Me.BillofMaterialsandTaskList_fra = New System.Windows.Forms.GroupBox()
        Me.ExpandAll_cmd = New System.Windows.Forms.Button()
        Me.BillOfMaterials_spr = New FarPoint.Win.Spread.FpSpread()
        Me.BillOfMaterials_spr_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.CollapseAll_cmd = New System.Windows.Forms.Button()
        Me.OrderTab = New System.Windows.Forms.TabPage()
        Me.OrderingForms_fra = New System.Windows.Forms.GroupBox()
        Me.OrderingForms_lst = New System.Windows.Forms.ListBox()
        Me.OrderingForms_con = New System.Windows.Forms.Panel()
        Me.MDI_pic = New System.Windows.Forms.PictureBox()
        Me.fraHdrJobInfo = New System.Windows.Forms.GroupBox()
        Me.txtHdrAltLetter = New System.Windows.Forms.TextBox()
        Me.txtHdrBnkLetter = New System.Windows.Forms.TextBox()
        Me.Units_txt = New System.Windows.Forms.TextBox()
        Me.txtHdrGONegNum = New System.Windows.Forms.TextBox()
        Me.HdrGONum_txt = New System.Windows.Forms.TextBox()
        Me.txtHdrBldgName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHdrGONegNum = New System.Windows.Forms.Label()
        Me.HdrGONum_lbl = New System.Windows.Forms.Label()
        Me.lblHdrBldgNme = New System.Windows.Forms.Label()
        Me.fraHdrIcons = New System.Windows.Forms.GroupBox()
        Me.Merge_cmd = New System.Windows.Forms.Button()
        Me.Copy_cmd = New System.Windows.Forms.Button()
        Me.Supt_cmd = New System.Windows.Forms.Button()
        Me.FreezeSave_btn = New System.Windows.Forms.Button()
        Me.Exit_cmd = New System.Windows.Forms.Button()
        Me.Save_cmd = New System.Windows.Forms.Button()
        Me.CMMain_cmd = New System.Windows.Forms.Button()
        Me.Screen_cmd = New System.Windows.Forms.Button()
        Me.Forms_cmd = New System.Windows.Forms.Button()
        Me.Book_cmd = New System.Windows.Forms.Button()
        Me.Config_cmd = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.CarTab.SuspendLayout()
        Me.CarData_fra.SuspendLayout()
        Me.GeneralInformation_fra.SuspendLayout()
        Me.BillofMaterialsandTaskList_fra.SuspendLayout()
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OrderingForms_fra.SuspendLayout()
        CType(Me.MDI_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MDI_pic.SuspendLayout()
        Me.fraHdrJobInfo.SuspendLayout()
        Me.fraHdrIcons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.OrderingForms_fra)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1602, 690)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.CarTab)
        Me.TabControl1.Controls.Add(Me.OrderTab)
        Me.TabControl1.Location = New System.Drawing.Point(6, 21)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1590, 663)
        Me.TabControl1.TabIndex = 11
        '
        'CarTab
        '
        Me.CarTab.Controls.Add(Me.CarData_fra)
        Me.CarTab.Location = New System.Drawing.Point(4, 25)
        Me.CarTab.Name = "CarTab"
        Me.CarTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CarTab.Size = New System.Drawing.Size(1582, 634)
        Me.CarTab.TabIndex = 2
        Me.CarTab.UseVisualStyleBackColor = True
        '
        'CarData_fra
        '
        Me.CarData_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CarData_fra.Controls.Add(Me.GeneralInformation_fra)
        Me.CarData_fra.Controls.Add(Me.BillofMaterialsandTaskList_fra)
        Me.CarData_fra.Location = New System.Drawing.Point(1, -6)
        Me.CarData_fra.Name = "CarData_fra"
        Me.CarData_fra.Size = New System.Drawing.Size(1575, 624)
        Me.CarData_fra.TabIndex = 0
        Me.CarData_fra.TabStop = False
        '
        'GeneralInformation_fra
        '
        Me.GeneralInformation_fra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneralInformation_fra.BackColor = System.Drawing.SystemColors.Window
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
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyExistingFront_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyExistingRear_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.ExistingRisers_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyExistingFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.RiserQtyExistingRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.PitDepth_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.PitDepth_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.Travel_txt)
        Me.GeneralInformation_fra.Controls.Add(Me.Travel_lbl)
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
        Me.GeneralInformation_fra.Controls.Add(Me.ExpandCollapseFrame_btn)
        Me.GeneralInformation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralInformation_fra.Location = New System.Drawing.Point(5, 11)
        Me.GeneralInformation_fra.Name = "GeneralInformation_fra"
        Me.GeneralInformation_fra.Size = New System.Drawing.Size(1570, 215)
        Me.GeneralInformation_fra.TabIndex = 25
        Me.GeneralInformation_fra.TabStop = False
        Me.GeneralInformation_fra.Text = "   General Information"
        '
        'Destination_cmb
        '
        Me.Destination_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Destination_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Destination_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Destination_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Destination_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Destination_cmb.Location = New System.Drawing.Point(1201, 190)
        Me.Destination_cmb.Name = "Destination_cmb"
        Me.Destination_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Destination_cmb.Size = New System.Drawing.Size(119, 21)
        Me.Destination_cmb.TabIndex = 181
        '
        'Destination_lbl
        '
        Me.Destination_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Destination_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Destination_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Destination_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Destination_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Destination_lbl.Location = New System.Drawing.Point(1065, 192)
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
        Me.GatewayReviewRequired_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GatewayReviewRequired_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GatewayReviewRequired_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GatewayReviewRequired_chk.Location = New System.Drawing.Point(1065, 172)
        Me.GatewayReviewRequired_chk.Name = "GatewayReviewRequired_chk"
        Me.GatewayReviewRequired_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GatewayReviewRequired_chk.Size = New System.Drawing.Size(227, 15)
        Me.GatewayReviewRequired_chk.TabIndex = 180
        Me.GatewayReviewRequired_chk.Text = "Gateway Review Required"
        Me.GatewayReviewRequired_chk.UseVisualStyleBackColor = False
        '
        'ExpensesPerDayDetails_btn
        '
        Me.ExpensesPerDayDetails_btn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExpensesPerDayDetails_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDayDetails_btn.Location = New System.Drawing.Point(1201, 141)
        Me.ExpensesPerDayDetails_btn.Name = "ExpensesPerDayDetails_btn"
        Me.ExpensesPerDayDetails_btn.Size = New System.Drawing.Size(92, 23)
        Me.ExpensesPerDayDetails_btn.TabIndex = 179
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
        Me.ExpensesPerDay_txt.Location = New System.Drawing.Point(1201, 116)
        Me.ExpensesPerDay_txt.MaxLength = 0
        Me.ExpensesPerDay_txt.Name = "ExpensesPerDay_txt"
        Me.ExpensesPerDay_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpensesPerDay_txt.Size = New System.Drawing.Size(92, 20)
        Me.ExpensesPerDay_txt.TabIndex = 177
        Me.ExpensesPerDay_txt.Text = " "
        Me.ExpensesPerDay_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExpensesPerDay_lbl
        '
        Me.ExpensesPerDay_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExpensesPerDay_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpensesPerDay_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExpensesPerDay_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpensesPerDay_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExpensesPerDay_lbl.Location = New System.Drawing.Point(1065, 119)
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
        Me.Bonds_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bonds_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Bonds_txt.Location = New System.Drawing.Point(1201, 91)
        Me.Bonds_txt.MaxLength = 0
        Me.Bonds_txt.Name = "Bonds_txt"
        Me.Bonds_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Bonds_txt.Size = New System.Drawing.Size(92, 20)
        Me.Bonds_txt.TabIndex = 175
        Me.Bonds_txt.Text = " "
        Me.Bonds_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Bonds_lbl
        '
        Me.Bonds_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Bonds_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Bonds_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Bonds_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bonds_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Bonds_lbl.Location = New System.Drawing.Point(1065, 94)
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
        Me.ShortFloorOperation_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ShortFloorOperation_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShortFloorOperation_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ShortFloorOperation_chk.Location = New System.Drawing.Point(1065, 45)
        Me.ShortFloorOperation_chk.Name = "ShortFloorOperation_chk"
        Me.ShortFloorOperation_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShortFloorOperation_chk.Size = New System.Drawing.Size(227, 15)
        Me.ShortFloorOperation_chk.TabIndex = 174
        Me.ShortFloorOperation_chk.Text = "Short Floor Operation <14.75"""
        Me.ShortFloorOperation_chk.UseVisualStyleBackColor = False
        '
        'Permits_txt
        '
        Me.Permits_txt.AcceptsReturn = True
        Me.Permits_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Permits_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Permits_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Permits_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Permits_txt.Location = New System.Drawing.Point(1201, 66)
        Me.Permits_txt.MaxLength = 0
        Me.Permits_txt.Name = "Permits_txt"
        Me.Permits_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Permits_txt.Size = New System.Drawing.Size(92, 20)
        Me.Permits_txt.TabIndex = 172
        Me.Permits_txt.Text = " "
        Me.Permits_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Permits_lbl
        '
        Me.Permits_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Permits_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Permits_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Permits_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Permits_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Permits_lbl.Location = New System.Drawing.Point(1065, 69)
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
        Me.PEStampRequired_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PEStampRequired_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PEStampRequired_cmb.Location = New System.Drawing.Point(1201, 14)
        Me.PEStampRequired_cmb.Name = "PEStampRequired_cmb"
        Me.PEStampRequired_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PEStampRequired_cmb.Size = New System.Drawing.Size(92, 21)
        Me.PEStampRequired_cmb.TabIndex = 170
        '
        'PEStampRequired_lbl
        '
        Me.PEStampRequired_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PEStampRequired_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PEStampRequired_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PEStampRequired_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PEStampRequired_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PEStampRequired_lbl.Location = New System.Drawing.Point(1065, 17)
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
        Me.OriginalGONumberAvailable_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGONumberAvailable_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGONumberAvailable_cmb.Location = New System.Drawing.Point(932, 166)
        Me.OriginalGONumberAvailable_cmb.Name = "OriginalGONumberAvailable_cmb"
        Me.OriginalGONumberAvailable_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGONumberAvailable_cmb.Size = New System.Drawing.Size(92, 21)
        Me.OriginalGONumberAvailable_cmb.TabIndex = 166
        '
        'OriginalGOnumber_txt
        '
        Me.OriginalGOnumber_txt.AcceptsReturn = True
        Me.OriginalGOnumber_txt.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGOnumber_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OriginalGOnumber_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGOnumber_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGOnumber_txt.Location = New System.Drawing.Point(932, 190)
        Me.OriginalGOnumber_txt.MaxLength = 6
        Me.OriginalGOnumber_txt.Name = "OriginalGOnumber_txt"
        Me.OriginalGOnumber_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OriginalGOnumber_txt.Size = New System.Drawing.Size(92, 20)
        Me.OriginalGOnumber_txt.TabIndex = 167
        Me.OriginalGOnumber_txt.Text = " "
        Me.OriginalGOnumber_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'OriginalGONumberAvailable_lbl
        '
        Me.OriginalGONumberAvailable_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.OriginalGONumberAvailable_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.OriginalGONumberAvailable_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OriginalGONumberAvailable_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGONumberAvailable_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OriginalGONumberAvailable_lbl.Location = New System.Drawing.Point(796, 168)
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
        Me.OriginalGOnumber_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OriginalGOnumber_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OriginalGOnumber_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OriginalGOnumber_lbl.Location = New System.Drawing.Point(854, 192)
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
        Me.ExistingControlModel_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlModel_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingControlModel_lst.Location = New System.Drawing.Point(932, 141)
        Me.ExistingControlModel_lst.Name = "ExistingControlModel_lst"
        Me.ExistingControlModel_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlModel_lst.Size = New System.Drawing.Size(119, 21)
        Me.ExistingControlModel_lst.Sorted = True
        Me.ExistingControlModel_lst.TabIndex = 163
        '
        'ExistingControlVendor_lst
        '
        Me.ExistingControlVendor_lst.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlVendor_lst.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlVendor_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlVendor_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ExistingControlVendor_lst.Location = New System.Drawing.Point(932, 116)
        Me.ExistingControlVendor_lst.Name = "ExistingControlVendor_lst"
        Me.ExistingControlVendor_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingControlVendor_lst.Size = New System.Drawing.Size(119, 21)
        Me.ExistingControlVendor_lst.Sorted = True
        Me.ExistingControlVendor_lst.TabIndex = 162
        '
        'ExistingControlModel_lbl
        '
        Me.ExistingControlModel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingControlModel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingControlModel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingControlModel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlModel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingControlModel_lbl.Location = New System.Drawing.Point(796, 143)
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
        Me.ExistingControlVendor_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingControlVendor_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingControlVendor_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingControlVendor_lbl.Location = New System.Drawing.Point(796, 119)
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
        Me.BankCompleteDate_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BankCompleteDate_txt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BankCompleteDate_txt.Location = New System.Drawing.Point(932, 91)
        Me.BankCompleteDate_txt.Name = "BankCompleteDate_txt"
        Me.BankCompleteDate_txt.Size = New System.Drawing.Size(119, 20)
        Me.BankCompleteDate_txt.TabIndex = 159
        '
        'DTRequestedShipDate
        '
        Me.DTRequestedShipDate.Checked = False
        Me.DTRequestedShipDate.CustomFormat = "MM/dd/yyyy"
        Me.DTRequestedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTRequestedShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTRequestedShipDate.Location = New System.Drawing.Point(932, 66)
        Me.DTRequestedShipDate.Name = "DTRequestedShipDate"
        Me.DTRequestedShipDate.Size = New System.Drawing.Size(119, 20)
        Me.DTRequestedShipDate.TabIndex = 158
        '
        'lblBankCompleteDate
        '
        Me.lblBankCompleteDate.BackColor = System.Drawing.SystemColors.Window
        Me.lblBankCompleteDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBankCompleteDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBankCompleteDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankCompleteDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBankCompleteDate.Location = New System.Drawing.Point(796, 94)
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
        Me.lblRequestedShipDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblRequestedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestedShipDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRequestedShipDate.Location = New System.Drawing.Point(796, 69)
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
        Me.FixtureFinish_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixtureFinish_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FixtureFinish_cmb.Location = New System.Drawing.Point(932, 40)
        Me.FixtureFinish_cmb.Name = "FixtureFinish_cmb"
        Me.FixtureFinish_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FixtureFinish_cmb.Size = New System.Drawing.Size(119, 21)
        Me.FixtureFinish_cmb.TabIndex = 156
        '
        'FixtureFinish_lbl
        '
        Me.FixtureFinish_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.FixtureFinish_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FixtureFinish_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FixtureFinish_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixtureFinish_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FixtureFinish_lbl.Location = New System.Drawing.Point(796, 43)
        Me.FixtureFinish_lbl.Name = "FixtureFinish_lbl"
        Me.FixtureFinish_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FixtureFinish_lbl.Size = New System.Drawing.Size(134, 15)
        Me.FixtureFinish_lbl.TabIndex = 157
        Me.FixtureFinish_lbl.Text = "Fixture Finish"
        '
        'RiserQtyExistingFront_Cmb
        '
        Me.RiserQtyExistingFront_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyExistingFront_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyExistingFront_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RiserQtyExistingFront_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyExistingFront_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiserQtyExistingFront_Cmb.Location = New System.Drawing.Point(942, 14)
        Me.RiserQtyExistingFront_Cmb.Name = "RiserQtyExistingFront_Cmb"
        Me.RiserQtyExistingFront_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyExistingFront_Cmb.Size = New System.Drawing.Size(45, 21)
        Me.RiserQtyExistingFront_Cmb.TabIndex = 151
        '
        'RiserQtyExistingRear_Cmb
        '
        Me.RiserQtyExistingRear_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyExistingRear_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyExistingRear_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RiserQtyExistingRear_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyExistingRear_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiserQtyExistingRear_Cmb.Location = New System.Drawing.Point(1006, 14)
        Me.RiserQtyExistingRear_Cmb.Name = "RiserQtyExistingRear_Cmb"
        Me.RiserQtyExistingRear_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyExistingRear_Cmb.Size = New System.Drawing.Size(45, 21)
        Me.RiserQtyExistingRear_Cmb.TabIndex = 152
        '
        'ExistingRisers_lbl
        '
        Me.ExistingRisers_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ExistingRisers_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExistingRisers_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExistingRisers_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExistingRisers_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExistingRisers_lbl.Location = New System.Drawing.Point(796, 17)
        Me.ExistingRisers_lbl.Name = "ExistingRisers_lbl"
        Me.ExistingRisers_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExistingRisers_lbl.Size = New System.Drawing.Size(134, 15)
        Me.ExistingRisers_lbl.TabIndex = 155
        Me.ExistingRisers_lbl.Text = "Existing Riser Quantity"
        '
        'RiserQtyExistingFront_lbl
        '
        Me.RiserQtyExistingFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyExistingFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyExistingFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RiserQtyExistingFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyExistingFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RiserQtyExistingFront_lbl.Location = New System.Drawing.Point(932, 17)
        Me.RiserQtyExistingFront_lbl.Name = "RiserQtyExistingFront_lbl"
        Me.RiserQtyExistingFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyExistingFront_lbl.Size = New System.Drawing.Size(9, 15)
        Me.RiserQtyExistingFront_lbl.TabIndex = 154
        Me.RiserQtyExistingFront_lbl.Text = "F"
        '
        'RiserQtyExistingRear_lbl
        '
        Me.RiserQtyExistingRear_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.RiserQtyExistingRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.RiserQtyExistingRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RiserQtyExistingRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiserQtyExistingRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RiserQtyExistingRear_lbl.Location = New System.Drawing.Point(993, 17)
        Me.RiserQtyExistingRear_lbl.Name = "RiserQtyExistingRear_lbl"
        Me.RiserQtyExistingRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RiserQtyExistingRear_lbl.Size = New System.Drawing.Size(9, 15)
        Me.RiserQtyExistingRear_lbl.TabIndex = 153
        Me.RiserQtyExistingRear_lbl.Text = "R"
        '
        'PitDepth_txt
        '
        Me.PitDepth_txt.AcceptsReturn = True
        Me.PitDepth_txt.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepth_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PitDepth_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepth_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PitDepth_txt.Location = New System.Drawing.Point(662, 190)
        Me.PitDepth_txt.MaxLength = 0
        Me.PitDepth_txt.Name = "PitDepth_txt"
        Me.PitDepth_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepth_txt.Size = New System.Drawing.Size(92, 20)
        Me.PitDepth_txt.TabIndex = 149
        Me.PitDepth_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PitDepth_lbl
        '
        Me.PitDepth_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PitDepth_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PitDepth_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PitDepth_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PitDepth_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PitDepth_lbl.Location = New System.Drawing.Point(526, 192)
        Me.PitDepth_lbl.Name = "PitDepth_lbl"
        Me.PitDepth_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PitDepth_lbl.Size = New System.Drawing.Size(134, 16)
        Me.PitDepth_lbl.TabIndex = 150
        Me.PitDepth_lbl.Text = "Pit Depth"
        '
        'Travel_txt
        '
        Me.Travel_txt.AcceptsReturn = True
        Me.Travel_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Travel_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Travel_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Travel_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Travel_txt.Location = New System.Drawing.Point(662, 166)
        Me.Travel_txt.MaxLength = 0
        Me.Travel_txt.Name = "Travel_txt"
        Me.Travel_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Travel_txt.Size = New System.Drawing.Size(92, 20)
        Me.Travel_txt.TabIndex = 147
        Me.Travel_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Travel_lbl
        '
        Me.Travel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Travel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Travel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Travel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Travel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Travel_lbl.Location = New System.Drawing.Point(526, 168)
        Me.Travel_lbl.Name = "Travel_lbl"
        Me.Travel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Travel_lbl.Size = New System.Drawing.Size(134, 16)
        Me.Travel_lbl.TabIndex = 148
        Me.Travel_lbl.Text = "Travel"
        '
        'TopFloorToOverhead_txt
        '
        Me.TopFloorToOverhead_txt.AcceptsReturn = True
        Me.TopFloorToOverhead_txt.BackColor = System.Drawing.SystemColors.Window
        Me.TopFloorToOverhead_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TopFloorToOverhead_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopFloorToOverhead_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TopFloorToOverhead_txt.Location = New System.Drawing.Point(662, 141)
        Me.TopFloorToOverhead_txt.MaxLength = 0
        Me.TopFloorToOverhead_txt.Name = "TopFloorToOverhead_txt"
        Me.TopFloorToOverhead_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopFloorToOverhead_txt.Size = New System.Drawing.Size(92, 20)
        Me.TopFloorToOverhead_txt.TabIndex = 145
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
        Me.TopFloorToOverhead_lbl.Location = New System.Drawing.Point(526, 143)
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
        Me.RopingNew_Cmb.Location = New System.Drawing.Point(662, 116)
        Me.RopingNew_Cmb.Name = "RopingNew_Cmb"
        Me.RopingNew_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RopingNew_Cmb.Size = New System.Drawing.Size(119, 21)
        Me.RopingNew_Cmb.TabIndex = 143
        '
        'Roping_lbl
        '
        Me.Roping_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Roping_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Roping_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Roping_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Roping_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Roping_lbl.Location = New System.Drawing.Point(526, 119)
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
        Me.MachineLocation_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineLocation_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MachineLocation_Cmb.Location = New System.Drawing.Point(662, 91)
        Me.MachineLocation_Cmb.Name = "MachineLocation_Cmb"
        Me.MachineLocation_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineLocation_Cmb.Size = New System.Drawing.Size(119, 21)
        Me.MachineLocation_Cmb.TabIndex = 141
        '
        'MachineLocation_lbl
        '
        Me.MachineLocation_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineLocation_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineLocation_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineLocation_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineLocation_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineLocation_lbl.Location = New System.Drawing.Point(526, 94)
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
        Me.HoistMotorRpm_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorRpm_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorRpm_txt.Location = New System.Drawing.Point(662, 66)
        Me.HoistMotorRpm_txt.MaxLength = 0
        Me.HoistMotorRpm_txt.Name = "HoistMotorRpm_txt"
        Me.HoistMotorRpm_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorRpm_txt.Size = New System.Drawing.Size(92, 20)
        Me.HoistMotorRpm_txt.TabIndex = 139
        Me.HoistMotorRpm_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HoistMotorRpm_lbl
        '
        Me.HoistMotorRpm_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorRpm_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorRpm_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorRpm_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorRpm_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistMotorRpm_lbl.Location = New System.Drawing.Point(526, 69)
        Me.HoistMotorRpm_lbl.Name = "HoistMotorRpm_lbl"
        Me.HoistMotorRpm_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorRpm_lbl.Size = New System.Drawing.Size(134, 16)
        Me.HoistMotorRpm_lbl.TabIndex = 140
        Me.HoistMotorRpm_lbl.Text = "Motor RPM"
        '
        'HoistMotorHP_txt
        '
        Me.HoistMotorHP_txt.AcceptsReturn = True
        Me.HoistMotorHP_txt.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorHP_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.HoistMotorHP_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorHP_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HoistMotorHP_txt.Location = New System.Drawing.Point(662, 40)
        Me.HoistMotorHP_txt.MaxLength = 0
        Me.HoistMotorHP_txt.Name = "HoistMotorHP_txt"
        Me.HoistMotorHP_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HoistMotorHP_txt.Size = New System.Drawing.Size(92, 20)
        Me.HoistMotorHP_txt.TabIndex = 137
        Me.HoistMotorHP_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HoistMotorHP_lbl
        '
        Me.HoistMotorHP_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.HoistMotorHP_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.HoistMotorHP_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HoistMotorHP_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoistMotorHP_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HoistMotorHP_lbl.Location = New System.Drawing.Point(526, 43)
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
        Me.CarWeight_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarWeight_txt.Location = New System.Drawing.Point(662, 14)
        Me.CarWeight_txt.MaxLength = 0
        Me.CarWeight_txt.Name = "CarWeight_txt"
        Me.CarWeight_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarWeight_txt.Size = New System.Drawing.Size(92, 20)
        Me.CarWeight_txt.TabIndex = 133
        Me.CarWeight_txt.Text = " "
        Me.CarWeight_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarWeight_lbl
        '
        Me.CarWeight_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CarWeight_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarWeight_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarWeight_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarWeight_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarWeight_lbl.Location = New System.Drawing.Point(526, 17)
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
        Me.CarDoorOpeningHeightFtRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightFtRear_txt.Location = New System.Drawing.Point(410, 141)
        Me.CarDoorOpeningHeightFtRear_txt.MaxLength = 0
        Me.CarDoorOpeningHeightFtRear_txt.Name = "CarDoorOpeningHeightFtRear_txt"
        Me.CarDoorOpeningHeightFtRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightFtRear_txt.TabIndex = 125
        Me.CarDoorOpeningHeightFtRear_txt.Text = " "
        Me.CarDoorOpeningHeightFtRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightInRear_txt
        '
        Me.CarDoorOpeningHeightInRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightInRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightInRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightInRear_txt.Location = New System.Drawing.Point(461, 141)
        Me.CarDoorOpeningHeightInRear_txt.MaxLength = 0
        Me.CarDoorOpeningHeightInRear_txt.Name = "CarDoorOpeningHeightInRear_txt"
        Me.CarDoorOpeningHeightInRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightInRear_txt.TabIndex = 126
        Me.CarDoorOpeningHeightInRear_txt.Text = " "
        Me.CarDoorOpeningHeightInRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthFtRear_txt
        '
        Me.CarDoorOpeningWidthFtRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthFtRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthFtRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthFtRear_txt.Location = New System.Drawing.Point(410, 116)
        Me.CarDoorOpeningWidthFtRear_txt.MaxLength = 0
        Me.CarDoorOpeningWidthFtRear_txt.Name = "CarDoorOpeningWidthFtRear_txt"
        Me.CarDoorOpeningWidthFtRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthFtRear_txt.TabIndex = 123
        Me.CarDoorOpeningWidthFtRear_txt.Text = " "
        Me.CarDoorOpeningWidthFtRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthInRear_txt
        '
        Me.CarDoorOpeningWidthInRear_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthInRear_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthInRear_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthInRear_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInRear_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthInRear_txt.Location = New System.Drawing.Point(461, 116)
        Me.CarDoorOpeningWidthInRear_txt.MaxLength = 0
        Me.CarDoorOpeningWidthInRear_txt.Name = "CarDoorOpeningWidthInRear_txt"
        Me.CarDoorOpeningWidthInRear_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInRear_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthInRear_txt.TabIndex = 124
        Me.CarDoorOpeningWidthInRear_txt.Text = " "
        Me.CarDoorOpeningWidthInRear_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightFtRear_lbl
        '
        Me.CarDoorOpeningHeightFtRear_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningHeightFtRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightFtRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFtRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFtRear_lbl.Location = New System.Drawing.Point(447, 143)
        Me.CarDoorOpeningHeightFtRear_lbl.Name = "CarDoorOpeningHeightFtRear_lbl"
        Me.CarDoorOpeningHeightFtRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightFtRear_lbl.TabIndex = 132
        Me.CarDoorOpeningHeightFtRear_lbl.Text = "Ft"
        '
        'CarDoorOpeningHeightInRear_lbl
        '
        Me.CarDoorOpeningHeightInRear_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningHeightInRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightInRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightInRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightInRear_lbl.Location = New System.Drawing.Point(499, 143)
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
        Me.CarDoorOpeningHeightRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightRear_lbl.Location = New System.Drawing.Point(276, 143)
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
        Me.CarDoorOpeningWidthRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthRear_lbl.Location = New System.Drawing.Point(276, 119)
        Me.CarDoorOpeningWidthRear_lbl.Name = "CarDoorOpeningWidthRear_lbl"
        Me.CarDoorOpeningWidthRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthRear_lbl.Size = New System.Drawing.Size(134, 17)
        Me.CarDoorOpeningWidthRear_lbl.TabIndex = 129
        Me.CarDoorOpeningWidthRear_lbl.Text = "Rear Door Width"
        '
        'CarDoorOpeningWidthFtRear_lbl
        '
        Me.CarDoorOpeningWidthFtRear_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningWidthFtRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthFtRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFtRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFtRear_lbl.Location = New System.Drawing.Point(447, 119)
        Me.CarDoorOpeningWidthFtRear_lbl.Name = "CarDoorOpeningWidthFtRear_lbl"
        Me.CarDoorOpeningWidthFtRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtRear_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthFtRear_lbl.TabIndex = 128
        Me.CarDoorOpeningWidthFtRear_lbl.Text = "Ft"
        '
        'CarDoorOpeningWidthInRear_lbl
        '
        Me.CarDoorOpeningWidthInRear_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningWidthInRear_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthInRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthInRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthInRear_lbl.Location = New System.Drawing.Point(499, 119)
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
        Me.CarDoorOpeningWidthInFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthInFront_txt.Location = New System.Drawing.Point(461, 40)
        Me.CarDoorOpeningWidthInFront_txt.MaxLength = 0
        Me.CarDoorOpeningWidthInFront_txt.Name = "CarDoorOpeningWidthInFront_txt"
        Me.CarDoorOpeningWidthInFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthInFront_txt.TabIndex = 114
        Me.CarDoorOpeningWidthInFront_txt.Text = " "
        Me.CarDoorOpeningWidthInFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthFtFront_txt
        '
        Me.CarDoorOpeningWidthFtFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningWidthFtFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningWidthFtFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningWidthFtFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningWidthFtFront_txt.Location = New System.Drawing.Point(410, 40)
        Me.CarDoorOpeningWidthFtFront_txt.MaxLength = 0
        Me.CarDoorOpeningWidthFtFront_txt.Name = "CarDoorOpeningWidthFtFront_txt"
        Me.CarDoorOpeningWidthFtFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthFtFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningWidthFtFront_txt.TabIndex = 113
        Me.CarDoorOpeningWidthFtFront_txt.Text = " "
        Me.CarDoorOpeningWidthFtFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightInFront_txt
        '
        Me.CarDoorOpeningHeightInFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightInFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightInFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightInFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightInFront_txt.Location = New System.Drawing.Point(461, 66)
        Me.CarDoorOpeningHeightInFront_txt.MaxLength = 0
        Me.CarDoorOpeningHeightInFront_txt.Name = "CarDoorOpeningHeightInFront_txt"
        Me.CarDoorOpeningHeightInFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightInFront_txt.TabIndex = 116
        Me.CarDoorOpeningHeightInFront_txt.Text = " "
        Me.CarDoorOpeningHeightInFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningHeightFtFront_txt
        '
        Me.CarDoorOpeningHeightFtFront_txt.AcceptsReturn = True
        Me.CarDoorOpeningHeightFtFront_txt.BackColor = System.Drawing.SystemColors.Window
        Me.CarDoorOpeningHeightFtFront_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CarDoorOpeningHeightFtFront_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtFront_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CarDoorOpeningHeightFtFront_txt.Location = New System.Drawing.Point(410, 66)
        Me.CarDoorOpeningHeightFtFront_txt.MaxLength = 0
        Me.CarDoorOpeningHeightFtFront_txt.Name = "CarDoorOpeningHeightFtFront_txt"
        Me.CarDoorOpeningHeightFtFront_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFtFront_txt.Size = New System.Drawing.Size(35, 20)
        Me.CarDoorOpeningHeightFtFront_txt.TabIndex = 115
        Me.CarDoorOpeningHeightFtFront_txt.Text = " "
        Me.CarDoorOpeningHeightFtFront_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarDoorOpeningWidthInFront_lbl
        '
        Me.CarDoorOpeningWidthInFront_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningWidthInFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthInFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthInFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthInFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthInFront_lbl.Location = New System.Drawing.Point(499, 43)
        Me.CarDoorOpeningWidthInFront_lbl.Name = "CarDoorOpeningWidthInFront_lbl"
        Me.CarDoorOpeningWidthInFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningWidthInFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningWidthInFront_lbl.TabIndex = 122
        Me.CarDoorOpeningWidthInFront_lbl.Text = "In"
        '
        'CarDoorOpeningWidthFtFront_lbl
        '
        Me.CarDoorOpeningWidthFtFront_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningWidthFtFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningWidthFtFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFtFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFtFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFtFront_lbl.Location = New System.Drawing.Point(447, 43)
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
        Me.CarDoorOpeningWidthFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningWidthFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningWidthFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningWidthFront_lbl.Location = New System.Drawing.Point(276, 43)
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
        Me.CarDoorOpeningHeightFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFront_lbl.Location = New System.Drawing.Point(276, 69)
        Me.CarDoorOpeningHeightFront_lbl.Name = "CarDoorOpeningHeightFront_lbl"
        Me.CarDoorOpeningHeightFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightFront_lbl.Size = New System.Drawing.Size(134, 19)
        Me.CarDoorOpeningHeightFront_lbl.TabIndex = 119
        Me.CarDoorOpeningHeightFront_lbl.Text = "Front Door Height"
        '
        'CarDoorOpeningHeightInFront_lbl
        '
        Me.CarDoorOpeningHeightInFront_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningHeightInFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightInFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightInFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightInFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightInFront_lbl.Location = New System.Drawing.Point(499, 69)
        Me.CarDoorOpeningHeightInFront_lbl.Name = "CarDoorOpeningHeightInFront_lbl"
        Me.CarDoorOpeningHeightInFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CarDoorOpeningHeightInFront_lbl.Size = New System.Drawing.Size(17, 15)
        Me.CarDoorOpeningHeightInFront_lbl.TabIndex = 118
        Me.CarDoorOpeningHeightInFront_lbl.Text = "In"
        '
        'CarDoorOpeningHeightFtFront_lbl
        '
        Me.CarDoorOpeningHeightFtFront_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.CarDoorOpeningHeightFtFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CarDoorOpeningHeightFtFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CarDoorOpeningHeightFtFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CarDoorOpeningHeightFtFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CarDoorOpeningHeightFtFront_lbl.Location = New System.Drawing.Point(447, 69)
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
        Me.Application_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Application_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Application_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Application_lbl.Location = New System.Drawing.Point(8, 168)
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
        Me.PowerSupply_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerSupply_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PowerSupply_cmb.Location = New System.Drawing.Point(144, 141)
        Me.PowerSupply_cmb.Name = "PowerSupply_cmb"
        Me.PowerSupply_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PowerSupply_cmb.Size = New System.Drawing.Size(92, 21)
        Me.PowerSupply_cmb.TabIndex = 109
        '
        'PowerSupply_lbl
        '
        Me.PowerSupply_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.PowerSupply_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PowerSupply_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PowerSupply_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerSupply_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PowerSupply_lbl.Location = New System.Drawing.Point(8, 143)
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
        Me.Application_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Application_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Application_cmb.Location = New System.Drawing.Point(144, 166)
        Me.Application_cmb.Name = "Application_cmb"
        Me.Application_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Application_cmb.Size = New System.Drawing.Size(119, 21)
        Me.Application_cmb.TabIndex = 110
        '
        'LayoutRequirements_cmb
        '
        Me.LayoutRequirements_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.LayoutRequirements_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.LayoutRequirements_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LayoutRequirements_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutRequirements_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LayoutRequirements_cmb.Location = New System.Drawing.Point(144, 190)
        Me.LayoutRequirements_cmb.Name = "LayoutRequirements_cmb"
        Me.LayoutRequirements_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LayoutRequirements_cmb.Size = New System.Drawing.Size(92, 21)
        Me.LayoutRequirements_cmb.TabIndex = 107
        '
        'LayoutRequirements_lbl
        '
        Me.LayoutRequirements_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.LayoutRequirements_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.LayoutRequirements_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LayoutRequirements_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutRequirements_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LayoutRequirements_lbl.Location = New System.Drawing.Point(8, 192)
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
        Me.DoorOperatorTypeRear_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DoorOperatorTypeRear_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeRear_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DoorOperatorTypeRear_lbl.Location = New System.Drawing.Point(276, 94)
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
        Me.DoorOperatorTypeFront_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeFront_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoorOperatorTypeFront_cmb.Location = New System.Drawing.Point(410, 14)
        Me.DoorOperatorTypeFront_cmb.Name = "DoorOperatorTypeFront_cmb"
        Me.DoorOperatorTypeFront_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeFront_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DoorOperatorTypeFront_cmb.TabIndex = 103
        '
        'DoorOperatorTypeFront_lbl
        '
        Me.DoorOperatorTypeFront_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DoorOperatorTypeFront_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoorOperatorTypeFront_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DoorOperatorTypeFront_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeFront_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DoorOperatorTypeFront_lbl.Location = New System.Drawing.Point(276, 17)
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
        Me.DoorOperatorTypeRear_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoorOperatorTypeRear_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoorOperatorTypeRear_cmb.Location = New System.Drawing.Point(410, 91)
        Me.DoorOperatorTypeRear_cmb.Name = "DoorOperatorTypeRear_cmb"
        Me.DoorOperatorTypeRear_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DoorOperatorTypeRear_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DoorOperatorTypeRear_cmb.TabIndex = 104
        '
        'DriveType_cmb
        '
        Me.DriveType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DriveType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DriveType_cmb.Location = New System.Drawing.Point(410, 190)
        Me.DriveType_cmb.Name = "DriveType_cmb"
        Me.DriveType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DriveType_cmb.Size = New System.Drawing.Size(92, 21)
        Me.DriveType_cmb.TabIndex = 101
        '
        'DriveType_lbl
        '
        Me.DriveType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.DriveType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.DriveType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DriveType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DriveType_lbl.Location = New System.Drawing.Point(276, 192)
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
        Me.MachineType_cmb.Location = New System.Drawing.Point(410, 166)
        Me.MachineType_cmb.Name = "MachineType_cmb"
        Me.MachineType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MachineType_cmb.Size = New System.Drawing.Size(92, 21)
        Me.MachineType_cmb.Sorted = True
        Me.MachineType_cmb.TabIndex = 99
        '
        'MachineType_lbl
        '
        Me.MachineType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.MachineType_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.MachineType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MachineType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MachineType_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MachineType_lbl.Location = New System.Drawing.Point(276, 168)
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
        Me.NumberofStopsTotal_cmb.Location = New System.Drawing.Point(144, 66)
        Me.NumberofStopsTotal_cmb.Name = "NumberofStopsTotal_cmb"
        Me.NumberofStopsTotal_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotal_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsTotal_cmb.TabIndex = 32
        '
        'NumberofStopsTotal_lbl
        '
        Me.NumberofStopsTotal_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotal_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotal_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsTotal_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotal_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsTotal_lbl.Location = New System.Drawing.Point(8, 69)
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
        Me.NumberofStopsFront_lbl.Location = New System.Drawing.Point(8, 94)
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
        Me.NumberofStopsRear_lbl.Location = New System.Drawing.Point(8, 119)
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
        Me.NumberofStopsFront_cmb.Location = New System.Drawing.Point(144, 91)
        Me.NumberofStopsFront_cmb.Name = "NumberofStopsFront_cmb"
        Me.NumberofStopsFront_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFront_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsFront_cmb.TabIndex = 33
        '
        'NumberofStopsRear_cmb
        '
        Me.NumberofStopsRear_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRear_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRear_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRear_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsRear_cmb.Location = New System.Drawing.Point(144, 116)
        Me.NumberofStopsRear_cmb.Name = "NumberofStopsRear_cmb"
        Me.NumberofStopsRear_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRear_cmb.Size = New System.Drawing.Size(92, 21)
        Me.NumberofStopsRear_cmb.TabIndex = 34
        '
        'SpeedNew_cmb
        '
        Me.SpeedNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpeedNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedNew_cmb.Location = New System.Drawing.Point(144, 40)
        Me.SpeedNew_cmb.Name = "SpeedNew_cmb"
        Me.SpeedNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedNew_cmb.Size = New System.Drawing.Size(92, 21)
        Me.SpeedNew_cmb.TabIndex = 24
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
        Me.CapacityNew_cmb.TabIndex = 23
        '
        'SpeedLabel_lbl
        '
        Me.SpeedLabel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedLabel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedLabel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedLabel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedLabel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedLabel_lbl.Location = New System.Drawing.Point(8, 43)
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
        'ExpandCollapseFrame_btn
        '
        Me.ExpandCollapseFrame_btn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ExpandCollapseFrame_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExpandCollapseFrame_btn.Location = New System.Drawing.Point(1, -1)
        Me.ExpandCollapseFrame_btn.Name = "ExpandCollapseFrame_btn"
        Me.ExpandCollapseFrame_btn.Size = New System.Drawing.Size(20, 19)
        Me.ExpandCollapseFrame_btn.TabIndex = 3
        Me.ExpandCollapseFrame_btn.UseVisualStyleBackColor = True
        '
        'BillofMaterialsandTaskList_fra
        '
        Me.BillofMaterialsandTaskList_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.ExpandAll_cmd)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.BillOfMaterials_spr)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.CollapseAll_cmd)
        Me.BillofMaterialsandTaskList_fra.Location = New System.Drawing.Point(4, 231)
        Me.BillofMaterialsandTaskList_fra.Name = "BillofMaterialsandTaskList_fra"
        Me.BillofMaterialsandTaskList_fra.Size = New System.Drawing.Size(1573, 386)
        Me.BillofMaterialsandTaskList_fra.TabIndex = 80
        Me.BillofMaterialsandTaskList_fra.TabStop = False
        Me.BillofMaterialsandTaskList_fra.Text = "Bill of Materials and Task List"
        '
        'ExpandAll_cmd
        '
        Me.ExpandAll_cmd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExpandAll_cmd.Location = New System.Drawing.Point(602, 14)
        Me.ExpandAll_cmd.Name = "ExpandAll_cmd"
        Me.ExpandAll_cmd.Size = New System.Drawing.Size(113, 23)
        Me.ExpandAll_cmd.TabIndex = 81
        Me.ExpandAll_cmd.Text = "Expand All"
        Me.ExpandAll_cmd.UseVisualStyleBackColor = True
        '
        'BillOfMaterials_spr
        '
        Me.BillOfMaterials_spr.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.BillOfMaterials_spr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillOfMaterials_spr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillOfMaterials_spr.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.BillOfMaterials_spr.Location = New System.Drawing.Point(6, 43)
        Me.BillOfMaterials_spr.Name = "BillOfMaterials_spr"
        Me.BillOfMaterials_spr.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.BillOfMaterials_spr_Sheet1})
        Me.BillOfMaterials_spr.Size = New System.Drawing.Size(1563, 337)
        Me.BillOfMaterials_spr.TabIndex = 80
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
        Me.CollapseAll_cmd.Location = New System.Drawing.Point(858, 14)
        Me.CollapseAll_cmd.Name = "CollapseAll_cmd"
        Me.CollapseAll_cmd.Size = New System.Drawing.Size(113, 23)
        Me.CollapseAll_cmd.TabIndex = 82
        Me.CollapseAll_cmd.Text = "Collapse All"
        Me.CollapseAll_cmd.UseVisualStyleBackColor = True
        '
        'OrderTab
        '
        Me.OrderTab.Location = New System.Drawing.Point(4, 25)
        Me.OrderTab.Name = "OrderTab"
        Me.OrderTab.Padding = New System.Windows.Forms.Padding(3)
        Me.OrderTab.Size = New System.Drawing.Size(1582, 634)
        Me.OrderTab.TabIndex = 1
        Me.OrderTab.UseVisualStyleBackColor = True
        '
        'OrderingForms_fra
        '
        Me.OrderingForms_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OrderingForms_fra.Controls.Add(Me.OrderingForms_lst)
        Me.OrderingForms_fra.Controls.Add(Me.OrderingForms_con)
        Me.OrderingForms_fra.Location = New System.Drawing.Point(11, 48)
        Me.OrderingForms_fra.Name = "OrderingForms_fra"
        Me.OrderingForms_fra.Size = New System.Drawing.Size(1575, 624)
        Me.OrderingForms_fra.TabIndex = 55
        Me.OrderingForms_fra.TabStop = False
        Me.OrderingForms_fra.Visible = False
        '
        'OrderingForms_lst
        '
        Me.OrderingForms_lst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OrderingForms_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderingForms_lst.FormattingEnabled = True
        Me.OrderingForms_lst.Location = New System.Drawing.Point(2, 12)
        Me.OrderingForms_lst.Name = "OrderingForms_lst"
        Me.OrderingForms_lst.Size = New System.Drawing.Size(116, 602)
        Me.OrderingForms_lst.TabIndex = 0
        '
        'OrderingForms_con
        '
        Me.OrderingForms_con.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OrderingForms_con.AutoScroll = True
        Me.OrderingForms_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OrderingForms_con.Location = New System.Drawing.Point(120, 12)
        Me.OrderingForms_con.Name = "OrderingForms_con"
        Me.OrderingForms_con.Size = New System.Drawing.Size(1483, 606)
        Me.OrderingForms_con.TabIndex = 53
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
        Me.MDI_pic.Size = New System.Drawing.Size(1602, 99)
        Me.MDI_pic.TabIndex = 24
        Me.MDI_pic.TabStop = False
        '
        'fraHdrJobInfo
        '
        Me.fraHdrJobInfo.BackColor = System.Drawing.SystemColors.Control
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrAltLetter)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrBnkLetter)
        Me.fraHdrJobInfo.Controls.Add(Me.Units_txt)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrGONegNum)
        Me.fraHdrJobInfo.Controls.Add(Me.HdrGONum_txt)
        Me.fraHdrJobInfo.Controls.Add(Me.txtHdrBldgName)
        Me.fraHdrJobInfo.Controls.Add(Me.Label1)
        Me.fraHdrJobInfo.Controls.Add(Me.Label2)
        Me.fraHdrJobInfo.Controls.Add(Me.lblHdrGONegNum)
        Me.fraHdrJobInfo.Controls.Add(Me.HdrGONum_lbl)
        Me.fraHdrJobInfo.Controls.Add(Me.lblHdrBldgNme)
        Me.fraHdrJobInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraHdrJobInfo.Font = New System.Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHdrJobInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHdrJobInfo.Location = New System.Drawing.Point(0, 60)
        Me.fraHdrJobInfo.Name = "fraHdrJobInfo"
        Me.fraHdrJobInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHdrJobInfo.Size = New System.Drawing.Size(1598, 30)
        Me.fraHdrJobInfo.TabIndex = 25
        Me.fraHdrJobInfo.TabStop = False
        '
        'txtHdrAltLetter
        '
        Me.txtHdrAltLetter.AcceptsReturn = True
        Me.txtHdrAltLetter.BackColor = System.Drawing.SystemColors.Window
        Me.txtHdrAltLetter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHdrAltLetter.Enabled = False
        Me.txtHdrAltLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHdrAltLetter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHdrAltLetter.Location = New System.Drawing.Point(644, 6)
        Me.txtHdrAltLetter.MaxLength = 0
        Me.txtHdrAltLetter.Name = "txtHdrAltLetter"
        Me.txtHdrAltLetter.ReadOnly = True
        Me.txtHdrAltLetter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHdrAltLetter.Size = New System.Drawing.Size(20, 20)
        Me.txtHdrAltLetter.TabIndex = 20
        Me.txtHdrAltLetter.Text = "A"
        Me.txtHdrAltLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtHdrBnkLetter.TabIndex = 19
        Me.txtHdrBnkLetter.Text = "A"
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
        Me.Units_txt.TabIndex = 21
        Me.Units_txt.Text = "01-04"
        Me.Units_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHdrGONegNum
        '
        Me.txtHdrGONegNum.AcceptsReturn = True
        Me.txtHdrGONegNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtHdrGONegNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHdrGONegNum.Enabled = False
        Me.txtHdrGONegNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHdrGONegNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHdrGONegNum.Location = New System.Drawing.Point(451, 6)
        Me.txtHdrGONegNum.MaxLength = 0
        Me.txtHdrGONegNum.Name = "txtHdrGONegNum"
        Me.txtHdrGONegNum.ReadOnly = True
        Me.txtHdrGONegNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHdrGONegNum.Size = New System.Drawing.Size(105, 20)
        Me.txtHdrGONegNum.TabIndex = 18
        Me.txtHdrGONegNum.Text = "ZZZZ-00000"
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
        Me.HdrGONum_txt.TabIndex = 16
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
        Me.txtHdrBldgName.TabIndex = 17
        Me.txtHdrBldgName.Text = "Queen Tower"
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
        Me.Label1.Text = "Bank - Alt"
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
        'lblHdrGONegNum
        '
        Me.lblHdrGONegNum.BackColor = System.Drawing.SystemColors.Control
        Me.lblHdrGONegNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHdrGONegNum.Enabled = False
        Me.lblHdrGONegNum.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblHdrGONegNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHdrGONegNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHdrGONegNum.Location = New System.Drawing.Point(384, 8)
        Me.lblHdrGONegNum.Name = "lblHdrGONegNum"
        Me.lblHdrGONegNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHdrGONegNum.Size = New System.Drawing.Size(67, 19)
        Me.lblHdrGONegNum.TabIndex = 31
        Me.lblHdrGONegNum.Text = "Estimate # "
        Me.lblHdrGONegNum.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.fraHdrIcons.Controls.Add(Me.Merge_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Copy_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Supt_cmd)
        Me.fraHdrIcons.Controls.Add(Me.FreezeSave_btn)
        Me.fraHdrIcons.Controls.Add(Me.Exit_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Save_cmd)
        Me.fraHdrIcons.Controls.Add(Me.CMMain_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Screen_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Forms_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Book_cmd)
        Me.fraHdrIcons.Controls.Add(Me.Config_cmd)
        Me.fraHdrIcons.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraHdrIcons.Font = New System.Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHdrIcons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHdrIcons.Location = New System.Drawing.Point(0, 0)
        Me.fraHdrIcons.Name = "fraHdrIcons"
        Me.fraHdrIcons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHdrIcons.Size = New System.Drawing.Size(1598, 60)
        Me.fraHdrIcons.TabIndex = 24
        Me.fraHdrIcons.TabStop = False
        '
        'Merge_cmd
        '
        Me.Merge_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Merge_cmd.Image = CType(resources.GetObject("Merge_cmd.Image"), System.Drawing.Image)
        Me.Merge_cmd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Merge_cmd.Location = New System.Drawing.Point(309, 8)
        Me.Merge_cmd.Name = "Merge_cmd"
        Me.Merge_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Merge_cmd.TabIndex = 42
        Me.Merge_cmd.TabStop = False
        Me.Merge_cmd.Tag = "Merge Cars"
        Me.Merge_cmd.Text = "Merge"
        Me.Merge_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Copy_cmd
        '
        Me.Copy_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copy_cmd.Image = CType(resources.GetObject("Copy_cmd.Image"), System.Drawing.Image)
        Me.Copy_cmd.Location = New System.Drawing.Point(259, 8)
        Me.Copy_cmd.Name = "Copy_cmd"
        Me.Copy_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Copy_cmd.TabIndex = 41
        Me.Copy_cmd.TabStop = False
        Me.Copy_cmd.Tag = "Copy Cars"
        Me.Copy_cmd.Text = "Copy"
        Me.Copy_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Supt_cmd
        '
        Me.Supt_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Supt_cmd.Image = CType(resources.GetObject("Supt_cmd.Image"), System.Drawing.Image)
        Me.Supt_cmd.Location = New System.Drawing.Point(909, 7)
        Me.Supt_cmd.Name = "Supt_cmd"
        Me.Supt_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Supt_cmd.TabIndex = 40
        Me.Supt_cmd.TabStop = False
        Me.Supt_cmd.Tag = "Supt"
        Me.Supt_cmd.Text = "Supt"
        Me.Supt_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'FreezeSave_btn
        '
        Me.FreezeSave_btn.Enabled = False
        Me.FreezeSave_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreezeSave_btn.Location = New System.Drawing.Point(957, 8)
        Me.FreezeSave_btn.Name = "FreezeSave_btn"
        Me.FreezeSave_btn.Size = New System.Drawing.Size(46, 46)
        Me.FreezeSave_btn.TabIndex = 39
        Me.FreezeSave_btn.TabStop = False
        Me.FreezeSave_btn.Text = "Freeze"
        Me.FreezeSave_btn.Visible = False
        '
        'Exit_cmd
        '
        Me.Exit_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_cmd.Image = CType(resources.GetObject("Exit_cmd.Image"), System.Drawing.Image)
        Me.Exit_cmd.Location = New System.Drawing.Point(0, 8)
        Me.Exit_cmd.Name = "Exit_cmd"
        Me.Exit_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Exit_cmd.TabIndex = 0
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
        Me.Save_cmd.TabIndex = 1
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
        Me.CMMain_cmd.TabIndex = 6
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
        Me.Screen_cmd.TabIndex = 10
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
        Me.Forms_cmd.TabIndex = 11
        Me.Forms_cmd.TabStop = False
        Me.Forms_cmd.Tag = "Print Forms"
        Me.Forms_cmd.Text = "Forms"
        Me.Forms_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Book_cmd
        '
        Me.Book_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Book_cmd.Image = CType(resources.GetObject("Book_cmd.Image"), System.Drawing.Image)
        Me.Book_cmd.Location = New System.Drawing.Point(762, 8)
        Me.Book_cmd.Name = "Book_cmd"
        Me.Book_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Book_cmd.TabIndex = 15
        Me.Book_cmd.TabStop = False
        Me.Book_cmd.Tag = "Create Booking File"
        Me.Book_cmd.Text = "Book"
        Me.Book_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Config_cmd
        '
        Me.Config_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Config_cmd.Image = CType(resources.GetObject("Config_cmd.Image"), System.Drawing.Image)
        Me.Config_cmd.Location = New System.Drawing.Point(810, 8)
        Me.Config_cmd.Name = "Config_cmd"
        Me.Config_cmd.Size = New System.Drawing.Size(46, 46)
        Me.Config_cmd.TabIndex = 34
        Me.Config_cmd.TabStop = False
        Me.Config_cmd.Tag = "Create Config File"
        Me.Config_cmd.Text = "Config"
        Me.Config_cmd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmEstimatingBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1602, 795)
        Me.Controls.Add(Me.MDI_pic)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstimatingBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOD Estimating"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.CarTab.ResumeLayout(False)
        Me.CarData_fra.ResumeLayout(False)
        Me.GeneralInformation_fra.ResumeLayout(False)
        Me.GeneralInformation_fra.PerformLayout()
        Me.BillofMaterialsandTaskList_fra.ResumeLayout(False)
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OrderingForms_fra.ResumeLayout(False)
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
    Public WithEvents txtHdrAltLetter As System.Windows.Forms.TextBox
    Public WithEvents txtHdrBnkLetter As System.Windows.Forms.TextBox
    Public WithEvents Units_txt As System.Windows.Forms.TextBox
    Public WithEvents txtHdrGONegNum As System.Windows.Forms.TextBox
    Public WithEvents HdrGONum_txt As System.Windows.Forms.TextBox
    Public WithEvents txtHdrBldgName As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblHdrGONegNum As System.Windows.Forms.Label
    Public WithEvents HdrGONum_lbl As System.Windows.Forms.Label
    Public WithEvents lblHdrBldgNme As System.Windows.Forms.Label
    Public WithEvents fraHdrIcons As System.Windows.Forms.GroupBox
    Private WithEvents Supt_cmd As System.Windows.Forms.Button
    Public WithEvents FreezeSave_btn As System.Windows.Forms.Button
    Private WithEvents Exit_cmd As System.Windows.Forms.Button
    Private WithEvents Save_cmd As System.Windows.Forms.Button
    Private WithEvents CMMain_cmd As System.Windows.Forms.Button
    Private WithEvents Screen_cmd As System.Windows.Forms.Button
    Private WithEvents Forms_cmd As System.Windows.Forms.Button
    Private WithEvents Book_cmd As System.Windows.Forms.Button
    Private WithEvents Config_cmd As System.Windows.Forms.Button
    Friend WithEvents GeneralInformation_fra As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ExpandCollapseFrame_btn As System.Windows.Forms.Button
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
    Public WithEvents Travel_txt As System.Windows.Forms.TextBox
    Public WithEvents Travel_lbl As System.Windows.Forms.Label
    Public WithEvents TopFloorToOverhead_txt As System.Windows.Forms.TextBox
    Public WithEvents TopFloorToOverhead_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyExistingFront_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents RiserQtyExistingRear_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents ExistingRisers_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyExistingFront_lbl As System.Windows.Forms.Label
    Public WithEvents RiserQtyExistingRear_lbl As System.Windows.Forms.Label
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
    Private WithEvents Merge_cmd As System.Windows.Forms.Button
    Private WithEvents Copy_cmd As System.Windows.Forms.Button
    Friend WithEvents CarTab As System.Windows.Forms.TabPage
    Friend WithEvents OrderTab As System.Windows.Forms.TabPage
    Friend WithEvents OrderingForms_fra As System.Windows.Forms.GroupBox
    Friend WithEvents OrderingForms_con As System.Windows.Forms.Panel
    Friend WithEvents OrderingForms_lst As System.Windows.Forms.ListBox
    Public WithEvents Destination_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Destination_lbl As System.Windows.Forms.Label

#End Region
End Class
