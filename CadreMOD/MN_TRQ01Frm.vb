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
Partial Friend Class MN_TRQ01_frm
    Inherits System.Windows.Forms.Form
    Private Sub MN_TRQ01_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        'If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
        '    UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
        'End If
        'If FormLoadWasProcessed Then
        '    FormLoadWasProcessed = False
        'Else
        '    PrepareThisForm()
        'End If

    End Sub

    Private bCriteriaRange As Boolean
    Private cRopeCompensation As Collection
    Private cCarTopSheave As Collection
    Private cCwtTopSheave As Collection

    Private Sub PrepareThisForm()

        'GeneralData_fra.Left = 0
        'SystemData_fra.Left = 0
        'Frame7.Left = GeneralData_fra.Width + 2
        'Only2To1Roping_fra.Left = GeneralData_fra.Width + 2
        'ElectricalData_fra.Left = GeneralData_fra.Width + 2
        'LobbyVision_fra.Left = ElectricalData_fra.Left
        'Frame2.Left = Only2To1Roping_fra.Left + Only2To1Roping_fra.Width + 2
        'Compensation_fra.Left = Only2To1Roping_fra.Left + Only2To1Roping_fra.Width + 2
        'TopOfCarDevices_fra.Left = Compensation_fra.Left
        'RopeGripper_fra.Left = Compensation_fra.Left
        'Governor_fra.Left = Compensation_fra.Left
        'SetPosition_obj.SetFormSizePos(Me)
        'SetFormCaption(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX)
        'bSkipFields2Type = True
        'bSkipWrapWarning = True
        'bJobNumber = True
        'If ADOConnection.ConnectionString = "" Then
        '    InitializeADODC()
        'End If
        'SortByTabOrder()
        'MN_TRQ01_typ.MotorRPM = Convert.ToInt16(Conversion.Val(ExtractMotorRPM(ME_MRM02Car_typ.HoistMotorRpm, False)))
        'Dependents.Set_MaxNumberRopes()
        'Dependents.Set_MachineSheaveDiameterCollection()
        'Load_ListBoxes()
        'Type2Fields()
        'Set_Fields_Grey()
        'bSkipFields2Type = False
        'bSkipWrapWarning = False
        'bJobNumber = False

    End Sub
    Private isInitializingComponent As Boolean
    Private Sub CompensationQty_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationQty_cmb.TextChanged

        'If isInitializingComponent Then
        '    Exit Sub
        'End If
        'If Conversion.Val(CompensationQty_cmb.Text) <> ME_PIT01Car_typ.CableChainQty Then
        '    If ConfirmAmendment(CompensationQty_cmb, CompensationQty_lbl, CStr(ME_PIT01Car_typ.CableChainQty)) Then
        '        StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
        '        MDIChildDirty = True
        '        MN_TRQ01_typ.bDirty = True
        '        Fields2Type()
        '        Dependents.MOD_Parent()
        '        Load_ListBoxes()
        '        Type2Fields()
        '        Set_Fields_Grey()
        '        Main_MDI_frm.ProcessChildMessage()
        '    Else
        '        CompensationQty_cmb.Text = CStr(ME_PIT01Car_typ.CableChainQty)
        '    End If
        'End If

    End Sub
    'Private Sub CompensationQty_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationQty_cmb.SelectedIndexChanged

    '    If Conversion.Val(CompensationQty_cmb.Text) <> ME_PIT01Car_typ.CableChainQty Then
    '        If ConfirmAmendment(CompensationQty_cmb, CompensationQty_lbl, CStr(ME_PIT01Car_typ.CableChainQty)) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            CompensationQty_cmb.Text = CStr(ME_PIT01Car_typ.CableChainQty)
    '        End If
    '    End If

    'End Sub
    'Private Sub CompensationQty_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CompensationQty_cmb.KeyDown
    '    WhichKeyPressed(eventArgs.KeyCode)
    'End Sub
    'Private Sub CompensationSize_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationSize_cmb.TextChanged

    '    If isInitializingComponent Then
    '        Exit Sub
    '    End If
    '    If CompensationSize_cmb.Text <> ME_PIT01Car_typ.CableChainSize Then
    '        If ConfirmAmendment(CompensationSize_cmb, CompensationSize_lbl, ME_PIT01Car_typ.CableChainSize) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeCableChainSize = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeCableChainSize = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            If String.IsNullOrEmpty(ME_PIT01Car_typ.CableChainSize) Then
    '                CompensationSize_cmb.SelectedIndex = -1
    '            Else
    '                CompensationSize_cmb.Text = ME_PIT01Car_typ.CableChainSize
    '            End If
    '        End If
    '    End If

    'End Sub
    'Private Sub CompensationSize_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationSize_cmb.SelectedIndexChanged

    '    If CompensationSize_cmb.Text <> ME_PIT01Car_typ.CableChainSize Then
    '        If ConfirmAmendment(CompensationSize_cmb, CompensationSize_lbl, ME_PIT01Car_typ.CableChainSize) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeCableChainSize = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeCableChainSize = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            If String.IsNullOrEmpty(ME_PIT01Car_typ.CableChainSize) Then
    '                CompensationSize_cmb.SelectedIndex = -1
    '            Else
    '                CompensationSize_cmb.Text = ME_PIT01Car_typ.CableChainSize
    '            End If
    '        End If
    '    End If

    'End Sub
    'Private Sub CompensationSize_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CompensationSize_cmb.KeyDown
    '    WhichKeyPressed(eventArgs.KeyCode)
    'End Sub
    'Private Sub CompensationType_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationType_cmb.TextChanged

    '    If isInitializingComponent Then
    '        Exit Sub
    '    End If
    '    If ME_PIT01Car_typ.CompensationType <> CompensationType_cmb.Text Then
    '        If ConfirmAmendment(CompensationType_cmb, CompensationType_lbl, ME_PIT01Car_typ.CompensationType) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeCompensationType = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeCompensationType = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            CompensationType_cmb.Text = ME_PIT01Car_typ.CompensationType
    '        End If
    '    End If

    'End Sub
    'Private Sub CompensationType_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompensationType_cmb.SelectedIndexChanged

    '    If ME_PIT01Car_typ.CompensationType <> CompensationType_cmb.Text Then
    '        If ConfirmAmendment(CompensationType_cmb, CompensationType_lbl, ME_PIT01Car_typ.CompensationType) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_PIT01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeCompensationType = True
    '            Dependents.MOD_Parent()
    '            Dependents.StatusChangeCompensationType = False
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            If String.IsNullOrEmpty(ME_PIT01Car_typ.CompensationType) Then
    '                CompensationType_cmb.SelectedIndex = -1
    '            Else
    '                CompensationType_cmb.Text = ME_PIT01Car_typ.CompensationType
    '            End If
    '        End If
    '    End If

    'End Sub
    'Private Sub CompensationType_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CompensationType_cmb.KeyDown
    '    WhichKeyPressed(eventArgs.KeyCode)
    'End Sub
    'Private Sub CompSheaveDiameter_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CompSheaveDiameter_txt.Leave

    '    If ValidateTextBoxInput_Text(Me, CompSheaveDiameter_txt, ENTRY_NOT_AN_INTEGER, True) = ENTRY_VALID Then
    '        If ME_PIT01Car_typ.SheaveDiameter <> CompSheaveDiameter_txt.Text Then
    '            If Not ConfirmAmendment(CompSheaveDiameter_txt, CompSheaveDiameter_lbl, ME_PIT01Car_typ.SheaveDiameter, True) Then
    '                CompSheaveDiameter_txt.Text = ME_PIT01Car_typ.SheaveDiameter
    '                Exit Sub
    '            End If
    '            MN_TRQ01_typ.bDirty = True
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If
    '    End If

    'End Sub
    'Private Sub HoistwaySheave_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles HoistwaySheave_cmb.Leave
    '    Dim bCriteria As Boolean

    '    If HoistwaySheave_cmb.Text = "None" Then
    '        bCriteria = Conversion.Val(ME_HstWay02Car_typ.HoistwaySheaveDia) <> 0
    '    Else
    '        bCriteria = HoistwaySheave_cmb.Text <> ME_HstWay02Car_typ.HoistwaySheaveDia
    '    End If
    '    If bCriteria Then
    '        If ConfirmAmendment(HoistwaySheave_cmb, HoistwaySheave_lbl, ME_HstWay02Car_typ.HoistwaySheaveDia) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_HSTW02_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            If Conversion.Val(ME_HstWay02Car_typ.HoistwaySheaveDia) = 0 Then
    '                AssignListIndex(HoistwaySheave_cmb, "None")
    '            Else
    '                If FindString(HoistwaySheave_cmb, ME_HstWay02Car_typ.HoistwaySheaveDia) = -1 Then
    '                    HoistwaySheave_cmb.Text = IIf(Conversion.Val(ME_HstWay02Car_typ.HoistwaySheaveDia) = 0, "None", ME_HstWay02Car_typ.HoistwaySheaveDia)
    '                Else
    '                    AssignListIndex(HoistwaySheave_cmb, ME_HstWay02Car_typ.HoistwaySheaveDia)
    '                End If
    '            End If
    '        End If
    '    End If
    '    SetColor_HoistwaySheave_cmb()

    'End Sub
    'Private Sub DriveType_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles DriveType_cmb.SelectedIndexChanged

    '    If DriveType_cmb.Text <> ME_MRM01Car_typ.ControllerType Then
    '        If ConfirmAmendment(DriveType_cmb, DriveType_lbl, ME_MRM01Car_typ.ControllerType) Then
    '            StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '            MDIChildDirty = True
    '            MN_TRQ01_typ.bDirty = True
    '            Fields2Type()
    '            Dependents.StatusChangeDriveType = True
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Dependents.StatusChangeDriveType = False
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        Else
    '            DriveType_cmb.Text = ME_MRM01Car_typ.ControllerType
    '        End If
    '    End If

    'End Sub
    'Private Sub MN_TRQ01_frm_Paint(ByVal eventSender As Object, ByVal eventArgs As PaintEventArgs) Handles MyBase.Paint

    '    On Error Resume Next

    '    If CounterCritical > 0 Or CounterWarning > 0 Then
    '        ShowTypeOfDisplay = RUN_DISPLAY
    '        Warn_msg_frm.ShowDialog()
    '        CounterCritical = 0
    '        CounterWarning = 0
    '    End If
    '    RopeGripper_fra.Left = TopOfCarDevices_fra.Left
    '    Governor_fra.Left = TopOfCarDevices_fra.Left

    'End Sub
    '    Private Sub NamePlateArmatureFullLoadCurrent_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NamePlateArmatureFullLoadCurrent_txt.Enter
    '        SelectInputArea(NamePlateArmatureFullLoadCurrent_txt, 0, Strings.Len(NamePlateArmatureFullLoadCurrent_txt.Text))
    '    End Sub
    '    Private Sub NamePlateArmatureFullLoadCurrent_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NamePlateArmatureFullLoadCurrent_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub NamePlateArmatureFullLoadCurrent_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles NamePlateArmatureFullLoadCurrent_txt.Leave

    '        If Math.Round(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent, 2) <> Math.Round(Conversion.Val(NamePlateArmatureFullLoadCurrent_txt.Text), 2) Then
    '            If ConfirmAmendment(NamePlateArmatureFullLoadCurrent_txt, NamePlateArmatureFullLoadCurrent_lbl, CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent = CSng(NamePlateArmatureFullLoadCurrent_txt.Text)
    '                bMotorDependentChange = True
    '                Dependents.MOD_Parent()
    '                bMotorDependentChange = False
    '            Else
    '                NamePlateArmatureFullLoadCurrent_txt.Text = CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent)
    '            End If
    '        End If
    '        NamePlateArmatureFullLoadCurrent_txt.BackColor = IIf(Conversion.Val(NamePlateArmatureFullLoadCurrent_txt.Text) = 0 And GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE, Color.Yellow, Color.White)

    '    End Sub
    '    Private Sub Ifan_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ifan_txt.Enter
    '        SelectInputArea(Ifan_txt, 0, Strings.Len(Ifan_txt.Text))
    '    End Sub
    '    Private Sub Ifan_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Ifan_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub Ifan_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Ifan_txt.Leave

    '        If ME_MRM01Car_typ.IFan <> Ifan_txt.Text Then
    '            If ConfirmAmendment(Ifan_txt, Ifan_lbl, CStr(ME_MRM01Car_typ.IFan)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                ME_MRM01Car_typ.IFan = Ifan_txt.Text
    '            Else
    '                Ifan_txt.Text = ME_MRM01Car_typ.IFan
    '            End If
    '        End If
    '        Ifan_txt.BackColor = Color.White

    '    End Sub
    '    Private Sub Iff_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Iff_txt.Enter
    '        SelectInputArea(Iff_txt, 0, Strings.Len(Iff_txt.Text))
    '    End Sub
    '    Private Sub Iff_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Iff_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub Iff_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Iff_txt.Leave
    '        Dim LimitationIFF As Integer = 40

    '        If ValidateTextBoxInput_Text(Me, Iff_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(1), CStr(LimitationIFF)) = ENTRY_VALID Then
    '            If Math.Round(Conversion.Val(ME_MRM01Car_typ.IFF), 2) <> Math.Round(Conversion.Val(Iff_txt.Text), 2) Then
    '                If ConfirmAmendment(Iff_txt, Iff_lbl, CStr(ME_MRM01Car_typ.IFF)) Then
    '                    StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                    MDIChildDirty = True
    '                    ME_MRM01Car_typ.IFF = Iff_txt.Text
    '                Else
    '                    Iff_txt.Text = ME_MRM01Car_typ.IFF
    '                End If
    '            End If
    '            Iff_txt.BackColor = IIf(Conversion.Val(Iff_txt.Text) = 0 And GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE, Color.Yellow, Color.White)
    '        End If

    '    End Sub
    '    Private Sub MachineSheaveDia_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles MachineSheaveDia_cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub MachineSheaveDia_cmb_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles MachineSheaveDia_cmb.KeyUp
    '        If Strings.Len(MachineSheaveDia_cmb.Text) > 5 Then
    '            MachineSheaveDia_cmb.Text = Strings.Left(MachineSheaveDia_cmb.Text, 5)
    '        End If
    '    End Sub
    '    Private Sub MachineSheaveDia_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MachineSheaveDia_cmb.Leave

    '        If MachineSheaveDia_cmb.Text <> ME_MRM01Car_typ.MachineSheaveDia Then
    '            If ConfirmAmendment(MachineSheaveDia_cmb, MachineSheaveDia_lbl, ME_MRM01Car_typ.MachineSheaveDia) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                MachineSheaveDia_cmb.Text = ME_MRM01Car_typ.MachineSheaveDia
    '            End If
    '            SetColor_MachineSheaveDia_cmb()
    '        End If

    '    End Sub
    '    Private Sub MainTravelingCable_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MainTravelingCable_cmb.SelectedIndexChanged

    '        If MainTravelingCable_cmb.Text <> MN_TRQ01_typ.MainTravelingCable Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub BrakeType_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BrakeType_cmb.SelectedIndexChanged

    '        If BrakeType_cmb.Text <> ME_MRM01Car_typ.BrakeType Then
    '            If ConfirmAmendment(BrakeType_cmb, BrakeType_lbl, ME_MRM01Car_typ.BrakeType) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                BrakeType_cmb.Text = ME_MRM01Car_typ.BrakeType
    '            End If
    '        End If
    '        If ME_MRM01Car_typ.BrakeType <> "" Then
    '            If ME_MRM01Car_typ.MachineModel = "38" Then
    '                If ME_MRM01Car_typ.BrakeType = "Disk" Then
    '                    Dependents.ParentFlag = True
    '                    MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "No Brake Solution. Replace with a new Machine.", MsgBoxStyle.Critical)
    '                    Dependents.ParentFlag = False
    '                    AssignListIndex(BrakeType_cmb, "Drum")
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub BuildingVoltage_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles BuildingVoltage_cmb.SelectedIndexChanged

    '        If (BuildingVoltage_cmb.Text) <> ME_COM01Car_typ.PowerSupply Then
    '            If ConfirmAmendment(BuildingVoltage_cmb, BuildingVoltage_lbl, CStr(ME_COM01Car_typ.PowerSupply)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                BuildingVoltage_cmb.Text = CStr(ME_COM01Car_typ.PowerSupply)
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Capacity_cmb_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Capacity_cmb.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_POSITIVE_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub Capacity_cmb_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles Capacity_cmb.KeyUp
    '        If Strings.Len(Capacity_cmb.Text) > 5 Then
    '            Capacity_cmb.Text = Strings.Left(Capacity_cmb.Text, 5)
    '        End If
    '        SetColor_Capacity_cmb()
    '    End Sub
    '    Private Sub Capacity_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Capacity_cmb.Leave

    '        If ValidateTextBoxInput_Text(Me, Capacity_cmb, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(1), CStr(32000)) <> ENTRY_VALID Then
    '            Capacity_cmb.Text = CStr(ME_COM01Car_typ.Capacity)
    '        ElseIf Conversion.Val(Capacity_cmb.Text) <> ME_COM01Car_typ.Capacity Then
    '            If ConfirmAmendment(Capacity_cmb, Capacity_lbl, CStr(ME_COM01Car_typ.Capacity)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.StatusChangeCapacityTRQ01 = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeCapacityTRQ01 = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                Capacity_cmb.Text = CStr(ME_COM01Car_typ.Capacity)
    '            End If
    '        End If
    '        SetColor_Capacity_cmb()

    '    End Sub
    '    Private Sub HoistwaySheave_cmb_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles HoistwaySheave_cmb.KeyUp
    '        SetColor_HoistwaySheave_cmb()
    '    End Sub
    '    Private Sub MN_TRQ01_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
    '        FormLoadWasProcessed = True
    '        PrepareThisForm()
    '    End Sub
    '    Private Sub MN_TRQ01_frm_Resize(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Resize

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If Not CBool(SetPosition_obj.SettingFormSize) And Me.WindowState <> FormWindowState.Minimized Then
    '            SetPosition_obj.AlignFrames(Me)
    '        End If

    '    End Sub
    '    Private Sub MachineRoomLocation_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MachineRoomLocation_cmb.SelectedIndexChanged

    '        If MachineRoomLocation_cmb.Text <> ME_MRM01Car_typ.MachineLocation Then
    '            If ConfirmAmendment(MachineRoomLocation_cmb, MachineRoomLocation_lbl, ME_MRM01Car_typ.MachineLocation) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeMachineLocation = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeMachineLocation = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                MachineRoomLocation_cmb.Text = ME_MRM01Car_typ.MachineLocation
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MachineTypeNew_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MachineTypeNew_cmb.SelectedIndexChanged

    '        If MachineTypeNew_cmb.Text <> ME_MRM01Car_typ.MachineModelNew Then
    '            If ConfirmAmendment(MachineTypeNew_cmb, MachineTypeNew_lbl, ME_MRM01Car_typ.MachineModelNew) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bLocalChange = 2
    '                bElectricalData = True
    '                Dependents.StatusChangeMachineModel = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeMachineModel = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                bLocalChange = 0
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                MachineTypeNew_cmb.Text = ME_MRM01Car_typ.MachineModel
    '            End If
    '        End If

    '    End Sub
    '    Private Sub ManufacturerNew_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ManufacturerNew_cmb.SelectedIndexChanged

    '        If ManufacturerNew_cmb.Text <> ME_MRM01Car_typ.MachineVendorNew Then
    '            If ConfirmAmendment(ManufacturerNew_cmb, ManufacturerNew_lbl, ME_MRM01Car_typ.MachineVendorNew) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                ME_MRM01Car_typ.MachineModelNew = ""
    '                bLocalChange = 1
    '                bElectricalData = True
    '                Dependents.StatusChangeManufactureNew = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeManufactureNew = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                bLocalChange = 0
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                ManufacturerNew_cmb.Text = ME_MRM01Car_typ.MachineVendor
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MotorRPM_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MotorRPM_cmb.TextChanged
    '        Dim sMsg As String = ""
    '        Dim bCriteria As Boolean

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If MotorRPM_cmb.Text <> MN_TRQ01_typ.NomimalMotorRpm Then
    '            If FindString(MotorRPM_cmb, ME_MRM02Car_typ.HoistMotorRpm) = -1 Then
    '                sMsg = "You are about to change " & MotorRPM_lbl.Text & " from " & ME_MRM02Car_typ.HoistMotorRpm & " to " & MotorRPM_cmb.Text & "." & Strings.Chr(13).ToString() & Strings.Chr(10).ToString()
    '                sMsg = sMsg & "It will change " & MotorRPM_lbl.Text & " on Estimating Screen to " & MotorRPM_cmb.Text & ". It will also reset all Torque Override values to default."
    '                MessageBox.Show(sMsg, "Nominal Motor RPM", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                bCriteria = True
    '            ElseIf ConfirmAmendment(MotorRPM_cmb, MotorRPM_lbl, ME_MRM02Car_typ.HoistMotorRpm) Then
    '                bCriteria = True
    '            End If
    '            If bCriteria Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM02_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeMachineToReplaceNew = (ME_MRM01Car_typ.Machine = "Replace" Or ME_MRM01Car_typ.Machine = "New")
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeMachineToReplaceNew = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                MotorRPM_cmb.Text = ME_MRM02Car_typ.HoistMotorRpm
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MotorRPM_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MotorRPM_cmb.SelectedIndexChanged
    '        Dim sMsg As String = ""
    '        Dim bCriteria As Boolean

    '        If MotorRPM_cmb.Text <> MN_TRQ01_typ.NomimalMotorRpm Then
    '            If FindString(MotorRPM_cmb, ME_MRM02Car_typ.HoistMotorRpm) = -1 Then
    '                If bLocalChange = 0 Then
    '                    sMsg = "You are about to change " & MotorRPM_lbl.Text & " from " & ME_MRM02Car_typ.HoistMotorRpm & " to " & MotorRPM_cmb.Text & "." & Strings.Chr(13).ToString() & Strings.Chr(10).ToString()
    '                    sMsg = sMsg & "It will change " & MotorRPM_lbl.Text & " on Estimating Screen to " & MotorRPM_cmb.Text & ". It will also reset all Torque Override values to default."
    '                    MessageBox.Show(sMsg, "Nominal Motor RPM", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    bCriteria = True
    '                End If
    '            ElseIf ConfirmAmendment(MotorRPM_cmb, MotorRPM_lbl, ME_MRM02Car_typ.HoistMotorRpm) Then
    '                bCriteria = True
    '            End If
    '            If bCriteria Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM02_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeMachineToReplaceNew = (ME_MRM01Car_typ.Machine = "Replace" Or ME_MRM01Car_typ.Machine = "New")
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeMachineToReplaceNew = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                MotorRPM_cmb.Text = ME_MRM02Car_typ.HoistMotorRpm
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MotorRPM_cmb_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles MotorRPM_cmb.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_POSITIVE_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub MotorRPM_cmb_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles MotorRPM_cmb.KeyUp

    '        If MotorRPM_cmb.Text = "" Then
    '            MotorRPM_cmb.BackColor = Color.Yellow
    '        Else
    '            MotorRPM_cmb.BackColor = IIf(FindString(MotorRPM_cmb, MotorRPM_cmb.Text) = -1, Color.Red, Color.White)
    '        End If

    '    End Sub
    '    Private Sub NumberOfRopes_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles NumberOfRopes_cmb.Leave

    '        If Conversion.Val(NumberOfRopes_cmb.Text) <> ME_MRM01Car_typ.HoistCableQty Then
    '            If ConfirmAmendment(NumberOfRopes_cmb, NumberOfRopes_lbl, CStr(ME_MRM01Car_typ.HoistCableQty)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.bIdealCompWeightFlag = True
    '                Dependents.MOD_Parent()
    '                Dependents.bIdealCompWeightFlag = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                If FindString(NumberOfRopes_cmb, CStr(ME_MRM01Car_typ.HoistCableQty)) = -1 Then
    '                    NumberOfRopes_cmb.Text = CStr(ME_MRM01Car_typ.HoistCableQty)
    '                    NumberOfRopes_cmb.BackColor = Color.Red
    '                Else
    '                    AssignListIndex(NumberOfRopes_cmb, CStr(ME_MRM01Car_typ.HoistCableQty))
    '                    NumberOfRopes_cmb.BackColor = Color.White
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Performance_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Performance_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If Performance_cmb.Text <> ME_COM01Car_typ.Performance Then
    '            If ConfirmAmendment(Performance_cmb, Performance_lbl, ME_COM01Car_typ.Performance) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                Performance_cmb.Text = ME_COM01Car_typ.Performance
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Performance_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Performance_cmb.SelectedIndexChanged

    '        If Performance_cmb.Text <> ME_COM01Car_typ.Performance Then
    '            If ConfirmAmendment(Performance_cmb, Performance_lbl, ME_COM01Car_typ.Performance) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                Performance_cmb.Text = ME_COM01Car_typ.Performance
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Qty1_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Qty1_cmb.SelectedIndexChanged

    '        If Qty1_cmb.Text <> MN_TRQ01_typ.MainTravelingCableQty Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub Speed_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Speed_cmb.Leave

    '        If Conversion.Val(Speed_cmb.Text) <> ME_COM01Car_typ.Speed Then
    '            If Conversion.Val(Speed_cmb.Text) = 0 Then Exit Sub
    '            If ConfirmAmendment(Speed_cmb, Speed_lbl, CStr(ME_COM01Car_typ.Speed)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                If FindString(Speed_cmb, CStr(ME_COM01Car_typ.Speed)) = -1 Then
    '                    Speed_cmb.SelectedIndex = -1
    '                Else
    '                    AssignListIndex(Speed_cmb, CStr(ME_COM01Car_typ.Speed))
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub TravelFt_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles TravelFt_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_POSITIVE_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub TravelIn_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles TravelIn_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_POSITIVE_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub TravelFt_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles TravelFt_txt.Leave

    '        If Conversion.Val(TravelFt_txt.Text) <> ME_COM01Car_typ.TravelFt Then
    '            If ValidateTextBoxInput_Text(Me, TravelFt_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(1999.99)) <> ENTRY_VALID Then
    '                TravelFt_txt.Text = CStr(ME_COM01Car_typ.TravelFt)
    '            ElseIf ConfirmAmendment(TravelFt_txt, TravelFt_lbl, CStr(ME_COM01Car_typ.TravelFt)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                TravelFt_txt.Text = CStr(ME_COM01Car_typ.TravelFt)
    '            End If
    '        End If

    '    End Sub
    '    Private Sub TravelIn_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles TravelIn_txt.Leave

    '        If Conversion.Val(TravelIn_txt.Text) <> ME_COM01Car_typ.TravelIn Then
    '            If ValidateTextBoxInput_Text(Me, TravelIn_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(11)) <> ENTRY_VALID Then
    '                TravelIn_txt.Text = CStr(ME_COM01Car_typ.TravelIn)
    '            ElseIf ConfirmAmendment(TravelIn_txt, TravelIn_lbl, CStr(ME_COM01Car_typ.TravelIn)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                TravelIn_txt.Text = CStr(ME_COM01Car_typ.TravelIn)
    '            End If
    '        End If

    '    End Sub
    '    Private Sub RopeSize_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeSize_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If bCriteriaRange Then
    '            Exit Sub
    '        End If
    '        If RopeSize_cmb.Text <> ME_MRM01Car_typ.HoistCableSize Then
    '            If ConfirmAmendment(RopeSize_cmb, RopeSize_lbl, ME_MRM01Car_typ.HoistCableSize) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeHoistCableSize = True
    '                Dependents.bIdealCompWeightFlag = True
    '                Dependents.MOD_Parent()
    '                Dependents.bIdealCompWeightFlag = False
    '                Dependents.StatusChangeHoistCableSize = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                If FindString(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize) = -1 Then
    '                    bCriteriaRange = True
    '                    RopeSize_cmb.SelectedIndex = -1
    '                    bCriteriaRange = False
    '                Else
    '                    AssignListIndex(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize)
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Public Sub RopeSize_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopeSize_cmb.SelectedIndexChanged
    '        Dim bCriteria As Boolean

    '        If bCriteriaRange Then
    '            Exit Sub
    '        End If
    '        If RopeSize_cmb.Text <> ME_MRM01Car_typ.HoistCableSize Then
    '            If bLocalChange = 0 Then
    '                bCriteria = ConfirmAmendment(RopeSize_cmb, RopeSize_lbl, ME_MRM01Car_typ.HoistCableSize)
    '            End If
    '            If bCriteria Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.StatusChangeHoistCableSize = True
    '                Dependents.bIdealCompWeightFlag = True
    '                Dependents.MOD_Parent()
    '                Dependents.bIdealCompWeightFlag = False
    '                Dependents.StatusChangeHoistCableSize = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                If FindString(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize) = -1 Then
    '                    bCriteriaRange = True
    '                    RopeSize_cmb.SelectedIndex = -1
    '                    bCriteriaRange = False
    '                Else
    '                    AssignListIndex(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize)
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub RopeSize_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles RopeSize_cmb.KeyDown
    '        Dim KeyCode As Integer = eventArgs.KeyCode

    '        If ME_MRM01Car_typ.MachineModel = "Other" Then
    '            KeyCode = 0
    '        End If

    '    End Sub
    '    Private Sub RopeSize_cmb_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles RopeSize_cmb.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        If ME_MRM01Car_typ.MachineModel = "Other" Then
    '            KeyAscii = 0
    '        Else
    '            ModifyKeyAscii(KeyAscii, CStr(NUMBERS_POSITIVE_ONLY))
    '        End If
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub Roping_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles RopingNew_cmb.SelectedIndexChanged

    '        If RopingNew_cmb.Text <> ME_MRM01Car_typ.RopingNew Then
    '            If ConfirmAmendment(RopingNew_cmb, RopingNew_lbl, ME_MRM01Car_typ.RopingNew) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.StatusChangeRopingNew = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeRopingNew = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                RopingNew_cmb.Text = ME_MRM01Car_typ.RopingNew
    '            End If
    '        End If

    '    End Sub
    '    Private Sub ShoeType_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ShoeType_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If ShoeType_cmb.Text <> ME_CAR01Car_typ.GuidesCarType Then
    '            If ConfirmAmendment(ShoeType_cmb, ShoeType_lbl, ME_CAR01Car_typ.GuidesCarType) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                ShoeType_cmb.Text = ME_CAR01Car_typ.GuidesCarType
    '            End If
    '        End If

    '    End Sub
    '    Private Sub ShoeType_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ShoeType_cmb.SelectedIndexChanged

    '        If ShoeType_cmb.Text <> ME_CAR01Car_typ.GuidesCarType Then
    '            If ConfirmAmendment(ShoeType_cmb, ShoeType_lbl, ME_CAR01Car_typ.GuidesCarType) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                ShoeType_cmb.Text = ME_CAR01Car_typ.GuidesCarType
    '            End If
    '        End If
    '    End Sub
    '    Private Sub Speed_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Speed_cmb.SelectedIndexChanged

    '        If bCriteriaRange Then
    '            Exit Sub
    '        End If
    '        If (Speed_cmb.Text) <> ME_COM01Car_typ.Speed Then
    '            If ConfirmAmendment(Speed_cmb, Speed_lbl, CStr(ME_COM01Car_typ.Speed)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_COM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.StatusChangeMachineToReplaceNew = (ME_MRM01Car_typ.Machine = "Replace" Or ME_MRM01Car_typ.Machine = "New")
    '                Dependents.StatusChangeSpeed = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeSpeed = False
    '                Dependents.StatusChangeMachineToReplaceNew = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                If FindString(Speed_cmb, CStr(ME_COM01Car_typ.Speed)) = -1 Then
    '                    bCriteriaRange = True
    '                    Speed_cmb.SelectedIndex = -1
    '                    bCriteriaRange = False
    '                Else
    '                    AssignListIndex(Speed_cmb, CStr(ME_COM01Car_typ.Speed))
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Speed_cmb_KeyUp(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles Speed_cmb.KeyUp
    '        SetColor_Speed_cmb()
    '    End Sub
    '    Private Sub Vfan_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Vfan_txt.Enter
    '        SelectInputArea(Vfan_txt, 0, Strings.Len(Vfan_txt.Text))
    '    End Sub
    '    Private Sub Vfan_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Vfan_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub Vfan_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Vfan_txt.Leave

    '        If ME_MRM01Car_typ.VFan <> Vfan_txt.Text Then
    '            If ConfirmAmendment(Vfan_txt, Vfan_lbl, CStr(ME_MRM01Car_typ.VFan)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                ME_MRM01Car_typ.VFan = Vfan_txt.Text
    '            Else
    '                Vfan_txt.Text = ME_MRM01Car_typ.VFan
    '            End If
    '        End If
    '        Vfan_txt.BackColor = Color.White

    '    End Sub
    '    Private Sub VFF_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles VFF_txt.Enter
    '        SelectInputArea(VFF_txt, 0, Strings.Len(VFF_txt.Text))
    '    End Sub
    '    Private Sub VFF_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles VFF_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub VFF_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles VFF_txt.Leave
    '        Dim LimitationVFF As Integer

    '        If Not Dependents.StatusChangeDriveType Then
    '            If ME_MRM01Car_typ.ControllerType = DRIVETYPE_QUATTRO Then
    '                LimitationVFF = 355
    '            Else
    '                LimitationVFF = 272
    '            End If
    '            OptionalTitle = VFF_lbl.Text
    '            If ValidateTextBoxInput_Text(Me, VFF_txt, ENTRY_NOT_IN_THE_NUMBER_RANGE, True, CStr(0), CStr(LimitationVFF)) = ENTRY_VALID Then
    '                If Math.Round(Conversion.Val(ME_MRM01Car_typ.VFF), 2) <> Math.Round(Conversion.Val(VFF_txt.Text), 2) Then
    '                    If ConfirmAmendment(VFF_txt, VFF_lbl, CStr(ME_MRM01Car_typ.VFF)) Then
    '                        StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                        MDIChildDirty = True
    '                        ME_MRM01Car_typ.VFF = VFF_txt.Text
    '                    Else
    '                        VFF_txt.Text = ME_MRM01Car_typ.VFF
    '                    End If
    '                End If
    '            End If
    '            VFF_txt.BackColor = IIf(Conversion.Val(VFF_txt.Text) = 0 And GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE, Color.Yellow, Color.White)
    '        End If

    '    End Sub
    '    Private Sub NamePlateArmatureFullLoadVoltage_txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NamePlateArmatureFullLoadVoltage_txt.Enter
    '        SelectInputArea(NamePlateArmatureFullLoadVoltage_txt, 0, Strings.Len(NamePlateArmatureFullLoadVoltage_txt.Text))
    '    End Sub
    '    Private Sub NamePlateArmatureFullLoadVoltage_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NamePlateArmatureFullLoadVoltage_txt.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub NamePlateArmatureFullLoadVoltage_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles NamePlateArmatureFullLoadVoltage_txt.Leave

    '        If Math.Round(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage, 2) <> Math.Round(Conversion.Val(NamePlateArmatureFullLoadVoltage_txt.Text), 2) Then
    '            If ConfirmAmendment(NamePlateArmatureFullLoadVoltage_txt, NamePlateArmatureFullLoadVoltage_lbl, CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage = CSng(NamePlateArmatureFullLoadVoltage_txt.Text)
    '            Else
    '                NamePlateArmatureFullLoadVoltage_txt.Text = CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage)
    '            End If
    '        End If
    '        NamePlateArmatureFullLoadVoltage_txt.BackColor = IIf(Conversion.Val(NamePlateArmatureFullLoadVoltage_txt.Text) = 0 And GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE, Color.Yellow, Color.White)

    '    End Sub
    '    Private Sub Wrap_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Wrap_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If Wrap_cmb.Text <> ME_MRM01Car_typ.Wrap Then
    '            If ConfirmAmendment(Wrap_cmb, Wrap_lbl, ME_MRM01Car_typ.Wrap) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.StatusChangeWrap = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeWrap = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                Wrap_cmb.Text = ME_MRM01Car_typ.Wrap
    '            End If
    '        End If

    '    End Sub
    '    Private Sub Wrap_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Wrap_cmb.SelectedIndexChanged

    '        If Wrap_cmb.Text <> ME_MRM01Car_typ.Wrap Then
    '            If ConfirmAmendment(Wrap_cmb, Wrap_lbl, ME_MRM01Car_typ.Wrap) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bElectricalData = True
    '                Dependents.StatusChangeWrap = True
    '                Dependents.MOD_Parent()
    '                Dependents.StatusChangeWrap = False
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                Wrap_cmb.Text = ME_MRM01Car_typ.Wrap
    '            End If
    '        End If

    '    End Sub
    '    Public Sub Fields2Type()

    '        Try
    '            ME_MRM01Car_typ.MachineVendorNew = ManufacturerNew_cmb.Text
    '            ME_MRM01Car_typ.MachineModelNew = MachineTypeNew_cmb.Text
    '            Dependents.Set_MachineVendor()
    '            Dependents.Set_MachineModel()
    '            ME_MRM01Car_typ.MachineSheaveDia = CStr(Conversion.Val("" & MachineSheaveDia_cmb.Text))
    '            ME_COM01Car_typ.Speed = Convert.ToInt16(Conversion.Val(Speed_cmb.Text))
    '            If GONumbers(CurrentGOSelection).ChangingSpeed = CheckState.Checked Then
    '                ME_COM01Car_typ.SpeedNew = ME_COM01Car_typ.Speed
    '            Else
    '                ME_COM01Car_typ.SpeedExisting = ME_COM01Car_typ.Speed
    '            End If
    '            MN_TRQ01_typ.NomimalMotorRpm = MotorRPM_cmb.Text
    '            ME_MRM01Car_typ.MachineLocation = MachineRoomLocation_cmb.Text
    '            ME_CAR01Car_typ.GuidesCarType = ShoeType_cmb.Text
    '            ME_MRM01Car_typ.ControllerType = DriveType_cmb.Text
    '            ME_COM01Car_typ.Capacity = Convert.ToInt16(Conversion.Val(Capacity_cmb.Text))
    '            ME_COM01Car_typ.TravelFt = Convert.ToInt16(Conversion.Val(TravelFt_txt.Text))
    '            ME_COM01Car_typ.TravelIn = Conversion.Val(TravelIn_txt.Text)
    '            If GONumbers(CurrentGOSelection).ChangingTravel = CheckState.Checked Then
    '                ME_COM01Car_typ.TravelFt_New = ME_COM01Car_typ.TravelFt
    '                ME_COM01Car_typ.TravelIn_New = ME_COM01Car_typ.TravelIn
    '            Else
    '                ME_COM01Car_typ.TravelFt_Existing = ME_COM01Car_typ.TravelFt
    '                ME_COM01Car_typ.TravelIn_Existing = ME_COM01Car_typ.TravelIn
    '            End If
    '            ME_MRM01Car_typ.BrakeType = BrakeType_cmb.Text
    '            If Dependents.HoistwaySheaveDia = SET_TO_ACTIVE Then
    '                ME_HstWay02Car_typ.HoistwaySheaveDia = HoistwaySheave_cmb.Text
    '            End If
    '            ME_COM01Car_typ.Performance = Performance_cmb.Text
    '            ME_CAR01Car_typ.CarWeight = "" & CarWeight_txt.Text
    '            ME_MRM01Car_typ.RopingNew = RopingNew_cmb.Text
    '            ME_MRM01Car_typ.Wrap = Wrap_cmb.Text
    '            ME_MRM01Car_typ.HoistCableSize = RopeSize_cmb.Text
    '            ME_MRM01Car_typ.HoistCableQty = Convert.ToInt16(Conversion.Val(NumberOfRopes_cmb.Text))
    '            ME_COM01Car_typ.PowerSupply = Convert.ToInt16(Conversion.Val(BuildingVoltage_cmb.Text))
    '            ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage = Conversion.Val(NamePlateArmatureFullLoadVoltage_txt.Text)
    '            ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent = Conversion.Val(NamePlateArmatureFullLoadCurrent_txt.Text)
    '            ME_MRM01Car_typ.VFF = VFF_txt.Text
    '            ME_MRM01Car_typ.IFF = Iff_txt.Text
    '            ME_MRM01Car_typ.VFan = Vfan_txt.Text
    '            ME_MRM01Car_typ.IFan = Ifan_txt.Text
    '            ME_PIT01Car_typ.CableChainSize = CompensationSize_cmb.Text
    '            ME_PIT01Car_typ.CableChainQty = Convert.ToInt16(Conversion.Val(CompensationQty_cmb.Text))
    '            ME_PIT01Car_typ.CompensationType = CompensationType_cmb.Text
    '            If Dependents.SheaveDiameter = SET_TO_ACTIVE Then
    '                ME_PIT01Car_typ.SheaveDiameter = CompSheaveDiameter_txt.Text
    '            End If
    '            If Dependents.CarSheaveDiameter = SET_TO_ACTIVE Then
    '                ME_CAR01Car_typ.CarSheaveDiameter = CarSheaveDiameter_cmb.Text
    '            End If
    '            ME_CAR01Car_typ.CarSheaveQty = Convert.ToInt16(Conversion.Val(CarSheaveQty_Cmb.Text))
    '            If Dependents.HWCwtSheaveDia = SET_TO_ACTIVE Then
    '                ME_HstWay02Car_typ.HWCwtSheaveDia = HWCwtSheaveDia_Cmb.Text
    '            End If
    '            MN_TRQ01_typ.MainTravelingCable = MainTravelingCable_cmb.Text
    '            MN_TRQ01_typ.MainTravelingCableQty = Qty1_cmb.Text
    '            MN_TRQ01_typ.AdditionalCoaxCableQty = AdditionalCoaxCableQty_cmb.Text
    '            MN_TRQ01_typ.AdditionalShieldPairsQty = AdditionalShieldPairsQty_cmb.Text
    '            ME_CAR01Car_typ.LoadWeighType = LoadWeighType_cmb.Text
    '            If MN_TRQ01_typ.bDirty Then
    '                FormsArray(ENGINEERING_FORMS, MN_TRQ02_MENU_INDEX).FormIsCompleted = False
    '                StatusData.FormsStatus(ENGINEERING_FORMS, MN_TRQ02_MENU_INDEX) = FORM_IS_CLEAN
    '            End If
    '            MN_TRQ01_typ.RopeGripperModel = RopeGripperModel_cmb.Text
    '            ME_MRM01Car_typ.RopeGripper = RopeGripper_cmb.Text
    '            ME_MRM01Car_typ.RopeGripperMount = RopeGripperMount_cmb.Text
    '            MN_TRQ01_typ.MountingToOuterMBflanges = MountingToOuterMBflanges_chk.CheckState
    '            ME_MRM02Car_typ.CarGovernorNewModel = CarGovernorNewModel_cmb.Text
    '            MN_TRQ01_typ.CarGovernorFastening = CarGovernorFastening_cmb.Text
    '            ME_MRM02Car_typ.CwtGovernorNewModel = CwtGovernorNewModel_cmb.Text
    '            MN_TRQ01_typ.CwtGovernorFastening = CwtGovernorFastening_cmb.Text
    '            MN_TRQ01_typ.RopeSplayKitMounting = RopeSplayKitMounting_cmb.Text
    '            MN_TRQ01_typ.QtyStarRepeater = RoundToNextHigherOrEqualInteger(Conversion.Val(QtyStarRepeater_cmb.Text))

    '        Catch
    '            MessageBox.Show(Conversion.ErrorToString(), "Fields2Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End Try

    '    End Sub
    '    Public Sub Type2Fields()

    '        isInitializingComponent = True
    '        MachineVendorExisting_Cmb.Text = ME_MRM01Car_typ.MachineVendorExisting
    '        MachineModelExisting_cmb.Text = ME_MRM01Car_typ.MachineModelExisting
    '        AssignListIndex(ManufacturerNew_cmb, ME_MRM01Car_typ.MachineVendorNew)
    '        AssignListIndex(MachineTypeNew_cmb, ME_MRM01Car_typ.MachineModelNew)
    '        If Dependents.MachineSheaveDiaTorque = SET_TO_ACTIVE Then
    '            If FindString(MachineSheaveDia_cmb, ME_MRM01Car_typ.MachineSheaveDia) = -1 Then
    '                If Conversion.Val(ME_MRM01Car_typ.MachineSheaveDia) = 0 Then
    '                    AssignListIndex_First(MachineSheaveDia_cmb, ME_MRM01Car_typ.MachineSheaveDia)
    '                Else
    '                    MachineSheaveDia_cmb.Text = ME_MRM01Car_typ.MachineSheaveDia
    '                End If
    '            Else
    '                AssignListIndex(MachineSheaveDia_cmb, ME_MRM01Car_typ.MachineSheaveDia)
    '            End If
    '        Else
    '            MachineSheaveDia_cmb.Text = ME_MRM01Car_typ.MachineSheaveDia
    '        End If
    '        If FindString(Speed_cmb, CStr(ME_COM01Car_typ.Speed)) = -1 Then
    '            Speed_cmb.SelectedIndex = -1
    '        Else
    '            AssignListIndex(Speed_cmb, CStr(ME_COM01Car_typ.Speed))
    '        End If
    '        Select Case GONumbers(CurrentGOSelection).MachineTypeExisting
    '            Case GEARED_TYPE
    '                AssignListIndex_First(MotorRPM_cmb, MN_TRQ01_typ.NomimalMotorRpm)
    '                AssignListIndex(DriveType_cmb, IIf(ME_MRM01Car_typ.ControllerType = "", DRIVETYPE_BR, ME_MRM01Car_typ.ControllerType))
    '            Case GEARLESS_TYPE
    '                AssignListIndex(MotorRPM_cmb, "None")
    '                AssignListIndex(DriveType_cmb, ME_MRM01Car_typ.ControllerType)
    '        End Select
    '        AssignListIndex(MachineRoomLocation_cmb, ME_MRM01Car_typ.MachineLocation)
    '        AssignListIndex(ShoeType_cmb, ME_CAR01Car_typ.GuidesCarType)
    '        If FindString(Capacity_cmb, CStr(ME_COM01Car_typ.Capacity)) = -1 Then
    '            Capacity_cmb.Text = CStr(ME_COM01Car_typ.Capacity)
    '        Else
    '            AssignListIndex(Capacity_cmb, CStr(ME_COM01Car_typ.Capacity))
    '        End If
    '        TravelFt_txt.Text = CStr(Conversion.Val(CStr(ME_COM01Car_typ.TravelFt)))
    '        TravelIn_txt.Text = IIf(Conversion.Val(CStr(ME_COM01Car_typ.TravelIn)) = 0, "", CStr(Conversion.Val(CStr(ME_COM01Car_typ.TravelIn))))
    '        AssignListIndex(BrakeType_cmb, ME_MRM01Car_typ.BrakeType)
    '        If Dependents.HoistwaySheaveDia = SET_TO_ACTIVE Then
    '            If FindString(HoistwaySheave_cmb, ME_HstWay02Car_typ.HoistwaySheaveDia) = -1 Then
    '                HoistwaySheave_cmb.Text = ME_HstWay02Car_typ.HoistwaySheaveDia
    '            Else
    '                AssignListIndex(HoistwaySheave_cmb, ME_HstWay02Car_typ.HoistwaySheaveDia)
    '            End If
    '        End If
    '        AssignListIndex(Performance_cmb, ME_COM01Car_typ.Performance)
    '        CarWeight_txt.Text = ME_CAR01Car_typ.CarWeight
    '        AssignListIndex(RopingNew_cmb, ME_MRM01Car_typ.RopingNew)
    '        AssignListIndex(Wrap_cmb, ME_MRM01Car_typ.Wrap)
    '        If FindString(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize) = -1 Then
    '            AssignListIndex_First(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize)
    '        Else
    '            AssignListIndex(RopeSize_cmb, ME_MRM01Car_typ.HoistCableSize)
    '        End If
    '        If FindString(NumberOfRopes_cmb, CStr(ME_MRM01Car_typ.HoistCableQty)) = -1 Then
    '            NumberOfRopes_cmb.Text = CStr(ME_MRM01Car_typ.HoistCableQty)
    '            NumberOfRopes_cmb.BackColor = Color.Red
    '        Else
    '            AssignListIndex(NumberOfRopes_cmb, CStr(ME_MRM01Car_typ.HoistCableQty))
    '            NumberOfRopes_cmb.BackColor = Color.White
    '        End If
    '        AssignListIndex(BuildingVoltage_cmb, CStr(ME_COM01Car_typ.PowerSupply))
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Or ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            NamePlateArmatureFullLoadVoltage_txt.BackColor = Color.White
    '            NamePlateArmatureFullLoadCurrent_txt.BackColor = Color.White
    '            VFF_txt.BackColor = Color.White
    '            Iff_txt.BackColor = Color.White
    '            Vfan_txt.BackColor = Color.White
    '            Ifan_txt.BackColor = Color.White
    '        Else
    '            NamePlateArmatureFullLoadVoltage_txt.BackColor = IIf(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage = 0, Color.Yellow, Color.White)
    '            NamePlateArmatureFullLoadCurrent_txt.BackColor = IIf(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent = 0, Color.Yellow, Color.White)
    '            VFF_txt.BackColor = IIf(ME_MRM01Car_typ.VFF = "", Color.Yellow, Color.White)
    '            Iff_txt.BackColor = IIf(ME_MRM01Car_typ.IFF = "", Color.Yellow, Color.White)
    '            Vfan_txt.BackColor = Color.White
    '            Ifan_txt.BackColor = Color.White
    '        End If
    '        If ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent = 0 Then
    '            NamePlateArmatureFullLoadCurrent_txt.Text = String.Empty
    '        Else
    '            NamePlateArmatureFullLoadCurrent_txt.Text = CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent)
    '        End If
    '        If ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage = 0 Then
    '            NamePlateArmatureFullLoadVoltage_txt.Text = String.Empty
    '        Else
    '            NamePlateArmatureFullLoadVoltage_txt.Text = CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage)
    '        End If
    '        VFF_txt.Text = ME_MRM01Car_typ.VFF
    '        Iff_txt.Text = ME_MRM01Car_typ.IFF
    '        Vfan_txt.Text = ME_MRM01Car_typ.VFan
    '        Ifan_txt.Text = ME_MRM01Car_typ.IFan
    '        CheckforNullTypeCombo(CompensationType_cmb, ME_PIT01Car_typ.CompensationType)
    '        If FindString(CompensationSize_cmb, ME_PIT01Car_typ.CableChainSize) = -1 Then
    '            ME_PIT01Car_typ.CableChainQty = 0
    '            Dependents.CableChainQty = SET_TO_GREY
    '        End If
    '        CheckforNullTypeCombo(CompensationSize_cmb, ME_PIT01Car_typ.CableChainSize)
    '        If ME_PIT01Car_typ.CableChainQty = 0 Then
    '            CompensationQty_cmb.SelectedIndex = -1
    '        Else
    '            CheckforNullTypeCombo(CompensationQty_cmb, CStr(ME_PIT01Car_typ.CableChainQty))
    '        End If
    '        If Dependents.SheaveDiameter = SET_TO_ACTIVE Then
    '            CompSheaveDiameter_txt.Text = ME_PIT01Car_typ.SheaveDiameter
    '        End If
    '        If Dependents.CarSheaveDiameter = SET_TO_ACTIVE Then
    '            CheckforNullTypeCombo(CarSheaveDiameter_cmb, ME_CAR01Car_typ.CarSheaveDiameter)
    '        End If
    '        If ME_CAR01Car_typ.CarSheaveQty = 0 Then
    '            CarSheaveQty_Cmb.SelectedIndex = -1
    '        Else
    '            CarSheaveQty_Cmb.Text = CStr(ME_CAR01Car_typ.CarSheaveQty)
    '        End If
    '        If Dependents.HWCwtSheaveDia = SET_TO_ACTIVE Then
    '            CheckforNullTypeCombo(HWCwtSheaveDia_Cmb, ME_HstWay02Car_typ.HWCwtSheaveDia)
    '        End If
    '        AssignListIndex(Qty1_cmb, MN_TRQ01_typ.MainTravelingCableQty)
    '        AssignListIndex(AdditionalCoaxCableQty_cmb, MN_TRQ01_typ.AdditionalCoaxCableQty)
    '        AssignListIndex(AdditionalShieldPairsQty_cmb, MN_TRQ01_typ.AdditionalShieldPairsQty)
    '        If MN_TRQ01_typ.MainTravelingCable = "" Then
    '            If MainTravelingCable_cmb.Items.Count > 0 Then
    '                MN_TRQ01_typ.MainTravelingCable = MainTravelingCable_cmb.GetListItem(0)
    '            End If
    '        End If
    '        AssignListIndex(MainTravelingCable_cmb, MN_TRQ01_typ.MainTravelingCable)
    '        Dependents.Set_ControlCableWeight()
    '        CheckforNullTypeCombo(LoadWeighType_cmb, ME_CAR01Car_typ.LoadWeighType)
    '        CheckforNullTypeCombo(RopeGripperModel_cmb, MN_TRQ01_typ.RopeGripperModel)
    '        If ME_MRM01Car_typ.RopeGripper = "Included" Then
    '            RopeGripper_cmb.Text = ME_MRM01Car_typ.RopeGripper
    '        Else
    '            CheckforNullTypeCombo(RopeGripper_cmb, ME_MRM01Car_typ.RopeGripper)
    '        End If
    '        CheckforNullTypeCombo(RopeGripperMount_cmb, ME_MRM01Car_typ.RopeGripperMount)
    '        MountingToOuterMBflanges_chk.CheckState = MN_TRQ01_typ.MountingToOuterMBflanges
    '        CheckforNullTypeCombo(CarGovernorNewModel_cmb, ME_MRM02Car_typ.CarGovernorNewModel)
    '        CheckforNullTypeCombo(CarGovernorFastening_cmb, MN_TRQ01_typ.CarGovernorFastening)
    '        CheckforNullTypeCombo(CwtGovernorNewModel_cmb, ME_MRM02Car_typ.CwtGovernorNewModel)
    '        CheckforNullTypeCombo(CwtGovernorFastening_cmb, MN_TRQ01_typ.CwtGovernorFastening)
    '        CheckforNullTypeCombo(RopeSplayKitMounting_cmb, MN_TRQ01_typ.RopeSplayKitMounting)
    '        CheckforNullTypeCombo(QtyStarRepeater_cmb, MN_TRQ01_typ.QtyStarRepeater)
    '        isInitializingComponent = False

    '    End Sub
    '    Private Sub SortByTabOrder()
    '        Dim lControl As Control
    '        Dim k, L As Integer

    '        On Error GoTo err_SortByTabOrder

    '        ReDim aControls(0)
    '        L = -1

    '        Dim cControl As Control
    '        Dim cControlChild As Control
    '        L = -1
    '        For i As Integer = 0 To Me.Controls.Count - 1
    '            If TypeOf Me.Controls(i) Is GroupBox Then
    '                For Each cControlChild In Me.Controls(i).Controls
    '                    k = -1
    '                    k = cControlChild.TabIndex
    '                    If k > -1 Then
    '                        L += 1
    '                        ReDim Preserve aControls(L)
    '                        aControls(L) = cControlChild
    '                    End If
    '                Next
    '            Else
    '                k = -1
    '                k = Me.Controls(i).TabIndex
    '                If k > -1 Then
    '                    L += 1
    '                    ReDim Preserve aControls(L)
    '                    aControls(L) = Me.Controls(i)
    '                End If
    '            End If
    '        Next i
    '        For i As Integer = 0 To L - 1
    '            For j As Integer = i + 1 To L
    '                If aControls(i).TabIndex > aControls(j).TabIndex Then
    '                    lControl = aControls(i)
    '                    aControls(i) = aControls(j)
    '                    aControls(j) = lControl
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
    '    Public Sub Validate_Renamed()
    '        MN_TRQ01.Validate_Dependents()
    '    End Sub
    '    Public Function PreTorqueValidation(ByRef bErrorMessage As Boolean) As Integer
    '        Dim result As Integer = 0
    '        Dim sTag As String = ""
    '        Dim bCriteria As Boolean
    '        Dim sMsg As String = ""
    '        Dim bOverhead As Boolean
    '        Dim TempVal1 As String
    '        Dim TempVal2 As String

    '        Try
    '            result = True
    '            For i As Integer = 0 To aControls.GetUpperBound(0)
    '                sTag = Convert.ToString(aControls(i).Tag)
    '                If sTag.Length Then
    '                    If Strings.Left(sTag, 1) = "1" Then
    '                        bCriteria = False
    '                        If aControls(i).ToString() = "" Then
    '                            bCriteria = True
    '                        Else
    '                            If TypeOf aControls(i) Is TextBox Then
    '                                If Conversion.Val("" & aControls(i).Text.ToString()) = 0 And aControls(i).Enabled Then
    '                                    bCriteria = True
    '                                End If
    '                            End If
    '                        End If
    '                        If aControls(i).Name = "Speed_cmb" Or aControls(i).Name = "NumberOfRopes_cmb" Then
    '                            If Conversion.Val(aControls(i).Text.ToString()) = 0 Then
    '                                bCriteria = True
    '                            End If
    '                        End If
    '                        If bCriteria Then
    '                            If sTag = "1 Geared" Then
    '                                If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                                    bCriteria = False
    '                                End If
    '                            End If
    '                        End If
    '                        If bCriteria Then
    '                            If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '                                Select Case aControls(i).Name
    '                                    Case "TravelIn_txt", "MotorRPM_cmb", "Vfan_txt", "Ifan_txt"
    '                                        bCriteria = False
    '                                End Select
    '                            Else
    '                                Select Case aControls(i).Name
    '                                    Case "DriveType_cmb", "TravelIn_txt"
    '                                        bCriteria = False
    '                                    Case "HoistwaySheave_cmb"
    '                                        If ME_HstWay02Car_typ.HoistwaySheave <> "New" And ME_HstWay02Car_typ.HoistwaySheave <> "Replace" Then
    '                                            bCriteria = False
    '                                        End If
    '                                    Case "CarWeight_txt"
    '                                        If Dependents.CarWeight = SET_TO_GREY Then
    '                                            bCriteria = False
    '                                        End If
    '                                End Select
    '                            End If
    '                        End If
    '                        If bCriteria Then
    '                            If ME_HstWay02Car_typ.HoistwaySheave = "Replace" Or ME_HstWay02Car_typ.HoistwaySheave = "New" Then
    '                                If ME_MRM01Car_typ.MachineLocation <> "Overhead" Then
    '                                    bOverhead = True
    '                                End If
    '                            End If
    '                            Select Case aControls(i).Name
    '                                Case "HoistwaySheave_cmb"
    '                                    If Dependents.HoistwaySheaveDia = SET_TO_GREY Then
    '                                        bCriteria = False
    '                                    Else
    '                                        If bOverhead Then
    '                                            bCriteria = False
    '                                        End If
    '                                    End If
    '                                Case "CompensationType_cmb", "CompensationSize_cmb"
    '                                    If Dependents.CompensationType <> SET_TO_ACTIVE Then
    '                                        bCriteria = False
    '                                    End If
    '                                Case "CompensationQty_cmb"
    '                                    If Dependents.CableChainQty <> SET_TO_ACTIVE Then
    '                                        bCriteria = False
    '                                    End If
    '                                Case "CompSheaveDiameter_txt"
    '                                    If Dependents.SheaveDiameter = SET_TO_GREY Then
    '                                        bCriteria = False
    '                                    End If
    '                                Case "CarWeight_txt"
    '                                    If Dependents.CarWeight = SET_TO_GREY Then
    '                                        bCriteria = False
    '                                    End If
    '                            End Select
    '                        End If
    '                        If bCriteria Then
    '                            Select Case aControls(i).Name
    '                                Case "VFF_txt", "Iff_txt", "Ifan_txt", "Vfan_txt", "NamePlateArmatureFullLoadVoltage_txt", "NamePlateArmatureFullLoadCurrent_txt"
    '                                    If ME_MRM01Car_typ.Controller = "Reuse" Or ME_MRM01Car_typ.ControllerVendor = MCE Then
    '                                        bCriteria = False
    '                                    End If
    '                                Case Else
    '                            End Select
    '                        End If
    '                        If bCriteria Then
    '                            If bErrorMessage Then
    '                                Dependents.ParentFlag = True
    '                                If ENG_ACCESS Then
    '                                    MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "A value must be entered for " & LabelCaption(aControls(i).Name), MsgBoxStyle.Critical)
    '                                    If aControls(i).Enabled Then
    '                                        If aControls(i).Visible Then
    '                                            aControls(i).Focus()
    '                                        End If
    '                                    End If
    '                                End If
    '                                Dependents.ParentFlag = False
    '                                result = False
    '                                bTorqueCriticalError = True
    '                            End If
    '                        End If

    '                        Select Case aControls(i).Name
    '                            Case "MachineSheaveDia_cmb"
    '                                If (ME_MRM01Car_typ.Controller = "New" Or ME_MRM01Car_typ.Controller = "Replace") And
    '                                   Dependents.MachineSheaveDiaTorque = SET_TO_ACTIVE Then
    '                                    If Conversion.Val(MachineSheaveDia_cmb.Text) = 0 Then
    '                                        If bErrorMessage Then
    '                                            Dependents.ParentFlag = True
    '                                            If ENG_ACCESS Then
    '                                                MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Data for Machine Sheave Diameter must be entered.", MsgBoxStyle.Critical)
    '                                                MachineSheaveDia_cmb.Focus()
    '                                            End If
    '                                            Dependents.ParentFlag = False
    '                                            result = False
    '                                            bTorqueCriticalError = True
    '                                        End If
    '                                    Else
    '                                        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                                            If Conversion.Val(MachineSheaveDia_cmb.Text) < 20 Then
    '                                                Dependents.ParentFlag = True
    '                                                If ENG_ACCESS Then
    '                                                    MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Machine Sheave Diameter cannot be less than 20!", MsgBoxStyle.Critical)
    '                                                    MachineSheaveDia_cmb.Focus()
    '                                                End If
    '                                                Dependents.ParentFlag = False
    '                                                result = False
    '                                                bTorqueCriticalError = True
    '                                            End If
    '                                        ElseIf ME_MRM01Car_typ.MachineModelNew <> "" Then
    '                                            If Conversion.Val(MachineSheaveDia_cmb.Text) < Math.Floor(cMinimumSheaveDiameter(ME_MRM01Car_typ.MachineModelNew)) Then
    '                                                Select Case ME_MRM01Car_typ.MachineModelNew
    '                                                    Case MACHINE_FMM200, MACHINE_FMR355, MACHINE_PMR355
    '                                                    Case Else
    '                                                        Dependents.ParentFlag = True
    '                                                        If ENG_ACCESS Then
    '                                                            MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Machine Sheave Diameter for " & ME_MRM01Car_typ.MachineModelNew & " cannot be less than " & cMinimumSheaveDiameter(ME_MRM01Car_typ.MachineModelNew) & "!", MsgBoxStyle.Critical)
    '                                                            MachineSheaveDia_cmb.Focus()
    '                                                        End If
    '                                                        Dependents.ParentFlag = False
    '                                                        result = False
    '                                                        bTorqueCriticalError = True
    '                                                End Select
    '                                            End If
    '                                        End If
    '                                        If Conversion.Val(MachineSheaveDia_cmb.Text) > 50 Then
    '                                            Dependents.ParentFlag = True
    '                                            If ENG_ACCESS Then
    '                                                MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Machine Sheave Diameter cannot be more then 50!", MsgBoxStyle.Critical)
    '                                                MachineSheaveDia_cmb.Focus()
    '                                            End If
    '                                            Dependents.ParentFlag = False
    '                                            result = False
    '                                            bTorqueCriticalError = True
    '                                        End If
    '                                    End If
    '                                End If
    '                            Case "NamePlateArmatureFullLoadVoltage_txt"
    '                                TempVal1 = ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage.ToString
    '                                TempVal2 = ME_MRM01Car_typ.ControllerType
    '                                If Dependents.NamePlateArmatureFullLoadVoltage = SET_TO_ACTIVE And Not (ME_MRM01Car_typ.Controller = "Reuse" Or ME_MRM01Car_typ.ControllerVendor = MCE) Then
    '                                    Dependents.ParentFlag = FormIsLoaded("MN_TRQ01_frm")
    '                                    If Conversion.Val(TempVal1) = 0 Then
    '                                        MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "A value for Armature Voltage (VFLU) must be entered", MsgBoxStyle.Critical)
    '                                    ElseIf TempVal2 = DRIVETYPE_QUATTRO Then
    '                                        If TempVal1 < 55 Then
    '                                            MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Minimum value for Armature Voltage (VFLU) for Quattro Drive is 55 (you entered " & TempVal1 & ")", MsgBoxStyle.Critical)
    '                                        ElseIf TempVal1 > 550 Then
    '                                            MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Maximum value for Armature Voltage (VFLU) for Quattro Drive is 550 (you entered " & TempVal1 & ")", MsgBoxStyle.Critical)
    '                                        End If
    '                                    ElseIf TempVal2 = DRIVETYPE_SCRDC Then
    '                                        If TempVal1 < 150 Then
    '                                            MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Minimum value for Armature Voltage (VFLU) for SCR/DC Drive is 150 (you entered " & TempVal1 & ")", MsgBoxStyle.Critical)
    '                                        ElseIf TempVal1 > 550 Then
    '                                            MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "Maximum value for Armature Voltage (VFLU) for SCR/DC Drive is 550 (you entered " & TempVal1 & ")", MsgBoxStyle.Critical)
    '                                        End If
    '                                    End If
    '                                    Dependents.ParentFlag = False
    '                                End If
    '                            Case "RopeGripperModel_cmb"
    '                                Select Case MN_TRQ01_typ.RopeGripperModel
    '                                    Case "SB200", "SB330", "SB331", "SB380"
    '                                        Select Case ME_COM01Car_typ.Speed
    '                                            Case Is > 1000
    '                                                If ME_MRM01Car_typ.RopingNew = "1:1" Then
    '                                                    Dependents.ParentFlag = True
    '                                                    If ENG_ACCESS Then
    '                                                        MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "You cannot use " & MN_TRQ01_typ.RopeGripperModel & " when Roping 1:1 and Speed > 1000", MsgBoxStyle.Critical)
    '                                                        MachineSheaveDia_cmb.Focus()
    '                                                    End If
    '                                                    Dependents.ParentFlag = False
    '                                                    result = False
    '                                                    bTorqueCriticalError = True
    '                                                End If
    '                                            Case Is > 500
    '                                                If ME_MRM01Car_typ.RopingNew = "2:1" Then
    '                                                    Dependents.ParentFlag = True
    '                                                    If ENG_ACCESS Then
    '                                                        MessageHandler(ENGINEERING_FORMS, MN_TRQ01_MENU_INDEX, "You cannot use " & MN_TRQ01_typ.RopeGripperModel & " when Roping 2:1 and Speed > 500", MsgBoxStyle.Critical)
    '                                                        MachineSheaveDia_cmb.Focus()
    '                                                    End If
    '                                                    Dependents.ParentFlag = False
    '                                                    result = False
    '                                                    bTorqueCriticalError = True
    '                                                End If
    '                                        End Select
    '                                End Select
    '                        End Select
    '                    End If
    '                End If
    '            Next i

    '            Return result

    '        Catch
    '            MessageBox.Show(Conversion.ErrorToString(), "PreTorqueValidation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '            Return result

    '        End Try

    '    End Function
    '    Private Sub Load_ListBoxes()
    '        Dim i As Integer
    '        Dim sSQL As String = "SELECT DISTINCT Manufacturer FROM SuperTable WHERE MachineType='" & GONumbers(CurrentGOSelection).MachineType & "'"

    '        MachineVendorExisting_Cmb.Items.Clear()
    '        MachineVendorExisting_Cmb.Items.Add(ME_MRM01Car_typ.MachineVendorExisting)

    '        MachineModelExisting_cmb.Items.Clear()
    '        MachineModelExisting_cmb.Items.Add(ME_MRM01Car_typ.MachineModelExisting)

    '        ManufacturerNew_cmb.Items.Clear()
    '        If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '            If ME_MRM01Car_typ.ControllerVendor = MCE Then
    '                ManufacturerNew_cmb.Items.Add(IMPERIAL)
    '                ManufacturerNew_cmb.Items.Add(OTHER)
    '            Else
    '                sSQL = "SELECT DISTINCT Manufacturer FROM SuperTable_Gearless WHERE MachineType='" & GEARLESS_TYPE & "'"
    '                WorkingRecordSet = New ADODB.Recordset
    '                WorkingRecordSet.Open(sSQL, ADOConnection)
    '                Do While Not WorkingRecordSet.EOF
    '                    ManufacturerNew_cmb.Items.Add(WorkingRecordSet("Manufacturer").Value)
    '                    WorkingRecordSet.MoveNext()
    '                Loop
    '                WorkingRecordSet.Close()
    '                WorkingRecordSet = Nothing
    '            End If
    '        Else
    '            ManufacturerNew_cmb.Items.Add(HOLLISTERWHITNEY)
    '        End If

    '        MachineTypeNew_cmb.Items.Clear()
    '        If ME_MRM01Car_typ.MachineVendorNew <> OTHER Then
    '            If GONumbers(CurrentGOSelection).MachineType = GEARLESS_TYPE Then
    '                sSQL = "SELECT DISTINCT MachineModel From SuperTable_Gearless WHERE MachineType='" & GEARLESS_TYPE & "' AND Manufacturer='" & ME_MRM01Car_typ.MachineVendorNew & "' ORDER BY MachineModel"
    '            Else
    '                sSQL = "SELECT DISTINCT MachineModel From SuperTable WHERE MachineType='" & GEARED_TYPE & "' AND Manufacturer='" & ME_MRM01Car_typ.MachineVendorNew & "' ORDER BY MachineModel"
    '            End If
    '            WorkingRecordSet = New ADODB.Recordset
    '            WorkingRecordSet.Open(sSQL, ADOConnection)
    '            Do While Not WorkingRecordSet.EOF
    '                MachineTypeNew_cmb.Items.Add(WorkingRecordSet("MachineModel").Value)
    '                WorkingRecordSet.MoveNext()
    '            Loop
    '            WorkingRecordSet.Close()
    '            WorkingRecordSet = Nothing
    '        End If
    '        If ME_MRM01Car_typ.MachineVendorNew <> IMPERIAL Then
    '            MachineTypeNew_cmb.Items.Add(OTHER)
    '        End If

    '        Speed_cmb.Items.Clear()
    '        Select Case GONumbers(CurrentGOSelection).MachineTypeExisting
    '            Case HYDRO_TYPE
    '                For i = 50 To 200 Step 25
    '                    Speed_cmb.Items.Add(CStr(i))
    '                Next i
    '            Case GEARED_TYPE
    '                Speed_cmb.Items.Add("100")
    '                Speed_cmb.Items.Add("150")
    '                Speed_cmb.Items.Add("200")
    '                Speed_cmb.Items.Add("250")
    '                Speed_cmb.Items.Add("300")
    '                Speed_cmb.Items.Add("350")
    '                Speed_cmb.Items.Add("400")
    '                Speed_cmb.Items.Add("450")
    '                Speed_cmb.Items.Add("500")
    '            Case GEARLESS_TYPE
    '                Speed_cmb.Items.Add("500")
    '                Speed_cmb.Items.Add("600")
    '                Speed_cmb.Items.Add("700")
    '                Speed_cmb.Items.Add("800")
    '                Speed_cmb.Items.Add("900")
    '                Speed_cmb.Items.Add("1000")
    '                Speed_cmb.Items.Add("1100")
    '                Speed_cmb.Items.Add("1200")
    '                Speed_cmb.Items.Add("1300")
    '                Speed_cmb.Items.Add("1400")
    '                If FindString(Speed_cmb, ME_COM01Car_typ.Speed) = -1 Then
    '                    sSQL = "SELECT DISTINCT Speed From SuperTable WHERE MachineType='" & GONumbers(CurrentGOSelection).MachineType & "' AND Manufacturer='" & ME_MRM01Car_typ.MachineVendor & "' "
    '                    sSQL = sSQL & "AND MachineModel='" & ME_MRM01Car_typ.MachineModel & "' ORDER BY Speed"
    '                    WorkingRecordSet = New ADODB.Recordset
    '                    WorkingRecordSet.Open(sSQL, ADOConnection)
    '                    If Not WorkingRecordSet.EOF Then Speed_cmb.Items.Clear()
    '                    Do While Not WorkingRecordSet.EOF
    '                        If FindString(Speed_cmb, WorkingRecordSet("Speed").Value) = -1 Then
    '                            Speed_cmb.Items.Add(WorkingRecordSet("Speed").Value)
    '                        End If
    '                        WorkingRecordSet.MoveNext()
    '                    Loop
    '                    WorkingRecordSet.Close()
    '                    WorkingRecordSet = Nothing
    '                End If
    '        End Select

    '        MotorRPM_cmb.Items.Clear()
    '        If Dependents.MotorRPM = SET_TO_ACTIVE Then
    '            For Each aRPM_item As String In aRPM
    '                If Not (aRPM_item Is Nothing) Then
    '                    MotorRPM_cmb.Items.Add(aRPM_item)
    '                End If
    '            Next aRPM_item
    '        End If

    '        i = -1
    '        WorkingRecordSet = New ADODB.Recordset
    '        WorkingRecordSet.Open("MRLocations", ADOConnection)
    '        MachineRoomLocation_cmb.Items.Clear()
    '        Do While Not WorkingRecordSet.EOF
    '            MachineRoomLocation_cmb.Items.Add(WorkingRecordSet("MRLocation").Value)
    '            If WorkingRecordSet("MRLocation").Value = "Overhead" Then
    '                i = MachineRoomLocation_cmb.Items.Count - 1
    '            End If
    '            WorkingRecordSet.MoveNext()
    '        Loop
    '        WorkingRecordSet.Close()
    '        WorkingRecordSet = Nothing

    '        ShoeType_cmb.Items.Clear()
    '        ShoeType_cmb.Items.Add("Roller")
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '            ShoeType_cmb.Items.Add("Sliding")
    '        End If

    '        DriveType_cmb.Items.Clear()
    '        If GONumbers(CurrentGOSelection).MachineTypeExisting = GEARLESS_TYPE Then
    '            DriveType_cmb.Items.Add(DRIVETYPE_SCRDC)
    '            If ME_MRM01Car_typ.ControllerModel = MODEL_TXR5 Or ME_MRM01Car_typ.SID_Type = SID_PH_MOD Or ME_MRM01Car_typ.SID_Type = SID_MTO Then
    '                DriveType_cmb.Items.Add(DRIVETYPE_QUATTRO)
    '            End If
    '            DriveType_cmb.Items.Add(DRIVETYPE_PF1)
    '        Else
    '            DriveType_cmb.Items.Add(DRIVETYPE_BR)
    '            DriveType_cmb.Items.Add(DRIVETYPE_PF1)
    '        End If

    '        Capacity_cmb.Items.Clear()
    '        Capacity_cmb.Items.Add("1500")
    '        Capacity_cmb.Items.Add("2000")
    '        Capacity_cmb.Items.Add("2500")
    '        Capacity_cmb.Items.Add("3000")
    '        Capacity_cmb.Items.Add("3500")
    '        Capacity_cmb.Items.Add("4000")
    '        Capacity_cmb.Items.Add("4500")
    '        Capacity_cmb.Items.Add("5000")
    '        Capacity_cmb.Items.Add("6000")

    '        BrakeType_cmb.Items.Clear()
    '        For i = 0 To aBrakeType.GetUpperBound(0)
    '            BrakeType_cmb.Items.Add(aBrakeType(i))
    '        Next i

    '        HoistwaySheave_cmb.Items.Clear()
    '        Select Case GONumbers(CurrentGOSelection).MachineType
    '            Case GEARED_TYPE
    '                If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 20 Then
    '                    HoistwaySheave_cmb.Items.Add("20")
    '                End If
    '                If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 25 Then
    '                    HoistwaySheave_cmb.Items.Add("25")
    '                End If
    '                If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 26 Then
    '                    HoistwaySheave_cmb.Items.Add("26")
    '                End If
    '                HoistwaySheave_cmb.Items.Add("30")
    '            Case GEARLESS_TYPE
    '                HoistwaySheave_cmb.Items.Add("None")
    '                sSQL = "SELECT * FROM [Sec Sheave Dia Gearless Query] ORDER BY [Sec Sheave Dia Gearless].[sec sheav dia]"
    '                WorkingRecordSet = New ADODB.Recordset
    '                WorkingRecordSet.Open(sSQL, ADOConnection)
    '                Do While Not WorkingRecordSet.EOF
    '                    If WorkingRecordSet(0).Value <> 0 Then
    '                        Dim UseResult As Integer = HoistwaySheave_cmb.Items.Add(WorkingRecordSet(0).Value)
    '                        If ME_MRM01Car_typ.MachineModel.Length > 0 Then
    '                            If ME_MRM01Car_typ.MachineModel <> "Other" Then
    '                                HoistwaySheave_cmb.SetItemData(UseResult, Math.Floor(WorkingRecordSet.Fields(1).Value * 1000))
    '                            End If
    '                        End If
    '                    End If
    '                    WorkingRecordSet.MoveNext()
    '                Loop
    '                WorkingRecordSet.Close()
    '                WorkingRecordSet = Nothing
    '        End Select

    '        Performance_cmb.Items.Clear()
    '        Performance_cmb.Items.Add(StandardPerformance)
    '        Performance_cmb.Items.Add(HighPerformance)

    '        RopingNew_cmb.Items.Clear()
    '        RopingNew_cmb.Items.Add("1:1")
    '        RopingNew_cmb.Items.Add("2:1")

    '        RopeSize_cmb.Items.Clear()
    '        For j As Integer = 0 To aHoistCableSize.GetUpperBound(0)
    '            If FindString(RopeSize_cmb, aHoistCableSize(j)) = -1 Then
    '                RopeSize_cmb.Items.Add(aHoistCableSize(j))
    '            End If
    '        Next j

    '        NumberOfRopes_cmb.Items.Clear()
    '        For i = 3 To Dependents.MaxNumberRopes
    '            NumberOfRopes_cmb.Items.Add(CStr(i))
    '        Next i

    '        BuildingVoltage_cmb.Items.Clear()
    '        BuildingVoltage_cmb.Items.Add("208")
    '        BuildingVoltage_cmb.Items.Add("240")
    '        If All_LocalCodeDep.CanadaJob Then
    '            BuildingVoltage_cmb.Items.Add("416")
    '        End If
    '        BuildingVoltage_cmb.Items.Add("440")
    '        BuildingVoltage_cmb.Items.Add("460")
    '        BuildingVoltage_cmb.Items.Add("480")
    '        BuildingVoltage_cmb.Items.Add("575")
    '        BuildingVoltage_cmb.Items.Add("600")

    '        MachineSheaveDia_cmb.Items.Clear()
    '        For jIndx As Integer = 0 To aMachineSheaveDiameter.GetUpperBound(0)
    '            If Not IsNothing(aMachineSheaveDiameter(jIndx).MachineSheaveDia) Then
    '                If FindString(MachineSheaveDia_cmb, aMachineSheaveDiameter(jIndx).MachineSheaveDia) = -1 Then
    '                    MachineSheaveDia_cmb.Items.Add(aMachineSheaveDiameter(jIndx).MachineSheaveDia)
    '                End If
    '            End If
    '        Next jIndx

    '        RopingNew_cmb.Items.Clear()
    '        RopingNew_cmb.Items.Add("1:1")
    '        RopingNew_cmb.Items.Add("2:1")

    '        Wrap_cmb.Items.Clear()
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '            Wrap_cmb.Items.Add("Single Wrap")
    '        Else
    '            Wrap_cmb.Items.Add("Single Wrap")
    '            Wrap_cmb.Items.Add("Double Wrap")
    '        End If

    '        CompensationType_cmb.Items.Clear()
    '        CompensationType_cmb.Items.Add("Cable")
    '        If ME_PIT01Car_typ.Compensation <> "New" And ME_PIT01Car_typ.Compensation <> "Replace" Then
    '            CompensationType_cmb.Items.Add("Chain")
    '        End If
    '        CompensationType_cmb.Items.Add("Whisperflex")

    '        CompensationSize_cmb.Items.Clear()
    '        If Not String.IsNullOrEmpty(ME_PIT01Car_typ.CompensationType) Then
    '            If ME_PIT01Car_typ.Compensation = "Reuse" Or ME_PIT01Car_typ.Compensation = "Relocate" Then
    '                CompensationSize_cmb.Items.Add("Unknown")
    '            End If
    '        End If

    '        CompensationQty_cmb.Items.Clear()
    '        If GONumbers(CurrentGOSelection).MachineType = HYDRO_TYPE Then
    '            CompensationQty_cmb.Items.Add(CStr(0))
    '        End If
    '        If ME_PIT01Car_typ.Compensation <> "None" And Not String.IsNullOrEmpty(ME_PIT01Car_typ.CompensationType) Then
    '            sSQL = "SELECT CompensationType.CompName, Compensation.CompSize1, Compensation.CompSize2 " & "FROM CompensationType " & _
    '                   "INNER JOIN Compensation ON CompensationType.CompType = Compensation.CompType " & _
    '                   "WHERE CompensationType.CompName='" & (IIf(ME_PIT01Car_typ.CompensationType = "Cable", "Rope", ME_PIT01Car_typ.CompensationType)) & "' " & _
    '                   "ORDER BY Compensation.CompSize, Compensation.CompSize1;"
    '            WorkingRecordSet = New ADODB.Recordset
    '            WorkingRecordSet.Open(sSQL, ADOConnection)
    '            Do While Not WorkingRecordSet.EOF
    '                Dim UseResult As Integer = CompensationSize_cmb.Items.Add(WorkingRecordSet("CompSize1").Value)
    '                CompensationSize_cmb.SetItemData(UseResult, Math.Floor(WorkingRecordSet("CompSize2").Value * 1000))
    '                WorkingRecordSet.MoveNext()
    '            Loop
    '            WorkingRecordSet.Close()
    '            WorkingRecordSet = Nothing
    '            If ME_PIT01Car_typ.Compensation <> "None" Then
    '                For i = 1 To 8
    '                    CompensationQty_cmb.Items.Add(Conversion.Str(i).Trim())
    '                Next i
    '            End If
    '        End If

    '        CarSheaveDiameter_cmb.Items.Clear()
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 20 Then
    '            CarSheaveDiameter_cmb.Items.Add("20")
    '        End If
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 25 Then
    '            CarSheaveDiameter_cmb.Items.Add("25")
    '        End If
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 26 Then
    '            CarSheaveDiameter_cmb.Items.Add("26")
    '        End If
    '        CarSheaveDiameter_cmb.Items.Add("30")

    '        CarSheaveQty_Cmb.Items.Clear()
    '        If GONumbers(CurrentGOSelection).MachineType = HYDRO_TYPE Or ME_CAR01Car_typ.TopOfCarSheave = "None" Then
    '            CarSheaveQty_Cmb.Items.Add(CStr(0))
    '        End If
    '        CarSheaveQty_Cmb.Items.Add("1")
    '        CarSheaveQty_Cmb.Items.Add("2")

    '        HWCwtSheaveDia_Cmb.Items.Clear()
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 20 Then
    '            HWCwtSheaveDia_Cmb.Items.Add("20")
    '        End If
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 25 Then
    '            HWCwtSheaveDia_Cmb.Items.Add("25")
    '        End If
    '        If 40 * Conversion.Val(TranslateRopeSize(ME_MRM01Car_typ.HoistCableSize, True)) <= 26 Then
    '            HWCwtSheaveDia_Cmb.Items.Add("26")
    '        End If
    '        HWCwtSheaveDia_Cmb.Items.Add("30")

    '        CableRecordSet.MoveFirst()
    '        MainTravelingCable_cmb.Items.Clear()
    '        Do While Not CableRecordSet.EOF
    '            If CableRecordSet("Use").Value = 1 Then
    '                MainTravelingCable_cmb.Items.Add(CableRecordSet("CableType").Value)
    '            End If
    '            CableRecordSet.MoveNext()
    '        Loop

    '        Qty1_cmb.Items.Clear()
    '        For i = 0 To 6
    '            Qty1_cmb.Items.Add(CStr(i))
    '        Next i

    '        AdditionalCoaxCableQty_cmb.Clear()
    '        AdditionalCoaxCableQty_cmb.Items.Add("0")
    '        AdditionalCoaxCableQty_cmb.Items.Add("2")

    '        AdditionalShieldPairsQty_cmb.Clear()
    '        Select Case MN_TRQ01_typ.AdditionalCoaxCableQty
    '            Case "0"
    '                AdditionalShieldPairsQty_cmb.Items.Add("4")
    '                AdditionalShieldPairsQty_cmb.Items.Add("6")
    '                AdditionalShieldPairsQty_cmb.Items.Add("8")
    '            Case "2"
    '                AdditionalShieldPairsQty_cmb.Items.Add("4")
    '                AdditionalShieldPairsQty_cmb.Items.Add("6")
    '            Case Else
    '        End Select

    '        LoadWeighType_cmb.Items.Clear()
    '        If ME_MRM01Car_typ.Controller = "New" Or ME_MRM01Car_typ.Controller = "Replace" Then
    '            If ME_MRM01Car_typ.ControllerVendor = SEC Then
    '                If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                    LoadWeighType_cmb.Items.Add(EZLMS)
    '                End If
    '                LoadWeighType_cmb.Items.Add(DUAL_EZLMS)
    '                LoadWeighType_cmb.Items.Add(LVDT)
    '            Else
    '                If All_LocalCodeDep.CanadaJob Then
    '                    LoadWeighType_cmb.Items.Add(MICELECT)
    '                Else
    '                    LoadWeighType_cmb.Items.Add(MICROSWITCH)
    '                End If
    '            End If
    '        Else
    '            LoadWeighType_cmb.Items.Add(EZLMS)
    '            LoadWeighType_cmb.Items.Add(DUAL_EZLMS)
    '            LoadWeighType_cmb.Items.Add(LVDT)
    '            If All_LocalCodeDep.CanadaJob Then
    '                LoadWeighType_cmb.Items.Add(MICELECT)
    '            Else
    '                LoadWeighType_cmb.Items.Add(MICROSWITCH)
    '            End If
    '        End If

    '        CarGovernorNewModel_cmb.Items.Clear()
    '        If ME_COM01Car_typ.Speed > 800 Then
    '            CarGovernorNewModel_cmb.Items.Add("GB 32")
    '            CarGovernorNewModel_cmb.Items.Add("GB 42")
    '        Else
    '            CarGovernorNewModel_cmb.Items.Add("HW202")
    '            CarGovernorNewModel_cmb.Items.Add("HW207")
    '            CarGovernorNewModel_cmb.Items.Add("HW210")
    '        End If

    '        CarGovernorFastening_cmb.Items.Clear()
    '        CarGovernorFastening_cmb.Items.Add("Floor")
    '        CarGovernorFastening_cmb.Items.Add("Steel")

    '        CwtGovernorNewModel_cmb.Items.Clear()
    '        If ME_COM01Car_typ.Speed > 800 Then
    '            CwtGovernorNewModel_cmb.Items.Add("GB 32")
    '            CwtGovernorNewModel_cmb.Items.Add("GB 42")
    '        Else
    '            CwtGovernorNewModel_cmb.Items.Add("HW202")
    '            CwtGovernorNewModel_cmb.Items.Add("HW207")
    '            CwtGovernorNewModel_cmb.Items.Add("HW210")
    '        End If

    '        CwtGovernorFastening_cmb.Items.Clear()
    '        CwtGovernorFastening_cmb.Items.Add("Floor")
    '        CwtGovernorFastening_cmb.Items.Add("Steel")

    '        RopeGripperModel_cmb.Items.Clear()
    '        RopeGripperModel_cmb.Items.Add("HW620")
    '        RopeGripperModel_cmb.Items.Add("HW622")
    '        RopeGripperModel_cmb.Items.Add("HW624")
    '        RopeGripperModel_cmb.Items.Add("HW625")
    '        RopeGripperModel_cmb.Items.Add("HW626")
    '        RopeGripperModel_cmb.Items.Add("SB200")
    '        RopeGripperModel_cmb.Items.Add("SB330")
    '        RopeGripperModel_cmb.Items.Add("SB331")
    '        RopeGripperModel_cmb.Items.Add("SB380")

    '        RopeGripper_cmb.Items.Clear()
    '        If ME_MRM01Car_typ.RopeGripper = "Included" Then
    '            RopeGripper_cmb.Items.Add("Included")
    '        Else
    '            RopeGripper_cmb.Items.Add("Reuse")
    '            RopeGripper_cmb.Items.Add("None")
    '            RopeGripper_cmb.Items.Add("Replace")
    '            RopeGripper_cmb.Items.Add("New")
    '            RopeGripper_cmb.Items.Add("Refurbish")
    '        End If

    '        RopeGripperMount_cmb.Items.Clear()
    '        RopeGripperMount_cmb.Items.Add("Overhead")
    '        RopeGripperMount_cmb.Items.Add("Machine Room")
    '        RopeGripperMount_cmb.Items.Add("Custom")
    '        If ME_MRM01Car_typ.RopeGripperMount = "None" Then
    '            RopeGripperMount_cmb.Items.Add("None")
    '        End If

    '        RopeSplayKitMounting_cmb.Items.Clear()
    '        RopeSplayKitMounting_cmb.Items.Add("Overhead")
    '        RopeSplayKitMounting_cmb.Items.Add("Machine Beam")
    '        RopeSplayKitMounting_cmb.Items.Add("Machine Room Slab")

    '        QtyStarRepeater_cmb.Items.Clear()
    '        For i = 0 To 5
    '            QtyStarRepeater_cmb.Items.Add(i)
    '        Next i

    '    End Sub
    '    Private Sub Set_Fields_Grey()
    '        Dim bOverhead As Boolean

    '        MachineVendorExisting_lbl.Enabled = False
    '        MachineVendorExisting_Cmb.Enabled = False
    '        MachineModelExisting_lbl.Enabled = False
    '        MachineModelExisting_cmb.Enabled = False
    '        If ME_MRM01Car_typ.Machine = "New" Or ME_MRM01Car_typ.Machine = "Replace" Then
    '            ManufacturerNew_cmb.Enabled = True
    '            ManufacturerNew_lbl.Enabled = True
    '        Else
    '            ManufacturerNew_cmb.Enabled = False
    '            ManufacturerNew_lbl.Enabled = False
    '        End If
    '        If ME_MRM01Car_typ.Machine = "New" Or ME_MRM01Car_typ.Machine = "Replace" Then
    '            MachineTypeNew_cmb.Enabled = True
    '            MachineTypeNew_lbl.Enabled = True
    '        Else
    '            MachineTypeNew_cmb.Enabled = False
    '            MachineTypeNew_lbl.Enabled = False
    '        End If
    '        If Dependents.MachineSheaveDiaTorque = SET_TO_GREY Then
    '            MachineSheaveDia_cmb.Enabled = False
    '            MachineSheaveDia_lbl.Enabled = False
    '        Else
    '            MachineSheaveDia_cmb.Enabled = True
    '            MachineSheaveDia_lbl.Enabled = True
    '        End If
    '        SetColor_MachineSheaveDia_cmb()
    '        Speed_cmb.Enabled = True
    '        Speed_lbl.Enabled = True
    '        SetColor_Speed_cmb()
    '        If Dependents.MotorRPM = SET_TO_GREY Then
    '            MotorRPM_cmb.Enabled = False
    '            MotorRPM_lbl.Enabled = False
    '        Else
    '            MotorRPM_cmb.Enabled = True
    '            MotorRPM_cmb.Enabled = True
    '        End If
    '        MachineRoomLocation_cmb.Enabled = True
    '        MachineRoomLocation_lbl.Enabled = True
    '        If Dependents.GuidesCarType = SET_TO_GREY Then
    '            ShoeType_cmb.Enabled = False
    '            ShoeType_lbl.Enabled = False
    '        Else
    '            ShoeType_cmb.Enabled = True
    '            ShoeType_lbl.Enabled = True
    '        End If
    '        If Dependents.DriveType = SET_TO_GREY Then
    '            DriveType_cmb.Enabled = False
    '            DriveType_lbl.Enabled = False
    '        Else
    '            DriveType_cmb.Enabled = True
    '            DriveType_lbl.Enabled = True
    '        End If
    '        Capacity_cmb.Enabled = True
    '        Capacity_lbl.Enabled = True
    '        SetColor_Capacity_cmb()
    '        TravelFt_txt.Enabled = True
    '        TravelFt_lbl.Enabled = True
    '        TravelIn_txt.Enabled = True
    '        TravelIn_lbl.Enabled = True
    '        If Conversion.Val(CStr(ME_COM01Car_typ.TravelFt)) = 0 And ENG_ACCESS Then
    '            TravelFt_txt.BackColor = Color.Yellow
    '        Else
    '            TravelFt_txt.BackColor = Color.White
    '        End If
    '        If Dependents.BrakeType = SET_TO_GREY Then
    '            BrakeType_cmb.Enabled = False
    '            BrakeType_lbl.Enabled = False
    '        Else
    '            BrakeType_cmb.Enabled = True
    '            BrakeType_lbl.Enabled = True
    '        End If
    '        If ME_HstWay02Car_typ.HoistwaySheave = "Replace" Or ME_HstWay02Car_typ.HoistwaySheave = "New" Then
    '            If ME_MRM01Car_typ.MachineLocation <> "Overhead" Then
    '                bOverhead = True
    '            End If
    '        End If
    '        If Dependents.HoistwaySheaveDia = SET_TO_GREY Then
    '            HoistwaySheave_cmb.Enabled = False
    '            HoistwaySheave_lbl.Enabled = False
    '        Else
    '            HoistwaySheave_cmb.Enabled = True
    '            HoistwaySheave_lbl.Enabled = True
    '        End If
    '        SetColor_HoistwaySheave_cmb()
    '        If Dependents.Performance = SET_TO_GREY Then
    '            Performance_cmb.Enabled = False
    '            Performance_lbl.Enabled = False
    '        Else
    '            Performance_cmb.Enabled = True
    '            Performance_lbl.Enabled = True
    '        End If
    '        If Dependents.CarWeight = SET_TO_GREY Then
    '            CarWeight_lbl.Enabled = False
    '            CarWeight_txt.Enabled = False
    '        Else
    '            CarWeight_lbl.Enabled = True
    '            CarWeight_txt.Enabled = True
    '        End If
    '        If Dependents.RopingNew_TRQ = SET_TO_GREY Then
    '            RopingNew_cmb.Enabled = False
    '            RopingNew_lbl.Enabled = False
    '        Else
    '            RopingNew_cmb.Enabled = True
    '            RopingNew_lbl.Enabled = True
    '        End If
    '        If ENG_ACCESS Then
    '            ExistingRopes_lbl.Enabled = True
    '            NumberOfRopes_cmb.Enabled = True
    '            NumberOfRopes_lbl.Enabled = True
    '            RopeSize_cmb.Enabled = True
    '            RopeSize_lbl.Enabled = True
    '            If FindString(NumberOfRopes_cmb, CStr(ME_MRM01Car_typ.HoistCableQty)) = -1 Then
    '                NumberOfRopes_cmb.BackColor = Color.Red
    '            Else
    '                NumberOfRopes_cmb.BackColor = Color.White
    '            End If
    '            If RopeSize_cmb.Text = "" And ENG_ACCESS Then
    '                RopeSize_cmb.BackColor = Color.Yellow
    '            Else
    '                If ValidateRopeSize(TranslateRopeSize(RopeSize_cmb.Text, True)) Then
    '                    If FindString(RopeSize_cmb, RopeSize_cmb.Text) = -1 Then
    '                        RopeSize_cmb.BackColor = Color.Red
    '                    Else
    '                        RopeSize_cmb.BackColor = Color.White
    '                    End If
    '                Else
    '                    RopeSize_cmb.BackColor = Color.Red
    '                End If
    '            End If
    '        End If
    '        If Dependents.Wrap = SET_TO_GREY Then
    '            Wrap_cmb.Enabled = False
    '            Wrap_lbl.Enabled = False
    '        Else
    '            Wrap_cmb.Enabled = True
    '            Wrap_lbl.Enabled = True
    '        End If
    '        BuildingVoltage_cmb.Enabled = True
    '        BuildingVoltage_lbl.Enabled = True
    '        If ME_COM01Car_typ.PowerSupply = 0 And ENG_ACCESS Then
    '            BuildingVoltage_cmb.BackColor = Color.Yellow
    '        Else
    '            BuildingVoltage_cmb.BackColor = Color.White
    '        End If
    '        If Dependents.VFF = SET_TO_GREY Then
    '            VFF_txt.Enabled = False
    '            VFF_lbl.Enabled = False
    '            VFF_txt.BackColor = Color.White
    '        Else
    '            VFF_txt.Enabled = True
    '            VFF_lbl.Enabled = True
    '            If VFF_txt.Text = "" And ENG_ACCESS Then
    '                VFF_txt.BackColor = Color.Yellow
    '            Else
    '                VFF_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If Dependents.IFF = SET_TO_GREY Then
    '            Iff_txt.Enabled = False
    '            Iff_lbl.Enabled = False
    '            Iff_txt.BackColor = Color.White
    '        Else
    '            Iff_txt.Enabled = True
    '            Iff_lbl.Enabled = True
    '            If Iff_txt.Text = "" And ENG_ACCESS Then
    '                Iff_txt.BackColor = Color.Yellow
    '            Else
    '                Iff_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If Dependents.VFan = SET_TO_GREY Then
    '            Vfan_txt.Enabled = False
    '            Vfan_lbl.Enabled = False
    '        Else
    '            Vfan_txt.Enabled = True
    '            Vfan_lbl.Enabled = True
    '        End If
    '        If Dependents.IFan = SET_TO_GREY Then
    '            Ifan_txt.Enabled = False
    '            Ifan_lbl.Enabled = False
    '        Else
    '            Ifan_txt.Enabled = True
    '            Ifan_lbl.Enabled = True
    '        End If
    '        If Dependents.NamePlateArmatureFullLoadVoltage = SET_TO_GREY Then
    '            NamePlateArmatureFullLoadVoltage_txt.Enabled = False
    '            NamePlateArmatureFullLoadVoltage_lbl.Enabled = False
    '            NamePlateArmatureFullLoadVoltage_txt.BackColor = Color.White
    '        Else
    '            NamePlateArmatureFullLoadVoltage_txt.Enabled = True
    '            NamePlateArmatureFullLoadVoltage_lbl.Enabled = True
    '            If NamePlateArmatureFullLoadVoltage_txt.Text = "" And ENG_ACCESS Then
    '                NamePlateArmatureFullLoadVoltage_txt.BackColor = Color.Yellow
    '            Else
    '                NamePlateArmatureFullLoadVoltage_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If Dependents.NamePlateArmatureFullLoadCurrent = SET_TO_GREY Then
    '            NamePlateArmatureFullLoadCurrent_txt.Enabled = False
    '            NamePlateArmatureFullLoadCurrent_lbl.Enabled = False
    '            NamePlateArmatureFullLoadCurrent_txt.BackColor = Color.White
    '        Else
    '            NamePlateArmatureFullLoadCurrent_txt.Enabled = True
    '            NamePlateArmatureFullLoadCurrent_lbl.Enabled = True
    '            If NamePlateArmatureFullLoadCurrent_txt.Text = "" And ENG_ACCESS Then
    '                NamePlateArmatureFullLoadCurrent_txt.BackColor = Color.Yellow
    '            Else
    '                NamePlateArmatureFullLoadCurrent_txt.BackColor = Color.White
    '            End If
    '        End If
    '        If Dependents.VFF = SET_TO_GREY And Dependents.IFF = SET_TO_GREY And Dependents.NamePlateArmatureFullLoadVoltage = SET_TO_GREY And
    '           Dependents.NamePlateArmatureFullLoadCurrent = SET_TO_GREY Then
    '            ResetElectricalDataToDefault_cmd.Enabled = False
    '        Else
    '            ResetElectricalDataToDefault_cmd.Enabled = True
    '        End If

    '        If Dependents.CableChainSize = SET_TO_INVISIBLE Then
    '            CompensationSize_cmb.Visible = False
    '            CompensationSize_lbl.Visible = False
    '        ElseIf Dependents.CableChainSize = SET_TO_GREY Then
    '            CompensationSize_cmb.Visible = True
    '            CompensationSize_lbl.Visible = True
    '            CompensationSize_cmb.Enabled = False
    '            CompensationSize_lbl.Enabled = False
    '        Else
    '            CompensationSize_cmb.Visible = True
    '            CompensationSize_lbl.Visible = True
    '            CompensationSize_cmb.Enabled = True
    '            CompensationSize_lbl.Enabled = True
    '        End If
    '        If Dependents.CompensationType = SET_TO_INVISIBLE Then
    '            CompensationType_cmb.Visible = False
    '            CompensationType_lbl.Visible = False
    '        ElseIf Dependents.CompensationType = SET_TO_GREY Then
    '            CompensationType_cmb.Visible = True
    '            CompensationType_lbl.Visible = True
    '            CompensationType_cmb.Enabled = False
    '            CompensationType_lbl.Enabled = False
    '        Else
    '            CompensationType_cmb.Visible = True
    '            CompensationType_lbl.Visible = True
    '            CompensationType_cmb.Enabled = True
    '            CompensationType_lbl.Enabled = True
    '        End If
    '        If Dependents.CableChainQty = SET_TO_INVISIBLE Then
    '            CompensationQty_cmb.Visible = False
    '            CompensationQty_lbl.Visible = False
    '        ElseIf Dependents.CableChainQty = SET_TO_GREY Then
    '            CompensationQty_cmb.Visible = True
    '            CompensationQty_lbl.Visible = True
    '            CompensationQty_cmb.Enabled = False
    '            CompensationQty_lbl.Enabled = False
    '        Else
    '            CompensationQty_cmb.Visible = True
    '            CompensationQty_lbl.Visible = True
    '            CompensationQty_cmb.Enabled = True
    '            CompensationQty_lbl.Enabled = True
    '        End If
    '        If Dependents.SheaveDiameter = SET_TO_INVISIBLE Then
    '            CompSheaveDiameter_txt.Visible = False
    '            CompSheaveDiameter_lbl.Visible = False
    '        ElseIf Dependents.SheaveDiameter = SET_TO_GREY Then
    '            CompSheaveDiameter_txt.Visible = True
    '            CompSheaveDiameter_lbl.Visible = True
    '            CompSheaveDiameter_txt.Enabled = False
    '            CompSheaveDiameter_lbl.Enabled = False
    '        Else
    '            CompSheaveDiameter_txt.Visible = True
    '            CompSheaveDiameter_lbl.Visible = True
    '            CompSheaveDiameter_txt.Enabled = True
    '            CompSheaveDiameter_lbl.Enabled = True
    '        End If
    '        Compensation_fra.Enabled = Not (Dependents.CableChainSize = SET_TO_GREY And Dependents.CompensationType = SET_TO_GREY And Dependents.CableChainQty = SET_TO_GREY And Dependents.SheaveDiameter = SET_TO_GREY)
    '        If Dependents.CarSheaveDiameter = SET_TO_INVISIBLE Then
    '            CarSheaveDiameter_cmb.Visible = False
    '            CarSheaveDiameter_lbl.Visible = False
    '        ElseIf Dependents.CarSheaveDiameter = SET_TO_GREY Then
    '            CarSheaveDiameter_cmb.Visible = True
    '            CarSheaveDiameter_lbl.Visible = True
    '            CarSheaveDiameter_cmb.Enabled = False
    '            CarSheaveDiameter_lbl.Enabled = False
    '        Else
    '            CarSheaveDiameter_cmb.Visible = True
    '            CarSheaveDiameter_lbl.Visible = True
    '            CarSheaveDiameter_cmb.Enabled = True
    '            CarSheaveDiameter_lbl.Enabled = True
    '        End If
    '        If Dependents.CarSheaveQty = SET_TO_INVISIBLE Then
    '            CarSheaveQty_Cmb.Visible = False
    '            CarSheaveQty_lbl.Visible = False
    '        ElseIf Dependents.CarSheaveQty = SET_TO_GREY Then
    '            CarSheaveQty_Cmb.Visible = True
    '            CarSheaveQty_lbl.Visible = True
    '            CarSheaveQty_Cmb.Enabled = False
    '            CarSheaveQty_lbl.Enabled = False
    '        Else
    '            CarSheaveQty_Cmb.Visible = True
    '            CarSheaveQty_lbl.Visible = True
    '            CarSheaveQty_Cmb.Enabled = True
    '            CarSheaveQty_lbl.Enabled = True
    '        End If
    '        If Dependents.HWCwtSheaveDia = SET_TO_INVISIBLE Then
    '            HWCwtSheaveDia_Cmb.Visible = False
    '            HWCwtSheaveDia_lbl.Visible = False
    '        ElseIf Dependents.HWCwtSheaveDia = SET_TO_GREY Then
    '            HWCwtSheaveDia_Cmb.Visible = True
    '            HWCwtSheaveDia_lbl.Visible = True
    '            HWCwtSheaveDia_Cmb.Enabled = False
    '            HWCwtSheaveDia_lbl.Enabled = False
    '        Else
    '            HWCwtSheaveDia_Cmb.Visible = True
    '            HWCwtSheaveDia_lbl.Visible = True
    '            HWCwtSheaveDia_Cmb.Enabled = True
    '            HWCwtSheaveDia_lbl.Enabled = True
    '        End If
    '        If Dependents.CarSheaveDiameter = SET_TO_ACTIVE Or Dependents.CarSheaveQty = SET_TO_ACTIVE Or Dependents.HWCwtSheaveDia = SET_TO_ACTIVE Or _
    '           ME_MRM01Car_typ.MachineModelNew = MACHINE_FMM200 Then
    '            Only2To1Roping_fra.Enabled = True
    '        Else
    '            Only2To1Roping_fra.Enabled = False
    '        End If
    '        If Not ENG_ACCESS Then
    '            For i As Integer = 0 To Me.Controls.Count - 1
    '                Me.Controls(i).Enabled = False
    '            Next i
    '        End If
    '        If Dependents.LoadWeighType = SET_TO_INVISIBLE Then
    '            LoadWeighType_cmb.Visible = False
    '            LoadWeighType_lbl.Visible = False
    '        ElseIf Dependents.LoadWeighType = SET_TO_GREY Then
    '            LoadWeighType_cmb.Visible = True
    '            LoadWeighType_lbl.Visible = True
    '            LoadWeighType_cmb.Enabled = False
    '            LoadWeighType_lbl.Enabled = False
    '        Else
    '            LoadWeighType_cmb.Visible = True
    '            LoadWeighType_lbl.Visible = True
    '            LoadWeighType_cmb.Enabled = True
    '            LoadWeighType_lbl.Enabled = True
    '        End If
    '        If GONumbers(CurrentGOSelection).MachineType = HYDRO_TYPE Then
    '            RopeGripper_fra.Visible = False
    '        ElseIf (ME_MRM01Car_typ.RopeGripper = "Included" And Dependents.RopeGripperMount_ENG = SET_TO_GREY) Or Not ENG_ACCESS Then
    '            RopeGripper_fra.Visible = True
    '            RopeGripper_fra.Enabled = False
    '        Else
    '            RopeGripper_fra.Visible = True
    '            RopeGripper_fra.Enabled = True
    '            If ME_MRM01Car_typ.RopeGripper = "None" Then
    '                RopeGripperModel_lbl.Enabled = False
    '                RopeGripperModel_cmb.Enabled = False
    '                RopeGripperModelDetails_cmd.Enabled = False
    '            Else
    '                RopeGripperModel_lbl.Enabled = True
    '                RopeGripperModel_cmb.Enabled = True
    '                Select Case MN_TRQ01_typ.RopeGripperModel
    '                    Case "SB200", "SB330", "SB331", "SB380"
    '                        RopeGripperModelDetails_cmd.Enabled = False
    '                    Case Else
    '                        RopeGripperModelDetails_cmd.Enabled = True
    '                End Select
    '            End If
    '            If ME_MRM01Car_typ.RopeGripper = "Included" Then
    '                RopeGripper_lbl.Enabled = False
    '                RopeGripper_cmb.Enabled = False
    '            Else
    '                RopeGripper_lbl.Enabled = True
    '                RopeGripper_cmb.Enabled = True
    '            End If
    '            If Dependents.RopeGripperMount_ENG = SET_TO_INVISIBLE Then
    '                RopeGripperMount_lbl.Visible = False
    '                RopeGripperMount_cmb.Visible = False
    '                RopeGripperMount_lbl.Enabled = False
    '                RopeGripperMount_cmb.Enabled = False
    '            ElseIf Dependents.RopeGripperMount_ENG = SET_TO_GREY Then
    '                RopeGripperMount_lbl.Visible = True
    '                RopeGripperMount_cmb.Visible = True
    '                RopeGripperMount_lbl.Enabled = False
    '                RopeGripperMount_cmb.Enabled = False
    '            Else
    '                RopeGripperMount_lbl.Visible = True
    '                RopeGripperMount_cmb.Visible = True
    '                RopeGripperMount_lbl.Enabled = True
    '                RopeGripperMount_cmb.Enabled = True
    '            End If
    '            MountingToOuterMBflanges_chk.Enabled = Not (Dependents.MountingToOuterMBflanges = SET_TO_GREY)
    '        End If
    '        If Dependents.CarGovernorNewModel = SET_TO_GREY Then
    '            CarGovernorNewModel_cmb.Enabled = False
    '            CarGovernorNewModel_lbl.Enabled = False
    '        Else
    '            CarGovernorNewModel_cmb.Enabled = True
    '            CarGovernorNewModel_lbl.Enabled = True
    '        End If
    '        If Dependents.CwtGovernorNewModel = SET_TO_GREY Then
    '            CwtGovernorNewModel_cmb.Enabled = False
    '            CwtGovernorNewModel_lbl.Enabled = False
    '        Else
    '            CwtGovernorNewModel_cmb.Enabled = True
    '            CwtGovernorNewModel_lbl.Enabled = True
    '        End If
    '        If Dependents.CarGovernorNewModel = SET_TO_GREY And Dependents.CwtGovernorNewModel = SET_TO_GREY Then
    '            Governor_fra.Enabled = False
    '        Else
    '            Governor_fra.Enabled = True
    '        End If
    '        If Dependents.RopeSplayKitMounting = SET_TO_GREY Then
    '            RopeSplayKitMounting_cmb.Enabled = False
    '            RopeSplayKitMounting_lbl.Enabled = False
    '        Else
    '            RopeSplayKitMounting_cmb.Enabled = True
    '            RopeSplayKitMounting_lbl.Enabled = True
    '        End If
    '        If Dependents.CarGovernorFastening = SET_TO_GREY Then
    '            CarGovernorFastening_cmb.Enabled = False
    '            CarGovernorFastening_lbl.Enabled = False
    '        Else
    '            CarGovernorFastening_cmb.Enabled = True
    '            CarGovernorFastening_lbl.Enabled = True
    '        End If
    '        If Dependents.CwtGovernorFastening = SET_TO_GREY Then
    '            CwtGovernorFastening_cmb.Enabled = False
    '            CwtGovernorFastening_lbl.Enabled = False
    '        Else
    '            CwtGovernorFastening_cmb.Enabled = True
    '            CwtGovernorFastening_lbl.Enabled = True
    '        End If
    '        If Dependents.QtyStarRepeater = SET_TO_GREY Then
    '            LobbyVision_fra.Enabled = False
    '            QtyStarRepeater_lbl.Enabled = False
    '            QtyStarRepeater_cmb.Enabled = False
    '        Else
    '            LobbyVision_fra.Enabled = True
    '            QtyStarRepeater_lbl.Enabled = True
    '            QtyStarRepeater_cmb.Enabled = True
    '        End If
    '        If Dependents.AdditionalCoaxCableQty = SET_TO_INVISIBLE Then
    '            AdditionalCoaxCableQty_cmb.Enabled = False
    '            AdditionalCoaxCableQty_lbl.Enabled = False
    '            AdditionalCoaxCableQty_cmb.Visible = False
    '            AdditionalCoaxCableQty_lbl.Visible = False
    '        ElseIf Dependents.AdditionalCoaxCableQty = SET_TO_GREY Then
    '            AdditionalCoaxCableQty_cmb.Enabled = False
    '            AdditionalCoaxCableQty_lbl.Enabled = False
    '        Else
    '            AdditionalCoaxCableQty_cmb.Enabled = True
    '            AdditionalCoaxCableQty_lbl.Enabled = True
    '        End If

    '        If Dependents.AdditionalShieldPairsQty = SET_TO_INVISIBLE Then
    '            AdditionalShieldPairsQty_cmb.Enabled = False
    '            AdditionalShieldPairsQty_lbl.Enabled = False
    '            AdditionalShieldPairsQty_cmb.Visible = False
    '            AdditionalShieldPairsQty_lbl.Visible = False
    '        ElseIf Dependents.AdditionalShieldPairsQty = SET_TO_GREY Then
    '            AdditionalShieldPairsQty_cmb.Enabled = False
    '            AdditionalShieldPairsQty_lbl.Enabled = False
    '        Else
    '            AdditionalShieldPairsQty_cmb.Enabled = True
    '            AdditionalShieldPairsQty_lbl.Enabled = True
    '        End If

    '    End Sub
    '    Private Sub Vfan_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Vfan_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub VFF_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles VFF_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub VFLU_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles NamePlateArmatureFullLoadVoltage_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub IDC1_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles NamePlateArmatureFullLoadCurrent_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub Ifan_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Ifan_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub Iff_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles Iff_txt.KeyPress
    '        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

    '        ModifyKeyAscii(KeyAscii, CStr(NUMBERS_ONLY))
    '        If KeyAscii = 0 Then
    '            eventArgs.Handled = True
    '        End If
    '        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    '    End Sub
    '    Private Sub CarWeight_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarWeight_txt.Enter
    '        SelectInputArea(CarWeight_txt, 0, Strings.Len(CarWeight_txt.Text))
    '    End Sub
    '    Private Sub CarWeight_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarWeight_txt.Leave

    '        If ME_CAR01Car_typ.CarWeight <> CarWeight_txt.Text Then
    '            If ValidateTextBoxInput_Text(Me, CarWeight_txt, ENTRY_NOT_A_NUMBER, True) = ENTRY_VALID Then
    '                If ConfirmAmendment(CarWeight_txt, CarWeight_lbl, ME_CAR01Car_typ.CarWeight, True) Then
    '                    MDIChildDirty = True
    '                    MN_TRQ01_typ.bDirty = True
    '                    Fields2Type()
    '                    Dependents.MOD_Parent()
    '                    Load_ListBoxes()
    '                    Type2Fields()
    '                    Set_Fields_Grey()
    '                    Main_MDI_frm.ProcessChildMessage()
    '                Else
    '                    CarWeight_txt.Text = ME_CAR01Car_typ.CarWeight
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarSheaveDiameter_cmb_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveDiameter_cmb.Enter
    '        SelectInputArea(CarSheaveDiameter_cmb, 0, Strings.Len(CarSheaveDiameter_cmb.Text))
    '    End Sub
    '    Private Sub CarSheaveDiameter_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CarSheaveDiameter_cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub CarSheaveDiameter_cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveDiameter_cmb.Leave

    '        If ValidateTextBoxInput_Text(Me, CarSheaveDiameter_cmb, ENTRY_NOT_AN_INTEGER, True) <> ENTRY_VALID Then
    '            Exit Sub
    '        End If
    '        If CarSheaveDiameter_cmb.Text <> ME_CAR01Car_typ.CarSheaveDiameter Then
    '            If ConfirmAmendment(CarSheaveDiameter_cmb, CarSheaveDiameter_lbl, ME_CAR01Car_typ.CarSheaveDiameter) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                CarSheaveDiameter_cmb.Text = ME_CAR01Car_typ.CarSheaveDiameter
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarSheaveQty_Cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveQty_Cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If (CarSheaveQty_Cmb.Text) <> ME_CAR01Car_typ.CarSheaveQty Then
    '            If ConfirmAmendment(CarSheaveQty_Cmb, CarSheaveQty_lbl, CStr(ME_CAR01Car_typ.CarSheaveQty)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                CarSheaveQty_Cmb.Text = CStr(ME_CAR01Car_typ.CarSheaveQty)
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarSheaveQty_Cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarSheaveQty_Cmb.SelectedIndexChanged

    '        If (CarSheaveQty_Cmb.Text) <> ME_CAR01Car_typ.CarSheaveQty Then
    '            If ConfirmAmendment(CarSheaveQty_Cmb, CarSheaveQty_lbl, CStr(ME_CAR01Car_typ.CarSheaveQty)) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                CarSheaveQty_Cmb.Text = CStr(ME_CAR01Car_typ.CarSheaveQty)
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarSheaveQty_Cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CarSheaveQty_Cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub HWCwtSheaveDia_Cmb_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles HWCwtSheaveDia_Cmb.Enter
    '        SelectInputArea(HWCwtSheaveDia_Cmb, 0, Strings.Len(HWCwtSheaveDia_Cmb.Text))
    '    End Sub
    '    Private Sub HWCwtSheaveDia_Cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles HWCwtSheaveDia_Cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub HWCwtSheaveDia_Cmb_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles HWCwtSheaveDia_Cmb.Leave

    '        If ValidateTextBoxInput_Text(Me, HWCwtSheaveDia_Cmb, ENTRY_NOT_AN_INTEGER, True) <> ENTRY_VALID Then
    '            Exit Sub
    '        End If
    '        If HWCwtSheaveDia_Cmb.Text <> ME_HstWay02Car_typ.HWCwtSheaveDia Then
    '            If ConfirmAmendment(HWCwtSheaveDia_Cmb, HWCwtSheaveDia_lbl, ME_HstWay02Car_typ.HWCwtSheaveDia) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_CAR01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                HWCwtSheaveDia_Cmb.Text = ME_HstWay02Car_typ.HWCwtSheaveDia
    '            End If
    '        End If

    '    End Sub
    '    Private Sub SetColor_MachineSheaveDia_cmb()

    '        If Dependents.MachineSheaveDiaTorque = SET_TO_GREY Then
    '            MachineSheaveDia_cmb.BackColor = Color.White
    '        Else
    '            If MachineSheaveDia_cmb.Text = "" And ENG_ACCESS Then
    '                MachineSheaveDia_cmb.BackColor = Color.Yellow
    '            Else
    '                If FindString(MachineSheaveDia_cmb, MachineSheaveDia_cmb.Text) = -1 Then
    '                    MachineSheaveDia_cmb.BackColor = IIf(ME_MRM01Car_typ.MachineModel = "Other", Color.White, Color.Red)
    '                Else
    '                    MachineSheaveDia_cmb.BackColor = Color.White
    '                End If
    '            End If
    '        End If

    '    End Sub
    '    Private Sub SetColor_Speed_cmb()

    '        If FindString(Speed_cmb, Speed_cmb.Text) = -1 Then
    '            Speed_cmb.BackColor = IIf(Speed_cmb.Text = "" And ENG_ACCESS, Color.Yellow, Color.Red)
    '        Else
    '            Speed_cmb.BackColor = Color.White
    '        End If

    '    End Sub
    '    Private Sub SetColor_Capacity_cmb()

    '        If Capacity_cmb.Text = "" And ENG_ACCESS Then
    '            Capacity_cmb.BackColor = Color.Yellow
    '        Else
    '            Capacity_cmb.BackColor = IIf(FindString(Capacity_cmb, Capacity_cmb.Text) = -1, Color.Red, Color.White)
    '        End If

    '    End Sub
    '    Private Sub SetColor_HoistwaySheave_cmb()

    '        If Dependents.HoistwaySheaveDia = SET_TO_GREY Then
    '            HoistwaySheave_cmb.BackColor = Color.White
    '        ElseIf HoistwaySheave_cmb.Text = "None" Or (HoistwaySheave_cmb.Text = "" And ME_HstWay02Car_typ.HoistwaySheave <> "New" And ME_HstWay02Car_typ.HoistwaySheave <> "Replace") Then
    '            HoistwaySheave_cmb.BackColor = Color.White
    '        ElseIf HoistwaySheave_cmb.Text = "" Then
    '            HoistwaySheave_cmb.BackColor = Color.Yellow
    '        Else
    '            HoistwaySheave_cmb.BackColor = IIf(FindString(HoistwaySheave_cmb, HoistwaySheave_cmb.Text) = -1, Color.Red, Color.White)
    '        End If

    '    End Sub
    '    Private Sub MN_TRQ01_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    '    End Sub
    '    Private Function LabelCaption(ByRef ControlName As String) As String

    '        Try
    '            Dim s As String = Strings.Left(ControlName, ControlName.IndexOf("_"))
    '            Return s & "."

    '        Finally

    '        End Try

    '    End Function
    '    Private Sub LoadWeighType_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LoadWeighType_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub LoadWeighType_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadWeighType_cmb.SelectedIndexChanged

    '        If LoadWeighType_cmb.Text <> ME_CAR01Car_typ.LoadWeighType Then
    '            If ConfirmAmendment(LoadWeighType_cmb, LoadWeighType_lbl, ME_CAR01Car_typ.LoadWeighType) Then
    '                If LoadWeighType_cmb.Text = LVDT And ME_MRM01Car_typ.RopesHoist = "Reuse" Then
    '                    MessageBox.Show("Please check shackle type to determine if new ropes need to be replaced.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                isInitializingComponent = True
    '                CheckforNullTypeCombo(LoadWeighType_cmb, ME_CAR01Car_typ.LoadWeighType)
    '                isInitializingComponent = False
    '            End If
    '        End If

    '    End Sub
    '    Private Sub LoadWeighType_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoadWeighType_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If LoadWeighType_cmb.Text <> ME_CAR01Car_typ.LoadWeighType Then
    '            If ConfirmAmendment(LoadWeighType_cmb, LoadWeighType_lbl, ME_CAR01Car_typ.LoadWeighType) Then
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
    '    Private Sub RopeGripperModel_cmb_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles RopeGripperModel_cmb.KeyDown
    '        WhichKeyPressed(EventArgs.KeyCode)
    '        If EventArgs.KeyCode = Keys.Delete Then
    '            RopeGripperModel_cmb.SelectedIndex = -1
    '        End If
    '    End Sub
    '    Private Sub RopeGripperModel_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RopeGripperModel_cmb.SelectedIndexChanged
    '        If RopeGripperModel_cmb.Text <> MN_TRQ01_typ.RopeGripperModel Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Set_Fields_Grey()
    '        End If
    '    End Sub
    '    Private Sub RopeGripperModel_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RopeGripperModel_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If RopeGripperModel_cmb.Text <> MN_TRQ01_typ.RopeGripperModel Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Set_Fields_Grey()
    '        End If

    '    End Sub
    '    Private Sub RopeGripperModelDetails_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopeGripperModelDetails_cmd.Click
    '        RopeGripperDetails_frm.ShowDialog()
    '    End Sub
    '    Private Sub RopeGripper_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopeGripper_cmb.SelectedIndexChanged

    '        If RopeGripper_cmb.Text <> ME_MRM01Car_typ.RopeGripper Then
    '            If ConfirmAmendment(RopeGripper_cmb, RopeGripper_lbl, ME_MRM01Car_typ.RopeGripper) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bLocalChange = 1
    '                bElectricalData = True
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                bLocalChange = 0
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                RopeGripper_cmb.Text = ME_MRM01Car_typ.RopeGripper
    '            End If
    '        End If

    '    End Sub
    '    Private Sub RopeGripperMount_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopeGripperMount_cmb.SelectedIndexChanged

    '        If RopeGripperMount_cmb.Text <> ME_MRM01Car_typ.RopeGripperMount Then
    '            If ConfirmAmendment(RopeGripperMount_cmb, RopeGripperMount_lbl, ME_MRM01Car_typ.RopeGripperMount) Then
    '                StatusData.FormsStatus(ESTIMATE_FORMS, ME_MRM01_MENU_INDEX) = FORM_IS_DIRTY
    '                MDIChildDirty = True
    '                MN_TRQ01_typ.bDirty = True
    '                Fields2Type()
    '                bLocalChange = 1
    '                bElectricalData = True
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                bElectricalData = False
    '                bLocalChange = 0
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                RopeGripperMount_cmb.Text = ME_MRM01Car_typ.RopeGripperMount
    '            End If
    '        End If

    '    End Sub
    '    Private Sub MountingToOuterMBflanges_chk_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MountingToOuterMBflanges_chk.CheckStateChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub MountingToOuterMBflanges_chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MountingToOuterMBflanges_chk.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub ResetElectricalDataToDefault_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetElectricalDataToDefault_cmd.Click
    '        Dim sMsg As String = "By resetting these values to default, it will also change the Gearless Nameplate Data values on" & ME_MRM01_TITLE &
    '                             ". It will also reset all Torque Override values to default." & Strings.Chr(13).ToString() & Strings.Chr(10).ToString() &
    '                             "Do you want to proceed with the change?"

    '        If Conversion.Val(ME_MRM01Car_typ.VFF_Default) = 0 And Conversion.Val(ME_MRM01Car_typ.IFF_Default) = 0 And
    '           Conversion.Val(ME_MRM01Car_typ.VFLU_Default) = 0 And Conversion.Val(ME_MRM01Car_typ.IDC1_Default) = 0 Then
    '            sMsg = "Default values not found for this current configuration.  Values will be reset to zeroes/blanks on this screen as well as on " &
    '                   ME_MRM01_TITLE & ". It will also reset all Torque Override values to default." & Strings.Chr(13).ToString() & Strings.Chr(10).ToString() &
    '                   "Do you want to proceed with the change?"
    '        ElseIf Conversion.Val(ME_MRM01Car_typ.VFF_Default) = 0 Or Conversion.Val(ME_MRM01Car_typ.IFF_Default) = 0 Or
    '                   Conversion.Val(ME_MRM01Car_typ.VFLU_Default) = 0 Or Conversion.Val(ME_MRM01Car_typ.IDC1_Default) = 0 Then
    '            sMsg = "Not all default values were found for this current configuration.  Some values will be reset to zeroes/blanks and others will be reset to a default value " &
    '                   "on this screen as well as on " & ME_MRM01_TITLE & ". It will also reset all Torque Override values to default." & Strings.Chr(13).ToString() &
    '                   Strings.Chr(10).ToString() & "Do you want to proceed with the change?"
    '        End If
    '        If MessageBox.Show(sMsg, "Validation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
    '            FormsArray(ENGINEERING_FORMS, MN_TRQ02_MENU_INDEX).FormIsCompleted = False
    '            StatusData.FormsStatus(ENGINEERING_FORMS, MN_TRQ02_MENU_INDEX) = FORM_IS_CLEAN
    '            MDIChildDirty = True
    '            ME_MRM01Car_typ.VFF = ME_MRM01Car_typ.VFF_Default
    '            ME_MRM01Car_typ.IFF = ME_MRM01Car_typ.IFF_Default
    '            ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage = Math.Round(Conversion.Val(ME_MRM01Car_typ.VFLU_Default), 2)
    '            ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent = Math.Round(Conversion.Val(ME_MRM01Car_typ.IDC1_Default), 2)
    '            Type2Fields()
    '        End If

    '    End Sub
    '    Private Sub CarGovernorNewModel_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarGovernorNewModel_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If CarGovernorNewModel_cmb.Text <> ME_MRM02Car_typ.CarGovernorNewModel Then
    '            If ConfirmAmendment(CarGovernorNewModel_cmb, CarGovernorNewModel_lbl, ME_MRM02Car_typ.CarGovernorNewModel) Then
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
    '    Private Sub CarGovernorNewModel_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CarGovernorNewModel_cmb.SelectedIndexChanged

    '        If CarGovernorNewModel_cmb.Text <> ME_MRM02Car_typ.CarGovernorNewModel Then
    '            If ConfirmAmendment(CarGovernorNewModel_cmb, CarGovernorNewModel_lbl, ME_MRM02Car_typ.CarGovernorNewModel) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                isInitializingComponent = True
    '                CheckforNullTypeCombo(CarGovernorNewModel_cmb, ME_MRM02Car_typ.CarGovernorNewModel)
    '                isInitializingComponent = False
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CarGovernorNewModel_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CarGovernorNewModel_cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub CwtGovernorNewModel_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CwtGovernorNewModel_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If CwtGovernorNewModel_cmb.Text <> ME_MRM02Car_typ.CwtGovernorNewModel Then
    '            If ConfirmAmendment(CwtGovernorNewModel_cmb, CwtGovernorNewModel_lbl, ME_MRM02Car_typ.CwtGovernorNewModel) Then
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
    '    Private Sub CwtGovernorNewModel_cmb_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles CwtGovernorNewModel_cmb.SelectedIndexChanged

    '        If CwtGovernorNewModel_cmb.Text <> ME_MRM02Car_typ.CwtGovernorNewModel Then
    '            If ConfirmAmendment(CwtGovernorNewModel_cmb, CwtGovernorNewModel_lbl, ME_MRM02Car_typ.CwtGovernorNewModel) Then
    '                MDIChildDirty = True
    '                Fields2Type()
    '                Dependents.MOD_Parent()
    '                Load_ListBoxes()
    '                Type2Fields()
    '                Set_Fields_Grey()
    '                Main_MDI_frm.ProcessChildMessage()
    '            Else
    '                isInitializingComponent = True
    '                CheckforNullTypeCombo(CwtGovernorNewModel_cmb, ME_MRM02Car_typ.CwtGovernorNewModel)
    '                isInitializingComponent = False
    '            End If
    '        End If

    '    End Sub
    '    Private Sub CwtGovernorNewModel_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles CwtGovernorNewModel_cmb.KeyDown
    '        WhichKeyPressed(eventArgs.KeyCode)
    '    End Sub
    '    Private Sub RopeSplayKitMounting_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RopeSplayKitMounting_cmb.SelectedIndexChanged, RopeSplayKitMounting_cmb.TextChanged

    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        If RopeSplayKitMounting_cmb.Text <> MN_TRQ01_typ.RopeSplayKitMounting Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Set_Fields_Grey()
    '            Type2Fields()
    '        End If

    '    End Sub
    '    Private Sub CarGovernorFastening_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CarGovernorFastening_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub CarGovernorFastening_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarGovernorFastening_cmb.SelectedIndexChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub CarGovernorFastening_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorFastening_cmb.TextChanged
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub CwtGovernorFastening_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CwtGovernorFastening_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub CwtGovernorFastening_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorFastening_cmb.SelectedIndexChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub CwtGovernorFastening_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorFastening_cmb.TextChanged
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub QtyStarRepeater_cmb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles QtyStarRepeater_cmb.KeyDown
    '        WhichKeyPressed(e.KeyCode)
    '    End Sub
    '    Private Sub QtyStarRepeater_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QtyStarRepeater_cmb.SelectedIndexChanged
    '        If isInitializingComponent Then
    '            Exit Sub
    '        End If
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub QtyStarRepeater_cmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles QtyStarRepeater_cmb.TextChanged
    '        MDIChildDirty = True
    '    End Sub
    '    Private Sub AdditionalCoaxCableQty_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdditionalCoaxCableQty_cmb.SelectedIndexChanged
    '        If AdditionalCoaxCableQty_cmb.Text <> MN_TRQ01_typ.AdditionalCoaxCableQty Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
    '    Private Sub AdditionalShieldPairsQty_cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdditionalShieldPairsQty_cmb.SelectedIndexChanged
    '        If AdditionalShieldPairsQty_cmb.Text <> MN_TRQ01_typ.AdditionalShieldPairsQty Then
    '            MDIChildDirty = True
    '            Fields2Type()
    '            Dependents.MOD_Parent()
    '            Load_ListBoxes()
    '            Type2Fields()
    '            Set_Fields_Grey()
    '            Main_MDI_frm.ProcessChildMessage()
    '        End If

    '    End Sub
End Class