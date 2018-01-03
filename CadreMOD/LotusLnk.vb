Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Data.Common
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Environment
Imports System.Net.Mail
Imports System.Collections.Generic

Module Lotuslnk

    Private Hold_Customer_ID As String = ""
    Public Hold_Contact_ID As String = ""
    Dim NewExistingFlag As String = ""

    Private HoldNotesCustomerPath As String = ""
    Private HoldNotesContactPath As String = ""
    Private HoldNotesActivitiesPath As String = ""
    Public HoldNotesFeedbackPath As String = ""
    Public HoldNotesPhonebookPath As String = ""
    Public HoldUniqueActivity As String = ""
    Public HoldFeedbackRecord As String = ""
    Public HoldNotesSMARTCenterPath As String = ""

    Public NotesUserName As String = ""
    Public gsNotesLinkDataUserName As String = ""
    Public gsSalesRep As String = ""
    Public ComServer As String = ""
    Public clsNotes As New clsNotesCOM

    Const Feedback As String = "MOD Estimates"
    Const SMART As String = "SM2ART Center"
    Const Activities As String = "SM2ART Activities"

    Public ChangingSpeed_OLD As Byte
    Public ChangingCapacity_OLD As Byte
    Public ChangingTravel_OLD As Byte
    Public RegionLocalMOD_OLD As Byte

    Private IsValid As Boolean

    Private Structure UserName_typ
        Dim FirstName As String
        Dim LastName As String
        Public Shared Function CreateInstance() As UserName_typ
            Dim result As New UserName_typ()
            result.FirstName = String.Empty
            result.LastName = String.Empty
            Return result
        End Function
    End Structure
    Private UserNames() As UserName_typ = Nothing

    Public FieldSup_ID As String = ""
    Public SalesRep_ID As String = ""
    Public ServiceRepID As String = ""

    Private iPos As Integer
    Public PreBidMODActive As Boolean
    Public gsPreBidBanks As String = ""

    Public Structure PreBidMOD_BankInfo_typ
        Dim Bank As String
        Dim ChangingTravel As Byte
        Dim ChangingSpeed As Byte
        Dim ChangingCapacity As Byte
        Dim RegionLocalMOD As Byte
        Dim SID_Alternate As Boolean
        Dim SID_Control As Boolean
        Dim DriveType As String
        Dim ExistingRoping As String
        Dim OEM As String
        Dim NonstandardControlFeatures As Byte
        Dim PreBidRearOpening As Boolean
        Public Shared Function CreateInstance() As PreBidMOD_BankInfo_typ
            Dim result As New PreBidMOD_BankInfo_typ()
            result.Bank = String.Empty
            result.DriveType = String.Empty
            result.ExistingRoping = String.Empty
            result.OEM = String.Empty
            Return result
        End Function
    End Structure
    Public PreBidMOD_BankInfo() As PreBidMOD_BankInfo_typ = Nothing

    Public MissingContactInfo As Boolean
    Public OfficeFromSmart As String = ""
    Public TestVersion As Boolean
    Public ReadersValue() As String
    Public NotesPath As String = String.Empty
    Public CadreBookingUploadDB As String = String.Empty
    Public IsPilotOffice As Boolean = False

    Public Sub Add_FeedBack_Doc()
        Dim Filesystem As New Scripting.FileSystemObject()
        Dim Name As String = ""
        '        Dim TotalProco, TotalPrice, TotalAward, TotalBid As Single
        Dim TotalProco, TotalAward As Single
        '        Dim LastBank As String = ""
        '        Dim CheckBank, AddDollars As Boolean
        '        Dim UsePrice As Single
        '        Dim SaveFlag As Boolean = False
        '        Dim SetPlannerDate As Boolean = False
        '        Dim totalNumDI As Integer = 0
        '        Dim totalDollarDI As Single = 0
        '        Dim totalNumHX As Integer = 0
        '        Dim totalDollarHX As Single = 0
        '        Dim totalNumTractionPOH As Integer = 0
        '        Dim totalDollarTractionPOH As Single = 0
        '        Dim totalNumTX As Integer = 0
        '        Dim totalDollarTX As Single = 0
        '        Dim totalNumTractionLocal As Integer = 0
        '        Dim totalDollarTractionLocal As Single = 0
        '        Dim totalNumQuantumLeap As Integer = 0
        '        Dim totalDollarQuantumLeap As Single = 0
        '        Dim totalNumHydroPOH As Integer = 0
        '        Dim totalDollarHydroPOH As Single = 0
        '        Dim totalNumHydroLocal As Integer = 0
        '        Dim totalDollarHydroLocal As Single = 0
        '        Dim totalNumSID_PH_MOD As Integer = 0
        '        Dim totalDollarSID_PH_MOD As Single = 0
        '        Dim totalNumSID_MTO As Integer = 0
        '        Dim totalDollarSID_MTO As Single = 0
        '        Dim totalNumSID_IO As Integer = 0
        '        Dim totalDollarSID_IO As Single = 0
        '        Dim totalNumReusedController As Integer = 0
        '        Dim totalDollarReusedController As Single = 0

        Try
            '            If Not QueryFeedback(False) Then
            '                If gbShape Then
            '                    CreateNewOpportunity()
            '                End If
            '            End If
            Attach_To_Feedback()
            '            For iIndx As Integer = 0 To GetUBoundGONumbers()
            '                If GONumbers(iIndx).IncludeInBid = CheckState.Checked Then
            '                    TotalPrice += GONumbers(iIndx).TargetPrice
            '                    TotalAward += GONumbers(iIndx).AwardPrice
            '                    TotalProco += GONumbers(iIndx).ProcoCost
            '                    TotalBid += GONumbers(iIndx).BidPrice
            '                    If Contracts.Status = Status_OfferWon And GONumbers(iIndx).FileVersion_BOOK < 2012.3 Then
            '                        SaveFlag = HasValidProposal(GONumbers(iIndx).Bank, GONumbers(iIndx).Alt, REPORT_Proposal)
            '                    Else
            '                        If HasValidProposal(GONumbers(iIndx).Bank, GONumbers(iIndx).Alt, REPORT_Proposal_LongForm) Or HasValidProposal(GONumbers(iIndx).Bank, GONumbers(iIndx).Alt, REPORT_Proposal_ShortForm) Or HasValidProposal(GONumbers(iIndx).Bank, GONumbers(iIndx).Alt, REPORT_Proposal_ThirdParty) Then
            '                            SaveFlag = True
            '                        End If
            '                    End If
            '                End If
            '            Next iIndx
            '            clsNotes.SetValue("Proposal_Price", TotalPrice)
            clsNotes.SetValue("MODFlag", "MOD")
            TotalAward = GetSummaryTotals("bank_final_price")
            clsNotes.SetValue("awardPrice", TotalAward)
            TotalProco = GetSummaryTotals("Total_Bank_Cost")
            clsNotes.SetValue("procoCost", TotalProco)
            '            clsNotes.SetValue("salesPlannerPrice", TotalBid)
            '            If SaveFlag Then
            '                LastBank = String.Empty
            '                For iIndx As Integer = 0 To GetUBoundGONumbers()
            '                    If GONumbers(iIndx).IncludeInBid = CheckState.Checked And LastBank <> GONumbers(iIndx).Bank Then
            '                        Select Case GONumbers(iIndx).ProductCode
            '                            Case 600, 630
            '                                totalNumTractionPOH += 1
            '                                totalDollarTractionPOH += GONumbers(iIndx).BidPrice
            '                            Case 610
            '                                totalNumHydroPOH += 1
            '                                totalDollarHydroPOH += GONumbers(iIndx).BidPrice
            '                            Case 612 To 613
            '                                totalNumHX += 1
            '                                totalDollarHX += GONumbers(iIndx).BidPrice
            '                            Case 615
            '                                totalNumHydroLocal += 1
            '                                totalDollarHydroLocal += GONumbers(iIndx).BidPrice
            '                            Case 641 To 644, 667, 668
            '                                totalNumSID_MTO += 1
            '                                totalDollarSID_MTO += GONumbers(iIndx).BidPrice
            '                            Case 646 To 649
            '                                totalNumSID_PH_MOD += 1
            '                                totalDollarSID_PH_MOD += GONumbers(iIndx).BidPrice
            '                            Case 660, 661, 664, 665
            '                                totalNumQuantumLeap += 1
            '                                totalDollarQuantumLeap += GONumbers(iIndx).BidPrice
            '                            Case 670
            '                                totalNumReusedController += 1
            '                                totalDollarReusedController += GONumbers(iIndx).BidPrice
            '                            Case 645, 676 To 679
            '                                totalNumDI += 1
            '                                totalDollarDI += GONumbers(iIndx).BidPrice
            '                            Case 680 To 683, 669
            '                                totalNumTX += 1
            '                                totalDollarTX += GONumbers(iIndx).BidPrice
            '                            Case 691 To 692
            '                                totalNumTractionLocal += 1
            '                                totalDollarTractionLocal += GONumbers(iIndx).BidPrice
            '                            Case Else
            '                        End Select
            '                        For jIndx As Integer = 0 To GetUBoundGONumbers()
            '                            If GONumbers(iIndx).Bank = GONumbers(jIndx).Bank Then
            '                                If GONumbers(iIndx).Alt = GONumbers(jIndx).Alt And GONumbers(iIndx).Units <> GONumbers(jIndx).Units And GONumbers(jIndx).IncludeInBid = CheckState.Checked Then
            '                                    CheckBank = True
            '                                    AddDollars = True
            '                                    UsePrice = GONumbers(jIndx).BidPrice
            '                                ElseIf GONumbers(jIndx).AltIncludeInBid = CheckState.Checked Then
            '                                    CheckBank = True
            '                                    AddDollars = False
            '                                    If GONumbers(jIndx).BidPrice > 0 Then
            '                                        UsePrice = GONumbers(jIndx).BidPrice
            '                                    Else
            '                                        UsePrice = GONumbers(jIndx).TargetPrice
            '                                    End If
            '                                Else
            '                                    CheckBank = False
            '                                End If
            '                                If CheckBank Then
            '                                    Select Case GONumbers(jIndx).ProductCode
            '                                        Case 600, 630
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumTractionPOH, totalDollarTractionPOH, UsePrice, AddDollars)
            '                                        Case 610
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumHydroPOH, totalDollarHydroPOH, UsePrice, AddDollars)
            '                                        Case 612 To 613
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumHX, totalDollarHX, UsePrice, AddDollars)
            '                                        Case 615
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumHydroLocal, totalDollarHydroLocal, UsePrice, AddDollars)
            '                                        Case 641 To 644, 667, 668
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumSID_MTO, totalDollarSID_MTO, UsePrice, AddDollars)
            '                                        Case 646 To 649
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumSID_PH_MOD, totalDollarSID_PH_MOD, UsePrice, AddDollars)
            '                                        Case 660, 661, 664, 665
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumQuantumLeap, totalDollarQuantumLeap, UsePrice, AddDollars)
            '                                        Case 670
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumReusedController, totalDollarReusedController, UsePrice, AddDollars)
            '                                        Case 645, 676 To 679
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumDI, totalDollarDI, UsePrice, AddDollars)
            '                                        Case 680 To 683, 669
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumTX, totalDollarTX, UsePrice, AddDollars)
            '                                        Case 691 To 692
            '                                            CompareProductCodesByBank(GONumbers(jIndx).ProductCode, GONumbers(iIndx).ProductCode, totalNumTractionLocal, totalDollarTractionLocal, UsePrice, AddDollars)
            '                                        Case Else
            '                                    End Select
            '                                End If
            '                            End If
            '                        Next jIndx
            '                        LastBank = GONumbers(iIndx).Bank
            '                    End If
            '                Next iIndx
            '            End If
            '            SaveSalesPlannerData("totalNumDI", totalNumDI, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarDI", Math.Round(totalDollarDI, 2), True)
            '            SaveSalesPlannerData("totalNumHX", totalNumHX, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarHX", Math.Round(totalDollarHX, 2), True)
            '            SaveSalesPlannerData("totalNumTractionPOH", totalNumTractionPOH, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarTractionPOH", Math.Round(totalDollarTractionPOH, 2), True)
            '            SaveSalesPlannerData("totalNumTX", totalNumTX, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarTX", Math.Round(totalDollarTX, 2), True)
            '            SaveSalesPlannerData("totalNumTractionLocal", totalNumTractionLocal, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarTractionLocal", Math.Round(totalDollarTractionLocal, 2), True)
            '            SaveSalesPlannerData("totalNumHydroPOH", totalNumHydroPOH, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarHydroPOH", Math.Round(totalDollarHydroPOH, 2), True)
            '            SaveSalesPlannerData("totalNumHydroLocal", totalNumHydroLocal, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarHydroLocal", Math.Round(totalDollarHydroLocal, 2), True)
            '            SaveSalesPlannerData("totalNumSID_MTO", totalNumSID_PH_MOD, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarSID_MTO", Math.Round(totalDollarSID_PH_MOD, 2), True)
            '            SaveSalesPlannerData("totalNumSID_M10", totalNumSID_MTO, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarSID_M10", Math.Round(totalDollarSID_MTO, 2), True)
            '            SaveSalesPlannerData("totalNumSID_IO", totalNumSID_IO, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarSID_IO", Math.Round(totalDollarSID_IO, 2), True)
            '            SaveSalesPlannerData("totalNumReusedController", totalNumReusedController, False, SetPlannerDate)
            '            SaveSalesPlannerData("totalDollarReusedController", Math.Round(totalDollarReusedController, 2), True)
            '            If SetPlannerDate Then
            '                clsNotes.SetValue("SalesPlannerDate", CDate(DateTime.Today.ToString("MM/dd/yyyy")))
            '            End If
            clsNotes.SetValue("Status", Contracts.Status)
            '            If Not String.IsNullOrEmpty(Contracts.OpportunityToOfferDate.Trim) Then
            '                clsNotes.SetValue("oppToOfferDate", CDate(CDate(Contracts.OpportunityToOfferDate).ToString("MM/dd/yyyy")))
            '            End If
            '            If Not String.IsNullOrEmpty(Contracts.ProposedDate.Trim) Then
            '                clsNotes.SetValue("proposedDate", CDate(CDate(Contracts.ProposedDate).ToString("MM/dd/yyyy")))
            '            End If
            '            If Not String.IsNullOrEmpty(Contracts.OpportunityClosedDate.Trim) Then
            '                clsNotes.SetValue("oppOfferClosedDate", CDate(CDate(Contracts.OpportunityClosedDate).ToString("MM/dd/yyyy")))
            '            End If
            clsNotes.SetValue("prob_sale", Get_ProbabilityofSale(Contracts.ProbabilityOfSale))
            clsNotes.SetValue("prob_sale_range", Contracts.ProbabilityOfSale)
            clsNotes.SetValue("SalesRep", Contracts.SalesRepName)
            clsNotes.SetValue("Estimator", clsNotes.CN_Username)
            clsNotes.SetValue("Version", SHORT_VERSION)
            '            clsNotes.SetValue("highRiskFlag", Contracts.JobHighRiskFactor)
            '            Dim UseMaxPercentSpecial As Decimal = 0
            '            For iIndx As Integer = 0 To GetUBoundGONumbers()
            '                If (GONumbers(iIndx).MachineType = HYDRO_TYPE And GONumbers(iIndx).NewControl = MODEL_HX) Or (GONumbers(iIndx).MachineType = GEARED_TYPE And GONumbers(iIndx).NewControl = SEC) And (GONumbers(iIndx).IncludeInBid = CheckState.Checked Or GONumbers(iIndx).AltIncludeInBid = CheckState.Checked) Then
            '                    If GONumbers(iIndx).MaxPercentSpecial > UseMaxPercentSpecial Then UseMaxPercentSpecial = GONumbers(iIndx).MaxPercentSpecial
            '                End If
            '            Next iIndx
            '            UseMaxPercentSpecial = Math.Round(CDbl(UseMaxPercentSpecial * 100), 2)
            '            clsNotes.SetValue("maxAdder", UseMaxPercentSpecial)
            clsNotes.SetValue_Readers("Reader", Contracts.Reader)
            clsNotes.SetValue_Readers("reader_global", Contracts.ReaderGlobal)
            If clsNotes.CheckAttachments() Then
                clsNotes.DeleteALLAttachments()
            End If
            VerifyPath(ReportsPath)
            Dim thisFolder As Scripting.Folder = Filesystem.GetFolder(ReportsPath)
            Dim theseFiles As Scripting.Files = thisFolder.Files
            For Each thisFile As Scripting.File In theseFiles
                Name = thisFile.Name.ToUpper()
                '                If (Name Like Contracts.EstimateNum & "*.*" Or Name Like "*.XLS*") And Not Name Like "*.A2B" And Not Name Like "*LETTER.DOC*" And Not Name Like "*SCRIPTS.DOC*" Then
                If (Name Like Contracts.EstimateNum & "*.JSON") Or (Name Like Contracts.EstimateNum & "*.CM") Or
                   (Name Like Contracts.EstimateNum & "*.M*") Or (Name Like Contracts.EstimateNum & "*.DOC*") Then
                    '                        For iIndx As Integer = 0 To GetUBoundGONumbers()
                    '                            If Name Like Get_FileName(Contracts.EstimateNum, GONumbers(iIndx).Bank, GONumbers(iIndx).Alt, GONumbers(iIndx).Units) Then
                    '                                clsNotes.AttachFile(Name)
                    '                                Exit For
                    '                            End If
                    '                        Next iIndx
                    '                    Else
                    clsNotes.AttachFile(Name)
                    '                    End If
                    '                    If Name Like (Contracts.EstimateNum.ToString() & "*" & REPORT_LetterOfIntent & "*").ToUpper() Then
                    '                        For iIndx As Integer = 0 To GetUBoundGONumbers()
                    '                            If Name Like (Contracts.EstimateNum.ToString() & GONumbers(iIndx).Bank & GONumbers(iIndx).Alt & REPORT_LetterOfIntent & "*").ToUpper() Then
                    '                                clsNotes.SetValue("LetterIntentDate", CDate(thisFile.DateCreated.ToString("d")))
                    '                                clsNotes.SetValue("LetterIntentVendor", GONumbers(iIndx).LetterOfIntent_Vendor)
                    '                                Exit For
                    '                            End If
                    '                        Next iIndx
                    '                    End If
                    '                End If
                End If
            Next thisFile
            '            If MDIChildDirty Or gbMDIChildDirty Or MP_CST03_Child_Dirty Or RunMDIChildDirty Then
            '                EstimateModified = True
            '            End If

            '        Finally
            '            MemoryHelper.ReleaseAndCleanObject(Filesystem)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Adding FeedBack Docs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '        End Try

    End Sub
    Private Sub SchindlerData_To_Fields()

        On Error Resume Next

        Contracts.EstimateNum = HoldUniqueActivity.ToUpper()
        Contracts.SchindlerAddress1 = ""
        Contracts.SchindlerAddress2 = ""
        Contracts.SchindlerCity = ""
        Contracts.SchindlerState = ""
        Contracts.SchindlerZip = ""
        If Not clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) Then
            MessageBox.Show("Could not find Corporate Phone Book database!", Application.ProductName)
        End If
        If Not clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") Then
            MessageBox.Show("Could not find Employees By Notes Name view", Application.ProductName)
        End If
        If Not clsNotes.NotesDocKey(NotesUserName) Then
            If ComServer = "" Then
                MessageBox.Show("No Schindler User Information was found for " & NotesUserName & Environment.NewLine & _
                                "in the Corporate Phone Directory on Local" & _
                                "Office related data will be blank", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("No Schindler User Information was found for " & NotesUserName & Environment.NewLine & _
                                "in the Corporate Phone Directory on " & ComServer & _
                                "Office related data will be blank", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Exit Sub
        End If
        If clsNotes.GetValue("Mail_State") = "" Or clsNotes.GetValue("Mail_Zip") = "" Then
            Contracts.SchindlerAddress1 = clsNotes.GetValue("Address1")
            Contracts.SchindlerAddress2 = clsNotes.GetValue("Address2")
            Contracts.SchindlerCity = clsNotes.GetValue("City")
            Contracts.SchindlerState = clsNotes.GetValue("State")
            Contracts.SchindlerZip = clsNotes.GetValue("Zip")
        Else
            Contracts.SchindlerAddress1 = clsNotes.GetValue("Mail_Address1")
            Contracts.SchindlerAddress2 = clsNotes.GetValue("Mail_Address2")
            Contracts.SchindlerCity = clsNotes.GetValue("Mail_City")
            Contracts.SchindlerState = clsNotes.GetValue("Mail_State")
            Contracts.SchindlerZip = clsNotes.GetValue("Mail_Zip")
        End If
        If Contracts.SchindlerAddress1 = "" And Contracts.SchindlerAddress2 = "" Then
            GoTo MISSINGMESSAGE
        ElseIf Contracts.SchindlerCity = "" Or Contracts.SchindlerState = "" Or Contracts.SchindlerZip = "" Then
            GoTo MISSINGMESSAGE
        End If

        Exit Sub

MISSINGMESSAGE:
        MessageBox.Show("Schindler Office Information is incomplete, please correct " & Environment.NewLine & _
                        "information in the Corporate Phone Directory.", "Warning - Corporate Phone Directory")

    End Sub
    Public Sub DetachFeedback()

        If NewExistingFlag = "Existing" Then
            Try
                Attach_To_Feedback()
                Hold_Customer_ID = clsNotes.GetValue("Unique")
                Hold_Contact_ID = clsNotes.GetValue("ContactUnique")
                If Not clsNotes.CheckAttachments() Then
                    MessageBox.Show("There are no file attachments for this estimate!", Application.ProductName)
                    Exit Sub
                End If
                CompareFiles()
                ArchiveFiles()
                DeleteAllFiles()
                VerifyPath(ReportsPath)
                clsNotes.DetachFiles()
                CompareFiles()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error In DetachFeedback")

            End Try
        End If

    End Sub

    Public Function QueryFeedback(ByRef SetValues As Boolean) As Boolean

        On Error Resume Next
        QueryFeedback = False


        If NewExistingFlag = "New" Then
            HoldFeedbackRecord = "Smart"
        Else
            'Can't attach to a record if it's  new 
            If Not Attach_To_Feedback() Then Exit Function

            If clsNotes.CheckAttachments() Then
                HoldFeedbackRecord = "Feedback"
            End If
        End If

        If Not SetValues Then
            Exit Function
        End If
        iPos = (clsNotes.GetValue("SalesRep").IndexOf("/"c) + 1)
        If iPos = 0 Then
            Contracts.SalesRepName = clsNotes.GetValue("SalesRep")
        Else
            Contracts.SalesRepName = Strings.Mid(clsNotes.GetValue("SalesRep"), 4, iPos - 4)
        End If
        iPos = (clsNotes.CN_Username.IndexOf("/"c) + 1)
        If iPos = 0 Then
            Contracts.Estimator = clsNotes.CN_Username
        Else
            Contracts.Estimator = Strings.Mid(clsNotes.CN_Username, 4, iPos - 4)
        End If
        If Convert.IsDBNull(clsNotes.GetValue("prob_sale_range")) OrElse clsNotes.GetValue("prob_sale_range").Length = 0 Then
            Contracts.ProbabilityOfSale = "100%"
        Else
            Contracts.ProbabilityOfSale = Map_ProbabilityofSale(clsNotes.GetValue("prob_sale_range"))
        End If
        'Contracts.ProposalNum = clsNotes.GetValue("Proposal_num")
        'If clsNotes.GetValue("HqRLMod") = "RL" Then
        '    RegionLocalMOD_OLD = CheckState.Checked
        'Else
        '    RegionLocalMOD_OLD = CheckState.Unchecked
        'End If
        'If clsNotes.GetValue("travelIncreaseYN").ToUpper() = "YES" Then
        '    ChangingTravel_OLD = CheckState.Checked
        'Else
        '    ChangingTravel_OLD = CheckState.Unchecked
        'End If
        'If clsNotes.GetValue("changecapacity").ToUpper() = "YES" Then
        '    ChangingCapacity_OLD = CheckState.Checked
        'Else
        '    ChangingCapacity_OLD = CheckState.Unchecked
        'End If
        'If clsNotes.GetValue("changespeed").ToUpper() = "YES" Then
        '    ChangingSpeed_OLD = CheckState.Checked
        'Else
        '    ChangingSpeed_OLD = CheckState.Unchecked
        'End If
        Contracts.EstimateDate = CDate(clsNotes.GetValue("date")).ToString("d")
        Contracts.ContractNumber = clsNotes.GetValue("custnumber")
        'If PreBidMODActive Then
        '    If clsNotes.GetValue("bidtype") = "Budget Price" Then
        '        MessageBox.Show("Cadre MOD estimates cannot be created for a 'Budget Price'!" & Environment.NewLine & _
        '              "Please modify PreBid to a 'Firm Price' in order to run Cadre MOD.", "Closing Cadre MOD", MessageBoxButtons.OK)
        '        EndProgram()
        '    End If
        'Else
        '    If Contracts.ContractNumber.Length > 0 And Contracts.ContractNumber <> "" Then
        '        Contracts.CurrentMaintenance = "Yes"
        '    Else
        '        Contracts.CurrentMaintenance = "No"
        '    End If
        '    If clsNotes.GetValue("pricingType") = "Firm" Then
        '        Contracts.Pricing_Type = "FIRM"
        '    Else
        '        Contracts.Pricing_Type = "BUDGET"
        '    End If
        'End If
        'If clsNotes.GetValue("specification") = "Yes" Then
        '    Contracts.SpecificationExists = CheckState.Checked
        'Else
        '    Contracts.SpecificationExists = CheckState.Unchecked
        'End If
        'Contracts.RegionCode = clsNotes.GetValue("area")
        'Contracts.MaxPercentSpecialStatus = ""
        'Contracts.SystemStatus = clsNotes.GetValue("systemStatus")
        'Contracts.OpportunityToOfferDate = clsNotes.GetValue("oppToOfferDate").ToString
        'Contracts.ProposedDate = clsNotes.GetValue("proposedDate").ToString
        'Contracts.OpportunityClosedDate = clsNotes.GetValue("oppOfferClosedDate").ToString
        Contracts.NationalAccount = clsNotes.GetValue("CustomerLevel") = "NA"
        Select Case clsNotes.GetValue("Status").ToUpper()
            Case "PRE-BID"
                Contracts.Status = Status_OpportunityInProgress
            Case "OPEN"
                If String.IsNullOrEmpty(Contracts.ProposedDate) Then
                    Contracts.Status = Status_OfferInProgress
                Else
                    Contracts.Status = Status_OfferSubmitted
                End If
            Case "SOLD", "AWARD"
                Contracts.Status = Status_OfferWon
            Case "LOST"
                Contracts.Status = Status_OfferLost
            Case "DEAD"
                Contracts.Status = Status_OfferOnHold
            Case Else
                Contracts.Status = clsNotes.GetValue("Status")
        End Select
        'SHELL_ACCESS = Not (Contracts.SystemStatus = "Approved" And Contracts.Status <> Status_OfferLost And Contracts.Status <> Status_OfferOnHold)
        'Contracts.OfficeRating = clsNotes.GetValue("officeRating")
        'Contracts.PreBidPrice = Convert.ToSingle(clsNotes.GetValue("proposal_price_prebid"))
        'Contracts.MaxPercentSpecial = Math.Round(CDbl(Conversion.Val(clsNotes.GetValue("approvedMaxAdder")) / 100), 4)
        'If Contracts.MaxPercentSpecial = 0 Then
        '    Contracts.MaxPercentSpecial = 0.1
        '    If clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) Then
        '        If clsNotes.NotesDocProfile("Cadre Access Control Profile") Then
        '            If clsNotes.GetValue_Readers("maxAdderLimit_level_1") Then
        '                Contracts.MaxPercentSpecial = Math.Round(CDbl(Conversion.Val(ReadersValue(0)) / 100), 4)
        '    End If
        'End If

        Query_SM2ART()

        Contracts.EngReviewStatus = clsNotes.GetValue("engineeringReqStatus")
        QueryFeedback = True

    End Function
    Public Sub Query_SM2ART()

        If NewExistingFlag = "Existing" Then
            Attach_To_Feedback()
            Hold_Customer_ID = clsNotes.GetValue("unique")
            Hold_Contact_ID = clsNotes.GetValue("ContactUnique")
        End If

        Attach_To_SmartCenter_Customer()
        Contracts.JobName = TrimFields(clsNotes.GetValue("CustName"))
        Contracts.SAPContactNumber = clsNotes.GetValue("SAPContactNumber")
        Contracts.JobAddress = TrimFields(clsNotes.GetValue("Address"))
        Contracts.JobAddress2 = TrimFields(clsNotes.GetValue("Address_1"))
        Contracts.JobCity = TrimFields(clsNotes.GetValue("City"))
        Contracts.JobState = clsNotes.GetValue("State")
        Contracts.JobZip = clsNotes.GetValue("Zip")
        OfficeFromSmart = TranslateOfficeNumber(clsNotes.GetValue("Office"), 4)
        If Contracts.SalesRepOffice = "" Then
            Contracts.SalesRepOffice = TranslateOfficeNumber(OfficeFromSmart)
        End If
        '        Contracts.ContractType = clsNotes.GetValue("ContractType")
        Contracts.Country = clsNotes.GetValue("Country")
        RetrieveBuildingType(clsNotes.GetValue("LocationsXML"))
        Owner_Info.Name = TrimFields(clsNotes.GetValue("BillToName"))
        Owner_Info.Address = TrimFields(clsNotes.GetValue("BillToAddress"))
        Owner_Info.City = TrimFields(clsNotes.GetValue("BillToCity"))
        Owner_Info.State = clsNotes.GetValue("BillToState")
        Owner_Info.Zip = clsNotes.GetValue("BillToZip")
        Owner_Info.Phone = clsNotes.GetValue("BillToPhone")
        Owner_Info.Fax = clsNotes.GetValue("BillToFax")
        Contracts.LCName = clsNotes.GetValue("LCName")
        Contracts.District = clsNotes.GetValue("district")
        Contracts.Region = Strings.Left(clsNotes.GetValue("Region"), 5)
        Contracts.Area = clsNotes.GetValue("Area")
        Contracts.Territory = clsNotes.GetValue("Territory")
        '        Contracts.CustomerTier = clsNotes.GetValue("CUSTOMERTIER")
        '        clsNotes.GetValue_Readers("Reader")
        '        Contracts.Reader = ReadersValue
        '        clsNotes.GetValue_Readers("reader_global")
        '        Contracts.ReaderGlobal = ReadersValue

        Attach_To_SmartCenter_Contact()
        If Not MissingContactInfo Then
            JobContact.Name = TrimFields(clsNotes.GetValue("fContact"))
            JobContact.Name = JobContact.Name & " " & TrimFields(clsNotes.GetValue("LContact"))
            JobContact.Address = TrimFields(clsNotes.GetValue("Address"))
            JobContact.Address2 = TrimFields(clsNotes.GetValue("Address_1"))
            JobContact.City = TrimFields(clsNotes.GetValue("City"))
            JobContact.State = clsNotes.GetValue("State")
            JobContact.Zip = clsNotes.GetValue("zip")
            JobContact.Tel = clsNotes.GetValue("Phone")
        End If
    End Sub

    Public Function SetUpLotusLink() As Boolean

        Dim results As Boolean
        Dim NewExistingStr As Integer = (Interaction.Command().IndexOf("~"c) + 1)
        NewExistingFlag = Strings.Left(Interaction.Command(), NewExistingStr - 1) ' Can be "New" or ""

        If NewExistingFlag = "New" Then
            results = SetUpLotusLinkNew()
        Else
            NewExistingFlag = "Existing"
            results = SetUpLotusLinkExisting()
        End If

        TestVersion = False
        If HoldNotesFeedbackPath.IndexOf("_dev") >= 0 Or HoldNotesFeedbackPath.IndexOf("_train") >= 0 Then
            TestVersion = True
        End If
        Dim UserName As String = clsNotes.CN_Username
        iPos = (UserName.IndexOf("/"c) + 1)
        NotesUserName = Strings.Mid(UserName, 4, iPos - 4)
        gsSalesRep = clsNotes.CN_Username
        gsNotesLinkDataUserName = ReCreatesNotesLinkDataUserName(clsNotes.CN_Username & "/")
        SetAccessLevelsRole()
        SchindlerData_To_Fields()
        NotesPath = GetNotesDataDir()
        CadreBookingUploadDB = NotesPath & "\" & NOTES_BOOKING_DATABASE
        If TestVersion Then
            CadreBookingUploadDB = NotesPath & "\" & NOTES_BOOKING_DATABASE_TEST
        End If

        If results = False Then
            MessageBox.Show("Error setting up lotus link.", "Lotus Link Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return results

    End Function

    Public Function SetUpLotusLinkExisting() As Boolean
        Dim result As Boolean = False
        Dim sInteractionCommand As String = gsCommand

        result = True
        'Splash.Splash_lbl.Text = "Establishing Link To Lotus Notes...."
        'Splash.Refresh()

        'Local command lines
        ' testing - ~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\sm2art_dev.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\sm2art_dev.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\SM2ART_Activities_dev.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\feedbackMOD_dev.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\Corporate Phone Directory.nsf~CMJE-8CZMKL
        ' production - ~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\sm2art.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\sm2art.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\SM2ART_Activities.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\feedbackMOD.nsf~C:\Users\jaymech\AppData\Local\Lotus\Notes\Data\Corporate Phone Directory.nsf~GPAR-6WAS9S

        'Server command lines
        If gbShape Then
            If TestVersion Then
                sInteractionCommand = "USSECNE1~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\SM2ART_Activities_dev.nsf~sec\develop\larry\feedbackMOD_dev.nsf~sec\Corporate Phone Directory.nsf~" & OpportunityID
                '        'sInteractionCommand = "USSECNE1~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\SM2ART_Activities_dev.nsf~sec\develop\larry\feedbackMOD_dev.nsf~sec\Corporate Phone Directory.nsf~JMOA-6S4USH"
                '        'sInteractionCommand = "USSECNE1~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\SM2ART_Activities_dev.nsf~sec\develop\larry\feedbackMOD_dev.nsf~sec\Corporate Phone Directory.nsf~KSON-9L52HG"
            Else
                sInteractionCommand = "USSECNN6~sec\sm2art.nsf~sec\sm2art.nsf~sec\SM2ART_Activities.nsf~sec\feedbackMOD.nsf~sec\Corporate Phone Directory.nsf~" & OpportunityID
                '        'sInteractionCommand = "USSECNN6~sec\sm2art.nsf~sec\sm2art.nsf~sec\SM2ART_Activities.nsf~sec\feedbackMOD.nsf~sec\Corporate Phone Directory.nsf~JMOA-6S4USH"
            End If
        End If
        ' testing - USSECNE1~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\sm2art_dev.nsf~sec\develop\larry\SM2ART_Activities_dev.nsf~sec\develop\larry\feedbackMOD_dev.nsf~sec\Corporate Phone Directory.nsf~JMOA-6S4USH
        ' production - USSECNN6~sec\sm2art.nsf~sec\sm2art.nsf~sec\SM2ART_Activities.nsf~sec\feedbackMOD.nsf~sec\Corporate Phone Directory.nsf~JMOA-6S4USH
        ' training - USSECNN6~sec\train\sm2art_train.nsf~sec\train\SM2ART_Activities_train.nsf~sec\train\FeedbackMOD_train.nsf~sec\Corporate Phone Directory.nsf~TRAI-NNG001

        Dim HoldStr1 As Integer = (sInteractionCommand.IndexOf("~"c) + 1)
        ComServer = Strings.Left(sInteractionCommand, HoldStr1 - 1).Trim

        'If ComServer = " " Then
        '    ComServer = ""
        'End If

        Dim HoldStr2 As Integer = Strings.InStr(HoldStr1 + 1, sInteractionCommand, "~", CompareMethod.Text)
        HoldNotesCustomerPath = Strings.Mid(sInteractionCommand, HoldStr1 + 1, (HoldStr2 - HoldStr1) - 1)
        Dim HoldStr3 As Integer = Strings.InStr(HoldStr2 + 1, sInteractionCommand, "~", CompareMethod.Text)
        HoldNotesContactPath = Strings.Mid(sInteractionCommand, HoldStr2 + 1, (HoldStr3 - HoldStr2) - 1)
        Dim HoldStr4 As Integer = Strings.InStr(HoldStr3 + 1, sInteractionCommand, "~", CompareMethod.Text)
        HoldNotesActivitiesPath = Strings.Mid(sInteractionCommand, HoldStr3 + 1, (HoldStr4 - HoldStr3) - 1)
        Dim HoldStr5 As Integer = Strings.InStr(HoldStr4 + 1, sInteractionCommand, "~", CompareMethod.Text)
        HoldNotesFeedbackPath = Strings.Mid(sInteractionCommand, HoldStr4 + 1, (HoldStr5 - HoldStr4) - 1)
        Dim HoldStr6 As Integer = Strings.InStr(HoldStr5 + 1, sInteractionCommand, "~", CompareMethod.Text)
        HoldNotesPhonebookPath = Strings.Mid(sInteractionCommand, HoldStr5 + 1, (HoldStr6 - HoldStr5) - 1)
        Dim HoldStr7 As Integer = Strings.InStr(HoldStr6 + 1, sInteractionCommand, "~", CompareMethod.Text)

        If HoldStr7 = 0 Then
            HoldUniqueActivity = Strings.Mid(sInteractionCommand, HoldStr6 + 1)
        Else
            HoldUniqueActivity = Strings.Mid(sInteractionCommand, HoldStr6 + 1, (HoldStr7 - HoldStr6) - 1)
            result = False
        End If

        Return result

    End Function

    Public Function SetUpLotusLinkNew() As Boolean
        Dim HoldStr7, HoldStr6, HoldStr8 As Integer
        Dim tempdate As String = ""
        ' Dim NewExistingFlag As String
        Dim SMARTCadreFlag As String
        Dim NotesServer As String

        Try
            Dim NewExistingStr As Integer = (Interaction.Command().IndexOf("~"c) + 1)
            'NewExistingFlag = Strings.Left(Interaction.Command(), NewExistingStr - 1) ' Can be "New" or "Existing"

            Dim SMARTCadreStr As Integer = Strings.InStr(NewExistingStr + 1, Interaction.Command(), "~", CompareMethod.Text)
            SMARTCadreFlag = Strings.Mid(Interaction.Command(), NewExistingStr + 1, (SMARTCadreStr - NewExistingStr) - 1) ' Can be "SMART", "CADRE" or "ARCHIVE"

            Dim HoldStr1 As Integer = Strings.InStr(SMARTCadreStr + 1, Interaction.Command(), "~", CompareMethod.Text)
            NotesServer = Strings.Mid(Interaction.Command(), SMARTCadreStr + 1, (HoldStr1 - SMARTCadreStr) - 1)

            If NotesServer = "" Or NotesServer = " " Then NotesServer = "Local"

            If NotesServer = "Local" Then
                ComServer = ""
            Else
                ComServer = NotesServer
            End If

            Dim HoldStr2 As Integer = Strings.InStr(HoldStr1 + 1, Interaction.Command(), "~", CompareMethod.Text)
            HoldNotesSMARTCenterPath = Strings.Mid(Interaction.Command(), HoldStr1 + 1, (HoldStr2 - HoldStr1) - 1)

            Dim HoldStr3 As Integer = Strings.InStr(HoldStr2 + 1, Interaction.Command(), "~", CompareMethod.Text)
            HoldNotesActivitiesPath = Strings.Mid(Interaction.Command(), HoldStr2 + 1, (HoldStr3 - HoldStr2) - 1)

            Dim HoldStr4 As Integer = Strings.InStr(HoldStr3 + 1, Interaction.Command(), "~", CompareMethod.Text)
            HoldNotesFeedbackPath = Strings.Mid(Interaction.Command(), HoldStr3 + 1, (HoldStr4 - HoldStr3) - 1)

            Dim HoldStr5 As Integer = Strings.InStr(HoldStr4 + 1, Interaction.Command(), "~", CompareMethod.Text)
            HoldNotesPhonebookPath = Strings.Mid(Interaction.Command(), HoldStr4 + 1, (HoldStr5 - HoldStr4) - 1)

            HoldStr6 = Strings.InStr(HoldStr5 + 1, Interaction.Command(), "~", CompareMethod.Text)
            Hold_Customer_ID = Strings.Mid(Interaction.Command(), HoldStr5 + 1, (HoldStr6 - HoldStr5) - 1)

            HoldStr7 = Strings.InStr(HoldStr6 + 1, Interaction.Command(), "~", CompareMethod.Text)
            Hold_Contact_ID = Strings.Mid(Interaction.Command(), HoldStr6 + 1, (HoldStr7 - HoldStr6) - 1)

            HoldStr8 = Strings.InStr(HoldStr7 + 1, Interaction.Command(), "~", CompareMethod.Text)
            HoldUniqueActivity = Strings.Mid(Interaction.Command(), HoldStr7 + 1)

            TestVersion = Strings.Right(HoldNotesSMARTCenterPath, 8) = "_dev.nsf" Or Strings.Right(HoldNotesSMARTCenterPath, 8) = "_train.nsf"
            Contracts.Estimator = clsNotes.CN_Username

        Catch ex As Exception
            MessageBox.Show("Error Setting Link to Lotus Notes" & vbCrLf & vbCrLf & ex.Message, "Error Linking to Lotus Notes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Reset_Resolution()
            Return False
        End Try

        Return True

    End Function

    Public Sub SetAccessLevelsRole()
        If gbShape Then
            SetUserRoleAccess()
        Else
            SetAccessLevels()
        End If
    End Sub

    Public Sub SetAccessLevels()

        FULL_ACCESS = False
        ENABLE_BOOKING_BTN = False
        ENG_ACCESS = False
        SID_ACCESS = False
        HYDRO_ONLY_ACCESS = False
        If clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) Then
            If clsNotes.NotesDocProfile("Cadre Access Control Profile") Then
                FULL_ACCESS = FindMemberInGroups("debugMembers", "debugMembers_additional_dsp")
                ENABLE_BOOKING_BTN = FindMemberInGroups("bookingMembers", "bookingMembers_additional_dsp")
                ENG_ACCESS = FindMemberInGroups("engineerMembers", "engineerMembers_additional_dsp")
                SID_ACCESS = FindMemberInGroups("MODCostMembers", "MODCostMembers_additional_dsp")
                HYDRO_ONLY_ACCESS = FindMemberInGroups("SSMembers", "SSMembers_additional_dsp")
            End If
        End If
        If IsPilotOffice Then
            FULL_ACCESS = True
        End If

    End Sub
    Public Sub SetUserRoleAccess()

        FULL_ACCESS = False
        ENABLE_BOOKING_BTN = False
        ENG_ACCESS = False
        SID_ACCESS = False
        HYDRO_ONLY_ACCESS = False
        Select Case UserRole
            Case USER_MANAGER, USER_QM_MANAGER
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case USER_SALES, USER_QM_SALES
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case USER_ENGINEER
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case "Developer"
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case USER_DIRECTOR, USER_QM_DIRECTOR
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case "Super User"
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
            Case Else
                FULL_ACCESS = True
                ENABLE_BOOKING_BTN = True
                ENG_ACCESS = True
                SID_ACCESS = True
                HYDRO_ONLY_ACCESS = False
        End Select

    End Sub

    Private Function FindMemberInGroups(ByRef ReaderField As String, ByRef ReaderFieldAdditional As String) As Boolean
        Dim result As Boolean = False

        If clsNotes.GetValue_Readers(ReaderField) Then
            For i As Integer = ReadersValue.GetLowerBound(0) To ReadersValue.GetUpperBound(0)
                If NotesUserName = ReadersValue(i) Then
                    result = True
                    Exit For
                End If
            Next i
        End If
        If Not result Then
            If clsNotes.GetValue_Readers(ReaderFieldAdditional) Then
                For i As Integer = ReadersValue.GetLowerBound(0) To ReadersValue.GetUpperBound(0)
                    If NotesUserName = ReadersValue(i) Then
                        result = True
                        Exit For
                    End If
                Next i
            End If
        End If
        Return result

    End Function

    Private Sub AttachToDBName(ByRef Path As String, ByRef DBName As String)
        If Not clsNotes.NotesDBName(ComServer, Path) Then
            MessageBox.Show("Could not find " & DBName & " database!", Application.ProductName)
            EndProgram()
        End If
    End Sub

    Private Sub AttachToDBView(ByRef ViewName As String)
        If Not clsNotes.NotesDBView(ViewName) Then
            MessageBox.Show("Could not find " & ViewName & " view", Application.ProductName)
            EndProgram()
        End If
    End Sub

    Private Function AttachToRecord(ByRef UniqueKey As String, ByRef KeyType As String) As Boolean
        AttachToRecord = False
        If Not clsNotes.NotesDocKey(UniqueKey) Then
            Select Case KeyType
                Case "Company"
                    MessageBox.Show("Company name not found in the " & SMART & " database!" & Environment.NewLine & "Key = " & Strings.Chr(34).ToString() & UniqueKey & Strings.Chr(34).ToString(), Application.ProductName)
                Case "Contact"
                    MessageBox.Show("Contact information is missing or has been deleted from the " & SMART & " database!" & Environment.NewLine & "Key = " & Strings.Chr(34).ToString() & UniqueKey & Strings.Chr(34).ToString(), Application.ProductName)
                    MissingContactInfo = True
                    Exit Function
                Case "Feedback"
                    If gbShape Then
                        Exit Function
                    Else
                        MessageBox.Show("Estimate not found in the " & Feedback & " database!" & Environment.NewLine & "Key = " & Strings.Chr(34).ToString() & UniqueKey & Strings.Chr(34).ToString(), "Error in LotusLnk.AttachToRecord", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case Else
            End Select
            EndProgram()
        End If
        AttachToRecord = True

    End Function

    Public Sub VerifyPath(ByRef FolderPath As String)
        If Not clsNotes.CADREFilePath(FolderPath) Then
            MessageBox.Show("Path not valid!" & Strings.Chr(10).ToString() & FolderPath, Application.ProductName)
            EndProgram()
        End If
    End Sub

    Public Function Attach_To_Feedback() As Boolean
        AttachToDBName(HoldNotesFeedbackPath, Feedback)
        AttachToDBView("(LU Activity Unique)")
        Attach_To_Feedback = AttachToRecord(HoldUniqueActivity, "Feedback")
    End Function

    Private Sub Attach_To_SmartCenter_Contact()
        If NewExistingFlag = "Existing" Then
            AttachToDBName(HoldNotesContactPath, SMART)
        Else
            AttachToDBName(HoldNotesSMARTCenterPath, SMART)
        End If

        AttachToDBView("(LU Contact Unique)")
        AttachToRecord(Hold_Contact_ID, "Contact")
    End Sub

    Private Sub Attach_To_SmartCenter_Customer()
        If NewExistingFlag = "Existing" Then
            AttachToDBName(HoldNotesCustomerPath, SMART)
        Else
            AttachToDBName(HoldNotesSMARTCenterPath, SMART)
        End If

        AttachToDBView("(LU Unique Company)")
        AttachToRecord(Hold_Customer_ID, "Company")
    End Sub
    '    Public Function Attach_To_Estimating_Feedback() As Boolean
    '        Dim result As Boolean = False

    '        result = clsNotes.NotesDBName("", NotesPath & "\feedback.nsf") 'Estimating Feedback
    '        If result Then
    '            AttachToDBView("ID For Modernization")
    '        End If
    '        Return result

    '    End Function
    Private Function TrimFields(ByVal strField As String) As String

        strField = strField.Trim()
        Do Until Strings.Right(strField, 1) <> Strings.Chr(13) And Strings.Right(strField, 1) <> Environment.NewLine And Strings.Right(strField, 1) <> vbFormFeed And Strings.Right(strField, 1) <> vbLf And Strings.Right(strField, 1) <> Environment.NewLine
            strField = Strings.Left(strField, strField.Length - 1)
        Loop
        Return strField

    End Function
    '    Public Sub Get_FieldSupID()

    '        Try
    '            FieldSup_ID = ""
    '            If Screen_BOOK.SuperintendentName = "ZZZ Other" Or Screen_BOOK.SuperintendentName = "" Then
    '                Exit Sub
    '            End If
    '            If Not clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) OrElse Not clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") OrElse Not clsNotes.NotesDocKey(Screen_BOOK.SuperintendentName) Then
    '                Throw New Exception()
    '            End If
    '            FieldSup_ID = clsNotes.GetValue("EmployeeID")

    '        Catch

    '        End Try


    '    End Sub
    '    Public Sub Get_SalesRepID()

    '        Try
    '            SalesRep_ID = ""
    '            If Contracts.SalesRepName = "ZZZ Other" Or Contracts.SalesRepName = "" Then
    '                Exit Sub
    '            End If
    '            If Not clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) OrElse Not clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") OrElse Not clsNotes.NotesDocKey(Contracts.SalesRepName) Then
    '                Throw New Exception()
    '            End If
    '            SalesRep_ID = clsNotes.GetValue("EmployeeID")

    '        Catch

    '        End Try


    '    End Sub
    '    Public Sub Get_ServiceRepID()

    '        Try

    '            ServiceRepID = ""
    '            If Screen_BOOK.ServiceRep = "ZZZ Other" Or Screen_BOOK.ServiceRep = "" Then
    '                Exit Sub
    '            End If
    '            If Not clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) OrElse Not clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") OrElse Not clsNotes.NotesDocKey(Screen_BOOK.ServiceRep) Then
    '                Throw New Exception()
    '            End If
    '            ServiceRepID = clsNotes.GetValue("EmployeeID")

    '        Catch

    '        End Try


    '    End Sub
    Private Sub RetrieveBuildingType(ByRef XML As String)
        Dim iPos, iPos2 As Integer
        Dim TempStr, ReturnValue As String
        Dim _myList As New List(Of String)()

        Contracts.BuildingType = String.Empty
        Contracts.IsCampus = False
        If XML.Trim().Length > 0 Then
            iPos = (XML.IndexOf("<building_type>") + 1) + 15
            TempStr = Strings.Mid(XML, iPos).Trim()
            iPos2 = TempStr.IndexOf("</building_type>")
            TempStr = Strings.Left(TempStr, iPos2).Trim()
            If TempStr = "*" Then
                Contracts.BuildingType = TempStr
            Else
                ReturnValue = "Code"
                '                Where = "Description = " & FixSQLString(TempStr)
                Dim sql As String = "SELECT code & ' - ' &  Description AS BldgCode FROM [Building Code] WHERE Description = " & FixSQLString(TempStr)
                _myList = GetDataFromOptions(sql)
                '                If Record_FindFirst(ADOConnectionMODDataDataBase, ADOCatalogMODDataDataBase, BUILDING_CODE_TABLE_QUERY_NAME, Where, 0, ReturnValue) <> RECORD_NOT_FOUND Then
                If _myList.Count <> 0 Then
                    Contracts.BuildingType = _myList(0)
                End If
            End If
            If Strings.InStr(iPos, XML, "<building_type>") > 0 Then
                Contracts.IsCampus = True
                '            End If
            End If
        End If
    End Sub
    '    Private Function ReadDataFromA2BFile(ByRef sFileName As String) As String
    '        Dim ExportFileHandle As Integer
    '        Dim ThisInputFilePathAndName, RecordBuffer, ThisTag, ThisValue As String
    '        Dim i As Integer
    '        Dim s As New StringBuilder()

    '        Try
    '            ExportFileHandle = FileSystem.FreeFile()
    '            ThisInputFilePathAndName = sFileName
    '            FileSystem.FileOpen(ExportFileHandle, ThisInputFilePathAndName, OpenMode.Input, OpenAccess.Read)
    '            i = 0
    '            Do While Not FileSystem.EOF(ExportFileHandle)
    '                RecordBuffer = ""
    '                ThisTag = ""
    '                RecordBuffer = FileSystem.LineInput(ExportFileHandle)
    '                If Strings.Left(RecordBuffer, 5) = "[BANK" Then
    '                    i += 1
    '                    ReDim Preserve PreBidMOD_BankInfo(i)
    '                    PreBidMOD_BankInfo(i).Bank = Strings.Mid(RecordBuffer, 7, 1)
    '                    s.Append(Strings.Mid(RecordBuffer, 7, 1))
    '                    Do While Not FileSystem.EOF(ExportFileHandle)
    '                        FileSystem.Input(ExportFileHandle, RecordBuffer)
    '                        If Strings.Left(RecordBuffer, 13) = "EquipmentType" Then
    '                            ThisTag = Strings.Mid(RecordBuffer, 15).Trim()
    '                            Select Case ThisTag
    '                                Case "Geared"
    '                                    s.Append("1")
    '                                Case "Hydro"
    '                                    s.Append("3")
    '                                Case "Gearless"
    '                                    s.Append("2")
    '                            End Select
    '                        ElseIf Strings.Left(RecordBuffer, 8) = "Control;" Then
    '                            Select Case Strings.Mid(RecordBuffer, 9).Trim()
    '                                Case SID_PH_MOD, SID_MTO, SID_DI : PreBidMOD_BankInfo(i).SID_Control = True
    '                                Case Else : PreBidMOD_BankInfo(i).SID_Control = False
    '                            End Select
    '                        ElseIf (RecordBuffer.IndexOf("ChangingTravel") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).ChangingTravel = Conversion.Val(ThisValue)
    '                        ElseIf (RecordBuffer.IndexOf("ChangingSpeed") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).ChangingSpeed = Conversion.Val(ThisValue)
    '                        ElseIf (RecordBuffer.IndexOf("ChangingCapacity") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).ChangingCapacity = Conversion.Val(ThisValue)
    '                        ElseIf (RecordBuffer.IndexOf("RegionLocalMOD") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).RegionLocalMOD = Conversion.Val(ThisValue)
    '                            Exit Do
    '                        ElseIf (RecordBuffer.IndexOf("SID") + 1) Then
    '                            PreBidMOD_BankInfo(i).SID_Alternate = Conversion.Val(Strings.Right(RecordBuffer, 1)) = CheckState.Checked
    '                        ElseIf (RecordBuffer.IndexOf("DriveType") + 1) Then
    '                            ThisValue = Strings.Mid(RecordBuffer, 11).Trim()
    '                            PreBidMOD_BankInfo(i).DriveType = ThisValue
    '                        ElseIf (RecordBuffer.IndexOf("ExistingRoping") + 1) Then
    '                            ThisValue = Strings.Mid(RecordBuffer, 16).Trim()
    '                            PreBidMOD_BankInfo(i).ExistingRoping = ThisValue
    '                        ElseIf (RecordBuffer.IndexOf("OEM") + 1) Then
    '                            ThisValue = Strings.Mid(RecordBuffer, 5).Trim()
    '                            PreBidMOD_BankInfo(i).OEM = ThisValue
    '                        ElseIf (RecordBuffer.IndexOf("CarTieInToExistingBank") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).RegionLocalMOD = Conversion.Val(ThisValue)
    '                        ElseIf (RecordBuffer.IndexOf("NonstandardControlFeatures") + 1) Then
    '                            ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                            PreBidMOD_BankInfo(i).NonstandardControlFeatures = Conversion.Val(ThisValue)
    '                        ElseIf (RecordBuffer.IndexOf("RearOpening") + 1) Then
    '                            PreBidMOD_BankInfo(i).PreBidRearOpening = Conversion.Val(Strings.Right(RecordBuffer, 1)) = CheckState.Checked
    '                        End If
    '                    Loop
    '                ElseIf RecordBuffer.IndexOf("secureMaintenanceFlag") >= 0 Then
    '                    ThisValue = CStr(Conversion.Val(Strings.Right(RecordBuffer, 1)))
    '                    If ThisValue = CheckState.Checked Then
    '                        Contracts.CurrentMaintenance = "Yes"
    '                    Else
    '                        Contracts.CurrentMaintenance = "No"
    '                    End If
    '                ElseIf RecordBuffer.IndexOf("NumTeams") >= 0 Then
    '                    ThisValue = Strings.Mid(RecordBuffer, 10)
    '                    Contracts.NumberSimultaneousTeams = Conversion.Val(ThisValue)
    '                ElseIf RecordBuffer.IndexOf("RMMFactorAdder") >= 0 Then
    '                    ThisValue = CStr(Conversion.Val(Strings.Mid(RecordBuffer, 16)))
    '                    Contracts.RMMFactorAdder = Conversion.Val(ThisValue)
    '                ElseIf RecordBuffer.IndexOf("CurrentProvider") >= 0 Then
    '                    ThisValue = Strings.Mid(RecordBuffer, 17).Trim()
    '                    Contracts.CurrentMaintenanceProvider = ThisValue
    '                    If Contracts.CurrentMaintenanceProvider = SEC Then
    '                        Contracts.JobClassification = "Retention"
    '                    Else
    '                        Contracts.JobClassification = "Recovery"
    '                    End If
    '                ElseIf Strings.Left(RecordBuffer, 12) = "CustomerTier" Then
    '                    If String.IsNullOrEmpty(Contracts.CustomerTier) Then
    '                        Contracts.CustomerTier = Strings.Mid(RecordBuffer, 14).Trim()
    '                    End If
    '                End If
    '            Loop
    '            FileSystem.FileClose(ExportFileHandle)

    '        Catch
    '            MessageBox.Show(Conversion.ErrorToString(), "ReadDataFromFile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '        End Try
    '        Return s.ToString()

    '    End Function
    '    Private Sub CompareProductCodesByBank(ByVal ThisPC As Integer, ByVal OriginalPC As Integer, ByRef TotalNum As Integer, ByRef TotalDollars As Single, ByRef UsePrice As Single, ByRef AddDollars As Boolean)
    '        Dim AddPC As Boolean = False

    '        Select Case ThisPC
    '            Case 600, 630
    '                Select Case OriginalPC
    '                    Case 600, 630
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 610
    '                Select Case OriginalPC
    '                    Case 610
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 612 To 613
    '                Select Case OriginalPC
    '                    Case 612 To 613
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 615
    '                Select Case OriginalPC
    '                    Case 615
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 660, 661
    '                Select Case OriginalPC
    '                    Case 660, 661
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 664, 665
    '                Select Case OriginalPC
    '                    Case 664, 665
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 641 To 644, 667, 668
    '                Select Case OriginalPC
    '                    Case 641 To 644, 667, 668
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 646 To 649
    '                Select Case OriginalPC
    '                    Case 646 To 649
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 670
    '                Select Case OriginalPC
    '                    Case 670
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 645, 676 To 679
    '                Select Case OriginalPC
    '                    Case 645, 676 To 679
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 680 To 683, 669
    '                Select Case OriginalPC
    '                    Case 680 To 683, 669
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case 691 To 692
    '                Select Case OriginalPC
    '                    Case 691 To 692
    '                    Case Else
    '                        AddPC = True
    '                End Select
    '            Case Else
    '        End Select
    '        If AddPC Then
    '            TotalNum += 1
    '            TotalDollars += UsePrice
    '        ElseIf AddDollars Then
    '            TotalDollars += UsePrice
    '        End If

    '    End Sub
    '    Private Function HasValidProposal(ByRef UseBank As String, ByRef UseAlt As String, ByRef FileName As String) As Boolean
    '        Dim fso As Scripting.FileSystemObject = Nothing
    '        Dim myfile As Scripting.File = Nothing
    '        Dim ProposalFileName As String = ""
    '        Dim GetDOCX As Boolean

    '        Try
    '            GetDOCX = False
    '            fso = MemoryHelper.ReleaseAndCleanObject(Of Scripting.FileSystemObject)(fso, New Scripting.FileSystemObject())
    '            ProposalFileName = ReportsPath & Contracts.EstimateNum & UseBank & UseAlt & FileName

    'ContinueHere:
    '            myfile = MemoryHelper.ReleaseAndCleanObject(Of Scripting.File)(myfile, fso.GetFile(ProposalFileName))
    '            If myfile.DateLastModified.Year < 2009 Then
    '                Throw New Exception()
    '            End If
    '            Return True

    '        Catch e As System.Exception
    '            If TypeOf e Is FileNotFoundException Then ' File not found
    '                If Not GetDOCX Then
    '                    GetDOCX = True
    '                    ProposalFileName = ProposalFileName & "x"
    '                    GoTo ContinueHere
    '                End If
    '            End If
    '            Return False

    '        End Try

    '    End Function
    '    Private Sub SaveSalesPlannerData(ByRef PlannerField As String, ByRef PlannerVal As Object, ByRef IsDollarVal As Boolean, Optional ByRef SetPlannerDate As Boolean = False)

    '        If clsNotes.GetValue(PlannerField).ToString <> PlannerVal.ToString Then
    '            clsNotes.SetValue(PlannerField, PlannerVal)
    '            If Not IsDollarVal Then
    '                SetPlannerDate = True
    '            End If
    '        End If

    '    End Sub

    Public Sub Populate_SalesRep(ByRef ComboCntl As ComboBox)
        Dim RepField As String = ""

        ComboCntl.Items.Clear()
        If Not (Not clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) OrElse Not clsNotes.NotesDocProfile("Names")) Then
            'If clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) OrElse clsNotes.NotesDocProfile("Names") Then  'AA
            RepField = IIf(All_LocalCodeDep.CanadaJob, "SalesRepNames_TOR", "SalesRepNames_SEC")
            If Not clsNotes.GetValue_Readers(RepField) Then
                RepField = "SalesRepNames"
            End If
            clsNotes.GetArray(RepField, ComboCntl)
        End If
        ComboCntl.Items.Add("ZZZ Other")

    End Sub

    '    Public Sub Populate_FieldSup(ByRef ComboCntl As ComboBox, ByRef FilterNames As Boolean, ByRef AddZZZOther As Boolean)
    '        Dim FieldSup_Field As String = ""

    '        If [ComboCntl].Text <> "" Then
    '            tempstore = [ComboCntl].Text
    '        End If
    '        [ComboCntl].Items.Clear()
    '        If Not (Not clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) OrElse Not clsNotes.NotesDocProfile("Names")) Then
    '            FieldSup_Field = IIf(All_LocalCodeDep.CanadaJob, "FieldSupervisorNames_TOR", "FieldSupervisorNames_SEC")
    '            If Not clsNotes.GetValue_Readers(FieldSup_Field) Then
    '                FieldSup_Field = "FieldSupervisorNames"
    '            End If
    '            clsNotes.GetArray(FieldSup_Field, [ComboCntl])
    '            If FilterNames Then
    '                FilterNamesByRegion([ComboCntl])
    '            End If
    '        End If
    '        If AddZZZOther Then
    '            [ComboCntl].Items.Add("ZZZ Other")
    '        End If
    '        AssignListIndex([ComboCntl], tempstore)

    '    End Sub
    '    Public Sub FilterNamesByRegion(ByRef cmb As ComboBox)
    '        Dim jIndx As Integer = 1
    '        Dim AllNames() As String = Nothing, AddNames() As String = Nothing

    '        If [cmb].Items.Count = 0 OrElse Contracts.RegionCode.Length = 0 OrElse Not clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) OrElse _
    '           Not clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") Then
    '            Exit Sub
    '        End If
    '        For iIndx As Integer = 0 To [cmb].Items.Count - 1
    '            ReDim Preserve AllNames(iIndx)
    '            AllNames(iIndx) = [cmb].GetListItem(iIndx)
    '        Next iIndx
    '        ReDim AddNames(0)
    '        For iIndx As Integer = 0 To AllNames.GetUpperBound(0)
    '            If clsNotes.NotesDocKey(AllNames(iIndx)) Then
    '                If clsNotes.GetValue("RegionCode").IndexOf(Contracts.RegionCode) >= 0 Then
    '                    ReDim Preserve AddNames(jIndx)
    '                    AddNames(jIndx) = AllNames(iIndx)
    '                    jIndx += 1
    '                End If
    '            End If
    '        Next iIndx
    '        If AddNames.GetUpperBound(0) > 0 Then
    '            [cmb].Items.Clear()
    '            For iIndx As Integer = 0 To AddNames.GetUpperBound(0)
    '                [cmb].Items.Add(AddNames(iIndx))
    '            Next iIndx
    '        End If

    '    End Sub

    Public Function GetNotesDataDir() As String
        Dim nDirectory As String = "C:\Notes\Data"

        On Error GoTo GETNOTESDATADIR_ERROR

        If Directory.Exists(nDirectory) Then
            Return nDirectory
        Else
            Dim appDataPath As String = GetFolderPath(SpecialFolder.LocalApplicationData)
            If Not String.IsNullOrEmpty(appDataPath) Then
                nDirectory = appDataPath & "\Lotus\Notes\Data"
                If Directory.Exists(nDirectory) Then
                    Return nDirectory
                Else
                    nDirectory = appDataPath & "\IBM\Notes\Data"
                    If Directory.Exists(nDirectory) Then
                        Return nDirectory
                    End If
                End If
            End If
        End If

GETNOTESDATADIR_ERROR:
        Return ""

    End Function

    Public Sub GetSalesRepData()
        Dim UseSalesRep As String = Contracts.SalesRepName.Trim

        If String.IsNullOrEmpty(UseSalesRep) OrElse UseSalesRep.ToUpper = "ZZZ OTHER" Then
            Attach_To_SmartCenter_Customer()
            iPos = (clsNotes.GetValue("SalesRep").IndexOf("/"c) + 1)
            If iPos = 0 Then
                Contracts.SalesRepName = clsNotes.GetValue("SalesRep")
            Else
                Contracts.SalesRepName = Strings.Mid(clsNotes.GetValue("SalesRep"), 4, iPos - 4)
            End If
            If NewExistingFlag = "Existing" Then
                Attach_To_Feedback()
            End If

        End If
        Contracts.SalesRepPhone = String.Empty
        Contracts.SalesRepAddress1 = String.Empty
        Contracts.SalesRepAddress2 = String.Empty
        Contracts.SalesRepCity = String.Empty
        Contracts.SalesRepState = String.Empty
        Contracts.SalesRepZip = String.Empty
        Contracts.SalesRepFax = String.Empty
        Contracts.SalesRepTitle = String.Empty
        Contracts.SalesRepOffice = String.Empty
        Contracts.SalesRepEmail = String.Empty
        Contracts.SalesRepMgrName = String.Empty
        Contracts.EmployeeType = String.Empty
        If clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) And clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") And clsNotes.NotesDocKey(Contracts.SalesRepName) Then
            Contracts.SalesRepPhone = clsNotes.GetValue("Phone")
            Contracts.SalesRepAddress1 = clsNotes.GetValue("Address1")
            Contracts.SalesRepAddress2 = clsNotes.GetValue("Address2")
            Contracts.SalesRepCity = clsNotes.GetValue("City")
            Contracts.SalesRepState = clsNotes.GetValue("State")
            Contracts.SalesRepZip = clsNotes.GetValue("Zip")
            Contracts.SalesRepFax = clsNotes.GetValue("Phone_1")
            Contracts.SalesRepTitle = clsNotes.GetValue("display_Title")
            Contracts.SalesRepOffice = TranslateOfficeNumber(clsNotes.GetValue("OfficeNum"))
            Contracts.SalesRepEmail = clsNotes.GetValue("email")
            Contracts.SalesRepMgrName = clsNotes.GetValue("Manager")
            Contracts.EmployeeType = clsNotes.GetValue("Type")
            iPos = (Contracts.SalesRepMgrName.IndexOf("/"c) + 1)
            Contracts.SalesRepMgrName = Strings.Mid(Contracts.SalesRepMgrName, 4, iPos - 4)
        End If

    End Sub
    Public Function ReCreatesNotesLinkDataUserName(ByVal sNotesLinkDataUserName As String) As String
        Dim s As String = ""
        Dim i As Integer = InStr(1, sNotesLinkDataUserName, "=")
        Dim j As Integer = InStr(1, sNotesLinkDataUserName, "/")

        Do While i > 0
            s = s & Mid$(sNotesLinkDataUserName, i + 1, j - i)
            i = InStr(j + 1, sNotesLinkDataUserName, "=")
            j = InStr(i + 1, sNotesLinkDataUserName, "/")
        Loop
        Return Left$(s, Len(s) - 1)

    End Function

    Public Function SetupSuptReviewLink() As Boolean
        Dim DataBaseError As String = ""
        Dim SUPT As String = ""
        Dim ComServerSupt As String = ""
        Dim bNotesDocKey As Boolean = False

        Try
            If TestVersion Then
                ComServerSupt = "USSECNE1"
                SUPT = "sec\develop\Larry\Approval Center_dev.nsf"
            Else
                ComServerSupt = "USSECNN4"
                SUPT = "sec\ApprovalCenter.nsf"
            End If
            If Not clsNotes.NotesDBName(ComServerSupt, SUPT) Then
                DataBaseError = DataBaseError & "Missing - Supt Review Approval Center_dev.nsf"
                Throw New Exception()
            End If
            If Not clsNotes.NotesDBView("(LU review key)") Then
                MessageBox.Show("Could not find (LU review key) View", Application.ProductName)
                EndProgram()
            End If
            bNotesDocKey = True

        Catch
            MessageBox.Show("Error in Lotus Link, missing or corrupt local Notes Supt database." & Environment.NewLine & "Closing Cadre!", "Error")
            EndProgram()

        End Try

        Return bNotesDocKey

    End Function

    Public Function Get_SuptStatus(ByVal sStatusDecision As String) As String
        Dim sSuptStatus As String = ""

        If SetupSuptReviewLink() Then
            If clsNotes.FindSUPTDocument() Then
                Select Case sStatusDecision
                    Case "Decision"
                        sSuptStatus = clsNotes.GetValue("Decision")
                    Case "Status"
                        sSuptStatus = clsNotes.GetValue("Status")
                End Select
            End If
        End If
        Return sSuptStatus

    End Function


    Private Function Get_ProbabilityofSale(ByRef Range As String) As Integer

        Select Case Range
            Case "0-25%"
                Return 12
            Case "26-50%"
                Return 38
            Case "51-75%"
                Return 63
            Case "76-99%"
                Return 82
            Case "100%"
                Return 100
            Case Else
                Return 0
        End Select

    End Function

    Public Function Map_ProbabilityofSale(ByRef ReadValue As String) As String

        If ReadValue.IndexOf("-") > -1 Then
            Return ReadValue
        Else
            Select Case Conversion.Val(ReadValue)
                Case Is <= 25
                    Return "0-25%"
                Case Is <= 50
                    Return "26-50%"
                Case Is <= 75
                    Return "51-75%"
                Case Is <= 90
                    Return "75-99"
                Case Else
                    Return "100%"
            End Select
        End If

    End Function

    Public Sub CreateActivity()

        If Not clsNotes.NotesDBName(ComServer, HoldNotesActivitiesPath) Then
            MessageBox.Show("Error in CreateActivity.  Closing Cadre.", Application.ProductName)
            Reset_Resolution()
            Environment.Exit(0)
        End If
        clsNotes.CreateDOCandCompute("Activity")
        clsNotes.SetValue("ActivityUnique", HoldUniqueActivity)
        clsNotes.SetValue("form", "Activity")
        clsNotes.SetValue("contact", JobContact.Name)
        clsNotes.SetValue("custname", Contracts.JobName)
        clsNotes.SetValue("activityType", "Created MOD Estimate")
        clsNotes.SetValue_Readers("salesRep", Contracts.SalesRepName)
        clsNotes.SetValue_Readers("salesRep_1", clsNotes.CN_Username)
        clsNotes.SetValue("office", Contracts.InstallingOffice)
        clsNotes.SetValue("lcName", Contracts.LCName)
        clsNotes.SetValue("district", Contracts.District)
        clsNotes.SetValue("region", Contracts.Region)
        clsNotes.SetValue("Area", Contracts.Area)
        clsNotes.SetValue("Territory", Contracts.Territory)
        clsNotes.SetValue("organizationLevel_1", Contracts.InstallingOffice)
        clsNotes.SetValue("organizationLevel_2", Contracts.District)
        clsNotes.SetValue("organizationLevel_3", Contracts.Region)
        If All_LocalCodeDep.CanadaJob Then
            clsNotes.SetValue("kg", "TOR")
        Else
            clsNotes.SetValue("kg", "SEC")
        End If
        clsNotes.SetValue("unique", Hold_Customer_ID)
        clsNotes.SetValue("contactUnique", Hold_Contact_ID)
        clsNotes.SetValue_Readers("Reader", Contracts.Reader)
        clsNotes.SetValue_Readers("reader_global", Contracts.ReaderGlobal)
        clsNotes.SetValue_Readers("Reader_Admin", "[ADMIN]")
        clsNotes.SetValue_Readers("AdminReader", "[ADMIN]")

    End Sub
End Module