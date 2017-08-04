Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.Common
Imports System.IO
Imports System.Windows.Forms
Module Common_IO
    Public ADOConnection As New ADODB.Connection
    Public ADOConnectionRPTDataDB As New ADODB.Connection
    Public ADOConnectionOptionDataBase As New ADODB.Connection
    Public ADOConnectionMessageDataBase As New ADODB.Connection
    Public ADOConnectionHapDatabase As New ADODB.Connection
    Public ADOCatalogRPTdata As ADOX.Catalog = Nothing
    Public ADOCatalogHapDatabase As ADOX.Catalog = Nothing
    Public _ADOCatalogOptionDataBase As ADOX.Catalog = Nothing
    Public Property ADOCatalogOptionDataBase() As ADOX.Catalog
        Get
            If _ADOCatalogOptionDataBase Is Nothing Then
                _ADOCatalogOptionDataBase = New ADOX.Catalog()
            End If
            Return _ADOCatalogOptionDataBase
        End Get
        Set(ByVal Value As ADOX.Catalog)
            _ADOCatalogOptionDataBase = Value
        End Set
    End Property
    Public ADOCatalogMessageDataBase As ADOX.Catalog = Nothing
    Public WorkingRecordSet As New ADODB.Recordset
    Public CableRecordSet As New ADODB.Recordset

    Public Const MOVE_FIRST As Integer = 0
    Public Const MOVE_NEXT As Integer = 1
    Public Const MOVE_PREVIOUS As Integer = 2
    Public Const MOVE_LAST As Integer = 3
    Public Const FIND_FIRST As Integer = 4
    Public Const FIND_NEXT As Integer = 5
    Public Const FIND_PREV As Integer = 6
    Public Const FIND_LAST As Integer = 7
    Public Const SEEK_ME As Integer = 8
    Public Const FILTER_ME As Integer = 9
    Public Const OPEN_RECORD As Integer = 10
    Public Const ADD_RECORD As Integer = 11
    Public Const UPDATE_RECORD As Integer = 12
    Public Const DELETE_RECORD As Integer = 13
    Public Const SET_RECORDSET As Integer = 14
    Public Const RECORD_NOT_FOUND As Integer = 15
    Public Const DUPLICATE_RECORD_FOUND As Integer = 16
    Public Const END_OF_RECORD As Integer = 17
    Public Const CLOSE_RECORD As Integer = 18
    Public Const REQUERY_ME As Integer = 19
    Public Const UPDATE_PITDRAW As Integer = 20
    Public Const NON_CRITICAL_ERROR As Integer = 21
    Public Const CRITICAL_ERROR As Integer = 22

    Public Const OPTION_DATABASE_NAME As String = "OPTIONS.accdb"

    Structure tagCustomerUnitSetArray
        Dim CustomerUnit As Byte
        Dim Action As Byte
    End Structure

    Structure tagStatusData
        Dim AllFormsComplete() As Boolean
        Dim FormsStatus(,) As Byte
    End Structure

    Structure tagFormsArrayData
        Dim Forms As Form ' Object
        Dim FormsName As String ' system form name
        Dim FormsTitle As String ' user displayed form title
        Dim FormGridType As Byte ' EST_GRID_TYPE, BOOK_GRID_TYPE
        Dim FormIsCompleted As Boolean ' True/False
        Dim FormIsClosed As Boolean ' form open or closed
        Dim ShowForm As Boolean ' Survey Form Flag
        Public Shared Function CreateInstance() As tagFormsArrayData
            Dim result As New tagFormsArrayData()
            result.FormsName = String.Empty
            result.FormsTitle = String.Empty
            Return result
        End Function
    End Structure

    Public EstimateModified As Boolean
    Public gAcknowledge As Integer

    Structure IconStatus_typ
        Dim IsVisible As Boolean
        Dim IsEnabled As Boolean
    End Structure
    Dim Acknowledgement As DialogResult

    Public Sub DisconnectDatabase(ByRef ThisDataBase As ADODB.Connection)

        Try
            ThisDataBase.Close()
            ThisDataBase = Nothing
        Catch
            If Information.Err().Number <> 91 Then MessageBox.Show("Error in Main: " & Environment.NewLine & CStr(Information.Err().Number) & ": " & Conversion.ErrorToString(Information.Err().Number) & Environment.NewLine & Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName) ' Object Not Set
        End Try

    End Sub
    Public Sub DisconnectADO()

        On Error Resume Next

        CableRecordSet.Close()
        CableRecordSet = Nothing
        If ADOConnection.State <> ConnectionState.Closed Then
            ADOConnection.Close()
        End If
        ADOConnection = Nothing

    End Sub
    'Public Function ExitLogic(ByRef IsMDIForm As Boolean) As Integer
    '    Dim EditHistoryText As String = ""
    '    Dim bAlreadySaved As Boolean
    '    Dim bAttach_To_Feedback As Boolean = False

    '    If IsMDIForm Then
    '        If AreFormsDirty() Then
    '            Acknowledgement = MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will have an invalid Pricing Run", "Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    '            If Acknowledgement = System.Windows.Forms.DialogResult.Yes Then
    '                SaveAll()
    '                bAlreadySaved = True
    '            End If
    '        End If
    '    Else
    '        If gbMDIChildDirty Then
    '            If MessageBox.Show("Contract Manager Data has changed.  Would you like to save?", Application.ProductName, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
    '                If JobRun Then
    '                    CM_MAIN_frm.SortLogic()
    '                End If
    '                CM_MAIN_frm.SaveData()
    '                bAlreadySaved = True
    '            End If
    '        End If
    '    End If
    '    If Not bAlreadySaved Then
    '        If MN_TRQ01_typ.bDirty Then
    '            Acknowledgement = MessageBox.Show("Do you want to save engineering changes?" & Environment.NewLine & "Selecting No will have an invalid Pricing Run", "Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    '            If Acknowledgement = System.Windows.Forms.DialogResult.Yes Then
    '                SaveAll()
    '            End If
    '        End If
    '    End If
    '    bAttach_To_Feedback = Attach_To_Feedback()
    '    If Not gbShape Or bAttach_To_Feedback Then
    '        clsNotes.SetValue("maxAdderSignature", "")
    '        clsNotes.SetValue("maxAdderSignatureDate", "")
    '        clsNotes.SetValue("maxAdderDecision", "")
    '        clsNotes.SetValue("maxAdderApprovalStatus", "")
    '        clsNotes.SetValue("maxAdderApproverNotifDate", "")
    '        clsNotes.SetValue("maxAdderUserNotifDate", "")
    '        clsNotes.SetValue("maxAdderApprovalRequestDate", "")
    '        clsNotes.SetValue("maxAdderApprovalReason_txt", "")
    '        If EstimateModified Then
    '            EditHistoryText = "Modified: " & Format(DateTime.Now, DATETIMENOTESFORMAT) & " by " & Contracts.Estimator
    '            clsNotes.SetValueAppend("EditHistory", EditHistoryText)
    '        End If
    '    End If
    '    If gbShape Then
    '        SaveOrder05()
    '    End If
    '    DisconnectDatabase(ADOConnectionRPTDataDB)
    '    DisconnectDatabase(ADOConnectionOptionDataBase)
    '    DisconnectDatabase(ADOConnectionMessageDataBase)
    '    DisconnectADO()
    '    ArchiveFiles()
    '    DeleteFiles()
    '    EndProgram()
    '    Cursor.Current = Cursors.Default
    '    Return System.Windows.Forms.DialogResult.Cancel

    'End Function
    Private Function ConvertFieldPropertyToString(ByVal PropValue As String) As String
        Return PropValue
    End Function
    Public Function Query_Execute(ByRef ThisDataBase As ADODB.Connection, ByRef ThisRecordset As ADODB.Recordset, ByRef ThisRecordSetType As Integer, _
                                 ByRef Action As Integer, Optional ByRef ThisQueryName As String = "", Optional ByRef ThisWhere As Object = Nothing, Optional ByRef ThisIndexName As Object = Nothing, _
                                 Optional ByRef ThisOrderBy As Object = Nothing, Optional ByRef ThisUniqueValues As Object = Nothing, Optional ByRef ThisSeekCompare As Object = Nothing, _
                                 Optional ByRef lADOCatalogDB As ADOX.Catalog = Nothing, Optional ByRef adoOption As Object = Nothing) As Integer

        'mwh 7/24/12: It looks like ThisRecordSetType is not used (anymore?)

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
                'ThisRecordset.Filter = ThisWhere  ' Set filter condition.
                'Set ThisRecordset = ThisRecordset.OpenRecordset() ' Create filtered dynaset-type Recordset.
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
    Public Function Record_FindFirst(ByRef ThisDataBase As ADODB.Connection, ByRef lADOCatalogDB As ADOX.Catalog, ByRef ThisQueryName As String, ByRef Where As String, ByRef adoOption As Integer, Optional ByRef FieldName As String = "") As Integer
        Dim result As Integer = 0
        Dim ThisRecordset As New ADODB.Recordset
        Dim sQueryName As String

        On Error GoTo Record_FindFirst_Error

        sQueryName = ThisQueryName
        If Query_Execute(ThisDataBase, ThisRecordset, 1, OPEN_RECORD, sQueryName, , , , , , , adoOption) = 2012 Then
            sQueryName = FixQueryName(ThisQueryName)
            Query_Execute(ThisDataBase, ThisRecordset, 1, OPEN_RECORD, sQueryName, , , , , , , adoOption)
        End If
        result = Query_Execute(ThisDataBase, ThisRecordset, 1, FIND_FIRST, sQueryName, Where, , , , , , adoOption)
        If FieldName <> "" Then
            If result = 0 Then
                FieldName = ThisRecordset(FieldName).Value.ToString
            Else
                FieldName = 0
            End If
        End If

Record_FindFirst_End:
        Query_Execute(ThisDataBase, ThisRecordset, 1, CLOSE_RECORD)
        Return result

Record_FindFirst_Error:
        If Information.Err().Number = 3265 Then
            result = RECORD_NOT_FOUND
            Resume Record_FindFirst_End
        End If
        MessageBox.Show(Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName)
        Resume Record_FindFirst_End

    End Function
    'Public Sub db2Combo(ByRef ThisDataBase As ADODB.Connection, ByRef ThisRecordSetType As Integer, ByRef ThisControl As ComboBox, Optional ByRef ThisIndexOffset As String = "", Optional ByRef ThisFieldOffset As String = "", Optional ByRef ThisCriteria As String = "", Optional ByRef ThisWhere As String = "", Optional ByRef ThisOrderBy As String = "", Optional ByRef ThisUniqueValues As String = "", Optional ByRef lADOCatalogDB As ADOX.Catalog = Nothing)
    '    Dim r As Integer ' row # of newly added item
    '    Dim tempRecordSet As New ADODB.Recordset
    '    Dim TempStr As String = ""
    '    Dim cc As Integer = Query_Execute(ThisDataBase, tempRecordSet, ThisRecordSetType, OPEN_RECORD, ThisCriteria, IIf(False, String.Empty, ThisWhere), , IIf(False, String.Empty, ThisOrderBy), IIf(False, String.Empty, ThisUniqueValues), , lADOCatalogDB)

    '    If cc = RECORD_NOT_FOUND Then Exit Sub
    '    While Not tempRecordSet.EOF
    '        TempStr = tempRecordSet(ThisFieldOffset).Value.ToString
    '        r = ThisControl.Items.Add(TempStr) ' Return value from .Items.Add is row # to replace .NewIndex
    '        If ThisIndexOffset <> "" Then
    '            If tempRecordSet.Fields.Count > 1 Then
    '                ThisControl.SetItemData(r, tempRecordSet.Fields(ThisIndexOffset).Value)
    '            End If
    '        End If
    '        tempRecordSet.MoveNext()
    '    End While

    '    Query_Execute(ThisDataBase, tempRecordSet, ThisRecordSetType, CLOSE_RECORD)

    'End Sub
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
    'Public Sub DeleteFiles()
    '    For Each FoundFile As String In My.Computer.FileSystem.GetFiles(ReportsPath)
    '        File.Delete(FoundFile)
    '    Next
    'End Sub
    'Public Sub ArchiveFiles()
    '    Dim Filesystem As New Scripting.FileSystemObject()
    '    Try

    '        If Microsoft.VisualBasic.FileSystem.Dir(ReportsPath & "*.*", FileAttribute.Normal) <> "" Then
    '            Filesystem.CopyFile(ReportsPath & "*.*", ArchivePath, True)
    '        End If
    '    Finally
    '        MemoryHelper.ReleaseAndCleanObject(Filesystem)
    '        Filesystem = Nothing
    '    End Try

    'End Sub
    'Public Sub CompareFiles()
    '    Dim Filesystem As New Scripting.FileSystemObject()
    '    Dim Name As String

    '    Name = Dir(ReportsPath, FileAttribute.Directory)
    '    Do While Name <> ""
    '        If Name <> "." And Name <> ".." Then
    '            If Filesystem.FileExists(ArchivePath & Name) = True Then
    '                If FileDateTime(ReportsPath & Name) <> FileDateTime(ArchivePath & Name) Then
    '                    If FileDateTime(ArchivePath & Name) > FileDateTime(ReportsPath & Name) Then
    '                        Filesystem.CopyFile(ArchivePath & Name, ReportsPath, True)
    '                    Else
    '                        Filesystem.CopyFile(ReportsPath & Name, ArchivePath, True)
    '                    End If
    '                End If
    '            End If
    '        End If
    '        Name = Dir()
    '    Loop

    'End Sub
    Public Function Get_FileName(ByRef ThisNegNum As String, ByRef ThisBank As String, ByRef ThisAlt As String, ByRef ThisUnits As String) As String

        Dim AddExt As String = CStr(Conversion.Val(Strings.Left(ThisUnits, 2)))
        Return ThisNegNum & ThisBank & ThisAlt & ".M" & AddExt

    End Function
    'Public Sub Check_SHELL_ACCESS()

    '    If SHELL_ACCESS Then
    '        Select Contracts.Status
    '            Case Status_OfferLost, Status_OfferOnHold
    '                MessageBox.Show("Job Status is set to " & Contracts.Status & ".   You cannot use this function.", Application.ProductName)
    '            Case Else
    '                MessageBox.Show("Approval To Bid form has pending item(s).  You cannot use this function until full approval is granted.", Application.ProductName)
    '        End Select
    '    End If

    'End Sub
    Public Sub db2Combo_Gen(ByRef ThisDataBase As ADODB.Connection, ByRef ThisRecordSetType As Integer, ByRef ThisControl As Object, ByRef ThisFieldOffset As String, ByRef ThisCriteria As String, Optional ByRef MinimumDataOffSet_optional As Nullable(Of Integer) = Nothing, Optional ByRef ThisWhere As String = "", Optional ByRef ThisOrderBy As String = "", Optional ByRef ThisUniqueValues As String = "", Optional ByRef lADOCatalogDB As ADOX.Catalog = Nothing)
        Dim MinimumDataOffSet As Integer = 0

        If Not IsNothing(MinimumDataOffSet_optional) Then
            MinimumDataOffSet = MinimumDataOffSet_optional.Value
        End If
        Try
            Dim tempRecordSet As New ADODB.Recordset
            Dim i As Byte
            Dim TempStr As String = ""

            Query_Execute(ThisDataBase, tempRecordSet, ThisRecordSetType, OPEN_RECORD, ThisCriteria, IIf(IsNothing(ThisWhere), String.Empty, ThisWhere), , IIf(IsNothing(ThisOrderBy), String.Empty, ThisOrderBy), IIf(IsNothing(ThisUniqueValues), String.Empty, ThisUniqueValues), , lADOCatalogDB)
            If Not tempRecordSet.EOF Then
                tempRecordSet.Fields().Refresh()
                If TypeOf ThisControl Is ComboBox Then
                    If Not MinimumDataOffSet_optional.HasValue Then
                        i = 0
                        For Each fld As ADODB.Field In tempRecordSet.Fields()
                            If Conversion.Val(ThisFieldOffset) <= i Then
                                If Not Convert.IsDBNull(fld.Value) Then
                                    CType(ThisControl, ComboBox).Items.Add(fld.Value)
                                End If
                            End If
                            i += 1
                        Next fld
                    Else
                        MinimumDataOffSet = 1
                        For Each fld As ADODB.Field In tempRecordSet.Fields()
                            If Not Convert.IsDBNull(fld.Value) Then
                                If fld.Value > MinimumDataOffSet Then
                                    CType(ThisControl, ComboBox).Items.Add(fld.Value)
                                End If
                            End If
                        Next fld
                    End If
                Else
                    ThisControl = ""
                    For Each fld As ADODB.Field In tempRecordSet.Fields()
                        If Not Convert.IsDBNull(fld.Value) Then
                            ThisControl = CStr(ThisControl) & " " & fld.Value
                        End If
                    Next fld
                End If
            End If
            Query_Execute(ThisDataBase, tempRecordSet, ThisRecordSetType, CLOSE_RECORD)
        Finally
            MinimumDataOffSet_optional = MinimumDataOffSet
        End Try

    End Sub
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
    '    Public Function RebuildSQL(ByVal sSQLName As String) As String
    '        On Error GoTo err_RebuildSQL
    '        Dim sSQL As String = String.Empty

    '        Select Case sSQLName
    '            Case "OFFICE_UNIONLOCAL_SQL"
    '                sSQL = "SELECT DISTINCTROW [Rate (US Labor)].Office, [Rate (US Labor)].UnionLocal, [Rate (US Labor)].Location, "
    '                sSQL = sSQL & "UnionLocal.[City/Region], UnionLocal.State, [CITY/REGION] & '-' "
    '                sSQL = sSQL & "& IIf([UnionLocal].[Union ID]<=9,'00',IIf([UnionLocal].[Union ID]<=99,'0','')) & [UnionLocal].[Union ID] AS [Location/ID] "
    '                sSQL = sSQL & "FROM UnionLocal LEFT JOIN [Rate (US Labor)] ON UnionLocal.[Union ID] = [Rate (US Labor)].UnionLocal;"
    '            Case "OFFICE_UNIONLOCAL_CANADA_SQL"
    '                sSQL = "SELECT DISTINCTROW [Rate (Canada Labor)].Office, [Rate (Canada Labor)].UnionLocal, [Rate (Canada Labor)].Location, [Location] & '-' "
    '                sSQL = sSQL & "& IIf([UnionLocal]<=9,'00' ,IIf([UnionLocal]<=99,'0','')) & [UnionLocal] AS [Location/ID] "
    '                sSQL = sSQL & "FROM [Rate (Canada Labor)];"
    '            Case "Earliest_And_Latest_Valid_Year_Query"
    '                sSQL = "SELECT Min(Year) AS [Low Year], Max(Year) AS [High Year] FROM [Rate (US Year)];"
    '            Case "BUILDING_CODE_TABLE_SQL"
    '                sSQL = "SELECT DISTINCTROW [Building Code].* FROM [Building Code] ORDER BY [Building Code].Description;"
    '            Case "DUTY_SQL"
    '                sSQL = "SELECT DISTINCTROW Duty.* FROM Duty;"
    '            Case LOCAL_CODE_ONLY_QUERY_NAME
    '                sSQL = "SELECT DISTINCTROW [Local Code].[Local Code], "
    '                sSQL = sSQL & "[Local Code] & '-' & IIf([City] Is Null,' ',[City] & ',') & IIf([State] Is Null,' ',[State]) "
    '                sSQL = sSQL & "AS [Local Code/ID], [Local Code].State, [Local Code].City FROM [Local Code];"
    '            Case GEN_CABTYPE_QUERY_NAME
    '                sSQL = "SELECT DISTINCTROW Gen_CabType.* FROM Gen_CabType;"
    '            Case CEILINGCODE_QUERY_NAME
    '                sSQL = "SELECT DISTINCTROW CeilingCode.* FROM CeilingCode;"
    '            Case Else
    '        End Select
    '        Return sSQL

    'err_RebuildSQL:
    '        MessageBox.Show("Error in Main: " & Environment.NewLine & CStr(Information.Err().Number) & ": " & Conversion.ErrorToString(Information.Err().Number) & Environment.NewLine & Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName)
    '        Return ""

    '    End Function
    'Public Sub SaveOrder05()
    '    Dim TryWsdl As New ORDERS05.SI_OUT_ORDERS_SECService
    '    Dim nc As New System.Net.NetworkCredential
    '    Dim Orders As New ORDERS05.ORDERS05

    '    Dim urls As String = "http://infwddx3.inf.schindler.com:80/XISOAPAdapter/MessageServlet?senderParty=&senderService=BS_DEV_CADRE&receiverParty=&receiverService=&interface=SI_OUT_ORDERS_SEC&interfaceNamespace=http://crm.schindler.com/QM"


    '    nc.UserName = "S_YAC_CADRE"
    '    nc.Password = "LS7-Q3014"
    '    TryWsdl.Credentials = nc
    '    TryWsdl.Url = urls

    '    Write_EDI_DC40()
    '    myIDOC.EDI_DC40 = myEDI_DC40(0)
    '    Write_E1EDK01()
    '    myIDOC.E1EDK01 = myE1EDK01(0)
    '    Write_E1EDK14()
    '    myIDOC.E1EDK14 = myE1EDK14
    '    Write_E1EDK03()
    '    myIDOC.E1EDK03 = myE1EDK03
    '    Write_E1EDKA1()
    '    myIDOC.E1EDKA1 = myE1EDKA1
    '    Write_E1EDK02()
    '    myIDOC.E1EDK02 = myE1EDK02
    '    Write_E1EDK17()
    '    myIDOC.E1EDK17 = myE1EDK17
    '    Write_E1EDP01()
    '    myIDOC.E1EDP01 = myE1EDP01
    '    Write_E1CUCFG_0()
    '    Write_E1CUCFG_1()
    '    Write_E1CUCFG_2()
    '    myIDOC.E1CUCFG = myE1CUCFG
    '    Orders.IDOC = myIDOC

    '    TryWsdl.SI_OUT_ORDERS_SEC(Orders)

    'End Sub
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
End Module