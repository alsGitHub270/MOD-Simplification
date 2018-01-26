Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json
Imports Microsoft.VisualBasic

Public Class frmEstimatingAlt
    Inherits System.Windows.Forms.Form
    Private sv As New FarPoint.Win.Spread.SheetView()
    Private svCollection As New System.Collections.ArrayList(10)
    Private isInitializingComponent As Boolean = True

    Private SheetHeaders(,) As a_SheetHeaders_typ
    Private Const TotalMaterialColumns As Integer = 15

    Private CurrentGenInfoFrameHeight As Integer = 0, CurrentTorqueFrameHeight As Integer = 0, CurrentBillofMaterialsandTaskListFrameHeight As Integer = 0
    Private CurrentGenInfoFrameColor As System.Drawing.Color = Color.White, CurrentTorqueFrameColor As System.Drawing.Color = Color.White

    Private CurParentRow As Integer = 0
    Private CurChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
    Private SheetCornerColWidth_MAIN As Integer = 0, SheetCornerColWidth_CHILD As Integer = 0

    Private Sub CreateDataSet(ByVal CurUnits As String)
        Dim iIndex As Integer = 0, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing
        Dim AddMaterial As Boolean = False
        Dim UseBaseDataRow As DataRow = Nothing, UseAltDataRow As DataRow = Nothing

        Try
            frmEstimatingBase.EstFileType = FileSuffix_BASE
            frmEstimatingBase.CreateEstimatingDataSet(CurUnits)
            AltDataset = Nothing
            AltDataset = New DataSet()
            AltDataset.EnforceConstraints = False
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
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_BASE).HeaderDesc = TABLECOL_OPTION_BASE
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_ALT).HeaderDesc = TABLECOL_OPTION_ALT
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_BASE).HeaderDesc = TABLECOL_TYPE_BASE
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_ALT).HeaderDesc = TABLECOL_TYPE_ALT
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_BASE).HeaderDesc = TABLECOL_ORDERBY_BASE
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_ALT).HeaderDesc = TABLECOL_ORDERBY_ALT
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_BASE).HeaderDesc = TABLECOL_UNITQTY_BASE
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_ALT).HeaderDesc = TABLECOL_UNITQTY_ALT
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST_ALT).HeaderDesc = TABLECOL_UNITCOST
            SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS_ALT).HeaderDesc = TABLECOL_STDHOURS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS_ALT).HeaderDesc = TABLECOL_SPECHOURS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS_ALT).HeaderDesc = TABLECOL_COMMENTS
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_BASE).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION_ALT).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_BASE).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE_ALT).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_BASE).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY_ALT).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_BASE).HeaderType = typeInt
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY_ALT).HeaderType = typeInt
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST_ALT).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS_ALT).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS_ALT).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS_ALT).HeaderType = typeStr

            ALT_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt, CurUnits) & FileSuffix_ALT & ".JSON"
            If Not File.Exists(ALT_Filename) Then
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
                            a_MaterialGroup(jIndex).OptionStrBase = Nothing
                            a_MaterialGroup(jIndex).OptionStr = Nothing
                            a_MaterialGroup(jIndex).TypeBase = Nothing
                            a_MaterialGroup(jIndex).Type = Nothing
                            a_MaterialGroup(jIndex).OrderByBase = Nothing
                            a_MaterialGroup(jIndex).OrderBy = Nothing
                            a_MaterialGroup(jIndex).QtyBase = -999
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
                        MainGroups = AltDataset.Tables.Add(TABLENAME_MAIN)
                        MainGroups.Columns.AddRange(HeaderSetup)
                        If Not IsNothing(a_MainGroup) Then
                            For jIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
                                MainGroups.Rows.Add(New Object() {a_MainGroup(jIndex).Description, a_MainGroup(jIndex).MainID})
                            Next jIndex
                        End If
                    Case MATERIAL_GROUP
                        SubGroups = AltDataset.Tables.Add(TABLENAME_MATERIALS)
                        SubGroups.Columns.AddRange(HeaderSetup)
                        If Not IsNothing(a_MaterialGroup) Then
                            For jIndex = a_MaterialGroup.GetLowerBound(0) To a_MaterialGroup.GetUpperBound(0)
                                SubGroups.Rows.Add(New Object() {a_MaterialGroup(jIndex).Description,
                                                                 a_MaterialGroup(jIndex).MainID,
                                                                 a_MaterialGroup(jIndex).MaterialID,
                                                                 a_MaterialGroup(jIndex).Units,
                                                                 a_MaterialGroup(jIndex).OptionStrBase,
                                                                 a_MaterialGroup(jIndex).OptionStr,
                                                                 a_MaterialGroup(jIndex).TypeBase,
                                                                 a_MaterialGroup(jIndex).Type,
                                                                 a_MaterialGroup(jIndex).OrderByBase,
                                                                 a_MaterialGroup(jIndex).OrderBy,
                                                                 a_MaterialGroup(jIndex).QtyBase,
                                                                 a_MaterialGroup(jIndex).Qty,
                                                                 a_MaterialGroup(jIndex).MaterialCost,
                                                                 a_MaterialGroup(jIndex).StandardHours,
                                                                 a_MaterialGroup(jIndex).SpecialHours, ""})
                            Next jIndex
                        End If
                    Case Else
                End Select
            Next iIndex
            GeneralInfo = AltDataset.Tables.Add(TABLENAME_GENERALINFO)
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

            Deserialize(ALT_Filename, AltDataset, "Error Reading Data - " & CurUnits, FormIsDirty)
            AltDataset.Relations.Add(TABLENAME_MATERIALS, MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))

            For iIndex = 0 To AltDataset.Tables.Count - 1
                For jIndex = 0 To AltDataset.Tables(iIndex).Rows.Count - 1
                    UseAltDataRow = AltDataset.Tables(iIndex).Rows(jIndex)
                    Select Case AltDataset.Tables(iIndex).TableName
                        Case TABLENAME_MATERIALS
                            UseAltDataRow(TABLECOL_OPTION_BASE) = GetValue(EstimatingDataset.Tables(TABLENAME_MATERIALS), TABLECOL_OPTION_EST,
                                                                          UseAltDataRow(TABLECOL_MAINID), UseAltDataRow(TABLECOL_MATERIALID))
                            UseAltDataRow(TABLECOL_TYPE_BASE) = GetValue(EstimatingDataset.Tables(TABLENAME_MATERIALS), TABLECOL_TYPE_EST,
                                                                          UseAltDataRow(TABLECOL_MAINID), UseAltDataRow(TABLECOL_MATERIALID))
                            UseAltDataRow(TABLECOL_ORDERBY_BASE) = GetValue(EstimatingDataset.Tables(TABLENAME_MATERIALS), TABLECOL_ORDERBY_EST,
                                                                          UseAltDataRow(TABLECOL_MAINID), UseAltDataRow(TABLECOL_MATERIALID))
                            UseAltDataRow(TABLECOL_UNITQTY_BASE) = GetValue(EstimatingDataset.Tables(TABLENAME_MATERIALS), TABLECOL_UNITQTY_EST,
                                                                          UseAltDataRow(TABLECOL_MAINID), UseAltDataRow(TABLECOL_MATERIALID))
                        Case TABLENAME_GENERALINFO
                            UseAltDataRow("UnitsInTab") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "UnitsInTab")
                            If IsDBNull(UseAltDataRow("CapacityNew_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("CapacityNew_cmb")) Then
                                UseAltDataRow("CapacityNew_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CapacityNew_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("SpeedNew_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("SpeedNew_cmb")) Then
                                UseAltDataRow("SpeedNew_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "SpeedNew_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("NumberofStopsTotal_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("NumberofStopsTotal_cmb")) Then
                                UseAltDataRow("NumberofStopsTotal_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsTotal_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("NumberofStopsFront_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("NumberofStopsFront_cmb")) Then
                                UseAltDataRow("NumberofStopsFront_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsFront_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("NumberofStopsRear_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("NumberofStopsRear_cmb")) Then
                                UseAltDataRow("NumberofStopsRear_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsRear_cmb")
                            End If
                            UseAltDataRow("PowerSupply_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PowerSupply_cmb")
                            UseAltDataRow("Application_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Application_cmb")
                            UseAltDataRow("LayoutRequirements_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "LayoutRequirements_cmb")
                            UseAltDataRow("DoorOperatorTypeFront_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DoorOperatorTypeFront_cmb")
                            UseAltDataRow("CarDoorOpeningWidthFtFront_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthFtFront_txt")
                            UseAltDataRow("CarDoorOpeningWidthInFront_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthInFront_txt")
                            UseAltDataRow("CarDoorOpeningHeightFtFront_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightFtFront_txt")
                            UseAltDataRow("CarDoorOpeningHeightInFront_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightInFront_txt")
                            UseAltDataRow("DoorOperatorTypeRear_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DoorOperatorTypeRear_cmb")
                            UseAltDataRow("CarDoorOpeningWidthFtRear_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthFtRear_txt")
                            UseAltDataRow("CarDoorOpeningWidthInRear_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningWidthInRear_txt")
                            UseAltDataRow("CarDoorOpeningHeightFtRear_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightFtRear_txt")
                            UseAltDataRow("CarDoorOpeningHeightInRear_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarDoorOpeningHeightInRear_txt")
                            If IsDBNull(UseAltDataRow("MachineType_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("MachineType_cmb")) Then
                                UseAltDataRow("MachineType_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("DriveType_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("DriveType_cmb")) Then
                                UseAltDataRow("DriveType_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DriveType_cmb")
                            End If
                            UseAltDataRow("CarWeight_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarWeight_txt")
                            UseAltDataRow("HoistMotorHP_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorHP_txt")
                            UseAltDataRow("HoistMotorRpm_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorRpm_txt")
                            UseAltDataRow("MachineLocation_Cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineLocation_Cmb")
                            If IsDBNull(UseAltDataRow("RopingNew_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("RopingNew_cmb")) Then
                                UseAltDataRow("RopingNew_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "RopingNew_cmb")
                            End If
                            If IsDBNull(UseAltDataRow("TopFloorToOverhead_txt")) OrElse String.IsNullOrEmpty(UseAltDataRow("TopFloorToOverhead_txt")) Then
                                UseAltDataRow("TopFloorToOverhead_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TopFloorToOverhead_txt")
                            End If
                            If IsDBNull(UseAltDataRow("Travel_txt")) OrElse String.IsNullOrEmpty(UseAltDataRow("Travel_txt")) Then
                                UseAltDataRow("Travel_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Travel_txt")
                            End If
                            If IsDBNull(UseAltDataRow("PitDepth_txt")) OrElse String.IsNullOrEmpty(UseAltDataRow("PitDepth_txt")) Then
                                UseAltDataRow("PitDepth_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PitDepth_txt")
                            End If
                            UseAltDataRow("RiserQtyFront_Cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "RiserQtyFront_Cmb")
                            UseAltDataRow("RiserQtyRear_Cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "RiserQtyRear_Cmb")
                            UseAltDataRow("FixtureFinish_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "FixtureFinish_cmb")
                            UseAltDataRow("DTRequestedShipDate") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DTRequestedShipDate")
                            UseAltDataRow("BankCompleteDate_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "BankCompleteDate_txt")
                            UseAltDataRow("ExistingControlVendor_lst") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExistingControlVendor_lst")
                            UseAltDataRow("ExistingControlModel_lst") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExistingControlModel_lst")
                            UseAltDataRow("OriginalGONumberAvailable_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "OriginalGONumberAvailable_cmb")
                            UseAltDataRow("OriginalGOnumber_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "OriginalGOnumber_txt")
                            UseAltDataRow("PEStampRequired_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PEStampRequired_cmb")
                            UseAltDataRow("ShortFloorOperation_chk") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ShortFloorOperation_chk")
                            UseAltDataRow("Permits_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Permits_txt")
                            UseAltDataRow("Bonds_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Bonds_txt")
                            UseAltDataRow("ExpensesPerDayZone_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayZone_txt")
                            UseAltDataRow("ExpensesPerDayParking_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayParking_txt")
                            UseAltDataRow("ExpensesPerDayOutOfTownExpenses_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayOutOfTownExpenses_txt")
                            UseAltDataRow("ExpensesPerDayTravelTime_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayTravelTime_txt")
                            UseAltDataRow("ExpensesPerDayMiscellaneous_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayMiscellaneous_txt")
                            UseAltDataRow("ExpensesPerDayTotal_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDayTotal_txt")
                            UseAltDataRow("ExpensesPerDay_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDay_txt")
                            UseAltDataRow("GatewayReviewRequired_chk") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "GatewayReviewRequired_chk")
                            If IsDBNull(UseAltDataRow("Destination_cmb")) OrElse String.IsNullOrEmpty(UseAltDataRow("Destination_cmb")) Then
                                UseAltDataRow("Destination_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Destination_cmb")
                            End If
                            UseAltDataRow("ChangeInCapacity_chk") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ChangeInCapacity_chk")
                            UseAltDataRow("CapacityExisting_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CapacityExisting_cmb")
                            UseAltDataRow("ChangeInSpeed_chk") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ChangeInSpeed_chk")
                            UseAltDataRow("SpeedExisting_cmb") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "SpeedExisting_cmb")
                            UseAltDataRow("ChangeInTravel_chk") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ChangeInTravel_chk")
                            UseAltDataRow("TravelExisting_txt") = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TravelExisting_txt")
                        Case Else
                            Exit For
                    End Select
                Next jIndex
            Next iIndex

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In Alt - CreateDataSet")

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
        For Each JSONFile In JSONFileLocation.GetFiles()
            If JSONFile IsNot Nothing Then
                If Path.GetExtension(JSONFile.ToString.ToUpper) = ".JSON" Then
                    If JSONFile.ToString.ToUpper.Contains(FileSuffix_ALT) Then
                        JSONFileList.Add(JSONFile)
                    End If
                End If
            End If
        Next JSONFile
        If JSONFileList.Count = 0 Then
            CarTab.Text = CurrentGOData_Typ.CurrentUnits & EST_Suffix
        Else
            Dim FoundFirstEstTab As Boolean = False
            For iIndex As Integer = 0 To JSONFileList.Count - 1
                UseTabName = FormatTabName(JSONFileList(iIndex).Name)
                If JSONFileList(iIndex).Name.ToUpper.Contains(FileSuffix_ALT) Then
                    If FoundFirstEstTab Then
                        TabControl1.TabPages.Add(UseTabName & ALT_Suffix)
                    Else
                        CarTab.Text = UseTabName & ALT_Suffix
                        FoundFirstEstTab = True
                    End If
                End If
            Next iIndex
        End If
        TabControl1.SelectTab(0)
        CurrentTab = TabControl1.TabPages(0).Text.Trim
        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        CurrentGenInfoFrameColor = GeneralInformation_fra.BackColor
        CurrentTorqueFrameHeight = Torque_fra.Height
        CurrentTorqueFrameColor = Torque_fra.BackColor
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
        DisplayALT()
        isInitializingComponent = False
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub frmEstimatingAlt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepareThisForm()
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
        UseMaterialItemRecordSet.Close()
        EndProgram()

    End Sub
    Private Sub CMMain_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMMain_cmd.Click
        ReturnToCM("Alt")
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
        Dim CurrentMachineType As String = GetValue(AltDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")
        Dim ExistingMachineVendor As String = GetValue(AltDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb")
        Dim ExistingMachineModel As String = GetValue(AltDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_cmb")
        Dim NewMachineVendor As String = GetValue(AltDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorNew_Cmb")
        Dim NewMachineModel As String = GetValue(AltDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb")
        Dim UseMachineVendor As String = String.Empty, UseMachineModel As String = String.Empty
        Dim HoistRopeSize As String = GetValue(AltDataset.Tables(TABLENAME_TORQUEDATA), "HoistRopeSize_Cmb")

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
        Select Case GetValue(AltDataset.Tables(TABLENAME_GENERALINFO), "ExistingControlVendor_lst")
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
    Private Sub MachineType_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MachineType_cmb.GotFocus
        ShowGeneralInfoBaseValue(MachineType_cmb)
    End Sub
    Private Sub MachineType_cmb_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineType_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub MachineType_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MachineType_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub DriveType_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DriveType_cmb.GotFocus
        ShowGeneralInfoBaseValue(DriveType_cmb)
    End Sub
    Private Sub DriveType_cmb_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveType_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub DriveType_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DriveType_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub BillOfMaterials_spr_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles BillOfMaterials_spr.Change
        Dim ChildSheetView As New FarPoint.Win.Spread.SheetView
        Dim CurRow As Integer = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
        Dim CurMAIN_ID As String = String.Empty, NewMAT_ID As String = String.Empty, NewDesc As String = String.Empty
        Dim CurUnits As String = Strings.Left(CurrentTab, CurrentTab.Length - 6)

        If Not isInitializingComponent Then
            FormIsDirty = AltDataset.HasChanges()
            If FormIsDirty Then
                ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurRow, 0)
                If Not ChildSheetView Is Nothing Then
                    CurRow = ChildSheetView.ActiveRowIndex
                    CurMAIN_ID = ChildSheetView.Cells(CurRow, MAT_COL_MAIN_ID).Text
                    NewMAT_ID = ChildSheetView.Cells(CurRow, MAT_COL_MATERIAL_ID).Text
                    If Math.Round(Conversion.Val(NewMAT_ID)) >= 900 And
                       ChildSheetView.ActiveColumnIndex = MAT_COL_MATERIAL_DESC Then
                        NewMAT_ID = (Math.Round(Conversion.Val(Strings.Left(NewMAT_ID, 3))) + 1).ToString & Strings.Right(NewMAT_ID, 3)
                        NewDesc = SetSPRText("Description", ChildSheetView, CurRow)
                        SubGroups.Rows.Add(New Object() {NewDesc, CurMAIN_ID, NewMAT_ID, CurUnits, "", "", "", 0, 0, 0, 0, ""})
                        CurRow = ChildSheetView.RowCount - 1
                        ChildSheetView.Cells(CurRow, MAT_COL_OPTION_ALT).CellType = SetSPRCombo("Options", ChildSheetView, CurRow)
                        ChildSheetView.Cells(CurRow, MAT_COL_TYPE_ALT).CellType = SetSPRCombo("Types", ChildSheetView, CurRow)
                        ChildSheetView.Cells(CurRow, MAT_COL_ORDER_BY_ALT).CellType = SetSPRCombo("OrderBys", ChildSheetView, CurRow)
                        ChildSheetView.Cells(CurRow, MAT_COL_QTY_ALT).Value = Conversion.Val(SetSPRText("UnitQty", ChildSheetView, CurRow))
                        Set_Fields_Grey_ALT()
                    End If
                End If
                RetrieveCostHours(CurRow)
            End If
        End If

    End Sub
    Private Sub BillOfMaterials_spr_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles BillOfMaterials_spr.ComboCloseUp

        SetIsPOHController()
        If Not isInitializingComponent Then
            FormIsDirty = AltDataset.HasChanges()
            If FormIsDirty Then
                RetrieveCostHours(e.Row)
            End If
        End If

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        CurrentTab = TabControl1.SelectedTab.Text.Trim
        If Not isInitializingComponent Then
            Select Case PromptForSave()
                Case MsgBoxResult.Yes, MsgBoxResult.No, 0
                    DisplayALT()
                Case Else
            End Select
        End If

    End Sub
    Private Sub DisplayALT()
        PopulateAltData(True)
        CarData_fra.Visible = True
        CarData_fra.BringToFront()
    End Sub
    Private Sub ExpensesPerDayDetails_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesPerDayDetails_btn.Click

        ExpensesPerDay_frm.ShowDialog(Me)
        ExpensesPerDay_txt.Text = FormatNumber(SubcontractedLaborCost.TotalCost, 2)
        If ExpensesPerDay_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "ExpensesPerDay_txt") Then
            GeneralInfoValueChanged(False)
        End If

    End Sub
    Private Sub BillOfMaterials_spr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BillOfMaterials_spr.Click
        CurParentRow = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
        CurChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurParentRow, 0)
    End Sub
    Private Sub RetrieveCostHours(ByVal UseRow As Integer)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurRow As Integer = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
        Dim TotalCost As Integer = 0, TotalStdHours As Integer = 0, TotalSpecHours As Integer = 0

        ChildSheetView = BillOfMaterials_spr.ActiveSheet.FindChildView(CurRow, 0)
        If Not ChildSheetView Is Nothing Then
            GetCostHours(ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView.Cells(UseRow, MAT_COL_OPTION_ALT).Text,
                         ChildSheetView.Cells(UseRow, MAT_COL_TYPE_ALT).Text, ChildSheetView.Cells(UseRow, MAT_COL_ORDER_BY_ALT).Text, "Cost",
                         ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_COST_ALT).Value, ChildSheetView.Cells(UseRow, MAT_COL_QTY_ALT).Value)
            GetCostHours(ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView.Cells(UseRow, MAT_COL_OPTION_ALT).Text,
                         ChildSheetView.Cells(UseRow, MAT_COL_TYPE_ALT).Text, ChildSheetView.Cells(UseRow, MAT_COL_ORDER_BY_ALT).Text, "Hours",
                         ChildSheetView.Cells(UseRow, MAT_COL_STANDARD_HOURS_ALT).Value, ChildSheetView.Cells(UseRow, MAT_COL_QTY_ALT).Value)
            For iIndex As Integer = 0 To ChildSheetView.RowCount - 1
                TotalCost += Math.Round(ChildSheetView.Cells(iIndex, MAT_COL_MATERIAL_COST_ALT).Value)
                TotalStdHours += Math.Round(ChildSheetView.Cells(iIndex, MAT_COL_STANDARD_HOURS_ALT).Value)
                TotalSpecHours += Math.Round(ChildSheetView.Cells(iIndex, MAT_COL_SPECIAL_HOURS_ALT).Value)
            Next iIndex
        End If
        BillOfMaterials_spr.ActiveSheet.SetValue(CurRow, MAIN_COL_TOTAL_COST, TotalCost)
        BillOfMaterials_spr.ActiveSheet.SetValue(CurRow, MAIN_COL_TOTAL_STD_HRS, TotalStdHours)
        BillOfMaterials_spr.ActiveSheet.SetValue(CurRow, MAIN_COL_TOTAL_SPEC_HRS, TotalSpecHours)

    End Sub
    Private Sub PopulateAltData(ByVal ResetData As Boolean)
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel
        Dim dt As DataTable
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim UseUnits As String = Strings.Left(CurrentTab, CurrentTab.Length - 6)
        Dim CurActiveRow As Integer = 0, CurActiveCol As Integer = 0, CurActiveChildRow As Integer = -999, CurActiveChildCol As Integer = -999

        Try
            Me.Cursor = Cursors.WaitCursor
            If BillOfMaterials_spr.ActiveSheet.RowCount > 0 Then
                CurActiveRow = BillOfMaterials_spr.ActiveSheet.ActiveRowIndex
                CurActiveCol = BillOfMaterials_spr.ActiveSheet.ActiveColumnIndex
                ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(CurActiveRow, 0)
                If Not ChildSheetView1 Is Nothing Then
                    CurActiveChildRow = ChildSheetView1.ActiveRowIndex()
                    CurActiveChildCol = ChildSheetView1.ActiveColumnIndex()
                End If
            End If
            BillOfMaterials_spr.ActiveSheet.RowCount = 0
            If ResetData Then
                CreateDataSet(UseUnits)
            End If
            Load_ListBoxes()
            model = BillOfMaterials_spr.ActiveSheet.Models.Data
            For Each dt In AltDataset.Tables
                dt.DefaultView.AllowNew = False
            Next dt
            model.DataMember = "EstimatingData"
            model.DataSource = AltDataset
            PopulateGeneralInfo()
            PopulateTorqueData()
            CapacityNewBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CapacityNew_cmb")
            SpeedNewBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "SpeedNew_cmb")
            NumberofStopsTotalBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsTotal_cmb")
            NumberofStopsFrontBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsFront_cmb")
            NumberofStopsRearBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "NumberofStopsRear_cmb")
            MachineTypeBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")
            DriveTypeBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DriveType_cmb")
            RopingNewBase_Cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "RopingNew_cmb")
            TopFloorToOverheadBase_txt.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TopFloorToOverhead_txt")
            TravelBase_txt.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Travel_txt")
            PitDepthBase_txt.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PitDepth_txt")
            DestinationBase_cmb.Text = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Destination_cmb")
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
            ExpensesPerDayDetails_btn.Left = ExpensesPerDay_txt.Left
            Torque_fra.Left = 6
            Torque_fra.Width = GeneralInformation_fra.Width
            BillofMaterialsandTaskList_fra.Left = 6
            BillofMaterialsandTaskList_fra.Width = GeneralInformation_fra.Width
            RelocateAndResizeAllFrames()
            BillOfMaterials_spr.Left = 6
            BillOfMaterials_spr.Visible = False
            ExpandCollapseAll("Expand")
            ExpandCollapseAll("Collapse")
            If GeneralInformation_fra.BackColor = FrameColorToProceed And Torque_fra.BackColor = FrameColorToProceed Then
                BillOfMaterials_spr.Visible = True
                For iIndex As Integer = 0 To BillOfMaterials_spr.ActiveSheet.RowCount - 1
                    ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView1 Is Nothing Then
                        ChildSheetView1.SetColumnVisible(MAT_COL_MAIN_ID, False)
                        ChildSheetView1.SetColumnVisible(MAT_COL_MATERIAL_ID, False)
                        ChildSheetView1.SetColumnVisible(MAT_COL_UNITS, False)
                        ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_DESC, 365)
                        ChildSheetView1.SetColumnWidth(MAT_COL_OPTION_BASE, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_OPTION_ALT, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_TYPE_BASE, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_TYPE_ALT, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_ORDER_BY_BASE, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_ORDER_BY_ALT, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_QTY_BASE, 90)
                        ChildSheetView1.SetColumnWidth(MAT_COL_QTY_ALT, 90)
                        ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_COST_ALT, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS_ALT, 120)
                        ChildSheetView1.SetColumnWidth(MAT_COL_SPECIAL_HOURS_ALT, 100)
                        ChildSheetView1.SetColumnWidth(MAT_COL_COMMENTS_ALT, 200)
                        If SheetCornerColWidth_CHILD = 0 Then
                            SheetCornerColWidth_CHILD = ChildSheetView1.SheetCorner.Columns(0, 0).Width
                        Else
                            ChildSheetView1.SheetCorner.Columns(0, 0).Width = SheetCornerColWidth_CHILD
                        End If
                        For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                            ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_ALT).CellType = SetSPRCombo("Options", ChildSheetView1, jIndex)
                            ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_ALT).CellType = SetSPRCombo("Types", ChildSheetView1, jIndex)
                            ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).CellType = SetSPRCombo("OrderBys", ChildSheetView1, jIndex)
                            If ChildSheetView1.Cells(jIndex, MAT_COL_QTY_ALT).Value = -999 Then
                                ChildSheetView1.Cells(jIndex, MAT_COL_QTY_ALT).Value = Conversion.Val(SetSPRText("UnitQty", ChildSheetView1, jIndex))
                            End If
                            If Not isInitializingComponent Then
                                GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_ALT).Text,
                                             ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_ALT).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).Text, "Cost",
                                             ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_COST_ALT).Value, ChildSheetView1.Cells(jIndex, MAT_COL_QTY_ALT).Value)
                                GetCostHours(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_ALT).Text,
                                             ChildSheetView1.Cells(jIndex, MAT_COL_TYPE_ALT).Text, ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).Text, "Hours",
                                             ChildSheetView1.Cells(jIndex, MAT_COL_STANDARD_HOURS_ALT).Value, ChildSheetView1.Cells(jIndex, MAT_COL_QTY_ALT).Value)
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
                BillOfMaterials_spr.ActiveSheet.SetActiveCell(CurActiveRow, CurActiveCol)
                If CurActiveChildRow <> -999 And CurActiveChildCol <> -999 Then
                    ChildSheetView1 = BillOfMaterials_spr.ActiveSheet.FindChildView(CurActiveRow, 0)
                    If Not ChildSheetView1 Is Nothing Then
                        ChildSheetView1.ExpandRow(CurActiveChildRow, True)
                        ChildSheetView1.SetActiveCell(CurActiveChildRow, CurActiveChildCol)
                    End If
                End If
            End If
            Set_Fields_Grey_ALT()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            UseMaterialItemRecordSet.Close()
            MessageBox.Show(Err.Description, "Error Populating Alt", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

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
            _row("UnitsInTab") = SplitUnitsForSave(Strings.Left(CurrentTab, CurrentTab.Length - 6))
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
            _row("UnitsInTab") = SplitUnitsForSave(Strings.Left(CurrentTab, CurrentTab.Length - 6))
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
    Public Sub SaveAltData()

        Try
            UpdateGeneralInfoDatatable()
            UpdateTorqueDataDatatable()
            ALT_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                       FormatFileNameFromTab(CurrentTab)) & FileSuffix_ALT & ".JSON"
            If Not Serialize(ALT_Filename, AltDataset, "Error Saving Data - " & CurrentTab, FormIsDirty) Then
                Throw New Exception
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Saving Alt Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub Save_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_cmd.Click
        UpdateAllTotals(Strings.Left(CurrentTab, CurrentTab.Length - 6))
        SaveAll()
    End Sub
    Private Sub GeneralInfoValueChanged(Optional ByVal UpdateComponents As Boolean = True)

        If Not isInitializingComponent Then
            UpdateGeneralInfoDatatable()
            Load_ListBoxes()
            isInitializingComponent = True
            If GeneralInformation_fra.BackColor = FrameColorToProceed And Torque_fra.BackColor = FrameColorToProceed And UpdateComponents Then
                PopulateAltData(False)
            Else
                PopulateGeneralInfo()
                PopulateTorqueData()
                Set_Fields_Grey_ALT()
            End If
            EnableBillOfMaterials()
            isInitializingComponent = False
            FormIsDirty = True
        End If

    End Sub
    Private Sub CapacityNew_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CapacityNew_cmb.GotFocus
        ShowGeneralInfoBaseValue(CapacityNew_cmb)
    End Sub
    Private Sub CapacityNew_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CapacityNew_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub CapacityNew_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapacityNew_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub SpeedNew_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpeedNew_cmb.GotFocus
        ShowGeneralInfoBaseValue(SpeedNew_cmb)
    End Sub
    Private Sub SpeedNew_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpeedNew_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub SpeedNew_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpeedNew_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsTotal_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsTotal_cmb.GotFocus
        ShowGeneralInfoBaseValue(NumberofStopsTotal_cmb)
    End Sub
    Private Sub NumberofStopsTotal_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsTotal_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub NumberofStopsTotal_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsTotal_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsFront_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsFront_cmb.GotFocus
        ShowGeneralInfoBaseValue(NumberofStopsFront_cmb)
    End Sub
    Private Sub NumberofStopsFront_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsFront_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub NumberofStopsFront_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsFront_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub NumberofStopsRear_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsRear_cmb.GotFocus
        ShowGeneralInfoBaseValue(NumberofStopsRear_cmb)
    End Sub
    Private Sub NumberofStopsRear_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsRear_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub NumberofStopsRear_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumberofStopsRear_cmb.SelectedIndexChanged
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
    Private Sub RopingNew_Cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RopingNew_Cmb.GotFocus
        ShowGeneralInfoBaseValue(RopingNew_Cmb)
    End Sub
    Private Sub RopingNew_Cmb_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopingNew_Cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub RopingNew_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RopingNew_Cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Private Sub TopFloorToOverhead_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TopFloorToOverhead_txt.GotFocus
        ShowGeneralInfoBaseValue(TopFloorToOverhead_txt)
    End Sub
    Private Sub TopFloorToOverhead_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TopFloorToOverhead_txt.LostFocus
        If TopFloorToOverhead_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TopFloorToOverhead_txt") Then
            GeneralInfoValueChanged()
        End If
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub TravelNew_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravelNew_txt.GotFocus
        ShowGeneralInfoBaseValue(TravelNew_txt)
    End Sub
    Private Sub TravelNew_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravelNew_txt.LostFocus
        If TravelNew_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TravelNew_txt") Then
            GeneralInfoValueChanged()
        End If
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub PitDepth_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PitDepth_txt.GotFocus
        ShowGeneralInfoBaseValue(PitDepth_txt)
    End Sub
    Private Sub PitDepth_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PitDepth_txt.LostFocus
        If PitDepth_txt.Text.Trim <> GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PitDepth_txt") Then
            GeneralInfoValueChanged()
        End If
        HideGeneralInfoBaseValue()
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
    Private Sub Destination_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Destination_cmb.GotFocus
        ShowGeneralInfoBaseValue(Destination_cmb)
    End Sub
    Private Sub Destination_cmb_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Destination_cmb.LostFocus
        HideGeneralInfoBaseValue()
    End Sub
    Private Sub Destination_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Destination_cmb.SelectedIndexChanged
        GeneralInfoValueChanged()
    End Sub
    Public Function PromptForSave() As DialogResult
        Dim SaveResponse As DialogResult = 0

        If FormIsDirty And AllowedToSave() Then
            SaveResponse = MsgBox("You must save the current Alt Data before continuing!" & Environment.NewLine &
                                 "Do you wish to save now?", MsgBoxStyle.YesNoCancel, "Save Required")
            If SaveResponse = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                SaveAltData()
                ArchiveFiles()
                Me.Cursor = Cursors.Default
            End If
        End If
        Return SaveResponse

    End Function
    Private Sub Set_Fields_Grey_ALT()
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        If Conversion.Val(NumberofStopsRear_cmb.Text) = 0 Then
            DoorOperatorTypeRear_cmb.SelectedIndex = -1
            CarDoorOpeningWidthFtRear_txt.Text = String.Empty
            CarDoorOpeningWidthInRear_txt.Text = String.Empty
            CarDoorOpeningHeightFtRear_txt.Text = String.Empty
            CarDoorOpeningHeightInRear_txt.Text = String.Empty
            RiserQtyRear_Cmb.SelectedIndex = -1
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
        If GeneralInformation_fra.BackColor = FrameColorToProceed And Torque_fra.BackColor = FrameColorToProceed Then
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
                        For kIndex As Integer = 0 To ChildSheetView1.ColumnCount - 1
                            ChildSheetView1.SetColumnSizeable(kIndex, False)
                            Select Case kIndex
                                Case MAT_COL_MATERIAL_DESC
                                    If Math.Round(Conversion.Val(ChildSheetView1.Cells(jIndex, MAT_COL_MATERIAL_ID).Text)) >= 900 Then
                                        ChildSheetView1.Cells(jIndex, kIndex).Locked = False
                                    Else
                                        ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                    End If
                                Case MAT_COL_STANDARD_HOURS_ALT
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                Case MAT_COL_OPTION_ALT, MAT_COL_TYPE_ALT, MAT_COL_ORDER_BY_ALT
                                    LockSPRComboIfMissingOptionsORSingleOption(ChildSheetView1.Cells(jIndex, kIndex))
                                Case MAT_COL_MATERIAL_COST_ALT
                                    If ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).Text = "RL" Or
                                       ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).Text = "PL" Or
                                       String.IsNullOrEmpty(ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY_ALT).Text) Or
                                       ChildSheetView1.Cells(jIndex, MAT_COL_OPTION_ALT).Text = "Refurbish" Then
                                        ChildSheetView1.Cells(jIndex, kIndex).Locked = False
                                    Else
                                        ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                    End If
                                Case MAT_COL_OPTION_BASE, MAT_COL_TYPE_BASE, MAT_COL_ORDER_BY_BASE, MAT_COL_QTY_BASE
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = True
                                Case Else
                                    ChildSheetView1.Cells(jIndex, kIndex).Locked = False
                            End Select
                        Next kIndex
                    Next jIndex
                End If
            Next iIndex
        End If

    End Sub
    Private Sub LockSPRComboIfMissingOptionsORSingleOption(ByRef CurCell As FarPoint.Win.Spread.Cell)
        Dim CurCmb As FarPoint.Win.Spread.CellType.ComboBoxCellType = CurCell.CellType

        If IsNothing(CurCmb) Then
            CurCell.Locked = True
        ElseIf CurCmb.Items.Count = 0 Then
            CurCell.Locked = True
        ElseIf CurCmb.Items.Count = 1 Then
            CurCell.Text = CurCmb.Items(0)
            CurCell.Locked = True
        Else
            CurCell.Locked = False
        End If

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
                        Select Case ChildSheetView.ActiveColumnIndex
                            Case MAT_COL_QTY_EST, MAT_COL_MATERIAL_COST_EST, MAT_COL_STANDARD_HOURS_EST, MAT_COL_SPECIAL_HOURS_EST
                                ChildSheetView.Cells(ChildSheetView.ActiveRowIndex, ChildSheetView.ActiveColumnIndex).Value = 0
                            Case Else
                                ChildSheetView.Cells(ChildSheetView.ActiveRowIndex, ChildSheetView.ActiveColumnIndex).Value = ""
                        End Select
                    End If
                    RetrieveCostHours(ChildSheetView.ActiveRowIndex)
                    FormIsDirty = True
                End If
            Case Else
        End Select

    End Sub
    Private Sub ShowGeneralInfoBaseValue(ByVal CurControl As Control)
        Dim UseControlName As String = Strings.Left(CurControl.Name, CurControl.Name.Length - 4)
        Dim UseBaseControlName As String = String.Empty

        For Each BaseControl As Control In GeneralInformationBase_fra.Controls
            UseBaseControlName = Strings.Left(BaseControl.Name, BaseControl.Name.Length - 8)
            If UseBaseControlName.ToUpper = UseControlName.ToUpper Then
                BaseControl.Visible = True
                If Strings.Right(BaseControl.Name, 3) = "lbl" Then
                    BaseControl.Left = 7
                    BaseControl.Top = 13
                Else
                    BaseControl.Left = 143
                    BaseControl.Top = 10
                End If
            Else
                BaseControl.Visible = False
            End If
        Next BaseControl
        If CurControl.Left > 900 Then
            GeneralInformationBase_fra.Left = CurControl.Left - CurControl.Width - 3
        Else
            GeneralInformationBase_fra.Left = CurControl.Left + CurControl.Width + 3
        End If
        GeneralInformationBase_fra.Top = CurControl.Top
        GeneralInformationBase_fra.Visible = True
        GeneralInformationBase_fra.BringToFront()

    End Sub
    Private Sub HideGeneralInfoBaseValue()
        GeneralInformationBase_fra.Left = 1329
        GeneralInformationBase_fra.Top = 10
        GeneralInformationBase_fra.Visible = False
        GeneralInformationBase_fra.SendToBack()
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
        Dim UseBackColor As System.Drawing.Color = FrameColorToProceed

        For Each Cntrl As Control In GeneralInformation_fra.Controls
            If [Cntrl].Enabled = True Then
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    If [Cntrl].Text.Trim.Length = 0 Then
                        UseBackColor = CurrentGenInfoFrameColor
                        Exit For
                    End If
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    If UseDTPicker.Value.ToString("d").Trim.Length = 0 Then
                        UseBackColor = CurrentGenInfoFrameColor
                        Exit For
                    End If
                End If
            End If
        Next Cntrl
        GeneralInformation_fra.BackColor = UseBackColor
        For Each Cntrl As Control In GeneralInformation_fra.Controls
            If Not (TypeOf [Cntrl] Is Button) Then
                [Cntrl].BackColor = UseBackColor
            End If
        Next Cntrl
        UseBackColor = FrameColorToProceed
        For Each Cntrl As Control In Torque_fra.Controls
            If [Cntrl].Enabled = True Then
                If TypeOf [Cntrl] Is ComboBox Or TypeOf [Cntrl] Is TextBox Then
                    If [Cntrl].Text.Trim.Length = 0 Then
                        UseBackColor = CurrentGenInfoFrameColor
                        Exit For
                    End If
                ElseIf TypeOf [Cntrl] Is DateTimePicker Then
                    Dim UseDTPicker As DateTimePicker = [Cntrl]
                    If UseDTPicker.Value.ToString("d").Trim.Length = 0 Then
                        UseBackColor = CurrentGenInfoFrameColor
                        Exit For
                    End If
                End If
            End If
        Next Cntrl
        Torque_fra.BackColor = UseBackColor
        For Each Cntrl As Control In Torque_fra.Controls
            If Not (TypeOf [Cntrl] Is Button) Then
                [Cntrl].BackColor = UseBackColor
            End If
        Next Cntrl
        If GeneralInformation_fra.BackColor = FrameColorToProceed And Torque_fra.BackColor = FrameColorToProceed Then
            PopulateAltData(False)
            BillofMaterialsandTaskList_fra.Enabled = True
            BillOfMaterials_spr.Visible = True
        Else
            BillofMaterialsandTaskList_fra.Enabled = False
            BillOfMaterials_spr.Visible = False
        End If

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
            isInitializingComponent = True
            If GeneralInformation_fra.BackColor = FrameColorToProceed And Torque_fra.BackColor = FrameColorToProceed Then
                PopulateAltData(False)
            Else
                PopulateGeneralInfo()
                PopulateTorqueData()
                Set_Fields_Grey_ALT()
            End If
            EnableBillOfMaterials()
            isInitializingComponent = False
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
        End If

    End Sub
    Private Sub PopulateTorqueData()
        Dim dr As DataRow

        If TorqueData.Rows.Count = 1 Then
            dr = TorqueData.Rows(0)
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
            TorqueMain()
        End If

    End Sub
End Class
