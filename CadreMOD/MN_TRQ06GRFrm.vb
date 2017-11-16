Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Partial Friend Class MN_TRQ06GR_frm
    Inherits System.Windows.Forms.Form
    'Private Sub MN_TRQ06GR_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '    If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
    '        UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
    '    End If
    '    If FormLoadWasProcessed Then
    '        FormLoadWasProcessed = False
    '    Else
    '        PrepareThisForm()
    '    End If

    'End Sub

    'Private Sub PrepareThisForm()

    '    SetPosition_obj.SetFormSizePos(Me)
    '    SetFormCaption(ENGINEERING_FORMS, MN_TRQ06_MENU_INDEX)
    '    If ME_MRM01Car_typ.ControllerVendor = MCE And (ME_MRM01Car_typ.Machine = "Replace" Or ME_MRM01Car_typ.Machine = "New") Then
    '        NotAvailable_lbl.Visible = True
    '        HeatEmissionResults_Frame.Visible = False
    '        Frame1.Visible = False
    '        Output_fra.Visible = False
    '        DriveSelection_fra.Visible = False
    '    Else
    '        NotAvailable_lbl.Visible = False
    '        HeatEmissionResults_Frame.Visible = True
    '        Frame1.Visible = True
    '        Output_fra.Visible = True
    '        DriveSelection_fra.Visible = True
    '        DisplayPowerData()
    '        Torque2DebugFile()
    '    End If

    'End Sub
    'Public Sub DisplayPowerData()
    '    Dim s As String = ""

    '    If ME_COM01Car_typ.PowerSupply = ("460") Or ME_COM01Car_typ.PowerSupply = ("480") Then
    '        TransformerRequired_lbl(1).Text = "Not Required"
    '    Else
    '        TransformerRequired_lbl(1).Text = "Required"
    '    End If
    '    DriveModel_lbl(1).Text = MN_TRQ01_typ.DriveModel
    '    DriveType_lbl(1).Text = IIf(Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR", DRIVETYPE_BR, DRIVETYPE_PF1)
    '    PeakInrushCurrent_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PeakCurrent), 2, TriState.True)
    '    If sDriveSelection = "Error" Then
    '        TransformerPower_lbl(1).Visible = False
    '        TransformerPower_lbl(3).Visible = False
    '        TransformerPower_lbl(2).Visible = True
    '        TransformerPower_lbl(2).Text = " ERROR! Exceeds VF122BR drive limitations."
    '        BuildingVoltage_lbl(1).Text = ""
    '        TransformerCurrent_lbl(1).Text = ""
    '    Else
    '        TransformerPower_lbl(1).Visible = True
    '        TransformerPower_lbl(3).Visible = True
    '        TransformerPower_lbl(2).Visible = False
    '        TransformerPower_lbl(1).Text = CStr(MN_TRQ01_typ.Required_KVA)
    '        TransformerPower_lbl(5).Text = CStr(MN_TRQ01_typ.Calculated_KVA)
    '        BuildingVoltage_lbl(1).Text = CStr(ME_COM01Car_typ.PowerSupply) & " Volts"
    '        s = Strings.FormatNumber(MN_TRQ01_typ.Required_KVA * 1000 / (ME_COM01Car_typ.PowerSupply * 3 ^ 0.5), 2, TriState.True)
    '        TransformerCurrent_lbl(1).Text = s
    '    End If
    '    SystemWithoutAnAutoTransformer_lbl(1).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformer), 2)
    '    SystemWithoutAnAutoTransformer_lbl(2).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithoutTransformerSS), 2)
    '    SystemWithAnAutoTransformer_lbl(1).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithTransformer), 2)
    '    SystemWithAnAutoTransformer_lbl(2).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseWithTransformerSS), 2)
    '    Cabinet_lbl(1).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseCabinet), 2)
    '    Cabinet_lbl(2).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseCabinetSS), 2)
    '    MotorAndMachine_lbl(1).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachine), 2)
    '    MotorAndMachine_lbl(2).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseMotorAndMachineSS), 2)
    '    AutoTransformer_lbl(1).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseAutoTransformer), 2)
    '    AutoTransformer_lbl(2).Text = Math.Round(Conversion.Val(MN_PowerData_GEARED_typ.HeatReleaseAutoTransformerSS), 2)
    '    PowerData_Label_lbl.Text = New String(" "c, 76) & "RFLU" & New String(" "c, 40) & "AFLU"
    '    PowerFromTheConverter_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_RFLU), 2, TriState.True)
    '    CurrentIntoTheConverter_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_RFLU), 2, TriState.True)
    '    LinePower_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LinePower_RFLU), 2, TriState.True) & Environment.NewLine
    '    LineCurrent_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_RFLU), 2, TriState.True) & Environment.NewLine
    '    PowerFromTheConverter_lbl(2).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_AFLU), 2, TriState.True) & Environment.NewLine
    '    CurrentIntoTheConverter_lbl(2).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentIntoConverter_AFLU), 2, TriState.True) & Environment.NewLine
    '    LinePower_lbl(2).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LinePower_AFLU), 2, TriState.True) & Environment.NewLine
    '    LineCurrent_lbl(2).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.LineCurrent_AFLU), 2, TriState.True)
    '    PF1_lbl.Text = New String(" "c, 76) & "RFLD" & New String(" "c, 40) & "DFLD"
    '    If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
    '        PF1_lbl.Visible = False
    '        Line1(0).Visible = False
    '        Line1(2).Visible = False
    '        For i As Integer = 0 To 4
    '            CurrentFromConverterPF1_lbl(i).Visible = False
    '            PowerFromConverterPF1_lbl(i).Visible = False
    '        Next i
    '    Else
    '        For i As Integer = 0 To 4
    '            CurrentFromConverterPF1_lbl(i).Visible = True
    '            PowerFromConverterPF1_lbl(i).Visible = True
    '        Next i
    '        PF1_lbl.Visible = True
    '        Line1(0).Visible = True
    '        Line1(2).Visible = True
    '        PowerFromConverterPF1_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_TRFLU), 2, TriState.True)
    '        PowerFromConverterPF1_lbl(3).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.PowerFromConverter_TSFLD), 2, TriState.True)
    '        CurrentFromConverterPF1_lbl(1).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TRFLU), 2, TriState.True)
    '        CurrentFromConverterPF1_lbl(3).Text = Strings.FormatNumber(Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD), 2, TriState.True)
    '    End If

    'End Sub
    'Private Sub MN_TRQ06GR_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

    '    FormLoadWasProcessed = True
    '    PrepareThisForm()

    'End Sub
    'Public Sub Validate_Renamed()

    'End Sub
    'Private Sub MN_TRQ06GR_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    'End Sub
End Class