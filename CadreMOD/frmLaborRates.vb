Imports System.Data.OleDb

Public Class frmLaborRates
    Dim AlexSender As System.Object
    Dim AlexE As System.EventArgs
    Public Property localOffice As String

    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AlexSender = sender
        AlexE = e
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


        dgvOverTime.DataSource = dtOverTime
        dgvOverTime.Columns(0).ReadOnly = True
        dgvOverTime.Columns(0).HeaderText = "Rate Year"

        summary_row = 0

        For i = 1 To dtOverTime.Columns.Count - 1 Step 5
            Try

                Dim dgvcc As New DataGridViewComboBoxColumn

                dgvOverTime.Columns(i).HeaderText = "# of Work Days (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"

                dgvOverTime.Columns(i + 1).HeaderText = "# of Work Hours (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 2).HeaderText = "# of Teams (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 3).HeaderText = "OT % Bank (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"
                dgvOverTime.Columns(i + 4).HeaderText = "OT Labor Inefficiency (" & dtSummaryGroup.Rows(summary_row).Item("Bank") & ")"

                summary_row += 1
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Building Overtime Grid")
            End Try
        Next

        Try
            For row = 0 To dgvOverTime.RowCount - 1
                Dim dgvcc As DataGridViewComboBoxCell
                Dim celval As Integer

                For col = 1 To dtOverTime.Columns.Count - 1 Step 5
                    celval = dgvOverTime.Item(col, row).Value
                    dgvcc = New DataGridViewComboBoxCell
                    dgvcc.Items.Add(celval)
                    dgvcc.Items.Add(4)
                    dgvcc.Items.Add(5)
                    dgvcc.Items.Add(6)
                    dgvcc.Value = celval    ' doesn't work
                    dgvOverTime.Item(col, row) = dgvcc

                    dgvcc = New DataGridViewComboBoxCell
                    celval = dgvOverTime.Item(col + 1, row).Value
                    dgvcc.Items.Add(celval)
                    dgvcc.Items.Add(8)
                    dgvcc.Items.Add(9)
                    dgvcc.Items.Add(10)
                    dgvcc.Items.Add(11)
                    dgvcc.Items.Add(12)

                    dgvOverTime.Item(col + 1, row) = dgvcc
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        dgvOverTime.AutoResizeColumns()
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

    Private Sub dgvOverTime_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvOverTime.CurrentCellDirtyStateChanged
        If dgvOverTime.IsCurrentCellDirty Then
            dgvOverTime.CommitEdit(DataGridViewDataErrorContexts.Commit)
            frmLaborRates_Load(AlexSender, AlexE)
        End If

        dgvOverTime.Refresh()
    End Sub



    Private Sub dgvOverTime_DataError(ByVal sender As Object,
                                      ByVal e As DataGridViewDataErrorEventArgs) _
                                    Handles dgvOverTime.DataError
        e.Cancel = True
        'MessageBox.Show("Error happened " _
        '    & e.Context.ToString())

        'If (e.Context = DataGridViewDataErrorContexts.Commit) _
        '    Then
        '    MessageBox.Show("Commit error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts _
        '    .CurrentCellChange) Then
        '    MessageBox.Show("Cell change")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        '    Then
        '    MessageBox.Show("parsing error")
        'End If
        'If (e.Context = _
        '    DataGridViewDataErrorContexts.LeaveControl) Then
        '    MessageBox.Show("leave control error")
        'End If

        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"

        '    e.ThrowException = False
        'End If
    End Sub
End Class