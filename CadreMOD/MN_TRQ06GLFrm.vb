Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic
Imports System
Partial Friend Class MN_TRQ06GL_frm
    Inherits System.Windows.Forms.Form
    'Private Sub MN_TRQ06GL_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

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
    '        Results_lbl.Visible = False
    '        NotAvailable_lbl.Visible = True
    '        HeatEmissionResults_Frame.Visible = False
    '        CurrentAndPowerResults_Frame.Visible = False
    '        InputData_fra(0).Visible = False
    '    Else
    '        Results_lbl.Visible = True
    '        NotAvailable_lbl.Visible = False
    '        HeatEmissionResults_Frame.Visible = True
    '        CurrentAndPowerResults_Frame.Visible = True
    '        InputData_fra(0).Visible = True
    '        DisplayPowerData()
    '        Torque2DebugFile()
    '    End If

    'End Sub
    'Public Sub DisplayPowerData()
    '    Dim s As String = ""

    '    DriveSelection_lbl(1).Text = "Drive Type = " & Strings.Chr(34).ToString() & ME_MRM01Car_typ.ControllerType & Strings.Chr(34).ToString() & Environment.NewLine
    '    Transformer_lbl(1).Text = sTransformerRequired

    '    If sTransformerRequired = "Transformer Not Required" Then
    '        E1_lbl(1).Text = "NA"
    '    Else
    '        E1_lbl(1).Text = Format(E1, "0.00")
    '    End If
    '    IDC1_lbl(1).Text = Format(Conversion.Val(IDC1), "0.00")
    '    IDC2_lbl(1).Text = Format(Conversion.Val(IDC2), "0.##")
    '    IDC3_lbl(1).Text = Format(Conversion.Val(IDC3), "0.##")
    '    IDC4_lbl(1).Text = Format(Conversion.Val(IDC4), "0.##")
    '    IDC5_lbl(1).Text = Format(Conversion.Val(IDC5), "0.##")
    '    IDC6_lbl(1).Text = Format(Conversion.Val(IDC6), "0.##")

    '    RunningLineCurrentFLU_lbl(1).Text = "IAC1 = " & Format(IAC1, "0.00") & " A"
    '    RunningLineCurrentFLU_lbl(2).Text = "KWAC1 = " & Format(KWAC1, "0.00") & " kW"
    '    AcceleratingLineCurrentFLU_lbl(1).Text = "IAC2 = " & Format(IAC2, "0.00") & " A"
    '    AcceleratingLineCurrentFLU_lbl(2).Text = "KWAC2 = " & Format(KWAC2, "0.00") & " kW"
    '    RegendCurrentFLD_lbl(1).Text = "IAC4 = " & Format(IAC4, "0.00") & " A"
    '    RegendCurrentFLD_lbl(2).Text = "KWAC4 = " & Format(KWAC4, "0.00") & " kW"
    '    RegendCurrentFLD125_lbl(1).Text = "IAC5 = " & Format(IAC5, "0.00") & " A"
    '    RegendCurrentFLD125_lbl(2).Text = "KWAC5 = " & Format(KWAC5, "0.00") & " kW"
    '    RegendCurrentDFLD_lbl(1).Text = "IAC3 = " & Format(IAC3, "0.00") & " A"
    '    RegendCurrentDFLD_lbl(2).Text = "KWAC3 = " & Format(KWAC3, "0.00") & " kW"
    '    RegendCurrentDFLD125_lbl(1).Text = "IAC6 = " & Format(IAC6, "0.00") & " A"
    '    RegendCurrentDFLD125_lbl(2).Text = "KWAC6 = " & Format(KWAC6, "0.00") & " kW"

    '    PeakInrushCurrent_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.PeakInrushCurrent), "0.00") & " A"

    '    If ME_MRM01Car_typ.ControllerType = DRIVETYPE_SCRDC Then
    '        SystemWithoutAnAutoTransformer_lbl(1).Text = Format(0, "0.00")
    '        SystemWithoutAnAutoTransformer_lbl(2).Text = Format(0, "0.00")
    '    Else
    '        SystemWithoutAnAutoTransformer_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformer), "0.00")
    '        SystemWithoutAnAutoTransformer_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithoutTransformerSS), "0.00")
    '    End If

    '    SystemWithAnAutoTransformer_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformer), "0.00")
    '    SystemWithAnAutoTransformer_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseWithTransformerSS), "0.00")

    '    Cabinet_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseCabinet), "0.00")
    '    Cabinet_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseCabinetSS), "0.00")

    '    MotorAndMachine_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachine), "0.00")
    '    MotorAndMachine_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseMotorAndMachineSS), "0.00")

    '    AutoTransformer_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformer), "0.00")
    '    AutoTransformer_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseAutoTransformerSS), "0.00")

    '    Choke_lbl(1).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseChoke), "0.00")
    '    Choke_lbl(2).Text = Format(Conversion.Val(MN_PowerData_GEARLESS_typ.HeatReleaseChokeSS), "0.00")

    'End Sub
    'Private Sub MN_TRQ06GL_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

    '    FormLoadWasProcessed = True
    '    PrepareThisForm()

    'End Sub
    'Public Sub Validate_Renamed()

    'End Sub
    'Private Sub MN_TRQ06GL_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    'End Sub
End Class