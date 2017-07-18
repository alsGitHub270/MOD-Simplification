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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BillofMaterialsandTaskList_fra = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.SheetView1 = New FarPoint.Win.Spread.SheetView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GeneralInformation_fra = New System.Windows.Forms.GroupBox()
        Me.TotalNumberOfFloors_cmb = New System.Windows.Forms.ComboBox()
        Me.TotalNumberOfFloors_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsTotal_cmb = New System.Windows.Forms.ComboBox()
        Me.NumberofStopsTotal_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsFront_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsRear_lbl = New System.Windows.Forms.Label()
        Me.NumberofLandingsTotal_lbl = New System.Windows.Forms.Label()
        Me.NumberofStopsFront_cmb = New System.Windows.Forms.ComboBox()
        Me.NumberofLandingsTotal_Cmb = New System.Windows.Forms.ComboBox()
        Me.NumberofStopsRear_cmb = New System.Windows.Forms.ComboBox()
        Me.SpeedNew_cmb = New System.Windows.Forms.ComboBox()
        Me.CapacityNew_cmb = New System.Windows.Forms.ComboBox()
        Me.SpeedLabel_lbl = New System.Windows.Forms.Label()
        Me.CapacityLabel_lbl = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.GroupBox1.SuspendLayout()
        Me.BillofMaterialsandTaskList_fra.SuspendLayout()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GeneralInformation_fra.SuspendLayout()
        Me.TabControl1.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.BillofMaterialsandTaskList_fra)
        Me.GroupBox1.Controls.Add(Me.GeneralInformation_fra)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1219, 690)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'BillofMaterialsandTaskList_fra
        '
        Me.BillofMaterialsandTaskList_fra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.Button2)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.FpSpread1)
        Me.BillofMaterialsandTaskList_fra.Controls.Add(Me.Button3)
        Me.BillofMaterialsandTaskList_fra.Location = New System.Drawing.Point(16, 250)
        Me.BillofMaterialsandTaskList_fra.Name = "BillofMaterialsandTaskList_fra"
        Me.BillofMaterialsandTaskList_fra.Size = New System.Drawing.Size(1184, 424)
        Me.BillofMaterialsandTaskList_fra.TabIndex = 80
        Me.BillofMaterialsandTaskList_fra.TabStop = False
        Me.BillofMaterialsandTaskList_fra.Text = "Bill of Materials and Task List"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(405, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 23)
        Me.Button2.TabIndex = 81
        Me.Button2.Text = "Expand All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FpSpread1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1.Location = New System.Drawing.Point(6, 43)
        Me.FpSpread1.Name = "FpSpread1"
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SheetView1})
        Me.FpSpread1.Size = New System.Drawing.Size(1174, 342)
        Me.FpSpread1.TabIndex = 80
        '
        'SheetView1
        '
        Me.SheetView1.Reset()
        Me.SheetView1.SheetName = "Sheet1"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.Location = New System.Drawing.Point(662, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 23)
        Me.Button3.TabIndex = 82
        Me.Button3.Text = "Collapse All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GeneralInformation_fra
        '
        Me.GeneralInformation_fra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GeneralInformation_fra.Controls.Add(Me.TotalNumberOfFloors_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.TotalNumberOfFloors_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsTotal_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsTotal_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsFront_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsRear_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofLandingsTotal_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsFront_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofLandingsTotal_Cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.NumberofStopsRear_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedNew_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityNew_cmb)
        Me.GeneralInformation_fra.Controls.Add(Me.SpeedLabel_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.CapacityLabel_lbl)
        Me.GeneralInformation_fra.Controls.Add(Me.Button1)
        Me.GeneralInformation_fra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralInformation_fra.Location = New System.Drawing.Point(16, 53)
        Me.GeneralInformation_fra.Name = "GeneralInformation_fra"
        Me.GeneralInformation_fra.Size = New System.Drawing.Size(1184, 196)
        Me.GeneralInformation_fra.TabIndex = 25
        Me.GeneralInformation_fra.TabStop = False
        Me.GeneralInformation_fra.Text = "   General Information"
        '
        'TotalNumberOfFloors_cmb
        '
        Me.TotalNumberOfFloors_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.TotalNumberOfFloors_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.TotalNumberOfFloors_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalNumberOfFloors_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalNumberOfFloors_cmb.Location = New System.Drawing.Point(163, 174)
        Me.TotalNumberOfFloors_cmb.Name = "TotalNumberOfFloors_cmb"
        Me.TotalNumberOfFloors_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TotalNumberOfFloors_cmb.Size = New System.Drawing.Size(134, 21)
        Me.TotalNumberOfFloors_cmb.TabIndex = 47
        '
        'TotalNumberOfFloors_lbl
        '
        Me.TotalNumberOfFloors_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.TotalNumberOfFloors_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TotalNumberOfFloors_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TotalNumberOfFloors_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalNumberOfFloors_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalNumberOfFloors_lbl.Location = New System.Drawing.Point(6, 176)
        Me.TotalNumberOfFloors_lbl.Name = "TotalNumberOfFloors_lbl"
        Me.TotalNumberOfFloors_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TotalNumberOfFloors_lbl.Size = New System.Drawing.Size(161, 17)
        Me.TotalNumberOfFloors_lbl.TabIndex = 48
        Me.TotalNumberOfFloors_lbl.Text = "Total Number of Floors *"
        '
        'NumberofStopsTotal_cmb
        '
        Me.NumberofStopsTotal_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotal_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotal_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotal_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsTotal_cmb.Location = New System.Drawing.Point(158, 98)
        Me.NumberofStopsTotal_cmb.Name = "NumberofStopsTotal_cmb"
        Me.NumberofStopsTotal_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotal_cmb.Size = New System.Drawing.Size(134, 21)
        Me.NumberofStopsTotal_cmb.TabIndex = 32
        '
        'NumberofStopsTotal_lbl
        '
        Me.NumberofStopsTotal_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsTotal_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsTotal_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofStopsTotal_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsTotal_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsTotal_lbl.Location = New System.Drawing.Point(6, 101)
        Me.NumberofStopsTotal_lbl.Name = "NumberofStopsTotal_lbl"
        Me.NumberofStopsTotal_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsTotal_lbl.Size = New System.Drawing.Size(117, 17)
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
        Me.NumberofStopsFront_lbl.Location = New System.Drawing.Point(6, 127)
        Me.NumberofStopsFront_lbl.Name = "NumberofStopsFront_lbl"
        Me.NumberofStopsFront_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFront_lbl.Size = New System.Drawing.Size(155, 17)
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
        Me.NumberofStopsRear_lbl.Location = New System.Drawing.Point(6, 154)
        Me.NumberofStopsRear_lbl.Name = "NumberofStopsRear_lbl"
        Me.NumberofStopsRear_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRear_lbl.Size = New System.Drawing.Size(155, 17)
        Me.NumberofStopsRear_lbl.TabIndex = 37
        Me.NumberofStopsRear_lbl.Text = "Qty of Rear Openings "
        '
        'NumberofLandingsTotal_lbl
        '
        Me.NumberofLandingsTotal_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofLandingsTotal_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofLandingsTotal_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NumberofLandingsTotal_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofLandingsTotal_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofLandingsTotal_lbl.Location = New System.Drawing.Point(6, 74)
        Me.NumberofLandingsTotal_lbl.Name = "NumberofLandingsTotal_lbl"
        Me.NumberofLandingsTotal_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofLandingsTotal_lbl.Size = New System.Drawing.Size(127, 17)
        Me.NumberofLandingsTotal_lbl.TabIndex = 38
        Me.NumberofLandingsTotal_lbl.Text = "Qty of Total Landings"
        '
        'NumberofStopsFront_cmb
        '
        Me.NumberofStopsFront_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsFront_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsFront_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsFront_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsFront_cmb.Location = New System.Drawing.Point(158, 124)
        Me.NumberofStopsFront_cmb.Name = "NumberofStopsFront_cmb"
        Me.NumberofStopsFront_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsFront_cmb.Size = New System.Drawing.Size(134, 21)
        Me.NumberofStopsFront_cmb.TabIndex = 33
        '
        'NumberofLandingsTotal_Cmb
        '
        Me.NumberofLandingsTotal_Cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofLandingsTotal_Cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofLandingsTotal_Cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofLandingsTotal_Cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofLandingsTotal_Cmb.Location = New System.Drawing.Point(158, 71)
        Me.NumberofLandingsTotal_Cmb.Name = "NumberofLandingsTotal_Cmb"
        Me.NumberofLandingsTotal_Cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofLandingsTotal_Cmb.Size = New System.Drawing.Size(134, 21)
        Me.NumberofLandingsTotal_Cmb.TabIndex = 31
        '
        'NumberofStopsRear_cmb
        '
        Me.NumberofStopsRear_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.NumberofStopsRear_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumberofStopsRear_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberofStopsRear_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberofStopsRear_cmb.Location = New System.Drawing.Point(158, 151)
        Me.NumberofStopsRear_cmb.Name = "NumberofStopsRear_cmb"
        Me.NumberofStopsRear_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumberofStopsRear_cmb.Size = New System.Drawing.Size(134, 21)
        Me.NumberofStopsRear_cmb.TabIndex = 34
        '
        'SpeedNew_cmb
        '
        Me.SpeedNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedNew_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpeedNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedNew_cmb.Location = New System.Drawing.Point(158, 44)
        Me.SpeedNew_cmb.Name = "SpeedNew_cmb"
        Me.SpeedNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedNew_cmb.Size = New System.Drawing.Size(134, 21)
        Me.SpeedNew_cmb.TabIndex = 24
        '
        'CapacityNew_cmb
        '
        Me.CapacityNew_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityNew_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityNew_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityNew_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityNew_cmb.Location = New System.Drawing.Point(158, 18)
        Me.CapacityNew_cmb.Name = "CapacityNew_cmb"
        Me.CapacityNew_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityNew_cmb.Size = New System.Drawing.Size(134, 21)
        Me.CapacityNew_cmb.TabIndex = 23
        '
        'SpeedLabel_lbl
        '
        Me.SpeedLabel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.SpeedLabel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpeedLabel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SpeedLabel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedLabel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SpeedLabel_lbl.Location = New System.Drawing.Point(6, 47)
        Me.SpeedLabel_lbl.Name = "SpeedLabel_lbl"
        Me.SpeedLabel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SpeedLabel_lbl.Size = New System.Drawing.Size(45, 17)
        Me.SpeedLabel_lbl.TabIndex = 26
        Me.SpeedLabel_lbl.Text = "Speed :"
        '
        'CapacityLabel_lbl
        '
        Me.CapacityLabel_lbl.BackColor = System.Drawing.SystemColors.Window
        Me.CapacityLabel_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CapacityLabel_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CapacityLabel_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityLabel_lbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CapacityLabel_lbl.Location = New System.Drawing.Point(6, 21)
        Me.CapacityLabel_lbl.Name = "CapacityLabel_lbl"
        Me.CapacityLabel_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CapacityLabel_lbl.Size = New System.Drawing.Size(59, 17)
        Me.CapacityLabel_lbl.TabIndex = 25
        Me.CapacityLabel_lbl.Text = "Capacity :"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1, -1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 19)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 21)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1207, 663)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1199, 634)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Car(s) 01-03"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1199, 634)
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
        Me.MDI_pic.Size = New System.Drawing.Size(1219, 99)
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
        Me.fraHdrJobInfo.Size = New System.Drawing.Size(1215, 30)
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
        Me.fraHdrIcons.Size = New System.Drawing.Size(1215, 60)
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
        'frmEstimatingBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1219, 795)
        Me.Controls.Add(Me.MDI_pic)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstimatingBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOD Estimating"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.BillofMaterialsandTaskList_fra.ResumeLayout(False)
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GeneralInformation_fra.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
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
    Friend WithEvents GeneralInformation_fra As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BillofMaterialsandTaskList_fra As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SheetView1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents TotalNumberOfFloors_cmb As System.Windows.Forms.ComboBox
    Public WithEvents TotalNumberOfFloors_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsTotal_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NumberofStopsTotal_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFront_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsRear_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofLandingsTotal_lbl As System.Windows.Forms.Label
    Public WithEvents NumberofStopsFront_cmb As System.Windows.Forms.ComboBox
    Public WithEvents NumberofLandingsTotal_Cmb As System.Windows.Forms.ComboBox
    Public WithEvents NumberofStopsRear_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SpeedNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents CapacityNew_cmb As System.Windows.Forms.ComboBox
    Public WithEvents SpeedLabel_lbl As System.Windows.Forms.Label
    Public WithEvents CapacityLabel_lbl As System.Windows.Forms.Label

#End Region
End Class
