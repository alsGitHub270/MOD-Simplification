Public Class frmOrdering
    Private dtOrdering As DataTable
    Private dtOrderingVars As DataTable
    Private componentsArray As Array

    Private Sub frmOrdering_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            If IsNothing(dsOrdering) Then
                dsOrdering = New DataSet()
            End If

            If dsOrdering.Tables.Contains("Ordering") = False Then
                Create_Ordering_Items_Table()
                InitializeTable("[Ordering Items]")
                Create_Ordering_Item_Variables_Table()
                InitializeTable("[Ordering Item Variables]")
                dsOrdering.Relations.Add("Ordering_Table_Relationship", dsOrdering.Tables("Ordering").Columns("id"), dsOrdering.Tables("Ordering_Items").Columns("fkey"))
            End If

            Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel
            model = sprOrdering.ActiveSheet.Models.Data
            model.DataSource = dsOrdering

            sprOrdering.ActiveSheet.GetDataView(False).AllowNew = False
            sprOrdering.ActiveSheet.Columns(0).Visible = False
            sprOrdering.ActiveSheet.Columns(1).Width = 350
            sprOrdering.ActiveSheet.Columns(1).Locked = True

            'ExpandCollapseAll("Expand")
            'ExpandCollapseAll("Collapse")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Ordering Form", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Create_Ordering_Items_Table()

        Dim column As DataColumn

        Try
            dtOrdering = dsOrdering.Tables.Add("Ordering")

            column = New DataColumn
            column.DataType = typeInt
            column.ColumnName = "id"
            dtOrdering.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "ordering_item"
            dtOrdering.Columns.Add(column)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Creating Ordering Items Data Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Create_Ordering_Item_Variables_Table()

        Dim column As DataColumn

        Try
            dtOrderingVars = dsOrdering.Tables.Add("Ordering_Items")

            column = New DataColumn
            column.DataType = typeInt
            column.ColumnName = "id"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "order_variable"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeInt
            column.ColumnName = "fkey"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car1"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car2"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car3"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car4"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car5"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car6"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car7"
            dtOrderingVars.Columns.Add(column)

            column = New DataColumn
            column.DataType = typeStr
            column.ColumnName = "car8"
            dtOrderingVars.Columns.Add(column)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Creating Ordering Item VariablesData Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub InitializeTable(strTblName As String)
        ' this only loads dtOrderiing and dtOrderingVars datatables.

        Dim dataSource As String = HAPDatabasePath & "\" & MODDATA_DATABASE_NAME

        Try
            Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dataSource & ";Jet OLEDB:Database Password=oscar"
                }
                Using cmd As New OleDb.OleDbCommand With
                    {
                        .Connection = cn,
                        .CommandText = "SELECT * FROM " & strTblName
                    }
                    cn.Open()

                    If strTblName = "[Ordering Items]" Then
                        dtOrdering.Load(cmd.ExecuteReader)
                    Else
                        dtOrderingVars.Load(cmd.ExecuteReader)
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Initializing Ordering Tables", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ExpandCollapseAll(ByVal ExpandCollapseAction As String)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To sprOrdering.ActiveSheet.RowCount - 1
            Select Case ExpandCollapseAction
                Case "Expand"
                    sprOrdering.ActiveSheet.ExpandRow(iIndex, True)
                    ChildSheetView = sprOrdering.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, True)
                        Next jIndex
                    End If
                Case "Collapse"
                    sprOrdering.ActiveSheet.ExpandRow(iIndex, False)
                    ChildSheetView = sprOrdering.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, False)
                        Next jIndex
                    End If
                Case Else
            End Select
        Next iIndex

    End Sub

    Private Sub sprOrdering_ChildViewCreated(sender As System.Object, e As FarPoint.Win.Spread.ChildViewCreatedEventArgs) Handles sprOrdering.ChildViewCreated

        With e.SheetView
            .RowHeader.AutoText = False
            .DataAutoCellTypes = False
            .DataAutoSizeColumns = False
            .ColumnHeader.Rows(0).Height = 30

            .Columns(0).Visible = False

            .Columns(1).Locked = True
            .Columns(1).Width = 230

            .Columns(2).Visible = False

            .Columns(3).Label = "Car 1"
            .Columns(3).Width = 75

            .Columns(4).Label = "Car 2"
            .Columns(4).Width = 75

            .Columns(5).Label = "Car 3"
            .Columns(5).Width = 75

            .Columns(6).Label = "Car 4"
            .Columns(6).Width = 75

            .Columns(7).Label = "Car 5"
            .Columns(7).Width = 75
           
            .Columns(8).Label = "Car 6"
            .Columns(8).Width = 75

            .Columns(9).Label = "Car 7"
            .Columns(9).Width = 75

            .Columns(10).Label = "Car 8"
            .Columns(10).Width = 75
        End With

    End Sub
End Class