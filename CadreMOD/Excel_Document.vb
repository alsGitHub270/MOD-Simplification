Imports System
Imports Microsoft.VisualBasic
Imports Excel = Microsoft.Office.Interop.Excel

Module Excel_Document
    Dim filename As String = ""

    Public Function OutputSuptFile(bank As String, units As String) As String
        filename = GenerateReport(bank, units)
        Return filename
    End Function



    Public Function GenerateReport(bank As String, units As String)


        Try
            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()

            If xlApp Is Nothing Then
                MessageBox.Show("Excel is not properly installed!!")
                Throw New Exception
            End If

            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            xlWorkSheet.Cells(1, 1) = Contracts.JobName & " - Bank: " & bank & ", Alt: A  Units: " & units

            filename = ReportsPath & Contracts.EstimateNum.ToString().Trim & bank & "A" & units

            xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()

            ReleaseObject(xlWorkSheet)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlApp)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Generating Excel Document", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return filename

    End Function


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
