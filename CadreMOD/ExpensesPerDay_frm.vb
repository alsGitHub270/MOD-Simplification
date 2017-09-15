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

    Private Sub InitializeCost()
        Dim i As Integer

        For i = 1 To 5
            Cost_txt(i).Text = ""
        Next i
        Total_txt.Text = ""

    End Sub
    Public Sub Fields2Type()
        Dim CurCost As String = String.Empty
        Dim NumParts() As String = Nothing

        For i As Integer = 1 To 5
            SubcontractedLaborCost.LaborCost(i - 1).Description = Description_txt(i).Text
            CurCost = Cost_txt(i).Text.Trim
            If Not String.IsNullOrEmpty(CurCost) Then
                NumParts = CurCost.Split(",")
                If NumParts.Length > 1 Then
                    CurCost = String.Empty
                    For iIndex As Integer = 0 To NumParts.GetUpperBound(0)
                        CurCost &= NumParts(iIndex)
                    Next iIndex
                End If
            End If
            SubcontractedLaborCost.LaborCost(i - 1).Cost = Conversion.Val(CurCost)
        Next i
        NumParts = Total_txt.Text.Split(",")
        If NumParts.Length = 1 Then
            CurCost = Total_txt.Text
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
                If Conversion.Val(CStr(SubcontractedLaborCost.TotalCost)) <> Conversion.Val(Total_txt.Text) Then
                    If MessageBox.Show("Data has been changed. Do you want to save it before closing.", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Fields2Type()
                    End If
                End If
                Me.Dispose()
            Case ACTION_TYPE_CLEAR_FORM
                InitializeCost()
            Case Else
        End Select

    End Sub
    Private Sub Type2Fields()

        For i As Integer = 1 To 5
            If SubcontractedLaborCost.LaborCost(i - 1).Cost = 0 Then
                Cost_txt(i).Text = ""
            Else
                Cost_txt(i).Text = FormatNumber(SubcontractedLaborCost.LaborCost(i - 1).Cost, 2)
            End If
        Next i
        Total_txt.Text = FormatNumber(SubcontractedLaborCost.TotalCost, 2)

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
    Private Sub Cost_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _Cost_txt_4.TextChanged, _Cost_txt_3.TextChanged, _Cost_txt_2.TextChanged, _Cost_txt_1.TextChanged, _Cost_txt_5.TextChanged
        If isInitializingComponent Then
            Exit Sub
        End If
        frmEstimatingBase.FormIsDirty = True
    End Sub
    Private Sub Cost_txt_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles _Cost_txt_4.KeyPress, _Cost_txt_3.KeyPress, _Cost_txt_2.KeyPress, _Cost_txt_1.KeyPress, _Cost_txt_5.KeyPress
        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)
        Dim Index As Integer = Array.IndexOf(Cost_txt, eventSender)

        If Description_txt(Index).Text.Trim() = "" Then
            SystemSounds.Beep.Play()
            KeyAscii = 0
        Else
            Select Case KeyAscii
                Case Keys.Back, Keys.Left, Keys.Right, Keys.Delete, Keys.Return, Keys.Decimal, Keys.D0 To Keys.D9
                Case Else
                    SystemSounds.Beep.Play()
                    KeyAscii = 0
            End Select
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    End Sub
    Private Sub Cost_txt_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _Cost_txt_4.Leave, _Cost_txt_3.Leave, _Cost_txt_2.Leave, _Cost_txt_1.Leave, _Cost_txt_5.Leave
        RecalculateTotal()
    End Sub
    Private Sub Description_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _Description_txt_5.TextChanged, _Description_txt_3.TextChanged, _Description_txt_4.TextChanged, _Description_txt_2.TextChanged, _Description_txt_1.TextChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        Dim Index As Integer = Array.IndexOf(Description_txt, eventSender)
        frmEstimatingBase.FormIsDirty = True
        If Description_txt(Index).Text.Trim() = "" Then
            SystemSounds.Beep.Play()
            Cost_txt(Index).Text = ""
            RecalculateTotal()
        End If

    End Sub
    Private Sub ExpensesPerDay_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        PrepareThisForm()
    End Sub
    Private Sub ExpensesPerDay_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
        Me.Finalize()
    End Sub
    Private Sub RecalculateTotal()
        Dim dTotal As Double = 0

        For i As Integer = 1 To 5
            If IsNumeric(Cost_txt(i).Text) Then
                dTotal += CDbl(Cost_txt(i).Text)
            End If
        Next i
        Total_txt.Text = FormatNumber(dTotal, 2)

    End Sub
End Class