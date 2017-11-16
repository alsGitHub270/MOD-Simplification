Option Strict Off
Option Explicit On
'Imports UpgradeHelpers.VB6.Utils
Imports Microsoft.VisualBasic
Imports System
Partial Friend Class MN_TRQ03_frm
    Inherits System.Windows.Forms.Form
    'Private Sub MN_TRQ03_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '    If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
    '        UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
    '    End If
    '    If FormLoadWasProcessed Then
    '        FormLoadWasProcessed = False
    '    Else
    '        PrepareThisForm()
    '    End If

    'End Sub

    'Private Sub FormsAfterMatch()

    'End Sub
    'Private Sub MN_TRQ03_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

    '    FormLoadWasProcessed = True
    '    PrepareThisForm()

    'End Sub
    'Private Sub Torque2InputFields()

    '    MachineRoomLocation_lbl(1).Text = ME_MRM01Car_typ.MachineLocation
    '    Capacity_lbl(1).Text = CStr(ME_COM01Car_typ.Capacity)
    '    CarWeight_lbl(1).Text = MN_TRQ01_typ.CarWeightCalculated
    '    Rise_lbl(1).Text = Strings.FormatNumber(ME_COM01Car_typ.TravelFt + ME_COM01Car_typ.TravelIn / 12, 2, TriState.False)
    '    Speed_lbl(1).Text = CStr(ME_COM01Car_typ.Speed)
    '    Wrap_lbl(1).Text = ME_MRM01Car_typ.Wrap
    '    AngleOfWrap_lbl(1).Text = MN_TRQ01_typ.WrapAngle
    '    ControlCableName_lbl(1).Text = MN_TRQ01_typ.MainTravelingCable
    '    ControlCableWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.ControlCableWeight), 4, TriState.True)
    '    MachineSheaveDiameter_lbl(1).Text = ME_MRM01Car_typ.MachineSheaveDia
    '    MachineSheaveInertia_lbl(1).Text = MN_TRQ01_typ.MachineSheaveJ
    '    If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '        DeflectorSheaveDiameter_lbl(0).Text = "Deflector Sheave Diameter"
    '        DeflectorSheaveInertia_lbl(0).Text = "Deflector Sheave Inertia"
    '    Else
    '        DeflectorSheaveDiameter_lbl(0).Text = "Secondary Sheave Diameter"
    '        DeflectorSheaveInertia_lbl(0).Text = "Secondary Sheave Inertia"
    '    End If
    '    If ME_HstWay02Car_typ.HoistwaySheave = "None" Then
    '        DeflectorSheaveDiameter_lbl(1).Text = "None"
    '    Else
    '        DeflectorSheaveDiameter_lbl(1).Text = CStr(HoistwaySheaveDiameter())
    '    End If
    '    DeflectorSheaveInertia_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.DeflectorSheaveJ), 2, TriState.True)
    '    CarTopSheaveDiameter_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter))
    '    CarTopSheaveInertia_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.CarSheaveJ), 2, TriState.True)
    '    CarTopSheaveQty_lbl(1).Text = CStr(ME_CAR01Car_typ.CarSheaveQty)
    '    CwtTopSheaveDiameter_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.CwtSheaveDiameter))
    '    CwtTopSheaveInertia_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.CwtSheaveJ))
    '    IdlerSheaveDiameter_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter))
    '    IdlerSheaveInertia_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia))
    '    QuantityOfIdlerSheaves_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.NumberofIdlerSheaves))
    '    Acceleration_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.Acceleration), 2, TriState.True)
    '    DecelerationNormal_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.Deceleration), 2, TriState.True)
    '    DecelerationTraction_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.DecelerationTraction), 2, TriState.True)
    '    DecelerationTSD_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.DecelerationTSD), 2, TriState.True)
    '    DecelerationD125_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.DecelerationD125), 2, TriState.True)
    '    ForwardGearEfficiency_lbl(1).Text = MN_TRQ01_typ.ForwardGearEfficiency
    '    ReverseGearEfficiency_lbl(1).Text = MN_TRQ01_typ.ReverseGearEfficiency
    '    HiSpeedShaftInertia_lbl(1).Text = MN_TRQ01_typ.HiSpeedShaftInertia
    '    MotorInertia_lbl(1).Text = IIf(dMotorInertia = 0, "", CStr(dMotorInertia))
    '    HatchEfficiency_lbl(1).Text = MN_TRQ01_typ.HatchEfficiency
    '    GearReductionRatio_lbl(1).Text = MN_TRQ01_typ.GearRation1
    '    GearRatio_lbl(1).Text = MN_TRQ01_typ.GearRation2
    '    Roping_lbl(1).Text = ME_MRM01Car_typ.RopingNew
    '    HoistRopeDiameter_lbl(1).Text = ME_MRM01Car_typ.HoistCableSize
    '    NumberOfRopes_lbl(1).Text = CStr(ME_MRM01Car_typ.HoistCableQty)
    '    GrooveNumber_lbl(1).Text = MN_TRQ01_typ.GrooveNumber
    '    RopeWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.RopeWeight), 4, TriState.True)
    '    RopeStrength_lbl(1).Text = MN_TRQ01_typ.RopeStrength
    '    GroovePressure_lbl(1).Text = MN_TRQ01_typ.MaxGroovePressure
    '    PercentCounterWeight_lbl(1).Text = MN_TRQ01_typ.Counterweight
    '    Select Case GONumbers(CurrentGOSelection).MachineType
    '        Case GEARED_TYPE
    '            MotorEfficiencyRunning_lbl(1).Text = Strings.FormatNumber(dMOTOR_EFFICIENCY_Running, 3, TriState.True)
    '            MotorEfficiencyAccelerating_lbl(1).Text = Strings.FormatNumber(dMOTOR_EFFICIENCY_Accelerating, 3, TriState.True)
    '            MotorEfficiencyDecelerating_lbl(1).Text = Strings.FormatNumber(dMOTOR_EFFICIENCY_Decelerating, 3, TriState.True)
    '            If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
    '                PowerFactorRunning_lbl(1).Text = Strings.FormatNumber(dPOWER_FACTOR_Running, 3, TriState.True)
    '                PowerFactorAccelerating_lbl(1).Text = Strings.FormatNumber(dPOWER_FACTOR_Accelerating, 3, TriState.True)
    '                PowerFactor3_lbl(1).Text = "0.000"
    '                PowerFactor4_lbl(1).Text = "0.000"
    '            Else
    '                PowerFactorRunning_lbl(1).Text = CStr(dPOWER_FACTOR_Running)
    '                PowerFactorAccelerating_lbl(1).Text = CStr(dPOWER_FACTOR_Running)
    '                PowerFactor3_lbl(1).Text = CStr(PF3)
    '                PowerFactor4_lbl(1).Text = CStr(PF4)
    '            End If
    '        Case GEARLESS_TYPE
    '            MotorEfficiencyRunning_lbl(1).Text = ""
    '            MotorEfficiencyAccelerating_lbl(1).Text = ""
    '            MotorEfficiencyDecelerating_lbl(1).Text = ""
    '            PowerFactorRunning_lbl(1).Text = Format(PF1, "0.000")
    '            PowerFactorAccelerating_lbl(1).Text = Format(PF2, "0.000")
    '            PowerFactor3_lbl(1).Text = Format(PF3, "0.000")
    '            PowerFactor4_lbl(1).Text = Format(PF4, "0.000")
    '    End Select
    '    MachineMake_lbl(1).Text = ME_MRM01Car_typ.MachineVendor
    '    MachineModel_lbl(1).Text = ME_MRM01Car_typ.MachineModel

    'End Sub
    'Private Sub Torque2OutputFields()

    '    GroovePressureSheaveDiameter_lbl(1).Text = Strings.FormatNumber(dGrooveP, 3, TriState.True) & Environment.NewLine
    '    RopeTension_lbl(1).Text = Strings.FormatNumber(dTension, 3, TriState.True)
    '    FactorOfSafety_lbl(1).Text = Strings.FormatNumber(dSafety, 3, TriState.True) & Environment.NewLine
    '    Unbalance_lbl(1).Text = Strings.FormatNumber(dUnbal, 2, TriState.True)
    '    SheaveLoad_lbl(1).Text = Strings.FormatNumber(dShvLoad, 2, TriState.True)
    '    MachinePull_lbl(1).Text = Strings.FormatNumber(dMMax, 2, TriState.True) & Environment.NewLine
    '    SafetyLoad_lbl(1).Text = Strings.FormatNumber(dSL, 2, TriState.True)
    '    CounterWeight_lbl(1).Text = Strings.FormatNumber(dCWT, 1, TriState.True)
    '    FullLoadRPM_lbl(1).Text = Strings.FormatNumber(dRPM, 1, TriState.True)
    '    AllowableSheaveLoad_lbl(1).Text = MN_TRQ01_typ.MaxShaftSheaveLoad
    '    TotalSystemInertiaAtHighSpeed_lbl(1).Text = Strings.FormatNumber(dTotalInertia, 3, TriState.True)
    '    TotalSystemInertiaAtTheSheave_lbl(1).Text = Strings.FormatNumber(dTotalInertiaAtSheave, 3, TriState.True)
    '    CompType_lbl(1).Text = IIf(String.IsNullOrEmpty(ME_PIT01Car_typ.CompensationType), "None", ME_PIT01Car_typ.CompensationType)
    '    NumberOfComps_lbl(1).Text = IIf(ME_PIT01Car_typ.CableChainSize = "Unknown", "Unknown", CStr(ME_PIT01Car_typ.CableChainQty))
    '    CompSize_lbl(1).Text = IIf(String.IsNullOrEmpty(ME_PIT01Car_typ.CableChainSize), "0.00", ME_PIT01Car_typ.CableChainSize)
    '    If ME_PIT01Car_typ.CableChainQty > 0 Then
    '        If Strings.Left(ME_PIT01Car_typ.CableChainSize, 2) = "WF" Then
    '            TotalCompWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(Strings.Mid(ME_PIT01Car_typ.CableChainSize, 3, 2)) * ME_PIT01Car_typ.CableChainQty / 10, 4, TriState.True)
    '            CompUnitWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(TotalCompWeight_lbl(1).Text) / ME_PIT01Car_typ.CableChainQty, 4, TriState.True)
    '        Else
    '            CompUnitWeight_lbl(1).Text = Strings.FormatNumber(IIf(Conversion.Val(MN_TRQ01_typ.CompensationWeight) = 0, Get_CompUnitWeight(), Conversion.Val(MN_TRQ01_typ.CompensationWeight) / ME_PIT01Car_typ.CableChainQty), 4, TriState.True)
    '            TotalCompWeight_lbl(1).Text = Strings.FormatNumber(IIf(Conversion.Val(MN_TRQ01_typ.CompensationWeight) = 0, Conversion.Val(CStr(Get_CompUnitWeight())) * ME_PIT01Car_typ.CableChainQty, MN_TRQ01_typ.CompensationWeight), 4, TriState.True)
    '        End If
    '    ElseIf ME_PIT01Car_typ.CableChainSize = "Unknown" Then
    '        CompUnitWeight_lbl(1).Text = "Unknown"
    '        TotalCompWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.CompensationWeight), 4, TriState.True)
    '    End If
    '    IdealCompWeight_lbl(1).Text = Strings.FormatNumber(dIdealCompWeight, 4, TriState.True)
    '    CompSheaveJ_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.CompSheaveJ), 2, TriState.True)
    '    If Conversion.Val(MN_TRQ01_typ.CompSheaveWt) > 0 Then
    '        CompSheaveWeight_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_TRQ01_typ.CompSheaveWt), 3, TriState.True)
    '    Else
    '        CompSheaveWeight_lbl(1).Text = " 0"
    '    End If
    '    CompSheaveDiameter_lbl(1).Text = CStr(Conversion.Val(MN_TRQ01_typ.SheaveDiameter))
    '    Dependents.Set_InputVoltage()
    '    InputVoltageToDrive_lbl(1).Text = MN_TRQ01_typ.InputVoltage
    '    BuildingPowerSupplyVoltage_lbl(1).Text = CStr(ME_COM01Car_typ.PowerSupply)
    '    If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '        VoltageFullLoadUp_lbl(1).Text = Format(Conversion.Val(VFLU), "0.##")
    '        Amps_lbl(1).Text = Format(Conversion.Val(IDC1), "0.##")
    '        FullFieldVoltage_lbl(1).Text = ME_MRM01Car_typ.VFF
    '        FullFieldCurrent_lbl(1).Text = ME_MRM01Car_typ.IFF
    '        FanVoltage_lbl(1).Text = ME_MRM01Car_typ.VFan
    '        FanCurrent_lbl(1).Text = ME_MRM01Car_typ.IFan
    '    End If

    'End Sub
    'Private Sub PrepareThisForm()

    '    SetPosition_obj.SetFormSizePos(Me)
    '    SetFormCaption(ENGINEERING_FORMS, MN_TRQ03_MENU_INDEX)
    '    Torque2InputFields()
    '    Torque2OutputFields()

    'End Sub
    'Private Sub MN_TRQ03_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    '    FormsAfterMatch()
    'End Sub
    'Public Sub Fields2Type()

    'End Sub
    'Public Sub Validate_Renamed()

    'End Sub
End Class