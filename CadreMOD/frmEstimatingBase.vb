Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json
Imports Microsoft.VisualBasic

Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Private sv As New FarPoint.Win.Spread.SheetView()
    Private svCollection As New System.Collections.ArrayList(10)
    Private isInitializingComponent As Boolean = True

    Private SheetHeaders(,) As a_SheetHeaders_typ
    Private Const TotalMaterialColumns As Integer = 11

    Private CurrentGenInfoFrameHeight As Integer = 0, CurrentTorqueFrameHeight As Integer = 0, CurrentBillofMaterialsandTaskListFrameHeight As Integer = 0
    Private CurrentGenInfoFrameText As String = String.Empty, CurrentTorqueFrameText As String = String.Empty

    Private CurParentRow As Integer = 0, CurActiveChildRow As Integer = -999, CurActiveChildCol As Integer = -999
    Private CurChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
    Private SheetCornerColWidth_MAIN As Integer = 0, SheetCornerColWidth_CHILD As Integer = 0
    Private OrderingForms_spc As Object
    Public EstFileType As String = FileSuffix_BASE

    Public Sub CreateEstimatingDataSet(ByVal CurUnits As String)
        Dim iIndex As Integer = 0, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing
        Dim AddMaterial As Boolean = False

        Try
            EstimatingDataset = Nothing
            EstimatingDataset = New DataSet()
            EstimatingDataset.EnforceConstraints = False
            MainGroups = Nothing
            SubGroups = Nothing
            GeneralInfo = Nothing
            TorqueData = Nothing
            Erase a_MainGroup
            Erase a_MaterialGroup

            Erase SheetHeaders
            ReDim SheetHeaders(MATERIAL_GROUP, TotalMaterialColumns)

            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderDesc = "Main Group"
            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderDesc = TABLECOL_MAINID
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_COST).HeaderDesc = "Total Cost"
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_STD_HRS).HeaderDesc = "Total Std Hours"
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_SPEC_HRS).HeaderDesc = "Total Spec Hours"
            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderType = typeStr
            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderType = typeStr
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_COST).HeaderType = typeInt
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_STD_HRS).HeaderType = typeInt
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_SPEC_HRS).HeaderType = typeInt

            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderDesc = TABLECOL_MATERIALDESC
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderDesc = TABLECOL_MAINID
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderDesc = TABLECOL_MATERIALID
            SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderDesc = TABLECOL_UNITS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_EST).HeaderDesc = TABLECOL_OPTION_EST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_EST).HeaderDesc = TABLECOL_TYPE_EST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_EST).HeaderDesc = TABLECOL_ORDERBY_EST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_EST).HeaderDesc = TABLECOL_UNITQTY_EST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST_EST).HeaderDesc = TABLECOL_UNITCOST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS_EST).HeaderDesc = TABLECOL_STDHOURS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS_EST).HeaderDesc = TABLECOL_SPECHOURS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS_EST).HeaderDesc = TABLECOL_COMMENTS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_EST).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_EST).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_EST).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_EST).HeaderType = typeInt
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST_EST).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS_EST).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS_EST).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS_EST).HeaderType = typeStr

            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, "A", CurUnits) & EstFileType & ".JSON"
            If Not File.Exists(EST_Filename) Then
                ResetADODBRecordset(UseMaterialItemRecordSet)
                UseMaterialItemRecordSet.Open(MAIN_GROUP_QRY, ADOConnectionMODDataDataBase)
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    UseMaterialItemRecordSet.MoveFirst()
                    iIndex = 0
                    Do Until UseMaterialItemRecordSet.EOF
                        Array.Resize(a_MainGroup, iIndex + 1)
                        a_MainGroup(iIndex).MainID = UseMaterialItemRecordSet.Fields("Main ID").Value.ToString.Trim
                        a_MainGroup(iIndex).Description = UseMaterialItemRecordSet.Fields("Main").Value.ToString.Trim
                        a_MainGroup(iIndex).Units = CurUnits
                        UseMaterialItemRecordSet.MoveNext()
                        iIndex += 1
                    Loop
                End If
                UseMaterialItemRecordSet.Close()
                jIndex = 0
                ResetADODBRecordset(UseMaterialItemRecordSet)
                UseMaterialItemRecordSet.Open(SUB_GROUP_QRY, ADOConnectionMODDataDataBase)
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    UseMaterialItemRecordSet.MoveFirst()
                    Do Until UseMaterialItemRecordSet.EOF
                        AddMaterial = False
                        If IsDBNull(UseMaterialItemRecordSet.Fields("Usage").Value) Then
                            AddMaterial = True
                        ElseIf UseMaterialItemRecordSet.Fields("Usage").Value.ToString = "PORT" Then
                            If Destination_cmb.Text = "Phased MOD" Or Destination_cmb.Text = "DI" Then
                                AddMaterial = True
                            End If
                        End If
                        If AddMaterial Then
                            Array.Resize(a_MaterialGroup, jIndex + 1)
                            a_MaterialGroup(jIndex).MainID = UseMaterialItemRecordSet.Fields("Main ID").Value.ToString.Trim
                            a_MaterialGroup(jIndex).MaterialID = UseMaterialItemRecordSet.Fields("Sub ID").Value.ToString.Trim
                            a_MaterialGroup(jIndex).Description = UseMaterialItemRecordSet.Fields("Sub").Value.ToString.Trim
                            a_MaterialGroup(jIndex).Units = CurUnits
                            a_MaterialGroup(jIndex).OptionStr = Nothing
                            a_MaterialGroup(jIndex).Type = Nothing
                            a_MaterialGroup(jIndex).OrderBy = Nothing
                            a_MaterialGroup(jIndex).Qty = -999
                            a_MaterialGroup(jIndex).MaterialCost = 0
                            a_MaterialGroup(jIndex).StandardHours = 0
                            a_MaterialGroup(jIndex).SpecialHours = 0
                            jIndex += 1
                        End If
                        UseMaterialItemRecordSet.MoveNext()
                    Loop
                End If
                UseMaterialItemRecordSet.Close()
            End If
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
                        MainGroups = EstimatingDataset.Tables.Add(TABLENAME_MAIN)
                        MainGroups.Columns.AddRange(HeaderSetup)
                        If Not IsNothing(a_MainGroup) Then
                            For jIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
                                MainGroups.Rows.Add(New Object() {a_MainGroup(jIndex).Description, a_MainGroup(jIndex).MainID})
                            Next jIndex
                        End If
                    Case MATERIAL_GROUP
                        SubGroups = EstimatingDataset.Tables.Add(TABLENAME_MATERIALS)
                        SubGroups.Columns.AddRange(HeaderSetup)
                        If Not IsNothing(a_MaterialGroup) Then
                            For jIndex = a_MaterialGroup.GetLowerBound(0) To a_MaterialGroup.GetUpperBound(0)
                                SubGroups.Rows.Add(New Object() {a_MaterialGroup(jIndex).Description,
                                                                 a_MaterialGroup(jIndex).MainID,
                                                                 a_MaterialGroup(jIndex).MaterialID,
                                                                 a_MaterialGroup(jIndex).Units,
                                                                 a_MaterialGroup(jIndex).OptionStr,
                                                                 a_MaterialGroup(jIndex).Type,
                                                                 a_MaterialGroup(jIndex).OrderBy,
                                                                 a_MaterialGroup(jIndex).Qty,
                                                                 a_MaterialGroup(jIndex).MaterialCost,
                                                                 a_MaterialGroup(jIndex).StandardHours,
                                                                 a_MaterialGroup(jIndex).SpecialHours, ""})
                            Next jIndex
                        End If
                    Case Else
                End Select
            Next iIndex
            GeneralInfo = EstimatingDataset.Tables.Add(TABLENAME_GENERALINFO)
            GeneralInfo.Columns.AddRange(New DataColumn() {New DataColumn("UnitsInTab", typeStr),
                                                           New DataColumn("CapacityNew_cmb", typeStr),
                                                           New DataColumn("SpeedNew_cmb", typeStr),
                                                           New DataColumn("NumberofStopsTotal_cmb", typeStr),
                                                           New DataColumn("NumberofStopsFront_cmb", typeStr),
                                                           New DataColumn("NumberofStopsRear_cmb", typeStr),
                                                           New DataColumn("PowerSupply_cmb", typeStr),
                                                           New DataColumn("Application_cmb", typeStr),
                                                           New DataColumn("LayoutRequirements_cmb", typeStr),
                                                           New DataColumn("DoorOperatorTypeFront_cmb", typeStr),
                                                           New DataColumn("CarDoorOpeningWidthFtFront_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningWidthInFront_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningHeightFtFront_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningHeightInFront_txt", typeStr),
                                                           New DataColumn("DoorOperatorTypeRear_cmb", typeStr),
                                                           New DataColumn("CarDoorOpeningWidthFtRear_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningWidthInRear_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningHeightFtRear_txt", typeStr),
                                                           New DataColumn("CarDoorOpeningHeightInRear_txt", typeStr),
                                                           New DataColumn("MachineType_cmb", typeStr),
                                                           New DataColumn("DriveType_cmb", typeStr),
                                                           New DataColumn("CarWeight_txt", typeStr),
                                                           New DataColumn("HoistMotorHP_txt", typeStr),
                                                           New DataColumn("HoistMotorRpm_txt", typeStr),
                                                           New DataColumn("MachineLocation_Cmb", typeStr),
                                                           New DataColumn("RopingNew_Cmb", typeStr),
                                                           New DataColumn("TopFloorToOverhead_txt", typeStr),
                                                           New DataColumn("TravelNew_txt", typeStr),
                                                           New DataColumn("PitDepth_txt", typeStr),
                                                           New DataColumn("RiserQtyFront_Cmb", typeStr),
                                                           New DataColumn("RiserQtyRear_Cmb", typeStr),
                                                           New DataColumn("FixtureFinish_cmb", typeStr),
                                                           New DataColumn("DTRequestedShipDate", typeStr),
                                                           New DataColumn("BankCompleteDate_txt", typeStr),
                                                           New DataColumn("ExistingControlVendor_lst", typeStr),
                                                           New DataColumn("ExistingControlModel_lst", typeStr),
                                                           New DataColumn("OriginalGONumberAvailable_cmb", typeStr),
                                                           New DataColumn("OriginalGOnumber_txt", typeStr),
                                                           New DataColumn("PEStampRequired_cmb", typeStr),
                                                           New DataColumn("ShortFloorOperation_chk", typeInt),
                                                           New DataColumn("Permits_txt", typeStr),
                                                           New DataColumn("Bonds_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayZone_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayParking_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayOutOfTownExpenses_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayTravelTime_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayMiscellaneous_txt", typeStr),
                                                           New DataColumn("ExpensesPerDayTotal_txt", typeStr),
                                                           New DataColumn("ExpensesPerDay_txt", typeStr),
                                                           New DataColumn("GatewayReviewRequired_chk", typeInt),
                                                           New DataColumn("Destination_cmb", typeStr),
                                                           New DataColumn("ChangeInCapacity_chk", typeInt),
                                                           New DataColumn("CapacityExisting_cmb", typeStr),
                                                           New DataColumn("ChangeInSpeed_chk", typeInt),
                                                           New DataColumn("SpeedExisting_cmb", typeStr),
                                                           New DataColumn("ChangeInTravel_chk", typeInt),
                                                           New DataColumn("TravelExisting_txt", typeStr)})

            SetUpTorqueDataset(EstimatingDataset)
            CreateLaborRateDataTable(EstimatingDataset)
            Deserialize(EST_Filename, EstimatingDataset, "Error Reading Data - " & CurUnits, FormIsDirty)
            EstimatingDataset.Relations.Add(TABLENAME_MATERIALS, MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))
            RecalculateLaborRates()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In Base - CreateDataSet")

        End Try

    End Sub
    Private Sub PrepareThisForm()
        Dim JSONFileLocation As DirectoryInfo = New DirectoryInfo(EstimatePath)
        Dim JSONFileList As List(Of FileInfo) = New List(Of FileInfo)
        Dim UseTabName As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        ResetADODBRecordset(UseMaterialItemRecordSet)
        SetAssociatedFieldNames()
        txtHdrBldgName.Text = Contracts.JobName
        txtHdrEstimateNum.Text = HoldUniqueActivity
        txtHdrBnkLetter.Text = CurrentGOData_Typ.Bank
        Units_txt.Text = CurrentGOData_Typ.CurrentUnits
        isInitializingComponent = True
        DAO2ADO(ADOConnectionMODDataDataBase, ADOCatalogMODDataDataBase, HAPDatabasePath & "\", MODDATA_DATABASE_NAME, True)
        DAO2ADO(ADOConnection, ADOCatalogTorqueDataBase, HAPDatabasePath & "\", TORQUE_DATABASE_NAME, True)
        ExpandCollapseGeneralInfoFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
        ExpandCollapseTorqueFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
        If CurrentGOData_Typ.EstimateLevel = "Master" Then
            EstFileType = FileSuffix_MASTER
            FreezeSave_btn.Visible = True
        Else
            FreezeSave_btn.Visible = False
        End If
        For Each JSONFile In JSONFileLocation.GetFiles()
            If JSONFile IsNot Nothing Then
                If Path.GetExtension(JSONFile.ToString.ToUpper) = ".JSON" Then
                    If JSONFile.ToString.ToUpper.Contains(EstFileType) Or JSONFile.ToString.ToUpper.Contains(FileSuffix_ORDERING) Then
                        JSONFileList.Add(JSONFile)
                    End If
                End If
            End If
        Next JSONFile
        If JSONFileList.Count = 0 Then
            CarTab.Text = CurrentGOData_Typ.CurrentUnits & EST_Suffix
            If CurrentGOData_Typ.EstimateLevel = "Master" Then
                OrderTab.Text = CurrentGOData_Typ.CurrentUnits & ORD_Suffix
            End If
        Else
            Dim FoundFirstEstTab As Boolean = False, FoundFirstOrdTab As Boolean = False
            For iIndex As Integer = 0 To JSONFileList.Count - 1
                UseTabName = FormatTabName(JSONFileList(iIndex).Name)
                If JSONFileList(iIndex).Name.ToUpper.Contains(EstFileType) Then
                    If FoundFirstEstTab Then
                        TabControl1.TabPages.Add(UseTabName & EST_Suffix)
                    Else
                        CarTab.Text = UseTabName & EST_Suffix
                        FoundFirstEstTab = True
                    End If
                ElseIf JSONFileList(iIndex).Name.ToUpper.Contains(FileSuffix_ORDERING) Then
                    If FoundFirstOrdTab Then
                        TabControl1.TabPages.Add(UseTabName & ORD_Suffix)
                    Else
                        OrderTab.Text = UseTabName & ORD_Suffix
                        FoundFirstOrdTab = True
                    End If
                End If
            Next iIndex
            If Not FoundFirstOrdTab Then
                OrderTab.Text = UseTabName & ORD_Suffix
            End If
        End If
        Copy_cmd.Visible = False
        Merge_cmd.Visible = False
        If CurrentGOData_Typ.EstimateLevel = "Base" Then
            For iIndex As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
                Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                If CurTab.Text.IndexOf(ORD_Suffix) > -1 Or CurTab.Text.Trim.Length = 0 Then
                    TabControl1.TabPages.Remove(CurTab)
                End If
            Next iIndex
            Copy_cmd.Visible = True
            If TabControl1.TabPages.Count > 1 Then
                Merge_cmd.Visible = True
            End If
        End If
        TabControl1.SelectTab(0)
        CurrentTab = TabControl1.TabPages(0).Text.Trim
        CurrentTabUnits = Strings.Left(CurrentTab, CurrentTab.Length - 6)
        TabControl1.Left = 3
        GroupBox1.Width = Me.Width - 5
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        CurrentGenInfoFrameText = GeneralInformation_fra.Text
        CurrentTorqueFrameHeight = Torque_fra.Height
        CurrentTorqueFrameText = Torque_fra.Text
        CurrentBillofMaterialsandTaskListFrameHeight = BillofMaterialsandTaskList_fra.Height
        Dim UseIndex As Integer = 0
        For Each Cntrl As Control In ExpensesPerDay_frm.Controls
            If TypeOf [Cntrl] Is TextBox Then
                ReDim Preserve SubcontractedLaborCost.LaborCost(UseIndex)
                SubcontractedLaborCost.LaborCost(UseIndex).Description = [Cntrl].Name
                UseIndex += 1
            End If
        Next Cntrl
        ResetADODBRecordset(UseMaterialItemRecordSet)
        UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
        DisplayEST_vs_ORD()
        EnableBillOfMaterials()
        isInitializingComponent = False
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub frmEstimatingBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepareThisForm()
    End Sub
    Private Sub BillOfMaterials_spr_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles BillOfMaterials_spr.CellClick
        CurParentRow = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
        CurChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurParentRow, 0)
        CurActiveChildRow = CurChildSheetView.ActiveRowIndex
        CurActiveChildCol = CurChildSheetView.ActiveColumnIndex
    End Sub
    Private Sub BillOfMaterials_spr_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs) Handles BillOfMaterials_spr.ChildViewCreated

        e.SheetView.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        e.SheetView.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        e.SheetView.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        BillOfMaterials_spr.InterfaceRenderer = Nothing
        BillOfMaterials_spr.HorizontalScrollBar.Renderer = Nothing
        BillOfMaterials_spr.VerticalScrollBar.Renderer = Nothing
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        e.SheetView.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        e.SheetView.SheetCornerStyle.BackColor = BillOfMaterials_spr.ActiveSheet.SheetCornerStyle.BackColor
        e.SheetView.GrayAreaBackColor = Color.Gray
        e.SheetView.LockBackColor = Color.DarkGray
        svCollection.Add(e.SheetView)

    End Sub
    Private Sub Exit_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_cmd.Click

        If FormIsDirty Then
            If MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will negate all changes.", "Please Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                SaveAll()
            End If
        End If
        ResetADODBRecordset(UseMaterialItemRecordSet)
        EndProgram()

    End Sub
    Private Sub CMMain_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMMain_cmd.Click
        ReturnToCM("Estimating")
    End Sub
    Private Sub ExpandAll_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandAll_cmd.Click
        ExpandCollapseAll("Expand")
    End Sub
    Private Sub CollapseAll_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseAll_cmd.Click
        ExpandCollapseAll("Collapse")
    End Sub
    Private Sub ExpandCollapseAll(ByVal ExpandCollapseAction As String)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurActiveRow As Integer = 0, CurActiveCol As Integer = 0, CurActiveChildRow As Integer = -999, CurActiveChildCol As Integer = -999

        If BillOfMaterials_spr.ActiveSheet.RowCount > 0 Then
            CurActiveRow = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
            CurActiveCol = BillOfMaterials_spr.ActiveSheet.ActiveColumnIndex
            ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurActiveRow, 0)
            If Not ChildSheetView Is Nothing Then
                CurActiveChildRow = ChildSheetView.ActiveRowIndex()
                CurActiveChildCol = ChildSheetView.ActiveColumnIndex()
            End If
        End If
        For iIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.RowCount - 1
            Select Case ExpandCollapseAction
                Case "Expand"
                    BillOfMaterials_spr.ActiveSheet.ExpandRow(iIndex, True)
                    ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, True)
                        Next jIndex
                    End If
                Case "Collapse"
                    BillOfMaterials_spr.ActiveSheet.ExpandRow(iIndex, False)
                    ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, False)
                        Next jIndex
                    End If
                Case Else
            End Select
        Next iIndex
        BillOfMaterials_spr.ActiveSheet.SetActiveCell(CurActiveRow, CurActiveCol)
        If CurActiveChildRow <> -999 And CurActiveChildCol <> -999 Then
            ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurActiveRow, 0)
            If Not ChildSheetView Is Nothing Then
                ChildSheetView.SetActiveCell(CurActiveChildRow, CurActiveChildCol)
            End If
        End If

    End Sub
    Private Sub ExpandCollapseGeneralInfoFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseGeneralInfoFrame_btn.Click

        If GeneralInformation_fra.Height = ExpandCollapseGeneralInfoFrame_btn.Height + 2 Then
            GeneralInformation_fra.Height = CurrentGenInfoFrameHeight
            ExpandCollapseGeneralInfoFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
            For Each CurControl As Control In GeneralInformation_fra.Controls
                CurControl.Visible = True
            Next CurControl
        Else
            GeneralInformation_fra.Height = ExpandCollapseGeneralInfoFrame_btn.Height + 2
            ExpandCollapseGeneralInfoFrame_btn.Image = Image.FromFile(ImageFileLocation & "add.png")
            For Each CurControl As Control In GeneralInformation_fra.Controls
                If CurControl.Name <> "ExpandCollapseGeneralInfoFrame_btn" Then
                    CurControl.Visible = False
                End If
            Next CurControl
        End If
        RelocateAndResizeAllFrames()

    End Sub
    Private Sub RelocateAndResizeAllFrames()

        Torque_fra.Top = GeneralInformation_fra.Top + GeneralInformation_fra.Height + 6
        BillofMaterialsandTaskList_fra.Top = Torque_fra.Top + Torque_fra.Height + 6
        If GeneralInformation_fra.Height = ExpandCollapseGeneralInfoFrame_btn.Height + 2 And
           Torque_fra.Height = ExpandCollapseTorqueFrame_btn.Height + 2 Then
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight + CurrentGenInfoFrameHeight + CurrentTorqueFrameHeight - 40
        ElseIf GeneralInformation_fra.Height = ExpandCollapseGeneralInfoFrame_btn.Height + 2 Then
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight + CurrentGenInfoFrameHeight - 20
        ElseIf Torque_fra.Height = ExpandCollapseTorqueFrame_btn.Height + 2 Then
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight + CurrentTorqueFrameHeight - 20
        Else
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight
        End If

    End Sub
    Private Sub Load_ListBoxes()
        Dim i As Integer = 0, jIndx As Integer = 0
        Dim sSQL As String = "", UseTable As String = "SuperTable"
        Dim AddValToArray As Boolean = True
        Dim CurrentMachineType As String = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")
        Dim ExistingMachineVendor As String = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb")
        Dim ExistingMachineModel As String = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_cmb")
        Dim NewMachineVendor As String = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorNew_Cmb")
        Dim NewMachineModel As String = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb")
        Dim UseMachineVendor As String = String.Empty, UseMachineModel As String = String.Empty
        Dim HoistRopeSize As String = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "HoistRopeSize_Cmb")

        'General info
        CapacityNew_cmb.Items.Clear()
        CapacityNew_cmb.Items.Add("1200")
        CapacityNew_cmb.Items.Add("1500")
        CapacityNew_cmb.Items.Add("2000")
        CapacityNew_cmb.Items.Add("2500")
        CapacityNew_cmb.Items.Add("3000")
        CapacityNew_cmb.Items.Add("3500")
        CapacityNew_cmb.Items.Add("4000")
        CapacityNew_cmb.Items.Add("4500")
        CapacityNew_cmb.Items.Add("5000")
        CapacityNew_cmb.Items.Add("6000")

        CapacityExisting_cmb.Items.Clear()
        CapacityExisting_cmb.Items.Add("1200")
        CapacityExisting_cmb.Items.Add("1500")
        CapacityExisting_cmb.Items.Add("2000")
        CapacityExisting_cmb.Items.Add("2500")
        CapacityExisting_cmb.Items.Add("3000")
        CapacityExisting_cmb.Items.Add("3500")
        CapacityExisting_cmb.Items.Add("4000")
        CapacityExisting_cmb.Items.Add("4500")
        CapacityExisting_cmb.Items.Add("5000")
        CapacityExisting_cmb.Items.Add("6000")

        SpeedNew_cmb.Items.Clear()
        Select Case CurrentGOData_Typ.MachineType
            Case HYDRO_TYPE
                For i = 50 To 200 Step 25
                    SpeedNew_cmb.Items.Add(CStr(i))
                Next i
            Case GEARED_TYPE
                SpeedNew_cmb.Items.Add("100")
                SpeedNew_cmb.Items.Add("150")
                SpeedNew_cmb.Items.Add("200")
                SpeedNew_cmb.Items.Add("250")
                SpeedNew_cmb.Items.Add("300")
                SpeedNew_cmb.Items.Add("350")
                SpeedNew_cmb.Items.Add("400")
                SpeedNew_cmb.Items.Add("450")
                SpeedNew_cmb.Items.Add("500")
            Case GEARLESS_TYPE
                SpeedNew_cmb.Items.Add("500")
                SpeedNew_cmb.Items.Add("600")
                SpeedNew_cmb.Items.Add("700")
                SpeedNew_cmb.Items.Add("800")
                SpeedNew_cmb.Items.Add("900")
                SpeedNew_cmb.Items.Add("1000")
                SpeedNew_cmb.Items.Add("1100")
                SpeedNew_cmb.Items.Add("1200")
                SpeedNew_cmb.Items.Add("1300")
                SpeedNew_cmb.Items.Add("1400")
        End Select

        SpeedExisting_cmb.Items.Clear()
        Select Case CurrentGOData_Typ.MachineType
            Case HYDRO_TYPE
                For i = 50 To 200 Step 25
                    SpeedExisting_cmb.Items.Add(CStr(i))
                Next i
            Case GEARED_TYPE
                SpeedExisting_cmb.Items.Add("100")
                SpeedExisting_cmb.Items.Add("150")
                SpeedExisting_cmb.Items.Add("200")
                SpeedExisting_cmb.Items.Add("250")
                SpeedExisting_cmb.Items.Add("300")
                SpeedExisting_cmb.Items.Add("350")
                SpeedExisting_cmb.Items.Add("400")
                SpeedExisting_cmb.Items.Add("450")
                SpeedExisting_cmb.Items.Add("500")
            Case GEARLESS_TYPE
                SpeedExisting_cmb.Items.Add("500")
                SpeedExisting_cmb.Items.Add("600")
                SpeedExisting_cmb.Items.Add("700")
                SpeedExisting_cmb.Items.Add("800")
                SpeedExisting_cmb.Items.Add("900")
                SpeedExisting_cmb.Items.Add("1000")
                SpeedExisting_cmb.Items.Add("1100")
                SpeedExisting_cmb.Items.Add("1200")
                SpeedExisting_cmb.Items.Add("1300")
                SpeedExisting_cmb.Items.Add("1400")
        End Select

        NumberofStopsTotal_cmb.Items.Clear()
        For i = MIN_BLDG_FLRS To MAX_BLDG_FLRS
            NumberofStopsTotal_cmb.Items.Add(i)
        Next i

        NumberofStopsFront_cmb.Items.Clear()
        For i = MIN_BLDG_FLRS To MAX_BLDG_FLRS
            NumberofStopsFront_cmb.Items.Add(i)
        Next i

        NumberofStopsRear_cmb.Items.Clear()
        For i = 0 To MAX_BLDG_FLRS
            NumberofStopsRear_cmb.Items.Add(i)
        Next i

        PowerSupply_cmb.Items.Clear()
        PowerSupply_cmb.Items.Add("208")
        PowerSupply_cmb.Items.Add("240")
        'If All_LocalCodeDep.CanadaJob Then
        '    PowerSupply_cmb.Items.Add("416")
        'End If
        PowerSupply_cmb.Items.Add("440")
        PowerSupply_cmb.Items.Add("460")
        PowerSupply_cmb.Items.Add("480")
        PowerSupply_cmb.Items.Add("575")
        PowerSupply_cmb.Items.Add("600")

        Application_cmb.Items.Clear()
        Application_cmb.Items.Add("Passenger")
        Application_cmb.Items.Add("Hospital/Service")
        Application_cmb.Items.Add("Freight")

        DoorOperatorTypeFront_cmb.Items.Clear()
        DoorOperatorTypeFront_cmb.Items.Add(DOORTYPE_1SCO)
        DoorOperatorTypeFront_cmb.Items.Add(DOORTYPE_1SSS)
        DoorOperatorTypeFront_cmb.Items.Add(DOORTYPE_2SSS)
        DoorOperatorTypeFront_cmb.Items.Add(DOORTYPE_2SCO)

        DoorOperatorTypeRear_cmb.Items.Clear()
        DoorOperatorTypeRear_cmb.Items.Add(DOORTYPE_1SCO)
        DoorOperatorTypeRear_cmb.Items.Add(DOORTYPE_1SSS)
        DoorOperatorTypeRear_cmb.Items.Add(DOORTYPE_2SSS)
        DoorOperatorTypeRear_cmb.Items.Add(DOORTYPE_2SCO)

        LayoutRequirements_cmb.Items.Clear()
        LayoutRequirements_cmb.Items.Add("Record Only")
        LayoutRequirements_cmb.Items.Add("Approval")
        LayoutRequirements_cmb.Items.Add("Machine Room")
        LayoutRequirements_cmb.Items.Add("Full")
        LayoutRequirements_cmb.Items.Add("None")

        MachineType_cmb.Items.Clear()
        Select Case CurrentGOData_Typ.MachineType
            Case GEARED_TYPE
                MachineType_cmb.Items.Add("Reuse " & GEARED_TYPE)
                MachineType_cmb.Items.Add("New " & GEARED_TYPE)
                If Not IsPOHController Then
                    MachineType_cmb.Items.Add(MACHINE_FMM200)
                End If
                MachineType_cmb.Items.Add("New " & GEARLESS_TYPE)
            Case GEARLESS_TYPE
                If Not IsPOHController Then
                    MachineType_cmb.Items.Add(MACHINE_FMM200)
                End If
                MachineType_cmb.Items.Add("Reuse " & GEARLESS_TYPE)
                MachineType_cmb.Items.Add("New " & GEARLESS_TYPE)
            Case Else
        End Select

        DriveType_cmb.Items.Clear()
        DriveType_cmb.Items.Add(AC_TYPE)
        DriveType_cmb.Items.Add(AC_REGEN_TYPE)
        DriveType_cmb.Items.Add(QUATTRO_TYPE)
        DriveType_cmb.Items.Add(DC_TYPE)

        MachineLocation_Cmb.Items.Clear()
        MachineLocation_Cmb.Items.Add("Overhead")
        MachineLocation_Cmb.Items.Add("Basement")
        MachineLocation_Cmb.Items.Add("Semi-Basement")

        RopingNew_Cmb.Items.Clear()
        RopingNew_Cmb.Items.Add("1:1 Single Wrap")
        RopingNew_Cmb.Items.Add("1:1 Dual Wrap")
        RopingNew_Cmb.Items.Add("2:1 Single Wrap")
        RopingNew_Cmb.Items.Add("2:1 Dual Wrap")
        RopingNew_Cmb.Items.Add("2:1 Underslung")

        RiserQtyFront_Cmb.Items.Clear()
        RiserQtyFront_Cmb.Items.Add("0")
        RiserQtyFront_Cmb.Items.Add("1")
        RiserQtyFront_Cmb.Items.Add("2")
        RiserQtyFront_Cmb.Items.Add("3")
        RiserQtyFront_Cmb.Items.Add("4")

        RiserQtyRear_Cmb.Items.Clear()
        RiserQtyRear_Cmb.Items.Add("0")
        RiserQtyRear_Cmb.Items.Add("1")
        RiserQtyRear_Cmb.Items.Add("2")
        RiserQtyRear_Cmb.Items.Add("3")
        RiserQtyRear_Cmb.Items.Add("4")

        FixtureFinish_cmb.Items.Clear()
        FixtureFinish_cmb.Items.Add(FINISH_4SS)
        FixtureFinish_cmb.Items.Add(FINISH_4BZ)
        FixtureFinish_cmb.Items.Add(FINISH_8SS)
        FixtureFinish_cmb.Items.Add(FINISH_8BZ)

        ExistingControlVendor_lst.Items.Clear()
        ResetADODBRecordset(UseMaterialItemRecordSet)
        UseMaterialItemRecordSet.Open("OEM_SQL", ADOConnectionMODDataDataBase)
        While Not UseMaterialItemRecordSet.EOF
            ExistingControlVendor_lst.Items.Add(UseMaterialItemRecordSet("Manufacturer").Value.ToString)
            UseMaterialItemRecordSet.MoveNext()
        End While
        UseMaterialItemRecordSet.Close()

        ExistingControlModel_lst.Items.Clear()
        Select Case GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExistingControlVendor_lst")
            Case SEC, WESTINGHOUSE
                ExistingControlModel_lst.Items.Add("DMR")
                ExistingControlModel_lst.Items.Add("EPCOH/EP2")
                ExistingControlModel_lst.Items.Add("ERL")
                ExistingControlModel_lst.Items.Add("Miconic A")
                ExistingControlModel_lst.Items.Add("Miconic V")
                ExistingControlModel_lst.Items.Add("REL")
                ExistingControlModel_lst.Items.Add("RSBL")
                ExistingControlModel_lst.Items.Add("SMF")
                ExistingControlModel_lst.Items.Add("SMF2")
                ExistingControlModel_lst.Items.Add("SMF3 (TTL)")
                ExistingControlModel_lst.Items.Add("TXR4")
                ExistingControlModel_lst.Items.Add("TXR5")
            Case ARMOR
                ExistingControlModel_lst.Items.Add("TAC 5")
                ExistingControlModel_lst.Items.Add("TMS 200")
                ExistingControlModel_lst.Items.Add("TMS 500")
                ExistingControlModel_lst.Items.Add("TMS 700")
                ExistingControlModel_lst.Items.Add("TMS 900")
            Case "Computerized Elevator Control"
                ExistingControlModel_lst.Items.Add("Swift 5000")
                ExistingControlModel_lst.Items.Add("Swift Futura")
                ExistingControlModel_lst.Items.Add("Swift Meridia")
            Case DOVER, "Thyssen"
                ExistingControlModel_lst.Items.Add("Computamatic")
                ExistingControlModel_lst.Items.Add("DMC")
                ExistingControlModel_lst.Items.Add("ISIS")
                ExistingControlModel_lst.Items.Add("LMH")
                ExistingControlModel_lst.Items.Add("Micromodernizer II")
                ExistingControlModel_lst.Items.Add("T 2000")
                ExistingControlModel_lst.Items.Add("T II")
                ExistingControlModel_lst.Items.Add("T III")
                ExistingControlModel_lst.Items.Add("T IV")
                ExistingControlModel_lst.Items.Add("TAC 20/22")
                ExistingControlModel_lst.Items.Add("TAC 50")
            Case "Fujitec"
                ExistingControlModel_lst.Items.Add("DC-DIM")
                ExistingControlModel_lst.Items.Add("EXDN")
                ExistingControlModel_lst.Items.Add("Flex 10A")
                ExistingControlModel_lst.Items.Add("Hydrodyne")
                ExistingControlModel_lst.Items.Add("MIC 200")
                ExistingControlModel_lst.Items.Add("MIC 300")
                ExistingControlModel_lst.Items.Add("MIC 320")
                ExistingControlModel_lst.Items.Add("MIC 400")
                ExistingControlModel_lst.Items.Add("Millennium")
                ExistingControlModel_lst.Items.Add("Superdyne")
            Case MONTGOMERY, "Kone"
                ExistingControlModel_lst.Items.Add("KCM 831")
                ExistingControlModel_lst.Items.Add("KONE ST")
                ExistingControlModel_lst.Items.Add("KONE HX")
                ExistingControlModel_lst.Items.Add("KONE TMS 600")
                ExistingControlModel_lst.Items.Add("Miprom I")
                ExistingControlModel_lst.Items.Add("Miprom II")
                ExistingControlModel_lst.Items.Add("Miprom 21")
                ExistingControlModel_lst.Items.Add("Miprom 2100")
                ExistingControlModel_lst.Items.Add("Miprom SL")
                ExistingControlModel_lst.Items.Add("Miprom 50/TMS 50")
                ExistingControlModel_lst.Items.Add("Resolve 20")
                ExistingControlModel_lst.Items.Add("Uniprom")
            Case OTIS
                ExistingControlModel_lst.Items.Add("Elevonic 101")
                ExistingControlModel_lst.Items.Add("Elevonic 211")
                ExistingControlModel_lst.Items.Add("Elevonic 311")
                ExistingControlModel_lst.Items.Add("Elevonic 335")
                ExistingControlModel_lst.Items.Add("Elevonic 401")
                ExistingControlModel_lst.Items.Add("Elevonic 411")
                ExistingControlModel_lst.Items.Add("GAMMA D")
                ExistingControlModel_lst.Items.Add("Gen2")
                ExistingControlModel_lst.Items.Add("LRS 3")
                ExistingControlModel_lst.Items.Add("LRV 1")
                ExistingControlModel_lst.Items.Add("LRV 3")
                ExistingControlModel_lst.Items.Add("LRV 4")
                ExistingControlModel_lst.Items.Add("LRV 5")
                ExistingControlModel_lst.Items.Add("MRQ (Spec 60)")
                ExistingControlModel_lst.Items.Add("MRS")
                ExistingControlModel_lst.Items.Add("MRVF")
            Case "U.S. Elevator"
                ExistingControlModel_lst.Items.Add("1200 MP")
                ExistingControlModel_lst.Items.Add("1210 MP")
                ExistingControlModel_lst.Items.Add("1220 MP")
                ExistingControlModel_lst.Items.Add("1230 MP")
                ExistingControlModel_lst.Items.Add("Ascension 1000")
                ExistingControlModel_lst.Items.Add("Ascension 2000")
            Case MCE, "Motion Control"
                ExistingControlModel_lst.Items.Add("DSD 412")
                ExistingControlModel_lst.Items.Add("HVP 900")
                ExistingControlModel_lst.Items.Add("IMC")
                ExistingControlModel_lst.Items.Add("I-BOX")
            Case Else
        End Select

        OriginalGONumberAvailable_cmb.Items.Clear()
        OriginalGONumberAvailable_cmb.Items.Add("Yes")
        OriginalGONumberAvailable_cmb.Items.Add("No")

        PEStampRequired_cmb.Items.Clear()
        PEStampRequired_cmb.Items.Add("Yes")
        PEStampRequired_cmb.Items.Add("No")

        Destination_cmb.Items.Clear()
        Destination_cmb.Items.Add("None")
        Destination_cmb.Items.Add("Phased MOD")
        Destination_cmb.Items.Add("DI")

        'Torque data
        ResetADODBRecordset(TorqueRecordset)
        MachineVendorExisting_Cmb.Items.Clear()
        TorqueRecordset.Open("SELECT DISTINCT Manufacturer FROM SuperTable WHERE MachineType='" & CurrentGOData_Typ.MachineType & "'", ADOConnection)
        Do While Not TorqueRecordset.EOF
            MachineVendorExisting_Cmb.Items.Add(TorqueRecordset("Manufacturer").Value)
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        MachineVendorExisting_Cmb.Items.Add(OTHER)

        MachineModelExisting_cmb.Items.Clear()
        If ExistingMachineVendor <> OTHER Then
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open("SELECT DISTINCT MachineModel From SuperTable WHERE MachineType='" & CurrentGOData_Typ.MachineType &
                                 "' AND Manufacturer='" & ExistingMachineVendor & "' ORDER BY MachineModel", ADOConnection)
            Do While Not TorqueRecordset.EOF
                MachineModelExisting_cmb.Items.Add(TorqueRecordset("MachineModel").Value)
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
        End If
        If FindString(MachineModelExisting_cmb, OTHER) = -1 Then
            MachineModelExisting_cmb.Items.Add(OTHER)
        End If

        If CurrentMachineType.IndexOf("Reuse") > -1 Then
            If OtherOther(False) Then
                UseMachineVendor = OTHER
                UseMachineModel = OTHER
            Else
                UseMachineVendor = ExistingMachineVendor
                UseMachineModel = ExistingMachineModel
            End If
        Else
            UseMachineVendor = NewMachineVendor
            UseMachineModel = NewMachineModel
        End If
        ReDim aMachineSheaveDiameter(0)
        aMachineSheaveDiameter(0) = ""
        If CurrentGOData_Typ.MachineType = GEARLESS_TYPE Then
            Select Case CurrentMachineType
                Case MACHINE_FMM200, "New " & GEARLESS_TYPE
                    UseTable = "SuperTable_Gearless"
                Case Else
            End Select
        End If
        If UseMachineModel = OTHER Or UseMachineModel = "" Then
            sSQL = "SELECT DISTINCT " & UseTable & ".[Sheave Dia] FROM " & UseTable
            If UseMachineVendor <> OTHER And UseMachineVendor <> "" Then
                sSQL &= " WHERE Manufacturer='" & UseMachineVendor & "' AND MachineType='" & CurrentGOData_Typ.MachineType & "'"
            Else
                sSQL &= " WHERE MachineType='" & CurrentGOData_Typ.MachineType & "'"
            End If
        Else
            sSQL = "SELECT DISTINCT " & UseTable & ".[Sheave Dia] FROM " & UseTable & " WHERE " & UseTable & ".MachineModel='" & UseMachineModel & "'"
        End If
        sSQL &= " ORDER BY " & UseTable & ".[Sheave Dia]"
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sSQL, ADOConnection)
        If Not TorqueRecordset.EOF Then
            Do While Not TorqueRecordset.EOF
                ReDim Preserve aMachineSheaveDiameter(i)
                If TorqueRecordset("Sheave Dia").Value.ToString = "5.91" Then
                    If UseMachineModel = MACHINE_FMM200 Then
                        AddValToArray = True
                    Else
                        AddValToArray = False
                    End If
                Else
                    AddValToArray = True
                End If
                If AddValToArray Then
                    aMachineSheaveDiameter(i) = TorqueRecordset("Sheave Dia").Value.ToString
                    i += 1
                End If
                TorqueRecordset.MoveNext()
            Loop
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        ExistingMachineSheaveDia_cmb.Items.Clear()
        For jIndx = 0 To aMachineSheaveDiameter.GetUpperBound(0)
            If Not IsNothing(aMachineSheaveDiameter(jIndx)) Then
                If FindString(ExistingMachineSheaveDia_cmb, aMachineSheaveDiameter(jIndx)) = -1 Then
                    ExistingMachineSheaveDia_cmb.Items.Add(aMachineSheaveDiameter(jIndx))
                End If
            End If
        Next jIndx

        ReDim aBrakeType(0)
        aBrakeType(0) = "Disk"
        i = 0
        Select Case CurrentMachineType
            Case "New " & GEARED_TYPE
                If NewMachineModel = "HW74" Then
                    aBrakeType(0) = "Drum"
                End If
            Case "Reuse " & GEARED_TYPE
                Select Case ExistingMachineModel
                    Case OTHER, String.Empty
                        Select Case ExistingMachineVendor
                            Case OTHER, String.Empty
                                sSQL = "SELECT DISTINCT BrakeTypes.BrakeType FROM BrakeTypes"
                            Case Else
                                sSQL = "SELECT DISTINCT BrakeTypes.BrakeType FROM SuperTable INNER JOIN BrakeTypes " &
                                       "ON SuperTable.[Brake Drum/Disk] = BrakeTypes.NewBrakeTypeID " &
                                       "WHERE SuperTable.Manufacturer='" & ExistingMachineVendor & "';"
                        End Select
                    Case Else
                        sSQL = "SELECT DISTINCT BrakeTypes.BrakeType FROM SuperTable INNER JOIN BrakeTypes " &
                               "ON SuperTable.[Brake Drum/Disk] = BrakeTypes.NewBrakeTypeID " &
                               "WHERE SuperTable.MachineModel='" & ExistingMachineModel & "';"
                End Select
                ResetADODBRecordset(TorqueRecordset)
                TorqueRecordset.Open(sSQL, ADOConnection)
                Do While Not TorqueRecordset.EOF
                    ReDim Preserve aBrakeType(i)
                    aBrakeType(i) = TorqueRecordset("BrakeType").Value.ToString
                    TorqueRecordset.MoveNext()
                    i += 1
                Loop
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
            Case MACHINE_FMM200, "New " & GEARLESS_TYPE, "Reuse " & GEARLESS_TYPE
                If NewMachineVendor <> SEC Then
                    aBrakeType(0) = "Drum"
                End If
            Case Else
                aBrakeType(0) = "Drum"
        End Select
        BrakeType_cmb.Items.Clear()
        For jIndx = 0 To aBrakeType.GetUpperBound(0)
            If FindString(BrakeType_cmb, LB_FINDSTRINGEXACT) = -1 Then
                BrakeType_cmb.Items.Add(aBrakeType(jIndx))
            End If
        Next jIndx

        If CurrentMachineType.IndexOf("Reuse") > -1 Then
            UseMachineVendor = ExistingMachineVendor
            UseMachineModel = ExistingMachineModel
        Else
            UseMachineVendor = NewMachineVendor
            UseMachineModel = NewMachineModel
        End If
        'sSQL = "SELECT RopeSizes.RopeSize, RopeSizes.MaxNumberRopes AS RopesMaximum " & "FROM RopeSizes " & "WHERE (((RopeSizes.MachineType)='" &
        '       UseMachineModel & "'));"
        Select Case UseMachineModel
            Case MACHINE_FMR355, MACHINE_PMR355, MACHINE_PMR490
                MaxNumberRopes = 8
            Case MACHINE_FM560
                MaxNumberRopes = 6
            Case MACHINE_FM630
                If HoistRopeSize = "19 mm" Then
                    MaxNumberRopes = 7
                Else
                    MaxNumberRopes = 9
                End If
            Case MACHINE_525LS
                Select Case HoistRopeSize
                    Case "1/2"
                        MaxNumberRopes = 7
                    Case "5/8"
                        MaxNumberRopes = 6
                    Case Else
                        MaxNumberRopes = 11
                End Select
            Case Else
                'If UseMachineModel = OTHER Or UseMachineModel = "" Then
                '    sSQL = "SELECT RopeSizes.RopeSize, Max(RopeSizes.MaxNumberRopes) AS RopesMaximum " &
                '           "FROM SuperTable INNER JOIN RopeSizes ON SuperTable.MachineModel = RopeSizes.MachineType " & "GROUP BY RopeSizes.RopeSize;"
                'End If
                'ResetADODBRecordset(TorqueRecordset)
                'TorqueRecordset.Open(sSQL, ADOConnection)
                'MaxNumberRopes = 2
                'Do While Not TorqueRecordset.EOF
                '    If TranslateRopeSize(HoistRopeSize, True) = "" & TorqueRecordset("RopeSize").Value Then
                '        If Conversion.Val("" & TorqueRecordset("RopesMaximum").Value) = 0 Then
                '            If CurrentMachineType.IndexOf(GEARLESS_TYPE) > -1 Then
                '                MaxNumberRopes = 11
                '            Else
                '                MaxNumberRopes = 8
                '            End If
                '            Exit Sub
                '        Else
                '            MaxNumberRopes = Conversion.Val("" & TorqueRecordset("RopesMaximum").Value)
                '        End If
                '        Exit Do
                '    End If
                '    TorqueRecordset.MoveNext()
                'Loop
                'TorqueRecordset.Close()
                'TorqueRecordset = Nothing
                'If MaxNumberRopes < 3 Then
                '    If CurrentMachineType.IndexOf(GEARLESS_TYPE) > -1 Then
                '        MaxNumberRopes = 11
                '    Else
                '        MaxNumberRopes = 8
                '    End If
                'End If
        End Select
        HoistRopeQty_Cmb.Items.Clear()
        For i = 3 To MaxNumberRopes
            HoistRopeQty_Cmb.Items.Add(i)
        Next i

        ReDim aHoistCableSize(0)
        Select Case UseMachineModel
            Case MACHINE_FMR355, MACHINE_PMR355
                aHoistCableSize(0) = "11 mm"
            Case MACHINE_PMR490
                aHoistCableSize(0) = "13 mm"
            Case MACHINE_FM560
                aHoistCableSize(0) = "16 mm"
            Case MACHINE_FM630
                ReDim aHoistCableSize(1)
                aHoistCableSize(0) = "16 mm"
                aHoistCableSize(1) = "19 mm"
            Case Else
                'Select Case CurrentMachineType
                '    Case "New" & GEARLESS_TYPE, MACHINE_FMM200
                sSQL = "SELECT DISTINCT RopeSizes.RopeSize FROM RopeSizes "
                '    Case Else
                '        sSQL = "SELECT DISTINCT RopeSizes.RopeSize FROM SuperTable INNER JOIN RopeSizes ON SuperTable.MachineModel = RopeSizes.MachineType " &
                '               "WHERE RopeSize Is Not Null AND SuperTable.MachineType='"
                '        If CurrentMachineType.IndexOf(GEARED_TYPE) > -1 Then
                '            sSQL &= GEARED_TYPE & "'"
                '        Else
                '            sSQL &= GEARLESS_TYPE & "'"
                '        End If
                '        If UseMachineVendor <> "" And UseMachineVendor <> OTHER Then
                '            sSQL &= " AND SuperTable.Manufacturer = '" & UseMachineVendor & "'"
                '        End If
                '        If UseMachineModel <> "" And UseMachineModel <> OTHER Then
                '            sSQL &= " AND RopeSizes.MachineType = '" & UseMachineModel & "'"
                '        End If
                'End Select
                ResetADODBRecordset(TorqueRecordset)
                TorqueRecordset.Open(sSQL, ADOConnection)
                If TorqueRecordset.EOF Then
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open("SELECT DISTINCT RopeSizes.RopeSize", ADOConnection)
                End If
                Do While Not TorqueRecordset.EOF
                    ReDim Preserve aHoistCableSize(i)
                    aHoistCableSize(i) = TranslateRopeSize(TorqueRecordset("RopeSize").Value.ToString, False)
                    TorqueRecordset.MoveNext()
                    i += 1
                Loop
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
        End Select
        HoistRopeSize_Cmb.Items.Clear()
        For jIndx = 0 To aHoistCableSize.GetUpperBound(0)
            If Not IsNothing(aHoistCableSize(jIndx)) Then
                HoistRopeSize_Cmb.Items.Add(aHoistCableSize(jIndx))
            End If
        Next jIndx

        Compensation_cmb.Items.Clear()
        Compensation_cmb.Items.Add("New")
        Compensation_cmb.Items.Add("Reuse")
        Compensation_cmb.Items.Add("None")

        CarSheaveQty_Cmb.Items.Clear()
        If CurrentGOData_Typ.MachineType = HYDRO_TYPE Then
            CarSheaveQty_Cmb.Items.Add(0)
        End If
        CarSheaveQty_Cmb.Items.Add(1)
        CarSheaveQty_Cmb.Items.Add(2)

        CwtSheaveQty_Cmb.Items.Clear()
        If CurrentGOData_Typ.MachineType = HYDRO_TYPE Then
            CwtSheaveQty_Cmb.Items.Add(0)
        End If
        CwtSheaveQty_Cmb.Items.Add(1)
        CwtSheaveQty_Cmb.Items.Add(2)

    End Sub
    Private Sub MachineType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineType_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub DriveType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveType_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub BillOfMaterials_spr_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles BillOfMaterials_spr.Change
        Dim ChildSheetView As New FarPoint.Win.Spread.SheetView
        Dim CurRow As Integer = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
        Dim CurMAIN_ID As String = String.Empty, NewMAT_ID As String = String.Empty, NewDesc As String = String.Empty

        If Not isInitializingComponent Then
            FormIsDirty = EstimatingDataset.HasChanges()
            If FormIsDirty Then
                ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurRow, 0)
                If Not ChildSheetView Is Nothing Then
                    CurRow = ChildSheetView.ActiveRowIndex
                    CurMAIN_ID = ChildSheetView.Cells(CurRow, MAT_COL_MAIN_ID).Text
                    NewMAT_ID = ChildSheetView.Cells(CurRow, MAT_COL_MATERIAL_ID).Text
                    If Math.Round(Conversion.Val(NewMAT_ID)) >= 900 And ChildSheetView.ActiveColumnIndex = MAT_COL_MATERIAL_DESC Then
                        NewMAT_ID = (Math.Round(Conversion.Val(Strings.Left(NewMAT_ID, 3))) + 1).ToString & Strings.Right(NewMAT_ID, 3)
                        NewDesc = SetSPRText("Description", ChildSheetView, CurRow)
                        SubGroups.Rows.Add(New Object() {NewDesc, CurMAIN_ID, NewMAT_ID, CurrentTabUnits, "", "", "", 0, 0, 0, 0, ""})
                    End If
                End If
                PopulateEstimating(False)
            End If
        End If

    End Sub
    Private Sub BillOfMaterials_spr_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles BillOfMaterials_spr.ComboCloseUp
        If Not isInitializingComponent Then
            FormIsDirty = EstimatingDataset.HasChanges()
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        CurrentTab = TabControl1.SelectedTab.Text.Trim
        CurrentTabUnits = Strings.Left(CurrentTab, CurrentTab.Length - 6)
        If Not isInitializingComponent Then
            Select Case PromptForSave()
                Case MsgBoxResult.Yes, MsgBoxResult.No, 0
                    DisplayEST_vs_ORD()
                Case Else
            End Select
        End If

    End Sub
    Private Sub DisplayEST_vs_ORD()

        If CurrentTab.IndexOf(EST_Suffix) > -1 Then
            PopulateEstimating(True)
            CarData_fra.Visible = True
            CarData_fra.BringToFront()
            If CurrentGOData_Typ.EstimateLevel = "Master" Then
                OrderingForms_fra.Visible = False
                OrderingForms_fra.SendToBack()
            End If
        ElseIf CurrentTab.IndexOf(ORD_Suffix) > -1 Then
            PopulateOrdering()
            OrderingForms_lst.Items.Clear()
            OrderingForms_lst.Items.Add("Governor")
            OrderingForms_lst.Left = 3
            OrderingForms_lst.Top = 12
            OrderingForms_lst.Height = OrderingForms_fra.Height - 6
            OrderingForms_con.Left = OrderingForms_lst.Left + OrderingForms_lst.Width + 6
            OrderingForms_con.Width = OrderingForms_fra.Width - OrderingForms_lst.Width - 18
            OrderingForms_con.Height = OrderingForms_fra.Height - 18
            OrderingForms_con.Top = OrderingForms_lst.Top
            CarData_fra.Visible = False
            CarData_fra.SendToBack()
            OrderingForms_fra.Visible = True
            OrderingForms_fra.BringToFront()
        Else
            CarData_fra.Visible = False
            CarData_fra.SendToBack()
            OrderingForms_fra.Visible = False
            OrderingForms_fra.SendToBack()
        End If

    End Sub
    Private Sub ExpensesPerDayDetails_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesPerDayDetails_btn.Click

        ExpensesPerDay_frm.ShowDialog(Me)
        ExpensesPerDay_txt.Text = FormatNumber(SubcontractedLaborCost.TotalCost, 2)
        If ExpensesPerDay_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDay_txt") Then
            GeneralInfoValueChanged(False)
        End If

    End Sub
    Private Sub PopulateEstimating(ByVal ResetData As Boolean)
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel
        Dim dt As DataTable
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim TotalCost As Single = 0, TotalStdHours As Single = 0, TotalSpecHours As Single = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            BillOfMaterials_spr.ActiveSheet.RowCount = 0
            If ResetData Then
                CreateEstimatingDataSet(CurrentTabUnits)
            End If
            Load_ListBoxes()
            model = BillOfMaterials_spr.ActiveSheet.Models.Data
            For Each dt In EstimatingDataset.Tables
                dt.DefaultView.AllowNew = False
            Next dt
            model.DataMember = "EstimatingData"
            model.DataSource = EstimatingDataset
            PopulateGeneralInfo()
            PopulateTorqueData()
            SetIsPOHController()
            BillOfMaterials_spr.ActiveSheet.GetDataView(False).AllowNew = False
            BillOfMaterials_spr.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
            BillOfMaterials_spr.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
            BillOfMaterials_spr.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
            BillOfMaterials_spr.InterfaceRenderer = Nothing
            BillOfMaterials_spr.HorizontalScrollBar.Renderer = Nothing
            BillOfMaterials_spr.VerticalScrollBar.Renderer = Nothing
            BillOfMaterials_spr.VisualStyles = FarPoint.Win.VisualStyles.Off
            BillOfMaterials_spr.ActiveSheet.Cells(0, 0, BillOfMaterials_spr.ActiveSheet.RowCount - 1, BillOfMaterials_spr.ActiveSheet.ColumnCount - 1).Font = fpFont
            BillOfMaterials_spr.ActiveSheet.Cells(0, 0, BillOfMaterials_spr.ActiveSheet.RowCount - 1, BillOfMaterials_spr.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            BillOfMaterials_spr.ActiveSheet.ColumnHeader.Cells(0, 0, 0, BillOfMaterials_spr.ActiveSheet.ColumnCount - 1).Font = fpFont
            BillOfMaterials_spr.ActiveSheet.ColumnHeader.Cells(0, 0, 0, BillOfMaterials_spr.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
            BillOfMaterials_spr.ActiveSheet.ColumnHeader.Cells(0, 0, 0, BillOfMaterials_spr.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            BillOfMaterials_spr.ActiveSheet.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
            BillOfMaterials_spr.ActiveSheet.RowHeader.Cells(0, 0, BillOfMaterials_spr.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
            BillOfMaterials_spr.ActiveSheet.RowHeader.Cells(0, 0, BillOfMaterials_spr.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
            BillOfMaterials_spr.ActiveSheet.SheetCornerStyle.BackColor = Color.DarkGray
            BillOfMaterials_spr.ActiveSheet.SetColumnWidth(MAIN_COL_MAIN_GROUP, 220)
            BillOfMaterials_spr.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_COST, 100)
            BillOfMaterials_spr.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_STD_HRS, 100)
            BillOfMaterials_spr.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_SPEC_HRS, 100)
            BillOfMaterials_spr.ActiveSheet.SetColumnVisible(1, False)
            BillOfMaterials_spr.ActiveSheet.GrayAreaBackColor = Color.White
            If SheetCornerColWidth_MAIN = 0 Then
                SheetCornerColWidth_MAIN = BillOfMaterials_spr.ActiveSheet.SheetCorner.Columns(0, 0).Width
            Else
                BillOfMaterials_spr.ActiveSheet.SheetCorner.Columns(0, 0).Width = SheetCornerColWidth_MAIN
            End If
            GeneralInformation_fra.Left = 6
            GeneralInformation_fra.Width = CarData_fra.Width - 10
            ExpensesPerDayDetails_btn.Left = ExpensesPerDay_txt.Left
            Torque_fra.Left = 6
            Torque_fra.Width = GeneralInformation_fra.Width
            BillofMaterialsandTaskList_fra.Left = 6
            BillofMaterialsandTaskList_fra.Width = GeneralInformation_fra.Width
            RelocateAndResizeAllFrames()
            BillOfMaterials_spr.Left = 6
            BillOfMaterials_spr.Visible = False
            'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
            ExpandCollapseAll("Expand")
            ExpandCollapseAll("Collapse")
            ResetADODBRecordset(UseMaterialItemRecordSet)
            UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
            If UseMaterialItemRecordSet.RecordCount > 0 Then
                BillOfMaterials_spr.Visible = True
                For iIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.RowCount - 1
                    ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView1 Is Nothing Then
                        ChildSheetView1.SetColumnVisible(MAT_COL_MAIN_ID, False)
                        ChildSheetView1.SetColumnVisible(MAT_COL_MATERIAL_ID, False)
                        ChildSheetView1.SetColumnVisible(MAT_COL_UNITS, False)
                        If SheetCornerColWidth_CHILD = 0 Then
                            SheetCornerColWidth_CHILD = ChildSheetView1.SheetCorner.Columns(0, 0).Width
                        Else
                            ChildSheetView1.SheetCorner.Columns(0, 0).Width = SheetCornerColWidth_CHILD
                        End If
                        For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                            ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_EST).CellType = SetSPRCombo("Options", ChildSheetView1, jIndex)
                            ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST).CellType = SetSPRCombo("Types", ChildSheetView1, jIndex)
                            ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).CellType = SetSPRCombo("OrderBys", ChildSheetView1, jIndex)
                            If ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Value = -999 Then
                                ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Value = Conversion.Val(SetSPRText("UnitQty", ChildSheetView1, jIndex))
                            End If
                        Next jIndex
                    End If
                    Dim ShowGroup As Boolean = False
                    Select Case BillOfMaterials_spr.ActiveSheet.GetValue(iIndex, MAT_COL_MAIN_ID)
                        Case MAIN_ID_ReuseGearedMachineACMotorOnly
                            If MachineType_cmb.Text = "Reuse " & GEARED_TYPE Then
                                ShowGroup = True
                            End If
                        Case MAIN_ID_NewGearedMachine
                            If MachineType_cmb.Text = "New " & GEARED_TYPE Then
                                ShowGroup = True
                            End If
                        Case MAIN_ID_FMM200
                            If MachineType_cmb.Text = MACHINE_FMM200 Then
                                ShowGroup = True
                            End If
                        Case MAIN_ID_ReuseGearlessMachine
                            If MachineType_cmb.Text = "Reuse " & GEARLESS_TYPE Then
                                ShowGroup = True
                            End If
                        Case MAIN_ID_NewGearlessMachine
                            If MachineType_cmb.Text = "New " & GEARLESS_TYPE Then
                                ShowGroup = True
                            End If
                        Case Else
                            ShowGroup = True
                    End Select
                    If ShowGroup Then
                        BillOfMaterials_spr.ActiveSheet.SetRowVisible(iIndex, True)
                    Else
                        BillOfMaterials_spr.ActiveSheet.SetRowVisible(iIndex, False)
                    End If
                Next iIndex
                Set_Fields_Grey_EST()
                For iIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.RowCount - 1
                    ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
                    TotalCost = 0
                    TotalStdHours = 0
                    TotalSpecHours = 0
                    If Not ChildSheetView1 Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                            If Not isInitializingComponent Then
                                ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST_EST).Value = GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text,
                                                                                                              ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_EST).Text,
                                                                                                              ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST).Text,
                                                                                                              ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text, "Cost",
                                                                                                              ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Value)
                                ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS_EST).Value = GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text,
                                                                                                               ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_EST).Text,
                                                                                                               ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST).Text,
                                                                                                               ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text, "Hours",
                                                                                                               ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Value)
                            End If
                            TotalCost += Math.Round(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST_EST).Value)
                            TotalStdHours += Math.Round(ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS_EST).Value)
                            TotalSpecHours += Math.Round(ChildSheetView1.Cells(jIndex, MAT_COL_SPECIAL_HOURS_EST).Value)
                        Next jIndex
                    End If
                    BillOfMaterials_spr.ActiveSheet.SetValue(iIndex, MAIN_COL_TOTAL_COST, TotalCost)
                    BillOfMaterials_spr.ActiveSheet.SetValue(iIndex, MAIN_COL_TOTAL_STD_HRS, TotalStdHours)
                    BillOfMaterials_spr.ActiveSheet.SetValue(iIndex, MAIN_COL_TOTAL_SPEC_HRS, TotalSpecHours)
                Next iIndex
            End If
            UseMaterialItemRecordSet.Close()
            'Else
            '    Set_Fields_Grey_EST()
            'End If
            BillOfMaterials_spr.ActiveSheet.SetActiveCell(CurParentRow, 0)
            If CurActiveChildRow <> -999 And CurActiveChildCol <> -999 Then
                BillOfMaterials_spr.ActiveSheet.ExpandRow(CurParentRow, True)
                If Not CurChildSheetView Is Nothing Then
                    CurChildSheetView.SetActiveCell(CurActiveChildRow, CurActiveChildCol)
                End If
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            UseMaterialItemRecordSet.Close()
            MessageBox.Show(Err.Description, "Error Populating Estimating", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub PopulateOrdering()

    End Sub
    Private Sub UpdateGeneralInfoDatatable()
        Dim _row As DataRow
        Dim is_new_row As Boolean = False

        Try
            If GeneralInfo.Rows.Count = 0 Then
                _row = GeneralInfo.NewRow
                is_new_row = True
            Else
                _row = GeneralInfo.Rows(0)
            End If
            _row("UnitsInTab") = SplitUnitsForSave(CurrentTabUnits)
            For Each Cntrl As Control In GeneralInformation_fra.Controls
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    _row([Cntrl].Name) = [Cntrl].Text
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    _row([Cntrl].Name) = UseDTPicker.Value.ToString("d")
                ElseIf TypeOf [Cntrl] Is CheckBox Then
                    Dim UseCheckbox As CheckBox = [Cntrl]
                    _row([Cntrl].Name) = UseCheckbox.CheckState
                End If
            Next Cntrl
            For iIndex As Integer = SubcontractedLaborCost.LaborCost.GetLowerBound(0) To SubcontractedLaborCost.LaborCost.GetUpperBound(0)
                _row(SubcontractedLaborCost.LaborCost(iIndex).Description) = SubcontractedLaborCost.LaborCost(iIndex).Cost
            Next iIndex
            If is_new_row Then
                GeneralInfo.Rows.Add(_row)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating General Information", "Updating General Information", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub UpdateTorqueDataDatatable()
        Dim _row As DataRow
        Dim is_new_row As Boolean = False

        Try
            If TorqueData.Rows.Count = 0 Then
                _row = TorqueData.NewRow
                is_new_row = True
            Else
                _row = TorqueData.Rows(0)
            End If
            _row("UnitsInTab") = SplitUnitsForSave(CurrentTabUnits)
            For Each Cntrl As Control In Torque_fra.Controls
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    _row([Cntrl].Name) = [Cntrl].Text
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    _row([Cntrl].Name) = UseDTPicker.Value.ToString("d")
                ElseIf TypeOf [Cntrl] Is CheckBox Then
                    Dim UseCheckbox As CheckBox = [Cntrl]
                    _row([Cntrl].Name) = UseCheckbox.CheckState
                End If
            Next Cntrl
            SaveTorqueEngineeringData(_row)
            If is_new_row Then
                TorqueData.Rows.Add(_row)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating Torque Data", "Updating Torque Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub SaveEstimatingData()

        Try
            UpdateGeneralInfoDatatable()
            UpdateTorqueDataDatatable()
            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, "A", FormatFileNameFromTab(CurrentTab)) & EstFileType & ".JSON"
            If Not Serialize(EST_Filename, EstimatingDataset, "Error Saving Data - " & CurrentTab, FormIsDirty) Then
                Throw New Exception
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Saving Estimating Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Sub SaveOrderingData()
        'Dim _row As DataRow
        'Dim is_new_row As Boolean = False

        Try
            'Currrent Estimating Tab
            'If GeneralInfo.Rows.Count = 0 Then
            '    _row = GeneralInfo.NewRow
            '    is_new_row = True
            'Else
            '    _row = GeneralInfo.Rows(0)
            'End If
            'For Each Cntrl As Control In Me.Controls
            '    If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
            '        _row([Cntrl].Name) = [Cntrl].Text
            '    ElseIf TypeOf [Cntrl] Is DateTimePicker Then
            '        Dim UseDTPicker As DateTimePicker = [Cntrl]
            '        _row([Cntrl].Name) = UseDTPicker.Value.ToString("d")
            '    ElseIf TypeOf [Cntrl] Is CheckBox Then
            '        Dim UseCheckbox As CheckBox = [Cntrl]
            '        _row([Cntrl].Name) = UseCheckbox.CheckState.ToString
            '    End If
            'Next Cntrl
            'For iIndex As Integer = SubcontractedLaborCost.LaborCost.GetLowerBound(0) To SubcontractedLaborCost.LaborCost.GetUpperBound(0)
            '    _row(SubcontractedLaborCost.LaborCost(iIndex).Description) = SubcontractedLaborCost.LaborCost(iIndex).Cost
            'Next iIndex
            'If is_new_row Then
            '    GeneralInfo.Rows.Add(_row)
            'End If
            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, "A",
                                                       FormatFileNameFromTab(CurrentTab)) & "MODORD.JSON"
            If Not Serialize(EST_Filename, dsOrdering, "Error Saving Data - " & CurrentTab, FormIsDirty) Then
                Throw New Exception
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Error Saving Ordering Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub Save_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_cmd.Click
        UpdateAllTotals(CurrentTabUnits)
        SaveAll()
    End Sub
    Private Sub GeneralInfoValueChanged(Optional ByVal UpdateComponents As Boolean = True)

        If Not isInitializingComponent Then
            UpdateGeneralInfoDatatable()
            Load_ListBoxes()
            'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 And UpdateComponents Then
            PopulateEstimating(False)
            'Else
            '    PopulateGeneralInfo()
            '    PopulateTorqueData()
            '    Set_Fields_Grey_EST()
            'End If
            EnableBillOfMaterials()
            FormIsDirty = True
        End If

    End Sub
    Private Sub CapacityNew_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapacityNew_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub SpeedNew_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedNew_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsTotal_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsTotal_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsFront_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsFront_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsRear_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsRear_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub PowerSupply_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerSupply_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub Application_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Application_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub LayoutRequirements_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayoutRequirements_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub DoorOperatorTypeFront_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoorOperatorTypeFront_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub CarDoorOpeningWidthFtFront_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthFtFront_txt.LostFocus
        If CarDoorOpeningWidthFtFront_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthFtFront_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningWidthInFront_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthInFront_txt.LostFocus
        If CarDoorOpeningWidthInFront_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthInFront_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningHeightFtFront_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightFtFront_txt.LostFocus
        If CarDoorOpeningHeightFtFront_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightFtFront_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningHeightInFront_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightInFront_txt.LostFocus
        If CarDoorOpeningHeightInFront_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightInFront_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub DoorOperatorTypeRear_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoorOperatorTypeRear_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub CarDoorOpeningWidthFtRear_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthFtRear_txt.LostFocus
        If CarDoorOpeningWidthFtRear_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthFtRear_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningWidthInRear_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthInRear_txt.LostFocus
        If CarDoorOpeningWidthInRear_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthInRear_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningHeightFtRear_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightFtRear_txt.LostFocus
        If CarDoorOpeningHeightFtRear_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightFtRear_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarDoorOpeningHeightInRear_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightInRear_txt.LostFocus
        If CarDoorOpeningHeightInRear_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightInRear_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub CarWeight_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarWeight_txt.LostFocus
        If CarWeight_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarWeight_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub HoistMotorHP_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles HoistMotorHP_txt.LostFocus
        If HoistMotorHP_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorHP_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub HoistMotorRpm_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistMotorRpm_txt.LostFocus
        If HoistMotorRpm_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorRpm_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub MachineLocation_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineLocation_Cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub RopingNew_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopingNew_Cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub TopFloorToOverhead_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TopFloorToOverhead_txt.LostFocus
        If TopFloorToOverhead_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TopFloorToOverhead_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub TravelNew_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravelNew_txt.LostFocus
        If TravelNew_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TravelNew_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub PitDepth_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PitDepth_txt.LostFocus
        If PitDepth_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PitDepth_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub RiserQtyFront_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiserQtyFront_Cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub RiserQtyRear_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiserQtyRear_Cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub FixtureFinish_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixtureFinish_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub DTRequestedShipDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTRequestedShipDate.ValueChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub BankCompleteDate_txt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankCompleteDate_txt.ValueChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ExistingControlVendor_lst_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExistingControlVendor_lst.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ExistingControlVendor_lst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExistingControlVendor_lst.TextChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ExistingControlModel_lst_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExistingControlModel_lst.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ExistingControlModel_lst_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExistingControlModel_lst.TextChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub OriginalGONumberAvailable_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalGONumberAvailable_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub OriginalGOnumber_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OriginalGOnumber_txt.LostFocus
        If OriginalGOnumber_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "OriginalGOnumber_txt") Then
            GeneralInfoValueChanged(False)
        End If
    End Sub
    Private Sub PEStampRequired_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEStampRequired_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ShortFloorOperation_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortFloorOperation_chk.CheckedChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub Permits_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Permits_txt.LostFocus
        If Permits_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Permits_txt") Then
            GeneralInfoValueChanged(False)
        End If
    End Sub
    Private Sub Bonds_txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bonds_txt.LostFocus
        If Bonds_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Bonds_txt") Then
            GeneralInfoValueChanged(False)
        End If
    End Sub
    Private Sub ExpensesPerDay_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesPerDay_txt.TextChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub GatewayReviewRequired_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GatewayReviewRequired_chk.CheckedChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub Destination_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Destination_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub Copy_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copy_cmd.Click
        ShowCopyMergeDialog(Copy_cmd.Tag)
    End Sub
    Private Sub Merge_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Merge_cmd.Click
        ShowCopyMergeDialog(Merge_cmd.Tag)
    End Sub
    Private Sub ShowCopyMergeDialog(ByVal CurButtonLabel As String)
        Dim iIndex As Integer = 0, AryIndex As Integer = -1

        If File.Exists(EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, "A",
                                                                 FormatFileNameFromTab(CurrentTab)) & EstFileType & ".JSON") Then
            Select Case PromptForSave()
                Case MsgBoxResult.Yes, 0
                    ArchiveFiles()
                    UnitCopyMerge_frm.Text = CurButtonLabel
                    UnitCopyMerge_frm.CurUnits = CurrentTabUnits
                    Erase UnitCopyMerge_frm.UnitOptions
                    If CurButtonLabel.Contains("Copy") Then
                        CalculateNumberOfCarsInEstimate(CurrentTabUnits)
                        UnitCopyMerge_frm.UnitOptions = UnitsInEstimate
                    ElseIf TabControl1.TabPages.Count > 1 Then
                        For iIndex = 0 To TabControl1.TabPages.Count
                            Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                            If CurTab.Text.IndexOf(EST_Suffix) > -1 And CurTab.Text <> CurrentTab Then
                                AryIndex += 1
                                ReDim Preserve UnitCopyMerge_frm.UnitOptions(AryIndex)
                                UnitCopyMerge_frm.UnitOptions(AryIndex) = Strings.Left(CurTab.Text.Trim, CurTab.Text.Length - 6)
                            End If
                        Next iIndex
                        If AryIndex = -1 Then
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                    UnitCopyMerge_frm.ShowDialog()
                    If UnitCopyMerge_frm.CopyMergeStatus = "Successful" Then
                        ArchiveFiles()
                        If CurButtonLabel.Contains("Merge") Then
                            For iIndex = TabControl1.TabPages.Count - 1 To 0 Step -1
                                Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                                If CurTab.Text = CurrentTabUnits & EST_Suffix Then
                                    TabControl1.TabPages.Remove(CurTab)
                                    Exit For
                                End If
                            Next iIndex
                            TabControl1.SelectTab(0)
                        End If
                    End If
                    DisplayEST_vs_ORD()
                Case Else
                    MsgBox("Current data for " & CurrentTab & " has not been saved!  Cannot continue until data has been saved", vbOKOnly, "No data file")
            End Select
        Else
            MsgBox("Current data for " & CurrentTab & " has not been saved!  Cannot continue until data has been saved", vbOKOnly, "No data file")
        End If

    End Sub
    Public Function PromptForSave() As DialogResult
        Dim SaveResponse As DialogResult = 0

        If FormIsDirty And AllowedToSave() Then
            If CurrentTab.ToUpper.Contains(EST_Suffix) Then
                SaveResponse = MsgBox("You must save the current Estimating Data before continuing!" & Environment.NewLine &
                                      "Do you wish to save now?", MsgBoxStyle.YesNoCancel, "Save Required")
                If SaveResponse = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    SaveEstimatingData()
                    ArchiveFiles()
                    Me.Cursor = Cursors.Default
                End If
            Else
                SaveResponse = MsgBox("You must save the current Ordering Data before continuing!" & Environment.NewLine &
                                      "Do you wish to save now?", MsgBoxStyle.YesNoCancel, "Save Required")
                If SaveResponse = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    SaveOrderingData()
                    ArchiveFiles()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
        Return SaveResponse

    End Function
    Private Sub Set_Fields_Grey_EST()
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurComboBox As ComboBox = Nothing
        Dim CurOption As String = String.Empty

        If Conversion.Val(NumberofStopsRear_cmb.Text) = 0 Then
            DoorOperatorTypeRear_lbl.Enabled = False
            DoorOperatorTypeRear_cmb.SelectedIndex = -1
            DoorOperatorTypeRear_cmb.Enabled = False
            CarDoorOpeningWidthRear_lbl.Enabled = False
            CarDoorOpeningWidthFtRear_txt.Text = String.Empty
            CarDoorOpeningWidthFtRear_txt.Enabled = False
            CarDoorOpeningWidthFtRear_lbl.Enabled = False
            CarDoorOpeningWidthInRear_txt.Text = String.Empty
            CarDoorOpeningWidthInRear_txt.Enabled = False
            CarDoorOpeningWidthInRear_lbl.Enabled = False
            CarDoorOpeningHeightRear_lbl.Enabled = False
            CarDoorOpeningHeightFtRear_txt.Text = String.Empty
            CarDoorOpeningHeightFtRear_txt.Enabled = False
            CarDoorOpeningHeightFtRear_lbl.Enabled = False
            CarDoorOpeningHeightInRear_txt.Text = String.Empty
            CarDoorOpeningHeightInRear_txt.Enabled = False
            CarDoorOpeningHeightInRear_lbl.Enabled = False
            RiserQtyRear_lbl.Enabled = False
            RiserQtyRear_Cmb.SelectedIndex = -1
            RiserQtyRear_Cmb.Enabled = False
        Else
            DoorOperatorTypeRear_lbl.Enabled = True
            DoorOperatorTypeRear_cmb.Enabled = True
            CarDoorOpeningWidthRear_lbl.Enabled = True
            CarDoorOpeningWidthFtRear_txt.Enabled = True
            CarDoorOpeningWidthFtRear_lbl.Enabled = True
            CarDoorOpeningWidthInRear_txt.Enabled = True
            CarDoorOpeningWidthInRear_lbl.Enabled = True
            CarDoorOpeningHeightRear_lbl.Enabled = True
            CarDoorOpeningHeightFtRear_txt.Enabled = True
            CarDoorOpeningHeightFtRear_lbl.Enabled = True
            CarDoorOpeningHeightInRear_txt.Enabled = True
            CarDoorOpeningHeightInRear_lbl.Enabled = True
            RiserQtyRear_lbl.Enabled = True
            RiserQtyRear_Cmb.Enabled = True
        End If
        If OriginalGONumberAvailable_cmb.Text = "Yes" Then
            OriginalGOnumber_lbl.Enabled = True
            OriginalGOnumber_txt.Enabled = True
        Else
            OriginalGOnumber_lbl.Enabled = False
            OriginalGOnumber_txt.Enabled = False
        End If
        For Each Cntrl As Control In Torque_fra.Controls
            If Not (TypeOf [Cntrl] Is Button) Then
                [Cntrl].Enabled = False
            End If
        Next Cntrl
        ChangeInCapacity_chk.Enabled = True
        ChangeInSpeed_chk.Enabled = True
        ChangeInTravel_chk.Enabled = True
        Select Case MachineType_cmb.Text
            Case "Reuse " & GEARED_TYPE
                ChangeInCapacity_chk.Enabled = False
                ChangeInCapacity_chk.CheckState = CheckState.Unchecked
                ChangeInSpeed_chk.Enabled = False
                ChangeInSpeed_chk.CheckState = CheckState.Unchecked
                ChangeInTravel_chk.Enabled = False
                ChangeInTravel_chk.CheckState = CheckState.Unchecked
                MachineVendorExisting_lbl.Enabled = True
                MachineVendorExisting_Cmb.Enabled = True
                MachineModelExisting_lbl.Enabled = True
                MachineModelExisting_cmb.Enabled = True
                ExistingMachineSheaveDia_lbl.Enabled = True
                ExistingMachineSheaveDia_cmb.Enabled = True
                ExistingMachineSheaveDiaIn_lbl.Enabled = True
                BrakeType_lbl.Enabled = True
                BrakeType_cmb.Enabled = True
                HoistRopeQty_lbl.Enabled = True
                HoistRopeQty_Cmb.Enabled = True
                HoistRopeSize_lbl.Enabled = True
                HoistRopeSize_Cmb.Enabled = True
                HoistRopeSizeIn_lbl.Enabled = True
                Compensation_lbl.Enabled = True
                Compensation_cmb.Enabled = True
                If MachineLocation_Cmb.Text = "Basement" Or MachineLocation_Cmb.Text = "Semi-Basement" Then
                    CarSheaveQty_lbl.Enabled = True
                    CarSheaveQty_Cmb.Enabled = True
                    CwtSheaveQty_lbl.Enabled = True
                    CwtSheaveQty_Cmb.Enabled = True
                End If
            Case "New " & GEARED_TYPE
                NominalMotorRPM_lbl.Enabled = True
                NominalMotorRPM_txt.Enabled = True
                HoistRopeQty_lbl.Enabled = True
                HoistRopeQty_Cmb.Enabled = True
                HoistRopeSize_lbl.Enabled = True
                HoistRopeSize_Cmb.Enabled = True
                HoistRopeSizeIn_lbl.Enabled = True
                CarToCwtRopeDrop_lbl.Enabled = True
                CarToCwtRopeDrop_txt.Enabled = True
                CarToCwtRopeDropIn_lbl.Enabled = True
                Compensation_lbl.Enabled = True
                Compensation_cmb.Enabled = True
                If MachineLocation_Cmb.Text = "Basement" Or MachineLocation_Cmb.Text = "Semi-Basement" Then
                    CarSheaveQty_lbl.Enabled = True
                    CarSheaveQty_Cmb.Enabled = True
                    CwtSheaveQty_lbl.Enabled = True
                    CwtSheaveQty_Cmb.Enabled = True
                End If
            Case MACHINE_FMM200, "New " & GEARLESS_TYPE
                HoistRopeQty_lbl.Enabled = True
                HoistRopeQty_Cmb.Enabled = True
                HoistRopeSize_lbl.Enabled = True
                HoistRopeSize_Cmb.Enabled = True
                HoistRopeSizeIn_lbl.Enabled = True
                CarToCwtRopeDrop_lbl.Enabled = True
                CarToCwtRopeDrop_txt.Enabled = True
                CarToCwtRopeDropIn_lbl.Enabled = True
                Compensation_lbl.Enabled = True
                Compensation_cmb.Enabled = True
            Case "Reuse " & GEARLESS_TYPE
                MachineVendorExisting_lbl.Enabled = True
                MachineVendorExisting_Cmb.Enabled = True
                MachineModelExisting_lbl.Enabled = True
                MachineModelExisting_cmb.Enabled = True
                ExistingMachineSheaveDia_lbl.Enabled = True
                ExistingMachineSheaveDia_cmb.Enabled = True
                ExistingMachineSheaveDiaIn_lbl.Enabled = True
                BrakeType_lbl.Enabled = True
                BrakeType_cmb.Enabled = True
                HoistRopeQty_lbl.Enabled = True
                HoistRopeQty_Cmb.Enabled = True
                HoistRopeSize_lbl.Enabled = True
                HoistRopeSize_Cmb.Enabled = True
                HoistRopeSizeIn_lbl.Enabled = True
                Compensation_lbl.Enabled = True
                Compensation_cmb.Enabled = True
                If MachineLocation_Cmb.Text = "Basement" Or MachineLocation_Cmb.Text = "Semi-Basement" Then
                    CarSheaveQty_lbl.Enabled = True
                    CarSheaveQty_Cmb.Enabled = True
                    CwtSheaveQty_lbl.Enabled = True
                    CwtSheaveQty_Cmb.Enabled = True
                End If
                FullLoadCurrentIDC1_lbl.Enabled = True
                FullLoadCurrentIDC1_txt.Enabled = True
                FullLoadCurrentIDC1Amps_lbl.Enabled = True
                ArmatureFullLoadVoltageVFLU_lbl.Enabled = True
                ArmatureFullLoadVoltageVFLU_txt.Enabled = True
                ArmatureFullLoadVoltageVFLUVolts_lbl.Enabled = True
            Case Else
        End Select
        ValidateChangeInCapacitySpeedTravel(ChangeInCapacity_chk.CheckState, CapacityExisting_lbl, CapacityExisting_cmb)
        ValidateChangeInCapacitySpeedTravel(ChangeInSpeed_chk.CheckState, SpeedExisting_lbl, SpeedExisting_cmb)
        ValidateChangeInCapacitySpeedTravel(ChangeInTravel_chk.CheckState, TravelExisting_lbl, TravelExisting_txt)
        'For Each Cntrl As Control In Torque_fra.Controls
        '    If TypeOf [Cntrl] Is ComboBox Then
        '        CurComboBox = [Cntrl]
        '        If CurComboBox.Items.Count = 1 Then
        '            isInitializingComponent = True
        '            CurComboBox.Text = CurComboBox.Items(0)
        '            isInitializingComponent = False
        '            CurComboBox.Enabled = False
        '        End If
        '    End If
        'Next Cntrl
        'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
        For iIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.RowCount - 1
            BillOfMaterials_spr.ActiveSheet.SetRowSizeable(iIndex, False)
            BillOfMaterials_spr.ActiveSheet.Cells(iIndex, MAIN_COL_MAIN_GROUP).Locked = True
            For jIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.ColumnCount - 1
                BillOfMaterials_spr.ActiveSheet.SetColumnSizeable(jIndex, False)
            Next jIndex
            ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                ChildSheetView1.LockBackColor = Color.WhiteSmoke
                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView1.SetRowSizeable(jIndex, False)
                    CurOption = String.Empty
                    For kIndex As Integer = 0 To ChildSheetView1.ColumnCount - 1
                        ChildSheetView1.SetColumnSizeable(kIndex, False)
                        Select Case kIndex
                            Case MAT_COL_MATERIAL_DESC
                                If Math.Round(Conversion.Val(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text)) >= 900 Then
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = False
                                Else
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                End If
                                ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_DESC, 365)
                            Case MAT_COL_OPTION_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_OPTION_EST, 100)
                                LockSPRComboIfMissingOptionsORSingleOption(ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_EST))
                                CurOption = ChildSheetView1.GetValue(jIndex, MAT_COL_OPTION_EST)
                            Case MAT_COL_TYPE_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_TYPE_EST, 100)
                                If CurOption = "Reuse" Or CurOption = "NA" Or String.IsNullOrEmpty(CurOption) Then
                                    ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST).Text = String.Empty
                                    ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST).Locked = True
                                Else
                                    LockSPRComboIfMissingOptionsORSingleOption(ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_EST))
                                End If
                            Case MAT_COL_ORDER_BY_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_ORDER_BY_EST, 100)
                                If CurOption = "Reuse" Or CurOption = "NA" Or String.IsNullOrEmpty(CurOption) Then
                                    ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text = String.Empty
                                    ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Locked = True
                                Else
                                    LockSPRComboIfMissingOptionsORSingleOption(ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST))
                                End If
                            Case MAT_COL_QTY_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_QTY_EST, 90)
                                If CurOption = "Reuse" Or CurOption = "NA" Or String.IsNullOrEmpty(CurOption) Then
                                    ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Value = 0
                                    ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Locked = True
                                Else
                                    ChildSheetView1.Cells(jIndex, MAT_COL_QTY_EST).Locked = False
                                End If
                            Case MAT_COL_MATERIAL_COST_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_COST_EST, 100)
                                If CurOption = "Reuse" Or CurOption = "NA" Or String.IsNullOrEmpty(CurOption) Then
                                    ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST_EST).Value = 0
                                    ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST_EST).Locked = True
                                ElseIf ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text = "RL" Or
                                       ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text = "PL" Or
                                       String.IsNullOrEmpty(ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_EST).Text) Or
                                       ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_EST).Text = "Refurbish" Then
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = False
                                Else
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                End If
                                ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS_EST, 120)
                            Case MAT_COL_STANDARD_HOURS_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS_EST, 120)
                                If CurOption = "Reuse" Or CurOption = "NA" Or String.IsNullOrEmpty(CurOption) Then
                                    ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS_EST).Value = 0
                                End If
                                ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                            Case MAT_COL_SPECIAL_HOURS_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_SPECIAL_HOURS_EST, 100)
                            Case MAT_COL_COMMENTS_EST
                                ChildSheetView1.SetColumnWidth(MAT_COL_COMMENTS_EST, 200)
                            Case Else
                                ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                        End Select
                    Next kIndex
                Next jIndex
            End If
        Next iIndex
        'End If

    End Sub
    Private Sub OrderingForms_lst_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderingForms_lst.DoubleClick
        Dim NewGovForm As New ORD_Governor_frm

        OrderingForms_con.Controls.Clear()
        NewGovForm.TopLevel = False
        NewGovForm.Left = 0
        NewGovForm.Width = OrderingForms_con.Width
        'NewGovForm.WindowState = FormWindowState.Maximized
        NewGovForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        NewGovForm.Visible = True
        OrderingForms_con.Controls.Clear()
        OrderingForms_con.Controls.Add(NewGovForm)

    End Sub
    Private Sub btnTorque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTorque.Click
        TorqueFrm.ShowDialog()
    End Sub
    Private Sub BillOfMaterials_spr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BillOfMaterials_spr.KeyDown
        Dim ChildSheetView As New FarPoint.Win.Spread.SheetView

        Select Case e.KeyCode
            Case Keys.Delete
                If Not isInitializingComponent Then
                    ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(BillOfMaterials_spr.ActiveSheet.ActiveRowIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        If Not ChildSheetView.Cells(ChildSheetView.ActiveRowIndex, ChildSheetView.ActiveColumnIndex).Locked Then
                            Select Case ChildSheetView.ActiveColumnIndex
                                Case MAT_COL_QTY_EST, MAT_COL_MATERIAL_COST_EST, MAT_COL_SPECIAL_HOURS_EST
                                    ChildSheetView.Cells(ChildSheetView.ActiveRowIndex, ChildSheetView.ActiveColumnIndex).Value = 0
                                Case Else
                                    ChildSheetView.Cells(ChildSheetView.ActiveRowIndex, ChildSheetView.ActiveColumnIndex).Value = ""
                            End Select
                            PopulateEstimating(False)
                        End If
                    End If
                    FormIsDirty = True
                End If
            Case Else
        End Select

    End Sub
    Private Sub FreezeSave_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FreezeSave_btn.Click

        If CurrentGOData_Typ.EstimateStatus = STATUS_BOOK_SUCCEEDED Then
            FreezeSave_btn.Text = "Frozen"
        ElseIf CurrentGOData_Typ.EstimateStatus = STATUS_FROZEN Then
            CurrentGOData_Typ.EstimateStatus = String.Empty
            FreezeSave_btn.Text = "Freeze"
        Else
            CurrentGOData_Typ.EstimateStatus = STATUS_FROZEN
            FreezeSave_btn.Text = "Frozen"
        End If

    End Sub
    Private Sub ExpandCollapseTorqueFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseTorqueFrame_btn.Click

        If Torque_fra.Height = ExpandCollapseTorqueFrame_btn.Height + 2 Then
            Torque_fra.Height = CurrentTorqueFrameHeight
            ExpandCollapseTorqueFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
            For Each CurControl As Control In Torque_fra.Controls
                CurControl.Visible = True
            Next CurControl
        Else
            Torque_fra.Height = ExpandCollapseTorqueFrame_btn.Height + 2
            ExpandCollapseTorqueFrame_btn.Image = Image.FromFile(ImageFileLocation & "add.png")
            For Each CurControl As Control In Torque_fra.Controls
                If CurControl.Name <> "ExpandCollapseTorqueFrame_btn" Then
                    CurControl.Visible = False
                End If
            Next CurControl
        End If
        RelocateAndResizeAllFrames()

    End Sub
    Private Sub EnableBillOfMaterials()
        Dim FrameCompleted As Boolean = True

        For Each Cntrl As Control In GeneralInformation_fra.Controls
            If [Cntrl].Enabled = True Then
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    If [Cntrl].Text.Trim.Length = 0 Then
                        FrameCompleted = False
                        Exit For
                    End If
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    If UseDTPicker.Value.ToString("d").Trim.Length = 0 Then
                        FrameCompleted = False
                        Exit For
                    End If
                End If
            End If
        Next Cntrl
        GeneralInformation_fra.Text = CurrentGenInfoFrameText
        If FrameCompleted Then
            GeneralInformation_fra.Text &= " (COMPLETED)"
        End If
        FrameCompleted = True
        For Each Cntrl As Control In Torque_fra.Controls
            If [Cntrl].Enabled = True Then
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    If [Cntrl].Text.Trim.Length = 0 Then
                        FrameCompleted = False
                        Exit For
                    End If
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    If UseDTPicker.Value.ToString("d").Trim.Length = 0 Then
                        FrameCompleted = False
                        Exit For
                    End If
                End If
            End If
        Next Cntrl
        Torque_fra.Text = CurrentTorqueFrameText
        If FrameCompleted Then
            Torque_fra.Text &= " (COMPLETED)"
        End If
        'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
        '    PopulateEstimating(False)
        '    BillofMaterialsandTaskList_fra.Enabled = True
        '    BillOfMaterials_spr.Visible = True
        'Else
        '    BillofMaterialsandTaskList_fra.Enabled = False
        '    BillOfMaterials_spr.Visible = False
        'End If

    End Sub
    Private Sub ChangeInCapacity_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeInCapacity_chk.CheckedChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ChangeInSpeed_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeInSpeed_chk.CheckedChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub ChangeInTravel_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeInTravel_chk.CheckedChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub TorqueValueChanged()

        If Not isInitializingComponent Then
            UpdateTorqueDataDatatable()
            Load_ListBoxes()
            'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
            PopulateEstimating(False)
            'Else
            '    PopulateGeneralInfo()
            '    PopulateTorqueData()
            '    Set_Fields_Grey_EST()
            'End If
            EnableBillOfMaterials()
            FormIsDirty = True
        End If

    End Sub
    Private Sub MachineVendorExisting_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineVendorExisting_Cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub MachineModelExisting_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineModelExisting_cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub ExistingMachineSheaveDia_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistingMachineSheaveDia_cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub NominalMotorRPM_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NominalMotorRPM_txt.LostFocus
        If NominalMotorRPM_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "NominalMotorRPM_txt") Then
            TorqueValueChanged()
        End If
    End Sub
    Private Sub BrakeType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrakeType_cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub HoistRopeQty_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistRopeQty_Cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub HoistRopeSize_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistRopeSize_Cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub CarToCwtRopeDrop_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarToCwtRopeDrop_txt.LostFocus
        If CarToCwtRopeDrop_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "CarToCwtRopeDrop_txt") Then
            TorqueValueChanged()
        End If
    End Sub
    Private Sub Compensation_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Compensation_cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub CarSheaveQty_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarSheaveQty_Cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub CwtSheaveQty_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CwtSheaveQty_Cmb.SelectedIndexChanged
        TorqueValueChanged()
    End Sub
    Private Sub FullLoadCurrentIDC1_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FullLoadCurrentIDC1_txt.LostFocus
        If FullLoadCurrentIDC1_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "FullLoadCurrentIDC1_txt") Then
            bMotorDependentChange = True
            TorqueValueChanged()
            bMotorDependentChange = False
        End If
    End Sub
    Private Sub ArmatureFullLoadVoltageVFLU_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArmatureFullLoadVoltageVFLU_txt.LostFocus
        If ArmatureFullLoadVoltageVFLU_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "ArmatureFullLoadVoltageVFLU_txt") Then
            TorqueValueChanged()
        End If
    End Sub
    Private Sub TravelExisting_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravelExisting_txt.LostFocus
        If TravelExisting_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TravelExisting_txt") Then
            GeneralInfoValueChanged()
        End If
    End Sub
    Private Sub PopulateGeneralInfo()
        Dim dr As DataRow

        If GeneralInfo.Rows.Count = 1 Then
            isInitializingComponent = True
            dr = GeneralInfo.Rows(0)
            For Each Cntrl As Control In GeneralInformation_fra.Controls
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    [Cntrl].Text = FindValueInDataRow([Cntrl].Name, dr)
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    UseDTPicker.Value = CDate(FindValueInDataRow([Cntrl].Name, dr))
                ElseIf TypeOf [Cntrl] Is CheckBox Then
                    Dim UseCheckbox As CheckBox = [Cntrl]
                    UseCheckbox.CheckState = Conversion.Val(FindValueInDataRow([Cntrl].Name, dr))
                End If
            Next Cntrl
            For iIndex As Integer = SubcontractedLaborCost.LaborCost.GetLowerBound(0) To SubcontractedLaborCost.LaborCost.GetUpperBound(0)
                SubcontractedLaborCost.LaborCost(iIndex).Cost = dr(SubcontractedLaborCost.LaborCost(iIndex).Description)
            Next iIndex
            isInitializingComponent = False
            'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
            TorqueMain()
            'End If
        End If

    End Sub
    Private Sub PopulateTorqueData()
        Dim dr As DataRow

        If TorqueData.Rows.Count = 1 Then
            dr = TorqueData.Rows(0)
            isInitializingComponent = True
            For Each Cntrl As Control In Torque_fra.Controls
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    [Cntrl].Text = FindValueInDataRow([Cntrl].Name, dr)
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    UseDTPicker.Value = CDate(FindValueInDataRow([Cntrl].Name, dr))
                ElseIf TypeOf [Cntrl] Is CheckBox Then
                    Dim UseCheckbox As CheckBox = [Cntrl]
                    UseCheckbox.CheckState = Conversion.Val(FindValueInDataRow([Cntrl].Name, dr))
                End If
            Next Cntrl
            isInitializingComponent = False
            'If GeneralInformation_fra.Text.IndexOf("COMPLETED") > -1 And Torque_fra.Text.IndexOf("COMPLETED") > -1 Then
            TorqueMain()
            'End If
        End If

    End Sub
    Private Sub btnLaborRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaborRates.Click

        If dtBuildingInfo.Rows(0).Item("installing_office") = "" Then
            MessageBox.Show("Please select an Installing Office to calculate Labor Rates", "Missing Installing Office", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        Try
            Using obj As New frmLaborRates
                obj.localOffice = dtBuildingInfo.Rows(0).Item("installing_office")
                obj.ShowDialog()
            End Using      ' calls dispose automatically

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Labor Rates Form", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class
