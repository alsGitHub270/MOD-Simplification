Imports System
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
        Dim workbook As Excel.Workbook = excel_app.Workbooks.Open(Filename:=excelFile)

        Dim sheet As Excel.Worksheet
        sheet = workbook.Worksheets("Sheet1")
        sheet.Unprotect()
        ' workbook.Unprotect()
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
            releaseObject(sheet)
            releaseObject(workbook)
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

    Public Sub GenerateCN1Report()
        Dim _bank As String = CurrentGOData_Typ.Bank
        Dim _units As String = CurrentGOData_Typ.CurrentUnits
        Dim excelSheet As Excel.Worksheet = Nothing
        Dim cn1_rows() As DataRow
        Dim template_file As String = HAPDatabasePath & "Templates\CN1_Report.xlsx"
        Dim excel_file As String = ReportsPath & Contracts.EstimateNum & "-" & _bank & "_CN1.xlsx"
        Dim excel_app As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim sheet As Excel.Worksheet = Nothing
        Dim xls_column As Char
        Dim std_rate As Decimal
        Dim ot_rate As Decimal

        Dim create_new_file As Boolean = True

        Dim _installation_office = CM_MAIN_frm.cboInstallingOffice.Text
        Dim _negnum = CM_MAIN_frm.txtNegNum.Text


        'THIS FUNCTIONALITY MUST BE ADDRESSED WHEN ADDED TO THE REPORT FORM!!!!!!!!!

        MessageBox.Show("This function does not currently work as values for installation office and negnum(controls on CM_MAIN) cannot be read.  This issue must be addressed during construction of the Reports form")
        Exit Sub

        If CurrentGOData_Typ.EstimateLevel <> "Summary" Then
            MessageBox.Show("Please set the cursor on the summary level row to identify which bank to process", "Cannot Identify Bank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If System.IO.File.Exists(excel_file) Then
            Dim dialog_result As DialogResult
            Dim message = "The CN1 Report already exists.  Do you want to open the existing file?" & Environment.NewLine & _
                        "Selecting No will create a new file and overwrite the existing one."
            dialog_result = MessageBox.Show(message, "Open Current File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If dialog_result = vbCancel Then
                Exit Sub
            End If
            If dialog_result = vbYes Then
                create_new_file = False
            End If

        End If

        Try
            ' Validate data exists
            cn1_rows = dtSummaryClone.Select("Bank = '" & _bank & "'")
            If cn1_rows.Count <> 2 Then
                Dim msg As String = "Incomplete CN1 Data.  Either 'Orig At Book' or 'RTE Values' are missing."
                MessageBox.Show(msg, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Copy  template to workspace
            If create_new_file Then
                IO.File.Copy(template_file, excel_file, True)

                ' Get the Labor Rates and calculate Installation $'s
                Dim my_list As List(Of String)
                my_list = GetLaborRates(_installation_office)
                std_rate = my_list(0)
                ot_rate = my_list(1)

            End If

            ' Get the Excel application object.
            Try
                excel_app = GetObject(, "Excel.Application")
            Catch ex As Exception
                excel_app = New Excel.Application
            End Try

            ' Open the workbook.
            workbook = excel_app.Workbooks.Open(Filename:=excel_file)
            sheet = workbook.Worksheets("Sheet1")

            If Not create_new_file Then
                excel_app.Visible = True
                Exit Sub
            End If

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
                    sheet.Range(xls_column & "13").Value = "N/A"
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
                    sheet.Range(xls_column & "38").Value = .Item("Sales_Commission")
                    'sheet.Range(xls_column & "39").Value = "N/A"
                    sheet.Range(xls_column & "41").Value = .Item("NPS_Cost")
                End With

            Next

            sheet.Protect(Password:="cadre", Contents:=vbTrue, UserInterfaceOnly:=True)
            workbook.Save()
            excel_app.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Generating CN1 Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'workbook.Close()
            'excel_app.Quit()
            ReleaseObject(sheet)
            ReleaseObject(workbook)
            'ReleaseObject(excel_app)
        End Try

    End Sub
End Module
