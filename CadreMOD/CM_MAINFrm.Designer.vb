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
        CreateDataSet()
        Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel
        model = FpSpread1.ActiveSheet.Models.Data

        Dim dt As DataTable
        For Each dt In myDataSet.Tables
            dt.DefaultView.AllowNew = False
        Next
        model.DataMember = "artists"
        model.DataSource = myDataSet

        FpSpread1.ActiveSheet.GetDataView(False).AllowNew = False

    End Sub
    Private visualControls() As String = New String() {"components", "ToolTipMain", "CostPriceView_cmb", "CostPrice_grd", "Totals_grd", "CostPriceView_lbl", "CostPrice_fra", "Comments_txt", "Comments_fra", "AgentFor_txt", "Company_txt", "ContactName_txt", "ContactCity_txt", "ContactAddress2_txt", "ContactAddress_txt", "ContactState_txt", "ContactZip_txt", "Agentfor_lbl", "Company_lbl", "ContactName_lbl", "ContactZip_lbl", "ContactState_lbl", "ContactCity_lbl", "ContactAddress_lbl", "Contact_fra", "ServiceOffice_cmb", "InstallingOffice_cmb", "SalesRep_lst", "ProbabilityOfSale_lst", "Status_cmb", "SalesOffice_lst", "ServiceOffice_lbl", "ProbabilityOfSale_lbl", "Status_lbl", "_label_7", "InstallingOffice_lbl", "SalesOffice_lbl", "Job_Info_Fra", "_Forms_btn_0", "JobAddress2_txt", "JobCity_txt", "JobAddress_txt", "JobName_txt", "JobState_txt", "JobZip_txt", "_label_14", "_label_12", "_label_10", "_label_9", "_label_8", "Customer_Info_Fra", "GO_grd", "_Forms_btn_1", "_Forms_btn_2", "_Action_btn_0", "_Action_btn_1", "_JobHighRiskFactor_lbl_1", "_JobHighRiskFactor_lbl_0", "Equipment_fra", "Scope_grd", "Scope_fra", "Hidden_pic", "_Menu_tlb_2", "EstimateNum_txt", "Estimator_txt", "_Menu_tlb_0", "_Menu_tlb_1", "_Menu_tlb_3", "_Menu_tlb_4", "_label_0", "_label_4", "TodaysDate_lbl", "Menu_pic", "_StatusBar1_Panel1", "_StatusBar1_Panel2", "_StatusBar1_Panel3", "_StatusBar1_Panel4", "StatusBar1", "Action_frm", "Action_btn", "Forms_btn", "JobHighRiskFactor_lbl", "Menu_tlb", "label", "Scope_grd_Sheet1", "GO_grd_Sheet1", "Totals_grd_Sheet1", "CostPrice_grd_Sheet1"}
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Public WithEvents AgentFor_txt As System.Windows.Forms.TextBox
    Public WithEvents Company_txt As System.Windows.Forms.TextBox
    Public WithEvents ContactName_txt As System.Windows.Forms.TextBox
    Public WithEvents ContactCity_txt As System.Windows.Forms.TextBox
    Public WithEvents ContactAddress2_txt As System.Windows.Forms.TextBox
    Public WithEvents ContactAddress_txt As System.Windows.Forms.TextBox
    Public WithEvents ContactState_txt As System.Windows.Forms.MaskedTextBox
    Public WithEvents ContactZip_txt As System.Windows.Forms.MaskedTextBox
    Public WithEvents Agentfor_lbl As System.Windows.Forms.Label
    Public WithEvents Company_lbl As System.Windows.Forms.Label
    Public WithEvents ContactName_lbl As System.Windows.Forms.Label
    Public WithEvents ContactZip_lbl As System.Windows.Forms.Label
    Public WithEvents ContactState_lbl As System.Windows.Forms.Label
    Public WithEvents ContactCity_lbl As System.Windows.Forms.Label
    Public WithEvents ContactAddress_lbl As System.Windows.Forms.Label
    Public WithEvents BuildingInformation_fra As System.Windows.Forms.GroupBox
    Private WithEvents _Forms_btn_0 As System.Windows.Forms.Button
    Public WithEvents JobAddress2_txt As System.Windows.Forms.TextBox
    Public WithEvents JobCity_txt As System.Windows.Forms.TextBox
    Public WithEvents JobAddress_txt As System.Windows.Forms.TextBox
    Public WithEvents JobName_txt As System.Windows.Forms.TextBox
    Public WithEvents JobState_txt As System.Windows.Forms.MaskedTextBox
    Public WithEvents JobZip_txt As System.Windows.Forms.MaskedTextBox
    Private WithEvents _label_14 As System.Windows.Forms.Label
    Private WithEvents _label_12 As System.Windows.Forms.Label
    Private WithEvents _label_10 As System.Windows.Forms.Label
    Private WithEvents _label_9 As System.Windows.Forms.Label
    Private WithEvents _label_8 As System.Windows.Forms.Label
    Private WithEvents _Menu_tlb_2 As System.Windows.Forms.Button
    Public WithEvents EstimateNum_txt As System.Windows.Forms.MaskedTextBox
    Public WithEvents Estimator_txt As System.Windows.Forms.MaskedTextBox
    Private WithEvents _Menu_tlb_0 As System.Windows.Forms.Button
    Private WithEvents _Menu_tlb_1 As System.Windows.Forms.Button
    Private WithEvents _Menu_tlb_3 As System.Windows.Forms.Button
    Private WithEvents _Menu_tlb_4 As System.Windows.Forms.Button
    Private WithEvents _label_0 As System.Windows.Forms.Label
    Private WithEvents _label_4 As System.Windows.Forms.Label
    Public WithEvents Menu_pic As System.Windows.Forms.PictureBox
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
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.AgentFor_txt = New System.Windows.Forms.TextBox()
        Me.Company_txt = New System.Windows.Forms.TextBox()
        Me.ContactName_txt = New System.Windows.Forms.TextBox()
        Me.ContactCity_txt = New System.Windows.Forms.TextBox()
        Me.ContactAddress2_txt = New System.Windows.Forms.TextBox()
        Me.ContactAddress_txt = New System.Windows.Forms.TextBox()
        Me.ContactState_txt = New System.Windows.Forms.MaskedTextBox()
        Me.ContactZip_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Agentfor_lbl = New System.Windows.Forms.Label()
        Me.Company_lbl = New System.Windows.Forms.Label()
        Me.ContactName_lbl = New System.Windows.Forms.Label()
        Me.ContactZip_lbl = New System.Windows.Forms.Label()
        Me.ContactState_lbl = New System.Windows.Forms.Label()
        Me.ContactCity_lbl = New System.Windows.Forms.Label()
        Me.ContactAddress_lbl = New System.Windows.Forms.Label()
        Me.BuildingInformation_fra = New System.Windows.Forms.GroupBox()
        Me.BuildingType_cmb = New System.Windows.Forms.ComboBox()
        Me.BuildingType_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Proposal_cmd = New System.Windows.Forms.Button()
        Me.Status_cmb = New System.Windows.Forms.ComboBox()
        Me.Consultant_chk = New System.Windows.Forms.CheckBox()
        Me._label_7 = New System.Windows.Forms.Label()
        Me.MajorProject_chk = New System.Windows.Forms.CheckBox()
        Me.Status_lbl = New System.Windows.Forms.Label()
        Me.SalesRep_lst = New System.Windows.Forms.ComboBox()
        Me.InstallingOffice_cmb = New System.Windows.Forms.ComboBox()
        Me.ServiceOffice_cmb = New System.Windows.Forms.ComboBox()
        Me.SalesOffice_lbl = New System.Windows.Forms.Label()
        Me.InstallingOffice_lbl = New System.Windows.Forms.Label()
        Me.SalesOffice_lst = New System.Windows.Forms.ComboBox()
        Me.ServiceOffice_lbl = New System.Windows.Forms.Label()
        Me.ProbabilityOfSale_lst = New System.Windows.Forms.ComboBox()
        Me.ProbabilityOfSale_lbl = New System.Windows.Forms.Label()
        Me._Forms_btn_0 = New System.Windows.Forms.Button()
        Me.JobAddress2_txt = New System.Windows.Forms.TextBox()
        Me.JobCity_txt = New System.Windows.Forms.TextBox()
        Me.JobAddress_txt = New System.Windows.Forms.TextBox()
        Me.JobName_txt = New System.Windows.Forms.TextBox()
        Me.JobState_txt = New System.Windows.Forms.MaskedTextBox()
        Me.JobZip_txt = New System.Windows.Forms.MaskedTextBox()
        Me._label_14 = New System.Windows.Forms.Label()
        Me._label_12 = New System.Windows.Forms.Label()
        Me._label_10 = New System.Windows.Forms.Label()
        Me._label_9 = New System.Windows.Forms.Label()
        Me._label_8 = New System.Windows.Forms.Label()
        Me.Menu_pic = New System.Windows.Forms.PictureBox()
        Me._Menu_tlb_2 = New System.Windows.Forms.Button()
        Me.EstimateNum_txt = New System.Windows.Forms.MaskedTextBox()
        Me.Estimator_txt = New System.Windows.Forms.MaskedTextBox()
        Me._Menu_tlb_0 = New System.Windows.Forms.Button()
        Me._Menu_tlb_1 = New System.Windows.Forms.Button()
        Me._Menu_tlb_3 = New System.Windows.Forms.Button()
        Me._Menu_tlb_4 = New System.Windows.Forms.Button()
        Me._label_0 = New System.Windows.Forms.Label()
        Me._label_4 = New System.Windows.Forms.Label()
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnDeleteMaster = New System.Windows.Forms.Button()
        Me.btnDeleteAlt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnDeleteBank = New System.Windows.Forms.Button()
        Me.btnForms = New System.Windows.Forms.Button()
        Me.btnAddBank = New System.Windows.Forms.Button()
        Me._Forms_btn_2 = New System.Windows.Forms.Button()
        Me.btnAddAlt = New System.Windows.Forms.Button()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.txtBidDate = New System.Windows.Forms.TextBox()
        Me.BuildingInformation_fra.SuspendLayout()
        CType(Me.Menu_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu_pic.SuspendLayout()
        Me.StatusBar1.SuspendLayout()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Equipment_fra.SuspendLayout()
        Me.SuspendLayout()
        '
        'AgentFor_txt
        '
        Me.AgentFor_txt.AcceptsReturn = True
        Me.AgentFor_txt.BackColor = System.Drawing.SystemColors.Window
        Me.AgentFor_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentFor_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AgentFor_txt.Location = New System.Drawing.Point(901, 129)
        Me.AgentFor_txt.MaxLength = 0
        Me.AgentFor_txt.Name = "AgentFor_txt"
        Me.AgentFor_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AgentFor_txt.Size = New System.Drawing.Size(327, 20)
        Me.AgentFor_txt.TabIndex = 14
        Me.AgentFor_txt.Text = "Arrow, Ltd"
        '
        'Company_txt
        '
        Me.Company_txt.AcceptsReturn = True
        Me.Company_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Company_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Company_txt.Location = New System.Drawing.Point(901, 15)
        Me.Company_txt.MaxLength = 0
        Me.Company_txt.Name = "Company_txt"
        Me.Company_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Company_txt.Size = New System.Drawing.Size(327, 20)
        Me.Company_txt.TabIndex = 7
        Me.Company_txt.Text = "Queen Enterprises"
        '
        'ContactName_txt
        '
        Me.ContactName_txt.AcceptsReturn = True
        Me.ContactName_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ContactName_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactName_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactName_txt.Location = New System.Drawing.Point(901, 107)
        Me.ContactName_txt.MaxLength = 0
        Me.ContactName_txt.Name = "ContactName_txt"
        Me.ContactName_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactName_txt.Size = New System.Drawing.Size(327, 20)
        Me.ContactName_txt.TabIndex = 13
        Me.ContactName_txt.Text = "Oliver Queen"
        '
        'ContactCity_txt
        '
        Me.ContactCity_txt.AcceptsReturn = True
        Me.ContactCity_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ContactCity_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactCity_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactCity_txt.Location = New System.Drawing.Point(901, 81)
        Me.ContactCity_txt.MaxLength = 0
        Me.ContactCity_txt.Name = "ContactCity_txt"
        Me.ContactCity_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactCity_txt.Size = New System.Drawing.Size(140, 20)
        Me.ContactCity_txt.TabIndex = 10
        Me.ContactCity_txt.Text = "Starling City"
        '
        'ContactAddress2_txt
        '
        Me.ContactAddress2_txt.AcceptsReturn = True
        Me.ContactAddress2_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ContactAddress2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactAddress2_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactAddress2_txt.Location = New System.Drawing.Point(901, 61)
        Me.ContactAddress2_txt.MaxLength = 0
        Me.ContactAddress2_txt.Name = "ContactAddress2_txt"
        Me.ContactAddress2_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactAddress2_txt.Size = New System.Drawing.Size(327, 20)
        Me.ContactAddress2_txt.TabIndex = 9
        '
        'ContactAddress_txt
        '
        Me.ContactAddress_txt.AcceptsReturn = True
        Me.ContactAddress_txt.BackColor = System.Drawing.SystemColors.Window
        Me.ContactAddress_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactAddress_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactAddress_txt.Location = New System.Drawing.Point(901, 37)
        Me.ContactAddress_txt.MaxLength = 0
        Me.ContactAddress_txt.Name = "ContactAddress_txt"
        Me.ContactAddress_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactAddress_txt.Size = New System.Drawing.Size(327, 20)
        Me.ContactAddress_txt.TabIndex = 8
        Me.ContactAddress_txt.Text = "123 Broad Street"
        '
        'ContactState_txt
        '
        Me.ContactState_txt.AllowPromptAsInput = False
        Me.ContactState_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactState_txt.Location = New System.Drawing.Point(1088, 81)
        Me.ContactState_txt.Mask = ">AA"
        Me.ContactState_txt.Name = "ContactState_txt"
        Me.ContactState_txt.Size = New System.Drawing.Size(25, 20)
        Me.ContactState_txt.TabIndex = 11
        Me.ContactState_txt.Text = "AA"
        Me.ContactState_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'ContactZip_txt
        '
        Me.ContactZip_txt.AllowPromptAsInput = False
        Me.ContactZip_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactZip_txt.Location = New System.Drawing.Point(1154, 81)
        Me.ContactZip_txt.Mask = "00000-9999"
        Me.ContactZip_txt.Name = "ContactZip_txt"
        Me.ContactZip_txt.Size = New System.Drawing.Size(74, 20)
        Me.ContactZip_txt.TabIndex = 12
        Me.ContactZip_txt.Text = "000000000"
        Me.ContactZip_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Agentfor_lbl
        '
        Me.Agentfor_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Agentfor_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Agentfor_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agentfor_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Agentfor_lbl.Location = New System.Drawing.Point(798, 132)
        Me.Agentfor_lbl.Name = "Agentfor_lbl"
        Me.Agentfor_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Agentfor_lbl.Size = New System.Drawing.Size(97, 17)
        Me.Agentfor_lbl.TabIndex = 60
        Me.Agentfor_lbl.Text = "Agent For:"
        Me.Agentfor_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Company_lbl
        '
        Me.Company_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Company_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Company_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Company_lbl.Location = New System.Drawing.Point(798, 19)
        Me.Company_lbl.Name = "Company_lbl"
        Me.Company_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Company_lbl.Size = New System.Drawing.Size(97, 13)
        Me.Company_lbl.TabIndex = 59
        Me.Company_lbl.Text = "Company:"
        Me.Company_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactName_lbl
        '
        Me.ContactName_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ContactName_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ContactName_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactName_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ContactName_lbl.Location = New System.Drawing.Point(798, 110)
        Me.ContactName_lbl.Name = "ContactName_lbl"
        Me.ContactName_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactName_lbl.Size = New System.Drawing.Size(97, 17)
        Me.ContactName_lbl.TabIndex = 58
        Me.ContactName_lbl.Text = "Contact Name:"
        Me.ContactName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactZip_lbl
        '
        Me.ContactZip_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ContactZip_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ContactZip_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactZip_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactZip_lbl.Location = New System.Drawing.Point(1112, 85)
        Me.ContactZip_lbl.Name = "ContactZip_lbl"
        Me.ContactZip_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactZip_lbl.Size = New System.Drawing.Size(23, 13)
        Me.ContactZip_lbl.TabIndex = 57
        Me.ContactZip_lbl.Text = "Zip:"
        Me.ContactZip_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContactState_lbl
        '
        Me.ContactState_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ContactState_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ContactState_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactState_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactState_lbl.Location = New System.Drawing.Point(1047, 85)
        Me.ContactState_lbl.Name = "ContactState_lbl"
        Me.ContactState_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactState_lbl.Size = New System.Drawing.Size(45, 13)
        Me.ContactState_lbl.TabIndex = 56
        Me.ContactState_lbl.Text = "State:"
        '
        'ContactCity_lbl
        '
        Me.ContactCity_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ContactCity_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ContactCity_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactCity_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactCity_lbl.Location = New System.Drawing.Point(798, 88)
        Me.ContactCity_lbl.Name = "ContactCity_lbl"
        Me.ContactCity_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactCity_lbl.Size = New System.Drawing.Size(97, 13)
        Me.ContactCity_lbl.TabIndex = 55
        Me.ContactCity_lbl.Text = "City:"
        Me.ContactCity_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContactAddress_lbl
        '
        Me.ContactAddress_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ContactAddress_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ContactAddress_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactAddress_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContactAddress_lbl.Location = New System.Drawing.Point(798, 41)
        Me.ContactAddress_lbl.Name = "ContactAddress_lbl"
        Me.ContactAddress_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ContactAddress_lbl.Size = New System.Drawing.Size(97, 13)
        Me.ContactAddress_lbl.TabIndex = 54
        Me.ContactAddress_lbl.Text = "Contact Address:"
        Me.ContactAddress_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BuildingInformation_fra
        '
        Me.BuildingInformation_fra.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingInformation_fra.Controls.Add(Me.BuildingType_cmb)
        Me.BuildingInformation_fra.Controls.Add(Me.BuildingType_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.txtBidDate)
        Me.BuildingInformation_fra.Controls.Add(Me.Label1)
        Me.BuildingInformation_fra.Controls.Add(Me.Proposal_cmd)
        Me.BuildingInformation_fra.Controls.Add(Me.Status_cmb)
        Me.BuildingInformation_fra.Controls.Add(Me.Consultant_chk)
        Me.BuildingInformation_fra.Controls.Add(Me._label_7)
        Me.BuildingInformation_fra.Controls.Add(Me.MajorProject_chk)
        Me.BuildingInformation_fra.Controls.Add(Me.Status_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.SalesRep_lst)
        Me.BuildingInformation_fra.Controls.Add(Me.InstallingOffice_cmb)
        Me.BuildingInformation_fra.Controls.Add(Me.ServiceOffice_cmb)
        Me.BuildingInformation_fra.Controls.Add(Me.SalesOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.InstallingOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.SalesOffice_lst)
        Me.BuildingInformation_fra.Controls.Add(Me.ServiceOffice_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.ProbabilityOfSale_lst)
        Me.BuildingInformation_fra.Controls.Add(Me.ProbabilityOfSale_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me._Forms_btn_0)
        Me.BuildingInformation_fra.Controls.Add(Me.AgentFor_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.Company_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.JobAddress2_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactName_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactCity_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.JobCity_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactAddress2_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactAddress_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactState_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.JobAddress_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactZip_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.JobName_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.Agentfor_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.Company_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.JobState_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactName_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactZip_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.JobZip_txt)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactState_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactCity_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me._label_14)
        Me.BuildingInformation_fra.Controls.Add(Me.ContactAddress_lbl)
        Me.BuildingInformation_fra.Controls.Add(Me._label_12)
        Me.BuildingInformation_fra.Controls.Add(Me._label_10)
        Me.BuildingInformation_fra.Controls.Add(Me._label_9)
        Me.BuildingInformation_fra.Controls.Add(Me._label_8)
        Me.BuildingInformation_fra.Dock = System.Windows.Forms.DockStyle.Top
        Me.BuildingInformation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingInformation_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BuildingInformation_fra.Location = New System.Drawing.Point(0, 57)
        Me.BuildingInformation_fra.Name = "BuildingInformation_fra"
        Me.BuildingInformation_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingInformation_fra.Size = New System.Drawing.Size(1452, 227)
        Me.BuildingInformation_fra.TabIndex = 50
        Me.BuildingInformation_fra.TabStop = False
        Me.BuildingInformation_fra.Text = "Building/Job Information"
        '
        'BuildingType_cmb
        '
        Me.BuildingType_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuildingType_cmb.DropDownWidth = 222
        Me.BuildingType_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingType_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BuildingType_cmb.Location = New System.Drawing.Point(578, 125)
        Me.BuildingType_cmb.Name = "BuildingType_cmb"
        Me.BuildingType_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingType_cmb.Size = New System.Drawing.Size(50, 21)
        Me.BuildingType_cmb.TabIndex = 86
        '
        'BuildingType_lbl
        '
        Me.BuildingType_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.BuildingType_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BuildingType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildingType_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BuildingType_lbl.Location = New System.Drawing.Point(467, 127)
        Me.BuildingType_lbl.Name = "BuildingType_lbl"
        Me.BuildingType_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildingType_lbl.Size = New System.Drawing.Size(100, 13)
        Me.BuildingType_lbl.TabIndex = 87
        Me.BuildingType_lbl.Text = "Building Type"
        Me.BuildingType_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(958, 205)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Bid Date"
        '
        'Proposal_cmd
        '
        Me.Proposal_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Proposal_cmd.Location = New System.Drawing.Point(1163, 157)
        Me.Proposal_cmd.Name = "Proposal_cmd"
        Me.Proposal_cmd.Size = New System.Drawing.Size(67, 23)
        Me.Proposal_cmd.TabIndex = 73
        Me.Proposal_cmd.Text = "Proposal"
        Me.Proposal_cmd.UseVisualStyleBackColor = True
        '
        'Status_cmb
        '
        Me.Status_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.Status_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Status_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status_cmb.Location = New System.Drawing.Point(1003, 157)
        Me.Status_cmb.Name = "Status_cmb"
        Me.Status_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Status_cmb.Size = New System.Drawing.Size(153, 21)
        Me.Status_cmb.TabIndex = 72
        '
        'Consultant_chk
        '
        Me.Consultant_chk.BackColor = System.Drawing.SystemColors.Window
        Me.Consultant_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Consultant_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.Consultant_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Consultant_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consultant_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Consultant_chk.Location = New System.Drawing.Point(510, 198)
        Me.Consultant_chk.Name = "Consultant_chk"
        Me.Consultant_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Consultant_chk.Size = New System.Drawing.Size(79, 15)
        Me.Consultant_chk.TabIndex = 76
        Me.Consultant_chk.Text = "Consultant"
        Me.Consultant_chk.UseVisualStyleBackColor = False
        '
        '_label_7
        '
        Me._label_7.AutoSize = True
        Me._label_7.BackColor = System.Drawing.SystemColors.Window
        Me._label_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._label_7.Location = New System.Drawing.Point(43, 156)
        Me._label_7.Name = "_label_7"
        Me._label_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_7.Size = New System.Drawing.Size(65, 13)
        Me._label_7.TabIndex = 81
        Me._label_7.Text = "Sales Rep"
        Me._label_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MajorProject_chk
        '
        Me.MajorProject_chk.BackColor = System.Drawing.SystemColors.Window
        Me.MajorProject_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MajorProject_chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.MajorProject_chk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MajorProject_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MajorProject_chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MajorProject_chk.Location = New System.Drawing.Point(27, 204)
        Me.MajorProject_chk.Name = "MajorProject_chk"
        Me.MajorProject_chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MajorProject_chk.Size = New System.Drawing.Size(103, 15)
        Me.MajorProject_chk.TabIndex = 75
        Me.MajorProject_chk.Text = "Major Project"
        Me.MajorProject_chk.UseVisualStyleBackColor = False
        '
        'Status_lbl
        '
        Me.Status_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.Status_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Status_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Status_lbl.Location = New System.Drawing.Point(958, 159)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Status_lbl.Size = New System.Drawing.Size(39, 17)
        Me.Status_lbl.TabIndex = 79
        Me.Status_lbl.Text = "Status"
        Me.Status_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SalesRep_lst
        '
        Me.SalesRep_lst.BackColor = System.Drawing.SystemColors.Window
        Me.SalesRep_lst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SalesRep_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesRep_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SalesRep_lst.Location = New System.Drawing.Point(115, 154)
        Me.SalesRep_lst.Name = "SalesRep_lst"
        Me.SalesRep_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SalesRep_lst.Size = New System.Drawing.Size(220, 21)
        Me.SalesRep_lst.Sorted = True
        Me.SalesRep_lst.TabIndex = 68
        '
        'InstallingOffice_cmb
        '
        Me.InstallingOffice_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.InstallingOffice_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InstallingOffice_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallingOffice_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.InstallingOffice_cmb.Location = New System.Drawing.Point(578, 148)
        Me.InstallingOffice_cmb.Name = "InstallingOffice_cmb"
        Me.InstallingOffice_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InstallingOffice_cmb.Size = New System.Drawing.Size(62, 21)
        Me.InstallingOffice_cmb.TabIndex = 70
        '
        'ServiceOffice_cmb
        '
        Me.ServiceOffice_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.ServiceOffice_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServiceOffice_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServiceOffice_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ServiceOffice_cmb.Location = New System.Drawing.Point(578, 172)
        Me.ServiceOffice_cmb.Name = "ServiceOffice_cmb"
        Me.ServiceOffice_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServiceOffice_cmb.Size = New System.Drawing.Size(62, 21)
        Me.ServiceOffice_cmb.TabIndex = 69
        '
        'SalesOffice_lbl
        '
        Me.SalesOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SalesOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SalesOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SalesOffice_lbl.Location = New System.Drawing.Point(5, 180)
        Me.SalesOffice_lbl.Name = "SalesOffice_lbl"
        Me.SalesOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SalesOffice_lbl.Size = New System.Drawing.Size(100, 13)
        Me.SalesOffice_lbl.TabIndex = 77
        Me.SalesOffice_lbl.Text = "Sales Office"
        Me.SalesOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InstallingOffice_lbl
        '
        Me.InstallingOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.InstallingOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.InstallingOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallingOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.InstallingOffice_lbl.Location = New System.Drawing.Point(467, 150)
        Me.InstallingOffice_lbl.Name = "InstallingOffice_lbl"
        Me.InstallingOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InstallingOffice_lbl.Size = New System.Drawing.Size(100, 13)
        Me.InstallingOffice_lbl.TabIndex = 78
        Me.InstallingOffice_lbl.Text = "Installing Office"
        Me.InstallingOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SalesOffice_lst
        '
        Me.SalesOffice_lst.BackColor = System.Drawing.SystemColors.Window
        Me.SalesOffice_lst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SalesOffice_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesOffice_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SalesOffice_lst.Location = New System.Drawing.Point(115, 178)
        Me.SalesOffice_lst.Name = "SalesOffice_lst"
        Me.SalesOffice_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SalesOffice_lst.Size = New System.Drawing.Size(80, 21)
        Me.SalesOffice_lst.TabIndex = 71
        '
        'ServiceOffice_lbl
        '
        Me.ServiceOffice_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ServiceOffice_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ServiceOffice_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServiceOffice_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ServiceOffice_lbl.Location = New System.Drawing.Point(477, 174)
        Me.ServiceOffice_lbl.Name = "ServiceOffice_lbl"
        Me.ServiceOffice_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServiceOffice_lbl.Size = New System.Drawing.Size(91, 13)
        Me.ServiceOffice_lbl.TabIndex = 82
        Me.ServiceOffice_lbl.Text = "Service Office"
        Me.ServiceOffice_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ProbabilityOfSale_lst
        '
        Me.ProbabilityOfSale_lst.BackColor = System.Drawing.SystemColors.Window
        Me.ProbabilityOfSale_lst.Enabled = False
        Me.ProbabilityOfSale_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbabilityOfSale_lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ProbabilityOfSale_lst.Location = New System.Drawing.Point(1076, 181)
        Me.ProbabilityOfSale_lst.Name = "ProbabilityOfSale_lst"
        Me.ProbabilityOfSale_lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProbabilityOfSale_lst.Size = New System.Drawing.Size(153, 21)
        Me.ProbabilityOfSale_lst.TabIndex = 74
        Me.ProbabilityOfSale_lst.Text = "ProbabilityOfSale_lst"
        '
        'ProbabilityOfSale_lbl
        '
        Me.ProbabilityOfSale_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.ProbabilityOfSale_lbl.Enabled = False
        Me.ProbabilityOfSale_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ProbabilityOfSale_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbabilityOfSale_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProbabilityOfSale_lbl.Location = New System.Drawing.Point(958, 183)
        Me.ProbabilityOfSale_lbl.Name = "ProbabilityOfSale_lbl"
        Me.ProbabilityOfSale_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProbabilityOfSale_lbl.Size = New System.Drawing.Size(105, 17)
        Me.ProbabilityOfSale_lbl.TabIndex = 80
        Me.ProbabilityOfSale_lbl.Text = "Probability of Sale"
        Me.ProbabilityOfSale_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Forms_btn_0
        '
        Me._Forms_btn_0.BackColor = System.Drawing.SystemColors.Control
        Me._Forms_btn_0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._Forms_btn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Forms_btn_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Forms_btn_0.Location = New System.Drawing.Point(120, 122)
        Me._Forms_btn_0.Name = "_Forms_btn_0"
        Me._Forms_btn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Forms_btn_0.Size = New System.Drawing.Size(162, 25)
        Me._Forms_btn_0.TabIndex = 6
        Me._Forms_btn_0.Text = "&Address"
        Me._Forms_btn_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._Forms_btn_0.UseVisualStyleBackColor = False
        '
        'JobAddress2_txt
        '
        Me.JobAddress2_txt.AcceptsReturn = True
        Me.JobAddress2_txt.BackColor = System.Drawing.SystemColors.Window
        Me.JobAddress2_txt.Enabled = False
        Me.JobAddress2_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobAddress2_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.JobAddress2_txt.Location = New System.Drawing.Point(121, 62)
        Me.JobAddress2_txt.MaxLength = 42
        Me.JobAddress2_txt.Name = "JobAddress2_txt"
        Me.JobAddress2_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.JobAddress2_txt.Size = New System.Drawing.Size(336, 20)
        Me.JobAddress2_txt.TabIndex = 2
        '
        'JobCity_txt
        '
        Me.JobCity_txt.AcceptsReturn = True
        Me.JobCity_txt.BackColor = System.Drawing.SystemColors.Window
        Me.JobCity_txt.Enabled = False
        Me.JobCity_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobCity_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.JobCity_txt.Location = New System.Drawing.Point(121, 82)
        Me.JobCity_txt.MaxLength = 42
        Me.JobCity_txt.Name = "JobCity_txt"
        Me.JobCity_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.JobCity_txt.Size = New System.Drawing.Size(148, 20)
        Me.JobCity_txt.TabIndex = 3
        Me.JobCity_txt.Text = "Starling City"
        '
        'JobAddress_txt
        '
        Me.JobAddress_txt.AcceptsReturn = True
        Me.JobAddress_txt.BackColor = System.Drawing.SystemColors.Window
        Me.JobAddress_txt.Enabled = False
        Me.JobAddress_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobAddress_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.JobAddress_txt.Location = New System.Drawing.Point(121, 38)
        Me.JobAddress_txt.MaxLength = 42
        Me.JobAddress_txt.Name = "JobAddress_txt"
        Me.JobAddress_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.JobAddress_txt.Size = New System.Drawing.Size(336, 20)
        Me.JobAddress_txt.TabIndex = 1
        Me.JobAddress_txt.Text = "456 Main Street"
        '
        'JobName_txt
        '
        Me.JobName_txt.AcceptsReturn = True
        Me.JobName_txt.BackColor = System.Drawing.SystemColors.Window
        Me.JobName_txt.Enabled = False
        Me.JobName_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobName_txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.JobName_txt.Location = New System.Drawing.Point(121, 16)
        Me.JobName_txt.MaxLength = 0
        Me.JobName_txt.Name = "JobName_txt"
        Me.JobName_txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.JobName_txt.Size = New System.Drawing.Size(336, 20)
        Me.JobName_txt.TabIndex = 0
        Me.JobName_txt.Text = "Queen Tower"
        '
        'JobState_txt
        '
        Me.JobState_txt.AllowPromptAsInput = False
        Me.JobState_txt.Enabled = False
        Me.JobState_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobState_txt.Location = New System.Drawing.Point(315, 82)
        Me.JobState_txt.Mask = ">AA"
        Me.JobState_txt.Name = "JobState_txt"
        Me.JobState_txt.Size = New System.Drawing.Size(23, 20)
        Me.JobState_txt.TabIndex = 4
        Me.JobState_txt.Text = "AA"
        Me.JobState_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'JobZip_txt
        '
        Me.JobZip_txt.AllowPromptAsInput = False
        Me.JobZip_txt.Enabled = False
        Me.JobZip_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobZip_txt.Location = New System.Drawing.Point(381, 82)
        Me.JobZip_txt.Mask = "00000-9999"
        Me.JobZip_txt.Name = "JobZip_txt"
        Me.JobZip_txt.Size = New System.Drawing.Size(76, 20)
        Me.JobZip_txt.TabIndex = 5
        Me.JobZip_txt.Text = "000000000"
        Me.JobZip_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        '_label_14
        '
        Me._label_14.BackColor = System.Drawing.SystemColors.Window
        Me._label_14.Enabled = False
        Me._label_14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_14.Location = New System.Drawing.Point(345, 86)
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
        Me._label_12.Location = New System.Drawing.Point(268, 86)
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
        Me._label_10.Location = New System.Drawing.Point(9, 86)
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
        'Menu_pic
        '
        Me.Menu_pic.BackColor = System.Drawing.SystemColors.Control
        Me.Menu_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_2)
        Me.Menu_pic.Controls.Add(Me.EstimateNum_txt)
        Me.Menu_pic.Controls.Add(Me.Estimator_txt)
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_0)
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_1)
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_3)
        Me.Menu_pic.Controls.Add(Me._Menu_tlb_4)
        Me.Menu_pic.Controls.Add(Me._label_0)
        Me.Menu_pic.Controls.Add(Me._label_4)
        Me.Menu_pic.Dock = System.Windows.Forms.DockStyle.Top
        Me.Menu_pic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_pic.Location = New System.Drawing.Point(0, 0)
        Me.Menu_pic.Name = "Menu_pic"
        Me.Menu_pic.Size = New System.Drawing.Size(1452, 57)
        Me.Menu_pic.TabIndex = 37
        Me.Menu_pic.TabStop = False
        '
        '_Menu_tlb_2
        '
        Me._Menu_tlb_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Menu_tlb_2.Image = CType(resources.GetObject("_Menu_tlb_2.Image"), System.Drawing.Image)
        Me._Menu_tlb_2.Location = New System.Drawing.Point(112, 1)
        Me._Menu_tlb_2.Name = "_Menu_tlb_2"
        Me._Menu_tlb_2.Size = New System.Drawing.Size(46, 46)
        Me._Menu_tlb_2.TabIndex = 35
        Me._Menu_tlb_2.TabStop = False
        Me._Menu_tlb_2.Tag = "Copy Equipment"
        Me._Menu_tlb_2.Text = "Copy"
        Me._Menu_tlb_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'EstimateNum_txt
        '
        Me.EstimateNum_txt.AllowPromptAsInput = False
        Me.EstimateNum_txt.Enabled = False
        Me.EstimateNum_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateNum_txt.Location = New System.Drawing.Point(644, 8)
        Me.EstimateNum_txt.Name = "EstimateNum_txt"
        Me.EstimateNum_txt.Size = New System.Drawing.Size(137, 20)
        Me.EstimateNum_txt.TabIndex = 6
        Me.EstimateNum_txt.Text = "ZZZZ-00000"
        Me.EstimateNum_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Estimator_txt
        '
        Me.Estimator_txt.AllowPromptAsInput = False
        Me.Estimator_txt.Enabled = False
        Me.Estimator_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estimator_txt.Location = New System.Drawing.Point(643, 30)
        Me.Estimator_txt.Name = "Estimator_txt"
        Me.Estimator_txt.Size = New System.Drawing.Size(137, 20)
        Me.Estimator_txt.TabIndex = 7
        Me.Estimator_txt.Text = "Chuck Finley"
        Me.Estimator_txt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        '_Menu_tlb_0
        '
        Me._Menu_tlb_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Menu_tlb_0.Image = CType(resources.GetObject("_Menu_tlb_0.Image"), System.Drawing.Image)
        Me._Menu_tlb_0.Location = New System.Drawing.Point(8, 1)
        Me._Menu_tlb_0.Name = "_Menu_tlb_0"
        Me._Menu_tlb_0.Size = New System.Drawing.Size(46, 46)
        Me._Menu_tlb_0.TabIndex = 33
        Me._Menu_tlb_0.TabStop = False
        Me._Menu_tlb_0.Tag = "Exit System"
        Me._Menu_tlb_0.Text = "Exit"
        Me._Menu_tlb_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Menu_tlb_1
        '
        Me._Menu_tlb_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Menu_tlb_1.Image = CType(resources.GetObject("_Menu_tlb_1.Image"), System.Drawing.Image)
        Me._Menu_tlb_1.Location = New System.Drawing.Point(60, 1)
        Me._Menu_tlb_1.Name = "_Menu_tlb_1"
        Me._Menu_tlb_1.Size = New System.Drawing.Size(46, 46)
        Me._Menu_tlb_1.TabIndex = 34
        Me._Menu_tlb_1.TabStop = False
        Me._Menu_tlb_1.Tag = "Save Data"
        Me._Menu_tlb_1.Text = "Save"
        Me._Menu_tlb_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        '_Menu_tlb_4
        '
        Me._Menu_tlb_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Menu_tlb_4.Image = CType(resources.GetObject("_Menu_tlb_4.Image"), System.Drawing.Image)
        Me._Menu_tlb_4.Location = New System.Drawing.Point(300, 1)
        Me._Menu_tlb_4.Name = "_Menu_tlb_4"
        Me._Menu_tlb_4.Size = New System.Drawing.Size(46, 46)
        Me._Menu_tlb_4.TabIndex = 37
        Me._Menu_tlb_4.TabStop = False
        Me._Menu_tlb_4.Tag = "Help"
        Me._Menu_tlb_4.Text = "Help"
        Me._Menu_tlb_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_label_0
        '
        Me._label_0.AutoSize = True
        Me._label_0.BackColor = System.Drawing.SystemColors.Control
        Me._label_0.Enabled = False
        Me._label_0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._label_0.Location = New System.Drawing.Point(581, 32)
        Me._label_0.Name = "_label_0"
        Me._label_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_0.Size = New System.Drawing.Size(63, 13)
        Me._label_0.TabIndex = 66
        Me._label_0.Text = "Estimator "
        Me._label_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_label_4
        '
        Me._label_4.BackColor = System.Drawing.SystemColors.Control
        Me._label_4.Enabled = False
        Me._label_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._label_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._label_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._label_4.Location = New System.Drawing.Point(577, 11)
        Me._label_4.Name = "_label_4"
        Me._label_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._label_4.Size = New System.Drawing.Size(67, 13)
        Me._label_4.TabIndex = 62
        Me._label_4.Text = "Estimate # "
        Me._label_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'StatusBar1
        '
        Me.StatusBar1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._StatusBar1_Panel1, Me._StatusBar1_Panel2, Me._StatusBar1_Panel3, Me._StatusBar1_Panel4})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 773)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.ShowItemToolTips = True
        Me.StatusBar1.Size = New System.Drawing.Size(1452, 22)
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
        Me.FpSpread1.Location = New System.Drawing.Point(8, 61)
        Me.FpSpread1.Name = "FpSpread1"
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView1})
        Me.FpSpread1.Size = New System.Drawing.Size(1435, 413)
        Me.FpSpread1.TabIndex = 11
        '
        'Equipment_fra
        '
        Me.Equipment_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Equipment_fra.BackColor = System.Drawing.SystemColors.Window
        Me.Equipment_fra.Controls.Add(Me.btnPrint)
        Me.Equipment_fra.Controls.Add(Me.Button3)
        Me.Equipment_fra.Controls.Add(Me.btnDeleteMaster)
        Me.Equipment_fra.Controls.Add(Me.btnDeleteAlt)
        Me.Equipment_fra.Controls.Add(Me.Button2)
        Me.Equipment_fra.Controls.Add(Me.btnDeleteBank)
        Me.Equipment_fra.Controls.Add(Me.btnForms)
        Me.Equipment_fra.Controls.Add(Me.btnAddBank)
        Me.Equipment_fra.Controls.Add(Me._Forms_btn_2)
        Me.Equipment_fra.Controls.Add(Me.btnAddAlt)
        Me.Equipment_fra.Controls.Add(Me.btnMerge)
        Me.Equipment_fra.Controls.Add(Me.FpSpread1)
        Me.Equipment_fra.Controls.Add(Me._JobHighRiskFactor_lbl_1)
        Me.Equipment_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Equipment_fra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Equipment_fra.Location = New System.Drawing.Point(0, 290)
        Me.Equipment_fra.Name = "Equipment_fra"
        Me.Equipment_fra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Equipment_fra.Size = New System.Drawing.Size(1452, 480)
        Me.Equipment_fra.TabIndex = 43
        Me.Equipment_fra.TabStop = False
        Me.Equipment_fra.Text = "Equipment "
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.Location = New System.Drawing.Point(869, 24)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(77, 22)
        Me.btnPrint.TabIndex = 79
        Me.btnPrint.Text = "Print to PDF"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.Location = New System.Drawing.Point(979, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 22)
        Me.Button3.TabIndex = 74
        Me.Button3.Text = "Collapse All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnDeleteMaster
        '
        Me.btnDeleteMaster.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeleteMaster.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteMaster.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteMaster.Location = New System.Drawing.Point(605, 35)
        Me.btnDeleteMaster.Name = "btnDeleteMaster"
        Me.btnDeleteMaster.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteMaster.Size = New System.Drawing.Size(77, 22)
        Me.btnDeleteMaster.TabIndex = 77
        Me.btnDeleteMaster.Text = "Del Master"
        Me.btnDeleteMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeleteMaster.UseVisualStyleBackColor = False
        '
        'btnDeleteAlt
        '
        Me.btnDeleteAlt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeleteAlt.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteAlt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAlt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteAlt.Location = New System.Drawing.Point(517, 35)
        Me.btnDeleteAlt.Name = "btnDeleteAlt"
        Me.btnDeleteAlt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteAlt.Size = New System.Drawing.Size(77, 22)
        Me.btnDeleteAlt.TabIndex = 78
        Me.btnDeleteAlt.Text = "Del Alt "
        Me.btnDeleteAlt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeleteAlt.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(284, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 22)
        Me.Button2.TabIndex = 73
        Me.Button2.Text = "Expand All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnDeleteBank
        '
        Me.btnDeleteBank.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeleteBank.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteBank.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteBank.Location = New System.Drawing.Point(425, 35)
        Me.btnDeleteBank.Name = "btnDeleteBank"
        Me.btnDeleteBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteBank.Size = New System.Drawing.Size(77, 22)
        Me.btnDeleteBank.TabIndex = 26
        Me.btnDeleteBank.Text = "Del Bank "
        Me.btnDeleteBank.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeleteBank.UseVisualStyleBackColor = False
        '
        'btnForms
        '
        Me.btnForms.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnForms.BackColor = System.Drawing.SystemColors.Control
        Me.btnForms.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnForms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnForms.Location = New System.Drawing.Point(694, 24)
        Me.btnForms.Name = "btnForms"
        Me.btnForms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnForms.Size = New System.Drawing.Size(77, 22)
        Me.btnForms.TabIndex = 27
        Me.btnForms.Text = "&Forms"
        Me.btnForms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnForms.UseVisualStyleBackColor = False
        '
        'btnAddBank
        '
        Me.btnAddBank.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAddBank.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddBank.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddBank.Location = New System.Drawing.Point(425, 11)
        Me.btnAddBank.Name = "btnAddBank"
        Me.btnAddBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAddBank.Size = New System.Drawing.Size(77, 22)
        Me.btnAddBank.TabIndex = 25
        Me.btnAddBank.Text = "Add Bank"
        Me.btnAddBank.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAddBank.UseVisualStyleBackColor = False
        '
        '_Forms_btn_2
        '
        Me._Forms_btn_2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._Forms_btn_2.BackColor = System.Drawing.SystemColors.Control
        Me._Forms_btn_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me._Forms_btn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Forms_btn_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Forms_btn_2.Location = New System.Drawing.Point(783, 24)
        Me._Forms_btn_2.Name = "_Forms_btn_2"
        Me._Forms_btn_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Forms_btn_2.Size = New System.Drawing.Size(77, 22)
        Me._Forms_btn_2.TabIndex = 28
        Me._Forms_btn_2.Text = "E&stimate"
        Me._Forms_btn_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._Forms_btn_2.UseVisualStyleBackColor = False
        '
        'btnAddAlt
        '
        Me.btnAddAlt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAddAlt.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddAlt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAlt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddAlt.Location = New System.Drawing.Point(517, 11)
        Me.btnAddAlt.Name = "btnAddAlt"
        Me.btnAddAlt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAddAlt.Size = New System.Drawing.Size(77, 22)
        Me.btnAddAlt.TabIndex = 29
        Me.btnAddAlt.Text = "Add Alt"
        Me.btnAddAlt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAddAlt.UseVisualStyleBackColor = False
        '
        'btnMerge
        '
        Me.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMerge.BackColor = System.Drawing.SystemColors.Control
        Me.btnMerge.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMerge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMerge.Location = New System.Drawing.Point(605, 11)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMerge.Size = New System.Drawing.Size(77, 22)
        Me.btnMerge.TabIndex = 72
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMerge.UseVisualStyleBackColor = False
        '
        'txtBidDate
        '
        Me.txtBidDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBidDate.Location = New System.Drawing.Point(1020, 200)
        Me.txtBidDate.Name = "txtBidDate"
        Me.txtBidDate.Size = New System.Drawing.Size(86, 20)
        Me.txtBidDate.TabIndex = 85
        '
        'CM_MAIN_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1452, 795)
        Me.Controls.Add(Me.BuildingInformation_fra)
        Me.Controls.Add(Me.Equipment_fra)
        Me.Controls.Add(Me.Menu_pic)
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
        CType(Me.Menu_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu_pic.ResumeLayout(False)
        Me.Menu_pic.PerformLayout()
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Equipment_fra.ResumeLayout(False)
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
        Me.Menu_tlb(2) = _Menu_tlb_2
        Me.Menu_tlb(0) = _Menu_tlb_0
        Me.Menu_tlb(1) = _Menu_tlb_1
        Me.Menu_tlb(3) = _Menu_tlb_3
        Me.Menu_tlb(4) = _Menu_tlb_4
    End Sub

    Sub InitializeForms_btn()
        ReDim Forms_btn(2)
        Me.Forms_btn(0) = _Forms_btn_0
        Me.Forms_btn(1) = btnForms
        Me.Forms_btn(2) = _Forms_btn_2
    End Sub
    Sub InitializeAction_btn()

    End Sub
    Friend WithEvents CurrentTime_tim As System.Windows.Forms.Timer
    Friend WithEvents Proposal_cmd As System.Windows.Forms.Button
    Public WithEvents Status_cmb As System.Windows.Forms.ComboBox
    Public WithEvents Consultant_chk As System.Windows.Forms.CheckBox
    Private WithEvents _label_7 As System.Windows.Forms.Label
    Public WithEvents MajorProject_chk As System.Windows.Forms.CheckBox
    Public WithEvents Status_lbl As System.Windows.Forms.Label
    Public WithEvents SalesRep_lst As System.Windows.Forms.ComboBox
    Public WithEvents InstallingOffice_cmb As System.Windows.Forms.ComboBox
    Public WithEvents ServiceOffice_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SalesOffice_lbl As System.Windows.Forms.Label
    Public WithEvents InstallingOffice_lbl As System.Windows.Forms.Label
    Public WithEvents SalesOffice_lst As System.Windows.Forms.ComboBox
    Public WithEvents ServiceOffice_lbl As System.Windows.Forms.Label
    Public WithEvents ProbabilityOfSale_lst As System.Windows.Forms.ComboBox
    Public WithEvents ProbabilityOfSale_lbl As System.Windows.Forms.Label
    Private WithEvents _JobHighRiskFactor_lbl_1 As System.Windows.Forms.Label
    Friend WithEvents SheetView1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Public WithEvents Equipment_fra As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents btnDeleteMaster As System.Windows.Forms.Button
    Private WithEvents btnDeleteAlt As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents btnDeleteBank As System.Windows.Forms.Button
    Private WithEvents btnForms As System.Windows.Forms.Button
    Private WithEvents btnAddBank As System.Windows.Forms.Button
    Private WithEvents _Forms_btn_2 As System.Windows.Forms.Button
    Private WithEvents btnAddAlt As System.Windows.Forms.Button
    Private WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents BuildingType_cmb As System.Windows.Forms.ComboBox
    Public WithEvents BuildingType_lbl As System.Windows.Forms.Label
    Friend WithEvents txtBidDate As System.Windows.Forms.TextBox
#End Region
End Class