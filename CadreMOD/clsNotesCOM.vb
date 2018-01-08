Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Friend Class clsNotesCOM
    Private sessionType As Type = Type.GetTypeFromProgID("Notes.NotesSession")
    Private session As Object = Activator.CreateInstance(sessionType)
    Private DB As Object
    Private View As Object
    Private doc As Object
    Private FilePath As String = ""
    Private NotesDocumentCollection As Object
    Private DocCreated As Boolean

    Public Function GetValue(ByRef valname As String) As Object
        Dim TempVal As String = doc.GetItemValue(valname)(0).ToString
        Dim iPos As Integer = (TempVal.IndexOf(Environment.NewLine) + 1)

        If iPos > 0 Then
            Do Until iPos = 0
                TempVal = Strings.Left(TempVal, iPos - 1) & " " & Strings.Mid(TempVal, iPos + 2)
                iPos = (TempVal.IndexOf(Environment.NewLine) + 1)
            Loop
        End If
        Return TempVal

    End Function
    Public Function GetValue_Readers(ByRef valname As String) As Boolean
        Dim result As Boolean = False

        Try
            Erase ReadersValue
            ReadersValue = doc.GetItemValue(valname)
            If ReadersValue.GetUpperBound(0) > -1 Then
                result = True
            End If
            Return result

        Catch
            Return result

        End Try

    End Function
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub SetValue(ByRef valname As String, ByRef Val As Object)
        doc.ReplaceItemValue(valname, Val)
        doc.Save(True, True)
    End Sub
    Public Sub SetValue_Readers(ByRef valname As String, ByRef Val As Object)
        Dim ReadersItem As Object = doc.ReplaceItemValue(valname, Val)

        ReadersItem.IsReaders = True
        doc.Save(True, True)

    End Sub
    '    Protected Overrides Sub Finalize()
    '        session = Nothing
    '        DB = Nothing
    '        View = Nothing
    '        doc = Nothing
    '    End Sub
    Public Function DetachFiles() As Boolean
        Dim result As Boolean = False
        Dim TempObj1 As Object
        Dim j As Integer
        Dim EmbeddedFiles() As String
        Dim thisFile As String = ""

        On Error GoTo DetachFilesError

        result = True
        TempObj1 = doc.GetFirstItem("FILEATTACH")
        If TempObj1 Is Nothing Then
            ReadersValue = doc.GetItemValue("FileAttachments")
            For Each ReadersValue_item As String In ReadersValue
                If ReadersValue_item <> "" Then
                    TempObj1 = doc.GetAttachment(ReadersValue_item)
                    TempObj1.ExtractFile(FilePath & ReadersValue_item)
                End If
            Next ReadersValue_item
        ElseIf (TempObj1.Type = Domino.IT_TYPE.RICHTEXT) Then
            ReadersValue = doc.GetItemValue("fileAttach")
            EmbeddedFiles = ReadersValue(0).Split("-")
            For Each EmbeddedFiles_item As String In EmbeddedFiles
                thisFile = EmbeddedFiles_item.Trim()
                If thisFile <> "" Then
                    j = (thisFile.IndexOf(".") + 1)
                    thisFile = Strings.Left(thisFile, j + 3)
                    If FileSystem.Dir(FilePath & thisFile, FileAttribute.Normal) <> "" Then
                        File.Delete(FilePath & thisFile)
                    End If
                    TempObj1 = doc.GetAttachment(thisFile)
                    TempObj1.ExtractFile(FilePath & thisFile)
                End If
            Next EmbeddedFiles_item
        End If

        Return result

DetachFilesError:
        If Information.Err.Number = 53 Then
            If FilePath.Length = 0 Then
                MessageBox.Show("File path property NOT SET!", Application.ProductName)
            Else
                MessageBox.Show("File NOT found!!  Please check if the file exists!", Application.ProductName)
            End If
        ElseIf Information.Err.Number = 91 Then
            Resume Next
        Else
            MessageBox.Show(CStr(Information.Err().Number) & ": " & Information.Err.Description, Application.ProductName)
        End If

        Return False

    End Function

    Public Function AttachSUPTFile(ByRef sFileName As String) As Boolean
        Dim result As Boolean = True
        Dim oAttachedFile As Object
        Dim oAttachedSUPTFile As Object

        oAttachedFile = doc.GetFirstItem("additionalAttachments")
        If oAttachedFile Is Nothing Then
            oAttachedFile = doc.CreateRichTextItem("additionalAttachments")
        End If
        oAttachedSUPTFile = oAttachedFile.EmbedObject(Domino.EMBED_TYPE.EMBED_ATTACHMENT, "", sFileName, "$FILE")
        Return result

    End Function

    Public Function AttachFile(ByRef FileName As String) As Boolean
        Dim result As Boolean = False
        Dim RTI_Name As String = ""
        Dim TempObj1 As Object
        Dim TempObj2 As Object
        Dim Listed As Boolean
        Dim NameAry As Object
        Dim ReattachOld As Boolean

        Try
            result = True
            Select Case Strings.Right(FileName, 3).ToUpper()
                Case "XLS"
                    If FileName Like HoldUniqueActivity.ToUpper() & "ELE.XLS" Or FileName Like HoldUniqueActivity.ToUpper() & "MEC.XLS" Then
                        RTI_Name = "ESTIMATEFILE"
                    Else
                        Return result
                    End If
                Case "BDP"
                    RTI_Name = "FILEATTACH"
                Case Else
                    RTI_Name = IIf(AttachBookingFile And BookingType > 0, "FILEATTACH", "ESTIMATEFILE")
            End Select
            If RTI_Name = "ESTIMATEFILE" Then
                TempObj1 = doc.GetFirstItem("FILEATTACH")
                If TempObj1 Is Nothing Then
                    ReattachOld = False
                Else
                    ReattachOld = True
                    Do Until TempObj1 Is Nothing
                        TempObj1.Remove()
                        doc.Save(True, True)
                        TempObj1 = doc.GetFirstItem("FILEATTACH")
                    Loop
                End If
                If Not ReattachOld And Strings.Right(FileName, 3).ToUpper() = "XLS" Then
                    Return result
                End If
                NameAry = doc.GetFirstItem("FileAttachments")
                Listed = NameAry.Contains(FileName)
                If Not Listed Then
                    NameAry.AppendToTextList(FileName)
                    If Not DocCreated Then
                        doc.Save(True, True)
                    End If
                End If
            End If
            TempObj1 = doc.GetFirstItem(RTI_Name)
            If TempObj1 Is Nothing Then
                TempObj1 = doc.CreateRichTextItem(RTI_Name)
            End If
            TempObj2 = TempObj1.EmbedObject(Domino.EMBED_TYPE.EMBED_ATTACHMENT, "", FilePath & FileName, "$FILE")
            If Not DocCreated Then
                doc.Save(True, True)
            End If

            Return result

        Catch e As System.Exception
            result = False
            If Information.Err().Number = 7225 Then
                Select Case True
                    Case FilePath.Length = 0
                        MessageBox.Show("FilePath property NOT SET!", Application.ProductName)
                    Case Else
                        MessageBox.Show("File NOT found!!  Please check if the file exists!", Application.ProductName)
                End Select
            Else
                MessageBox.Show(e.Message, "Error Attaching File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return result

        End Try

    End Function
    Public Sub DeleteALLAttachments()
        Dim i As Byte
        Dim EngFile() As String
        Dim TempObj As Object = doc.GetFirstItem("FILEATTACH")

        Do Until TempObj Is Nothing
            TempObj.Remove()
            doc.Save(True, True)
            TempObj = doc.GetFirstItem("FILEATTACH")
        Loop
        TempObj = doc.GetFirstItem("EstimateFile")
        Do Until TempObj Is Nothing
            TempObj.Remove()
            doc.Save(True, True)
            TempObj = doc.GetFirstItem("EstimateFile")
        Loop
        TempObj = doc.GetFirstItem("ATTACHMENTELECTRICAL")
        If Not (TempObj Is Nothing) Then
            ReadersValue = doc.GetItemValue("FileAttachments")
            ReDim EngFile(0)
            i = 1
            For X As Integer = ReadersValue.GetLowerBound(0) To ReadersValue.GetUpperBound(0)
                If Strings.Right(ReadersValue(X), 3).ToUpper() = "XLS" Or Strings.Right(ReadersValue(X), 4).ToUpper() = "XLSX" Or Strings.Right(ReadersValue(X), 3).ToUpper() = "A2B" Or _
                   Strings.Right(ReadersValue(X), 10).ToUpper() = "LETTER.DOC" Or Strings.Right(ReadersValue(X), 11).ToUpper() = "LETTER.DOCX" Or _
                   Strings.Right(ReadersValue(X), 11).ToUpper() = "SCRIPTS.DOC" Or Strings.Right(ReadersValue(X), 12).ToUpper() = "SCRIPTS.DOCX" Then
                    ReDim Preserve EngFile(i)
                    EngFile(i) = ReadersValue(X).Trim()
                    i += 1
                End If
            Next
            TempObj = doc.ReplaceItemValue("FileAttachments", "")
            doc.Save(True, True)
            If EngFile.GetUpperBound(0) > 0 Then
                TempObj = doc.GetFirstItem("FileAttachments")
                For i = 1 To EngFile.GetUpperBound(0)
                    TempObj.AppendToTextList(EngFile(i))
                    doc.Save(True, True)
                Next i
            End If
        End If

    End Sub
    Public ReadOnly Property NotesDBName(ByVal ComServer As String, ByVal DBName As String) As Boolean

        Get
            Dim result As Boolean = False

            result = True
            DB = session.GetDatabase(ComServer, DBName)
            If Not DB.IsOpen Then
                result = False
            End If
            Return result
        End Get

    End Property

    Public ReadOnly Property NotesDBView(ByVal ViewName As String) As Boolean

        Get
            Dim result As Boolean = False

            result = True
            View = DB.GetView(ViewName)
            If (View Is Nothing) Then
                result = False
            End If
            Return result
        End Get

    End Property

    Public ReadOnly Property NotesDocKey(ByVal KeyName As String) As Boolean

        Get
            Dim result As Boolean = False

            result = True
            View.Refresh()
            doc = View.GetDocumentByKey(KeyName)
            If (doc Is Nothing) Then
                result = False
            End If
            Return result
        End Get

    End Property
    Public ReadOnly Property NotesDocProfile(ByVal ProfileName As String) As Boolean

        Get
            Dim result As Boolean = False

            result = True
            doc = DB.GetProfileDocument(ProfileName)
            If (doc Is Nothing) Then
                result = False
            End If
            Return result
        End Get

    End Property
    Public ReadOnly Property CADREFilePath(ByVal Path As String) As Boolean

        Get
            Dim result As Boolean = False

            result = True
            FilePath = Path
            If Not Directory.Exists(FilePath) Then
                result = False
            End If
            Return result
        End Get

    End Property
    Public ReadOnly Property CN_Username() As String
        Get
            Return session.UserName
        End Get
    End Property
    '    Public ReadOnly Property FeedbackDate() As Date
    '        Get
    '            Return DateTime.Parse(DB.LastModified)
    '        End Get
    '    End Property

    Public Function CheckAttachments() As Boolean
        Dim result As Boolean = False

        result = True
        If Not doc.HasEmbedded Then
            result = False
        End If
        Return result

    End Function

    Public Sub CreateDOC(ByRef FormName As String)
        doc = DB.CreateDocument
        doc.Form = FormName
        DocCreated = True
        doc.Save(True, False)
    End Sub
    Public Sub CreateDOCandCompute(ByRef Formname As String)

        doc = DB.CreateDocument
        doc.Form = Formname
        doc.ComputeWithForm(True, False)
        doc.Save(True, False)

    End Sub
    Public Sub GetArray(ByRef valname As String, ByRef Combo As ComboBox)

        ReadersValue = doc.GetItemValue(valname)
        For Each ReadersValue_item As String In ReadersValue
            If ReadersValue_item.Trim().Length > 0 Then
                Combo.Items.Add(ReadersValue_item)
            End If
        Next ReadersValue_item

    End Sub
    '    Public Sub SetValueAppend(ByRef valname As String, ByRef Val As String)
    '        Dim fieldHistory() As String = doc.GetItemValue(valname)
    '        Dim fieldHistoryLog As Object = doc.ReplaceItemValue(valname, Val)

    '        For Each fieldHistory_item As String In fieldHistory
    '            fieldHistoryLog.AppendToTextList(fieldHistory_item)
    '        Next fieldHistory_item
    '        doc.Save(True, True)

    '    End Sub
    Public Sub DocSave()
        doc.Save(True, True)
        DocCreated = False
    End Sub
    '    Public ReadOnly Property GetBookingUploadStatus(ByVal ComServer As String, ByVal DBName As String, ByVal NegNum As String, ByVal Bank As String, ByVal Alt As String, ByVal CurrentStatus As String) As String

    '        Get
    '            Dim result As String = CurrentStatus
    '            Dim keys() As String = {NegNum, Bank, Alt}
    '            Dim BookFlag As String = String.Empty

    '            If NotesDBName(ComServer, DBName) Then
    '                If NotesDBView("LU Award by Neg Number") Then
    '                    View.Refresh()
    '                    doc = View.GetDocumentByKey(keys, True)
    '                    While Not (doc Is Nothing)
    '                        If GetValue("NegNum") = NegNum And GetValue("Bank").ToString.ToUpper = Bank And GetValue("Alt").ToString.ToUpper = Alt Then
    '                            BookFlag = GetValue("BookFlag").ToString.ToUpper
    '                            If Strings.InStr(1, BookFlag, "AWARD") > 0 Then
    '                                If Strings.InStr(1, BookFlag, "SUCCEED") > 0 Then
    '                                    result = STATUS_AWARD_SUCCEEDED
    '                                End If
    '                            End If
    '                            If Strings.InStr(1, BookFlag, "BOOK") > 0 Then
    '                                If Strings.InStr(1, BookFlag, "SUCCEED") > 0 Then
    '                                    result = STATUS_BOOK_SUCCEEDED
    '                                    Exit While
    '                                End If
    '                            End If
    '                            If Strings.InStr(1, BookFlag, "CONFIG") > 0 Then
    '                                If Strings.InStr(1, BookFlag, "SUCCEED") > 0 Then
    '                                    result = STATUS_BOOK_SUCCEEDED
    '                                    Exit While
    '                                End If
    '                            End If
    '                        End If
    '                        doc = View.GetNextDocument(doc)
    '                    End While
    '                End If
    '            End If
    '            Return result
    '        End Get

    '    End Property
    '    Public ReadOnly Property GetGONumber(ByVal ComServer As String, ByVal DBName As String, ByVal NegNum As String, ByVal Bank As String, ByVal Alt As String) As String

    '        Get
    '            Dim result As String = String.Empty
    '            Dim keys() As String = {NegNum, Bank, Alt}
    '            Dim BookFlag As String = String.Empty

    '            If NotesDBName(ComServer, DBName) Then
    '                If NotesDBView("LU Award by Neg Number") Then
    '                    View.Refresh()
    '                    doc = View.GetDocumentByKey(keys, True)
    '                    While Not (doc Is Nothing)
    '                        BookFlag = GetValue("BookFlag").ToString.ToUpper
    '                        If GetValue("NegNum") = NegNum And GetValue("Bank").ToString.ToUpper = Bank And GetValue("Alt").ToString.ToUpper = Alt And
    '                           (Strings.InStr(1, BookFlag, "AWARD") > 0 Or Strings.InStr(1, BookFlag, "BOOK") > 0 Or Strings.InStr(1, BookFlag, "CONFIG") > 0) Then
    '                            result = GetValue("GONUM").ToString.ToUpper
    '                            If Not String.IsNullOrEmpty(result) Then
    '                                Exit While
    '                            End If
    '                        End If
    '                        doc = View.GetNextDocument(doc)
    '                    End While
    '                End If
    '            End If
    '            Return result
    '        End Get

    '    End Property
    '    Public Function GetNotesCanonicalName(ByVal sName As String) As String
    '        Dim sNotesName As String = ""
    '        Dim sFull_NotesName As String = ""

    '        DB = session.GetDatabase(ComServer, HoldNotesPhonebookPath)
    '        View = DB.GetView("(>LU Employees \ By Notes Name)")
    '        NotesDocumentCollection = View.GetAllDocumentsByKey(sName)
    '        If Not (NotesDocumentCollection Is Nothing) Then
    '            If NotesDocumentCollection.Count > 0 Then
    '                doc = NotesDocumentCollection.GetFirstDocument
    '                While Not (doc Is Nothing) And sFull_NotesName = ""
    '                    sNotesName = clsNotes.GetValue("NotesName")
    '                    If InStr(1, sNotesName, sName & "/") > 0 Then
    '                        sFull_NotesName = clsNotes.GetValue("Full_NotesName")
    '                    End If
    '                    doc = NotesDocumentCollection.GetNextDocument(doc)
    '                End While
    '            End If
    '        End If
    '        Return sFull_NotesName

    '    End Function

    Public Function FindSUPTDocument() As Boolean
        Dim result As Boolean = False

        Try
            Dim b As Boolean
           
            If NotesDocKeyCollection(Contracts.EstimateNum) Then
                b = True
                Do While b
                    If Contracts.EstimateNum = GetValue("proposal_num") Then
                        Return True
                    End If
                    b = GetNextDocumentFromCollection()
                Loop
            End If
            Return result

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "Find SUPT Document", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return result

        End Try

    End Function

    Public Function GetNextDocumentFromCollection() As Boolean
        Dim result As Boolean = False

        result = True
        doc = NotesDocumentCollection.GetNextDocument(doc)
        If doc Is Nothing Then
            result = False
        End If
        Return result

    End Function
    Public ReadOnly Property NotesDocKeyCollection(ByVal KeyName As String) As Boolean
        Get
            View.Refresh()
            NotesDocumentCollection = View.GetAllDocumentsByKey(KeyName, True)
            If (NotesDocumentCollection Is Nothing) Then
                Return False
            End If
            If NotesDocumentCollection.Count = 0 Then
                Return False
            End If
            doc = NotesDocumentCollection.GetFirstDocument
            If (doc Is Nothing) Then
                Return False
            End If
            Return True

        End Get
    End Property
    '    Public Sub DetachFilesBookingUpload(ByVal ComServer As String, ByVal DBName As String, ByVal NegNum As String, ByVal Bank As String, ByVal Alt As String)
    '        Dim result As MsgBoxStyle = MsgBoxStyle.Critical
    '        Dim keys() As String = {NegNum, Bank, Alt}
    '        Dim BookFlag As String = String.Empty
    '        Dim TempObj1 As Object
    '        Dim EmbeddedFiles() As String
    '        Dim thisFile As String = ""
    '        Dim SAPFileFound As Boolean = False, COSUMFileFound As Boolean = False

    '        Try
    '            gsSUPT_FileNameGOSUM = String.Empty
    '            If NotesDBName(ComServer, DBName) Then
    '                If NotesDBView("LU Award by Neg Number") Then
    '                    View.Refresh()
    '                    doc = View.GetDocumentByKey(keys, True)
    '                    While Not (doc Is Nothing)
    '                        BookFlag = GetValue("BookFlag").ToString.ToUpper
    '                        If GetValue("NegNum") = NegNum And GetValue("Bank").ToString.ToUpper = Bank And GetValue("Alt").ToString.ToUpper = Alt And
    '                           Strings.InStr(1, BookFlag, "AWARD") > 0 And Strings.InStr(1, BookFlag, "SUCCEED") > 0 Then
    '                            If CADREFilePath(SuptPath) Then
    '                                TempObj1 = doc.GetFirstItem("FILEATTACH")
    '                                If TempObj1 Is Nothing Then
    '                                    ReadersValue = doc.GetItemValue("FileAttachments")
    '                                    For Each ReadersValue_item As String In ReadersValue
    '                                        If ReadersValue_item.ToUpper.IndexOf(".SAP") > -1 Then
    '                                            TempObj1 = doc.GetAttachment(ReadersValue_item)
    '                                            TempObj1.ExtractFile(SuptPath & ReadersValue_item)
    '                                            SAPFileFound = True
    '                                            gsSUPT_FileNameSAP = SuptPath & ReadersValue_item
    '                                        ElseIf ReadersValue_item.ToUpper.IndexOf("COSUM.TXT") > -1 Then
    '                                            TempObj1 = doc.GetAttachment(ReadersValue_item)
    '                                            TempObj1.ExtractFile(SuptPath & ReadersValue_item)
    '                                            COSUMFileFound = True
    '                                            If Strings.Mid(ReadersValue_item, 15, 2).Trim = Strings.Left(GONumbers(CurrentGOSelection).Units, 2).Trim Then
    '                                                gsSUPT_FileNameGOSUM = SuptPath & ReadersValue_item
    '                                            End If
    '                                        End If
    '                                    Next ReadersValue_item
    '                                ElseIf TempObj1.Type = Domino.IT_TYPE.RICHTEXT Then
    '                                    ReadersValue = doc.GetItemValue("fileAttach")
    '                                    EmbeddedFiles = ReadersValue(0).Split(" - ")
    '                                    For Each EmbeddedFiles_item As String In EmbeddedFiles
    '                                        thisFile = EmbeddedFiles_item.Trim()
    '                                        If thisFile <> "" Then
    '                                            If thisFile.ToUpper.IndexOf(".SAP") > -1 Then
    '                                                TempObj1 = doc.GetAttachment(thisFile)
    '                                                TempObj1.ExtractFile(SuptPath & thisFile)
    '                                                SAPFileFound = True
    '                                                gsSUPT_FileNameSAP = SuptPath & thisFile
    '                                            ElseIf thisFile.ToUpper.IndexOf("COSUM.TXT") > -1 Then
    '                                                TempObj1 = doc.GetAttachment(thisFile)
    '                                                TempObj1.ExtractFile(SuptPath & thisFile)
    '                                                If Strings.Mid(thisFile, 15, 2).Trim = Strings.Left(GONumbers(CurrentGOSelection).Units, 2).Trim Then
    '                                                    gsSUPT_FileNameGOSUM = SuptPath & thisFile
    '                                                End If
    '                                                COSUMFileFound = True
    '                                            End If
    '                                        End If
    '                                    Next EmbeddedFiles_item
    '                                End If
    '                            End If
    '                        End If
    '                        doc = View.GetNextDocument(doc)
    '                    End While
    '                End If
    '            End If
    '            If SAPFileFound And COSUMFileFound Then
    '                result = MsgBoxStyle.OkOnly
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show("Error: " & Information.Err().Number & ", " & Information.Err.Description & Strings.Chr(10).ToString(), "DetachFilesBookingUpload", MessageBoxButtons.OK)

    '        End Try

    '    End Sub
End Class