Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Media
Imports System.Windows.Forms
Partial Friend Class ExpensesPerDay_frm
    Inherits System.Windows.Forms.Form

    Const ACTION_TYPE_CLEAR_FORM As Integer = 0
    Const ACTION_TYPE_UNLOADME As Integer = 1
    Dim i As Integer

    Public Sub Fields2Type()
        Dim CurCost As String = String.Empty
        Dim NumParts() As String = Nothing
        Dim UseIndex As Integer = 0

        For Each Cntrl As Control In Me.Controls
            If TypeOf [Cntrl] Is TextBox Then
                ReDim Preserve SubcontractedLaborCost.LaborCost(UseIndex)
                CurCost = [Cntrl].Text.Trim
                If Not String.IsNullOrEmpty(CurCost) Then
                    NumParts = CurCost.Split(",")
                    If NumParts.Length > 1 Then
                        CurCost = String.Empty
                        For iIndex As Integer = 0 To NumParts.GetUpperBound(0)
                            CurCost &= NumParts(iIndex)
                        Next iIndex
                    End If
                End If
                SubcontractedLaborCost.LaborCost(UseIndex).Description = [Cntrl].Name
                SubcontractedLaborCost.LaborCost(UseIndex).Cost = Conversion.Val(CurCost)
                UseIndex += 1
            End If
        Next Cntrl
        NumParts = ExpensesPerDayTotal_txt.Text.Split(",")
        If NumParts.Length = 1 Then
            CurCost = ExpensesPerDayTotal_txt.Text
        Else
            CurCost = String.Empty
            For iIndex As Integer = 0 To NumParts.GetUpperBound(0)
                CurCost &= NumParts(iIndex)
            Next iIndex
        End If
        SubcontractedLaborCost.TotalCost = Conversion.Val(CurCost)

    End Sub
    Private Sub ActionLogic(ByRef ThisAction As Integer)

        Select Case ThisAction
            Case ACTION_TYPE_UNLOADME
                If Conversion.Val(CStr(SubcontractedLaborCost.TotalCost)) <> Conversion.Val(ExpensesPerDayTotal_txt.Text) Then
                    If MessageBox.Show("Data has been changed. Do you want to save it before closing.", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Fields2Type()
                    End If
                End If
                Me.Dispose()
            Case ACTION_TYPE_CLEAR_FORM
                For Each Cntrl As Control In Me.Controls
                    If TypeOf [Cntrl] Is TextBox Then
                        [Cntrl].Text = String.Empty
                    End If
                Next Cntrl
            Case Else
        End Select

    End Sub
    Private Sub Type2Fields()
        Dim UseIndex As Integer = 0

        For UseIndex = SubcontractedLaborCost.LaborCost.GetLowerBound(0) To SubcontractedLaborCost.LaborCost.GetUpperBound(0)
            For Each Cntrl As Control In Me.Controls
                If [Cntrl].Name = SubcontractedLaborCost.LaborCost(UseIndex).Description Then
                    [Cntrl].Text = FormatNumber(SubcontractedLaborCost.LaborCost(UseIndex).Cost, 2)
                    Exit For
                End If
            Next Cntrl
        Next UseIndex
        ExpensesPerDayTotal_txt.Text = FormatNumber(SubcontractedLaborCost.TotalCost, 2)

    End Sub
    Private Sub PrepareThisForm()

        isInitializingComponent = True
        Type2Fields()
        isInitializingComponent = False

    End Sub
    Private Sub Action_btn_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _Action_btn_1.Click, _Action_btn_0.Click
        Dim Index As Integer = Array.IndexOf(Action_btn, eventSender)
        ActionLogic(Index)
    End Sub
    Private isInitializingComponent As Boolean
    Private Sub Cost_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ExpensesPerDayTravelTime_txt.TextChanged, ExpensesPerDayOutOfTownExpenses_txt.TextChanged, ExpensesPerDayParking_txt.TextChanged, ExpensesPerDayZone_txt.TextChanged, ExpensesPerDayMiscellaneous_txt.TextChanged
        If isInitializingComponent Then
            Exit Sub
        End If
        FormIsDirty = True
    End Sub
    Private Sub Cost_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles ExpensesPerDayTravelTime_txt.KeyPress, ExpensesPerDayOutOfTownExpenses_txt.KeyPress, ExpensesPerDayParking_txt.KeyPress, ExpensesPerDayZone_txt.KeyPress, ExpensesPerDayMiscellaneous_txt.KeyPress
        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

        Select Case KeyAscii
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Delete, Keys.Return, Keys.Decimal, Keys.D0 To Keys.D9
            Case Else
                SystemSounds.Beep.Play()
                KeyAscii = 0
        End Select
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    End Sub
    Private Sub Cost_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ExpensesPerDayTravelTime_txt.Leave, ExpensesPerDayOutOfTownExpenses_txt.Leave, ExpensesPerDayParking_txt.Leave, ExpensesPerDayMiscellaneous_txt.Leave, ExpensesPerDayZone_txt.Leave
        RecalculateTotal()
    End Sub
    Private Sub ExpensesPerDay_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        PrepareThisForm()
    End Sub
    Private Sub ExpensesPerDay_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
        Me.Finalize()
    End Sub
    Private Sub RecalculateTotal()
        Dim dTotal As Double = 0

        dTotal += Conversion.Val(ExpensesPerDayZone_txt.Text)
        dTotal += Conversion.Val(ExpensesPerDayParking_txt.Text)
        dTotal += Conversion.Val(ExpensesPerDayOutOfTownExpenses_txt.Text)
        dTotal += Conversion.Val(ExpensesPerDayTravelTime_txt.Text)
        dTotal += Conversion.Val(ExpensesPerDayMiscellaneous_txt.Text)
        ExpensesPerDayTotal_txt.Text = FormatNumber(dTotal, 2)

    End Sub
End Class