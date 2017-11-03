Option Strict Off
Option Explicit On
Imports System.IO

Public Class UnitCopyMerge_frm
    Public CurUnits As String = String.Empty
    Public UnitOptions() As String = Nothing
    Public CopyMergeStatus As String = String.Empty
    Private FilesCreated() As String = Nothing, FilesDeleted() As String = Nothing

    Private Sub Cancel_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_cmd.Click
        CopyMergeStatus = "Cancelled"
        Me.Cursor = Cursors.Default
        Me.Dispose()
    End Sub
    Private Sub UnitCopyMerge_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrepareThisForm()
    End Sub
    Private Sub PrepareThisForm()

        CopyMergeStatus = String.Empty
        UnitsFrom_lbl.Text = CurUnits
        UnitsTo_cmb.Items.Clear()
        For iIndex As Integer = UnitOptions.GetLowerBound(0) To UnitOptions.GetUpperBound(0)
            UnitsTo_cmb.Items.Add(UnitOptions(iIndex))
        Next iIndex
        UnitsTo_cmb.SelectedIndex = -1
        UnitsTo_cmb.Enabled = True
        CopyMerge_cmd.Text = Me.Text

    End Sub
    Private Sub CopyMerge_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMerge_cmd.Click
        Dim EST_Filename As String = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                                 FormatFileNameFromTab(CurUnits & EST_Suffix)) & "MODEST.JSON"
        Dim EST_NewFilename As String = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                                    FormatFileNameFromTab(UnitsTo_cmb.Text & EST_Suffix)) & "MODEST.JSON"
        Dim TempDataset As System.Data.DataSet = EstimatingDataset
        Dim iIndex As Integer = 0, jIndex As Integer = 0, AryIndex As Integer = 0
        Dim TempUnits As String = String.Empty
        Dim UseGeneralInfo As DataTable = Nothing
        Dim CurDataRow As DataRow = Nothing
        Dim TempUnitsInEstimate() As String = Nothing

        Try
            If UnitsTo_cmb.SelectedIndex = -1 Then
                MsgBox("You have not selected the Unit to which you want to " & CopyMerge_cmd.Text & "!", MsgBoxStyle.Critical, "Units To Not Selected")
                Exit Sub
            End If
            If Me.Text.Contains("Copy") Then
                frmEstimatingBase.TabControl1.TabPages.Add(UnitsTo_cmb.Text.Trim & EST_Suffix)
                If File.Exists(EST_Filename) Then
                    'Create newly copied json file and update Units
                    File.Copy(EST_Filename, EST_NewFilename)
                    AddToFilesList("Created", EST_NewFilename)
                    If Not Deserialize(EST_NewFilename, TempDataset, "Error Creating Copy - Updating new data", False) Then
                        Throw New Exception()
                    End If
                    UseGeneralInfo = TempDataset.Tables(TABLENAME_GENERALINFO)
                    CurDataRow = UseGeneralInfo.Rows(0)
                    CurDataRow("UnitsInTab") = UnitsTo_cmb.Text
                    If Not Serialize(EST_NewFilename, TempDataset, "Error Creating Copy - Saving new data", False) Then
                        Throw New Exception()
                    End If
                    'Remove the split Unit from the current tab and then update current json file with updated units
                    CalculateNumberOfCarsInEstimate(CurUnits)
                    For iIndex = UnitsInEstimate.GetLowerBound(0) To UnitsInEstimate.GetUpperBound(0)
                        If Math.Round(Conversion.Val(UnitsInEstimate(iIndex))) = Math.Round(Conversion.Val(UnitsTo_cmb.Text)) Then
                            UnitsInEstimate(iIndex) = -999
                            Exit For
                        End If
                    Next iIndex
                    For iIndex = UnitsInEstimate.GetLowerBound(0) To UnitsInEstimate.GetUpperBound(0)
                        If UnitsInEstimate(iIndex) <> "-999" Then
                            ReDim Preserve TempUnitsInEstimate(AryIndex)
                            TempUnitsInEstimate(AryIndex) = UnitsInEstimate(iIndex)
                            AryIndex += 1
                        End If
                    Next iIndex
                    TempUnits = String.Empty
                    For iIndex = TempUnitsInEstimate.GetLowerBound(0) To TempUnitsInEstimate.GetUpperBound(0)
                        TempUnits &= TempUnitsInEstimate(iIndex) & ","
                    Next iIndex
                    TempUnits = Strings.Left(TempUnits, TempUnits.Length - 1)
                    EST_NewFilename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                                  FormatFileNameFromTab(FormatUnits(TempUnits) & EST_Suffix)) & "MODEST.JSON"
                    TempDataset = EstimatingDataset
                    File.Copy(EST_Filename, EST_NewFilename)
                    AddToFilesList("Created", EST_NewFilename)
                    If Not Deserialize(EST_NewFilename, TempDataset, "Error Creating Copy - Updating current data", False) Then
                        Throw New Exception()
                    End If
                    UseGeneralInfo = TempDataset.Tables(TABLENAME_GENERALINFO)
                    CurDataRow = UseGeneralInfo.Rows(0)
                    CurDataRow("UnitsInTab") = TempUnits
                    If Not Serialize(EST_NewFilename, TempDataset, "Error Creating Copy - Saving current data", False) Then
                        Throw New Exception()
                    End If
                    AddToFilesList("Deleted", EST_Filename)
                End If
            Else
                CalculateNumberOfCarsInEstimate(CurUnits)
                Erase TempUnitsInEstimate
                TempUnitsInEstimate = UnitsInEstimate
                CalculateNumberOfCarsInEstimate(UnitsTo_cmb.Text)
                AryIndex = UnitsInEstimate.Length + 1
                For iIndex = TempUnitsInEstimate.GetLowerBound(0) To TempUnitsInEstimate.GetUpperBound(0)
                    ReDim Preserve UnitsInEstimate(AryIndex)
                    UnitsInEstimate(AryIndex) = TempUnitsInEstimate(iIndex)
                    AryIndex += 1
                Next iIndex
                TempUnits = String.Empty
                For iIndex = UnitsInEstimate.GetLowerBound(0) To UnitsInEstimate.GetUpperBound(0)
                    TempUnits &= UnitsInEstimate(iIndex) & ","
                Next iIndex
                TempUnits = Strings.Left(TempUnits, TempUnits.Length - 1)
                AddToFilesList("Deleted", EST_Filename)
                EST_Filename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                           FormatFileNameFromTab(UnitsTo_cmb.Text & EST_Suffix)) & "MODEST.JSON"
                EST_NewFilename = EstimatePath & Get_FileName(Contracts.EstimateNum, CurrentGOData_Typ.Bank, CurrentGOData_Typ.Alt,
                                                              FormatFileNameFromTab(FormatUnits(TempUnits) & EST_Suffix)) & "MODEST.JSON"
                If EST_Filename <> EST_NewFilename Then
                    File.Copy(EST_Filename, EST_NewFilename)
                    AddToFilesList("Created", EST_NewFilename)
                    AddToFilesList("Deleted", EST_Filename)
                End If
                TempDataset = EstimatingDataset
                If Not Deserialize(EST_NewFilename, TempDataset, "Error Creating Copy - Updating current data", False) Then
                    Throw New Exception
                End If
                UseGeneralInfo = TempDataset.Tables(TABLENAME_GENERALINFO)
                CurDataRow = UseGeneralInfo.Rows(0)
                CurDataRow("UnitsInTab") = TempUnits
                If Not Serialize(EST_NewFilename, TempDataset, "Error Creating Copy - Saving current data", False) Then
                    Throw New Exception
                End If
            End If
            For iIndex = FilesDeleted.GetLowerBound(0) To FilesDeleted.GetUpperBound(0)
                File.Delete(FilesDeleted(iIndex))
            Next iIndex
            CopyMergeStatus = "Successful"

        Catch ex As Exception
            CopyMergeStatus = "Failed"
            For iIndex = FilesCreated.GetLowerBound(0) To FilesCreated.GetUpperBound(0)
                File.Delete(FilesCreated(iIndex))
            Next iIndex

        End Try

    End Sub
    Private Sub AddToFilesList(ByVal CreateOrDelete As String, ByVal CurFile As String)
        Dim FilesIndex As Integer = 0
        Dim CurFiles() As String = FilesCreated

        If CreateOrDelete = "Deleted" Then
            CurFiles = FilesDeleted
        End If
        If IsNothing(CurFiles) Then
            ReDim CurFiles(FilesIndex)
        Else
            FilesIndex = CurFiles.GetUpperBound(0) + 1
            ReDim Preserve CurFiles(FilesIndex)
            CurFiles(FilesIndex) = CurFile
        End If

    End Sub
End Class