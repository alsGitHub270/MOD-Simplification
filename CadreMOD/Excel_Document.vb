﻿Imports System
Imports Microsoft.VisualBasic
Imports Excel = Microsoft.Office.Interop.Excel

Module Excel_Document
    Dim filename As String = ""

    'Public Function OutputSuptFile(bank As String, units As String) As String
    '    filename = GenerateSuptApprovalReport(bank, units)
    '    Return filename
    'End Function



    'Public Function GenerateSuptApprovalReport(bank As String, units As String)


    '    Try
    '        Dim xlApp As Excel.Application = New Excel.Application()

    '        If xlApp Is Nothing Then
    '            MessageBox.Show("Excel is not properly installed!!")
    '            Throw New Exception
    '        End If

    '        Dim xlWorkBook As Excel.Workbook
    '        Dim xlWorkSheet As Excel.Worksheet
    '        Dim misValue As Object = System.Reflection.Missing.Value

    '        xlWorkBook = xlApp.Workbooks.Add(misValue)
    '        xlWorkSheet = xlWorkBook.Sheets("sheet1")

    '        xlWorkSheet.Cells(1, 1) = Contracts.JobName & " - Bank: " & bank & ", Alt: A  Units: " & units

    '        filename = ReportsPath & Contracts.EstimateNum.ToString().Trim & bank & "A" & units

    '        xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
    '            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
    '        xlWorkBook.Close(True, misValue, misValue)
    '        xlApp.Quit()

    '        ReleaseObject(xlWorkSheet)
    '        ReleaseObject(xlWorkBook)
    '        ReleaseObject(xlApp)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error Generating Excel Document", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Return filename

    'End Function

    Public Sub ModifySuptApprovalRptHeaders(excelFile As String)

        Dim excel_app As Excel.Application

        ' Get the Excel application object.
        Try
            excel_app = GetObject(, "Excel.Application")
        Catch ex As Exception
            excel_app = New Excel.Application
        End Try

        ' Open the workbook.
        Dim workbook As Excel.Workbook = excel_app.Workbooks.Open(filename:=excelFile)

        Dim sheet As Excel.Worksheet
        sheet = workbook.Worksheets("Sheet1")
        sheet.Unprotect()

        Try
            sheet.Range("A1:A3").EntireRow.Insert()
            sheet.Range("A1:Z14").Font.Bold = True
            sheet.Range("I:Z").Columns.AutoFit()
            sheet.Range("A:Z").Columns.Locked = True
            sheet.Cells(1, 1) = "SUPERINTENDENT APPROVAL REPORT"
            sheet.Range("A1:A1").Cells.Font.Size = 14.0

            sheet.Range("A14:Z14").VerticalAlignment = Excel.Constants.xlCenter
            sheet.Range("A14:Z14").HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Protect(Password:="cadre", Contents:=vbTrue, UserInterfaceOnly:=True)
            workbook.Save()
            excel_app.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in AddSuptHeaders", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ReleaseObject(sheet)
            ReleaseObject(workbook)
            'releaseObject(excel_app)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub GenerateCN1Report(_bank As String, _units As String, _installation_office As String, _negnum As String)
        Dim excelSheet As Excel.Worksheet = Nothing
        Dim cn1_rows() As DataRow
        Dim template_file As String = HAPDatabasePath & "Templates\CN1_Report.xlsx"
        Dim excel_file As String = ReportsPath & Contracts.EstimateNum & "_CN1.xlsx"
        Dim excel_app As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim sheet As Excel.Worksheet = Nothing
        Dim xls_column As Char
        Dim std_rate As Decimal
        Dim ot_rate As Decimal
        Dim my_list As List(Of String)


        Try
            ' Validate data exists
            cn1_rows = dtSummaryClone.Select("Bank = '" & _bank & "'")
            If cn1_rows.Count <> 2 Then
                Dim msg As String = "Incomplete CN1 Data.  Either 'Orig At Book' or 'RTE Values' are missing."
                MessageBox.Show(msg, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Copy  template to workspace
            IO.File.Copy(template_file, excel_file, True)

            ' Get the Labor Rates and calculate Installation $'s
            my_list = GetLaborRates(_installation_office)
            std_rate = my_list(0)
            ot_rate = my_list(1)

            ' Get the Excel application object.
            Try
                excel_app = GetObject(, "Excel.Application")
            Catch ex As Exception
                excel_app = New Excel.Application
            End Try

            ' Open the workbook.
            workbook = excel_app.Workbooks.Open(Filename:=excel_file)
            sheet = workbook.Worksheets("Sheet1")
            sheet.Unprotect()

            ' Populate headers
            Dim this_date As String = Now.ToString
            sheet.Range("D1").Value = "As Of: " & this_date

            sheet.Range("A1").Value = Contracts.JobName
            sheet.Range("A2").Value = Contracts.JobAddress
            If Contracts.JobAddress2.Length = 0 Then
                sheet.Range("A3").Value = Contracts.JobCity.Trim & ", " & Contracts.JobState & "  " & Contracts.JobZip
                sheet.Range("A4").Value = String.Empty
            Else
                sheet.Range("A3").Value = Contracts.JobAddress2
                sheet.Range("A4").Value = Contracts.JobCity.Trim & ", " & Contracts.JobState & "  " & Contracts.JobZip
            End If

            sheet.Range("B6").Value = _negnum
            sheet.Range("B8").Value = _bank
            sheet.Range("B9").Value = CalculateNumberOfCarsInEstimate(_units)


            ' Populate each column from SummaryClone
            For Each _row As DataRow In cn1_rows
                If _row.Item(0) = "Orig At Book" Then
                    xls_column = "B"
                Else
                    xls_column = "C"
                End If
                With _row
                    sheet.Range(xls_column & "12").Value = .Item("Bank_Final_Price")
                    sheet.Range(xls_column & "13").Value = .Item("N/A")
                    sheet.Range(xls_column & "16").Value = .Item("Material_HQ")
                    sheet.Range(xls_column & "17").Value = .Item("Material_RL")
                    sheet.Range(xls_column & "18").Value = .Item("Tax")
                    sheet.Range(xls_column & "20").Value = .Item("Freight")
                    sheet.Range(xls_column & "21").Value = .Item("Bank_Final_Price")
                    sheet.Range(xls_column & "24").Value = .Item("Labor_Cost")
                    sheet.Range(xls_column & "25").Value = .Item("BDP_Hours") + .Item("Special_hours") + .Item("Labor_Hours")
                    '  sheet.Range(xls_column & "27").Value = .Item("Labor_Cost")
                    sheet.Range(xls_column & "27").Value = .Item("OT_Hours_Included") * ot_rate
                    sheet.Range(xls_column & "28").Value = .Item("OT_Hours_Included")
                    sheet.Range(xls_column & "30").Value = "N/A"
                    sheet.Range(xls_column & "34").Value = .Item("Expenses")
                    sheet.Range(xls_column & "36").Value = .Item("Subcontract_Work")
                    sheet.Range(xls_column & "37").Value = .Item("Misc_Costs")
                    sheet.Range(xls_column & "38").Value = "N/A"
                    sheet.Range(xls_column & "39").Value = "N/A"
                    sheet.Range(xls_column & "41").Value = "N/A"
                End With

            Next

            sheet.Protect(Password:="cadre", Contents:=vbTrue, UserInterfaceOnly:=True)
            workbook.Save()
            excel_app.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Generating CN1 Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                clsNotes.DocSave(excel_file)
            Catch ex As Exception
                MessageBox.Show("Error saving file to Lotus Notes", "Error Saving to Notes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'workbook.Close()
            'excel_app.Quit()
            ReleaseObject(sheet)
            ReleaseObject(workbook)
            'ReleaseObject(excel_app)
            End Try

    End Sub
End Module
