Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms

Module Startup
    Private HoldDirectory As String = String.Empty
    Public gbShape As Boolean = False
    Public gsServer As String = ""

    <STAThread()> _
    Public Sub Main() 
        Dim hwnd As Integer = 0, Result As Integer = 0
        Dim HoldDataPath As String = String.Empty
        Dim RunningMOD() As String = {"CadreMO", "PreBidMO"}
        Dim InstanceCount As Integer = 0

        Try
            For iIndex As Integer = 0 To RunningMOD.GetUpperBound(0)
                Dim processes() As Diagnostics.Process = Diagnostics.Process.GetProcessesByName(RunningMOD(iIndex))
                If RunningMOD(iIndex) = "PreBidMO" Then
                    InstanceCount = 0
                Else
                    InstanceCount = 1
                End If
                If processes.Length > InstanceCount Then
                    Dim mProcess As Diagnostics.Process = Nothing
                    For Each p As Diagnostics.Process In processes
                        If mProcess Is Nothing Then
                            mProcess = p
                        Else
                            If p.StartTime < mProcess.StartTime Then
                                mProcess = p
                            End If
                        End If
                    Next
                    hwnd = mProcess.MainWindowHandle
                    'If RunningMOD(iIndex) = "PreBidMO" Then
                    '    MessageBox.Show("PreBid MOD Is Already Running!" & Environment.NewLine & _
                    '                    "You must complete the existing estimate first.", "PreBid MOD Already Active", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Result = ShowWindow(hwnd, SW_MAXIMIZE)
                    'Else
                    '    MessageBox.Show("CADRE MOD Is Already Running!" & Environment.NewLine & _
                    '                    "You must complete the existing estimate first.", "CADRE MOD Already Active", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Result = ShowWindow(hwnd, SW_RESTORE)
                    'End If
                    Result = SetFocus(hwnd)
                    Environment.Exit(0)
                End If
            Next
            Set_Resolution()
            tPathName = My.Application.Info.DirectoryPath & "\"
            'Splash.Show()
            'Splash.Text = "Loading Cadre MOD"
            'Splash.Splash_lbl.Text = ""
            'Splash.Refresh()
            Cursor.Current = Cursors.WaitCursor
            GetPath("Paths", "Data", tPathName)
            HoldDataPath = VerifyPath(HoldDirectory)
            EstimatePath = HoldDataPath
            HAPDatabasePath = HoldDataPath
            DebugPath = VerifyPath(HoldDataPath & "Debug\")
            SuptPath = VerifyPath(HoldDataPath & "Supt\")
            GetPath("Options", "SystemDB", tPathName & "System.mda")
            SystemDatabaseName = HoldDirectory.Trim()
            SystemDatabaseName = Strings.Left(SystemDatabaseName, SystemDatabaseName.Length - 1)
            GetPath("Paths", "Reports", tPathName)
            ReportsPath = VerifyPath(HoldDirectory)
            GetPath("Paths", "SAP", tPathName)
            SAPPath = VerifyPath(HoldDirectory)
            GetPath("Paths", "FlatFiles", tPathName)
            EPCOPath = VerifyPath(HoldDirectory, False)
            GetPath("Paths", "Archive", tPathName)
            ArchivePath = VerifyPath(HoldDirectory)
            PathPDF = tPathName
            GetPath("Paths", "SpecAndData", tPathName)
            SpecAndDataPath = VerifyPath(HoldDirectory)
            gbShape = SHAPE_Recognition()
            If SetUpLotusLink() Then
                hwnd = FindWindow(Nothing, "PreBid MOD")
                If hwnd > 0 Then
                    MessageBox.Show("PreBid MOD Is Already Running!" & Environment.NewLine & _
                                    "You must close PreBid MOD first.", "PreBid MOD Already Active", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Result = ShowWindow(hwnd, SW_RESTORE)
                    Result = SetFocus(hwnd)
                    Environment.Exit(0)
                End If
            End If
            QueryFeedback(True)
            DAO2ADO(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, EstimatePath, OPTION_DATABASE_NAME, True)
            '     CM_MAIN_IO.InitializeStructCRMData()
            'If gbShape Then
            '    Get_CRMProjectData()
            'End If
            GetSalesRepData()
            EstimateModified = False
            '  Splash.Close()
            Application.Run(New CM_MAIN_frm)

        Catch
            MessageBox.Show("Error in Startup.Main: " & Environment.NewLine & CStr(Information.Err().Number) & ": " & Conversion.ErrorToString(Information.Err().Number) & Environment.NewLine & Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName)

        End Try

    End Sub
    Private Sub GetPath(ByVal ApplicationName As String, ByVal KeyName As String, ByVal DefaultStr As String)
        Dim cc As Integer = 0

        HoldDirectory = New String(" "c, 255)
        cc = GetPrivateProfileString(ApplicationName, KeyName, DefaultStr, HoldDirectory, 255, tPathName & APPLICATION_INI_FILE_NAME)

    End Sub
    Private Function VerifyPath(ByVal UseHoldDirectory As String, Optional ByVal DoCreateDirectory As Boolean = True) As String
        Dim PathName As String = UseHoldDirectory.Trim()

        PathName = Strings.Left(PathName, PathName.Length - 1)
        If Strings.Right(PathName, 1) <> "\" Then
            PathName = PathName & "\"
        End If
        If DoCreateDirectory Then
            If Not Directory.Exists(PathName) Then
                Directory.CreateDirectory(PathName)
            End If
        End If
        Return PathName

    End Function
    Private Function SHAPE_Recognition() As Boolean
        Dim sCommand As String = Interaction.Command()
        Dim aParameters(0 To 10) As String
        Dim iStart As Integer = 1
        Dim iEnd As Integer
        Dim i As Integer
        Dim N As Integer = 0
        Dim sMsg As String = "There "

        gsCommand = sCommand
        'sCommand = "200000145~YGNSLSENGZNA~EC1"

        SHAPE_Recognition = False
        If Asc(Left(sCommand, 1)) = 34 Then    'If Left(sCommand, 1) <> "~" Then
            sCommand = Mid(sCommand, 2)
            If Asc(Right(sCommand, 1)) = 34 Then
                sCommand = Left(sCommand, Len(sCommand) - 1)
            End If
            iEnd = InStr(1, sCommand, "~")
            Do While iEnd > 0
                N = N + 1
                aParameters(N) = Mid(sCommand, iStart, iEnd - iStart)
                iStart = iEnd + 1
                iEnd = InStr(iStart, sCommand, "~")
            Loop
            If N = 0 Then
                If Trim(sCommand) = "" Then
                    MsgBox("Command Line is empty.", 48, "There are no Input Parameters.")
                    EndProgram()
                Else
                    aParameters(1) = Trim(sCommand)
                    MsgBox("Command Line looks like: " & sCommand, 48, "Only one Parameter was recognized.")
                End If
            Else
                N = N + 1
                aParameters(N) = Mid(sCommand, iStart, Len(sCommand) - iStart + 1)
                sMsg = sMsg & N & " Parameters." & Chr(13) & Chr(10)
                For i = 1 To N
                    sMsg = sMsg & aParameters(i) & Chr(13) & Chr(10)
                Next
            End If
            OpportunityID = String.Format("{0,10:0000000000}", Val(aParameters(1))).Trim
            UserRole = aParameters(2)
            gsServer = aParameters(3)
            SHAPE_Recognition = True
        End If

    End Function

End Module