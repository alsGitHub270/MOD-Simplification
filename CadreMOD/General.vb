Imports System.Globalization
Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json

Module General

    Public Function AssignListIndex(ByRef ThisListBox As ComboBox, ByRef ThisValue As String) As Boolean
        Dim result As Boolean = False

        If [ThisListBox].Items.Count > 0 Then
            For i As Integer = 0 To ([ThisListBox].Items.Count - 1)
                If [ThisListBox].Items(i).ToString = ThisValue Then
                    [ThisListBox].SelectedIndex = i
                    Return True
                End If
            Next
        End If
        Return result

    End Function
    Public Function AssignListIndex_First(ByRef ThisListBox As ComboBox, ByRef ThisValue As String) As Boolean
        Dim result As Boolean = False

        If Not AssignListIndex(ThisListBox, ThisValue) Then
            If [ThisListBox].Items.Count > 0 Then
                result = True
                [ThisListBox].SelectedIndex = 0
                DataChangedByProgram = True
            End If
        End If
        Return result

    End Function
    Public Sub SelectInputArea(ByRef ThisControl As Object, ByRef ThisStartSel As Byte, ByRef ThisStartLen As Byte)

        ThisControl.SelectionStart = ThisStartSel
        If TypeOf ThisControl Is MaskedTextBox Then
            CType(ThisControl, MaskedTextBox).SelectionLength = Strings.Len(CType(ThisControl, MaskedTextBox).Text)
        Else
            ThisControl.SelectionLength = ThisStartLen
        End If

    End Sub

    Public Sub WhichKeyPressed(ByRef ThisKeyCode As Integer, Optional ByRef AllowHelpScreen As Boolean = False)

        Select Case ThisKeyCode
            'Case Keys.F1
            '    If AllowHelpScreen Then
            '        HelpScreen_frm.ShowDialog()
            '    End If
            'Case Keys.F3
            '    ExitLogic(True)
            'Case Keys.PageDown
            '    Main_MDI_frm.NextForm()
            'Case Keys.PageUp
            '    Main_MDI_frm.PreviousForm()
            Case Keys.Up
                SendKeys.Send("+{TAB}")
            Case Keys.Return
                SendKeys.Send("{TAB}")
            Case Keys.Down
                SendKeys.Send("{ENTER}")
            Case Else
        End Select

    End Sub
    Public Sub DAO2ADO(ByRef ADODBConnection As ADODB.Connection, ByRef ADOCatalogConnection As ADOX.Catalog, ByRef sDBPath As String, ByRef sDBName As String, ByVal AsReadOnly As Boolean)
        Dim sConnectionString As String = ""

        Try
            If Strings.Right(sDBPath, 1) <> "\" Then
                sDBPath = sDBPath & "\"
            End If
            ADODBConnection = New ADODB.Connection
            If AsReadOnly Then
                ADODBConnection.Mode = ADODB.ConnectModeEnum.adModeRead
            Else
                ADODBConnection.Mode = ADODB.ConnectModeEnum.adModeReadWrite
            End If
            ADODBConnection.Provider = "Microsoft.ACE.OLEDB.12.0"
            ADODBConnection.Properties("Data Source").Value = sDBPath & sDBName
            ADODBConnection.Properties("Persist Security Info").Value = False
            ADODBConnection.Properties("Jet OLEDB:System database").Value = sDBPath + "System.mdw"
            ADODBConnection.Properties("Jet OLEDB:Database Password").Value = "oscar"
            ADODBConnection.Open()
            ADODBConnection.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            ADOCatalogConnection = New ADOX.Catalog

            ADOCatalogConnection.ActiveConnection = ADODBConnection

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "DAO2ADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub
    Private Function ConvertFieldPropertyToString(ByVal PropValue As String) As String
        Return PropValue
    End Function
    Private Function FixQueryName(ByRef ThisQueryName As String) As String
        Dim s As String = ThisQueryName.Trim()

        If Not s.StartsWith("[") Then
            If s.IndexOf(" ") >= 0 Then
                s = "[" & s & "]"
            End If
        Else
            s = s.Substring(1, Math.Min(s.Length - 2, s.Length - 1))
        End If
        Return s

    End Function
    Public Function SQLfromCatalog(ByRef ThisQueryName As String, ByRef lADOCatalogDB As ADOX.Catalog) As String
        Dim cmd As New ADODB.Command

        Try
            cmd = lADOCatalogDB.Procedures.Item(ThisQueryName).Command
        Catch
            Try
                cmd = lADOCatalogDB.Views.Item(ThisQueryName).Command
            Catch
                MessageBox.Show(Conversion.ErrorToString(), "SQLfromCatalog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Try
        Return cmd.CommandText

    End Function
    'Public Sub db2List(ByRef ThisDataBase As ADODB.Connection, ByRef ThisCriteria As String, ByRef ThisControl As ComboBox, ByRef ThisDBFieldName As String, Optional ByRef ThisDBIndexName As String = "", Optional ByRef ThisWhere As String = "", Optional ByRef ThisOrderBy As String = "", Optional ByRef ThisUniqueValues As String = "", Optional ByRef lADOCatalogDB As ADOX.Catalog = Nothing)
    '    Dim r As Integer
    '    Dim tempRecordSet As New ADODB.Recordset
    '    Dim TempStr As String = ""

    '    Query_Execute(ThisDataBase, tempRecordSet, 1, OPEN_RECORD, ThisCriteria, IIf(ThisWhere Is Nothing, String.Empty, CStr(ThisWhere)), , _
    '                 IIf(ThisOrderBy Is Nothing, String.Empty, ThisOrderBy), IIf(ThisUniqueValues Is Nothing, String.Empty, ThisUniqueValues), , lADOCatalogDB)

    '    While Not tempRecordSet.EOF
    '        TempStr = tempRecordSet(ThisDBFieldName).Value.ToString
    '        r = ThisControl.Items.Add(TempStr)
    '        If ThisDBIndexName <> "" Then
    '            ThisControl.SetItemData(r, tempRecordSet.Fields(ThisDBIndexName).Value)
    '        End If
    '        tempRecordSet.MoveNext()
    '    End While

    '    Query_Execute(ThisDataBase, tempRecordSet, 1, CLOSE_RECORD)

    'End Sub
    Public Function ValidateTextBoxInput_Text(ByRef ThisForm As Form, ByRef ThisControl As Control, ByRef CheckForThisErrorType As Byte, ByRef AllowZeroLength As Boolean, Optional ByRef minvalue As String = "", Optional ByRef MaxValue As String = "") As Byte
        Dim rc As Byte = ValidateEntry_Common(ThisControl.Text, CheckForThisErrorType, AllowZeroLength, minvalue, MaxValue)

        If rc <> ENTRY_VALID Then
            'MessageHandler_Common(Message_Common_RecordSet, Label_Specific_RecordSet, ThisForm, ThisControl, rc, minvalue, MaxValue)
            Return rc
        ElseIf AllowZeroLength Then
            Return ENTRY_VALID
        Else
            Return ENTRY_VALID
        End If

    End Function
    Public Function ValidateEntry_Common(ByRef ThisControlText As String, ByRef CheckForThisErrorType As Byte, ByRef AllowZeroLength As Boolean, Optional ByRef minvalue As String = "", Optional ByRef MaxValue As String = "") As Byte

        Dim ReturnCode As Byte = ENTRY_VALID

        ' Critical Errors -----------------------------------------------------------------------------------------------------------------------------
        Select Case CheckForThisErrorType
            Case ENTRY_NOT_A_NUMBER
                Dim dbNumericTemp As Double
                If ThisControlText.Length = 0 Then
                    If AllowZeroLength Then
                        ThisControlText = CStr(0)
                        Return ReturnCode
                    Else
                        ReturnCode = ENTRY_NOT_A_NUMBER
                    End If
                ElseIf (Not Double.TryParse(ThisControlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, dbNumericTemp)) Or (ThisControlText.IndexOf(","c) >= 0) Then
                    ReturnCode = ENTRY_NOT_A_NUMBER
                End If
            Case ENTRY_NOT_AN_INTEGER
                Dim dbNumericTemp2 As Double
                If [ThisControlText].Length = 0 Then
                    If AllowZeroLength Then
                        ThisControlText = CStr(0)
                        Return ReturnCode
                    Else
                        ReturnCode = ENTRY_NOT_AN_INTEGER
                    End If
                ElseIf (Not Double.TryParse(ThisControlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, dbNumericTemp2)) Or (ThisControlText.IndexOf(","c) >= 0) Then
                    ReturnCode = ENTRY_NOT_AN_INTEGER
                Else
                    If (ThisControlText) < -32768 Or (ThisControlText) > 32767 Then
                        ReturnCode = ENTRY_NOT_AN_INTEGER
                    ElseIf (Conversion.Val(ThisControlText) - Conversion.Val(ThisControlText) <> 0) Then
                        ReturnCode = ENTRY_NOT_AN_INTEGER
                    End If
                End If
            Case ENTRY_NOT_A_DATE
                If ThisControlText = "__/__/__" Then
                    If AllowZeroLength Then
                        Return ReturnCode
                    Else
                        ReturnCode = ENTRY_NOT_A_DATE
                    End If
                ElseIf Not Information.IsDate([ThisControlText]) Then
                    ReturnCode = ENTRY_NOT_A_DATE
                End If
            Case ENTRY_NOT_IN_THE_NUMBER_RANGE
                Dim dbNumericTemp3 As Double
                If ThisControlText.Length = 0 Then
                    If AllowZeroLength Then
                        ThisControlText = CStr(0)
                        Return ReturnCode
                    Else
                        ReturnCode = ENTRY_NOT_A_NUMBER
                    End If
                ElseIf Not Double.TryParse(ThisControlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, dbNumericTemp3) Then
                    ReturnCode = ENTRY_NOT_A_NUMBER
                ElseIf Conversion.Val([ThisControlText]) < (minvalue) Or Conversion.Val([ThisControlText]) > (MaxValue) Then
                    ReturnCode = ENTRY_NOT_IN_THE_NUMBER_RANGE
                End If
            Case ENTRY_NOT_BLANK
                If ThisControlText.Length = 0 Then
                    ReturnCode = ENTRY_NOT_BLANK
                End If
            Case Else
        End Select

        Return ReturnCode

    End Function
    Public Function CalculateNumberOfCarsInEstimate(ByRef Units As String) As Integer
        Dim TempLine As String = ""
        Dim UnitsLine As New System.Text.StringBuilder
        Dim Pos As Integer
        Dim RngeStart, RngeEnd As Byte
        Dim ReturnVal As Integer = 0

        If Not String.IsNullOrEmpty(Units) Then
            Erase UnitsInEstimate
            Const Comma As String = ","
            Dim LowUnit As Byte = 255
            Dim HighUnit As Byte = 0
            UnitsInEstimate = Units.Split(New String() {Comma}, StringSplitOptions.None)
            For Each UnitsInEstimate_item As String In UnitsInEstimate
                UnitsLine.Append(Comma & UnitsInEstimate_item)
                Pos = (UnitsInEstimate_item.IndexOf("-") + 1)
                If Pos = 0 Then
                    TempLine = TempLine & Comma & UnitsInEstimate_item
                    If (UnitsInEstimate_item) < LowUnit Then LowUnit = Conversion.Val(UnitsInEstimate_item)
                    If (UnitsInEstimate_item) > HighUnit Then HighUnit = Conversion.Val(UnitsInEstimate_item)
                Else
                    RngeStart = Conversion.Val(Strings.Left(UnitsInEstimate_item, 2))
                    RngeEnd = Conversion.Val(Strings.Right(UnitsInEstimate_item, 2))
                    For k As Integer = RngeStart To RngeEnd
                        TempLine = TempLine & Comma & CStr(k)
                    Next k
                    If RngeStart < LowUnit Then LowUnit = RngeStart
                    If RngeEnd > HighUnit Then HighUnit = RngeEnd
                End If
            Next UnitsInEstimate_item
            TempLine = Strings.Mid(TempLine, 2)
            UnitsInEstimate = TempLine.Split(",")
            ReturnVal = UnitsInEstimate.GetUpperBound(0) + 1
        End If
        Return ReturnVal

    End Function
    Public Sub EndProgram()
        Reset_Resolution()
        Environment.Exit(0)
    End Sub
    Public Function TranslateOfficeNumber(ByVal sOfficeNumberOld As String, Optional ByVal bSalesOffice As Boolean = False, Optional ByVal bIgnoreShape As Boolean = False) As String
        Dim sWhere As String = "[Office] = " & FixSQLString(sOfficeNumberOld)
        Dim sNewOffice As String = "New Office"

        TranslateOfficeNumber = sOfficeNumberOld
        Select Case TranslateOfficeNumber
            Case "0410", "0710"
                TranslateOfficeNumber = "0610"
            Case "1120"
                TranslateOfficeNumber = "1110"
            Case "0410, 0710"
                TranslateOfficeNumber = "0610"
            Case "1120"
                TranslateOfficeNumber = "1110"
            Case "1121", "1220", "1230"
                TranslateOfficeNumber = "1210"
            Case "1320"
                TranslateOfficeNumber = "1311"
            Case "1430"
                TranslateOfficeNumber = "1410"
            Case "1450"
                TranslateOfficeNumber = "1440"
            Case "1611", "1612", "1613", "1614"
                TranslateOfficeNumber = "1610"
            Case "1712", "1713", "1714", "1715", "1716", "1717", "1718", "1731"
                TranslateOfficeNumber = "1730"
            Case "1751", "1752", "1811", "1812"
                TranslateOfficeNumber = "1750"
            Case "0320", "2211", "2212", "2214"
                TranslateOfficeNumber = "2210"
            Case "2312", "2313"
                TranslateOfficeNumber = "2310"
            Case "2411", "2414", "2416", "2417"
                TranslateOfficeNumber = "2410"
            Case "2413"
                TranslateOfficeNumber = "2540"
            Case "2541"
                TranslateOfficeNumber = "2543"
            Case "2721"
                TranslateOfficeNumber = "2720"
            Case "2811"
                TranslateOfficeNumber = "2810"
            Case "2610"
                TranslateOfficeNumber = "2812"
            Case "2912"
                TranslateOfficeNumber = "2911"
            Case "3332"
                TranslateOfficeNumber = "3330"
            Case "3412", "3414", "3415", "3416", "3417"
                TranslateOfficeNumber = "3410"
            Case "3611"
                TranslateOfficeNumber = "3610"
            Case "3630"
                TranslateOfficeNumber = "3631"
            Case "3711"
                TranslateOfficeNumber = "3710"
            Case "3413"
                TranslateOfficeNumber = "3810"
            Case "4811", "4812", "4813", "6331"
                TranslateOfficeNumber = "4810"
            Case "4912"
                TranslateOfficeNumber = "4910"
            Case "5115"
                TranslateOfficeNumber = "5110"
            Case "5112", "5113", "5114"
                TranslateOfficeNumber = "5111"
            Case "5231"
                TranslateOfficeNumber = "5230"
            Case "5311", "5312", "5413"
                TranslateOfficeNumber = "5310"
            Case "5411", "5412", "6711"
                TranslateOfficeNumber = "5410"
            Case "5512"
                TranslateOfficeNumber = "5511"
            Case "5612"
                TranslateOfficeNumber = "5610"
            Case "5614"
                TranslateOfficeNumber = "5611"
            Case "5811"
                TranslateOfficeNumber = "5810"
            Case "5911", "1420"
                TranslateOfficeNumber = "5910"
            Case "6111-6112"
                TranslateOfficeNumber = "6110"
            Case "6113"
                TranslateOfficeNumber = "6122"
            Case "6435", "6436"
                TranslateOfficeNumber = "6432"
            Case "6642", "6433"
                TranslateOfficeNumber = "6640"
            Case "6712-6713"
                TranslateOfficeNumber = "6710"
            Case "8111", "8112"
                TranslateOfficeNumber = "8110"
            Case "8241"
                TranslateOfficeNumber = "8240"
            Case "8311", "8341"
                TranslateOfficeNumber = "8310"
            Case "4911", "4913", "8330"
                TranslateOfficeNumber = "8312"
            Case "8321"
                TranslateOfficeNumber = "8320"
            Case "8411", "8412"
                TranslateOfficeNumber = "8410"
            Case "2216"
                TranslateOfficeNumber = "8520"
            Case "8113", "8120", "8611", "8612"
                TranslateOfficeNumber = "8610"
            Case Else
        End Select
        If Not gbShape And Not bIgnoreShape Then
            Exit Function
        End If
        If Not bSalesOffice Then
            If String.IsNullOrEmpty(ProjectData.SalesOffice) Then
                Exit Function
            End If
            If ProjectData.SalesOffice.Length <> 4 Then
                Exit Function
            End If
            If ProjectData.SalesOffice.Substring(0, 1) = "X" Then
                Exit Function
            End If
            'If ProjectData.SalesOffice.Substring(0, 1) <> "9" Then
            '    Exit Function
            'End If
        End If
        'If Not String.IsNullOrEmpty(sOfficeNumberOld) Then
        '    If Record_FindFirst(ADOConnectionMODDataDataBase, ADOCatalogMODDataDataBase, "MOD_OFFICE_SQL", sWhere, 0, sNewOffice) = RECORD_NOT_FOUND Then
        '        TranslateOfficeNumber = sOfficeNumberOld
        '    ElseIf sNewOffice <> "" Then
        '        TranslateOfficeNumber = sNewOffice
        '    End If
        'End If

    End Function
    Public Function FixSQLString(ByVal ThisFieldValue As String) As String
        Dim j As Byte
        Dim i As Byte = (ThisFieldValue.IndexOf("'"c) + 1)

        Do While (i > 0)
            j = i + 2
            ThisFieldValue = Strings.Left(ThisFieldValue, i) & "'" & Strings.Mid(ThisFieldValue, i + 1)
            i = Strings.InStr(j, ThisFieldValue, "'")
        Loop
        Return "'" & ThisFieldValue & "'"

    End Function
    Public Function Get_FileName(ByRef ThisNegNum As String, ByRef ThisBank As String, ByRef ThisAlt As String, ByRef ThisUnits As String) As String
        Return ThisNegNum & ThisBank & ThisAlt & ThisUnits
    End Function
    Public Function GetDataFromOptions(ByVal sSQL As String, Optional ByVal multiple_fields As Boolean = False) As List(Of String)
        Dim dataSource As String = HAPDatabasePath & "\" & MODDATA_DATABASE_NAME
        Dim cnstr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dataSource & ";Jet OLEDB:Database Password=oscar"
        Dim result As String
        Dim myList As New List(Of String)()

        Using cn As New OleDb.OleDbConnection(cnstr)
            cn.Open()

            Dim cmd As New OleDb.OleDbCommand(sSQL, cn)
            Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader
            While reader.Read
                If Not String.IsNullOrEmpty(reader(0).ToString) Then
                    If multiple_fields Then
                        For i As Integer = 0 To (reader.FieldCount - 1)
                            myList.Add(reader(i).ToString)
                        Next i
                    Else
                        result = (reader(0).ToString)
                        myList.Add(result)
                    End If
                End If
            End While

        End Using

        Return myList
    End Function
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Public Function FormatUnits(ByRef UnitsInString As String) As String
        Dim UnitsLine As String = String.Empty
        Dim TempLine As String = String.Empty
        Dim Seqd As Boolean
        Dim Pos As Integer
        Dim RngeStart, RngeEnd As Byte
        Dim UnitNum() As String = Nothing
        Dim LowUnit As Byte = 255
        Dim HighUnit As Byte = 0

        Const Comma As String = ","
        Erase UnitNum
        UnitNum = UnitsInString.Split(New String() {Comma}, StringSplitOptions.None)
        For Each UnitNum_item As String In UnitNum
            UnitsLine = UnitsLine & Comma & UnitNum_item
            Pos = (UnitNum_item.IndexOf("-") + 1)
            If Pos = 0 Then
                TempLine = TempLine & Comma & UnitNum_item
                If (UnitNum_item) < LowUnit Then
                    LowUnit = Conversion.Val(UnitNum_item)
                End If
                If (UnitNum_item) > HighUnit Then
                    HighUnit = Conversion.Val(UnitNum_item)
                End If
            Else
                RngeStart = Conversion.Val(Strings.Left(UnitNum_item, 2))
                RngeEnd = Conversion.Val(Strings.Right(UnitNum_item, 2))
                For k As Integer = RngeStart To RngeEnd
                    TempLine = TempLine & Comma & CStr(k)
                Next k
                If RngeStart < LowUnit Then
                    LowUnit = RngeStart
                End If
                If RngeEnd > HighUnit Then
                    HighUnit = RngeEnd
                End If
            End If
        Next UnitNum_item
        TempLine = Strings.Mid(TempLine, 2)
        UnitNum = TempLine.Split(","c)
        Array.Sort(UnitNum)
        Dim TempNum As Byte = LowUnit
        Do Until TempNum = HighUnit
            For Each UnitNum_item_2 As String In UnitNum
                If Conversion.Val(UnitNum_item_2) = TempNum Then
                    Seqd = True
                    Exit For
                Else
                    Seqd = False
                End If
            Next UnitNum_item_2
            If Not Seqd Then
                Exit Do
            End If
            TempNum += 1
        Loop
        If Seqd Then
            If LowUnit < 10 Then
                UnitsLine = "0" & LowUnit
            Else
                UnitsLine = CStr(LowUnit)
            End If
            If HighUnit < 10 Then
                UnitsLine &= "-" & "0" & CStr(HighUnit)
            Else
                UnitsLine &= "-" & CStr(HighUnit)
            End If
        Else
            UnitsLine = Strings.Mid(UnitsLine, 2)
        End If
        Return UnitsLine

    End Function
    Public Function SplitUnitsForSave(ByVal CurUnits As String) As String
        Dim ReturnVal As String = String.Empty

        CalculateNumberOfCarsInEstimate(CurUnits)
        For iIndex As Integer = UnitsInEstimate.GetLowerBound(0) To UnitsInEstimate.GetUpperBound(0)
            ReturnVal &= UnitsInEstimate(iIndex) & ","
        Next iIndex
        ReturnVal = Strings.Left(ReturnVal, ReturnVal.Length - 1)
        Return ReturnVal

    End Function
    Public Function Serialize(ByVal UseFileName As String, ByRef UseDataset As System.Data.DataSet, ByVal ErrMsg As String, ByRef CurDirtyFlag As Boolean) As Boolean
        Dim json As String = ""
        Dim ReturnVal As Boolean = True

        Try
            json = JsonConvert.SerializeObject(UseDataset, Formatting.Indented)
            Using sw As StreamWriter = New StreamWriter(UseFileName)
                sw.Write(json)
            End Using
            CurDirtyFlag = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, ErrMsg)
            ReturnVal = False

        End Try
        Return ReturnVal

    End Function
    Public Function Deserialize(ByVal UseFileName As String, ByRef UseDataset As System.Data.DataSet, ByVal ErrMsg As String, ByRef CurDirtyFlag As Boolean) As Boolean
        Dim json As String = ""
        Dim dsTemp As DataSet
        Dim ReturnVal As Boolean = True

        Try
            If File.Exists(UseFileName) Then
                Using sr As StreamReader = New StreamReader(UseFileName)
                    json = sr.ReadToEnd
                End Using
                'JsonSerializerSettings()
                'NullValueHandling = NullValueHandling.Include
                dsTemp = JsonConvert.DeserializeObject(Of DataSet)(json)
                UseDataset.Merge(dsTemp, True, MissingSchemaAction.Ignore)   'HACK:  may want to revise this to something like 
                '     dataset.Merge(JsonConvert.DeserializeObject(Of DataSet)(json), true, MissingSchemaAction.AddWithKey)
                CurDirtyFlag = False
            Else
                ReturnVal = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ErrMsg)
            ReturnVal = False

        End Try
        Return ReturnVal

    End Function
    Public Sub ArchiveFiles()
        Dim JSONFileLocation As DirectoryInfo = New DirectoryInfo(EstimatePath)

        Try
            For Each JSONFile In JSONFileLocation.GetFiles()
                If JSONFile IsNot Nothing Then
                    If Path.GetExtension(JSONFile.ToString.ToUpper) = ".JSON" Then
                        If JSONFile.ToString.ToUpper.Contains(Contracts.EstimateNum.ToUpper) Then
                            File.Copy(JSONFile.FullName, ArchivePath & JSONFile.ToString, True)
                        End If
                    End If
                End If
            Next JSONFile

        Finally

        End Try

    End Sub
    Public Function GetSummaryTotals(ByVal columnName As String) As Single
        Dim sngValue As Double = 0
        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row.Item(columnName)) Then
                sngValue += row.Item(columnName)
            End If
        Next row
        Return sngValue
    End Function
    Public Function GetSummaryTotals(ByVal column As Integer) As Single
        Dim sngValue As Double = 0
        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row.Item(column)) Then
                sngValue += row.Item(column)
            End If
        Next row
        Return sngValue
    End Function
    Public Sub SaveAll()

        CM_MAIN_frm.SaveAll()
        Select CurrentGOData_Typ.EstimateLevel
            Case "Master"
                frmEstimatingBase.SaveEstimatingData()
                frmEstimatingBase.SaveOrderingData()
            Case "Base"
                frmEstimatingBase.SaveEstimatingData()
            Case "Alt"
                frmEstimatingAlt.SaveAltData()
            Case Else
        End Select
        ArchiveFiles()

    End Sub
    Public Sub CompareFiles()
        Dim Filesystem As New Scripting.FileSystemObject()
        Dim Name As String

        Name = Dir(ReportsPath, FileAttribute.Directory)
        Do While Name <> ""
            If Name <> "." And Name <> ".." Then
                If Filesystem.FileExists(ArchivePath & Name) = True Then
                    If FileDateTime(ReportsPath & Name) <> FileDateTime(ArchivePath & Name) Then
                        If FileDateTime(ArchivePath & Name) > FileDateTime(ReportsPath & Name) Then
                            Filesystem.CopyFile(ArchivePath & Name, ReportsPath, True)
                        Else
                            Filesystem.CopyFile(ReportsPath & Name, ArchivePath, True)
                        End If
                    End If
                End If
            End If
            Name = Dir()
        Loop

    End Sub
    Public Sub DeleteAllFiles()
        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(ReportsPath)
            File.Delete(FoundFile)
        Next FoundFile
    End Sub
    Public Sub DeleteFiles()
        Dim FileNameLike As String = String.Empty

        Select Case CurrentGOData_Typ.EstimateLevel
            Case "Alt"
                FileNameLike = Contracts.EstimateNum & CurrentGOData_Typ.Bank & CurrentGOData_Typ.Alt & "*" & FileSuffix_ALT & ".JSON"
            Case "Master"
                FileNameLike = Contracts.EstimateNum & CurrentGOData_Typ.Bank & "A*" & FileSuffix_MASTER & ".JSON"
            Case "Summary"
                FileNameLike = Contracts.EstimateNum & CurrentGOData_Typ.Bank & "*" & ".JSON"
            Case Else
                Exit Sub
        End Select
        ArchiveFiles()
        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(ReportsPath)
            If FoundFile Like ReportsPath & FileNameLike Then
                File.Delete(FoundFile)
            End If
        Next FoundFile

    End Sub
End Module
