Public Class frmLaborRates
    Dim this_sender As System.Object
    Dim this_e As System.EventArgs
    Public Property localOffice As String

    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        this_sender = sender
        this_e = e
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

        ' Overtime --------

        dgvOverTime.DataSource = dtOverTime
        dgvOverTime.Columns(0).ReadOnly = True
        dgvOverTime.Columns(0).HeaderText = "Bank"
        dgvOverTime.Columns(1).HeaderText = "Work Days"
        dgvOverTime.Columns(2).HeaderText = "Work Hours"
        dgvOverTime.Columns(3).HeaderText = "# Teams"
        dgvOverTime.Columns(4).HeaderText = "OT %"
        dgvOverTime.Columns(5).HeaderText = "OT Labor Inefficiency"
        summary_row = 0

        Try
            For row = 0 To dgvOverTime.RowCount - 1
                Dim dgvcc As DataGridViewComboBoxCell
                Dim celval As Integer

                celval = dgvOverTime.Item(1, row).Value
                dgvcc = New DataGridViewComboBoxCell
                dgvcc.Items.Add(celval)
                dgvcc.Items.Add(4)
                dgvcc.Items.Add(5)
                dgvcc.Items.Add(6)
                dgvcc.Value = celval    ' doesn't work
                dgvOverTime.Item(1, row) = dgvcc

                dgvcc = New DataGridViewComboBoxCell
                celval = dgvOverTime.Item(2, row).Value
                dgvcc.Items.Add(celval)
                dgvcc.Items.Add(8)
                dgvcc.Items.Add(9)
                dgvcc.Items.Add(10)
                dgvcc.Items.Add(11)
                dgvcc.Items.Add(12)

                dgvOverTime.Item(2, row) = dgvcc

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
            frmLaborRates_Load(this_sender, this_e)
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