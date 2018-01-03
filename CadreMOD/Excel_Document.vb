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


        ' Get the Excel application object.
        Dim excel_app As New Excel.Application



        ' Make Excel visible (optional).
        'excel_app.Visible = True

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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in AddSuptHeaders", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            workbook.Close()
            excel_app.Quit()
            releaseObject(sheet)
            releaseObject(workbook)
            releaseObject(excel_app)
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

End Module
