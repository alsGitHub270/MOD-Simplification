Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Partial Friend Class MN_TRQ04_frm
    Inherits System.Windows.Forms.Form
    Private Sub MN_TRQ04_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
            UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
        End If
        If FormLoadWasProcessed Then
            FormLoadWasProcessed = False
        Else
            PrepareThisForm()
        End If


    End Sub

    Private Sub PrepareThisForm()

        SetPosition_obj.SetFormSizePos(Me)
        SetFormCaption(ENGINEERING_FORMS, MN_TRQ04_MENU_INDEX)

        FullCarAtTopAcceleratingUp_lbl(1).Text = Strings.FormatNumber(Traction(1), 3, TriState.True)
        If Traction(1) > dMaxTraction Then
            FullCarAtTopAcceleratingUp_lbl(0).ForeColor = Color.Red
            FullCarAtTopAcceleratingUp_lbl(1).ForeColor = Color.Red
        Else
            FullCarAtTopAcceleratingUp_lbl(0).ForeColor = Color.Black
            FullCarAtTopAcceleratingUp_lbl(1).ForeColor = Color.Black
        End If

        FullCarAtBottomAcceleratingUp_lbl(1).Text = Strings.FormatNumber(Traction(2), 3, TriState.True)
        If Traction(2) > dMaxTraction Then
            FullCarAtBottomAcceleratingUp_lbl(0).ForeColor = Color.Red
            FullCarAtBottomAcceleratingUp_lbl(1).ForeColor = Color.Red
        Else
            FullCarAtBottomAcceleratingUp_lbl(0).ForeColor = Color.Black
            FullCarAtBottomAcceleratingUp_lbl(1).ForeColor = Color.Black
        End If

        EmptyCarAtTopAcceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(3), 3, TriState.True)
        If Traction(3) > dMaxTraction Then
            EmptyCarAtTopAcceleratingDown_lbl(0).ForeColor = Color.Red
            EmptyCarAtTopAcceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            EmptyCarAtTopAcceleratingDown_lbl(0).ForeColor = Color.Black
            EmptyCarAtTopAcceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        EmptyCarAtBottomAcceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(4), 3, TriState.True)
        If Traction(4) > dMaxTraction Then
            EmptyCarAtBottomAcceleratingDown_lbl(0).ForeColor = Color.Red
            EmptyCarAtBottomAcceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            EmptyCarAtBottomAcceleratingDown_lbl(0).ForeColor = Color.Black
            EmptyCarAtBottomAcceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        FullCarAtTopDeceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(5), 3, TriState.True)
        If Traction(5) > dMaxTraction Then
            FullCarAtTopDeceleratingDown_lbl(0).ForeColor = Color.Red
            FullCarAtTopDeceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            FullCarAtTopDeceleratingDown_lbl(0).ForeColor = Color.Black
            FullCarAtTopDeceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        FullCarAtBottomDeceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(6), 3, TriState.True)
        If Traction(6) > dMaxTraction Then
            FullCarAtBottomDeceleratingDown_lbl(0).ForeColor = Color.Red
            FullCarAtBottomDeceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            FullCarAtBottomDeceleratingDown_lbl(0).ForeColor = Color.Black
            FullCarAtBottomDeceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        EmptyCarAtTopDeceleratingUp_lbl(1).Text = Strings.FormatNumber(Traction(7), 3, TriState.True)
        If Traction(7) > dMaxTraction Then
            EmptyCarAtTopDeceleratingUp_lbl(0).ForeColor = Color.Red
            EmptyCarAtTopDeceleratingUp_lbl(1).ForeColor = Color.Red
        Else
            EmptyCarAtTopDeceleratingUp_lbl(0).ForeColor = Color.Black
            EmptyCarAtTopDeceleratingUp_lbl(1).ForeColor = Color.Black
        End If

        EmptyCarAtBottomDeceleratingUp_lbl(1).Text = Strings.FormatNumber(Traction(8), 3, TriState.True)
        If Traction(8) > dMaxTraction Then
            EmptyCarAtBottomDeceleratingUp_lbl(0).ForeColor = Color.Red
            EmptyCarAtBottomDeceleratingUp_lbl(1).ForeColor = Color.Red
        Else
            EmptyCarAtBottomDeceleratingUp_lbl(0).ForeColor = Color.Black
            EmptyCarAtBottomDeceleratingUp_lbl(1).ForeColor = Color.Black
        End If

        OverloadedCarAtTopDeceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(9), 3, TriState.True)
        If Traction(9) > dMaxTraction Then
            OverloadedCarAtTopDeceleratingDown_lbl(0).ForeColor = Color.Red
            OverloadedCarAtTopDeceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            OverloadedCarAtTopDeceleratingDown_lbl(0).ForeColor = Color.Black
            OverloadedCarAtTopDeceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        OverloadedCarAtBottomDeceleratingDown_lbl(1).Text = Strings.FormatNumber(Traction(10), 3, TriState.True)
        If Traction(10) > dMaxTraction Then
            OverloadedCarAtBottomDeceleratingDown_lbl(0).ForeColor = Color.Red
            OverloadedCarAtBottomDeceleratingDown_lbl(1).ForeColor = Color.Red
        Else
            OverloadedCarAtBottomDeceleratingDown_lbl(0).ForeColor = Color.Black
            OverloadedCarAtBottomDeceleratingDown_lbl(1).ForeColor = Color.Black
        End If

        MaximumAllowableTractionRatio_lbl(1).Text = "        ***** " & Strings.FormatNumber(dMaxTraction, 3, TriState.True) & " *****" & Environment.NewLine

    End Sub
    Private Sub MN_TRQ04_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load

        FormLoadWasProcessed = True
        PrepareThisForm()

    End Sub
    Public Sub Validate_Renamed()

    End Sub
    Public Sub Fields2Type()

    End Sub
    Private Sub MN_TRQ04_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    End Sub
End Class