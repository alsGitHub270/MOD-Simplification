Option Strict Off
Option Explicit On
'Imports UpgradeHelpers.VB6.Gui
'Imports UpgradeHelpers.VB6.Utils
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Drawing
Imports System.Windows.Forms
Partial Friend Class MN_TRQ02_frm
    Inherits System.Windows.Forms.Form
    '    Private Sub MN_TRQ02_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '        If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
    '            UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
    '        End If
    '        If FormLoadWasProcessed Then
    '            FormLoadWasProcessed = False
    '        Else
    '            PrepareThisForm()
    '        End If

    '    End Sub

    '    Private bRopeValidation As Boolean

    '    Private Sub PrepareThisForm()

    '        SystemData_fra.Left = 0
    '        WrapAngleCalc_fra.Left = 0
    '        RopingAndRelatedData_fra.Left = 0
    '        CompensationData_fra.Left = 0
    '        Software_fra.Left = 0
    '        SheaveData_fra.Left = SystemData_fra.Width + 3
    '        DeflectorSecondarySheave_fra.Left = SheaveData_fra.Left
    '        OnlyBasement_fra.Left = SheaveData_fra.Left
    '        Only2To1Roping_fra.Left = SheaveData_fra.Left
    '        RopeModifiers_fra.Left = SheaveData_fra.Left + SheaveData_fra.Width + 3
    '        MotorDrive_fra.Left = RopeModifiers_fra.Left
    '        ACMotor_fra.Left = RopeModifiers_fra.Left
    '        Autotransformer_fra.Left = RopeModifiers_fra.Left
    '        FMM200_fra.Left = RopeModifiers_fra.Left
    '        DriveCalcValues_fra.Left = Software_fra.Left
    '        MachineHand_fra.Left = RopeModifiers_fra.Left
    '        SetPosition_obj.SetFormSizePos(Me)
    '        SetFormCaption(ENGINEERING_FORMS, MN_TRQ02_MENU_INDEX)
    '        SortByTabOrder()
    '        bSkipFields2Type = True
    '        bJobNumber = True
    '        Load_ListBoxes()
    '        InitMachineHand_spr()
    '        bJobNumber = True
    '        PreTorque()
    '        Type2Fields()
    '        bJobNumber = False
    '        Set_Fields_Grey()

    '    End Sub
    '    Private Sub CarSheaveDiameter_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CarSheaveDiameter_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CarSheaveDiameter_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveDiameter_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, CarSheaveDiameter_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.CarSheaveDiameter <> CarSheaveDiameter_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeCarTopSheaveDiameterCalculated = True
    '                Dependents.StatusChangeTopOfCarJ = True
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Dependents.StatusChangeTopOfCarJ = False
    '                Dependents.StatusChangeCarTopSheaveDiameterCalculated = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarWeightCalculated_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CarWeightCalculated_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CarWeightCalculated_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarWeightCalculated_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, CarWeightCalculated_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If CarWeightCalculated_txt.Text <> MN_TRQ01_typ.CarWeightCalculated Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CompensationWeight_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CompensationWeight_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CompensationWeight_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationWeight_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, CompensationWeight_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If CompensationWeight_txt.Text <> MN_TRQ02_typ.CompensationWeight Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CompSheaveJ_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CompSheaveJ_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CompSheaveJ_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompSheaveJ_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, CompSheaveJ_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If CompSheaveJ_txt.Text <> MN_TRQ01_typ.CompSheaveJ Then
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.CompSheaveJ = CompSheaveJ_txt.Text
    '                CompSheaveJ_ChangeColor()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CompSheaveWeight_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompSheaveWeight_txt.Leave

    '        If CompSheaveWeight_txt.Text <> MN_TRQ01_typ.CompSheaveWt Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub Counterweight_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Counterweight_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub Counterweight_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Counterweight_txt.Leave

    '        If Counterweight_txt.Text <> MN_TRQ01_typ.Counterweight Then
    '            OptionalTitle = "Counterweight Validation"
    '            If ValidateTextBoxInput_Text(Me, Counterweight_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(40), CStr(50)) = ENTRY_VALID Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CwtSheaveDiameter_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CwtSheaveDiameter_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CwtSheaveDiameter_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CwtSheaveDiameter_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, CwtSheaveDiameter_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If CwtSheaveDiameter_txt.Text <> MN_TRQ01_typ.CwtSheaveDiameter Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeCwtTopSheaveDiameterCalculated = True
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Dependents.StatusChangeCwtTopSheaveDiameterCalculated = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub DeflectorSheave_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles DeflectorSheave_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub DeflectorSheave_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles DeflectorSheave_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, DeflectorSheave_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.DeflectorSheaveDiameter <> DeflectorSheave_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                MN_TRQ01_typ.DeflectorSheaveJ = CStr(0)
    '                Dependents.StatusChangeDeflectorSheaveDiameterCalculated = True
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Dependents.StatusChangeDeflectorSheaveDiameterCalculated = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub DriveModel_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles DriveModel_cmb.SelectedIndexChanged

    '        If MN_TRQ01_typ.DriveModel <> DriveModel_cmb.Text Then
    '            If DriveModel_cmb.Text = "VF85BR" Then
    '                MsgBox("Drive Model VF85BR is obsolete. You will not be able to book this Job.", 48, "Drive Model Validation.")
    '            End If
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeDrive = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeDrive = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub IdlerSheaveDiameter_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles IdlerSheaveDiameter_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub IdlerSheaveDiameter_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles IdlerSheaveDiameter_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, IdlerSheaveDiameter_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.IdlerSheaveDiameter <> IdlerSheaveDiameter_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeIdlerSheaveDiameterCalculated = True
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Dependents.StatusChangeIdlerSheaveDiameterCalculated = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub len1_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles len1_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub len1_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles len1_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, len1_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(100)) = ENTRY_VALID Then
    '            If len1_txt.Text <> MN_TRQ01_typ.len1 Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub len2_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles len2_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub len2_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles len2_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, len2_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(100)) = ENTRY_VALID Then
    '            If len2_txt.Text <> MN_TRQ01_typ.len2 Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub len3_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles len3_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub len3_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles len3_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, len3_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(100)) = ENTRY_VALID Then
    '            If len3_txt.Text <> MN_TRQ01_typ.len3 Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub NominalMotorHP_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles NominalMotorHP_cmb.SelectedIndexChanged

    '        If MN_TRQ01_typ.NominalMotorHP <> NominalMotorHP_cmb.Text Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub OverheadSheaveInertia_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles OverheadSheaveInertia_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub OverheadSheaveInertia_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles OverheadSheaveInertia_txt.Leave

    '        If MN_TRQ01_typ.OverheadSheaveInertia <> OverheadSheaveInertia_txt.Text Then
    '            If ValidateTextBoxInput_Text(Me, OverheadSheaveInertia_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.StatusChangeIdlerSheaveJ = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeIdlerSheaveJ = False
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private isInitializingComponent As Boolean
    '    Private Sub RequiredKVA_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RequiredKVA_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If MN_TRQ01_typ.Required_KVA <> Conversion.Val(RequiredKVA_cmb.Text) Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub RequiredKVA_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RequiredKVA_cmb.SelectedIndexChanged

    '        If MN_TRQ01_typ.Required_KVA <> Conversion.Val(RequiredKVA_cmb.Text) Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub RopeDrop_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles RopeDrop_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub RopeDrop_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeDrop_txt.Leave

    '        If MN_TRQ01_typ.RopeDrop <> RopeDrop_txt.Text Then
    '            If ConfirmAmendment(RopeDrop_txt, RopeDrop_lbl, MN_TRQ01_typ.RopeDrop) Then

    '                MDIChildDirty = True
    '                Fields2Type()
    '                ME_MRM01Car_typ.CarToCwtRopeDrop = MN_TRQ01_typ.RopeDrop
    '                bWrapAngleDependentChange = True
    '                Dependents.MOD_Parent()
    '                bWrapAngleDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                RopeDrop_txt.Text = MN_TRQ01_typ.RopeDrop
    '            End If

    '        End If

    '    End Sub
    '    Private Sub CarSheaveJ_ChangeColor()
    '        Dim s As String = ""
    '        Dim i, j As Integer

    '        On Error Resume Next

    '        If MN_TRQ01_typ.CarSheaveJ <> CarSheaveJ_txt.Text Then
    '            MN_TRQ01_typ.CarSheaveJ = CarSheaveJ_txt.Text
    '            If CarSheaveJ_txt.Text = "" Then
    '                CarSheaveJ_txt.BackColor = IIf(CarSheaveJ_txt.Enabled, Color.Yellow, Color.White)
    '            Else
    '                If Conversion.Val(CarTopSheaveJdefault) = Conversion.Val(CarSheaveJ_txt.Text) And ME_MRM01Car_typ.RopingNew = "2:1" Then
    '                    If bJobNumber Then
    '                        If CarSheaveDiameter_txt.Text = "" Then
    '                            CarSheaveJ_txt.BackColor = Color.White
    '                        Else
    '                            j = Conversion.Val(CarSheaveDiameter_txt.Text)
    '                            If j > Conversion.Val(CarSheaveDiameter_txt.Text) Then j -= 1
    '                            If j > 9 Then
    '                                For i = j To j - 5 Step -1
    '                                    'UPGRADE_WARNING: (1068) cCarTopSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                                    s = CStr(cCarTopSheave(Conversion.Str(i).Trim()))
    '                                    If Information.Err().Number = 0 Then
    '                                        CarSheaveJ_txt.BackColor = IIf((CarTopSheaveJdefault) = Conversion.Val(s) / 100, Color.White, Color.Cyan)
    '                                        Exit Sub
    '                                    Else
    '                                        Information.Err().Clear()
    '                                    End If
    '                                Next i
    '                                If i = j - 6 Then CarSheaveJ_txt.BackColor = Color.White
    '                            Else
    '                                CarSheaveJ_txt.BackColor = Color.White
    '                            End If
    '                        End If
    '                    Else
    '                        CarSheaveJ_txt.BackColor = Color.White
    '                    End If
    '                ElseIf Conversion.Val(CarTopSheaveJdefault) = 0 Then
    '                    CarSheaveJ_txt.BackColor = Color.White
    '                Else
    '                    CarSheaveJ_txt.BackColor = Color.Cyan
    '                End If
    '            End If
    '        Else
    '            s = ""
    '            If Not CarSheaveJ_txt.Enabled Then
    '                CarSheaveJ_txt.BackColor = Color.White
    '            ElseIf Conversion.Val(CarSheaveJ_txt.Text) = 0 And CarSheaveJ_txt.Enabled Then
    '                CarSheaveJ_txt.BackColor = Color.Yellow
    '            Else
    '                Select Case ME_CAR01Car_typ.TopOfCarSheave
    '                    Case "Replace", "New"
    '                        j = Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter)
    '                        If j > Conversion.Val(MN_TRQ01_typ.CarSheaveDiameter) Then j -= 1
    '                    Case Else
    '                        j = Conversion.Val(CarSheaveDiameter_txt.Text)
    '                        If j > Conversion.Val(CarSheaveDiameter_txt.Text) Then j -= 1
    '                End Select
    '                If j > 19 And j < 41 Then
    '                    For i = j To j - 5 Step -1
    '                        'UPGRADE_WARNING: (1068) cCarTopSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                        s = CStr(cCarTopSheave(Conversion.Str(i).Trim()))
    '                        If Information.Err().Number = 0 Then
    '                            CarSheaveJ_txt.BackColor = IIf((CarTopSheaveJdefault) = Conversion.Val(s) / 100, Color.White, Color.Cyan)
    '                            Exit Sub
    '                        Else
    '                            Information.Err().Clear()
    '                        End If
    '                    Next i
    '                    If i = j - 6 Then CarSheaveJ_txt.BackColor = Color.White
    '                Else
    '                    CarSheaveJ_txt.BackColor = Color.Cyan
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CwtSheaveJ_ChangeColor()
    '        Dim s As String = ""
    '        Dim i, j As Integer

    '        On Error Resume Next

    '        If MN_TRQ01_typ.CwtSheaveJ <> CwtSheaveJ_txt.Text Then
    '            MN_TRQ01_typ.CwtSheaveJ = CwtSheaveJ_txt.Text
    '            If CwtSheaveJ_txt.Text = "" Then
    '                CwtSheaveJ_txt.BackColor = IIf(CwtSheaveJ_txt.Enabled, Color.Yellow, Color.White)
    '            Else
    '                If Conversion.Val(CwtTopSheaveJdefault) = Conversion.Val(CwtSheaveJ_txt.Text) And ME_MRM01Car_typ.RopingNew = "2:1" Then
    '                    If bJobNumber Then
    '                        If CwtSheaveDiameter_txt.Text = "" Then
    '                            CwtSheaveJ_txt.BackColor = Color.White
    '                        Else
    '                            j = Conversion.Val(CwtSheaveDiameter_txt.Text)
    '                            If j > Conversion.Val(CwtSheaveDiameter_txt.Text) Then j -= 1
    '                            If j > 9 Then
    '                                For i = j To j - 5 Step -1
    '                                    'UPGRADE_WARNING: (1068) cCwtTopSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                                    s = CStr(cCwtTopSheave(Conversion.Str(i).Trim()))
    '                                    If Information.Err().Number = 0 Then
    '                                        CwtSheaveJ_txt.BackColor = IIf((CwtTopSheaveJdefault) = Conversion.Val(s) / 100, Color.White, Color.Cyan)
    '                                        Exit Sub
    '                                    Else
    '                                        Information.Err().Clear()
    '                                    End If
    '                                Next i
    '                                If i = j - 6 Then CwtSheaveJ_txt.BackColor = Color.White
    '                            Else
    '                                CwtSheaveJ_txt.BackColor = Color.White
    '                            End If
    '                        End If
    '                    Else
    '                        CwtSheaveJ_txt.BackColor = Color.White
    '                    End If
    '                ElseIf Conversion.Val(CwtTopSheaveJdefault) = 0 Then
    '                    CwtSheaveJ_txt.BackColor = Color.White
    '                Else
    '                    CwtSheaveJ_txt.BackColor = Color.Cyan 'vbMagenta
    '                End If
    '            End If
    '        Else
    '            s = ""
    '            If Not CwtSheaveJ_txt.Enabled Then
    '                CwtSheaveJ_txt.BackColor = Color.White
    '            ElseIf Conversion.Val(CwtSheaveJ_txt.Text) = 0 And CwtSheaveJ_txt.Enabled Then
    '                CwtSheaveJ_txt.BackColor = Color.Yellow
    '            Else
    '                Select Case ME_HstWay02Car_typ.HWCwtSheave
    '                    Case "Replace", "New"
    '                        j = Conversion.Val(MN_TRQ01_typ.CwtSheaveDiameter)
    '                        If j > Conversion.Val(MN_TRQ01_typ.CwtSheaveDiameter) Then j -= 1
    '                    Case Else
    '                        j = Conversion.Val(CwtSheaveDiameter_txt.Text)
    '                        If j > Conversion.Val(CwtSheaveDiameter_txt.Text) Then j -= 1
    '                End Select
    '                If j > 19 And j < 37 Then
    '                    For i = j To j - 5 Step -1
    '                        'UPGRADE_WARNING: (1068) cCwtTopSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                        s = CStr(cCwtTopSheave(Conversion.Str(i).Trim()))
    '                        If Information.Err().Number = 0 Then
    '                            CwtSheaveJ_txt.BackColor = IIf((CwtTopSheaveJdefault) = Conversion.Val(s) / 100, Color.White, Color.Cyan)
    '                            Exit Sub
    '                        Else
    '                            Information.Err().Clear()
    '                        End If
    '                    Next i
    '                    If i = j - 6 Then CwtSheaveJ_txt.BackColor = Color.White
    '                Else
    '                    CwtSheaveJ_txt.BackColor = Color.Cyan
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CompSheaveJ_ChangeColor()
    '        Dim s As String = ""
    '        Dim i, j As Integer

    '        On Error Resume Next

    '        MN_TRQ01_typ.CompSheaveJ = CompSheaveJ_txt.Text
    '        If Conversion.Val(CompSheaveJ_txt.Text) = 0 Then
    '            If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
    '                If Dependents.SheaveDiameterTQ = SET_TO_ACTIVE Then
    '                    CompSheaveJ_txt.BackColor = Color.Yellow
    '                Else
    '                    CompSheaveJ_txt.BackColor = Color.White
    '                End If
    '            Else
    '                If Dependents.SheaveDiameterTQ = SET_TO_ACTIVE Then
    '                    CompSheaveJ_txt.BackColor = Color.Yellow
    '                Else
    '                    CompSheaveJ_txt.BackColor = Color.White
    '                End If
    '            End If
    '        Else
    '            If Conversion.Val(CompSheaveJdefault) = Conversion.Val(CompSheaveJ_txt.Text) Then
    '                If bJobNumber Then
    '                    If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
    '                        CompSheaveJ_txt.BackColor = Color.White
    '                    Else
    '                        j = Conversion.Val(MN_TRQ01_typ.SheaveDiameter)
    '                        If j >= Conversion.Val(MN_TRQ01_typ.SheaveDiameter) And j > 20 And j < 51 Then j -= 1
    '                        If j > 9 And j <= 50 Then
    '                            For i = j To j - 10 Step -1
    '                                'UPGRADE_WARNING: (1068) cRopeCompensation.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                                s = CStr(cRopeCompensation(j))
    '                                If Information.Err().Number = 0 Then
    '                                    If (CompSheaveJdefault) = Conversion.Val(Strings.Mid(s, 7)) Then
    '                                        CompSheaveJ_txt.BackColor = Color.White
    '                                    Else
    '                                        CompSheaveJ_txt.BackColor = Color.Cyan 'vbMagenta
    '                                    End If
    '                                    Exit Sub
    '                                Else
    '                                    Information.Err().Clear()
    '                                End If
    '                            Next i
    '                            If i = j - 11 Then CompSheaveJ_txt.BackColor = Color.White
    '                        Else
    '                            CompSheaveJ_txt.BackColor = Color.White
    '                        End If
    '                    End If
    '                Else
    '                    CompSheaveJ_txt.BackColor = Color.White
    '                End If
    '            ElseIf Conversion.Val(CompSheaveJdefault) = 0 Then
    '                CompSheaveJ_txt.BackColor = Color.White
    '            Else
    '                CompSheaveJ_txt.BackColor = Color.Cyan
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarSheaveJ_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CarSheaveJ_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CwtSheaveJ_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles CwtSheaveJ_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub CarSheaveJ_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveJ_txt.Leave

    '        If MN_TRQ01_typ.CarSheaveJ <> CarSheaveJ_txt.Text Then
    '            If ValidateTextBoxInput_Text(Me, CarSheaveJ_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.StatusChangeTopOfCarJ = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeTopOfCarJ = False
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CwtSheaveJ_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CwtSheaveJ_txt.Leave

    '        If CwtSheaveJ_txt.Text <> MN_TRQ01_typ.CwtSheaveJ Then
    '            If ValidateTextBoxInput_Text(Me, CwtSheaveJ_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.StatusChangeCwtJ = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeCwtJ = False
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub DeflectorSheaveJ_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles DeflectorSheaveJ_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub DeflectorSheaveJ_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles DeflectorSheaveJ_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, DeflectorSheaveJ_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If DeflectorSheaveJ_txt.Text <> MN_TRQ01_typ.DeflectorSheaveJ Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.StatusChangeDeflectorSheaveJ = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeDeflectorSheaveJ = False
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MN_TRQ02_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

    '        FormLoadWasProcessed = True
    '        PrepareThisForm()

    '    End Sub
    '    Private Sub MN_TRQ02_frm_Resize(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Resize
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If Not SetPosition_obj.SettingFormSize And Me.WindowState <> FormWindowState.Minimized Then SetPosition_obj.AlignFrames(Me)
    '    End Sub
    '    Private Sub ForwardGearEfficiency_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles ForwardGearEfficiency_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub ForwardGearEfficiency_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ForwardGearEfficiency_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, ForwardGearEfficiency_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.ForwardGearEfficiency <> ForwardGearEfficiency_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub HiSpeedShaftInertia_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles HiSpeedShaftInertia_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub HiSpeedShaftInertia_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles HiSpeedShaftInertia_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, HiSpeedShaftInertia_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.HiSpeedShaftInertia <> HiSpeedShaftInertia_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub GearRatio1_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles GearRatio1_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub GearRatio1_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles GearRatio1_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, GearRatio1_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.GearRation1 <> GearRatio1_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub GearRatio2_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles GearRatio2_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_AND_COLON_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub GearRatio2_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles GearRatio2_txt.Leave

    '        If MN_TRQ01_typ.GearRation2 <> GearRatio2_txt.Text Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub GrooveNumber_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles GrooveNumber_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If GrooveNumber_cmb.Text <> MN_TRQ01_typ.GrooveNumber Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub GrooveNumber_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles GrooveNumber_cmb.SelectedIndexChanged

    '        If GrooveNumber_cmb.Text <> MN_TRQ01_typ.GrooveNumber Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub MachineSheaveJ_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles MachineSheaveJ_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub MachineSheaveJ_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MachineSheaveJ_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, MachineSheaveJ_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MachineSheaveJ_txt.Text <> MN_TRQ01_typ.MachineSheaveJ Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MaxShaftSheaveLoad_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles MaxShaftSheaveLoad_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub MaxShaftSheaveLoad_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MaxShaftSheaveLoad_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, MaxShaftSheaveLoad_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MaxShaftSheaveLoad_txt.Text <> MN_TRQ01_typ.MaxShaftSheaveLoad Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub ReverseGearEfficiency_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles ReverseGearEfficiency_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub ReverseGearEfficiency_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ReverseGearEfficiency_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, ReverseGearEfficiency_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.ReverseGearEfficiency <> ReverseGearEfficiency_txt.Text Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub RopeGrade_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeGrade_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If RopeGrade_cmb.Text <> MN_TRQ01_typ.RopeGrade Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            bMotorDependentChange = True
    '            Dependents.MOD_Parent()
    '            bMotorDependentChange = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub RopeGrade_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeGrade_cmb.SelectedIndexChanged

    '        If RopeGrade_cmb.Text <> MN_TRQ01_typ.RopeGrade Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub RopeOffset_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles RopeOffset_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub RopeOffset_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeOffset_txt.Leave
    '        Dim bCriteria As Boolean
    '        Dim lMax As Integer

    '        If ME_MRM01Car_typ.MachineLocation = "Overhead" Then
    '            lMax = 10
    '        Else
    '            lMax = 15
    '        End If
    '        If ValidateTextBoxInput_Text(Me, RopeOffset_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(lMax)) = ENTRY_VALID Then
    '            If RopeOffset_txt.Text <> MN_TRQ01_typ.RopeOffset Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                If Conversion.Val(RopeOffset_txt.Text.Trim()) = 0 Then
    '                    MN_TRQ01_typ.HorizontalDistance = ""
    '                    MN_TRQ01_typ.VerticalDistance = ""
    '                    WrapAngle_txt.Text = MN_TRQ01_typ.WrapAngle
    '                    WrapAngleLogic()
    '                Else
    '                    If ME_MRM01Car_typ.MachineLocation = "Overhead" Then
    '                        bCriteria = Conversion.Val(RopeOffset_txt.Text) < 0 Or Conversion.Val(RopeOffset_txt.Text) > 10
    '                    Else
    '                        bCriteria = Conversion.Val(RopeOffset_txt.Text) < 0 Or Conversion.Val(RopeOffset_txt.Text) > 15
    '                    End If
    '                    If bCriteria Then
    '                        RopeOffset_txt.BackColor = Color.Red
    '                        MN_TRQ01_typ.WrapAngle = CStr(0)
    '                    Else
    '                        RopeOffset_txt.BackColor = Color.White
    '                        WrapAngleLogic()
    '                    End If
    '                End If
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        Else
    '            RopeOffset_txt.BackColor = Color.Red
    '        End If

    '    End Sub
    '    Private Sub SheaveDiameter_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles SheaveDiameter_txt.Leave

    '        If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) <> Conversion.Val(SheaveDiameter_txt.Text) Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            MN_TRQ01_typ.CompSheaveJ = CStr(0)
    '            Dependents.StatusChangeSheaveDiameterCalculated = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeSheaveDiameterCalculated = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub SoftwareLevel_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles SoftwareLevel_txt.Enter
    '        SelectInputArea(SoftwareLevel_txt, 0, Strings.Len(SoftwareLevel_txt.Text))
    '    End Sub
    '    Private Sub SoftwareLevel_txt_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles SoftwareLevel_txt.KeyDown
    '        Dim KeyCode As Integer = eventArgs.KeyCode
    '        Dim Shift As Integer = IIf(eventArgs.Shift, 1, 0)
    '        WhichKeyPressed(KeyCode)
    '    End Sub
    '    Private Sub SoftwareLevel_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles SoftwareLevel_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub SoftwareLevel_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles SoftwareLevel_txt.Leave

    '        If SoftwareLevel_txt.Text <> MN_TRQ01_typ.SoftwareLevel Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub WrapAngle_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles WrapAngle_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub WrapAngle_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles WrapAngle_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, WrapAngle_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(360)) = ENTRY_VALID Then
    '            If WrapAngle_txt.Text <> MN_TRQ01_typ.WrapAngle Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bWrapAngleChange = True
    '                Dependents.MOD_Parent()
    '                bWrapAngleChange = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Public Sub Fields2Type()

    '        On Error GoTo err_Fields2Type

    '        If bSkipFields2Type Then
    '            Exit Sub
    '        End If
    '        MN_TRQ01_typ.RopeDrop = RopeDrop_txt.Text
    '        MN_TRQ01_typ.WrapAngle = WrapAngle_txt.Text
    '        MN_TRQ01_typ.HorizontalDistance = X1_txt.Text
    '        MN_TRQ01_typ.VerticalDistance = Y1_txt.Text
    '        MN_TRQ01_typ.RopeOffset = RopeOffset_txt.Text
    '        MN_TRQ01_typ.GrooveNumber = GrooveNumber_cmb.Text
    '        If Dependents.SheaveDiameterTQ = SET_TO_ACTIVE Then
    '            MN_TRQ01_typ.SheaveDiameter = SheaveDiameter_txt.Text
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_ACTIVE Then
    '            MN_TRQ01_typ.CompSheaveJ = CompSheaveJ_txt.Text
    '        End If
    '        If Dependents.CompensationWeightTQ = SET_TO_ACTIVE Then
    '            MN_TRQ02_typ.CompensationWeight = IIf(CompensationWeight_txt.Text = "", CStr(0), CompensationWeight_txt.Text)
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_ACTIVE Then
    '            MN_TRQ01_typ.CompSheaveWt = CompSheaveWeight_txt.Text
    '        End If
    '        MN_TRQ01_typ.SoftwareLevel = SoftwareLevel_txt.Text
    '        MN_TRQ01_typ.MachineSheaveJ = MachineSheaveJ_txt.Text
    '        MN_TRQ01_typ.GearRation1 = GearRatio1_txt.Text
    '        MN_TRQ01_typ.GearRation2 = GearRatio2_txt.Text
    '        MN_TRQ01_typ.ForwardGearEfficiency = ForwardGearEfficiency_txt.Text
    '        MN_TRQ01_typ.ReverseGearEfficiency = ReverseGearEfficiency_txt.Text
    '        MN_TRQ01_typ.HiSpeedShaftInertia = HiSpeedShaftInertia_txt.Text
    '        MN_TRQ01_typ.MaxShaftSheaveLoad = MaxShaftSheaveLoad_txt.Text
    '        If Dependents.DeflectorSheaveDiameter = SET_TO_ACTIVE And (ME_MRM01Car_typ.MachineLocation <> "Overhead" Or ME_MRM01Car_typ.MachineLocation = "Overhead" And Not (ME_HstWay02Car_typ.HoistwaySheave = "New" Or ME_HstWay02Car_typ.HoistwaySheave = "Replace")) Then
    '            MN_TRQ01_typ.DeflectorSheaveDiameter = DeflectorSheave_txt.Text
    '        End If
    '        If Dependents.DeflectorSheaveJ = SET_TO_ACTIVE Then
    '            MN_TRQ01_typ.DeflectorSheaveJ = DeflectorSheaveJ_txt.Text
    '        End If
    '        MN_TRQ01_typ.IdlerSheaveDiameter = IdlerSheaveDiameter_txt.Text
    '        MN_TRQ01_typ.OverheadSheaveInertia = OverheadSheaveInertia_txt.Text
    '        Select Case ME_CAR01Car_typ.TopOfCarSheave
    '            Case "Reuse", "Refurbish", "Relocate"
    '                MN_TRQ01_typ.CarSheaveDiameter = CarSheaveDiameter_txt.Text
    '            Case "Replace", "New", "None"
    '        End Select
    '        MN_TRQ01_typ.CarSheaveJ = CarSheaveJ_txt.Text
    '        Select Case ME_HstWay02Car_typ.HWCwtSheave
    '            Case "Reuse", "Refurbish", "Relocate"
    '                MN_TRQ01_typ.CwtSheaveDiameter = CwtSheaveDiameter_txt.Text
    '            Case "Replace", "New", "None"
    '        End Select
    '        MN_TRQ01_typ.CwtSheaveJ = CwtSheaveJ_txt.Text
    '        MN_TRQ01_typ.len1 = len1_txt.Text
    '        MN_TRQ01_typ.len2 = len2_txt.Text
    '        MN_TRQ01_typ.len3 = len3_txt.Text
    '        MN_TRQ01_typ.RopeGrade = RopeGrade_cmb.Text
    '        If Dependents.CarWeight = SET_TO_GREY Then
    '            MN_TRQ01_typ.CarWeightCalculated = CarWeightCalculated_txt.Text
    '        End If
    '        MN_TRQ01_typ.Counterweight = Counterweight_txt.Text
    '        MN_TRQ01_typ.DriveModel = DriveModel_cmb.Text
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '            MN_TRQ01_typ.NominalMotorHP = NominalMotorHP_cmb.Text
    '            dMH = Conversion.Val(MN_TRQ01_typ.NominalMotorHP)
    '        End If
    '        MN_TRQ01_typ.Required_KVA = Conversion.Val(RequiredKVA_cmb.Text)
    '        MN_TRQ01_typ.HoistMotorCurrent = Math.Round(Conversion.Val(HoistMotorCurrent_txt.Text), 1)
    '        MN_TRQ01_typ.STMQty = Conversion.Val(STMQty_txt.Text)
    '        MN_TRQ01_typ.STMLength = ConvertToSingle(STMLength_txt.Text)
    '        MN_TRQ01_typ.BlockingBeamLength = Conversion.Val(BlockingBeamLength_txt.Text)
    '        MN_TRQ01_typ.BlockingBeamLengthCar = Conversion.Val(BlockingBeamLengthCar_txt.Text)
    '        MN_TRQ01_typ.BlockingBeamLengthCwt = Conversion.Val(BlockingBeamLengthCwt_txt.Text)
    '        MN_TRQ01_typ.BlockingBeamSize = BlockingBeamSize_cmb.Text
    '        MN_TRQ01_typ.PME = ConvertToSingle(PME_txt.Text)
    '        MN_TRQ01_typ.INE = ConvertToSingle(INE_txt.Text)
    '        MN_TRQ01_typ.INA = ConvertToSingle(INA_txt.Text)
    '        MN_TRQ01_typ.UN = Conversion.Val(UN_txt.Text)
    '        MN_TRQ01_typ.PC1EG = ConvertToSingle(PC1EG_txt.Text)
    '        MN_TRQ01_typ.PC1AG = ConvertToSingle(PC1AG_txt.Text)
    '        MN_TRQ01_typ.TME = ConvertToSingle(TME_txt.Text)
    '        MN_TRQ01_typ.HoistMotorType = HoistMotorType_cmb.Text
    '        MN_TRQ01_typ.VariableMagneticDiscBrake = VariableMagneticDiscBrake_cmb.Text
    '        ReDim MN_TRQ01_typ.MachineHand(0)
    '        For iIndex As Integer = 1 To MachineHand_spr.ActiveSheet.ColumnCount
    '            ReDim Preserve MN_TRQ01_typ.MachineHand(iIndex)
    '            MN_TRQ01_typ.MachineHand(iIndex).CarUnit = Strings.Mid(MachineHand_spr.ActiveSheet.ColumnHeader.Columns(iIndex - 1).Label, 5)
    '            MN_TRQ01_typ.MachineHand(iIndex).MachineHand = MachineHand_spr.ActiveSheet.Cells(0, iIndex - 1).Text
    '        Next iIndex
    '        MN_TRQ01_typ.FZ1 = Math.Round(ConvertToSingle(FZ1_txt.Text), 3)
    '        MN_TRQ01_typ.FZ2 = Math.Round(ConvertToSingle(FZ2_txt.Text), 3)

    '        Exit Sub

    'err_Fields2Type:
    '        MessageBox.Show(Conversion.ErrorToString(), "Fields2Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Resume Next

    '    End Sub
    '    Public Sub Type2Fields()

    '        bSkipFields2Type = True
    '        isInitializingComponent = True
    '        If CarSheaveJ_txt.BackColor.Equals(Color.White) Then
    '            CarTopSheaveJdefault = MN_TRQ01_typ.CarSheaveJ
    '        End If
    '        If CwtSheaveJ_txt.BackColor.Equals(Color.White) Then
    '            CwtTopSheaveJdefault = MN_TRQ01_typ.CwtSheaveJ
    '        End If
    '        Counterweight_txt.Text = MN_TRQ01_typ.Counterweight
    '        If Dependents.CarWeight = SET_TO_GREY Then
    '            CarWeightCalculated_txt.Text = MN_TRQ01_typ.CarWeightCalculated
    '        End If
    '        Select Case ME_CAR01Car_typ.TopOfCarSheave
    '            Case "Reuse", "Refurbish", "Relocate"
    '                CarSheaveDiameter_txt.Text = MN_TRQ01_typ.CarSheaveDiameter
    '            Case "Replace", "New", "None"
    '        End Select
    '        CarSheaveJ_txt.Text = MN_TRQ01_typ.CarSheaveJ
    '        Select Case ME_HstWay02Car_typ.HWCwtSheave
    '            Case "Reuse", "Refurbish", "Relocate"
    '                CwtSheaveDiameter_txt.Text = MN_TRQ01_typ.CwtSheaveDiameter
    '            Case "Replace", "New", "None"
    '        End Select
    '        CwtSheaveJ_txt.Text = MN_TRQ01_typ.CwtSheaveJ
    '        MachineSheaveJ_txt.Text = MN_TRQ01_typ.MachineSheaveJ
    '        GearRatio1_txt.Text = MN_TRQ01_typ.GearRation1
    '        GearRatio2_txt.Text = MN_TRQ01_typ.GearRation2
    '        ForwardGearEfficiency_txt.Text = MN_TRQ01_typ.ForwardGearEfficiency
    '        ReverseGearEfficiency_txt.Text = MN_TRQ01_typ.ReverseGearEfficiency
    '        HiSpeedShaftInertia_txt.Text = MN_TRQ01_typ.HiSpeedShaftInertia
    '        MaxShaftSheaveLoad_txt.Text = MN_TRQ01_typ.MaxShaftSheaveLoad
    '        If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '            DeflectorSheave_lbl.Text = "Secondary Sheave Dia Calculated (in)"
    '            DeflectorSheaveJ_lbl.Text = "Secondary Sheave Inertia (lbs-ft-sec^2)"
    '        Else
    '            DeflectorSheave_lbl.Text = "Deflector Sheave Dia Calculated (in)"
    '            DeflectorSheaveJ_lbl.Text = "Deflector Sheave Inertia (lbs-ft-sec^2)"
    '        End If
    '        If Dependents.DeflectorSheaveDiameter = SET_TO_ACTIVE And Not (ME_MRM01Car_typ.MachineLocation = "Overhead" And (ME_HstWay02Car_typ.HoistwaySheave = "New" Or ME_HstWay02Car_typ.HoistwaySheave = "Replace")) Then
    '            If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveDiameter) = 0 Then
    '                DeflectorSheave_txt.Text = ""
    '            Else
    '                DeflectorSheave_txt.Text = MN_TRQ01_typ.DeflectorSheaveDiameter
    '            End If
    '        End If
    '        If Dependents.DeflectorSheaveJ = SET_TO_ACTIVE Then
    '            If Conversion.Val(MN_TRQ01_typ.DeflectorSheaveJ) = 0 Then
    '                DeflectorSheaveJ_txt.Text = ""
    '            Else
    '                DeflectorSheaveJ_txt.Text = MN_TRQ01_typ.DeflectorSheaveJ
    '            End If
    '        End If
    '        If Conversion.Val(MN_TRQ01_typ.IdlerSheaveDiameter) = 0 Then
    '            IdlerSheaveDiameter_txt.Text = ""
    '        Else
    '            IdlerSheaveDiameter_txt.Text = MN_TRQ01_typ.IdlerSheaveDiameter
    '        End If
    '        If Conversion.Val(MN_TRQ01_typ.OverheadSheaveInertia) = 0 Then
    '            IdlerSheaveJdefault = ""
    '            OverheadSheaveInertia_txt.Text = ""
    '        Else
    '            IdlerSheaveJdefault = MN_TRQ01_typ.OverheadSheaveInertia
    '            OverheadSheaveInertia_txt.Text = MN_TRQ01_typ.OverheadSheaveInertia
    '        End If
    '        WrapAngle_txt.Text = MN_TRQ01_typ.WrapAngle
    '        RopeOffset_txt.Text = MN_TRQ01_typ.RopeOffset
    '        X1_txt.Text = MN_TRQ01_typ.HorizontalDistance
    '        If Conversion.Val(MN_TRQ01_typ.VerticalDistance) = 0 Then
    '            Y1_txt.Text = ""
    '        Else
    '            Y1_txt.Text = Format(Conversion.Val(MN_TRQ01_typ.VerticalDistance), "0.##")
    '        End If
    '        RopeDrop_txt.Text = MN_TRQ01_typ.RopeDrop
    '        AssignListIndex(GrooveNumber_cmb, MN_TRQ01_typ.GrooveNumber)
    '        If Dependents.SheaveDiameterTQ = SET_TO_ACTIVE Then
    '            SheaveDiameter_txt.Text = MN_TRQ01_typ.SheaveDiameter
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_ACTIVE Then
    '            If Conversion.Val(MN_TRQ01_typ.CompSheaveJ) = 0 Then
    '                CompSheaveJ_txt.Text = ""
    '            Else
    '                CompSheaveJ_txt.Text = MN_TRQ01_typ.CompSheaveJ
    '            End If
    '        End If
    '        If Dependents.CompensationWeightTQ = SET_TO_ACTIVE Then
    '            If Conversion.Val(MN_TRQ02_typ.CompensationWeight) = 0 Then
    '                CompensationWeight_txt.Text = ""
    '            Else
    '                CompensationWeight_txt.Text = MN_TRQ02_typ.CompensationWeight
    '            End If
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_ACTIVE Then
    '            CompSheaveWeight_txt.Text = MN_TRQ01_typ.CompSheaveWt
    '        End If
    '        SoftwareLevel_txt.Text = MN_TRQ01_typ.SoftwareLevel
    '        len1_txt.Text = MN_TRQ01_typ.len1
    '        len2_txt.Text = MN_TRQ01_typ.len2
    '        len3_txt.Text = MN_TRQ01_typ.len3
    '        If MN_TRQ01_typ.RopeGrade = "" Then
    '            If RopeGrade_cmb.Items.Count > 0 Then
    '                MN_TRQ01_typ.RopeGrade = RopeGrade_cmb.GetListItem(0)
    '            End If
    '        End If
    '        AssignListIndex(RopeGrade_cmb, MN_TRQ01_typ.RopeGrade)
    '        AssignListIndex(DriveModel_cmb, MN_TRQ01_typ.DriveModel)
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '            AssignListIndex(NominalMotorHP_cmb, MN_TRQ01_typ.NominalMotorHP)
    '        End If
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Or ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            AssignListIndex(RequiredKVA_cmb, CStr(MN_TRQ01_typ.Required_KVA))
    '        End If
    '        HoistMotorCurrent_txt.Text = MN_TRQ01_typ.HoistMotorCurrent
    '        STMQty_txt.Text = MN_TRQ01_typ.STMQty
    '        STMLength_txt.Text = MN_TRQ01_typ.STMLength
    '        BlockingBeamLength_txt.Text = MN_TRQ01_typ.BlockingBeamLength
    '        BlockingBeamLengthCar_txt.Text = MN_TRQ01_typ.BlockingBeamLengthCar
    '        BlockingBeamLengthCwt_txt.Text = MN_TRQ01_typ.BlockingBeamLengthCwt
    '        AssignListIndex(BlockingBeamSize_cmb, MN_TRQ01_typ.BlockingBeamSize)
    '        PME_txt.Text = MN_TRQ01_typ.PME
    '        INE_txt.Text = MN_TRQ01_typ.INE
    '        INA_txt.Text = MN_TRQ01_typ.INA
    '        UN_txt.Text = MN_TRQ01_typ.UN
    '        PC1EG_txt.Text = MN_TRQ01_typ.PC1EG
    '        PC1AG_txt.Text = MN_TRQ01_typ.PC1AG
    '        TME_txt.Text = MN_TRQ01_typ.TME
    '        HoistMotorType_cmb.Text = MN_TRQ01_typ.HoistMotorType
    '        VariableMagneticDiscBrake_cmb.Text = MN_TRQ01_typ.VariableMagneticDiscBrake
    '        For iIndex As Integer = 1 To MN_TRQ01_typ.MachineHand.GetUpperBound(0)
    '            MachineHand_spr.ActiveSheet.Cells(0, iIndex - 1).Text = MN_TRQ01_typ.MachineHand(iIndex).MachineHand
    '        Next iIndex
    '        FZ1_txt.Text = MN_TRQ01_typ.FZ1
    '        FZ2_txt.Text = MN_TRQ01_typ.FZ2
    '        isInitializingComponent = False
    '        bSkipFields2Type = False

    '    End Sub
    '    Private Sub X1_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles X1_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub X1_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles X1_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, X1_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(500)) = ENTRY_VALID Then
    '            If X1_txt.Text <> MN_TRQ01_typ.HorizontalDistance Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                bWrapAngleDependentChange = True
    '                Dependents.MOD_Parent()
    '                bWrapAngleDependentChange = False
    '                Load_ListBoxes()
    '                If MN_TRQ01_typ.HorizontalDistance = "" Then
    '                    MN_TRQ01_typ.VerticalDistance = ""
    '                    MN_TRQ01_typ.RopeOffset = ""
    '                    X1_txt.BackColor = Color.White
    '                    Y1_txt.BackColor = Color.White
    '                    If ME_MRM01Car_typ.MachineModelNew <> MACHINE_FMM200 Then
    '                        RopeOffset_txt.BackColor = Color.White
    '                    End If
    '                End If
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '            If Conversion.Val(MN_TRQ01_typ.HorizontalDistance) < 0 Then
    '                X1_txt.BackColor = Color.Red
    '            Else
    '                X1_txt.BackColor = Color.White
    '            End If
    '        Else
    '            X1_txt.BackColor = Color.Red
    '        End If

    '    End Sub
    '    Private Sub Y1_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Y1_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)
    '    End Sub
    '    Private Sub Y1_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Y1_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, Y1_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(500)) <> ENTRY_VALID Then Exit Sub
    '        If Conversion.Val(Y1_txt.Text) <> Conversion.Val(MN_TRQ01_typ.VerticalDistance) Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            bWrapAngleDependentChange = True
    '            Dependents.MOD_Parent()
    '            bWrapAngleDependentChange = False
    '            Load_ListBoxes()
    '            If MN_TRQ01_typ.VerticalDistance = "" Then
    '                MN_TRQ01_typ.HorizontalDistance = ""
    '                MN_TRQ01_typ.RopeOffset = ""
    '            End If
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Public Sub OverheadSheaveInertia_ChangeColor()
    '        Dim i, j As Integer
    '        Dim s As String = ""

    '        On Error Resume Next

    '        If OverheadSheaveInertia_txt.Text = "" Then
    '            If OverheadSheaveInertia_txt.Enabled Then
    '                OverheadSheaveInertia_txt.BackColor = Color.Yellow
    '            Else
    '                OverheadSheaveInertia_txt.BackColor = Color.White
    '            End If
    '        Else
    '            If Conversion.Val(IdlerSheaveJdefault) = Conversion.Val(OverheadSheaveInertia_txt.Text) Then
    '                If bJobNumber Then
    '                    If IdlerSheaveDiameter_txt.Text = "" Then
    '                        OverheadSheaveInertia_txt.BackColor = Color.White
    '                    Else
    '                        j = Conversion.Val(IdlerSheaveDiameter_txt.Text)
    '                        If j > Conversion.Val(IdlerSheaveDiameter_txt.Text) Then j -= 1
    '                        If j > 9 Then
    '                            For i = j To j - 5 Step -1
    '                                'UPGRADE_WARNING: (1068) cIdlerSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                                s = CStr(cIdlerSheave(Conversion.Str(i).Trim()))
    '                                If Information.Err().Number = 0 Then
    '                                    If Conversion.Val(IdlerSheaveJdefault) * 100 = (s) Then
    '                                        OverheadSheaveInertia_txt.BackColor = Color.White
    '                                    Else
    '                                        OverheadSheaveInertia_txt.BackColor = Color.Cyan 'vbMagenta
    '                                    End If
    '                                    Exit For
    '                                Else
    '                                    Information.Err().Clear()
    '                                    OverheadSheaveInertia_txt.BackColor = Color.Cyan 'vbMagenta
    '                                End If
    '                            Next i
    '                        End If
    '                    End If
    '                Else
    '                    j = Conversion.Val(IdlerSheaveDiameter_txt.Text)
    '                    If j > Conversion.Val(IdlerSheaveDiameter_txt.Text) Then j -= 1
    '                    If j > 9 Then
    '                        For i = j To j - 5 Step -1
    '                            'UPGRADE_WARNING: (1068) cIdlerSheave.Item() of type Variant is being forced to String. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
    '                            s = CStr(cIdlerSheave(Conversion.Str(i).Trim()))
    '                            If Information.Err().Number = 0 Then
    '                                If (IdlerSheaveJdefault) = Conversion.Val(s) / 100 Then
    '                                    OverheadSheaveInertia_txt.BackColor = Color.White
    '                                    Exit For
    '                                End If
    '                            Else
    '                                Information.Err().Clear()
    '                            End If
    '                        Next i
    '                        If i = j - 6 Then OverheadSheaveInertia_txt.BackColor = Color.Cyan 'vbMagenta
    '                    Else
    '                        OverheadSheaveInertia_txt.BackColor = Color.Cyan 'vbMagenta
    '                    End If
    '                End If
    '            Else
    '                OverheadSheaveInertia_txt.BackColor = Color.Cyan 'vbMagenta
    '            End If
    '        End If

    '    End Sub
    '    Public Sub WrapAngleLogic()

    '        iWrapAngleLogic = GetWrapAngleLogic()
    '        Select Case iWrapAngleLogic
    '            Case 1
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                WrapAngle_txt.BackColor = Color.White
    '                X1_lbl.Enabled = True
    '                X1_txt.Enabled = True
    '                Y1_lbl.Enabled = True
    '                Y1_txt.Enabled = True
    '                Refer_lbl.Enabled = True
    '                RopeDrop_lbl.Enabled = False
    '                RopeDrop_txt.Enabled = False
    '                RopeOffset_lbl.Enabled = False
    '                RopeOffset_txt.Enabled = False
    '            Case 2, 4
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                X1_lbl.Enabled = False
    '                X1_txt.Enabled = False
    '                Y1_lbl.Enabled = False
    '                Y1_txt.Enabled = False
    '                Refer_lbl.Enabled = False
    '                RopeDrop_lbl.Enabled = False
    '                RopeDrop_txt.Enabled = False
    '                RopeOffset_lbl.Enabled = False
    '                RopeOffset_txt.Enabled = False
    '            Case 3
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                X1_lbl.Enabled = True
    '                X1_txt.Enabled = True
    '                Y1_lbl.Enabled = True
    '                Y1_txt.Enabled = True
    '                Refer_lbl.Enabled = True
    '                RopeDrop_lbl.Enabled = False
    '                RopeDrop_txt.Enabled = False
    '                If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '                    RopeOffset_lbl.Enabled = False
    '                    RopeOffset_txt.Enabled = False
    '                Else
    '                    RopeOffset_lbl.Enabled = True
    '                    RopeOffset_txt.Enabled = True
    '                End If
    '            Case 51
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                RopeDrop_lbl.Enabled = False
    '                RopeDrop_txt.Enabled = False
    '                RopeDrop_txt.Text = ""
    '                X1_lbl.Enabled = True
    '                X1_txt.Enabled = True
    '                Y1_lbl.Enabled = True
    '                Y1_txt.Enabled = True
    '                Refer_lbl.Enabled = True
    '                RopeOffset_lbl.Enabled = False
    '                RopeOffset_txt.Enabled = False
    '            Case 52
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                RopeDrop_lbl.Enabled = True
    '                RopeDrop_txt.Enabled = True
    '                X1_lbl.Enabled = False
    '                X1_txt.Enabled = False
    '                Y1_lbl.Enabled = False
    '                Y1_txt.Enabled = False
    '                Refer_lbl.Enabled = False
    '                RopeOffset_lbl.Enabled = False
    '                RopeOffset_txt.Enabled = False
    '            Case 6
    '                WrapAngle_lbl.Enabled = True
    '                WrapAngle_txt.Enabled = True
    '                RopeDrop_lbl.Enabled = False
    '                RopeDrop_txt.Enabled = False
    '                X1_lbl.Enabled = False
    '                X1_txt.Enabled = False
    '                Y1_lbl.Enabled = False
    '                Y1_txt.Enabled = False
    '                Refer_lbl.Enabled = False
    '                RopeOffset_lbl.Enabled = False
    '                RopeOffset_txt.Enabled = False
    '        End Select

    '    End Sub
    '    Public Sub Validate_Renamed()

    '        MN_TRQ02.Validate_Dependents(Me)
    '        If CounterCritical > 0 Or CounterWarning > 0 Then
    '            bTorqueCriticalError = True
    '        Else
    '            If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE And (ME_MRM01Car_typ.ControllerType = DRIVETYPE_PF1 Or _
    '               ME_MRM01Car_typ.ControllerType = DRIVETYPE_BR Or ME_MRM01Car_typ.ControllerType = DRIVETYPE_BESTPRICE) Then
    '            Else
    '                CalculateTORQUE()
    '                If CounterCritical > 0 Or CounterWarning > 0 Then
    '                    bTorqueCriticalError = True
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Set_Fields_Grey()
    '        Dim iOnly2To1Roping As Integer

    '        If Dependents.CarWeight = SET_TO_GREY Then
    '            CarWeightCalculated_txt.Enabled = True
    '            CarWeightCalculated_lbl.Enabled = True
    '        Else
    '            CarWeightCalculated_txt.Enabled = False
    '            CarWeightCalculated_lbl.Enabled = False
    '        End If
    '        If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            CarSheaveDiameter_txt.Enabled = False
    '            CarSheaveDiameter_lbl.Enabled = False
    '            CarSheaveJ_txt.Enabled = False
    '            CarSheaveJ_lbl.Enabled = False
    '            CwtSheaveDiameter_txt.Enabled = False
    '            CwtSheaveDiameter_lbl.Enabled = False
    '            CwtSheaveJ_txt.Enabled = False
    '            CwtSheaveJ_lbl.Enabled = False
    '            Only2To1Roping_fra.Enabled = False
    '        Else
    '            Select Case ME_CAR01Car_typ.TopOfCarSheave
    '                Case "Reuse", "Refurbish", "Relocate"
    '                    CarSheaveDiameter_txt.Enabled = True
    '                    CarSheaveDiameter_lbl.Enabled = True
    '                    CarSheaveJ_txt.Enabled = True
    '                    CarSheaveJ_lbl.Enabled = True
    '                Case "Replace", "New"
    '                    CarSheaveDiameter_txt.Enabled = False
    '                    CarSheaveDiameter_lbl.Enabled = False
    '                    CarSheaveJ_txt.Enabled = True
    '                    CarSheaveJ_lbl.Enabled = True
    '                Case "None"
    '                    CarSheaveDiameter_txt.Enabled = False
    '                    CarSheaveDiameter_lbl.Enabled = False
    '                    CarSheaveJ_txt.Enabled = False
    '                    CarSheaveJ_lbl.Enabled = False
    '                    iOnly2To1Roping = 1
    '            End Select
    '            Select Case ME_HstWay02Car_typ.HWCwtSheave
    '                Case "Reuse", "Refurbish", "Relocate"
    '                    CwtSheaveDiameter_txt.Enabled = True
    '                    CwtSheaveDiameter_lbl.Enabled = True
    '                    CwtSheaveJ_txt.Enabled = True
    '                    CwtSheaveJ_lbl.Enabled = True
    '                Case "Replace", "New"
    '                    CwtSheaveDiameter_txt.Enabled = False
    '                    CwtSheaveDiameter_lbl.Enabled = False
    '                    CwtSheaveJ_txt.Enabled = True
    '                    CwtSheaveJ_lbl.Enabled = True
    '                Case "None"
    '                    CwtSheaveDiameter_txt.Enabled = False
    '                    CwtSheaveDiameter_lbl.Enabled = False
    '                    CwtSheaveJ_txt.Enabled = False
    '                    CwtSheaveJ_lbl.Enabled = False
    '                    iOnly2To1Roping += 1
    '            End Select
    '            Only2To1Roping_fra.Enabled = Not (iOnly2To1Roping = 2)
    '        End If
    '        If Dependents.GearRatio1 = SET_TO_GREY Then
    '            GearRatio1_txt.Enabled = False
    '            GearRatio1_lbl.Enabled = False
    '        Else
    '            GearRatio1_txt.Enabled = True
    '            GearRatio1_lbl.Enabled = True
    '        End If
    '        If Dependents.GearRatio2 = SET_TO_GREY Then
    '            GearRatio2_txt.Enabled = False
    '            GearRatio2_lbl.Enabled = False
    '        Else
    '            GearRatio2_txt.Enabled = True
    '            GearRatio2_lbl.Enabled = True
    '        End If
    '        If Dependents.HiSpeedShaftInertia = SET_TO_GREY Then
    '            HiSpeedShaftInertia_txt.Enabled = False
    '            HiSpeedShaftInertia_lbl.Enabled = False
    '        Else
    '            HiSpeedShaftInertia_txt.Enabled = True
    '            HiSpeedShaftInertia_lbl.Enabled = True
    '        End If
    '        If Dependents.SheaveDiameterTQ = SET_TO_ACTIVE Then
    '            SheaveDiameter_lbl.Enabled = True
    '            SheaveDiameter_txt.Enabled = True
    '            If Conversion.Val(MN_TRQ01_typ.SheaveDiameter) = 0 Then
    '                SheaveDiameter_txt.BackColor = Color.Yellow
    '            Else
    '                SheaveDiameter_txt.BackColor = Color.White
    '            End If
    '        Else
    '            SheaveDiameter_lbl.Enabled = False
    '            SheaveDiameter_txt.Enabled = False
    '            SheaveDiameter_txt.BackColor = Color.White
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_ACTIVE Then
    '            CompSheaveJ_lbl.Enabled = True
    '            CompSheaveJ_txt.Enabled = True
    '        Else
    '            CompSheaveJ_lbl.Enabled = False
    '            CompSheaveJ_txt.Enabled = False
    '        End If
    '        If Dependents.CompensationWeightTQ = SET_TO_GREY Then
    '            CompensationWeight_lbl.Enabled = False
    '            CompensationWeight_txt.Enabled = False
    '            CompensationWeight_txt.BackColor = Color.White
    '        Else
    '            CompensationWeight_lbl.Enabled = True
    '            CompensationWeight_txt.Enabled = True
    '            If Conversion.Val(MN_TRQ02_typ.CompensationWeight) = 0 Then
    '                CompensationWeight_txt.BackColor = Color.Yellow
    '            Else
    '                CompensationWeight_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If Dependents.CompSheaveWeightTQ = SET_TO_GREY Then
    '            CompSheaveWeight_txt.Enabled = False
    '            CompSheaveWeight_lbl.Enabled = False
    '            CompSheaveWeight_txt.BackColor = Color.White
    '        Else
    '            CompSheaveWeight_txt.Enabled = True
    '            CompSheaveWeight_lbl.Enabled = True
    '            If Conversion.Val(MN_TRQ01_typ.CompSheaveWt) = 0 Then
    '                CompSheaveWeight_txt.BackColor = Color.Yellow
    '            Else
    '                CompSheaveWeight_txt.BackColor = Color.White
    '            End If
    '        End If
    '        CompensationData_fra.Enabled = Not (Dependents.SheaveDiameterTQ <> SET_TO_ACTIVE And Dependents.CompensationWeightTQ <> SET_TO_ACTIVE And Dependents.SheaveDiameterTQ <> SET_TO_ACTIVE And Dependents.CompSheaveWeightTQ <> SET_TO_ACTIVE)
    '        If Dependents.OnlyBasement = SET_TO_GREY Then
    '            OnlyBasement_fra.Enabled = False
    '            IdlerSheaveJdefault = ""
    '            OverheadSheaveInertia_txt.Text = ""
    '            OverheadSheaveInertia_txt.Enabled = False
    '            OverheadSheaveInertia_lbl.Enabled = False
    '            IdlerSheaveDiameter_txt.Text = ""
    '            IdlerSheaveDiameter_txt.Enabled = False
    '            IdlerSheaveDiameter_lbl.Enabled = False
    '        Else
    '            OnlyBasement_fra.Enabled = True
    '            OverheadSheaveInertia_txt.Enabled = True
    '            OverheadSheaveInertia_lbl.Enabled = True
    '            IdlerSheaveDiameter_txt.Enabled = True
    '            IdlerSheaveDiameter_lbl.Enabled = True
    '        End If
    '        If Dependents.DeflectorSheaveDiameter = SET_TO_ACTIVE And Not (ME_MRM01Car_typ.MachineLocation = "Overhead" And (ME_HstWay02Car_typ.HoistwaySheave = "New" Or ME_HstWay02Car_typ.HoistwaySheave = "Replace")) Then
    '            DeflectorSheave_lbl.Enabled = True
    '            DeflectorSheave_txt.Enabled = True
    '        Else
    '            DeflectorSheave_lbl.Enabled = False
    '            DeflectorSheave_txt.Enabled = False
    '        End If
    '        If Dependents.DeflectorSheaveJ = SET_TO_GREY Then
    '            DeflectorSecondarySheave_fra.Enabled = DeflectorSheave_lbl.Enabled
    '            DeflectorSheaveJ_lbl.Enabled = False
    '            DeflectorSheaveJ_txt.Enabled = False
    '            DeflectorSheaveJ_txt.BackColor = Color.White
    '        Else
    '            DeflectorSecondarySheave_fra.Enabled = True
    '            DeflectorSheaveJ_lbl.Enabled = True
    '            DeflectorSheaveJ_txt.Enabled = True
    '            If Conversion.Val(DeflectorSheaveJ_txt.Text) = 0 Then
    '                DeflectorSheaveJ_txt.BackColor = Color.Yellow
    '            Else
    '                If Conversion.Val(DeflectorSheaveJdefault) = Conversion.Val(DeflectorSheaveJ_txt.Text) Then
    '                    DeflectorSheaveJ_txt.BackColor = Color.White
    '                Else
    '                    DeflectorSheaveJ_txt.BackColor = Color.Cyan
    '                End If
    '            End If
    '        End If
    '        If Conversion.Val(Counterweight_txt.Text) = 0 Then
    '            Counterweight_txt.BackColor = Color.Yellow
    '        Else
    '            If Conversion.Val(Counterweight_txt.Text) > 50 Or Conversion.Val(Counterweight_txt.Text) < 40 Then
    '                Counterweight_txt.BackColor = Color.Red
    '            Else
    '                Counterweight_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            Counterweight_lbl.Text = "% Counterweight (40-50)      KG="
    '        Else
    '            Counterweight_lbl.Text = "% Counterweight (40-50)"
    '        End If
    '        If RopeDrop_txt.Enabled And Conversion.Val(RopeDrop_txt.Text) = 0 And GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '            RopeDrop_txt.BackColor = Color.Yellow
    '        Else
    '            RopeDrop_txt.BackColor = Color.White
    '        End If
    '        If WrapAngle_txt.Text = "" And WrapAngle_txt.Enabled Then
    '            WrapAngle_txt.BackColor = Color.Yellow
    '        Else
    '            WrapAngle_txt.BackColor = Color.White
    '        End If
    '        If CarSheaveDiameter_txt.Text = "" And CarSheaveDiameter_txt.Enabled Then
    '            CarSheaveDiameter_txt.BackColor = Color.Yellow
    '        Else
    '            CarSheaveDiameter_txt.BackColor = Color.White
    '        End If
    '        CarSheaveJ_ChangeColor()
    '        If CwtSheaveDiameter_txt.Text = "" And CwtSheaveDiameter_txt.Enabled Then
    '            CwtSheaveDiameter_txt.BackColor = Color.Yellow
    '        Else
    '            CwtSheaveDiameter_txt.BackColor = Color.White
    '        End If
    '        CwtSheaveJ_ChangeColor()
    '        OverheadSheaveInertia_ChangeColor()
    '        If ForwardGearEfficiency_txt.Enabled And ForwardGearEfficiency_txt.Text = "" Then
    '            ForwardGearEfficiency_txt.BackColor = Color.Yellow
    '        Else
    '            ForwardGearEfficiency_txt.BackColor = Color.White
    '        End If
    '        If ReverseGearEfficiency_txt.Enabled And ReverseGearEfficiency_txt.Text = "" Then
    '            ReverseGearEfficiency_txt.BackColor = Color.Yellow
    '        Else
    '            ReverseGearEfficiency_txt.BackColor = Color.White
    '        End If
    '        If HiSpeedShaftInertia_txt.Text = "" And HiSpeedShaftInertia_txt.Enabled Then
    '            HiSpeedShaftInertia_txt.BackColor = Color.Yellow
    '        Else
    '            HiSpeedShaftInertia_txt.BackColor = Color.White
    '        End If
    '        If GearRatio1_txt.Text = "" And GearRatio1_txt.Enabled Then
    '            GearRatio1_txt.BackColor = Color.Yellow
    '        Else
    '            GearRatio1_txt.BackColor = Color.White
    '        End If
    '        If GearRatio2_txt.Text = "" And GearRatio2_txt.Enabled Then
    '            GearRatio2_txt.BackColor = Color.Yellow
    '        Else
    '            GearRatio2_txt.BackColor = Color.White
    '        End If
    '        If MachineSheaveJ_txt.Text = "" And MachineSheaveJ_txt.Enabled Then
    '            MachineSheaveJ_txt.BackColor = Color.Yellow
    '        Else
    '            MachineSheaveJ_txt.BackColor = Color.White
    '        End If
    '        MaxShaftSheaveLoad_txt.Enabled = True
    '        MaxShaftSheaveLoad_lbl.Enabled = True
    '        If MaxShaftSheaveLoad_txt.Text = "" Then
    '            If ME_MRM01Car_typ.MachineModel = "Other" Then
    '                MaxShaftSheaveLoad_txt.Enabled = False
    '                MaxShaftSheaveLoad_lbl.Enabled = False
    '                MaxShaftSheaveLoad_txt.BackColor = Color.White
    '            Else
    '                MaxShaftSheaveLoad_txt.BackColor = Color.Yellow
    '            End If
    '        Else
    '            MaxShaftSheaveLoad_txt.BackColor = Color.White
    '        End If
    '        CompSheaveJ_ChangeColor()
    '        If Dependents.SoftwareLevel = SET_TO_GREY Then
    '            SoftwareLevel_lbl.Enabled = False
    '            SoftwareLevel_txt.Enabled = False
    '        Else
    '            SoftwareLevel_lbl.Enabled = True
    '            SoftwareLevel_txt.Enabled = True
    '        End If
    '        If Dependents.NominalMotorHP = SET_TO_GREY Then
    '            NominalMotorHP_cmb.Enabled = False
    '            NominalMotorHP_lbl.Enabled = False
    '        Else
    '            NominalMotorHP_cmb.Enabled = True
    '            NominalMotorHP_lbl.Enabled = True
    '        End If
    '        Select Case GONumbers(CurrentGOSelection).MachineType
    '            Case GEARED_TYPE
    '                ACMotor_fra.Enabled = True
    '                If Math.Round(ME_COM01Car_typ.PowerSupply) = 460 Or Math.Round(ME_COM01Car_typ.PowerSupply) = 480 Then
    '                    RequiredKVA_lbl.Enabled = False
    '                    RequiredKVA_cmb.Enabled = False
    '                    RequiredKVA_cmb.SelectedIndex = -1
    '                    Autotransformer_fra.Enabled = False
    '                Else
    '                    RequiredKVA_lbl.Enabled = True
    '                    RequiredKVA_cmb.Enabled = True
    '                    Autotransformer_fra.Enabled = True
    '                End If
    '            Case GEARLESS_TYPE
    '                ACMotor_fra.Enabled = False
    '                If ME_MRM01Car_typ.ControllerVendor = SEC Then
    '                    If ME_MRM01Car_typ.ControllerType = DRIVETYPE_BR Or ME_MRM01Car_typ.ControllerType = DRIVETYPE_PF1 Then
    '                        ACMotor_fra.Enabled = True
    '                    End If
    '                End If
    '                If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 And Math.Round(ME_COM01Car_typ.PowerSupply) <> 460 And
    '                   Math.Round(ME_COM01Car_typ.PowerSupply) <> 480 Then
    '                    RequiredKVA_lbl.Enabled = True
    '                    RequiredKVA_cmb.Enabled = True
    '                    Autotransformer_fra.Enabled = True
    '                Else
    '                    RequiredKVA_lbl.Enabled = False
    '                    RequiredKVA_cmb.Enabled = False
    '                    RequiredKVA_cmb.SelectedIndex = -1
    '                    Autotransformer_fra.Enabled = False
    '                End If
    '        End Select
    '        If DriveModel_cmb.Items.Count = 0 Or Dependents.DriveModel = SET_TO_GREY Then
    '            DriveModel_lbl.Enabled = False
    '            DriveModel_cmb.Enabled = False
    '        Else
    '            DriveModel_lbl.Enabled = True
    '            DriveModel_cmb.Enabled = True
    '        End If
    '        If Dependents.FMM200Frame_TQ = SET_TO_INVISIBLE Then
    '            FMM200_fra.Visible = False
    '            FMM200_fra.Enabled = False
    '        Else
    '            FMM200_fra.Visible = True
    '            If Dependents.FMM200Frame_TQ = SET_TO_GREY Then
    '                FMM200_fra.Enabled = False
    '            Else
    '                FMM200_fra.Enabled = True
    '                If Dependents.BlockingBeamLength = SET_TO_GREY Then
    '                    BlockingBeamLength_lbl.Enabled = False
    '                    BlockingBeamLength_txt.Enabled = False
    '                Else
    '                    BlockingBeamLength_lbl.Enabled = True
    '                    BlockingBeamLength_txt.Enabled = True
    '                End If
    '                If Dependents.BlockingBeamLengthCar = SET_TO_GREY Then
    '                    BlockingBeamLengthCar_lbl.Enabled = False
    '                    BlockingBeamLengthCar_txt.Enabled = False
    '                Else
    '                    BlockingBeamLengthCar_lbl.Enabled = True
    '                    BlockingBeamLengthCar_txt.Enabled = True
    '                End If
    '                If Dependents.BlockingBeamLengthCwt = SET_TO_GREY Then
    '                    BlockingBeamLengthCwt_lbl.Enabled = False
    '                    BlockingBeamLengthCwt_txt.Enabled = False
    '                Else
    '                    BlockingBeamLengthCwt_lbl.Enabled = True
    '                    BlockingBeamLengthCwt_txt.Enabled = True
    '                End If
    '                If ME_MRM01Car_typ.MachineModelNew = MACHINE_PMR490 Then
    '                    STMQty_lbl.Enabled = False
    '                    STMQty_txt.Enabled = False
    '                    STMLength_lbl.Enabled = False
    '                    STMLength_txt.Enabled = False
    '                    BlockingBeamSize_lbl.Enabled = False
    '                    BlockingBeamSize_cmb.Enabled = False
    '                    VariableMagneticDiscBrake_lbl.Enabled = False
    '                    VariableMagneticDiscBrake_cmb.Enabled = False
    '                Else
    '                    STMQty_lbl.Enabled = True
    '                    STMQty_txt.Enabled = True
    '                    STMLength_lbl.Enabled = True
    '                    STMLength_txt.Enabled = True
    '                    BlockingBeamSize_lbl.Enabled = True
    '                    BlockingBeamSize_cmb.Enabled = True
    '                    VariableMagneticDiscBrake_lbl.Enabled = True
    '                    VariableMagneticDiscBrake_cmb.Enabled = True
    '                End If
    '            End If
    '        End If
    '        If Dependents.DriveCalcValuesFrame_TQ = SET_TO_INVISIBLE Then
    '            DriveCalcValues_fra.Visible = False
    '            DriveCalcValues_fra.Enabled = False
    '        Else
    '            DriveCalcValues_fra.Visible = True
    '            If Dependents.DriveCalcValuesFrame_TQ = SET_TO_GREY And Dependents.TME = SET_TO_GREY And Dependents.FZ1 = SET_TO_GREY And Dependents.FZ2 = SET_TO_GREY Then
    '                DriveCalcValues_fra.Enabled = False
    '            Else
    '                DriveCalcValues_fra.Enabled = True
    '                If Dependents.DriveCalcValuesFrame_TQ = SET_TO_GREY Then
    '                    PME_lbl.Enabled = False
    '                    PME_txt.Enabled = False
    '                    PME_KW_lbl.Enabled = False
    '                    INE_lbl.Enabled = False
    '                    INE_txt.Enabled = False
    '                    INE_A_lbl.Enabled = False
    '                    INA_lbl.Enabled = False
    '                    INA_txt.Enabled = False
    '                    INA_A_lbl.Enabled = False
    '                    PC1EG_lbl.Enabled = False
    '                    PC1EG_txt.Enabled = False
    '                    PC1EG_KW_lbl.Enabled = False
    '                    PC1AG_lbl.Enabled = False
    '                    PC1AG_txt.Enabled = False
    '                    PC1AG_KW_lbl.Enabled = False
    '                Else
    '                    PME_lbl.Enabled = True
    '                    PME_txt.Enabled = True
    '                    PME_KW_lbl.Enabled = True
    '                    INE_lbl.Enabled = True
    '                    INE_txt.Enabled = True
    '                    INE_A_lbl.Enabled = True
    '                    INA_lbl.Enabled = True
    '                    INA_txt.Enabled = True
    '                    INA_A_lbl.Enabled = True
    '                    PC1EG_lbl.Enabled = True
    '                    PC1EG_txt.Enabled = True
    '                    PC1EG_KW_lbl.Enabled = True
    '                    PC1AG_lbl.Enabled = True
    '                    PC1AG_txt.Enabled = True
    '                    PC1AG_KW_lbl.Enabled = True
    '                End If
    '            End If
    '        End If
    '        If Dependents.TME = SET_TO_INVISIBLE Then
    '            TME_lbl.Visible = False
    '            TME_lbl.Enabled = False
    '            TME_txt.Visible = False
    '            TME_txt.Enabled = False
    '            TMENm_lbl.Visible = False
    '            TMENm_lbl.Enabled = False
    '        Else
    '            TME_lbl.Visible = True
    '            TME_txt.Visible = True
    '            TMENm_lbl.Visible = True
    '            If Dependents.TME = SET_TO_GREY Then
    '                TME_lbl.Enabled = False
    '                TME_txt.Enabled = False
    '                TMENm_lbl.Enabled = False
    '            Else
    '                TME_lbl.Enabled = True
    '                TME_txt.Enabled = True
    '                TMENm_lbl.Enabled = True
    '            End If
    '        End If
    '        If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            WrapAngle_lbl.Enabled = False
    '            WrapAngle_txt.Enabled = False
    '            RopeOffset_txt.BackColor = Color.LightGray
    '            RopeOffset_lbl.Enabled = False
    '            RopeOffset_txt.Enabled = False
    '            RopeOffset_txt.BackColor = Color.LightGray
    '            GrooveNumber_lbl.Enabled = False
    '            GrooveNumber_cmb.Enabled = False
    '            MachineSheaveJ_lbl.Enabled = False
    '            MachineSheaveJ_txt.Enabled = False
    '            MachineSheaveJ_txt.BackColor = Color.LightGray
    '            ForwardGearEfficiency_lbl.Enabled = False
    '            ForwardGearEfficiency_txt.Enabled = False
    '            ForwardGearEfficiency_txt.BackColor = Color.LightGray
    '            ReverseGearEfficiency_lbl.Enabled = False
    '            ReverseGearEfficiency_txt.Enabled = False
    '            ReverseGearEfficiency_txt.BackColor = Color.LightGray
    '            CarSheaveDiameter_lbl.Enabled = False
    '            CarSheaveDiameter_txt.Enabled = False
    '            CarSheaveDiameter_txt.BackColor = Color.LightGray
    '            CwtSheaveDiameter_lbl.Enabled = False
    '            CwtSheaveDiameter_txt.Enabled = False
    '            CwtSheaveDiameter_txt.BackColor = Color.LightGray
    '            len1_lbl.Enabled = False
    '            len1_txt.Enabled = False
    '            len2_lbl.Enabled = False
    '            len2_txt.Enabled = False
    '            len3_lbl.Enabled = False
    '            len3_txt.Enabled = False
    '            RopeGrade_lbl.Enabled = False
    '            RopeGrade_cmb.Enabled = False
    '        Else
    '            WrapAngleLogic()
    '            GrooveNumber_lbl.Enabled = True
    '            GrooveNumber_cmb.Enabled = True
    '            MachineSheaveJ_lbl.Enabled = True
    '            MachineSheaveJ_txt.Enabled = True
    '            ForwardGearEfficiency_lbl.Enabled = True
    '            ForwardGearEfficiency_txt.Enabled = True
    '            ReverseGearEfficiency_lbl.Enabled = True
    '            ReverseGearEfficiency_txt.Enabled = True
    '            len1_lbl.Enabled = True
    '            len1_txt.Enabled = True
    '            len2_lbl.Enabled = True
    '            len2_txt.Enabled = True
    '            len3_lbl.Enabled = True
    '            len3_txt.Enabled = True
    '            RopeGrade_lbl.Enabled = True
    '            RopeGrade_cmb.Enabled = True
    '        End If
    '        If Dependents.MachineHand = SET_TO_GREY Then
    '            MachineHand_fra.Enabled = False
    '        Else
    '            MachineHand_fra.Enabled = True
    '        End If
    '        If Dependents.FZ1 = SET_TO_INVISIBLE Then
    '            FZ1_lbl.Visible = False
    '            FZ1_lbl.Enabled = False
    '            FZ1_txt.Visible = False
    '            FZ1_txt.Enabled = False
    '            FZ1N_lbl.Visible = False
    '            FZ1N_lbl.Enabled = False
    '        Else
    '            FZ1_lbl.Visible = True
    '            FZ1_txt.Visible = True
    '            FZ1N_lbl.Visible = True
    '            If Dependents.FZ1 = SET_TO_GREY Then
    '                FZ1_lbl.Enabled = False
    '                FZ1_txt.Enabled = False
    '                FZ1N_lbl.Enabled = False
    '            Else
    '                FZ1_lbl.Enabled = True
    '                FZ1_txt.Enabled = True
    '                FZ1N_lbl.Enabled = True
    '            End If
    '        End If
    '        If Dependents.FZ2 = SET_TO_INVISIBLE Then
    '            FZ2_lbl.Visible = False
    '            FZ2_lbl.Enabled = False
    '            FZ2_txt.Visible = False
    '            FZ2_txt.Enabled = False
    '            FZ2N_lbl.Visible = False
    '            FZ2N_lbl.Enabled = False
    '        Else
    '            FZ2_lbl.Visible = True
    '            FZ2_txt.Visible = True
    '            FZ2N_lbl.Visible = True
    '            If Dependents.FZ2 = SET_TO_GREY Then
    '                FZ2_lbl.Enabled = False
    '                FZ2_txt.Enabled = False
    '                FZ2N_lbl.Enabled = False
    '            Else
    '                FZ2_lbl.Enabled = True
    '                FZ2_txt.Enabled = True
    '                FZ2N_lbl.Enabled = True
    '            End If
    '        End If
    '        If FMM200_fra.Visible Then
    '            If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '                FMM200_fra.Text = MACHINE_FMM200
    '            ElseIf ME_MRM01Car_typ.MachineModelNew = MACHINE_PMR490 Then
    '                FMM200_fra.Text = MACHINE_PMR490
    '            End If
    '            MachineHand_fra.Top = FMM200_fra.Top + FMM200_fra.Height + 3
    '        Else
    '            MachineHand_fra.Top = FMM200_fra.Top
    '        End If
    '        If Not ENG_ACCESS Then
    '            For i As Integer = 0 To Me.Controls.Count - 1
    '                Me.Controls(i).Enabled = False
    '            Next i
    '        End If

    '    End Sub
    '    Private Sub Load_ListBoxes()
    '        Dim sSQL As String = ""

    '        Try
    '            If ME_MRM01Car_typ.RopingNew <> "" Then
    '                If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '                    GrooveNumber_cmb.Items.Add("90 V-Groove")
    '                Else
    '                    sSQL = "SELECT Groove.GrooveID, Groove.Groove, Roping.Roping, ElevatorType.ElevatorType, Wrap.Wrap FROM Wrap " & "INNER JOIN (ElevatorType INNER JOIN (Roping INNER JOIN Groove ON Roping.RopingID = Groove.Roping) " & "ON ElevatorType.ElevatorTypeID = Groove.ElevatorType) ON Wrap.WrapID = Groove.Wrap;"
    '                    WorkingRecordSet = New ADODB.Recordset
    '                    WorkingRecordSet.Open(sSQL, ADOConnection)
    '                    GrooveNumber_cmb.Items.Clear()
    '                    Do While Not WorkingRecordSet.EOF
    '                        If WorkingRecordSet("ElevatorType").Value = GONumbers(CurrentGOSelection).MachineType Then
    '                            If WorkingRecordSet("Wrap").Value = Strings.Left(ME_MRM01Car_typ.Wrap, 6) Then
    '                                If WorkingRecordSet("Roping").Value = ME_MRM01Car_typ.RopingNew Then
    '                                    GrooveNumber_cmb.Items.Add(WorkingRecordSet("Groove").Value)
    '                                End If
    '                            End If
    '                        End If
    '                        WorkingRecordSet.MoveNext()
    '                    Loop
    '                    WorkingRecordSet.Close()
    '                    WorkingRecordSet = Nothing
    '                End If
    '            End If

    '            RopeGrade_cmb.Items.Clear()
    '            RopeGrade_cmb.Items.Add("Traction Steel")
    '            If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                If (TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) = 0.5 Or (TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) = 0.625 Then RopeGrade_cmb.Items.Add("EHS")
    '            Else
    '                RopeGrade_cmb.Items.Add("EHS")
    '            End If

    '            WrapAngleLogic()

    '            DriveModel_cmb.Items.Clear()
    '            Select Case GONumbers(CurrentGOSelection).MachineType
    '                Case GEARED_TYPE
    '                    For i As Integer = 1 To DriveListByCost.GetUpperBound(0)
    '                        Select Case ME_MRM01Car_typ.ControllerType
    '                            Case DRIVETYPE_BR
    '                                If Strings.Right(DriveListByCost(i).DriveSelection, 2) = "BR" Then
    '                                    DriveModel_cmb.Items.Add(DriveListByCost(i).DriveSelection)
    '                                End If
    '                            Case DRIVETYPE_PF1
    '                                If Strings.Right(DriveListByCost(i).DriveSelection, 3) = "PF1" Then
    '                                    DriveModel_cmb.Items.Add(DriveListByCost(i).DriveSelection)
    '                                End If
    '                            Case Else
    '                                DriveModel_cmb.Items.Add(DriveListByCost(i).DriveSelection)
    '                        End Select
    '                    Next i
    '                Case GEARLESS_TYPE
    '                    If ME_MRM01Car_typ.MachineModelNew = MACHINE_525LS Then
    '                        DriveModel_cmb.Items.Add("VF88PF1")
    '                    Else
    '                        Select Case ME_MRM01Car_typ.ControllerType
    '                            Case DRIVETYPE_SCRDC
    '                                DriveModel_cmb.Items.Add("DSD412-190")
    '                                DriveModel_cmb.Items.Add("DSD412-300")
    '                            Case DRIVETYPE_QUATTRO
    '                                DriveModel_cmb.Items.Add("Quattro-125")
    '                                DriveModel_cmb.Items.Add("Quattro-150")
    '                                DriveModel_cmb.Items.Add("Quattro-200")
    '                                DriveModel_cmb.Items.Add("Quattro-250")
    '                                DriveModel_cmb.Items.Add("Quattro-300")
    '                            Case DRIVETYPE_PF1
    '                                DriveModel_cmb.Items.Add("VF55PF1")
    '                                DriveModel_cmb.Items.Add("VF88PF1")
    '                                DriveModel_cmb.Items.Add("VF155PF1")
    '                                DriveModel_cmb.Items.Add("VF288PF1")
    '                            Case DRIVETYPE_BR
    '                                DriveModel_cmb.Items.Add("VF33BR")
    '                                DriveModel_cmb.Items.Add("VF44BR")
    '                                DriveModel_cmb.Items.Add("VF85BR")
    '                                DriveModel_cmb.Items.Add("VF122BR")
    '                            Case Else
    '                        End Select
    '                    End If
    '            End Select

    '            NominalMotorHP_cmb.Items.Clear()
    '            If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                NominalMotorHP_cmb.Items.Add("15")
    '                NominalMotorHP_cmb.Items.Add("20")
    '                NominalMotorHP_cmb.Items.Add("25")
    '                Select Case ME_MRM02Car_typ.HoistMotorRpm
    '                    Case "700-1000"
    '                        NominalMotorHP_cmb.Items.Add("35")
    '                        NominalMotorHP_cmb.Items.Add("50")
    '                    Case "1001-1300"
    '                        NominalMotorHP_cmb.Items.Add("30")
    '                        NominalMotorHP_cmb.Items.Add("35")
    '                        NominalMotorHP_cmb.Items.Add("50")
    '                        If ME_MRM02Car_typ.Mounting = "Foot-Mounted" Then
    '                            NominalMotorHP_cmb.Items.Add("60")
    '                            NominalMotorHP_cmb.Items.Add("75")
    '                        End If
    '                    Case "1600-1900"
    '                        NominalMotorHP_cmb.Items.Add("35")
    '                        NominalMotorHP_cmb.Items.Add("40")
    '                        NominalMotorHP_cmb.Items.Add("50")
    '                End Select
    '            End If

    '            RequiredKVA_cmb.Items.Clear()
    '            Select Case ME_COM01Car_typ.PowerSupply
    '                Case 208, 240
    '                    RequiredKVA_cmb.Items.Add("19.5")
    '                    RequiredKVA_cmb.Items.Add("26")
    '                    RequiredKVA_cmb.Items.Add("32")
    '                    RequiredKVA_cmb.Items.Add("40")
    '                    RequiredKVA_cmb.Items.Add("50")
    '                    RequiredKVA_cmb.Items.Add("60")
    '                    RequiredKVA_cmb.Items.Add("100")
    '                    RequiredKVA_cmb.Items.Add("180")
    '                Case 416
    '                    RequiredKVA_cmb.Items.Add("100")
    '                    RequiredKVA_cmb.Items.Add("180")
    '                Case 440
    '                    RequiredKVA_cmb.Items.Add("60")
    '                Case 460, 480
    '                    RequiredKVA_cmb.Items.Add("0")
    '                Case 575, 600
    '                    RequiredKVA_cmb.Items.Add("19.5")
    '                    RequiredKVA_cmb.Items.Add("26")
    '                    RequiredKVA_cmb.Items.Add("32")
    '                    RequiredKVA_cmb.Items.Add("40")
    '                    RequiredKVA_cmb.Items.Add("60")
    '                    RequiredKVA_cmb.Items.Add("100")
    '                    RequiredKVA_cmb.Items.Add("180")
    '                Case Else
    '                    RequiredKVA_cmb.Items.Add("19.5")
    '                    RequiredKVA_cmb.Items.Add("26")
    '                    RequiredKVA_cmb.Items.Add("32")
    '                    RequiredKVA_cmb.Items.Add("40")
    '                    RequiredKVA_cmb.Items.Add("50")
    '                    RequiredKVA_cmb.Items.Add("60")
    '                    RequiredKVA_cmb.Items.Add("100")
    '                    RequiredKVA_cmb.Items.Add("180")
    '            End Select

    '            BlockingBeamSize_cmb.Items.Clear()
    '            BlockingBeamSize_cmb.Items.Add("W6X25")
    '            BlockingBeamSize_cmb.Items.Add("W8X28")

    '            VariableMagneticDiscBrake_cmb.Clear()
    '            VariableMagneticDiscBrake_cmb.AddItem("2X500LE1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X650LE1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X760LE1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X900LE1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X1000LE1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X500GT1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X650GT1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X760GT1.75")
    '            VariableMagneticDiscBrake_cmb.AddItem("2X900GT1.75")

    '            HoistMotorType_cmb.Clear()
    '            If ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '                HoistMotorType_cmb.AddItem("FMM200-6C588")
    '                HoistMotorType_cmb.AddItem("FMM200-6C396")
    '                HoistMotorType_cmb.AddItem("FMM200-6C378")
    '                HoistMotorType_cmb.AddItem("FMM200-6C342")
    '                HoistMotorType_cmb.AddItem("FMM200-6C306")
    '                HoistMotorType_cmb.AddItem("FMM200-6C252")
    '                HoistMotorType_cmb.AddItem("FMM200-6D468")
    '                HoistMotorType_cmb.AddItem("FMM200-6D342")
    '                HoistMotorType_cmb.AddItem("FMM200-6D324")
    '                HoistMotorType_cmb.AddItem("FMM200-6D288")
    '                HoistMotorType_cmb.AddItem("FMM200-6D252")
    '                HoistMotorType_cmb.AddItem("FMM200-6D216")
    '                HoistMotorType_cmb.AddItem("FMM200-6E432")
    '                HoistMotorType_cmb.AddItem("FMM200-6E288")
    '                HoistMotorType_cmb.AddItem("FMM200-6E252")
    '                HoistMotorType_cmb.AddItem("FMM200-6E234")
    '                HoistMotorType_cmb.AddItem("FMM200-6E180")
    '            ElseIf ME_MRM01Car_typ.MachineModelNew = MACHINE_PMR490 Then
    '                HoistMotorType_cmb.AddItem("PMR490-24B228")
    '                HoistMotorType_cmb.AddItem("PMR490-24B240")
    '                HoistMotorType_cmb.AddItem("PMR490-24B252")
    '                HoistMotorType_cmb.AddItem("PMR490-24B276")
    '                HoistMotorType_cmb.AddItem("PMR490-24B288")
    '                HoistMotorType_cmb.AddItem("PMR490-24B300")
    '                HoistMotorType_cmb.AddItem("PMR490-24B312")
    '                HoistMotorType_cmb.AddItem("PMR490-24B324")
    '                HoistMotorType_cmb.AddItem("PMR490-24B336")
    '                HoistMotorType_cmb.AddItem("PMR490-24B348")
    '                HoistMotorType_cmb.AddItem("PMR490-24B360")
    '                HoistMotorType_cmb.AddItem("PMR490-24B408")
    '                HoistMotorType_cmb.AddItem("PMR490-24B432")
    '                HoistMotorType_cmb.AddItem("PMR490-24B456")
    '                HoistMotorType_cmb.AddItem("PMR490-24B480")
    '                HoistMotorType_cmb.AddItem("PMR490-24B504")
    '                HoistMotorType_cmb.AddItem("PMR490-24B540")
    '                HoistMotorType_cmb.AddItem("PMR490-24B576")
    '                HoistMotorType_cmb.AddItem("PMR490-24B612")
    '                HoistMotorType_cmb.AddItem("PMR490-24B648")
    '                HoistMotorType_cmb.AddItem("PMR490-24B684")
    '                HoistMotorType_cmb.AddItem("PMR490-24B720")
    '                HoistMotorType_cmb.AddItem("PMR490-24B756")
    '                HoistMotorType_cmb.AddItem("PMR490-24B792")
    '            End If

    '        Catch
    '            MessageBox.Show(Conversion.ErrorToString(), "Load_ListBoxes (Torque Overrides)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End Try

    '    End Sub
    '    Private Sub SortByTabOrder()
    '        Dim lControl As Control
    '        Dim k, L As Integer

    '        On Error GoTo err_SortByTabOrder

    '        ReDim oControls(0)
    '        L = -1
    '        For i As Integer = 0 To Me.Controls.Count - 1
    '            k = -1
    '            k = Me.Controls(i).TabIndex
    '            If k > -1 Then
    '                L += 1
    '                ReDim Preserve oControls(L)
    '                oControls(L) = Me.Controls(i)
    '            End If
    '        Next i
    '        For i As Integer = 0 To L - 1
    '            For j As Integer = i + 1 To L
    '                If oControls(i).TabIndex > oControls(j).TabIndex Then
    '                    lControl = oControls(i)
    '                    oControls(i) = oControls(j)
    '                    oControls(j) = lControl
    '                End If
    '            Next j
    '        Next i

    '        Exit Sub

    'err_SortByTabOrder:
    '        If Information.Err().Number = 438 Then
    '            Resume Next
    '        End If
    '        MessageBox.Show(Conversion.ErrorToString(), "SortByTabOrder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    End Sub
    '    Private Sub MN_TRQ02_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    '    End Sub
    '    Private Sub HoistMotorCurrent_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles HoistMotorCurrent_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub HoistMotorCurrent_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles HoistMotorCurrent_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, HoistMotorCurrent_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If Math.Round(MN_TRQ01_typ.HoistMotorCurrent, 1) <> Math.Round(Conversion.Val(HoistMotorCurrent_txt.Text), 1) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub STMQty_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles STMQty_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub STMQty_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles STMQty_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, STMQty_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.STMQty <> Conversion.Val(STMQty_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub BlockingBeamLength_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles BlockingBeamLength_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub BlockingBeamLength_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BlockingBeamLength_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, BlockingBeamLength_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.BlockingBeamLength <> Conversion.Val(BlockingBeamLength_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub BlockingBeamLengthCar_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles BlockingBeamLengthCar_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub BlockingBeamLengthCar_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BlockingBeamLengthCar_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, BlockingBeamLengthCar_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.BlockingBeamLengthCar <> Conversion.Val(BlockingBeamLengthCar_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub BlockingBeamLengthCwt_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles BlockingBeamLengthCwt_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub BlockingBeamLengthCwt_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BlockingBeamLengthCwt_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, BlockingBeamLengthCwt_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.BlockingBeamLengthCwt <> Conversion.Val(BlockingBeamLengthCwt_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub BlockingBeamSize_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BlockingBeamSize_cmb.SelectedIndexChanged

    '        If BlockingBeamSize_cmb.Text <> MN_TRQ01_typ.BlockingBeamSize Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '        End If

    '    End Sub
    '    Private Sub BlockingBeamSize_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BlockingBeamSize_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If BlockingBeamSize_cmb.Text <> MN_TRQ01_typ.BlockingBeamSize Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '        End If

    '    End Sub
    '    Private Sub STMLength_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles STMLength_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub STMLength_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles STMLength_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, STMLength_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.STMLength <> Conversion.Val(STMLength_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub PME_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PME_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub PME_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PME_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, PME_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.PME <> Conversion.Val(PME_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub INE_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles INE_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub INE_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles INE_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, INE_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.INE <> Conversion.Val(INE_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub INA_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles INA_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub INA_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles INA_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, INA_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.INA <> Conversion.Val(INA_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub PC1EG_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PC1EG_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub PC1EG_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PC1EG_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, PC1EG_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.PC1EG <> Conversion.Val(PC1EG_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub PC1AG_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PC1AG_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub PC1AG_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PC1AG_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, PC1AG_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.PC1AG <> Conversion.Val(PC1AG_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub TME_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TME_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub TME_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TME_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, TME_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.TME <> Conversion.Val(TME_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariableMagneticDiscBrake_cmb.Enter
    '        SelectInputArea(VariableMagneticDiscBrake_cmb, 0, Strings.Len(VariableMagneticDiscBrake_cmb.Text))
    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles VariableMagneticDiscBrake_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode, e.KeyCode = Keys.F1)
    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles VariableMagneticDiscBrake_cmb.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariableMagneticDiscBrake_cmb.Leave

    '        If VariableMagneticDiscBrake_cmb.Text.Trim().Length > 0 Then
    '            If Conversion.Val(VariableMagneticDiscBrake_cmb.Text) <> Conversion.Val(MN_TRQ01_typ.VariableMagneticDiscBrake) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariableMagneticDiscBrake_cmb.SelectedIndexChanged
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub VariableMagneticDiscBrake_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariableMagneticDiscBrake_cmb.TextChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub HoistMotorType_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles HoistMotorType_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode, e.KeyCode = Keys.F1)
    '    End Sub
    '    Private Sub HoistMotorType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoistMotorType_cmb.SelectedIndexChanged

    '        If HoistMotorType_cmb.Text.Trim().Length > 0 Then
    '            If MN_TRQ01_typ.HoistMotorType <> HoistMotorType_cmb.Text.Trim Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub HoistMotorType_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HoistMotorType_cmb.TextChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub UN_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UN_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub UN_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UN_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, UN_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.UN <> Conversion.Val(UN_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub FZ1_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FZ1_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub FZ1_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FZ1_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, FZ1_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.FZ1 <> Conversion.Val(FZ1_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub FZ2_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FZ2_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(e.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            e.Handled = True
    '        End If
    '        e.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub FZ2_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FZ2_txt.Leave

    '        If ValidateTextBoxInput_Text(Me, FZ2_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '            If MN_TRQ01_typ.FZ2 <> Conversion.Val(FZ2_txt.Text) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            End If
    '        End If

    '    End Sub
    '    Private Sub InitMachineHand_spr()
    '        Dim jIndex As Integer = 0

    '        MachineHand_spr.ActiveSheet.ColumnCount = MN_TRQ01_typ.MachineHand.GetUpperBound(0)
    '        For jIndex = 1 To MN_TRQ01_typ.MachineHand.GetUpperBound(0)
    '            MachineHand_spr.ActiveSheet.ColumnHeader.Columns(jIndex - 1).Label = "Car " & MN_TRQ01_typ.MachineHand(jIndex).CarUnit
    '        Next jIndex

    '    End Sub
    '    Private Sub MachineHand_spr_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles MachineHand_spr.Change
    '        If MachineHand_spr.ActiveSheet.Cells(0, e.Column).Text <> MN_TRQ01_typ.MachineHand(e.Column).MachineHand Then
    '            MDIChildDirty = True
    '        End If
    '    End Sub
End Class