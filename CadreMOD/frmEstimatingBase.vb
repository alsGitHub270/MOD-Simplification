Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json
Imports Microsoft.VisualBasic

Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Private sv As New FarPoint.Win.Spread.SheetView()
    Private svCollection As New System.Collections.ArrayList(10)
    Public EstimatingDataset As System.Data.DataSet
    Private OrderingDataset As System.Data.DataSet
    Private MainGroups As DataTable = Nothing
    Private SubGroups As DataTable = Nothing
    Private GeneralInfo As DataTable = Nothing
    Private OrderingInfo As DataTable = Nothing
    Private isInitializingComponent As Boolean = True
    Public FormIsDirty As Boolean

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

    Private CurParentRow As Integer = 0
    Private CurChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
    Private SheetCornerColWidth As Integer = 0
    Private EST_Filename As String = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt, CurrentGOData_Typ.Units) & "MODEST.json"
    Dim OrderingForms_spc As Object

    Private Sub CreateDataSet(ByVal CurUnits As String)
        Dim iIndex As Integer = 0, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing

        Try
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
            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderType = typeStr
            SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderType = typeStr
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_COST).HeaderType = typeInt
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_STD_HRS).HeaderType = typeInt
            SheetHeaders(MAIN_GROUP, MAIN_COL_TOTAL_SPEC_HRS).HeaderType = typeInt

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
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderType = typeStr
            SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderType = typeInt
            SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderType = typeSingle
            SheetHeaders(MATERIAL_GROUP, MAT_COL_COMMENTS).HeaderType = typeStr

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

            GeneralInfo = EstimatingDataset.Tables.Add("GeneralInfo")
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
                                         New DataColumn("Travel_txt", typeStr),
                                         New DataColumn("PitDepth_txt", typeStr),
                                         New DataColumn("RiserQtyExistingFront_Cmb", typeStr),
                                         New DataColumn("RiserQtyExistingRear_Cmb", typeStr),
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
                                         New DataColumn("Zone_txt", typeStr),
                                         New DataColumn("Parking_txt", typeStr),
                                         New DataColumn("OutOfTownExpense_txt", typeStr),
                                         New DataColumn("TravelTime_txt", typeStr),
                                         New DataColumn("Miscellaneous_txt", typeStr),
                                         New DataColumn("TotalExpensesPerDay_txt", typeStr),
                                         New DataColumn("ExpensesPerDay_txt", typeStr),
                                         New DataColumn("GatewayReviewRequired_chk", typeInt)})

            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                       FormatFileNameFromTab(TabControl1.SelectedTab.Text.Trim)) & "MODEST.json"
            Deserialize(EST_Filename, EstimatingDataset, "Error Reading Data - " & TabControl1.SelectedTab.Text, FormIsDirty)
            EstimatingDataset.Relations.Add("EstMaterials", MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In Estimating - CreateDataSet")

        End Try

    End Sub
    Private Sub PrepareThisForm()
        Dim JSONFileLocation As DirectoryInfo = New DirectoryInfo(EstimatePath)
        Dim JSONFileList As List(Of FileInfo) = New List(Of FileInfo)
        Dim UseTabName As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        isInitializingComponent = True
        DAO2ADO(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, My.Application.Info.DirectoryPath & "\", OPTION_DATABASE_NAME, True)
        Load_ListBoxes()
        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        For Each JSONFile In JSONFileLocation.GetFiles()
            If JSONFile IsNot Nothing Then
                If Path.GetExtension(JSONFile.ToString.ToUpper) = ".JSON" Then
                    If JSONFile.ToString.ToUpper.Contains("MODEST") Or JSONFile.ToString.ToUpper.Contains("MODORD") Then
                        JSONFileList.Add(JSONFile)
                    End If
                End If
            End If
        Next JSONFile
        If JSONFileList.Count = 0 Then
            CarTab.Text = CurrentUnits & EST_Suffix
            If EstimateLevel = "Master" Then
                OrderTab.Text = CurrentUnits & ORD_Suffix
            End If
        Else
            UseTabName = FormatTabName(JSONFileList(0).Name)
            CarTab.Text = UseTabName & EST_Suffix
            If JSONFileList(1).Name.ToUpper.Contains("MODORD") Then
                OrderTab.Text = UseTabName & ORD_Suffix
            End If
            For iIndex As Integer = 0 To JSONFileList.Count - 1
                UseTabName = FormatTabName(JSONFileList(iIndex).Name)
                If JSONFileList(1).Name.ToUpper.Contains("MODEST") Then
                    TabControl1.TabPages.Add(UseTabName & EST_Suffix)
                ElseIf JSONFileList(1).Name.ToUpper.Contains("MODORD") Then
                    TabControl1.TabPages.Add(UseTabName & ORD_Suffix)
                End If
            Next iIndex
        End If
        If EstimateLevel = "Base" Then
            For iIndex As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
                Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                If CurTab.Text.IndexOf(ORD_Suffix) > -1 Or CurTab.Text.Trim.Length = 0 Then
                    TabControl1.TabPages.Remove(CurTab)
                End If
            Next iIndex
            Copy_cmd.Visible = True
            Merge_cmd.Visible = True
        Else
            Copy_cmd.Visible = False
            Merge_cmd.Visible = False
        End If
        TabControl1.SelectTab(0)
        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        CurrentBillofMaterialsandTaskListFrameHeight = BillofMaterialsandTaskList_fra.Height
        ExpensesPerDayDetails_btn.Left = ExpensesPerDay_txt.Left
        Dim UseIndex As Integer = 0
        For Each Cntrl As Control In ExpensesPerDay_frm.Controls
            If TypeOf [Cntrl] Is TextBox Then
                ReDim Preserve SubcontractedLaborCost.LaborCost(UseIndex)
                SubcontractedLaborCost.LaborCost(UseIndex).Description = [Cntrl].Name
                UseIndex += 1
            End If
        Next Cntrl
        DisplayEST_vs_ORD()
        Set_Fields_Grey()
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
                SaveAll()
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
        For i As Integer = 0 To MAX_BLDG_FLRS
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
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not isInitializingComponent Then
            If PromptForSave() Then
                DisplayEST_vs_ORD()
            End If
        End If
    End Sub
    Private Sub DisplayEST_vs_ORD()

        If TabControl1.SelectedTab.Text.IndexOf(EST_Suffix) > -1 Then
            PopulateEstimating()
            CarData_fra.Visible = True
            CarData_fra.BringToFront()
            If EstimateLevel = "Master" Then
                OrderingForms_fra.Visible = False
                OrderingForms_fra.SendToBack()
            End If
        ElseIf TabControl1.SelectedTab.Text.IndexOf(ORD_Suffix) > -1 Then
            PopulateOrdering()
            OrderingForms_lst.Items.Clear()
            OrderingForms_lst.Items.Add("Governor")
            OrderingForms_con.Left = OrderingForms_lst.Left + OrderingForms_lst.Width + 3
            OrderingForms_con.Width = OrderingForms_fra.Width - OrderingForms_con.Left - 1
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
        Dim UseUnits As String = Strings.Left(TabControl1.SelectedTab.Text.Trim, TabControl1.SelectedTab.Text.Length - 6)

        FpSpread1.ActiveSheet.RowCount = 0
        CreateDataSet(UseUnits)
        model = FpSpread1.ActiveSheet.Models.Data
        For Each dt In EstimatingDataset.Tables
            dt.DefaultView.AllowNew = False
        Next dt
        model.DataMember = "EstimatingData"
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
            _row("UnitsInTab") = SplitUnitsForSave(Strings.Left(TabControl1.SelectedTab.Text, TabControl1.SelectedTab.Text.Length - 6))
            For Each Cntrl As Control In Me.Controls
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
            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                       FormatFileNameFromTab(TabControl1.SelectedTab.Text.Trim)) & "MODEST.json"
            If Not Serialize(EST_Filename, EstimatingDataset, "Error Saving Data - " & TabControl1.SelectedTab.Text, FormIsDirty) Then
                Throw New Exception
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Error Saving Estimating Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub SaveOrderingData()
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
            EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                       FormatFileNameFromTab(TabControl1.SelectedTab.Text.Trim)) & "MODORD.json"
            If Not Serialize(EST_Filename, OrderingDataset, "Error Saving Data - " & TabControl1.SelectedTab.Text, FormIsDirty) Then
                Throw New Exception
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving data", "Error Saving Ordering Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub Save_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_cmd.Click
        SaveAll()
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
        Set_Fields_Grey()
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
    Private Sub LayoutRequirements_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayoutRequirements_cmb.SelectedIndexChanged
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
    Private Sub ShortFloorOperation_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortFloorOperation_chk.CheckedChanged
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
    Private Sub Copy_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copy_cmd.Click
        ShowCopyMergeDialog(Copy_cmd.Tag)
    End Sub
    Private Sub Merge_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Merge_cmd.Click
        ShowCopyMergeDialog(Merge_cmd.Tag)
    End Sub
    Private Sub ShowCopyMergeDialog(ByVal CurButtonLabel As String)
        Dim CurUnits As String = Strings.Left(TabControl1.SelectedTab.Text.Trim, TabControl1.SelectedTab.Text.Length - 6)
        Dim iIndex As Integer = 0, AryIndex As Integer = -1

        If File.Exists(EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                                 FormatFileNameFromTab(TabControl1.SelectedTab.Text.Trim)) & "MODEST.json") Then
            If PromptForSave() Then
                ArchiveFiles()
                UnitCopyMerge_frm.Text = CurButtonLabel
                UnitCopyMerge_frm.CurUnits = CurUnits
                Erase UnitCopyMerge_frm.UnitOptions
                If CurButtonLabel.Contains("Copy") Then
                    CalculateNumberOfCarsInEstimate(CurUnits)
                    UnitCopyMerge_frm.UnitOptions = UnitsInEstimate
                ElseIf TabControl1.TabPages.Count > 1 Then
                    For iIndex = 0 To TabControl1.TabPages.Count
                        Dim CurTab As TabPage = TabControl1.TabPages(iIndex)
                        If CurTab.Text.IndexOf(EST_Suffix) > -1 And CurTab.Text <> TabControl1.SelectedTab.Text Then
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
                            If CurTab.Text = CurUnits & EST_Suffix Then
                                TabControl1.TabPages.Remove(CurTab)
                                Exit For
                            End If
                        Next iIndex
                        TabControl1.SelectTab(0)
                    End If
                End If
                DisplayEST_vs_ORD()
            End If
        Else
            MsgBox("Current data for " & TabControl1.SelectedTab.Text & " has not been saved!  Cannot continue until data has been saved", vbOKOnly, "No data file")
        End If

    End Sub
    Public Function FormatTabName(ByVal CurFileName As String) As String
        Dim ReturnVal As String = Strings.Mid(CurFileName, 14, CurFileName.Length - 24)
        Dim UnitParts() As String = ReturnVal.Split("_")

        If UnitParts.Length > 1 Then
            ReturnVal = String.Empty
            For iIndex As Integer = UnitParts.GetLowerBound(0) To UnitParts.GetUpperBound(0)
                ReturnVal &= UnitParts(iIndex) & ", "
            Next iIndex
            ReturnVal = Strings.Left(ReturnVal, ReturnVal.Length - 2)
        End If
        Return ReturnVal

    End Function
    Public Function FormatFileNameFromTab(ByVal CurTab As String) As String
        Dim ReturnVal As String = Strings.Left(CurTab, CurTab.Length - 6)
        Dim FileParts() As String = ReturnVal.Split(", ")

        If FileParts.Length > 1 Then
            ReturnVal = String.Empty
            For iIndex As Integer = FileParts.GetLowerBound(0) To FileParts.GetUpperBound(0)
                ReturnVal &= FileParts(iIndex) & "_"
            Next iIndex
            ReturnVal = Strings.Left(ReturnVal, ReturnVal.Length - 1)
        End If
        Return ReturnVal

    End Function
    Private Function PromptForSave() As Boolean
        Dim ReturnVal As Boolean = True
        Dim SaveResponse As Integer = 0

        If FormIsDirty Then
            If TabControl1.SelectedTab.Text.ToUpper.Contains(EST_Suffix) Then
                SaveResponse = MsgBox("You must save the current Estimating Data before continuing!" & Environment.NewLine & "Do you wish to save now?", MsgBoxStyle.YesNoCancel, "Save Required")
                If SaveResponse = MsgBoxResult.Yes Then
                    SaveEstimatingData()
                    ArchiveFiles()
                Else
                    ReturnVal = False
                End If
            Else
                SaveResponse = MsgBox("You must save the current Ordering Data before continuing!" & Environment.NewLine & "Do you wish to save now?", MsgBoxStyle.YesNoCancel, "Save Required")
                If SaveResponse = MsgBoxResult.Yes Then
                    SaveOrderingData()
                    ArchiveFiles()
                Else
                    ReturnVal = False
                End If
            End If
        End If
        Return ReturnVal

    End Function
    Private Sub SaveAll()
        SaveEstimatingData()
        If EstimateLevel = "Master" Then
            SaveOrderingData()
        End If
        ArchiveFiles()
    End Sub
    Private Sub Set_Fields_Grey()

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
            RiserQtyExistingRear_lbl.Enabled = False
            RiserQtyExistingRear_Cmb.SelectedIndex = -1
            RiserQtyExistingRear_Cmb.Enabled = False
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
            RiserQtyExistingRear_lbl.Enabled = True
            RiserQtyExistingRear_Cmb.Enabled = True
        End If

    End Sub
    Private Sub OrderingForms_lst_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderingForms_lst.DoubleClick
        Dim NewGovForm As New ORD_Governor_frm

        OrderingForms_con.Controls.Clear()
        NewGovForm.TopLevel = False
        NewGovForm.WindowState = FormWindowState.Maximized
        NewGovForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        NewGovForm.Visible = True
        OrderingForms_con.Controls.Clear()
        OrderingForms_con.Controls.Add(NewGovForm)

    End Sub
End Class
