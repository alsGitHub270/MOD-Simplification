﻿Option Strict Off
Option Explicit On

Module frmEstimatingBaseMOD
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

    Public EstimatingDataset As System.Data.DataSet
    Public OrderingDataset As System.Data.DataSet
    Public MainGroups As DataTable = Nothing
    Public SubGroups As DataTable = Nothing
    Public GeneralInfo As DataTable = Nothing
    Public OrderingInfo As DataTable = Nothing

    Public Const TABLENAME_MAIN As String = "EstMainGroup"
    Public Const TABLENAME_MATERIALS As String = "EstMaterials"
    Public Const TABLENAME_GENERALINFO As String = "GeneralInfo"
    Public Const TABLENAME_ORDERINFO As String = "OrderInfo"

    Public Const TABLECOL_MATERIALDESC As String = "Material Description"
    Public Const TABLECOL_MAINID As String = "MainID"
    Public Const TABLECOL_MATERIALID As String = "MaterialID"
    Public Const TABLECOL_UNITS As String = "Units"

    Public Const TABLECOL_OPTION_EST As String = "Option"
    Public Const TABLECOL_TYPE_EST As String = "Type"
    Public Const TABLECOL_ORDERBY_EST As String = "Order By"
    Public Const TABLECOL_UNITQTY_EST As String = "Unit Qty"

    Public Const TABLECOL_OPTION_BASE As String = "Option (Base)"
    Public Const TABLECOL_OPTION_ALT As String = "Option (Alt)"
    Public Const TABLECOL_TYPE_BASE As String = "Type (Base)"
    Public Const TABLECOL_TYPE_ALT As String = "Type (Alt)"
    Public Const TABLECOL_ORDERBY_BASE As String = "Order By (Base)"
    Public Const TABLECOL_ORDERBY_ALT As String = "Order By (Alt)"
    Public Const TABLECOL_UNITQTY_BASE As String = "Unit Qty (Base)"
    Public Const TABLECOL_UNITQTY_ALT As String = "Unit Qty (Alt)"

    Public Const TABLECOL_UNITCOST As String = "Unit Material Cost"
    Public Const TABLECOL_STDHOURS As String = "Unit Standard Hours"
    Public Const TABLECOL_SPECHOURS As String = "Unit Special Hours"
    Public Const TABLECOL_COMMENTS As String = "Comments"

    Public Const TABLECOL_ALTVALUES As String = "Alt Values"

    Public Const MAIN_COL_MAIN_GROUP As Integer = 0
    Public Const MAIN_COL_MAIN_ID As Integer = 1
    Public Const MAIN_COL_TOTAL_COST As Integer = 2
    Public Const MAIN_COL_TOTAL_STD_HRS As Integer = 3
    Public Const MAIN_COL_TOTAL_SPEC_HRS As Integer = 4

    Public Const MAT_COL_MATERIAL_DESC As Integer = 0
    Public Const MAT_COL_MAIN_ID As Integer = 1
    Public Const MAT_COL_MATERIAL_ID As Integer = 2
    Public Const MAT_COL_UNITS As Integer = 3
    'Estimating
    Public Const MAT_COL_OPTION_EST As Integer = 4
    Public Const MAT_COL_TYPE_EST As Integer = 5
    Public Const MAT_COL_ORDER_BY_EST As Integer = 6
    Public Const MAT_COL_QTY_EST As Integer = 7
    Public Const MAT_COL_MATERIAL_COST_EST As Integer = 8
    Public Const MAT_COL_STANDARD_HOURS_EST As Integer = 9
    Public Const MAT_COL_SPECIAL_HOURS_EST As Integer = 10
    Public Const MAT_COL_COMMENTS_EST As Integer = 11
    'Alt
    Public Const MAT_COL_OPTION_BASE As Integer = 4
    Public Const MAT_COL_OPTION_ALT As Integer = 5
    Public Const MAT_COL_TYPE_BASE As Integer = 6
    Public Const MAT_COL_TYPE_ALT As Integer = 7
    Public Const MAT_COL_ORDER_BY_BASE As Integer = 8
    Public Const MAT_COL_ORDER_BY_ALT As Integer = 9
    Public Const MAT_COL_QTY_BASE As Integer = 10
    Public Const MAT_COL_QTY_ALT As Integer = 11
    Public Const MAT_COL_MATERIAL_COST_ALT As Integer = 12
    Public Const MAT_COL_STANDARD_HOURS_ALT As Integer = 13
    Public Const MAT_COL_SPECIAL_HOURS_ALT As Integer = 14
    Public Const MAT_COL_COMMENTS_ALT As Integer = 15

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

    Public IsPOHController As Boolean = False

    Public Const COMPONENT_LIST_TABLE As String = "[Component List]"
    Public Const GROUP_SETUP_QRY As String = "GROUP_SETUP_QRY"
    Public Const MAIN_GROUP_QRY As String = "MAIN_GROUP_QRY"
    Public Const SUB_GROUP_QRY As String = "SUB_GROUP_QRY"

    ' Main ID's in table ***********************************************************************
    Public Const MAIN_ID_Controller As String = "05CON"
    Public Const MAIN_ID_ReuseGearedMachineACMotorOnly As String = "10RGD"
    Public Const MAIN_ID_NewGearedMachine As String = "15NGD"
    Public Const MAIN_ID_FMM200 As String = "20FMM"
    Public Const MAIN_ID_ReuseGearlessMachine As String = "25RGL"
    Public Const MAIN_ID_NewGearlessMachine As String = "30NGL"
    Public Const MAIN_ID_Governor As String = "35GOV"
    Public Const MAIN_ID_AscendingCarUnintendingMotion As String = "40ASC"
    Public Const MAIN_ID_CarItems As String = "45CAR"
    Public Const MAIN_ID_DoorOperator As String = "50DOP"
    Public Const MAIN_ID_CabEquipment As String = "55CAB"
    Public Const MAIN_ID_LANDINGDOOR As String = "60LND"
    Public Const MAIN_ID_Hoistway As String = "65HST"
    Public Const MAIN_ID_Fixtures As String = "70FIX"
    Public Const MAIN_ID_PIT As String = "75PIT"
    Public Const MAIN_ID_Miscellaneous As String = "80MIS"
    Public Const MAIN_ID_SubcontractingWork As String = "85SUB"

    ' Material ID's in table ***********************************************************************
    Public Const MAT_ID_Controller As String = "005CON"
    Public Const MAT_ID_SecurityPackage As String = "010CON"
    Public Const MAT_ID_IntergroupEmergencyPower As String = "020CON"
    Public Const MAT_ID_TractionBatteryLowering As String = "025CON"
    Public Const MAT_ID_CodeBlueOption As String = "030CON"
    Public Const MAT_ID_PanicFeatureRiotControl As String = "035CON"
    Public Const MAT_ID_CodePinkOption As String = "040CON"
    Public Const MAT_ID_InconspicuousRiserSoftware As String = "045CON"
    Public Const MAT_ID_CustomSoftware As String = "050CON"
    Public Const MAT_ID_Drive As String = "055CON"
    Public Const MAT_ID_Transformer As String = "060CON"
    Public Const MAT_ID_ChokeFilter As String = "065CON"
    Public Const MAT_ID_MTO As String = "070CON"
    Public Const MAT_ID_MachineRoomWiring As String = "075CON"
    Public Const MAT_ID_MachineRoomDuct As String = "080CON"
    Public Const MAT_ID_SeismicHolddowns As String = "085CON"
    Public Const MAT_ID_MachineRoomSeismicSwitch As String = "090CON"
    Public Const MAT_ID_PTG As String = "095CON"
    Public Const MAT_ID_InterfaceBoxes As String = "100CON"
    Public Const MAT_ID_ConfigurationStation As String = "105CON"
    Public Const MAT_ID_PORTSecurityType As String = "110CON"
    Public Const MAT_ID_StatisticsperYear As String = "115CON"
    Public Const MAT_ID_ACMotorRGD As String = "005RGD"
    Public Const MAT_ID_ACMotorCoupler As String = "010RGD"
    Public Const MAT_ID_MotorAdapterPlateKitforfootmountedmotorsonly As String = "015RGD"
    Public Const MAT_ID_DriveSheave As String = "020RGD"
    Public Const MAT_ID_BrakePads As String = "025RGD"
    Public Const MAT_ID_BrakeSwitchRGD As String = "030RGD"
    Public Const MAT_ID_DrainFlushSeals As String = "035RGD"
    Public Const MAT_ID_MachineBearings As String = "040RGD"
    Public Const MAT_ID_MachineNGD As String = "005NGD"
    Public Const MAT_ID_ACMotorNGD As String = "010NGD"
    Public Const MAT_ID_BrakeSwitchNGD As String = "015NGD"
    Public Const MAT_ID_MachineIsolation As String = "020NGD"
    Public Const MAT_ID_DeflectorSheaves As String = "025NGD"
    Public Const MAT_ID_SheaveGuardNGD As String = "030NGD"
    Public Const MAT_ID_BlockingAssemblyNGD As String = "035NGD"
    Public Const MAT_ID_MachineFMM As String = "005FMM"
    Public Const MAT_ID_FMM200FrameMechanicalParts As String = "010FMM"
    Public Const MAT_ID_BlockingAssemblyFMM As String = "015FMM"
    Public Const MAT_ID_STM As String = "020FMM"
    Public Const MAT_ID_AntitwistDevice As String = "025FMM"
    Public Const MAT_ID_KSSContacts As String = "030FMM"
    Public Const MAT_ID_KSSInterfaceKit As String = "035FMM"
    Public Const MAT_ID_LMSKit As String = "040FMM"
    Public Const MAT_ID_CarPulleySingleAxleAdapter As String = "045FMM"
    Public Const MAT_ID_CwtPulleySingleAxleAdapter As String = "045FMM"
    Public Const MAT_ID_CwtSeismicKit As String = "050FMM"
    Public Const MAT_ID_Encoder As String = "005RGL"
    Public Const MAT_ID_Sheave As String = "010RGL"
    Public Const MAT_ID_SheaveGuardRGL As String = "015RGL"
    Public Const MAT_ID_BrakeSwitchRGL As String = "020RGL"
    Public Const MAT_ID_BrakeWork As String = "025RGL"
    Public Const MAT_ID_FieldCoils As String = "030RGL"
    Public Const MAT_ID_BearingsSeals As String = "035RGL"
    Public Const MAT_ID_TurnUndercutCommutator As String = "040RGL"
    Public Const MAT_ID_MachineFrameandSecondarySheave As String = "005NGL"
    Public Const MAT_ID_MachineBedplateIsolation As String = "010NGL"
    Public Const MAT_ID_AssemblyTool As String = "015NGL"
    Public Const MAT_ID_ManualHandwindingDevice As String = "020NGL"
    Public Const MAT_ID_HydraulicTool As String = "025NGL"
    Public Const MAT_ID_Sheaves As String = "030NGL"
    Public Const MAT_ID_SheaveGuardNGL As String = "035NGL"
    Public Const MAT_ID_MachineDisassembly As String = "040NGL"
    Public Const MAT_ID_MachineAlignment As String = "045NGL"
    Public Const MAT_ID_GovernorCar As String = "005GOV"
    Public Const MAT_ID_GovernorMountingSlaborRail As String = "010GOV"
    Public Const MAT_ID_GovernorEncoder As String = "015GOV"
    Public Const MAT_ID_GovernerCWT As String = "020GOV"
    Public Const MAT_ID_GovernorCWTmounting As String = "025GOV"
    Public Const MAT_ID_RopeGripper As String = "005ASC"
    Public Const MAT_ID_RopeGripperMountingKit As String = "010ASC"
    Public Const MAT_ID_MachineBlockingwhenraisingmachineup As String = "015ASC"
    Public Const MAT_ID_LevelingUnit As String = "005CAR"
    Public Const MAT_ID_ETSETSL As String = "010CAR"
    Public Const MAT_ID_LoadWeighingDevice As String = "015CAR"
    Public Const MAT_ID_CarDuct As String = "020CAR"
    Public Const MAT_ID_CarTopInspectionStation As String = "025CAR"
    Public Const MAT_ID_ToeGuard As String = "030CAR"
    Public Const MAT_ID_CarTopHandRail As String = "035CAR"
    Public Const MAT_ID_CarPlatform As String = "040CAR"
    Public Const MAT_ID_CabIsolationPads As String = "045CAR"
    Public Const MAT_ID_CarSling As String = "050CAR"
    Public Const MAT_ID_CarSheaveAttachmentandGuard As String = "055CAR"
    Public Const MAT_ID_RollerGuidesCar As String = "060CAR"
    Public Const MAT_ID_CarRollerGuideAdapterPlate As String = "065CAR"
    Public Const MAT_ID_GuideShoeCovers As String = "070CAR"
    Public Const MAT_ID_CarSafety As String = "075CAR"
    Public Const MAT_ID_FrontCarDoorOperatorPackageOperatorGateSwitchHangerClutch As String = "005DOP"
    Public Const MAT_ID_FrontCarDoorOperator As String = "010DOP"
    Public Const MAT_ID_FrontClutch As String = "015DOP"
    Public Const MAT_ID_FrontCarDoorGateSwitch As String = "020DOP"
    Public Const MAT_ID_FrontCarDoorTrackHanger As String = "025DOP"
    Public Const MAT_ID_RearCarDoorOperatorPackageOperatorGateSwitchHangerClutch As String = "030DOP"
    Public Const MAT_ID_RearCarDoorOperator As String = "035DOP"
    Public Const MAT_ID_RearClutch As String = "040DOP"
    Public Const MAT_ID_RearCarDoorGateSwitch As String = "045DOP"
    Public Const MAT_ID_RearCarDoorTrackHanger As String = "050DOP"
    Public Const MAT_ID_DoorLockMonitor As String = "055DOP"
    Public Const MAT_ID_DoorRestrictor As String = "060DOP"
    Public Const MAT_ID_DoorDetectors As String = "065DOP"
    Public Const MAT_ID_NewCabComplete As String = "005CAB"
    Public Const MAT_ID_CabShell As String = "010CAB"
    Public Const MAT_ID_CeilingLighting As String = "015CAB"
    Public Const MAT_ID_EmergencyLightCanopyType As String = "020CAB"
    Public Const MAT_ID_CabReturns As String = "025CAB"
    Public Const MAT_ID_WallPanels As String = "030CAB"
    Public Const MAT_ID_CarDoor As String = "035CAB"
    Public Const MAT_ID_Handrails As String = "040CAB"
    Public Const MAT_ID_CarSill As String = "045CAB"
    Public Const MAT_ID_Fan As String = "050CAB"
    Public Const MAT_ID_EmergencyExitSwitch As String = "055CAB"
    Public Const MAT_ID_CabFlooring As String = "060CAB"
    Public Const MAT_ID_Subflooring As String = "065CAB"
    Public Const MAT_ID_CabPads As String = "070CAB"
    Public Const MAT_ID_FreightEnclosure As String = "075CAB"
    Public Const MAT_ID_Gate As String = "080CAB"
    Public Const MAT_ID_HoistwayDoorPackagetotalopenings As String = "005LND"
    Public Const MAT_ID_HoistwayDoorTracks As String = "010LND"
    Public Const MAT_ID_NylonTrackInserts As String = "015LND"
    Public Const MAT_ID_HoistwayDoorHanger As String = "020LND"
    Public Const MAT_ID_HoistwayDoorInterlocksPickups As String = "025LND"
    Public Const MAT_ID_HoistwayDoorClosers As String = "030LND"
    Public Const MAT_ID_HoistwayDoorGibs As String = "035LND"
    Public Const MAT_ID_FireTabs As String = "040LND"
    Public Const MAT_ID_HoistwayFrameComplete As String = "045LND"
    Public Const MAT_ID_SillSupports As String = "050LND"
    Public Const MAT_ID_HoistwayDoor As String = "055LND"
    Public Const MAT_ID_SightGuard As String = "060LND"
    Public Const MAT_ID_Escutheons As String = "065LND"
    Public Const MAT_ID_HoistwaySill As String = "070LND"
    Public Const MAT_ID_Astragals As String = "075LND"
    Public Const MAT_ID_HoistwayHeaders As String = "080LND"
    Public Const MAT_ID_Struts As String = "085LND"
    Public Const MAT_ID_FreightDoorPackage As String = "090LND"
    Public Const MAT_ID_TravellingCableHoistwayWiring As String = "005HST"
    Public Const MAT_ID_TravelCableHangers As String = "010HST"
    Public Const MAT_ID_HoistwayDuct As String = "015HST"
    Public Const MAT_ID_HoistRopes As String = "020HST"
    Public Const MAT_ID_Shackles As String = "025HST"
    Public Const MAT_ID_CarGovernorRope As String = "030HST"
    Public Const MAT_ID_CWTGovernorRope As String = "035HST"
    Public Const MAT_ID_CWTSheaveattachmentandGuard As String = "040HST"
    Public Const MAT_ID_CounterweightDerailmentDevice As String = "045HST"
    Public Const MAT_ID_GuideRails As String = "050HST"
    Public Const MAT_ID_RailBrackets As String = "055HST"
    Public Const MAT_ID_CounterweightFrame As String = "060HST"
    Public Const MAT_ID_CounterweightSubWeights As String = "065HST"
    Public Const MAT_ID_CwtSafety As String = "070HST"
    Public Const MAT_ID_CWTRollerGuides As String = "075HST"
    Public Const MAT_ID_CWTRollerGuideAdapterPlate As String = "080HST"
    Public Const MAT_ID_CWTGuideShoeCovers As String = "085HST"
    Public Const MAT_ID_HoistwayScreening As String = "090HST"
    Public Const MAT_ID_HoistwayLimitSwitch As String = "095HST"
    Public Const MAT_ID_Fascia As String = "100HST"
    Public Const MAT_ID_RopeSplayClamp As String = "105HST"
    Public Const MAT_ID_POEBoxesandconnectioncables As String = "110HST"
    Public Const MAT_ID_POEBoxesforTurnstileApplication As String = "115HST"
    Public Const MAT_ID_DestinationWiringinft As String = "120HST"
    Public Const MAT_ID_AdditionalDuctforPHASEMODDIinft As String = "125HST"
    Public Const MAT_ID_AdditonalTravelingCableforPHASEMODDI As String = "130HST"
    Public Const MAT_ID_MainCarStation As String = "005FIX"
    Public Const MAT_ID_AuxCarStation As String = "010FIX"
    Public Const MAT_ID_CarTravelingLantern As String = "015FIX"
    Public Const MAT_ID_CarPositionIndicatorInTransom As String = "020FIX"
    Public Const MAT_ID_VoiceAnnunciator As String = "025FIX"
    Public Const MAT_ID_HandsFreePhone As String = "030FIX"
    Public Const MAT_ID_MainFloorHallStationsEgress As String = "035FIX"
    Public Const MAT_ID_TypicalFloorHallStations As String = "040FIX"
    Public Const MAT_ID_HallPositionIndicator As String = "045FIX"
    Public Const MAT_ID_HallLantern As String = "050FIX"
    Public Const MAT_ID_HallPILanternCombo As String = "055FIX"
    Public Const MAT_ID_HoistwayAccessSwitch As String = "060FIX"
    Public Const MAT_ID_FireEmergencyRecallSwitchifseparate As String = "065FIX"
    Public Const MAT_ID_PhoneLineMonitoringifseparate As String = "070FIX"
    Public Const MAT_ID_InconspicuousRisers As String = "075FIX"
    Public Const MAT_ID_JambBraille As String = "080FIX"
    Public Const MAT_ID_EmergencyPowerPanelifseparate As String = "085FIX"
    Public Const MAT_ID_FireCommandCenterPanel As String = "090FIX"
    Public Const MAT_ID_LobbyStatusPanel As String = "095FIX"
    Public Const MAT_ID_LobbyVisionMachineRoom As String = "100FIX"
    Public Const MAT_ID_LobbyVisionOther As String = "105FIX"
    Public Const MAT_ID_IntercomSystem As String = "110FIX"
    Public Const MAT_ID_DesignationSignageStatic As String = "115FIX"
    Public Const MAT_ID_DesignationSignageActive As String = "120FIX"
    Public Const MAT_ID_BrailleAddDestinatononly As String = "125FIX"
    Public Const MAT_ID_TemporaryDestinationIndicators As String = "130FIX"
    Public Const MAT_ID_DestinationIndicators As String = "135FIX"
    Public Const MAT_ID_TempCOPCoversMain As String = "140FIX"
    Public Const MAT_ID_TempCOPCoversAux As String = "145FIX"
    Public Const MAT_ID_LobbyPORTDevices As String = "150FIX"
    Public Const MAT_ID_FrontTypicalPORTDevices As String = "155FIX"
    Public Const MAT_ID_RearTypicalPORTDevices As String = "160FIX"
    Public Const MAT_ID_SparePORTDevicesType1 As String = "165FIX"
    Public Const MAT_ID_SparePORTDevicesType2 As String = "170FIX"
    Public Const MAT_ID_SparePORTDevicesType3 As String = "175FIX"
    Public Const MAT_ID_PedestalBase As String = "180FIX"
    Public Const MAT_ID_BackPlates As String = "185FIX"
    Public Const MAT_ID_Platestocoverexistingholes As String = "190FIX"
    Public Const MAT_ID_CarBuffer As String = "005PIT"
    Public Const MAT_ID_CarBufferBlockingStand As String = "010PIT"
    Public Const MAT_ID_CarBufferBlockingSupport As String = "015PIT"
    Public Const MAT_ID_CarBufferFootingChannels As String = "020PIT"
    Public Const MAT_ID_CwtBuffer As String = "025PIT"
    Public Const MAT_ID_CwtBufferBlockingStand As String = "030PIT"
    Public Const MAT_ID_CwtBufferBlockingSupport As String = "035PIT"
    Public Const MAT_ID_CwtBufferFootingChannels As String = "040PIT"
    Public Const MAT_ID_BufferSwitchCar As String = "045PIT"
    Public Const MAT_ID_BufferSwitchCwt As String = "050PIT"
    Public Const MAT_ID_GovernorTensionSheaveCar As String = "055PIT"
    Public Const MAT_ID_GovernorTensionSheaveCwt As String = "060PIT"
    Public Const MAT_ID_PitSwitch As String = "065PIT"
    Public Const MAT_ID_PitLadder As String = "070PIT"
    Public Const MAT_ID_PitLight As String = "075PIT"
    Public Const MAT_ID_PitFloodSwitch As String = "080PIT"
    Public Const MAT_ID_SumpPumpCoverforexisting As String = "085PIT"
    Public Const MAT_ID_WhisperFlexCompensationHitch As String = "090PIT"
    Public Const MAT_ID_WhisperFlex As String = "095PIT"
    Public Const MAT_ID_SwayDevice As String = "100PIT"
    Public Const MAT_ID_CompensationRope As String = "105PIT"
    Public Const MAT_ID_CompensationSheave As String = "110PIT"
    Public Const MAT_ID_CompensationSwitch As String = "115PIT"
    Public Const MAT_ID_CounterweightGuard As String = "120PIT"
    Public Const MAT_ID_CleaningandPainting As String = "005MIS"
    Public Const MAT_ID_SystemAdjusting As String = "010MIS"
    Public Const MAT_ID_SAISInspection As String = "015MIS"
    Public Const MAT_ID_ConsultantGSAInspection As String = "020MIS"
    Public Const MAT_ID_FireServiceEPTesting As String = "025MIS"
    Public Const MAT_ID_StandbyTime As String = "030MIS"
    Public Const MAT_ID_MachineRoomSpecialAccess As String = "035MIS"
    Public Const MAT_ID_TestingandComissioningforPORT As String = "040MIS"
    Public Const MAT_ID_Miscelleneous As String = "045MIS"
    Public Const MAT_ID_IncrementalBlankLineMIS As String = "900MIS"
    Public Const MAT_ID_FrontRecladding As String = "005SUB"
    Public Const MAT_ID_NitroCleaning As String = "010SUB"
    Public Const MAT_ID_FireAlarmSystem As String = "015SUB"
    Public Const MAT_ID_ElectricalWork As String = "020SUB"
    Public Const MAT_ID_CabWork As String = "025SUB"
    Public Const MAT_ID_BuildingGCWork As String = "030SUB"
    Public Const MAT_ID_Crane As String = "035SUB"
    Public Const MAT_ID_ThirdPartySecurityCompanyFee As String = "040SUB"
    Public Const MAT_ID_IncrementalBlankLineSUB As String = "900SUB"

    Public UseTypeCol As String = TABLECOL_TYPE_EST, UseOptionCol As String = TABLECOL_OPTION_EST, UseOrderByCol As String = TABLECOL_ORDERBY_EST
    Public UseUnitQtyCol As String = TABLECOL_UNITQTY_EST

    Public Sub GetCostHours(ByVal MaterialID As String, ByVal CurOption As String, ByVal CurType As String, ByVal CurOrderBy As String,
                            ByVal CostOrHours As String, ByRef CurField As Single, ByVal CurQty As Integer)
        Dim UseWhere As String = "[Sub ID] = '" & MaterialID & "'"
        Dim MachineType As String = GEARLESS_TYPE
        Dim UseFrontWidth As Single = 0, UseFrontHeight As Single = 0, UseRearWidth As Single = 0, UseRearHeight As Single = 0
        Dim UseMaterialItemRecordSet As New ADODB.Recordset
        Dim UseField As String = String.Empty
        Dim TotalTravel As Single = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Travel_txt")) +
                                    Conversion.Val(GetValue(TABLENAME_GENERALINFO, "TopFloorToOverhead_txt")) +
                                    Conversion.Val(GetValue(TABLENAME_GENERALINFO, "PitDepth_txt"))
        Dim FrontOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsFront_cmb"))
        Dim RearOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsRear_cmb"))
        Dim TotalOpenings As Integer = FrontOpenings + RearOpenings
        Dim AddValue As Boolean = False

        Try
            If String.IsNullOrEmpty(CurOption) Then
                Exit Sub
            End If
            If String.IsNullOrEmpty(CurOrderBy) Then
                Exit Sub
            ElseIf CurOrderBy = "RL" Then
                Exit Sub
            End If
            Try
                Select Case CurOption
                    Case "New"
                        UseField = "Labor Hours - New"
                    Case "Reuse"
                        UseField = "Labor Hours - Reuse"
                    Case "Refurbish"
                        UseField = "Labor Hours - Refurbish"
                    Case Else
                        UseField = String.Empty
                End Select
                UseMaterialItemRecordSet = New ADODB.Recordset
                UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    Select Case MaterialID
                        Case MAT_ID_Controller
                            UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            If Not IsPOHController Then
                                                UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                    UseMaterialItemRecordSet.MoveFirst()
                                                    Do Until UseMaterialItemRecordSet.EOF
                                                        Select Case UseMaterialItemRecordSet.Fields("Usage").Value
                                                            Case MACHINE_FMM200
                                                                If GetValue(TABLENAME_GENERALINFO, "MachineType_cmb") = MACHINE_FMM200 Then
                                                                    CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                                End If
                                                            Case "Haughton or Otis"
                                                                If Not String.IsNullOrEmpty(GetValue(TABLENAME_GENERALINFO, "ExistingControlVendor_lst")) Then
                                                                    Select Case GetValue(TABLENAME_GENERALINFO, "ExistingControlVendor_lst").ToUpper
                                                                        Case "HAUGHTON", "OTIS"
                                                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                                        Case Else
                                                                    End Select
                                                                End If
                                                            Case "spare parts kit"
                                                                CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                            Case Else
                                                        End Select
                                                        UseMaterialItemRecordSet.MoveNext()
                                                    Loop
                                                End If
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_SecurityPackage, MAT_ID_IntergroupEmergencyPower, MAT_ID_TractionBatteryLowering, MAT_ID_CodeBlueOption, MAT_ID_PanicFeatureRiotControl,
                             MAT_ID_CodePinkOption, MAT_ID_InconspicuousRiserSoftware, MAT_ID_CustomSoftware, MAT_ID_MTO, MAT_ID_MachineRoomWiring,
                             MAT_ID_MachineRoomDuct, MAT_ID_SeismicHolddowns, MAT_ID_MachineRoomSeismicSwitch, MAT_ID_PTG, MAT_ID_InterfaceBoxes,
                             MAT_ID_StatisticsperYear, MAT_ID_DriveSheave, MAT_ID_BrakePads, MAT_ID_DrainFlushSeals, MAT_ID_MachineBearings,
                             MAT_ID_SheaveGuardNGD, MAT_ID_Sheave, MAT_ID_SheaveGuardRGL, MAT_ID_BrakeWork, MAT_ID_FieldCoils,
                             MAT_ID_BearingsSeals, MAT_ID_TurnUndercutCommutator, MAT_ID_Sheaves, MAT_ID_SheaveGuardNGL, MAT_ID_MachineAlignment,
                             MAT_ID_MachineBlockingwhenraisingmachineup, MAT_ID_CarDuct, MAT_ID_ToeGuard, MAT_ID_CarPlatform, MAT_ID_CabIsolationPads,
                             MAT_ID_CarSling, MAT_ID_CarSheaveAttachmentandGuard, MAT_ID_DoorLockMonitor, MAT_ID_NewCabComplete, MAT_ID_CabShell,
                             MAT_ID_CeilingLighting, MAT_ID_EmergencyLightCanopyType, MAT_ID_CabReturns, MAT_ID_WallPanels, MAT_ID_CarDoor, MAT_ID_Handrails,
                             MAT_ID_CarSill, MAT_ID_Fan, MAT_ID_CabFlooring, MAT_ID_Subflooring, MAT_ID_CabPads, MAT_ID_FreightEnclosure, MAT_ID_Gate,
                             MAT_ID_HoistwayDoorPackagetotalopenings, MAT_ID_HoistwayDoorTracks, MAT_ID_NylonTrackInserts, MAT_ID_HoistwayDoorHanger,
                             MAT_ID_HoistwayDoorInterlocksPickups, MAT_ID_HoistwayDoorClosers, MAT_ID_HoistwayDoorGibs, MAT_ID_FireTabs,
                             MAT_ID_HoistwayFrameComplete, MAT_ID_SillSupports, MAT_ID_HoistwayDoor, MAT_ID_SightGuard, MAT_ID_Escutheons,
                             MAT_ID_HoistwaySill, MAT_ID_Astragals, MAT_ID_HoistwayHeaders, MAT_ID_Struts, MAT_ID_FreightDoorPackage,
                             MAT_ID_TravelCableHangers, MAT_ID_HoistwayDuct, MAT_ID_CWTSheaveattachmentandGuard, MAT_ID_CounterweightDerailmentDevice,
                             MAT_ID_GuideRails, MAT_ID_RailBrackets, MAT_ID_CounterweightFrame, MAT_ID_CounterweightSubWeights, MAT_ID_HoistwayScreening,
                             MAT_ID_Fascia, MAT_ID_POEBoxesandconnectioncables, MAT_ID_POEBoxesforTurnstileApplication, MAT_ID_DestinationWiringinft,
                             MAT_ID_AdditionalDuctforPHASEMODDIinft, MAT_ID_AdditonalTravelingCableforPHASEMODDI, MAT_ID_CarTravelingLantern,
                             MAT_ID_CarPositionIndicatorInTransom, MAT_ID_VoiceAnnunciator, MAT_ID_HandsFreePhone, MAT_ID_MainFloorHallStationsEgress,
                             MAT_ID_HallPositionIndicator, MAT_ID_HallLantern, MAT_ID_HallPILanternCombo, MAT_ID_HoistwayAccessSwitch,
                             MAT_ID_FireEmergencyRecallSwitchifseparate, MAT_ID_PhoneLineMonitoringifseparate, MAT_ID_InconspicuousRisers, MAT_ID_JambBraille,
                             MAT_ID_EmergencyPowerPanelifseparate, MAT_ID_FireCommandCenterPanel, MAT_ID_LobbyStatusPanel, MAT_ID_IntercomSystem,
                             MAT_ID_TemporaryDestinationIndicators, MAT_ID_TempCOPCoversMain, MAT_ID_TempCOPCoversAux, MAT_ID_Platestocoverexistingholes,
                             MAT_ID_CarBufferBlockingStand, MAT_ID_CwtBufferBlockingStand, MAT_ID_BufferSwitchCar, MAT_ID_BufferSwitchCwt, MAT_ID_PitLight,
                             MAT_ID_PitFloodSwitch, MAT_ID_SumpPumpCoverforexisting, MAT_ID_SwayDevice, MAT_ID_CompensationSheave,
                             MAT_ID_CompensationSwitch, MAT_ID_CounterweightGuard, MAT_ID_CleaningandPainting, MAT_ID_SystemAdjusting, MAT_ID_SAISInspection,
                             MAT_ID_ConsultantGSAInspection, MAT_ID_FireServiceEPTesting, MAT_ID_StandbyTime, MAT_ID_MachineRoomSpecialAccess,
                             MAT_ID_TestingandComissioningforPORT, MAT_ID_Miscelleneous, MAT_ID_FrontRecladding, MAT_ID_NitroCleaning,
                             MAT_ID_FireAlarmSystem, MAT_ID_ElectricalWork, MAT_ID_CabWork, MAT_ID_BuildingGCWork, MAT_ID_Crane,
                             MAT_ID_ThirdPartySecurityCompanyFee
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_CwtSeismicKit
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            CurField *= 77 + (1.25 * TotalTravel)
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_LevelingUnit
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            CurField *= (11.75 * TotalOpenings) + (11.25 * 2) + (11.75 * (TotalOpenings / 6))
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                    If Conversion.Val(GetValue(TABLENAME_GENERALINFO, "SpeedNew_cmb")) < 200 Then
                                        UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                        If UseMaterialItemRecordSet.RecordCount > 0 Then
                                            UseMaterialItemRecordSet.MoveFirst()
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        End If
                                    End If
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_Drive, MAT_ID_Transformer, MAT_ID_ChokeFilter, MAT_ID_ConfigurationStation, MAT_ID_PORTSecurityType, MAT_ID_ACMotorRGD,
                             MAT_ID_ACMotorCoupler, MAT_ID_MotorAdapterPlateKitforfootmountedmotorsonly, MAT_ID_BrakeSwitchRGD, MAT_ID_MachineNGD,
                             MAT_ID_ACMotorNGD, MAT_ID_BrakeSwitchNGD, MAT_ID_MachineIsolation, MAT_ID_DeflectorSheaves, MAT_ID_BlockingAssemblyNGD,
                             MAT_ID_MachineFMM, MAT_ID_FMM200FrameMechanicalParts, MAT_ID_STM, MAT_ID_AntitwistDevice, MAT_ID_KSSContacts,
                             MAT_ID_KSSInterfaceKit, MAT_ID_LMSKit, MAT_ID_CarPulleySingleAxleAdapter, MAT_ID_Encoder, MAT_ID_BrakeSwitchRGL,
                             MAT_ID_MachineFrameandSecondarySheave, MAT_ID_MachineBedplateIsolation, MAT_ID_AssemblyTool, MAT_ID_ManualHandwindingDevice,
                             MAT_ID_HydraulicTool, MAT_ID_MachineDisassembly, MAT_ID_GovernorCar, MAT_ID_GovernorMountingSlaborRail, MAT_ID_GovernorEncoder,
                             MAT_ID_GovernerCWT, MAT_ID_GovernorCWTmounting, MAT_ID_RopeGripper, MAT_ID_RopeGripperMountingKit, MAT_ID_LevelingUnit,
                             MAT_ID_ETSETSL, MAT_ID_LoadWeighingDevice, MAT_ID_ETSETSL, MAT_ID_LoadWeighingDevice, MAT_ID_CarTopHandRail,
                             MAT_ID_RollerGuidesCar, MAT_ID_CarRollerGuideAdapterPlate, MAT_ID_GuideShoeCovers,
                             MAT_ID_FrontCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_FrontCarDoorOperator, MAT_ID_FrontClutch,
                             MAT_ID_FrontCarDoorGateSwitch, MAT_ID_FrontCarDoorTrackHanger, MAT_ID_RearCarDoorOperatorPackageOperatorGateSwitchHangerClutch,
                             MAT_ID_RearCarDoorOperator, MAT_ID_RearClutch, MAT_ID_RearCarDoorGateSwitch, MAT_ID_RearCarDoorTrackHanger,
                             MAT_ID_DoorRestrictor, MAT_ID_EmergencyExitSwitch, MAT_ID_HoistRopes, MAT_ID_CarGovernorRope, MAT_ID_CWTGovernorRope,
                             MAT_ID_CWTRollerGuides, MAT_ID_CWTRollerGuideAdapterPlate, MAT_ID_CWTGuideShoeCovers, MAT_ID_RopeSplayClamp,
                             MAT_ID_MainCarStation, MAT_ID_AuxCarStation, MAT_ID_TypicalFloorHallStations, MAT_ID_LobbyVisionMachineRoom,
                             MAT_ID_LobbyVisionOther, MAT_ID_DesignationSignageStatic, MAT_ID_DesignationSignageActive, MAT_ID_BrailleAddDestinatononly,
                             MAT_ID_DestinationIndicators, MAT_ID_LobbyPORTDevices, MAT_ID_FrontTypicalPORTDevices, MAT_ID_RearTypicalPORTDevices,
                             MAT_ID_SparePORTDevicesType1, MAT_ID_SparePORTDevicesType2, MAT_ID_SparePORTDevicesType3, MAT_ID_PedestalBase,
                             MAT_ID_BackPlates, MAT_ID_CarBuffer, MAT_ID_CarBufferBlockingSupport, MAT_ID_CarBufferFootingChannels, MAT_ID_CwtBuffer,
                             MAT_ID_CwtBufferBlockingSupport, MAT_ID_CwtBufferFootingChannels, MAT_ID_GovernorTensionSheaveCar,
                             MAT_ID_GovernorTensionSheaveCwt, MAT_ID_PitSwitch, MAT_ID_PitLadder, MAT_ID_WhisperFlexCompensationHitch,
                             MAT_ID_CompensationRope
                            UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_CarTopInspectionStation
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            UseField = String.Empty
                                            Select Case Contracts.JobState
                                                Case "WA"
                                                    If Contracts.JobCity = "Seattle" Then
                                                        UseField = "Light Test Switch Assembly"
                                                    Else
                                                        UseField = "CMTS Work Light"
                                                    End If
                                                Case "MI", "OR"
                                                    UseField = "CMTS Work Light"
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(UseField) Then
                                                UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder' AND Types = '" & UseField & "'"
                                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                    UseMaterialItemRecordSet.MoveFirst()
                                                    CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                End If
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_CarSafety, MAT_ID_CwtSafety
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                UseMaterialItemRecordSet.MoveFirst()
                                                Do Until UseMaterialItemRecordSet.EOF
                                                    CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                    UseMaterialItemRecordSet.MoveNext()
                                                Loop
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_DoorDetectors
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            If CurType.IndexOf("Minimax") > -1 And RearOpenings > 0 Then
                                                UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                    UseMaterialItemRecordSet.MoveFirst()
                                                    CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                End If
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_TravellingCableHoistwayWiring
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            If CurType.IndexOf("Travelling Cable + Hoistway Wiring") > -1 Then
                                                CurField += 1000 + (12 * TotalTravel)
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_Shackles
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            If Contracts.JobState = "NY" And Contracts.JobCity = "New York" Then
                                                UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                    UseMaterialItemRecordSet.MoveFirst()
                                                    CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                End If
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case MAT_ID_HoistwayLimitSwitch
                            Select Case CurOption
                                Case "New"
                                    UseMaterialItemRecordSet.Filter = UseWhere
                                    AddValue = True
                                Case "Refurbish"
                                    UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                                    AddValue = True
                                Case Else
                                    AddValue = False
                            End Select
                            If AddValue Then
                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                    UseMaterialItemRecordSet.MoveFirst()
                                    If CostOrHours = "Cost" Then
                                        Select Case CurOption
                                            Case "New"
                                                CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            Case "Reuse"
                                                CurField = 0
                                            Case Else
                                        End Select
                                    ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                        If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                            CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                        End If
                                    End If
                                End If
                            End If
                        Case MAT_ID_WhisperFlex
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                If CostOrHours = "Cost" Then
                                    Select Case CurOption
                                        Case "New"
                                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                                If CurType.IndexOf("WF10") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF15") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF20") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF25") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF30") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF35") > -1 Then
                                                    UseField = "WF10"
                                                ElseIf CurType.IndexOf("WF40") > -1 Then
                                                    UseField = "WF10"
                                                Else
                                                    UseField = String.Empty
                                                End If
                                                If Not String.IsNullOrEmpty(UseField) Then
                                                    UseMaterialItemRecordSet.MoveFirst()
                                                    Do Until UseMaterialItemRecordSet.EOF
                                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseField) > -1 Then
                                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                            Exit Do
                                                        End If
                                                        UseMaterialItemRecordSet.MoveNext()
                                                    Loop
                                                End If
                                            End If
                                        Case "Reuse"
                                            CurField = 0
                                        Case Else
                                    End Select
                                ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                        CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                    End If
                                End If
                            End If
                        Case Else
                    End Select
                End If
                UseMaterialItemRecordSet.Close()
                CurField = Math.Round(CurField, 2)

            Catch ex As Exception
                Dim ComponentDesc As String = String.Empty

                UseMaterialItemRecordSet.Close()
                UseMaterialItemRecordSet = New ADODB.Recordset
                UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    UseMaterialItemRecordSet.Filter = "[Sub ID] = '" & MaterialID & "'"
                    UseMaterialItemRecordSet.MoveFirst()
                    ComponentDesc = UseMaterialItemRecordSet.Fields("Sub").Value.ToString
                End If
                UseMaterialItemRecordSet.Close()
                MessageBox.Show("Error retrieving " & CostOrHours & " for " & ComponentDesc, "Error Retrieving " & CostOrHours & " Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In GetCostHours")

        End Try

    End Sub
    Public Function SetSPRCombo(ByVal ArrayType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ReturnCmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim CurMATID As String = CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text
        Dim UseWhere As String = "[Sub ID] = '" & CurMATID & "'"
        Dim Options As String() = Nothing, TempAry As String() = Nothing
        Dim iIndex As Integer = 0, TempIndex As Integer = 0
        Dim UseFieldName As String = String.Empty, CurValue As String = String.Empty
        Dim UseMaterialItemRecordSet As New ADODB.Recordset
        Dim AddToOptions As Boolean = True
        Dim NumberOfFrontOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsFront_cmb"))
        Dim NumberOfRearOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsRear_cmb"))
        Dim OEMVendor As String = GetValue(TABLENAME_GENERALINFO, "ExistingControlVendor_lst")
        Dim OEMModel As String = GetValue(TABLENAME_GENERALINFO, "ExistingControlModel_lst")

        Try
            If Math.Round(Conversion.Val(CurMATID)) > 900 Then
                CurMATID = "900" & Strings.Right(CurMATID, 3)
                UseWhere = "[Sub ID] = '" & CurMATID & "'"
            End If
            UseMaterialItemRecordSet = New ADODB.Recordset
            UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
            If UseMaterialItemRecordSet.RecordCount > 0 Then
                UseMaterialItemRecordSet.Filter = UseWhere
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    UseMaterialItemRecordSet.MoveFirst()
                    Erase Options
                    Select Case ArrayType
                        Case "Options"
                            If IsDBNull(UseMaterialItemRecordSet.Fields("Options").Value) Then
                                Options = {"New", "Reuse", "Refurbish"}
                            Else
                                AddToOptions = True
                                Select Case CurMATID
                                    Case MAT_ID_GovernorTensionSheaveCar, MAT_ID_GovernorTensionSheaveCwt
                                        UseFieldName = GetValue(TABLENAME_MATERIALS, UseTypeCol, MAIN_ID_Governor, MAT_ID_GovernorCar)
                                        If String.IsNullOrEmpty(UseFieldName) Then
                                            AddToOptions = False
                                        Else
                                            If UseFieldName.IndexOf("GB") > -1 Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") = -1 Then
                                                    AddToOptions = False
                                                Else
                                                    Options = {"Included"}
                                                End If
                                            ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) = -1 Then
                                                AddToOptions = False
                                            End If
                                        End If
                                    Case Else
                                End Select
                                If AddToOptions Then
                                    Do Until UseMaterialItemRecordSet.EOF
                                        TempAry = UseMaterialItemRecordSet.Fields("Options").Value.ToString.Split("/")
                                        If IsNothing(Options) Then
                                            Options = TempAry
                                        Else
                                            For iIndex = 0 To TempAry.GetUpperBound(0)
                                                If Array.BinarySearch(Options, TempAry(iIndex)) = -1 Then
                                                    TempIndex = Options.Length + 1
                                                    Array.Resize(Options, TempIndex)
                                                    Options(TempIndex - 1) = TempAry(iIndex)
                                                End If
                                            Next iIndex
                                        End If
                                        UseMaterialItemRecordSet.MoveNext()
                                    Loop
                                End If
                            End If
                        Case "Types"
                            Do Until UseMaterialItemRecordSet.EOF
                                If Not IsDBNull(UseMaterialItemRecordSet.Fields("Types").Value) And IsDBNull(UseMaterialItemRecordSet.Fields("Usage").Value) Then
                                    AddToOptions = False
                                    Select Case CurMATID
                                        Case MAT_ID_TractionBatteryLowering
                                            Select Case GetValue(TABLENAME_MATERIALS, UseTypeCol, MAIN_ID_Controller, MAT_ID_Drive)
                                                Case "VF33BR", "VF44BR"
                                                    AddToOptions = True
                                                Case Else
                                            End Select
                                        Case MAT_ID_Drive
                                            UseFieldName = String.Empty
                                            If IsPOHController Then
                                                UseFieldName = "POH"
                                            Else
                                                Select Case GetValue(TABLENAME_GENERALINFO, "DriveType_cmb")
                                                    Case AC_TYPE
                                                        UseFieldName = "BR"
                                                    Case AC_REGEN_TYPE
                                                        UseFieldName = "PF1"
                                                    Case QUATTRO_TYPE
                                                        UseFieldName = "Quattro"
                                                    Case DC_TYPE
                                                        UseFieldName = "DSD"
                                                    Case Else
                                                End Select
                                            End If
                                            If Not String.IsNullOrEmpty(UseFieldName) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case MAT_ID_Transformer
                                            UseFieldName = String.Empty
                                            If IsPOHController Then
                                                UseFieldName = "POH"
                                            Else
                                                Select Case GetValue(TABLENAME_GENERALINFO, "DriveType_cmb")
                                                    Case AC_TYPE, AC_REGEN_TYPE
                                                        UseFieldName = "VF"
                                                    Case QUATTRO_TYPE
                                                        UseFieldName = "Quattro"
                                                    Case DC_TYPE
                                                        UseFieldName = "DSD"
                                                    Case Else
                                                End Select
                                            End If
                                            If Not String.IsNullOrEmpty(UseFieldName) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case MAT_ID_ChokeFilter
                                            UseFieldName = String.Empty
                                            If IsPOHController Then
                                                UseFieldName = "POH"
                                            Else
                                                Select Case GetValue(TABLENAME_GENERALINFO, "DriveType_cmb")
                                                    Case QUATTRO_TYPE
                                                        UseFieldName = "Quattro"
                                                    Case DC_TYPE
                                                        UseFieldName = "DSD"
                                                    Case Else
                                                End Select
                                            End If
                                            If Not String.IsNullOrEmpty(UseFieldName) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case MAT_ID_MachineNGD
                                            Select Case GetValue(TABLENAME_GENERALINFO, "MachineLocation_Cmb")
                                                Case "Overhead", "Basement"
                                                    If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GetValue(TABLENAME_GENERALINFO, "MachineLocation_Cmb")) > -1 Then
                                                        AddToOptions = True
                                                    End If
                                                Case Else
                                                    AddToOptions = True
                                            End Select
                                        Case MAT_ID_GovernorCar, MAT_ID_GovernerCWT
                                            If IsPOHController And UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") > -1 Then
                                                AddToOptions = False
                                            Else
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_GovernorEncoder
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Rim Mounted") > -1 Then
                                                If GetValue(TABLENAME_MATERIALS, UseOptionCol, MAIN_ID_Governor, MAT_ID_GovernorCar).IndexOf("Reuse") > -1 Then
                                                    AddToOptions = True
                                                End If
                                            Else
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_ETSETSL, MAT_ID_LoadWeighingDevice, MAT_ID_CarTopInspectionStation
                                            If IsPOHController Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                                    AddToOptions = True
                                                End If
                                            Else
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_CarTopHandRail
                                            UseFieldName = String.Empty
                                            If NumberOfFrontOpenings > 0 And NumberOfRearOpenings > 0 Then
                                                UseFieldName = "Front & Rear Opening"
                                            ElseIf NumberOfFrontOpenings > 0 Then
                                                UseFieldName = "Front Opening"
                                            End If
                                            If Not String.IsNullOrEmpty(UseFieldName) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case MAT_ID_FrontCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_FrontCarDoorOperator,
                                             MAT_ID_FrontClutch, MAT_ID_FrontCarDoorGateSwitch, MAT_ID_FrontCarDoorTrackHanger,
                                             MAT_ID_RearCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_RearCarDoorOperator,
                                             MAT_ID_RearClutch, MAT_ID_RearCarDoorGateSwitch, MAT_ID_RearCarDoorTrackHanger, MAT_ID_DoorDetectors
                                            If IsPOHController Then
                                                AddToOptions = True
                                            ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") = -1 Then
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_HoistRopes
                                            If (GetValue(TABLENAME_GENERALINFO, "RopingNew_Cmb").IndexOf("1:1") > -1 And
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("1:1") > -1) AndAlso
                                               ((GetValue(TABLENAME_GENERALINFO, "MachineType_cmb").IndexOf(GEARED_TYPE) > -1 And
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GEARED_TYPE) > -1) Or
                                               (GetValue(TABLENAME_GENERALINFO, "MachineType_cmb").IndexOf(GEARLESS_TYPE) > -1 And
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GEARLESS_TYPE) > -1)) Then
                                                AddToOptions = True
                                            ElseIf (GetValue(TABLENAME_GENERALINFO, "RopingNew_Cmb").IndexOf("2:1") > -1 And
                                                   UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("2:1") > -1) AndAlso
                                                   ((GetValue(TABLENAME_GENERALINFO, "MachineType_cmb").IndexOf(GEARED_TYPE) > -1 And
                                                   UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GEARED_TYPE) > -1) Or
                                                   (GetValue(TABLENAME_GENERALINFO, "MachineType_cmb").IndexOf(GEARLESS_TYPE) > -1 And
                                                   UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GEARLESS_TYPE) > -1)) Then
                                                AddToOptions = True
                                            ElseIf (UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("FMR") > -1 Or
                                                   UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("PMR") > -1) Then
                                                If Not IsPOHController Then
                                                    AddToOptions = True
                                                End If
                                            ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Basement") > -1 Then
                                                If GetValue(TABLENAME_GENERALINFO, "MachineLocation_Cmb") = "Basement" Then
                                                    AddToOptions = True
                                                End If
                                            Else
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_HoistwayLimitSwitch
                                            Select Case GetValue(TABLENAME_MATERIALS, UseOptionCol, MAIN_ID_Hoistway, MAT_ID_HoistwayLimitSwitch)
                                                Case "New"
                                                    AddToOptions = True
                                                Case "Refurbish"
                                                    If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(OEMVendor) > -1 Then
                                                        AddToOptions = True
                                                    End If
                                                Case Else
                                            End Select
                                        Case MAT_ID_LobbyPORTDevices, MAT_ID_FrontTypicalPORTDevices, MAT_ID_RearTypicalPORTDevices, MAT_ID_SparePORTDevicesType1,
                                             MAT_ID_SparePORTDevicesType2, MAT_ID_SparePORTDevicesType3
                                            If Not IsPOHController Then
                                                If Contracts.JobState = "CA" Then
                                                    If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("CA") > -1 Then
                                                        AddToOptions = True
                                                    End If
                                                ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("CA") = -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case MAT_ID_PedestalBase
                                            If Not IsPOHController Then
                                                AddToOptions = True
                                            End If
                                        Case MAT_ID_CarBuffer, MAT_ID_CwtBuffer
                                            Select Case Math.Round(Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Application_cmb")))
                                                Case Is = 0
                                                    UseFieldName = String.Empty
                                                Case Is <= 100
                                                    Select Case GetValue(TABLENAME_GENERALINFO, "Application_cmb")
                                                        Case "Passenger"
                                                            UseFieldName = "100 fpm (passenger)"
                                                        Case "Freight"
                                                            UseFieldName = "100 fpm (freight)"
                                                        Case Else
                                                            UseFieldName = String.Empty
                                                    End Select
                                                Case Is <= 150
                                                    Select Case GetValue(TABLENAME_GENERALINFO, "Application_cmb")
                                                        Case "Passenger"
                                                            UseFieldName = "150 fpm (passenger)"
                                                        Case "Freight"
                                                            UseFieldName = "150 fpm (freight)"
                                                        Case Else
                                                            UseFieldName = String.Empty
                                                    End Select
                                                Case Is <= 200
                                                    Select Case GetValue(TABLENAME_GENERALINFO, "Application_cmb")
                                                        Case "Passenger"
                                                            UseFieldName = "200 fpm (passenger)"
                                                        Case "Freight"
                                                            UseFieldName = "200 fpm (freight)"
                                                        Case Else
                                                            UseFieldName = String.Empty
                                                    End Select
                                                Case Is <= 355
                                                    UseFieldName = "355"
                                                Case Is <= 400
                                                    UseFieldName = "400"
                                                Case Is <= 453
                                                    UseFieldName = "453"
                                                Case Is <= 500
                                                    UseFieldName = "500"
                                                Case Is <= 620
                                                    UseFieldName = "620"
                                                Case Is <= 700
                                                    UseFieldName = "700"
                                                Case Else
                                                    UseFieldName = "1000"
                                            End Select
                                            If Not String.IsNullOrEmpty(UseFieldName) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(UseFieldName) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        Case Else
                                            AddToOptions = True
                                    End Select
                                    If AddToOptions Then
                                        Array.Resize(Options, iIndex + 1)
                                        Options(iIndex) = UseMaterialItemRecordSet.Fields("Types").Value.ToString
                                        iIndex += 1
                                    End If
                                End If
                                UseMaterialItemRecordSet.MoveNext()
                            Loop
                        Case "OrderBys"
                            If IsPOHController Then
                                UseFieldName = "Order by POH"
                            Else
                                UseFieldName = "Order by TX"
                            End If
                            If IsDBNull(UseMaterialItemRecordSet.Fields(UseFieldName).Value) Then
                                Options = {"EE", "ME", "RL"}
                            Else
                                Options = UseMaterialItemRecordSet.Fields(UseFieldName).Value.ToString.Split("/")
                            End If
                        Case Else
                    End Select
                End If
            End If
            UseMaterialItemRecordSet.Close()
            If IsNothing(Options) Then
                ReturnCmb.Clear()
            Else
                For iIndex = Options.GetLowerBound(0) To Options.GetUpperBound(0)
                    Options(iIndex) = Options(iIndex).Trim
                Next iIndex
                ReturnCmb.Items = Options
                ReturnCmb.MaxDrop = Options.Length
                ReturnCmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
                ReturnCmb.Editable = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In SetSPRCombo")

        End Try
        Return ReturnCmb

    End Function
    Public Function SetSPRText(ByVal TextType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As String
        Dim CurMATID As String = CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text
        Dim UseWhere As String = "[Sub ID] = '" & CurMATID & "'"
        Dim UseMaterialItemRecordSet As New ADODB.Recordset
        Dim ReturnIntVal As Integer = -999
        Dim ReturnVal As String = String.Empty
        Dim CurTravel As Single = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Travel_txt"))
        Dim CurPitDepth As Single = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "PitDepth_txt"))
        Dim TotalTravel As Single = CurTravel + Conversion.Val(GetValue(TABLENAME_GENERALINFO, "TopFloorToOverhead_txt")) + CurPitDepth

        Try
            If Math.Round(Conversion.Val(CurMATID)) > 900.0 Then
                CurMATID = "900" & Strings.Right(CurMATID, 3)
                UseWhere = "[Sub ID] = '" & CurMATID & "'"
            End If
            UseMaterialItemRecordSet = New ADODB.Recordset
            UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
            If UseMaterialItemRecordSet.RecordCount > 0 Then
                UseMaterialItemRecordSet.Filter = UseWhere
                If UseMaterialItemRecordSet.RecordCount > 0 Then
                    UseMaterialItemRecordSet.MoveFirst()
                    Select Case TextType
                        Case "UnitQty"
                            If IsDBNull(UseMaterialItemRecordSet.Fields("Cost Qty").Value) Then
                                ReturnIntVal = 1
                            ElseIf String.IsNullOrEmpty(UseMaterialItemRecordSet.Fields("Cost Qty").Value.ToString.Trim) Then
                                ReturnIntVal = 1
                            Else
                                ReturnIntVal = UseMaterialItemRecordSet.Fields("Cost Qty").Value
                            End If
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value) Then
                                Select Case UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value.ToString.ToUpper
                                    Case "TRAVEL+OVERHEAR+PIT DEPTH"
                                        ReturnIntVal *= TotalTravel
                                    Case "TRAVEL+2*PIT DEPTH+10FT"
                                        ReturnIntVal *= (CurTravel + (2 * CurPitDepth) + 10)
                                    Case Else
                                End Select
                            End If
                        Case "Description"
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields("Sub").Value) Then
                                ReturnVal = UseMaterialItemRecordSet.Fields("Sub").Value.ToString
                            End If
                        Case Else
                    End Select
                End If
            End If
            UseMaterialItemRecordSet.Close()
            Select Case TextType
                Case "UnitQty"
                    If ReturnIntVal = -999 Then
                        ReturnIntVal = 1
                    Else
                        ReturnIntVal = Math.Round(ReturnIntVal)
                    End If
                    ReturnVal = ReturnIntVal.ToString
                Case Else
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In SetSPRText")

        End Try
        Return ReturnVal

    End Function
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
    Public Function GetValue(ByVal UseTable As String, ByVal UseField As String, Optional ByVal UseMainID As String = "", Optional ByVal UseMaterialID As String = "") As String
        Dim ReturnVal As String = String.Empty
        Dim CurRow As Integer = 0, iIndex As Integer = 0
        Dim CurMaterialTable As DataTable = EstimatingDataset.Tables(UseTable)
        Dim CurDataRow As DataRow = Nothing

        For iIndex = 0 To CurMaterialTable.Rows.Count - 1
            CurDataRow = CurMaterialTable.Rows(iIndex)
            If String.IsNullOrEmpty(UseMainID) Or String.IsNullOrEmpty(UseMaterialID) Then
                If Not IsDBNull(CurDataRow(UseField)) Then
                    ReturnVal = CurDataRow(UseField)
                End If
                Exit For
            ElseIf CurDataRow(TABLECOL_MAINID) = UseMainID And CurDataRow(TABLECOL_MATERIALID) = UseMaterialID Then
                If Not IsDBNull(CurDataRow(UseField)) Then
                    ReturnVal = CurDataRow(UseField)
                End If
                Exit For
            End If
        Next iIndex
        Return ReturnVal

    End Function
    Public Sub SetIsPOHController()

        If GetValue(TABLENAME_MATERIALS, UseTypeCol, MAIN_ID_Controller, MAT_ID_Controller).ToString.IndexOf("TXR5") = -1 Then
            IsPOHController = True
        Else
            IsPOHController = False
        End If

    End Sub
    Public Sub UpdateAllTotals(ByVal CurUnits As String)
        Dim iIndex As Integer = 0, AltIndex As Integer = 1
        Dim CurDataRow As DataRow = Nothing
        Dim UseId As String = String.Empty, UseAltId As String = String.Empty
        Dim FoundDataRow As Boolean = False
        Dim Material_HQ As Single = 0, Material_RL As Single = 0, TempCost As Single = 0
        Dim BDP_Hours As Single = 0, Special_Hours As Single = 0, Labor_Hours As Single = 0, Labor_Cost As Single = 0
        Dim SubContract_Work As Single = 0, Misc_Costs As Single = 0, Expenses As Single = 0, Freight As Single = 0, NPS_Cost As Single = 0
        Dim Total_Bank_Cost As Single = 0, Bank_Net_Price As Single = 0
        Dim Sales_Commission As Single = 0, NPS_Surcharge As Single = 0, Taxes As Single = 0
        Dim UseMaterialItemRecordSet As New ADODB.Recordset
        Dim UseWhere As String = String.Empty, PerUnit As String = String.Empty
        Dim PerCarQty As Single = CalculateNumberOfCarsInEstimate(CurUnits)
        Dim MaterialQty As Single = 0, LaborQty As Single = 0
        Dim TotalTravel As Single = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Travel_txt")) +
                                    Conversion.Val(GetValue(TABLENAME_GENERALINFO, "TopFloorToOverhead_txt")) +
                                    Conversion.Val(GetValue(TABLENAME_GENERALINFO, "PitDepth_txt"))
        Dim FrontOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsFront_cmb"))
        Dim RearOpenings As Integer = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "NumberofStopsRear_cmb"))
        Dim TotalOpenings As Integer = FrontOpenings + RearOpenings
        Dim UseFieldName As String = String.Empty

        Try
            'CJ (10/23/17) - still need to program multiple tabs - will only update based on single tab
            For iIndex = 0 To SubGroups.Rows.Count - 1
                CurDataRow = SubGroups.Rows(iIndex)
                If Not IsDBNull(CurDataRow(UseOptionCol)) Then
                    Select Case CurDataRow(UseOptionCol)
                        Case "New", "Refurbish", "Included"
                            UseMaterialItemRecordSet = New ADODB.Recordset
                            UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseWhere = "[Sub ID] = '" & CurDataRow(TABLECOL_MATERIALID) & "'"
                                If Not IsDBNull(CurDataRow(UseTypeCol)) Then
                                    UseWhere &= " AND Types = '" & CurDataRow(UseTypeCol) & "'"
                                End If
                                UseMaterialItemRecordSet.Filter = UseWhere
                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                    UseMaterialItemRecordSet.MoveFirst()
                                    'Material Qty and Cost
                                    If IsDBNull(UseMaterialItemRecordSet.Fields("Unit").Value) Then
                                        PerUnit = "PER CAR"
                                    Else
                                        PerUnit = UseMaterialItemRecordSet.Fields("Unit").Value.ToString.Trim.ToUpper
                                    End If
                                    Select Case PerUnit
                                        Case "PER CAR", "PER ASSEMBLY (1 PER CAR)", "PER UNIT", "PER CAR PER FT (2 CABLES)"
                                            MaterialQty = PerCarQty
                                        Case "PER BANK", "PER JOB"
                                            MaterialQty = 1
                                        Case "PER BANK/FT"
                                            MaterialQty = TotalTravel
                                        Case "PER FOOT", "PER FT"
                                            MaterialQty = TotalTravel
                                        Case "PER CAR PER FT"
                                            MaterialQty = PerCarQty * TotalTravel
                                        Case "PER OPERATOR"
                                            If CurDataRow(TABLECOL_MATERIALDESC).ToString.ToUpper.IndexOf("FRONT") > -1 Then
                                                UseFieldName = MAT_ID_FrontCarDoorOperator
                                            Else
                                                UseFieldName = MAT_ID_RearCarDoorOperator
                                            End If
                                            MaterialQty = PerCarQty * Conversion.Val(GetValue(TABLENAME_MATERIALS, UseUnitQtyCol, MAIN_ID_DoorOperator, UseFieldName))
                                        Case "PER DOOR"
                                            MaterialQty = PerCarQty * Conversion.Val(GetValue(TABLENAME_MATERIALS, UseUnitQtyCol, MAIN_ID_CabEquipment, MAT_ID_CarDoor))
                                        Case "PER ROPE PER CAR"
                                            MaterialQty = PerCarQty * Conversion.Val(GetValue(TABLENAME_MATERIALS, UseUnitQtyCol, MAIN_ID_Hoistway, MAT_ID_HoistRopes))
                                        Case "PER OPENING PER CAR"
                                            MaterialQty = PerCarQty * TotalOpenings
                                        Case "PER PORT"
                                            Select Case CurDataRow(TABLECOL_MATERIALDESC).ToString.ToUpper
                                                Case "PEDESTAL & BASE", "BACK PLATES"
                                                    MaterialQty = GetPORTQty(MAT_ID_LobbyPORTDevices) + GetPORTQty(MAT_ID_FrontTypicalPORTDevices) +
                                                             GetPORTQty(MAT_ID_RearTypicalPORTDevices) + GetPORTQty(MAT_ID_SparePORTDevicesType1) +
                                                             GetPORTQty(MAT_ID_SparePORTDevicesType2) + GetPORTQty(MAT_ID_SparePORTDevicesType3)
                                                    MaterialQty *= PerCarQty
                                                Case Else
                                                    MaterialQty = PerCarQty * GetPORTQty(CurDataRow(TABLECOL_MATERIALID))
                                            End Select
                                        Case Else
                                            MaterialQty = 0
                                    End Select
                                    TempCost = CurDataRow(TABLECOL_UNITCOST) * MaterialQty
                                    Select Case CurDataRow(TABLECOL_MAINID)
                                        Case MAIN_ID_Miscellaneous
                                            Misc_Costs += TempCost
                                        Case MAIN_ID_SubcontractingWork
                                            SubContract_Work += TempCost
                                        Case Else
                                            If String.IsNullOrEmpty(CurDataRow(UseOrderByCol)) OrElse CurDataRow(UseOrderByCol).ToString = "RL" Then
                                                Material_RL += TempCost
                                            Else
                                                Material_HQ += TempCost
                                            End If
                                    End Select

                                    'Labor Qty, Hours, and Cost
                                    'If IsDBNull(UseMaterialItemRecordSet.Fields("Labor Qty").Value) Then           'CJ (10/23/17) - Labor Qty = 'x'?
                                    '    PerUnit = "PER CAR"
                                    'Else
                                    '    LaborQty = MaterialQty
                                    'End If
                                    Select Case True
                                        Case UseMaterialItemRecordSet.Fields("Labor Per Car").Value
                                            LaborQty = PerCarQty
                                        Case UseMaterialItemRecordSet.Fields("Labor Per Bank").Value
                                            LaborQty = 1
                                        Case UseMaterialItemRecordSet.Fields("Labor Per Job").Value
                                            LaborQty = 1
                                        Case Else
                                            LaborQty = 0
                                    End Select
                                    BDP_Hours += (CurDataRow(TABLECOL_STDHOURS) * LaborQty)
                                    Special_Hours += (CurDataRow(TABLECOL_SPECHOURS) * LaborQty)
                                End If
                            End If
                            UseMaterialItemRecordSet.Close()
                        Case "Reuse"
                        Case Else
                    End Select
                End If
            Next iIndex

            For iIndex = 0 To dtSummaryGroup.Rows.Count - 1
                CurDataRow = dtSummaryGroup.Rows(iIndex)
                If CurDataRow("Bank") = CurrentGOData_Typ.Bank Then
                    UseId = CurDataRow("id")
                    Exit For
                End If
            Next iIndex
            Select Case CurrentGOData_Typ.EstimateLevel
                Case "Master", "Base"
                    For iIndex = 0 To dtBaseGroup.Rows.Count - 1
                        CurDataRow = dtBaseGroup.Rows(iIndex)
                        If CurDataRow("id") = UseId Then
                            FoundDataRow = True
                            Exit For
                        End If
                    Next iIndex
                Case "Alt"
                    For iIndex = 0 To dtBaseGroup.Rows.Count - 1
                        CurDataRow = dtBaseGroup.Rows(iIndex)
                        If CurDataRow("id") = UseId Then
                            UseAltId = CurDataRow("alt_id")
                            Exit For
                        End If
                    Next iIndex
                    For iIndex = 0 To dtAltGroup.Rows.Count - 1
                        CurDataRow = dtAltGroup.Rows(iIndex)
                        If CurDataRow("alt_id") = UseAltId Then
                            If AltIndex = CurrentGOData_Typ.Alt Then
                                FoundDataRow = True
                                Exit For
                            End If
                            AltIndex += 1
                        End If
                    Next iIndex
                Case Else
            End Select
            If FoundDataRow Then
                CurDataRow("Material_HQ") = Math.Round(Material_HQ, 2)
                CurDataRow("Material_RL") = Math.Round(Material_RL, 2)
                CurDataRow("BDP_Hours") = Math.Round(BDP_Hours, 2)
                CurDataRow("Special_Hours") = Math.Round(Special_Hours, 2)
                Labor_Hours = BDP_Hours + Special_Hours
                Labor_Cost = Labor_Hours * CurDataRow("Labor_Rate")
                CurDataRow("Labor_Cost") = Math.Round(Labor_Cost, 2)
                If CurDataRow("OT_Hours_Included") > Labor_Hours Then
                    CurDataRow("OT_Hours_Included") = 0
                Else
                    Labor_Hours -= CurDataRow("OT_Hours_Included")
                End If
                CurDataRow("Labor_Hours") = Math.Round(Labor_Hours, 2)
                CurDataRow("SubContract_Work") = Math.Round(SubContract_Work, 2)
                CurDataRow("Misc_Costs") = Math.Round(Misc_Costs, 2)
                Expenses = Conversion.Val(GetValue(TABLENAME_GENERALINFO, "ExpensesPerDay_txt"))
                CurDataRow("Expenses") = Math.Round(Expenses, 2)
                Freight = (Material_HQ + Material_RL) * FREIGHT_RATE
                CurDataRow("Freight") = Math.Round(Freight, 2)
                NPS_Cost = Conversion.Val(dtBuildingInfo(0)("nps_one_time_cost").ToString)
                NPS_Cost += Conversion.Val(dtBuildingInfo(0)("nps_material_cost").ToString) * Conversion.Val(dtBuildingInfo(0)("nps_duration").ToString)
                NPS_Cost *= PerCarQty
                NPS_Cost += Conversion.Val(dtBuildingInfo(0)("nps_labor_cost").ToString) * Conversion.Val(dtBuildingInfo(0)("nps_duration").ToString) * PerCarQty
                Total_Bank_Cost = Material_HQ + Material_RL + Labor_Cost + SubContract_Work + Misc_Costs + Expenses + Freight + NPS_Cost +
                                  (Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Permits_txt")) * PerCarQty) +
                                  Conversion.Val(GetValue(TABLENAME_GENERALINFO, "Bonds_txt"))
                Bank_Net_Price = Total_Bank_Cost / (1 - CurDataRow("C1"))

                NPS_Surcharge = CalculateNPSSurcharge(Bank_Net_Price)
                Taxes = CalculateTaxes(Bank_Net_Price, (Material_HQ + Material_RL))
                Sales_Commission = CalculateSalesCommission()
                Total_Bank_Cost += NPS_Surcharge + Taxes + Sales_Commission
                Bank_Net_Price = Total_Bank_Cost / (1 - CurDataRow("C1"))
                NPS_Surcharge = CalculateNPSSurcharge(Bank_Net_Price)
                Taxes = CalculateTaxes(Bank_Net_Price, (Material_HQ + Material_RL))
                Sales_Commission = CalculateSalesCommission()
                Total_Bank_Cost += NPS_Surcharge + Taxes + Sales_Commission
                Bank_Net_Price = Total_Bank_Cost / (1 - CurDataRow("C1"))

                CurDataRow("NPS_Cost") = Math.Round(NPS_Cost + NPS_Surcharge, 2)
                CurDataRow("Tax") = Math.Round(Taxes, 2)
                CurDataRow("Sales_Commission") = Math.Round(Sales_Commission, 2)

                CurDataRow("Total_Bank_Cost") = Math.Round(Total_Bank_Cost, 2)
                CurDataRow("Bank_Net_Price") = Math.Round(Bank_Net_Price, 2)
                CurDataRow("speed") = Math.Round(Conversion.Val(GetValue(TABLENAME_GENERALINFO, "SpeedNew_cmb")))
                CurDataRow("machine_model") = GetValue(TABLENAME_GENERALINFO, "MachineType_cmb")
            End If
            CM_MAIN_frm.CalculateFinalBankPrice()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In UpdateAllTotals")

        End Try

    End Sub
    Private Function CalculateNPSSurcharge(ByVal CurrentPrice As Single) As Single
        Dim NPSSurcharge As Single = 0, NPSSurchargeRate As Single = 0

        If Conversion.Val(dtBuildingInfo(0)("nps_duration").ToString) > 12 Then
            If CurrentPrice <= 500000 Then
                NPSSurchargeRate = 1.8
            ElseIf CurrentPrice <= 2500000 Then
                NPSSurchargeRate = 3.3
            ElseIf CurrentPrice <= 5000000 Then
                NPSSurchargeRate = 4.55
            ElseIf CurrentPrice <= 7500000 Then
                NPSSurchargeRate = 5.65
            Else
                NPSSurchargeRate = 6.65
            End If
        End If
        NPSSurcharge = (CurrentPrice * NPSSurchargeRate) / 1000
        Return NPSSurcharge

    End Function
    Private Function CalculateTaxes(ByVal CurrentPrice As Single, ByVal CurrentMaterialCost As Single) As Single
        Dim TotalTax As Single = 0
        Dim TaxRate As Single = Conversion.Val(dtBuildingInfo(0)("tax_rate").ToString)

        Select Case ProjectData.TaxType
            Case "U", "S*" ' Use Tax
                If dtBuildingInfo(0)("tax_code").ToString = "Taxable" Then
                    TotalTax = CurrentMaterialCost * TaxRate
                End If
            Case "E" ' Excise Tax
                If dtBuildingInfo(0)("tax_code").ToString = "Taxable" Then
                    TotalTax = CurrentPrice * TaxRate
                End If
            Case "S" ' Sales Tax
                If dtBuildingInfo(0)("tax_code").ToString = "Taxable" Then
                    TotalTax = CurrentPrice * TaxRate
                End If
            Case Else
        End Select
        Return TotalTax

    End Function
    Private Function CalculateSalesCommission() As Single
        Return 0            'CJ (10/23/17) - will be zero until logic provided
    End Function
    Private Function GetPORTQty(ByVal MAT_ID As String) As Single
        Dim ReturnVal As Single = 0
        Dim PORTIndex As Integer = 0
        Dim PORTDataRow As DataRow = Nothing

        For PORTIndex = 0 To SubGroups.Rows.Count - 1
            PORTDataRow = SubGroups.Rows(PORTIndex)
            If PORTDataRow(TABLECOL_MATERIALID).ToString = MAT_ID Then
                ReturnVal = Conversion.Val(PORTDataRow(UseUnitQtyCol).ToString)
                Exit For
            End If
        Next PORTIndex
        Return ReturnVal

    End Function
    Public Sub SetAssociatedFieldNames()

        If CurrentGOData_Typ.EstimateLevel = "Alt" Then
            UseTypeCol = TABLECOL_TYPE_ALT
            UseOptionCol = TABLECOL_OPTION_ALT
            UseOrderByCol = TABLECOL_ORDERBY_ALT
            UseUnitQtyCol = TABLECOL_UNITQTY_ALT
        End If

    End Sub
End Module