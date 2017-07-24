Module General

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
End Module
