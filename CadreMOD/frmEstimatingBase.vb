Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)
    Dim myDataSet As System.Data.DataSet

    'Data Types
    Private dtStr As System.Type = System.Type.GetType("System.String")
    Private dtInt As System.Type = System.Type.GetType("System.Int32")

    Public Structure a_SheetHeaders_typ
        Dim HeaderDesc As String
        Dim HeaderType As System.Type
        Public Shared Function CreateInstance() As a_SheetHeaders_typ
            Dim result As New a_SheetHeaders_typ
            result.HeaderDesc = String.Empty
            Return result
        End Function
    End Structure
    Private SheetHeaders(,) As a_SheetHeaders_typ
    Public Const TotalMaterialColumns As Integer = 10
    Public Const MAIN_COL_MAIN_GROUP As Integer = 0
    Public Const MAIN_COL_MAIN_ID As Integer = 1
    Public Const MAT_COL_MATERIAL_DESC As Integer = 0
    Public Const MAT_COL_MAIN_ID As Integer = 1
    Public Const MAT_COL_MATERIAL_ID As Integer = 2
    Public Const MAT_COL_UNITS As Integer = 3
    Public Const MAT_COL_OPTION As Integer = 4
    Public Const MAT_COL_TYPE As Integer = 5
    Public Const MAT_COL_ORDER_BY As Integer = 6
    Public Const MAT_COL_QTY As Integer = 7
    Public Const MAT_COL_MATERIAL_COST As Integer = 8
    Public Const MAT_COL_STANDARD_HOURS As Integer = 9
    Public Const MAT_COL_SPECIAL_HOURS As Integer = 10

    Public Structure a_MainGroup_typ
        Dim MainID As String
        Dim Description As String
        Dim Units As String
        Public Shared Function CreateInstance() As a_MainGroup_typ
            Dim result As New a_MainGroup_typ
            result.MainID = String.Empty
            result.Description = String.Empty
            result.Units = String.Empty
            Return result
        End Function
    End Structure
    Public a_MainGroup() As a_MainGroup_typ

    Public Structure a_MaterialGroup_typ
        Dim Description As String
        Dim MainID As String
        Dim MaterialID As String
        Dim OptionStr() As String
        Dim Type() As String
        Dim OrderBy() As String
        Dim Qty As Integer
        Dim Units As String
        Dim MaterialCost As Single
        Dim StandardHours As Integer
        Dim SpecialHours As Integer
        Public Shared Function CreateInstance() As a_MaterialGroup_typ
            Dim result As New a_MaterialGroup_typ
            result.MainID = String.Empty
            result.MaterialID = String.Empty
            result.Description = String.Empty
            result.Units = String.Empty
            Return result
        End Function
    End Structure
    Public a_MaterialGroup() As a_MaterialGroup_typ

    Public Const MAIN_GROUP As Integer = 1
    Public Const MATERIAL_GROUP As Integer = 2
    Private CurrentGenInfoFrameHeight As Integer = 0, CurrentBillofMaterialsandTaskListFrameHeight As Integer = 0
    Private MaterialItemRecordSet As New ADODB.Recordset

    Private Sub CreateDataSet()
        Dim MainGroups As DataTable = Nothing
        Dim SubGroups As DataTable = Nothing
        Dim iIndex As Integer = -1, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing
        Dim CurMainID As String = String.Empty
        Dim Action As Integer = MOVE_FIRST
        Dim AddToMaterialGroup As Boolean = True

        DAO2ADO(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, My.Application.Info.DirectoryPath & "\", OPTION_DATABASE_NAME, True)
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, GROUP_SETUP_QRY)

        myDataSet = New DataSet()
        myDataSet.EnforceConstraints = False

        Erase SheetHeaders
        ReDim SheetHeaders(MATERIAL_GROUP, TotalMaterialColumns)

        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderDesc = "Main Group"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderDesc = "MainID"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderType = dtStr
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderType = dtStr

        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderDesc = "Material Description"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderDesc = "MainID"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderDesc = "MaterialID"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderDesc = "Units"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderDesc = "Option"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderDesc = "Type"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderDesc = "Order By"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderDesc = "Qty"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderDesc = "Material Cost"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderDesc = "Standard Hours"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderDesc = "Special Hours"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderType = dtInt

        Erase a_MainGroup
        Erase a_MaterialGroup
        Do Until Query_Execute(ADOConnectionRPTDataDB, MaterialItemRecordSet, 1, Action) <> 0
            If MaterialItemRecordSet.Fields("MainID").Value.ToString.Trim <> CurMainID Then
                CurMainID = MaterialItemRecordSet.Fields("MainID").Value.ToString.Trim
                iIndex += 1
                ReDim Preserve a_MainGroup(iIndex)
            End If
            a_MainGroup(iIndex).MainID = CurMainID
            a_MainGroup(iIndex).Description = MaterialItemRecordSet.Fields("Main Group").Value.ToString.Trim
            a_MainGroup(iIndex).Units = "01-03"
            AddToMaterialGroup = True
            If Not IsNothing(a_MaterialGroup) Then
                For kIndex = a_MaterialGroup.GetLowerBound(0) To a_MaterialGroup.GetUpperBound(0)
                    If a_MaterialGroup(kIndex).MaterialID = MaterialItemRecordSet.Fields("MaterialID").Value.ToString.Trim Then
                        AddToMaterialGroup = False
                        Exit For
                    End If
                Next kIndex
            End If
            If AddToMaterialGroup Then
                ReDim Preserve a_MaterialGroup(jIndex)
                a_MaterialGroup(jIndex).MainID = CurMainID
                a_MaterialGroup(jIndex).MaterialID = MaterialItemRecordSet.Fields("MaterialID").Value.ToString.Trim
                a_MaterialGroup(jIndex).Description = MaterialItemRecordSet.Fields("Material Description").Value.ToString.Trim
                a_MaterialGroup(jIndex).Units = "01-03"
                a_MaterialGroup(jIndex).OptionStr = Nothing
                a_MaterialGroup(jIndex).Type = Nothing
                a_MaterialGroup(jIndex).OrderBy = Nothing
                a_MaterialGroup(jIndex).Qty = CalculateNumberOfCarsInEstimate("01-03")
                a_MaterialGroup(jIndex).MaterialCost = 0
                a_MaterialGroup(jIndex).StandardHours = 0
                a_MaterialGroup(jIndex).SpecialHours = 0
                jIndex += 1
            End If
            Action = MOVE_NEXT
        Loop
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)

        For iIndex = SheetHeaders.GetLowerBound(0) To SheetHeaders.GetUpperBound(0)
            Erase HeaderSetup
            kIndex = 0
            For jIndex = SheetHeaders.GetLowerBound(1) To SheetHeaders.GetUpperBound(1)
                If Not String.IsNullOrEmpty(SheetHeaders(iIndex, jIndex).HeaderDesc) Then
                    ReDim Preserve HeaderSetup(kIndex)
                    HeaderSetup(kIndex) = New DataColumn(SheetHeaders(iIndex, jIndex).HeaderDesc, SheetHeaders(iIndex, jIndex).HeaderType)
                    kIndex += 1
                End If
            Next jIndex
            Select Case iIndex
                Case MAIN_GROUP
                    MainGroups = myDataSet.Tables.Add("EstMainGroup")
                    MainGroups.Columns.AddRange(HeaderSetup)
                    For jIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
                        MainGroups.Rows.Add(New Object() {a_MainGroup(jIndex).Description, a_MainGroup(jIndex).MainID})
                    Next jIndex
                Case MATERIAL_GROUP
                    SubGroups = myDataSet.Tables.Add("EstMaterials")
                    SubGroups.Columns.AddRange(HeaderSetup)
                    For jIndex = a_MaterialGroup.GetLowerBound(0) To a_MaterialGroup.GetUpperBound(0)
                        SubGroups.Rows.Add(New Object() {a_MaterialGroup(jIndex).Description, a_MaterialGroup(jIndex).MainID, a_MaterialGroup(jIndex).MaterialID,
                                                         a_MaterialGroup(jIndex).Units, a_MaterialGroup(jIndex).OptionStr, a_MaterialGroup(jIndex).Type,
                                                         a_MaterialGroup(jIndex).OrderBy, a_MaterialGroup(jIndex).Qty, a_MaterialGroup(jIndex).MaterialCost,
                                                         a_MaterialGroup(jIndex).StandardHours, a_MaterialGroup(jIndex).SpecialHours})
                    Next jIndex
                    Exit For
                Case Else
            End Select
        Next iIndex

        myDataSet.Relations.Add("EstMaterials", MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))

    End Sub
    Private Sub frmEstimatingBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

        Me.Cursor = Cursors.WaitCursor
        Load_ListBoxes()
        FpSpread1.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        FpSpread1.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        FpSpread1.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        FpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off
        'Init Spread
        With FpSpread1.ActiveSheet
            .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
            .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            .RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
            .SheetCornerStyle.BackColor = Color.DarkGray
            .SetColumnWidth(0, 150)
            .SetColumnVisible(1, False)
            .GrayAreaBackColor = Color.White
        End With
        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        GeneralInformation_fra.Left = 6
        GeneralInformation_fra.Width = GroupBox1.Width - GeneralInformation_fra.Left - 10
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        BillofMaterialsandTaskList_fra.Left = 6
        BillofMaterialsandTaskList_fra.Width = GroupBox1.Width - BillofMaterialsandTaskList_fra.Left - 10
        CurrentBillofMaterialsandTaskListFrameHeight = BillofMaterialsandTaskList_fra.Height
        Relocate_BillofMaterialsandTaskList_Frame()
        FpSpread1.Left = 6
        'FpSpread1.Width = GroupBox1.Width - FpSpread1.Left - 10
        FpSpread1.Visible = False
        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_DESC, 200)
                ChildSheetView1.SetColumnVisible(MAT_COL_MAIN_ID, False)
                ChildSheetView1.SetColumnVisible(MAT_COL_MATERIAL_ID, False)
                ChildSheetView1.SetColumnVisible(MAT_COL_UNITS, False)

                ChildSheetView1.SetColumnWidth(MAT_COL_OPTION, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_TYPE, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_ORDER_BY, 100)
                If iIndex = 0 Then
                    For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                        ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).CellType = SetCombo("Options", ChildSheetView1, jIndex)
                        ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).CellType = SetCombo("Types", ChildSheetView1, jIndex)
                        ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).CellType = SetCombo("OrderBys", ChildSheetView1, jIndex)
                        ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value = CalculateNumberOfCarsInEstimate("01-03")         'TabControl1.TabPages(0).Text)
                    Next jIndex
                End If
                ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_COST, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_SPECIAL_HOURS, 100)

                'For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                '    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                '    If Not ChildSheetView2 Is Nothing Then

                '        ChildSheetView2.SetColumnVisible(1, False)
                '    End If
                'Next jindex
            End If
        Next iIndex
        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub FpSpread1_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs)

        e.SheetView.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        e.SheetView.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        e.SheetView.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        'Display child
        'e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).Font = fpFont
        'e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).ForeColor = Color.Black
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).Font = fpFont
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).BackColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).BackColor
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).ForeColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).ForeColor
        e.SheetView.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        'e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).BackColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).BackColor
        'e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).ForeColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).ForeColor
        e.SheetView.SheetCornerStyle.BackColor = FpSpread1.ActiveSheet.SheetCornerStyle.BackColor
        e.SheetView.GrayAreaBackColor = Color.Gray
        e.SheetView.LockBackColor = Color.DarkGray
        'e.SheetView.SetColumnWidth(1, 110)
        'e.SheetView.SetColumnWidth(2, 110)
        'e.SheetView.SetColumnVisible(3, False)
        svCollection.Add(e.SheetView)

    End Sub
    Private Sub _IconButton_cmd_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_0.Click
        End
    End Sub
    Private Sub _IconButton_cmd_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_6.Click
        CM_MAIN_frm.Show()
        Me.Dispose()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ExpandCollapseAll("Expand")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ExpandCollapseAll("Collapse")
    End Sub
    Private Sub ExpandCollapseAll(ByVal ExpandCollapseAction As String)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            Select Case ExpandCollapseAction
                Case "Expand"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, True)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, True)
                        Next jIndex
                    End If
                Case "Collapse"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, False)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, False)
                        Next jIndex
                    End If
                Case Else
            End Select
        Next iIndex

    End Sub
    Private Sub ExpandCollapseFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseFrame_btn.Click

        If GeneralInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            GeneralInformation_fra.Height = CurrentGenInfoFrameHeight
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        Else
            GeneralInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\add.png")
        End If
        Relocate_BillofMaterialsandTaskList_Frame()

    End Sub
    Private Sub Relocate_BillofMaterialsandTaskList_Frame()

        BillofMaterialsandTaskList_fra.Top = GeneralInformation_fra.Top + GeneralInformation_fra.Height + 6
        If GeneralInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            BillofMaterialsandTaskList_fra.Height += CurrentGenInfoFrameHeight - 20
        Else
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight
        End If

    End Sub
    Private Sub Load_ListBoxes()

        MachineType_cmb.Items.Clear()
        MachineType_cmb.Items.Add(GEARED_TYPE)
        MachineType_cmb.Items.Add(GEARLESS_TYPE)

        DriveType_cmb.Items.Clear()
        DriveType_cmb.Items.Add(AC_TYPE)
        DriveType_cmb.Items.Add(AC_REGEN_TYPE)
        DriveType_cmb.Items.Add(DC_TYPE)

    End Sub
    Private Function SetCombo(ByVal ArrayType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ReturnCmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim UseWhere As String = String.Empty
        Dim Options As String() = Nothing
        Dim Action As Integer = MOVE_FIRST

        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, GROUP_SETUP_QRY)
        UseWhere = "MaterialID = '" & CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text & "'"
        If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) = RECORD_NOT_FOUND Then
            Options = {"Option1", "Option2", "Option3"}
        Else
            Do Until Query_Execute(ADOConnectionRPTDataDB, MaterialItemRecordSet, 1, Action) <> 0
                If MaterialItemRecordSet.Fields("MaterialID").Value.ToString = CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text Then
                    Select Case ArrayType
                        Case "Options"
                            If MaterialItemRecordSet.Fields("OptionNew").Value = True Then
                                CheckForAryValue(Options, "New")
                            End If
                            If MaterialItemRecordSet.Fields("OptionReuse").Value = True Then
                                CheckForAryValue(Options, "Reuse")
                            End If
                            If MaterialItemRecordSet.Fields("OptionRefurbish").Value = True Then
                                CheckForAryValue(Options, "Refurbish")
                            End If
                            If MaterialItemRecordSet.Fields("OptionNA").Value = True Then
                                CheckForAryValue(Options, "NA")
                            End If
                            If Not Convert.IsDBNull(MaterialItemRecordSet.Fields("OptionOther").Value) Then
                                CheckForAryValue(Options, MaterialItemRecordSet.Fields("OptionOther").Value.ToString)
                            End If
                        Case "Types"
                            If Not Convert.IsDBNull(MaterialItemRecordSet.Fields("Type")) Then
                                CheckForAryValue(Options, MaterialItemRecordSet.Fields("Type").Value.ToString)
                            End If
                        Case "OrderBys"
                            If MaterialItemRecordSet.Fields("OrderByHQ").Value = True Then
                                CheckForAryValue(Options, "HQ")
                            End If
                            If MaterialItemRecordSet.Fields("OrderByRL").Value = True Then
                                CheckForAryValue(Options, "RL")
                            End If
                        Case Else
                            Options = {"Option1", "Option2", "Option3"}
                            Exit Do
                    End Select
                End If
                Action = MOVE_NEXT
            Loop
        End If
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
        ReturnCmb.Items = Options
        ReturnCmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        ReturnCmb.Editable = False
        ReturnCmb.MaxDrop = Options.Length
        Return ReturnCmb

    End Function
    Private Sub CheckForAryValue(ByRef CurAry() As String, ByVal SetValue As String)
        Dim iIndex As Integer = 0, jIndex As Integer = 0
        Dim FoundValue As Boolean = False

        If IsNothing(CurAry) Then
            ReDim CurAry(iIndex)
            CurAry(iIndex) = SetValue
        Else
            For jIndex = CurAry.GetLowerBound(0) To CurAry.GetUpperBound(0)
                If CurAry(jIndex) = SetValue Then
                    FoundValue = True
                    Exit For
                End If
            Next jIndex
            If Not FoundValue Then
                iIndex = CurAry.GetUpperBound(0) + 1
                ReDim Preserve CurAry(iIndex)
                CurAry(iIndex) = SetValue
            End If
        End If

    End Sub
    Private Sub GetCostHours(ByVal MaterialID As String, ByVal CurOption As String, ByVal CurType As String, ByVal CurOrderBy As String,
                             ByVal CostOrHours As String, ByRef CurField As Integer, ByVal CurQty As Integer)
        Dim UseWhere As String = "MaterialID = '" & MaterialID & "'"

        If String.IsNullOrEmpty(CurOption) Then
            Exit Sub
        ElseIf CurOption <> "New" Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(CurType) Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(CurOrderBy) Then
            Exit Sub
        ElseIf CurOrderBy = "RL" Then
            Exit Sub
        End If
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, GROUP_SETUP_QRY)
        Select Case MaterialID
            Case "00CON"
                If String.IsNullOrEmpty(MachineType_cmb.Text) Or String.IsNullOrEmpty(DriveType_cmb.Text) Then
                    Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
                    Exit Sub
                Else
                    UseWhere &= " AND Type = '" & CurType & "'"
                    Select Case CurType
                        Case "SCH - TXR5", "SCH - TX2R7"
                            UseWhere &= " AND [Criteria 1] = '" & MachineType_cmb.Text & "' AND [Criteria 2] = '" & DriveType_cmb.Text & "'"
                        Case Else
                    End Select
                    If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                        If CostOrHours = "Cost" Then
                            CurField = MaterialItemRecordSet.Fields("Material Cost").Value * CurQty
                        ElseIf CostOrHours = "Hours" Then
                            CurField = MaterialItemRecordSet.Fields("Standard Hours").Value * CurQty
                        End If
                    End If
                End If
            Case Else
        End Select
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)

    End Sub
    Private Sub MachineType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineType_cmb.SelectedIndexChanged
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).Text,
                                 ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).Text, "Cost",
                                 ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST).Value, ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value)
                    GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).Text,
                                 ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).Text, "Hours",
                                 ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS).Text, ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value)
                Next jIndex
            End If
        Next iIndex

    End Sub
    Private Sub DriveType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveType_cmb.SelectedIndexChanged
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).Text,
                                 ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).Text, "Cost",
                                 ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST).Value, ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value)
                    GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).Text,
                                 ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).Text, "Hours",
                                 ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS).Value, ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value)
                Next jIndex
            End If
        Next iIndex

    End Sub
    Private Sub FpSpread1_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(FpSpread1.ActiveSheet.ActiveRowIndex, 0)
        If Not ChildSheetView1 Is Nothing Then
            GetCostHours(ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(e.Row, MAT_COL_OPTION).Text,
                 ChildSheetView1.Cells(e.Row, MAT_COL_TYPE).Text, ChildSheetView1.Cells(e.Row, MAT_COL_ORDER_BY).Text, "Cost",
                 ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_COST).Value, ChildSheetView1.Cells(e.Row, MAT_COL_QTY).Value)
            GetCostHours(ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(e.Row, MAT_COL_OPTION).Text,
                         ChildSheetView1.Cells(e.Row, MAT_COL_TYPE).Text, ChildSheetView1.Cells(e.Row, MAT_COL_ORDER_BY).Text, "Hours",
                         ChildSheetView1.Cells(e.Row, MAT_COL_STANDARD_HOURS).Value, ChildSheetView1.Cells(e.Row, MAT_COL_QTY).Value)
        End If

    End Sub
    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(FpSpread1.ActiveSheet.ActiveRowIndex, 0)
        If Not ChildSheetView1 Is Nothing Then
            GetCostHours(ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(e.Row, MAT_COL_OPTION).Text,
                 ChildSheetView1.Cells(e.Row, MAT_COL_TYPE).Text, ChildSheetView1.Cells(e.Row, MAT_COL_ORDER_BY).Text, "Cost",
                 ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_COST).Value, ChildSheetView1.Cells(e.Row, MAT_COL_QTY).Value)
            GetCostHours(ChildSheetView1.Cells(e.Row, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(e.Row, MAT_COL_OPTION).Text,
                         ChildSheetView1.Cells(e.Row, MAT_COL_TYPE).Text, ChildSheetView1.Cells(e.Row, MAT_COL_ORDER_BY).Text, "Hours",
                         ChildSheetView1.Cells(e.Row, MAT_COL_STANDARD_HOURS).Value, ChildSheetView1.Cells(e.Row, MAT_COL_QTY).Value)
        End If

    End Sub
End Class
