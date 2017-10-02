Imports System.Data.OleDb

Public Class frmLaborRates


    Private Sub frmLaborRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
        Dim dataSource As String = My.Application.Info.DirectoryPath & "\" & OPTION_DATABASE_NAME

        Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dataSource & ";Jet OLEDB:Database Password=oscar")

        Dim sql As String = "SELECT rate_year as [Rate Year], labor_rate as [Labor Rate], st_composite as [ST Composite], ot_composite as [OT Composite]," & _
                            " blended_composite as [Blended Composite], labor_ratio as [Labor Ratio / Yr] FROM temp_labor_rates "
        Try
            ' This is our DataAdapter. This executes our SQL Statement above against the Database
            ' we defined in the Connection String
            Dim adapter As New OleDbDataAdapter(sql, cn)

            ' Gets the records from the table and fills our adapter with those.
            Dim dt As New DataTable("temp_labor_rates")

            adapter.Fill(dt)

            ' Assigns our DataSource on the DataGridView
            DataGridView1.DataSource = dt
            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).ReadOnly = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Building Rate Grid")
        Finally
            cn.Close()
        End Try

    End Sub

End Class