Option Strict Off
Option Explicit On
'Imports UpgradeHelpers.VB6.Gui
'Imports UpgradeHelpers.VB6.Utils
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.Common
Partial Friend Class MN_TRQ05_frm
    Inherits System.Windows.Forms.Form
    'Private Sub MN_TRQ05_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '    If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
    '        UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
    '    End If
    '    If FormLoadWasProcessed Then
    '        FormLoadWasProcessed = False
    '    Else
    '        PrepareThisForm()
    '    End If

    'End Sub

    'Dim str_Errors As String = ""
    'Dim ErrorCount As Integer = -1

    'Private Sub PrepareThisForm()
    '    Dim j As Integer
    '    Dim UsePREG As Double
    '    Dim SetHeight As Integer = 180

    '    SetPosition_obj.SetFormSizePos(Me)
    '    SetFormCaption(ENGINEERING_FORMS, MN_TRQ05_MENU_INDEX)
    '    PopulateDataFrames()
    '    str_Errors = ""
    '    Errors_lbl(0).Text = ""
    '    ErrorCount = -1
    '    If g_bErrors Then
    '        If iError(1) <> 0 Then
    '            If strError(1) = "" Then
    '                AppendNextError("Rope Safety Factor < ANSI Safety Factor" & Strings.Chr(9) & Strings.Chr(9) & Strings.FormatNumber(dSafety, 3, TriState.True))
    '            Else
    '                AppendNextError(strError(1))
    '            End If
    '        End If
    '        If iError(2) <> 0 Then
    '            If strError(2) = "" Then
    '                AppendNextError("Check for ANSI Safety Factor - Non Standard Speed " & Strings.FormatNumber(dSpeed, 1, TriState.True))
    '            Else
    '                AppendNextError(strError(2))
    '            End If
    '        End If
    '        If iError(3) <> 0 Then
    '            If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '                If strError(3) = "" Then
    '                    AppendNextError("K3269 Groove Pressure not found, Non-Standard Speed. CONSULT TABLES")
    '                Else
    '                    AppendNextError(strError(3))
    '                End If
    '            End If
    '        End If
    '        If dGrooveP > Conversion.Val(MN_TRQ01_typ.MaxGroovePressure) Then
    '            AppendNextError("Calculated groove pressure of " & Strings.FormatNumber(dGrooveP, 3, TriState.True) & " is greater than the Allowable Max Groove Pressure value of " & MN_TRQ01_typ.MaxGroovePressure)
    '        End If
    '        If iError(9) <> 0 Then
    '            If strError(9) = "" Then
    '                AppendNextError("Maximum Traction Ratio of " & Strings.FormatNumber(dMaxTraction, 3, TriState.True) & " was EXCEEDED.")
    '            Else
    '                AppendNextError(strError(9))
    '            End If
    '        End If
    '        If iError(11) <> 0 Then
    '            If strError(11) = "" Then
    '                AppendNextError("Calculated full horsepower of " & Strings.FormatNumber(dFullHP, 3, TriState.True) & " is greater than allowed for selected machine (" & ME_MRM01Car_typ.MachineModel & ").")
    '            Else
    '                AppendNextError(strError(11))
    '            End If
    '        End If
    '        If iError(15) <> 0 Then
    '            If strError(15) = "" Then
    '                If iError(15) = 2 Then
    '                    AppendNextError("Calculated motor HP exceeds the available motor HP.")
    '                Else
    '                    AppendNextError("You have to pick next RPM or larger Model.")
    '                End If
    '            Else
    '                AppendNextError(strError(15))
    '            End If
    '        End If
    '        If iError(16) <> 0 Then
    '            If strError(16) = "" Then
    '                AppendNextError("Calculated motor HP exceeds the machine limitation.")
    '            Else
    '                AppendNextError(strError(16))
    '            End If
    '        End If
    '        If iError(17) <> 0 Then
    '            If strError(17) = "" Then
    '                AppendNextError("Not Standard Application. Calculated Horsepower of " & dMH & " is too large for selected machine (" & ME_MRM01Car_typ.MachineModel & ").")
    '            Else
    '                AppendNextError(strError(17))
    '            End If
    '        End If
    '        If ME_MRM01Car_typ.MachineModel = "Other" Then
    '            AppendNextError("Allowable Sheave Load is unknown.")
    '        ElseIf dShvLoad > Conversion.Val(MN_TRQ01_typ.MaxShaftSheaveLoad) Then
    '            AppendNextError("Calculated sheave load of " & Strings.FormatNumber(dShvLoad, 3, TriState.True) & " is greater than the max sheave load table value of " & Strings.FormatNumber(MN_TRQ01_typ.MaxShaftSheaveLoad, 3, TriState.True) & ".")
    '        End If
    '    End If
    '    If Conversion.Val(IRFLU_lbl(2).Text) > Conversion.Val(IRFLU_lbl(1).Text) Then
    '        AppendNextError(IRFLU_lbl(0).Text & " of " & IRFLU_lbl(2).Text & " " & IRFLU_lbl(4).Text & " exceeds the Allowable " & IRFLU_lbl(3).Text & " " & IRFLU_lbl(1).Text & " " & IRFLU_lbl(4).Text)
    '    End If
    '    If Conversion.Val(IAFLU_lbl(2).Text) > Conversion.Val(IAFLU_lbl(1).Text) Then
    '        AppendNextError(IAFLU_lbl(0).Text & " of " & IAFLU_lbl(2).Text & " " & IAFLU_lbl(4).Text & " exceeds the Allowable " & IAFLU_lbl(3).Text & " of " & IAFLU_lbl(1).Text & " " & IAFLU_lbl(4).Text)
    '    End If
    '    If PREG_lbl(2).Visible Then
    '        If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '            If Conversion.Val(PREG_lbl(2).Text) > Conversion.Val(PREG_lbl(1).Text) Then
    '                AppendNextError(PREG_lbl(0).Text & " of " & PREG_lbl(2).Text & " " & PREG_lbl(4).Text & " exceeds the Allowable " & PREG_lbl(3).Text & " of " & PREG_lbl(1).Text & " " & PREG_lbl(4).Text)
    '            End If
    '        Else
    '            j = (PREG_lbl(1).Text.IndexOf("-") + 1)
    '            If j = 0 Then
    '                UsePREG = 0
    '            Else
    '                UsePREG = Conversion.Val(Strings.Mid(PREG_lbl(1).Text, j + 1))
    '            End If
    '            If Conversion.Val(PREG_lbl(2).Text) > UsePREG Then
    '                AppendNextError(PREG_lbl(0).Text & " of " & PREG_lbl(2).Text & " " & PREG_lbl(4).Text & " exceeds the Allowable " & PREG_lbl(3).Text & " of " & PREG_lbl(1).Text & " " & PREG_lbl(4).Text)
    '            End If
    '            If j = 0 Then
    '                UsePREG = 0
    '            Else
    '                UsePREG = Conversion.Val(Strings.Left(PREG_lbl(1).Text, j - 1))
    '            End If
    '            If Conversion.Val(PREG_lbl(2).Text) < UsePREG Then
    '                AppendNextError(PREG_lbl(0).Text & " of " & PREG_lbl(2).Text & " " & PREG_lbl(4).Text & " less than Allowable " & PREG_lbl(3).Text & " of " & PREG_lbl(1).Text & " " & PREG_lbl(4).Text)
    '            End If
    '        End If
    '    End If
    '    If DecTork_lbl(2).Visible Then
    '        If Conversion.Val(DecTork_lbl(2).Text) > Conversion.Val(DecTork_lbl(1).Text) Then
    '            AppendNextError(DecTork_lbl(0).Text & " of " & DecTork_lbl(2).Text & " " & DecTork_lbl(4).Text & " exceeds the Allowable " & DecTork_lbl(3).Text & " of " & DecTork_lbl(1).Text & " " & DecTork_lbl(4).Text)
    '        End If
    '    End If
    '    If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '        If Conversion.Val(TRFLU_lbl(1).Text) < Conversion.Val(RunningTorque_lbl(1).Text) Then
    '            AppendNextError("Running Torque of " & RunningTorque_lbl(1).Text & " ft-lbs exceeds the Allowable TRFLU of " & TRFLU_lbl(1).Text & " ft-lbs")
    '        End If
    '        If Conversion.Val(TRFLU_lbl(5).Text) < Conversion.Val(FullLoadTorque_lbl(1).Text) Then
    '            AppendNextError("Full Load Torque of " & FullLoadTorque_lbl(1).Text & " ft-lbs exceeds the Allowable TRFLU of " & TRFLU_lbl(1).Text & " ft-lbs")
    '        End If
    '        If Conversion.Val(TAFLU_lbl(1).Text) < Conversion.Val(CalculatedPeakAcceleratingTorque_lbl(1).Text) And Conversion.Val(TAFLU_lbl(1).Text) <> 0 Then
    '            AppendNextError("Peak Accelerating Torque of " & CalculatedPeakAcceleratingTorque_lbl(1).Text & " ft-lbs exceeds the Allowable TAFLU of " & TAFLU_lbl(1).Text & " ft-lbs")
    '        End If
    '        If Conversion.Val(TSFLD_lbl(1).Text) > Conversion.Val(CalculatedPeakDeceleratingTorque_lbl(1).Text) Then
    '            AppendNextError("Peak Decelerating Torque of " & CalculatedPeakDeceleratingTorque_lbl(1).Text & " ft-lbs exceeds the Allowable TSFLD of " & TSFLD_lbl(1).Text & " ft-lbs")
    '        End If
    '        If dFullHP > MN_TRQ01_typ.NominalMotorHP Then
    '            AppendNextError("Nominal Motor HP " & MN_TRQ01_typ.NominalMotorHP & " is under full load HP " & Strings.FormatNumber(dFullHP, 2, TriState.True))
    '        End If
    '    End If
    '    If ErrorCount = -1 Then
    '        Errors_lbl(0).Text = "NO ERRORS FOUND" & Environment.NewLine
    '        Errors_lbl(0).Height = 68
    '    Else
    '        Errors_lbl(0).Text = str_Errors
    '        SetHeight = 60 + (10 * ErrorCount)
    '        If SetHeight < 180 Then
    '            SetHeight = 180
    '        End If
    '    End If
    '    ErrorMessages_frame.Height = SetHeight

    'End Sub
    'Private Sub MN_TRQ05_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
    '    FormLoadWasProcessed = True
    '    PrepareThisForm()
    'End Sub
    'Public Sub Validate_Renamed()

    'End Sub
    'Public Sub Fields2Type()

    'End Sub
    'Private Sub PopulateDataFrames()
    '    Dim sSQL, s As String

    '    If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '        Allowable_lbl.Visible = True
    '        For iindex As Integer = 0 To 5
    '            TRFLU_lbl(iindex).Visible = True
    '        Next
    '        For iindex As Integer = 0 To 2
    '            TAFLU_lbl(iindex).Visible = True
    '            TSFLD_lbl(iindex).Visible = True
    '        Next
    '        sSQL = "SELECT * FROM [HP RPM MotorJ] "
    '        sSQL = sSQL & "WHERE rpm=" & CStr(MN_TRQ01_typ.MotorRPM)
    '        sSQL = sSQL & " AND HP=" & MN_TRQ01_typ.NominalMotorHP
    '        WorkingRecordSet = New ADODB.Recordset
    '        WorkingRecordSet.Open(sSQL, ADOConnection)
    '        If Not WorkingRecordSet.EOF Then
    '            TRFLU_lbl(1).Text = WorkingRecordSet("TRFLU").Value
    '            TRFLU_lbl(5).Text = WorkingRecordSet("TRFLU").Value
    '            TAFLU_lbl(1).Text = WorkingRecordSet("TAFLU").Value
    '            TSFLD_lbl(1).Text = CStr(-WorkingRecordSet("TAFLU").Value)
    '        End If
    '        WorkingRecordSet.Close()
    '        WorkingRecordSet = Nothing
    '        IRFLU_lbl(2).Text = Strings.FormatNumber(dIrflu, 2, TriState.True)
    '        IAFLU_lbl(2).Text = Strings.FormatNumber(dIaflu, 2, TriState.True)
    '        If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
    '            PREG_lbl(2).Text = Strings.FormatNumber(dPreg, 2, TriState.True)
    '            DecTork_lbl(2).Visible = False
    '        Else
    '            DecTork_lbl(2).Visible = True
    '            DecTork_lbl(2).Text = Strings.FormatNumber(Math.Abs(Conversion.Val(MN_PowerData_GEARED_typ.CurrentOutOfTheConverter_TSFLD)), 2, TriState.True)
    '        End If
    '        sSQL = "SELECT * FROM [Drive Selection] "
    '        sSQL = sSQL & "WHERE ANSI=" & (IIf((CurrentGOData_Typ.ANSICode) >= 2000, "True", "False"))
    '        sSQL = sSQL & " AND [Drive Selection]='" & MN_TRQ01_typ.DriveModel & "'"
    '        WorkingRecordSet = New ADODB.Recordset
    '        WorkingRecordSet.Open(sSQL, ADOConnection)
    '        IRFLU_lbl(1).Text = ""
    '        IRFLU_lbl(3).Text = "IRFLU"
    '        IAFLU_lbl(1).Text = ""
    '        IAFLU_lbl(3).Text = "IAFLU"
    '        PREG_lbl(3).Text = "PREG"
    '        PREG_lbl(4).Text = "kW"
    '        PREG_lbl(5).Text = "kW"
    '        DecTork_lbl(3).Text = "IDFLD"
    '        PREG_lbl(0).Text = "Dynamic Braking Power"          '"Regenerative Power"
    '        DecTork_lbl(0).Text = "Decelerating Current Full Load Down"
    '        If Not WorkingRecordSet.EOF Then
    '            IRFLU_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("Irflu").Value, 0, TriState.True)
    '            IAFLU_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("Iaflu").Value, 0, TriState.True)
    '            If Strings.Right(MN_TRQ01_typ.DriveModel, 2) = "BR" Then
    '                PREG_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("preg").Value, 1, TriState.True)
    '                For i As Integer = 0 To 5
    '                    PREG_lbl(i).Visible = True
    '                    DecTork_lbl(i).Visible = False
    '                Next i
    '            Else
    '                DecTork_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("IDFLD").Value, 0, TriState.True)
    '                For i As Integer = 0 To 5
    '                    DecTork_lbl(i).Visible = True
    '                    PREG_lbl(i).Visible = False
    '                Next i
    '            End If
    '        End If
    '    Else
    '        Allowable_lbl.Visible = False
    '        For iindex As Integer = 0 To 5
    '            TRFLU_lbl(iindex).Visible = False
    '        Next
    '        For iindex As Integer = 0 To 2
    '            TAFLU_lbl(iindex).Visible = False
    '            TSFLD_lbl(iindex).Visible = False
    '        Next
    '        IRFLU_lbl(3).Text = "IDC1"
    '        IAFLU_lbl(3).Text = "IDC2"
    '        PREG_lbl(3).Text = "IFF"
    '        PREG_lbl(4).Text = "Amps"
    '        PREG_lbl(5).Text = "Amps"
    '        DecTork_lbl(3).Text = "VFLU"
    '        DecTork_lbl(4).Text = "Volts"
    '        DecTork_lbl(5).Text = "Volts"
    '        sSQL = "SELECT * FROM [Drive Selection " & (IIf(ME_MRM01Car_typ.ControllerType = DRIVETYPE_SCRDC, "SSDC", "Quattro")) & "]"
    '        WorkingRecordSet = New ADODB.Recordset
    '        WorkingRecordSet.Open(sSQL & " WHERE [Drive Selection]='" & MN_TRQ01_typ.DriveModel & "'", ADOConnection)
    '        If Not WorkingRecordSet.EOF Then
    '            IRFLU_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("IDC1").Value, 0, TriState.True)
    '            IAFLU_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("IDC2").Value, 0, TriState.True)
    '            s = Strings.FormatNumber(WorkingRecordSet("IFFmin").Value, 1, TriState.True) & " - "
    '            s = s & Strings.FormatNumber(WorkingRecordSet("IFFmax").Value, 0, TriState.True)
    '            PREG_lbl(1).Text = s
    '            For i As Integer = 0 To 5
    '                PREG_lbl(i).Visible = True
    '                DecTork_lbl(i).Visible = True
    '            Next i
    '            DecTork_lbl(1).Text = Strings.FormatNumber(WorkingRecordSet("VFLU").Value, 0, TriState.True)
    '        End If
    '        IRFLU_lbl(2).Text = Strings.FormatNumber(Conversion.Val(ME_MRM01Car_typ.NamePlateArmatureFullLoadCurrent), 2, TriState.True)
    '        IAFLU_lbl(2).Text = Strings.FormatNumber(Conversion.Val(IDC2), 2, TriState.True)
    '        PREG_lbl(0).Text = "Motor Current Full Field (IFF)"
    '        PREG_lbl(2).Text = ME_MRM01Car_typ.IFF
    '        DecTork_lbl(0).Text = "Voltage Full Load Up (VFLU)"
    '        DecTork_lbl(2).Text = CStr(ME_MRM01Car_typ.NamePlateArmatureFullLoadVoltage)
    '    End If
    '    WorkingRecordSet.Close()
    '    WorkingRecordSet = Nothing
    '    RunningTorque_lbl(1).Text = Strings.FormatNumber(dRunTork, 2, TriState.True)
    '    FullLoadTorque_lbl(1).Text = Strings.FormatNumber(dFullTork, 2, TriState.True)
    '    CalculatedPeakAcceleratingTorque_lbl(1).Text = Strings.FormatNumber(dAccTork, 2, TriState.True)
    '    CalculatedPeakDeceleratingTorque_lbl(1).Text = Strings.FormatNumber(dDecTork, 2, TriState.True)
    '    RunningHorsepower_lbl(1).Text = Strings.FormatNumber(dHPower, 2, TriState.True)
    '    RunningHorsepower_lbl(0).Text = "Running Horsepower"
    '    CalculatedFullLoadHorsepower_lbl(1).Text = Strings.FormatNumber(dFullHP, 2, TriState.True)
    '    If GONumbers(CurrentGOSelection).MachineType = GEARED_TYPE Then
    '        For i As Integer = 0 To 4
    '            MotorHorsepower_lbl(i).Visible = True
    '        Next i
    '        MotorHorsepower_lbl(1).Text = Strings.FormatNumber(MN_TRQ01_typ.NominalMotorHPDefault, 2, TriState.True)
    '        If dMH = (MN_TRQ01_typ.NominalMotorHPDefault) Then
    '            MotorHorsepower_lbl(2).Visible = False
    '            MotorHorsepower_lbl(3).Visible = False
    '        Else
    '            MotorHorsepower_lbl(3).Text = Strings.FormatNumber(dMH, 2, TriState.True)
    '        End If
    '    Else
    '        For i As Integer = 0 To 4
    '            MotorHorsepower_lbl(i).Visible = False
    '        Next i
    '    End If
    '    DriveModel_lbl(1).Text = MN_TRQ01_typ.DriveModelDefault
    '    If MN_TRQ01_typ.DriveModelDefault = MN_TRQ01_typ.DriveModel Then
    '        DriveModel_lbl(2).Visible = False
    '        DriveModel_lbl(3).Visible = False
    '        DriveModel_lbl(3).Text = ""
    '    Else
    '        DriveModel_lbl(2).Visible = True
    '        DriveModel_lbl(3).Visible = True
    '        DriveModel_lbl(3).Text = MN_TRQ01_typ.DriveModel
    '    End If

    'End Sub
    'Private Sub MN_TRQ05_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed

    'End Sub
    'Private Sub AppendNextError(ByVal ErrorMsg As String)
    '    str_Errors &= ErrorMsg & Environment.NewLine
    '    ErrorCount += 1
    'End Sub
End Class