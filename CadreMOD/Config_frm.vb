Option Strict Off
Option Explicit On
Imports System
Imports System.Windows.Forms
Partial Friend Class Config_frm
    Inherits System.Windows.Forms.Form
    Public ChangedResolution As Boolean = False

    Private Sub Config_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        Dim hWndSrc As Integer
        Dim a As Boolean
        Dim SupportsRes As Boolean = False
        Dim i As Integer = 0

        ChangedResolution = False
        Do
            a = EnumDisplaySettings(0, i, DevM)
            i += 1
            If DevM.dmPelsWidth >= PreferredScreenWidth And DevM.dmPelsHeight >= PreferredScreenHeight Then
                SupportsRes = True
                Exit Do
            End If
        Loop Until (Not a)
        If Not SupportsRes Then
            MessageBox.Show("For maximum visibility, this Application is best viewed with a screen resolution of " & PreferredScreenWidth & " x " &
                            PreferredScreenHeight & "." & Environment.NewLine & "Your equipment does not support this." & Environment.NewLine &
                            "You may have to scroll", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'save the current resolution/screen setting
        Dim hDCSrc As Integer = GetWindowDC(hWndSrc) ' Get device context for entire window
        SaveWidth = GetDeviceCaps(hDCSrc, HORZRES)
        SaveHeight = GetDeviceCaps(hDCSrc, VERTRES)
        SaveRefresh = GetDeviceCaps(hDCSrc, VREFRESH)
        If SupportsRes And SaveWidth < PreferredScreenWidth And SaveHeight < PreferredScreenHeight Then
            ChangeDisplayResolution(PreferredScreenWidth, PreferredScreenHeight)
            ChangedResolution = True
        End If

    End Sub
    Private Sub Config_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
    End Sub
End Class