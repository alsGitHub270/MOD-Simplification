<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CM_MAIN_frm
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        ' isInitializingComponent = True
        InitializeComponent()
        '   isInitializingComponent = False
        '    ReLoadForm(False)
        'Add any initialization after the InitializeComponent() call


    End Sub
    Private visualControls() As String = New String() {"components", "ToolTipMain", "CostPriceView_cmb", "CostPrice_grd", "Totals_grd", "CostPriceView_lbl", "CostPrice_fra", "Comments_txt", "Comments_fra", "AgentFor_txt", "Company_txt", "ContactName_txt", "ContactCity_txt", "ContactAddress2_txt", "ContactAddress_txt", "ContactState_txt", "ContactZip_txt", "Agentfor_lbl", "Company_lbl", "ContactName_lbl", "ContactZip_lbl", "ContactState_lbl", "ContactCity_lbl", "ContactAddress_lbl", "Contact_fra", "ServiceOffice_cmb", "InstallingOffice_cmb", "SalesRep_lst", "ProbabilityOfSale_lst", "Status_cmb", "SalesOffice_lst", "ServiceOffice_lbl", "ProbabilityOfSale_lbl", "Status_lbl", "_label_7", "InstallingOffice_lbl", "SalesOffice_lbl", "Job_Info_Fra", "_Forms_btn_0", "JobAddress2_txt", "JobCity_txt", "JobAddress_txt", "JobName_txt", "JobState_txt", "JobZip_txt", "_label_14", "_label_12", "_label_10", "_label_9", "_label_8", "Customer_Info_Fra", "GO_grd", "_Forms_btn_1", "_Forms_btn_2", "_Action_btn_0", "_Action_btn_1", "_JobHighRiskFactor_lbl_1", "_JobHighRiskFactor_lbl_0", "Equipment_fra", "Scope_grd", "Scope_fra", "Hidden_pic", "_Menu_tlb_2", "EstimateNum_txt", "Estimator_txt", "_Menu_tlb_0", "_Menu_tlb_1", "_Menu_tlb_3", "_Menu_tlb_4", "_label_0", "_label_4", "TodaysDate_lbl", "Menu_pic", "_StatusBar1_Panel1", "_StatusBar1_Panel2", "_StatusBar1_Panel3", "_StatusBar1_Panel4", "StatusBar1", "Action_frm", "Action_btn", "Forms_btn", "JobHighRiskFactor_lbl", "Menu_tlb", "label", "Scope_grd_Sheet1", "GO_grd_Sheet1", "Totals_grd_Sheet1", "CostPrice_grd_Sheet1"}
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Public WithEvents BuildingInformation_fra As System.Windows.Forms.GroupBox
    Public WithEvents txtJobAddress2 As System.Windows.Forms.TextBox
    Public WithEvents txtJobCity As System.Windows.Forms.TextBox
    Public WithEvents txtJobAddress As System.Windows.Forms.TextBox
    Public WithEvents txtJobName As System.Windows.Forms.TextBox
    Public WithEvents txtJobState As System.Windows.Forms.MaskedTextBox
    Public WithEvents txtJobZip As System.Windows.Forms.MaskedTextBox
    Private WithEvents _label_14 As System.Windows.Forms.Label
    Private WithEvents _label_12 As System.Windows.Forms.Label
    Private WithEvents _label_10 As System.Windows.Forms.Label
    Private WithEvents _label_9 As System.Windows.Forms.Label
    Private WithEvents _label_8 As System.Windows.Forms.Label
    Private WithEvents btn_Help As System.Windows.Forms.Button
    Private WithEvents _StatusBar1_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents _StatusBar1_Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents _StatusBar1_Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents _StatusBar1_Panel4 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
    Public Action_btn(1) As System.Windows.Forms.Button
    Public Forms_btn(2) As System.Windows.Forms.Button
    Public JobHighRiskFactor_lbl(1) As System.Windows.Forms.Label
    Public Menu_tlb(4) As System.Windows.Forms.Button
    Public label(14) As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CM_MAIN_frm))
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.BuildingInformation_fra = New System.Windows.Forms.GroupBox()
        Me.cboSupt = New System.Windows.Forms.ComboBox()
        Me.lblSupt = New System.Windows.Forms.Label()
        Me.txtContractNumber = New System.Windows.Forms.TextBox()
        Me.lblContractNumber = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTaxRate = New System.Windows.Forms.TextBox()
        Me.ExpandCollapseFrame_btn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTaxCode = New System.Windows.Forms.ComboBox()
        Me.lblNationalAccount = New System.Windows.Forms.Label()
        Me.cboNationalAccount = New System.Windows.Forms.ComboBox()
        Me.txtConsultant = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBidDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBuildingType = New System.Windows.Forms.ComboBox()
        Me.lblBuildingType = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me._label_7 = New System.Windows.Forms.Label()
        Me.Status_lbl = New System.Windows.Forms.Label()
        Me.cboSalesRep = New System.Windows.Forms.ComboBox()
        Me.cboInstallingOffice = New System.Windows.Forms.ComboBox()
        Me.cboServiceOffice = New System.Windows.Forms.ComboBox()
        Me.SalesOffice_lbl = New System.Windows.Forms.Label()
        Me.InstallingOffice_lbl = New System.Windows.Forms.Label()
        Me.cboSalesOffice = New System.Windows.Forms.ComboBox()
        Me.ServiceOffice_lbl = New System.Windows.Forms.Label()
        Me.cboProbabilityOfSale = New System.Windows.Forms.ComboBox()
        Me.ProbabilityOfSale_lbl = New System.Windows.Forms.Label()
        Me.txtJobAddress2 = New System.Windows.Forms.TextBox()
        Me.txtJobCity = New System.Windows.Forms.TextBox()
        Me.txtJobAddress = New System.Windows.Forms.TextBox()
        Me.txtJobName = New System.Windows.Forms.TextBox()
        Me.txtJobState = New System.Windows.Forms.MaskedTextBox()
        Me.txtJobZip = New System.Windows.Forms.MaskedTextBox()
        Me._label_14 = New System.Windows.Forms.Label()
        Me._label_12 = New System.Windows.Forms.Label()
        Me._label_10 = New System.Windows.Forms.Label()
        Me._label_9 = New System.Windows.Forms.Label()
        Me._label_8 = New System.Windows.Forms.Label()
        Me.fraCode = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkHeadDetection = New System.Windows.Forms.CheckBox()
        Me.cboNFPA13CodeYear = New System.Windows.Forms.ComboBox()
        Me.txtSDSlevel = New System.Windows.Forms.TextBox()
        Me.SDSlevel_lbl = New System.Windows.Forms.Label()
        Me.chkDSA = New System.Windows.Forms.CheckBox()
        Me.chkOSHPD = New System.Windows.Forms.CheckBox()
        Me.HeatDetection_chk = New System.Windows.Forms.CheckBox()
        Me.cboANSICode = New System.Windows.Forms.ComboBox()
        Me.cboLocalCode = New System.Windows.Forms.ComboBox()
        Me.cboSeismicZone = New System.Windows.Forms.ComboBox()
        Me.ANSICode_lbl = New System.Windows.Forms.Label()
        Me.lblLocalCode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Help = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusStrip()
        Me._StatusBar1_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._StatusBar1_Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._StatusBar1_Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._StatusBar1_Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CurrentTime_tim = New System.Windows.Forms.Timer(Me.components)
        Me._JobHighRiskFactor_lbl_1 = New System.Windows.Forms.Label()
        Me.SheetView1 = New FarPoint.Win.Spread.SheetView()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.Equipment_fra = New System.Windows.Forms.GroupBox()
        Me.sprTotals = New FarPoint.Win.Spread.FpSpread()
        Me.sprTotals_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnForms = New System.Windows.Forms.Button()
        Me.btnEstimate = New System.Windows.Forms.Button()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.NewProductService_fra = New System.Windows.Forms.GroupBox()
        Me.txtNPSLaborCost = New System.Windows.Forms.TextBox()
        Me.txtNPSOneTimeCost = New System.Windows.Forms.TextBox()
        Me.txtNPSMaterialCost = New System.Windows.Forms.TextBox()
        Me.cboDurationMonths = New System.Windows.Forms.ComboBox()
        Me.cboCallBackHours = New System.Windows.Forms.ComboBox()
        Me.lblNPSLaborCosts = New System.Windows.Forms.Label()
        Me.lblNPSOneTimeCost_ = New System.Windows.Forms.Label()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.lblNPSMaterialCost = New System.Windows.Forms.Label()
        Me.lblCallBackHours = New System.Windows.Forms.Label()
        Me.txtOCPL = New System.Windows.Forms.TextBox()
        Me.lblOCPL = New System.Windows.Forms.Label()
        Me.btnLaborRates = New System.Windows.Forms.Button()
        Me.btnGatewayReview = New System.Windows.Forms.Button()
        Me.lblGatewayStatus = New System.Windows.Forms.Label()
        Me.txtGatewayStatus = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnProposal = New System.Windows.Forms.Button()
        Me._label_4 = New System.Windows.Forms.Label()
        Me._label_0 = New System.Windows.Forms.Label()
        Me._Menu_tlb_3 = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtEstimator = New System.Windows.Forms.MaskedTextBox()
        Me.txtEstimateNum = New System.Windows.Forms.MaskedTextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.Menu_pic = New System.Windows.Forms.PictureBox()
        Me.btnSuptReview = New System.Windows.Forms.Button()
        Me.btnContact = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSuptReview = New System.Windows.Forms.TextBox()
        Me.BuildingInformation_fra.SuspendLayout()
        Me.fraCode.SuspendLayout()
        Me.StatusBar1.SuspendLayout()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Equipment_fra.SuspendLayout()
        CType(Me.sprTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprTotals_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NewProductService_fra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Menu_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu_pic.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BuildingInformation_fra
        '
        Me.BuildingInformation_fra.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingInformation_fra.Controls.Add(Me.cboSupt)
        Me.BuildingInformation_fra.Controls.Add(Me.lblSupt)
        Me.BuildingInformation_fra.Controls.Add(Me.txtContractNumber)
        Me.BuildingInformation_fra.Controls.Add(Me.lblContractNumber)
        Me.BuildingInformation_fra.Controls.Add(Me.Label7)
        Me.BuildingInformation_fra.Controls.Add(Me.txtTaxRate)
        Me.BuildingInformation_fra.Controls.Add(Me.ExpandCollapseFrame_btn)
        Me.BuildingInformation_fra.Controls.Add(Me.Label6)
        Me.BuildingInformation_fra.Controls.Add(Me.cboTaxCode)
        Me.BuildingInformation_fra.Controls.Add(Me.lblNationalAccount)
        Me.BuildingInformation_fra.Controls.Add(Me.cboNationalAccount)
        Me.BuildingInformation_fra.Controls.Add(Me.txtConsultant)
        Me.BuildingInformation_fra.Controls.Add(Me.Label3)
        Me.BuildingInformation_fra.Controls.Add(Me.txtBidDate)
        Me.BuildingInformation_fra.Controls.Add(Me.cboBuildingType)
        Me.BuildingInformation_fra.Controls.Add(Me.lblBuildingType)
        Me.BuildingInformation_fra.Controls.Add(Me.Label1)
        Me.BuildingInformation_fra.Controls.Add(Me.cboStatus)
        Me.BuildingInformation_fra.Controls.Add(Me._label_7)
        Me.BuildingInformation_fra.Controls.Add(Me.Status_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.cboSalesRep)
        Me.BuildingInformation_fra.Controls.Add(Me.cboInstallingOffice)
        Me.BuildingInformation_fra.Controls.Add(Me.cboServiceOffice)
        Me.BuildingInformation_fra.Controls.Add(Me.SalesOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.InstallingOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.cboSalesOffice)
        Me.BuildingInformation_fra.Controls.Add(Me.ServiceOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.cboProbabilityOfSale)
        Me.BuildingInformation_fra.Controls.Add(Me.ProbabilityOfSale_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobAddress2)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobCity)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobAddress)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobName)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobState)
        Me.BuildingInformation_fra.Controls.Add(Me.txtJobZip)
        Me.BuildingInformation_fra.Controls.Add(Me._label_14)
        Me.BuildingInformation_fra.Controls.Add(Me._label_12)
        Me.BuildingInformation_fra.Controls.Add(Me._label_10)
        Me.BuildingInformation_fra.Controls.Add(Me._label_9)
        Me.BuildingInformation_fra.Controls.Add(Me._label_8)
        Me.BuildingInformation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingInformation_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BuildingInformation_fra.Location = New System.Drawing.Point(0, 57)
        Me.BuildingInformation_fra.Name = "BuildingInformation_fra"
        Me.BuildingInformation_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingInformation_fra.Size = New System.Drawing.Size(859, 231)
        Me.BuildingInformation_fra.TabIndex = 50
        Me.BuildingInformation_fra.TabStop = False
        Me.BuildingInformation_fra.Text = "    Building/Job Information"
        '
        'cboSupt
        '
        Me.cboSupt.BackColor = System.Drawing.SystemColors.Window
        Me.cboSupt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupt.DropDownWidth = 222
        Me.cboSupt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSupt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSupt.Location = New System.Drawing.Point(123, 140)
        Me.cboSupt.Name = "cboSupt"
        Me.cboSupt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSupt.Size = New System.Drawing.Size(157, 21)
        Me.cboSupt.TabIndex = 104
        '
        'lblSupt
        '
        Me.lblSupt.BackColor = System.Drawing.SystemColors.Window
        Me.lblSupt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblSupt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSupt.Location = New System.Drawing.Point(23, 145)
        Me.lblSupt.Name = "lblSupt"
        Me.lblSupt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSupt.Size = New System.Drawing.Size(94, 13)
        Me.lblSupt.TabIndex = 105
        Me.lblSupt.Text = "Superintendent:"
        Me.lblSupt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtContractNumber
        '
        Me.txtContractNumber.AcceptsReturn = True
        Me.txtContractNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtContractNumber.Enabled = False
        Me.txtContractNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContractNumber.Location = New System.Drawing.Point(357, 141)
        Me.txtContractNumber.MaxLength = 42
        Me.txtContractNumber.Name = "txtContractNumber"
        Me.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContractNumber.Size = New System.Drawing.Size(101, 20)
        Me.txtContractNumber.TabIndex = 102
        '
        'lblContractNumber
        '
        Me.lblContractNumber.BackColor = System.Drawing.SystemColors.Window
        Me.lblContractNumber.Enabled = False
        Me.lblContractNumber.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblContractNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblContractNumber.Location = New System.Drawing.Point(286, 144)
        Me.lblContractNumber.Name = "lblContractNumber"
        Me.lblContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContractNumber.Size = New System.Drawing.Size(65, 13)
        Me.lblContractNumber.TabIndex = 103
        Me.lblContractNumber.Text = "Contract #:"
        Me.lblContractNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(682, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Tax Rate:"
        '
        'txtTaxRate
        '
        Me.txtTaxRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxRate.Location = New System.Drawing.Point(749, 168)
        Me.txtTaxRate.Name = "txtTaxRate"
        Me.txtTaxRate.Size = New System.Drawing.Size(87, 20)
        Me.txtTaxRate.TabIndex = 100
        '
        'ExpandCollapseFrame_btn
        '
        Me.ExpandCollapseFrame_btn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ExpandCollapseFrame_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExpandCollapseFrame_btn.Location = New System.Drawing.Point(0, 0)
        Me.ExpandCollapseFrame_btn.Name = "ExpandCollapseFrame_btn"
        Me.ExpandCollapseFrame_btn.Size = New System.Drawing.Size(20, 19)
        Me.ExpandCollapseFrame_btn.TabIndex = 51
        Me.ExpandCollapseFrame_btn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(682, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Tax Code:"
        '
        'cboTaxCode
        '
        Me.cboTaxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTaxCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTaxCode.FormattingEnabled = True
        Me.cboTaxCode.Location = New System.Drawing.Point(749, 196)
        Me.cboTaxCode.Name = "cboTaxCode"
        Me.cboTaxCode.Size = New System.Drawing.Size(87, 21)
        Me.cboTaxCode.TabIndex = 98
        '
        'lblNationalAccount
        '
        Me.lblNationalAccount.AutoSize = True
        Me.lblNationalAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationalAccount.Location = New System.Drawing.Point(485, 201)
        Me.lblNationalAccount.Name = "lblNationalAccount"
        Me.lblNationalAccount.Size = New System.Drawing.Size(109, 13)
        Me.lblNationalAccount.TabIndex = 96
        Me.lblNationalAccount.Text = "National Account:"
        '
        'cboNationalAccount
        '
        Me.cboNationalAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNationalAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNationalAccount.FormattingEnabled = True
        Me.cboNationalAccount.Location = New System.Drawing.Point(596, 196)
        Me.cboNationalAccount.Name = "cboNationalAccount"
        Me.cboNationalAccount.Size = New System.Drawing.Size(81, 21)
        Me.cboNationalAccount.TabIndex = 95
        '
        'txtConsultant
        '
        Me.txtConsultant.BackColor = System.Drawing.SystemColors.Window
        Me.txtConsultant.Enabled = False
        Me.txtConsultant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsultant.Location = New System.Drawing.Point(122, 117)
        Me.txtConsultant.Name = "txtConsultant"
        Me.txtConsultant.Size = New System.Drawing.Size(336, 20)
        Me.txtConsultant.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Enabled = False
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Consultant:"
        '
        'txtBidDate
        '
        Me.txtBidDate.Checked = False
        Me.txtBidDate.CustomFormat = "MM/dd/yyyy"
        Me.txtBidDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBidDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtBidDate.Location = New System.Drawing.Point(597, 141)
        Me.txtBidDate.Name = "txtBidDate"
        Me.txtBidDate.Size = New System.Drawing.Size(108, 20)
        Me.txtBidDate.TabIndex = 88
        '
        'cboBuildingType
        '
        Me.cboBuildingType.BackColor = System.Drawing.SystemColors.Window
        Me.cboBuildingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuildingType.DropDownWidth = 222
        Me.cboBuildingType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBuildingType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBuildingType.Location = New System.Drawing.Point(121, 193)
        Me.cboBuildingType.Name = "cboBuildingType"
        Me.cboBuildingType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboBuildingType.Size = New System.Drawing.Size(336, 21)
        Me.cboBuildingType.TabIndex = 86
        '
        'lblBuildingType
        '
        Me.lblBuildingType.BackColor = System.Drawing.SystemColors.Window
        Me.lblBuildingType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBuildingType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuildingType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBuildingType.Location = New System.Drawing.Point(18, 196)
        Me.lblBuildingType.Name = "lblBuildingType"
        Me.lblBuildingType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBuildingType.Size = New System.Drawing.Size(100, 13)
        Me.lblBuildingType.TabIndex = 87
        Me.lblBuildingType.Text = "Building Type:"
        Me.lblBuildingType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(535, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Bid Date:"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStatus.Location = New System.Drawing.Point(596, 116)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStatus.Size = New System.Drawing.Size(231, 21)
        Me.cboStatus.TabIndex = 72
        '
        '_label_7
        '
        Me._label_7.AutoSize = True
        Me._label_7.BackColor = System.Drawing.SystemColors.Window
        Me._label_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._label_7.Location = New System.Drawing.Point(525, 14)
        Me._label_7.Name = "_label_7"
        Me._label_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_7.Size = New System.Drawing.Size(69, 13)
        Me._label_7.TabIndex = 81
        Me._label_7.Text = "Sales Rep:"
        Me._label_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Status_lbl
        '
        Me.Status_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Status_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Status_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status_lbl.Location = New System.Drawing.Point(551, 119)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Status_lbl.Size = New System.Drawing.Size(39, 17)
        Me.Status_lbl.TabIndex = 79
        Me.Status_lbl.Text = "Status:"
        Me.Status_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboSalesRep
        '
        Me.cboSalesRep.BackColor = System.Drawing.SystemColors.Window
        Me.cboSalesRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalesRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSalesRep.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSalesRep.Location = New System.Drawing.Point(597, 12)
        Me.cboSalesRep.Name = "cboSalesRep"
        Me.cboSalesRep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSalesRep.Size = New System.Drawing.Size(230, 21)
        Me.cboSalesRep.Sorted = True
        Me.cboSalesRep.TabIndex = 68
        '
        'cboInstallingOffice
        '
        Me.cboInstallingOffice.BackColor = System.Drawing.SystemColors.Window
        Me.cboInstallingOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstallingOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInstallingOffice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInstallingOffice.Location = New System.Drawing.Point(597, 63)
        Me.cboInstallingOffice.Name = "cboInstallingOffice"
        Me.cboInstallingOffice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboInstallingOffice.Size = New System.Drawing.Size(80, 21)
        Me.cboInstallingOffice.TabIndex = 70
        '
        'cboServiceOffice
        '
        Me.cboServiceOffice.BackColor = System.Drawing.SystemColors.Window
        Me.cboServiceOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServiceOffice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboServiceOffice.Location = New System.Drawing.Point(597, 90)
        Me.cboServiceOffice.Name = "cboServiceOffice"
        Me.cboServiceOffice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboServiceOffice.Size = New System.Drawing.Size(80, 21)
        Me.cboServiceOffice.TabIndex = 69
        '
        'SalesOffice_lbl
        '
        Me.SalesOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SalesOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SalesOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SalesOffice_lbl.Location = New System.Drawing.Point(490, 38)
        Me.SalesOffice_lbl.Name = "SalesOffice_lbl"
        Me.SalesOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SalesOffice_lbl.Size = New System.Drawing.Size(100, 13)
        Me.SalesOffice_lbl.TabIndex = 77
        Me.SalesOffice_lbl.Text = "Sales Office:"
        Me.SalesOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InstallingOffice_lbl
        '
        Me.InstallingOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.InstallingOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.InstallingOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallingOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.InstallingOffice_lbl.Location = New System.Drawing.Point(490, 63)
        Me.InstallingOffice_lbl.Name = "InstallingOffice_lbl"
        Me.InstallingOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InstallingOffice_lbl.Size = New System.Drawing.Size(100, 13)
        Me.InstallingOffice_lbl.TabIndex = 78
        Me.InstallingOffice_lbl.Text = "Installing Office:"
        Me.InstallingOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboSalesOffice
        '
        Me.cboSalesOffice.BackColor = System.Drawing.SystemColors.Window
        Me.cboSalesOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalesOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSalesOffice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSalesOffice.Location = New System.Drawing.Point(597, 36)
        Me.cboSalesOffice.Name = "cboSalesOffice"
        Me.cboSalesOffice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSalesOffice.Size = New System.Drawing.Size(80, 21)
        Me.cboSalesOffice.TabIndex = 71
        '
        'ServiceOffice_lbl
        '
        Me.ServiceOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ServiceOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ServiceOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServiceOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ServiceOffice_lbl.Location = New System.Drawing.Point(499, 93)
        Me.ServiceOffice_lbl.Name = "ServiceOffice_lbl"
        Me.ServiceOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServiceOffice_lbl.Size = New System.Drawing.Size(91, 13)
        Me.ServiceOffice_lbl.TabIndex = 82
        Me.ServiceOffice_lbl.Text = "Service Office:"
        Me.ServiceOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboProbabilityOfSale
        '
        Me.cboProbabilityOfSale.BackColor = System.Drawing.SystemColors.Window
        Me.cboProbabilityOfSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProbabilityOfSale.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboProbabilityOfSale.Location = New System.Drawing.Point(597, 168)
        Me.cboProbabilityOfSale.Name = "cboProbabilityOfSale"
        Me.cboProbabilityOfSale.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboProbabilityOfSale.Size = New System.Drawing.Size(81, 21)
        Me.cboProbabilityOfSale.TabIndex = 74
        '
        'ProbabilityOfSale_lbl
        '
        Me.ProbabilityOfSale_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ProbabilityOfSale_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ProbabilityOfSale_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbabilityOfSale_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProbabilityOfSale_lbl.Location = New System.Drawing.Point(484, 171)
        Me.ProbabilityOfSale_lbl.Name = "ProbabilityOfSale_lbl"
        Me.ProbabilityOfSale_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProbabilityOfSale_lbl.Size = New System.Drawing.Size(107, 17)
        Me.ProbabilityOfSale_lbl.TabIndex = 80
        Me.ProbabilityOfSale_lbl.Text = "Probability of Sale:"
        Me.ProbabilityOfSale_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtJobAddress2
        '
        Me.txtJobAddress2.AcceptsReturn = True
        Me.txtJobAddress2.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobAddress2.Enabled = False
        Me.txtJobAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobAddress2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJobAddress2.Location = New System.Drawing.Point(121, 63)
        Me.txtJobAddress2.MaxLength = 42
        Me.txtJobAddress2.Name = "txtJobAddress2"
        Me.txtJobAddress2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtJobAddress2.Size = New System.Drawing.Size(336, 20)
        Me.txtJobAddress2.TabIndex = 2
        '
        'txtJobCity
        '
        Me.txtJobCity.AcceptsReturn = True
        Me.txtJobCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobCity.Enabled = False
        Me.txtJobCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJobCity.Location = New System.Drawing.Point(122, 86)
        Me.txtJobCity.MaxLength = 42
        Me.txtJobCity.Name = "txtJobCity"
        Me.txtJobCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtJobCity.Size = New System.Drawing.Size(141, 20)
        Me.txtJobCity.TabIndex = 3
        '
        'txtJobAddress
        '
        Me.txtJobAddress.AcceptsReturn = True
        Me.txtJobAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobAddress.Enabled = False
        Me.txtJobAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJobAddress.Location = New System.Drawing.Point(121, 38)
        Me.txtJobAddress.MaxLength = 42
        Me.txtJobAddress.Name = "txtJobAddress"
        Me.txtJobAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtJobAddress.Size = New System.Drawing.Size(336, 20)
        Me.txtJobAddress.TabIndex = 1
        '
        'txtJobName
        '
        Me.txtJobName.AcceptsReturn = True
        Me.txtJobName.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobName.Enabled = False
        Me.txtJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJobName.Location = New System.Drawing.Point(121, 16)
        Me.txtJobName.MaxLength = 0
        Me.txtJobName.Name = "txtJobName"
        Me.txtJobName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtJobName.Size = New System.Drawing.Size(336, 20)
        Me.txtJobName.TabIndex = 0
        '
        'txtJobState
        '
        Me.txtJobState.AllowPromptAsInput = False
        Me.txtJobState.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobState.Enabled = False
        Me.txtJobState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobState.Location = New System.Drawing.Point(314, 86)
        Me.txtJobState.Mask = ">AA"
        Me.txtJobState.Name = "txtJobState"
        Me.txtJobState.Size = New System.Drawing.Size(34, 20)
        Me.txtJobState.TabIndex = 4
        Me.txtJobState.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtJobZip
        '
        Me.txtJobZip.AllowPromptAsInput = False
        Me.txtJobZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobZip.Enabled = False
        Me.txtJobZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobZip.Location = New System.Drawing.Point(382, 86)
        Me.txtJobZip.Mask = "00000-9999"
        Me.txtJobZip.Name = "txtJobZip"
        Me.txtJobZip.Size = New System.Drawing.Size(76, 20)
        Me.txtJobZip.TabIndex = 5
        Me.txtJobZip.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        '_label_14
        '
        Me._label_14.BackColor = System.Drawing.SystemColors.Window
        Me._label_14.Enabled = False
        Me._label_14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_14.Location = New System.Drawing.Point(346, 90)
        Me._label_14.Name = "_label_14"
        Me._label_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_14.Size = New System.Drawing.Size(26, 13)
        Me._label_14.TabIndex = 49
        Me._label_14.Text = "Zip:"
        Me._label_14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_label_12
        '
        Me._label_12.BackColor = System.Drawing.SystemColors.Window
        Me._label_12.Enabled = False
        Me._label_12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_12.Location = New System.Drawing.Point(269, 89)
        Me._label_12.Name = "_label_12"
        Me._label_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_12.Size = New System.Drawing.Size(39, 13)
        Me._label_12.TabIndex = 48
        Me._label_12.Text = "State:"
        Me._label_12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_label_10
        '
        Me._label_10.BackColor = System.Drawing.SystemColors.Window
        Me._label_10.Enabled = False
        Me._label_10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_10.Location = New System.Drawing.Point(10, 90)
        Me._label_10.Name = "_label_10"
        Me._label_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_10.Size = New System.Drawing.Size(105, 13)
        Me._label_10.TabIndex = 47
        Me._label_10.Text = "City:"
        Me._label_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_label_9
        '
        Me._label_9.BackColor = System.Drawing.SystemColors.Window
        Me._label_9.Enabled = False
        Me._label_9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_9.Location = New System.Drawing.Point(9, 42)
        Me._label_9.Name = "_label_9"
        Me._label_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_9.Size = New System.Drawing.Size(105, 13)
        Me._label_9.TabIndex = 46
        Me._label_9.Text = "Building Address:"
        Me._label_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_label_8
        '
        Me._label_8.BackColor = System.Drawing.SystemColors.Window
        Me._label_8.Enabled = False
        Me._label_8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_8.Location = New System.Drawing.Point(9, 20)
        Me._label_8.Name = "_label_8"
        Me._label_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_8.Size = New System.Drawing.Size(105, 13)
        Me._label_8.TabIndex = 45
        Me._label_8.Text = "Building Name:"
        Me._label_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fraCode
        '
        Me.fraCode.BackColor = System.Drawing.SystemColors.Window
        Me.fraCode.Controls.Add(Me.Label5)
        Me.fraCode.Controls.Add(Me.chkHeadDetection)
        Me.fraCode.Controls.Add(Me.cboNFPA13CodeYear)
        Me.fraCode.Controls.Add(Me.txtSDSlevel)
        Me.fraCode.Controls.Add(Me.SDSlevel_lbl)
        Me.fraCode.Controls.Add(Me.chkDSA)
        Me.fraCode.Controls.Add(Me.chkOSHPD)
        Me.fraCode.Controls.Add(Me.HeatDetection_chk)
        Me.fraCode.Controls.Add(Me.cboANSICode)
        Me.fraCode.Controls.Add(Me.cboLocalCode)
        Me.fraCode.Controls.Add(Me.cboSeismicZone)
        Me.fraCode.Controls.Add(Me.ANSICode_lbl)
        Me.fraCode.Controls.Add(Me.lblLocalCode)
        Me.fraCode.Controls.Add(Me.Label4)
        Me.fraCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCode.Location = New System.Drawing.Point(865, 57)
        Me.fraCode.Name = "fraCode"
        Me.fraCode.Size = New System.Drawing.Size(317, 183)
        Me.fraCode.TabIndex = 97
        Me.fraCode.TabStop = False
        Me.fraCode.Text = "Codes"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(47, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Tag = " "
        Me.Label5.Text = "NFPA 13 Code Year:"
        '
        'chkHeadDetection
        '
        Me.chkHeadDetection.BackColor = System.Drawing.Color.White
        Me.chkHeadDetection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHeadDetection.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkHeadDetection.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkHeadDetection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHeadDetection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHeadDetection.Location = New System.Drawing.Point(75, 139)
        Me.chkHeadDetection.Name = "chkHeadDetection"
        Me.chkHeadDetection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHeadDetection.Size = New System.Drawing.Size(112, 15)
        Me.chkHeadDetection.TabIndex = 70
        Me.chkHeadDetection.Text = "Heat Detection:"
        Me.chkHeadDetection.UseVisualStyleBackColor = False
        '
        'cboNFPA13CodeYear
        '
        Me.cboNFPA13CodeYear.BackColor = System.Drawing.SystemColors.Window
        Me.cboNFPA13CodeYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboNFPA13CodeYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNFPA13CodeYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNFPA13CodeYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboNFPA13CodeYear.Location = New System.Drawing.Point(173, 86)
        Me.cboNFPA13CodeYear.Name = "cboNFPA13CodeYear"
        Me.cboNFPA13CodeYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboNFPA13CodeYear.Size = New System.Drawing.Size(134, 21)
        Me.cboNFPA13CodeYear.TabIndex = 18
        '
        'txtSDSlevel
        '
        Me.txtSDSlevel.AcceptsReturn = True
        Me.txtSDSlevel.BackColor = System.Drawing.SystemColors.Window
        Me.txtSDSlevel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSDSlevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSDSlevel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSDSlevel.Location = New System.Drawing.Point(171, 113)
        Me.txtSDSlevel.MaxLength = 6
        Me.txtSDSlevel.Name = "txtSDSlevel"
        Me.txtSDSlevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSDSlevel.Size = New System.Drawing.Size(134, 20)
        Me.txtSDSlevel.TabIndex = 17
        Me.txtSDSlevel.Text = " "
        '
        'SDSlevel_lbl
        '
        Me.SDSlevel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SDSlevel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SDSlevel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SDSlevel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SDSlevel_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SDSlevel_lbl.Location = New System.Drawing.Point(9, 117)
        Me.SDSlevel_lbl.Name = "SDSlevel_lbl"
        Me.SDSlevel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SDSlevel_lbl.Size = New System.Drawing.Size(156, 17)
        Me.SDSlevel_lbl.TabIndex = 67
        Me.SDSlevel_lbl.Text = "SDS level - <= 2.0 / > 2.0:"
        '
        'chkDSA
        '
        Me.chkDSA.BackColor = System.Drawing.Color.White
        Me.chkDSA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDSA.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDSA.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkDSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDSA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDSA.Location = New System.Drawing.Point(253, 158)
        Me.chkDSA.Name = "chkDSA"
        Me.chkDSA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDSA.Size = New System.Drawing.Size(52, 15)
        Me.chkDSA.TabIndex = 16
        Me.chkDSA.Text = "DSA:"
        Me.chkDSA.UseVisualStyleBackColor = False
        '
        'chkOSHPD
        '
        Me.chkOSHPD.BackColor = System.Drawing.Color.White
        Me.chkOSHPD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOSHPD.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOSHPD.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkOSHPD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOSHPD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOSHPD.Location = New System.Drawing.Point(236, 139)
        Me.chkOSHPD.Name = "chkOSHPD"
        Me.chkOSHPD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOSHPD.Size = New System.Drawing.Size(69, 15)
        Me.chkOSHPD.TabIndex = 15
        Me.chkOSHPD.Text = "OSHPD:"
        Me.chkOSHPD.UseVisualStyleBackColor = False
        '
        'HeatDetection_chk
        '
        Me.HeatDetection_chk.BackColor = System.Drawing.Color.White
        Me.HeatDetection_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HeatDetection_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.HeatDetection_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HeatDetection_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeatDetection_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HeatDetection_chk.Location = New System.Drawing.Point(6, 246)
        Me.HeatDetection_chk.Name = "HeatDetection_chk"
        Me.HeatDetection_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HeatDetection_chk.Size = New System.Drawing.Size(181, 15)
        Me.HeatDetection_chk.TabIndex = 19
        Me.HeatDetection_chk.Text = "Heat Detection"
        Me.HeatDetection_chk.UseVisualStyleBackColor = False
        '
        'cboANSICode
        '
        Me.cboANSICode.BackColor = System.Drawing.SystemColors.Window
        Me.cboANSICode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboANSICode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboANSICode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboANSICode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboANSICode.Location = New System.Drawing.Point(173, 60)
        Me.cboANSICode.Name = "cboANSICode"
        Me.cboANSICode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboANSICode.Size = New System.Drawing.Size(134, 21)
        Me.cboANSICode.TabIndex = 13
        '
        'cboLocalCode
        '
        Me.cboLocalCode.BackColor = System.Drawing.SystemColors.Window
        Me.cboLocalCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLocalCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLocalCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLocalCode.Location = New System.Drawing.Point(173, 36)
        Me.cboLocalCode.Name = "cboLocalCode"
        Me.cboLocalCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLocalCode.Size = New System.Drawing.Size(134, 21)
        Me.cboLocalCode.TabIndex = 11
        '
        'cboSeismicZone
        '
        Me.cboSeismicZone.BackColor = System.Drawing.SystemColors.Window
        Me.cboSeismicZone.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboSeismicZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeismicZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeismicZone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSeismicZone.Location = New System.Drawing.Point(171, 11)
        Me.cboSeismicZone.Name = "cboSeismicZone"
        Me.cboSeismicZone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSeismicZone.Size = New System.Drawing.Size(134, 21)
        Me.cboSeismicZone.TabIndex = 10
        '
        'ANSICode_lbl
        '
        Me.ANSICode_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ANSICode_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ANSICode_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ANSICode_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ANSICode_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ANSICode_lbl.Location = New System.Drawing.Point(39, 63)
        Me.ANSICode_lbl.Name = "ANSICode_lbl"
        Me.ANSICode_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ANSICode_lbl.Size = New System.Drawing.Size(126, 13)
        Me.ANSICode_lbl.TabIndex = 63
        Me.ANSICode_lbl.Tag = " "
        Me.ANSICode_lbl.Text = "ANSI/CSA/B44 Code:"
        '
        'lblLocalCode
        '
        Me.lblLocalCode.BackColor = System.Drawing.SystemColors.Window
        Me.lblLocalCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLocalCode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblLocalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLocalCode.Location = New System.Drawing.Point(95, 40)
        Me.lblLocalCode.Name = "lblLocalCode"
        Me.lblLocalCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLocalCode.Size = New System.Drawing.Size(70, 17)
        Me.lblLocalCode.TabIndex = 56
        Me.lblLocalCode.Text = "Local Code:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(80, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Seismic Zone:"
        '
        'btn_Help
        '
        Me.btn_Help.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Help.Image = CType(resources.GetObject("btn_Help.Image"), System.Drawing.Image)
        Me.btn_Help.Location = New System.Drawing.Point(249, 5)
        Me.btn_Help.Name = "btn_Help"
        Me.btn_Help.Size = New System.Drawing.Size(46, 46)
        Me.btn_Help.TabIndex = 37
        Me.btn_Help.TabStop = False
        Me.btn_Help.Tag = "Help"
        Me.btn_Help.Text = "Help"
        Me.btn_Help.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._StatusBar1_Panel1, Me._StatusBar1_Panel2, Me._StatusBar1_Panel3, Me._StatusBar1_Panel4})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 773)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.ShowItemToolTips = True
        Me.StatusBar1.Size = New System.Drawing.Size(1484, 22)
        Me.StatusBar1.TabIndex = 41
        '
        '_StatusBar1_Panel1
        '
        Me._StatusBar1_Panel1.AutoSize = False
        Me._StatusBar1_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel1.DoubleClickEnabled = True
        Me._StatusBar1_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel1.Name = "_StatusBar1_Panel1"
        Me._StatusBar1_Panel1.Size = New System.Drawing.Size(370, 22)
        Me._StatusBar1_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._StatusBar1_Panel1.ToolTipText = "Message Display Area"
        '
        '_StatusBar1_Panel2
        '
        Me._StatusBar1_Panel2.AutoSize = False
        Me._StatusBar1_Panel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel2.DoubleClickEnabled = True
        Me._StatusBar1_Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel2.Name = "_StatusBar1_Panel2"
        Me._StatusBar1_Panel2.Size = New System.Drawing.Size(160, 22)
        Me._StatusBar1_Panel2.ToolTipText = "Version"
        '
        '_StatusBar1_Panel3
        '
        Me._StatusBar1_Panel3.AutoSize = False
        Me._StatusBar1_Panel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel3.DoubleClickEnabled = True
        Me._StatusBar1_Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel3.Name = "_StatusBar1_Panel3"
        Me._StatusBar1_Panel3.Size = New System.Drawing.Size(100, 22)
        Me._StatusBar1_Panel3.ToolTipText = "CurrentDate"
        '
        '_StatusBar1_Panel4
        '
        Me._StatusBar1_Panel4.AutoSize = False
        Me._StatusBar1_Panel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel4.DoubleClickEnabled = True
        Me._StatusBar1_Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel4.Name = "_StatusBar1_Panel4"
        Me._StatusBar1_Panel4.Size = New System.Drawing.Size(100, 22)
        Me._StatusBar1_Panel4.ToolTipText = "Current Time"
        '
        'CurrentTime_tim
        '
        Me.CurrentTime_tim.Enabled = True
        Me.CurrentTime_tim.Interval = 60000
        '
        '_JobHighRiskFactor_lbl_1
        '
        Me._JobHighRiskFactor_lbl_1.BackColor = System.Drawing.SystemColors.Window
        Me._JobHighRiskFactor_lbl_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._JobHighRiskFactor_lbl_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._JobHighRiskFactor_lbl_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._JobHighRiskFactor_lbl_1.Location = New System.Drawing.Point(152, 163)
        Me._JobHighRiskFactor_lbl_1.Name = "_JobHighRiskFactor_lbl_1"
        Me._JobHighRiskFactor_lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._JobHighRiskFactor_lbl_1.Size = New System.Drawing.Size(20, 18)
        Me._JobHighRiskFactor_lbl_1.TabIndex = 71
        '
        'SheetView1
        '
        Me.SheetView1.Reset()
        Me.SheetView1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SheetView1.Columns.Get(0).Width = 61.0!
        Me.SheetView1.Columns.Get(1).Width = 61.0!
        Me.SheetView1.Columns.Get(2).Width = 61.0!
        Me.SheetView1.Columns.Get(3).Width = 61.0!
        Me.SheetView1.Columns.Get(4).Width = 61.0!
        Me.SheetView1.Columns.Get(5).Width = 61.0!
        Me.SheetView1.Columns.Get(6).Width = 61.0!
        Me.SheetView1.Columns.Get(7).Width = 61.0!
        Me.SheetView1.Columns.Get(8).Width = 61.0!
        Me.SheetView1.Columns.Get(9).Width = 61.0!
        Me.SheetView1.Columns.Get(10).Width = 61.0!
        Me.SheetView1.Columns.Get(11).Width = 61.0!
        Me.SheetView1.Columns.Get(12).Width = 61.0!
        Me.SheetView1.Columns.Get(13).Width = 61.0!
        Me.SheetView1.Columns.Get(14).Width = 61.0!
        Me.SheetView1.Columns.Get(15).Width = 61.0!
        Me.SheetView1.Columns.Get(16).Width = 61.0!
        Me.SheetView1.Columns.Get(17).Width = 61.0!
        Me.SheetView1.Columns.Get(18).Width = 61.0!
        Me.SheetView1.Columns.Get(19).Width = 61.0!
        Me.SheetView1.Columns.Get(20).Width = 61.0!
        Me.SheetView1.Columns.Get(21).Width = 61.0!
        Me.SheetView1.Columns.Get(22).Width = 61.0!
        Me.SheetView1.Columns.Get(23).Width = 61.0!
        Me.SheetView1.Columns.Get(24).Width = 61.0!
        Me.SheetView1.Columns.Get(25).Width = 61.0!
        Me.SheetView1.Columns.Get(26).Width = 61.0!
        Me.SheetView1.Columns.Get(27).Width = 61.0!
        Me.SheetView1.Columns.Get(28).Width = 61.0!
        Me.SheetView1.Columns.Get(29).Width = 61.0!
        Me.SheetView1.Columns.Get(30).Width = 61.0!
        Me.SheetView1.Columns.Get(31).Width = 61.0!
        Me.SheetView1.Columns.Get(32).Width = 61.0!
        Me.SheetView1.Columns.Get(33).Width = 61.0!
        Me.SheetView1.Columns.Get(34).Width = 61.0!
        Me.SheetView1.Columns.Get(35).Width = 61.0!
        Me.SheetView1.Columns.Get(36).Width = 61.0!
        Me.SheetView1.Columns.Get(37).Width = 61.0!
        Me.SheetView1.Columns.Get(38).Width = 61.0!
        Me.SheetView1.Columns.Get(39).Width = 61.0!
        Me.SheetView1.Columns.Get(40).Width = 61.0!
        Me.SheetView1.Columns.Get(41).Width = 61.0!
        Me.SheetView1.Columns.Get(42).Width = 61.0!
        Me.SheetView1.Columns.Get(43).Width = 61.0!
        Me.SheetView1.Columns.Get(44).Width = 61.0!
        Me.SheetView1.Columns.Get(45).Width = 61.0!
        Me.SheetView1.Columns.Get(46).Width = 61.0!
        Me.SheetView1.Columns.Get(47).Width = 61.0!
        Me.SheetView1.Columns.Get(48).Width = 61.0!
        Me.SheetView1.Columns.Get(49).Width = 61.0!
        Me.SheetView1.Columns.Get(50).Width = 61.0!
        Me.SheetView1.Columns.Get(51).Width = 61.0!
        Me.SheetView1.Columns.Get(52).Width = 61.0!
        Me.SheetView1.Columns.Get(53).Width = 61.0!
        Me.SheetView1.Columns.Get(54).Width = 61.0!
        Me.SheetView1.Columns.Get(55).Width = 61.0!
        Me.SheetView1.Columns.Get(56).Width = 61.0!
        Me.SheetView1.Columns.Get(57).Width = 61.0!
        Me.SheetView1.Columns.Get(58).Width = 61.0!
        Me.SheetView1.Columns.Get(59).Width = 61.0!
        Me.SheetView1.Columns.Get(60).Width = 61.0!
        Me.SheetView1.Columns.Get(61).Width = 61.0!
        Me.SheetView1.Columns.Get(62).Width = 61.0!
        Me.SheetView1.Columns.Get(63).Width = 61.0!
        Me.SheetView1.Columns.Get(64).Width = 61.0!
        Me.SheetView1.Columns.Get(65).Width = 61.0!
        Me.SheetView1.Columns.Get(66).Width = 61.0!
        Me.SheetView1.Columns.Get(67).Width = 61.0!
        Me.SheetView1.Columns.Get(68).Width = 61.0!
        Me.SheetView1.Columns.Get(69).Width = 61.0!
        Me.SheetView1.Columns.Get(70).Width = 61.0!
        Me.SheetView1.Columns.Get(71).Width = 61.0!
        Me.SheetView1.Columns.Get(72).Width = 61.0!
        Me.SheetView1.Columns.Get(73).Width = 61.0!
        Me.SheetView1.Columns.Get(74).Width = 61.0!
        Me.SheetView1.Columns.Get(75).Width = 61.0!
        Me.SheetView1.Columns.Get(76).Width = 61.0!
        Me.SheetView1.Columns.Get(77).Width = 61.0!
        Me.SheetView1.Columns.Get(78).Width = 61.0!
        Me.SheetView1.Columns.Get(79).Width = 61.0!
        Me.SheetView1.Columns.Get(80).Width = 61.0!
        Me.SheetView1.Columns.Get(81).Width = 61.0!
        Me.SheetView1.Columns.Get(82).Width = 61.0!
        Me.SheetView1.Columns.Get(83).Width = 61.0!
        Me.SheetView1.Columns.Get(84).Width = 61.0!
        Me.SheetView1.Columns.Get(85).Width = 61.0!
        Me.SheetView1.Columns.Get(86).Width = 61.0!
        Me.SheetView1.Columns.Get(87).Width = 61.0!
        Me.SheetView1.Columns.Get(88).Width = 61.0!
        Me.SheetView1.Columns.Get(89).Width = 61.0!
        Me.SheetView1.Columns.Get(90).Width = 61.0!
        Me.SheetView1.Columns.Get(91).Width = 61.0!
        Me.SheetView1.Columns.Get(92).Width = 61.0!
        Me.SheetView1.Columns.Get(93).Width = 61.0!
        Me.SheetView1.Columns.Get(94).Width = 61.0!
        Me.SheetView1.Columns.Get(95).Width = 61.0!
        Me.SheetView1.Columns.Get(96).Width = 61.0!
        Me.SheetView1.Columns.Get(97).Width = 61.0!
        Me.SheetView1.Columns.Get(98).Width = 61.0!
        Me.SheetView1.Columns.Get(99).Width = 61.0!
        Me.SheetView1.Columns.Get(100).Width = 61.0!
        Me.SheetView1.Columns.Get(101).Width = 61.0!
        Me.SheetView1.Columns.Get(102).Width = 61.0!
        Me.SheetView1.Columns.Get(103).Width = 61.0!
        Me.SheetView1.Columns.Get(104).Width = 61.0!
        Me.SheetView1.Columns.Get(105).Width = 61.0!
        Me.SheetView1.Columns.Get(106).Width = 61.0!
        Me.SheetView1.Columns.Get(107).Width = 61.0!
        Me.SheetView1.Columns.Get(108).Width = 61.0!
        Me.SheetView1.Columns.Get(109).Width = 61.0!
        Me.SheetView1.Columns.Get(110).Width = 61.0!
        Me.SheetView1.Columns.Get(111).Width = 61.0!
        Me.SheetView1.Columns.Get(112).Width = 61.0!
        Me.SheetView1.Columns.Get(113).Width = 61.0!
        Me.SheetView1.Columns.Get(114).Width = 61.0!
        Me.SheetView1.Columns.Get(115).Width = 61.0!
        Me.SheetView1.Columns.Get(116).Width = 61.0!
        Me.SheetView1.Columns.Get(117).Width = 61.0!
        Me.SheetView1.Columns.Get(118).Width = 61.0!
        Me.SheetView1.Columns.Get(119).Width = 61.0!
        Me.SheetView1.Columns.Get(120).Width = 61.0!
        Me.SheetView1.Columns.Get(121).Width = 61.0!
        Me.SheetView1.Columns.Get(122).Width = 61.0!
        Me.SheetView1.Columns.Get(123).Width = 61.0!
        Me.SheetView1.Columns.Get(124).Width = 61.0!
        Me.SheetView1.Columns.Get(125).Width = 61.0!
        Me.SheetView1.Columns.Get(126).Width = 61.0!
        Me.SheetView1.Columns.Get(127).Width = 61.0!
        Me.SheetView1.Columns.Get(128).Width = 61.0!
        Me.SheetView1.Columns.Get(129).Width = 61.0!
        Me.SheetView1.Columns.Get(130).Width = 61.0!
        Me.SheetView1.Columns.Get(131).Width = 61.0!
        Me.SheetView1.Columns.Get(132).Width = 61.0!
        Me.SheetView1.Columns.Get(133).Width = 61.0!
        Me.SheetView1.Columns.Get(134).Width = 61.0!
        Me.SheetView1.Columns.Get(135).Width = 61.0!
        Me.SheetView1.Columns.Get(136).Width = 61.0!
        Me.SheetView1.Columns.Get(137).Width = 61.0!
        Me.SheetView1.Columns.Get(138).Width = 61.0!
        Me.SheetView1.Columns.Get(139).Width = 61.0!
        Me.SheetView1.Columns.Get(140).Width = 61.0!
        Me.SheetView1.Columns.Get(141).Width = 61.0!
        Me.SheetView1.Columns.Get(142).Width = 61.0!
        Me.SheetView1.Columns.Get(143).Width = 61.0!
        Me.SheetView1.Columns.Get(144).Width = 61.0!
        Me.SheetView1.Columns.Get(145).Width = 61.0!
        Me.SheetView1.Columns.Get(146).Width = 61.0!
        Me.SheetView1.Columns.Get(147).Width = 61.0!
        Me.SheetView1.Columns.Get(148).Width = 61.0!
        Me.SheetView1.Columns.Get(149).Width = 61.0!
        Me.SheetView1.Columns.Get(150).Width = 61.0!
        Me.SheetView1.Columns.Get(151).Width = 61.0!
        Me.SheetView1.Columns.Get(152).Width = 61.0!
        Me.SheetView1.Columns.Get(153).Width = 61.0!
        Me.SheetView1.Columns.Get(154).Width = 61.0!
        Me.SheetView1.Columns.Get(155).Width = 61.0!
        Me.SheetView1.Columns.Get(156).Width = 61.0!
        Me.SheetView1.Columns.Get(157).Width = 61.0!
        Me.SheetView1.Columns.Get(158).Width = 61.0!
        Me.SheetView1.Columns.Get(159).Width = 61.0!
        Me.SheetView1.Columns.Get(160).Width = 61.0!
        Me.SheetView1.Columns.Get(161).Width = 61.0!
        Me.SheetView1.Columns.Get(162).Width = 61.0!
        Me.SheetView1.Columns.Get(163).Width = 61.0!
        Me.SheetView1.Columns.Get(164).Width = 61.0!
        Me.SheetView1.Columns.Get(165).Width = 61.0!
        Me.SheetView1.Columns.Get(166).Width = 61.0!
        Me.SheetView1.Columns.Get(167).Width = 61.0!
        Me.SheetView1.Columns.Get(168).Width = 61.0!
        Me.SheetView1.Columns.Get(169).Width = 61.0!
        Me.SheetView1.Columns.Get(170).Width = 61.0!
        Me.SheetView1.Columns.Get(171).Width = 61.0!
        Me.SheetView1.Columns.Get(172).Width = 61.0!
        Me.SheetView1.Columns.Get(173).Width = 61.0!
        Me.SheetView1.Columns.Get(174).Width = 61.0!
        Me.SheetView1.Columns.Get(175).Width = 61.0!
        Me.SheetView1.Columns.Get(176).Width = 61.0!
        Me.SheetView1.Columns.Get(177).Width = 61.0!
        Me.SheetView1.Columns.Get(178).Width = 61.0!
        Me.SheetView1.Columns.Get(179).Width = 61.0!
        Me.SheetView1.Columns.Get(180).Width = 61.0!
        Me.SheetView1.Columns.Get(181).Width = 61.0!
        Me.SheetView1.Columns.Get(182).Width = 61.0!
        Me.SheetView1.Columns.Get(183).Width = 61.0!
        Me.SheetView1.Columns.Get(184).Width = 61.0!
        Me.SheetView1.Columns.Get(185).Width = 61.0!
        Me.SheetView1.Columns.Get(186).Width = 61.0!
        Me.SheetView1.Columns.Get(187).Width = 61.0!
        Me.SheetView1.Columns.Get(188).Width = 61.0!
        Me.SheetView1.Columns.Get(189).Width = 61.0!
        Me.SheetView1.Columns.Get(190).Width = 61.0!
        Me.SheetView1.Columns.Get(191).Width = 61.0!
        Me.SheetView1.Columns.Get(192).Width = 61.0!
        Me.SheetView1.Columns.Get(193).Width = 61.0!
        Me.SheetView1.Columns.Get(194).Width = 61.0!
        Me.SheetView1.Columns.Get(195).Width = 61.0!
        Me.SheetView1.Columns.Get(196).Width = 61.0!
        Me.SheetView1.Columns.Get(197).Width = 61.0!
        Me.SheetView1.Columns.Get(198).Width = 61.0!
        Me.SheetView1.Columns.Get(199).Width = 61.0!
        Me.SheetView1.Columns.Get(200).Width = 61.0!
        Me.SheetView1.Columns.Get(201).Width = 61.0!
        Me.SheetView1.Columns.Get(202).Width = 61.0!
        Me.SheetView1.Columns.Get(203).Width = 61.0!
        Me.SheetView1.Columns.Get(204).Width = 61.0!
        Me.SheetView1.Columns.Get(205).Width = 61.0!
        Me.SheetView1.Columns.Get(206).Width = 61.0!
        Me.SheetView1.Columns.Get(207).Width = 61.0!
        Me.SheetView1.Columns.Get(208).Width = 61.0!
        Me.SheetView1.Columns.Get(209).Width = 61.0!
        Me.SheetView1.Columns.Get(210).Width = 61.0!
        Me.SheetView1.Columns.Get(211).Width = 61.0!
        Me.SheetView1.Columns.Get(212).Width = 61.0!
        Me.SheetView1.Columns.Get(213).Width = 61.0!
        Me.SheetView1.Columns.Get(214).Width = 61.0!
        Me.SheetView1.Columns.Get(215).Width = 61.0!
        Me.SheetView1.Columns.Get(216).Width = 61.0!
        Me.SheetView1.Columns.Get(217).Width = 61.0!
        Me.SheetView1.Columns.Get(218).Width = 61.0!
        Me.SheetView1.Columns.Get(219).Width = 61.0!
        Me.SheetView1.Columns.Get(220).Width = 61.0!
        Me.SheetView1.Columns.Get(221).Width = 61.0!
        Me.SheetView1.Columns.Get(222).Width = 61.0!
        Me.SheetView1.Columns.Get(223).Width = 61.0!
        Me.SheetView1.Columns.Get(224).Width = 61.0!
        Me.SheetView1.Columns.Get(225).Width = 61.0!
        Me.SheetView1.Columns.Get(226).Width = 61.0!
        Me.SheetView1.Columns.Get(227).Width = 61.0!
        Me.SheetView1.Columns.Get(228).Width = 61.0!
        Me.SheetView1.Columns.Get(229).Width = 61.0!
        Me.SheetView1.Columns.Get(230).Width = 61.0!
        Me.SheetView1.Columns.Get(231).Width = 61.0!
        Me.SheetView1.Columns.Get(232).Width = 61.0!
        Me.SheetView1.Columns.Get(233).Width = 61.0!
        Me.SheetView1.Columns.Get(234).Width = 61.0!
        Me.SheetView1.Columns.Get(235).Width = 61.0!
        Me.SheetView1.Columns.Get(236).Width = 61.0!
        Me.SheetView1.Columns.Get(237).Width = 61.0!
        Me.SheetView1.Columns.Get(238).Width = 61.0!
        Me.SheetView1.Columns.Get(239).Width = 61.0!
        Me.SheetView1.Columns.Get(240).Width = 61.0!
        Me.SheetView1.Columns.Get(241).Width = 61.0!
        Me.SheetView1.Columns.Get(242).Width = 61.0!
        Me.SheetView1.Columns.Get(243).Width = 61.0!
        Me.SheetView1.Columns.Get(244).Width = 61.0!
        Me.SheetView1.Columns.Get(245).Width = 61.0!
        Me.SheetView1.Columns.Get(246).Width = 61.0!
        Me.SheetView1.Columns.Get(247).Width = 61.0!
        Me.SheetView1.Columns.Get(248).Width = 61.0!
        Me.SheetView1.Columns.Get(249).Width = 61.0!
        Me.SheetView1.Columns.Get(250).Width = 61.0!
        Me.SheetView1.Columns.Get(251).Width = 61.0!
        Me.SheetView1.Columns.Get(252).Width = 61.0!
        Me.SheetView1.Columns.Get(253).Width = 61.0!
        Me.SheetView1.Columns.Get(254).Width = 61.0!
        Me.SheetView1.Columns.Get(255).Width = 61.0!
        Me.SheetView1.Columns.Get(256).Width = 61.0!
        Me.SheetView1.Columns.Get(257).Width = 61.0!
        Me.SheetView1.Columns.Get(258).Width = 61.0!
        Me.SheetView1.Columns.Get(259).Width = 61.0!
        Me.SheetView1.Columns.Get(260).Width = 61.0!
        Me.SheetView1.Columns.Get(261).Width = 61.0!
        Me.SheetView1.Columns.Get(262).Width = 61.0!
        Me.SheetView1.Columns.Get(263).Width = 61.0!
        Me.SheetView1.Columns.Get(264).Width = 61.0!
        Me.SheetView1.Columns.Get(265).Width = 61.0!
        Me.SheetView1.Columns.Get(266).Width = 61.0!
        Me.SheetView1.Columns.Get(267).Width = 61.0!
        Me.SheetView1.Columns.Get(268).Width = 61.0!
        Me.SheetView1.Columns.Get(269).Width = 61.0!
        Me.SheetView1.Columns.Get(270).Width = 61.0!
        Me.SheetView1.Columns.Get(271).Width = 61.0!
        Me.SheetView1.Columns.Get(272).Width = 61.0!
        Me.SheetView1.Columns.Get(273).Width = 61.0!
        Me.SheetView1.Columns.Get(274).Width = 61.0!
        Me.SheetView1.Columns.Get(275).Width = 61.0!
        Me.SheetView1.Columns.Get(276).Width = 61.0!
        Me.SheetView1.Columns.Get(277).Width = 61.0!
        Me.SheetView1.Columns.Get(278).Width = 61.0!
        Me.SheetView1.Columns.Get(279).Width = 61.0!
        Me.SheetView1.Columns.Get(280).Width = 61.0!
        Me.SheetView1.Columns.Get(281).Width = 61.0!
        Me.SheetView1.Columns.Get(282).Width = 61.0!
        Me.SheetView1.Columns.Get(283).Width = 61.0!
        Me.SheetView1.Columns.Get(284).Width = 61.0!
        Me.SheetView1.Columns.Get(285).Width = 61.0!
        Me.SheetView1.Columns.Get(286).Width = 61.0!
        Me.SheetView1.Columns.Get(287).Width = 61.0!
        Me.SheetView1.Columns.Get(288).Width = 61.0!
        Me.SheetView1.Columns.Get(289).Width = 61.0!
        Me.SheetView1.Columns.Get(290).Width = 61.0!
        Me.SheetView1.Columns.Get(291).Width = 61.0!
        Me.SheetView1.Columns.Get(292).Width = 61.0!
        Me.SheetView1.Columns.Get(293).Width = 61.0!
        Me.SheetView1.Columns.Get(294).Width = 61.0!
        Me.SheetView1.Columns.Get(295).Width = 61.0!
        Me.SheetView1.Columns.Get(296).Width = 61.0!
        Me.SheetView1.Columns.Get(297).Width = 61.0!
        Me.SheetView1.Columns.Get(298).Width = 61.0!
        Me.SheetView1.Columns.Get(299).Width = 61.0!
        Me.SheetView1.Columns.Get(300).Width = 61.0!
        Me.SheetView1.Columns.Get(301).Width = 61.0!
        Me.SheetView1.Columns.Get(302).Width = 61.0!
        Me.SheetView1.Columns.Get(303).Width = 61.0!
        Me.SheetView1.Columns.Get(304).Width = 61.0!
        Me.SheetView1.Columns.Get(305).Width = 61.0!
        Me.SheetView1.Columns.Get(306).Width = 61.0!
        Me.SheetView1.Columns.Get(307).Width = 61.0!
        Me.SheetView1.Columns.Get(308).Width = 61.0!
        Me.SheetView1.Columns.Get(309).Width = 61.0!
        Me.SheetView1.Columns.Get(310).Width = 61.0!
        Me.SheetView1.Columns.Get(311).Width = 61.0!
        Me.SheetView1.Columns.Get(312).Width = 61.0!
        Me.SheetView1.Columns.Get(313).Width = 61.0!
        Me.SheetView1.Columns.Get(314).Width = 61.0!
        Me.SheetView1.Columns.Get(315).Width = 61.0!
        Me.SheetView1.Columns.Get(316).Width = 61.0!
        Me.SheetView1.Columns.Get(317).Width = 61.0!
        Me.SheetView1.Columns.Get(318).Width = 61.0!
        Me.SheetView1.Columns.Get(319).Width = 61.0!
        Me.SheetView1.Columns.Get(320).Width = 61.0!
        Me.SheetView1.Columns.Get(321).Width = 61.0!
        Me.SheetView1.Columns.Get(322).Width = 61.0!
        Me.SheetView1.Columns.Get(323).Width = 61.0!
        Me.SheetView1.Columns.Get(324).Width = 61.0!
        Me.SheetView1.Columns.Get(325).Width = 61.0!
        Me.SheetView1.Columns.Get(326).Width = 61.0!
        Me.SheetView1.Columns.Get(327).Width = 61.0!
        Me.SheetView1.Columns.Get(328).Width = 61.0!
        Me.SheetView1.Columns.Get(329).Width = 61.0!
        Me.SheetView1.Columns.Get(330).Width = 61.0!
        Me.SheetView1.Columns.Get(331).Width = 61.0!
        Me.SheetView1.Columns.Get(332).Width = 61.0!
        Me.SheetView1.Columns.Get(333).Width = 61.0!
        Me.SheetView1.Columns.Get(334).Width = 61.0!
        Me.SheetView1.Columns.Get(335).Width = 61.0!
        Me.SheetView1.Columns.Get(336).Width = 61.0!
        Me.SheetView1.Columns.Get(337).Width = 61.0!
        Me.SheetView1.Columns.Get(338).Width = 61.0!
        Me.SheetView1.Columns.Get(339).Width = 61.0!
        Me.SheetView1.Columns.Get(340).Width = 61.0!
        Me.SheetView1.Columns.Get(341).Width = 61.0!
        Me.SheetView1.Columns.Get(342).Width = 61.0!
        Me.SheetView1.Columns.Get(343).Width = 61.0!
        Me.SheetView1.Columns.Get(344).Width = 61.0!
        Me.SheetView1.Columns.Get(345).Width = 61.0!
        Me.SheetView1.Columns.Get(346).Width = 61.0!
        Me.SheetView1.Columns.Get(347).Width = 61.0!
        Me.SheetView1.Columns.Get(348).Width = 61.0!
        Me.SheetView1.Columns.Get(349).Width = 61.0!
        Me.SheetView1.Columns.Get(350).Width = 61.0!
        Me.SheetView1.Columns.Get(351).Width = 61.0!
        Me.SheetView1.Columns.Get(352).Width = 61.0!
        Me.SheetView1.Columns.Get(353).Width = 61.0!
        Me.SheetView1.Columns.Get(354).Width = 61.0!
        Me.SheetView1.Columns.Get(355).Width = 61.0!
        Me.SheetView1.Columns.Get(356).Width = 61.0!
        Me.SheetView1.Columns.Get(357).Width = 61.0!
        Me.SheetView1.Columns.Get(358).Width = 61.0!
        Me.SheetView1.Columns.Get(359).Width = 61.0!
        Me.SheetView1.Columns.Get(360).Width = 61.0!
        Me.SheetView1.Columns.Get(361).Width = 61.0!
        Me.SheetView1.Columns.Get(362).Width = 61.0!
        Me.SheetView1.Columns.Get(363).Width = 61.0!
        Me.SheetView1.Columns.Get(364).Width = 61.0!
        Me.SheetView1.Columns.Get(365).Width = 61.0!
        Me.SheetView1.Columns.Get(366).Width = 61.0!
        Me.SheetView1.Columns.Get(367).Width = 61.0!
        Me.SheetView1.Columns.Get(368).Width = 61.0!
        Me.SheetView1.Columns.Get(369).Width = 61.0!
        Me.SheetView1.Columns.Get(370).Width = 61.0!
        Me.SheetView1.Columns.Get(371).Width = 61.0!
        Me.SheetView1.Columns.Get(372).Width = 61.0!
        Me.SheetView1.Columns.Get(373).Width = 61.0!
        Me.SheetView1.Columns.Get(374).Width = 61.0!
        Me.SheetView1.Columns.Get(375).Width = 61.0!
        Me.SheetView1.Columns.Get(376).Width = 61.0!
        Me.SheetView1.Columns.Get(377).Width = 61.0!
        Me.SheetView1.Columns.Get(378).Width = 61.0!
        Me.SheetView1.Columns.Get(379).Width = 61.0!
        Me.SheetView1.Columns.Get(380).Width = 61.0!
        Me.SheetView1.Columns.Get(381).Width = 61.0!
        Me.SheetView1.Columns.Get(382).Width = 61.0!
        Me.SheetView1.Columns.Get(383).Width = 61.0!
        Me.SheetView1.Columns.Get(384).Width = 61.0!
        Me.SheetView1.Columns.Get(385).Width = 61.0!
        Me.SheetView1.Columns.Get(386).Width = 61.0!
        Me.SheetView1.Columns.Get(387).Width = 61.0!
        Me.SheetView1.Columns.Get(388).Width = 61.0!
        Me.SheetView1.Columns.Get(389).Width = 61.0!
        Me.SheetView1.Columns.Get(390).Width = 61.0!
        Me.SheetView1.Columns.Get(391).Width = 61.0!
        Me.SheetView1.Columns.Get(392).Width = 61.0!
        Me.SheetView1.Columns.Get(393).Width = 61.0!
        Me.SheetView1.Columns.Get(394).Width = 61.0!
        Me.SheetView1.Columns.Get(395).Width = 61.0!
        Me.SheetView1.Columns.Get(396).Width = 61.0!
        Me.SheetView1.Columns.Get(397).Width = 61.0!
        Me.SheetView1.Columns.Get(398).Width = 61.0!
        Me.SheetView1.Columns.Get(399).Width = 61.0!
        Me.SheetView1.Columns.Get(400).Width = 61.0!
        Me.SheetView1.Columns.Get(401).Width = 61.0!
        Me.SheetView1.Columns.Get(402).Width = 61.0!
        Me.SheetView1.Columns.Get(403).Width = 61.0!
        Me.SheetView1.Columns.Get(404).Width = 61.0!
        Me.SheetView1.Columns.Get(405).Width = 61.0!
        Me.SheetView1.Columns.Get(406).Width = 61.0!
        Me.SheetView1.Columns.Get(407).Width = 61.0!
        Me.SheetView1.Columns.Get(408).Width = 61.0!
        Me.SheetView1.Columns.Get(409).Width = 61.0!
        Me.SheetView1.Columns.Get(410).Width = 61.0!
        Me.SheetView1.Columns.Get(411).Width = 61.0!
        Me.SheetView1.Columns.Get(412).Width = 61.0!
        Me.SheetView1.Columns.Get(413).Width = 61.0!
        Me.SheetView1.Columns.Get(414).Width = 61.0!
        Me.SheetView1.Columns.Get(415).Width = 61.0!
        Me.SheetView1.Columns.Get(416).Width = 61.0!
        Me.SheetView1.Columns.Get(417).Width = 61.0!
        Me.SheetView1.Columns.Get(418).Width = 61.0!
        Me.SheetView1.Columns.Get(419).Width = 61.0!
        Me.SheetView1.Columns.Get(420).Width = 61.0!
        Me.SheetView1.Columns.Get(421).Width = 61.0!
        Me.SheetView1.Columns.Get(422).Width = 61.0!
        Me.SheetView1.Columns.Get(423).Width = 61.0!
        Me.SheetView1.Columns.Get(424).Width = 61.0!
        Me.SheetView1.Columns.Get(425).Width = 61.0!
        Me.SheetView1.Columns.Get(426).Width = 61.0!
        Me.SheetView1.Columns.Get(427).Width = 61.0!
        Me.SheetView1.Columns.Get(428).Width = 61.0!
        Me.SheetView1.Columns.Get(429).Width = 61.0!
        Me.SheetView1.Columns.Get(430).Width = 61.0!
        Me.SheetView1.Columns.Get(431).Width = 61.0!
        Me.SheetView1.Columns.Get(432).Width = 61.0!
        Me.SheetView1.Columns.Get(433).Width = 61.0!
        Me.SheetView1.Columns.Get(434).Width = 61.0!
        Me.SheetView1.Columns.Get(435).Width = 61.0!
        Me.SheetView1.Columns.Get(436).Width = 61.0!
        Me.SheetView1.Columns.Get(437).Width = 61.0!
        Me.SheetView1.Columns.Get(438).Width = 61.0!
        Me.SheetView1.Columns.Get(439).Width = 61.0!
        Me.SheetView1.Columns.Get(440).Width = 61.0!
        Me.SheetView1.Columns.Get(441).Width = 61.0!
        Me.SheetView1.Columns.Get(442).Width = 61.0!
        Me.SheetView1.Columns.Get(443).Width = 61.0!
        Me.SheetView1.Columns.Get(444).Width = 61.0!
        Me.SheetView1.Columns.Get(445).Width = 61.0!
        Me.SheetView1.Columns.Get(446).Width = 61.0!
        Me.SheetView1.Columns.Get(447).Width = 61.0!
        Me.SheetView1.Columns.Get(448).Width = 61.0!
        Me.SheetView1.Columns.Get(449).Width = 61.0!
        Me.SheetView1.Columns.Get(450).Width = 61.0!
        Me.SheetView1.Columns.Get(451).Width = 61.0!
        Me.SheetView1.Columns.Get(452).Width = 61.0!
        Me.SheetView1.Columns.Get(453).Width = 61.0!
        Me.SheetView1.Columns.Get(454).Width = 61.0!
        Me.SheetView1.Columns.Get(455).Width = 61.0!
        Me.SheetView1.Columns.Get(456).Width = 61.0!
        Me.SheetView1.Columns.Get(457).Width = 61.0!
        Me.SheetView1.Columns.Get(458).Width = 61.0!
        Me.SheetView1.Columns.Get(459).Width = 61.0!
        Me.SheetView1.Columns.Get(460).Width = 61.0!
        Me.SheetView1.Columns.Get(461).Width = 61.0!
        Me.SheetView1.Columns.Get(462).Width = 61.0!
        Me.SheetView1.Columns.Get(463).Width = 61.0!
        Me.SheetView1.Columns.Get(464).Width = 61.0!
        Me.SheetView1.Columns.Get(465).Width = 61.0!
        Me.SheetView1.Columns.Get(466).Width = 61.0!
        Me.SheetView1.Columns.Get(467).Width = 61.0!
        Me.SheetView1.Columns.Get(468).Width = 61.0!
        Me.SheetView1.Columns.Get(469).Width = 61.0!
        Me.SheetView1.Columns.Get(470).Width = 61.0!
        Me.SheetView1.Columns.Get(471).Width = 61.0!
        Me.SheetView1.Columns.Get(472).Width = 61.0!
        Me.SheetView1.Columns.Get(473).Width = 61.0!
        Me.SheetView1.Columns.Get(474).Width = 61.0!
        Me.SheetView1.Columns.Get(475).Width = 61.0!
        Me.SheetView1.Columns.Get(476).Width = 61.0!
        Me.SheetView1.Columns.Get(477).Width = 61.0!
        Me.SheetView1.Columns.Get(478).Width = 61.0!
        Me.SheetView1.Columns.Get(479).Width = 61.0!
        Me.SheetView1.Columns.Get(480).Width = 61.0!
        Me.SheetView1.Columns.Get(481).Width = 61.0!
        Me.SheetView1.Columns.Get(482).Width = 61.0!
        Me.SheetView1.Columns.Get(483).Width = 61.0!
        Me.SheetView1.Columns.Get(484).Width = 61.0!
        Me.SheetView1.Columns.Get(485).Width = 61.0!
        Me.SheetView1.Columns.Get(486).Width = 61.0!
        Me.SheetView1.Columns.Get(487).Width = 61.0!
        Me.SheetView1.Columns.Get(488).Width = 61.0!
        Me.SheetView1.Columns.Get(489).Width = 61.0!
        Me.SheetView1.Columns.Get(490).Width = 61.0!
        Me.SheetView1.Columns.Get(491).Width = 61.0!
        Me.SheetView1.Columns.Get(492).Width = 61.0!
        Me.SheetView1.Columns.Get(493).Width = 61.0!
        Me.SheetView1.Columns.Get(494).Width = 61.0!
        Me.SheetView1.Columns.Get(495).Width = 61.0!
        Me.SheetView1.Columns.Get(496).Width = 61.0!
        Me.SheetView1.Columns.Get(497).Width = 61.0!
        Me.SheetView1.Columns.Get(498).Width = 61.0!
        Me.SheetView1.Columns.Get(499).Width = 61.0!
        Me.SheetView1.RowHeader.Columns.Default.Resizable = False
        Me.SheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FpSpread1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpread1.Location = New System.Drawing.Point(6, 67)
        Me.FpSpread1.Name = "FpSpread1"
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView1})
        Me.FpSpread1.Size = New System.Drawing.Size(1478, 403)
        Me.FpSpread1.TabIndex = 11
        Me.FpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'Equipment_fra
        '
        Me.Equipment_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Equipment_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Equipment_fra.Controls.Add(Me.sprTotals)
        Me.Equipment_fra.Controls.Add(Me.btnAdd)
        Me.Equipment_fra.Controls.Add(Me.btnPrint)
        Me.Equipment_fra.Controls.Add(Me.Button3)
        Me.Equipment_fra.Controls.Add(Me.btnDelete)
        Me.Equipment_fra.Controls.Add(Me.Button2)
        Me.Equipment_fra.Controls.Add(Me.btnForms)
        Me.Equipment_fra.Controls.Add(Me.btnEstimate)
        Me.Equipment_fra.Controls.Add(Me.btnMerge)
        Me.Equipment_fra.Controls.Add(Me.FpSpread1)
        Me.Equipment_fra.Controls.Add(Me._JobHighRiskFactor_lbl_1)
        Me.Equipment_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Equipment_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Equipment_fra.Location = New System.Drawing.Point(0, 294)
        Me.Equipment_fra.Name = "Equipment_fra"
        Me.Equipment_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Equipment_fra.Size = New System.Drawing.Size(1484, 476)
        Me.Equipment_fra.TabIndex = 43
        Me.Equipment_fra.TabStop = False
        Me.Equipment_fra.Text = "Equipment "
        '
        'sprTotals
        '
        Me.sprTotals.AccessibleDescription = "sprTotals, Sheet1, Row 0, Column 0, "
        Me.sprTotals.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprTotals.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.DeepSkyBlue
        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DeepSkyBlue
        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.LightSteelBlue
        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.LightSkyBlue
        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        Me.sprTotals.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.sprTotals.HorizontalScrollBar.TabIndex = 44
        Me.sprTotals.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprTotals.Location = New System.Drawing.Point(6, 49)
        Me.sprTotals.Name = "sprTotals"
        Me.sprTotals.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both
        Me.sprTotals.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both
        Me.sprTotals.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprTotals_Sheet1})
        Me.sprTotals.Size = New System.Drawing.Size(1442, 21)
        Me.sprTotals.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.ArcticSea
        Me.sprTotals.TabIndex = 87
        Me.sprTotals.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprTotals.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.Navy
        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.DeepSkyBlue
        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DeepSkyBlue
        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.LightSteelBlue
        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.LightSkyBlue
        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        Me.sprTotals.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.sprTotals.VerticalScrollBar.TabIndex = 45
        Me.sprTotals.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprTotals_Sheet1
        '
        Me.sprTotals_Sheet1.Reset()
        Me.sprTotals_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprTotals_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprTotals_Sheet1.ColumnCount = 23
        Me.sprTotals_Sheet1.RowCount = 1
        Me.sprTotals_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 0).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 1).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 1).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 2).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 3).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 3).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 4).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 4).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 5).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 5).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 6).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 6).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 7).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 7).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 8).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 8).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 9).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 9).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 9).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 10).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 10).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 10).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 11).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 11).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 11).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 12).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 12).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 12).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 13).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 13).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 13).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 14).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 14).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 14).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 15).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 15).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 15).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 16).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 16).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 16).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 17).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 17).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.Cells.Get(0, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.sprTotals_Sheet1.Cells.Get(0, 18).Locked = True
        Me.sprTotals_Sheet1.Cells.Get(0, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTotals_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderArcticSea"
        Me.sprTotals_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTotals_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerArcticSea"
        Me.sprTotals_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTotals_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderArcticSea"
        Me.sprTotals_Sheet1.ColumnHeader.Rows.Get(0).Height = 33.0!
        Me.sprTotals_Sheet1.ColumnHeader.Visible = False
        Me.sprTotals_Sheet1.Columns.Get(0).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(1).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(2).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(3).Width = 36.0!
        Me.sprTotals_Sheet1.Columns.Get(4).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(5).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(6).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(7).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(8).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(9).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(10).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(11).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(12).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(13).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(14).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(15).Width = 38.0!
        Me.sprTotals_Sheet1.Columns.Get(16).Width = 38.0!
        Me.sprTotals_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black)
        Me.sprTotals_Sheet1.RowHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.sprTotals_Sheet1.RowHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.sprTotals_Sheet1.RowHeader.Cells.Get(0, 0).Value = "Neg Summary"
        Me.sprTotals_Sheet1.RowHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.sprTotals_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.sprTotals_Sheet1.RowHeader.Columns.Get(0).Width = 296.0!
        Me.sprTotals_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTotals_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderArcticSea"
        Me.sprTotals_Sheet1.Rows.Get(0).BackColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.Rows.Get(0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.sprTotals_Sheet1.Rows.Get(0).Height = 13.0!
        Me.sprTotals_Sheet1.Rows.Get(0).Label = "Neg Summary"
        Me.sprTotals_Sheet1.Rows.Get(0).Locked = True
        Me.sprTotals_Sheet1.Rows.Get(0).NoteIndicatorColor = System.Drawing.Color.Cyan
        Me.sprTotals_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTotals_Sheet1.SheetCornerStyle.Parent = "CornerArcticSea"
        Me.sprTotals_Sheet1.VerticalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black)
        Me.sprTotals_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(386, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdd.Size = New System.Drawing.Size(77, 22)
        Me.btnAdd.TabIndex = 80
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.Location = New System.Drawing.Point(842, 21)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 22)
        Me.btnPrint.TabIndex = 79
        Me.btnPrint.Text = "Print to PDF"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.Location = New System.Drawing.Point(1001, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 22)
        Me.Button3.TabIndex = 74
        Me.Button3.Text = "Collapse All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(480, 21)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDelete.Size = New System.Drawing.Size(77, 22)
        Me.btnDelete.TabIndex = 78
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(211, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 22)
        Me.Button2.TabIndex = 73
        Me.Button2.Text = "Expand All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnForms
        '
        Me.btnForms.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnForms.BackColor = System.Drawing.SystemColors.Control
        Me.btnForms.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnForms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnForms.Location = New System.Drawing.Point(667, 21)
        Me.btnForms.Name = "btnForms"
        Me.btnForms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnForms.Size = New System.Drawing.Size(77, 22)
        Me.btnForms.TabIndex = 27
        Me.btnForms.Text = "&Forms"
        Me.btnForms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnForms.UseVisualStyleBackColor = False
        '
        'btnEstimate
        '
        Me.btnEstimate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEstimate.BackColor = System.Drawing.SystemColors.Control
        Me.btnEstimate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstimate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEstimate.Location = New System.Drawing.Point(756, 21)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEstimate.Size = New System.Drawing.Size(77, 22)
        Me.btnEstimate.TabIndex = 28
        Me.btnEstimate.Text = "E&stimate"
        Me.btnEstimate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEstimate.UseVisualStyleBackColor = False
        '
        'btnMerge
        '
        Me.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMerge.BackColor = System.Drawing.SystemColors.Control
        Me.btnMerge.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMerge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMerge.Location = New System.Drawing.Point(573, 21)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMerge.Size = New System.Drawing.Size(77, 22)
        Me.btnMerge.TabIndex = 72
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMerge.UseVisualStyleBackColor = False
        '
        'NewProductService_fra
        '
        Me.NewProductService_fra.BackColor = System.Drawing.SystemColors.Window
        Me.NewProductService_fra.Controls.Add(Me.txtNPSLaborCost)
        Me.NewProductService_fra.Controls.Add(Me.txtNPSOneTimeCost)
        Me.NewProductService_fra.Controls.Add(Me.txtNPSMaterialCost)
        Me.NewProductService_fra.Controls.Add(Me.cboDurationMonths)
        Me.NewProductService_fra.Controls.Add(Me.cboCallBackHours)
        Me.NewProductService_fra.Controls.Add(Me.lblNPSLaborCosts)
        Me.NewProductService_fra.Controls.Add(Me.lblNPSOneTimeCost_)
        Me.NewProductService_fra.Controls.Add(Me.lblDuration)
        Me.NewProductService_fra.Controls.Add(Me.lblNPSMaterialCost)
        Me.NewProductService_fra.Controls.Add(Me.lblCallBackHours)
        Me.NewProductService_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewProductService_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NewProductService_fra.Location = New System.Drawing.Point(1188, 57)
        Me.NewProductService_fra.Name = "NewProductService_fra"
        Me.NewProductService_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NewProductService_fra.Size = New System.Drawing.Size(249, 143)
        Me.NewProductService_fra.TabIndex = 98
        Me.NewProductService_fra.TabStop = False
        Me.NewProductService_fra.Text = "New Product Service"
        '
        'txtNPSLaborCost
        '
        Me.txtNPSLaborCost.AcceptsReturn = True
        Me.txtNPSLaborCost.BackColor = System.Drawing.SystemColors.Window
        Me.txtNPSLaborCost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNPSLaborCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPSLaborCost.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNPSLaborCost.Location = New System.Drawing.Point(165, 87)
        Me.txtNPSLaborCost.MaxLength = 0
        Me.txtNPSLaborCost.Name = "txtNPSLaborCost"
        Me.txtNPSLaborCost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNPSLaborCost.Size = New System.Drawing.Size(78, 20)
        Me.txtNPSLaborCost.TabIndex = 16
        '
        'txtNPSOneTimeCost
        '
        Me.txtNPSOneTimeCost.AcceptsReturn = True
        Me.txtNPSOneTimeCost.BackColor = System.Drawing.SystemColors.Window
        Me.txtNPSOneTimeCost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNPSOneTimeCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPSOneTimeCost.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNPSOneTimeCost.Location = New System.Drawing.Point(165, 111)
        Me.txtNPSOneTimeCost.MaxLength = 0
        Me.txtNPSOneTimeCost.Name = "txtNPSOneTimeCost"
        Me.txtNPSOneTimeCost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNPSOneTimeCost.Size = New System.Drawing.Size(78, 20)
        Me.txtNPSOneTimeCost.TabIndex = 17
        '
        'txtNPSMaterialCost
        '
        Me.txtNPSMaterialCost.AcceptsReturn = True
        Me.txtNPSMaterialCost.BackColor = System.Drawing.SystemColors.Window
        Me.txtNPSMaterialCost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNPSMaterialCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPSMaterialCost.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNPSMaterialCost.Location = New System.Drawing.Point(165, 63)
        Me.txtNPSMaterialCost.MaxLength = 0
        Me.txtNPSMaterialCost.Name = "txtNPSMaterialCost"
        Me.txtNPSMaterialCost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNPSMaterialCost.Size = New System.Drawing.Size(78, 20)
        Me.txtNPSMaterialCost.TabIndex = 15
        '
        'cboDurationMonths
        '
        Me.cboDurationMonths.BackColor = System.Drawing.SystemColors.Window
        Me.cboDurationMonths.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDurationMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDurationMonths.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDurationMonths.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDurationMonths.Location = New System.Drawing.Point(165, 15)
        Me.cboDurationMonths.Name = "cboDurationMonths"
        Me.cboDurationMonths.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDurationMonths.Size = New System.Drawing.Size(78, 21)
        Me.cboDurationMonths.TabIndex = 13
        '
        'cboCallBackHours
        '
        Me.cboCallBackHours.BackColor = System.Drawing.SystemColors.Window
        Me.cboCallBackHours.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboCallBackHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCallBackHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCallBackHours.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCallBackHours.Location = New System.Drawing.Point(165, 39)
        Me.cboCallBackHours.Name = "cboCallBackHours"
        Me.cboCallBackHours.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboCallBackHours.Size = New System.Drawing.Size(78, 21)
        Me.cboCallBackHours.TabIndex = 14
        '
        'lblNPSLaborCosts
        '
        Me.lblNPSLaborCosts.BackColor = System.Drawing.SystemColors.Window
        Me.lblNPSLaborCosts.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNPSLaborCosts.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNPSLaborCosts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNPSLaborCosts.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNPSLaborCosts.Location = New System.Drawing.Point(13, 92)
        Me.lblNPSLaborCosts.Name = "lblNPSLaborCosts"
        Me.lblNPSLaborCosts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNPSLaborCosts.Size = New System.Drawing.Size(141, 18)
        Me.lblNPSLaborCosts.TabIndex = 37
        Me.lblNPSLaborCosts.Text = "Labor Cost (per month) :"
        Me.lblNPSLaborCosts.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNPSOneTimeCost_
        '
        Me.lblNPSOneTimeCost_.BackColor = System.Drawing.SystemColors.Window
        Me.lblNPSOneTimeCost_.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNPSOneTimeCost_.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNPSOneTimeCost_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNPSOneTimeCost_.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNPSOneTimeCost_.Location = New System.Drawing.Point(13, 116)
        Me.lblNPSOneTimeCost_.Name = "lblNPSOneTimeCost_"
        Me.lblNPSOneTimeCost_.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNPSOneTimeCost_.Size = New System.Drawing.Size(141, 18)
        Me.lblNPSOneTimeCost_.TabIndex = 34
        Me.lblNPSOneTimeCost_.Text = "One Time Cost:"
        Me.lblNPSOneTimeCost_.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDuration
        '
        Me.lblDuration.BackColor = System.Drawing.SystemColors.Window
        Me.lblDuration.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDuration.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuration.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDuration.Location = New System.Drawing.Point(13, 20)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDuration.Size = New System.Drawing.Size(141, 18)
        Me.lblDuration.TabIndex = 30
        Me.lblDuration.Text = "Duration (months) :"
        Me.lblDuration.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNPSMaterialCost
        '
        Me.lblNPSMaterialCost.BackColor = System.Drawing.SystemColors.Window
        Me.lblNPSMaterialCost.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNPSMaterialCost.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNPSMaterialCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNPSMaterialCost.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNPSMaterialCost.Location = New System.Drawing.Point(5, 68)
        Me.lblNPSMaterialCost.Name = "lblNPSMaterialCost"
        Me.lblNPSMaterialCost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNPSMaterialCost.Size = New System.Drawing.Size(149, 18)
        Me.lblNPSMaterialCost.TabIndex = 31
        Me.lblNPSMaterialCost.Text = "Material Cost (per month):"
        Me.lblNPSMaterialCost.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCallBackHours
        '
        Me.lblCallBackHours.BackColor = System.Drawing.SystemColors.Window
        Me.lblCallBackHours.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCallBackHours.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCallBackHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallBackHours.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCallBackHours.Location = New System.Drawing.Point(13, 44)
        Me.lblCallBackHours.Name = "lblCallBackHours"
        Me.lblCallBackHours.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCallBackHours.Size = New System.Drawing.Size(141, 18)
        Me.lblCallBackHours.TabIndex = 29
        Me.lblCallBackHours.Text = "Call Back (hours) :"
        Me.lblCallBackHours.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtOCPL
        '
        Me.txtOCPL.AcceptsReturn = True
        Me.txtOCPL.BackColor = System.Drawing.SystemColors.Window
        Me.txtOCPL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOCPL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOCPL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOCPL.Location = New System.Drawing.Point(157, 16)
        Me.txtOCPL.MaxLength = 0
        Me.txtOCPL.Name = "txtOCPL"
        Me.txtOCPL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOCPL.Size = New System.Drawing.Size(78, 20)
        Me.txtOCPL.TabIndex = 99
        '
        'lblOCPL
        '
        Me.lblOCPL.BackColor = System.Drawing.SystemColors.Window
        Me.lblOCPL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOCPL.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblOCPL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOCPL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOCPL.Location = New System.Drawing.Point(8, 19)
        Me.lblOCPL.Name = "lblOCPL"
        Me.lblOCPL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOCPL.Size = New System.Drawing.Size(138, 18)
        Me.lblOCPL.TabIndex = 100
        Me.lblOCPL.Text = "($ in Millions) :"
        Me.lblOCPL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnLaborRates
        '
        Me.btnLaborRates.BackColor = System.Drawing.SystemColors.Control
        Me.btnLaborRates.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.btnLaborRates.Location = New System.Drawing.Point(474, 5)
        Me.btnLaborRates.Name = "btnLaborRates"
        Me.btnLaborRates.Size = New System.Drawing.Size(51, 46)
        Me.btnLaborRates.TabIndex = 101
        Me.btnLaborRates.Text = "Labor Rates"
        Me.btnLaborRates.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLaborRates.UseVisualStyleBackColor = False
        '
        'btnGatewayReview
        '
        Me.btnGatewayReview.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGatewayReview.Location = New System.Drawing.Point(301, 5)
        Me.btnGatewayReview.Name = "btnGatewayReview"
        Me.btnGatewayReview.Size = New System.Drawing.Size(51, 46)
        Me.btnGatewayReview.TabIndex = 102
        Me.btnGatewayReview.TabStop = False
        Me.btnGatewayReview.Tag = ""
        Me.btnGatewayReview.Text = "Gateway"
        Me.btnGatewayReview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblGatewayStatus
        '
        Me.lblGatewayStatus.AutoSize = True
        Me.lblGatewayStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGatewayStatus.Location = New System.Drawing.Point(71, 17)
        Me.lblGatewayStatus.Name = "lblGatewayStatus"
        Me.lblGatewayStatus.Size = New System.Drawing.Size(47, 13)
        Me.lblGatewayStatus.TabIndex = 104
        Me.lblGatewayStatus.Text = "Status:"
        '
        'txtGatewayStatus
        '
        Me.txtGatewayStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatewayStatus.Location = New System.Drawing.Point(124, 13)
        Me.txtGatewayStatus.Name = "txtGatewayStatus"
        Me.txtGatewayStatus.Size = New System.Drawing.Size(119, 20)
        Me.txtGatewayStatus.TabIndex = 103
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblGatewayStatus)
        Me.GroupBox1.Controls.Add(Me.txtGatewayStatus)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1188, 202)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(249, 38)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gateway Review"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtOCPL)
        Me.GroupBox2.Controls.Add(Me.lblOCPL)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(865, 240)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 48)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OCPL"
        '
        'btnProposal
        '
        Me.btnProposal.BackColor = System.Drawing.SystemColors.Control
        Me.btnProposal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProposal.Location = New System.Drawing.Point(358, 5)
        Me.btnProposal.Name = "btnProposal"
        Me.btnProposal.Size = New System.Drawing.Size(51, 46)
        Me.btnProposal.TabIndex = 107
        Me.btnProposal.TabStop = False
        Me.btnProposal.Tag = ""
        Me.btnProposal.Text = "Proposal"
        Me.btnProposal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProposal.UseVisualStyleBackColor = False
        '
        '_label_4
        '
        Me._label_4.BackColor = System.Drawing.SystemColors.Control
        Me._label_4.Enabled = False
        Me._label_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_4.Location = New System.Drawing.Point(664, 9)
        Me._label_4.Name = "_label_4"
        Me._label_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_4.Size = New System.Drawing.Size(70, 13)
        Me._label_4.TabIndex = 62
        Me._label_4.Text = "Estimate # :"
        Me._label_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_label_0
        '
        Me._label_0.AutoSize = True
        Me._label_0.BackColor = System.Drawing.SystemColors.Control
        Me._label_0.Enabled = False
        Me._label_0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._label_0.Location = New System.Drawing.Point(671, 28)
        Me._label_0.Name = "_label_0"
        Me._label_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_0.Size = New System.Drawing.Size(63, 13)
        Me._label_0.TabIndex = 66
        Me._label_0.Text = "Estimator:"
        Me._label_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Menu_tlb_3
        '
        Me._Menu_tlb_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Menu_tlb_3.Image = CType(resources.GetObject("_Menu_tlb_3.Image"), System.Drawing.Image)
        Me._Menu_tlb_3.Location = New System.Drawing.Point(164, 1)
        Me._Menu_tlb_3.Name = "_Menu_tlb_3"
        Me._Menu_tlb_3.Size = New System.Drawing.Size(46, 46)
        Me._Menu_tlb_3.TabIndex = 36
        Me._Menu_tlb_3.TabStop = False
        Me._Menu_tlb_3.Tag = "Print Screen"
        Me._Menu_tlb_3.Text = "Screen"
        Me._Menu_tlb_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(60, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(46, 46)
        Me.btnSave.TabIndex = 34
        Me.btnSave.TabStop = False
        Me.btnSave.Tag = "Save Data"
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(8, 1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(46, 46)
        Me.btnExit.TabIndex = 33
        Me.btnExit.TabStop = False
        Me.btnExit.Tag = "Exit System"
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtEstimator
        '
        Me.txtEstimator.AllowPromptAsInput = False
        Me.txtEstimator.Enabled = False
        Me.txtEstimator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstimator.Location = New System.Drawing.Point(739, 28)
        Me.txtEstimator.Name = "txtEstimator"
        Me.txtEstimator.Size = New System.Drawing.Size(137, 20)
        Me.txtEstimator.TabIndex = 7
        Me.txtEstimator.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtEstimateNum
        '
        Me.txtEstimateNum.AllowPromptAsInput = False
        Me.txtEstimateNum.Enabled = False
        Me.txtEstimateNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstimateNum.Location = New System.Drawing.Point(740, 6)
        Me.txtEstimateNum.Name = "txtEstimateNum"
        Me.txtEstimateNum.Size = New System.Drawing.Size(137, 20)
        Me.txtEstimateNum.TabIndex = 6
        Me.txtEstimateNum.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.Location = New System.Drawing.Point(112, 1)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(46, 46)
        Me.btnCopy.TabIndex = 35
        Me.btnCopy.TabStop = False
        Me.btnCopy.Tag = "Copy Equipment"
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Menu_pic
        '
        Me.Menu_pic.BackColor = System.Drawing.SystemColors.Control
        Me.Menu_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Menu_pic.Controls.Add(Me.btnCopy)
        Me.Menu_pic.Controls.Add(Me.btnExit)
        Me.Menu_pic.Controls.Add(Me.btnSave)
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_3)
        Me.Menu_pic.Dock = System.Windows.Forms.DockStyle.Top
        Me.Menu_pic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_pic.Location = New System.Drawing.Point(0, 0)
        Me.Menu_pic.Name = "Menu_pic"
        Me.Menu_pic.Size = New System.Drawing.Size(1484, 57)
        Me.Menu_pic.TabIndex = 37
        Me.Menu_pic.TabStop = False
        '
        'btnSuptReview
        '
        Me.btnSuptReview.BackColor = System.Drawing.SystemColors.Control
        Me.btnSuptReview.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuptReview.Image = CType(resources.GetObject("btnSuptReview.Image"), System.Drawing.Image)
        Me.btnSuptReview.Location = New System.Drawing.Point(528, 6)
        Me.btnSuptReview.Name = "btnSuptReview"
        Me.btnSuptReview.Size = New System.Drawing.Size(51, 46)
        Me.btnSuptReview.TabIndex = 109
        Me.btnSuptReview.TabStop = False
        Me.btnSuptReview.Tag = "Supt"
        Me.btnSuptReview.Text = "Supt"
        Me.btnSuptReview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSuptReview.UseVisualStyleBackColor = False
        '
        'btnContact
        '
        Me.btnContact.BackColor = System.Drawing.SystemColors.Control
        Me.btnContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.btnContact.Location = New System.Drawing.Point(417, 5)
        Me.btnContact.Name = "btnContact"
        Me.btnContact.Size = New System.Drawing.Size(51, 46)
        Me.btnContact.TabIndex = 110
        Me.btnContact.Text = "Contacts"
        Me.btnContact.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnContact.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtSuptReview)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(1188, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 48)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Superintendent Review"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(71, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Status:"
        '
        'txtSuptReview
        '
        Me.txtSuptReview.Enabled = False
        Me.txtSuptReview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuptReview.Location = New System.Drawing.Point(124, 18)
        Me.txtSuptReview.Name = "txtSuptReview"
        Me.txtSuptReview.Size = New System.Drawing.Size(119, 20)
        Me.txtSuptReview.TabIndex = 103
        '
        'CM_MAIN_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1484, 795)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnContact)
        Me.Controls.Add(Me.btnSuptReview)
        Me.Controls.Add(Me.txtEstimateNum)
        Me.Controls.Add(Me.txtEstimator)
        Me.Controls.Add(Me.btnProposal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me._label_0)
        Me.Controls.Add(Me.btnGatewayReview)
        Me.Controls.Add(Me._label_4)
        Me.Controls.Add(Me.btnLaborRates)
        Me.Controls.Add(Me.NewProductService_fra)
        Me.Controls.Add(Me.btn_Help)
        Me.Controls.Add(Me.BuildingInformation_fra)
        Me.Controls.Add(Me.Equipment_fra)
        Me.Controls.Add(Me.Menu_pic)
        Me.Controls.Add(Me.fraCode)
        Me.Controls.Add(Me.StatusBar1)
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(97, 137)
        Me.MinimumSize = New System.Drawing.Size(800, 676)
        Me.Name = "CM_MAIN_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contract Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BuildingInformation_fra.ResumeLayout(False)
        Me.BuildingInformation_fra.PerformLayout()
        Me.fraCode.ResumeLayout(False)
        Me.fraCode.PerformLayout()
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Equipment_fra.ResumeLayout(False)
        CType(Me.sprTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprTotals_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NewProductService_fra.ResumeLayout(False)
        Me.NewProductService_fra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Menu_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu_pic.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Sub ReLoadForm(ByVal addEvents As Boolean)
        Initializelabel()
        InitializeMenu_tlb()

        InitializeForms_btn()
        InitializeAction_btn()
        If addEvents Then
            'AddHandler MyBase.Activated, AddressOf Me.CM_MAIN_frm_Activated
            'AddHandler MyBase.KeyDown, AddressOf Me.CM_MAIN_frm_KeyDown
            'AddHandler MyBase.KeyPress, AddressOf Me.CM_MAIN_frm_KeyPress
            'AddHandler MyBase.Load, AddressOf Me.CM_MAIN_frm_Load
            'AddHandler MyBase.MouseMove, AddressOf Me.CM_MAIN_frm_MouseMove
            'AddHandler MyBase.FormClosing, AddressOf Me.CM_MAIN_frm_FormClosing
            'AddHandler MyBase.Resize, AddressOf Me.CM_MAIN_frm_Resize
            'AddHandler MyBase.Closed, AddressOf Me.CM_MAIN_frm_Closed
        End If
    End Sub
    Sub Initializelabel()
        ReDim label(14)
        Me.label(7) = _label_7
        Me.label(14) = _label_14
        Me.label(12) = _label_12
        Me.label(10) = _label_10
        Me.label(9) = _label_9
        Me.label(8) = _label_8
        Me.label(0) = _label_0
        Me.label(4) = _label_4
    End Sub
    Sub InitializeMenu_tlb()
        ReDim Menu_tlb(4)
        Me.Menu_tlb(2) = btnCopy
        Me.Menu_tlb(0) = btnExit
        Me.Menu_tlb(1) = btnSave
        Me.Menu_tlb(3) = _Menu_tlb_3
        Me.Menu_tlb(4) = btn_Help
    End Sub

    Sub InitializeForms_btn()
        ReDim Forms_btn(2)

        Me.Forms_btn(1) = btnForms
        Me.Forms_btn(2) = btnEstimate
    End Sub
    Sub InitializeAction_btn()

    End Sub
    Friend WithEvents CurrentTime_tim As System.Windows.Forms.Timer
    Public WithEvents cboStatus As System.Windows.Forms.ComboBox
    Private WithEvents _label_7 As System.Windows.Forms.Label
    Public WithEvents Status_lbl As System.Windows.Forms.Label
    Public WithEvents cboSalesRep As System.Windows.Forms.ComboBox
    Public WithEvents cboInstallingOffice As System.Windows.Forms.ComboBox
    Public WithEvents cboServiceOffice As System.Windows.Forms.ComboBox
    Public WithEvents SalesOffice_lbl As System.Windows.Forms.Label
    Public WithEvents InstallingOffice_lbl As System.Windows.Forms.Label
    Public WithEvents cboSalesOffice As System.Windows.Forms.ComboBox
    Public WithEvents ServiceOffice_lbl As System.Windows.Forms.Label
    Public WithEvents cboProbabilityOfSale As System.Windows.Forms.ComboBox
    Public WithEvents ProbabilityOfSale_lbl As System.Windows.Forms.Label
    Private WithEvents _JobHighRiskFactor_lbl_1 As System.Windows.Forms.Label
    Friend WithEvents SheetView1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Public WithEvents Equipment_fra As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents btnForms As System.Windows.Forms.Button
    Private WithEvents btnEstimate As System.Windows.Forms.Button
    Private WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cboBuildingType As System.Windows.Forms.ComboBox
    Public WithEvents lblBuildingType As System.Windows.Forms.Label
    Public WithEvents txtBidDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtConsultant As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNationalAccount As System.Windows.Forms.Label
    Friend WithEvents cboNationalAccount As System.Windows.Forms.ComboBox
    Public WithEvents fraCode As System.Windows.Forms.GroupBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents chkHeadDetection As System.Windows.Forms.CheckBox
    Public WithEvents cboNFPA13CodeYear As System.Windows.Forms.ComboBox
    Public WithEvents txtSDSlevel As System.Windows.Forms.TextBox
    Public WithEvents SDSlevel_lbl As System.Windows.Forms.Label
    Public WithEvents chkDSA As System.Windows.Forms.CheckBox
    Public WithEvents chkOSHPD As System.Windows.Forms.CheckBox
    Public WithEvents HeatDetection_chk As System.Windows.Forms.CheckBox
    Public WithEvents cboANSICode As System.Windows.Forms.ComboBox
    Public WithEvents cboLocalCode As System.Windows.Forms.ComboBox
    Public WithEvents cboSeismicZone As System.Windows.Forms.ComboBox
    Public WithEvents ANSICode_lbl As System.Windows.Forms.Label
    Public WithEvents lblLocalCode As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTaxCode As System.Windows.Forms.ComboBox
    Friend WithEvents ExpandCollapseFrame_btn As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Public WithEvents NewProductService_fra As System.Windows.Forms.GroupBox
    Public WithEvents txtNPSLaborCost As System.Windows.Forms.TextBox
    Public WithEvents txtNPSOneTimeCost As System.Windows.Forms.TextBox
    Public WithEvents txtNPSMaterialCost As System.Windows.Forms.TextBox
    Public WithEvents cboDurationMonths As System.Windows.Forms.ComboBox
    Public WithEvents cboCallBackHours As System.Windows.Forms.ComboBox
    Public WithEvents lblNPSLaborCosts As System.Windows.Forms.Label
    Public WithEvents lblNPSOneTimeCost_ As System.Windows.Forms.Label
    Public WithEvents lblDuration As System.Windows.Forms.Label
    Public WithEvents lblNPSMaterialCost As System.Windows.Forms.Label
    Public WithEvents lblCallBackHours As System.Windows.Forms.Label
    Public WithEvents txtOCPL As System.Windows.Forms.TextBox
    Public WithEvents lblOCPL As System.Windows.Forms.Label
    Friend WithEvents sprTotals As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprTotals_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Private WithEvents btnGatewayReview As System.Windows.Forms.Button
    Friend WithEvents lblGatewayStatus As System.Windows.Forms.Label
    Friend WithEvents txtGatewayStatus As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtContractNumber As System.Windows.Forms.TextBox
    Private WithEvents lblContractNumber As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents btnProposal As System.Windows.Forms.Button
    Private WithEvents _label_4 As System.Windows.Forms.Label
    Private WithEvents _label_0 As System.Windows.Forms.Label
    Private WithEvents _Menu_tlb_3 As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnExit As System.Windows.Forms.Button
    Public WithEvents txtEstimator As System.Windows.Forms.MaskedTextBox
    Public WithEvents txtEstimateNum As System.Windows.Forms.MaskedTextBox
    Private WithEvents btnCopy As System.Windows.Forms.Button
    Public WithEvents Menu_pic As System.Windows.Forms.PictureBox
    Private WithEvents btnSuptReview As System.Windows.Forms.Button
    Public WithEvents cboSupt As System.Windows.Forms.ComboBox
    Public WithEvents lblSupt As System.Windows.Forms.Label
    Private WithEvents btnLaborRates As System.Windows.Forms.Button
    Private WithEvents btnContact As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSuptReview As System.Windows.Forms.TextBox
#End Region
End Class