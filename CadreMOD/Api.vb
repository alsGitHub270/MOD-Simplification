Option Strict Off
Option Explicit On
'Imports UpgradeHelpers.VB6.Gui
'Imports UpgradeHelpers.VB6.Utils
'Imports UpgradeHelpers.VB6.VB
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Module API

    Public Enum CursorTypeEnumEnum
        adOpenKeyset = 1
    End Enum
    Public Enum PictureTypeConstantsEnum
        vbPicTypeBitmap = 1
    End Enum
    Public Enum QueryUnloadConstantsEnum
        vbFormControlMenu = 0
    End Enum
    Public Enum ScaleModeConstantsEnum
        vbHiMetric = 8
        vbUser = 0
        vbPixels = 3
    End Enum

    Dim zType As PictureTypeConstantsEnum

    ' Form Capture/Print-------------------------- ---------------------------

    Public Structure PALETTEENTRY
        Dim peRed As Byte
        Dim peGreen As Byte
        Dim peBlue As Byte
        Dim peFlags As Byte
    End Structure

    Public Structure LOGPALETTE
        Dim palVersion As Short
        Dim palNumEntries As Short
        Dim palPalEntry() As PALETTEENTRY ' Enough for 256 colors
    End Structure

    Private Structure GUID
        Dim Data1 As Integer
        Dim Data2 As Short
        Dim Data3 As Short
        Dim Data4() As Byte
    End Structure
    Dim l As LOGPALETTE
    Private Const RASTERCAPS As Integer = 38
    Private Const RC_PALETTE As Integer = &H100S
    Private Const SIZEPALETTE As Integer = 104

    Private Declare Function CreateCompatibleDC Lib "GDI32" (ByVal hDC As Integer) As Integer
    Private Declare Function CreateCompatibleBitmap Lib "GDI32" (ByVal hDC As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer
    Public Declare Function GetDeviceCaps Lib "GDI32" (ByVal hDC As Integer, ByVal iCapabilitiy As Integer) As Integer
    Private Declare Function GetSystemPaletteEntries Lib "GDI32" (ByVal hDC As Integer, ByVal wStartIndex As Integer, ByVal wNumEntries As Integer, ByRef lpPaletteEntries As PALETTEENTRY) As Integer
    Private Declare Function CreatePalette Lib "GDI32" (ByRef lpLogPalette As LOGPALETTE) As Integer
    Private Declare Function SelectObject Lib "GDI32" (ByVal hDC As Integer, ByVal hObject As Integer) As Integer
    Private Declare Function BitBlt Lib "GDI32" (ByVal hDCDest As Integer, ByVal XDest As Integer, ByVal YDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hDCSrc As Integer, ByVal XSrc As Integer, ByVal YSrc As Integer, ByVal dwRop As Integer) As Integer
    Private Declare Function DeleteDC Lib "GDI32" (ByVal hDC As Integer) As Integer
    Private Declare Function SelectPalette Lib "GDI32" (ByVal hDC As Integer, ByVal hPalette As Integer, ByVal bForceBackground As Integer) As Integer
    Private Declare Function RealizePalette Lib "GDI32" (ByVal hDC As Integer) As Integer
    Public Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Integer) As Integer
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As Integer) As Integer
    Private Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Integer, ByVal hDC As Integer) As Integer
    Public Declare Function GetProfileString Lib "kernel32" Alias "GetProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer) As Integer
    Public Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" (ByVal lpszSection As String, ByVal lpszKeyName As String, ByVal lpszString As String) As Integer

    Private Structure PicBmp
        Dim Size As Integer
        Dim Type As Integer
        Dim hBmp As Integer
        Dim hPal As Integer
        Dim Reserved As Integer
    End Structure

    Private Declare Function OleCreatePictureIndirect Lib "olepro32.dll" (ByRef PicDesc As PicBmp, ByRef RefIID As GUID, ByVal fPictureOwnsHandle As Integer, ByRef IPic As Image) As Integer

    ' API Constants -----------------------------------------------------------------------------------------------------------------------------
    Public Const WM_USER As Integer = &H400S
    Public Const CB_SHOWDROPDOWN As Integer = (WM_USER + 15)
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const CB_FINDSTRINGEXACT As Integer = &H158S

    ' API Declarations  ------------------------------------------------------------------------------------------------------------------------
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function WinHelp Lib "user32" Alias "WinHelpA" (ByVal hwnd As Integer, ByVal LPHELPFILE As String, ByVal wCommand As Integer, ByVal dwData As Integer) As Integer
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Declare Function ShowWindow Lib "user32" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    Declare Function SetFocus Lib "user32" (ByVal hwnd As Integer) As Integer

    ' WinHelp command constants
    Public Const HELP_TAB As Integer = &HFS

    ' Horizontal ScrollBar
    Public Const LB_SETHORIZONTALEXTENT As Integer = &H194S

    ' Change Resolution
    Public Const CCDEVICENAME As Integer = 32
    Public Const CCFORMNAME As Integer = 32

    Public Structure DEVMODE
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
        Public dmDeviceName As String

        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer
        Public dmPositionX As Integer
        Public dmPositionY As Integer
        Public dmDisplayOrientation As Integer
        Public dmDisplayFixedOutput As Integer
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
        Public dmFormName As String

        Public dmLogPixels As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer
        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
        Public dmICMMethod As Integer
        Public dmICMIntent As Integer
        Public dmMediaType As Integer
        Public dmDitherType As Integer
        Public dmReserved1 As Integer
        Public dmReserved2 As Integer
        Public dmPanningWidth As Integer
        Public dmPanningHeight As Integer
    End Structure

    Public DevM As New DEVMODE
    Public Declare Function EnumDisplaySettings Lib "user32.dll" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Short, ByVal iModeNum As Short, ByRef lpDevMode As DEVMODE) As Short

    Public SaveHeight As Integer
    Public SaveWidth As Integer
    Public SaveRefresh As Integer

    Private Declare Function ChangeDisplaySettings Lib "user32.dll" Alias "ChangeDisplaySettingsA" (ByRef lpDevMode As DEVMODE, ByVal dwFlags As Integer) As Integer
    Private Const DM_DISPLAYFREQUENCY As Integer = &H400000
    Private Const DM_PELSHEIGHT As Integer = &H100000
    Private Const DM_PELSWIDTH As Integer = &H80000

    Private Const CDS_UPDATEREGISTRY As Integer = &H1S
    Private Const DISP_CHANGE_SUCCESSFUL As Integer = 0

    Public Const HORZRES As Integer = 8 ' Screen width in pixels
    Public Const VERTRES As Integer = 10 ' Screen height in pixels
    Public Const VREFRESH As Integer = 116 ' Screen refresh rate in MHZ

    Private Declare Function DeleteObject Lib "gdi32" (ByVal hObject As IntPtr) As Boolean
    Private Declare Function GetWindowRect Lib "user32" (ByVal hWnd As IntPtr, ByRef rect As RECT) As IntPtr
    Private Const SRCCOPY As Integer = &HCC0020
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure 'RECT

    'Public Sub PrintPictureToFitPage(ByRef Pic As Image)
    '    Dim Prn As New Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6.Printer
    '    Dim PrnWidth As Double = Prn.ScaleWidth
    '    Dim PrnHeight As Double = Prn.ScaleHeight
    '    Dim PicRatio As Double = Pic.Width / Pic.Height
    '    Dim PrnRatio As Double = 0

    '    If Pic.Height >= Pic.Width Then
    '        Prn.Orientation = 1
    '    Else
    '        Prn.Orientation = 2
    '    End If
    '    PrnWidth = Prn.ScaleX(Prn.ScaleWidth, Prn.ScaleMode, 8)
    '    PrnHeight = Prn.ScaleY(Prn.ScaleHeight, Prn.ScaleMode, 8)
    '    PrnRatio = PrnWidth / PrnHeight
    '    PrnWidth = Prn.ScaleX(PrnWidth, 8, Prn.ScaleMode)
    '    PrnHeight = Prn.ScaleY(PrnHeight, 8, Prn.ScaleMode)
    '    Prn.PaintPicture(Pic, 0, 0, PrnWidth, PrnHeight)
    '    Prn.EndDoc()

    'End Sub

    'Public Function CaptureForm(ByRef frmSrc As Form) As Image
    '    Dim result As Image = Nothing

    '    If frmSrc.Name = "CM_MAIN_frm" Then
    '        Return MemoryHelper.ReleaseAndCleanObject(Of Image)(result, CaptureWindow(frmSrc.Handle.ToInt32, frmSrc.Width, frmSrc.Height))
    '    Else
    '        Return MemoryHelper.ReleaseAndCleanObject(Of Image)(result, CaptureWindow(Main_MDI_frm.Handle.ToInt32, Application.OpenForms(0).Width, Application.OpenForms(0).Height))
    '    End If

    '    Return result

    'End Function

    Public Function CaptureWindow(ByVal handle As IntPtr, ByVal WidthSrc As Integer, ByVal HeightSrc As Integer) As Image
        Dim hdcSrc As IntPtr = GetWindowDC(handle)                                  ' get te hDC of the target window        
        Dim windowRect As New RECT                                                  ' get the size        

        GetWindowRect(handle, windowRect)
        Dim hdcDest As IntPtr = CreateCompatibleDC(hdcSrc)                          ' create a device context we can copy to        
        Dim hBitmap As IntPtr = CreateCompatibleBitmap(hdcSrc, WidthSrc, HeightSrc)       ' create a bitmap we can copy it to, using GetDeviceCaps to get the width/height        
        Dim hOld As IntPtr = SelectObject(hdcDest, hBitmap)                         ' select the bitmap object        
        BitBlt(hdcDest, 0, 0, WidthSrc, HeightSrc, hdcSrc, 0, 0, SRCCOPY)                 ' bitblt over        
        SelectObject(hdcDest, hOld)                                                 ' restore selection        
        DeleteDC(hdcDest)                                                           ' clean up         
        ReleaseDC(handle, hdcSrc)
        Dim img As Image = Image.FromHbitmap(hBitmap)                               ' get a .NET image object for it        
        DeleteObject(hBitmap)                                                       ' free up the Bitmap object        
        Return img

    End Function

    'Public Sub SetHScroll(ByRef Frm As Warn_msg_frm, ByRef Ctrl As ListBox)
    '    Dim nTextWidth As Integer
    '    Dim StrText As String = ""
    '    Dim LongestStringSize As Integer

    '    For i As Integer = 0 To Ctrl.Items.Count - 1
    '        If Ctrl.GetListItem(i).Length > LongestStringSize Then
    '            LongestStringSize = Ctrl.GetListItem(i).Length
    '            StrText = Ctrl.GetListItem(i)
    '        End If
    '    Next

    '    If StrText <> "" Then
    '        nTextWidth = ConvertPixelsToTwips(Frm.CreateGraphics().MeasureString(StrText & " ", Frm.Font).Width)
    '        SendMessage(Ctrl.Handle.ToInt32(), LB_SETHORIZONTALEXTENT, nTextWidth, 0)
    '    End If

    'End Sub
    Public Sub Set_Resolution()



        Config_frm.Show()
        Config_frm.Close()

    End Sub

    Public Sub Reset_Resolution()

        If (SaveWidth < PreferredScreenWidth Or SaveHeight < PreferredScreenHeight) And Config_frm.ChangedResolution Then
            DevM.dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT Or DM_DISPLAYFREQUENCY
            DevM.dmPelsWidth = SaveWidth
            DevM.dmPelsHeight = SaveHeight
            DevM.dmDisplayFrequency = SaveRefresh
            ChangeDisplayResolution(SaveWidth, SaveHeight)
        End If

    End Sub

    Public Function ChangeDisplayResolution(ByVal NewWidth As Integer, ByVal NewHeight As Integer) As Boolean
        Dim typDM As DEVMODE = New DEVMODE
        Dim lRet As Integer = EnumDisplaySettings(0, 0, typDM)

        If lRet = 0 Then
            Return False
        End If

        typDM.dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT Or DM_DISPLAYFREQUENCY
        typDM.dmPelsWidth = NewWidth
        typDM.dmPelsHeight = NewHeight
        typDM.dmDisplayFrequency = SaveRefresh

        lRet = ChangeDisplaySettings(typDM, CDS_UPDATEREGISTRY)
        Select Case lRet
            Case DISP_CHANGE_SUCCESSFUL
                Return True
            Case Else
                Return False
        End Select

    End Function
End Module
