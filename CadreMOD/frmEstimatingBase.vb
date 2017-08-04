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

    ' Material ID's in table ***********************************************************************
    Public Const Controller As String = "00CON"
    Public Const SecurityPackage As String = "01CON"
    Public Const InterGroupEmergencyPower As String = "02CON"
    Public Const TractionBatteryLowering As String = "03CON"
    Public Const CodeBlueOption As String = "04CON"
    Public Const PanicFeatureRiotControl As String = "05CON"
    Public Const CodePinkOption As String = "06CON"
    Public Const InconspicuousRiser As String = "07CON"
    Public Const ReuseGearedACMotor As String = "00RGD"
    Public Const MotorAdapterPlateKit As String = "01RGD"
    Public Const ReuseGearedMachineRefurbishmentWork As String = "02RGD"
    Public Const BrakeWork As String = "03RGD"
    Public Const NitroCleaning As String = "04RGD"
    Public Const Machine As String = "00NGD"
    Public Const NewGearedACMotor As String = "01NGD"
    Public Const NewGearedBrakeSwitch As String = "02NGD"
    Public Const MachineIsolation As String = "03NGD"
    Public Const NewGearedSheaves As String = "04NGD"
    Public Const NewGearedSheaveGuard As String = "05NGD"
    Public Const BedPlate As String = "06NGD"
    Public Const FMM200Machine As String = "00FMM"
    Public Const BlockingAssembly As String = "01FMM"
    Public Const STM As String = "02FMM"
    Public Const KSSContacts As String = "03FMM"
    Public Const CarAdapter As String = "04FMM"
    Public Const CwtAdapter As String = "05FMM"
    Public Const Encoder As String = "00RGL"
    Public Const Sheave As String = "01RGL"
    Public Const ReuseGearlessSheaveGuard As String = "02RGL"
    Public Const ReuseGearlessBrakeSwitch As String = "03RGL"
    Public Const BrakeWorkforreuserefurbish As String = "04RGL"
    Public Const NitroCleaningforreuserefurbish As String = "05RGL"
    Public Const ReuseGearlessMachineRefurbishmentWork As String = "06RGL"
    Public Const NewGearlessMachine As String = "00NGL"
    Public Const MachineBedplateIsolation As String = "01NGL"
    Public Const NewGearlessSheaves As String = "02NGL"
    Public Const SheaveGuard As String = "03NGL"
    Public Const MachineDisassembly As String = "04NGL"
    Public Const Governor As String = "00GOV"
    Public Const GovernorMountingSlaborRail As String = "01GOV"
    Public Const GovernorEncoder As String = "02GOV"
    Public Const GovernorCwt As String = "03GOV"
    Public Const RopeGripper As String = "00ACU"
    Public Const RopeGripperMountingKit As String = "01ACU"
    Public Const CarTopMaintenanceStation As String = "00CAR"
    Public Const SALSISLevelingUnit As String = "01CAR"
    Public Const ETSETSL As String = "02CAR"
    Public Const LoadWeighingDevice As String = "03CAR"
    Public Const CarDuct As String = "04CAR"
    Public Const OKRCarTopBox As String = "05CAR"
    Public Const ToeGuard As String = "06CAR"
    Public Const FrontCarDoorOperatorPackage As String = "00DOP"
    Public Const FrontCarDoorOperator As String = "01DOP"
    Public Const FrontClutch As String = "02DOP"
    Public Const FrontCarDoorTrack As String = "03DOP"
    Public Const FrontCarDoorHanger As String = "04DOP"
    Public Const FrontCarDoorGateSwitch As String = "05DOP"
    Public Const RearCarDoorOperatorPackage As String = "06DOP"
    Public Const RearCarDoorOperator As String = "07DOP"
    Public Const RearClutch As String = "08DOP"
    Public Const RearCarDoorTrack As String = "09DOP"
    Public Const RearCarDoorHanger As String = "10DOP"
    Public Const RearCarDoorGateSwitch As String = "11DOP"
    Public Const DoorRestrictor As String = "12DOP"
    Public Const DoorDetectors As String = "13DOP"
    Public Const RollerGuidesCar As String = "00RGS"
    Public Const CarRollerGuideAdapterPlate As String = "01RGS"
    Public Const NewCabComplete As String = "00PAS"
    Public Const CabShell As String = "01PAS"
    Public Const CeilingLighting As String = "02PAS"
    Public Const EmergencyLightCanopyType As String = "03PAS"
    Public Const CabReturns As String = "04PAS"
    Public Const CabPanels As String = "05PAS"
    Public Const CarDoor As String = "06PAS"
    Public Const Handrails As String = "07PAS"
    Public Const CarSill As String = "08PAS"
    Public Const Fan As String = "09PAS"
    Public Const EmergencyExitSwitch As String = "10PAS"
    Public Const CabFlooring As String = "11PAS"
    Public Const Subflooring As String = "12PAS"
    Public Const CabPads As String = "13PAS"
    Public Const CarTopHandRail As String = "14PAS"
    Public Const CarPlatform As String = "15PAS"
    Public Const CarSling As String = "16PAS"
    Public Const IsolationPads As String = "17PAS"
    Public Const CarSafety As String = "18PAS"
    Public Const FreightEnclosure As String = "00FRT"
    Public Const Gate As String = "01FRT"
    Public Const HoistwayFrame As String = "00LND"
    Public Const HoistwayDoor As String = "01LND"
    Public Const HoistwayDoorTracks As String = "02LND"
    Public Const NylonTrackInserts As String = "03LND"
    Public Const HoistwayDoorHangers As String = "04LND"
    Public Const HoistwayDoorRollers As String = "05LND"
    Public Const InterlocksandPickups As String = "06LND"
    Public Const DoorClosers As String = "07LND"
    Public Const Escutheons As String = "08LND"
    Public Const HoistwayDoorGibs As String = "09LND"
    Public Const FireTabs As String = "10LND"
    Public Const SightGuard As String = "11LND"
    Public Const Astragals As String = "12LND"
    Public Const HoistwaySill As String = "13LND"
    Public Const Struts As String = "14LND"
    Public Const HoistwayHeaders As String = "15LND"
    Public Const HoistwayDoorPackage As String = "16LND"
    Public Const FreightDoorPackage As String = "17LND"
    Public Const TravellingCableHoistwayWiring As String = "00HST"
    Public Const HoistwayDuct As String = "01HST"
    Public Const TravelCableHangers As String = "02HST"
    Public Const HoistRopes As String = "03HST"
    Public Const STMs As String = "04HST"
    Public Const AntitwistDevice As String = "05HST"
    Public Const STMCarCwtAdapter As String = "06HST"
    Public Const Shackles As String = "07HST"
    Public Const CarGovernorRope As String = "08HST"
    Public Const CwtGovernorRope As String = "09HST"
    Public Const CarSheaveandGuard As String = "10HST"
    Public Const CwtSheaveandGuard As String = "11HST"
    Public Const RollerGuidesCwt As String = "12HST"
    Public Const CwtRollerGuideAdapterPlate As String = "13HST"
    Public Const SeismicSwitch As String = "14HST"
    Public Const SeismicEquipment As String = "15HST"
    Public Const GuideRails As String = "16HST"
    Public Const RailBrackets As String = "17HST"
    Public Const CounterweightFrame As String = "18HST"
    Public Const CounterweightSubWeights As String = "19HST"
    Public Const CwtSafety As String = "20HST"
    Public Const HoistwayScreening As String = "21HST"
    Public Const HoistwayLimitSwitch As String = "22HST"
    Public Const Fascia As String = "23HST"
    Public Const RopeSplayClamp As String = "24HST"
    Public Const MainCarStation As String = "00FIX"
    Public Const AuxCarStation As String = "01FIX"
    Public Const CarTravelingLantern As String = "02FIX"
    Public Const CarPositionIndicatorInTransom As String = "03FIX"
    Public Const VoiceAnnunciator As String = "04FIX"
    Public Const HandsFreePhone As String = "05FIX"
    Public Const HallStations As String = "06FIX"
    Public Const HallPositionIndicator As String = "07FIX"
    Public Const HallLantern As String = "08FIX"
    Public Const HallPILanternCombo As String = "09FIX"
    Public Const HoistwayAccessSwitch As String = "10FIX"
    Public Const FERSwitch As String = "11FIX"
    Public Const InconspicuousRisers As String = "12FIX"
    Public Const JambBraille As String = "13FIX"
    Public Const EmergencyPowerPanel As String = "14FIX"
    Public Const StatusPanel As String = "15FIX"
    Public Const LobbyVision As String = "16FIX"
    Public Const IntercomSystem As String = "17FIX"
    Public Const CarBuffer As String = "00PIT"
    Public Const CarBufferBlocking As String = "01PIT"
    Public Const CarBufferFootingChannels As String = "02PIT"
    Public Const CwtBuffer As String = "03PIT"
    Public Const CwtBufferBlocking As String = "04PIT"
    Public Const CWTBufferFootingChannels As String = "05PIT"
    Public Const BufferSwitch As String = "06PIT"
    Public Const GovernorTensionSheaveCar As String = "07PIT"
    Public Const GovernorTensionSheaveCwt As String = "08PIT"
    Public Const PitSwitch As String = "09PIT"
    Public Const PitLadder As String = "10PIT"
    Public Const PitLight As String = "11PIT"
    Public Const WhisperFlex As String = "12PIT"
    Public Const SwayDevice As String = "13PIT"
    Public Const CompensationRope As String = "14PIT"
    Public Const CompensationSheave As String = "15PIT"
    Public Const CompensationSwitch As String = "16PIT"
    Public Const CounterweightGuard As String = "17PIT"
    Public Const CleaningandPainting As String = "00MSC"
    Public Const SAISInspection As String = "01MSC"
    Public Const ConsultantGSAInspection As String = "02MSC"
    Public Const FireServiceEPTesting As String = "03MSC"
    Public Const MachineRoomSpecialAccess As String = "04MSC"
    Public Const Miscellaneous As String = "05MSC"
    Public Const FrontRecladding As String = "00SUB"
    Public Const FireAlarmSystem As String = "01SUB"
    Public Const ElectricalWork As String = "02SUB"
    Public Const CabWork As String = "03SUB"
    Public Const BuildingGCWork As String = "04SUB"
    Public Const Crane As String = "05SUB"

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
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderDesc = "Unit Qty"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderDesc = "Unit Material Cost"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderDesc = "Unit Standard Hours"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderDesc = "Unit Special Hours"
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
    Private Sub PrepareThisForm()
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
        GeneralInformation_fra.Width = CarData_fra.Width - GeneralInformation_fra.Left - 10
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        BillofMaterialsandTaskList_fra.Left = 6
        BillofMaterialsandTaskList_fra.Width = CarData_fra.Width - BillofMaterialsandTaskList_fra.Left - 10
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
                ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS, 120)
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
        CarTab.Text = "EST: 01-03"
        OrderTab.Text = "ORD: 01-03"
        TabControl1.SelectTab(0)
        DisplayEST_vs_ORD()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub frmEstimatingBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepareThisForm()
    End Sub
    Private Sub FpSpread1_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs) Handles FpSpread1.ChildViewCreated

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
    Private Sub ExpandAll_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandAll_cmd.Click
        ExpandCollapseAll("Expand")
    End Sub
    Private Sub CollapseAll_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseAll_cmd.Click
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
            For Each CurControl As Control In GeneralInformation_fra.Controls
                CurControl.Visible = True
            Next CurControl
        Else
            GeneralInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\add.png")
            For Each CurControl As Control In GeneralInformation_fra.Controls
                If CurControl.Name <> "ExpandCollapseFrame_btn" Then
                    CurControl.Visible = False
                End If
            Next CurControl
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

        '***************** Estimating **********************
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

        SpeedNew_cmb.Items.Clear()
        Select Case MachineType
            Case HYDRO_TYPE
                For i As Integer = 50 To 200 Step 25
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

        NumberofStopsTotal_cmb.Items.Clear()
        For i As Integer = MIN_BLDG_FLRS To MAX_BLDG_FLRS
            NumberofStopsTotal_cmb.Items.Add(i)
        Next i

        NumberofStopsFront_cmb.Items.Clear()
        For i As Integer = MIN_BLDG_FLRS To MAX_BLDG_FLRS
            NumberofStopsFront_cmb.Items.Add(i)
        Next i

        NumberofStopsRear_cmb.Items.Clear()
        For i As Integer = MIN_BLDG_FLRS To MAX_BLDG_FLRS
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

        LayoutEntranceDrawing_cmb.Items.Clear()
        LayoutEntranceDrawing_cmb.Items.Add("Record Only")
        LayoutEntranceDrawing_cmb.Items.Add("Approval")
        LayoutEntranceDrawing_cmb.Items.Add("Machine Room")
        LayoutEntranceDrawing_cmb.Items.Add("Full")

        MachineType_cmb.Items.Clear()
        MachineType_cmb.Items.Add(GEARED_TYPE)
        MachineType_cmb.Items.Add(GEARLESS_TYPE)

        DriveType_cmb.Items.Clear()
        DriveType_cmb.Items.Add(AC_TYPE)
        DriveType_cmb.Items.Add(AC_REGEN_TYPE)
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

        RiserQtyExistingFront_Cmb.Items.Clear()
        RiserQtyExistingFront_Cmb.Items.Add("0")
        RiserQtyExistingFront_Cmb.Items.Add("1")
        RiserQtyExistingFront_Cmb.Items.Add("2")
        RiserQtyExistingFront_Cmb.Items.Add("3")
        RiserQtyExistingFront_Cmb.Items.Add("4")

        RiserQtyExistingRear_Cmb.Items.Clear()
        RiserQtyExistingRear_Cmb.Items.Add("0")
        RiserQtyExistingRear_Cmb.Items.Add("1")
        RiserQtyExistingRear_Cmb.Items.Add("2")
        RiserQtyExistingRear_Cmb.Items.Add("3")
        RiserQtyExistingRear_Cmb.Items.Add("4")

        FixtureFinish_cmb.Items.Clear()
        FixtureFinish_cmb.Items.Add(FINISH_4SS)
        FixtureFinish_cmb.Items.Add(FINISH_4BZ)
        FixtureFinish_cmb.Items.Add(FINISH_8SS)
        FixtureFinish_cmb.Items.Add(FINISH_8BZ)

        ExistingControlVendor_lst.Items.Clear()
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "OEM_SQL")
        While Not MaterialItemRecordSet.EOF
            ExistingControlVendor_lst.Items.Add(MaterialItemRecordSet("Manufacturer").Value.ToString)
            MaterialItemRecordSet.MoveNext()
        End While
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)

        ExistingControlModel_lst.Items.Clear()
        Select Case ExistingControlVendor_lst.Text
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

        '********************* Ordering **************************
        CarGovernorNewModel_cmb.Items.Clear()
        If Conversion.Val(SpeedNew_cmb.Text) > 800 Then
            CarGovernorNewModel_cmb.Items.Add("GB 32")
            CarGovernorNewModel_cmb.Items.Add("GB 42")
        Else
            CarGovernorNewModel_cmb.Items.Add("HW202")
            CarGovernorNewModel_cmb.Items.Add("HW207")
            CarGovernorNewModel_cmb.Items.Add("HW210")
        End If

        CarGovernorExistingVendor_cmb.Items.Clear()
        CarGovernorExistingVendor_cmb.Items.Add(WESTINGHOUSE)
        CarGovernorExistingVendor_cmb.Items.Add(HAUGHTON)
        CarGovernorExistingVendor_cmb.Items.Add(HOLLISTERWHITNEY)
        CarGovernorExistingVendor_cmb.Items.Add(VILLARES)
        CarGovernorExistingVendor_cmb.Items.Add(OTHER)

        CarGovernorExistingModel_cmb.Items.Clear()
        Select Case CarGovernorExistingVendor_cmb.Text
            Case WESTINGHOUSE
                CarGovernorExistingModel_cmb.Items.Add("B5")
                CarGovernorExistingModel_cmb.Items.Add("B22")
                CarGovernorExistingModel_cmb.Items.Add("W5")
            Case HAUGHTON
                CarGovernorExistingModel_cmb.Items.Add("16 Series")
                CarGovernorExistingModel_cmb.Items.Add("12I")
            Case HOLLISTERWHITNEY
                CarGovernorExistingModel_cmb.Items.Add("HW201")
                CarGovernorExistingModel_cmb.Items.Add("HW205")
                CarGovernorExistingModel_cmb.Items.Add("HW206")
                CarGovernorExistingModel_cmb.Items.Add("HW208")
                CarGovernorExistingModel_cmb.Items.Add("HW209")
            Case VILLARES
                CarGovernorExistingModel_cmb.Items.Add("B5")
                CarGovernorExistingModel_cmb.Items.Add("B22")
            Case Else
        End Select
        CarGovernorExistingModel_cmb.Items.Add(OTHER)

        CarGovCableSize_cmb.Items.Clear()
        CarGovCableSize_cmb.Items.Add("3/8")
        CarGovCableSize_cmb.Items.Add("1/2")

        CarGovernor1Hand_cmb.Items.Clear()
        CarGovernor1Hand_cmb.Items.Add("Left Hand")
        CarGovernor1Hand_cmb.Items.Add("Right Hand")

        CarGovernorMounting_cmb.Items.Clear()
        CarGovernorMounting_cmb.Items.Add("Slab")
        CarGovernorMounting_cmb.Items.Add("Rail")

        CarGovernorExistingSheaveDiameter_cmb.Items.Clear()
        If CarGovernorExistingModel_cmb.Text = "B22" Then
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("22.00")
        Else
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("12.00")
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("16.00")
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("Other")
        End If

        CwtGovernorNewModel_cmb.Items.Clear()
        If Conversion.Val(SpeedNew_cmb.Text) > 800 Then
            CwtGovernorNewModel_cmb.Items.Add("GB 32")
            CwtGovernorNewModel_cmb.Items.Add("GB 42")
        Else
            CwtGovernorNewModel_cmb.Items.Add("HW202")
            CwtGovernorNewModel_cmb.Items.Add("HW207")
            CwtGovernorNewModel_cmb.Items.Add("HW210")
        End If

        CwtGovernorExistingVendor_cmb.Items.Clear()
        CwtGovernorExistingVendor_cmb.Items.Add(WESTINGHOUSE)
        CwtGovernorExistingVendor_cmb.Items.Add(HAUGHTON)
        CwtGovernorExistingVendor_cmb.Items.Add(HOLLISTERWHITNEY)
        CwtGovernorExistingVendor_cmb.Items.Add(VILLARES)
        CwtGovernorExistingVendor_cmb.Items.Add(OTHER)

        CwtGovernorExistingModel_cmb.Items.Clear()
        Select Case CwtGovernorExistingVendor_cmb.Text
            Case WESTINGHOUSE
                CwtGovernorExistingModel_cmb.Items.Add("B5")
                CwtGovernorExistingModel_cmb.Items.Add("B22")
                CwtGovernorExistingModel_cmb.Items.Add("W5")
            Case HAUGHTON
                CwtGovernorExistingModel_cmb.Items.Add("16 Series")
                CwtGovernorExistingModel_cmb.Items.Add("12I")
            Case HOLLISTERWHITNEY
                CwtGovernorExistingModel_cmb.Items.Add("HW201")
                CwtGovernorExistingModel_cmb.Items.Add("HW205")
                CwtGovernorExistingModel_cmb.Items.Add("HW206")
                CwtGovernorExistingModel_cmb.Items.Add("HW208")
                CwtGovernorExistingModel_cmb.Items.Add("HW209")
            Case VILLARES
                CwtGovernorExistingModel_cmb.Items.Add("B5")
                CwtGovernorExistingModel_cmb.Items.Add("B22")
            Case Else
        End Select
        CwtGovernorExistingModel_cmb.Items.Add(OTHER)

        CwtGovCableSize_cmb.Items.Clear()
        CwtGovCableSize_cmb.Items.Add("3/8")
        CwtGovCableSize_cmb.Items.Add("1/2")

        CwtGovernor1Hand_cmb.Items.Clear()
        CwtGovernor1Hand_cmb.Items.Add("Left Hand")
        CwtGovernor1Hand_cmb.Items.Add("Right Hand")

        CwtGovernorMounting_cmb.Items.Clear()
        CwtGovernorMounting_cmb.Items.Add("Slab")
        CwtGovernorMounting_cmb.Items.Add("Rail")

        CwtGovernorExistingSheaveDiameter_cmb.Items.Clear()
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("12.00")
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("16.00")
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("Other")

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
            Case Controller
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
                            CurField = MaterialItemRecordSet.Fields("Material Cost").Value          ' * CurQty
                        ElseIf CostOrHours = "Hours" Then
                            CurField = MaterialItemRecordSet.Fields("Standard Hours").Value         ' * CurQty
                        End If
                    End If
                End If
            Case SecurityPackage, InterGroupEmergencyPower, TractionBatteryLowering, CodeBlueOption, PanicFeatureRiotControl, CodePinkOption,
                 InconspicuousRiser
                If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                    If CostOrHours = "Cost" Then
                        CurField = MaterialItemRecordSet.Fields("Material Cost").Value
                    ElseIf CostOrHours = "Hours" Then
                        CurField = MaterialItemRecordSet.Fields("Standard Hours").Value
                    End If
                End If
            Case Else
        End Select
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)

    End Sub
    Private Sub MachineType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineType_cmb.SelectedIndexChanged
        RetrieveCostHours_Controller()
    End Sub
    Private Sub DriveType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveType_cmb.SelectedIndexChanged
        RetrieveCostHours_Controller()
    End Sub
    Private Sub FpSpread1_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        ChildSheetView = FpSpread1.ActiveSheet.FindChildView(CurRow, 0)
        If Not ChildSheetView Is Nothing Then
            Select Case ChildSheetView.Cells(e.Row, MAT_COL_MATERIAL_ID).Text
                Case Controller
                    RetrieveCostHours_Controller()
                Case Else
            End Select
        End If

    End Sub
    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        RetrieveCostHours_Controller()
    End Sub
    Private Sub RetrieveCostHours_Controller()
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(CurRow, 0)
        If Not ChildSheetView1 Is Nothing Then
            GetCostHours(ChildSheetView1.Cells(CurRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(CurRow, MAT_COL_OPTION).Text,
                         ChildSheetView1.Cells(CurRow, MAT_COL_TYPE).Text, ChildSheetView1.Cells(CurRow, MAT_COL_ORDER_BY).Text, "Cost",
                         ChildSheetView1.Cells(CurRow, MAT_COL_MATERIAL_COST).Value, ChildSheetView1.Cells(CurRow, MAT_COL_QTY).Value)
            GetCostHours(ChildSheetView1.Cells(CurRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView1.Cells(CurRow, MAT_COL_OPTION).Text,
                         ChildSheetView1.Cells(CurRow, MAT_COL_TYPE).Text, ChildSheetView1.Cells(CurRow, MAT_COL_ORDER_BY).Text, "Hours",
                         ChildSheetView1.Cells(CurRow, MAT_COL_STANDARD_HOURS).Value, ChildSheetView1.Cells(CurRow, MAT_COL_QTY).Value)
        End If

    End Sub
    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DisplayEST_vs_ORD()
    End Sub
    Private Sub DisplayEST_vs_ORD()

        If TabControl1.SelectedTab.Text.IndexOf("EST") > -1 Then
            CarData_fra.Visible = True
            OrderingTabs.Visible = False
        ElseIf TabControl1.SelectedTab.Text.IndexOf("ORD") > -1 Then
            CarData_fra.Visible = False
            OrderingTabs.Visible = True
        End If

    End Sub
    Private Sub SetGovImage(ByVal FromControl As String)

        Gov_img.SizeMode = PictureBoxSizeMode.AutoSize
        Select Case FromControl
            Case "NewGov"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "\images\NewGovernor.png")
            Case "ExistingGov"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "\images\ExistingGovernor.png")
            Case "GovMounting"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "\images\GovernorMounting.png")
            Case "GovMinimumClearances"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "\images\GovernorMachineRoomClearances.png")
            Case "GovTensionSheave"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "\images\GovernorTensionSheavePit.png")
            Case Else
                Gov_img.Image = Nothing
        End Select

    End Sub
    Private Sub ResetGovImage()
        Gov_img.Image = Nothing
    End Sub
    Private Sub CarGovernorNewModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorNewModel_cmb.GotFocus
        SetGovImage("NewGov")
    End Sub
    Private Sub CarGovernorNewModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorNewModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingVendor_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingVendor_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorExistingVendor_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingVendor_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingModel_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorExistingModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovCableSize_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovCableSize_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovCableSize_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovCableSize_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorPullthrough_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorPullthrough_txt.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorPullthrough_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorPullthrough_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1Hand_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1Hand_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernor1Hand_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1Hand_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorMounting_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorMounting_cmb.GotFocus
        SetGovImage("GovMounting")
    End Sub
    Private Sub CarGovernorMounting_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorMounting_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarMeetsMinimumClearances_chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarMeetsMinimumClearances_chk.GotFocus
        SetGovImage("GovMinimumClearances")
    End Sub
    Private Sub CarMeetsMinimumClearances_chk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarMeetsMinimumClearances_chk.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1TensionSheaveA_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveA_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernor1TensionSheaveA_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveA_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1TensionSheaveB_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveB_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernor1TensionSheaveB_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveB_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingSheaveDiameter_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingSheaveDiameter_cmb.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernorExistingSheaveDiameter_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingSheaveDiameter_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorNewModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorNewModel_cmb.GotFocus
        SetGovImage("NewGov")
    End Sub
    Private Sub CwtGovernorNewModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorNewModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingVendor_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingVendor_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorExistingVendor_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingVendor_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingModel_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorExistingModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovCableSize_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovCableSize_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovCableSize_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovCableSize_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorPullthrough_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorPullthrough_txt.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorPullthrough_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorPullthrough_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1Hand_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1Hand_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernor1Hand_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1Hand_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorMounting_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorMounting_cmb.GotFocus
        SetGovImage("GovMounting")
    End Sub
    Private Sub CwtGovernorMounting_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorMounting_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtMeetsMinimumClearances_chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtMeetsMinimumClearances_chk.GotFocus
        SetGovImage("GovMinimumClearances")
    End Sub
    Private Sub CwtMeetsMinimumClearances_chk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtMeetsMinimumClearances_chk.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1TensionSheaveA_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveA_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernor1TensionSheaveA_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveA_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1TensionSheaveB_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveB_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernor1TensionSheaveB_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveB_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingSheaveDiameter_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingSheaveDiameter_cmb.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernorExistingSheaveDiameter_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingSheaveDiameter_cmb.LostFocus
        ResetGovImage()
    End Sub
End Class
