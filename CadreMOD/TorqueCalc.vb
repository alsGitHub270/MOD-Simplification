Option Strict Off
Option Explicit On
Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module TorqueCalc
    Public aMachineSheaveDiameter() As String = Nothing
    Public aRPM() As String = Nothing
    Public aBrakeType() As String = Nothing
    Public aHoistCableSize() As String = Nothing
    Public MaxNumberRopes As Integer = 11

    Public CableRecordSet As New ADODB.Recordset
    Public gbHideWireListLength As Boolean = False

    Private dZ2 As Double = 0, dY1 As Double = 0, dX1 As Double = 0, dZ1 As Double = 0, dZ3 As Double = 0
    Public dX, dWA, dDsDia As Double
    Dim b As Double
    Dim C As Double
    Dim Nc As Integer
    Dim Ni As Integer
    Public dRequired_AMPS As Double
    Public Const dConversionM2E As Double = 745.69987158227
    Public Const PI As Double = 3.141592653589
    Public Li1 As Double
    Public Li2 As Double
    Public dIdealCompWeight As Double
    Public IT1 As Double
    Public sDriveSelection As String = ""
    Public ES1MIN As Double
    Public E1 As Double
    Public E2 As Integer
    Public aE1() As Integer
    Public IAC1 As Double
    Public IAC2 As Double
    Public IAC3 As Double
    Public IAC4 As Double
    Public IAC5 As Double
    Public IAC6 As Double
    Public KWAC1 As Double
    Public KWAC2 As Double
    Public KWAC3 As Double
    Public KWAC4 As Double
    Public KWAC5 As Double
    Public KWAC6 As Double
    Public PF1 As Double
    Public PF2 As Double
    Public PF3 As Double
    Public PF4 As Double
    Public IDC1 As String = ""
    Public IDC2 As String = ""
    Public IDC3 As String = ""
    Public IDC4 As String = ""
    Public IDC5 As String = ""
    Public IDC6 As String = ""
    Public VFLU As String = ""
    Public DutyFactor As Double
    Public KT As Single
    Public VFF As String = String.Empty
    Public IFF As String = String.Empty
    Public VFan As String = String.Empty
    Public IFan As String = String.Empty

    Public sTransformerRequired As String = ""
    Public iWrapAngleLogic As Integer
    Public bOK As Boolean
    Public g_bErrors As Boolean
    Public iError(17) As Integer
    Public strError(17) As String
    Public Traction(10) As Double
    Public TractionComment(10) As String

    Public dMOTOR_EFFICIENCY_Running As Double
    Public dMOTOR_EFFICIENCY_Accelerating As Double
    Public dMOTOR_EFFICIENCY_Decelerating As Double
    Public dPOWER_FACTOR_Running As Double
    Public dPOWER_FACTOR_Accelerating As Double
    Public gTRFLU As Integer
    Public gTAFLU As Integer

    Public dIrflu As Double
    Public dIaflu As Double
    Public dPreg As Double

    Public dMotorInertia, dTotalInertia As Double
    Public iRoping As Integer
    Public dCWT, dCompWt As Double
    Public dRun_Amp, dAcc_Amp, dDec_Amp, dAcc_AmpU As Double
    Public dDec_AmpD, dRun_AmpU, dDec_AmpU, dAcc_AmpD, dRun_AmpD As Double

    Public dIdlerSH As Double
    Public dCwtSH As Double
    Public dRadius, dRadius1, dDSH, dRadius2, dMSH As Double
    Public dAlpha, dTCompWt, dUnbal, dLD, dShv As Double
    Public dLD1, dGAccel, dShh, dShvLoad, dGDecel, dLD2 As Double
    Public dMpta, dFriction, dLD3, dTCompWt1, dMpba, dMpbd As Double
    Public dHPower, dMMaxF, dMMaxD, dMptd, dMMaxA, dMMaxDTSD, dMMax, dRPM As Double
    Public dHPowerRounded As Double
    Public dFullHP, dFBottom, dRunTork, dUB, dFTop, dFullTork As Double
    Public dRWT, dCSH, dCSH1, dW1 As Double
    Public T1s, T2s As Double
    Public dSpeed, dTension, dGrooveP, dSafety, dS1 As Double
    Public dDecTork, dGD1, dATork, dMH, dGA, dAccTork, dSL As Double
    Public dFullLoadTorque As Double
    Public dDUM, dA3, dA1, dPeakTork, dA2, dA9, dDUMa As Double
    Public dMaxTraction, dT2, dT1, dCompSH, dTotalInertiaAtSheave As Double
    Public init_im, init_mh As Double
    Public init_AccTork, init_FullHp, init_Atork, init_FullTork, init_DecTork As Double
    Public dRise, dCapacity, dCarWeight, dCtrlCableWt, dXtraCCable As Double
    Public dRGE, dDecel125, dDecel, dGI, dMsDia, dGR, dAccel, dDecelTrac, dDecelTSD, dFGE As Double
    Public dXCompChain, dWrapA, dDSRad, dCounterWeight, dTAdder, dXRope As Double
    Public dInputSpeed, dHEff As Double
    Public sMachineType As String = ""

    Public dAddAccel, dPosition, dAddDecel As Double
    Public dAddAccAmpU, dAddRunTorkU, dAddAccTorkU, dAddDecTorkU, dAddRunAmpU, dAddDecAmpU As Double
    Public dAddAccAmpD, dAddRunTorkD, dAddAccTorkD, dAddDecTorkD, dAddRunAmpD, dAddDecAmpD As Double
    Public sAddCalcErr As String = ""
    Public dLHPos, dLLoad As Double
    Public bWrapAngleChange As Boolean
    Public bWrapAngleDependentChange As Boolean
    Public bMotorDependentChange As Boolean
    Public sFlatFilePath As String = ""
    Public sDebugPowerData As String = ""
    Public Structure DriveList_typ
        Dim DriveSelection As String
        Dim IRFLU As String
        Dim IAFLU As String
        Public Shared Function CreateInstance() As DriveList_typ
            Dim result As New DriveList_typ()
            result.DriveSelection = String.Empty
            result.IRFLU = String.Empty
            result.IAFLU = String.Empty
            Return result
        End Function
    End Structure
    Public DriveListByCost() As DriveList_typ = Nothing

    Public Structure RopeGripperCriteria_typ
        Dim OutToOutMax As Single
        Dim SpeedMax As Single
        Dim CapacityMax As Single
        Dim HangingLoadMax As Single
        Dim CapacityMin As Single
        Dim CarAndCwtWeightMin As Single
    End Structure
    Public RopeGripperCriteria() As RopeGripperCriteria_typ = Nothing
    Public Const HW620 As Integer = 0
    Public Const HW622 As Integer = 1
    Public Const HW624 As Integer = 2
    Public Const HW625 As Integer = 3
    Public Const HW626 As Integer = 4
    Public Const SB200 As Integer = 5
    Public Const SB330 As Integer = 6
    Public Const SB331 As Integer = 7
    Public Const SB380 As Integer = 8
    Public Const K3 As Single = 5.4

    Public Structure MN_TRQ01_typDec
        Dim JobNumber As String
        Dim JobName As String
        Dim Date_Renamed As String
        Dim EngName As String
        Dim EquipmentType As String
        Dim MachineType As String
        Dim Manufacturer As String
        Dim Speed As String
        Dim MotorRPM As Integer
        Dim DriveType As String
        Dim MachineRoomLocation As String
        Dim ShoeType As String
        Dim Capacity As String
        Dim CarWeightCalculated As String
        Dim Rise As String
        Dim BrakeType As String
        Dim Counterweight As String
        Dim Acceleration As String
        Dim Deceleration As String
        Dim DecelerationTraction As String
        Dim DecelerationTSD As String
        Dim DecelerationD125 As String
        Dim TractionAdder As String
        Dim HatchEfficiency As String
        Dim GearRation2 As String
        Dim GearRation1 As String
        Dim ForwardGearEfficiency As String
        Dim ReverseGearEfficiency As String
        Dim HiSpeedShaftInertia As String
        Dim MachineSheaveDia As String
        Dim MachineSheaveJ As String
        Dim DeflectorSheaveDiameter As String
        Dim DeflectorSheaveJ As String
        Dim MaxShaftSheaveLoad As String
        Dim ControlCableWeight As String
        Dim ExtarHoistRope As String
        Dim ExtarCompensationChain As String
        Dim ExtarControlCable As String
        Dim Roping As String
        Dim GrooveNumber As String
        Dim NumberOfRopes As String
        Dim RopeSize As String
        Dim RopeDrop As String
        Dim RopeWeight As String
        Dim RopeStrength As String
        Dim RopeGrade As String
        Dim MaxGroovePressure As String
        Dim Wrap As String
        Dim WrapAngle As String
        Dim RopeOffset As String
        Dim CarSheaveDiameter As String
        Dim CarSheaveJ As String
        Dim NumberofCarTopSheaves As String
        Dim CwtSheaveDiameter As String
        Dim CwtSheaveJ As String
        Dim SheaveDiameter As String
        Dim CompSheaveJ As String
        Dim CompSheaveWt As String
        Dim CompensationQty As String
        Dim HorizontalDistance As String
        Dim VerticalDistance As String
        Dim MainTravelingCable As String
        Dim MainTravelingCableQty As String
        Dim AdditionalCoaxCableQty As String
        Dim AdditionalShieldPairsQty As String
        Dim MainTravelingCableWeight As String
        Dim InputVoltage As String
        Dim BuildingVoltage As String
        Dim Performance As String
        Dim IdlerSheaveDiameter As String
        Dim NumberofIdlerSheaves As String
        Dim OverheadSheaveInertia As String
        Dim len1 As String
        Dim len2 As String
        Dim len3 As String
        Dim bDirty As Boolean
        Dim bPowerData As Boolean
        Dim bSuperTable As Boolean
        Dim DriveModelDefault As String
        Dim DriveModel As String
        Dim NominalMotorHPDefault As String
        Dim NominalMotorHP As String
        Dim SoftwareLevel As String
        Dim HoistRopeLength As Single
        Dim ActualStaticSpringLoadPerRope As Single
        Dim RopeGripperModel As String
        Dim Required_KVA As Double
        Dim Calculated_KVA As Double
        Dim HoistMotorCurrent As Single
        Dim STMQty As Integer
        Dim STMLength As Single
        Dim BlockingBeamLength As Integer
        Dim BlockingBeamLengthCar As Integer
        Dim BlockingBeamLengthCwt As Integer
        Dim BlockingBeamSize As String
        Dim PME As Single
        Dim INE As Single
        Dim INA As Single
        Dim PC1EG As Single
        Dim PC1AG As Single
        Dim INE_Calculated As Single
        Dim INA_Calculated As Single
        Dim PC1EG_Calculated As Single
        Dim PC1AG_Calculated As Single
        Dim MountingToOuterMBflanges As Byte
        Dim TME As Single
        Dim HoistMotorType As String
        Dim VariableMagneticDiscBrake As String
        Dim UN As Integer
        Dim NomimalMotorRpm As String
        Dim RopeSplayKitMounting As String
        Dim CarGovernorFastening As String
        Dim CwtGovernorFastening As String
        Dim QtyStarRepeater As Integer
        'Dim MachineHand() As MachineHand_typ
        Dim FZ1 As Single
        Dim FZ2 As Single
        Dim MachineVendorNew As String
        Dim MachineModelNew As String
        Dim FormIsCompleted As Boolean ' True/False
        Public Shared Function CreateInstance() As MN_TRQ01_typDec
            Dim result As New MN_TRQ01_typDec()
            result.JobNumber = String.Empty
            result.JobName = String.Empty
            result.Date_Renamed = String.Empty
            result.EngName = String.Empty
            result.EquipmentType = String.Empty
            result.MachineType = String.Empty
            result.Manufacturer = String.Empty
            result.Speed = String.Empty
            result.DriveType = String.Empty
            result.MachineRoomLocation = String.Empty
            result.ShoeType = String.Empty
            result.Capacity = String.Empty
            result.CarWeightCalculated = String.Empty
            result.Rise = String.Empty
            result.BrakeType = String.Empty
            result.Counterweight = String.Empty
            result.Acceleration = String.Empty
            result.Deceleration = String.Empty
            result.DecelerationTraction = String.Empty
            result.DecelerationTSD = String.Empty
            result.DecelerationD125 = String.Empty
            result.TractionAdder = String.Empty
            result.HatchEfficiency = String.Empty
            result.GearRation2 = String.Empty
            result.GearRation1 = String.Empty
            result.ForwardGearEfficiency = String.Empty
            result.ReverseGearEfficiency = String.Empty
            result.HiSpeedShaftInertia = String.Empty
            result.MachineSheaveDia = String.Empty
            result.MachineSheaveJ = String.Empty
            result.DeflectorSheaveDiameter = String.Empty
            result.DeflectorSheaveJ = String.Empty
            result.MaxShaftSheaveLoad = String.Empty
            result.ControlCableWeight = String.Empty
            result.ExtarHoistRope = String.Empty
            result.ExtarCompensationChain = String.Empty
            result.ExtarControlCable = String.Empty
            result.Roping = String.Empty
            result.GrooveNumber = String.Empty
            result.NumberOfRopes = String.Empty
            result.RopeSize = String.Empty
            result.RopeDrop = String.Empty
            result.RopeWeight = String.Empty
            result.RopeStrength = String.Empty
            result.RopeGrade = String.Empty
            result.MaxGroovePressure = String.Empty
            result.Wrap = String.Empty
            result.WrapAngle = String.Empty
            result.RopeOffset = String.Empty
            result.CarSheaveDiameter = String.Empty
            result.CarSheaveJ = String.Empty
            result.NumberofCarTopSheaves = String.Empty
            result.CwtSheaveDiameter = String.Empty
            result.CwtSheaveJ = String.Empty
            result.SheaveDiameter = String.Empty
            result.CompSheaveJ = String.Empty
            result.CompSheaveWt = String.Empty
            result.CompensationQty = String.Empty
            result.HorizontalDistance = String.Empty
            result.VerticalDistance = String.Empty
            result.MainTravelingCable = String.Empty
            result.MainTravelingCableQty = String.Empty
            result.AdditionalCoaxCableQty = String.Empty
            result.AdditionalShieldPairsQty = String.Empty
            result.MainTravelingCableWeight = String.Empty
            result.InputVoltage = String.Empty
            result.BuildingVoltage = String.Empty
            result.Performance = String.Empty
            result.IdlerSheaveDiameter = String.Empty
            result.NumberofIdlerSheaves = String.Empty
            result.OverheadSheaveInertia = String.Empty
            result.len1 = String.Empty
            result.len2 = String.Empty
            result.len3 = String.Empty
            result.DriveModelDefault = String.Empty
            result.DriveModel = String.Empty
            result.NominalMotorHPDefault = String.Empty
            result.NominalMotorHP = String.Empty
            result.SoftwareLevel = String.Empty
            result.RopeGripperModel = String.Empty
            result.BlockingBeamSize = String.Empty
            result.HoistMotorType = String.Empty
            result.VariableMagneticDiscBrake = String.Empty
            result.NomimalMotorRpm = String.Empty
            result.RopeSplayKitMounting = String.Empty
            result.CarGovernorFastening = String.Empty
            result.CwtGovernorFastening = String.Empty
            result.MachineVendorNew = String.Empty
            result.MachineModelNew = String.Empty
            Return result
        End Function
    End Structure
    Public MN_TRQ01_typ As MN_TRQ01_typDec = MN_TRQ01_typDec.CreateInstance()
    Public Structure MN_TRQ02_typDec
        Dim JobNumber As String
        Dim JobName As String
        Dim Date_Renamed As String
        Dim EngName As String
        Dim EquipmentType As String
        Dim MachineType As String
        Dim Manufacturer As String
        Dim Speed As String
        Dim MotorRPM As Integer
        Dim DriveType As String
        Dim MachineRoomLocation As String
        Dim ShoeType As String
        Dim Capacity As String
        Dim CarWeightCalculated As String
        Dim Rise As String
        Dim BrakeType As String
        Dim Counterweight As String
        Dim Acceleration As String
        Dim Deceleration As String
        Dim DecelerationTraction As String
        Dim DecelerationTSD As String
        Dim DecelerationD125 As String
        Dim TractionAdder As String
        Dim HatchEfficiency As String
        Dim GearRation2 As String
        Dim GearRation1 As String
        Dim ForwardGearEfficiency As String
        Dim ReverseGearEfficiency As String
        Dim HiSpeedShaftInertia As String
        Dim MachineSheaveDia As String
        Dim MachineSheaveJ As String
        Dim DeflectorSheaveDiameter As String
        Dim DeflectorSheaveJ As String
        Dim MaxShaftSheaveLoad As String
        Dim ControlCableWeight As String
        Dim ExtarHoistRope As String
        Dim ExtarCompensationChain As String
        Dim ExtarControlCable As String
        Dim Roping As String
        Dim GrooveNumber As String
        Dim NumberOfRopes As String
        Dim RopeSize As String
        Dim RopeDrop As String
        Dim RopeWeight As String
        Dim RopeStrength As String
        Dim RopeGrade As String
        Dim MaxGroovePressure As String
        Dim Wrap As String
        Dim WrapAngle As String
        Dim RopeOffset As String
        Dim CarSheaveDiameter As String
        Dim CarSheaveJ As String
        Dim NumberofCarTopSheaves As String
        Dim CwtSheaveDiameter As String
        Dim CwtSheaveJ As String
        Dim SheaveDiameter As String
        Dim CompSheaveJ As String
        Dim CompSheaveWt As String
        Dim CompensationWeight As String
        Dim CompensationUnitWeight As String
        Dim HorizontalDistance As String
        Dim VerticalDistance As String
        Dim MainTravelingCable As String
        Dim MainTravelingCableQty As String
        Dim AdditionalCoaxCableQty As String
        Dim AdditionalShieldPairsQty As String
        Dim MainTravelingCableWeight As String
        Dim InputVoltage As String
        Dim BuildingVoltage As String
        Dim Performance As String
        Dim IdlerSheaveDiameter As String
        Dim NumberofIdlerSheaves As String
        Dim OverheadSheaveInertia As String
        Dim len1 As String
        Dim len2 As String
        Dim len3 As String
        Dim bDirty As Boolean
        Dim bPowerData As Boolean
        Dim bSuperTable As Boolean
        Dim DriveModelDefault As String
        Dim DriveModel As String
        Dim NominalMotorHPDefault As String
        Dim NominalMotorHP As String
        Dim SoftwareLevel As String
        Dim HoistRopeLength As Single
        Dim ActualStaticSpringLoadPerRope As Single
        Dim RopeGripperModel As String
        Dim Required_KVA As Double
        Dim Calculated_KVA As Double
        Dim HoistMotorCurrent As Single
        Dim STMQty As Integer
        Dim STMLength As Single
        Dim BlockingBeamLength As Integer
        Dim BlockingBeamLengthCar As Integer
        Dim BlockingBeamLengthCwt As Integer
        Dim BlockingBeamSize As String
        Dim PME As Single
        Dim INE As Single
        Dim INA As Single
        Dim PC1EG As Single
        Dim PC1AG As Single
        Dim INE_Calculated As Single
        Dim INA_Calculated As Single
        Dim PC1EG_Calculated As Single
        Dim PC1AG_Calculated As Single
        Dim MountingToOuterMBflanges As Byte
        Dim TME As Single
        Dim HoistMotorType As String
        Dim VariableMagneticDiscBrake As String
        Dim UN As Integer
        Dim NomimalMotorRpm As String
        Dim RopeSplayKitMounting As String
        Dim CarGovernorFastening As String
        Dim CwtGovernorFastening As String
        Dim QtyStarRepeater As Integer
        'Dim MachineHand() As MachineHand_typ
        Dim FZ1 As Single
        Dim FZ2 As Single
        Dim MachineVendorNew As String
        Dim MachineModelNew As String
        Dim FormIsCompleted As Boolean ' True/False
        Dim CompensationSize As String
        Public Shared Function CreateInstance() As MN_TRQ02_typDec
            Dim result As New MN_TRQ02_typDec()
            result.JobNumber = String.Empty
            result.JobName = String.Empty
            result.Date_Renamed = String.Empty
            result.EngName = String.Empty
            result.EquipmentType = String.Empty
            result.MachineType = String.Empty
            result.Manufacturer = String.Empty
            result.Speed = String.Empty
            result.DriveType = String.Empty
            result.MachineRoomLocation = String.Empty
            result.ShoeType = String.Empty
            result.Capacity = String.Empty
            result.CarWeightCalculated = String.Empty
            result.Rise = String.Empty
            result.BrakeType = String.Empty
            result.Counterweight = String.Empty
            result.Acceleration = String.Empty
            result.Deceleration = String.Empty
            result.DecelerationTraction = String.Empty
            result.DecelerationTSD = String.Empty
            result.DecelerationD125 = String.Empty
            result.TractionAdder = String.Empty
            result.HatchEfficiency = String.Empty
            result.GearRation2 = String.Empty
            result.GearRation1 = String.Empty
            result.ForwardGearEfficiency = String.Empty
            result.ReverseGearEfficiency = String.Empty
            result.HiSpeedShaftInertia = String.Empty
            result.MachineSheaveDia = String.Empty
            result.MachineSheaveJ = String.Empty
            result.DeflectorSheaveDiameter = String.Empty
            result.DeflectorSheaveJ = String.Empty
            result.MaxShaftSheaveLoad = String.Empty
            result.ControlCableWeight = String.Empty
            result.ExtarHoistRope = String.Empty
            result.ExtarCompensationChain = String.Empty
            result.ExtarControlCable = String.Empty
            result.Roping = String.Empty
            result.GrooveNumber = String.Empty
            result.NumberOfRopes = String.Empty
            result.RopeSize = String.Empty
            result.RopeDrop = String.Empty
            result.RopeWeight = String.Empty
            result.RopeStrength = String.Empty
            result.RopeGrade = String.Empty
            result.MaxGroovePressure = String.Empty
            result.Wrap = String.Empty
            result.WrapAngle = String.Empty
            result.RopeOffset = String.Empty
            result.CarSheaveDiameter = String.Empty
            result.CarSheaveJ = String.Empty
            result.NumberofCarTopSheaves = String.Empty
            result.CwtSheaveDiameter = String.Empty
            result.CwtSheaveJ = String.Empty
            result.SheaveDiameter = String.Empty
            result.CompSheaveJ = String.Empty
            result.CompSheaveWt = String.Empty
            result.CompensationWeight = String.Empty
            result.HorizontalDistance = String.Empty
            result.VerticalDistance = String.Empty
            result.MainTravelingCable = String.Empty
            result.MainTravelingCableQty = String.Empty
            result.AdditionalCoaxCableQty = String.Empty
            result.AdditionalShieldPairsQty = String.Empty
            result.MainTravelingCableWeight = String.Empty
            result.InputVoltage = String.Empty
            result.BuildingVoltage = String.Empty
            result.Performance = String.Empty
            result.IdlerSheaveDiameter = String.Empty
            result.NumberofIdlerSheaves = String.Empty
            result.OverheadSheaveInertia = String.Empty
            result.len1 = String.Empty
            result.len2 = String.Empty
            result.len3 = String.Empty
            result.DriveModelDefault = String.Empty
            result.DriveModel = String.Empty
            result.NominalMotorHPDefault = String.Empty
            result.NominalMotorHP = String.Empty
            result.SoftwareLevel = String.Empty
            result.RopeGripperModel = String.Empty
            result.BlockingBeamSize = String.Empty
            result.HoistMotorType = String.Empty
            result.VariableMagneticDiscBrake = String.Empty
            result.NomimalMotorRpm = String.Empty
            result.RopeSplayKitMounting = String.Empty
            result.CarGovernorFastening = String.Empty
            result.CwtGovernorFastening = String.Empty
            result.MachineVendorNew = String.Empty
            result.MachineModelNew = String.Empty
            result.CompensationSize = String.Empty
            Return result
        End Function
    End Structure
    Public MN_TRQ02_typ As MN_TRQ02_typDec = MN_TRQ02_typDec.CreateInstance()

    Public Structure MN_PowerData_GEARED_typDec
        Dim PowerFromConverter_RFLU As String
        Dim CurrentIntoConverter_RFLU As String
        Dim ACCurrentIntoDrive_RFLU As String
        Dim LineCurrent_RFLU As String
        Dim LinePower_RFLU As String
        Dim PowerFromConverter_AFLU As String
        Dim CurrentIntoConverter_AFLU As String
        Dim ACCurrentIntoDrive_AFLU As String
        Dim LineCurrent_AFLU As String
        Dim LinePower_AFLU As String
        Dim PowerFromConverter_TSFLD As String
        Dim CurrentOutOfTheConverter_TSFLD As String
        Dim ACCurrentIntoBuilding_TSFLD As String
        Dim LineCurrent_TSFLD As String
        Dim LinePower_TSFLD As String
        Dim PowerFromConverter_TRFLU As String
        Dim CurrentOutOfTheConverter_TRFLU As String
        Dim ACCurrentIntoBuilding_TRFLU As String
        Dim LineCurrent_TRFLU As String
        Dim LinePower_TRFLU As String
        Dim PeakCurrent As String
        Dim HeatReleaseWithoutTransformer As String
        Dim HeatReleaseWithTransformer As String
        Dim HeatReleaseCabinet As String
        Dim HeatReleaseMotorAndMachine As String
        Dim HeatReleaseAutoTransformer As String
        Dim HeatReleaseWithoutTransformerSS As String
        Dim HeatReleaseWithTransformerSS As String
        Dim HeatReleaseCabinetSS As String
        Dim HeatReleaseMotorAndMachineSS As String
        Dim HeatReleaseAutoTransformerSS As String
        Dim IRFLU As String
        Dim IAFLU As String
        Dim Preg As String
        Public Shared Function CreateInstance() As MN_PowerData_GEARED_typDec
            Dim result As New MN_PowerData_GEARED_typDec()
            result.PowerFromConverter_RFLU = String.Empty
            result.CurrentIntoConverter_RFLU = String.Empty
            result.ACCurrentIntoDrive_RFLU = String.Empty
            result.LineCurrent_RFLU = String.Empty
            result.LinePower_RFLU = String.Empty
            result.PowerFromConverter_AFLU = String.Empty
            result.CurrentIntoConverter_AFLU = String.Empty
            result.ACCurrentIntoDrive_AFLU = String.Empty
            result.LineCurrent_AFLU = String.Empty
            result.LinePower_AFLU = String.Empty
            result.PowerFromConverter_TSFLD = String.Empty
            result.CurrentOutOfTheConverter_TSFLD = String.Empty
            result.ACCurrentIntoBuilding_TSFLD = String.Empty
            result.LineCurrent_TSFLD = String.Empty
            result.LinePower_TSFLD = String.Empty
            result.PowerFromConverter_TRFLU = String.Empty
            result.CurrentOutOfTheConverter_TRFLU = String.Empty
            result.ACCurrentIntoBuilding_TRFLU = String.Empty
            result.LineCurrent_TRFLU = String.Empty
            result.LinePower_TRFLU = String.Empty
            result.PeakCurrent = String.Empty
            result.HeatReleaseWithoutTransformer = String.Empty
            result.HeatReleaseWithTransformer = String.Empty
            result.HeatReleaseCabinet = String.Empty
            result.HeatReleaseMotorAndMachine = String.Empty
            result.HeatReleaseAutoTransformer = String.Empty
            result.HeatReleaseWithoutTransformerSS = String.Empty
            result.HeatReleaseWithTransformerSS = String.Empty
            result.HeatReleaseCabinetSS = String.Empty
            result.HeatReleaseMotorAndMachineSS = String.Empty
            result.HeatReleaseAutoTransformerSS = String.Empty
            result.IRFLU = String.Empty
            result.IAFLU = String.Empty
            result.Preg = String.Empty
            Return result
        End Function
    End Structure
    Public MN_PowerData_GEARED_typ As MN_PowerData_GEARED_typDec = MN_PowerData_GEARED_typDec.CreateInstance()

    Public Structure MN_PowerData_GEARLESS_typDec
        Dim ACLineCurrent_RFLU As String
        Dim GeneratedACPower_RFLU As String
        Dim ACLineCurrent_AFLU As String
        Dim GeneratedACPower_AFLU As String
        Dim RegenerativeACLineCurrent_RFLD As String
        Dim RegenerativeACPower_RFLD As String
        Dim RegenerativeACLineCurrent_R125FLD As String
        Dim RegenerativeACPower_R125FLD As String
        Dim RegenerativeACLineCurrent_DFLD As String
        Dim RegenerativeACPower_DFLD As String
        Dim RegenerativeACLineCurrent_D125FLD As String
        Dim RegenerativeACPower_D125FLD As String
        Dim HeatReleaseWithoutTransformer As String
        Dim HeatReleaseWithTransformer As String
        Dim HeatReleaseCabinet As String
        Dim HeatReleaseMotorAndMachine As String
        Dim HeatReleaseAutoTransformer As String
        Dim HeatReleaseChoke As String
        Dim HeatReleaseWithoutTransformerSS As String
        Dim HeatReleaseWithTransformerSS As String
        Dim HeatReleaseCabinetSS As String
        Dim HeatReleaseMotorAndMachineSS As String
        Dim HeatReleaseAutoTransformerSS As String
        Dim HeatReleaseChokeSS As String
        Dim PeakInrushCurrent As String
        Public Shared Function CreateInstance() As MN_PowerData_GEARLESS_typDec
            Dim result As New MN_PowerData_GEARLESS_typDec()
            result.ACLineCurrent_RFLU = String.Empty
            result.GeneratedACPower_RFLU = String.Empty
            result.ACLineCurrent_AFLU = String.Empty
            result.GeneratedACPower_AFLU = String.Empty
            result.RegenerativeACLineCurrent_RFLD = String.Empty
            result.RegenerativeACPower_RFLD = String.Empty
            result.RegenerativeACLineCurrent_R125FLD = String.Empty
            result.RegenerativeACPower_R125FLD = String.Empty
            result.RegenerativeACLineCurrent_DFLD = String.Empty
            result.RegenerativeACPower_DFLD = String.Empty
            result.RegenerativeACLineCurrent_D125FLD = String.Empty
            result.RegenerativeACPower_D125FLD = String.Empty
            result.HeatReleaseWithoutTransformer = String.Empty
            result.HeatReleaseWithTransformer = String.Empty
            result.HeatReleaseCabinet = String.Empty
            result.HeatReleaseMotorAndMachine = String.Empty
            result.HeatReleaseAutoTransformer = String.Empty
            result.HeatReleaseChoke = String.Empty
            result.HeatReleaseWithoutTransformerSS = String.Empty
            result.HeatReleaseWithTransformerSS = String.Empty
            result.HeatReleaseCabinetSS = String.Empty
            result.HeatReleaseMotorAndMachineSS = String.Empty
            result.HeatReleaseAutoTransformerSS = String.Empty
            result.HeatReleaseChokeSS = String.Empty
            result.PeakInrushCurrent = String.Empty
            Return result
        End Function
    End Structure
    Public MN_PowerData_GEARLESS_typ As MN_PowerData_GEARLESS_typDec = MN_PowerData_GEARLESS_typDec.CreateInstance()
    Public CriticalErrorCounter As Byte
    Private MachineType As String = String.Empty
    Private ControllerType As String = String.Empty
    Private RopingNew As String = String.Empty
    Private Wrap As String = String.Empty
    Private PowerSupply As Integer = 0
    Private Speed As Integer = 0
    Private Capacity As Integer = 0
    Private Travel As Single = 0
    Private TopOfCarSheave As String = String.Empty
    Private CarSheaveQty As Integer = 0
    Private MachineLocation As String = String.Empty
    Private HoistRopeSize As String = String.Empty
    Private HoistRopeQty As String = String.Empty
    Private NominalMotorRPM As String = String.Empty
    Private MachineVendor As String = String.Empty
    Private MachineModel As String = String.Empty
    Private CarToCwtRopeDrop As String = String.Empty
    Private MachineVendorExisting As String = String.Empty
    Private MachineModelExisting As String = String.Empty
    Private BrakeType As String = String.Empty
    Private MachineSheaveDiameter As String = String.Empty
    Private HoistwaySheave As String = String.Empty
    Private ControllerVendor As String = String.Empty
    Private Compensation As String = String.Empty
    Private CompensationType As String = String.Empty
    Private CompSheave As String = String.Empty
    Private Mounting As String = String.Empty

    Public cCarTopSheave As Collection
    Public cCwtTopSheave As Collection
    Public cIdlerSheave As Collection
    Private cRopeCompensation As Collection

    Public Structure MachineSheaveDiameter_typ
        Dim GearRatio2 As String
        Dim GearRatio1 As String
        Dim ForwardGearEfficiency As String
        Dim ReverseGearEfficiency As String
        Dim MachineSheaveDia As String
        Dim MachineSheaveJ As String
        Dim HiSpeedShaftInertia As String
        Dim MaxShaftSheaveLoad As String
        Public Shared Function CreateInstance() As MachineSheaveDiameter_typ
            Dim result As New MachineSheaveDiameter_typ()
            result.GearRatio2 = String.Empty
            result.GearRatio1 = String.Empty
            result.ForwardGearEfficiency = String.Empty
            result.ReverseGearEfficiency = String.Empty
            result.MachineSheaveDia = String.Empty
            result.MachineSheaveJ = String.Empty
            result.HiSpeedShaftInertia = String.Empty
            result.MaxShaftSheaveLoad = String.Empty
            Return result
        End Function
    End Structure
    Public aMachineData() As MachineSheaveDiameter_typ = Nothing
    Public DeflectorSheaveJdefault As String = ""
    Public IdlerSheaveJdefault As String = ""
    Public CarTopSheaveJdefault As String = ""
    Public CwtTopSheaveJdefault As String = ""
    Public CompSheaveJdefault As String = ""
    Public CompSheaveWtdefault As String = ""
    Public bSkipFields2Type As Boolean
    Public bSkipWrapWarning As Boolean
    Public bTorqueCriticalError As Boolean
    Public sDebugInfo As String = ""

    Public Const INVERTER_EFFICIENCY As Double = 0.95
    Public Const TORQUE_DEBUG_DETAIL_FILE_NAME As String = "MO_TORQUE.TXT"

    Public Sub CalculateTORQUE()
        Dim sSQL As String = ""
        Dim iIndex As Integer

        If MachineType = GEARLESS_TYPE And ControllerType <> DRIVETYPE_SCRDC And ControllerType <> DRIVETYPE_QUATTRO Then
            Exit Sub
        End If
        ReDim DriveListByCost(0)
        If MachineType = GEARED_TYPE Then
            iIndex = 1
            sSQL = "SELECT * FROM [Drive Selection] WHERE [Drive Selection].ANSI="
            If Conversion.Val(CurrentGOData_Typ.ANSICode) >= 2000 Then
                sSQL &= "True"
            Else
                sSQL &= "False"
            End If
            sSQL &= " ORDER BY Sequence"
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            TorqueRecordset.MoveFirst()
            Do Until TorqueRecordset.EOF
                ReDim Preserve DriveListByCost(iIndex)
                DriveListByCost(iIndex).DriveSelection = TorqueRecordset("Drive Selection").Value.ToString
                DriveListByCost(iIndex).IRFLU = TorqueRecordset("IRFLU").Value.ToString
                DriveListByCost(iIndex).IAFLU = TorqueRecordset("IAFLU").Value.ToString
                iIndex += 1
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
        End If
        Set_RopeStrength()
        bOK = False
        ClearErrors()
        VFLU = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "ArmatureFullLoadVoltageVFLU_txt"))
        VFF = GetDefaultValue_VFLU_IDC1_VFF_IFF("VFF")
        IFF = GetDefaultValue_VFLU_IDC1_VFF_IFF("IFF")
        VFan = String.Empty
        IFan = String.Empty

        dW1 = Conversion.Val(CStr(0) & MN_TRQ01_typ.CompSheaveWt)
        dS1 = 0
        If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
            dCompSH = 0
        Else
            dCompSH = Conversion.Val(CStr(0) & MN_TRQ01_typ.CompSheaveJ) / (CDbl(CStr(0) & MN_TRQ01_typ.SheaveDiameter) / 24) ^ 2
        End If
        If Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) = 0 Then
            dIdlerSH = 0
        Else
            dIdlerSH = Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia) / (Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) / 24) ^ 2
        End If
        InitializeCalcVariables()
        If Conversion.Val(MN_TRQ02_typ.CompensationWeight) = 0 Then
            If (Compensation = "Reuse" Or Compensation = "Relocate") And MN_TRQ02_typ.CompensationSize = "Unknown" Then
                If RopingNew = "1:1" Then
                    iRoping = 1
                Else
                    iRoping = 2
                End If
                dRWT = Conversion.Val(HoistRopeQty) * Conversion.Val(MN_TRQ01_typ.RopeWeight)
                dIdealCompWeight = iRoping * dRWT - dCtrlCableWt / 4
                dCompWt = dIdealCompWeight / 2
            Else
                dCompWt = Conversion.Val(MN_TRQ01_typ.CompensationQty) * Conversion.Val(MN_TRQ02_typ.CompensationUnitWeight)
            End If
        Else
            dCompWt = Conversion.Val(MN_TRQ02_typ.CompensationWeight)
        End If
        dCWT = dCarWeight + (dCounterWeight / 100) * dCapacity + dCtrlCableWt * (dRise + dXtraCCable) / 4
        If RopingNew = "1:1" Or TopOfCarSheave = "None" Then
            iRoping = 1
            dCSH = 0
            dCSH1 = 0
            dCwtSH = 0
        Else
            iRoping = 2
            dRadius2 = Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter) / 24
            If Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter) = 0 Then
                dCSH = 0
            Else
                dCSH = (Conversion.Val(CStr(0) & MN_TRQ01_typ.CarSheaveJ)) / (dRadius2 ^ 2)
            End If
            dCSH1 = dCSH
            If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
                dCwtSH = 0
            Else
                dCwtSH = Conversion.Val(MN_TRQ01_typ.CwtSheaveJ) / Conversion.Val((MN_TRQ01_typ.CwtSheaveDiameter) / 24) ^ 2
            End If
        End If
        'deflector sheave
        dRadius1 = dDSRad / 12
        If dRadius1 = 0 Then
            dDSH = 0
        Else
            dDSH = Conversion.Val(MN_TRQ01_typ.DeflectorSheaveJ) / (dRadius1 ^ 2)
        End If
        'machine sheave
        dRadius = dMsDia / 24
        If dRadius = 0 Then
            dMSH = 0
        Else
            dMSH = (Conversion.Val(CStr(0) & MN_TRQ01_typ.MachineSheaveJ) * 32.174) / (dRadius ^ 2)
        End If
        'rope data
        dRWT = Conversion.Val(HoistRopeQty) * Conversion.Val(MN_TRQ01_typ.RopeWeight)
        Calculate_T1s_T2s()
        RopeTensionCalc()
        SafetyCalc()
        dUnbal = dRise * (dRWT - (dCompWt + dCtrlCableWt / 4) / iRoping) 'Cable unbalance calculation
        SheaveLoadCalcNew() 'SheaveLoadCalc
        MachinePullData()
        MotorData()
        If MN_TRQ01_typ.bPowerData Then
            dIdealCompWeight = iRoping * dRWT - dCtrlCableWt / 4
            If MachineType = GEARED_TYPE Then
                If Conversion.Val(MN_TRQ01_typ.NominalMotorHP) = 0 Or bMotorDependentChange Then
                    MotorInertiasNew(False)
                Else
                    dMH = Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
                    MN_TRQ01_typ.MotorRPM = Conversion.Val(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
                    sSQL = "SELECT * FROM [HP RPM MotorJ] "
                    sSQL = sSQL & "WHERE rpm=" & CStr(MN_TRQ01_typ.MotorRPM)
                    sSQL = sSQL & "AND HP=" & CStr(dMH)
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        gTRFLU = TorqueRecordset("TRFLU").Value
                        gTAFLU = TorqueRecordset("TAFLU").Value
                        dMotorInertia = TorqueRecordset("Motor Inertia").Value
                        dATork = gTAFLU
                        Acc_Dec_Tork(dMotorInertia)
                    End If
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                End If
            Else
                Acc_Dec_Tork(0)
            End If
            CalcTorqueProperties()
        End If

    End Sub
    Private Sub CalcTorqueProperties()
        Dim NoErrors As Boolean

        CheckPeakTork()
        TractionRatioNew()
        MaxTraction()
        If dGR = 0 Or dFGE = 0 Then
            dTotalInertia = 0
        Else
            dTotalInertia = ((((Li1 + dW1) / (iRoping ^ 2) + Li2) / 32.174) * (dRadius ^ 2)) / ((dGR ^ 2) * dFGE) + (dMotorInertia + dGI)
        End If
        'note: the above is the inertia at the high speed shaft, to get the system inertia at the sheave you multiply by gr^2
        dTotalInertiaAtSheave = dTotalInertia * (dGR ^ 2)
        dAddAccel = Conversion.Val(CStr(0) & MN_TRQ01_typ.Acceleration)
        dAddDecel = Conversion.Val(CStr(0) & MN_TRQ01_typ.Deceleration)
        CalcAddGrdTork()
        CalcAddCurrents()
        Select Case MachineType
            Case GEARED_TYPE
                If MN_TRQ01_typ.DriveModel = "" Or bMotorDependentChange Then
                    For iIndex As Integer = 1 To DriveListByCost.GetUpperBound(0)
                        If DriveListByCost(iIndex).DriveSelection <> "VF85BR" And
                           ((ControllerType = DRIVETYPE_BR And Strings.Right(DriveListByCost(iIndex).DriveSelection, 2) = "BR") Or
                           (ControllerType = DRIVETYPE_PF1 And Strings.Right(DriveListByCost(iIndex).DriveSelection, 3) = "PF1")) Then
                            MN_TRQ01_typ.DriveModel = DriveListByCost(iIndex).DriveSelection
                            MN_TRQ01_typ.DriveModelDefault = ""
                            MN_PowerData_GEARED_typ.IRFLU = ""
                            MN_PowerData_GEARED_typ.IAFLU = ""
                            MN_PowerData_GEARED_typ.Preg = ""
                            NoErrors = True
                            Select Case ControllerType
                                Case DRIVETYPE_BR
                                    If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
                                        CalcPowerData_GEARED_NON_REGEN()
                                    End If
                                Case DRIVETYPE_PF1
                                    If Strings.Right(MN_TRQ01_typ.DriveModel, 3) = "PF1" Then
                                        CalcPowerData_GEARED_REGEN()
                                    End If
                                Case DRIVETYPE_BESTPRICE
                                    If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
                                        CalcPowerData_GEARED_NON_REGEN()
                                    Else
                                        CalcPowerData_GEARED_REGEN()
                                    End If
                            End Select
                            If MN_PowerData_GEARED_typ.IRFLU = "" Or MN_PowerData_GEARED_typ.IAFLU = "" Or MN_PowerData_GEARED_typ.Preg = "" Then
                                NoErrors = False
                            ElseIf dIrflu > Conversion.Val(DriveListByCost(iIndex).IRFLU) Then
                                NoErrors = False
                            ElseIf dIaflu > Conversion.Val(DriveListByCost(iIndex).IAFLU) Then
                                NoErrors = False
                            End If
                            If NoErrors Then
                                Exit Sub
                            End If
                        End If
                    Next iIndex
                    If ENG_ACCESS Then
                        For iIndex As Integer = DriveListByCost.GetUpperBound(0) To 1 Step -1
                            Select Case ControllerType
                                Case DRIVETYPE_BR
                                    If Strings.Right(DriveListByCost(iIndex).DriveSelection, 2) = "BR" And DriveListByCost(iIndex).DriveSelection <> "VF85BR" Then
                                        MN_TRQ01_typ.DriveModel = DriveListByCost(iIndex).DriveSelection
                                        Exit For
                                    End If
                                Case DRIVETYPE_PF1
                                    If Strings.Right(DriveListByCost(iIndex).DriveSelection, 2) = "PF1" Then
                                        MN_TRQ01_typ.DriveModel = DriveListByCost(iIndex).DriveSelection
                                        Exit For
                                    End If
                                Case DRIVETYPE_BESTPRICE
                                    MN_TRQ01_typ.DriveModel = DriveListByCost(DriveListByCost.GetUpperBound(0)).DriveSelection
                                    Exit For
                            End Select
                        Next
                    Else
                        MN_TRQ01_typ.DriveModel = ""
                        MN_TRQ01_typ.DriveModelDefault = ""
                    End If
                ElseIf Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
                    CalcPowerData_GEARED_NON_REGEN()
                Else
                    CalcPowerData_GEARED_REGEN()
                End If
            Case GEARLESS_TYPE
                CalcPowerData_GEARLESS()
        End Select

    End Sub
    Public Sub ClearErrors()

        For i As Integer = 0 To iError.GetUpperBound(0)
            iError(i) = 0
            strError(i) = ""
        Next
        g_bErrors = False

    End Sub
    Private Sub InitializeCalcVariables()

        dCarWeight = Conversion.Val(CStr(0) & MN_TRQ01_typ.CarWeightCalculated)
        dCapacity = Conversion.Val(CStr(0) & CStr(Capacity))
        dCtrlCableWt = Conversion.Val(("" & MN_TRQ01_typ.ControlCableWeight).Trim())
        dRise = Math.Round(Conversion.Val(Conversion.Val(Travel)), 2)
        dXtraCCable = Conversion.Val(CStr(0) & MN_TRQ01_typ.len3)
        dMsDia = Conversion.Val(CStr(0) & MachineSheaveDiameter)
        dGR = Conversion.Val(CStr(0) & MN_TRQ01_typ.GearRation1)
        If Conversion.Val(MN_TRQ01_typ.Acceleration) = 0 Or Conversion.Val(MN_TRQ01_typ.Deceleration) = 0 Or
           Conversion.Val(MN_TRQ01_typ.DecelerationTraction) = 0 Or Conversion.Val(MN_TRQ01_typ.DecelerationD125) = 0 Or
           Conversion.Val(MN_TRQ01_typ.DecelerationTSD) = 0 Or Conversion.Val(MN_TRQ01_typ.TractionAdder) = 0 Then
            Calc_GeneralData()
        End If
        dAccel = Conversion.Val(CStr(0) & MN_TRQ01_typ.Acceleration)
        dDecel = Conversion.Val(CStr(0) & MN_TRQ01_typ.Deceleration)
        dDecelTrac = Conversion.Val(CStr(0) & MN_TRQ01_typ.DecelerationTraction)
        dDecel125 = Conversion.Val(CStr(0) & MN_TRQ01_typ.DecelerationD125)
        dDecelTSD = Conversion.Val(CStr(0) & MN_TRQ01_typ.DecelerationTSD)
        dRGE = Conversion.Val(CStr(0) & MN_TRQ01_typ.ReverseGearEfficiency)
        dFGE = Conversion.Val(CStr(0) & MN_TRQ01_typ.ForwardGearEfficiency)
        dGI = Conversion.Val(CStr(0) & MN_TRQ01_typ.HiSpeedShaftInertia)
        dDSRad = HoistwaySheaveDiameter() / 2
        dCounterWeight = Conversion.Val(CStr(0) & MN_TRQ01_typ.Counterweight)
        dWrapA = Conversion.Val(CStr(0) & MN_TRQ01_typ.WrapAngle)
        dTAdder = Conversion.Val(CStr(0) & MN_TRQ01_typ.TractionAdder)
        dXCompChain = Conversion.Val(CStr(0) & MN_TRQ01_typ.len2)
        dXRope = Conversion.Val(CStr(0) & MN_TRQ01_typ.len1)
        dInputSpeed = Conversion.Val(CStr(0) & CStr(Speed))
        If MN_TRQ01_typ.HatchEfficiency = "" Or MN_TRQ01_typ.bDirty Then InitHatchEff()
        dHEff = Conversion.Val(CStr(0) & MN_TRQ01_typ.HatchEfficiency)
        sMachineType = MachineModel
        dMH = Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
        dMotorInertia = 0
        dATork = 0
        If Conversion.Val("" & MN_TRQ01_typ.NumberofCarTopSheaves) = 0 Then
            Nc = 0
        Else
            Nc = Conversion.Val(MN_TRQ01_typ.NumberofCarTopSheaves)
        End If
        If Conversion.Val(CStr(0) & MN_TRQ01_typ.NumberofIdlerSheaves) = 0 Then
            Ni = 0
        Else
            Ni = Conversion.Val(MN_TRQ01_typ.NumberofIdlerSheaves)
        End If

    End Sub
    Private Sub RopeTensionCalc()

        Try
            If Conversion.Val(HoistRopeQty) = 0 Then
                dTension = 1
            Else
                dTension = T1s / (iRoping * Conversion.Val(HoistRopeQty)) 'dTension = dGrooveP * dMsDia / 2
            End If
            dGrooveP = dTension / (dRadius * 12)

        Catch

        End Try

    End Sub
    Private Sub SafetyCalc()
        Dim bFound As Boolean = False

        'safety calculations
        dSafety = Conversion.Val(CStr(0) & MN_TRQ01_typ.RopeStrength) / dTension
        dSpeed = dInputSpeed * iRoping
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open("SafetyFactors", ADOConnection)
        Do While Not TorqueRecordset.EOF
            If TorqueRecordset("RopeSpeed").Value = dSpeed Then
                bFound = True
                If TorqueRecordset("PassengerSF").Value > dSafety Then
                    iError(1) = 1
                    g_bErrors = True
                    strError(1) = "Safety Factor " & Strings.FormatNumber(TorqueRecordset("PassengerSF").Value, 3, TriState.True) &
                                  " is greater than the calculated safety of " & Strings.FormatNumber(dSafety, 3, TriState.True) & "."
                End If
            End If
            If dSpeed > 1500 Then
                If dSafety < 11.9 Then
                    iError(1) = 1
                    g_bErrors = True
                    strError(1) = "Safety Factor of 11.9 is greater than the calculated safety of " & Strings.FormatNumber(dSafety, 3, TriState.True) & "."
                End If
            End If
            If iError(1) = 1 And bFound Then Exit Do
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        If Not bFound Then
            iError(2) = 1
            g_bErrors = True
            strError(2) = "No combination of rope speed and safety factor was found. Calculated safety was " & Strings.FormatNumber(dSafety, 3, TriState.True) & "."
        End If

    End Sub
    Private Sub MachinePullData()
        'machine pull calculations  : the comments that follow are from the pascal program
        'question: why is the machine pull so much higher than the value in grd02. Subsequently, why is the peak acc. tork between 2.5 and 3.5 times
        '          higher than the full load tork in 2:1 roping
        'answer: machine pull calculations were verified on 9/28/88 against the older grd02 equations. The discrepancy was found in the handling of
        '        roping factor. The torked equations were not correct. The entire inertial load due to the car, load, cwt, etc. was getting
        '        multiplied by acceleration, a and that created the higher machine pulls and peak torks.


        dGAccel = dAccel / 32.174
        dGDecel = dDecel / 32.174
        dLD1 = dCarWeight + dCapacity - dCWT
        dLD2 = dCarWeight + dCapacity + dCWT
        Li1 = dCarWeight + dCapacity + dCWT + (dRise + dXCompChain) * dCompWt + dCtrlCableWt * (dRise + dXtraCCable) / 2 + dCompSH * 32.174
        Dim iBasement As Integer = 1
        If MachineLocation = "Basement" Then iBasement = 3
        Li2 = (dRWT * (iBasement * dRise + dXRope / 2) + dMSH + dDSH * 32.174 + Ni * dIdlerSH * 32.174 + Nc * dCSH * 32.174 + dCwtSH * 32.174) * iRoping
        'dTCompWt1 = dCompWt * (dRise + dXCompChain) + dCtrlCableWt * (dRise + dXtraCCable) / 2
        'dLD3 = (dRWT * (dRise + dXRope) + dMSH + dDSH + dCSH + dCSH1) * iRoping
        ' S1 was the compshv eq. weight in the grd02 program and since for geared jobs you never use a rope comp that would require a comp sheave,
        ' the value of s1 was just left in the equations and set to 0 at the beginning. So you can ignore any reference to S1 in the geared
        ' calculations
        dFriction = dCapacity * (1 - dCounterWeight / 100) * (1 - dHEff)
        'machine pull bottom accelerating up
        dMpba = (dLD1 + dRise * (dRWT * iRoping - dCompWt)) / iRoping + dGAccel * ((Li1 / iRoping) + Li2) + dFriction / iRoping
        Dim F1 As Double = dMpba
        'machine pull top accelerating up
        dMpta = (dLD1 + dRise * (dCompWt + dCtrlCableWt / 4 - dRWT * iRoping)) / iRoping + dGAccel * ((Li1 / iRoping) + Li2) + dFriction / iRoping
        Dim F2 As Double = dMpta
        'max machine pull accelerating
        If dMpta > dMpba Then
            dMMaxA = dMpta
        Else
            dMMaxA = dMpba
        End If
        'machine pull bottom deccelerating down
        dMpbd = (dLD1 + dRise * (dRWT * iRoping - dCompWt)) / iRoping + dGDecel * ((Li1 / iRoping) + Li2) - dFriction / iRoping
        Dim F3 As Double = dMpbd
        'machine pull top deccelerating down
        dMptd = (dLD1 + dRise * (dCompWt + dCtrlCableWt / 4 - dRWT * iRoping)) / iRoping + dGDecel * ((Li1 / iRoping) + Li2) - dFriction / iRoping
        Dim F4 As Double = dMptd
        'Full Speed Up/Down
        Dim F5 As Double = (dLD1 + dRise * (dRWT * iRoping - dCompWt)) / iRoping + dFriction / iRoping
        Dim F6 As Double = (dLD1 + dRise * (dCompWt + dCtrlCableWt / 4 - dRWT * iRoping)) / iRoping + dFriction / iRoping
        If F5 > F6 Then
            dMMaxF = F5
        Else
            dMMaxF = F6
        End If
        'max machine pull deccelerating
        If dMptd > dMpbd Then
            dMMaxD = dMptd
        Else
            dMMaxD = dMpbd
        End If
        dGDecel = dDecel * 1.15 / 32.174
        dMpbd = (dLD1 + dRise * (dRWT * iRoping - dCompWt)) / iRoping + dGDecel * ((Li1 / iRoping) + Li2) - dFriction / iRoping
        dMptd = (dLD1 + dRise * (dCompWt + dCtrlCableWt / 4 - dRWT * iRoping)) / iRoping + dGDecel * ((Li1 / iRoping) + Li2) - dFriction / iRoping
        If dMptd > dMpbd Then
            dMMaxDTSD = dMptd
        Else
            dMMaxDTSD = dMpbd
        End If
        If dMMaxA > dMMaxD Then
            dMMax = dMMaxA
        Else
            dMMax = dMMaxD
        End If

    End Sub
    Private Sub MotorData()

        MN_TRQ01_typ.bPowerData = True
        If MachineType = GEARED_TYPE Then
            If Conversion.Val(MN_TRQ01_typ.GearRation1) <> 0 And Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency) <> 0 Then
                dFullTork = (dMMaxF * dRadius) / (Conversion.Val(MN_TRQ01_typ.GearRation1) * Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency))
            Else
                dFullTork = -1
                MN_TRQ01_typ.bPowerData = False
            End If
            'rpm calc : 3.8197 = 12/pi motor speed
            If Conversion.Val(CStr(dMsDia)) <> 0 Then
                dRPM = dInputSpeed * dGR * iRoping * (12 / PI) / dMsDia
            Else
                dRPM = -1
                MN_TRQ01_typ.bPowerData = False
            End If
        Else
            dFullTork = (dMMaxF * dRadius)
            'rpm calc : 3.82 = 12/pi motor speed
            If Conversion.Val(CStr(dMsDia)) <> 0 Then
                dRPM = dInputSpeed * iRoping * (12 / PI) / dMsDia
            Else
                dRPM = -1
                MN_TRQ01_typ.bPowerData = False
            End If
        End If
        dFullHP = dRPM * dFullTork / 5252.11305
        dHPowerRounded = 0
        If MachineType = GEARED_TYPE Then
            'running motor horsepower
            If Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency) <> 0 And Conversion.Val(CStr(dHEff)) <> 0 Then
                dHPower = (dCapacity * (1 - (dCounterWeight / 100)) * dInputSpeed) / (33000 * Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency) * dHEff)
            Else
                dHPower = -1
                MN_TRQ01_typ.bPowerData = False
            End If
            ValidatedFullHP()
        Else
            'running motor horsepower
            If dHEff <> 0 Then
                dHPower = (dCapacity * (1 - (dCounterWeight / 100)) * dInputSpeed) / (33000 * 0.98 * dHEff)
            Else
                dHPower = -1
                MN_TRQ01_typ.bPowerData = False
            End If
        End If
        'running tork
        If dRPM <> 0 Then
            dRunTork = dHPower * 5252.11305 / dRPM
        Else
            dRPM = -1
            MN_TRQ01_typ.bPowerData = False
        End If

    End Sub
    Private Sub MotorInertiasNew(ByRef bJustDefault As Boolean)
        Dim maxHP As Integer
        Dim sSQL As String = ""

        MN_TRQ01_typ.MotorRPM = Conversion.Val(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
        strError(12) = ""
        Select Case MN_TRQ01_typ.MotorRPM
            Case 850
                If ValidateHP(15, 90, 238, 0.129) = 15 Then
                    dMotorInertia = 0.129
                    dMH = 15
                    dATork = 238
                ElseIf ValidateHP(20, 120, 317, 0.2664) = 20 Then
                    dMotorInertia = 0.2664
                    dMH = 20
                    dATork = 317
                ElseIf ValidateHP(25, 150, 385, 0.375) = 25 Then
                    dMotorInertia = 0.375
                    dMH = 25
                    dATork = 385
                ElseIf ValidateHP(35, 210, 520, 0.606) = 35 Then
                    dMotorInertia = 0.606
                    dMH = 35
                    dATork = 520
                ElseIf ValidateHP(50, 300, 725, 0.727, True) = 50 Then
                    dMotorInertia = 0.727
                    dMH = 50
                    dATork = 725
                Else
                    iError(11) = 1
                    g_bErrors = True
                    maxHP = 50
                End If
            Case 1150
                If ValidateHP(15, 67, 177, 0.0982) = 15 Then
                    dMotorInertia = 0.0982
                    dMH = 15
                    dATork = 177
                ElseIf ValidateHP(20, 89, 236, 0.1228) = 20 Then
                    dMotorInertia = 0.1228
                    dMH = 20
                    dATork = 236
                ElseIf ValidateHP(25, 114, 277, 0.278) = 25 Then
                    dMotorInertia = 0.278
                    dMH = 25
                    dATork = 277
                ElseIf ValidateHP(30, 134, 342, 0.323) = 30 Then
                    dMotorInertia = 0.323
                    dMH = 30
                    dATork = 342
                ElseIf ValidateHP(35, 156, 384, 0.359) = 35 Then
                    dMotorInertia = 0.359
                    dMH = 35
                    dATork = 384
                ElseIf ValidateHP(50, 227, 488, 0.624) = 50 Then
                    dMotorInertia = 0.624
                    dMH = 50
                    dATork = 488
                ElseIf ValidateHP(60, 272, 586, 0.624) = 60 Then
                    dMotorInertia = 0.624
                    dMH = 60
                    dATork = 586
                ElseIf ValidateHP(75, 336, 672, 1.13, True) = 75 Then
                    dMotorInertia = 1.13
                    dMH = 75
                    dATork = 672
                Else
                    iError(11) = 1
                    g_bErrors = True
                    maxHP = 75
                End If
            Case 1750
                If ValidateHP(15, 45, 119, 0.0861) = 15 Then
                    dMotorInertia = 0.0861
                    dMH = 15
                    dATork = 119
                ElseIf ValidateHP(20, 60, 158, 0.0982) = 20 Then
                    dMotorInertia = 0.0982
                    dMH = 20
                    dATork = 158
                ElseIf ValidateHP(25, 75, 170, 0.147) = 25 Then
                    dMotorInertia = 0.147
                    dMH = 25
                    dATork = 170
                ElseIf ValidateHP(35, 105, 248, 0.373) = 35 Then
                    dMotorInertia = 0.373
                    dMH = 35
                    dATork = 248
                ElseIf ValidateHP(40, 120, 283, 0.373) = 40 Then
                    dMotorInertia = 0.373
                    dMH = 40
                    dATork = 283
                ElseIf ValidateHP(50, 150, 375, 0.324, True) = 50 Then
                    dMotorInertia = 0.324
                    dMH = 50
                    dATork = 375
                Else
                    iError(11) = 1
                    g_bErrors = True
                    maxHP = 50
                End If
        End Select
        If bMotorDependentChange Then
            If iError(11) = 1 Then dMH = 0
            MN_TRQ01_typ.NominalMotorHP = CStr(dMH)
        Else
            If Conversion.Val(MN_TRQ01_typ.NominalMotorHP) = 0 Then
                MN_TRQ01_typ.NominalMotorHP = Round2Next5(dFullHP)
            Else
                dMH = Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
            End If
        End If
        MN_TRQ01_typ.NominalMotorHPDefault = CStr(dMH)
        If dMH <> 0 Then
            sSQL = "SELECT MinHP,MaxHP FROM [HP Nominal] WHERE Make = '" & MachineVendor & "' AND Model = '" & MachineModel & "' AND " &
                   "RPM=" & CStr(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            If Not TorqueRecordset.EOF Then
                If dMH < TorqueRecordset("MinHP").Value Then
                    dMH = TorqueRecordset("MinHP").Value
                    MN_TRQ01_typ.NominalMotorHP = CStr(dMH)
                ElseIf dMH > TorqueRecordset("MaxHP").Value Then
                    iError(17) = 1
                    g_bErrors = True
                    strError(17) = "Not Standard Application. Calculated Horsepower of " & dMH & " is too large for selected machine (" & MachineModel & ")."
                End If
            End If
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            sSQL = "SELECT * FROM [HP Limits] WHERE Manufacturer = '" & MachineVendor & "' AND MachineModel = '" & MachineModel & "'"
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            If Not TorqueRecordset.EOF Then
                If TorqueRecordset("HP Limitation").Value < dMH Then
                    iError(16) = 1
                    strError(16) = "Calculated motor HP (" & Format(dMH, "0.00") & ") exceeds the machine limitation (" & Format(TorqueRecordset("HP Limitation").Value, "0.00") & ")."
                    g_bErrors = True
                End If
            End If
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
        End If
        If iError(11) = 1 Then
            strError(11) = "Calculated full load horsepower of " & Strings.FormatNumber(dFullHP, 3, TriState.True) & " is greater than the available Schindler motor (maximum " & CStr(maxHP) & " HP for " & CStr(MN_TRQ01_typ.MotorRPM) & " RPM)."
            If strError(12) <> "" Then
                MsgBox(strError(12), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ENG: Full Load Horsepoer")
            Else
                MsgBox(strError(11), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ENG: Full Load Horsepoer")
            End If
            bTorqueCriticalError = True
            MN_TRQ01_typ.bPowerData = False
        ElseIf MachineType = GEARED_TYPE Then
            Validate_NominalMotorHP(MN_TRQ01_typ.NominalMotorHP)
            Validate_NominalMotorHP(MN_TRQ01_typ.NominalMotorHPDefault)
        End If

    End Sub
    Private Sub Acc_Dec_Tork(ByRef dTempMotorInertia As Double)
        Dim dTdec_Normal, dTdec_TSD As Double

        'safety load
        'note: originally it was 0.3 * w1 but since it couldn't be justified it was changed to 0.5*w1. However, w1 is set to 0
        'at the beginning of the calculations
        dSL = dCarWeight + dCapacity + 0.5 * dW1
        If MachineType = GEARED_TYPE Then
            dGA = (dAccel / (dMsDia / 24)) * dGR
            'motoring
            dAccTork = ((dMMaxA) * dMsDia / 24) / (dGR * dFGE) + (dTempMotorInertia + dGI) * dGA
            'plugging
            dGD1 = (dDecel / (dMsDia / 24)) * dGR
            dTdec_Normal = -((dMMaxD * dMsDia * dRGE) / (24 * dGR) + (dTempMotorInertia + dGI) * dGD1)
            dGD1 = (dDecelTSD / (dMsDia / 24)) * dGR
            dTdec_TSD = -((dMMaxDTSD * dMsDia * dRGE) / (24 * dGR) + (dTempMotorInertia + dGI) * dGD1)
            If Math.Abs(dTdec_Normal) > Math.Abs(dTdec_TSD) Then
                dDecTork = dTdec_Normal
            Else
                dDecTork = dTdec_TSD
            End If
            dFullLoadTorque = (dMMaxF * dMsDia / 24) / (dGR * Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency))
        Else
            dAccTork = dMMaxA * dMsDia / 24
            dDecTork = -(dMMaxD * dMsDia / 24)
            If Math.Abs(dMMaxD) > Math.Abs(dMMaxDTSD) Then
                dDecTork = dMMaxD * (dMsDia / 24)
            Else
                dDecTork = dMMaxDTSD * (dMsDia / 24)
            End If
            dFullLoadTorque = dMMaxF * (dMsDia / 24)
        End If
        dDecTork = -Math.Abs(dDecTork)

    End Sub
    Private Sub CheckPeakTork()

        If Math.Abs(dAccTork) > Math.Abs(dDecTork) Then
            dPeakTork = dAccTork
        Else
            dPeakTork = dDecTork
        End If

    End Sub
    Private Sub MaxTraction()
        'calculate the maximum traction for the job
        Dim L As Integer
        Dim T1 As New StringBuilder()

        If dWrapA <> 0 Then
            Select Case MN_TRQ01_typ.GrooveNumber
                Case "K3269"
                    dMaxTraction = Math.Exp(0.21 * dWrapA * (PI / 180))
                Case "K3140"
                    dMaxTraction = Math.Exp(0.235 * dWrapA * (PI / 180))
                Case "K6604"
                    dMaxTraction = Math.Exp(0.114 * dWrapA * (PI / 180))
                Case "K6806"
                    dMaxTraction = Math.Exp(0.126 * dWrapA * (PI / 180))
                Case "K6807"
                    dMaxTraction = Math.Exp(0.094 * dWrapA * (PI / 180))
                Case "K1111"
                    dMaxTraction = Math.Exp(0.22 * dWrapA * (PI / 180))
                Case "K7378"
                    dMaxTraction = Math.Exp(0.12 * dWrapA * (PI / 180))
            End Select
            iError(9) = 0
            For i As Integer = 1 To 7
                If Traction(i) > dMaxTraction Then
                    L = TractionComment(i).Length
                    If T1.ToString() <> "" Then
                        T1.Append(Environment.NewLine & TractionComment(i) & New String(" "c, 38 - L) & CStr(Traction(i)))
                    Else
                        T1 = New StringBuilder(TractionComment(i) & New String(" "c, 38 - L) & CStr(Traction(i)))
                    End If
                    iError(9) = 1
                    g_bErrors = True
                End If
            Next
            If iError(9) = 1 Then
                strError(9) = "The following traction value(s) is/are greater than the Maximum Traction value of " & Strings.FormatNumber(dMaxTraction, 3, TriState.True) & ":" & Environment.NewLine & T1.ToString() & Environment.NewLine
            End If
        End If

    End Sub
    Private Sub CalcAddGrdTork()
        'routine to do the additional calcs for hoistway position
        Try
            Dim G As Double = dAddAccel / 32.174
            Dim gd As Double = dAddDecel / 32.174
            Dim ld5 As Double = dCarWeight + dLLoad - dCWT
            Dim ld6 As Double = dCarWeight + dLLoad + dCWT
            Dim ld3 As Double = (dRWT * (dRise + dXRope) + dMSH + dDSH) * iRoping + dCSH + dCSH1
            Dim GA As Double = (dAddAccel / (dMsDia / 24)) * dGR
            Dim gd1 As Double = (dAddDecel / (dMsDia / 24)) * dGR
            'static and dynamic loads on the motor
            Dim static_f As Double = ld5 + (dPosition * dCompWt) + ((dRise - dPosition) * dRWT * iRoping) + ((dPosition / 2 + dXtraCCable / 2) * dCtrlCableWt) - (dPosition * dRWT * iRoping) - ((dRise - dPosition) * dCompWt)
            Dim inertia_f As Double = ((ld6 + ((dRise + dXCompChain) * dCompWt) + (((dPosition + dXtraCCable) / 2) * dCtrlCableWt)) / iRoping + ld3)
            Dim dAFriction As Double = dCapacity * (1 - (dCounterWeight / 100)) * (1 - dHEff)
            Dim dAMprU As Double = static_f / iRoping
            Dim dAMprD As Double = static_f / iRoping
            Dim dAMpaU As Double = dAMprU + G * inertia_f
            Dim dAMpaD As Double = dAMprD - G * inertia_f
            Dim dAMpdU As Double = dAMprU - gd * inertia_f
            Dim dAMpdD As Double = dAMprD + gd * inertia_f
            'accelerating up tork
            If dAMpaU >= 0 Then
                'motoring
                dAddAccTorkU = (((dAMpaU + (dAFriction / iRoping)) * dMsDia) / (24 * dGR * dFGE)) + (dMotorInertia + dGI) * GA
            Else
                'plugging
                dAddAccTorkU = -((((dAMpaU - (dAFriction / iRoping)) * dMsDia * dRGE) / (24 * dGR)) + (dMotorInertia + dGI) * GA)
            End If
            'accelerating down tork
            If dAMpaD <= 0 Then
                'motoring
                dAddAccTorkD = -((((dAMpaD + (dAFriction / iRoping)) * dMsDia) / (24 * dGR * dFGE)) - (dMotorInertia + dGI) * GA)
            Else
                'plugging
                dAddAccTorkD = (((dAMpaD - (dAFriction / iRoping)) * dMsDia * dRGE) / (24 * dGR)) - (dMotorInertia + dGI) * GA
            End If
            'decelerating down tork
            If dAMpdD <= 0 Then
                'motoring
                dAddDecTorkD = (((dAMpdD + (dAFriction / iRoping)) * dMsDia) / (24 * dGR * dFGE)) + (dMotorInertia + dGI) * gd1
            Else
                'plugging
                dAddDecTorkD = -((((dAMpdD - (dAFriction / iRoping)) * dMsDia * dRGE) / (24 * dGR)) + (dMotorInertia + dGI) * gd1)
            End If
            'decelerating up tork
            If dAMpdU > 0 Then
                'motoring
                dAddDecTorkU = -((((dAMpdU + (dAFriction / iRoping)) * dMsDia) / (24 * dGR * dFGE)) - (dMotorInertia + dGI) * gd1)
            Else
                'plugging
                dAddDecTorkU = ((((dAMpdU - (dAFriction / iRoping)) * dMsDia * dRGE) / (24 * dGR)) - (dMotorInertia + dGI) * gd1)
            End If
            'full speed up tork
            If static_f >= 0 Then
                dAddRunTorkU = ((dAMprU + (dAFriction / iRoping)) * dMsDia) / (24 * dGR * dFGE)
            Else
                dAddRunTorkU = ((dAMprU - (dAFriction / iRoping)) * dMsDia * dRGE) / (24 * dGR)
            End If
            'full speed down tork
            If static_f <= 0 Then
                dAddRunTorkD = (-((dAMprD + (dAFriction / iRoping)) * dMsDia)) / (24 * dGR * dFGE)
            Else
                dAddRunTorkD = (-((dAMprD - (dAFriction / iRoping)) * dMsDia * dRGE)) / (24 * dGR)
            End If

        Catch exc As System.Exception

        End Try

    End Sub
    Private Sub CalcAddCurrents()

        'calculate the currents for the additional calculations
        If dMH = 10 Then
            dAddAccAmpU = 6.9111514 + (0.94834072 * Math.Abs(dAddAccTorkU)) + (0.00394721 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 6.9111514 + (0.94834072 * Math.Abs(dAddAccTorkD)) + (0.00394721 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 6.9111514 + (0.94834072 * Math.Abs(dAddDecTorkU)) + (0.00394721 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 6.9111514 + (0.94834072 * Math.Abs(dAddDecTorkD)) + (0.00394721 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 6.9111514 + (0.94834072 * Math.Abs(dAddRunTorkU)) + (0.00394721 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 6.9111514 + (0.94834072 * Math.Abs(dAddRunTorkD)) + (0.00394721 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf dMH = 15 Then
            dAddAccAmpU = 6.25382463 + (1.03254943 * Math.Abs(dAddAccTorkU)) + (0.00191662 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 6.25382463 + (1.03254943 * Math.Abs(dAddAccTorkD)) + (0.00191662 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 6.25382463 + (1.03254943 * Math.Abs(dAddDecTorkU)) + (0.00191662 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 6.25382463 + (1.03254943 * Math.Abs(dAddDecTorkD)) + (0.00191662 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 6.25382463 + (1.03254943 * Math.Abs(dAddRunTorkU)) + (0.00191662 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 6.25382463 + (1.03254943 * Math.Abs(dAddRunTorkD)) + (0.00191662 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf dMH = 20 Then
            dAddAccAmpU = 9.7716708 + (0.94083154 * Math.Abs(dAddAccTorkU)) + (0.00172705 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 9.7716708 + (0.94083154 * Math.Abs(dAddAccTorkD)) + (0.00172705 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 9.7716708 + (0.94083154 * Math.Abs(dAddDecTorkU)) + (0.00172705 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 9.7716708 + (0.94083154 * Math.Abs(dAddDecTorkD)) + (0.00172705 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 9.7716708 + (0.94083154 * Math.Abs(dAddRunTorkU)) + (0.00172705 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 9.7716708 + (0.94083154 * Math.Abs(dAddRunTorkD)) + (0.00172705 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf dMH = 25 Then
            dAddAccAmpU = 6.35175832 + (1.00981385 * Math.Abs(dAddAccTorkU)) + (0.00088309 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 6.35175832 + (1.00981385 * Math.Abs(dAddAccTorkD)) + (0.00088309 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 6.35175832 + (1.00981385 * Math.Abs(dAddDecTorkU)) + (0.00088309 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 6.35175832 + (1.00981385 * Math.Abs(dAddDecTorkD)) + (0.00088309 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 6.35175832 + (1.00981385 * Math.Abs(dAddRunTorkU)) + (0.00088309 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 6.35175832 + (1.00981385 * Math.Abs(dAddRunTorkD)) + (0.00088309 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf dMH = 30 Then
            dAddAccAmpU = 5.5016466 + (1.04185474 * Math.Abs(dAddAccTorkU)) + (0.00067939 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 5.5016466 + (1.04185474 * Math.Abs(dAddAccTorkD)) + (0.00067939 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 5.5016466 + (1.04185474 * Math.Abs(dAddDecTorkU)) + (0.00067939 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 5.5016466 + (1.04185474 * Math.Abs(dAddDecTorkD)) + (0.00067939 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 5.5016466 + (1.04185474 * Math.Abs(dAddRunTorkU)) + (0.00067939 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 5.5016466 + (1.04185474 * Math.Abs(dAddRunTorkD)) + (0.00067939 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf (dMH = 40) And (sMachineType = "58" Or sMachineType = "Other") Then
            dAddAccAmpU = 5.60755877 + (0.73368509 * Math.Abs(dAddAccTorkU)) + (0.000189 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 5.60755877 + (0.73368509 * Math.Abs(dAddAccTorkD)) + (0.000189 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 5.60755877 + (0.73368509 * Math.Abs(dAddDecTorkU)) + (0.000189 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 5.60755877 + (0.73368509 * Math.Abs(dAddDecTorkD)) + (0.000189 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 5.60755877 + (0.73368509 * Math.Abs(dAddRunTorkU)) + (0.000189 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 5.60755877 + (0.73368509 * Math.Abs(dAddRunTorkD)) + (0.000189 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf dMH = 40 Then
            dAddAccAmpU = 14.94194962 + (1.02159996 * Math.Abs(dAddAccTorkU)) + (0.00059959 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 14.94194962 + (1.02159996 * Math.Abs(dAddAccTorkD)) + (0.00059959 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 14.94194962 + (1.02159996 * Math.Abs(dAddDecTorkU)) + (0.00059959 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 14.94194962 + (1.02159996 * Math.Abs(dAddDecTorkD)) + (0.00059959 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 14.94194962 + (1.02159996 * Math.Abs(dAddRunTorkU)) + (0.00059959 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 14.94194962 + (1.02159996 * Math.Abs(dAddRunTorkD)) + (0.00059959 * (Math.Abs(dAddRunTorkD)) ^ 2)
        ElseIf (dMH = 50) Then  'And (sMachineType = "58" Or sMachineType = "Other") Then
            dAddAccAmpU = 9.23504457 + (0.69235709 * Math.Abs(dAddAccTorkU)) + (0.00019406 * (Math.Abs(dAddAccTorkU)) ^ 2)
            dAddAccAmpD = 9.23504457 + (0.69235709 * Math.Abs(dAddAccTorkD)) + (0.00019406 * (Math.Abs(dAddAccTorkD)) ^ 2)
            dAddDecAmpU = 9.23504457 + (0.69235709 * Math.Abs(dAddDecTorkU)) + (0.00019406 * (Math.Abs(dAddDecTorkU)) ^ 2)
            dAddDecAmpD = 9.23504457 + (0.69235709 * Math.Abs(dAddDecTorkD)) + (0.00019406 * (Math.Abs(dAddDecTorkD)) ^ 2)
            dAddRunAmpU = 9.23504457 + (0.69235709 * Math.Abs(dAddRunTorkU)) + (0.00019406 * (Math.Abs(dAddRunTorkU)) ^ 2)
            dAddRunAmpD = 9.23504457 + (0.69235709 * Math.Abs(dAddRunTorkD)) + (0.00019406 * (Math.Abs(dAddRunTorkD)) ^ 2)
        End If
        sAddCalcErr = ""
        If (dAddRunAmpU <= 0) Or (dAddAccAmpU <= 0) Or (dAddDecAmpU <= 0) Or (dAddRunAmpD <= 0) Or (dAddAccAmpD <= 0) Or (dAddDecAmpD <= 0) Then
            'set an error message for the screen
            sAddCalcErr = "Couldn't find a valid combination of Machine and HP (" & sMachineType & ", " & CStr(dMH) & " Hp). Unable to calculate currents. "
        End If

    End Sub
    Private Sub CalcPowerData_GEARED_NON_REGEN()
        Dim aTE(5) As Double, aTI(5) As Double, aTPF(5) As Double
        Dim sMsg As String = ""

        MN_TRQ01_typ.MotorRPM = Conversion.Val(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
        If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
            IT1 = 8.8
        Else
            IT1 = (5.4 * 1000 / (PowerSupply * (3 ^ 0.5)))
        End If
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open("[HP RPM MotorJ]", ADOConnection)
        Dim bTEandTPF As Boolean = False
        Do While Not TorqueRecordset.EOF
            If TorqueRecordset("RPM").Value = MN_TRQ01_typ.MotorRPM Then
                If TorqueRecordset("HP").Value = dMH Then
                    For i As Integer = 1 To 6
                        aTE(i - 1) = TorqueRecordset("te" & Conversion.Str(i).Trim()).Value
                        aTI(i - 1) = TorqueRecordset("ti" & Conversion.Str(i).Trim()).Value
                        aTPF(i - 1) = TorqueRecordset("tpf" & Conversion.Str(i).Trim()).Value
                    Next i
                    bTEandTPF = True
                    Exit Do
                End If
            End If
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        If Not bTEandTPF Then
            If ENG_ACCESS Then
                MsgBox("Based on RPM (" & MN_TRQ01_typ.MotorRPM & ") and HP (" & dMH & "), cannot calculate Motor Efficiency",
                       MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ENG: Motor Efficiency")
            End If
            bTorqueCriticalError = True
            MN_TRQ01_typ.bPowerData = False
            Exit Sub
        End If
        'MOTOR_EFFICIENCY = 1st eq
        dMOTOR_EFFICIENCY_Running = aTE(0)
        dIrflu = aTI(0)
        For i As Integer = 2 To 6
            dMOTOR_EFFICIENCY_Running += dFullTork ^ (i - 1) * aTE(i - 1)
            dIrflu += dFullTork ^ (i - 1) * aTI(i - 1)
        Next i
        dMOTOR_EFFICIENCY_Running /= 100
        MN_PowerData_GEARED_typ.PowerFromConverter_RFLU = CStr(dFullTork * dRPM * dConversionM2E / 5252.11305 / 1000.0# / INVERTER_EFFICIENCY / dMOTOR_EFFICIENCY_Running)
        'POWER_FACTOR =3rd eq    POWER_FACTOR Running
        dPOWER_FACTOR_Running = aTPF(0)
        For i As Integer = 2 To 6
            dPOWER_FACTOR_Running += dFullTork ^ (i - 1) * aTPF(i - 1)
        Next i
        dPOWER_FACTOR_Running /= 100
        Set_InputVoltage()
        MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU = CStr((Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_RFLU) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage)) / dPOWER_FACTOR_Running)
        MN_PowerData_GEARED_typ.ACCurrentIntoDrive_RFLU = ((Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply) + IT1).ToString
        MN_PowerData_GEARED_typ.LineCurrent_RFLU = MN_PowerData_GEARED_typ.ACCurrentIntoDrive_RFLU
        MN_PowerData_GEARED_typ.LinePower_RFLU = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_RFLU) * dPOWER_FACTOR_Running / 1000.0#)
        'MOTOR_EFFICIENCY =2nd eq
        dMOTOR_EFFICIENCY_Accelerating = aTE(0)
        dIaflu = aTI(0)
        For i As Integer = 2 To 6
            dMOTOR_EFFICIENCY_Accelerating += dAccTork ^ (i - 1) * aTE(i - 1)
            dIaflu += dAccTork ^ (i - 1) * aTI(i - 1)
        Next i
        dMOTOR_EFFICIENCY_Accelerating /= 100
        MN_PowerData_GEARED_typ.PowerFromConverter_AFLU = CStr(dAccTork * dRPM * dConversionM2E / 5252.11305 / 1000.0# / (dMOTOR_EFFICIENCY_Accelerating * 0.95))
        'POWER_FACTOR = 4th eq POWER_FACTOR accel
        dPOWER_FACTOR_Accelerating = aTPF(0)
        For i As Integer = 2 To 6
            dPOWER_FACTOR_Accelerating += dAccTork ^ (i - 1) * aTPF(i - 1)
        Next i
        dPOWER_FACTOR_Accelerating /= 100
        dPreg = (9.80665 * dCapacity / 2.204623) * (1 - Conversion.Val(MN_TRQ01_typ.Counterweight) / 100) * ((Speed / 60) / 3.2808399) * Conversion.Val(MN_TRQ01_typ.HatchEfficiency) * dMOTOR_EFFICIENCY_Running * Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency) / 1000
        MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU = CStr(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_AFLU) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage) / dPOWER_FACTOR_Accelerating)
        MN_PowerData_GEARED_typ.ACCurrentIntoDrive_AFLU = ((Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply) + IT1).ToString
        MN_PowerData_GEARED_typ.LineCurrent_AFLU = MN_PowerData_GEARED_typ.ACCurrentIntoDrive_AFLU
        MN_PowerData_GEARED_typ.LinePower_AFLU = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_AFLU) * dPOWER_FACTOR_Accelerating / 1000.0#)
        MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformer = CStr(445.0# * dFullHP + 2400.0#)
        MN_PowerData_GEARED_typ.HeatReleaseWithTransformer = CStr(455.0# * dFullHP + 3500.0#)
        MN_PowerData_GEARED_typ.HeatReleaseCabinet = CStr(223.0# * dFullHP + 2900.0#)
        MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachine = CStr(308.0# * dFullHP)
        MN_PowerData_GEARED_typ.HeatReleaseAutoTransformer = CStr(14.0# * dFullHP + 1350.0#)
        MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformerSS = CStr((445.0# * dFullHP + 2400.0#) * 0.35)
        MN_PowerData_GEARED_typ.HeatReleaseWithTransformerSS = CStr((455.0# * dFullHP + 3500.0#) * 0.35)
        MN_PowerData_GEARED_typ.HeatReleaseCabinetSS = CStr((223.0# * dFullHP + 2900.0#) * 0.3)
        MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachineSS = CStr((308.0# * dFullHP) * 0.45)
        MN_PowerData_GEARED_typ.HeatReleaseAutoTransformerSS = CStr((14.0# * dFullHP + 1350.0#) * 0.25)
        sDriveSelection = DriveSelection(dIrflu, dIaflu, dPreg, Strings.Right(ControllerType, 3) = "PF1")
        sDriveSelection = DriveSelectionValidation(dIrflu, dIaflu, dPreg, Strings.Right(ControllerType, 3) = "PF1")
        If sDriveSelection = "Error" Then
            MN_PowerData_GEARED_typ.IRFLU = ""
            MN_PowerData_GEARED_typ.IAFLU = ""
            MN_PowerData_GEARED_typ.Preg = ""
        Else
            MN_PowerData_GEARED_typ.IRFLU = CStr(dIrflu)
            MN_PowerData_GEARED_typ.IAFLU = CStr(dIaflu)
            MN_PowerData_GEARED_typ.Preg = CStr(dPreg)
        End If

    End Sub
    Private Sub CalcPowerData_GEARED_REGEN()
        Dim aTE(5) As Double, aTI(5) As Double, aTPF(5) As Double
        Dim bTEandTPF As Boolean
        Dim sMsg As String = ""

        Try
            MN_TRQ01_typ.MotorRPM = Conversion.Val(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
            If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
                IT1 = 8.8
            Else
                IT1 = (5.4 * 1000 / (PowerSupply * (3 ^ 0.5)))
            End If
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open("[HP RPM MotorJ]", ADOConnection)
            bTEandTPF = False
            Do While Not TorqueRecordset.EOF
                If TorqueRecordset("RPM").Value = MN_TRQ01_typ.MotorRPM Then
                    If TorqueRecordset("HP").Value = dMH Then
                        For i As Integer = 1 To 6
                            aTE(i - 1) = TorqueRecordset("te" & Conversion.Str(i).Trim()).Value
                            aTI(i - 1) = TorqueRecordset("ti" & Conversion.Str(i).Trim()).Value
                            aTPF(i - 1) = TorqueRecordset("tpf" & Conversion.Str(i).Trim()).Value
                        Next i
                        bTEandTPF = True
                        Exit Do
                    End If
                End If
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            If Not bTEandTPF Then
                If ENG_ACCESS Then
                    MsgBox("Based on RPM (" & MN_TRQ01_typ.MotorRPM & ") and HP (" & dMH & "), cannot calculate Motor Efficiency",
                           MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ENG: Motor Efficiency")
                End If
                bTorqueCriticalError = True
                MN_TRQ01_typ.bPowerData = False
                Exit Sub
            End If
            'MOTOR_EFFICIENCY = 1st eq
            dMOTOR_EFFICIENCY_Running = aTE(0)
            dIrflu = aTI(0)
            For i As Integer = 2 To 6
                dMOTOR_EFFICIENCY_Running += dFullTork ^ (i - 1) * aTE(i - 1)
                dIrflu += dFullTork ^ (i - 1) * aTI(i - 1)
            Next i
            dMOTOR_EFFICIENCY_Running /= 100
            MN_PowerData_GEARED_typ.PowerFromConverter_RFLU = CStr(dFullTork * dRPM * dConversionM2E / 5252.11305 / 1000.0# / 0.91 / dMOTOR_EFFICIENCY_Running)
            'POWER_FACTOR =3rd eq    POWER_FACTOR Running
            dPOWER_FACTOR_Running = 0.99
            Set_InputVoltage()
            MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU = CStr((Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_RFLU) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage)) / dPOWER_FACTOR_Running)
            MN_PowerData_GEARED_typ.ACCurrentIntoDrive_RFLU = ((Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply) + IT1).ToString
            MN_PowerData_GEARED_typ.LineCurrent_RFLU = MN_PowerData_GEARED_typ.ACCurrentIntoDrive_RFLU
            MN_PowerData_GEARED_typ.LinePower_RFLU = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_RFLU) * dPOWER_FACTOR_Running / 1000)
            'MOTOR_EFFICIENCY =2nd eq
            dMOTOR_EFFICIENCY_Accelerating = aTE(0)
            dIaflu = aTI(0)
            For i As Integer = 2 To 6
                dMOTOR_EFFICIENCY_Accelerating += dAccTork ^ (i - 1) * aTE(i - 1)
                dIaflu += dAccTork ^ (i - 1) * aTI(i - 1)
            Next i
            dMOTOR_EFFICIENCY_Accelerating /= 100
            MN_PowerData_GEARED_typ.PowerFromConverter_AFLU = CStr(dAccTork * dRPM * dConversionM2E / 5252.11305 / 1000.0# / (dMOTOR_EFFICIENCY_Accelerating * 0.91))
            'MOTOR_EFFICIENCY DECELERATING
            dMOTOR_EFFICIENCY_Decelerating = aTE(0)
            For i As Integer = 2 To 6
                dMOTOR_EFFICIENCY_Decelerating += Math.Abs(dDecTork) ^ (i - 1) * aTE(i - 1)
            Next i
            dMOTOR_EFFICIENCY_Decelerating /= 100
            'POWER_FACTOR = 4th eq POWER_FACTOR accel
            dPOWER_FACTOR_Accelerating = 0.99
            PF3 = 0.99
            PF4 = 0.99
            dPreg = (9.80665 * dCapacity / 2.204623) * (1 - Conversion.Val(MN_TRQ01_typ.Counterweight) / 100) * ((Speed / 60) / 3.2808399) * Conversion.Val(MN_TRQ01_typ.HatchEfficiency) * dMOTOR_EFFICIENCY_Running * Conversion.Val(MN_TRQ01_typ.ForwardGearEfficiency) / 1000
            MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU = CStr(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_AFLU) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage) / dPOWER_FACTOR_Accelerating)
            MN_PowerData_GEARED_typ.ACCurrentIntoDrive_AFLU = ((Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply) + IT1).ToString
            MN_PowerData_GEARED_typ.LineCurrent_AFLU = MN_PowerData_GEARED_typ.ACCurrentIntoDrive_AFLU
            MN_PowerData_GEARED_typ.LinePower_AFLU = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_AFLU) * dPOWER_FACTOR_Accelerating / 1000.0#)
            MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformer = CStr(535.0# * dFullHP + 2469.0#)
            MN_PowerData_GEARED_typ.HeatReleaseWithTransformer = CStr(602.0# * dFullHP + 4549.0#)
            MN_PowerData_GEARED_typ.HeatReleaseCabinet = CStr(70.0# * dFullHP + 182.0#)
            MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachine = CStr(467.0# * dFullHP + 116)
            MN_PowerData_GEARED_typ.HeatReleaseAutoTransformer = CStr(67.0# * dFullHP + 2080.0#)
            MN_PowerData_GEARED_typ.PowerFromConverter_TSFLD = CStr(dDecTork * dRPM * dConversionM2E / 5252.11305 / 1000.0# * 0.91 * dMOTOR_EFFICIENCY_Decelerating)
            MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD = CStr((Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_TSFLD) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage)) / PF4)
            MN_PowerData_GEARED_typ.ACCurrentIntoBuilding_TSFLD = CStr((Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD)) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply)
            MN_PowerData_GEARED_typ.LineCurrent_TSFLD = MN_PowerData_GEARED_typ.ACCurrentIntoBuilding_TSFLD
            MN_PowerData_GEARED_typ.LinePower_TSFLD = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_TSFLD) * PF4 / 1000)
            MN_PowerData_GEARED_typ.PowerFromConverter_TRFLU = CStr((-dFullTork) * dRPM * dConversionM2E / 5252.11305 / 1000.0# * 0.91 * dMOTOR_EFFICIENCY_Running)
            MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TRFLU = CStr((Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_TRFLU) * 1000.0# / 3 ^ 0.5 / Conversion.Val(MN_TRQ01_typ.InputVoltage)) / PF3)
            MN_PowerData_GEARED_typ.ACCurrentIntoBuilding_TRFLU = CStr((Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TRFLU)) * Conversion.Val(MN_TRQ01_typ.InputVoltage) / PowerSupply)
            MN_PowerData_GEARED_typ.LineCurrent_TRFLU = MN_PowerData_GEARED_typ.ACCurrentIntoBuilding_TRFLU
            MN_PowerData_GEARED_typ.LinePower_TRFLU = CStr(3 ^ 0.5 * PowerSupply * Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_TRFLU) * PF3 / 1000)
            MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformerSS = CStr((535.0# * dFullHP + 2469.0#) * 0.35)
            MN_PowerData_GEARED_typ.HeatReleaseWithTransformerSS = CStr((602.0# * dFullHP + 4549.0#) * 0.3)
            MN_PowerData_GEARED_typ.HeatReleaseCabinetSS = CStr((68.0# * dFullHP + 2353.0#) * 0.3)
            MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachineSS = CStr((467.0# * dFullHP + 116.0#) * 0.5)
            MN_PowerData_GEARED_typ.HeatReleaseAutoTransformerSS = CStr((67.0# * dFullHP + 2080.0#) * 0.15)
            sDriveSelection = DriveSelection(dIrflu, dIaflu, dPreg, Strings.Right(ControllerType, 3) = "PF1")
            sDriveSelection = DriveSelectionValidation(dIrflu, dIaflu, dPreg, Strings.Right(ControllerType, 3) = "PF1")
            If sDriveSelection = "Error" Then
                MN_PowerData_GEARED_typ.IRFLU = ""
                MN_PowerData_GEARED_typ.IAFLU = ""
                MN_PowerData_GEARED_typ.Preg = ""
            Else
                MN_PowerData_GEARED_typ.IRFLU = CStr(dIrflu)
                MN_PowerData_GEARED_typ.IAFLU = CStr(dIaflu)
                MN_PowerData_GEARED_typ.Preg = CStr(dPreg)
            End If

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "CalcPowerData_GEARED_REGEN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub
    Private Sub CalcPowerData_GEARLESS()
        Dim EP As Single = PowerSupply
        Dim iVFLU As Integer = Math.Round(Conversion.Val(VFLU))

        Select Case ControllerType
            Case DRIVETYPE_BESTPRICE, DRIVETYPE_BR, DRIVETYPE_PF1
                EP = Math.Round(MN_TRQ01_typ.UN / PowerSupply, 2)
        End Select
        IDC1 = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "FullLoadCurrentIDC1_txt"))
        IDC2 = CStr(Conversion.Val(IDC1) * dAccTork / dFullTork)
        IDC3 = CStr(Conversion.Val(IDC1) * dDecTork / dFullTork)
        IDC4 = CStr(Conversion.Val(IDC1) * dRunTork / dFullTork)
        IDC5 = CStr(Conversion.Val(IDC4) * 1.25)
        IDC6 = CStr(Conversion.Val(IDC3) * 1.25)
        sTransformerRequired = TransformerRequired()
        If ControllerType = DRIVETYPE_QUATTRO Then
            If iVFLU >= 100 And iVFLU <= 525 Then
                Select Case EP
                    Case Is <= 208
                        Select Case iVFLU
                            Case Is <= 200
                                E1 = 208
                            Case Is <= 400
                                E1 = 380
                            Case Else
                                E1 = 480
                        End Select
                    Case Is <= 230
                        Select Case iVFLU
                            Case Is <= 250
                                E1 = 230
                            Case Is <= 400
                                E1 = 364
                            Case Else
                                E1 = 460
                        End Select
                    Case Is <= 240
                        Select Case iVFLU
                            Case Is <= 250
                                E1 = 240
                            Case Is <= 400
                                E1 = 380
                            Case Else
                                E1 = 480
                        End Select
                    Case Is <= 460
                        Select Case iVFLU
                            Case Is <= 200
                                E1 = 304
                            Case Is <= 250
                                E1 = 364
                            Case Else
                                E1 = 460
                        End Select
                    Case Is <= 480
                        Select Case iVFLU
                            Case Is <= 200
                                E1 = 317
                            Case Is <= 350
                                E1 = 380
                            Case Else
                                E1 = 480
                        End Select
                    Case Is <= 550
                        Select Case iVFLU
                            Case Is <= 350
                                E1 = 363
                            Case Else
                                E1 = 459
                        End Select
                    Case Else
                        Select Case iVFLU
                            Case Is <= 400
                                E1 = 380
                            Case Else
                                E1 = 480
                        End Select
                End Select
            End If
        Else
            ReDim Preserve aE1(0)
            IT1 = (5.4 * 1000 / (EP * (3 ^ 0.5)))
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open("E1", ADOConnection)
            Do While Not TorqueRecordset.EOF
                ReDim Preserve aE1(aE1.GetUpperBound(0) + 1)
                aE1(aE1.GetUpperBound(0)) = TorqueRecordset("Voltage").Value
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            ES1MIN = Conversion.Val(VFLU) * 1.1
            E1 = ES1MIN
            For i As Integer = 1 To aE1.GetUpperBound(0)
                If aE1(i) > ES1MIN Then
                    E1 = aE1(i)
                    Exit For
                End If
            Next i
        End If
        Select Case ControllerType
            Case DRIVETYPE_SCRDC
                PF1 = 0.7
                PF2 = 0.6
                PF3 = 0.5
                PF4 = 0.4
            Case DRIVETYPE_QUATTRO
                PF1 = 1.0#
                PF2 = 1.0#
                PF3 = 1.0#
                PF4 = 1.0#
        End Select
        If GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "Application_cmb") = "General Purpose" And MN_TRQ01_typ.Performance = StandardPerformance Then
            DutyFactor = 0.83
        Else
            DutyFactor = 1.0#
        End If
        E2 = 170
        If Conversion.Val(VFF) >= (0.8 * E2) Then
            E2 = 340
        End If
        Select Case ControllerType
            Case DRIVETYPE_SCRDC
                IAC1 = (DutyFactor * E1 * Conversion.Val(IDC1) * 0.85) / EP + E2 * Conversion.Val(IFF) * 0.75 / EP + Conversion.Val(VFan) * Conversion.Val(IFan) / (Math.Sqrt(3) * EP) + IT1
                IAC2 = (DutyFactor * E1 * Conversion.Val(IDC2) * 0.85) / EP + E2 * Conversion.Val(IFF) * 0.75 / EP + Conversion.Val(VFan) * Conversion.Val(IFan) / (Math.Sqrt(3) * EP) + IT1
                IAC3 = (E1 * Conversion.Val(IDC3) * 0.85) / EP
                IAC4 = (E1 * Conversion.Val(IDC4) * 0.85) / EP
                IAC5 = (E1 * Conversion.Val(IDC5) * 0.85) / EP
                IAC6 = (E1 * Conversion.Val(IDC6) * 0.85) / EP
            Case DRIVETYPE_QUATTRO
                IAC1 = (Conversion.Val(VFLU) * Conversion.Val(IDC1) * 1.1) / (EP * 3 ^ 0.5) + IT1 + (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
                IAC2 = (Conversion.Val(VFLU) * Conversion.Val(IDC2) * 1.1) / (EP * 3 ^ 0.5) + IT1 + (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
                IAC3 = (Conversion.Val(VFLU) * Conversion.Val(IDC3) * 1.1) / (EP * 3 ^ 0.5) - IT1 - (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
                IAC4 = (Conversion.Val(VFLU) * Conversion.Val(IDC4) * 1.1) / (EP * 3 ^ 0.5) - IT1 - (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
                IAC5 = (Conversion.Val(VFLU) * Conversion.Val(IDC5) * 1.1) / (EP * 3 ^ 0.5) - IT1 - (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
                IAC6 = (Conversion.Val(VFLU) * Conversion.Val(IDC6) * 1.1) / (EP * 3 ^ 0.5) - IT1 - (Conversion.Val(VFan) * Conversion.Val(IFan)) / (EP * Math.Sqrt(3))
        End Select
        KWAC1 = 3 ^ 0.5 * EP * IAC1 * PF1 / 1000.0#
        KWAC2 = 3 ^ 0.5 * EP * IAC2 * PF2 / 1000.0#
        KWAC3 = 3 ^ 0.5 * EP * IAC3 * PF4 / 1000.0#
        KWAC4 = 3 ^ 0.5 * EP * IAC4 * PF3 / 1000.0#
        KWAC5 = 3 ^ 0.5 * EP * IAC5 * PF3 / 1000.0#
        KWAC6 = 3 ^ 0.5 * EP * IAC6 * PF4 / 1000.0#
        If sTransformerRequired = "Transformer Not Required" Then
            MN_PowerData_GEARLESS_typ.PeakInrushCurrent = CStr((IT1 + 1000 * 1.25 / (EP * 3 ^ 0.5)) * 10)
        Else
            MN_PowerData_GEARLESS_typ.PeakInrushCurrent = CStr(IAC1 * 10)
        End If
        If sTransformerRequired = "Transformer Not Required" Then
            MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformer = CStr(0)
            MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformer = CStr(245.0# * dFullHP + 5600.0#)
        Else
            MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformer = CStr(245.0# * dFullHP + 5600.0#)
            MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformer = CStr(0)
        End If
        MN_PowerData_GEARLESS_typ.HeatReleaseCabinet = CStr(31.0# * dFullHP + 3000.0#)
        MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachine = CStr(139.0# * dFullHP + 3600)
        MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformer = CStr(91.0# * dFullHP + 180.0#)
        If ControllerType = DRIVETYPE_QUATTRO Then
            MN_PowerData_GEARLESS_typ.HeatReleaseChoke = CStr(0)
        Else
            MN_PowerData_GEARLESS_typ.HeatReleaseChoke = CStr(31.0# * dFullHP)
        End If
        If sTransformerRequired = "Transformer Not Required" Then
            MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformerSS = CStr((245.0# * dFullHP + 5600.0#) * 0.35)
            MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformerSS = CStr(0)
        Else
            MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformerSS = CStr(0)
            MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformerSS = CStr((245.0# * dFullHP + 5600.0#) * 0.35)
        End If
        MN_PowerData_GEARLESS_typ.HeatReleaseCabinetSS = CStr((31.0# * dFullHP + 3000.0#) * 0.55)
        MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachineSS = CStr((139.0# * dFullHP + 3600) * 0.4)
        MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformerSS = CStr((91.0# * dFullHP + 180.0#) * 0.25)
        If ControllerType = DRIVETYPE_QUATTRO Then
            MN_PowerData_GEARLESS_typ.HeatReleaseChokeSS = CStr(0)
        Else
            MN_PowerData_GEARLESS_typ.HeatReleaseChokeSS = CStr(31.0# * dFullHP * 0.2)
        End If
        sDriveSelection = DriveSelectionGEARLESS(ControllerType = DRIVETYPE_SCRDC)

        If ControllerType = DRIVETYPE_QUATTRO Then
            If MN_TRQ01_typ.DriveModel <> "" Then
                If sTransformerRequired <> "Transformer Not Required" Then
                    Dim Ip As Single = QuattroInternalTransformerIp() * 10
                    If Ip <> 0 Then
                        MN_PowerData_GEARLESS_typ.PeakInrushCurrent = CStr(Ip)
                    End If
                End If
            End If
        ElseIf ControllerType = DRIVETYPE_SCRDC Then
            Dim MinKVA As Single = DutyFactor * 0.85 * Conversion.Val(IDC1) * E1 * 3 ^ 0.5 / 1000
            Dim K1 As Single = Math.Ceiling(MinKVA)
            Dim K2 As Single = E2 * Conversion.Val(IFF) / 1000
            KT = K1 + K2
        End If

    End Sub
    Private Sub CalcWrapAngle(ByRef bDisableOutput As Boolean, Optional ByRef b51 As Boolean = False)
        Dim dRopeOffset, k, U, f, G As Double
        Dim h As Integer
        Dim bCriteria As Boolean

        Try

            'calculate the wrap angle
            dX1 = Conversion.Val(MN_TRQ01_typ.HorizontalDistance)
            dY1 = Conversion.Val(MN_TRQ01_typ.VerticalDistance)
            dDsDia = HoistwaySheaveDiameter()
            dMsDia = Conversion.Val(MachineSheaveDiameter)
            dRopeOffset = Conversion.Val(MN_TRQ01_typ.RopeOffset)
            If dX1 = 0 Or dY1 = 0 Or dDsDia = 0 Or dMsDia = 0 Or (dRopeOffset = 0 And MachineLocation <> "Overhead") Then
                Select Case iWrapAngleLogic
                    Case 1
                        MN_TRQ01_typ.WrapAngle = "160"
                    Case 2, 4
                        MN_TRQ01_typ.WrapAngle = "180"
                    Case 3
                        MN_TRQ01_typ.WrapAngle = "200"
                    Case 51
                        If b51 Then
                            C = 0
                            b = Conversion.Val(MN_TRQ01_typ.WrapAngle) - 270
                        Else
                            dWA = -1
                            MN_TRQ01_typ.WrapAngle = ""
                        End If
                End Select
            Else
                b = Math.Atan(dY1 / dX1) * 180 / PI
                k = (dMsDia - dDsDia) / 2
                U = (dX1 ^ 2 + dY1 ^ 2) ^ 0.5
                C = ArcSin(k / U) * 180 / PI
                If MachineLocation = "Overhead" Then
                    bCriteria = MachineType = GEARLESS_TYPE
                    If bCriteria Then bCriteria = Wrap = "Double Wrap"
                    If bCriteria Then
                        dWA = 270 + b + 3 * C
                    Else
                        dWA = 90 + b + C
                    End If
                Else
                    f = ArcCos(((dMsDia + dDsDia) / 2) / U) * 180 / PI
                    If (MN_TRQ01_typ.RopeOffset) < (dMsDia - dDsDia) / 2 Then
                        h = -1
                    Else
                        h = 1
                    End If
                    If dMsDia / 2 + h * dX1 = dRopeOffset + dDsDia / 2 Then
                        G = Math.Atan((h * dX1) / dY1) * 180 / PI
                        dWA = 270 - f - G
                    Else
                        dWA = -1
                    End If
                End If
                If Not bDisableOutput And dWA <> -1 Then
                    Select Case iWrapAngleLogic
                        Case 1, 2
                            If dWA > 180 Then dWA = 180
                        Case 3
                            If dWA < 180 Then dWA = 180
                        Case 4
                            If dWA < 175 Then dWA = 175
                            If dWA > 185 Then dWA = 185
                    End Select
                End If
            End If

        Catch

            If Information.Err().Number = 5 Then
                If Not bSkipWrapWarning Then
                    Select Case iWrapAngleLogic
                        Case 1
                            dWA = 160
                        Case 2, 4
                            dWA = 180
                        Case 3
                            dWA = 200
                        Case 51
                            If b51 Then
                                C = 0
                                b = Conversion.Val(MN_TRQ01_typ.WrapAngle) - 270
                            Else
                                dWA = -1
                            End If
                        Case Else
                            dWA = -1
                    End Select
                End If
            Else
                MessageBox.Show(Conversion.ErrorToString(), "CalcWrapAngle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try

    End Sub
    Private Sub Calc_GeneralData()

        Select Case MachineType
            Case GEARED_TYPE
                Select Case MN_TRQ01_typ.Performance
                    Case StandardPerformance
                        MN_TRQ01_typ.Acceleration = CStr(2.624672)
                        MN_TRQ01_typ.Deceleration = CStr(2.624672)
                        MN_TRQ01_typ.DecelerationTraction = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) + 1)
                        MN_TRQ01_typ.DecelerationTSD = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) * 1.15)
                        MN_TRQ01_typ.DecelerationD125 = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) / 2)
                        MN_TRQ01_typ.TractionAdder = CStr(1.25) 'per Marc
                    Case HighPerformance
                        MN_TRQ01_typ.Acceleration = CStr(3.28084)
                        MN_TRQ01_typ.Deceleration = CStr(3.28084)
                        MN_TRQ01_typ.DecelerationTraction = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) + 1)
                        MN_TRQ01_typ.DecelerationTSD = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) * 1.15)
                        MN_TRQ01_typ.DecelerationD125 = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) / 2)
                        MN_TRQ01_typ.TractionAdder = CStr(1.25) 'per Marc
                End Select
            Case GEARLESS_TYPE
                Select Case MN_TRQ01_typ.Performance
                    Case StandardPerformance
                        MN_TRQ01_typ.Acceleration = CStr(3.28084)
                        MN_TRQ01_typ.Deceleration = CStr(3.28084)
                        MN_TRQ01_typ.DecelerationTraction = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) + 1)
                        MN_TRQ01_typ.DecelerationTSD = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) * 1.15)
                        MN_TRQ01_typ.DecelerationD125 = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) / 2)
                        MN_TRQ01_typ.TractionAdder = CStr(0) 'kill
                    Case HighPerformance
                        MN_TRQ01_typ.Acceleration = CStr(3.937008)
                        MN_TRQ01_typ.Deceleration = CStr(3.937008)
                        MN_TRQ01_typ.DecelerationTraction = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) + 1)
                        MN_TRQ01_typ.DecelerationTSD = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) * 1.15)
                        MN_TRQ01_typ.DecelerationD125 = CStr(Conversion.Val(MN_TRQ01_typ.Deceleration) / 2)
                        MN_TRQ01_typ.TractionAdder = CStr(0)
                End Select
        End Select

    End Sub
    Private Function ValidateHP(ByRef HP As Integer, ByRef TRFLU As Integer, ByRef TAFLU As Integer, ByRef dTempMotorInertia As Double, Optional ByRef bMaxHP As Boolean = False) As Integer
        Dim result As Integer = 0

        Acc_Dec_Tork(dTempMotorInertia)
        If dAccTork < TAFLU Then
            If Math.Abs(dDecTork) < TAFLU Then
                If dFullTork < TRFLU Then
                    If dRunTork < TRFLU Then
                        result = HP
                        gTRFLU = TRFLU
                        gTAFLU = TAFLU
                    ElseIf bMaxHP Then
                        strError(12) = "Even with max avalable (" & HP & ")HP: Run Tork (" & Strings.FormatNumber(dRunTork, 2) & ") > TRFLU (" & TRFLU & ")."
                    End If
                ElseIf bMaxHP Then
                    strError(12) = "Even with max avalable (" & HP & ")HP: Full Tork (" & Strings.FormatNumber(dFullTork, 2) & ") > TRFLU (" & TRFLU & ")."
                End If
            End If
        ElseIf bMaxHP Then
            strError(12) = "Even with max avalable (" & HP & ")HP: Acc Tork (" & Strings.FormatNumber(dAccTork, 2) & ") > TAFLU (" & TAFLU & ")."
        End If
        If strError(12) <> "" Then
            strError(12) = strError(12) & " Nominal Motor HP was not selected."
        End If
        Return result

    End Function
    Private Sub SheaveLoadCalcNew()
        Dim D, E As Double

        'sheave load calculation - calcs max suspended load and not the component sheave load vectors
        If Wrap = "Single Wrap" Then
            dAlpha = (180 - dWrapA) * (PI / 180)
            dShv = T1s + T2s * (Math.Cos(dAlpha))
            dShh = T2s * Math.Sin(dAlpha)
        Else
            CalcWrapAngle(True, True)
            D = (90 - b - C) * (PI / 180)
            E = (D + 2 * C * (PI / 180))
            dShv = T1s + 0.5 * Math.Cos(D) * (T1s + 3 * T2s) + 0.5 * Math.Cos(E) * (T1s + T2s)
            dShh = 0.5 * Math.Sin(D) * (T1s + 3 * T2s) + 0.5 * Math.Sin(E) * (T1s + T2s)
        End If
        dShvLoad = Math.Sqrt(dShv ^ 2 + dShh ^ 2) / iRoping

    End Sub
    Private Sub TractionRatioNew()

        'calc the traction ratio
        '1/9/03 removed traction adder from the accel calculation per D.Kraft recommendation. TJC
        'WAS : dA1 = (dAccel + dTAdder) / 32.174
        dA1 = (dAccel) / 32.174
        dA2 = 1 + dA1
        dA3 = 1 - dA1
        dA9 = iRoping * dDSH + iRoping * dCSH
        dDUM = 1 + iRoping * dA1
        dDUMa = 1 - iRoping * dA1
        If Conversion.Val(MN_TRQ01_typ.CompSheaveJ) * Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
            dCompSH = 0
        Else
            dCompSH = Conversion.Val(MN_TRQ01_typ.CompSheaveJ) / (Conversion.Val(MN_TRQ01_typ.SheaveDiameter) / 24) ^ 2
        End If
        If Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia) * Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) = 0 Then
            dIdlerSH = 0
        Else
            dIdlerSH = Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia) / (Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) / 24) ^ 2
        End If
        'full car accelerating up at the top
        dT1 = dA2 * (dCarWeight + dCapacity + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt * (dRise + dXtraCCable) / 2) + dDUM * (dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * dIdlerSH * iRoping) + dW1 / 2 + dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dXCompChain / 2)) + dDUMa * (iRoping * dRise + dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * iRoping * (dCwtSH + dDSH + Ni * dIdlerSH) + dW1 / 2
        Traction(1) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(1) = "Full Car Accel Up at Top"
        'fullcar accelerting up at the bottom
        dT1 = dA2 * (dCarWeight + dCapacity + dCompWt * (dXCompChain / 2) + dCtrlCableWt * (dXtraCCable / 2)) + dDUM * (iRoping * dRise + dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * dIdlerSH * iRoping) + dW1 / 2 + dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dRise + dXCompChain / 2)) + dDUMa * (dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * iRoping * (dCwtSH + dDSH + Ni * dIdlerSH) + dW1 / 2
        Traction(2) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(2) = "Full Car Accel Up at Bottom"
        'empty car accelerating down at the top
        dT1 = dA3 * (dCarWeight + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt * (dRise + dXtraCCable) / 2) + dDUMa * (dXRope / 2) * dRWT
        dT1 = dT1 - (dA1 * 32.174) * iRoping * (Nc * dCSH1 + Ni * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA2 * (dCWT + dCompWt * (dXCompChain / 2)) + dDUM * (iRoping * dRise + dXRope / 2) * dRWT
        dT2 = dT2 + dA1 * 32.174 * (dCompSH + Ni * iRoping * dIdlerSH + iRoping * dCwtSH + iRoping * dDSH) + dW1 / 2
        Traction(3) = Conversion.Val(Strings.FormatNumber(dT2 / dT1, 3, TriState.True))
        TractionComment(3) = "Empty Car Accel Down at Top"
        'empty car accelerating down at the bottom
        dT1 = dA3 * (dCarWeight + dCompWt * (dXCompChain / 2) + dCtrlCableWt * (dXtraCCable / 2))
        dT1 += dDUMa * (iRoping * dRise + dXRope / 2) * dRWT
        dT1 = dT1 - (dA1 * 32.174) * iRoping * (Nc * dCSH1 + Ni * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA2 * (dCWT + dCompWt * (dRise + dXCompChain / 2)) + dDUM * (dXRope / 2) * dRWT
        dT2 = dT2 + (dA1 * 32.174) * (dCompSH + iRoping * (dCwtSH + dDSH + Ni * dIdlerSH)) + dW1 / 2
        Traction(4) = Conversion.Val(Strings.FormatNumber(dT2 / dT1, 3, TriState.True))
        TractionComment(4) = "Empty Car Accel Down at Bottom"
        'note: in accel/up and deccel/dn modes note that the equations do not change sign because accel/up +/+ = + and deccel/dn -/- = +. The
        '      same holds true for accel/dn and deccel/up in both cases of +/- and -/+ = -
        dA1 = dDecelTrac / 32.174
        dA2 = 1 + dA1
        dA3 = 1 - dA1
        dDUM = 1 + iRoping * dA1
        dDUMa = 1 - iRoping * dA1
        'full car decelerating down at the top
        dT1 = dA2 * (dCarWeight + dCapacity + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt * (dRise + dXtraCCable) / 2)
        dT1 += dDUM * (dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * iRoping * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dXCompChain / 2)) + dDUMa * (iRoping * dRise + dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * iRoping * (dCwtSH + dDSH + Ni * dIdlerSH) + dW1 / 2
        Traction(5) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(5) = "Full Car Decel Down at Top"
        'full car decelerating down at the bottom
        dT1 = dA2 * (dCarWeight + dCapacity + dCompWt * (dXCompChain / 2) + dCtrlCableWt * (dXtraCCable / 2))
        dT1 += dDUM * (iRoping * dRise + dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * iRoping * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dRise + dXCompChain / 2)) + dDUMa * (dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * (iRoping * (dCwtSH + dDSH + Ni * dIdlerSH)) + dW1 / 2
        Traction(6) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(6) = "Full Car Decel Down at Bottom"
        'empty car decelerating up at the top
        dT1 = dA3 * (dCarWeight + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt * (dRise + dXtraCCable) / 2)
        dT1 += dDUMa * (dXRope / 2) * dRWT
        dT1 = dT1 - (dA1 * 32.174) * iRoping * (Nc * dCSH1 + Ni * dIdlerSH) + dW1 / 2 + dFriction
        dT2 = dA2 * (dCWT + dCompWt * (dXCompChain / 2)) + dDUM * (iRoping * dRise + dXRope / 2) * dRWT
        dT2 = dT2 + (dA1 * 32.174) * (dCompSH + iRoping * (Ni * dIdlerSH + dCwtSH + dDSH)) + dW1 / 2
        Traction(7) = Conversion.Val(Strings.FormatNumber(dT2 / dT1, 3, TriState.True))
        TractionComment(7) = "Empty Car Decel Up at Top"
        'empty car decelerating up at the bottom
        dT1 = dA3 * (dCarWeight + dCompWt * (dXCompChain / 2) + dCtrlCableWt * (dXtraCCable / 2))
        dT1 += dDUMa * (iRoping * dRise + dXRope / 2) * dRWT
        dT1 = dT1 - (dA1 * 32.174) * iRoping * (Nc * dCSH1 + Ni * dIdlerSH) + dW1 / 2 + dFriction
        dT2 = dA2 * (dCWT + dCompWt * (dRise + dXCompChain / 2)) + dDUM * (dXRope / 2) * dRWT
        dT2 = dT2 + (dA1 * 32.174) * (dCompSH + iRoping * (dCwtSH + dDSH + Ni * dIdlerSH)) + dW1 / 2
        Traction(8) = Conversion.Val(Strings.FormatNumber(dT2 / dT1, 3, TriState.True))
        TractionComment(8) = "Empty Car Decel Up at Bottom"
        'for geared only
        dA1 = dDecel125 / 32.174
        dA2 = 1 + dA1
        dA3 = 1 - dA1
        dDUM = 1 + iRoping * dA1
        dDUMa = 1 - iRoping * dA1
        'Overloaded car decelerating down at the top
        dT1 = dA2 * (dCarWeight + 1.25 * dCapacity + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt * (dRise + dXtraCCable) / 2)
        dT1 += dDUM * (dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * iRoping * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dXCompChain / 2)) + dDUMa * (iRoping * dRise + dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * iRoping * (dCwtSH + dDSH + Ni * dIdlerSH) + dW1 / 2
        Traction(9) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(10) = "Overloaded Car Decel Down at Top"
        'Overloaded car decelerating down at the bottom
        dT1 = dA2 * (dCarWeight + 1.25 * dCapacity + dCompWt * (dXCompChain / 2) + dCtrlCableWt * (dXtraCCable / 2))
        dT1 += dDUM * (iRoping * dRise + dXRope / 2) * dRWT
        dT1 = dT1 + (dA1 * 32.174) * (Nc * dCSH1 * iRoping + dCompSH + Ni * iRoping * dIdlerSH) + dW1 / 2 - dFriction
        dT2 = dA3 * (dCWT + dCompWt * (dRise + dXCompChain / 2))
        dT2 += dDUMa * (dXRope / 2) * dRWT
        dT2 = dT2 - (dA1 * 32.174) * iRoping * (dCwtSH + dDSH + Ni * dIdlerSH) + dW1 / 2
        Traction(10) = Conversion.Val(Strings.FormatNumber(dT1 / dT2, 3, TriState.True))
        TractionComment(10) = "Overloaded Car Decel Down at Bottom"

    End Sub
    Public Function QuattroInternalTransformerIp() As Single
        Dim EP As Single = PowerSupply
        Dim Ip As Single = 0

        Select Case EP
            Case Is <= 208
                If E1 <= 380 Then
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 161
                        Case "Quattro-150"
                            Ip = 192
                        Case "Quattro-200"
                            Ip = 256
                        Case "Quattro-250"
                            Ip = 320
                        Case "Quattro-300"
                            Ip = 384
                        Case Else
                    End Select
                Else
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 203
                        Case "Quattro-150"
                            Ip = 242
                        Case "Quattro-200"
                            Ip = 322
                        Case "Quattro-250"
                            Ip = 403
                        Case "Quattro-300"
                            Ip = 484
                        Case Else
                    End Select
                End If
            Case Is <= 230
                If E1 <= 364 Then
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 146
                        Case "Quattro-150"
                            Ip = 173
                        Case "Quattro-200"
                            Ip = 231
                        Case "Quattro-250"
                            Ip = 289
                        Case "Quattro-300"
                            Ip = 347
                        Case Else
                    End Select
                Else
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 183
                        Case "Quattro-150"
                            Ip = 219
                        Case "Quattro-200"
                            Ip = 292
                        Case "Quattro-250"
                            Ip = 364
                        Case "Quattro-300"
                            Ip = 437
                        Case Else
                    End Select
                End If
            Case Is <= 240
                If E1 <= 380 Then
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 140
                        Case "Quattro-150"
                            Ip = 166
                        Case "Quattro-200"
                            Ip = 222
                        Case "Quattro-250"
                            Ip = 277
                        Case "Quattro-300"
                            Ip = 332
                        Case Else
                    End Select
                Else
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 176
                        Case "Quattro-150"
                            Ip = 210
                        Case "Quattro-200"
                            Ip = 279
                        Case "Quattro-250"
                            Ip = 349
                        Case "Quattro-300"
                            Ip = 419
                        Case Else
                    End Select
                End If
            Case Is <= 460
                If E1 <= 230 Then
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 92
                        Case "Quattro-150"
                            Ip = 109
                        Case "Quattro-200"
                            Ip = 146
                        Case "Quattro-250"
                            Ip = 182
                        Case "Quattro-300"
                            Ip = 219
                        Case Else
                    End Select
                Else
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 73
                        Case "Quattro-150"
                            Ip = 87
                        Case "Quattro-200"
                            Ip = 116
                        Case "Quattro-250"
                            Ip = 145
                        Case "Quattro-300"
                            Ip = 173
                        Case Else
                    End Select
                End If
            Case Is <= 480
                If E1 <= 240 Then
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 88
                        Case "Quattro-150"
                            Ip = 105
                        Case "Quattro-200"
                            Ip = 140
                        Case "Quattro-250"
                            Ip = 175
                        Case "Quattro-300"
                            Ip = 210
                        Case Else
                    End Select
                Else
                    Select Case MN_TRQ01_typ.DriveModel
                        Case "Quattro-125"
                            Ip = 70
                        Case "Quattro-150"
                            Ip = 83
                        Case "Quattro-200"
                            Ip = 111
                        Case "Quattro-250"
                            Ip = 138
                        Case "Quattro-300"
                            Ip = 166
                        Case Else
                    End Select
                End If
            Case Is <= 550
                Select Case E1
                    Case Is <= 220
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 38
                            Case "Quattro-150"
                                Ip = 46
                            Case "Quattro-200"
                                Ip = 61
                            Case "Quattro-250"
                                Ip = 77
                            Case "Quattro-300"
                                Ip = 91
                            Case Else
                        End Select
                    Case Is <= 363
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 61
                            Case "Quattro-150"
                                Ip = 73
                            Case "Quattro-200"
                                Ip = 97
                            Case "Quattro-250"
                                Ip = 121
                            Case "Quattro-300"
                                Ip = 145
                            Case Else
                        End Select
                    Case Else
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 77
                            Case "Quattro-150"
                                Ip = 91
                            Case "Quattro-200"
                                Ip = 122
                            Case "Quattro-250"
                                Ip = 152
                            Case "Quattro-300"
                                Ip = 183
                            Case Else
                        End Select
                End Select
            Case Is <= 575
                Select Case E1
                    Case Is <= 230
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 36
                            Case "Quattro-150"
                                Ip = 44
                            Case "Quattro-200"
                                Ip = 58
                            Case "Quattro-250"
                                Ip = 73
                            Case "Quattro-300"
                                Ip = 87
                            Case Else
                        End Select
                    Case Is <= 380
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 58
                            Case "Quattro-150"
                                Ip = 69
                            Case "Quattro-200"
                                Ip = 92
                            Case "Quattro-250"
                                Ip = 116
                            Case "Quattro-300"
                                Ip = 139
                            Case Else
                        End Select
                    Case Else
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 73
                            Case "Quattro-150"
                                Ip = 87
                            Case "Quattro-200"
                                Ip = 117
                            Case "Quattro-250"
                                Ip = 146
                            Case "Quattro-300"
                                Ip = 175
                            Case Else
                        End Select
                End Select
            Case Is <= 600
                Select Case E1
                    Case Is <= 150
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 22
                            Case "Quattro-150"
                                Ip = 26
                            Case "Quattro-200"
                                Ip = 35
                            Case "Quattro-250"
                                Ip = 43
                            Case "Quattro-300"
                                Ip = 52
                            Case Else
                        End Select
                    Case Is <= 240
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 35
                            Case "Quattro-150"
                                Ip = 42
                            Case "Quattro-200"
                                Ip = 56
                            Case "Quattro-250"
                                Ip = 70
                            Case "Quattro-300"
                                Ip = 84
                            Case Else
                        End Select
                    Case Else
                        Select Case MN_TRQ01_typ.DriveModel
                            Case "Quattro-125"
                                Ip = 56
                            Case "Quattro-150"
                                Ip = 66
                            Case "Quattro-200"
                                Ip = 89
                            Case "Quattro-250"
                                Ip = 111
                            Case "Quattro-300"
                                Ip = 133
                            Case Else
                        End Select
                End Select
            Case Else
        End Select
        Return Ip

    End Function
    Private Function DriveSelectionGEARLESS(ByRef bSSDC As Boolean) As String
        Dim result As String = String.Empty
        Dim sSQL As String = ""

        result = ""
        If MN_TRQ01_typ.DriveModel = "" Or MN_TRQ01_typ.DriveModelDefault = "" Or bMotorDependentChange Then
            sSQL = "[Drive Selection " & (IIf(bSSDC, "SSDC", "Quattro")) & "]"
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            Do While Not TorqueRecordset.EOF
                If TorqueRecordset("IDC1").Value >= Conversion.Val(IDC1) Then
                    If TorqueRecordset("IDC2").Value >= Conversion.Val(IDC2) Then
                        If Conversion.Val(IFF) < TorqueRecordset("IFFmin").Value Or Conversion.Val(IFF) > TorqueRecordset("IFFmax").Value Then
                            MN_TRQ01_typ.DriveModel = "IFF Error"
                        End If
                        MN_TRQ01_typ.DriveModelDefault = TorqueRecordset("Drive Selection").Value
                        If MN_TRQ01_typ.DriveModel = "" Or bMotorDependentChange Then
                            MN_TRQ01_typ.DriveModel = MN_TRQ01_typ.DriveModelDefault
                        End If
                        Exit Do
                    End If
                End If
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            If MN_TRQ01_typ.DriveModel = "IFF Error" Then
                If ControllerType = DRIVETYPE_SCRDC Then
                    MN_TRQ01_typ.DriveModelDefault = "DSD412-300"
                Else
                    MN_TRQ01_typ.DriveModelDefault = "Quattro-300"
                End If
                MN_TRQ01_typ.DriveModel = MN_TRQ01_typ.DriveModelDefault
            End If
        End If
        Return result

    End Function
    Private Function DriveSelection(ByRef dIrflu As Double, ByRef dIaflu As Double, ByRef dPreg As Double, ByRef bPF1 As Boolean) As String
        Dim result As String = String.Empty
        Dim bANSI, bCriteria As Boolean
        Dim sSQL As String = ""

        result = ""
        If MN_TRQ01_typ.DriveModel = "" Or MN_TRQ01_typ.DriveModelDefault = "" Or bMotorDependentChange Then
            sSQL = "SELECT * From [Drive Selection] WHERE ANSI=" & (IIf(bANSI, "True", "False")) & " ORDER BY Sequence"
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            Do While Not TorqueRecordset.EOF
                If TorqueRecordset("Irflu").Value >= dIrflu And TorqueRecordset("Drive Selection").Value.ToString <> "VF85BR" And
                   ((ControllerType = DRIVETYPE_BR And Strings.Right(TorqueRecordset("Drive Selection").Value.ToString, 2) = "BR") Or
                   (ControllerType = DRIVETYPE_PF1 And Strings.Right(TorqueRecordset("Drive Selection").Value.ToString, 3) = "PF1")) Then
                    If TorqueRecordset("Iaflu").Value >= dIaflu Then
                        bCriteria = False
                        If Right(TorqueRecordset("Drive Selection").Value, 3) = "PF1" Then
                            If TorqueRecordset("IDFLD").Value >= Math.Abs(Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD)) Then
                                bCriteria = True
                            End If
                        Else
                            If TorqueRecordset("Preg").Value >= dPreg / 1000 Then
                                bCriteria = True
                            End If
                        End If
                        If bCriteria Then
                            MN_TRQ01_typ.Required_KVA = CalculateTransformerKVA(TorqueRecordset("Required_KVA").Value) 'transformer KVA
                            dRequired_AMPS = 1000 * (MN_TRQ01_typ.Required_KVA + K3) / (3 ^ 0.5 * PowerSupply)
                            If MachineType = GEARED_TYPE Then
                                MN_PowerData_GEARED_typ.PeakCurrent = CStr(1000 * MN_TRQ01_typ.Required_KVA / (3 ^ 0.5 * PowerSupply) * 10)
                            End If
                            MN_TRQ01_typ.DriveModelDefault = TorqueRecordset("Drive Selection").Value
                            If MN_TRQ01_typ.DriveModel = "" Or bMotorDependentChange Then
                                MN_TRQ01_typ.DriveModel = MN_TRQ01_typ.DriveModelDefault
                            End If
                            TorqueRecordset.Close()
                            TorqueRecordset = Nothing
                            Return result
                        End If
                    End If
                End If
                TorqueRecordset.MoveNext()
            Loop
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            If Not String.IsNullOrEmpty(MN_TRQ01_typ.DriveModel) And Not String.IsNullOrEmpty(MN_TRQ01_typ.DriveModelDefault) Then
                MN_TRQ01_typ.DriveModel = "Error"
                result = "Error"
            End If
            dRequired_AMPS = 0
            MN_TRQ01_typ.Required_KVA = 0
            MN_PowerData_GEARED_typ.PeakCurrent = CStr(0)
        End If
        Return result

    End Function
    Private Function DriveSelectionValidation(ByRef dIrflu As Double, ByRef dIaflu As Double, ByRef dPreg As Double, ByRef bPF1 As Boolean) As String
        Dim result As String = String.Empty
        Dim bCriteria As Boolean
        Dim sSQL As String
        Dim bANSI As Boolean

        result = ""
        Select Case PowerSupply
            Case 460, 480
                dRequired_AMPS = 0
                MN_TRQ01_typ.Required_KVA = 0
                MN_PowerData_GEARED_typ.PeakCurrent = CStr(0)
            Case Else
                bANSI = Conversion.Val(CurrentGOData_Typ.ANSICode) >= 2000
                If MN_TRQ01_typ.DriveModel <> "" Then
                    sSQL = "SELECT * FROM [Drive Selection] WHERE [Drive Selection]='" & MN_TRQ01_typ.DriveModel & "' AND "
                    sSQL = sSQL & " [Drive Selection].ANSI=" & (IIf(bANSI, "True", "False"))
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        MN_TRQ01_typ.Required_KVA = CalculateTransformerKVA(TorqueRecordset("Required_KVA").Value) 'transformer KVA
                        dRequired_AMPS = 1000 * (MN_TRQ01_typ.Required_KVA + K3) / (3 ^ 0.5 * PowerSupply)
                        If MachineType = GEARED_TYPE Then
                            MN_PowerData_GEARED_typ.PeakCurrent = CStr(1000 * MN_TRQ01_typ.Required_KVA / (3 ^ 0.5 * PowerSupply) * 10)
                        End If
                        TorqueRecordset.Close()
                        TorqueRecordset = Nothing
                        Return result
                    End If
                End If
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
                sSQL = "SELECT * From [Drive Selection] WHERE ANSI=" & (IIf(bANSI, "True", "False"))
                TorqueRecordset.Open(sSQL, ADOConnection)
                Do While Not TorqueRecordset.EOF
                    If TorqueRecordset("Irflu").Value >= dIrflu Then
                        If TorqueRecordset("Iaflu").Value >= dIaflu Then
                            bCriteria = False
                            If bPF1 Then
                                If TorqueRecordset("IDFLD").Value >= Math.Abs(Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD)) Then
                                    bCriteria = True
                                End If
                            Else
                                If TorqueRecordset("Preg").Value >= dPreg / 1000 Then
                                    bCriteria = True
                                End If
                            End If
                            If bCriteria Then
                                MN_TRQ01_typ.Required_KVA = CalculateTransformerKVA(TorqueRecordset("Required_KVA").Value) 'transformer KVA
                                dRequired_AMPS = 1000 * (MN_TRQ01_typ.Required_KVA + K3) / (3 ^ 0.5 * PowerSupply)
                                If MachineType = GEARED_TYPE Then
                                    MN_PowerData_GEARED_typ.PeakCurrent = CStr(1000 * MN_TRQ01_typ.Required_KVA / (3 ^ 0.5 * PowerSupply) * 10)
                                End If
                                TorqueRecordset.Close()
                                TorqueRecordset = Nothing
                                Return result
                            End If
                        End If
                    End If
                    TorqueRecordset.MoveNext()
                Loop
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
                result = "Error"
                dRequired_AMPS = 0
                MN_TRQ01_typ.Required_KVA = 0
                If MachineType = GEARED_TYPE Then
                    MN_PowerData_GEARED_typ.PeakCurrent = CStr(0)
                End If
        End Select
        Return result

    End Function
    Private Function ReverseCalcWrapAngle() As Double
        Dim result As Double = 0
        Dim dOffset As Double = 0, k As Double = 0, U As Double = 0, dWAgiven As Double = 0, dWAcalculated As Double = 0
        Dim idY1 As Double = 0

        Try
            If Conversion.Val(MN_TRQ01_typ.RopeDrop) = 0 Or Conversion.Val(MN_TRQ01_typ.WrapAngle) <= 0 Then
                Return result
            End If
            dDsDia = HoistwaySheaveDiameter()
            dMsDia = Conversion.Val(MachineSheaveDiameter)
            dX1 = CDbl(MN_TRQ01_typ.RopeDrop) - (dDsDia + dMsDia) / 2
            MN_TRQ02_frm.X1_txt.BackColor = Color.White
            If dX1 <= 0 Then
                MN_TRQ01_typ.HorizontalDistance = CStr(dX1)
                MN_TRQ02_frm.X1_txt.BackColor = Color.Red
                Return result
            End If
            MN_TRQ01_typ.HorizontalDistance = CStr(dX1)
            dWAgiven = Conversion.Val(MN_TRQ01_typ.WrapAngle)
            dOffset = 300
            For idY1 = 0 To 300 Step 0.01
                b = Math.Atan(idY1 / dX1) * 180 / PI
                k = (dMsDia - dDsDia) / 2
                U = (dX1 ^ 2 + idY1 ^ 2) ^ 0.5
                If Math.Abs(U) > Math.Abs(k) Then
                    C = ArcSin(k / U) * 180 / PI
                    dWAcalculated = 270 + b + 3 * C
                    If dOffset > Math.Abs(dWAcalculated - dWAgiven) Then
                        dOffset = Math.Abs(dWAcalculated - dWAgiven)
                        If idY1 = 0 Then
                            result = 0.001
                        Else
                            result = idY1
                        End If
                    End If
                End If
            Next idY1
            dY1 = idY1
            Return result

        Catch

            If Information.Err().Number = 5 Then
                If Not bSkipWrapWarning Then
                    If HoistwaySheaveDiameter() = 0 Then
                        MN_TRQ01_typ.WrapAngle = "180"
                    Else
                        MN_TRQ01_typ.WrapAngle = "160"
                    End If
                End If
            Else
                MessageBox.Show(Conversion.ErrorToString(), "ReverseCalcWrapAngle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return result
        End Try
    End Function
    Public Function TransformerRequired() As String
        Dim sTransformerRequired As String = ""
        Dim dNamePlateDriveAmps As Double
        Dim bRatio As Boolean
        Dim EP As Single = PowerSupply

        Try
            Select Case ControllerType
                Case DRIVETYPE_BESTPRICE, DRIVETYPE_BR, DRIVETYPE_PF1
                    EP = Math.Round(MN_TRQ01_typ.UN / PowerSupply, 2)
            End Select
            Select Case ControllerType
                Case DRIVETYPE_SCRDC
                    sTransformerRequired = "Transformer Required"
                Case DRIVETYPE_QUATTRO
                    sTransformerRequired = "Transformer Not Required"
                    If EP > 480 * 1.1 Then
                        sTransformerRequired = "Step Down Transformer Required"
                    Else
                        bRatio = False
                        If Conversion.Val(VFLU) = 0 Then
                            bRatio = True
                        Else
                            If EP / Conversion.Val(VFLU) >= 2 Then
                                bRatio = True
                            End If
                        End If
                        If bRatio Then
                            sTransformerRequired = "Step Down Transformer Required"
                        Else
                            dNamePlateDriveAmps = 125
                            If Conversion.Val(IDC1) > 125 Then
                                dNamePlateDriveAmps = 300
                                For i As Integer = 150 To 250 Step 50
                                    If Conversion.Val(IDC1) < i Then
                                        dNamePlateDriveAmps = i
                                        Exit For
                                    End If
                                    'Must check for an Error if dNamePlateDriveAmps > 300
                                Next i
                            End If
                            If Conversion.Val(VFLU) * Conversion.Val(IDC1) * 0.92 / dNamePlateDriveAmps > EP Then
                                sTransformerRequired = "Step Up Transformer Required"
                            End If
                        End If
                    End If
            End Select

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "TransformerRequired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
        Return sTransformerRequired

    End Function
    Private Sub ValidatedFullHP()
        Dim sSQL As String = "SELECT * FROM [HP Limits] WHERE Manufacturer = '" & MachineVendor & "' AND MachineModel = '" & MachineModel & "'"

        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sSQL, ADOConnection)
        If Not TorqueRecordset.EOF Then
            If TorqueRecordset("HP Limitation").Value < dHPower Then
                iError(16) = 1
                strError(16) = "Calculated motor HP (" & Format(dHPower, "0.00") & ") exceeds the machine limitation (" & Format(TorqueRecordset("HP Limitation").Value, "0.00") & ")."
                g_bErrors = True
            End If
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        Dim T As String = ExtractMotorRPM(NominalMotorRPM)
        If T <> "" Then
            sSQL = "SELECT HP FROM [HP Criterias] WHERE Make = '" & MachineVendor & "' AND Model = '" & MachineModel & "' AND Machine = 'New' AND " &
                   "RPM= " & T & " ORDER BY HP"
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            If Not TorqueRecordset.EOF Then
                Do While Not TorqueRecordset.EOF
                    If TorqueRecordset("HP").Value >= dHPower Then
                        dHPowerRounded = TorqueRecordset("HP").Value
                        Exit Do
                    End If
                    TorqueRecordset.MoveNext()
                Loop
                If TorqueRecordset.EOF Then
                    iError(15) = 1
                    strError(15) = "You have to pick next RPM or larger Model."
                    g_bErrors = True
                End If
            End If
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
            If iError(15) = 1 Then Exit Sub
            T = ExtractMotorRPM(NominalMotorRPM)
            sSQL = "SELECT MinHP,MaxHP FROM [HP Nominal] WHERE Make = '" & MachineVendor & "' AND Model = '" & MachineModel & "' AND RPM=" & T
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            If Not TorqueRecordset.EOF Then
                If Not IsNothing(TorqueRecordset("MinHP").Value) And Not IsNothing(TorqueRecordset("MaxHP").Value) Then
                    If Math.Round(TorqueRecordset("MinHP").Value) > Math.Round(Conversion.Val(MN_TRQ01_typ.NominalMotorHP)) Or
                       Math.Round(TorqueRecordset("MaxHP").Value) < Math.Round(Conversion.Val(MN_TRQ01_typ.NominalMotorHP)) Then
                        iError(15) = 2
                        strError(15) = "Nominal Motor HP exceeds the available application limits of Quantum Leap."
                        g_bErrors = True
                    End If
                End If
            End If
            TorqueRecordset.Close()
            TorqueRecordset = Nothing
        End If

    End Sub
    Private Function ArcSin(ByRef X As Double) As Double
        Return Math.Atan(X / Math.Sqrt((-X) * X + 1))
    End Function
    Private Function ArcCos(ByRef X As Double) As Double
        Return Math.Atan((-X) / Math.Sqrt((-X) * X + 1)) + 2 * Math.Atan(1)
    End Function
    Public Sub TorqueMain(Optional ByRef bDisplay As Boolean = False)
        Dim sMsg As String = ""
        Dim AllowedDriveModels() As String = Nothing
        Dim FoundDriveModel As Boolean = False
        Dim iIndex As Integer = 0
        Dim CurMachineType As String = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineType_cmb")

        Try
            ResetADODBRecordset(CableRecordSet)
            CableRecordSet.Open("SELECT CableID,CableType,CableWeight,PartNumber, Use FROM CableWeight ORDER BY CableID", ADOConnection)
            Select Case GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "RopingNew_Cmb")
                Case "1:1 Single Wrap"
                    RopingNew = "1:1"
                    Wrap = "Single Wrap"
                Case "1:1 Dual Wrap"
                    RopingNew = "1:1"
                    Wrap = "Double Wrap"
                Case "2:1 Single Wrap"
                    RopingNew = "2:1"
                    Wrap = "Single Wrap"
                Case "2:1 Dual Wrap"
                    RopingNew = "2:1"
                    Wrap = "Double Wrap"
                Case "2:1 Underslung"
                    RopingNew = "2:1"
                    Wrap = "Underslung"
                Case Else
                    Exit Sub
            End Select
            Speed = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "SpeedNew_cmb"))
            Capacity = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CapacityNew_cmb"))
            MachineVendorExisting = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb")
            MachineModelExisting = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_Cmb")
            CarToCwtRopeDrop = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "CarToCwtRopeDrop_txt")
            Set_MachineVendorNew(CurMachineType)
            Set_MachineModelNew(CurMachineType)
            Mounting = String.Empty
            Select Case CurMachineType
                Case "Reuse " & GEARED_TYPE
                    MachineType = GEARED_TYPE
                    MachineVendor = MachineVendorExisting
                    MachineModel = MachineModelExisting
                    Mounting = GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_ReuseGearedMachineACMotorOnly, MAT_ID_ACMotorRGD)
                Case "New " & GEARED_TYPE
                    MachineType = GEARED_TYPE
                    MachineVendor = MN_TRQ01_typ.MachineVendorNew
                    MachineModel = MN_TRQ01_typ.MachineModelNew
                    Mounting = GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_NewGearedMachine, MAT_ID_ACMotorNGD)
                Case "Reuse " & GEARLESS_TYPE
                    MachineType = GEARLESS_TYPE
                    MachineVendor = MachineVendorExisting
                    MachineModel = MachineModelExisting
                Case "New " & GEARLESS_TYPE
                    MachineType = GEARLESS_TYPE
                    MachineVendor = MN_TRQ01_typ.MachineVendorNew
                    MachineModel = MN_TRQ01_typ.MachineModelNew
                Case MACHINE_FMM200
                    MachineType = GEARLESS_TYPE
                    MachineVendor = MN_TRQ01_typ.MachineVendorNew
                    MachineModel = MN_TRQ01_typ.MachineModelNew
                Case Else
                    Exit Sub
            End Select
            If Not String.IsNullOrEmpty(Mounting) Then
                If Mounting.IndexOf("Foot") > -1 Then
                    Mounting = "Foot-Mounted"
                ElseIf Mounting.IndexOf("Flange") > -1 Then
                    Mounting = "Flange"
                End If
            End If
            Select Case GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "DriveType_cmb")
                Case AC_TYPE
                    ControllerType = DRIVETYPE_BR
                Case AC_REGEN_TYPE
                    ControllerType = DRIVETYPE_PF1
                Case QUATTRO_TYPE
                    ControllerType = DRIVETYPE_QUATTRO
                Case DC_TYPE
                    ControllerType = DRIVETYPE_SCRDC
                Case Else
                    Exit Sub
            End Select
            PowerSupply = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PowerSupply_cmb")
            Travel = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "TravelNew_txt"))
            TopOfCarSheave = GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_CarItems, MAT_ID_CarSheaveAttachmentandGuard)
            CarSheaveQty = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "CarSheaveQty_Cmb"))
            InitializeTorqueCollections()
            MachineLocation = GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "MachineLocation_Cmb")
            HoistRopeSize = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "HoistRopeSize_Cmb")
            HoistRopeQty = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "HoistRopeQty_Cmb")
            NominalMotorRPM = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "NominalMotorRPM_txt")
            BrakeType = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "BrakeType_cmb")
            MachineSheaveDiameter = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "ExistingMachineSheaveDia_cmb")
            If CurMachineType = "New " & GEARED_TYPE Then
                HoistwaySheave = GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_NewGearedMachine, MAT_ID_DeflectorSheaves)
            ElseIf CurMachineType = "New " & GEARLESS_TYPE Then
                HoistwaySheave = GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_NewGearlessMachine, MAT_ID_MachineFrameandSecondarySheave)
            Else
                HoistwaySheave = "None"
            End If
            ControllerVendor = GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_Controller, MAT_ID_Controller)
            Compensation = GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "Compensation_cmb")
            CompensationType = "Rope"
            If GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_WhisperFlex) = "New" Then
                CompensationType = "WhisperFlex"
            End If
            CompSheave = GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_PIT, MAT_ID_CompensationSheave)

            CriticalErrorCounter = 0
            If MachineType = GEARLESS_TYPE And (ControllerType = DRIVETYPE_PF1 Or ControllerType = DRIVETYPE_BR Or ControllerType = DRIVETYPE_BESTPRICE) Then
                If MN_TRQ01_typ.Counterweight = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.Counterweight = "43"
                End If
                If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_525LS Then
                    ReDim AllowedDriveModels(1)
                    AllowedDriveModels(1) = "VF88PF1"
                Else
                    ReDim AllowedDriveModels(4)
                    Select Case ControllerType
                        Case DRIVETYPE_PF1
                            AllowedDriveModels(1) = "VF55PF1"
                            AllowedDriveModels(2) = "VF88PF1"
                            AllowedDriveModels(3) = "VF155PF1"
                            AllowedDriveModels(4) = "VF288PF1"
                        Case DRIVETYPE_BR
                            ReDim AllowedDriveModels(4)
                            AllowedDriveModels(1) = "VF33BR"
                            AllowedDriveModels(2) = "VF44BR"
                            AllowedDriveModels(3) = "VF85BR"
                            AllowedDriveModels(4) = "VF122BR"
                        Case Else
                    End Select
                End If
                If AllowedDriveModels.GetUpperBound(0) > 0 Then
                    For iIndex = 1 To AllowedDriveModels.GetUpperBound(0)
                        If MN_TRQ01_typ.DriveModel = AllowedDriveModels(iIndex) Then
                            FoundDriveModel = True
                            Exit For
                        End If
                    Next iIndex
                    If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_525LS Then
                        MN_TRQ01_typ.DriveModelDefault = "VF88PF1"
                    ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_PMR490 And ControllerType = DRIVETYPE_PF1 Then
                        MN_TRQ01_typ.DriveModelDefault = "VF155PF1"
                    ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMR355 And ControllerType = DRIVETYPE_PF1 Then
                        MN_TRQ01_typ.DriveModelDefault = "VF288PF1"
                    ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_PMR355 And ControllerType = DRIVETYPE_BR Then
                        MN_TRQ01_typ.DriveModelDefault = "VF122BR"
                    ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FM630 And ControllerType = DRIVETYPE_BR Then
                        MN_TRQ01_typ.DriveModelDefault = "VF122BR"
                    Else
                        iIndex = AllowedDriveModels.GetUpperBound(0)
                        MN_TRQ01_typ.DriveModelDefault = AllowedDriveModels(iIndex)
                    End If
                    If Not FoundDriveModel Then
                        If MN_TRQ02_typ.FormIsCompleted And ENG_ACCESS Then
                            MsgBox("Changed Drive Model from " & MN_TRQ01_typ.DriveModel & " to " & MN_TRQ01_typ.DriveModelDefault,
                                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ENG: Reset Drive Model to default value")
                        End If
                        MN_TRQ01_typ.DriveModel = MN_TRQ01_typ.DriveModelDefault
                    End If
                End If
                MN_TRQ01_typ.Required_KVA = CalculateTransformerKVA(MN_TRQ01_typ.Required_KVA)
            Else
                If Not MN_TRQ02_typ.FormIsCompleted Or MN_TRQ01_typ.bDirty Then
                    PreTorque()
                End If
                CalculateTORQUE()
                Torque2DebugFile()
            End If

        Catch
            MessageBox.Show(Information.Err().Number.ToString() & Conversion.ErrorToString() & " Error Occurred in module: TorqueCalc.bas, function: TorqueMain", Application.ProductName)
            CriticalErrorCounter = 1

        End Try

    End Sub
    Public Sub PreTorque()
        Dim tempIdlerSheaveDiameter, tempNominalMotorRPM As String
        Dim TempRopeSplayKitMounting As String = MN_TRQ01_typ.RopeSplayKitMounting

        Try
            If MachineType = GEARLESS_TYPE And (ControllerType = DRIVETYPE_PF1 Or ControllerType = DRIVETYPE_BR Or ControllerType = DRIVETYPE_BESTPRICE) Then
                Exit Sub
            End If
            If MN_TRQ01_typ.bDirty Then
                tempNominalMotorRPM = NominalMotorRPM
                MN_TRQ01_typ = MN_TRQ01_typDec.CreateInstance()
                NominalMotorRPM = tempNominalMotorRPM
                MN_TRQ01_typ.bDirty = True
                MN_TRQ01_typ.RopeSplayKitMounting = TempRopeSplayKitMounting
                If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
                    If Math.Round(PowerSupply) = 460 Or Math.Round(PowerSupply) = 480 Then
                        MN_TRQ01_typ.Required_KVA = 0
                    Else
                        MN_TRQ01_typ.Required_KVA = Math.Round(GetFMM200Value("KVAd"), 2)
                    End If
                Else
                    MN_TRQ01_typ.Required_KVA = -999.99
                End If
            End If
            Set_CarWeight()
            Set_CarSheaveDiameter()
            Set_CarSheaveJ()
            If Conversion.Val(MN_TRQ01_typ.NumberofCarTopSheaves) = 0 Or MN_TRQ01_typ.bDirty Then
                If CarSheaveQty = 0 Then
                    MN_TRQ01_typ.NumberofCarTopSheaves = 2
                Else
                    MN_TRQ01_typ.NumberofCarTopSheaves = CarSheaveQty
                End If
            End If
            Set_CwtSheaveDiameter()
            Set_CwtSheaveJ()
            If MachineLocation = "Basement" Or MachineLocation = "Semi-Basement" Then
                If MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) = 0 Then
                    tempIdlerSheaveDiameter = CStr(Conversion.Val(TranslateRopeSize(HoistRopeSize, True)) * 40)
                    If (tempIdlerSheaveDiameter) > 26 Then
                        MN_TRQ01_typ.IdlerSheaveDiameter = "30"
                    ElseIf (tempIdlerSheaveDiameter) > 25 Then
                        MN_TRQ01_typ.IdlerSheaveDiameter = "26"
                    ElseIf (tempIdlerSheaveDiameter) > 20 Then
                        MN_TRQ01_typ.IdlerSheaveDiameter = "25"
                    Else
                        MN_TRQ01_typ.IdlerSheaveDiameter = "20"
                    End If
                End If
                Set_OverheadSheaveInertia()
                If Conversion.Val(MN_TRQ01_typ.NumberofIdlerSheaves) = 0 Then
                    MN_TRQ01_typ.NumberofIdlerSheaves = 4
                End If
            Else
                MN_TRQ01_typ.IdlerSheaveDiameter = ""
                MN_TRQ01_typ.NumberofIdlerSheaves = ""
                MN_TRQ01_typ.OverheadSheaveInertia = ""
            End If
            If MN_TRQ01_typ.Counterweight = "" Or MN_TRQ01_typ.bDirty Then
                If MachineType = GEARED_TYPE Then
                    MN_TRQ01_typ.Counterweight = "40"
                Else
                    MN_TRQ01_typ.Counterweight = "43"
                End If
            End If
            Set_GrooveNumber()
            UpdateGearData()
            If MN_TRQ01_typ.MachineModelNew = MACHINE_FMM200 Then
                MN_TRQ01_typ.GearRation1 = String.Empty
                MN_TRQ01_typ.GearRation2 = String.Empty
            End If
            If MN_TRQ01_typ.MainTravelingCable = "" Then
                Set_MainTravelingCable()
            End If
            If MN_TRQ01_typ.MainTravelingCableQty = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.MainTravelingCableQty = "1"
            End If
            Set_ControlCableWeight()
            Set_RopeStrength()
            If MN_TRQ01_typ.SheaveDiameter = "" Or MN_TRQ01_typ.bDirty Then
                Set_CompensationSheaveDiameter()
            End If
            Set_CompSheaveJandWt()
            If Conversion.Val(MN_TRQ02_typ.CompensationWeight) = 0 Or MN_TRQ01_typ.bDirty Then
                If (Compensation = "Reuse" Or Compensation = "Relocate") And MN_TRQ02_typ.CompensationSize = "Unknown" Then
                    Set_RopeStrength()
                    dRWT = Conversion.Val(HoistRopeQty) * Conversion.Val(MN_TRQ01_typ.RopeWeight)
                    If RopingNew = "2:1" Then
                        iRoping = 2
                    Else
                        iRoping = 1
                    End If
                    dIdealCompWeight = iRoping * dRWT - Conversion.Val(MN_TRQ01_typ.ControlCableWeight) / 4
                    MN_TRQ02_typ.CompensationWeight = Strings.FormatNumber(dIdealCompWeight / 2, 3, TriState.True)
                Else
                    Set_CompUnitWeight()
                    MN_TRQ02_typ.CompensationWeight = Conversion.Val(MN_TRQ01_typ.CompensationQty) * Conversion.Val(MN_TRQ02_typ.CompensationUnitWeight)
                End If
            End If
            If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Or MN_TRQ01_typ.bDirty Then
                Set_WrapAngle()
            End If
            Calc_GeneralData()
            If MN_TRQ01_typ.HatchEfficiency = "" Or MN_TRQ01_typ.bDirty Then
                InitHatchEff()
            End If
            If MachineType = GEARED_TYPE Then
                If MN_TRQ01_typ.len1 = "" Or MN_TRQ01_typ.bDirty Then
                    If RopingNew = "1:1" Then
                        MN_TRQ01_typ.len1 = "30"
                    Else
                        MN_TRQ01_typ.len1 = "40"
                    End If
                End If
                If MN_TRQ01_typ.len2 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.len2 = "30"
                End If
                If MN_TRQ01_typ.len3 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.len3 = "3"
                End If
            Else
                If MN_TRQ01_typ.len1 = "" Or MN_TRQ01_typ.bDirty Then
                    If RopingNew = "1:1" Then
                        MN_TRQ01_typ.len1 = "60"
                    Else
                        MN_TRQ01_typ.len1 = "80"
                    End If
                End If
                If MN_TRQ01_typ.len2 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.len2 = "30"
                End If
                If MN_TRQ01_typ.len3 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.len3 = "12"
                End If
            End If
            If MN_TRQ01_typ.RopeGrade = "" Or MN_TRQ01_typ.bDirty Then
                If TranslateRopeSize(HoistRopeSize, True) < 0.5 Then
                    MN_TRQ01_typ.RopeGrade = "EHS"
                Else
                    MN_TRQ01_typ.RopeGrade = "Traction Steel"
                End If
            End If
            If MN_TRQ01_typ.DeflectorSheaveDiameter = "" Or MN_TRQ01_typ.bDirty Then
                If HoistwaySheave <> "None" And MachineModel <> MACHINE_FMM200 Then
                    If MachineType = GEARED_TYPE Then
                        MN_TRQ01_typ.DeflectorSheaveDiameter = HoistwaySheaveDiameter()
                    Else
                        Select Case HoistwaySheave
                            Case "Reuse", "Regroove", "Relocate"
                                MN_TRQ01_typ.DeflectorSheaveDiameter = MachineSheaveDiameter
                            Case "New", "Replace"
                                MN_TRQ01_typ.DeflectorSheaveDiameter = HoistwaySheaveDiameter()
                        End Select
                    End If
                    Set_DeflectorSheaveJ()
                Else
                    MN_TRQ01_typ.DeflectorSheaveDiameter = ""
                    MN_TRQ01_typ.DeflectorSheaveJ = ""
                    DeflectorSheaveJdefault = ""
                End If
            Else
                If HoistwaySheave <> "None" And MachineModel <> MACHINE_FMM200 Then
                    If DeflectorSheaveJdefault = "" Or MN_TRQ01_typ.DeflectorSheaveJ = "" Then
                        Set_DeflectorSheaveJ()
                    End If
                Else
                    MN_TRQ01_typ.DeflectorSheaveDiameter = ""
                    MN_TRQ01_typ.DeflectorSheaveJ = ""
                    DeflectorSheaveJdefault = ""
                End If
            End If
            MN_TRQ01_typ.bDirty = False

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "PreTorque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Private Sub UpdateGearData()
        Dim sSQL As String = ""
        Dim sWhere As String = ""
        Dim sOrderBy As String = ""
        Dim bCriteria As Boolean = False
        Dim bPretend As Boolean = False
        Dim HSSInertiaAdder As Single = 0
        Dim i As Integer = 0

        ReDim aMachineData(0)
        MN_TRQ01_typ.bSuperTable = True
        MN_TRQ01_typ.MotorRPM = Conversion.Val(Conversion.Val(ExtractMotorRPM(NominalMotorRPM)))
        Select Case MachineModel
            Case "18"
                HSSInertiaAdder = 0.0468
            Case "28"
                HSSInertiaAdder = 0.0426
            Case "37", "57"
                HSSInertiaAdder = 0.0407
            Case "38"
                HSSInertiaAdder = 0.0432
            Case "58"
                HSSInertiaAdder = 0.032
            Case "61"
                HSSInertiaAdder = 0.0471
            Case "HW43/44"
                If BrakeType = "Drum" Then
                    HSSInertiaAdder = -0.0019
                Else
                    HSSInertiaAdder = 0.0184
                End If
            Case "HW53/54"
                If BrakeType = "Drum" Then
                    HSSInertiaAdder = 0.0375
                Else
                    HSSInertiaAdder = 0.0184
                End If
            Case "HW63/64"
                If BrakeType = "Drum" Then
                    HSSInertiaAdder = 0.0375
                Else
                    HSSInertiaAdder = 0.0229
                End If
            Case "HW74"
                If BrakeType = "Drum" Then
                    HSSInertiaAdder = 0.0003
                Else
                    HSSInertiaAdder = 0.0229
                End If
            Case Else
                HSSInertiaAdder = 0
        End Select
        If MachineModel = "Other" Then
lbl_OTHER:
            MN_TRQ01_typ.bSuperTable = False
            aMachineData(0).MachineSheaveJ = ""
            If MachineType = GEARED_TYPE Then
                aMachineData(0).GearRatio1 = ""
                aMachineData(0).GearRatio2 = ""
                aMachineData(0).ForwardGearEfficiency = "0.65"
                aMachineData(0).ReverseGearEfficiency = "0.55"
            Else
                aMachineData(0).GearRatio1 = "1"
                aMachineData(0).GearRatio2 = "1:1"
                aMachineData(0).ForwardGearEfficiency = "0.98"
                aMachineData(0).ReverseGearEfficiency = "0.98"
            End If
            If MachineType = GEARED_TYPE Then
                If BrakeType = "Disk" Or bPretend Then
                    sSQL = "SELECT DISTINCT [HSS Inertia] From SuperTable "
                    If MachineModel = OTHER Or MachineModel = "" Then
                        If MachineVendor = OTHER Or MachineVendor = "" Then
                            Select Case RopingNew
                                Case "1:1"
                                    If Capacity <= 2000 Then
                                        aMachineData(0).HiSpeedShaftInertia = "0.087"
                                    ElseIf Capacity > 4000 Then
                                        aMachineData(0).HiSpeedShaftInertia = "0.214"
                                    Else
                                        aMachineData(0).HiSpeedShaftInertia = "0.112"
                                    End If
                                Case Else
                                    If Capacity <= 4000 Then
                                        aMachineData(0).HiSpeedShaftInertia = "0.087"
                                    ElseIf Capacity > 8000 Then
                                        aMachineData(0).HiSpeedShaftInertia = "0.214"
                                    Else
                                        aMachineData(0).HiSpeedShaftInertia = "0.112"
                                    End If
                            End Select
                        Else
                            sWhere = "WHERE Manufacturer='" & MachineVendor & "' "
                        End If
                    Else
                        If BrakeType = "Disk" Then
                            sWhere = "WHERE [Brake Drum/Disk]=2 AND Manufacturer='" & MachineVendor & "' AND MachineModel='" & MachineModel & "'"
                        Else
                            sWhere = "WHERE [Brake Drum/Disk]=1 AND Manufacturer='" & MachineVendor & "' AND MachineModel='" & MachineModel & "'"
                        End If
                    End If
                    sSQL = sSQL & sWhere & " ORDER BY [HSS Inertia] DESC;"
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        Select Case TorqueRecordset("HSS Inertia").Value
                            Case 1
                                aMachineData(0).HiSpeedShaftInertia = "0.2571"
                            Case 2
                                aMachineData(0).HiSpeedShaftInertia = "0.6405"
                            Case 3
                                aMachineData(0).HiSpeedShaftInertia = "1.3251"
                            Case 4
                                aMachineData(0).HiSpeedShaftInertia = "3.234"
                            Case Else
                                aMachineData(0).HiSpeedShaftInertia = TorqueRecordset("HSS Inertia").Value
                        End Select
                        aMachineData(0).HiSpeedShaftInertia = CStr(Math.Round(CDbl(Conversion.Val(aMachineData(0).HiSpeedShaftInertia) + HSSInertiaAdder), 4))
                    End If
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                Else
                    Select Case RopingNew
                        Case "1:1"
                            If Capacity <= 4500 Then
                                aMachineData(0).HiSpeedShaftInertia = "0.6405"
                            ElseIf Capacity > 6000 Then
                                aMachineData(0).HiSpeedShaftInertia = "3.2340"
                            Else
                                aMachineData(0).HiSpeedShaftInertia = "1.3251"
                            End If
                        Case "2:1"
                            If Capacity <= 9000 Then
                                aMachineData(0).HiSpeedShaftInertia = "0.6405"
                            ElseIf Capacity > 12000 Then
                                aMachineData(0).HiSpeedShaftInertia = "3.2340"
                            Else
                                aMachineData(0).HiSpeedShaftInertia = "1.3251"
                            End If
                    End Select
                    aMachineData(0).HiSpeedShaftInertia = CStr(Math.Round(CDbl(Conversion.Val(aMachineData(0).HiSpeedShaftInertia) + HSSInertiaAdder), 4))
                End If
                aMachineData(0).MaxShaftSheaveLoad = ""
                bCriteria = True
                If MachineModel <> OTHER Then
                    sSQL = "SELECT [Std Susp Ld] From SuperTable GROUP BY MachineModel, Manufacturer, [Std Susp Ld] " & "HAVING MachineModel='" &
                           MachineModel & "' AND Manufacturer='" & MachineVendor & "'"
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        aMachineData(0).MaxShaftSheaveLoad = TorqueRecordset("Std Susp Ld").Value.ToString
                    End If
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                    sSQL = "SELECT [Machine Inertia] From SuperTable GROUP BY MachineModel, Manufacturer, [Machine Inertia] " & "HAVING MachineModel='" &
                           MachineModel & "' AND Manufacturer='" & MachineVendor & "'"
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        If TorqueRecordset.RecordCount = 1 Then
                            If IsDBNull(TorqueRecordset("Machine Inertia").Value) Then
                                aMachineData(0).MachineSheaveJ = String.Empty
                            Else
                                aMachineData(0).MachineSheaveJ = TorqueRecordset("Machine Inertia").Value
                            End If
                            bCriteria = False
                        End If
                    End If
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                End If
                If bCriteria Then
                    If Conversion.Val(MachineSheaveDiameter) <= 30 Then
                        aMachineData(0).MachineSheaveJ = CStr(17)
                    Else
                        aMachineData(0).MachineSheaveJ = CStr(IIf(Conversion.Val(MachineSheaveDiameter) > 36, 68, 34))
                    End If
                End If
                aMachineData(0).GearRatio1 = Format(MN_TRQ01_typ.MotorRPM * 2 * PI * (Conversion.Val(MachineSheaveDiameter) / 24) / (Speed * Conversion.Val(Strings.Left(RopingNew, 1))), "0.####")
            Else
                sSQL = "SELECT SuperTable.[Machine Inertia], SuperTable.[Std Susp Ld], SuperTable.HP FROM SuperTable "
                sSQL &= "WHERE SuperTable.MachineType='" & GEARLESS_TYPE & "' AND SuperTable.Roping=" & Strings.Left(RopingNew, 1)
                sSQL &= " AND CStr('' & [SuperTable].[Speed])='" & CStr(Speed) & "' AND SuperTable.Wrap=" & CStr(IIf(Wrap = "Single Wrap", 1, 2))
                sSQL &= " AND SuperTable.Capacity=" & CStr(Capacity)
                ResetADODBRecordset(TorqueRecordset)
                TorqueRecordset.Open(sSQL, ADOConnection)
                If Not TorqueRecordset.EOF Then
                    If TorqueRecordset("Machine Inertia").ToString = "System.__ComObject" Then
                        aMachineData(0).MachineSheaveJ = ""
                    Else
                        aMachineData(0).MachineSheaveJ = Format(TorqueRecordset("Machine Inertia").Value, "0.####")
                    End If
                    If TorqueRecordset("Std Susp Ld").ToString = "System.__ComObject" Then
                        aMachineData(0).MaxShaftSheaveLoad = ""
                    Else
                        aMachineData(0).MaxShaftSheaveLoad = "" & TorqueRecordset("Std Susp Ld").Value
                    End If
                Else
                    sSQL = "SELECT [Std Susp Ld], [Machine Inertia] From SuperTable "
                    sSQL &= "GROUP BY Manufacturer, MachineModel, MachineType, [Std Susp Ld], [Machine Inertia] "
                    sSQL &= "HAVING Manufacturer='" & MachineVendor & "' AND MachineModel = '" & MachineModel & "' AND "
                    sSQL &= "MachineType='Gearless'"
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open(sSQL, ADOConnection)
                    If Not TorqueRecordset.EOF Then
                        If TorqueRecordset("Machine Inertia").ToString = "System.__ComObject" Then
                            aMachineData(0).MachineSheaveJ = ""
                        Else
                            aMachineData(0).MachineSheaveJ = Format(TorqueRecordset("Machine Inertia").Value, "0.###")
                        End If
                        If TorqueRecordset("Std Susp Ld").ToString = "System.__ComObject" Then
                            aMachineData(0).MaxShaftSheaveLoad = ""
                        Else
                            aMachineData(0).MaxShaftSheaveLoad = "" & TorqueRecordset("Std Susp Ld").Value
                        End If
                    End If
                End If
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
                If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_525LS Then
                    aMachineData(0).MaxShaftSheaveLoad = 22000
                End If
            End If
            Set_DeflectorSheaveJ()
            If MN_TRQ01_typ.MachineSheaveJ = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.MachineSheaveJ = aMachineData(0).MachineSheaveJ
            End If
            If MN_TRQ01_typ.GearRation1 = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.GearRation1 = aMachineData(0).GearRatio1
            End If
            If MN_TRQ01_typ.GearRation2 = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.GearRation2 = aMachineData(0).GearRatio2
            End If
            If MN_TRQ01_typ.ForwardGearEfficiency = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.ForwardGearEfficiency = aMachineData(0).ForwardGearEfficiency
            End If
            If MN_TRQ01_typ.ReverseGearEfficiency = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.ReverseGearEfficiency = aMachineData(0).ReverseGearEfficiency
            End If
            If MN_TRQ01_typ.HiSpeedShaftInertia = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.HiSpeedShaftInertia = aMachineData(0).HiSpeedShaftInertia
            End If
            If MN_TRQ01_typ.MaxShaftSheaveLoad = "" Or MN_TRQ01_typ.bDirty Then
                MN_TRQ01_typ.MaxShaftSheaveLoad = aMachineData(0).MaxShaftSheaveLoad
            End If
        ElseIf MachineModel <> "" And Speed <> 0 And (ExtractMotorRPM(NominalMotorRPM) <> "" Or MachineType = GEARLESS_TYPE) And RopingNew <> "" Then
            If Strings.Left(MachineModel, 3) = GTE Then
                sSQL = "SELECT DISTINCT IIf([Default]='',0,[Default]), SuperTable.MachineModel, SuperTable.[Machine Inertia], SuperTable.[Sheave Dia], "
                sSQL &= "SuperTable.[Std Susp Ld], SuperTable.[Worm Wheel], SuperTable.[Worm Thread], SuperTable.[Actual FGE], SuperTable.[Actual RGE], "
                sSQL &= "SuperTable.[Brake Drum/Disk], SuperTable.[HSS Inertia], SuperTable.Wrap " & "FROM SuperTable "
                sSQL &= "GROUP BY IIf([Default]='',0,[Default]), SuperTable.MachineModel, SuperTable.[Machine Inertia], SuperTable.[Sheave Dia], "
                sSQL &= "SuperTable.[Std Susp Ld], SuperTable.[Worm Wheel], SuperTable.[Worm Thread], SuperTable.[Actual FGE], SuperTable.[Actual RGE], "
                sSQL &= "SuperTable.[Brake Drum/Disk], SuperTable.[HSS Inertia], SuperTable.Wrap, CStr([SuperTable].[Speed]), SuperTable.Roping "
                sSQL &= "HAVING " & "SuperTable.MachineModel='" & MachineModel & "' AND " & "SuperTable.Wrap=" & CStr(IIf(Wrap = "Single Wrap", 1, 2))
                sSQL &= " AND " & "CStr([SuperTable].[Speed])='" & CStr(Speed) & "' AND " & "SuperTable.Roping=" & Strings.Left(RopingNew, 1)
                ResetADODBRecordset(TorqueRecordset)
                TorqueRecordset.Open(sSQL, ADOConnection)
            Else
                If MachineVendor = "Westinghouse" And MachineType = GEARLESS_TYPE Then
                    sSQL = "SELECT DISTINCT IIf([Default]='',0,[Default]), MachineModel, [Machine Inertia], [Sheave Dia], [Std Susp Ld], [Worm Wheel], "
                    sSQL &= "[Worm Thread], [Actual FGE], [Actual RGE], [Brake Drum/Disk], [HSS Inertia], HP, Wrap, Roping, Capacity FROM SuperTable "
                    sSQL &= "WHERE " & "MachineModel='" & MachineModel & "' AND "
                    sSQL &= (IIf(MachineType = GEARLESS_TYPE, "SuperTable.Wrap=" & (IIf(Wrap = "Single Wrap", 1, 2)) & " AND ", ""))
                    sSQL &= "CStr('' &  [SuperTable].[Speed])='" & CStr(Speed) & "' AND "
                    sSQL &= (IIf(MachineType = GEARLESS_TYPE, "", "SuperTable.RPM=" & ExtractMotorRPM(NominalMotorRPM) & " AND "))
                    sSQL &= "SuperTable.Capacity=" & CStr(Capacity) & " AND " & "SuperTable.Roping=" & Strings.Left(RopingNew, 1)
                Else
                    sSQL = "SELECT DISTINCT IIf([Default]='',0,[Default]), MachineModel, [Machine Inertia], [Sheave Dia], [Std Susp Ld], [Worm Wheel], "
                    sSQL &= "[Worm Thread], [Actual FGE], [Actual RGE], [Brake Drum/Disk], [HSS Inertia], HP, Wrap, Roping, Capacity FROM SuperTable "
                    sSQL &= "WHERE " & "MachineModel='" & MachineModel & "' AND "
                    sSQL &= (IIf(MachineType = GEARLESS_TYPE, "SuperTable.Wrap=" & (IIf(Wrap = "Single Wrap", 1, 2)) & " AND ", ""))
                    sSQL &= "CStr('' & [SuperTable].[Speed])='" & CStr(Speed) & "' AND SuperTable.[Sheave Dia]="
                    sSQL &= CStr(Conversion.Val(MachineSheaveDiameter)) & " AND "
                    sSQL &= (IIf(MachineType = GEARLESS_TYPE, "", "SuperTable.RPM=" & ExtractMotorRPM(NominalMotorRPM) & " AND "))
                    sSQL &= "SuperTable.Roping=" & Strings.Left(RopingNew, 1)
                End If
                sOrderBy = " ORDER BY IIf([Default]='',0,[Default]) DESC;"
                ResetADODBRecordset(TorqueRecordset)
                TorqueRecordset.Open(sSQL & sOrderBy, ADOConnection)
            End If
            If Not TorqueRecordset.EOF Then
                Do While Not TorqueRecordset.EOF
                    bCriteria = BrakeType = "Disk" And TorqueRecordset("Brake Drum/Disk").Value = 2
                    If Not bCriteria Then
                        If BrakeType = "Drum" Then
                            If MachineType = GEARLESS_TYPE Then bCriteria = True
                            If Not bCriteria Then
                                bCriteria = BrakeType = "Drum" And TorqueRecordset("Brake Drum/Disk").Value = 1
                            End If
                        End If
                    End If
                    If bCriteria Then
                        ReDim Preserve aMachineData(i)
                        If MachineType = GEARED_TYPE Then
                            aMachineData(i).GearRatio2 = TorqueRecordset("Worm Wheel").Value & ":" & TorqueRecordset("Worm Thread").Value
                            aMachineData(i).GearRatio1 = ""
                            If TorqueRecordset("Worm Thread").Value > 0 Then
                                aMachineData(i).GearRatio1 = CStr(Conversion.Val(Format(TorqueRecordset("Worm Wheel").Value / TorqueRecordset("Worm Thread").Value, "0.####")))
                            End If
                        Else
                            aMachineData(i).GearRatio2 = "1:1"
                            aMachineData(i).GearRatio1 = "1"
                        End If
                        If MachineType = GEARLESS_TYPE Then
                            aMachineData(i).ForwardGearEfficiency = CStr(0.98)
                        Else
                            aMachineData(i).ForwardGearEfficiency = ""
                            If TorqueRecordset("Actual FGE").Value <> 0 Then
                                Select Case TorqueRecordset("Actual FGE").Value
                                    Case 1
                                        aMachineData(i).ForwardGearEfficiency = CStr(0.65)
                                    Case 2
                                        aMachineData(i).ForwardGearEfficiency = CStr(0.74)
                                    Case 3
                                        aMachineData(i).ForwardGearEfficiency = CStr(0.78)
                                    Case Is >= 4
                                        aMachineData(i).ForwardGearEfficiency = CStr(0.8)
                                    Case Else
                                        aMachineData(i).ForwardGearEfficiency = Format(TorqueRecordset("Actual FGE").Value, "###0.0###")
                                End Select
                            Else
                                aMachineData(i).ForwardGearEfficiency = Format(TorqueRecordset("Actual FGE").Value, "###0.0###")
                            End If
                        End If
                        If MachineType = GEARLESS_TYPE Then
                            aMachineData(i).ReverseGearEfficiency = CStr(0.98)
                        Else
                            aMachineData(i).ReverseGearEfficiency = ""
                            If TorqueRecordset("Actual RGE").Value <> 0 Then
                                Select Case TorqueRecordset("Actual RGE").Value
                                    Case 1
                                        aMachineData(i).ReverseGearEfficiency = CStr(0.55)
                                    Case 2
                                        aMachineData(i).ReverseGearEfficiency = CStr(0.64)
                                    Case 3
                                        aMachineData(i).ReverseGearEfficiency = CStr(0.68)
                                    Case Is >= 4
                                        aMachineData(i).ReverseGearEfficiency = CStr(0.7)
                                    Case Else
                                        aMachineData(i).ReverseGearEfficiency = Format(TorqueRecordset("Actual RGE").Value, "###0.0###")
                                End Select
                            Else
                                aMachineData(i).ReverseGearEfficiency = CStr(Conversion.Val(aMachineData(i).ForwardGearEfficiency) - 0.1)
                            End If
                        End If
                        aMachineData(i).MachineSheaveDia = TorqueRecordset("Sheave Dia").Value
                        aMachineData(i).MachineSheaveJ = ""
                        Select Case TorqueRecordset("Machine Inertia").Value
                            Case 0
                                If TorqueRecordset("Sheave Dia").Value <= 30 Then
                                    aMachineData(i).MachineSheaveJ = "17.00"
                                ElseIf TorqueRecordset("Sheave Dia").Value > 36 Then
                                    aMachineData(i).MachineSheaveJ = "68.00"
                                Else
                                    aMachineData(i).MachineSheaveJ = "34.00"
                                End If
                            Case 1
                                aMachineData(i).MachineSheaveJ = "17.00"
                            Case 2
                                aMachineData(i).MachineSheaveJ = "34.00"
                            Case 3 : aMachineData(i).MachineSheaveJ = "68.00"
                            Case Else
                                aMachineData(i).MachineSheaveJ = Format(TorqueRecordset("Machine Inertia").Value, "0.####")
                        End Select
                        aMachineData(i).HiSpeedShaftInertia = ""
                        If MachineModel <> "Other" Then
                            If MachineType = GEARED_TYPE Then
                                Select Case TorqueRecordset("HSS Inertia").Value
                                    Case 0
                                        Select Case TorqueRecordset("Roping").Value
                                            Case 1
                                                If TorqueRecordset("Capacity").Value <= 4500 Then
                                                    aMachineData(i).HiSpeedShaftInertia = "0.6405"
                                                ElseIf TorqueRecordset("Capacity").Value > 6000 Then
                                                    aMachineData(i).HiSpeedShaftInertia = "3.234"
                                                Else
                                                    aMachineData(i).HiSpeedShaftInertia = "1.3251"
                                                End If
                                            Case 2
                                                If TorqueRecordset("Capacity").Value <= 9000 Then
                                                    aMachineData(i).HiSpeedShaftInertia = "0.6405"
                                                ElseIf TorqueRecordset("Capacity").Value > 12000 Then
                                                    aMachineData(i).HiSpeedShaftInertia = "3.234"
                                                Else
                                                    aMachineData(i).HiSpeedShaftInertia = "1.3251"
                                                End If
                                            Case Else : aMachineData(i).HiSpeedShaftInertia = ""
                                        End Select
                                    Case 1
                                        aMachineData(i).HiSpeedShaftInertia = "0.2571"
                                    Case 2
                                        aMachineData(i).HiSpeedShaftInertia = "0.6405"
                                    Case 3
                                        aMachineData(i).HiSpeedShaftInertia = "1.3251"
                                    Case 4
                                        aMachineData(i).HiSpeedShaftInertia = "3.234"
                                    Case Else
                                        aMachineData(i).HiSpeedShaftInertia = TorqueRecordset("HSS Inertia").Value
                                End Select
                                aMachineData(0).HiSpeedShaftInertia = CStr(Math.Round(CDbl(Conversion.Val(aMachineData(0).HiSpeedShaftInertia) + HSSInertiaAdder), 4))
                            End If
                        End If
                        aMachineData(i).MaxShaftSheaveLoad = TorqueRecordset("Std Susp Ld").Value
                        i += 1
                    End If
                    TorqueRecordset.MoveNext()
                Loop
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
                If i = 0 Then
                    MN_TRQ01_typ.bSuperTable = False
                End If
                Set_DeflectorSheaveJ()
                If MachineType = GEARLESS_TYPE Then
                    aMachineData(0).GearRatio2 = "1:1"
                    aMachineData(0).GearRatio1 = "1"
                    aMachineData(0).HiSpeedShaftInertia = ""
                End If
                If aMachineData(0).MachineSheaveJ = "" Then
                    If MachineModel = "Other" Then
                        If Conversion.Val(MachineSheaveDiameter) <= 30 Then
                            aMachineData(0).MachineSheaveJ = CStr(17)
                        Else
                            aMachineData(0).MachineSheaveJ = CStr(IIf(Conversion.Val(MachineSheaveDiameter) > 36, 68, 34))
                        End If
                        aMachineData(0).GearRatio1 = Format(MN_TRQ01_typ.MotorRPM * 2 * PI * (Conversion.Val(MachineSheaveDiameter) / 24) /
                                                            (Speed * Conversion.Val(Strings.Left(RopingNew, 1))), "0.####")
                    End If
                End If
                If MN_TRQ01_typ.MachineSheaveJ = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.MachineSheaveJ = aMachineData(0).MachineSheaveJ
                End If
                If MN_TRQ01_typ.GearRation1 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.GearRation1 = aMachineData(0).GearRatio1
                End If
                If MN_TRQ01_typ.GearRation2 = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.GearRation2 = aMachineData(0).GearRatio2
                End If
                If MN_TRQ01_typ.ForwardGearEfficiency = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.ForwardGearEfficiency = aMachineData(0).ForwardGearEfficiency
                End If
                If MN_TRQ01_typ.ReverseGearEfficiency = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.ReverseGearEfficiency = aMachineData(0).ReverseGearEfficiency
                End If
                If MN_TRQ01_typ.HiSpeedShaftInertia = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.HiSpeedShaftInertia = aMachineData(0).HiSpeedShaftInertia
                End If
                If MN_TRQ01_typ.MaxShaftSheaveLoad = "" Or MN_TRQ01_typ.bDirty Then
                    MN_TRQ01_typ.MaxShaftSheaveLoad = aMachineData(0).MaxShaftSheaveLoad
                End If
            Else
                MN_TRQ01_typ.bSuperTable = False
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
                bPretend = True
                GoTo lbl_OTHER
            End If
        Else
            MN_TRQ01_typ.bSuperTable = False
        End If

    End Sub
    Public Sub Set_WrapAngle()

        MN_TRQ01_typ.RopeDrop = CarToCwtRopeDrop.ToString
        Select Case MachineModel
            Case MACHINE_FMM200
                MN_TRQ01_typ.WrapAngle = "130"
            Case MACHINE_525LS
                MN_TRQ01_typ.WrapAngle = "140"
            Case Else
                iWrapAngleLogic = GetWrapAngleLogic()
                Select Case iWrapAngleLogic
                    Case 1
                        dWA = Conversion.Val(MN_TRQ01_typ.WrapAngle)
                        If MN_TRQ01_typ.VerticalDistance <> "" And MN_TRQ01_typ.HorizontalDistance <> "" Then
                            CalcWrapAngle(False)
                            If dWA = -1 Or dWA > 180 Then
                                dWA = 160
                            End If
                            MN_TRQ01_typ.WrapAngle = Format(dWA, "###0.0#")
                        Else
                            If MN_TRQ01_typ.VerticalDistance = "" And MN_TRQ01_typ.HorizontalDistance = "" Then
                                If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Then
                                    MN_TRQ01_typ.WrapAngle = "160"
                                End If
                            ElseIf bWrapAngleDependentChange Then
                                If MN_TRQ01_typ.VerticalDistance = "" Or MN_TRQ01_typ.HorizontalDistance = "" Then
                                    MN_TRQ01_typ.WrapAngle = "160"
                                End If
                            End If
                        End If
                    Case 2, 4
                        If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Then
                            MN_TRQ01_typ.WrapAngle = CStr(180)
                        End If
                    Case 3
                        If MN_TRQ01_typ.VerticalDistance = "" And MN_TRQ01_typ.HorizontalDistance = "" And MN_TRQ01_typ.RopeOffset = "" Then
                            If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Then
                                MN_TRQ01_typ.WrapAngle = "200"
                            End If
                        Else
                            dWA = 200
                            If MN_TRQ01_typ.VerticalDistance <> "" And MN_TRQ01_typ.HorizontalDistance <> "" And MN_TRQ01_typ.RopeOffset <> "" Then
                                CalcWrapAngle(False)
                                If dWA = -1 Then
                                    dWA = 200
                                End If
                                If dWA < 180 Then
                                    dWA = 180
                                End If
                            End If
                            MN_TRQ01_typ.WrapAngle = Format(dWA, "###0.0#")
                        End If
                    Case 51
                        MN_TRQ01_typ.RopeDrop = ""
                        If Conversion.Val(MN_TRQ01_typ.VerticalDistance) = 0 Or Conversion.Val(MN_TRQ01_typ.HorizontalDistance) = 0 Then
                            If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Then
                                If Conversion.Val(MN_TRQ01_typ.VerticalDistance) = 0 And Conversion.Val(MN_TRQ01_typ.HorizontalDistance) = 0 Then
                                    MN_TRQ01_typ.WrapAngle = "340"
                                Else
                                    MN_TRQ01_typ.WrapAngle = ""
                                End If
                            Else
                                If bWrapAngleChange Then
                                    MN_TRQ01_typ.VerticalDistance = ""
                                    MN_TRQ01_typ.HorizontalDistance = ""
                                Else
                                    If bWrapAngleDependentChange Then
                                        MN_TRQ01_typ.WrapAngle = "340"
                                    End If
                                End If
                            End If
                        Else
                            If bWrapAngleChange Then
                                MN_TRQ01_typ.VerticalDistance = ""
                                MN_TRQ01_typ.HorizontalDistance = ""
                            Else
                                CalcWrapAngle(False)
                                If dWA = -1 Then
                                    MN_TRQ01_typ.WrapAngle = "340"
                                Else
                                    MN_TRQ01_typ.WrapAngle = Format(dWA, "###0.0#")
                                End If
                            End If
                        End If
                        MN_TRQ01_typ.RopeOffset = ""
                    Case 52
                        If Conversion.Val(MN_TRQ01_typ.WrapAngle) = 0 Then
                            MN_TRQ01_typ.WrapAngle = "340"
                        End If
                        MN_TRQ01_typ.VerticalDistance = CStr(ReverseCalcWrapAngle())
                        If Conversion.Val(MN_TRQ01_typ.VerticalDistance) <> 0 Then
                            MN_TRQ01_typ.VerticalDistance = Format(Conversion.Val(MN_TRQ01_typ.VerticalDistance), "0.##")
                        End If
                    Case Else
                End Select
        End Select

    End Sub
    Private Sub InitHatchEff()
        Dim sSQL As String = "SELECT HatchEfficiency.HatchEff FROM ShoeTypes INNER JOIN (Roping INNER JOIN (MRLocations INNER JOIN HatchEfficiency " &
                             "ON MRLocations.MRLocationID = " & "HatchEfficiency.MRLocation) ON Roping.RopingID = HatchEfficiency.Roping)  " &
                             "ON ShoeTypes.ShoeID = HatchEfficiency.ShoeType " & "WHERE Roping.Roping='" & RopingNew &
                             "' AND ShoeTypes.ShoeType = 'Roller' AND MRLocations.MRLocation = '" & MachineLocation & "';"

        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sSQL, ADOConnection)
        If Not TorqueRecordset.EOF Then
            MN_TRQ01_typ.HatchEfficiency = TorqueRecordset("HatchEff").Value.ToString
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing

    End Sub
    Public Function GetWrapAngleLogic() As Integer

        Select Case MachineType
            Case GEARED_TYPE
                If MachineLocation = "Overhead" Then
                    If HoistwaySheave <> "None" Then
                        iWrapAngleLogic = 1
                    Else
                        iWrapAngleLogic = 2
                    End If
                Else
                    If HoistwaySheave <> "None" Then
                        iWrapAngleLogic = 3
                    Else
                        iWrapAngleLogic = 4
                    End If
                End If
            Case GEARLESS_TYPE
                If MachineLocation = "Overhead" Then
                    If HoistwaySheave <> "None" Then
                        If Wrap = "Single Wrap" Then
                            iWrapAngleLogic = 1
                        Else
                            If Conversion.Val(MachineSheaveDiameter) = HoistwaySheaveDiameter() Then
                                iWrapAngleLogic = 51
                            Else
                                iWrapAngleLogic = 52
                            End If
                        End If
                    Else
                        iWrapAngleLogic = 2
                    End If
                Else
                    If HoistwaySheave <> "None" Then
                        If Wrap = "Single Wrap" Then
                            iWrapAngleLogic = 3
                        Else
                            iWrapAngleLogic = 6
                        End If
                    Else
                        iWrapAngleLogic = 4
                    End If
                End If
        End Select
        Return iWrapAngleLogic

    End Function
    Public Sub Set_CompUnitWeight()
        Dim result As Double = 0
        Dim sSQL As String = "SELECT CompensationType.CompName, Compensation.CompSize1, Compensation.CompSize2 " & "FROM CompensationType " & _
                             "INNER JOIN Compensation ON CompensationType.CompType = Compensation.CompType " & _
                             "ORDER BY Compensation.CompSize, Compensation.CompSize1;"

        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sSQL, ADOConnection)
        Do While Not TorqueRecordset.EOF
            If TorqueRecordset("CompName").Value.ToUpper() = CompensationType.ToUpper() Then
                If TorqueRecordset("CompSize1").Value.ToString = MN_TRQ02_typ.CompensationSize Then
                    result = TorqueRecordset("CompSize2").Value
                    Exit Do
                End If
            End If
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        MN_TRQ02_typ.CompensationUnitWeight = result

    End Sub
    Public Function HoistwaySheaveDiameter() As Double
        Dim ReturnVal As Double = 0

        If HoistwaySheave = "New" Or HoistwaySheave = "Replace" Then
            ReturnVal = Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter)
        Else
            If MachineType = HYDRO_TYPE Then
                ReturnVal = 0
            Else
                Select Case MachineModel
                    Case MACHINE_FMM200
                        ReturnVal = 4.92
                    Case MACHINE_FM560
                        ReturnVal = 30
                    Case MACHINE_PMR490
                        ReturnVal = 23.62
                    Case MACHINE_FM630
                        ReturnVal = 35.4
                    Case MACHINE_FMR355, MACHINE_PMR355
                        ReturnVal = 17
                    Case Else
                        Select Case Math.Round(40 * Conversion.Val(TranslateRopeSize(HoistRopeSize, True)))
                            Case Is > 26
                                ReturnVal = 30
                            Case Is > 25
                                ReturnVal = 26
                            Case Is > 20
                                ReturnVal = 25
                            Case Else
                                ReturnVal = 20
                        End Select
                End Select
            End If
        End If
        Return ReturnVal

    End Function
    Public Sub Torque2DebugFile()

        Torque2DebugFileIn()
        Torque2DebugFileOut()
        Dim sDebugTraction As String = "Full Car at Top Accelerating Up;" & Strings.FormatNumber(Traction(1), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Full Car at Bottom Accelerating Up;" & Strings.FormatNumber(Traction(2), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Empty Car at Top Accelerating Down;" & Strings.FormatNumber(Traction(3), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Empty Car at Bottom Accelerating Down;" & Strings.FormatNumber(Traction(4), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Full Car at Top Decelerating Down;" & Strings.FormatNumber(Traction(5), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Full Car at Bottom Decelerating Down;" & Strings.FormatNumber(Traction(6), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Empty Car at Top Decelerating Up;" & Strings.FormatNumber(Traction(7), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Empty Car at Bottom Decelerating Up;" & Strings.FormatNumber(Traction(8), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Overloaded Car at Top Decelerating Down" & Strings.FormatNumber(Traction(9), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Overloaded Car at Bottom Decelerating Down;" & Strings.FormatNumber(Traction(10), 3, TriState.True) & Environment.NewLine
        sDebugTraction = sDebugTraction & "Maximum Allowable Traction Ratio;" & Strings.FormatNumber(dMaxTraction, 3, TriState.True) & Environment.NewLine
        If Strings.Right(sDebugInfo, 7) = "~end~1~" Then sDebugInfo = sDebugInfo & Environment.NewLine & Environment.NewLine & sDebugTraction & "~end~2~"

        If MachineType = GEARED_TYPE Then
            Torque2DebugPowerDataGeared()
        Else
            Torque2DebugPowerDataGearLess()
        End If

        Dim FileNumber As Integer = FileSystem.FreeFile()
        Dim DebugFile As String = DebugPath & HoldUniqueActivity & "_" & CurrentGOData_Typ.Bank & CurrentGOData_Typ.Alt & CurrentTabUnits & TORQUE_DEBUG_DETAIL_FILE_NAME
        FileSystem.FileOpen(FileNumber, DebugFile, OpenMode.Output)
        FileSystem.PrintLine(FileNumber, sDebugInfo)
        FileSystem.FileClose(FileNumber)

    End Sub
    Public Sub Torque2DebugFileIn()
        Dim sDebugInfoIn As String = ""

        sDebugInfoIn = sDebugInfoIn & "Torque Run for;" & CurrentGOData_Typ.GONum & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Machine Room Location;" & MachineLocation & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Capacity;" & CStr(Capacity) & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Car Weight Calculated;" & MN_TRQ01_typ.CarWeightCalculated & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Rise;" & CStr(Travel) & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Speed;" & CStr(Speed) & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Wrap;" & Wrap & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Angle of Wrap;" & MN_TRQ01_typ.WrapAngle & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Control Cable Weight;" & Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.ControlCableWeight), 4, TriState.True) & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Machine Sheave Diameter;" & MachineSheaveDiameter & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Machine Sheave Inertia;" & MN_TRQ01_typ.MachineSheaveJ & Environment.NewLine
        If MachineType = GEARED_TYPE Then
            sDebugInfoIn = sDebugInfoIn & "Deflector Sheave Diameter;" & HoistwaySheaveDiameter() & Environment.NewLine
            sDebugInfoIn = sDebugInfoIn & "Deflector Sheave Inertia;" & MN_TRQ01_typ.DeflectorSheaveJ & Environment.NewLine
        Else
            sDebugInfoIn = sDebugInfoIn & "Secondary Sheave Diameter;" & HoistwaySheaveDiameter() & Environment.NewLine
            sDebugInfoIn = sDebugInfoIn & "Secondary Sheave Inertia;" & MN_TRQ01_typ.DeflectorSheaveJ & Environment.NewLine
        End If
        sDebugInfoIn = sDebugInfoIn & "Car Top Sheave Diameter;" & MN_TRQ01_typ.CarSheaveDiameter & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Car Top Sheave Inertia;" & MN_TRQ01_typ.CarSheaveJ & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Cwt Top Sheave Diameter;" & MN_TRQ01_typ.CwtSheaveDiameter & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Cwt Top Sheave Inertia;" & MN_TRQ01_typ.CwtSheaveJ & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Idler Sheave Diameter;" & MN_TRQ01_typ.IdlerSheaveDiameter & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Idler Sheave Inertia;" & MN_TRQ01_typ.OverheadSheaveInertia & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Quantity of Idler Sheaves;" & MN_TRQ01_typ.NumberofIdlerSheaves & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Acceleration;" & MN_TRQ01_typ.Acceleration & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Deceleration Normal;" & MN_TRQ01_typ.Deceleration & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Deceleration Traction;" & MN_TRQ01_typ.DecelerationTraction & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Deceleration TSD;" & MN_TRQ01_typ.DecelerationTSD & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Deceleration D125;" & MN_TRQ01_typ.DecelerationD125 & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Forward Gear Effeciency;" & MN_TRQ01_typ.ForwardGearEfficiency & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Reverse Gear Effeciency;" & MN_TRQ01_typ.ReverseGearEfficiency & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Hi Speed Shaft Inertia;" & MN_TRQ01_typ.HiSpeedShaftInertia & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Motor Inertia;" & CStr(dMotorInertia) & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Hatch Efficiency;" & MN_TRQ01_typ.HatchEfficiency & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Gear Reduction Ratio;" & MN_TRQ01_typ.GearRation1 & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Gear Ratio;" & MN_TRQ01_typ.GearRation2 & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Roping;" & RopingNew & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Hoist Rope Diameter;" & HoistRopeSize & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Number of Ropes;" & HoistRopeQty & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Groove Number;" & MN_TRQ01_typ.GrooveNumber & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Rope Weight;" & MN_TRQ01_typ.RopeWeight & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Rope Strength;" & MN_TRQ01_typ.RopeStrength & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "Groove Pressure;" & MN_TRQ01_typ.MaxGroovePressure & Environment.NewLine
        sDebugInfoIn = sDebugInfoIn & "% Counterweight;" & MN_TRQ01_typ.Counterweight & Environment.NewLine
        sDebugInfo = sDebugInfoIn

    End Sub
    Public Sub Torque2DebugFileOut()
        Dim sDebugInfoOut As String = ""

        sDebugInfoOut = "Groove Pressure of Sheave Diameter; " & Strings.FormatNumber(dGrooveP, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Rope Tension; " & Strings.FormatNumber(dTension, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Factor Of Safety; " & Strings.FormatNumber(dSafety, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Unbalance (a  -  means comp > hoist); " & Strings.FormatNumber(dUnbal, 2, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Sheave Load; " & Strings.FormatNumber(dShvLoad, 2, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Machine Pull; " & Strings.FormatNumber(dMMax, 2, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Safety Load; " & Strings.FormatNumber(dSL, 2, TriState.True) & Environment.NewLine
        If MachineType = GEARED_TYPE Then
            sDebugInfoOut = sDebugInfoOut & "Motor Horsepower; " & Strings.FormatNumber(dMH, 1, TriState.True) & Environment.NewLine
        End If
        sDebugInfoOut = sDebugInfoOut & "Counter Weight; " & Strings.FormatNumber(dCWT, 1, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Full Load RPM; " & Strings.FormatNumber(dRPM, 1, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Full Load Horsepower; " & Strings.FormatNumber(dFullHP, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Full Load Torque; " & Strings.FormatNumber(dFullTork, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Running Horsepower; " & Strings.FormatNumber(dHPower, 2, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Running Torque, Mid-Hatch ; " & Strings.FormatNumber(dRunTork, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Peak Accelerating Torque; " & Strings.FormatNumber(dAccTork, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Peak Decelerating Torque; " & Strings.FormatNumber(dDecTork, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Total System Inertia at High Speed Shaft; " & Strings.FormatNumber(dTotalInertia, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Total System Inertia at the Sheave; " & Strings.FormatNumber(dTotalInertiaAtSheave, 3, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Comp Type; " & CompensationType & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Number of Comps; " & CStr(MN_TRQ01_typ.CompensationQty) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Comp size; " & MN_TRQ02_typ.CompensationSize & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Comp unit Weight; " & CStr(MN_TRQ02_typ.CompensationUnitWeight) & Environment.NewLine
        If Conversion.Val(MN_TRQ02_typ.CompensationWeight) = 0 Then
            sDebugInfoOut = sDebugInfoOut & "Total Comp Weight; " & Conversion.Val(MN_TRQ02_typ.CompensationUnitWeight) *
                            Conversion.Val(MN_TRQ01_typ.CompensationQty) & Environment.NewLine
        Else
            sDebugInfoOut = sDebugInfoOut & "Total Comp Weight; " & MN_TRQ02_typ.CompensationWeight & Environment.NewLine
        End If
        sDebugInfoOut = sDebugInfoOut & "Ideal Comp Weight; " & Strings.FormatNumber(dIdealCompWeight, 4, TriState.True) & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Comp Sheave Weight; " & Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.CompSheaveWt), 4, TriState.True) & Environment.NewLine
        Set_InputVoltage()
        sDebugInfoOut = sDebugInfoOut & "Input Voltage to Drive; " & MN_TRQ01_typ.InputVoltage & Environment.NewLine
        sDebugInfoOut = sDebugInfoOut & "Building Power Supply Voltage;" & CStr(PowerSupply) & Environment.NewLine
        If MachineType = GEARLESS_TYPE Then
            sDebugInfoOut = sDebugInfoOut & "Voltage Full Load Up (VFLU);" & Format(Conversion.Val(VFLU), "0.##") & Environment.NewLine
            sDebugInfoOut = sDebugInfoOut & "Amps (IDC1);" & Format(Conversion.Val(IDC1), "0.##") & Environment.NewLine
            sDebugInfoOut = sDebugInfoOut & "Full Field Voltage;" & VFF & Environment.NewLine
            sDebugInfoOut = sDebugInfoOut & "Full Field Current;" & IFF & Environment.NewLine
            sDebugInfoOut = sDebugInfoOut & "Fan Voltage;" & VFan & Environment.NewLine
            sDebugInfoOut = sDebugInfoOut & "Fan Currnent;" & IFan & Environment.NewLine
        End If
        sDebugInfoOut = sDebugInfoOut & "~end~1~"
        sDebugInfo = sDebugInfo & Environment.NewLine & sDebugInfoOut

    End Sub
    Public Sub Torque2DebugPowerDataGeared()
        Dim s As String = ""
        Dim FileNumber As Integer

        sDebugPowerData = ""
        sDebugPowerData = sDebugPowerData & "RFLU Power from the converter; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_RFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "RFLU Current into the converter; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "RFLU AC current into the VF50/VF85/120BR drive; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.ACCurrentIntoDrive_RFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "RFLU Line current; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_RFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "RFLU Line power; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LinePower_RFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "AFLU Power from the converter; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_AFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "AFLU Current into the converter; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "AFLU AC current into the VF50/VF85/120BR drive; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.ACCurrentIntoDrive_AFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "AFLU Line current; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_AFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "AFLU Line power; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LinePower_AFLU), 2, TriState.True) & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Peak Inrush Current; " & Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PeakCurrent), 2, TriState.True) & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Transformer Power "
        If sDriveSelection = "Error" Then
            s = " ERROR! Exceeds 122BR drive limitations."
            sDebugPowerData = sDebugPowerData & s & Environment.NewLine
            sDebugPowerData = sDebugPowerData & "Transformer Current " & Strings.Chr(9) & New String(" "c, 4) & s & Environment.NewLine
        Else
            sDebugPowerData = sDebugPowerData & CStr(MN_TRQ01_typ.Required_KVA) & " KVA    @ " & CStr(PowerSupply) & " Building Voltage"
            s = Strings.FormatNumber(MN_TRQ01_typ.Required_KVA * 1000 / (PowerSupply * 3 ^ 0.5), 2, TriState.True) & " Amps"
            sDebugPowerData = sDebugPowerData & Environment.NewLine & "Transformer Current " & Strings.Chr(9) & New String(" "c, 4) & s
        End If
        sDebugPowerData = sDebugPowerData & Environment.NewLine & "Heat Release Calculation Running" & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the system without an auto transformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformer), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the system with an auto transformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithTransformer), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the cabinet (including inverter and dynamic braking resistors); " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseCabinet), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the motor and machine; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachine), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the autotransformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseAutoTransformer), "0.00")
        sDebugPowerData = sDebugPowerData & Environment.NewLine & "Heat Release Calculation Stand Still" & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the system without an auto transformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformerSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the system with an auto transformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithTransformerSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the cabinet (including inverter and dynamic braking resistors); " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseCabinetSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the motor and machine; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachineSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "For the autotransformer; " & Format(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseAutoTransformerSS), "0.00")
        If Strings.Right(sDebugInfo, 7) = "~end~2~" Then
            sDebugInfo = sDebugInfo & Environment.NewLine & Environment.NewLine & sDebugPowerData & Environment.NewLine & "~end~3~"
            FileNumber = FileSystem.FreeFile()
            Dim DebugFile As String = DebugPath & HoldUniqueActivity & "_" & CurrentGOData_Typ.Bank & CurrentGOData_Typ.Alt & CurrentTabUnits & TORQUE_DEBUG_DETAIL_FILE_NAME
            FileSystem.FileOpen(FileNumber, DebugFile, OpenMode.Output)
            FileSystem.PrintLine(FileNumber, sDebugInfo)
            FileSystem.FileClose(FileNumber)
        End If

    End Sub
    Public Sub Torque2DebugPowerDataGearLess()
        Dim FileNumber As Integer

        sDebugPowerData = ""
        sDebugPowerData = sDebugPowerData & "Drive Selection " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "Drive Type = " & Strings.Chr(34).ToString() & ControllerType & Strings.Chr(34).ToString() & Environment.NewLine
        Dim s As String = sTransformerRequired
        sDebugPowerData = sDebugPowerData & "Transformer " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & s & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC1 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC1), "0.###") & " A" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC2 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC2), "0.###") & " A" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC3 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC3), "0.###") & " A" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC4 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC4), "0.###") & " A" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC5 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC5), "0.###") & " A" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IDC6 " & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(IDC6), "0.###") & " A" & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Current" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "Power" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC1 = " & Format(IAC1, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC1 = " & Format(KWAC1, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC2 = " & Format(IAC2, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC2 = " & Format(KWAC2, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC4 = " & Format(IAC4, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC4 = " & Format(KWAC4, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC5 = " & Format(IAC5, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC5 = " & Format(KWAC5, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC3 = " & Format(IAC3, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC3 = " & Format(KWAC3, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "IAC6 = " & Format(IAC6, "0.00") & " A"
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "KWAC6 = " & Format(KWAC6, "0.00") & " kW" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Power Factor 1" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "PF1 = " & Format(PF1, "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Power Factor 2" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "PF2 = " & Format(PF2, "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Power Factor 3" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "PF3 = " & Format(PF3, "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Power Factor 4" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "PF4 = " & Format(PF4, "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Peak Inrush Current = " & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.PeakInrushCurrent), "0.00") & " A" & Environment.NewLine & Environment.NewLine & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Heat Emission Results " & Environment.NewLine
        sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & "Running" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & "Stand Still" & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "System without an auto transformer" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        If ControllerType = DRIVETYPE_SCRDC Then
            sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Format(0, "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
            sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Format(0, "0.00") & Environment.NewLine
        Else
            sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformer), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
            sDebugPowerData = sDebugPowerData & Strings.Chr(9) & Strings.Chr(9) & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformerSS), "0.00") & Environment.NewLine
        End If
        sDebugPowerData = sDebugPowerData & "System with an auto transformer" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformer), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformerSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Cabinet (including inverter and dynamic braking resistors)" & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseCabinet), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseCabinetSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Motor and machine" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachine), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachineSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Auto Transformer" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformer), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformerSS), "0.00") & Environment.NewLine
        sDebugPowerData = sDebugPowerData & "Choke" & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseChoke), "0.00") & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9) & Strings.Chr(9)
        sDebugPowerData = sDebugPowerData & Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseChokeSS), "0.00") & Environment.NewLine

        If Strings.Right(sDebugInfo, 7) = "~end~2~" Then
            sDebugInfo = sDebugInfo & Environment.NewLine & Environment.NewLine & sDebugPowerData & Environment.NewLine & "~end~3~"
            FileNumber = FileSystem.FreeFile()
            Dim DebugFile As String = DebugPath & HoldUniqueActivity & "_" & CurrentGOData_Typ.Bank & CurrentGOData_Typ.Alt & CurrentTabUnits & TORQUE_DEBUG_DETAIL_FILE_NAME
            FileSystem.FileOpen(FileNumber, DebugFile, OpenMode.Output)
            FileSystem.PrintLine(FileNumber, sDebugInfo)
            FileSystem.FileClose(FileNumber)
        End If

    End Sub
    Public Function CalculateTransformerKVA(ByVal DefaultKVA As Double) As Double
        Dim result As Double = 0
        Dim MotorEfficiency As Double = dMOTOR_EFFICIENCY_Running
        Dim COS_Theta As Double = 0
        Dim PF1 As Double = 0.99
        Dim TransformerCurrent As Double = 8.8
        Dim InverterEfficiency As Double = IIf(ControllerType = DRIVETYPE_BR, 0.95, 0.91)
        Dim EP As Double = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "PowerSupply_cmb"))
        Dim PA As Double = IIf(MachineType = GEARLESS_TYPE And ControllerType = DRIVETYPE_PF1, 3, 0)
        Dim VLine As Double = Conversion.Val(MN_TRQ01_typ.InputVoltage)
        Dim ConverterKW As Double = (dFullTork * dRPM * 746) / ((5250 * MotorEfficiency) * (1000 * InverterEfficiency))
        Dim ConverterCurrent As Double = 0
        Dim LineCurrentAC As Double = ((ConverterCurrent + TransformerCurrent) * VLine) / EP
        Dim TmpIRFLU As Double = LineCurrentAC
        Dim KWRunningFLU As Double = (Math.Sqrt(3) * EP * dIrflu * (IIf(ControllerType = DRIVETYPE_BR, COS_Theta, PF1))) / 1000
        Dim A As Double = 7.2
        Dim B As Double = 2.19
        Dim C As Double = -0.0238
        Dim D As Double = 0.00012
        Dim E As Double = -0.000000278
        Dim F As Double = 0.000000000206

        If ControllerType = DRIVETYPE_BR Then
            Select Case NominalMotorRPM
                Case "700-1000"
                    Select Case Math.Round(Conversion.Val(MN_TRQ01_typ.NominalMotorHP))
                        Case Is <= 15
                            A = 5.6
                            B = 1.1
                            C = -0.0047
                            D = -0.0000077
                            E = 0.000000088
                            F = -0.0000000001
                        Case Is <= 20
                            A = 5.6
                            B = 0.89
                            C = -0.0031
                            D = -0.0000095
                            E = 0.000000022
                            F = -0.00000000003
                        Case Is <= 25
                            A = 6.1
                            B = 0.93
                            C = -0.0046
                            D = 0.00001
                            E = -0.0000000093
                            F = 0.0
                        Case Is <= 35
                            A = 8.9
                            B = 0.77
                            C = -0.003
                            D = 0.0000051
                            E = -0.0000000033
                            F = 0.0
                        Case Else
                            A = 8.2
                            B = 0.58
                            C = -0.0016
                            D = 0.000002
                            E = -0.00000000097
                            F = 0.0
                    End Select
                Case "1001-1300"
                    Select Case Math.Round(Conversion.Val(MN_TRQ01_typ.NominalMotorHP))
                        Case Is <= 15
                            A = 7.2
                            B = 2.2
                            C = -0.024
                            D = 0.00012
                            E = -0.00000028
                            F = 0.00000000021
                        Case Is <= 20
                            A = 6.8
                            B = 1.6
                            C = -0.012
                            D = 0.000041
                            E = -0.00000005
                            F = -0.0000000000096
                        Case Is <= 25
                            A = 8.4
                            B = 1.7
                            C = -0.017
                            D = 0.000096
                            E = -0.00000027
                            F = 0.0000000003
                        Case Is <= 30
                            A = 6.9
                            B = 1.2
                            C = -0.0075
                            D = 0.000021
                            E = -0.000000021
                            F = 0.0
                        Case Is <= 35
                            A = 8.9
                            B = 1.2
                            C = -0.01
                            D = 0.000047
                            E = -0.00000011
                            F = 0.0000000001
                        Case Is <= 40
                            A = 9.5
                            B = 1.7
                            C = -0.014
                            D = 0.000059
                            E = -0.00000012
                            F = 0.000000000086
                        Case Is <= 50
                            A = 13.0
                            B = 1.3
                            C = -0.0082
                            D = 0.000027
                            E = -0.000000042
                            F = 0.000000000025
                        Case Else
                            A = 8.0
                            B = 0.95
                            C = -0.0044
                            D = 0.00001
                            E = -0.000000012
                            F = 0.0000000000053
                    End Select
                Case Else
                    Select Case Math.Round(Conversion.Val(MN_TRQ01_typ.NominalMotorHP))
                        Case Is <= 15
                            A = 8.1
                            B = 4.6
                            C = -0.1
                            D = 0.0011
                            E = -0.0000062
                            F = 0.000000014
                        Case Is <= 20
                            A = 8.1
                            B = 4.1
                            C = -0.087
                            D = 0.00094
                            E = -0.000005
                            F = 0.000000011
                        Case Is <= 25
                            A = 13.0
                            B = 4.3
                            C = -0.094
                            D = 0.00098
                            E = -0.0000048
                            F = 0.0000000087
                        Case Is <= 35
                            A = 13.0
                            B = 2.3
                            C = -0.029
                            D = 0.00018
                            E = -0.00000057
                            F = 0.0000000007
                        Case Else
                            A = 20.0
                            B = 1.4
                            C = -0.0097
                            D = 0.000029
                            E = -0.000000031
                            F = 0.0
                    End Select
            End Select
            COS_Theta = A + (B * dFullTork) + (C * dFullTork ^ 2) + (D * dFullTork ^ 3) + (E * dFullTork ^ 4)
            ConverterCurrent = (ConverterKW * 1000) / (Math.Sqrt(3) * VLine * COS_Theta)
        Else
            ConverterCurrent = (ConverterKW * 1000) / (Math.Sqrt(3) * VLine * PF1)
        End If
        MN_TRQ01_typ.Calculated_KVA = Math.Round(((ConverterCurrent * VLine * Math.Sqrt(3)) / 1000) + PA, 1)
        If Math.Round(MN_TRQ01_typ.Required_KVA, 2) = Math.Round(-999.99, 2) Or
           (String.IsNullOrEmpty(MN_TRQ01_typ.DriveModel) And String.IsNullOrEmpty(MN_TRQ01_typ.DriveModelDefault)) Or bMotorDependentChange Then
            Select Case EP
                Case 208, 240
                    If Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 19.5 Then
                        result = 19.5
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 26 Then
                        result = 26
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 32 Then
                        result = 32
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 40 Then
                        result = 40
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 50 Then
                        result = 50
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 60 Then
                        result = 60
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 100 Then
                        result = 100
                    Else
                        result = 180
                    End If
                Case 416
                    If Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 100 Then
                        result = 100
                    Else
                        result = 180
                    End If
                Case 440
                    result = 60
                Case 460, 480
                    result = 0
                Case 575, 600
                    If Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 19.5 Then
                        result = 19.5
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 26 Then
                        result = 26
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 32 Then
                        result = 32
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 40 Then
                        result = 40
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 60 Then
                        result = 60
                    ElseIf Math.Round(MN_TRQ01_typ.Calculated_KVA, 1) <= 100 Then
                        result = 100
                    Else
                        result = 180
                    End If
                Case Else
                    result = DefaultKVA
            End Select
        Else
            result = MN_TRQ01_typ.Required_KVA
        End If
        Return result

    End Function
    Public Function GetFMM200Value(ByRef FieldName As String) As Object
        Dim SpeedInMeters As Single = Speed / 200
        Dim UseCapacity As Integer = Capacity
        Dim TotalTravelInMeters As Integer = Math.Round((Travel * 12) * 0.0254)
        Dim sSQL As String = ""
        Dim ReturnValue As Object = String.Empty

        Try
            If SpeedInMeters <= 1.0 Then
                SpeedInMeters = 1.0
            ElseIf SpeedInMeters <= 1.75 Then
                SpeedInMeters = 1.75
            ElseIf SpeedInMeters <= 2.0 Then
                SpeedInMeters = 2.0
            Else
                SpeedInMeters = 2.5
            End If
            If UseCapacity <= 2500 Then
                UseCapacity = 2500
            ElseIf UseCapacity <= 3000 Then
                UseCapacity = 3000
            ElseIf UseCapacity <= 3500 Then
                UseCapacity = 3500
            ElseIf UseCapacity <= 4000 Then
                UseCapacity = 4000
            ElseIf UseCapacity <= 4500 Then
                UseCapacity = 4500
            Else
                UseCapacity = 5000
            End If
            If TotalTravelInMeters <= 20 Then
                TotalTravelInMeters = 20
            ElseIf TotalTravelInMeters <= 40 Then
                TotalTravelInMeters = 40
            ElseIf TotalTravelInMeters <= 60 Then
                TotalTravelInMeters = 60
            Else
                TotalTravelInMeters = 75
            End If
            sSQL = "SELECT " & FieldName & " From FMM200_Values WHERE VKN=" & SpeedInMeters & " AND GQ1=" & UseCapacity & " AND HQ=" & TotalTravelInMeters
            ResetADODBRecordset(TorqueRecordset)
            TorqueRecordset.Open(sSQL, ADOConnection)
            If Not Convert.IsDBNull(TorqueRecordset(FieldName).Value) Then
                ReturnValue = TorqueRecordset(FieldName).Value
            End If

        Catch ex As Exception
            MsgBox("Error: (" & Information.Err.Number & ") " & Information.Err.Description, MsgBoxStyle.Critical, "GetFMM200Value")

        Finally
            TorqueRecordset.Close()
            TorqueRecordset = Nothing

        End Try

        Return ReturnValue

    End Function
    Public Function GetDefaultValue_VFLU_IDC1_VFF_IFF(ByVal WhichVar As String) As String
        Dim WrapVal As String = "1", sSQL As String = "", ReturnVal As String = String.Empty

        sSQL = "SELECT * FROM [Lookup Defaults] WHERE " & "[Lookup Defaults].[Machine Vendor]='" & MachineVendor & "' AND " &
               "[Lookup Defaults].[Machine Model] = '" & MachineModel & "' AND " &
               "[Lookup Defaults].Speed=" & Speed.ToString & " AND " &
               "[Lookup Defaults].Capacity=" & Capacity.ToString & " AND " &
               "[Lookup Defaults].Roping='" & RopingNew & "'"
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sSQL, ADOConnection)
        If Not TorqueRecordset.EOF Then
            ReturnVal = TorqueRecordset(WhichVar).Value.ToString
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        Return ReturnVal

    End Function
    Private Function Round2Next5(ByVal sValue As String) As Integer
        Dim sRound2Next5 As String = ""
        Dim iDecimalPoint As Integer

        If Not String.IsNullOrEmpty(sValue) Then
            iDecimalPoint = InStr(1, sValue, ".")
            If Val(Mid$(sValue, iDecimalPoint)) = 0 Then
                If Val(Mid$(sValue, iDecimalPoint - 1, 1)) <= 5 Then
                    sRound2Next5 = Left(sValue, iDecimalPoint - 2) + "5"
                Else
                    sRound2Next5 = Str(CInt(Val(Left(sValue, iDecimalPoint - 2))) + 1) + "0"
                End If
            Else
                If Val(Mid$(sValue, iDecimalPoint - 1, 1)) < 5 Then
                    sRound2Next5 = Left(sValue, iDecimalPoint - 2) + "5"
                Else
                    sRound2Next5 = Str(CInt(Val(Left(sValue, iDecimalPoint - 2))) + 1) + "0"
                End If
            End If
            If CInt(sRound2Next5) > 25 Then
                Select Case NominalMotorRPM
                    Case "700-1000"
                        If CInt(sRound2Next5) <= 35 Then
                            sRound2Next5 = "35"
                        Else
                            sRound2Next5 = "50"
                        End If
                    Case "1001-1300"
                        If CInt(sRound2Next5) <= 30 Then
                            sRound2Next5 = "30"
                        ElseIf CInt(sRound2Next5) <= 35 Then
                            sRound2Next5 = "35"
                        ElseIf CInt(sRound2Next5) <= 50 Then
                            sRound2Next5 = "50"
                        ElseIf CInt(sRound2Next5) <= 60 And Mounting = "Foot-Mounted" Then
                            sRound2Next5 = "60"
                        Else
                            sRound2Next5 = "75"
                        End If
                    Case "1600-1900"
                        If CInt(sRound2Next5) <= 35 Then
                            sRound2Next5 = "35"
                        ElseIf CInt(sRound2Next5) <= 40 Then
                            sRound2Next5 = "40"
                        Else
                            sRound2Next5 = "50"
                        End If
                End Select
            End If

        End If
        Return sRound2Next5

    End Function
    '    Public Function ValidateMajorWireListFields(ByVal bDisplayErrorMesssage As Boolean) As Integer
    '        Dim sMsgElectrical As String = "IFF, VFF, Name Plate Armature Full Load Voltage, and Name Plate Armature Full Load Current must be entered."
    '        Dim sMsgLength As String = "MR Width and MR Depth must be entered."
    '        Dim sMsg As String = ""
    '        Dim sTitle As String = ""
    '        Dim iValidateMajorWireListFields As Integer = -1

    '        If MachineType = GEARLESS_TYPE Then
    '            If ControllerType = DRIVETYPE_SCRDC Or ControllerType = DRIVETYPE_QUATTRO Then
    '                If Conversion.Val(IFF) = 0 Or _
    '                    Conversion.Val(VFF) = 0 Or _
    '                    Conversion.Val(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage) = 0 Or _
    '                    Conversion.Val(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent) = 0 Then
    '                    sMsg = sMsgElectrical
    '                    iValidateMajorWireListFields = ERROR_CANCEL
    '                End If
    '            End If
    '        End If
    '        If MachineType = HYDRO_TYPE Then
    '            If ME_HYDMRM01Car_typ.MRWidth < 1 Or ME_HYDMRM01Car_typ.MRDepth < 1 Then
    '                sMsg = sMsg & sMsgLength
    '                If iValidateMajorWireListFields = -1 Then
    '                    iValidateMajorWireListFields = ERROR_CONTINUE
    '                End If
    '            End If
    '        Else
    '            If ME_MRM02Car_typ.MRWidth < 1 Or ME_MRM02Car_typ.MRDepth < 1 Then
    '                sMsg = sMsg & Chr(10) & Chr(13) & sMsgLength
    '                If iValidateMajorWireListFields = -1 Then
    '                    iValidateMajorWireListFields = ERROR_CONTINUE
    '                End If
    '            End If
    '        End If
    '        If Len(sMsg) And bDisplayErrorMesssage Then
    '            If iValidateMajorWireListFields = ERROR_CONTINUE Then
    '                sTitle = "Wire List Length column will be hidden."
    '            Else
    '                sTitle = "Wire List can't be displayed."
    '            End If
    '            MsgBox(sMsg, 48, sTitle)
    '        End If
    '        ValidateMajorWireListFields = iValidateMajorWireListFields
    '    End Function
    Public Sub Calculate_T1s_T2s()
        Dim CarAtBottom As Double = dCarWeight + dCapacity + dRWT * (iRoping * dRise + dXRope / 2) + dCompWt * (dXCompChain / 2) + dCtrlCableWt *
                                    (dXtraCCable / 2) + dW1 / 2
        Dim CarAtTop As Double = dCarWeight + dCapacity + dRWT * (dXRope / 2) + dCompWt * (dRise + dXCompChain / 2) + dCtrlCableWt *
                                 (dRise + dXtraCCable) / 2 + dW1 / 2

        If CarAtBottom > CarAtTop Then
            T1s = CarAtBottom
            T2s = dCWT + dCompWt * (dRise + dXCompChain / 2) + dW1 / 2 + dRWT * (dXRope / 2)
        Else
            T1s = CarAtTop
            T2s = dCWT + dCompWt * (dXCompChain / 2) + dW1 / 2 + dRWT * (dRise * iRoping + dXRope / 2)
        End If

    End Sub
    Private Sub Validate_NominalMotorHP(ByRef CurHP As String)
        Dim AllowedHP() As String = {"15", "20", "25"}

        Select Case ExtractMotorRPM(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorRpm_txt"))
            Case "850"
                ReDim AllowedHP(4)
                AllowedHP(0) = "15"
                AllowedHP(1) = "20"
                AllowedHP(2) = "25"
                AllowedHP(3) = "35"
                AllowedHP(4) = "50"
            Case "1150"
                If Mounting = "Foot-Mounted" Then
                    ReDim AllowedHP(7)
                    AllowedHP(0) = "15"
                    AllowedHP(1) = "20"
                    AllowedHP(2) = "25"
                    AllowedHP(3) = "30"
                    AllowedHP(4) = "35"
                    AllowedHP(5) = "50"
                    AllowedHP(6) = "60"
                    AllowedHP(7) = "75"
                Else
                    ReDim AllowedHP(5)
                    AllowedHP(0) = "15"
                    AllowedHP(1) = "20"
                    AllowedHP(2) = "25"
                    AllowedHP(3) = "30"
                    AllowedHP(4) = "35"
                    AllowedHP(5) = "50"
                End If
            Case "1750"
                ReDim AllowedHP(5)
                AllowedHP(0) = "15"
                AllowedHP(1) = "20"
                AllowedHP(2) = "25"
                AllowedHP(3) = "35"
                AllowedHP(4) = "40"
                AllowedHP(5) = "50"
        End Select
        For iIndex As Integer = AllowedHP.GetLowerBound(0) To AllowedHP.GetUpperBound(0)
            If CurHP <= AllowedHP(iIndex) Then
                CurHP = AllowedHP(iIndex)
                Exit For
            End If
        Next iIndex

    End Sub
    Public Function OtherOther(Optional ByVal FindSheaveDiameter As Boolean = True) As Boolean
        Dim ReturnVal As Boolean = False
        Dim UseRPM As Integer = 0
        Dim sSQL As String = String.Empty
        Dim CurDataset As DataSet = SetCurrentDataset()
        Dim MachineVendorExisting As String = GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineVendorExisting_Cmb")
        Dim MachineModelExisting As String = GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelExisting_Cmb")

        If String.IsNullOrEmpty(MachineVendorExisting) Or String.IsNullOrEmpty(MachineModelExisting) Then
            ReturnVal = True
        Else
            If MachineModelExisting.ToUpper = OTHER.ToUpper Then
                ReturnVal = True
            Else
                Select Case MachineVendorExisting
                    Case ARMOR
                        Select Case MachineModelExisting
                            Case "#2", "#3", "Other"
                                ReturnVal = True
                        End Select
                    Case DOVER
                        Select Case MachineModelExisting
                            Case "GD109", "GD200"
                                ReturnVal = True
                        End Select
                    Case GURNEY
                        Select Case MachineModelExisting
                            Case "D35", "Other"
                                ReturnVal = True
                        End Select
                    Case MONTGOMERY
                        Select Case MachineModelExisting
                            Case "203", "207", "208", "209", "210", "215", "Other"
                                ReturnVal = True
                        End Select
                    Case OTIS
                        Select Case MachineModelExisting
                            Case "27 BT (#2)", "11", "12"
                                ReturnVal = True
                        End Select
                End Select
            End If
            If Not ReturnVal Then
                UseRPM = ExtractMotorRPM(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "HoistMotorRpm_txt"))
                sSQL = "SELECT DISTINCT [HSS Inertia] From SuperTable WHERE Manufacturer = '" & MachineVendorExisting &
                       "' AND MachineModel = '" & MachineModelExisting & "' AND Speed = " & GetValue(CurDataset.Tables(TABLENAME_GENERALINFO), "SpeedNew_cmb") &
                       " AND RPM = " & UseRPM
                If FindSheaveDiameter Then
                    sSQL &= " AND [Sheave Dia] = " & CInt(Conversion.Val(GetValue(CurDataset.Tables(TABLENAME_TORQUEDATA), "ExistingMachineSheaveDia_cmb")))
                End If
                TorqueRecordset = New ADODB.Recordset
                TorqueRecordset.Open(sSQL, ADOConnection)
                If TorqueRecordset.EOF Then
                    ReturnVal = True
                Else
                    Do While Not TorqueRecordset.EOF
                        If IsDBNull(TorqueRecordset("HSS Inertia").Value) Then
                            ReturnVal = True
                            Exit Do
                        Else
                            If TorqueRecordset("HSS Inertia").Value = 0 Then
                                ReturnVal = True
                                Exit Do
                            End If
                        End If
                        TorqueRecordset.MoveNext()
                    Loop
                End If
                TorqueRecordset.Close()
                TorqueRecordset = Nothing
            End If
        End If
        Return ReturnVal

    End Function
    Public Function TranslateRopeSize(ByRef CurRopeSize As String, ByRef bFromRatioToDecimal As Boolean) As String

        If bFromRatioToDecimal Then
            Select Case CurRopeSize
                Case "3/16"
                    Return "0.1875"
                Case "3/8"
                    Return "0.375"
                Case "7/16"
                    Return "0.4375"
                Case "1/2"
                    Return "0.5"
                Case "9/16"
                    Return "0.5625"
                Case "5/8"
                    Return "0.625"
                Case "11/16"
                    Return "0.6875"
                Case "3/4"
                    Return "0.75"
                Case "7/8"
                    Return "0.875"
                Case "1 1/8"
                    Return "1.125"
                Case "1 1/4"
                    Return "1.25"
                Case Else
                    Return IIf(CurRopeSize = "", CStr(0), CurRopeSize)
            End Select
        Else
            Select Case CurRopeSize
                Case "0.1875"
                    Return "3/16"
                Case "0.375"
                    Return "3/8"
                Case "0.4375", "0.438"
                    Return "7/16"
                Case "0.5"
                    Return "1/2"
                Case "0.5625", "0.563", "0.562"
                    Return "9/16"
                Case "0.625"
                    Return "5/8"
                Case "0.6875", "0.688"
                    Return "11/16"
                Case "0.75"
                    Return "3/4"
                Case "0.875"
                    Return "7/8"
                Case "1.125"
                    Return "1 1/8"
                Case "1.25"
                    Return "1 1/4"
                Case Else
                    Return CurRopeSize
            End Select
        End If

    End Function
    Public Function ExtractMotorRPM(ByVal UseRPM As String) As String
        Dim ReturnVal As String = String.Empty

        Select Case UseRPM
            Case Is <= 850
                ReturnVal = 850
            Case Is <= 1150
                ReturnVal = 1150
            Case Is <= 1750
                ReturnVal = 1750
            Case Else
        End Select
        Return Conversion.Val(ReturnVal)

    End Function
    Private Sub Set_MachineVendorNew(ByVal CurMachineType As String)
        Dim NewVendor As String = ""

        If CurMachineType = MACHINE_FMM200 Then
            MN_TRQ01_typ.MachineVendorNew = SEC
        ElseIf CurMachineType.IndexOf("Reuse") = -1 Then
            If ControllerVendor <> "TXR5" And MachineType = GEARLESS_TYPE Then
                NewVendor = OTHER
            ElseIf MachineType = GEARED_TYPE Then
                NewVendor = HOLLISTERWHITNEY
            ElseIf GetValue_Materials(EstimatingDataset, UseOptionCol, MAIN_ID_Controller, MAT_ID_Controller) <> "New" Then
                NewVendor = IMPERIAL
            Else
                NewVendor = SEC
                If RopingNew = "1:1" And Speed >= 200 And Speed <= 450 And Capacity >= 2000 And Capacity <= 3500 Then
                    If Math.Round(Conversion.Val(CarToCwtRopeDrop), 1) >= 25 Then
                        NewVendor = IMPERIAL
                    ElseIf Conversion.Val(CarToCwtRopeDrop) > 0 And Math.Round(Conversion.Val(CarToCwtRopeDrop), 1) < 25 Then
                        NewVendor = OTHER
                    End If
                End If
            End If
            If MachineType = GEARLESS_TYPE And MachineVendorExisting = OTHER And Not MN_TRQ01_typ.FormIsCompleted Then
                If ControllerVendor <> "TXR5" Then
                    If MN_TRQ01_typ.MachineVendorNew <> OTHER And MN_TRQ01_typ.MachineVendorNew <> IMPERIAL Then
                        MN_TRQ01_typ.MachineVendorNew = NewVendor
                    End If
                Else
                    MN_TRQ01_typ.MachineVendorNew = NewVendor
                End If
            ElseIf MN_TRQ01_typ.MachineVendorNew = String.Empty Then
                MN_TRQ01_typ.MachineVendorNew = NewVendor
            End If
        Else
            MN_TRQ01_typ.MachineVendorNew = String.Empty
        End If

    End Sub
    Private Sub Set_MachineModelNew(ByVal CurMachineType As String)
        Dim sSQL As String = String.Empty, NewModel As String = String.Empty

        If CurMachineType = MACHINE_FMM200 Then
            MN_TRQ01_typ.MachineModelNew = MACHINE_FMM200
        ElseIf CurMachineType.IndexOf("Reuse") = -1 Then
            If MachineType = GEARED_TYPE Then
                If MachineVendor = HOLLISTERWHITNEY Then
                    If String.IsNullOrEmpty(MN_TRQ01_typ.MachineModelNew) Then
                        NewModel = GetMachineValue()
                        If NewModel <> "99" Then
                            MN_TRQ01_typ.MachineModelNew = NewModel
                        End If
                    End If
                Else
                    MN_TRQ01_typ.MachineModelNew = OTHER
                End If
            ElseIf GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_Controller, MAT_ID_Controller) <> "TXR5" Then
                If MN_TRQ01_typ.MachineModelNew = String.Empty Then
                    If MN_TRQ01_typ.MachineVendorNew = IMPERIAL Then
                        MN_TRQ01_typ.MachineModelNew = MACHINE_525LS
                    Else
                        MN_TRQ01_typ.MachineModelNew = OTHER
                    End If
                End If
            Else
                If MN_TRQ01_typ.MachineModelNew = String.Empty Then
                    If MachineType = GEARED_TYPE Then
                        NewModel = OTHER
                        If RopingNew = "1:1" Then
                            If MN_TRQ01_typ.MachineVendorNew = IMPERIAL Then
                                If (Math.Round(Conversion.Val(CarToCwtRopeDrop), 1) >= 25 And Conversion.Val(CarToCwtRopeDrop) > 0) Then
                                    NewModel = MACHINE_525LS
                                End If
                            ElseIf MN_TRQ01_typ.MachineVendorNew = SEC Then
                                NewModel = SelectNewGearlessMachineModel()
                            End If
                        Else
                            If MN_TRQ01_typ.MachineVendorNew = SEC Then
                                NewModel = SelectNewGearlessMachineModel()
                            ElseIf MN_TRQ01_typ.MachineVendorNew = IMPERIAL Then
                                If Speed < 200 Or Speed > 450 Or Capacity < 2000 Or Capacity > 3500 Then
                                    NewModel = OTHER
                                Else
                                    NewModel = MACHINE_525LS
                                End If
                            End If
                        End If
                    Else
                        Select Case MN_TRQ01_typ.MachineVendorNew
                            Case SEC
                                NewModel = SelectNewGearlessMachineModel()
                            Case IMPERIAL
                                If Speed < 200 Or Speed > 450 Or Capacity < 2000 Or Capacity > 3500 Then
                                    NewModel = OTHER
                                Else
                                    NewModel = MACHINE_525LS
                                End If
                            Case Else
                                NewModel = OTHER
                        End Select
                    End If
                End If
            End If
            If String.IsNullOrEmpty(NewModel) Then
                NewModel = MN_TRQ01_typ.MachineModelNew
            End If
            MN_TRQ01_typ.MachineModelNew = NewModel
        Else
            MN_TRQ01_typ.MachineModelNew = ""
        End If

    End Sub
    Private Sub InitializeTorqueCollections()
        Dim s As String

        DeflectorSheaveJdefault = ""
        IdlerSheaveJdefault = ""
        CarTopSheaveJdefault = ""
        CwtTopSheaveJdefault = ""
        CompSheaveJdefault = ""
        CompSheaveWtdefault = ""

        ResetADODBRecordset(TorqueRecordset)

        cCarTopSheave = New Collection()
        cCwtTopSheave = New Collection()
        TorqueRecordset.Open("JcValues", ADOConnection)
        Do While Not TorqueRecordset.EOF
            s = Format(TorqueRecordset("Jc").Value * 100, "000000")
            If TorqueRecordset("Car or Cwt").Value.ToString = "Car" Then
                cCarTopSheave.Add(s, TorqueRecordset("Diameter").Value)
            Else
                cCwtTopSheave.Add(s, TorqueRecordset("Diameter").Value)
            End If
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()

        cIdlerSheave = New Collection()
        TorqueRecordset.Open("IdlerSheave", ADOConnection)
        Do While Not TorqueRecordset.EOF
            s = Format(TorqueRecordset("OverheadSheaveInertia").Value * 100, "000000")
            cIdlerSheave.Add(s, TorqueRecordset("IdlerSheaveRadius").Value)
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()

        cRopeCompensation = New Collection()
        TorqueRecordset.Open("[Compensation Rope]", ADOConnection)
        TorqueRecordset.Requery()
        Do While Not TorqueRecordset.EOF
            s = Format(TorqueRecordset("Weight").Value, "00000") & "~"
            s = s & TorqueRecordset("Inertia").Value.ToString
            cRopeCompensation.Add(s, TorqueRecordset("Diameter").Value)
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()

        TorqueRecordset = Nothing

    End Sub
    Public Sub Set_CarWeight()
        Dim dCapacityCoefficient As Double = 0
        Dim CurrentCarWeight As Double = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CarWeight_txt"))
        Dim CurrentCapacity As Double = Conversion.Val(GetValue(EstimatingDataset.Tables(TABLENAME_GENERALINFO), "CapacityNew_cmb"))

        If CurrentCarWeight > 0 Then
            MN_TRQ01_typ.CarWeightCalculated = CurrentCarWeight
        Else
            If Conversion.Val(MN_TRQ01_typ.CarWeightCalculated) = 0 Then
                If CurrentCapacity < 2000 Then
                    dCapacityCoefficient = 2
                ElseIf CurrentCapacity > 10000 Then
                    dCapacityCoefficient = 1
                Else
                    dCapacityCoefficient = (18 - CurrentCapacity / 1000) / 8
                End If
                MN_TRQ01_typ.CarWeightCalculated = CurrentCapacity * dCapacityCoefficient
            End If
        End If

    End Sub
    Public Sub Set_CarSheaveDiameter()
        Dim dSheaveDiameter As Double

        If CurrentGOData_Typ.MachineType = HYDRO_TYPE Then
            MN_TRQ01_typ.CarSheaveDiameter = String.Empty
        ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
            MN_TRQ01_typ.CarSheaveDiameter = "5.91"
        ElseIf RopingNew = "1:1" Then
            MN_TRQ01_typ.CarSheaveDiameter = String.Empty
        Else
            If Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter) = 0 Or MN_TRQ01_typ.bDirty Then
                dSheaveDiameter = 40 * Conversion.Val(TranslateRopeSize(HoistRopeSize, True))
                If dSheaveDiameter > 30 Then
                    MN_TRQ01_typ.CarSheaveDiameter = "30"
                Else
                    If dSheaveDiameter > 26 Then
                        MN_TRQ01_typ.CarSheaveDiameter = "30"
                    ElseIf dSheaveDiameter > 25 Then
                        MN_TRQ01_typ.CarSheaveDiameter = "26"
                    ElseIf dSheaveDiameter > 20 Then
                        MN_TRQ01_typ.CarSheaveDiameter = "25"
                    Else
                        MN_TRQ01_typ.CarSheaveDiameter = "20"
                    End If
                End If
            End If
        End If

    End Sub
    Public Sub Set_CarSheaveJ()
        Dim i, j As Integer
        Dim s As String = ""

        If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
            MN_TRQ01_typ.CarSheaveJ = String.Empty
        Else
            If MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.CarSheaveJ) = 0 Then
                j = Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter)
                If j > 19 And j <= 40 Then
                    For i = j To j - 5 Step -1
                        Try
                            s = cCarTopSheave(Conversion.Str(i).Trim()).ToString
                            MN_TRQ01_typ.CarSheaveJ = Conversion.Val(s) / 100
                            Exit For
                        Catch ex As Exception

                        End Try
                    Next i
                    If i = j - 6 Then
                        MN_TRQ01_typ.CarSheaveJ = ""
                    End If
                Else
                    MN_TRQ01_typ.CarSheaveJ = ""
                End If
            End If
        End If

    End Sub
    Public Sub Set_CwtSheaveDiameter()
        Dim dSheaveDiameter As Double

        If CurrentGOData_Typ.MachineType = HYDRO_TYPE Then
            MN_TRQ01_typ.CwtSheaveDiameter = String.Empty
        ElseIf GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
            MN_TRQ01_typ.CwtSheaveDiameter = "5.91"
        Else
            If Conversion.Val(MN_TRQ01_typ.CwtSheaveDiameter) = 0 Or MN_TRQ01_typ.bDirty Then
                dSheaveDiameter = 40 * Conversion.Val(TranslateRopeSize(HoistRopeSize, True))
                If dSheaveDiameter > 30 Then
                    MN_TRQ01_typ.CwtSheaveDiameter = "30"
                Else
                    If dSheaveDiameter > 26 Then
                        MN_TRQ01_typ.CwtSheaveDiameter = "30"
                    ElseIf dSheaveDiameter > 25 Then
                        MN_TRQ01_typ.CwtSheaveDiameter = "26"
                    ElseIf dSheaveDiameter > 20 Then
                        MN_TRQ01_typ.CwtSheaveDiameter = "25"
                    Else
                        MN_TRQ01_typ.CwtSheaveDiameter = "20"
                    End If
                End If
            End If
        End If

    End Sub
    Public Sub Set_CwtSheaveJ()
        Dim i, j As Integer
        Dim s As String = ""

        If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
            MN_TRQ01_typ.CwtSheaveJ = String.Empty
        Else
            If MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.CwtSheaveJ) = 0 Then
                j = Conversion.Val(MN_TRQ01_typ.CwtSheaveDiameter)
                If j > 19 And j < 36 Then
                    For i = j To j - 5 Step -1
                        Try
                            s = cCwtTopSheave(Conversion.Str(i).Trim()).ToString
                            MN_TRQ01_typ.CwtSheaveJ = CStr(Conversion.Val(s) / 100)
                            Exit For

                        Catch ex As Exception

                        End Try
                    Next i
                    If i = j - 6 Then
                        MN_TRQ01_typ.CwtSheaveJ = ""
                    End If
                Else
                    MN_TRQ01_typ.CwtSheaveJ = ""
                End If
            End If
        End If

    End Sub
    Public Sub Set_OverheadSheaveInertia()
        Dim i, j As Integer
        Dim s As String = ""

        If MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia) = 0 Then
            j = Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter)
            If j > 40 Or j < 10 Then
                MN_TRQ01_typ.OverheadSheaveInertia = ""
                Exit Sub
            End If
            If j > 9 Then
                For i = j To j - 5 Step -1
                    Try
                        s = CStr(cIdlerSheave(Conversion.Str(i).Trim()))
                        MN_TRQ01_typ.OverheadSheaveInertia = CStr(Conversion.Val(s) / 100)
                        Exit For

                    Catch ex As Exception

                    End Try
                Next i
                If i = j - 6 Then
                    MN_TRQ01_typ.OverheadSheaveInertia = ""
                End If
            Else
                MN_TRQ01_typ.OverheadSheaveInertia = ""
            End If
        End If

    End Sub
    Public Sub Set_GrooveNumber()

        If MN_TRQ01_typ.GrooveNumber = "" Then
            If GetValue(EstimatingDataset.Tables(TABLENAME_TORQUEDATA), "MachineModelNew_Cmb") = MACHINE_FMM200 Then
                MN_TRQ01_typ.GrooveNumber = "90 V-Groove"
            Else
                If RopingNew = "" Then
                    MN_TRQ01_typ.GrooveNumber = "K3140"
                Else
                    ResetADODBRecordset(TorqueRecordset)
                    TorqueRecordset.Open("SELECT Groove.GrooveID, Groove.Groove, Roping.Roping, ElevatorType.ElevatorType, Wrap.Wrap FROM Wrap " &
                                         "INNER JOIN (ElevatorType INNER JOIN (Roping INNER JOIN Groove ON Roping.RopingID = Groove.Roping) " &
                                         "ON ElevatorType.ElevatorTypeID = Groove.ElevatorType) ON Wrap.WrapID = Groove.Wrap;", ADOConnection)
                    If TorqueRecordset.EOF Then
                        MN_TRQ01_typ.GrooveNumber = "K3140"
                    Else
                        Do While Not TorqueRecordset.EOF
                            If TorqueRecordset("ElevatorType").Value.ToString = MachineType Then
                                If TorqueRecordset("Wrap").Value.ToString = Strings.Left(Wrap, 6) Then
                                    If TorqueRecordset("Roping").Value.ToString = RopingNew Then
                                        MN_TRQ01_typ.GrooveNumber = TorqueRecordset("Groove").Value.ToString
                                        Exit Do
                                    End If
                                End If
                            End If
                            TorqueRecordset.MoveNext()
                        Loop
                    End If
                    TorqueRecordset.Close()
                    TorqueRecordset = Nothing
                End If
            End If
        End If

    End Sub
    Public Function GetMachineValue() As String
        Dim result As String = String.Empty
        Dim strSpeed As String = ""
        Dim MACHINE_GEARED_QUERY_BY_LOCATION As String = "MACHINE_GEARED_HW_1_TO_1_OVERHEAD_QUERY"

        result = "99"
        If RopingNew = "2:1" Then
            If MachineLocation = "Overhead" Then
                MACHINE_GEARED_QUERY_BY_LOCATION = "MACHINE_GEARED_HW_2_TO_1_OVERHEAD_QUERY"
            Else
                MACHINE_GEARED_QUERY_BY_LOCATION = "MACHINE_GEARED_HW_2_TO_1_BASEMENT_QUERY"
            End If
        ElseIf MachineLocation <> "Overhead" Then
            MACHINE_GEARED_QUERY_BY_LOCATION = "MACHINE_GEARED_HW_1_TO_1_BASEMENT_QUERY"
        End If
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(MACHINE_GEARED_QUERY_BY_LOCATION, ADOConnection)
        TorqueRecordset.Filter = "[Capacity] >= " & Capacity
        If TorqueRecordset.RecordCount > 0 Then
            TorqueRecordset.MoveFirst()
            If Speed > 500 Then
                strSpeed = "500 FPM"
            ElseIf Speed > 450 And Speed <= 500 Then
                strSpeed = "500 FPM"
            ElseIf Speed > 400 And Speed <= 450 Then
                strSpeed = "450 FPM"
            ElseIf Speed > 350 And Speed <= 400 Then
                strSpeed = "400 FPM"
            ElseIf Speed > 300 And Speed <= 350 Then
                strSpeed = "350 FPM"
            ElseIf Speed > 250 And Speed <= 300 Then
                strSpeed = "300 FPM"
            ElseIf Speed > 200 And Speed <= 250 Then
                strSpeed = "250 FPM"
            ElseIf Speed > 150 And Speed <= 200 Then
                strSpeed = "200 FPM"
            ElseIf Speed > 125 And Speed <= 150 Then
                strSpeed = "150 FPM"
            ElseIf Speed > 100 And Speed <= 125 Then
                strSpeed = "125 FPM"
            Else
                strSpeed = "100 FPM"
            End If
            result = TorqueRecordset.Fields(strSpeed).Value.ToString
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        Return result

    End Function
    Public Function SelectNewGearlessMachineModel() As String
        Dim ReturnVal As String = MACHINE_FM560

        If Not OtherOther() Or (Travel <= 656) Then
            If MachineType = GEARED_TYPE Then
                If RopingNew = "1:1" Then
                    If Capacity > 2000 And Capacity < 4000 And Speed >= 500 Then
                        ReturnVal = MACHINE_PMR490
                    End If
                ElseIf Capacity <= 4000 Then
                    ReturnVal = MACHINE_FMR355
                ElseIf Speed >= 250 Then
                    ReturnVal = MACHINE_PMR490
                End If
            Else
                If RopingNew = "1:1" Then
                    If Capacity > 2000 And Capacity < 4000 And Speed < 1400 Then
                        ReturnVal = MACHINE_PMR490
                    End If
                ElseIf Capacity <= 4000 Then
                    ReturnVal = MACHINE_FMR355
                ElseIf Capacity < 8000 And Speed < 1000 Then
                    ReturnVal = MACHINE_PMR490
                End If
            End If
        End If
        Return ReturnVal

    End Function
    Public Sub Set_DeflectorSheaveJ()
        Dim sSQL As String = ""

        If MN_TRQ01_typ.MachineModelNew = MACHINE_FMM200 Then
            MN_TRQ01_typ.DeflectorSheaveJ = ""
        Else
            Select Case HoistwaySheave
                Case "None"
                    DeflectorSheaveJdefault = ""
                    MN_TRQ01_typ.DeflectorSheaveJ = ""
                Case Else
                    If MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.DeflectorSheaveJ) = 0 Then
                        If MachineType = GEARLESS_TYPE Then
                            If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) > 0 Then
                                If MachineModel = "Other" Then
                                    sSQL = "SELECT Max([Sec Sheave Dia Gearless].[sec sheave inertia]) AS [J] FROM [Sec Sheave Dia Gearless] "
                                    sSQL &= "GROUP BY [Sec Sheave Dia Gearless].[sec sheav dia] HAVING [Sec Sheave Dia Gearless].[sec sheav dia]="
                                    sSQL &= MN_TRQ01_typ.DeflectorSheaveDiameter
                                    ResetADODBRecordset(TorqueRecordset)
                                    TorqueRecordset.Open(sSQL, ADOConnection)
                                    If TorqueRecordset.EOF Then
                                        If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) <= 30 Then
                                            DeflectorSheaveJdefault = CStr(17)
                                        Else
                                            If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) > 36 Then
                                                If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) > 42 Then
                                                    DeflectorSheaveJdefault = ""
                                                Else
                                                    DeflectorSheaveJdefault = CStr(68)
                                                End If
                                            Else
                                                DeflectorSheaveJdefault = CStr(34)
                                            End If
                                        End If
                                    Else
                                        DeflectorSheaveJdefault = TorqueRecordset("J").Value.ToString
                                    End If
                                    If String.IsNullOrEmpty(MN_TRQ01_typ.DeflectorSheaveJ) Then
                                        If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) <= 42 Then
                                            MN_TRQ01_typ.DeflectorSheaveJ = CStr(Conversion.Val(DeflectorSheaveJdefault))
                                        End If
                                    End If
                                Else
                                    sSQL = "SELECT * FROM [Sec Sheave Dia Gearless] WHERE MachineType='" & MachineModel & "'"
                                    ResetADODBRecordset(TorqueRecordset)
                                    TorqueRecordset.Open(sSQL, ADOConnection)
                                    DeflectorSheaveJdefault = ""
                                    If TorqueRecordset.EOF Then
                                        If Conversion.Val(MachineSheaveDiameter) <= 30 Then
                                            DeflectorSheaveJdefault = CStr(17)
                                        Else
                                            If Conversion.Val(MachineSheaveDiameter) > 36 Then
                                                If Conversion.Val(MachineSheaveDiameter) > 42 Then
                                                    DeflectorSheaveJdefault = ""
                                                Else
                                                    DeflectorSheaveJdefault = CStr(68)
                                                End If
                                            Else
                                                DeflectorSheaveJdefault = CStr(34)
                                            End If
                                        End If
                                    Else
                                        If Strings.Left(MachineModel, 3) = "GTE" Or Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) = TorqueRecordset("sec sheav dia").Value Then
                                            DeflectorSheaveJdefault = TorqueRecordset("sec sheave inertia").Value.ToString
                                        Else
                                            If Conversion.Val(MachineSheaveDiameter) <= 30 Then
                                                DeflectorSheaveJdefault = CStr(17)
                                            Else
                                                If Conversion.Val(MachineSheaveDiameter) > 36 Then
                                                    DeflectorSheaveJdefault = CStr(68)
                                                Else
                                                    DeflectorSheaveJdefault = CStr(34)
                                                End If
                                            End If
                                        End If
                                    End If
                                    If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveJ) = 0 Then
                                        MN_TRQ01_typ.DeflectorSheaveJ = CStr(Conversion.Val(DeflectorSheaveJdefault))
                                    End If
                                End If
                                TorqueRecordset.Close()
                                TorqueRecordset = Nothing
                            Else
                                MN_TRQ01_typ.DeflectorSheaveJ = CStr(0)
                                DeflectorSheaveJdefault = ""
                            End If
                        Else
                            If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) > 0 Then
                                Select Case Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter)
                                    Case Is < 15
                                        DeflectorSheaveJdefault = CStr(0)
                                    Case Is <= 20
                                        DeflectorSheaveJdefault = CStr(2.84)
                                    Case Is <= 25
                                        DeflectorSheaveJdefault = CStr(7.01)
                                    Case Is <= 26
                                        DeflectorSheaveJdefault = CStr(8.06)
                                    Case Is <= 30
                                        DeflectorSheaveJdefault = CStr(12.56)
                                    Case Else
                                        DeflectorSheaveJdefault = ""
                                End Select
                            Else
                                DeflectorSheaveJdefault = ""
                            End If
                            If String.IsNullOrEmpty(MN_TRQ01_typ.DeflectorSheaveJ) Then
                                If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) <= 30 Then
                                    MN_TRQ01_typ.DeflectorSheaveJ = CStr(Conversion.Val(DeflectorSheaveJdefault))
                                End If
                            End If
                        End If
                    End If
            End Select
        End If

    End Sub
    Public Sub Set_MainTravelingCable()
        Dim MaxLength As Single

        If MN_TRQ01_typ.MainTravelingCable = "" Then
            If ControllerVendor = "TXR5" Then
                MaxLength = Travel + 125
                If MaxLength < 491 Then
                    MN_TRQ01_typ.MainTravelingCable = "CWS - 74"
                ElseIf MaxLength >= 491 And MaxLength < 900 Then
                    MN_TRQ01_typ.MainTravelingCable = "CSX - 750"
                Else
                    MN_TRQ01_typ.MainTravelingCable = MachineType
                End If
            End If
        End If

    End Sub
    Public Sub Set_ControlCableWeight()
        Dim dControlCableWeight As Double = Conversion.Val(MN_TRQ01_typ.ControlCableWeight)
        Dim dMainCableWeight As Double = 0

        CableRecordSet.MoveFirst()
        Do While Not CableRecordSet.EOF
            If CableRecordSet("CableType").Value.ToString = MN_TRQ01_typ.MainTravelingCable Then
                dMainCableWeight = CableRecordSet("CableWeight").Value
                Exit Do
            End If
            CableRecordSet.MoveNext()
        Loop
        CableRecordSet.MoveFirst()
        MN_TRQ01_typ.ControlCableWeight = CStr(dMainCableWeight)
        If MN_TRQ01_typ.MainTravelingCable <> "" Then
            If Conversion.Val(MN_TRQ01_typ.MainTravelingCableQty) > 0 Then
                MN_TRQ01_typ.ControlCableWeight = CStr(dMainCableWeight * Conversion.Val(MN_TRQ01_typ.MainTravelingCableQty))
            End If
        End If
        If dControlCableWeight <> Conversion.Val(MN_TRQ01_typ.ControlCableWeight) Then
            Set_CompensationSize()
        End If

    End Sub
    Private Sub Set_CompensationSize()
        Dim IsWhisperflex As Boolean = GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_PIT, MAT_ID_WhisperFlex) = "New"
        Dim IsRope As Boolean = GetValue_Materials(EstimatingDataset, UseTypeCol, MAIN_ID_PIT, MAT_ID_CompensationRope) = "New"

        If MachineType = HYDRO_TYPE Then
            MN_TRQ02_typ.CompensationSize = String.Empty
        Else
            If Compensation = "None" Then
                MN_TRQ02_typ.CompensationSize = String.Empty
            Else
                If String.IsNullOrEmpty(MN_TRQ02_typ.CompensationSize) Then
                    If IsWhisperflex Then
                        Set_RopeStrength()
                        dRWT = Conversion.Val(HoistRopeQty) * Conversion.Val(MN_TRQ01_typ.RopeWeight)
                        dCtrlCableWt = Conversion.Val(MN_TRQ01_typ.ControlCableWeight)
                        If RopingNew = "2:1" Then
                            iRoping = 2
                        Else
                            iRoping = 1
                        End If
                        dIdealCompWeight = iRoping * dRWT - dCtrlCableWt / 4
                        If dIdealCompWeight >= 8 Then
                            MN_TRQ02_typ.CompensationSize = "WF40"
                        ElseIf dIdealCompWeight >= 7 Then
                            MN_TRQ02_typ.CompensationSize = "WF35"
                        ElseIf dIdealCompWeight >= 6 Then
                            MN_TRQ02_typ.CompensationSize = "WF30"
                        ElseIf dIdealCompWeight >= 5 Then
                            MN_TRQ02_typ.CompensationSize = "WF25"
                        ElseIf dIdealCompWeight >= 4 Then
                            MN_TRQ02_typ.CompensationSize = "WF20"
                        ElseIf dIdealCompWeight >= 3 Then
                            MN_TRQ02_typ.CompensationSize = "WF15"
                        Else
                            MN_TRQ02_typ.CompensationSize = "WF10"
                        End If
                    End If
                ElseIf Strings.Left(MN_TRQ02_typ.CompensationSize, 2) = "WF" And IsRope Then
                    MN_TRQ02_typ.CompensationSize = ""
                ElseIf (Strings.Left(MN_TRQ02_typ.CompensationSize, 2) <> "WF" And MN_TRQ02_typ.CompensationSize <> "Unknown" And IsWhisperflex) Then
                    Set_RopeStrength()
                    dRWT = Conversion.Val(HoistRopeQty) * Conversion.Val(MN_TRQ01_typ.RopeWeight)
                    dCtrlCableWt = Conversion.Val(MN_TRQ01_typ.ControlCableWeight)
                    If RopingNew = "2:1" Then
                        iRoping = 2
                    Else
                        iRoping = 1
                    End If
                    dIdealCompWeight = iRoping * dRWT - dCtrlCableWt / 4
                    If dIdealCompWeight >= 8 Then
                        MN_TRQ02_typ.CompensationSize = "WF40"
                    ElseIf dIdealCompWeight >= 7 Then
                        MN_TRQ02_typ.CompensationSize = "WF35"
                    ElseIf dIdealCompWeight >= 6 Then
                        MN_TRQ02_typ.CompensationSize = "WF30"
                    ElseIf dIdealCompWeight >= 5 Then
                        MN_TRQ02_typ.CompensationSize = "WF25"
                    ElseIf dIdealCompWeight >= 4 Then
                        MN_TRQ02_typ.CompensationSize = "WF20"
                    ElseIf dIdealCompWeight >= 3 Then
                        MN_TRQ02_typ.CompensationSize = "WF15"
                    Else
                        MN_TRQ02_typ.CompensationSize = "WF10"
                    End If
                ElseIf IsRope Then
                    Select Case MN_TRQ02_typ.CompensationSize
                        Case "1/2", "9/16"
                            MN_TRQ02_typ.CompensationSize = "5/8"
                        Case "11/16"
                            MN_TRQ02_typ.CompensationSize = "3/4"
                        Case Else
                    End Select
                End If
            End If
        End If

    End Sub
    Public Sub Set_RopeStrength()
        Dim sFieldName As String = ""
        Dim dRopeWeight As String = MN_TRQ01_typ.RopeWeight
        Dim ConvertedHoistRopeSize As Double = Math.Round(Conversion.Val(TranslateRopeSize(HoistRopeSize, True)), 4)

        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open("RopeData", ADOConnection)
        Do While Not TorqueRecordset.EOF
            If Math.Round(Conversion.Val(TorqueRecordset("RopeDiameterMin").Value.ToString), 4) <= ConvertedHoistRopeSize And
               Math.Round(Conversion.Val(TorqueRecordset("RopeDiameterMax").Value.ToString), 4) >= ConvertedHoistRopeSize Then
                sFieldName = "RopeWeight"
                If MN_TRQ01_typ.RopeGrade = "EHS" Then
                    If MachineType = GEARED_TYPE Then
                        If Math.Round(ConvertedHoistRopeSize, 1) = 0.5 Or Math.Round(ConvertedHoistRopeSize, 3) = 0.625 Then
                            sFieldName = "RopeWeight_Geared_EHS"
                        End If
                    End If
                End If
                MN_TRQ01_typ.RopeWeight = TorqueRecordset(sFieldName).Value.ToString
                If MN_TRQ01_typ.RopeGrade = "EHS" Then
                    If MachineType = GEARED_TYPE Then
                        sFieldName = "UStrengthHS_Geared"
                    Else
                        sFieldName = "UStrengthHS_Gearless"
                    End If
                    If TorqueRecordset(sFieldName).Value.ToString = "None" Then
                        MN_TRQ01_typ.RopeStrength = 0
                    Else
                        MN_TRQ01_typ.RopeStrength = TorqueRecordset(sFieldName).Value.ToString
                    End If
                Else
                    If TorqueRecordset("UStrengthTS").Value.ToString = "None" Then
                        MN_TRQ01_typ.RopeStrength = 0
                    Else
                        MN_TRQ01_typ.RopeStrength = TorqueRecordset("UStrengthTS").Value.ToString
                    End If
                End If
                Exit Do
            End If
            TorqueRecordset.MoveNext()
        Loop
        TorqueRecordset.Close()
        TorqueRecordset = Nothing
        Set_MaxGroovePressure()
        If dRopeWeight <> MN_TRQ01_typ.RopeWeight Then
            Set_CompensationSize()
        End If

    End Sub
    Private Sub Set_MaxGroovePressure()

        If MachineType = GEARED_TYPE Then
            Set_MaxGroovePressure_GEARED()
        Else
            Set_MaxGroovePressure_GEARLESS()
        End If

    End Sub
    Private Sub Set_MaxGroovePressure_GEARLESS()
        Dim sWhere As String = "SELECT * FROM MaxGroovePressure WHERE RopeDiameter=" & Strings.Chr(34).ToString() &
                               Math.Round(Conversion.Val(TranslateRopeSize(HoistRopeSize, True)), 4) & Strings.Chr(34).ToString() & " AND Roping=" &
                               Strings.Chr(34).ToString() & RopingNew & Strings.Chr(34).ToString()

        If RopingNew = "2:1" Then
            sWhere &= " AND Groove='" & MN_TRQ01_typ.GrooveNumber & "'"
        End If
        MN_TRQ01_typ.MaxGroovePressure = ""
        ResetADODBRecordset(TorqueRecordset)
        TorqueRecordset.Open(sWhere, ADOConnection)
        If Not TorqueRecordset.EOF Then
            MN_TRQ01_typ.MaxGroovePressure = TorqueRecordset("MaxGroovePressure").Value.ToString
        End If
        TorqueRecordset.Close()
        TorqueRecordset = Nothing

    End Sub
    Private Sub Set_MaxGroovePressure_GEARED()
        Dim i As Integer = 0, j As Single = 0
        Dim ConvertedHoistRopeSize As Double = Math.Round(Conversion.Val(TranslateRopeSize(HoistRopeSize, True)), 4)

        MN_TRQ01_typ.MaxGroovePressure = ""
        If ("" & Speed).Length Then
            If ("" & HoistRopeSize).Length Then
                i = Speed
                If MN_TRQ01_typ.GrooveNumber = "K3269" Then
                    If i < 200 Then i = 200
                    Select Case i
                        Case 200
                            j = (202 - 0.3533 * Speed) * (ConvertedHoistRopeSize / 0.5)
                        Case 250
                            j = 119 * (ConvertedHoistRopeSize / 0.5)
                        Case 300
                            j = 108 * (ConvertedHoistRopeSize / 0.5)
                        Case 350
                            j = 101 * (ConvertedHoistRopeSize / 0.5)
                        Case 400
                            j = 96 * (ConvertedHoistRopeSize / 0.5)
                        Case 450
                            j = 93.5 * (ConvertedHoistRopeSize / 0.5)
                        Case 500
                            j = 91 * (ConvertedHoistRopeSize / 0.5)
                        Case 600
                            j = 86 * (ConvertedHoistRopeSize / 0.5)
                        Case 700
                            j = 84 * (ConvertedHoistRopeSize / 0.5)
                        Case Else
                            j = 0
                            iError(3) = 1
                            g_bErrors = True
                    End Select
                ElseIf MN_TRQ01_typ.GrooveNumber = "K3140" Then  'must be K3140 for geared jobs
                    Select Case i
                        Case 100
                            j = 124 * (ConvertedHoistRopeSize / 0.5)
                        Case 150
                            j = 109 * (ConvertedHoistRopeSize / 0.5)
                        Case 200
                            j = 98 * (ConvertedHoistRopeSize / 0.5)
                        Case 250
                            j = 90 * (ConvertedHoistRopeSize / 0.5)
                        Case 300
                            j = 82 * (ConvertedHoistRopeSize / 0.5)
                        Case 350
                            j = 76 * (ConvertedHoistRopeSize / 0.5)
                        Case 400
                            j = 71 * (ConvertedHoistRopeSize / 0.5)
                        Case 450
                            j = 66 * (ConvertedHoistRopeSize / 0.5)
                        Case 500
                            j = 60 * (ConvertedHoistRopeSize / 0.5)
                        Case 550
                            j = 56 * (ConvertedHoistRopeSize / 0.5)
                        Case 600
                            j = 52 * (ConvertedHoistRopeSize / 0.5)
                        Case 700
                            j = 46 * (ConvertedHoistRopeSize / 0.5)
                        Case Else
                            j = 0
                            iError(3) = 1
                            g_bErrors = True
                    End Select
                Else
                    j = 0
                End If
                MN_TRQ01_typ.MaxGroovePressure = CStr(j)
            End If
        Else
            If Not bSkipFields2Type Then
                MessageBox.Show("Speed is blank. Maximum Groove Pressure will be recalculated when a speed is selected.", "No Speed selected.", MessageBoxButtons.OK)
            End If
        End If

    End Sub
    Private Sub Set_CompensationSheaveDiameter()

        If MachineType = HYDRO_TYPE Then
            MN_TRQ01_typ.SheaveDiameter = String.Empty
        ElseIf Compensation = "None" Or String.IsNullOrEmpty(CompSheave) Then
            MN_TRQ01_typ.SheaveDiameter = String.Empty
        Else
            If String.IsNullOrEmpty(MN_TRQ01_typ.SheaveDiameter) Then
                If CompSheave <> "None" Then
                    Select Case MachineModel
                        Case MACHINE_FMR355, MACHINE_PMR355
                            MN_TRQ01_typ.SheaveDiameter = 17
                        Case MACHINE_FM560
                            MN_TRQ01_typ.SheaveDiameter = 30
                        Case Else
                            If Conversion.Val(HoistRopeSize) = 0 Then
                                MN_TRQ01_typ.SheaveDiameter = 30
                            Else
                                Select Case Math.Round(Conversion.Val(TranslateRopeSize(HoistRopeSize, True)) * 40)
                                    Case Is <= 20
                                        MN_TRQ01_typ.SheaveDiameter = 20
                                    Case Is <= 26
                                        MN_TRQ01_typ.SheaveDiameter = 26
                                    Case Is <= 30
                                        MN_TRQ01_typ.SheaveDiameter = 30
                                    Case Is <= 40
                                        MN_TRQ01_typ.SheaveDiameter = 40
                                    Case Is <= 45
                                        MN_TRQ01_typ.SheaveDiameter = 45
                                    Case Else
                                        MN_TRQ01_typ.SheaveDiameter = 30
                                End Select
                            End If
                    End Select
                End If
            End If
        End If

    End Sub
    Public Sub Set_CompSheaveJandWt()
        Dim i As Integer = 0, j As Integer = 0
        Dim s As String = ""

        If Not (MN_TRQ01_typ.bDirty Or Conversion.Val(MN_TRQ01_typ.CompSheaveJ) = 0) Then
            Exit Sub
        End If
        If CompSheave = "None" Then
            If MN_TRQ01_typ.CompSheaveJ <> "" Then
                MN_TRQ01_typ.CompSheaveJ = ""
            End If
            If MN_TRQ01_typ.CompSheaveWt <> "" Then
                MN_TRQ01_typ.CompSheaveWt = ""
            End If
        Else
            j = Conversion.Val(MN_TRQ01_typ.SheaveDiameter)
            If j >= Conversion.Val(MN_TRQ01_typ.SheaveDiameter) And j > 20 And j < 51 Then
                j -= 1
            End If
            If j > 9 And j <= 50 Then
                For i = j To j - 10 Step -1
                    Try
                        s = CStr(cRopeCompensation(Conversion.Str(i).Trim()))
                        CompSheaveWtdefault = CStr(Conversion.Val(Strings.Left(s, 5)))
                        CompSheaveJdefault = CStr(Conversion.Val(Strings.Mid(s, 7)))
                        If MN_TRQ01_typ.CompSheaveWt <> CompSheaveWtdefault Then
                            FormIsDirty = True
                        End If
                        MN_TRQ01_typ.CompSheaveWt = CompSheaveWtdefault
                        If MN_TRQ01_typ.CompSheaveJ <> CompSheaveJdefault Then
                            FormIsDirty = True
                            MN_TRQ01_typ.CompSheaveJ = CompSheaveJdefault
                        End If
                        Exit For

                    Catch ex As Exception

                    End Try
                Next i
                If i = j - 11 Then
                    CompSheaveWtdefault = ""
                    CompSheaveJdefault = ""
                    MN_TRQ01_typ.CompSheaveWt = ""
                    MN_TRQ01_typ.CompSheaveJ = ""
                End If
            Else
                CompSheaveWtdefault = ""
                CompSheaveJdefault = ""
                MN_TRQ01_typ.CompSheaveWt = ""
                MN_TRQ01_typ.CompSheaveJ = ""
            End If
        End If

    End Sub
    Public Sub Set_InputVoltage()

        If PowerSupply = 460 Or PowerSupply = 480 Then
            MN_TRQ01_typ.InputVoltage = PowerSupply.ToString
        Else
            MN_TRQ01_typ.InputVoltage = 460
        End If

    End Sub
End Module