Imports System.Data.OleDb

Public Class frmLaborRates

    Public Property localOffice As String

    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim summary_row As Integer = 0
        Try

            DataGridView1.DataSource = dtLaborRates

            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.Columns(0).HeaderText = "Rate Year"
            DataGridView1.Columns(1).HeaderText = "ST Rate"
            DataGridView1.Columns(2).HeaderText = "OT Rate"

            For i = 3 To dtLaborRates.Columns.Count - 1
                DataGridView1.Columns(i).HeaderText = "Labor Ratio (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                summary_row += 1
            Next

            DataGridView1.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Building Labor Rate Grid")

        End Try

        Me.lblLocalOffice.Text = "Local Office:  " & localOffice
    End Sub

End Class