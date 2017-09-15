Imports System.Globalization
Imports System.Collections.Generic
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
    Public Function Query_Execute(ByRef ThisDataBase As ADODB.Connection, ByRef ThisRecordset As ADODB.Recordset, ByRef ThisRecordSetType As Integer, _
                                 ByRef Action As Integer, Optional ByRef ThisQueryName As String = "", Optional ByRef ThisWhere As Object = Nothing, Optional ByRef ThisIndexName As Object = Nothing, _
                                 Optional ByRef ThisOrderBy As Object = Nothing, Optional ByRef ThisUniqueValues As Object = Nothing, Optional ByRef ThisSeekCompare As Object = Nothing, _
                                 Optional ByRef lADOCatalogDB As ADOX.Catalog = Nothing, Optional ByRef adoOption As Object = Nothing) As Integer
        Dim result As Integer = 0
        Dim SQL As String = ""
        Dim p As Byte
        Dim cmd As New ADODB.Command
        Dim tempRS As New ADODB.Recordset
        Dim iAction As Integer
        Dim sThisWhere As String = ""
        Dim sSingleQuote As String = ""
        Dim sQueryName As String = ""
        On Error GoTo Query_Execute_Error
        If Not (Not (ThisWhere Is Nothing) AndAlso ThisWhere.Equals(Type.Missing)) Then sThisWhere = ThisWhere
        If Action = SEEK_ME Then
            iAction = FIND_FIRST
            For i As Integer = 0 To ThisRecordset.Fields.Count - 1
                If ThisRecordset.Fields(i).Name = ThisIndexName Then
                    If ConvertFieldPropertyToString((ADODB.DataTypeEnum.adVarWChar.ToString)) = "adVarWChar" Then
                        sSingleQuote = "'"
                    End If
                    Exit For
                End If
            Next i
            If sSingleQuote = "'" Then
                sThisWhere = Replace(ThisWhere, "'", "''")
                sThisWhere = "[" & ThisIndexName & "]=" & sSingleQuote & sThisWhere & sSingleQuote
            Else
                sThisWhere = "[" & ThisIndexName & "]=" & sSingleQuote & ThisWhere & sSingleQuote
            End If
        Else
            iAction = Action
        End If
        Select Case iAction
            Case OPEN_RECORD
                ThisRecordset = New ADODB.Recordset
                If ((ThisWhere = "") And (ThisOrderBy = "") And (ThisUniqueValues = "")) Or (String.IsNullOrEmpty(ThisWhere) And String.IsNullOrEmpty(ThisOrderBy) And String.IsNullOrEmpty(ThisUniqueValues)) Then
                    iAction = 2012
                    ThisRecordset.Open(ThisQueryName, ThisDataBase, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                Else
                    SQL = SQLfromCatalog(ThisQueryName, lADOCatalogDB)
                    SQL = Strings.Left(SQL, SQL.Length - 3)
                    If Not (Not (ThisUniqueValues Is Nothing) AndAlso ThisUniqueValues.Equals(Type.Missing)) Then
                        If Not String.IsNullOrEmpty(ThisUniqueValues) Then
                            p = (SQL.IndexOf("DISTINCTROW") + 1)
                            If p > 0 Then SQL = "SELECT DISTINCT " & Strings.Mid(SQL, p + 12)
                        End If
                    End If
                    If Not (Not (ThisWhere Is Nothing) AndAlso ThisWhere.Equals(Type.Missing)) Then
                        If Not String.IsNullOrEmpty(ThisWhere) Then
                            If Not (ThisWhere = "") Then SQL = SQL & " WHERE " & ThisWhere
                        End If
                    End If
                    If Not (Not (ThisOrderBy Is Nothing) AndAlso ThisOrderBy.Equals(Type.Missing)) Then
                        If Not String.IsNullOrEmpty(ThisOrderBy) Then
                            If Not (ThisOrderBy = "") Then
                                SQL = SQL & " ORDER BY " & ThisOrderBy
                            End If
                        End If
                    End If
                    ThisRecordset.Open(SQL, ThisDataBase, ADODB.LockTypeEnum.adLockOptimistic)
                    cmd = Nothing
                End If
            Case REQUERY_ME
                ThisRecordset.Requery()
            Case MOVE_FIRST
                If ThisRecordset.RecordCount <= 0 Then
                    Return RECORD_NOT_FOUND
                End If
                ThisRecordset.MoveFirst()
            Case MOVE_NEXT
                If ThisRecordset.RecordCount <= 0 Then
                    Return END_OF_RECORD
                End If
                ThisRecordset.MoveNext()
                If ThisRecordset.EOF Then result = END_OF_RECORD
            Case MOVE_PREVIOUS
                If ThisRecordset.RecordCount = 0 Then result = END_OF_RECORD
                ThisRecordset.MovePrevious()
                If ThisRecordset.BOF Then result = END_OF_RECORD
            Case MOVE_LAST
                If ThisRecordset.RecordCount <= 0 Then Return result
                ThisRecordset.MoveLast()
            Case FIND_FIRST
                If ThisRecordset.RecordCount <= 0 Then
                    Return RECORD_NOT_FOUND
                End If
                tempRS = ThisRecordset.Clone()
                tempRS.Filter = sThisWhere
                If tempRS.RecordCount > 0 Then
                    tempRS.MoveFirst()
                    ThisRecordset.Bookmark = tempRS.Bookmark
                Else
                    Return RECORD_NOT_FOUND
                End If
                tempRS.Close()
                tempRS = Nothing
            Case FIND_LAST
                If ThisRecordset.RecordCount <= 0 Then
                    Return RECORD_NOT_FOUND
                End If
                tempRS = ThisRecordset.Clone()
                tempRS.Filter = ThisWhere
                If tempRS.RecordCount > 0 Then
                    tempRS.MoveLast()
                    ThisRecordset.Bookmark = tempRS.Bookmark
                Else
                    result = RECORD_NOT_FOUND
                End If
                tempRS.Close()
                tempRS = Nothing
            Case FIND_NEXT
                If ThisRecordset.RecordCount <= 0 Then
                    Return END_OF_RECORD
                End If
                tempRS = ThisRecordset.Clone()
                tempRS.Filter = ThisWhere
                tempRS.Sort = ThisRecordset.Sort
                If tempRS.RecordCount > 0 Then
                    tempRS.Bookmark = ThisRecordset.Bookmark
                    tempRS.MoveNext()
                    If Not tempRS.EOF Then
                        ThisRecordset.Bookmark = tempRS.Bookmark
                    Else
                        result = END_OF_RECORD
                    End If
                Else
                    If ThisRecordset.RecordCount > 0 Then
                        ThisRecordset.MoveLast()
                        ThisRecordset.MoveNext()
                    End If
                    result = END_OF_RECORD
                End If
                tempRS.Close()
                tempRS = Nothing
            Case FIND_PREV
                If ThisRecordset.RecordCount <= 0 Then
                    Return result
                End If
                tempRS = ThisRecordset.Clone()
                tempRS.Filter = ThisWhere
                tempRS.Sort = ThisRecordset.Sort
                If tempRS.RecordCount > 0 Then
                    tempRS.Bookmark = ThisRecordset.Bookmark
                    tempRS.MovePrevious()
                    If Not tempRS.EOF Then
                        ThisRecordset.Bookmark = tempRS.Bookmark
                    Else
                        result = END_OF_RECORD
                    End If
                Else
                    If ThisRecordset.RecordCount > 0 Then
                        ThisRecordset.MoveFirst()
                        ThisRecordset.MovePrevious()
                    End If
                    result = END_OF_RECORD
                End If
                tempRS.Close()
                tempRS = Nothing
            Case SEEK_ME
                ThisRecordset = New ADODB.Recordset
                ThisRecordset.ActiveConnection = ThisDataBase
                ThisRecordset.Source = ThisQueryName
                ThisRecordset.CursorLocation = ADODB.CursorLocationEnum.adUseServer
                ThisRecordset.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                ThisRecordset.Open()
                ThisRecordset.Index = ThisIndexName
                If Not (ThisSeekCompare Is Nothing) AndAlso ThisSeekCompare.Equals(Type.Missing) Then
                    ThisRecordset.Seek(ThisWhere, ADODB.SeekEnum.adSeekFirstEQ)
                Else
                    ThisRecordset.Seek(ThisWhere, ThisSeekCompare)
                End If
                If ThisRecordset.EOF Then
                    result = RECORD_NOT_FOUND
                End If
            Case FILTER_ME
                Return result
            Case CLOSE_RECORD
                ThisRecordset.Close()
            Case DELETE_RECORD
                ThisRecordset.Delete()
            Case Else
        End Select
Query_Execute_End:
        Return result
Query_Execute_Error:
        If iAction = 2012 Then
            sQueryName = FixQueryName(ThisQueryName)
            On Error Resume Next
            ThisRecordset.Open(sQueryName, ThisDataBase, ADODB.LockTypeEnum.adLockOptimistic)
            If Information.Err().Number = 0 Then Resume Query_Execute_End
            result = 2012
            Resume Query_Execute_End
        End If
        If Information.Err().Number <> 3420 And Information.Err().Number <> 3704 Then
            MessageBox.Show(Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName)
            result = CRITICAL_ERROR
            Resume Query_Execute_End
        End If
        Return result
    End Function
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
    Public Function ValidateTextBoxInput_Text(ByRef ThisForm As Form, ByRef ThisControl As Control, ByRef CheckForThisErrorType As Byte, ByRef AllowZeroLength As Boolean, Optional ByRef minvalue As String = "", Optional ByRef MaxValue As String = "") As Byte
        Dim rc As Byte = ValidateEntry_Common(ThisControl.Text, CheckForThisErrorType, AllowZeroLength, minvalue, MaxValue)
        If rc <> ENTRY_VALID Then
            Return rc
        ElseIf AllowZeroLength Then
            Return ENTRY_VALID
        Else
            Return ENTRY_VALID
        End If
    End Function
    Public Function ValidateEntry_Common(ByRef ThisControlText As String, ByRef CheckForThisErrorType As Byte, ByRef AllowZeroLength As Boolean, Optional ByRef minvalue As String = "", Optional ByRef MaxValue As String = "") As Byte
        Dim ReturnCode As Byte = ENTRY_VALID
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
        Dim UnitsInEstimate() As String
        Dim ReturnVal As Integer = 0
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
        If Not String.IsNullOrEmpty(sOfficeNumberOld) Then
            'If Record_FindFirst(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, "MOD_OFFICE_SQL", sWhere, 0, sNewOffice) = RECORD_NOT_FOUND Then
            '    TranslateOfficeNumber = sOfficeNumberOld
            'ElseIf sNewOffice <> "" Then
            '    TranslateOfficeNumber = sNewOffice
            'End If
        End If

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
        Dim AddExt As String = CStr(Conversion.Val(Strings.Left(ThisUnits, 2)))
        Return ThisNegNum & ThisBank & ThisAlt & "M" & AddExt
    End Function

    Public Function GetDataFromOptions(sSQL As String, Optional ByVal multiple_fields As Boolean = False) As List(Of String)
        Dim dataSource As String = My.Application.Info.DirectoryPath & "\" & OPTION_DATABASE_NAME
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

End Module
