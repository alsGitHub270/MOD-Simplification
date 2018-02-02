Option Strict Off
Option Explicit On
Imports System.Globalization
Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json

Module EstimatingMOD
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
    Public AltDataset As System.Data.DataSet
    Public dsOrdering As System.Data.DataSet
    Public MainGroups As DataTable = Nothing
    Public SubGroups As DataTable = Nothing
    Public GeneralInfo As DataTable = Nothing
    Public TorqueData As DataTable = Nothing
    Public OrderingInfo As DataTable = Nothing
    Public CurrentTab As String = String.Empty
    Public CurrentTabUnits As String = String.Empty

    Public EST_Filename As String = String.Empty
    Public ALT_Filename As String = String.Empty
    Public Const FileSuffix_MASTER As String = "MODMST"
    Public Const FileSuffix_BASE As String = "MODEST"
    Public Const FileSuffix_ALT As String = "MODALT"
    Public Const FileSuffix_ORDERING As String = "MODORD"

    Public Const TABLENAME_MAIN As String = "EstMainGroup"
    Public Const TABLENAME_MATERIALS As String = "EstMaterials"
    Public Const TABLENAME_GENERALINFO As String = "GeneralInfo"
    Public Const TABLENAME_TORQUEDATA As String = "TorqueData"
    Public Const TABLENAME_ORDERINFO As String = "OrderInfo"
    Public Const TABLENAME_LABORRATES As String = "LaborRates"
    Public Const TABLENAME_OVERTIME As String = "OverTime"

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
        Dim OptionStrBase As String
        Dim OptionStr() As String
        Dim TypeBase As String
        Dim Type() As String
        Dim OrderByBase As String
        Dim OrderBy() As String
        Dim QtyBase As Integer
        Dim Qty As Integer
        Dim Units As String
        Dim MaterialCost As Single
        Dim StandardHours As Single
        Dim SpecialHours As Single
        Public Shared Function CreateInstance() As a_MaterialGroup_typ
            Dim result As New a_MaterialGroup_typ
            result.MainID = String.Empty
            result.MaterialID = String.Empty
            result.Description = String.Empty
            result.OptionStrBase = String.Empty
            result.TypeBase = String.Empty
            result.OrderByBase = String.Empty
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
    Public Const MAT_ID_SchindlerAheadHardware As String = "051CON"
    Public Const MAT_ID_Drive As String = "055CON"
    Public Const MAT_ID_Transformer As String = "060CON"
    Public Const MAT_ID_ChokeforDCApplications As String = "065CON"
    Public Const MAT_ID_MTO As String = "070CON"
    Public Const MAT_ID_MachineRoomWiring As String = "075CON"
    Public Const MAT_ID_MachineRoomDuct As String = "080CON"
    Public Const MAT_ID_SeismicHolddowns As String = "085CON"
    Public Const MAT_ID_MachineRoomSeismicSwitch As String = "090CON"
    Public Const MAT_ID_PTG As String = "095CON"
    Public Const MAT_ID_InterfaceBoxes As String = "100CON"
    Public Const MAT_ID_ConfigurationStation As String = "105CON"
    Public Const MAT_ID_PORTSecurityType As String = "110CON"
    Public Const MAT_ID_ProgrammingStation As String = "111CON"
    Public Const MAT_ID_ACMotorRGD As String = "005RGD"
    Public Const MAT_ID_ACMotorCouplerandAdapterKit As String = "010RGD"
    Public Const MAT_ID_DriveSheave As String = "020RGD"
    Public Const MAT_ID_BrakePads As String = "025RGD"
    Public Const MAT_ID_BrakePins As String = "026RGD"
    Public Const MAT_ID_BrakeCoilsRGD As String = "027RGD"
    Public Const MAT_ID_BrakeSwitchRGD As String = "030RGD"
    Public Const MAT_ID_DrainFlushSeals As String = "035RGD"
    Public Const MAT_ID_MachineBearings As String = "040RGD"
    Public Const MAT_ID_GearedMachineBedplateBrakeSwitch As String = "005NGD"
    Public Const MAT_ID_ACMotorNGD As String = "010NGD"
    Public Const MAT_ID_MachineIsolation As String = "020NGD"
    Public Const MAT_ID_DeflectorSheaves As String = "025NGD"
    Public Const MAT_ID_SheaveGuardNGD As String = "030NGD"
    Public Const MAT_ID_BlockingAssemblyNGD As String = "035NGD"
    Public Const MAT_ID_MachineFrameandMechancialParts As String = "005FMM"
    Public Const MAT_ID_BlockingAssemblyFMM As String = "015FMM"
    Public Const MAT_ID_RelocateCableHolesLaborOnly As String = "016FMM"
    Public Const MAT_ID_STM As String = "020FMM"
    Public Const MAT_ID_KSSLMSKitandContacts As String = "030FMM"
    Public Const MAT_ID_CarSheaveAndAttachment As String = "045FMM"
    Public Const MAT_ID_Encoder As String = "005RGL"
    Public Const MAT_ID_Sheave As String = "010RGL"
    Public Const MAT_ID_SheaveGuardRGL As String = "015RGL"
    Public Const MAT_ID_BrakeSwitchRGL As String = "020RGL"
    Public Const MAT_ID_BrakeCoilsRGL As String = "027RGD"
    Public Const MAT_ID_BrakeLinings As String = "025RGL"
    Public Const MAT_ID_FieldCoils As String = "030RGL"
    Public Const MAT_ID_BearingsSeals As String = "035RGL"
    Public Const MAT_ID_TurnUndercutCommutator As String = "040RGL"
    Public Const MAT_ID_MachineFrameandSecondarySheave As String = "005NGL"
    Public Const MAT_ID_MachineBedplateIsolation As String = "010NGL"
    Public Const MAT_ID_AssemblyTool As String = "015NGL"
    Public Const MAT_ID_ManualHandwindingDevice As String = "020NGL"
    Public Const MAT_ID_HydraulicBrakeTestTool As String = "025NGL"
    Public Const MAT_ID_SheaveGuardNGL As String = "035NGL"
    Public Const MAT_ID_MachineDisassemblyandReassembly As String = "040NGL"
    Public Const MAT_ID_CarGovernor As String = "005GOV"
    Public Const MAT_ID_CarGovernorTensionSheave As String = "006GOV"
    Public Const MAT_ID_CarGovernorMounting As String = "010GOV"
    Public Const MAT_ID_CarGovernorEncoder As String = "015GOV"
    Public Const MAT_ID_CarGovernorRope As String = "016GOV"
    Public Const MAT_ID_CwtGovernor As String = "020GOV"
    Public Const MAT_ID_CwtGovernorTensionSheave As String = "021GOV"
    Public Const MAT_ID_CwtGovernorMounting As String = "025GOV"
    Public Const MAT_ID_CwtGovernorRope As String = "036GOV"
    Public Const MAT_ID_RopeGripper As String = "005ASC"
    Public Const MAT_ID_RopeGripperMountingKit As String = "010ASC"
    Public Const MAT_ID_RopeSplayClamp As String = "011ASC"
    Public Const MAT_ID_MachineBlockingwhenraisingmachineup As String = "015ASC"
    Public Const MAT_ID_LevelingUnit As String = "005CAR"
    Public Const MAT_ID_ETSETSL As String = "010CAR"
    Public Const MAT_ID_LoadWeighingDevice As String = "015CAR"
    Public Const MAT_ID_CarDuctWiring As String = "020CAR"
    Public Const MAT_ID_CarTopInspectionStation As String = "025CAR"
    Public Const MAT_ID_FixtureInterface As String = "026CAR"
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
    Public Const MAT_ID_CabInteriorPackageInstalledbySEC As String = "021CAB"
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
    Public Const MAT_ID_HoistwayDoorGibsandFireTabs As String = "035LND"
    Public Const MAT_ID_HoistwayFrameComplete As String = "045LND"
    Public Const MAT_ID_SillSupports As String = "050LND"
    Public Const MAT_ID_HoistwayDoor As String = "055LND"
    Public Const MAT_ID_SightGuard As String = "060LND"
    Public Const MAT_ID_Escutheons As String = "065LND"
    Public Const MAT_ID_HoistwaySill As String = "070LND"
    Public Const MAT_ID_HoistwayDoorAstragals As String = "075LND"
    Public Const MAT_ID_HoistwayHeaders As String = "080LND"
    Public Const MAT_ID_Struts As String = "085LND"
    Public Const MAT_ID_FreightDoorPackage As String = "090LND"
    Public Const MAT_ID_TravellingCableHoistwayWiring As String = "005HST"
    Public Const MAT_ID_TravelCableHangers As String = "010HST"
    Public Const MAT_ID_HoistwayDuct As String = "015HST"
    Public Const MAT_ID_HoistRopes As String = "020HST"
    Public Const MAT_ID_HoistCableShackles As String = "025HST"
    Public Const MAT_ID_CWTSheaveattachmentandGuard As String = "040HST"
    Public Const MAT_ID_CounterweightDerailmentDeviceRingandString As String = "045HST"
    Public Const MAT_ID_CarGuideRails As String = "050HST"
    Public Const MAT_ID_CwtGuideRails As String = "051HST"
    Public Const MAT_ID_CarRailBrackets As String = "055HST"
    Public Const MAT_ID_CwtRailBrackets As String = "056HST"
    Public Const MAT_ID_CounterweightFrame As String = "060HST"
    Public Const MAT_ID_CounterweightFillerWeights As String = "065HST"
    Public Const MAT_ID_CwtSafety As String = "070HST"
    Public Const MAT_ID_CWTRollerGuides As String = "075HST"
    Public Const MAT_ID_CWTRollerGuideAdapterPlate As String = "080HST"
    Public Const MAT_ID_CWTGuideShoeCovers As String = "085HST"
    Public Const MAT_ID_HoistwayScreening As String = "090HST"
    Public Const MAT_ID_HoistwayLimitSwitch As String = "095HST"
    Public Const MAT_ID_Fascia As String = "100HST"
    Public Const MAT_ID_POEBoxesandconnectioncables As String = "110HST"
    Public Const MAT_ID_POEBoxesforTurnstileApplication As String = "115HST"
    Public Const MAT_ID_DestinationWiringinft As String = "120HST"
    Public Const MAT_ID_AdditionalDuctforPHASEMODDIinft As String = "125HST"
    Public Const MAT_ID_AdditonalTravelingCableforPHASEMODDI As String = "130HST"
    Public Const MAT_ID_MainCarStation As String = "005FIX"
    Public Const MAT_ID_AuxCarStation As String = "010FIX"
    Public Const MAT_ID_CarTravelingLantern As String = "015FIX"
    Public Const MAT_ID_CarPositionIndicator As String = "020FIX"
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
    Public Const MAT_ID_TemporaryDestinationIndicators2PerOpening As String = "130FIX"
    Public Const MAT_ID_FrontDestinationIndicators2PerOpening As String = "135FIX"
    Public Const MAT_ID_RearDestinationIndicators2PerOpening As String = "136FIX"
    Public Const MAT_ID_TempCOPCoversMain As String = "140FIX"
    Public Const MAT_ID_TempCOPCoversAux As String = "145FIX"
    Public Const MAT_ID_LobbyPORTDevices As String = "150FIX"
    Public Const MAT_ID_FrontTypicalPORTDevices As String = "155FIX"
    Public Const MAT_ID_RearTypicalPORTDevices As String = "160FIX"
    Public Const MAT_ID_ChassisPORTWithC42TurnstileOnly As String = "161FIX"
    Public Const MAT_ID_SparePORTDevicesType1 As String = "165FIX"
    Public Const MAT_ID_SparePORTDevicesType2 As String = "170FIX"
    Public Const MAT_ID_SparePORTDevicesType3 As String = "175FIX"
    Public Const MAT_ID_PedestalBase As String = "180FIX"
    Public Const MAT_ID_MountingStyle42Flat As String = "185FIX"
    Public Const MAT_ID_MountingStyle44Flat As String = "186FIX"
    Public Const MAT_ID_Backplates As String = "187FIX"
    Public Const MAT_ID_Platestocoverexistingholes As String = "190FIX"
    Public Const MAT_ID_CarBuffer As String = "005PIT"
    Public Const MAT_ID_CarBufferBlockingSupportandStand As String = "015PIT"
    Public Const MAT_ID_CarBufferFootingChannels As String = "020PIT"
    Public Const MAT_ID_CwtBuffer As String = "025PIT"
    Public Const MAT_ID_CwtBufferBlockingSupportandStand As String = "035PIT"
    Public Const MAT_ID_CwtBufferFootingChannels As String = "040PIT"
    Public Const MAT_ID_BufferSwitchCar As String = "045PIT"
    Public Const MAT_ID_BufferSwitchCwt As String = "050PIT"
    Public Const MAT_ID_PitSwitch As String = "065PIT"
    Public Const MAT_ID_PitLadder As String = "070PIT"
    Public Const MAT_ID_PitLight As String = "075PIT"
    Public Const MAT_ID_PitFloodSwitch As String = "080PIT"
    Public Const MAT_ID_SumpPumpCoverforexisting As String = "085PIT"
    Public Const MAT_ID_WhisperFlexCompensationHitch As String = "090PIT"
    Public Const MAT_ID_WhisperFlex As String = "095PIT"
    Public Const MAT_ID_WhisperFlexSwayDevice As String = "100PIT"
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
    Public Const MAT_ID_RubbishRemoval As String = "041SUB"
    Public Const MAT_ID_IncrementalBlankLineSUB As String = "900SUB"

    Public UseTypeCol As String = TABLECOL_TYPE_EST, UseOptionCol As String = TABLECOL_OPTION_EST, UseOrderByCol As String = TABLECOL_ORDERBY_EST
    Public UseUnitQtyCol As String = TABLECOL_UNITQTY_EST
    Public UseMaterialItemRecordSet As New ADODB.Recordset
    Public TorqueRecordset As New ADODB.Recordset
    Public BankLaborRate As Single = 0

    Public Function GetCostHours(ByVal MaterialID As String, ByVal CurOption As String, ByVal CurType As String, ByVal CurOrderBy As String,
                                 ByVal CostOrHours As String, ByVal CurQty As Integer) As Single
        Dim UseWhere As String = "[Sub ID] = '" & MaterialID & "'"
        Dim MachineType As String = GEARLESS_TYPE
        Dim UseFrontWidth As Single = 0, UseFrontHeight As Single = 0, UseRearWidth As Single = 0, UseRearHeight As Single = 0
        Dim UseField As String = String.Empty
        Dim TotalTravel As Single = 0, FrontOpenings As Integer = 0, RearOpenings As Integer = 0, TotalOpenings As Integer = 0
        Dim AddValue As Boolean = False
        Dim CurDataset As DataSet = Nothing
        Dim MachineLocation As String = String.Empty, RopingNew As String = String.Empty
        Dim TotalRisers As Integer = 0
        Dim CurField As Single = 0

        Try
            If String.IsNullOrEmpty(CurOption) Then
                Return CurField
            End If
            If String.IsNullOrEmpty(CurOrderBy) Then
                Return CurField
            ElseIf CurOrderBy = "RL" Then
                Return CurField
            End If
            CurDataset = SetCurrentDataset()
            TotalTravel = Conversion.Val(GetValue_GeneralInfo(CurDataset, "TravelNew_txt")) +
                          Conversion.Val(GetValue_GeneralInfo(CurDataset, "TopFloorToOverhead_txt")) +
                          Conversion.Val(GetValue_GeneralInfo(CurDataset, "PitDepth_txt"))
            FrontOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsFront_cmb"))
            RearOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsRear_cmb"))
            TotalOpenings = FrontOpenings + RearOpenings
            MachineLocation = GetValue_GeneralInfo(CurDataset, "MachineLocation_Cmb")
            Select Case GetValue_GeneralInfo(CurDataset, "RopingNew_Cmb")
                Case "1:1 Single Wrap"
                    RopingNew = "1:1"
                Case "1:1 Dual Wrap"
                    RopingNew = "1:1"
                Case "2:1 Single Wrap"
                    RopingNew = "2:1"
                Case "2:1 Dual Wrap"
                    RopingNew = "2:1"
                Case "2:1 Underslung"
                    RopingNew = "2:1"
                Case Else
            End Select
            TotalRisers = Conversion.Val(GetValue_GeneralInfo(CurDataset, "RiserQtyFront_Cmb")) +
                          Conversion.Val(GetValue_GeneralInfo(CurDataset, "RiserQtyRear_Cmb"))
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
                                                Select Case UseMaterialItemRecordSet.Fields("Types").Value
                                                    Case MACHINE_FMM200
                                                        If GetValue_GeneralInfo(CurDataset, "MachineType_cmb") = MACHINE_FMM200 Then
                                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                                        End If
                                                    Case "Haughton or Otis"
                                                        If Not String.IsNullOrEmpty(GetValue_GeneralInfo(CurDataset, "ExistingControlVendor_lst")) Then
                                                            Select Case GetValue_GeneralInfo(CurDataset, "ExistingControlVendor_lst").ToUpper
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
                                Case "Reuse", "Included"
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
                     MAT_ID_DriveSheave, MAT_ID_BrakePads, MAT_ID_DrainFlushSeals, MAT_ID_MachineBearings,
                     MAT_ID_SheaveGuardNGD, MAT_ID_Sheave, MAT_ID_SheaveGuardRGL, MAT_ID_BrakeLinings, MAT_ID_FieldCoils,
                     MAT_ID_BearingsSeals, MAT_ID_TurnUndercutCommutator, MAT_ID_SheaveGuardNGL,
                     MAT_ID_MachineBlockingwhenraisingmachineup, MAT_ID_CarDuctWiring, MAT_ID_ToeGuard, MAT_ID_CarPlatform, MAT_ID_CabIsolationPads,
                     MAT_ID_CarSling, MAT_ID_CarSheaveAttachmentandGuard, MAT_ID_DoorLockMonitor, MAT_ID_NewCabComplete, MAT_ID_CabShell,
                     MAT_ID_CeilingLighting, MAT_ID_EmergencyLightCanopyType, MAT_ID_CabReturns, MAT_ID_WallPanels, MAT_ID_CarDoor, MAT_ID_Handrails,
                     MAT_ID_CarSill, MAT_ID_Fan, MAT_ID_CabFlooring, MAT_ID_Subflooring, MAT_ID_CabPads, MAT_ID_FreightEnclosure, MAT_ID_Gate,
                     MAT_ID_HoistwayDoorPackagetotalopenings, MAT_ID_HoistwayDoorTracks, MAT_ID_NylonTrackInserts, MAT_ID_HoistwayDoorHanger,
                     MAT_ID_HoistwayDoorInterlocksPickups, MAT_ID_HoistwayDoorClosers, MAT_ID_HoistwayDoorGibsandFireTabs,
                     MAT_ID_HoistwayFrameComplete, MAT_ID_SillSupports, MAT_ID_HoistwayDoor, MAT_ID_SightGuard, MAT_ID_Escutheons,
                     MAT_ID_HoistwaySill, MAT_ID_HoistwayDoorAstragals, MAT_ID_HoistwayHeaders, MAT_ID_Struts, MAT_ID_FreightDoorPackage,
                     MAT_ID_TravelCableHangers, MAT_ID_CWTSheaveattachmentandGuard, MAT_ID_CounterweightDerailmentDeviceRingandString,
                     MAT_ID_CarGuideRails, MAT_ID_CarRailBrackets, MAT_ID_CounterweightFrame, MAT_ID_CounterweightFillerWeights,
                     MAT_ID_POEBoxesandconnectioncables, MAT_ID_POEBoxesforTurnstileApplication, MAT_ID_DestinationWiringinft,
                     MAT_ID_AdditionalDuctforPHASEMODDIinft, MAT_ID_AdditonalTravelingCableforPHASEMODDI,
                     MAT_ID_FireEmergencyRecallSwitchifseparate, MAT_ID_PhoneLineMonitoringifseparate,
                     MAT_ID_EmergencyPowerPanelifseparate, MAT_ID_FireCommandCenterPanel, MAT_ID_LobbyStatusPanel, MAT_ID_IntercomSystem,
                     MAT_ID_TemporaryDestinationIndicators2PerOpening, MAT_ID_TempCOPCoversMain, MAT_ID_TempCOPCoversAux, MAT_ID_Platestocoverexistingholes,
                     MAT_ID_BufferSwitchCar, MAT_ID_BufferSwitchCwt, MAT_ID_PitLight, MAT_ID_HallPositionIndicator,
                     MAT_ID_PitFloodSwitch, MAT_ID_SumpPumpCoverforexisting, MAT_ID_WhisperFlexSwayDevice, MAT_ID_CompensationSheave,
                     MAT_ID_CompensationSwitch, MAT_ID_CounterweightGuard, MAT_ID_CleaningandPainting, MAT_ID_SystemAdjusting, MAT_ID_SAISInspection,
                     MAT_ID_ConsultantGSAInspection, MAT_ID_FireServiceEPTesting, MAT_ID_StandbyTime, MAT_ID_MachineRoomSpecialAccess,
                     MAT_ID_TestingandComissioningforPORT, MAT_ID_Miscelleneous, MAT_ID_FrontRecladding, MAT_ID_NitroCleaning,
                     MAT_ID_FireAlarmSystem, MAT_ID_ElectricalWork, MAT_ID_CabWork, MAT_ID_BuildingGCWork, MAT_ID_Crane,
                     MAT_ID_ThirdPartySecurityCompanyFee, MAT_ID_SchindlerAheadHardware, MAT_ID_CabInteriorPackageInstalledbySEC, MAT_ID_CwtGuideRails,
                     MAT_ID_CwtRailBrackets, MAT_ID_RubbishRemoval, MAT_ID_TravellingCableHoistwayWiring, MAT_ID_ProgrammingStation, MAT_ID_BrakeCoilsRGD,
                     MAT_ID_BrakeCoilsRGL
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
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
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                            If Conversion.Val(GetValue_GeneralInfo(CurDataset, "SpeedNew_cmb")) < 200 Then
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
                Case MAT_ID_Drive, MAT_ID_Transformer, MAT_ID_ChokeforDCApplications, MAT_ID_ConfigurationStation, MAT_ID_PORTSecurityType,
                     MAT_ID_ACMotorCouplerandAdapterKit, MAT_ID_BrakeSwitchRGD, MAT_ID_GearedMachineBedplateBrakeSwitch,
                     MAT_ID_ACMotorNGD, MAT_ID_MachineIsolation, MAT_ID_DeflectorSheaves, MAT_ID_BlockingAssemblyNGD,
                     MAT_ID_MachineFrameandMechancialParts, MAT_ID_KSSLMSKitandContacts,
                     MAT_ID_CarSheaveAndAttachment, MAT_ID_Encoder, MAT_ID_BrakeSwitchRGL,
                     MAT_ID_MachineFrameandSecondarySheave, MAT_ID_MachineBedplateIsolation, MAT_ID_AssemblyTool, MAT_ID_ManualHandwindingDevice,
                     MAT_ID_HydraulicBrakeTestTool, MAT_ID_MachineDisassemblyandReassembly, MAT_ID_CarGovernor, MAT_ID_CarGovernorMounting,
                     MAT_ID_CarGovernorEncoder, MAT_ID_CwtGovernor, MAT_ID_CwtGovernorMounting, MAT_ID_RopeGripper, MAT_ID_RopeGripperMountingKit,
                     MAT_ID_ETSETSL, MAT_ID_LoadWeighingDevice, MAT_ID_ETSETSL, MAT_ID_LoadWeighingDevice,
                     MAT_ID_CarTopHandRail, MAT_ID_RollerGuidesCar, MAT_ID_CarRollerGuideAdapterPlate, MAT_ID_GuideShoeCovers,
                     MAT_ID_FrontCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_FrontCarDoorOperator, MAT_ID_FrontClutch,
                     MAT_ID_FrontCarDoorGateSwitch, MAT_ID_FrontCarDoorTrackHanger, MAT_ID_RearCarDoorOperatorPackageOperatorGateSwitchHangerClutch,
                     MAT_ID_RearCarDoorOperator, MAT_ID_RearClutch, MAT_ID_RearCarDoorGateSwitch, MAT_ID_RearCarDoorTrackHanger,
                     MAT_ID_DoorRestrictor, MAT_ID_EmergencyExitSwitch,
                     MAT_ID_CWTRollerGuides, MAT_ID_CWTRollerGuideAdapterPlate, MAT_ID_CWTGuideShoeCovers, MAT_ID_RopeSplayClamp,
                     MAT_ID_MainCarStation, MAT_ID_AuxCarStation, MAT_ID_LobbyVisionMachineRoom,
                     MAT_ID_LobbyVisionOther, MAT_ID_DesignationSignageStatic, MAT_ID_DesignationSignageActive, MAT_ID_BrailleAddDestinatononly,
                     MAT_ID_FrontDestinationIndicators2PerOpening, MAT_ID_LobbyPORTDevices, MAT_ID_FrontTypicalPORTDevices, MAT_ID_RearTypicalPORTDevices,
                     MAT_ID_SparePORTDevicesType1, MAT_ID_SparePORTDevicesType2, MAT_ID_SparePORTDevicesType3, MAT_ID_PedestalBase,
                     MAT_ID_MountingStyle42Flat, MAT_ID_Backplates, MAT_ID_CarBuffer, MAT_ID_CarBufferBlockingSupportandStand,
                     MAT_ID_CarBufferFootingChannels, MAT_ID_CwtBuffer,
                     MAT_ID_CwtBufferBlockingSupportandStand, MAT_ID_CwtBufferFootingChannels, MAT_ID_CarGovernorTensionSheave,
                     MAT_ID_CwtGovernorTensionSheave, MAT_ID_PitSwitch, MAT_ID_PitLadder, MAT_ID_VoiceAnnunciator,
                     MAT_ID_WhisperFlexCompensationHitch, MAT_ID_CompensationRope, MAT_ID_HandsFreePhone,
                     MAT_ID_HallPILanternCombo, MAT_ID_BlockingAssemblyFMM, MAT_ID_RelocateCableHolesLaborOnly, MAT_ID_FixtureInterface,
                     MAT_ID_RearDestinationIndicators2PerOpening, MAT_ID_ChassisPORTWithC42TurnstileOnly
                    UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
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
                                Case "Reuse", "Included"
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
                                Case "Reuse", "Included"
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
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                            End If
                        End If
                    End If
                Case MAT_ID_HoistCableShackles
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
                                Case "Reuse", "Included"
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
                                    Case "Reuse", "Included"
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
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                            End If
                        End If
                    End If
                Case MAT_ID_STM
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                            UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                Do Until UseMaterialItemRecordSet.EOF
                                    If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("End Connector") > -1 Then
                                        If CurType.IndexOf("5 STM") > -1 And
                                           UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("5 STM") > -1 Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        ElseIf (CurType.IndexOf("3 STM") > -1 OrElse CurType.IndexOf("4 STM") > -1) And
                                               (UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("3 STM") > -1) Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        End If
                                    ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Twist Device") > -1 Then
                                        If CurType.IndexOf("5 STM") > -1 And
                                           UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("5 STM") > -1 Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        ElseIf (CurType.IndexOf("4 STM") > -1) And
                                               (UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("4 STM") > -1) Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        ElseIf (CurType.IndexOf("3 STM") > -1) And
                                               (UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("3 STM") > -1) Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                        End If
                                    Else
                                        CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                    End If
                                    UseMaterialItemRecordSet.MoveNext()
                                Loop
                            End If
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                            End If
                        End If
                    End If
                Case MAT_ID_Fascia
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
                                CurField *= Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsTotal_cmb"))
                            End If
                        End If
                    End If
                Case MAT_ID_ACMotorRGD
                    UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                            If GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb") = OTIS Then
                                UseMaterialItemRecordSet.Filter = UseWhere & " AND Usage = 'Adder'"
                                If UseMaterialItemRecordSet.RecordCount > 0 Then
                                    UseMaterialItemRecordSet.MoveFirst()
                                    Do Until UseMaterialItemRecordSet.EOF
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_Cmb")) > -1 Then
                                            CurField += UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                            Exit Do
                                        End If
                                        UseMaterialItemRecordSet.MoveNext()
                                    Loop
                                End If
                            End If

                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                            End If
                        End If
                    End If
                Case MAT_ID_HoistRopes
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
                        ElseIf CostOrHours = "Hours" And CurOption = "New" And Not String.IsNullOrEmpty(CurType) Then
                            CurField = 0
                            Select Case TotalTravel
                                Case Is <= 150
                                    Select Case MachineLocation
                                        Case "Overhead"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 16
                                                Case "2:1"
                                                    CurField = 24
                                                Case Else
                                            End Select
                                        Case "Basement", "Semi-Basement"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 32
                                                Case "2:1"
                                                    CurField = 36
                                                Case Else
                                            End Select
                                        Case Else
                                    End Select
                                Case Is <= 300
                                    Select Case MachineLocation
                                        Case "Overhead"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 24
                                                Case "2:1"
                                                    CurField = 36
                                                Case Else
                                            End Select
                                        Case "Basement", "Semi-Basement"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 48
                                                Case "2:1"
                                                    CurField = 54
                                                Case Else
                                            End Select
                                        Case Else
                                    End Select
                                Case Is <= 450
                                    Select Case MachineLocation
                                        Case "Overhead"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 32
                                                Case "2:1"
                                                    CurField = 48
                                                Case Else
                                            End Select
                                        Case "Basement", "Semi-Basement"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 64
                                                Case "2:1"
                                                    CurField = 72
                                                Case Else
                                            End Select
                                        Case Else
                                    End Select
                                Case Else
                                    Select Case MachineLocation
                                        Case "Overhead"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 40
                                                Case "2:1"
                                                    CurField = 60
                                                Case Else
                                            End Select
                                        Case "Basement", "Semi-Basement"
                                            Select Case RopingNew
                                                Case "1:1"
                                                    CurField = 80
                                                Case "2:1"
                                                    CurField = 90
                                                Case Else
                                            End Select
                                        Case Else
                                    End Select
                            End Select
                        End If
                    End If
                Case MAT_ID_HoistwayScreening
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                    CurField *= (TotalTravel + 10)
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = 16 * Math.Round((TotalTravel / 100), 2)
                            End If
                        End If
                    End If
                Case MAT_ID_CarTravelingLantern
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = 2 * UseMaterialItemRecordSet.Fields(UseField).Value
                            End If
                        End If
                    End If
                Case MAT_ID_CarPositionIndicator
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                If RearOpenings > 0 Then
                                    CurField *= 2
                                End If
                            End If
                        End If
                    End If
                Case MAT_ID_MainFloorHallStationsEgress
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value * TotalRisers
                            End If
                        End If
                    End If
                Case MAT_ID_TypicalFloorHallStations
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value * TotalRisers * (TotalOpenings - 1)
                            End If
                        End If
                    End If
                Case MAT_ID_HallLantern, MAT_ID_JambBraille
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value * TotalOpenings
                            End If
                        End If
                    End If
                Case MAT_ID_HoistwayAccessSwitch
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value
                                If CurType = "Top & Bottom" Then
                                    CurField *= 2
                                End If
                            End If
                        End If
                    End If
                Case MAT_ID_InconspicuousRisers
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" And Not String.IsNullOrEmpty(UseField) Then
                            If Not IsDBNull(UseMaterialItemRecordSet.Fields(UseField).Value) Then
                                CurField = UseMaterialItemRecordSet.Fields(UseField).Value * TotalRisers * TotalOpenings
                            End If
                        End If
                    End If
                Case MAT_ID_CarGovernorRope, MAT_ID_CwtGovernorRope, MAT_ID_TravellingCableHoistwayWiring
                    UseMaterialItemRecordSet.Filter = UseWhere & " AND Types = '" & CurType & "'"
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" Then
                            If TotalTravel <= 150 Then
                                CurField = 4
                            Else
                                CurField = 4 + Math.Round(((TotalTravel - 150) / 50) * 0.3, 2)
                            End If
                        End If
                    End If
                Case MAT_ID_HoistwayDuct
                    UseMaterialItemRecordSet.Filter = UseWhere
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        UseMaterialItemRecordSet.MoveFirst()
                        If CostOrHours = "Cost" Then
                            Select Case CurOption
                                Case "New"
                                    CurField = UseMaterialItemRecordSet.Fields("Transfer Price").Value
                                Case "Reuse", "Included"
                                    CurField = 0
                                Case Else
                            End Select
                        ElseIf CostOrHours = "Hours" Then
                            If CurOption = "New" Then
                                If TotalTravel <= 150 Then
                                    CurField = 16
                                Else
                                    CurField = 16 + Math.Round(((TotalTravel - 150) / 50), 2)
                                End If
                            Else
                                CurField = 8
                            End If
                        End If
                    End If
                Case Else
            End Select
            CurField = Math.Round(CurField, 2)
            Return CurField

        Catch ex As Exception
            UseMaterialItemRecordSet.Filter = "[Sub ID] = '" & MaterialID & "'"
            UseMaterialItemRecordSet.MoveFirst()
            MessageBox.Show("Error retrieving " & CostOrHours & " for " & UseMaterialItemRecordSet.Fields("Sub").Value.ToString, "Error Retrieving " & CostOrHours & " Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0

        End Try

    End Function
    Public Function SetSPRCombo(ByVal ArrayType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ReturnCmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim CurMATID As String = CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text
        Dim UseWhere As String = "[Sub ID] = '" & CurMATID & "'"
        Dim Options As String() = Nothing, TempAry As String() = Nothing
        Dim iIndex As Integer = 0, TempIndex As Integer = 0
        Dim CurValue As String = String.Empty
        Dim AddToOptions As Boolean = True
        Dim NumberOfFrontOpenings As Integer = 0, NumberOfRearOpenings As Integer = 0, OEMVendor As String = String.Empty, OEMModel As String = String.Empty
        Dim CurDataset As DataSet = Nothing
        Dim Speed As Integer = 0
        Dim RopingNew As String = String.Empty
        Dim FrontDoorOpeningWidth As Integer = 0, RearDoorOpeningWidth As Integer = 0
        Dim FrontDoorOpeningHeight As Integer = 0, RearDoorOpeningHeight As Integer = 0
        Dim CurMachineType As String = String.Empty, MachineType As String = String.Empty
        Dim CurControllerOption As String = String.Empty
        Dim Destination As String = String.Empty
        Dim CarGovernor As String = String.Empty, CarGovernorType As String = String.Empty
        Dim CwtGovernor As String = String.Empty, CwtGovernorType As String = String.Empty

        Try
            CurDataset = SetCurrentDataset()
            NumberOfFrontOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsFront_cmb"))
            NumberOfRearOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsRear_cmb"))
            OEMVendor = GetValue_GeneralInfo(CurDataset, "ExistingControlVendor_lst")
            OEMModel = GetValue_GeneralInfo(CurDataset, "ExistingControlModel_lst")
            Speed = Conversion.Val(GetValue_GeneralInfo(CurDataset, "SpeedNew_cmb"))
            RopingNew = GetValue_GeneralInfo(CurDataset, "RopingNew_Cmb")
            FrontDoorOpeningWidth = Math.Round((Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningWidthFtFront_txt")) / 12) +
                                               Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningWidthInFront_txt")))
            RearDoorOpeningWidth = Math.Round((Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningWidthFtRear_txt")) / 12) +
                                               Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningWidthInRear_txt")))
            FrontDoorOpeningHeight = Math.Round((Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningHeightFtFront_txt")) / 12) +
                                               Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningHeightInFront_txt")))
            RearDoorOpeningHeight = Math.Round((Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningHeightFtRear_txt")) / 12) +
                                               Conversion.Val(GetValue_GeneralInfo(CurDataset, "CarDoorOpeningHeightInRear_txt")))
            CurMachineType = GetValue(CurDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")
            CurControllerOption = GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_Controller, MAT_ID_Controller)
            Select Case CurMachineType
                Case "Reuse " & GEARED_TYPE
                    MachineType = GEARED_TYPE
                Case "New " & GEARED_TYPE
                    MachineType = GEARED_TYPE
                Case "Reuse " & GEARLESS_TYPE
                    MachineType = GEARLESS_TYPE
                Case "New " & GEARLESS_TYPE
                    MachineType = GEARLESS_TYPE
                Case MACHINE_FMM200
                    MachineType = GEARLESS_TYPE
                Case Else
            End Select
            Destination = GetValue_GeneralInfo(CurDataset, "Destination_cmb")
            CarGovernor = GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_Governor, MAT_ID_CarGovernor)
            CarGovernorType = GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_Governor, MAT_ID_CarGovernor)
            CwtGovernor = GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_Governor, MAT_ID_CwtGovernor)
            CwtGovernorType = GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_Governor, MAT_ID_CwtGovernor)
            If Math.Round(Conversion.Val(CurMATID)) > 900 Then
                CurMATID = "900" & Strings.Right(CurMATID, 3)
                UseWhere = "[Sub ID] = '" & CurMATID & "'"
            End If
            UseMaterialItemRecordSet.Filter = UseWhere
            If UseMaterialItemRecordSet.RecordCount > 0 Then
                UseMaterialItemRecordSet.MoveFirst()
                Erase Options
                CurValue = String.Empty
                Select Case ArrayType
                    Case "Options"
                        If IsDBNull(UseMaterialItemRecordSet.Fields("Options").Value) Then
                            Options = {"New", "Reuse", "Refurbish"}
                        Else
                            AddToOptions = True
                            Select Case CurMATID
                                Case MAT_ID_CarGovernorTensionSheave, MAT_ID_CwtGovernorTensionSheave
                                    If String.IsNullOrEmpty(CarGovernorType) Then
                                        AddToOptions = False
                                    Else
                                        If CarGovernorType.IndexOf("GB") > -1 Then
                                            AddToOptions = False
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") > -1 Then
                                                Options = {"Included"}
                                            End If
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CarGovernorType) = -1 Then
                                            AddToOptions = False
                                        End If
                                    End If
                                Case MAT_ID_ACMotorCouplerandAdapterKit, MAT_ID_BrakeSwitchRGD
                                    CurValue = GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_ReuseGearedMachineACMotorOnly, MAT_ID_ACMotorRGD)
                                    If String.IsNullOrEmpty(CurValue) Then
                                        AddToOptions = False
                                    ElseIf CurValue = "Reuse" Then
                                        AddToOptions = False
                                        Options = {"Included"}
                                    End If
                                Case MAT_ID_MachineBedplateIsolation
                                    If IsPOHController Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_ManualHandwindingDevice
                                    If IsPOHController Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_CarGovernorMounting
                                    If CarGovernor <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_CwtGovernorMounting
                                    If CwtGovernor <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_RopeGripperMountingKit
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_AscendingCarUnintendingMotion, MAT_ID_RopeGripper) <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_LevelingUnit
                                    If CurControllerOption = "Reuse" And Destination = "DI" Then
                                        AddToOptions = False
                                        Options = {"Reuse"}
                                    End If
                                Case MAT_ID_ETSETSL
                                    If IsPOHController Then
                                        AddToOptions = False
                                    Else
                                        If CurControllerOption = "Reuse" And Destination = "DI" Then
                                            AddToOptions = False
                                            Options = {"Reuse"}
                                        End If
                                    End If
                                Case MAT_ID_LoadWeighingDevice
                                    If GetValue_GeneralInfo(CurDataset, "MachineType_cmb") = MACHINE_FMM200 Then
                                        AddToOptions = False
                                    Else
                                        If Not IsPOHController Then
                                            If CurControllerOption = "Reuse" And Destination = "DI" Then
                                                AddToOptions = False
                                                Options = {"Reuse"}
                                            End If
                                        End If
                                    End If
                                Case MAT_ID_CarBufferBlockingSupportandStand, MAT_ID_CarBufferFootingChannels
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_CarBuffer) <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_CwtBufferBlockingSupportandStand, MAT_ID_CwtBufferFootingChannels
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_CwtBuffer) <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_WhisperFlexCompensationHitch
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_WhisperFlex) <> "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_SchindlerAheadHardware, MAT_ID_MachineFrameandMechancialParts, MAT_ID_AssemblyTool,
                                     MAT_ID_HydraulicBrakeTestTool, MAT_ID_MachineDisassemblyandReassembly, MAT_ID_LobbyVisionMachineRoom,
                                     MAT_ID_LobbyVisionOther
                                    If IsPOHController Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_CabShell, MAT_ID_CeilingLighting, MAT_ID_CabInteriorPackageInstalledbySEC, MAT_ID_CabReturns, MAT_ID_WallPanels,
                                     MAT_ID_CarDoor, MAT_ID_Handrails, MAT_ID_CarSill
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_CabEquipment, MAT_ID_NewCabComplete) = "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_HoistwayDoorTracks, MAT_ID_NylonTrackInserts, MAT_ID_HoistwayDoorHanger, MAT_ID_HoistwayDoorInterlocksPickups,
                                     MAT_ID_HoistwayDoorClosers
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_LANDINGDOOR, MAT_ID_HoistwayDoorPackagetotalopenings) = "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_SillSupports, MAT_ID_HoistwayDoor, MAT_ID_SightGuard, MAT_ID_Escutheons, MAT_ID_HoistwaySill,
                                     MAT_ID_HoistwayDoorAstragals, MAT_ID_HoistwayHeaders, MAT_ID_Struts
                                    If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_LANDINGDOOR, MAT_ID_HoistwayFrameComplete) = "New" Then
                                        AddToOptions = False
                                    End If
                                Case MAT_ID_MachineRoomWiring
                                    If CurControllerOption = "New" Then
                                        AddToOptions = False
                                        Options = {"New"}
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
                                        Select Case GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_Controller, MAT_ID_Drive)
                                            Case "VF33BR", "VF44BR"
                                                AddToOptions = True
                                            Case Else
                                        End Select
                                    Case MAT_ID_Drive
                                        If IsPOHController Then
                                            CurValue = "POH"
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DriveType_cmb")
                                                Case AC_TYPE
                                                    CurValue = "BR"
                                                Case AC_REGEN_TYPE
                                                    CurValue = "PF1"
                                                Case QUATTRO_TYPE
                                                    CurValue = "Quattro"
                                                Case DC_TYPE
                                                    CurValue = "DSD"
                                                Case Else
                                            End Select
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_Transformer
                                        If IsPOHController Then
                                            CurValue = "POH"
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DriveType_cmb")
                                                Case AC_TYPE, AC_REGEN_TYPE
                                                    CurValue = "VF"
                                                Case QUATTRO_TYPE
                                                    CurValue = "Quattro"
                                                Case DC_TYPE
                                                    CurValue = "DSD"
                                                Case Else
                                            End Select
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_ChokeforDCApplications
                                        If IsPOHController Then
                                            CurValue = "POH"
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DriveType_cmb")
                                                Case QUATTRO_TYPE
                                                    CurValue = "Quattro"
                                                Case DC_TYPE
                                                    CurValue = "DSD"
                                                Case Else
                                            End Select
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_GearedMachineBedplateBrakeSwitch
                                        CurValue = GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorNew_Cmb")
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                            CurValue = GetValue_GeneralInfo(CurDataset, "MachineLocation_Cmb")
                                            Select Case CurValue
                                                Case "Overhead", "Basement"
                                                    If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                        If Math.Round(Conversion.Val(dtBuildingInfo(0)("seismic_zone"))) > 1 Then
                                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Seismic") > -1 Then
                                                                AddToOptions = True
                                                            End If
                                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Seismic") = -1 Then
                                                            AddToOptions = True
                                                        End If
                                                    End If
                                                Case Else
                                                    If Math.Round(Conversion.Val(dtBuildingInfo(0)("seismic_zone"))) > 1 Then
                                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Seismic") > -1 Then
                                                            AddToOptions = True
                                                        End If
                                                    ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Seismic") = -1 Then
                                                        AddToOptions = True
                                                    End If
                                            End Select
                                        End If
                                    Case MAT_ID_CarGovernor, MAT_ID_CwtGovernor
                                        If IsPOHController And UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") > -1 Then
                                            AddToOptions = False
                                        ElseIf Speed <= 500 Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("HW 207") > -1 Or
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("HW 202") > -1 Then
                                                AddToOptions = True
                                            End If
                                        ElseIf Speed > 500 And Speed <= 800 Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("HW 210") > -1 Then
                                                AddToOptions = True
                                            End If
                                        ElseIf Speed <= 1575 Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB 32") > -1 Then
                                                AddToOptions = True
                                            End If
                                        ElseIf Speed <= 1968 Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB 42") > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_CarGovernorEncoder
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Rim Mounted") > -1 Then
                                            If CarGovernor.IndexOf("Reuse") > -1 Then
                                                AddToOptions = True
                                            End If
                                        ElseIf Not IsPOHController Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CarGovernorType) > -1 Then
                                                AddToOptions = True
                                            End If
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_ETSETSL
                                        If IsPOHController Then
                                            CurValue = "POH"
                                        Else
                                            If Speed >= 200 And Speed <= 800 Then
                                                CurValue = "800"
                                            ElseIf Speed > 800 And Speed <= 1200 Then
                                                CurValue = "1200"
                                            ElseIf Speed > 1200 And Speed <= 1400 Then
                                                CurValue = "1400"
                                            ElseIf Speed > 1400 And Speed <= 1600 Then
                                                CurValue = "1600"
                                            Else
                                                CurValue = "1800"
                                            End If
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_CarTopInspectionStation
                                        If IsPOHController Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                                AddToOptions = True
                                            End If
                                        Else
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_LoadWeighingDevice
                                        If IsPOHController Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                                AddToOptions = True
                                            End If
                                        ElseIf GetValue_GeneralInfo(CurDataset, "MachineType_cmb") <> MACHINE_FMM200 Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_CarTopHandRail
                                        If NumberOfFrontOpenings > 0 And NumberOfRearOpenings > 0 Then
                                            CurValue = "Front & Rear Opening"
                                        ElseIf NumberOfFrontOpenings > 0 Then
                                            CurValue = "Front Opening"
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_FrontCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_FrontCarDoorTrackHanger
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeFront_cmb")
                                                Case DOORTYPE_1SCO
                                                    CurValue = "1SCO"
                                                Case DOORTYPE_1SSS
                                                    CurValue = "1SSO"
                                                Case DOORTYPE_2SSS
                                                    CurValue = "2SSO"
                                                Case DOORTYPE_2SCO
                                                    CurValue = "2SCO"
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                Select Case CurValue
                                                    Case "1SCO"
                                                        If FrontDoorOpeningWidth <= 50 Then
                                                            CurValue &= " (30 in. - 50 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth > 50 And FrontDoorOpeningWidth < 60 Then
                                                            CurValue &= " (51 in. - 59 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 60 And FrontDoorOpeningWidth < 69 Then
                                                            CurValue &= " (60 in. - 68 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 69 Then
                                                            CurValue &= " (69 in. - 83 in. Opening)"
                                                        End If
                                                    Case "1SSO"
                                                        If FrontDoorOpeningWidth < 43 Then
                                                            CurValue &= " (22 in. - 42 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 43 Then
                                                            CurValue &= " (43 in. - 48 in. Opening)"
                                                        End If
                                                    Case "2SSO"
                                                        If FrontDoorOpeningWidth < 30 Then
                                                            CurValue &= " (24 in. - 29 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 30 And FrontDoorOpeningWidth < 49 Then
                                                            CurValue &= " (30 in. - 48 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 49 And FrontDoorOpeningWidth < 65 Then
                                                            CurValue &= " (49 in. - 64 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 65 Then
                                                            CurValue &= " (65 in. - 72 in. Opening)"
                                                        End If
                                                    Case "2SCO"
                                                        If FrontDoorOpeningWidth < 60 Then
                                                            CurValue &= " (33 in. - 59 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 60 And FrontDoorOpeningWidth < 70 Then
                                                            CurValue &= " (60 in. - 69 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 70 And FrontDoorOpeningWidth < 74 Then
                                                            CurValue &= " (70 in. - 73 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 74 Then
                                                            CurValue &= " (74 in. - 83 in. Opening)"
                                                        End If
                                                    Case "3SSS"
                                                        If FrontDoorOpeningWidth < 49 Then
                                                            CurValue &= " (30 in. - 48 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 49 And FrontDoorOpeningWidth < 60 Then
                                                            CurValue &= " (49 in. - 59 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 60 And FrontDoorOpeningWidth < 69 Then
                                                            CurValue &= " (60 in. - 69 in. Opening)"
                                                        ElseIf FrontDoorOpeningWidth >= 70 Then
                                                            CurValue &= " (70 in. - 72 in. Opening)"
                                                        End If
                                                    Case Else
                                                End Select
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_RearCarDoorOperatorPackageOperatorGateSwitchHangerClutch, MAT_ID_RearCarDoorTrackHanger
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeRear_cmb")
                                                Case DOORTYPE_1SCO
                                                    CurValue = "1SCO"
                                                Case DOORTYPE_1SSS
                                                    CurValue = "1SSO"
                                                Case DOORTYPE_2SSS
                                                    CurValue = "2SSO"
                                                Case DOORTYPE_2SCO
                                                    CurValue = "2SCO"
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                Select Case CurValue
                                                    Case "1SCO"
                                                        If RearDoorOpeningWidth <= 50 Then
                                                            CurValue &= " (30 in. - 50 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth > 50 And RearDoorOpeningWidth < 60 Then
                                                            CurValue &= " (51 in. - 59 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 60 And RearDoorOpeningWidth < 69 Then
                                                            CurValue &= " (60 in. - 68 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 69 Then
                                                            CurValue &= " (69 in. - 83 in. Opening)"
                                                        End If
                                                    Case "1SSO"
                                                        If RearDoorOpeningWidth < 43 Then
                                                            CurValue &= " (22 in. - 42 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 43 Then
                                                            CurValue &= " (43 in. - 48 in. Opening)"
                                                        End If
                                                    Case "2SSO"
                                                        If RearDoorOpeningWidth < 30 Then
                                                            CurValue &= " (24 in. - 29 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 30 And RearDoorOpeningWidth < 49 Then
                                                            CurValue &= " (30 in. - 48 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 49 And RearDoorOpeningWidth < 65 Then
                                                            CurValue &= " (49 in. - 64 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 65 Then
                                                            CurValue &= " (65 in. - 72 in. Opening)"
                                                        End If
                                                    Case "2SCO"
                                                        If RearDoorOpeningWidth < 60 Then
                                                            CurValue &= " (33 in. - 59 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 60 And RearDoorOpeningWidth < 70 Then
                                                            CurValue &= " (60 in. - 69 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 70 And RearDoorOpeningWidth < 74 Then
                                                            CurValue &= " (70 in. - 73 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 74 Then
                                                            CurValue &= " (74 in. - 83 in. Opening)"
                                                        End If
                                                    Case "3SSS"
                                                        If RearDoorOpeningWidth < 49 Then
                                                            CurValue &= " (30 in. - 48 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 49 And RearDoorOpeningWidth < 60 Then
                                                            CurValue &= " (49 in. - 59 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 60 And RearDoorOpeningWidth < 69 Then
                                                            CurValue &= " (60 in. - 69 in. Opening)"
                                                        ElseIf RearDoorOpeningWidth >= 70 Then
                                                            CurValue &= " (70 in. - 72 in. Opening)"
                                                        End If
                                                    Case Else
                                                End Select
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_FrontCarDoorOperator
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeFront_cmb")
                                                Case DOORTYPE_1SCO
                                                    If FrontDoorOpeningWidth >= 30 And FrontDoorOpeningWidth <= 83 Then
                                                        CurValue = "1SCO (30 in. - 83 in. Opening)"
                                                    End If
                                                Case DOORTYPE_1SSS
                                                    If FrontDoorOpeningWidth >= 22 And FrontDoorOpeningWidth <= 48 Then
                                                        CurValue = "1SSO (22 in. - 48 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SSS
                                                    If FrontDoorOpeningWidth >= 24 And FrontDoorOpeningWidth <= 72 Then
                                                        CurValue = "2SSO (24 in. - 72 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SCO
                                                    If FrontDoorOpeningWidth >= 33 And FrontDoorOpeningWidth <= 83 Then
                                                        CurValue = "2SCO (33 in. - 83 in. Opening)"
                                                    End If
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_RearCarDoorOperator
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeRear_cmb")
                                                Case DOORTYPE_1SCO
                                                    If RearDoorOpeningWidth >= 30 And RearDoorOpeningWidth <= 83 Then
                                                        CurValue = "1SCO (30 in. - 83 in. Opening)"
                                                    End If
                                                Case DOORTYPE_1SSS
                                                    If RearDoorOpeningWidth >= 22 And RearDoorOpeningWidth <= 48 Then
                                                        CurValue = "1SSO (22 in. - 48 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SSS
                                                    If RearDoorOpeningWidth >= 24 And RearDoorOpeningWidth <= 72 Then
                                                        CurValue = "2SSO (24 in. - 72 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SCO
                                                    If RearDoorOpeningWidth >= 33 And RearDoorOpeningWidth <= 83 Then
                                                        CurValue = "2SCO (33 in. - 83 in. Opening)"
                                                    End If
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_FrontClutch
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeFront_cmb")
                                                Case DOORTYPE_1SCO
                                                    If FrontDoorOpeningWidth >= 30 And FrontDoorOpeningWidth < 60 Then
                                                        CurValue = "1SCO (30 in. - 59 in. Opening)"
                                                    ElseIf FrontDoorOpeningWidth >= 60 And FrontDoorOpeningWidth <= 83 Then
                                                        CurValue = "1SCO (60 in. - 83 in. Opening)"
                                                    End If
                                                Case DOORTYPE_1SSS
                                                    If FrontDoorOpeningWidth >= 22 And FrontDoorOpeningWidth <= 48 Then
                                                        CurValue = "1SSO (22 in. - 48 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SSS
                                                    If FrontDoorOpeningWidth >= 24 And FrontDoorOpeningWidth <= 72 Then
                                                        CurValue = "2SSO (24 in. - 72 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SCO
                                                    If FrontDoorOpeningWidth >= 33 And FrontDoorOpeningWidth <= 83 Then
                                                        CurValue = "2SCO (33 in. - 83 in. Opening)"
                                                    End If
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_RearClutch
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                            AddToOptions = True
                                        Else
                                            Select Case GetValue_GeneralInfo(CurDataset, "DoorOperatorTypeRear_cmb")
                                                Case DOORTYPE_1SCO
                                                    If RearDoorOpeningWidth >= 30 And RearDoorOpeningWidth < 60 Then
                                                        CurValue = "1SCO (30 in. - 59 in. Opening)"
                                                    ElseIf RearDoorOpeningWidth >= 60 And RearDoorOpeningWidth <= 83 Then
                                                        CurValue = "1SCO (60 in. - 83 in. Opening)"
                                                    End If
                                                Case DOORTYPE_1SSS
                                                    If RearDoorOpeningWidth >= 22 And RearDoorOpeningWidth <= 48 Then
                                                        CurValue = "1SSO (22 in. - 48 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SSS
                                                    If RearDoorOpeningWidth >= 24 And RearDoorOpeningWidth <= 72 Then
                                                        CurValue = "2SSO (24 in. - 72 in. Opening)"
                                                    End If
                                                Case DOORTYPE_2SCO
                                                    If RearDoorOpeningWidth >= 33 And RearDoorOpeningWidth <= 83 Then
                                                        CurValue = "2SCO (33 in. - 83 in. Opening)"
                                                    End If
                                                Case Else
                                            End Select
                                            If Not String.IsNullOrEmpty(CurValue) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        End If
                                    Case MAT_ID_FrontCarDoorGateSwitch, MAT_ID_RearCarDoorGateSwitch
                                        If IsPOHController Then
                                            AddToOptions = True
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") = -1 Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_DoorDetectors
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Minimax") > -1 Then
                                            If FrontDoorOpeningHeight = 84 Or RearDoorOpeningHeight = 84 Then
                                                CurValue = "15ft"
                                            ElseIf FrontDoorOpeningHeight > 84 Or RearDoorOpeningHeight > 84 Then
                                                CurValue = "25ft"
                                            End If
                                        Else
                                            If FrontDoorOpeningHeight = 84 Or RearDoorOpeningHeight = 84 Then
                                                CurValue = "= 84"
                                            ElseIf (FrontDoorOpeningHeight > 84 And FrontDoorOpeningHeight <= 120) Or
                                                   (RearDoorOpeningHeight > 84 And RearDoorOpeningHeight <= 120) Then
                                                CurValue = "> 84"
                                            End If
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_HoistRopes
                                        If MachineType = GEARED_TYPE Then
                                            CurValue = "TS"
                                        ElseIf MachineType = GEARLESS_TYPE Then
                                            Select Case MN_TRQ01_typ.MachineModelNew
                                                Case MACHINE_FMR355, MACHINE_PMR490
                                                    CurValue = MN_TRQ01_typ.MachineModelNew
                                                Case MACHINE_FM560
                                                    CurValue = "FMR 560"
                                                Case MACHINE_FM630
                                                    CurValue = "FMR 630"
                                                Case MACHINE_FM710
                                                    CurValue = "FMR 710"
                                                Case Else
                                                    CurValue = """" & " Dia EHS"
                                            End Select
                                        End If
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_HoistwayLimitSwitch
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("New") > -1 Then
                                            AddToOptions = True
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(OEMVendor) > -1 Then
                                            AddToOptions = True
                                        End If
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
                                    Case MAT_ID_PedestalBase, MAT_ID_MountingStyle42Flat, MAT_ID_Backplates
                                        If Not IsPOHController Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_CarBuffer, MAT_ID_CwtBuffer
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Spring") > -1 Then
                                            Select Case Speed
                                                Case Is = 0
                                                Case Is <= 100
                                                    Select Case GetValue_GeneralInfo(CurDataset, "Application_cmb")
                                                        Case "Passenger"
                                                            CurValue = "100 fpm (passenger)"
                                                        Case "Freight"
                                                            CurValue = "100 fpm (freight)"
                                                        Case Else
                                                    End Select
                                                Case Is <= 150
                                                    Select Case GetValue_GeneralInfo(CurDataset, "Application_cmb")
                                                        Case "Passenger"
                                                            CurValue = "150 fpm (passenger)"
                                                        Case "Freight"
                                                            CurValue = "150 fpm (freight)"
                                                        Case Else
                                                    End Select
                                                Case Is <= 200
                                                    Select Case GetValue_GeneralInfo(CurDataset, "Application_cmb")
                                                        Case "Passenger"
                                                            CurValue = "200 fpm (passenger)"
                                                        Case "Freight"
                                                            CurValue = "200 fpm (freight)"
                                                        Case Else
                                                    End Select
                                                Case Else
                                            End Select
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Oil") > -1 Then
                                            Select Case Speed
                                                Case Is = 0
                                                Case Is <= 355
                                                    CurValue = "355"
                                                Case Is <= 400
                                                    CurValue = "400"
                                                Case Is <= 453
                                                    CurValue = "453"
                                                Case Is <= 500
                                                    CurValue = "500"
                                                Case Is <= 620
                                                    CurValue = "620"
                                                Case Is <= 700
                                                    CurValue = "700"
                                                Case Else
                                                    CurValue = "1000"
                                            End Select
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_CarGovernorRope
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") > -1 Then
                                            If Not String.IsNullOrEmpty(CarGovernorType) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CarGovernorType) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("B5") > -1 Or
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("B22") > -1 Then
                                            Select Case CarGovernor
                                                Case "Reuse", "Refurbish"
                                                    AddToOptions = True
                                                Case Else
                                            End Select
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("HW") Then
                                            If CarGovernor = "New" Then
                                                If Not String.IsNullOrEmpty(CarGovernorType) Then
                                                    If CarGovernorType.IndexOf("HW") > -1 Then
                                                        AddToOptions = True
                                                    End If
                                                End If
                                            Else
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_CwtGovernorRope
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("GB") > -1 Then
                                            If Not String.IsNullOrEmpty(CwtGovernorType) Then
                                                If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CwtGovernorType) > -1 Then
                                                    AddToOptions = True
                                                End If
                                            End If
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("B5") > -1 Or
                                               UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("B22") > -1 Then
                                            Select Case CwtGovernor
                                                Case "Reuse", "Refurbish"
                                                    AddToOptions = True
                                                Case Else
                                            End Select
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("HW") Then
                                            If CwtGovernor = "New" Then
                                                If Not String.IsNullOrEmpty(CwtGovernorType) Then
                                                    If CwtGovernorType.IndexOf("HW") > -1 Then
                                                        AddToOptions = True
                                                    End If
                                                End If
                                            Else
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_CarRollerGuideAdapterPlate
                                        If GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_CarItems, MAT_ID_RollerGuidesCar) = "New" Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_MachineFrameandSecondarySheave
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Imperial") > -1 Then
                                            AddToOptions = True
                                        ElseIf Not IsPOHController Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_BrakeSwitchRGD
                                        CurValue = "Non-HW"
                                        If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb") = HOLLISTERWHITNEY Then
                                            CurValue = "Hollister Whitney"
                                        End If
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_ACMotorNGD
                                        If IsPOHController Then
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("POH") > -1 Then
                                                AddToOptions = True
                                            End If
                                        Else
                                            Select Case Conversion.Val(ExtractMotorRPM(MN_TRQ01_typ.MotorRPM))
                                                Case Is <= 850
                                                    If Conversion.Val(MN_TRQ01_typ.NominalMotorHP) <= 35 Then
                                                        CurValue = "35 hp, 850 rpm"
                                                    Else
                                                        CurValue = "50 hp, 850 rpm"
                                                    End If
                                                Case Is <= 1150
                                                    Select Case Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
                                                        Case Is <= 15
                                                            CurValue = "15 hp"
                                                        Case Is <= 25
                                                            CurValue = "25 hp"
                                                        Case Is <= 30
                                                            CurValue = "30 hp"
                                                        Case Is <= 35
                                                            CurValue = "35 hp"
                                                        Case Is <= 50
                                                            CurValue = "50 hp"
                                                        Case Is <= 60
                                                            CurValue = "60 hp"
                                                        Case Else
                                                            CurValue = "75 hp"
                                                    End Select
                                                    CurValue &= ", 1150 rpm"
                                                Case Else
                                                    Select Case Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
                                                        Case Is <= 15
                                                            CurValue = "15 hp"
                                                        Case Is <= 25
                                                            CurValue = "25 hp"
                                                        Case Is <= 35
                                                            CurValue = "35 hp"
                                                        Case Is <= 40
                                                            CurValue = "40 hp"
                                                        Case Else
                                                            CurValue = "50 hp"
                                                    End Select
                                                    CurValue &= ", 1750 rpm"
                                            End Select
                                        End If
                                    Case MAT_ID_Encoder
                                        CurValue = GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_Cmb")
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                            AddToOptions = True
                                        ElseIf UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf("Universal") > -1 Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_CarGovernorTensionSheave, MAT_ID_CwtGovernorTensionSheave
                                        If CurMATID = MAT_ID_CarGovernorTensionSheave Then
                                            CurValue = CarGovernorType
                                        Else
                                            CurValue = CwtGovernorType
                                        End If
                                        If Not String.IsNullOrEmpty(CurValue) Then
                                            If CurValue.IndexOf("HW") > -1 Then
                                                CurValue = "HW"
                                            ElseIf CurValue.IndexOf("GB") > -1 Then
                                                CurValue = "GB"
                                            End If
                                            If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                                AddToOptions = True
                                            End If
                                        End If
                                    Case MAT_ID_RopeGripper
                                        CurValue = GetValue_GeneralInfo(CurDataset, "MachineType_cmb")
                                        If Not (CurValue = MACHINE_FMM200 Or (CurValue = "New " & GEARLESS_TYPE And
                                               (GetValue_GeneralInfo(CurDataset, "DriveType_cmb") = AC_TYPE Or
                                               GetValue_GeneralInfo(CurDataset, "DriveType_cmb") = AC_REGEN_TYPE))) Then
                                            AddToOptions = True
                                        End If
                                    Case MAT_ID_RopeSplayClamp
                                        CurValue = Strings.Left(RopingNew, 3)
                                        If UseMaterialItemRecordSet.Fields("Types").Value.ToString.IndexOf(CurValue) > -1 Then
                                            AddToOptions = True
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
                        If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                            CurValue = CurrentSheet.Cells(RowNum, MAT_COL_OPTION_ALT).Text
                        Else
                            CurValue = CurrentSheet.Cells(RowNum, MAT_COL_OPTION_EST).Text
                        End If
                        If CurValue = "Refurbish" Then
                            Options = {"RL"}
                        Else
                            If IsPOHController Then
                                CurValue = "Order by POH"
                            Else
                                CurValue = "Order by TX"
                            End If
                            Select Case CurMATID
                                Case MAT_ID_HoistRopes, MAT_ID_HoistCableShackles
                                    Select Case GetValue_GeneralInfo(CurDataset, "MachineType_cmb")
                                        Case "Reuse " & GEARED_TYPE, "Reuse " & GEARLESS_TYPE
                                            If IsDBNull(UseMaterialItemRecordSet.Fields(CurValue).Value) Then
                                                Options = {"EE", "ME", "RL"}
                                            Else
                                                Options = {"ME", "RL"}
                                            End If
                                        Case "New " & GEARED_TYPE, "New " & GEARLESS_TYPE
                                            Options = {"ME"}
                                        Case Else
                                    End Select
                                Case MAT_ID_CompensationSheave
                                    Select Case GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_CompensationSheave)
                                        Case "New"
                                            Options = {"ME"}
                                        Case "Refurbish"
                                            Options = {"RL"}
                                        Case Else
                                            If IsDBNull(UseMaterialItemRecordSet.Fields(CurValue).Value) Then
                                                Options = {"EE", "ME", "RL"}
                                            Else
                                                Options = UseMaterialItemRecordSet.Fields(CurValue).Value.ToString.Split("/")
                                            End If
                                    End Select
                                Case MAT_ID_CompensationSwitch
                                    Select Case GetValue_Materials(CurDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_CompensationSwitch)
                                        Case "New"
                                            Options = {"ME"}
                                        Case "Refurbish"
                                            Options = {"RL"}
                                        Case Else
                                            If IsDBNull(UseMaterialItemRecordSet.Fields(CurValue).Value) Then
                                                Options = {"EE", "ME", "RL"}
                                            Else
                                                Options = UseMaterialItemRecordSet.Fields(CurValue).Value.ToString.Split("/")
                                            End If
                                    End Select
                                Case Else
                                    If IsDBNull(UseMaterialItemRecordSet.Fields(CurValue).Value) Then
                                        Options = {"EE", "ME", "RL"}
                                    Else
                                        Options = UseMaterialItemRecordSet.Fields(CurValue).Value.ToString.Split("/")
                                    End If
                            End Select
                        End If
                    Case Else
                End Select
            End If
            If IsNothing(Options) Then
                ReturnCmb.Clear()
            Else
                Dim SetAutoSizeCol As Boolean = False
                For iIndex = Options.GetLowerBound(0) To Options.GetUpperBound(0)
                    Options(iIndex) = Options(iIndex).Trim
                    If Options(iIndex).Length >= 15 Then
                        SetAutoSizeCol = True
                    End If
                Next iIndex
                iIndex = Options.GetUpperBound(0) + 1
                ReturnCmb.Items = Options
                ReturnCmb.MaxDrop = Options.Length
                ReturnCmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
                ReturnCmb.Editable = False
                If SetAutoSizeCol Then
                    ReturnCmb.ListWidth = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In SetSPRCombo")

        End Try
        Return ReturnCmb

    End Function
    Public Function SetSPRText(ByVal TextType As String, ByVal CurrentSheet As FarPoint.Win.Spread.SheetView, ByVal RowNum As Integer) As String
        Dim CurMATID As String = CurrentSheet.Cells(RowNum, MAT_COL_MATERIAL_ID).Text
        Dim UseWhere As String = "[Sub ID] = '" & CurMATID & "'"
        Dim ReturnIntVal As Integer = -999
        Dim ReturnVal As String = String.Empty
        Dim CurTravel As Single = 0, CurPitDepth As Single = 0, CurOverhead As Single = 0, TotalTravel As Single = 0
        Dim CurDataset As DataSet = Nothing
        Dim FrontOpenings As Integer = 0, RearOpenings As Integer = 0, TotalOpenings As Integer = 0, HoistRopeQty As Integer = 0
        Dim RopingNew As String = String.Empty

        Try
            CurDataset = SetCurrentDataset()
            CurTravel = Conversion.Val(GetValue_GeneralInfo(CurDataset, "TravelNew_txt"))
            CurPitDepth = Conversion.Val(GetValue_GeneralInfo(CurDataset, "PitDepth_txt"))
            CurOverhead = CurOverhead
            TotalTravel = CurTravel + CurOverhead + CurPitDepth
            FrontOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsFront_cmb"))
            RearOpenings = Conversion.Val(GetValue_GeneralInfo(CurDataset, "NumberofStopsRear_cmb"))
            TotalOpenings = FrontOpenings + RearOpenings
            HoistRopeQty = Conversion.Val(GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "HoistRopeQty_Cmb"))
            RopingNew = GetValue_GeneralInfo(CurDataset, "RopingNew_Cmb")
            If Math.Round(Conversion.Val(CurMATID)) > 900.0 Then
                CurMATID = "900" & Strings.Right(CurMATID, 3)
                UseWhere = "[Sub ID] = '" & CurMATID & "'"
            End If
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
                            If Not String.IsNullOrEmpty(UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value.ToString) Then
                                Select Case UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value.ToString.Trim.ToUpper
                                    Case "LENGTH = TRAVEL + OVERHEAD + 3XPIT DEPTH + 60"
                                        ReturnIntVal *= Math.Round(CurTravel + CurOverhead + (3 * CurPitDepth) + 60)
                                    Case "1 IF FRONT OPENING, 2 IF FRONT & REAR OPENING"
                                        If RearOpenings > 0 Then
                                            ReturnIntVal = 2
                                        End If
                                    Case "2 * NO. OF ROPES"
                                        ReturnIntVal = 2 * HoistRopeQty
                                    Case "1 PER LANDING PER CAR", "1 PER OPENING"
                                        ReturnIntVal = TotalOpenings
                                    Case "1 PER BUFFER PER CAR"
                                        ReturnIntVal = GetValue_Materials(CurDataset, UseUnitQtyCol, MAIN_ID_PIT, CurMATID)
                                    Case "2 CABLES OF LENGTH = (TRAVEL+2*PIT DEPTH+10FT)"
                                        ReturnIntVal *= Math.Round(CurTravel + (2 * CurPitDepth) + 10)
                                    Case "NO. OF COMP ROPES X (TRAVEL +  2*PIT DEPTH + 10FT)"
                                        ReturnIntVal *= Math.Round((CurTravel + (2 * CurPitDepth) + 10) * Conversion.Val(MN_TRQ01_typ.CompensationQty))
                                    Case "LENGTH PER CAR = (TRAVEL + PIT DEPTH + TOP FLOOR TO OVERHEAD + 10 FT)*2"
                                        ReturnIntVal *= Math.Round((CurTravel + CurPitDepth + CurOverhead + 10) * 2)
                                    Case "2 PER OPENING PER CAR"
                                        ReturnIntVal *= 2 * TotalOpenings
                                    Case "2 PER FRONT OPENING PER CAR"
                                        ReturnIntVal *= 2 * FrontOpenings
                                    Case "2 PER REAR OPENING PER CAR"
                                        ReturnIntVal *= 2 * RearOpenings
                                    Case Else
                                        If CurMATID = MAT_ID_HoistRopes Then
                                            ReturnIntVal = HoistRopeQty
                                            If RopingNew.IndexOf("1:1") > -1 Then
                                                Select Case GetValue_GeneralInfo(CurDataset, "MachineLocation_Cmb")
                                                    Case "Overhead"
                                                        ReturnIntVal *= CurTravel + (2 * CurOverhead) + CurPitDepth
                                                    Case "Basement", "Semi-Basement"
                                                        ReturnIntVal *= (3 * CurTravel) + (2 * CurOverhead) + CurPitDepth
                                                    Case Else
                                                End Select
                                            ElseIf RopingNew.IndexOf("2:1") > -1 Then
                                                Select Case GetValue_GeneralInfo(CurDataset, "MachineLocation_Cmb")
                                                    Case "Overhead"
                                                        ReturnIntVal *= (2 * CurTravel) + (4 * CurOverhead) + (2 * CurPitDepth)
                                                    Case "Basement", "Semi-Basement"
                                                        ReturnIntVal *= (4 * CurTravel) + (6 * CurOverhead) + (2 * CurPitDepth)
                                                    Case Else
                                                End Select
                                            End If
                                            If RopingNew.IndexOf("Underslung") > -1 Then
                                                ReturnIntVal += 30
                                            ElseIf RopingNew.IndexOf("Dual Wrap") > -1 Then
                                                ReturnIntVal += 20
                                            End If
                                        End If
                                End Select
                            End If
                        End If
                    Case "Description"
                        If Not IsDBNull(UseMaterialItemRecordSet.Fields("Sub").Value) Then
                            ReturnVal = UseMaterialItemRecordSet.Fields("Sub").Value.ToString
                        End If
                    Case Else
                End Select
            End If
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
    Public Function GetValue(ByVal CurTable As DataTable, ByVal UseField As String, Optional ByVal UseMainID As String = "", Optional ByVal UseMaterialID As String = "") As String
        Dim ReturnVal As String = String.Empty
        Dim CurRow As Integer = 0, iIndex As Integer = 0
        Dim CurDataRow As DataRow = Nothing

        For iIndex = 0 To CurTable.Rows.Count - 1
            CurDataRow = CurTable.Rows(iIndex)
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
        Dim CurDataset As DataSet = Nothing
        Dim CurrentController As String = String.Empty

        CurDataset = SetCurrentDataset()
        SetAssociatedFieldNames()
        CurrentController = GetValue_Materials(CurDataset, UseTypeCol, MAIN_ID_Controller, MAT_ID_Controller)
        If CurrentController.IndexOf("TXR5") = -1 Then
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
        Dim Material_HQ As Single = 0, Material_RL As Single = 0, TempCost As Single = 0, TempBaseCost As Single = 0
        Dim BDP_Hours As Single = 0, Special_Hours As Single = 0, Labor_Hours As Single = 0, Labor_Cost As Single = 0
        Dim TempBDP_Hours As Single = 0, TempSpecial_Hours As Single = 0, TempBaseBDP_Hours As Single = 0, TempBaseSpecial_Hours As Single = 0
        Dim SubContract_Work As Single = 0, PBO_Costs As Single = 0, Expenses As Single = 0, Freight As Single = 0, NPS_Cost As Single = 0
        Dim Engineering As Single = 0
        Dim Total_Bank_Cost As Single = 0, Bank_Net_Price As Single = 0
        Dim Sales_Commission As Single = 0, NPS_Surcharge As Single = 0, Taxes As Single = 0
        Dim UseWhere As String = String.Empty, PerUnit As String = String.Empty
        Dim PerCarQty As Single = CalculateNumberOfCarsInEstimate(CurUnits)
        Dim MaterialQty As Single = 0, LaborQty As Single = 0
        Dim UseFieldName As String = String.Empty
        Dim CurDataset As DataSet = Nothing
        Dim SubContract_Work_Base As Single = 0, Material_RL_Base As Single = 0, Material_HQ_Base As Single = 0, BDP_Hours_Base As Single = 0,
            Special_Hours_Base As Single = 0

        Try
            CurDataset = SetCurrentDataset()
            'CJ (10/23/17) - still need to program multiple tabs - will only update based on single tab
            For iIndex = 0 To SubGroups.Rows.Count - 1
                CurDataRow = SubGroups.Rows(iIndex)
                If Not IsDBNull(CurDataRow(UseOptionCol)) Then
                    ResetADODBRecordset(UseMaterialItemRecordSet)
                    UseMaterialItemRecordSet.Open(COMPONENT_LIST_TABLE, ADOConnectionMODDataDataBase)
                    If UseMaterialItemRecordSet.RecordCount > 0 Then
                        'Base Cost/Hours
                        If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                            UseWhere = "[Sub ID] = '" & CurDataRow(TABLECOL_MATERIALID) & "'"
                            If Not IsDBNull(CurDataRow(TABLECOL_TYPE_BASE)) Then
                                UseWhere &= " AND Types = '" & CurDataRow(TABLECOL_TYPE_BASE) & "'"
                            End If
                            UseMaterialItemRecordSet.Filter = UseWhere
                            If UseMaterialItemRecordSet.RecordCount > 0 Then
                                UseMaterialItemRecordSet.MoveFirst()
                                Select Case CurDataRow(TABLECOL_OPTION_BASE)
                                    Case "New", "Refurbish", "Included"
                                        'Material Qty and Cost
                                        PerUnit = String.Empty
                                        If Not IsDBNull(UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value) Then
                                            PerUnit = UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value.ToString.Trim.ToUpper
                                        End If
                                        Select Case PerUnit
                                            Case "PER BANK", "PER JOB"
                                                MaterialQty = 1
                                            Case Else
                                                MaterialQty = PerCarQty
                                        End Select
                                        TempBaseCost = GetBaseValue_ForTotals(TABLECOL_MATERIALID, "Cost") * MaterialQty
                                        Select Case CurDataRow(TABLECOL_MAINID)
                                            Case MAIN_ID_Miscellaneous, MAIN_ID_SubcontractingWork
                                                SubContract_Work_Base += TempBaseCost
                                            Case Else
                                                If String.IsNullOrEmpty(CurDataRow(TABLECOL_ORDERBY_BASE)) OrElse
                                                   CurDataRow(TABLECOL_ORDERBY_BASE).ToString = "RL" Then
                                                    Material_RL_Base += TempBaseCost
                                                Else
                                                    Material_HQ_Base += TempBaseCost
                                                End If
                                        End Select
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
                                        TempBaseBDP_Hours = GetBaseValue_ForTotals(TABLECOL_MATERIALID, "BDP Hours") * LaborQty
                                        TempBaseSpecial_Hours = GetBaseValue_ForTotals(TABLECOL_MATERIALID, "Spec Hours") * LaborQty
                                        BDP_Hours_Base += TempBaseBDP_Hours
                                        Special_Hours_Base += TempBaseSpecial_Hours
                                    Case "Reuse"
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
                                        TempBaseBDP_Hours = GetBaseValue_ForTotals(TABLECOL_MATERIALID, "BDP Hours") * LaborQty
                                        TempBaseSpecial_Hours = GetBaseValue_ForTotals(TABLECOL_MATERIALID, "Spec Hours") * LaborQty
                                        BDP_Hours_Base += TempBaseBDP_Hours
                                        Special_Hours_Base += TempBaseSpecial_Hours
                                    Case Else
                                End Select
                            End If
                        End If
                        'Cost/Hours
                        UseWhere = "[Sub ID] = '" & CurDataRow(TABLECOL_MATERIALID) & "'"
                        If Not IsDBNull(CurDataRow(UseTypeCol)) Then
                            UseWhere &= " AND Types = '" & CurDataRow(UseTypeCol) & "'"
                        End If
                        UseMaterialItemRecordSet.Filter = UseWhere
                        If UseMaterialItemRecordSet.RecordCount > 0 Then
                            UseMaterialItemRecordSet.MoveFirst()
                            Select Case CurDataRow(UseOptionCol)
                                Case "New", "Refurbish", "Included"
                                    'Material Qty and Cost
                                    PerUnit = String.Empty
                                    If Not IsDBNull(UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value) Then
                                        PerUnit = UseMaterialItemRecordSet.Fields("Cost Qty Logic").Value.ToString.Trim.ToUpper
                                    End If
                                    Select Case PerUnit
                                        Case "PER BANK", "PER JOB"
                                            MaterialQty = 1
                                        Case Else
                                            MaterialQty = PerCarQty
                                    End Select
                                    TempCost = CurDataRow(TABLECOL_UNITCOST) * MaterialQty
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempCost, 2) = Math.Round(TempBaseCost, 2) Then
                                            TempCost = 0
                                        ElseIf Math.Round(TempCost, 2) < Math.Round(TempBaseCost, 2) Then
                                            TempCost -= TempBaseCost
                                        Else
                                            TempCost = TempBaseCost - TempCost
                                        End If
                                    End If
                                    Select Case CurDataRow(TABLECOL_MAINID)
                                        Case MAIN_ID_Miscellaneous, MAIN_ID_SubcontractingWork
                                            SubContract_Work += TempCost
                                        Case Else
                                            If IsDBNull(CurDataRow(UseOrderByCol)) OrElse String.IsNullOrEmpty(CurDataRow(UseOrderByCol)) OrElse
                                               CurDataRow(UseOrderByCol).ToString = "RL" Then
                                                Material_RL += TempCost
                                            Else
                                                Material_HQ += TempCost
                                            End If
                                    End Select
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
                                    TempBDP_Hours = CurDataRow(TABLECOL_STDHOURS) * LaborQty
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempBDP_Hours, 2) = Math.Round(TempBaseBDP_Hours, 2) Then
                                            TempBDP_Hours = 0
                                        ElseIf Math.Round(TempBDP_Hours, 2) < Math.Round(TempBaseBDP_Hours, 2) Then
                                            TempBDP_Hours -= TempBaseBDP_Hours
                                        Else
                                            TempBDP_Hours = TempBaseBDP_Hours - TempBDP_Hours
                                        End If
                                    End If
                                    BDP_Hours += TempBDP_Hours
                                    TempSpecial_Hours = CurDataRow(TABLECOL_SPECHOURS) * LaborQty
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempSpecial_Hours, 2) = Math.Round(TempBaseSpecial_Hours, 2) Then
                                            TempSpecial_Hours = 0
                                        ElseIf Math.Round(TempSpecial_Hours, 2) < Math.Round(TempBaseSpecial_Hours, 2) Then
                                            TempSpecial_Hours -= TempBaseSpecial_Hours
                                        Else
                                            TempSpecial_Hours = TempBaseSpecial_Hours - TempSpecial_Hours
                                        End If
                                    End If
                                    Special_Hours += TempSpecial_Hours
                                Case "Reuse"
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempCost, 2) = Math.Round(TempBaseCost, 2) Then
                                            TempCost = 0
                                        ElseIf Math.Round(TempCost, 2) < Math.Round(TempBaseCost, 2) Then
                                            TempCost -= TempBaseCost
                                        Else
                                            TempCost = TempBaseCost - TempCost
                                        End If
                                        Select Case CurDataRow(TABLECOL_MAINID)
                                            Case MAIN_ID_Miscellaneous, MAIN_ID_SubcontractingWork
                                                SubContract_Work += TempCost
                                            Case Else
                                                If String.IsNullOrEmpty(CurDataRow(UseOrderByCol)) OrElse CurDataRow(UseOrderByCol).ToString = "RL" Then
                                                    Material_RL += TempCost
                                                Else
                                                    Material_HQ += TempCost
                                                End If
                                        End Select
                                    End If
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
                                    TempBDP_Hours = CurDataRow(TABLECOL_STDHOURS) * LaborQty
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempBDP_Hours, 2) = Math.Round(TempBaseBDP_Hours, 2) Then
                                            TempBDP_Hours = 0
                                        ElseIf Math.Round(TempBDP_Hours, 2) < Math.Round(TempBaseBDP_Hours, 2) Then
                                            TempBDP_Hours -= TempBaseBDP_Hours
                                        Else
                                            TempBDP_Hours = TempBaseBDP_Hours - TempBDP_Hours
                                        End If
                                    End If
                                    BDP_Hours += TempBDP_Hours
                                    TempSpecial_Hours = CurDataRow(TABLECOL_SPECHOURS) * LaborQty
                                    If CurrentGOData_Typ.EstimateLevel = "Alt" Then
                                        If Math.Round(TempSpecial_Hours, 2) = Math.Round(TempBaseSpecial_Hours, 2) Then
                                            TempSpecial_Hours = 0
                                        ElseIf Math.Round(TempSpecial_Hours, 2) < Math.Round(TempBaseSpecial_Hours, 2) Then
                                            TempSpecial_Hours -= TempBaseSpecial_Hours
                                        Else
                                            TempSpecial_Hours = TempBaseSpecial_Hours - TempSpecial_Hours
                                        End If
                                    End If
                                    Special_Hours += TempSpecial_Hours
                                Case Else
                            End Select
                        End If
                    End If
                    UseMaterialItemRecordSet.Close()
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
                        If CurDataRow("id") = UseAltId Then
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
                If CurrentGOData_Typ.EstimateLevel = "Alt" Then     'Adjsut costs = Base - curcost       
                    PBO_Costs = 0
                    Expenses = 0
                    NPS_Cost = 0
                Else
                    PBO_Costs = (Conversion.Val(GetValue_GeneralInfo(CurDataset, "Permits_txt")) * PerCarQty) +
                                 Conversion.Val(GetValue_GeneralInfo(CurDataset, "Bonds_txt")) +
                                 Conversion.Val(dtBuildingInfo(0)("ocpl"))
                    Expenses = Conversion.Val(GetValue_GeneralInfo(CurDataset, "ExpensesPerDay_txt"))
                    NPS_Cost = Conversion.Val(dtBuildingInfo(0)("nps_one_time_cost").ToString)
                    NPS_Cost += Conversion.Val(dtBuildingInfo(0)("nps_material_cost").ToString) * Conversion.Val(dtBuildingInfo(0)("nps_duration").ToString)
                    NPS_Cost *= PerCarQty
                    NPS_Cost += Conversion.Val(dtBuildingInfo(0)("nps_labor_cost").ToString) * Conversion.Val(dtBuildingInfo(0)("nps_duration").ToString) * PerCarQty
                End If
                CurDataRow("Material_HQ") = Math.Round(Material_HQ, 2)
                CurDataRow("Material_RL") = Math.Round(Material_RL, 2)
                CurDataRow("BDP_Hours") = Math.Round(BDP_Hours, 2)
                CurDataRow("Special_Hours") = Math.Round(Special_Hours, 2)
                Labor_Hours = BDP_Hours + Special_Hours
                Labor_Cost = Labor_Hours * BankLaborRate
                CurDataRow("Labor_Cost") = Math.Round(Labor_Cost, 2)
                CurDataRow("Labor_Rate") = BankLaborRate
                If CurDataRow("OT_Hours_Included") > Labor_Hours Then
                    CurDataRow("OT_Hours_Included") = 0
                Else
                    Labor_Hours -= CurDataRow("OT_Hours_Included")
                End If
                CurDataRow("Labor_Hours") = Math.Round(Labor_Hours, 2)
                CurDataRow("SubContract_Work") = Math.Round(SubContract_Work, 2)
                CurDataRow("Misc_Costs") = Math.Round(PBO_Costs, 2)
                CurDataRow("Expenses") = Math.Round(Expenses, 2)
                Freight = (Material_HQ + Material_RL) * FREIGHT_RATE
                CurDataRow("Freight") = Math.Round(Freight, 2)
                Engineering = (Material_HQ + Material_RL) * ENGINEERING_RATE
                CurDataRow("Engineering_Cost") = Math.Round(Engineering, 2)
                Total_Bank_Cost = Material_HQ + Material_RL + Labor_Cost + SubContract_Work + PBO_Costs + Expenses + Freight + NPS_Cost +
                                  PBO_Costs
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
                CurDataRow("speed") = Math.Round(Conversion.Val(GetValue_GeneralInfo(CurDataset, "SpeedNew_cmb")))
                CurDataRow("machine_model") = GetValue_GeneralInfo(CurDataset, "MachineType_cmb")
            End If
            CM_MAIN_frm.FpSpread1.Refresh()
            CM_MAIN_frm.CalculateC1_FinalBankPrice()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In UpdateAllTotals")

        End Try

    End Sub
    Private Function CalculateNPSSurcharge(ByVal CurrentPrice As Single) As Single
        Dim NPSSurcharge As Single = 0, NPSSurchargeRate As Single = 0

        If CurrentGOData_Typ.EstimateLevel <> "Alt" Then
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
        End If
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
    'Private Function GetPORTQty(ByVal MAT_ID As String, Optional ByVal UseBaseDataTable As Boolean = False) As Single
    '    Dim ReturnVal As Single = 0
    '    Dim PORTIndex As Integer = 0
    '    Dim PORTDataRow As DataRow = Nothing
    '    Dim UseDataTable As System.Data.DataTable = SubGroups

    '    If UseBaseDataTable Then
    '        UseDataTable = EstimatingDataset.Tables(TABLENAME_MATERIALS)
    '    End If
    '    For PORTIndex = 0 To UseDataTable.Rows.Count - 1
    '        PORTDataRow = UseDataTable.Rows(PORTIndex)
    '        If PORTDataRow(TABLECOL_MATERIALID).ToString = MAT_ID Then
    '            ReturnVal = Conversion.Val(PORTDataRow(UseUnitQtyCol).ToString)
    '            Exit For
    '        End If
    '    Next PORTIndex
    '    Return ReturnVal

    'End Function
    Public Sub SetAssociatedFieldNames()

        If CurrentGOData_Typ.EstimateLevel = "Alt" Then
            UseTypeCol = TABLECOL_TYPE_ALT
            UseOptionCol = TABLECOL_OPTION_ALT
            UseOrderByCol = TABLECOL_ORDERBY_ALT
            UseUnitQtyCol = TABLECOL_UNITQTY_ALT
        Else
            UseTypeCol = TABLECOL_TYPE_EST
            UseOptionCol = TABLECOL_OPTION_EST
            UseOrderByCol = TABLECOL_ORDERBY_EST
            UseUnitQtyCol = TABLECOL_UNITQTY_EST
        End If

    End Sub
    Public Function FindValueInDataRow(ByVal FieldName As String, ByVal UseDataRow As System.Data.DataRow) As String
        Dim drIndex As Integer = 0
        Dim ReturnVal As String = String.Empty

        If Not IsDBNull(UseDataRow(FieldName)) Then
            ReturnVal = UseDataRow(FieldName)
        End If
        Return ReturnVal

    End Function
    Public Function SetCurrentDataset() As DataSet
        Dim UseDataset As DataSet = Nothing

        Select Case CurrentGOData_Typ.EstimateLevel
            Case "Base", "Master"
                UseDataset = EstimatingDataset
            Case "Alt"
                UseDataset = AltDataset
            Case Else
        End Select
        Return UseDataset

    End Function
    Private Function GetBaseValue_ForTotals(ByVal MAT_ID As String, ByVal ValueType As String) As Single
        Dim ReturnVal As Single = 0
        Dim BaseIndex As Integer = 0
        Dim BaseDataRow As DataRow = Nothing
        Dim FieldName As String = TABLECOL_UNITCOST

        Select Case ValueType
            Case "BDP Hours"
                FieldName = TABLECOL_STDHOURS
            Case "Spec Hours"
                FieldName = TABLECOL_SPECHOURS
            Case Else
        End Select
        For BaseIndex = 0 To EstimatingDataset.Tables(TABLENAME_MATERIALS).Rows.Count - 1
            BaseDataRow = EstimatingDataset.Tables(TABLENAME_MATERIALS).Rows(BaseIndex)
            If BaseDataRow(TABLECOL_MATERIALID).ToString = MAT_ID Then
                ReturnVal = Conversion.Val(BaseDataRow(FieldName).ToString)
                Exit For
            End If
        Next BaseIndex
        Return ReturnVal

    End Function
    Private Function GetValue_GeneralInfo(ByRef UseDataset As DataSet, ByVal FieldName As String) As String
        Dim ReturnVal As String = String.Empty

        ReturnVal = GetValue(UseDataset.Tables(TABLENAME_GENERALINFO), FieldName)
        If String.IsNullOrEmpty(ReturnVal) And CurrentGOData_Typ.EstimateLevel = "Alt" Then
            ReturnVal = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), FieldName)
        End If
        Return ReturnVal

    End Function
    Public Function GetValue_Materials(ByRef UseDataset As DataSet, ByVal ColumnName As String, ByVal UseMainID As String, ByVal UseMatID As String) As String
        Dim ReturnVal As String = String.Empty

        ReturnVal = GetValue(UseDataset.Tables(TABLENAME_MATERIALS), ColumnName)
        If String.IsNullOrEmpty(ReturnVal) And CurrentGOData_Typ.EstimateLevel = "Alt" Then
            Select Case ColumnName
                Case TABLECOL_TYPE_ALT
                    ColumnName = TABLECOL_TYPE_BASE
                Case TABLECOL_OPTION_ALT
                    ColumnName = TABLECOL_OPTION_BASE
                Case TABLECOL_ORDERBY_ALT
                    ColumnName = TABLECOL_ORDERBY_BASE
                Case TABLECOL_UNITQTY_ALT
                    ColumnName = TABLECOL_UNITQTY_BASE
                Case Else
                    Return ReturnVal
            End Select
            ReturnVal = GetValue(UseDataset.Tables(TABLENAME_MATERIALS), ColumnName, UseMainID, UseMatID)
        End If
        Return ReturnVal

    End Function
    Public Sub MergeBaseWithAlts()
        Dim MasterFiles() As String = Nothing, AltFiles() As String = Nothing
        Dim JSONFileLocation As DirectoryInfo = New DirectoryInfo(EstimatePath)
        Dim iIndex As Integer = 0, jIndex As Integer = 0
        Dim NewMasterFileName As String = String.Empty
        Dim CurUnits As String = String.Empty

        Try
            For Each JSONFile In JSONFileLocation.GetFiles()
                If JSONFile IsNot Nothing Then
                    If Path.GetExtension(JSONFile.ToString.ToUpper) = ".JSON" Then
                        If JSONFile.ToString.ToUpper.Contains(Contracts.EstimateNum.ToUpper & CurrentGOData_Typ.Bank) Then
                            If JSONFile.ToString.ToUpper.Contains(FileSuffix_BASE) Then
                                NewMasterFileName = JSONFile.ToString.ToUpper.Replace(FileSuffix_BASE, FileSuffix_MASTER)
                                If File.Exists(EstimatePath & NewMasterFileName) Then
                                    File.Delete(EstimatePath & NewMasterFileName)
                                End If
                                JSONFile.CopyTo(EstimatePath & NewMasterFileName)
                                ReDim Preserve MasterFiles(iIndex)
                                MasterFiles(iIndex) = NewMasterFileName
                                iIndex += 1
                            ElseIf JSONFile.ToString.ToUpper.Contains(FileSuffix_ALT) Then
                                ReDim Preserve AltFiles(jIndex)
                                AltFiles(jIndex) = JSONFile.ToString
                                jIndex += 1
                            End If
                        End If
                    End If
                End If
            Next JSONFile
            If Not IsNothing(AltFiles) Then
                For iIndex = 0 To MasterFiles.GetUpperBound(0)
                    'CurUnits = Strings.Mid(MasterFiles(iIndex), 14, MasterFiles(iIndex).Length - 24)
                    'frmEstimatingBase.EstFileType = FileSuffix_BASE
                    'frmEstimatingBase.CreateEstimatingDataSet(CurUnits)


                Next iIndex
            End If

        Finally

        End Try
    End Sub
    Public Sub ReturnToCM(ByVal EstScreen As String)

        If Not IsNothing(UseMaterialItemRecordSet) Then
            If UseMaterialItemRecordSet.State = ADODB.ObjectStateEnum.adStateOpen Then
                UseMaterialItemRecordSet.Close()
            End If
        End If
        Select Case EstScreen
            Case "Estimating"
                Select Case frmEstimatingBase.PromptForSave()
                    Case MsgBoxResult.Yes
                        UpdateAllTotals(Strings.Left(CurrentTab, CurrentTab.Length - 6))
                        frmEstimatingBase.Cursor = Cursors.Default
                        frmEstimatingBase.Dispose()
                    Case MsgBoxResult.No, 0
                        frmEstimatingBase.Cursor = Cursors.Default
                        frmEstimatingBase.Dispose()
                    Case Else
                End Select
            Case "Alt"
                Select Case frmEstimatingAlt.PromptForSave()
                    Case MsgBoxResult.Yes
                        UpdateAllTotals(Strings.Left(CurrentTab, CurrentTab.Length - 6))
                        frmEstimatingAlt.Cursor = Cursors.Default
                        frmEstimatingAlt.Dispose()
                    Case MsgBoxResult.No, 0
                        frmEstimatingAlt.Cursor = Cursors.Default
                        frmEstimatingAlt.Dispose()
                    Case Else
                End Select
        End Select

    End Sub
    Public Function AllowedToSave() As Boolean
        Dim ReturnVal As Boolean = True
        Dim sMsg As String = String.Empty

        If Not ENABLE_BOOKING_BTN And Not ENG_ACCESS Then
            If CurrentGOData_Typ.EstimateStatus = STATUS_BOOK_SUCCEEDED Then
                ReturnVal = False
                sMsg = "Estimate has successfully Booked, saving changes now is not allowed."
            ElseIf CurrentGOData_Typ.EstimateStatus = STATUS_FROZEN Then
                ReturnVal = False
                sMsg = "Estimate has been frozen, saving changes now is not allowed."
            End If
        End If
        'If String.IsNullOrEmpty(sMsg) Then
        '    If ME_OCS01Car_typ.SuptReview = "Under Review" Then
        '        ReturnVal = False
        '        sMsg = "Estimate is under Supt Review - changes cannot be made to the estimate."
        '    End If
        'End If
        If Not String.IsNullOrEmpty(sMsg) Then
            MessageBox.Show(sMsg, "Cadre Save Restriction")
        End If
        Return ReturnVal

    End Function
    Public Sub ValidateChangeInCapacitySpeedTravel(ByVal CurCheckState As CheckState, ByRef UseLabel As Label, ByRef UseControl As Windows.Forms.Control)
        Dim EnableStatus As Boolean = False
        Dim UseCombo As ComboBox = Nothing
        Dim UseText As TextBox = Nothing

        If CurCheckState = CheckState.Checked Then
            EnableStatus = True
        Else
            If Not IsNothing(UseControl) Then
                If TypeOf UseControl Is ComboBox Then
                    UseCombo = UseControl
                    UseCombo.SelectedIndex = -1
                ElseIf TypeOf UseControl Is TextBox Then
                    UseText = UseControl
                    UseText.Text = String.Empty
                End If
            End If
        End If
        UseLabel.Enabled = EnableStatus
        UseControl.Enabled = EnableStatus

    End Sub
    Public Sub SetUpTorqueDataset(ByRef CurDataset As DataSet)

        TorqueData = CurDataset.Tables.Add(TABLENAME_TORQUEDATA)
        TorqueData.Columns.AddRange(New DataColumn() {New DataColumn("UnitsInTab", typeStr),
                                                      New DataColumn("MachineVendorExisting_Cmb", typeStr),
                                                      New DataColumn("MachineModelExisting_Cmb", typeStr),
                                                      New DataColumn("ExistingMachineSheaveDia_cmb", typeStr),
                                                      New DataColumn("NominalMotorRPM_txt", typeStr),
                                                      New DataColumn("BrakeType_cmb", typeStr),
                                                      New DataColumn("HoistRopeQty_Cmb", typeStr),
                                                      New DataColumn("HoistRopeSize_Cmb", typeStr),
                                                      New DataColumn("CarToCwtRopeDrop_txt", typeStr),
                                                      New DataColumn("Compensation_cmb", typeStr),
                                                      New DataColumn("CarSheaveQty_Cmb", typeStr),
                                                      New DataColumn("CwtSheaveQty_Cmb", typeStr),
                                                      New DataColumn("FullLoadCurrentIDC1_txt", typeStr),
                                                      New DataColumn("ArmatureFullLoadVoltageVFLU_txt", typeStr),
                                                      New DataColumn("MachineVendorNew_Cmb", typeStr),
                                                      New DataColumn("MachineModelNew_Cmb", typeStr),
                                                      New DataColumn("Acceleration", typeStr),
                                                      New DataColumn("bDirty", typeStr),
                                                      New DataColumn("bPowerData", typeStr),
                                                      New DataColumn("bSuperTable", typeStr),
                                                      New DataColumn("Calculated_KVA", typeStr),
                                                      New DataColumn("CarSheaveDiameter", typeStr),
                                                      New DataColumn("CarSheaveJ", typeStr),
                                                      New DataColumn("CarWeightCalculated", typeStr),
                                                      New DataColumn("CompensationWeight", typeStr),
                                                      New DataColumn("CompSheaveJ", typeStr),
                                                      New DataColumn("CompSheaveWt", typeStr),
                                                      New DataColumn("ControlCableWeight", typeStr),
                                                      New DataColumn("Counterweight", typeStr),
                                                      New DataColumn("CwtSheaveDiameter", typeStr),
                                                      New DataColumn("CwtSheaveJ", typeStr),
                                                      New DataColumn("Deceleration", typeStr),
                                                      New DataColumn("DecelerationD125", typeStr),
                                                      New DataColumn("DecelerationTraction", typeStr),
                                                      New DataColumn("DecelerationTSD", typeStr),
                                                      New DataColumn("DeflectorSheaveDiameter", typeStr),
                                                      New DataColumn("DeflectorSheaveJ", typeStr),
                                                      New DataColumn("DriveModel", typeStr),
                                                      New DataColumn("DriveModelDefault", typeStr),
                                                      New DataColumn("ForwardGearEfficiency", typeStr),
                                                      New DataColumn("GearRation1", typeStr),
                                                      New DataColumn("GearRation2", typeStr),
                                                      New DataColumn("GrooveNumber", typeStr),
                                                      New DataColumn("HatchEfficiency", typeStr),
                                                      New DataColumn("HiSpeedShaftInertia", typeStr),
                                                      New DataColumn("HoistCableQty", typeStr),
                                                      New DataColumn("HorizontalDistance", typeStr),
                                                      New DataColumn("IdlerSheaveDiameter", typeStr),
                                                      New DataColumn("InputVoltage", typeStr),
                                                      New DataColumn("len1", typeStr),
                                                      New DataColumn("len2", typeStr),
                                                      New DataColumn("len3", typeStr),
                                                      New DataColumn("MachineSheaveJ", typeStr),
                                                      New DataColumn("MainTravelingCable", typeStr),
                                                      New DataColumn("MainTravelingCableQty", typeStr),
                                                      New DataColumn("MaxGroovePressure", typeStr),
                                                      New DataColumn("MaxShaftSheaveLoad", typeStr),
                                                      New DataColumn("MotorRPM", typeStr),
                                                      New DataColumn("NominalMotorHP", typeStr),
                                                      New DataColumn("NominalMotorHPDefault", typeStr),
                                                      New DataColumn("NumberofCarTopSheaves", typeStr),
                                                      New DataColumn("NumberofIdlerSheaves", typeStr),
                                                      New DataColumn("OverheadSheaveInertia", typeStr),
                                                      New DataColumn("Required_KVA", typeStr),
                                                      New DataColumn("ReverseGearEfficiency", typeStr),
                                                      New DataColumn("RopeDrop", typeStr),
                                                      New DataColumn("RopeGrade", typeStr),
                                                      New DataColumn("RopeGripperModel", typeStr),
                                                      New DataColumn("RopeOffset", typeStr),
                                                      New DataColumn("RopeSplayKitMounting", typeStr),
                                                      New DataColumn("RopeStrength", typeStr),
                                                      New DataColumn("RopeWeight", typeStr),
                                                      New DataColumn("SheaveDiameter", typeStr),
                                                      New DataColumn("TractionAdder", typeStr),
                                                      New DataColumn("UN", typeStr),
                                                      New DataColumn("VerticalDistance", typeStr),
                                                      New DataColumn("WrapAngle", typeStr)})

    End Sub
    Public Sub SaveTorqueEngineeringData(ByVal CurDataRow As DataRow)

        CurDataRow("MachineVendorNew_Cmb") = MN_TRQ01_typ.MachineVendorNew
        CurDataRow("MachineModelNew_Cmb") = MN_TRQ01_typ.MachineModelNew
        CurDataRow("Acceleration") = MN_TRQ01_typ.Acceleration
        CurDataRow("bDirty") = MN_TRQ01_typ.bDirty
        CurDataRow("bPowerData") = MN_TRQ01_typ.bPowerData
        CurDataRow("bSuperTable") = MN_TRQ01_typ.bSuperTable
        CurDataRow("Calculated_KVA") = MN_TRQ01_typ.Calculated_KVA
        CurDataRow("CarSheaveDiameter") = MN_TRQ01_typ.CarSheaveDiameter
        CurDataRow("CarSheaveJ") = MN_TRQ01_typ.CarSheaveJ
        CurDataRow("CarWeightCalculated") = MN_TRQ01_typ.CarWeightCalculated
        CurDataRow("CompensationWeight") = MN_TRQ02_typ.CompensationWeight
        CurDataRow("CompSheaveJ") = MN_TRQ01_typ.CompSheaveJ
        CurDataRow("CompSheaveWt") = MN_TRQ01_typ.CompSheaveWt
        CurDataRow("ControlCableWeight") = MN_TRQ01_typ.ControlCableWeight
        CurDataRow("Counterweight") = MN_TRQ01_typ.Counterweight
        CurDataRow("CwtSheaveDiameter") = MN_TRQ01_typ.CwtSheaveDiameter
        CurDataRow("CwtSheaveJ") = MN_TRQ01_typ.CwtSheaveJ
        CurDataRow("Deceleration") = MN_TRQ01_typ.Deceleration
        CurDataRow("DecelerationD125") = MN_TRQ01_typ.DecelerationD125
        CurDataRow("DecelerationTraction") = MN_TRQ01_typ.DecelerationTraction
        CurDataRow("DecelerationTSD") = MN_TRQ01_typ.DecelerationTSD
        CurDataRow("DeflectorSheaveDiameter") = MN_TRQ01_typ.DeflectorSheaveDiameter
        CurDataRow("DeflectorSheaveJ") = MN_TRQ01_typ.DeflectorSheaveJ
        CurDataRow("DriveModel") = MN_TRQ01_typ.DriveModel
        CurDataRow("DriveModelDefault") = MN_TRQ01_typ.DriveModelDefault
        CurDataRow("ForwardGearEfficiency") = MN_TRQ01_typ.ForwardGearEfficiency
        CurDataRow("GearRation1") = MN_TRQ01_typ.GearRation1
        CurDataRow("GearRation2") = MN_TRQ01_typ.GearRation2
        CurDataRow("GrooveNumber") = MN_TRQ01_typ.GrooveNumber
        CurDataRow("HatchEfficiency") = MN_TRQ01_typ.HatchEfficiency
        CurDataRow("HiSpeedShaftInertia") = MN_TRQ01_typ.HiSpeedShaftInertia
        CurDataRow("HorizontalDistance") = MN_TRQ01_typ.HorizontalDistance
        CurDataRow("IdlerSheaveDiameter") = MN_TRQ01_typ.IdlerSheaveDiameter
        CurDataRow("InputVoltage") = MN_TRQ01_typ.InputVoltage
        CurDataRow("len1") = MN_TRQ01_typ.len1
        CurDataRow("len2") = MN_TRQ01_typ.len2
        CurDataRow("len3") = MN_TRQ01_typ.len3
        CurDataRow("MachineSheaveJ") = MN_TRQ01_typ.MachineSheaveJ
        CurDataRow("MainTravelingCable") = MN_TRQ01_typ.MainTravelingCable
        CurDataRow("MainTravelingCableQty") = MN_TRQ01_typ.MainTravelingCableQty
        CurDataRow("MaxGroovePressure") = MN_TRQ01_typ.MaxGroovePressure
        CurDataRow("MaxShaftSheaveLoad") = MN_TRQ01_typ.MaxShaftSheaveLoad
        CurDataRow("MotorRPM") = MN_TRQ01_typ.MotorRPM
        CurDataRow("NominalMotorHP") = MN_TRQ01_typ.NominalMotorHP
        CurDataRow("NominalMotorHPDefault") = MN_TRQ01_typ.NominalMotorHPDefault
        CurDataRow("NumberofCarTopSheaves") = MN_TRQ01_typ.NumberofCarTopSheaves
        CurDataRow("NumberofIdlerSheaves") = MN_TRQ01_typ.NumberofIdlerSheaves
        CurDataRow("OverheadSheaveInertia") = MN_TRQ01_typ.OverheadSheaveInertia
        CurDataRow("Required_KVA") = MN_TRQ01_typ.Required_KVA
        CurDataRow("ReverseGearEfficiency") = MN_TRQ01_typ.ReverseGearEfficiency
        CurDataRow("RopeDrop") = MN_TRQ01_typ.RopeDrop
        CurDataRow("RopeGrade") = MN_TRQ01_typ.RopeGrade
        CurDataRow("RopeGripperModel") = MN_TRQ01_typ.RopeGripperModel
        CurDataRow("RopeOffset") = MN_TRQ01_typ.RopeOffset
        CurDataRow("RopeSplayKitMounting") = MN_TRQ01_typ.RopeSplayKitMounting
        CurDataRow("RopeStrength") = MN_TRQ01_typ.RopeStrength
        CurDataRow("RopeWeight") = MN_TRQ01_typ.RopeWeight
        CurDataRow("SheaveDiameter") = MN_TRQ01_typ.SheaveDiameter
        CurDataRow("TractionAdder") = MN_TRQ01_typ.TractionAdder
        CurDataRow("UN") = MN_TRQ01_typ.UN
        CurDataRow("VerticalDistance") = MN_TRQ01_typ.VerticalDistance
        CurDataRow("WrapAngle") = MN_TRQ01_typ.WrapAngle

    End Sub
    Public Sub CreateLaborRateDataTable(ByRef CurDataset As DataSet)
        Dim column As DataColumn

        dtLaborRates = CurDataset.Tables.Add(TABLENAME_LABORRATES)

        dtLaborRates.Columns.Add("UnitsInTab")

        column = New DataColumn
        column.DataType = typeSingle
        column.DefaultValue = 0
        column.ColumnName = "rate_year"
        dtLaborRates.Columns.Add(column)

        column = New DataColumn
        column.DataType = typeSingle
        column.DefaultValue = 0
        column.ColumnName = "st_rate"
        dtLaborRates.Columns.Add(column)

        column = New DataColumn
        column.DataType = typeSingle
        column.DefaultValue = 0
        column.ColumnName = "ot_rate"
        dtLaborRates.Columns.Add(column)

        column = New DataColumn
        column.DataType = typeSingle
        column.DefaultValue = 0
        column.ColumnName = "labor_ratio_" & CurrentGOData_Typ.Bank
        dtLaborRates.Columns.Add(column)

    End Sub
    Public Sub RecalculateLaborRates()
        Dim rate_year As Integer = Year(Now)
        Dim adjustment As Decimal = 1.035
        Dim st_rate As Decimal
        Dim ot_rate As Decimal
        Dim myList As New List(Of String)()
        Dim installation_office As String
        Dim x As Integer

        Try
            If dtLaborRates.Rows.Count = 0 Then
                InitializeLaborRates()
            End If
            installation_office = dtBuildingInfo.Rows(0).Item("installing_office")
            If installation_office.Trim.Length = 0 Then
                Exit Sub
            End If
            myList = GetLaborRates(installation_office)
            x = CInt(dtLaborRates(0).Item("rate_year")) - rate_year
            For i As Integer = 0 To dtLaborRates.Rows.Count - 1
                st_rate = myList(0) * adjustment ^ x
                ot_rate = myList(1) * adjustment ^ x
                dtLaborRates.Rows(i).Item("st_rate") = Math.Round(st_rate, 2)
                dtLaborRates.Rows(i).Item("ot_rate") = Math.Round(ot_rate, 2)
                x += 1
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Processing Labor Rates", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub InitializeLaborRates()
        Dim rate_year As Integer = Year(Now)
        Dim adjustment As Decimal = 1.035
        Dim st_rate As Decimal
        Dim ot_rate As Decimal
        Dim myList As New List(Of String)()
        Dim installation_office As String
        Dim RatioStart As Integer = 20

        Try
            If dtBuildingInfo.Rows.Count = 0 OrElse dtBuildingInfo.Rows(0).Item("installing_office") = "" Then
                Exit Sub
            Else
                installation_office = dtBuildingInfo.Rows(0).Item("installing_office")
            End If
            myList = GetDataFromOptions("SELECT STRate, OTRate FROM [Rate (MOD Labor)] WHERE Office = '" & installation_office & "';", True)
            st_rate = myList(0)
            ot_rate = myList(1)
            For i As Integer = 0 To 9
                Dim workRow As DataRow = dtLaborRates.NewRow
                workRow("UnitsInTab") = CurrentTabUnits
                workRow("rate_year") = rate_year
                workRow("st_rate") = Math.Round(st_rate, 2)
                workRow("ot_rate") = Math.Round(ot_rate, 2)
                Select Case i
                    Case 0
                        workRow("labor_ratio_" & CurrentGOData_Typ.Bank) = 20
                    Case 1
                        workRow("labor_ratio_" & CurrentGOData_Typ.Bank) = 20
                    Case 2
                        workRow("labor_ratio_" & CurrentGOData_Typ.Bank) = 60
                    Case Else
                        workRow("labor_ratio_" & CurrentGOData_Typ.Bank) = 0
                End Select
                dtLaborRates.Rows.Add(workRow)
                rate_year += 1
                st_rate *= adjustment
                ot_rate *= adjustment
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in InitializeLaborRates", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Sub LockSPRComboIfMissingOptionsORSingleOption(ByRef CurCell As FarPoint.Win.Spread.Cell)
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
    Public Sub CreateOverTimeDataTable(ByRef CurDataset As DataSet)
        Dim column As DataColumn

        Try
            dtOverTime = CurDataset.Tables.Add(TABLENAME_OVERTIME)

            dtOverTime.Columns.Add("bank")
            column = New DataColumn
            column.DataType = typeInt
            column.DefaultValue = 4
            column.ColumnName = "work_days"
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "work_hours"
            column.DataType = typeInt
            column.DefaultValue = 10
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "#_teams"
            column.DataType = typeInt
            column.DefaultValue = 1
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "ot_%"
            column.DataType = typeSingle
            column.DefaultValue = 0
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "ot_labor_inefficiency"
            column.DataType = typeSingle
            column.DefaultValue = -999.99
            dtOverTime.Columns.Add(column)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Creating OverTime Datatable", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Sub InitializeOverTime()
        Dim newRow As DataRow = Nothing

        If dtOverTime.Rows.Count = 0 Then
            newRow = dtOverTime.NewRow
            newRow("bank") = CurrentGOData_Typ.Bank
            newRow("ot_labor_inefficiency") = 0
            dtOverTime.Rows.Add(newRow)
            isDirty = True
        Else
            newRow = dtOverTime(0)
            If newRow("ot_labor_inefficiency") = -999.99 Then
                newRow("ot_labor_inefficiency") = 0
                Select Case newRow("work_days")
                    Case 5
                        Select Case newRow("work_hours")
                            Case 10
                                newRow("ot_labor_inefficiency") = 5
                            Case 12
                                newRow("ot_labor_inefficiency") = 10
                            Case Else
                        End Select
                    Case 6
                        Select Case newRow("work_hours")
                            Case 8
                                newRow("ot_labor_inefficiency") = 10
                            Case 10
                                newRow("ot_labor_inefficiency") = 15
                            Case 12
                                newRow("ot_labor_inefficiency") = 20
                            Case Else
                        End Select
                    Case 7
                        Select Case newRow("work_hours")
                            Case 8
                                newRow("ot_labor_inefficiency") = 25
                            Case 10
                                newRow("ot_labor_inefficiency") = 30
                            Case 12
                                newRow("ot_labor_inefficiency") = 35
                            Case Else
                        End Select
                    Case Else
                End Select
            End If
        End If


    End Sub
    Public Function CalculateLaborRate()
        Dim LaborRate As Single = 0
        Dim OvertimePercent As Single = 0
        Dim LaborRatio As Single = 0

        If dtOverTime.Rows.Count > 0 Then
            OvertimePercent = dtOverTime(0).Item("ot_%")
        End If
        For i As Integer = 0 To dtLaborRates.Rows.Count - 1
            LaborRatio = dtLaborRates.Rows(i).Item("labor_ratio_" & CurrentGOData_Typ.Bank)
            If LaborRatio > 1 Then
                LaborRatio /= 100
            End If
            LaborRate += ((dtLaborRates.Rows(i).Item("st_rate") * (1 - OvertimePercent)) + (dtLaborRates.Rows(i).Item("ot_rate") * OvertimePercent)) *
                          LaborRatio
        Next i
        Return Math.Round(LaborRate, 2)

    End Function
End Module
