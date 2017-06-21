Partial Class frmEstimatingBase
#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

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
        Dim ComboBoxCellType1 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType2 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Dim ComboBoxCellType3 As FarPoint.Win.Spread.CellType.ComboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.SheetView1 = New FarPoint.Win.Spread.SheetView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        Me._IconButton_cmd_22 = New System.Windows.Forms.Button()
        Me.FreezeSave_btn = New System.Windows.Forms.Button()
        Me._IconButton_cmd_0 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_1 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_6 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_10 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_11 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_15 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_16 = New System.Windows.Forms.Button()
        Me._IconButton_cmd_21 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FpSpread4 = New FarPoint.Win.Spread.FpSpread()
        Me.SheetView3 = New FarPoint.Win.Spread.SheetView()
        Me.FpSpread3 = New FarPoint.Win.Spread.FpSpread()
        Me.SheetView2 = New FarPoint.Win.Spread.SheetView()
        Me.FpSpread2 = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread2_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        CType(Me.MDI_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MDI_pic.SuspendLayout()
        Me.fraHdrJobInfo.SuspendLayout()
        Me.fraHdrIcons.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FpSpread4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SheetView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SheetView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread2_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.FpSpread1)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 295)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1129, 518)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bill of Materials and Task List"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(175, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 23)
        Me.Button2.TabIndex = 78
        Me.Button2.Text = "Expand All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(986, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 23)
        Me.Button3.TabIndex = 79
        Me.Button3.Text = "Collapse All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1.Location = New System.Drawing.Point(10, 89)
        Me.FpSpread1.Name = "FpSpread1"
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView1})
        Me.FpSpread1.Size = New System.Drawing.Size(1125, 397)
        Me.FpSpread1.TabIndex = 10
        '
        'SheetView1
        '
        Me.SheetView1.Reset()
        Me.SheetView1.SheetName = "Sheet1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 21)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1134, 475)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1126, 446)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Car(s) 01-03"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1126, 446)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Car(s) 04"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.MDI_pic.Size = New System.Drawing.Size(1129, 99)
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
        Me.fraHdrJobInfo.Size = New System.Drawing.Size(1125, 30)
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
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_22)
        Me.fraHdrIcons.Controls.Add(Me.FreezeSave_btn)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_0)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_1)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_6)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_10)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_11)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_15)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_16)
        Me.fraHdrIcons.Controls.Add(Me._IconButton_cmd_21)
        Me.fraHdrIcons.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraHdrIcons.Font = New System.Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHdrIcons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHdrIcons.Location = New System.Drawing.Point(0, 0)
        Me.fraHdrIcons.Name = "fraHdrIcons"
        Me.fraHdrIcons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHdrIcons.Size = New System.Drawing.Size(1125, 60)
        Me.fraHdrIcons.TabIndex = 24
        Me.fraHdrIcons.TabStop = False
        '
        '_IconButton_cmd_22
        '
        Me._IconButton_cmd_22.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_22.Image = CType(resources.GetObject("_IconButton_cmd_22.Image"), System.Drawing.Image)
        Me._IconButton_cmd_22.Location = New System.Drawing.Point(909, 7)
        Me._IconButton_cmd_22.Name = "_IconButton_cmd_22"
        Me._IconButton_cmd_22.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_22.TabIndex = 40
        Me._IconButton_cmd_22.TabStop = False
        Me._IconButton_cmd_22.Tag = "Supt"
        Me._IconButton_cmd_22.Text = "Supt"
        Me._IconButton_cmd_22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        '_IconButton_cmd_0
        '
        Me._IconButton_cmd_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_0.Image = CType(resources.GetObject("_IconButton_cmd_0.Image"), System.Drawing.Image)
        Me._IconButton_cmd_0.Location = New System.Drawing.Point(0, 8)
        Me._IconButton_cmd_0.Name = "_IconButton_cmd_0"
        Me._IconButton_cmd_0.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_0.TabIndex = 0
        Me._IconButton_cmd_0.TabStop = False
        Me._IconButton_cmd_0.Tag = "Exit System"
        Me._IconButton_cmd_0.Text = "Exit"
        Me._IconButton_cmd_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_1
        '
        Me._IconButton_cmd_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_1.Image = CType(resources.GetObject("_IconButton_cmd_1.Image"), System.Drawing.Image)
        Me._IconButton_cmd_1.Location = New System.Drawing.Point(48, 8)
        Me._IconButton_cmd_1.Name = "_IconButton_cmd_1"
        Me._IconButton_cmd_1.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_1.TabIndex = 1
        Me._IconButton_cmd_1.TabStop = False
        Me._IconButton_cmd_1.Tag = "Save Changes"
        Me._IconButton_cmd_1.Text = "Save"
        Me._IconButton_cmd_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_6
        '
        Me._IconButton_cmd_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_6.Image = CType(resources.GetObject("_IconButton_cmd_6.Image"), System.Drawing.Image)
        Me._IconButton_cmd_6.Location = New System.Drawing.Point(96, 8)
        Me._IconButton_cmd_6.Name = "_IconButton_cmd_6"
        Me._IconButton_cmd_6.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_6.TabIndex = 6
        Me._IconButton_cmd_6.Tag = "Return to Contract Manager"
        Me._IconButton_cmd_6.Text = "Main"
        Me._IconButton_cmd_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_10
        '
        Me._IconButton_cmd_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_10.Image = CType(resources.GetObject("_IconButton_cmd_10.Image"), System.Drawing.Image)
        Me._IconButton_cmd_10.Location = New System.Drawing.Point(440, 8)
        Me._IconButton_cmd_10.Name = "_IconButton_cmd_10"
        Me._IconButton_cmd_10.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_10.TabIndex = 10
        Me._IconButton_cmd_10.TabStop = False
        Me._IconButton_cmd_10.Tag = "Print Screen"
        Me._IconButton_cmd_10.Text = "Screen"
        Me._IconButton_cmd_10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_11
        '
        Me._IconButton_cmd_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_11.Image = CType(resources.GetObject("_IconButton_cmd_11.Image"), System.Drawing.Image)
        Me._IconButton_cmd_11.Location = New System.Drawing.Point(145, 8)
        Me._IconButton_cmd_11.Name = "_IconButton_cmd_11"
        Me._IconButton_cmd_11.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_11.TabIndex = 11
        Me._IconButton_cmd_11.TabStop = False
        Me._IconButton_cmd_11.Tag = "Print Forms"
        Me._IconButton_cmd_11.Text = "Forms"
        Me._IconButton_cmd_11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_15
        '
        Me._IconButton_cmd_15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_15.Image = CType(resources.GetObject("_IconButton_cmd_15.Image"), System.Drawing.Image)
        Me._IconButton_cmd_15.Location = New System.Drawing.Point(762, 8)
        Me._IconButton_cmd_15.Name = "_IconButton_cmd_15"
        Me._IconButton_cmd_15.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_15.TabIndex = 15
        Me._IconButton_cmd_15.TabStop = False
        Me._IconButton_cmd_15.Tag = "Create Booking File"
        Me._IconButton_cmd_15.Text = "Book"
        Me._IconButton_cmd_15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_16
        '
        Me._IconButton_cmd_16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_16.Image = CType(resources.GetObject("_IconButton_cmd_16.Image"), System.Drawing.Image)
        Me._IconButton_cmd_16.Location = New System.Drawing.Point(810, 8)
        Me._IconButton_cmd_16.Name = "_IconButton_cmd_16"
        Me._IconButton_cmd_16.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_16.TabIndex = 34
        Me._IconButton_cmd_16.TabStop = False
        Me._IconButton_cmd_16.Tag = "Create Config File"
        Me._IconButton_cmd_16.Text = "Config"
        Me._IconButton_cmd_16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_IconButton_cmd_21
        '
        Me._IconButton_cmd_21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._IconButton_cmd_21.Image = CType(resources.GetObject("_IconButton_cmd_21.Image"), System.Drawing.Image)
        Me._IconButton_cmd_21.Location = New System.Drawing.Point(713, 8)
        Me._IconButton_cmd_21.Name = "_IconButton_cmd_21"
        Me._IconButton_cmd_21.Size = New System.Drawing.Size(46, 46)
        Me._IconButton_cmd_21.TabIndex = 39
        Me._IconButton_cmd_21.TabStop = False
        Me._IconButton_cmd_21.Tag = "Set to Award"
        Me._IconButton_cmd_21.Text = "Award"
        Me._IconButton_cmd_21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FpSpread4)
        Me.GroupBox2.Controls.Add(Me.FpSpread3)
        Me.GroupBox2.Controls.Add(Me.FpSpread2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1129, 196)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "General Information"
        '
        'FpSpread4
        '
        Me.FpSpread4.AccessibleDescription = "FpSpread4, Sheet1, Row 0, Column 0, Power Supply"
        Me.FpSpread4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread4.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread4.Location = New System.Drawing.Point(858, 21)
        Me.FpSpread4.Name = "FpSpread4"
        Me.FpSpread4.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView3})
        Me.FpSpread4.Size = New System.Drawing.Size(276, 165)
        Me.FpSpread4.TabIndex = 2
        Me.FpSpread4.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'SheetView3
        '
        Me.SheetView3.Reset()
        Me.SheetView3.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SheetView3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SheetView3.ColumnCount = 2
        Me.SheetView3.RowCount = 2
        Me.SheetView3.Cells.Get(0, 0).Value = "Power Supply"
        Me.SheetView3.Cells.Get(1, 0).Value = "Seismic Zone"
        Me.SheetView3.ColumnHeader.Visible = False
        Me.SheetView3.Columns.Get(0).Width = 169.0!
        ComboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType1.Editable = True
        Me.SheetView3.Columns.Get(1).CellType = ComboBoxCellType1
        Me.SheetView3.Columns.Get(1).Width = 102.0!
        Me.SheetView3.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None)
        Me.SheetView3.RowHeader.Columns.Default.Resizable = False
        Me.SheetView3.RowHeader.Visible = False
        Me.SheetView3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FpSpread3
        '
        Me.FpSpread3.AccessibleDescription = "FpSpread3, Sheet1, Row 0, Column 0, Door Type"
        Me.FpSpread3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread3.Location = New System.Drawing.Point(442, 21)
        Me.FpSpread3.Name = "FpSpread3"
        Me.FpSpread3.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView2})
        Me.FpSpread3.Size = New System.Drawing.Size(276, 165)
        Me.FpSpread3.TabIndex = 1
        Me.FpSpread3.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'SheetView2
        '
        Me.SheetView2.Reset()
        Me.SheetView2.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SheetView2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SheetView2.ColumnCount = 2
        Me.SheetView2.RowCount = 8
        Me.SheetView2.Cells.Get(0, 0).Value = "Door Type"
        Me.SheetView2.Cells.Get(1, 0).Value = "Door Size"
        Me.SheetView2.Cells.Get(2, 0).Value = "Rise"
        Me.SheetView2.Cells.Get(3, 0).Value = "Fixture Finish"
        Me.SheetView2.Cells.Get(4, 0).Value = "Roping"
        Me.SheetView2.Cells.Get(5, 0).Value = "Number Of Hall Risers"
        Me.SheetView2.Cells.Get(6, 0).Value = "Type Of Drive"
        Me.SheetView2.Cells.Get(7, 0).Value = "Machine Location"
        Me.SheetView2.ColumnHeader.Visible = False
        Me.SheetView2.Columns.Get(0).Width = 169.0!
        ComboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType2.Editable = True
        Me.SheetView2.Columns.Get(1).CellType = ComboBoxCellType2
        Me.SheetView2.Columns.Get(1).Width = 102.0!
        Me.SheetView2.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None)
        Me.SheetView2.RowHeader.Columns.Default.Resizable = False
        Me.SheetView2.RowHeader.Visible = False
        Me.SheetView2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FpSpread2
        '
        Me.FpSpread2.AccessibleDescription = "FpSpread2, Sheet1, Row 0, Column 0, Speed"
        Me.FpSpread2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread2.Location = New System.Drawing.Point(12, 21)
        Me.FpSpread2.Name = "FpSpread2"
        Me.FpSpread2.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread2_Sheet1})
        Me.FpSpread2.Size = New System.Drawing.Size(276, 165)
        Me.FpSpread2.TabIndex = 0
        Me.FpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'FpSpread2_Sheet1
        '
        Me.FpSpread2_Sheet1.Reset()
        Me.FpSpread2_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread2_Sheet1.ColumnCount = 2
        Me.FpSpread2_Sheet1.RowCount = 8
        Me.FpSpread2_Sheet1.Cells.Get(0, 0).Value = "Speed"
        Me.FpSpread2_Sheet1.Cells.Get(1, 0).Value = "Capacity"
        Me.FpSpread2_Sheet1.Cells.Get(2, 0).Value = "Stops"
        Me.FpSpread2_Sheet1.Cells.Get(3, 0).Value = "Openings"
        Me.FpSpread2_Sheet1.Cells.Get(4, 0).Value = "Front"
        Me.FpSpread2_Sheet1.Cells.Get(5, 0).Value = "Rear"
        Me.FpSpread2_Sheet1.Cells.Get(6, 0).Value = "Number Of Floors"
        Me.FpSpread2_Sheet1.Cells.Get(7, 0).Value = "Machine Type"
        Me.FpSpread2_Sheet1.ColumnHeader.Visible = False
        Me.FpSpread2_Sheet1.Columns.Get(0).Width = 169.0!
        ComboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right
        ComboBoxCellType3.Editable = True
        Me.FpSpread2_Sheet1.Columns.Get(1).CellType = ComboBoxCellType3
        Me.FpSpread2_Sheet1.Columns.Get(1).Width = 102.0!
        Me.FpSpread2_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None)
        Me.FpSpread2_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread2_Sheet1.RowHeader.Visible = False
        Me.FpSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'frmEstimatingBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1146, 795)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.MDI_pic)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEstimatingBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hierarchy and alpha-blending"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        CType(Me.MDI_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MDI_pic.ResumeLayout(False)
        Me.fraHdrJobInfo.ResumeLayout(False)
        Me.fraHdrJobInfo.PerformLayout()
        Me.fraHdrIcons.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.FpSpread4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SheetView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SheetView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread2_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents _IconButton_cmd_22 As System.Windows.Forms.Button
    Public WithEvents FreezeSave_btn As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_0 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_1 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_6 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_10 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_11 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_15 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_16 As System.Windows.Forms.Button
    Private WithEvents _IconButton_cmd_21 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FpSpread2 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread2_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpread4 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SheetView3 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpread3 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SheetView2 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SheetView1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button

#End Region
End Class
