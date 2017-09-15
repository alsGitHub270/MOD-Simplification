Imports System.IO
Imports Newtonsoft.Json
Imports System.Collections.Generic

Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Private sv As New FarPoint.Win.Spread.SheetView()
    Private svCollection As New System.Collections.ArrayList(10)
    Private EstimatingDataset As System.Data.DataSet
    Private MainGroups As DataTable = Nothing
    Private SubGroups As DataTable = Nothing
    Private GeneralInfo As DataTable
    Private isInitializingComponent As Boolean
    Public FormIsDirty As Boolean

    Private dtStr As System.Type = System.Type.GetType("System.String")
    Private dtInt As System.Type = System.Type.GetType("System.Int32")
    Private dtSng As System.Type = System.Type.GetType("System.Single")

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
    Public Const TotalMaterialColumns As Integer = 11
    Public Const MAIN_COL_MAIN_GROUP As Integer = 0
    Public Const MAIN_COL_MAIN_ID As Integer = 1
    Public Const MAIN_COL_TOTAL_COST As Integer = 2
    Public Const MAIN_COL_TOTAL_STD_HRS As Integer = 3
    Public Const MAIN_COL_TOTAL_SPEC_HRS As Integer = 4

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
    Public Const MAT_COL_COMMENTS As Integer = 11

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

    ' Main ID's in table ***********************************************************************
    Public Const MAIN_ID_Controller As String = "00CON"
    Public Const MAIN_ID_ReuseGearedMachine As String = "05RGD"
    Public Const MAIN_ID_NewGearedMachine As String = "10NGD"
    Public Const MAIN_ID_FMM200 As String = "15FMM"
    Public Const MAIN_ID_ReuseGearlessMachine As String = "20RGL"
    Public Const MAIN_ID_NewGearlessMachine As String = "25NGL"
    Public Const MAIN_ID_Governor As String = "30GOV"
    Public Const MAIN_ID_ACUM As String = "35ACU"
    Public Const MAIN_ID_CarItems As String = "40CAR"
    Public Const MAIN_ID_DoorOperator As String = "45DOP"
    Public Const MAIN_ID_RollerGuides As String = "50RGS"
    Public Const MAIN_ID_PassengerCab As String = "55PAS"
    Public Const MAIN_ID_FreightCab As String = "60FRT"
    Public Const MAIN_ID_LandingDoor As String = "65LND"
    Public Const MAIN_ID_Hoistway As String = "70HST"
    Public Const MAIN_ID_Fixtures As String = "75FIX"
    Public Const MAIN_ID_Pit As String = "80PIT"
    Public Const MAIN_ID_Miscellaneous As String = "85MSC"
    Public Const MAIN_ID_SubcontractingWork As String = "90SUB"

    ' Material ID's in table ***********************************************************************
    Public Const MATID_Controller As String = "00CON"
    Public Const MATID_SecurityPackage As String = "01CON"
    Public Const MATID_IntergroupEmergencyPower As String = "02CON"
    Public Const MATID_TractionBatteryLowering As String = "03CON"
    Public Const MATID_CodeBlueOption As String = "04CON"
    Public Const MATID_PanicFeatureRiotControl As String = "05CON"
    Public Const MATID_CodePinkOption As String = "06CON"
    Public Const MATID_InconspicuousRiser As String = "07CON"
    Public Const MATID_Drive As String = "08CON"
    Public Const MATID_Transformer As String = "09CON"
    Public Const MATID_MTO As String = "10CON"
    Public Const MATID_MachineRoomWiring As String = "11CON"
    Public Const MATID_MachineRoomDuct As String = "12CON"
    Public Const MATID_ReuseGearedACMotor As String = "00RGD"
    Public Const MATID_ReuseGearedMotorAdapterPlateKit As String = "01RGD"
    Public Const MATID_ReuseGearedMachineRefurbishmentWork As String = "02RGD"
    Public Const MATID_ReuseGearedBrakeWork As String = "03RGD"
    Public Const MATID_ReuseGearedNitroCleaning As String = "04RGD"
    Public Const MATID_NewGearedMachine As String = "00NGD"
    Public Const MATID_NewGearedACMotor As String = "01NGD"
    Public Const MATID_NewGearedBrakeSwitch As String = "02NGD"
    Public Const MATID_NewGearedMachineIsolation As String = "03NGD"
    Public Const MATID_NewGearedSheaves As String = "04NGD"
    Public Const MATID_NewGearedSheaveGuard As String = "05NGD"
    Public Const MATID_NewGearedBedPlate As String = "06NGD"
    Public Const MATID_FMM200Machine As String = "00FMM"
    Public Const MATID_FMM200BlockingAssembly As String = "01FMM"
    Public Const MATID_FMM200STM As String = "02FMM"
    Public Const MATID_FMM200KSSContacts As String = "03FMM"
    Public Const MATID_FMM200CarAdapter As String = "04FMM"
    Public Const MATID_FMM200CwtAdapter As String = "05FMM"
    Public Const MATID_ReuseGearlessEncoder As String = "00RGL"
    Public Const MATID_ReuseGearlessSheave As String = "01RGL"
    Public Const MATID_ReuseGearlessSheaveGuard As String = "02RGL"
    Public Const MATID_ReuseGearlessBrakeSwitch As String = "03RGL"
    Public Const MATID_ReuseGearlessBrakeWork As String = "04RGL"
    Public Const MATID_ReuseGearlessNitroCleaning As String = "05RGL"
    Public Const MATID_ReuseGearlessMachineRefurbishmentWork As String = "06RGL"
    Public Const MATID_NewGearlessMachine As String = "00NGL"
    Public Const MATID_NewGearlessMachineBedplateIsolation As String = "01NGL"
    Public Const MATID_NewGearlessSheaves As String = "02NGL"
    Public Const MATID_NewGearlessSheaveGuard As String = "03NGL"
    Public Const MATID_NewGearlessMachineDisassembly As String = "04NGL"
    Public Const MATID_CarGovernor As String = "00GOV"
    Public Const MATID_CarGovernorEncoder As String = "01GOV"
    Public Const MATID_CarGovernorMounting As String = "02GOV"
    Public Const MATID_CwtGovernor As String = "03GOV"
    Public Const MATID_CwtGovernorEncoder As String = "04GOV"
    Public Const MATID_CwtGovernorMounting As String = "05GOV"
    Public Const MATID_RopeGripper As String = "00ACU"
    Public Const MATID_RopeGripperMountingKit As String = "01ACU"
    Public Const MATID_CarTopMaintenanceStation As String = "00CAR"
    Public Const MATID_SALSISLevelingUnit As String = "01CAR"
    Public Const MATID_ETS_ETSL As String = "02CAR"
    Public Const MATID_LoadWeighingDevice As String = "03CAR"
    Public Const MATID_CarDuct As String = "04CAR"
    Public Const MATID_OKRCarTopBox As String = "05CAR"
    Public Const MATID_ToeGuard As String = "06CAR"
    Public Const MATID_FrontCarDoorOperatorPackage As String = "00DOP"
    Public Const MATID_FrontCarDoorOperator As String = "01DOP"
    Public Const MATID_FrontClutch As String = "02DOP"
    Public Const MATID_FrontCarDoorTrack As String = "03DOP"
    Public Const MATID_FrontCarDoorHanger As String = "04DOP"
    Public Const MATID_FrontCarDoorGateSwitch As String = "05DOP"
    Public Const MATID_RearCarDoorOperatorPackage As String = "06DOP"
    Public Const MATID_RearCarDoorOperator As String = "07DOP"
    Public Const MATID_RearClutch As String = "08DOP"
    Public Const MATID_RearCarDoorTrack As String = "09DOP"
    Public Const MATID_RearCarDoorHanger As String = "10DOP"
    Public Const MATID_RearCarDoorGateSwitch As String = "11DOP"
    Public Const MATID_DoorRestrictor As String = "12DOP"
    Public Const MATID_DoorDetectors As String = "13DOP"
    Public Const MATID_CarRollerGuides As String = "00RGS"
    Public Const MATID_CarRollerGuideAdapterPlate As String = "01RGS"
    Public Const MATID_CarRGShoeCovers As String = "02RGS"
    Public Const MATID_CwtRollerGuides As String = "03RGS"
    Public Const MATID_CwtRollerGuideAdapterPlate As String = "04RGS"
    Public Const MATID_CwtRGShoeCovers As String = "05RGS"
    Public Const MATID_NewCabComplete As String = "00PAS"
    Public Const MATID_CabShell As String = "01PAS"
    Public Const MATID_CeilingLighting As String = "02PAS"
    Public Const MATID_EmergencyLightCanopyType As String = "03PAS"
    Public Const MATID_CabReturns As String = "04PAS"
    Public Const MATID_CabPanels As String = "05PAS"
    Public Const MATID_CarDoor As String = "06PAS"
    Public Const MATID_Handrails As String = "07PAS"
    Public Const MATID_CarSill As String = "08PAS"
    Public Const MATID_Fan As String = "09PAS"
    Public Const MATID_EmergencyExitSwitch As String = "10PAS"
    Public Const MATID_CabFlooring As String = "11PAS"
    Public Const MATID_Subflooring As String = "12PAS"
    Public Const MATID_CabPads As String = "13PAS"
    Public Const MATID_CarTopHandRail As String = "14PAS"
    Public Const MATID_CarPlatform As String = "15PAS"
    Public Const MATID_CarSling As String = "16PAS"
    Public Const MATID_IsolationPads As String = "17PAS"
    Public Const MATID_CarSafety As String = "18PAS"
    Public Const MATID_FreightEnclosure As String = "00FRT"
    Public Const MATID_Gate As String = "01FRT"
    Public Const MATID_HoistwayFrame As String = "00LND"
    Public Const MATID_HoistwayDoor As String = "01LND"
    Public Const MATID_HoistwayDoorTracks As String = "02LND"
    Public Const MATID_NylonTrackInserts As String = "03LND"
    Public Const MATID_HoistwayDoorHangers As String = "04LND"
    Public Const MATID_HoistwayDoorRollers As String = "05LND"
    Public Const MATID_InterlocksandPickups As String = "06LND"
    Public Const MATID_DoorClosers As String = "07LND"
    Public Const MATID_Escutheons As String = "08LND"
    Public Const MATID_HoistwayDoorGibs As String = "09LND"
    Public Const MATID_FireTabs As String = "10LND"
    Public Const MATID_SightGuard As String = "11LND"
    Public Const MATID_Astragals As String = "12LND"
    Public Const MATID_HoistwaySill As String = "13LND"
    Public Const MATID_Struts As String = "14LND"
    Public Const MATID_HoistwayHeaders As String = "15LND"
    Public Const MATID_HoistwayDoorPackage As String = "16LND"
    Public Const MATID_FreightDoorPackage As String = "21LND"
    Public Const MATID_TravellingCableHoistwayWiring As String = "00HST"
    Public Const MATID_HoistwayDuct As String = "01HST"
    Public Const MATID_TravelCableHangers As String = "02HST"
    Public Const MATID_HoistRopes As String = "03HST"
    Public Const MATID_STMs As String = "04HST"
    Public Const MATID_AntitwistDevice As String = "05HST"
    Public Const MATID_STMCarCwtAdapter As String = "06HST"
    Public Const MATID_Shackles As String = "07HST"
    Public Const MATID_CarGovernorRope As String = "08HST"
    Public Const MATID_CwtGovernorRope As String = "09HST"
    Public Const MATID_CarSheaveandGuard As String = "10HST"
    Public Const MATID_CwtSheaveandGuard As String = "11HST"
    Public Const MATID_RollerGuidesCwt As String = "12HST"
    Public Const MATID_SeismicSwitch As String = "14HST"
    Public Const MATID_SeismicEquipment As String = "15HST"
    Public Const MATID_GuideRails As String = "16HST"
    Public Const MATID_RailBrackets As String = "17HST"
    Public Const MATID_CounterweightFrame As String = "18HST"
    Public Const MATID_CounterweightSubWeights As String = "19HST"
    Public Const MATID_CwtSafety As String = "20HST"
    Public Const MATID_HoistwayScreening As String = "21HST"
    Public Const MATID_HoistwayLimitSwitch As String = "22HST"
    Public Const MATID_Fascia As String = "23HST"
    Public Const MATID_RopeSplayClamp As String = "24HST"
    Public Const MATID_MainCarStation As String = "00FIX"
    Public Const MATID_AuxCarStation As String = "01FIX"
    Public Const MATID_CarTravelingLantern As String = "02FIX"
    Public Const MATID_CarPositionIndicatorInTransom As String = "03FIX"
    Public Const MATID_VoiceAnnunciator As String = "04FIX"
    Public Const MATID_HandsFreePhone As String = "05FIX"
    Public Const MATID_HallStations As String = "06FIX"
    Public Const MATID_HallPositionIndicator As String = "07FIX"
    Public Const MATID_HallLantern As String = "08FIX"
    Public Const MATID_HallPILanternCombo As String = "09FIX"
    Public Const MATID_HoistwayAccessSwitch As String = "10FIX"
    Public Const MATID_FERSwitch As String = "11FIX"
    Public Const MATID_InconspicuousRisers As String = "12FIX"
    Public Const MATID_JambBraille As String = "13FIX"
    Public Const MATID_EmergencyPowerPanel As String = "14FIX"
    Public Const MATID_StatusPanel As String = "15FIX"
    Public Const MATID_LobbyVision As String = "16FIX"
    Public Const MATID_IntercomSystem As String = "17FIX"
    Public Const MATID_CarBuffer As String = "00PIT"
    Public Const MATID_CarBufferBlocking As String = "01PIT"
    Public Const MATID_CarBufferFootingChannels As String = "02PIT"
    Public Const MATID_CwtBuffer As String = "03PIT"
    Public Const MATID_CwtBufferBlocking As String = "04PIT"
    Public Const MATID_CWTBufferFootingChannels As String = "05PIT"
    Public Const MATID_BufferSwitch As String = "06PIT"
    Public Const MATID_GovernorTensionSheaveCar As String = "07PIT"
    Public Const MATID_GovernorTensionSheaveCwt As String = "08PIT"
    Public Const MATID_PitSwitch As String = "09PIT"
    Public Const MATID_PitLadder As String = "10PIT"
    Public Const MATID_PitLight As String = "11PIT"
    Public Const MATID_WhisperFlex As String = "12PIT"
    Public Const MATID_SwayDevice As String = "13PIT"
    Public Const MATID_CompensationRope As String = "14PIT"
    Public Const MATID_CompensationSheave As String = "15PIT"
    Public Const MATID_CompensationSwitch As String = "16PIT"
    Public Const MATID_CounterweightGuard As String = "17PIT"
    Public Const MATID_CleaningandPainting As String = "00MSC"
    Public Const MATID_SAISInspection As String = "01MSC"
    Public Const MATID_ConsultantGSAInspection As String = "02MSC"
    Public Const MATID_FireServiceEPTesting As String = "03MSC"
    Public Const MATID_MachineRoomSpecialAccess As String = "04MSC"
    Public Const MATID_Miscellaneous As String = "05MSC"
    Public Const MATID_FrontRecladding As String = "00SUB"
    Public Const MATID_FireAlarmSystem As String = "01SUB"
    Public Const MATID_ElectricalWork As String = "02SUB"
    Public Const MATID_CabWork As String = "03SUB"
    Public Const MATID_BuildingGCWork As String = "04SUB"
    Public Const MATID_Crane As String = "05SUB"

    Private Const EST_Prefix As String = "EST: "
    Private Const ORD_Prefix As String = "ORD: "

    Private CurParentRow As Integer = 0
    Private CurChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
    Private SheetCornerColWidth As Integer = 0

    Private Sub CreateDataSet(ByVal CurUnits As String)
        Dim iIndex As Integer = 0, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing

        EstimatingDataset = Nothing
        EstimatingDataset = New DataSet()
        EstimatingDataset.EnforceConstraints = False

        Erase SheetHeaders
        ReDim SheetHeaders(MATERIAL_GROUP, TotalMaterialColumns)

        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderDesc = "Main Group"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderDesc = "MainID"
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_COST).HeaderDesc = "Total Cost"
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_STD_HRS).HeaderDesc = "Total Std Hours"
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_SPEC_HRS).HeaderDesc = "Total Spec Hours"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderType = dtStr
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderType = dtStr
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_COST).HeaderType = dtInt
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_STD_HRS).HeaderType = dtInt
        SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_SPEC_HRS).HeaderType = dtInt

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
        SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS).HeaderDesc = "Comments"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderType = dtSng
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderType = dtSng
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderType = dtSng
        SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS).HeaderType = dtStr

        Erase a_MainGroup
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "MainGroup")
        If MaterialItemRecordSet.RecordCount > 0 Then
            Array.Resize(a_MainGroup, MaterialItemRecordSet.RecordCount)
            MaterialItemRecordSet.MoveFirst()
            iIndex = 0
            Do Until MaterialItemRecordSet.EOF
                a_MainGroup(iIndex).MainID = MaterialItemRecordSet.Fields("MainID").Value.ToString.Trim
                a_MainGroup(iIndex).Description = MaterialItemRecordSet.Fields("Main Group").Value.ToString.Trim
                a_MainGroup(iIndex).Units = CurUnits
                MaterialItemRecordSet.MoveNext()
                iIndex += 1
            Loop
        End If
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
        Erase a_MaterialGroup
        jIndex = 0
        For iIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
            Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "SubGroup")
            MaterialItemRecordSet.Filter = "MainID = '" & a_MainGroup(iIndex).MainID & "'"
            If MaterialItemRecordSet.RecordCount > 0 Then
                MaterialItemRecordSet.MoveFirst()
                Do Until MaterialItemRecordSet.EOF
                    ReDim Preserve a_MaterialGroup(jIndex)
                    a_MaterialGroup(jIndex).MainID = a_MainGroup(iIndex).MainID
                    a_MaterialGroup(jIndex).MaterialID = MaterialItemRecordSet.Fields("MaterialID").Value.ToString.Trim
                    a_MaterialGroup(jIndex).Description = MaterialItemRecordSet.Fields("Material Description").Value.ToString.Trim
                    a_MaterialGroup(jIndex).Units = CurUnits
                    a_MaterialGroup(jIndex).OptionStr = Nothing
                    a_MaterialGroup(jIndex).Type = Nothing
                    a_MaterialGroup(jIndex).OrderBy = Nothing
                    a_MaterialGroup(jIndex).Qty = CalculateNumberOfCarsInEstimate(CurUnits)
                    a_MaterialGroup(jIndex).MaterialCost = 0
                    a_MaterialGroup(jIndex).StandardHours = 0
                    a_MaterialGroup(jIndex).SpecialHours = 0
                    MaterialItemRecordSet.MoveNext()
                    jIndex += 1
                Loop
            End If
            Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
        Next iIndex
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
                    MainGroups = EstimatingDataset.Tables.Add("EstMainGroup")
                    MainGroups.Columns.AddRange(HeaderSetup)
                    For jIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
                        MainGroups.Rows.Add(New Object() {a_MainGroup(jIndex).Description, a_MainGroup(jIndex).MainID})
                    Next jIndex
                Case MATERIAL_GROUP
                    SubGroups = EstimatingDataset.Tables.Add("EstMaterials")
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
        Deserialize()
        EstimatingDataset.Relations.Add("EstMaterials", MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))

    End Sub
    Private Sub PrepareThisForm()
        Dim TabToRemove As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        isInitializingComponent = True
        DAO2ADO(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, My.Application.Info.DirectoryPath & "\", OPTION_DATABASE_NAME, True)
        Load_ListBoxes()
        OrderingTabs.Top = CarData_fra.Top
        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        CarTab.Text = EST_Prefix & CurrentUnits
        OrderTab.Text = ORD_Prefix & CurrentUnits
        Select Case EstimateLevel
            Case "Master"
                TabToRemove = "+"
            Case Else
                TabToRemove = ORD_Prefix
        End Select
        If Not String.IsNullOrEmpty(TabToRemove) Then
            For iIndex As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
                Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                If CurTab.Text.IndexOf(TabToRemove) > -1 Then
                    TabControl1.TabPages.Remove(CurTab)
                End If
            Next iIndex
        End If
        TabControl1.SelectTab(0)
        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        CurrentBillofMaterialsandTaskListFrameHeight = BillofMaterialsandTaskList_fra.Height
        ExpensesPerDayDetails_btn.Left = ExpensesPerDay_txt.Left
        DisplayEST_vs_ORD()
        isInitializingComponent = False
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
        e.SheetView.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        e.SheetView.SheetCornerStyle.BackColor = FpSpread1.ActiveSheet.SheetCornerStyle.BackColor
        e.SheetView.GrayAreaBackColor = Color.Gray
        e.SheetView.LockBackColor = Color.DarkGray
        svCollection.Add(e.SheetView)

    End Sub
    Private Sub Exit_cmd_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_cmd.Click

        If FormIsDirty Then
            If MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will negate all changes.", "Please Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Call SaveEstimatingData()
            End If
        End If
        EndProgram()

    End Sub
    Private Sub CMMain_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMMain_cmd.Click
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
        MachineType_cmb.Items.Add("Reuse " & GEARED_TYPE)
        MachineType_cmb.Items.Add("New " & GEARED_TYPE)
        MachineType_cmb.Items.Add("FMM200")
        MachineType_cmb.Items.Add("Reuse " & GEARLESS_TYPE)
        MachineType_cmb.Items.Add("New " & GEARLESS_TYPE)

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

        PEStampRequired_cmb.Items.Clear()
        PEStampRequired_cmb.Items.Add("Yes")
        PEStampRequired_cmb.Items.Add("No")

    End Sub
    Private Function SetCombo(ByVal ArrayType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ReturnCmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim UseWhere As String = "MaterialID = '" & CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text & "'"
        Dim Options As String() = {"Option1", "Option2", "Option3"}
        Dim Action As Integer = MOVE_FIRST
        Dim myList As New List(Of String)()

        Select Case ArrayType
            Case "Options"
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "Options")
                If MaterialItemRecordSet.RecordCount > 0 Then
                    MaterialItemRecordSet.Filter = UseWhere
                    If MaterialItemRecordSet.RecordCount > 0 Then
                        MaterialItemRecordSet.MoveFirst()
                        Erase Options
                        If MaterialItemRecordSet.Fields("OptionNew").Value = True Then
                            AddToArray(Options, "New")
                        End If
                        If MaterialItemRecordSet.Fields("OptionReuse").Value = True Then
                            AddToArray(Options, "Reuse")
                        End If
                        If MaterialItemRecordSet.Fields("OptionRefurbish").Value = True Then
                            AddToArray(Options, "Refurbish")
                        End If
                        If MaterialItemRecordSet.Fields("OptionNA").Value = True Then
                            AddToArray(Options, "NA")
                        End If
                        If Not Convert.IsDBNull(MaterialItemRecordSet.Fields("OptionOther").Value) Then
                            AddToArray(Options, MaterialItemRecordSet.Fields("OptionOther").Value.ToString)
                        End If
                    End If
                End If
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
            Case "Types"
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "Type_Cost_Hours")
                If MaterialItemRecordSet.RecordCount > 0 Then
                    MaterialItemRecordSet.Filter = UseWhere
                    If MaterialItemRecordSet.RecordCount > 0 Then
                        MaterialItemRecordSet.MoveFirst()
                        Erase Options
                        Do Until MaterialItemRecordSet.EOF
                            AddToArray(Options, MaterialItemRecordSet.Fields("Type").Value.ToString)
                            MaterialItemRecordSet.MoveNext()
                        Loop
                    End If
                End If
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
            Case "OrderBys"
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "OrderBys")
                If MaterialItemRecordSet.RecordCount > 0 Then
                    MaterialItemRecordSet.Filter = UseWhere
                    If MaterialItemRecordSet.RecordCount > 0 Then
                        Erase Options
                        If MaterialItemRecordSet.Fields("OrderByHQ").Value = True Then
                            AddToArray(Options, "HQ")
                        End If
                        If MaterialItemRecordSet.Fields("OrderByRL").Value = True Then
                            AddToArray(Options, "RL")
                        End If
                    End If
                End If
                Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
            Case Else
        End Select
        ReturnCmb.Items = Options
        ReturnCmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        ReturnCmb.Editable = False
        ReturnCmb.MaxDrop = Options.Length
        Return ReturnCmb

    End Function
    Private Sub AddToArray(ByRef CurAry() As String, ByVal SetValue As String)
        Dim iIndex As Integer = 1

        If IsNothing(CurAry) Then
            Array.Resize(CurAry, iIndex)
            CurAry.SetValue(SetValue, iIndex - 1)
        Else
            If Array.BinarySearch(CurAry, SetValue) < 0 Then
                iIndex = CurAry.Length + 1
                Array.Resize(CurAry, iIndex)
                CurAry.SetValue(SetValue, iIndex - 1)
            End If
        End If

    End Sub
    Private Sub GetCostHours(ByVal MaterialID As String, ByVal CurOption As String, ByVal CurType As String, ByVal CurOrderBy As String,
                             ByVal CostOrHours As String, ByRef CurField As Single, ByVal CurQty As Integer)
        Dim UseWhere As String = "MaterialID = '" & MaterialID & "'"
        Dim MachineType As String = GEARLESS_TYPE
        Dim UseFrontWidth As Single = 0, UseFrontHeight As Single = 0, UseRearWidth As Single = 0, UseRearHeight As Single = 0

        If String.IsNullOrEmpty(CurOption) Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(CurOrderBy) Then
            Exit Sub
        ElseIf CurOrderBy = "RL" Then
            Exit Sub
        End If
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, GROUP_SETUP_QRY)
        Select Case MaterialID
            Case MATID_Controller
                If String.IsNullOrEmpty(MachineType_cmb.Text) Or String.IsNullOrEmpty(DriveType_cmb.Text) Or String.IsNullOrEmpty(CurType) Then
                    Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
                    Exit Sub
                Else
                    UseWhere &= " AND Type = '" & CurType & "'"
                    Select Case CurType
                        Case "SCH - TXR5", "SCH - TX2R7"
                            Select Case MachineType_cmb.Text
                                Case "Reuse " & GEARED_TYPE, "New " & GEARED_TYPE
                                    MachineType = GEARED_TYPE
                                Case "FMM200", "Reuse " & GEARLESS_TYPE, "New " & GEARLESS_TYPE
                                    MachineType = GEARLESS_TYPE
                                Case Else
                            End Select
                            UseWhere &= " AND [Criteria 1] = '" & MachineType & "' AND [Criteria 2] = '" & DriveType_cmb.Text & "'"
                        Case Else
                    End Select
                    If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                        If CostOrHours = "Cost" And CurOption = "New" Then
                            CurField = MaterialItemRecordSet.Fields("Material Cost").Value          ' * CurQty
                        ElseIf CostOrHours = "Hours" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours New").Value         ' * CurQty
                                Case "Reuse"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Reuse").Value         ' * CurQty
                                Case "Refurbish"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Refurbish").Value         ' * CurQty
                                Case Else
                            End Select
                        End If
                    End If
                End If
            Case MATID_SecurityPackage, MATID_IntergroupEmergencyPower, MATID_TractionBatteryLowering, MATID_CodeBlueOption, MATID_PanicFeatureRiotControl, MATID_CodePinkOption,
                 MATID_InconspicuousRiser, MATID_MachineRoomWiring, MATID_MachineRoomDuct
                If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                    If CostOrHours = "Cost" Then
                        CurField = MaterialItemRecordSet.Fields("Material Cost").Value
                    ElseIf CostOrHours = "Hours" Then
                        Select Case CurOption
                            Case "New"
                                CurField = MaterialItemRecordSet.Fields("Standard Hours New").Value         ' * CurQty
                            Case "Reuse"
                                CurField = MaterialItemRecordSet.Fields("Standard Hours Reuse").Value         ' * CurQty
                            Case "Refurbish"
                                CurField = MaterialItemRecordSet.Fields("Standard Hours Refurbish").Value         ' * CurQty
                            Case Else
                        End Select
                    End If
                End If
            Case MATID_CarRollerGuides, MATID_CarRollerGuideAdapterPlate, MATID_CarRGShoeCovers, MATID_CwtRollerGuides, MATID_CwtRollerGuideAdapterPlate,
                 MATID_CwtRGShoeCovers
                If String.IsNullOrEmpty(CurType) Then
                    Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
                    Exit Sub
                Else
                    UseWhere &= " AND Type = '" & CurType & "'"
                    If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                        If CostOrHours = "Cost" And CurOption = "New" Then
                            CurField = MaterialItemRecordSet.Fields("Material Cost").Value          ' * CurQty
                        ElseIf CostOrHours = "Hours" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours New").Value         ' * CurQty
                                Case "Reuse"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Reuse").Value         ' * CurQty
                                Case "Refurbish"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Refurbish").Value         ' * CurQty
                                Case Else
                            End Select
                        End If
                    End If
                End If
            Case MATID_ToeGuard
                If String.IsNullOrEmpty(CarDoorOpeningWidthFtFront_txt.Text) And String.IsNullOrEmpty(CarDoorOpeningWidthInFront_txt.Text) And
                   String.IsNullOrEmpty(CarDoorOpeningWidthFtRear_txt.Text) And String.IsNullOrEmpty(CarDoorOpeningWidthInRear_txt.Text) Then
                    Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
                    Exit Sub
                Else
                    UseFrontWidth = Math.Round(Conversion.Val(CarDoorOpeningWidthFtFront_lbl.Text) * 12 +
                                               Conversion.Val(CarDoorOpeningWidthInFront_txt.Text), 2)
                    Select Case UseFrontWidth
                        Case Is <= 36
                            UseFrontWidth = 36
                        Case Is <= 42
                            UseFrontWidth = 42
                        Case Is <= 48
                            UseFrontWidth = 48
                        Case Is <= 54
                            UseFrontWidth = 54
                        Case Else       '<= 60
                            UseFrontWidth = 60
                    End Select
                    UseWhere &= " AND [Criteria 1] = '" & UseFrontWidth & "'"
                    If Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, FIND_FIRST, "", UseWhere) <> RECORD_NOT_FOUND Then
                        If CostOrHours = "Cost" And CurOption = "New" Then
                            CurField = MaterialItemRecordSet.Fields("Material Cost").Value          ' * CurQty
                        ElseIf CostOrHours = "Hours" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours New").Value         ' * CurQty
                                Case "Reuse"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Reuse").Value         ' * CurQty
                                Case "Refurbish"
                                    CurField = MaterialItemRecordSet.Fields("Standard Hours Refurbish").Value         ' * CurQty
                                Case Else
                            End Select
                        End If
                    End If
                    'UseRearWidth = Math.Round(Conversion.Val(CarDoorOpeningWidthFtRear_lbl.Text) * 12 +
                    '                           Conversion.Val(CarDoorOpeningWidthInRear_txt.Text), 2)
                End If

            Case Else
        End Select
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)
        CurField = Math.Round(CurField, 2)

    End Sub
    Private Sub MachineType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineType_cmb.SelectedIndexChanged
        Dim GetRow As Integer = FindRowByMaterialID(MATID_Controller)

        If GetRow <> -999 Then
            RetrieveCostHours(GetRow)
            PopulateEstimating()
        End If
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If

    End Sub
    Private Sub DriveType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveType_cmb.SelectedIndexChanged
        Dim GetRow As Integer = FindRowByMaterialID(MATID_Controller)

        If GetRow <> -999 Then
            RetrieveCostHours(GetRow)
            PopulateEstimating()
        End If
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If

    End Sub
    Private Sub FpSpread1_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        RetrieveCostHours(e.Row)
        If Not isInitializingComponent Then
            FormIsDirty = EstimatingDataset.HasChanges()
        End If
    End Sub
    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        RetrieveCostHours(e.Row)
    End Sub
    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Dim LastIndex As Integer = TabControl1.TabPages.Count - 1
        Dim UseUnits As String = String.Empty

        If TabControl1.SelectedTab.Text.IndexOf("+") > -1 Then
            UseUnits = InputBox("Enter Car Unit(s)", "Split Cars")
            If Not String.IsNullOrEmpty(UseUnits) Then
                TabControl1.TabPages.Insert(LastIndex, EST_Prefix & UseUnits)
                TabControl1.SelectTab(LastIndex)
                DisplayEST_vs_ORD()
            End If
        Else
            DisplayEST_vs_ORD()
        End If

    End Sub
    Private Sub DisplayEST_vs_ORD()

        If TabControl1.SelectedTab.Text.IndexOf(EST_Prefix) > -1 Then
            PopulateEstimating()
            CarData_fra.Visible = True
            If EstimateLevel = "Master" Then
                OrderingTabs.Visible = False
            End If
        ElseIf TabControl1.SelectedTab.Text.IndexOf(ORD_Prefix) > -1 Then
            PopulateOrdering()
            CarData_fra.Visible = False
            OrderingTabs.Visible = True
        ElseIf TabControl1.SelectedTab.Text.IndexOf("+") > -1 Then
            CarData_fra.Visible = False
            OrderingTabs.Visible = False
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
    Private Sub ExpensesPerDayDetails_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesPerDayDetails_btn.Click
        ExpensesPerDay_frm.ShowDialog()
        ExpensesPerDay_txt.Text = FormatNumber(SubcontractedLaborCost.TotalCost, 2)
    End Sub
    Private Sub FpSpread1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread1.Click
        CurParentRow = FpSpread1.ActiveSheet.ActiveRowIndex
        CurChildSheetView = FpSpread1.ActiveSheet.FindChildView(CurParentRow, 0)
    End Sub
    Private Sub RetrieveCostHours(ByVal UseRow As Integer)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        ChildSheetView = FpSpread1.ActiveSheet.FindChildView(CurRow, 0)
        If Not ChildSheetView Is Nothing Then
            GetCostHours(ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView.Cells(UseRow, MAT_COL_OPTION).Text,
                         ChildSheetView.Cells(UseRow, MAT_COL_TYPE).Text, ChildSheetView.Cells(UseRow, MAT_COL_ORDER_BY).Text, "Cost",
                         ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_COST).Value, ChildSheetView.Cells(UseRow, MAT_COL_QTY).Value)
            GetCostHours(ChildSheetView.Cells(UseRow, MAT_COL_MATERIAL_ID).Text, ChildSheetView.Cells(UseRow, MAT_COL_OPTION).Text,
                         ChildSheetView.Cells(UseRow, MAT_COL_TYPE).Text, ChildSheetView.Cells(UseRow, MAT_COL_ORDER_BY).Text, "Hours",
                         ChildSheetView.Cells(UseRow, MAT_COL_STANDARD_HOURS).Value, ChildSheetView.Cells(UseRow, MAT_COL_QTY).Value)
        End If

    End Sub
    Private Sub PopulateEstimating()
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel
        Dim dt As DataTable
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim UseUnits As String = Strings.Mid(TabControl1.SelectedTab.Text.Trim, 6)

        CreateDataSet(UseUnits)
        model = FpSpread1.ActiveSheet.Models.Data
        For Each dt In EstimatingDataset.Tables
            dt.DefaultView.AllowNew = False
        Next
        model.DataMember = "artists"
        model.DataSource = EstimatingDataset
        FpSpread1.ActiveSheet.GetDataView(False).AllowNew = False
        FpSpread1.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        FpSpread1.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        FpSpread1.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        FpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off
        FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
        FpSpread1.ActiveSheet.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
        FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
        FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
        FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
        FpSpread1.ActiveSheet.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        FpSpread1.ActiveSheet.RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
        FpSpread1.ActiveSheet.RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
        FpSpread1.ActiveSheet.SheetCornerStyle.BackColor = Color.DarkGray
        FpSpread1.ActiveSheet.SetColumnWidth(MAIN_COL_MAIN_GROUP, 150)
        FpSpread1.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_COST, 100)
        FpSpread1.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_STD_HRS, 100)
        FpSpread1.ActiveSheet.SetColumnWidth(MAIN_COL_TOTAL_SPEC_HRS, 100)
        FpSpread1.ActiveSheet.SetColumnVisible(1, False)
        FpSpread1.ActiveSheet.GrayAreaBackColor = Color.White
        GeneralInformation_fra.Left = 6
        GeneralInformation_fra.Width = CarData_fra.Width - GeneralInformation_fra.Left - 10
        BillofMaterialsandTaskList_fra.Left = 6
        BillofMaterialsandTaskList_fra.Width = CarData_fra.Width - BillofMaterialsandTaskList_fra.Left - 10
        Relocate_BillofMaterialsandTaskList_Frame()
        FpSpread1.Left = 6
        FpSpread1.Visible = False
        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
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

                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView1.Cells(jIndex, MAT_COL_OPTION).CellType = SetCombo("Options", ChildSheetView1, jIndex)
                    ChildSheetView1.Cells(jIndex, MAT_COL_TYPE).CellType = SetCombo("Types", ChildSheetView1, jIndex)
                    ChildSheetView1.Cells(jIndex, MAT_COL_ORDER_BY).CellType = SetCombo("OrderBys", ChildSheetView1, jIndex)
                    ChildSheetView1.Cells(jIndex, MAT_COL_QTY).Value = CalculateNumberOfCarsInEstimate(UseUnits)
                Next jIndex

                ChildSheetView1.SetColumnWidth(MAT_COL_MATERIAL_COST, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_STANDARD_HOURS, 120)
                ChildSheetView1.SetColumnWidth(MAT_COL_SPECIAL_HOURS, 100)
                ChildSheetView1.SetColumnWidth(MAT_COL_COMMENTS, 200)
                If SheetCornerColWidth = 0 Then
                    SheetCornerColWidth = ChildSheetView1.SheetCorner.Columns(0, 0).Width
                Else
                    ChildSheetView1.SheetCorner.Columns(0, 0).Width = SheetCornerColWidth
                End If
            End If
            Dim ShowGroup As Boolean = False
            Select Case FpSpread1.ActiveSheet.GetValue(iIndex, MAT_COL_MAIN_ID)
                Case MAIN_ID_ReuseGearedMachine
                    If MachineType_cmb.Text = "Reuse " & GEARED_TYPE Then
                        ShowGroup = True
                    End If
                Case MAIN_ID_NewGearedMachine
                    If MachineType_cmb.Text = "New " & GEARED_TYPE Then
                        ShowGroup = True
                    End If
                Case MAIN_ID_FMM200
                    If MachineType_cmb.Text = "FMM200" Then
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
                FpSpread1.ActiveSheet.SetRowVisible(iIndex, True)
            Else
                FpSpread1.ActiveSheet.SetRowVisible(iIndex, False)
            End If
        Next iIndex

    End Sub
    Private Sub PopulateOrdering()

    End Sub
    Private Function FindRowByMaterialID(ByVal UseMaterialID As String) As Integer
        Dim ReturnVal As Integer = -999
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim CurRow As Integer = 0, iIndex As Integer = 0

        For iIndex = 0 To FpSpread1.ActiveSheet.RowCount - 1
            If FpSpread1.ActiveSheet.GetValue(iIndex, MAIN_COL_MAIN_ID) = MAIN_ID_Controller Then
                CurRow = iIndex
                Exit For
            End If
        Next iIndex
        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(CurRow, 0)
        If Not ChildSheetView1 Is Nothing Then
            For iIndex = 0 To ChildSheetView1.RowCount - 1
                If ChildSheetView1.GetValue(iIndex, MAT_COL_MATERIAL_ID) = UseMaterialID Then
                    ReturnVal = iIndex
                    Exit For
                End If
            Next iIndex
        End If
        Return ReturnVal

    End Function
    Private Sub SaveEstimatingData()
        Dim _row As DataRow
        Dim is_new_row As Boolean = False

        Try
            If GeneralInfo.Rows.Count = 0 Then
                _row = GeneralInfo.NewRow
                is_new_row = True
            Else
                _row = GeneralInfo.Rows(0)
            End If

            '_row("building_type") = cboBuildingType.Text
            '_row("major_project") = chkMajorProject.CheckState
            '_row("sales_rep") = cboSalesRep.Text
            '_row("sales_office") = cboSalesOffice.Text
            '_row("installing_office") = cboInstallingOffice.Text
            '_row("service_office") = cboServiceOffice.Text
            '_row("status") = cboStatus.Text
            '_row("probability_of_sale") = cboProbabilityOfSale.Text
            '_row("bid_date") = txtBidDate.Text
            '_row("national_account") = cboNationalAccount.Text
            '_row("tax_code") = cboTaxCode.Text
            '_row("seismic_zone") = cboSeismicZone.Text
            '_row("local_code") = cboLocalCode.Text
            '_row("ansi_csa_b44_code") = cboANSICode.Text
            '_row("nfpa_code") = cboNFPA13CodeYear.Text
            '_row("sds_level") = txtSDSlevel.Text
            '_row("oshpd") = chkOSHPD.CheckState
            '_row("dsa") = chkDSA.CheckState
            '_row("head_detection") = chkHeadDetection.CheckState
            '_row("engineering_survey") = chkEngineeringSurvey.CheckState
            '_row("nps_duration") = cboDurationMonths.Text
            '_row("nps_call_back") = cboCallBackHours.Text
            '_row("nps_material_cost") = txtNPSMaterialCost.Text
            '_row("nps_labor_cost") = txtNPSLaborCost.Text
            '_row("nps_one_time_cost") = txtNPSOneTimeCost.Text
            '_row("ocpl") = txtOCPL.Text
            If is_new_row Then
                GeneralInfo.Rows.Add(_row)
            End If
            Serialize()

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Error Saving Estimating Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub Serialize()
        Dim json As String = ""
        Dim EST_Filename As String = Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt, CurrentGOData_Typ.Units)

        Try
            json = JsonConvert.SerializeObject(EstimatingDataset, Formatting.Indented)
            Using sw As StreamWriter = New StreamWriter(EstimatePath & EST_Filename & "MODEST.json")
                sw.Write(json)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Writing Cadre Json file")

        End Try
        FormIsDirty = False

    End Sub
    Private Sub Deserialize()
        Dim json As String = ""
        Dim EST_Filename As String = Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt, CurrentGOData_Typ.Units)

        Try
            Using sr As StreamReader = New StreamReader(EstimatePath & EST_Filename & "MODEST.json")
                json = sr.ReadToEnd
            End Using
            EstimatingDataset = JsonConvert.DeserializeObject(Of DataSet)(json)
            EstimatingDataset.Merge(EstimatingDataset, True, MissingSchemaAction.Ignore)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Reading Input File")

        End Try
        FormIsDirty = False

    End Sub
    Private Sub Save_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_cmd.Click
        SaveEstimatingData()
    End Sub
    Private Sub CapacityNew_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapacityNew_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub SpeedNew_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedNew_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub NumberofStopsTotal_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsTotal_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub NumberofStopsFront_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsFront_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub NumberofStopsRear_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberofStopsRear_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub PowerSupply_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerSupply_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub Application_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Application_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub LayoutEntranceDrawing_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayoutEntranceDrawing_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub DoorOperatorTypeFront_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoorOperatorTypeFront_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningWidthFtFront_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthFtFront_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningWidthInFront_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthInFront_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningHeightFtFront_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightFtFront_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningHeightInFront_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightInFront_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub DoorOperatorTypeRear_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoorOperatorTypeRear_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningWidthFtRear_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthFtRear_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningWidthInRear_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningWidthInRear_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningHeightFtRear_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightFtRear_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarDoorOpeningHeightInRear_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarDoorOpeningHeightInRear_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub CarWeight_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarWeight_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub HoistMotorHP_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistMotorHP_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub HoistMotorRpm_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistMotorRpm_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub MachineLocation_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MachineLocation_Cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub RopingNew_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopingNew_Cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub TopFloorToOverhead_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopFloorToOverhead_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub Travel_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Travel_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub PitDepth_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PitDepth_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub RiserQtyExistingFront_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiserQtyExistingFront_Cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub RiserQtyExistingRear_Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiserQtyExistingRear_Cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub FixtureFinish_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixtureFinish_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub DTRequestedShipDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTRequestedShipDate.ValueChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub BankCompleteDate_txt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankCompleteDate_txt.ValueChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub ExistingControlVendor_lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistingControlVendor_lst.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub ExistingControlModel_lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistingControlModel_lst.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub OriginalGONumberAvailable_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalGONumberAvailable_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub OriginalGOnumber_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalGOnumber_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub PEStampRequired_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEStampRequired_cmb.SelectedIndexChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub MinimumFloorDistance_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumFloorDistance_chk.CheckedChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub Permits_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Permits_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub Bonds_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bonds_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub ExpensesPerDay_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesPerDay_txt.TextChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
    Private Sub GatewayReviewRequired_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GatewayReviewRequired_chk.CheckedChanged
        If Not isInitializingComponent Then
            FormIsDirty = True
        End If
    End Sub
End Class
