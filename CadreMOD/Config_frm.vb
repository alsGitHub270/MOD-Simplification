Option Strict Off
Option Explicit On
Imports System
Imports System.Windows.Forms
Partial Friend Class Config_frm
    Inherits System.Windows.Forms.Form
    'Private Sub Config_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
    '    If Not (UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm Is eventSender) Then
    '        UpgradeHelpers.VB6.Gui.ActivateHelper.myActiveForm = eventSender
    '    End If
    'End Sub

    Private Sub Config_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        Dim hWndSrc As Integer
        Dim a As Boolean
        Dim SupportsRes As Boolean = False
        Dim wid As Integer = 1024
        Dim hgt As Integer = 768
        Dim i As Integer = 0
        ' loop through supported resolutions to determine if
        ' 1024 x 768 is supported on this hardware
        Do
            a = EnumDisplaySettings(0, i, DevM)
            i += 1
            If DevM.dmPelsWidth = 1024 And DevM.dmPelsHeight = 768 Then
                SupportsRes = True
            End If
        Loop Until (Not a)

        If Not SupportsRes Then
            MessageBox.Show("This Application Requires A Screen Resolution of 1024 x 768." & Environment.NewLine & "Your equipment does not support this.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(0)
        End If

        'save the current resolution/screen setting
        Dim hDCSrc As Integer = GetWindowDC(hWndSrc) ' Get device context for entire window
        SaveWidth = GetDeviceCaps(hDCSrc, HORZRES)
        SaveHeight = GetDeviceCaps(hDCSrc, VERTRES)
        SaveRefresh = GetDeviceCaps(hDCSrc, VREFRESH)
        If SupportsRes And SaveWidth < 1024 And SaveHeight < 768 Then
            ChangeDisplayResolution(wid, hgt)
        End If

    End Sub
    Private Sub Config_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    End Sub
End Class