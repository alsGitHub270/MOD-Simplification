Public Class frmLaborRates
    Dim this_sender As System.Object
    Dim this_e As System.EventArgs
    Public Property localOffice As String

    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            dgvLaborRatios.DataSource = dtLaborRates
            dgvLaborRatios.Columns(0).Visible = False
            dgvLaborRatios.Columns(1).ReadOnly = True
            dgvLaborRatios.Columns(1).HeaderText = "Rate Year"
            dgvLaborRatios.Columns(2).HeaderText = "ST Rate"
            dgvLaborRatios.Columns(3).HeaderText = "OT Rate"
            dgvLaborRatios.Columns(4).HeaderText = "Labor Ratio (" & CurrentGOData_Typ.Bank & ")"
            dgvLaborRatios.Columns(4).DefaultCellStyle.Format = "0.00\%"
            dgvLaborRatios.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Building Labor Rate Grid")

        End Try

        dgvOverTime.DataSource = dtOverTime
        dgvOverTime.Columns(0).ReadOnly = True
        dgvOverTime.Columns(0).HeaderText = "Bank"
        dgvOverTime.Columns(1).HeaderText = "Work Days"
        dgvOverTime.Columns(2).HeaderText = "Work Hours"
        dgvOverTime.Columns(3).HeaderText = "# Teams"
        dgvOverTime.Columns(4).HeaderText = "OT %"
        dgvOverTime.Columns(5).HeaderText = "OT Labor Inefficiency"

        Try
            For row = 0 To dgvOverTime.RowCount - 1
                Dim dgvcc As DataGridViewComboBoxCell
                Dim celval As Integer

                celval = dgvOverTime.Item(1, row).Value
                dgvcc = New DataGridViewComboBoxCell
                dgvcc.Items.Add(4)
                dgvcc.Items.Add(5)
                dgvcc.Items.Add(6)
                dgvcc.Items.Add(7)
                dgvcc.Value = celval    ' doesn't work
                dgvOverTime.Item(1, row) = dgvcc

                dgvcc = New DataGridViewComboBoxCell
                celval = dgvOverTime.Item(2, row).Value
                Select Case dgvOverTime.Item(1, row).Value
                    Case 4
                        dgvcc.Items.Add(10)
                    Case 5
                        dgvcc.Items.Add(10)
                        dgvcc.Items.Add(12)
                    Case Else
                        dgvcc.Items.Add(8)
                        dgvcc.Items.Add(10)
                        dgvcc.Items.Add(12)
                End Select
                dgvOverTime.Item(2, row) = dgvcc

                dgvOverTime.Columns(4).DefaultCellStyle.Format = "0.00\%"
                dgvOverTime.Columns(5).DefaultCellStyle.Format = "0.00\%"
            Next row

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        dgvOverTime.AutoResizeColumns()
        Me.lblLocalOffice.Text = "Local Office:  " & localOffice

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If isDirty Then
            BankLaborRate = CalculateLaborRate()
        End If
        Me.Dispose()
    End Sub
    Private Sub dgvLaborRatios_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaborRatios.CellValueChanged
        isDirty = True
    End Sub
    Private Sub dgvOverTime_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOverTime.CellValueChanged
        isDirty = True
    End Sub
    Private Sub dgvOverTime_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOverTime.CurrentCellDirtyStateChanged

        If dgvOverTime.IsCurrentCellDirty Then
            dgvOverTime.CommitEdit(DataGridViewDataErrorContexts.Commit)
            frmLaborRates_Load(this_sender, this_e)
        End If
        dgvOverTime.Refresh()

    End Sub
    Private Sub dgvOverTime_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dgvOverTime.DataError
        e.Cancel = True
    End Sub
End Class