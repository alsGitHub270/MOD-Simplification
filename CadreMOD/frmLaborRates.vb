Imports System.Data.OleDb

Public Class frmLaborRates

    Public Property localOffice As String

    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim summary_row As Integer = 0
        Try

            dgvLaborRatios.DataSource = dtLaborRates

            dgvLaborRatios.Columns(0).ReadOnly = True
            dgvLaborRatios.Columns(0).HeaderText = "Rate Year"
            dgvLaborRatios.Columns(1).HeaderText = "ST Rate"
            dgvLaborRatios.Columns(2).HeaderText = "OT Rate"

            For i = 3 To dtLaborRates.Columns.Count - 1
                dgvLaborRatios.Columns(i).HeaderText = "Labor Ratio (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                summary_row += 1
            Next

            dgvLaborRatios.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Building Labor Rate Grid")

        End Try


        summary_row = 0

        For i = 1 To dtOverTime.Columns.Count - 1 Step 5
            Try
                dgvOverTime.DataSource = dtOverTime

                dgvOverTime.Columns(0).ReadOnly = True
                dgvOverTime.Columns(0).HeaderText = "Rate Year"
                dgvOverTime.Columns(i).HeaderText = "# of Work Hrs (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 1).HeaderText = "# of Work Days (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 2).HeaderText = "# of Teams (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 3).HeaderText = "OT % Bank (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 4).HeaderText = "OT Labor Inefficiency (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                summary_row += 1
            Catch ex As Exception

        End Try

        dgvOverTime.AutoResizeColumns()
        Next

        Me.lblLocalOffice.Text = "Local Office:  " & localOffice

    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub dgvLaborRatios_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaborRatios.CellValueChanged
        isDirty = True
    End Sub

    Private Sub dgvOverTime_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOverTime.CellValueChanged
        isDirty = True
    End Sub
End Class