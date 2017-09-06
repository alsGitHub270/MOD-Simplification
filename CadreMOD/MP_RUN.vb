Option Strict Off
Option Explicit On
Imports System
Imports System.Windows.Forms
Partial Friend Class MP_RUN_frm
    Inherits System.Windows.Forms.Form
    Private Sub MP_RUN_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
            UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
        End If
    End Sub
    Dim ThisConfigHasQuote As Boolean

    Private Sub Cancel_cmd_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Cancel_cmd.Click
        Me.Dispose()
    End Sub
    Private Sub MP_RUN_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        If Not CalledToRunReconfig Then
            Reconfig.Text = "OK"
            Me.AcceptButton = Reconfig
            Me.Cancel_cmd = Cancel_cmd
            RunConfigWithOut_Chk(NONE_TYPE).CheckState = CheckState.Unchecked
            RunConfigWithOut_Chk(NONE_TYPE).Enabled = False
            Me.Width = ConvertTwipsToPixels(10155)
            Separator_line.Visible = True
            ReportHeader_lbl.Visible = True
            ReportHeader_txt.Visible = True
            ReportHeader_txt.Text = GONumbers(CurrentGOSelection).ReportHeader
        Else
            Reconfig.Text = "Reconfig"
            Me.AcceptButton = Reconfig
            Me.Cancel_cmd = Cancel_cmd
            RunConfigWithOut_Chk(NONE_TYPE).Enabled = True
            Me.Width = ConvertTwipsToPixels(3675)
            Separator_line.Visible = False
            ReportHeader_lbl.Visible = False
            ReportHeader_txt.Visible = False
        End If

        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        isInitializingComponent = True
        If CalledToRunReconfig Then
            For typestrvalue As Integer = REUSE_TYPE To OTHER_TYPE
                If RunConfigWithOut(typestrvalue) Then
                    RunConfigWithOut_Chk(typestrvalue).CheckState = CheckState.Unchecked
                Else
                    RunConfigWithOut_Chk(typestrvalue).CheckState = CheckState.Checked
                End If
            Next

            ThisConfigHasQuote = HasQuote()

            If ThisConfigHasQuote Then
                RunConfigWithOut_Chk(QUOTE_TYPE).Enabled = True
                If RunConfigWithOut(QUOTE_TYPE) Then
                    RunConfigWithOut_Chk(QUOTE_TYPE).CheckState = CheckState.Unchecked
                Else
                    RunConfigWithOut_Chk(QUOTE_TYPE).CheckState = CheckState.Checked
                End If
            Else
                RunConfigWithOut_Chk(QUOTE_TYPE).Enabled = False
                RunConfigWithOut_Chk(QUOTE_TYPE).CheckState = CheckState.Unchecked
            End If
        Else
            For typestrvalue As Integer = REUSE_TYPE To QUOTE_TYPE
                If TypeCustomize(typestrvalue) Then
                    RunConfigWithOut_Chk(typestrvalue).CheckState = CheckState.Checked
                Else
                    RunConfigWithOut_Chk(typestrvalue).CheckState = CheckState.Unchecked
                End If
            Next
        End If
        isInitializingComponent = False

    End Sub
    Private Sub Reconfig_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Reconfig.Click
        Dim ProdCode As Integer

        If CalledToRunReconfig Then
            For typestrvalue As Integer = REUSE_TYPE To QUOTE_TYPE
                RunConfigWithOut(typestrvalue) = RunConfigWithOut_Chk(typestrvalue).CheckState = CheckState.Unchecked
            Next
            If RunMDIChildDirty Then
                ProdCode = CarProductCode
                MOD_ProductCode()
                If ProdCode <> CarProductCode Then
                    PrepareForRun(JOB_RUN)
                Else
                    MP_CST01_frm.CostGrid2Type()
                    RunMDIChildDirty = False
                    MP_CST01_frm.Type2CostGrid()
                End If
            Else
                MP_CST01_frm.Type2CostGrid()
            End If
        Else
            For typestrvalue As Integer = REUSE_TYPE To QUOTE_TYPE
                TypeCustomize(typestrvalue) = RunConfigWithOut_Chk(typestrvalue).CheckState
            Next
            GONumbers(CurrentGOSelection).ReportHeader = ReportHeader_txt.Text
        End If

        Me.Dispose()

    End Sub
    Private isInitializingComponent As Boolean
    Private Sub ReportHeader_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles ReportHeader_txt.TextChanged
        If isInitializingComponent Then
            Exit Sub
        End If
        If ReportHeader_txt.Text <> GONumbers(CurrentGOSelection).ReportHeader Then
            CM_GridStatus.GridStatus = GRID_IS_DIRTY
        End If
    End Sub
    Private Sub RunConfigWithOut_Chk_CheckStateChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _RunConfigWithOut_Chk_2.CheckStateChanged, _RunConfigWithOut_Chk_8.CheckStateChanged, _RunConfigWithOut_Chk_9.CheckStateChanged, _RunConfigWithOut_Chk_7.CheckStateChanged, _RunConfigWithOut_Chk_6.CheckStateChanged, _RunConfigWithOut_Chk_5.CheckStateChanged, _RunConfigWithOut_Chk_4.CheckStateChanged, _RunConfigWithOut_Chk_3.CheckStateChanged, _RunConfigWithOut_Chk_1.CheckStateChanged, _RunConfigWithOut_Chk_0.CheckStateChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        Dim Index As Integer = Array.IndexOf(RunConfigWithOut_Chk, eventSender)
        RunConfigWithOut(Index) = RunConfigWithOut_Chk(Index).CheckState = CheckState.Unchecked

    End Sub
    Private Function HasQuote() As Boolean
        Dim result As Boolean = False

        For Row As Integer = 1 To CostGridType_Data.GetUpperBound(0)
            If CostGridType_Data(Row).Col(TYPE_STR - 1) <> "Quote" And Not String.IsNullOrEmpty(CostGridType_Data(Row).ReferenceNumber) Then
                Return True
            End If
        Next

        Return result
    End Function
    Private Sub MP_RUN_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    End Sub
End Class