Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Partial Friend Class CM_MAIN_frm
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)

    Dim dsTemp As DataSet

    Dim copying_to_new_row As Boolean = False
    Dim adding_to_labor_and_overtime As Boolean = False

    Dim initializing As Boolean
    Dim id_to_copy As String = ""

    Private CurrentBuildingInformationFrameHeight As Integer = 0, CurrentEquipmentFrameHeight As Integer = 0

    Const _BANK_COLUMN As Integer = 3

    Private UseCurRow As Integer = 0, UseCurCol As Integer = 0, CurSummaryRow As Integer = 0

    Private Sub CreateDataSet()

        dsCadre = New DataSet()
        dsCadre.EnforceConstraints = False

        dtSummaryGroup = dsCadre.Tables.Add("SummaryGroup")
        dtSummaryGroup.Columns.AddRange(New DataColumn() {New DataColumn("SummaryGroup", typeStr),
                                                            New DataColumn("id", typeStr),
                                                            New DataColumn("_", typeStr),
                                                            New DataColumn("Bank", typeStr),
                                                            New DataColumn("Bank_Type", typeStr),
                                                            New DataColumn("Units", typeStr),
                                                            New DataColumn("Material_HQ", typeInt),
                                                            New DataColumn("Material_RL", typeInt),
                                                            New DataColumn("Tax", typeInt),
                                                            New DataColumn("BDP_Hours", typeInt),
                                                            New DataColumn("Special_Hours", typeInt),
                                                            New DataColumn("Labor_Hours", typeInt),
                                                            New DataColumn("OT_Hours_Included", typeInt),
                                                            New DataColumn("Labor_Cost", typeInt),
                                                            New DataColumn("SubContract_Work", typeInt),
                                                            New DataColumn("Expenses", typeInt),
                                                            New DataColumn("Engineering_Cost", typeInt),
                                                            New DataColumn("Misc_Costs", typeInt),
                                                            New DataColumn("Freight", typeInt),
                                                            New DataColumn("NPS_Cost", typeInt),
                                                            New DataColumn("Total_Bank_Cost", typeInt),
                                                            New DataColumn("C1", typeSingle),
                                                            New DataColumn("Bank_Net_Price", typeInt),
                                                            New DataColumn("Sales_Commission", typeInt),
                                                            New DataColumn("Bank_Final_Price", typeInt),
                                                            New DataColumn("Labor_Rate", typeInt),
                                                            New DataColumn("product_code", typeInt),
                                                            New DataColumn("lead_time", typeInt),
                                                            New DataColumn("Include", typeBool),
                                                            New DataColumn("speed", typeInt),
                                                            New DataColumn("machine_model", typeStr),
                                                            New DataColumn("gateway_review_required", typeBool)
                                                         })

        dtBaseGroup = dsCadre.Tables.Add("BaseGroup")
        dtBaseGroup.Columns.AddRange(New DataColumn() {New DataColumn("BaseGroup", typeStr), _
                                                       New DataColumn("id", typeStr), _
                                                       New DataColumn("sort_fld", typeStr), _
                                                       New DataColumn("filler1", typeStr), _
                                                       New DataColumn("alt_id", typeStr), _
                                                       New DataColumn("Material_HQ", typeInt), _
                                                       New DataColumn("Material_RL", typeInt), _
                                                       New DataColumn("Tax", typeInt), _
                                                       New DataColumn("BDP_Hours", typeInt), _
                                                       New DataColumn("Special_Hours", typeInt), _
                                                       New DataColumn("Labor_Hours", typeInt), _
                                                       New DataColumn("OT_Hours_Included", typeInt), _
                                                       New DataColumn("Labor_Cost", typeInt), _
                                                       New DataColumn("SubContract_Work", typeInt), _
                                                       New DataColumn("Expenses", typeInt), _
                                                       New DataColumn("Engineering_Cost", typeInt), _
                                                       New DataColumn("Misc_Costs", typeInt), _
                                                       New DataColumn("Freight", typeInt), _
                                                       New DataColumn("NPS_Cost", typeInt), _
                                                       New DataColumn("Total_Bank_Cost", typeInt), _
                                                       New DataColumn("C1", typeSingle), _
                                                       New DataColumn("Bank_Net_Price", typeInt), _
                                                       New DataColumn("Sales_Commission", typeInt), _
                                                       New DataColumn("Bank_Final_Price", typeInt), _
                                                       New DataColumn("Labor_Rate", typeInt), _
                                                       New DataColumn("product_code", typeInt), _
                                                       New DataColumn("lead_time", typeInt), _
                                                       New DataColumn("Comment", typeStr), _
                                                       New DataColumn("speed", typeInt), _
                                                       New DataColumn("machine_model", typeStr)
                                                        })

        dtAltGroup = dsCadre.Tables.Add("AltGroup")
        dtAltGroup.Columns.AddRange(New DataColumn() {New DataColumn("AltGroup", typeStr), _
                                                      New DataColumn("id", typeStr), _
                                                      New DataColumn("filler1", typeStr), _
                                                      New DataColumn("filler2", typeStr), _
                                                      New DataColumn("Offer", typeStr), _
                                                      New DataColumn("Merge", typeStr), _
                                                      New DataColumn("Material_HQ", typeInt), _
                                                      New DataColumn("Material_RL", typeInt), _
                                                      New DataColumn("Tax", typeInt), _
                                                      New DataColumn("BDP_Hours", typeInt), _
                                                      New DataColumn("Special_Hours", typeInt), _
                                                      New DataColumn("Labor_Hours", typeInt), _
                                                      New DataColumn("OT_Hours_Included", typeInt), _
                                                      New DataColumn("Labor_Cost", typeInt), _
                                                      New DataColumn("SubContract_Work", typeInt), _
                                                      New DataColumn("Expenses", typeInt), _
                                                      New DataColumn("Engineering_Cost", typeInt), _
                                                      New DataColumn("Misc_Costs", typeInt), _
                                                      New DataColumn("Freight", typeInt), _
                                                      New DataColumn("NPS_Cost", typeInt), _
                                                      New DataColumn("Total_Bank_Cost", typeInt), _
                                                      New DataColumn("C1", typeSingle), _
                                                      New DataColumn("Bank_Net_Price", typeInt), _
                                                      New DataColumn("Sales_Commission", typeInt), _
                                                      New DataColumn("Bank_Final_Price", typeInt), _
                                                      New DataColumn("Labor_Rate", typeInt), _
                                                      New DataColumn("product_code", typeInt), _
                                                      New DataColumn("lead_time", typeInt),
                                                      New DataColumn("Comment", typeStr),
                                                      New DataColumn("speed", typeInt),
                                                      New DataColumn("machine_model", typeStr)
                                                     })

        dtContactGroup = dsCadre.Tables.Add("Contacts")
        dtContactGroup.Columns.AddRange(New DataColumn() {New DataColumn("contactType", typeStr), _
                                                          New DataColumn("companyName", typeStr), _
                                                          New DataColumn("contactName", typeStr), _
                                                          New DataColumn("address", typeStr), _
                                                          New DataColumn("address2", typeStr), _
                                                          New DataColumn("city", typeStr), _
                                                          New DataColumn("state", typeStr), _
                                                          New DataColumn("zipcode", typeStr), _
                                                          New DataColumn("phone", typeStr), _
                                                          New DataColumn("ext", typeStr), _
                                                          New DataColumn("fax", typeStr), _
                                                          New DataColumn("email", typeStr)
                                                         })


        dtBuildingInfo = dsCadre.Tables.Add("BldgInfo")
        dtBuildingInfo.Columns.AddRange(New DataColumn() {New DataColumn("building_type", typeStr), _
                                                          New DataColumn("superintendent", typeStr), _
                                                          New DataColumn("sales_rep", typeStr), _
                                                          New DataColumn("sales_office", typeStr), _
                                                          New DataColumn("installing_office", typeStr), _
                                                          New DataColumn("service_office", typeStr), _
                                                          New DataColumn("bid_date", typeStr), _
                                                          New DataColumn("national_account", typeStr), _
                                                          New DataColumn("tax_rate", typeStr), _
                                                          New DataColumn("tax_code", typeStr), _
                                                          New DataColumn("seismic_zone", typeStr), _
                                                          New DataColumn("local_code", typeStr), _
                                                          New DataColumn("ansi_csa_b44_code", typeStr), _
                                                          New DataColumn("nfpa_code", typeStr), _
                                                          New DataColumn("sds_level", typeStr), _
                                                          New DataColumn("oshpd", typeBool), _
                                                          New DataColumn("dsa", typeBool), _
                                                          New DataColumn("head_detection", typeBool), _
                                                          New DataColumn("engineering_survey", typeBool), _
                                                          New DataColumn("nps_duration", typeStr), _
                                                          New DataColumn("nps_call_back", typeStr), _
                                                          New DataColumn("nps_material_cost", typeStr), _
                                                          New DataColumn("nps_labor_cost", typeStr), _
                                                          New DataColumn("nps_one_time_cost", typeStr), _
                                                          New DataColumn("ocpl", typeStr)
                                                         })


        Deserialize(CM_file, dsCadre, "Error Reading Input json estimate file", isDirty)
        FpSpread1.ActiveSheet.SortRows(3, True, False)

        If dtContactGroup.Rows.Count = 0 And Owner_Info.Name.Length > 0 Then
            UpdateContactGroupFromNotes()
        End If

        CreateLaborRateDataTable()

        CreateOverTimeDataTable()

        'Add the relations
        dsCadre.Relations.Add("Summary_Base_Relationship", dsCadre.Tables("SummaryGroup").Columns("id"), dsCadre.Tables("BaseGroup").Columns("id"))
        dsCadre.Relations.Add("Base_Alt_Relationship", dsCadre.Tables("BaseGroup").Columns("alt_id"), dsCadre.Tables("AltGroup").Columns("id"))

    End Sub

    Private Sub CreateLaborRateDataTable()
        dtLaborRates = dsCadre.Tables.Add("LaborRates")
        dtLaborRates.Columns.Add("rate_year")
        dtLaborRates.Columns.Add("st_rate")
        dtLaborRates.Columns.Add("ot_rate")
        For i = 0 To dtSummaryGroup.Rows.Count - 1
            dtLaborRates.Columns.Add("labor_ratio_" & dtSummaryGroup.Rows(i).Item("Bank"))
        Next
        ReadInLaborRates()
    End Sub

    Private Sub CreateOverTimeDataTable()
        ' Creates datatable for all rows in the summary table
        Dim column As DataColumn
        Try
            dtOverTime = dsCadre.Tables.Add("OverTime")

            dtOverTime.Columns.Add("bank")
            column = New DataColumn
            column.DataType = typeInt
            column.DefaultValue = 5
            column.ColumnName = "work_days"
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "work_hours"
            column.DataType = typeInt
            column.DefaultValue = 8
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "#_teams"
            column.DataType = typeInt
            column.DefaultValue = 1
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "ot_%"
            column.DataType = typeSingle
            column.DefaultValue = 0
            dtOverTime.Columns.Add(column)

            column = New DataColumn
            column.ColumnName = "ot_labor_inefficiency"
            column.DataType = typeSingle
            column.DefaultValue = 0
            dtOverTime.Columns.Add(column)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Creating OverTime Datatable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ReadInOvertime()

    End Sub

    Private Sub InsertNewOvertimeRow(ByVal pBank As String)

        Try
            Dim _row As DataRow = dtOverTime.NewRow
            _row("Bank") = pBank
            dtOverTime.Rows.Add(_row)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Adding Row to Overtime Datatable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ReadInLaborRates()
        Dim json As String
        Dim rate_year As Integer = Year(Now)
        Dim labor_rates_not_found As Boolean = True

        Try

            If File.Exists(CM_file) Then
                Using sr As StreamReader = New StreamReader(CM_file)  ' to be changed to CM_file
                    json = sr.ReadToEnd
                End Using

                Dim ser As JObject = JObject.Parse(json)
                Dim data As List(Of JToken) = ser.Children().ToList

                For Each item As JProperty In data
                    item.CreateReader()
                    Select Case item.Name
                        Case "LaborRates"
                            For Each lr As JObject In item.Values
                                labor_rates_not_found = False
                                Dim workRow As DataRow = dtLaborRates.NewRow
                                For i As Integer = 0 To dtLaborRates.Columns.Count - 1
                                    If Not IsNothing(lr.Item(dtLaborRates.Columns(i).ColumnName)) Then
                                        workRow.Item(i) = lr.Item(dtLaborRates.Columns(i).ColumnName)   ' Column names and key from json must be the same.  lr uses name, no ordinal designation
                                    End If
                                Next
                                dtLaborRates.Rows.Add(workRow)
                            Next
                    End Select
                Next
            End If
            If labor_rates_not_found Then
                InitializeLaborRates()
            Else
                RecalculateLaborRates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Reading In Labor Rates", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RecalculateLaborRates()

        Dim rate_year As Integer = Year(Now)
        Dim adjustment As Decimal = 1.035
        Dim st_rate As Decimal
        Dim ot_rate As Decimal
        Dim myList As New List(Of String)()
        Dim installation_office As String
        Dim x As Integer

        If dtLaborRates.Rows.Count = 0 Then
            ReadInLaborRates()
        End If

        If initializing Then
            installation_office = dtBuildingInfo.Rows(0).Item("installing_office")
        Else
            installation_office = Me.cboInstallingOffice.Text
        End If

        Try
            If installation_office.Trim.Length = 0 Then
                Exit Sub
            End If
            Dim sSQL As String = "SELECT STRate, OTRate " & _
                    "FROM [Rate (MOD Labor)] " & _
                    "WHERE Office = '" & installation_office & "';"

            myList = GetDataFromOptions(sSQL, True)
            x = CInt(dtLaborRates(0).Item("rate_year")) - rate_year

            For i As Integer = 0 To dtLaborRates.Rows.Count - 1
                st_rate = myList(0) * adjustment ^ x
                ot_rate = myList(1) * adjustment ^ x
                dtLaborRates.Rows(i).Item("st_rate") = Math.Round(st_rate, 2)
                dtLaborRates.Rows(i).Item("ot_rate") = Math.Round(ot_rate, 2)
                x += 1
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Processing Labor Rates", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InitializeLaborRates()
        Dim rate_year As Integer
        Dim adjustment As Decimal = 1.035
        Dim st_rate As Decimal
        Dim ot_rate As Decimal
        Dim myList As New List(Of String)()
        Dim installation_office As String

        rate_year = Year(Now)
        If initializing Then
            If dtBuildingInfo.Rows.Count = 0 OrElse dtBuildingInfo.Rows(0).Item("installing_office") = "" Then
                ' Me.btnLaborRates.Enabled = False
                Exit Sub
            Else
                installation_office = dtBuildingInfo.Rows(0).Item("installing_office")
            End If
        Else
            installation_office = Me.cboInstallingOffice.Text
        End If

        Try
            Dim sSQL As String = "SELECT STRate, OTRate " & _
                    "FROM [Rate (MOD Labor)] " & _
                    "WHERE Office = '" & installation_office & "';"

            myList = GetDataFromOptions(sSQL, True)
            st_rate = myList(0)
            ot_rate = myList(1)
            For i As Integer = 0 To 9
                Dim workRow As DataRow = dtLaborRates.NewRow
                workRow("rate_year") = rate_year
                workRow("st_rate") = Math.Round(st_rate, 2)
                workRow("ot_rate") = Math.Round(ot_rate, 2)
                For j As Integer = 3 To dtLaborRates.Columns.Count - 1
                    workRow(j) = 0
                Next
                dtLaborRates.Rows.Add(workRow)
                rate_year += 1
                st_rate *= adjustment
                ot_rate *= adjustment
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in InitializeLaborRates", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ReadInOvertime()
        Dim json As String
        Dim OT_not_found As Boolean = True

        Try
            If File.Exists(CM_file) Then
                Using sr As StreamReader = New StreamReader(CM_file)  ' to be changed to CM_file
                    json = sr.ReadToEnd
                End Using

                Dim ser As JObject = JObject.Parse(json)
                Dim data As List(Of JToken) = ser.Children().ToList

                For Each item As JProperty In data
                    item.CreateReader()
                    Select Case item.Name
                        Case "OverTime"
                            For Each ot As JObject In item.Values
                                OT_not_found = False
                                Dim workRow As DataRow = dtOverTime.NewRow
                                For i As Integer = 0 To dtOverTime.Columns.Count - 1
                                    ' Column names and key from json must be the same.
                                    If Not IsNothing(ot.Item(dtOverTime.Columns(i).ColumnName)) Then
                                        workRow.Item(i) = ot.Item(dtOverTime.Columns(i).ColumnName)
                                    End If
                                Next
                                dtOverTime.Rows.Add(workRow)
                            Next
                    End Select
                Next
            End If
            If OT_not_found Then
                InitializeOverTime()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Reading In Overtime", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InitializeOverTime()

        For Each row As DataRow In dtSummaryGroup.Rows
            Dim newRow As DataRow = dtOverTime.NewRow
            newRow("bank") = row.Item("Bank")
            dtOverTime.Rows.Add(newRow)
        Next
        isDirty = True
    End Sub

    Private Sub btnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        If isDirty Then
            If PromptForSave() <> DialogResult.Yes Then
                Exit Sub
            End If
        End If
        CurrentGOData_Typ.Units = FpSpread1.ActiveSheet.Cells(CurRow, 2).Text
        CurrentGOData_Typ.Bank = FpSpread1.ActiveSheet.Cells(CurRow, 3).Text
        CurrentGOData_Typ.MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentGOData_Typ.CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case CurrentGOData_Typ.EstimateLevel
            Case "Summary"
            Case "Master", "Base"
                Me.ShowInTaskbar = False
                Using frmEstimatingBase
                    frmEstimatingBase.ShowDialog()
                End Using
                Me.ShowInTaskbar = True
            Case "Alt"
                Me.ShowInTaskbar = False
                Using frmEstimatingAlt
                    frmEstimatingAlt.ShowDialog()
                End Using
                Me.ShowInTaskbar = True
            Case Else
        End Select

    End Sub

    Private Sub CM_MAIN_frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If isDirty Then
            If PromptForSave() = DialogResult.Cancel Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        EndProgram()

    End Sub

    Private Sub CM_MAIN_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FpSpread1.Hide()
        DetachFeedback()

        Dim ShiftDist As Single = (Me.Width - BuildingInformation_fra.Width) / 2
        initializing = True

        CreateDataSet()
        Dim dt As DataTable
        For Each dt In dsCadre.Tables
            dt.DefaultView.AllowNew = False
        Next

        Dim model As FarPoint.Win.Spread.Model.DefaultSheetDataModel

        model = FpSpread1.ActiveSheet.Models.Data
        model.DataSource = dsCadre
        FpSpread1.ActiveSheet.GetDataView(False).AllowNew = False
        FpSpread1.ActiveSheet.SortRows(3, True, False)

        If dtSummaryGroup.Rows.Count = 0 Then
            AddBankRow()
        End If
        Load_ListBoxes()
        Text2Fields()
        LoadTopOfForm()

        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

        Dim gl As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, Color.Black)
        FpSpread1.ActiveSheet.HorizontalGridLine = gl
        FpSpread1.ActiveSheet.VerticalGridLine = gl

        FpSpread1.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        FpSpread1.ActiveSheet.RowHeader.Columns(0).Width = 30
        FpSpread1.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        FpSpread1.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        FpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off

        If dtSummaryGroup.Rows.Count > 0 Then
            Try
                'Init Spread
                With FpSpread1.ActiveSheet
                    .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
                    .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
                    .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
                    '.ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
                    .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black

                    .RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
                    '  .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
                    .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
                    .SheetCornerStyle.BackColor = Color.DarkGray

                    .GrayAreaBackColor = Color.White
                    .LockBackColor = Color.LightGray
                End With
            Catch ex As Exception
                MessageBox.Show("Error in CM_Mainfrm.Load: & Environment.NewLine & CStr(Information.Err().Number) " & _
                                Conversion.ErrorToString(Information.Err().Number) & Environment.NewLine & _
                                Information.Err().Number.ToString() & Conversion.ErrorToString(), Application.ProductName)

            End Try

        End If

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType()
        percentType.DecimalPlaces = 2

        Dim numberType As New FarPoint.Win.Spread.CellType.NumberCellType()
        numberType.DecimalPlaces = 0
        numberType.ShowSeparator = True


        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True
        currencyType.MaximumValue = 99999999

        Dim ckbxcell As New FarPoint.Win.Spread.CellType.CheckBoxCellType()

        Dim cbstr_Machine As String()
        cbstr_Machine = New String() {"Geared", "Gearless", "Hydro"}
        Dim cmbocell_Machine As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell_Machine.Items = cbstr_Machine
        cmbocell_Machine.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell_Machine.Editable = False
        cmbocell_Machine.MaxDrop = 3

        For i As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1

            Dim cmbocell_Bank As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
            Dim cbstr_Bank() As String
            cmbocell_Bank.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
            cmbocell_Bank.Editable = False
            cmbocell_Bank.MaxDrop = 3

            cbstr_Bank = BuildBanks(FpSpread1.ActiveSheet.GetValue(i, 3))
            cmbocell_Bank.Items = cbstr_Bank

            FpSpread1.ActiveSheet.Rows(i).Locked = True

            FpSpread1.ActiveSheet.Cells(i, 0).Column.Width = 75        'summary
            FpSpread1.Sheets(0).ColumnHeader.Columns(0).Label = "Group"

            FpSpread1.ActiveSheet.Columns(1).Visible = False

            FpSpread1.ActiveSheet.Cells(i, 2).Column.Width = 20         'STATUS

            FpSpread1.ActiveSheet.Cells(i, 3).Column.Width = 35         'bank
            FpSpread1.ActiveSheet.Cells(i, 3).CellType = cmbocell_Bank      ' bank
            FpSpread1.ActiveSheet.Cells(i, 3).Locked = False

            FpSpread1.ActiveSheet.Cells(i, 4).Column.Width = 75         'bank_type
            FpSpread1.ActiveSheet.Cells(i, 4).CellType = cmbocell_Machine   ' machine/bank type
            FpSpread1.ActiveSheet.Cells(i, 4).Locked = False

            FpSpread1.ActiveSheet.Cells(i, 5).Column.Width = 60         'units
            FpSpread1.ActiveSheet.Cells(i, 5).Locked = False

            FpSpread1.ActiveSheet.Cells(i, 6).Column.Width = 65         'material_HQ
            FpSpread1.ActiveSheet.Cells(i, 6).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(6).Label = "Material HQ"

            FpSpread1.ActiveSheet.Cells(i, 7).Column.Width = 63         'material_RL
            FpSpread1.ActiveSheet.Cells(i, 7).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(7).Label = "Material RL"

            FpSpread1.ActiveSheet.Cells(i, 8).Column.Width = 60         'sales tax
            FpSpread1.ActiveSheet.Cells(i, 8).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(8).Label = "Sales Tax"

            FpSpread1.ActiveSheet.Cells(i, 9).Column.Width = 50         'total BDP Hours
            FpSpread1.ActiveSheet.Cells(i, 9).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(9).Label = "BDP Hours"

            FpSpread1.ActiveSheet.Cells(i, 10).Column.Width = 50        'total special hours
            FpSpread1.ActiveSheet.Cells(i, 10).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(10).Label = "Special Hours"

            FpSpread1.ActiveSheet.Cells(i, 11).Column.Width = 50        'total labor hours
            FpSpread1.ActiveSheet.Cells(i, 11).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(11).Label = "Labor Hours"

            FpSpread1.ActiveSheet.Cells(i, 12).Column.Width = 60        'Overtime hours included
            FpSpread1.ActiveSheet.Cells(i, 12).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(12).Label = "OT Hrs Included"

            FpSpread1.ActiveSheet.Cells(i, 13).Column.Width = 60        'labor $
            FpSpread1.ActiveSheet.Cells(i, 13).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(13).Label = "Labor"

            FpSpread1.ActiveSheet.Cells(i, 14).Column.Width = 70        'Subcontract work
            FpSpread1.ActiveSheet.Cells(i, 14).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(14).Label = "Subcontact Work"

            FpSpread1.ActiveSheet.Cells(i, 15).Column.Width = 60        'expenses
            FpSpread1.ActiveSheet.Cells(i, 15).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(15).Label = "Expenses"

            FpSpread1.ActiveSheet.Cells(i, 16).Column.Width = 60        'engineering costs
            FpSpread1.ActiveSheet.Cells(i, 16).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(16).Label = "Eng Cost"

            FpSpread1.ActiveSheet.Cells(i, 17).Column.Width = 60        'misc costs
            FpSpread1.ActiveSheet.Cells(i, 17).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(17).Label = "P/O/B"

            FpSpread1.ActiveSheet.Cells(i, 18).Column.Width = 60        'freight
            FpSpread1.ActiveSheet.Cells(i, 18).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(18).Label = "Freight"

            FpSpread1.ActiveSheet.Cells(i, 19).Column.Width = 65        'NPS Cost
            FpSpread1.ActiveSheet.Cells(i, 19).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(19).Label = "NPS Cost"

            FpSpread1.ActiveSheet.Cells(i, 20).Column.Width = 70        'total bank cost
            FpSpread1.Sheets(0).ColumnHeader.Columns(20).Label = "Total Bank Cost"
            FpSpread1.ActiveSheet.Cells(i, 20).CellType = currencyType

            FpSpread1.ActiveSheet.Cells(i, 21).Column.Width = 50        'project c1
            FpSpread1.Sheets(0).ColumnHeader.Columns(21).Label = "C1"
            percentType.ReadOnly = True
            FpSpread1.ActiveSheet.Cells(i, 21).CellType = percentType
            FpSpread1.ActiveSheet.Cells(i, 21).Locked = False

            FpSpread1.ActiveSheet.Cells(i, 22).Column.Width = 70        'bank net price
            FpSpread1.ActiveSheet.Cells(i, 22).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(22).Label = "Bank Net Price"
            FpSpread1.ActiveSheet.Columns(22).Visible = False

            FpSpread1.ActiveSheet.Cells(i, 23).Column.Width = 60        'sales commission
            FpSpread1.ActiveSheet.Cells(i, 23).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(23).Label = "Sales Com"

            FpSpread1.ActiveSheet.Cells(i, 24).Column.Width = 70        'bank final price
            FpSpread1.ActiveSheet.Cells(i, 24).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(24).Label = "Sell Price"

            FpSpread1.ActiveSheet.Cells(i, 25).Column.Width = 60        'Labor rate
            FpSpread1.ActiveSheet.Cells(i, 25).CellType = currencyType
            FpSpread1.Sheets(0).ColumnHeader.Columns(25).Label = "Labor Rate"

            FpSpread1.ActiveSheet.Cells(i, 26).Column.Width = 40
            FpSpread1.ActiveSheet.Cells(i, 12).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(26).Label = "Prod Code"

            FpSpread1.ActiveSheet.Cells(i, 27).Column.Width = 40
            FpSpread1.ActiveSheet.Cells(i, 27).CellType = numberType
            FpSpread1.Sheets(0).ColumnHeader.Columns(27).Label = "Lead Time"

            FpSpread1.ActiveSheet.Cells(i, 28).Column.Width = 45      'Include indicator
            FpSpread1.Sheets(0).ColumnHeader.Columns(28).Label = "Include"
            FpSpread1.ActiveSheet.Cells(i, 28).CellType = ckbxcell
            FpSpread1.ActiveSheet.Cells(i, 28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            FpSpread1.ActiveSheet.Cells(i, 28).Locked = False

            FpSpread1.ActiveSheet.Columns(29).Visible = False       ' speed
            FpSpread1.ActiveSheet.Columns(30).Visible = False       ' machine_model
            FpSpread1.ActiveSheet.Columns(31).Visible = False       ' gateway_review_required

            FpSpread1.ActiveSheet.ColumnHeader.Rows(0).Height = 30

        Next

        SetTitleInfo()

        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
        CurrentBuildingInformationFrameHeight = BuildingInformation_fra.Height
        CurrentEquipmentFrameHeight = Equipment_fra.Height

        Relocate_Equipment_Frame()
        SizeTotalsGrid()

        ProcessNegSummaryTotals()
        SetSummaryC1Colors()

        initializing = False
        FpSpread1.Show()
    End Sub


    Private Sub FpSpread1_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

        Dim usex As FarPoint.Win.Spread.SheetView = e.View.GetSheetView
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        CurrentGOData_Typ.EstimateLevel = String.Empty
        CurrentGOData_Typ.Alt = "A"

        If usex.TitleInfo.Text.ToUpper.IndexOf("SUMMARY") > -1 Then
            CurrentGOData_Typ.EstimateLevel = "Summary"
        Else
            CurSummaryRow = 0
            For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
                If FpSpread1.ActiveSheet.Cells(iIndex, 3).Text = Strings.Right(usex.TitleInfo.Text, 1) Then
                    CurSummaryRow = iIndex
                    Exit For
                End If
            Next iIndex
            If usex.TitleInfo.Text.ToUpper.IndexOf("GRANDCHILD") > -1 Then
                CurrentGOData_Typ.Alt = usex.ActiveRowIndex + 1
                CurrentGOData_Typ.EstimateLevel = "Alt"
            Else
                ChildSheetView1 = FpSpread1.ActiveSheet.GetChildView(CurSummaryRow, 0)
                If Not IsNothing(ChildSheetView1) Then
                    If ChildSheetView1.RowCount > 0 Then
                        CurrentGOData_Typ.EstimateLevel = ChildSheetView1.Cells(e.Row, 0).Text
                    End If
                End If
            End If
        End If

        CurrentGOData_Typ.CurrentRow = e.Row
        UseCurRow = e.Row
        UseCurCol = e.Column

        ProcessNegSummaryTotals()

    End Sub

    Private Sub FpSpread1_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        If Not initializing Then isDirty = True
        CalculateC1_FinalBankPrice()
        SetSummaryC1Colors()
        SetBaseAltC1Colors()
    End Sub

    Private Sub FpSpread1_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs) Handles FpSpread1.ChildViewCreated

        Dim dateType As New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim gl As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, Color.Black)

        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True
        currencyType.MaximumValue = 50000000

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.DecimalPlaces = 2

        Dim numberType As New FarPoint.Win.Spread.CellType.NumberCellType()
        numberType.DecimalPlaces = 0
        numberType.ShowSeparator = True

        Dim ckbxcell As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        ' ckbxcell.TextTrue = "Included In Bid"
        ckbxcell.TextFalse = ""

        'Dim bttncell As New FarPoint.Win.Spread.CellType.ButtonCellType()
        'bttncell.ButtonColor = Color.Cyan
        'bttncell.DarkColor = Color.DarkCyan
        'bttncell.LightColor = Color.AliceBlue
        'bttncell.TwoState = False
        'bttncell.Text = "Merge"
        'bttncell.ShadowSize = 3

        e.SheetView.LockBackColor = Color.LightGray

        If e.SheetView.ParentRelationName = "Summary_Base_Relationship" Then  'Bank Row
            With e.SheetView
                .RowHeader.AutoText = False
                .DataAutoCellTypes = False
                .DataAutoSizeColumns = False
                .ColumnHeader.Rows(0).Height = 30

                .Columns(0).Label = "Group"
                .Columns(0).Locked = True
                .Columns(0).Width = 230

                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False

                .Columns(5).Label = "Material HQ"
                .Columns(5).Locked = True
                .Columns(5).CellType = currencyType
                .Columns(5).Width = 65

                .Columns(6).Label = "Material RL"
                .Columns(6).Locked = True
                .Columns(6).CellType = currencyType
                .Columns(6).Width = 63

                .Columns(7).Label = "Sales Tax"
                .Columns(7).Locked = True
                .Columns(7).CellType = currencyType
                .Columns(7).Width = 60

                .Columns(8).Label = "BDP Hours"
                .Columns(8).Locked = True
                .Columns(8).CellType = numberType
                .Columns(8).Width = 50

                .Columns(9).Label = "Special Hours"
                .Columns(9).Locked = True
                .Columns(9).CellType = numberType
                .Columns(9).Width = 50

                .Columns(10).Label = "Labor Hours"
                .Columns(10).Locked = True
                .Columns(10).CellType = numberType
                .Columns(10).Width = 50

                .Columns(11).Label = "OT Hrs Included"
                .Columns(11).Locked = True
                .Columns(11).CellType = numberType
                .Columns(11).Width = 60

                .Columns(12).Label = "Labor"
                .Columns(12).Locked = True
                .Columns(12).CellType = currencyType
                .Columns(12).Width = 60

                .Columns(13).Label = "Subcontact Work"
                .Columns(13).Locked = True
                .Columns(13).CellType = currencyType
                .Columns(13).Width = 70

                .Columns(14).Label = "Expenses"
                .Columns(14).Locked = True
                .Columns(14).CellType = currencyType
                .Columns(14).Width = 60

                .Columns(15).Label = "Eng Cost"
                .Columns(15).Locked = True
                .Columns(15).CellType = currencyType
                .Columns(15).Width = 60

                .Columns(16).Label = "P/O/B"
                .Columns(16).Locked = True
                .Columns(16).CellType = currencyType
                .Columns(16).Width = 60

                .Columns(17).Label = "Freight"
                .Columns(17).Locked = True
                .Columns(17).CellType = currencyType
                .Columns(17).Width = 60

                .Columns(18).Label = "NPS Cost"
                .Columns(18).Locked = True
                .Columns(18).CellType = currencyType
                .Columns(18).Width = 65

                .Columns(19).Label = "Total Bank Cost"
                .Columns(19).Locked = True
                .Columns(19).CellType = currencyType
                .Columns(19).Width = 70

                .Columns(20).Label = "C1"
                .Columns(20).Locked = False
                .Columns(20).CellType = percentType
                .Columns(20).Width = 50

                .Columns(21).Label = "Bank Net Price"
                .Columns(21).Locked = True
                .Columns(21).CellType = currencyType
                .Columns(21).Width = 70
                .Columns(21).Visible = False

                .Columns(22).Label = "Sales Com"
                .Columns(22).Locked = True
                .Columns(22).CellType = currencyType
                .Columns(22).Width = 60

                .Columns(23).Label = "Sell Price"
                .Columns(23).Locked = True
                .Columns(23).CellType = currencyType
                .Columns(23).Width = 70

                .Columns(24).Label = "Labor Rate"
                .Columns(24).Locked = True
                .Columns(24).CellType = currencyType
                .Columns(24).Width = 60

                .Columns(25).Label = "Prod Code"
                .Columns(25).Locked = True
                .Columns(25).Width = 40
                .Columns(25).CellType = numberType

                .Columns(26).Label = "Lead Time"
                .Columns(26).Locked = True
                .Columns(26).Width = 40
                .Columns(26).CellType = numberType

                .Columns(27).Label = "Comments"
                .Columns(27).Locked = False
                .Columns(27).Width = 175

                .Columns(28).Label = "Speed"
                .Columns(28).Locked = True
                .Columns(28).Width = 50
                .Columns(28).Visible = False

                .Columns(29).Label = "machine_model"
                .Columns(29).Locked = False
                .Columns(29).Width = 50
                .Columns(29).Visible = False


                .HorizontalGridLine = gl
                .VerticalGridLine = gl

                .SortRows(1, True, True)
                If .RowCount <> 1 Then
                    .SetRowExpandable(0, False)
                End If

            End With
        Else  ' AltGroup
            With e.SheetView

                .DataAutoCellTypes = False
                .DataAutoSizeColumns = False
                .ColumnHeader.Rows(0).Height = 30

                .Columns(0).Label = "Group"
                .Columns(0).Locked = True
                .Columns(0).Width = 114

                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(4).Label = "Offer"
                .Columns(4).Locked = False
                .Columns(4).CellType = ckbxcell
                .Columns(4).Width = 45
                .Columns(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center

                .Columns(5).Label = "Merge"
                .Columns(5).Locked = False
                .Columns(5).CellType = ckbxcell
                .Columns(5).Width = 45
                .Columns(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center

                .Columns(6).Label = "Material HQ"
                .Columns(6).Locked = True
                .Columns(6).CellType = currencyType
                .Columns(6).Width = 65

                .Columns(7).Label = "Material RL"
                .Columns(7).Locked = True
                .Columns(7).CellType = currencyType
                .Columns(7).Width = 63

                .Columns(8).Label = "Sales Tax"
                .Columns(8).Locked = True
                .Columns(8).CellType = currencyType
                .Columns(8).Width = 60

                .Columns(9).Label = "BDP Hours"
                .Columns(9).Locked = True
                .Columns(9).CellType = numberType
                .Columns(9).Width = 50

                .Columns(10).Label = "Special Hours"
                .Columns(10).Locked = True
                .Columns(10).CellType = numberType
                .Columns(10).Width = 50

                .Columns(11).Label = "Labor Hours"
                .Columns(11).Locked = True
                .Columns(11).CellType = numberType
                .Columns(11).Width = 50

                .Columns(12).Label = "OT Hrs Included"
                .Columns(12).Locked = True
                .Columns(12).CellType = numberType
                .Columns(12).Width = 60

                .Columns(13).Label = "Labor"
                .Columns(13).Locked = True
                .Columns(13).CellType = currencyType
                .Columns(13).Width = 60

                .Columns(14).Label = "Subcontact Work"
                .Columns(14).Locked = True
                .Columns(14).CellType = currencyType
                .Columns(14).Width = 70

                .Columns(15).Label = "Expenses"
                .Columns(15).Locked = True
                .Columns(15).CellType = currencyType
                .Columns(15).Width = 60

                .Columns(16).Label = "Eng Cost"
                .Columns(16).Locked = True
                .Columns(16).CellType = currencyType
                .Columns(16).Width = 60

                .Columns(17).Label = "P/O/B"
                .Columns(17).Locked = True
                .Columns(17).CellType = currencyType
                .Columns(17).Width = 60

                .Columns(18).Label = "Freight"
                .Columns(18).Locked = True
                .Columns(18).CellType = currencyType
                .Columns(18).Width = 60

                .Columns(19).Label = "NPS Cost"
                .Columns(19).Locked = True
                .Columns(19).CellType = currencyType
                .Columns(19).Width = 65

                .Columns(20).Label = "Total Bank Cost"
                .Columns(20).Locked = True
                .Columns(20).CellType = currencyType
                .Columns(20).Width = 70

                .Columns(21).Label = "C1"
                .Columns(21).Locked = False
                .Columns(21).CellType = percentType
                .Columns(21).Width = 50

                .Columns(22).Label = "Bank Net Price"
                .Columns(22).Locked = True
                .Columns(22).CellType = currencyType
                .Columns(22).Width = 70
                .Columns(22).Visible = False

                .Columns(23).Label = "Sales Com"
                .Columns(23).Locked = True
                .Columns(23).CellType = currencyType
                .Columns(23).Width = 60

                .Columns(24).Label = "Sell Price"
                .Columns(24).Locked = True
                .Columns(24).CellType = currencyType
                .Columns(24).Width = 70

                .Columns(25).Label = "Labor Rate"
                .Columns(25).Locked = True
                .Columns(25).CellType = currencyType
                .Columns(25).Width = 60


                .Columns(26).Label = "Prod Code"
                .Columns(26).Locked = True
                .Columns(26).Width = 40
                '   .Columns(26).CellType = numberType

                .Columns(27).Label = "Lead Time"
                .Columns(27).Locked = True
                .Columns(27).Width = 40
                '  .Columns(26).CellType = numberType

                .Columns(28).Label = "Comments"
                .Columns(28).Locked = False
                .Columns(28).Width = 175

                .Columns(29).Label = "Speed"
                .Columns(29).Locked = True
                .Columns(29).Width = 50
                .Columns(29).Visible = False

                .Columns(30).Label = "machine_model"
                .Columns(30).Locked = False
                .Columns(30).Width = 200
                .Columns(30).Width = 50
                .Columns(30).Visible = False

                .HorizontalGridLine = gl
                .VerticalGridLine = gl

            End With
        End If

        SetBaseAltC1Colors()
        RefineMasterRow()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ExpandCollapseAll("Expand")
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ExpandCollapseAll("Collapse")
    End Sub


    Private Sub ExpandCollapseAll(ByVal ExpandCollapseAction As String)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            Select Case ExpandCollapseAction
                Case "Expand"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, True)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, True)
                        Next jIndex
                    End If
                Case "Collapse"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, False)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, False)
                        Next jIndex
                    End If
                Case Else
            End Select
        Next iIndex

    End Sub


    Private Sub btnMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerge.Click

        Dim update_message As String
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        CurrentGOData_Typ.MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentGOData_Typ.CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case CurrentGOData_Typ.EstimateLevel
            Case "Summary"
            Case "Master"
            Case "Base", "Alt"

                Dim _id As String
                _id = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 1).Text

                Dim _bank As String
                _bank = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 3).Text

                Dim foundRows() As Data.DataRow
                Dim criteria As String
                criteria = "BaseGroup = 'Master' AND id = '" & _id & "'"
                foundRows = dtBaseGroup.Select(criteria)
                If foundRows.Count = 0 Then

                    update_message = "You are about to create a 'Master' for Bank " & _bank & ".  Are you sure?"

                    If MessageBox.Show(update_message, "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                        '  dsCadre.Tables("BaseGroup").Rows.Add((New Object() {"Master", altID, bank, "01-04", "Geared", target, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""}))
                        AddMasterRow(_id)

                        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
                        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
                        percentType.DecimalPlaces = 2
                        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(CurSummaryRow, 0)
                        ChildSheetView1.SortRows(1, True, True)
                        ChildSheetView1.SetRowExpandable(0, False)

                        percentType.ReadOnly = True
                        ChildSheetView1.Cells(0, 20).CellType = percentType
                        ChildSheetView1.Cells(1, 20).CellType = percentType
                        ChildSheetView1.Cells(0, 23).Locked = False

                        SetBaseAltC1Colors()

                        UpdateSummary(True)
                        SetSummaryC1Colors()

                        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "circlechecked.png"), FarPoint.Win.RenderStyle.Normal)
                        Dim t As New FarPoint.Win.Spread.CellType.TextCellType
                        t.BackgroundImage = p
                        ' Apply the text cell.
                        FpSpread1.ActiveSheet.Cells(CurSummaryRow, 2).CellType = t
                    End If
                Else
                    MessageBox.Show("A Master Has Already Been Created", "Cannot Create Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case Else

        End Select

        FpSpread1.Refresh()
        MergeBaseWithAlts()

    End Sub


    Private Function FindActiveRows() As Array

        Dim summaryRow As Integer = -1
        Dim baseRow As Integer = -1
        Dim altRow As Integer = -1
        Dim found As Boolean = False
        Dim returnArray(2) As String

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing


        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                If ChildSheetView1.SelectionCount > 0 Then
                    summaryRow = iIndex
                    baseRow = ChildSheetView1.ActiveRowIndex
                    Exit For
                End If
                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView2 = ChildSheetView1.FindChildView(jIndex, 0)
                    If Not IsNothing(ChildSheetView2) AndAlso ChildSheetView2.SelectionCount > 0 Then
                        summaryRow = iIndex
                        baseRow = jIndex
                        altRow = ChildSheetView2.ActiveRowIndex
                        found = True
                        Exit For
                    End If
                Next jIndex
                If found Then
                    Exit For
                End If
            End If
        Next
        returnArray = {summaryRow, baseRow, altRow}

        Return returnArray

    End Function


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        'Dim printset = New FarPoint.Win.Spread.PrintInfo()

        'printset.PrintToPdf = True

        'printset.PdfFileName = "c:\temp\test.pdf"

        'printset.PdfWriteMode = FarPoint.Win.Spread.PdfWriteMode.Append

        'For Each sheet As FarPoint.Win.Spread.SheetView In FpSpread1.Sheets

        '    sheet.PrintInfo = printset
        'Next

        'FpSpread1.PrintSheet(-1)


        Dim printset As New FarPoint.Win.Spread.PrintInfo()
        printset.PrintToPdf = True
        'printset.PdfFileName = "c:\temp\results.pdf"
        printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        printset.Margin.Top = 2
        printset.Margin.Bottom = 2
        printset.Margin.Left = 2
        printset.Margin.Right = 2
        printset.ZoomFactor = 0.9
        printset.BestFitCols = True

        Try
            printset.PdfFileName = ReportsPath & Me.txtEstimateNum.Text & "-" & Contracts.JobName & ".pdf"

            If File.Exists(printset.PdfFileName) Then
                File.Delete(printset.PdfFileName)
                Application.DoEvents()
            End If

            ExpandCollapseAll("Expand")
            ExpandCollapseAll("Collapse")

            Dim combinedSheet As New FarPoint.Win.Spread.SheetView
            combinedSheet = CreateCombinedSheet()

            SetCombinedSheetHeaders(combinedSheet)

            Dim header As String
            header = "Contract Management" & vbCrLf & vbCrLf & "Estimate:  " & Contracts.EstimateNum & vbCrLf & "Job Name:  " & Contracts.JobName & vbCrLf & vbCrLf

            printset.Header = header

            combinedSheet.PrintInfo = printset

            If Not IsNothing(combinedSheet) Then
                FpSpread1.PrintSheet(combinedSheet)
                Application.DoEvents()
                Process.Start(printset.PdfFileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Generating PDF (btnPrint)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddAlternateRow()

        'MsgBox(FpSpread1.ActiveSheet.ActiveRowIndex)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        Dim baseID As String, thisRowDescription As String
        Dim summaryRowIndex As Integer, baseRowIndex As Integer, altCount As Integer

        Dim activeRows As Array
        Dim activeRow As Integer
        Dim default_c1 As Decimal

        Try
            activeRows = FindActiveRows()
            activeRow = activeRows(0)

            ' if FindActiveRow returns -1, it's likely that the cursor is set on a summary row.  Then use ActiveRow
            If activeRow = -1 Then
                activeRow = FpSpread1.ActiveSheet.ActiveRowIndex
            End If

            ChildSheetView = FpSpread1.ActiveSheet.FindChildView(activeRow, 0)

            summaryRowIndex = ChildSheetView.ParentRowIndex
            baseRowIndex = ChildSheetView.ActiveRowIndex
            ChildSheetView2 = ChildSheetView.GetChildView(baseRowIndex, 0)
            altCount = ChildSheetView2.RowCount
            'ChildSheetView2.GetLastNonEmptyRow()
            If ChildSheetView.Cells(baseRowIndex, 0).Text = "Master" Then
                baseRowIndex += 1
            End If
            baseID = ChildSheetView.Cells(baseRowIndex, 4).Value
            thisRowDescription = "Alt"

            default_c1 = CalculateDefaultC1()

            dsCadre.Tables("AltGroup").Rows.Add(New Object() {thisRowDescription, baseID, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, default_c1, 0, 0, 0, 0})

            SetBaseAltC1Colors()

            FpSpread1.Refresh()

            MessageBox.Show("Alternate row added")
            isDirty = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Adding Alternate Row", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub AddBankRow()
        ' Add a new summary row to the grid
        ' Add a new base row to the grid
        Dim _id As String = GetRandom(10000000, 99999999).ToString
        Dim _bank As String = ""

        ' Initialize bank to A if no banks currently exist
        If dtSummaryGroup.Rows.Count = 0 Then
            _bank = "A"

        End If

        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.ReadOnly = True
        percentType.DecimalPlaces = 2

        Try
            Dim default_c1 As Decimal
            default_c1 = CalculateDefaultC1()

            dsCadre.Tables("SummaryGroup").Rows.Add(New Object() {"GO Summary", _id, "", _bank, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, default_c1, 0, 0, 0, 0, 0, 0, False, 0, "", False})

            FpSpread1.Refresh()
            FpSpread1.ActiveSheet.ActiveRowIndex = FpSpread1.ActiveSheet.RowCount - 1
            FpSpread1.ActiveSheet.ActiveRow.Locked = True

            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Locked = False
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Locked = False
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Locked = False
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 21).Locked = False

            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 6).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 7).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 8).CellType = currencyType

            For i As Integer = 13 To 24
                FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, i).CellType = currencyType
            Next

            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 21).CellType = percentType

            Dim cbstr As String()
            cbstr = New String() {"Geared", "Gearless", "Hydro"}
            Dim cmbocell_machine As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
            cmbocell_machine.Items = cbstr
            cmbocell_machine.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
            cmbocell_machine.Editable = False
            cmbocell_machine.MaxDrop = 4
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).CellType = cmbocell_machine

            Dim cbstr1 As String()
            FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 3, False)
            cbstr1 = BuildAvailableBanks()
            Dim cmbocell_bank As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
            cmbocell_bank.Items = cbstr1
            cmbocell_bank.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
            cmbocell_bank.Editable = False
            cmbocell_bank.MaxDrop = 4
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).CellType = cmbocell_bank

            FpSpread1.ActiveSheet.Columns(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center

            dtBaseGroup.Rows.Add(New Object() {"Base", _id, "1", "", _id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, default_c1, 0, 0, 0, 0, 0, 0, ""})
            isDirty = True

            adding_to_labor_and_overtime = True

            SetSummaryC1Colors()
            SetBaseAltC1Colors()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Adding Bank Row", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            FpSpread1.Refresh()
        End Try
    End Sub

    Private Sub FpSpread1_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        Select Case e.Column
            Case 3
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value = "" Then
                    MessageBox.Show("Please select a bank", "Bank ?", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Else
                    If copying_to_new_row Then
                        AddCopiedBaseAndAlt()
                    End If
                End If
            Case 4
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value = "" Then
                    MessageBox.Show("Please select a machine(bank_type).", "Missing Data")
                    'e.Cancel = True
                Else
                    FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 5, False)
                End If
        End Select
    End Sub


    Private Sub FpSpread1_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpSpread1.LeaveCell

        Dim textBoxType As New FarPoint.Win.Spread.CellType.TextCellType()


        Select Case e.Column
            Case 3
                Dim _bank As String = FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value.ToString
                If _bank = "" Then
                    MessageBox.Show("Please select a bank", "Bank ?", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    e.Cancel = True
                ElseIf adding_to_labor_and_overtime Then
                    dtLaborRates.Columns.Add("labor_ratio_" & _bank)
                    InsertNewOvertimeRow(_bank)
                    adding_to_labor_and_overtime = False
                End If

            Case 4
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value = "" Then
                    MessageBox.Show("Please select a machine(bank_type).", "Missing Data")
                    e.Cancel = True
                Else
                    FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 5, False)
                End If

            Case 5
                If Not validUnits() Then
                    e.Cancel = True
                End If
        End Select

        If e.Cancel = False Then
            If e.Row <> e.NewRow Then
                If StillValid() Then
                    FpSpread1.ActiveSheet.SortRows(3, True, False)
                Else
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Function validUnits() As Boolean
        Dim valid As Boolean = True

        Dim units() As String
        Dim subunits() As String

        units = FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Value.ToString.Split("-")

        For Each unit In units
            If unit.IndexOf(",") > -1 Then
                subunits = unit.Split(",")
                For Each subunit In subunits
                    If Not IsNumeric(subunit.Trim) Then
                        valid = False
                        Exit For
                    End If
                Next
            End If

            If Not valid Then Exit For

            If Not IsNumeric(unit.Trim) Then
                valid = False
                Exit For
            End If
        Next

        If Not valid Then
            MessageBox.Show("Please enter units as numerics(i.e., 01-03 or 01,02-04 etc)", "Invalid Units")
        End If

        Return valid

    End Function

    Private Function StillValid() As Boolean
        Dim isValid As Boolean = True

        If IsNothing(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Value) Or FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Value.ToString.Trim = "" Then
            MessageBox.Show("Please select a machine.", "Missing Data")
            isValid = False
        End If

        If Not validUnits() Then
            isValid = False
        End If

        Return isValid

    End Function


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim activeRows As Array
        activeRows = FindActiveRows()

        'MsgBox("ActiveIndexRow: " & FpSpread1.ActiveSheet.ActiveRowIndex & vbCrLf & _
        '       "Summary Row:  " & activeRows(0) & vbCrLf & _
        '       "Base Row: " & activeRows(1) & vbCrLf & _
        '       "Alt row:  " & activeRows(2))
        Dim summary_row As String
        If activeRows(0) = -1 And CurrentGOData_Typ.EstimateLevel = "Summary" Then
            summary_row = FpSpread1.Sheets(0).ActiveRowIndex
        Else
            summary_row = activeRows(0)
        End If

        If CurrentGOData_Typ.EstimateLevel = "Alt" Then
            If MessageBox.Show("You are about to delete Alternate '" & (activeRows(2) + 1).ToString & "' for Bank '" & FpSpread1.ActiveSheet.Cells(summary_row, 3).Value & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                'If MessageBox.Show("Delete Alt '" & CInt(activeRows(2)) + 1 & "' from the Estimate?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DeleteFiles()
                DeleteAltRow(activeRows)
            End If
        ElseIf CurrentGOData_Typ.EstimateLevel = "Master" Then
            Dim selected_bank As String = FpSpread1.Sheets(0).Cells(summary_row, 3).Text
            If MessageBox.Show("Delete Master for Bank '" & selected_bank & "' from the Estimate?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ' DeleteAltRow(activeRows)
                DeleteFiles()
                DeleteMaster(activeRows)
            End If
        ElseIf CurrentGOData_Typ.EstimateLevel = "Summary" Then
            Dim selected_bank As String = FpSpread1.Sheets(0).Cells(summary_row, 3).Text
            If MessageBox.Show("You are about to delete all data for Bank '" & selected_bank & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DeleteBank(summary_row)
                DeleteLaborAndOT(selected_bank)
                DeleteFiles()
            End If
        ElseIf CurrentGOData_Typ.EstimateLevel = "Base" Then
            MessageBox.Show("You cannot delete a Base Row.  You might want to remove the 'Summary' row to delete the estimate for the entire Bank", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please click on the Group Column of the Row you wish to delete", "Cannot Determine Which Row Selected!")
        End If

    End Sub

    Private Sub DeleteAltRow(ByVal activeRows As Array)
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(activeRows(0), 0)
        If Not ChildSheetView1 Is Nothing Then
            ChildSheetView2 = ChildSheetView1.FindChildView(activeRows(1), 0)
            If Not IsNothing(ChildSheetView2) Then
                Try
                    ChildSheetView2.RemoveRows(activeRows(2), 1)
                    isDirty = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Cannot Delete the Alt Row")
                End Try
            End If
        End If

    End Sub


    Private Function BuildAvailableBanks() As String()
        ' Roll thru all the banks in the summary row. 
        ' then delete if bank already in use

        Dim myList As New List(Of String)()
        Dim i As Integer
        Dim bank As String

        For i = 65 To 90     'build the initial list (A...Z)
            myList.Add(Chr(i))
        Next i

        For Each dr As DataRow In dsCadre.Tables(0).Rows
            If Not IsDBNull(dr("Bank")) Then
                bank = dr("Bank")
                If bank <> "" Then
                    i = myList.IndexOf(bank)
                    If i > -1 Then
                        myList.RemoveAt(i)
                    End If
                End If
            End If
        Next dr

        Return myList.ToArray

    End Function

    Private Function BuildBanks(ByVal thisBank As String) As String()

        Dim myList As New List(Of String)()

        myList = BuildAvailableBanks().ToList

        myList.Add(thisBank)
        myList.Sort()

        Return myList.ToArray

    End Function

    Private Sub Load_ListBoxes()
        Dim myList As New List(Of String)()

        cboBuildingType.Items.Clear()

        Dim sSQL As String = "SELECT code & ' - ' &  Description AS BldgCode " & _
                    "FROM [Building Code] " & _
                    "ORDER BY Code;"

        myList = GetDataFromOptions(sSQL)
        For Each code In myList
            cboBuildingType.Items.Add(code)
        Next

        sSQL = "SELECT DISTINCTROW [Local Code] & ' - ' & IIf([City] Is Null,'',[City] & ',') & IIf([State] Is Null,' ',[State]) AS [Local Code/ID] FROM [Local Code] WHERE [State] = '" & txtJobState.Text & "';"

        myList = GetDataFromOptions(sSQL)
        For Each code In myList
            cboLocalCode.Items.Add(code)
        Next

        cboANSICode.Items.Clear()
        cboANSICode.Items.Add(CStr(1971))
        cboANSICode.Items.Add(CStr(1978))
        cboANSICode.Items.Add(CStr(1981))
        cboANSICode.Items.Add(CStr(1984))
        cboANSICode.Items.Add(CStr(1987))
        cboANSICode.Items.Add(CStr(1989))
        cboANSICode.Items.Add(CStr(1990))
        cboANSICode.Items.Add(CStr(1993))
        cboANSICode.Items.Add(CStr(1994))
        cboANSICode.Items.Add(CStr(1996))
        cboANSICode.Items.Add(CStr(1997))
        cboANSICode.Items.Add(CStr(1998))
        cboANSICode.Items.Add(CStr(1999))
        cboANSICode.Items.Add(CStr(2000))
        cboANSICode.Items.Add(CStr(2002))
        cboANSICode.Items.Add(CStr(2003))
        cboANSICode.Items.Add(CStr(2004))
        cboANSICode.Items.Add(CStr(2005))
        cboANSICode.Items.Add(CStr(2007))
        cboANSICode.Items.Add(CStr(2008))
        cboANSICode.Items.Add(CStr(2009))
        cboANSICode.Items.Add(CStr(2010))
        cboANSICode.Items.Add(CStr(2013))
        cboANSICode.Items.Add(CStr(2016))

        cboNFPA13CodeYear.Items.Clear()
        cboNFPA13CodeYear.Items.Add("2010")
        cboNFPA13CodeYear.Items.Add("2013")

        cboNationalAccount.Items.Add("No")
        cboNationalAccount.Items.Add("Yes")

        cboTaxCode.Items.Clear()
        cboTaxCode.Items.Add("Taxable")
        cboTaxCode.Items.Add("Tax Exempt")
        If DefaultTaxCode = "Tax Excluded" Then cboTaxCode.Items.Add("Tax Excluded")

        cboSeismicZone.Items.Clear()
        For i As Integer = 0 To 4
            cboSeismicZone.Items.Add(CStr(i))
        Next i

        cboNFPA13CodeYear.Items.Clear()
        cboNFPA13CodeYear.Items.Add("2010")
        cboNFPA13CodeYear.Items.Add("2013")

        sSQL = "SELECT Office FROM [MOD OFFICE]  ORDER BY Office"
        myList = GetDataFromOptions(sSQL)
        For Each office In myList
            cboSalesOffice.Items.Add(office)
        Next

        'same query for installing office
        For Each office In myList
            cboInstallingOffice.Items.Add(office)
        Next

        sSQL = "SELECT Office FROM [MOD OFFICE] ORDER BY Office"
        myList = GetDataFromOptions(sSQL)
        For Each office In myList
            cboServiceOffice.Items.Add(office)
        Next

        cboProbabilityOfSale.Items.Clear()
        cboProbabilityOfSale.Items.Add("0-25%")
        cboProbabilityOfSale.Items.Add("26-50%")
        cboProbabilityOfSale.Items.Add("51-75%")
        cboProbabilityOfSale.Items.Add("76-99%")
        cboProbabilityOfSale.Items.Add("100%")

        cboDurationMonths.Items.Clear()
        cboDurationMonths.Items.Add("0")
        cboDurationMonths.Items.Add("3")
        cboDurationMonths.Items.Add("6")
        cboDurationMonths.Items.Add("9")
        cboDurationMonths.Items.Add("12")
        If Contracts.NationalAccount Then
            cboDurationMonths.Items.Add("15")
            cboDurationMonths.Items.Add("18")
            cboDurationMonths.Items.Add("21")
            cboDurationMonths.Items.Add("24")
        End If

        cboCallBackHours.Items.Clear()
        cboCallBackHours.Items.Add("0")
        cboCallBackHours.Items.Add("8")
        cboCallBackHours.Items.Add("24")

        cboStatus.Items.Clear()
        If Not String.IsNullOrEmpty(Contracts.CRM_Status) Then
            cboStatus.Items.Add(Contracts.CRM_Status)
        End If
        Select Case Contracts.BidType
            Case BID_TYPE_CAPITAL_PLAN
                cboStatus.Items.Add(Status_OpportunityInProgress)
                cboStatus.Items.Add(Status_OpportunityOnHold)
                cboStatus.Items.Add(Status_OpportunityLost)
                cboStatus.Items.Add(Status_OpportunityCancelled)
            Case Else
                Select Case Contracts.Status
                    Case Status_OfferSubmitted, Status_OfferOnHold, Status_OfferWon, Status_OfferLost
                        cboStatus.Items.Add(Status_OfferSubmitted)
                        cboStatus.Items.Add(Status_OfferOnHold)
                        cboStatus.Items.Add(Status_OfferWon)
                        cboStatus.Items.Add(Status_OfferLost)
                    Case Else
                        cboStatus.Items.Add(Status_OfferInProgress)
                        cboStatus.Items.Add(Status_OfferCancelled)
                End Select
        End Select

        Populate_SalesRep(Me.cboSalesRep)
        Populate_FieldSup()

    End Sub

    Private Sub Text2Fields()

        txtEstimateNum.Text = Contracts.EstimateNum
        txtEstimator.Text = Contracts.Estimator
        txtJobName.Text = Contracts.JobName
        txtJobAddress.Text = Contracts.JobAddress
        txtJobAddress2.Text = Contracts.JobAddress2
        txtJobCity.Text = Contracts.JobCity
        txtJobState.Text = Contracts.JobState
        txtJobZip.Text = Contracts.JobZip



        If Contracts.NationalAccount Then
            cboNationalAccount.SelectedItem = "Yes"
        Else
            cboNationalAccount.SelectedItem = "No"
        End If

        txtTaxRate.Text = GetTaxRate()

        AssignListIndex_First(cboBuildingType, Contracts.BuildingType)
        AssignListIndex_First(cboSalesOffice, Contracts.SalesRepOffice)
        AssignListIndex_First(cboStatus, Contracts.Status)
        AssignListIndex(cboSalesRep, Contracts.SalesRepName)
        AssignListIndex(cboSalesOffice, Contracts.SalesRepOffice)
    End Sub

    Private Sub txtBidDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBidDate.Validating
        If IsDate(txtBidDate.Text) Then
        Else
            e.Cancel = True
            MessageBox.Show("Please enter a valid date in the format mm/dd/yy", "Invalid Date")
        End If
    End Sub

    Private Sub btnContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContact.Click
        Using obj As New frmContacts
            obj.ShowDialog()
        End Using
    End Sub

    Private Sub cmbSeismicZone_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboSeismicZone.Leave, cboSeismicZone.SelectedIndexChanged
        ValidateTextBoxInput_Text(Me, cboSeismicZone, ENTRY_NOT_AN_INTEGER, True)
        If Not initializing Then isDirty = True
    End Sub

    Private Sub ExpandCollapseFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseFrame_btn.Click
        If BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            BuildingInformation_fra.Height = CurrentBuildingInformationFrameHeight
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "delete.png")
            For Each CurControl As Control In BuildingInformation_fra.Controls
                CurControl.Visible = True
            Next CurControl
            NewProductService_fra.Height = BuildingInformation_fra.Height
            For Each CurControl As Control In NewProductService_fra.Controls
                CurControl.Visible = True
            Next CurControl
            Me.txtOCPL.Visible = True
            Me.lblOCPL.Visible = True
            Me.btnLaborRates.Visible = True
        Else
            BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "add.png")
            For Each CurControl As Control In BuildingInformation_fra.Controls
                If CurControl.Name <> "ExpandCollapseFrame_btn" Then
                    CurControl.Visible = False
                End If
            Next CurControl
            NewProductService_fra.Height = BuildingInformation_fra.Height
            For Each CurControl As Control In NewProductService_fra.Controls
                CurControl.Visible = False
            Next CurControl
            Me.txtOCPL.Visible = False
            Me.lblOCPL.Visible = False
            Me.btnLaborRates.Visible = False
        End If
        Relocate_Equipment_Frame()

    End Sub
    Private Sub Relocate_Equipment_Frame()

        Equipment_fra.Top = BuildingInformation_fra.Top + BuildingInformation_fra.Height + 6
        If BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            Equipment_fra.Height += CurrentBuildingInformationFrameHeight - 20
        Else
            Equipment_fra.Height = CurrentEquipmentFrameHeight
        End If

    End Sub
    Private Sub FpSpread1_SelectionChanging(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.SelectionChangingEventArgs) Handles FpSpread1.SelectionChanging

        ProcessNegSummaryTotals()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveAll()
    End Sub


    Private Sub AddMasterRow(ByVal _id As String)

        On Error GoTo AddMasterRow_Error

        Dim altValue As Integer = 0
        Dim baseValue As Integer = 0
        Dim criteria As String

        criteria = "id = '" & _id & "'"
        Dim baseRow() As Data.DataRow
        baseRow = dtBaseGroup.Select(criteria)

        ' Copy existing Bank Row data into a new row
        Dim _newRow As DataRow = dtBaseGroup.NewRow

        ' Add each column value from base to new row for master
        For i As Integer = 0 To dtBaseGroup.Columns.Count - 1
            _newRow.Item(i) = baseRow(0).Item(i)
        Next

        ' Next, make adjustments to each column as specified from the 'merge' selected rows in alt group for this base
        Dim altRow() As Data.DataRow
        altRow = dtAltGroup.Select(criteria)

        For Each row In altRow
            If row.Item("Merge") = "True" Then
                For i As Integer = 6 To dtAltGroup.Columns.Count - 1
                    If i <> 28 Then  ' exclude comments
                        If i > 24 Then
                            Dim altString As String = IIf(IsDBNull(row.Item(i)), "", row.Item(i))
                            If altString.Length > 0 Then
                                _newRow.Item(i - 1) = altString
                            End If

                        Else
                            altValue = IIf(IsDBNull(row.Item(i)), 0, row.Item(i))

                            If i <> 21 Then     ' not moving C1 value
                                If IsDBNull(_newRow.Item(i - 1)) Then
                                    _newRow.Item(i - 1) = altValue
                                Else
                                    _newRow.Item(i - 1) += altValue
                                End If
                            Else
                                ' Recalculate C1 after all values processed
                            End If
                        End If

                    End If

                Next
            End If
        Next


        ' Recalculate the C1 now
        Dim sales_commission As Integer
        sales_commission = IIf(IsDBNull(_newRow.Item("Sales_Commission")), 0, _newRow.Item("Sales_Commission"))
        _newRow.Item("C1") = ((_newRow.Item("Bank_Final_Price") - sales_commission) / _newRow.Item("Total_Bank_Cost") - 1.0)

        ' Update new row as Master.
        _newRow("id") = _id
        _newRow("sort_fld") = "0"
        _newRow("BaseGroup") = "Master"
        _newRow("alt_id") = ""

        'TODO lock base C1


        dtBaseGroup.Rows.Add(_newRow)

        isDirty = True

        Exit Sub

AddMasterRow_Error:
        Select Case Err.Number
            Case Else
                MessageBox.Show(Err.Description, "Error Adding Master Row", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub DeleteMaster(ByVal activeRows() As String)

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(activeRows(0), 0)
        If ChildSheetView1.RowCount > 1 Then
            ChildSheetView1.RemoveRows(0, 1)
            isDirty = True
        End If

        '  "Unlock" C1
        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.DecimalPlaces = 2
        ChildSheetView1.Cells(0, 20).CellType = percentType

        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "openned.png"), FarPoint.Win.RenderStyle.Normal)
        Dim t As New FarPoint.Win.Spread.CellType.TextCellType
        t.BackgroundImage = p
        ' Apply the text cell.
        FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
        FpSpread1.Refresh()

    End Sub

    Private Sub DeleteBank(ByVal summaryRow As String)

        Try
            FpSpread1.ActiveSheet.RemoveRows(summaryRow, 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cannot Delete the Bank Row")
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim activeRows As Array
        activeRows = FindActiveRows()

        Dim summary_row As String
        If activeRows(0) = -1 And CurrentGOData_Typ.EstimateLevel = "Summary" Then
            summary_row = FpSpread1.Sheets(0).ActiveRowIndex
        Else
            summary_row = activeRows(0)
        End If

        If CurrentGOData_Typ.EstimateLevel = "Alt" Or CurrentGOData_Typ.EstimateLevel = "Base" Then
            AddAlternateRow()
        ElseIf CurrentGOData_Typ.EstimateLevel = "Summary" Then
            AddBankRow()
        ElseIf CurrentGOData_Typ.EstimateLevel = "Master" Then
            MessageBox.Show("You cannot add an alternate row to the Master Row.  Please select the Base Row where you wish to add an alternate.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("Please click on the 'Group' Column of the Row.", "Cannot Determine Which Group/Row to Add!")
        End If

    End Sub

    Private Sub LoadTopOfForm()
        Dim row As Data.DataRow
        Try
            If dtBuildingInfo.Rows.Count = 1 Then
                row = dtBuildingInfo.Rows(0)  ' there should only be one row.  unless new estimat
                txtEstimateNum.Text = Contracts.EstimateNum
                txtEstimator.Text = Contracts.Estimator
                txtJobName.Text = Contracts.JobName
                txtJobAddress.Text = Contracts.JobAddress
                txtJobAddress2.Text = Contracts.JobAddress2
                txtJobCity.Text = Contracts.JobCity
                txtJobState.Text = Contracts.JobState
                txtJobZip.Text = Contracts.JobZip

                txtConsultant.Text = GetConsultantsName()
                txtContractNumber.Text = Contracts.ContractNumber

                cboBuildingType.SelectedItem = row("building_type")
                cboSupt.SelectedItem = row("superintendent")
                cboSalesRep.SelectedItem = row.Item("sales_rep").ToString
                cboSalesOffice.SelectedItem = row.Item("Sales_Office").ToString
                cboInstallingOffice.SelectedItem = row.Item("installing_office").ToString
                cboServiceOffice.SelectedItem = row.Item("service_office").ToString

                'cboStatus.SelectedItem = row.Item("status").ToString
                cboProbabilityOfSale.SelectedText = Contracts.ProbabilityOfSale
                txtBidDate.Text = row.Item("bid_date").ToString

                cboNationalAccount.SelectedItem = row.Item("national_account").ToString

                txtTaxRate.Text = row.Item("tax_rate").ToString
                cboTaxCode.SelectedItem = row.Item("tax_code").ToString
                cboSeismicZone.SelectedItem = row.Item("seismic_zone").ToString
                cboLocalCode.SelectedItem = row.Item("local_code").ToString
                cboANSICode.SelectedItem = row.Item("ansi_csa_b44_code").ToString

                cboNFPA13CodeYear.SelectedItem = row.Item("nfpa_code").ToString
                txtSDSlevel.Text = row.Item("sds_level").ToString

                If IsDBNull(row.Item("oshpd")) Then
                    chkOSHPD.CheckState = CheckState.Unchecked
                Else
                    chkOSHPD.CheckState = IIf(row.Item("oshpd"), CheckState.Checked, CheckState.Unchecked)
                End If

                If IsDBNull(row.Item("dsa")) Then
                    chkDSA.CheckState = CheckState.Unchecked
                Else
                    chkDSA.CheckState = IIf(row.Item("dsa"), CheckState.Checked, CheckState.Unchecked)
                End If

                If IsDBNull(row.Item("head_detection")) Then
                    chkHeadDetection.CheckState = CheckState.Unchecked
                Else
                    chkHeadDetection.CheckState = IIf(row.Item("head_detection"), CheckState.Checked, CheckState.Unchecked)
                End If

                If IsDBNull(row.Item("engineering_survey")) Then
                    chkEngineeringSurvey.CheckState = CheckState.Unchecked
                Else
                    chkEngineeringSurvey.CheckState = IIf(row.Item("engineering_survey"), CheckState.Checked, CheckState.Unchecked)
                End If

                cboDurationMonths.SelectedItem = row.Item("nps_duration").ToString
                cboCallBackHours.SelectedItem = row.Item("nps_call_back").ToString
                txtNPSMaterialCost.Text = row.Item("nps_material_cost").ToString

                txtNPSLaborCost.Text = row.Item("nps_labor_cost").ToString
                txtNPSOneTimeCost.Text = row.Item("nps_one_time_cost").ToString
                txtOCPL.Text = row.Item("ocpl").ToString
            Else
                UpdateBldgInfoFromNotes()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Top of Form From Dataset", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub SaveTopOfFormToDataset()

        Try
            If dtBuildingInfo.Rows.Count = 0 Then
                Dim _newRow As DataRow = dtBuildingInfo.NewRow
                dtBuildingInfo.Rows.Add(_newRow)
            End If

            dtBuildingInfo.Rows(0)("building_type") = cboBuildingType.Text
            dtBuildingInfo.Rows(0)("superintendent") = cboSupt.Text

            dtBuildingInfo.Rows(0)("sales_rep") = cboSalesRep.Text
            dtBuildingInfo.Rows(0)("sales_office") = cboSalesOffice.Text
            dtBuildingInfo.Rows(0)("installing_office") = cboInstallingOffice.Text
            dtBuildingInfo.Rows(0)("service_office") = cboServiceOffice.Text
            'row("status") = cboStatus.Text
            'row("probability_of_sale") = cboProbabilityOfSale.Text
            dtBuildingInfo.Rows(0)("bid_date") = txtBidDate.Text
            dtBuildingInfo.Rows(0)("national_account") = cboNationalAccount.Text
            dtBuildingInfo.Rows(0)("tax_rate") = txtTaxRate.Text
            dtBuildingInfo.Rows(0)("tax_code") = cboTaxCode.Text
            dtBuildingInfo.Rows(0)("seismic_zone") = cboSeismicZone.Text
            dtBuildingInfo.Rows(0)("local_code") = cboLocalCode.Text
            dtBuildingInfo.Rows(0)("ansi_csa_b44_code") = cboANSICode.Text
            dtBuildingInfo.Rows(0)("nfpa_code") = cboNFPA13CodeYear.Text
            dtBuildingInfo.Rows(0)("sds_level") = txtSDSlevel.Text
            dtBuildingInfo.Rows(0)("oshpd") = chkOSHPD.CheckState
            dtBuildingInfo.Rows(0)("dsa") = chkDSA.CheckState
            dtBuildingInfo.Rows(0)("head_detection") = chkHeadDetection.CheckState
            dtBuildingInfo.Rows(0)("engineering_survey") = chkEngineeringSurvey.CheckState
            dtBuildingInfo.Rows(0)("nps_duration") = cboDurationMonths.Text
            dtBuildingInfo.Rows(0)("nps_call_back") = cboCallBackHours.Text
            dtBuildingInfo.Rows(0)("nps_material_cost") = txtNPSMaterialCost.Text
            dtBuildingInfo.Rows(0)("nps_labor_cost") = txtNPSLaborCost.Text
            dtBuildingInfo.Rows(0)("nps_one_time_cost") = txtNPSOneTimeCost.Text
            dtBuildingInfo.Rows(0)("ocpl") = txtOCPL.Text
        Catch ex As Exception
            MessageBox.Show("Error saving data at top of Contract Management Screen", "Error Saving to Dataset", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CM_MAIN_frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        sprTotals.Refresh()
    End Sub

    Private Sub ProcessNegSummaryTotals()
        Dim dblC1 As Double
        Dim dblValue As Double
        Dim summaryColumn As Integer = 0

        If Not IsNothing(dtSummaryGroup) AndAlso dtSummaryGroup.Rows.Count > 0 Then

            For i As Integer = 6 To dtSummaryGroup.Columns.Count - 1
                dblValue = 0
                For Each row As DataRow In dtSummaryGroup.Rows
                    If Not IsDBNull(row.Item(i)) Then
                        If IsNumeric(row.Item(i)) Then
                            dblValue += row.Item(i)
                        End If
                    End If
                Next row
                Select Case i
                    Case 6 To 8, 13 To 20, 22 To 26
                        sprTotals.ActiveSheet.Cells(0, summaryColumn).Text = FormatCurrency(dblValue, 0)
                    Case 9 To 12
                        sprTotals.ActiveSheet.Cells(0, summaryColumn).Text = FormatNumber(dblValue, 0)
                    Case 21
                        'calculate after loop
                End Select

                summaryColumn += 1
            Next i
            dblC1 = (sprTotals.ActiveSheet.Cells(0, 18).Text - sprTotals.ActiveSheet.Cells(0, 17).Text) / (sprTotals.ActiveSheet.Cells(0, 14).Text) - 1.0
            sprTotals.ActiveSheet.Cells(0, 15).Text = Math.Round(dblC1, 4).ToString("P")

            sprTotals.Refresh()
        End If

    End Sub

    Private Sub SizeTotalsGrid()

        sprTotals.ActiveSheet.Cells(0, 0).Column.Width = 63         'material_HQ
        sprTotals.ActiveSheet.Cells(0, 1).Column.Width = 63         'material_RL
        sprTotals.ActiveSheet.Cells(0, 2).Column.Width = 60         'sales tax
        sprTotals.ActiveSheet.Cells(0, 3).Column.Width = 50         'total BDP Hours
        sprTotals.ActiveSheet.Cells(0, 4).Column.Width = 50        'total special hours
        sprTotals.ActiveSheet.Cells(0, 5).Column.Width = 50        'total labor hours
        sprTotals.ActiveSheet.Cells(0, 6).Column.Width = 60        'Overtime hours included
        sprTotals.ActiveSheet.Cells(0, 7).Column.Width = 60        'labor $
        sprTotals.ActiveSheet.Cells(0, 8).Column.Width = 70        'Subcontract work
        sprTotals.ActiveSheet.Cells(0, 9).Column.Width = 60        'expenses
        sprTotals.ActiveSheet.Cells(0, 10).Column.Width = 60        'misc costs
        sprTotals.ActiveSheet.Cells(0, 11).Column.Width = 60        'freight
        sprTotals.ActiveSheet.Cells(0, 12).Column.Width = 60        'freight
        sprTotals.ActiveSheet.Cells(0, 13).Column.Width = 65        'NPS Cost
        sprTotals.ActiveSheet.Cells(0, 14).Column.Width = 70        'total bank cost
        sprTotals.ActiveSheet.Cells(0, 15).Column.Width = 50        'project c1
        sprTotals.ActiveSheet.Cells(0, 16).Column.Width = 70        'bank net price
        sprTotals.ActiveSheet.Cells(0, 17).Column.Width = 60        'sales commission
        sprTotals.ActiveSheet.Cells(0, 18).Column.Width = 70        'bank final price (Sell Pric3
        sprTotals.ActiveSheet.Cells(0, 19).Column.Width = 60       'labor rate

        sprTotals.ActiveSheet.Rows(0).Locked = True

        sprTotals.ActiveSheet.Cells(0, 16).Column.Visible = False

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        If isDirty Then
            If PromptForSave() = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        EndProgram()

    End Sub

    Private Sub cboSalesOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesOffice.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub

    Private Sub updateDtBuildingInfo(ByVal column_name As String, ByVal value As String)
        Dim row As DataRow
        row = dtBuildingInfo.Rows(0)
        row(column_name) = value
    End Sub


    Private Sub FpSpread1_SubEditorOpening(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.SubEditorOpeningEventArgs) Handles FpSpread1.SubEditorOpening
        e.Cancel = True     ' to prevent calculator from automatically opening on number cell double click
    End Sub
    Private Sub cboBuildingType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBuildingType.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboSalesRep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesRep.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboInstallingOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstallingOffice.SelectedIndexChanged
        If Not initializing Then
            isDirty = True
            If dtBuildingInfo.Rows.Count = 0 OrElse cboInstallingOffice.Text <> dtBuildingInfo.Rows(0).Item("installing_office") Then
                RecalculateLaborRates()
            End If
        End If
    End Sub
    Private Sub cboServiceOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiceOffice.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboProbabilityOfSale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProbabilityOfSale.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtBidDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBidDate.ValueChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboNationalAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNationalAccount.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtTaxRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxRate.TextChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboTaxCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTaxCode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboLocalCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocalCode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboANSICode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboANSICode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboNFPA13CodeYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNFPA13CodeYear.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtSDSlevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDSlevel.TextChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkOSHPD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOSHPD.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkDSA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDSA.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkHeadDetection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeadDetection.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkEngineeringSurvey_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEngineeringSurvey.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboSupt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSupt.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        ' copy the selected summary, and copy, along with all base, master  and  alt data

        If CurrentGOData_Typ.EstimateLevel <> "Summary" Then
            MessageBox.Show("Please select the group column of the summary group that you wish to copy, then click on 'Copy'.", "Please Identify The Group to Copy", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        copying_to_new_row = True

        ExpandCollapseAll("Collapse")

        CopySummaryRow()

        'id = FpSpread1.ActiveSheet.RowCount - 1

        FpSpread1.Refresh()
        FpSpread1.ActiveSheet.ActiveRowIndex = FpSpread1.ActiveSheet.RowCount - 1
        FpSpread1.ActiveSheet.ActiveRow.Locked = True

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Locked = False
        'FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Locked = False
        'FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Locked = False
        'FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 20).Locked = False


        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.ReadOnly = True
        percentType.DecimalPlaces = 2

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 6).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 7).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 8).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 21).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 22).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 23).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 24).CellType = currencyType

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 20).CellType = percentType

        For i As Integer = 13 To 18
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, i).CellType = currencyType
        Next

        Dim cbstr As String()
        cbstr = New String() {"Geared", "Gearless", "Hydro"}
        Dim cmbocell_machine As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell_machine.Items = cbstr
        cmbocell_machine.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell_machine.Editable = False
        cmbocell_machine.MaxDrop = 4
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).CellType = cmbocell_machine

        Dim cbstr1 As String()
        FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 3, False)
        cbstr1 = BuildAvailableBanks()
        Dim cmbocell_bank As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell_bank.Items = cbstr1
        cmbocell_bank.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell_bank.Editable = False
        cmbocell_bank.MaxDrop = 4
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).CellType = cmbocell_bank

        FpSpread1.ActiveSheet.Columns(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center

        FpSpread1.ActiveSheet.SetRowExpandable(FpSpread1.ActiveSheet.ActiveRowIndex, False)
        FpSpread1.Refresh()
    End Sub

    Public Sub SaveAll()
        SaveTopOfFormToDataset()
        'Serialize("C:\Temp\cadre.json", dsCadre, "Error Writing Cadre Json file", isDirty)           'Contracts.EstimateNum & ".json"
        ' Serialize(Contracts.EstimateNum & ".json", dsCadre, "Error Writing Cadre Json file", isDirty) 
        Serialize(CM_file, dsCadre, "Error Writing Cadre Json file", isDirty)
        SaveData_Contract() '
    End Sub

    Private Sub UpdateContactGroupFromNotes()
        Dim _row As DataRow = dtContactGroup.NewRow
        Try
            _row("contactType") = "owner"
            _row("companyName") = Owner_Info.Name
            _row("contactName") = ""
            _row("address") = Owner_Info.Address
            _row("address2") = Owner_Info.Address2
            _row("city") = Owner_Info.City
            _row("state") = Owner_Info.State
            _row("zipcode") = Owner_Info.Zip
            _row("phone") = Owner_Info.Phone
            _row("ext") = Owner_Info.Ext
            _row("fax") = Owner_Info.Fax
            _row("email") = ""

            dtContactGroup.Rows.Add(_row)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Updating Contact Group From Notes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Update new row as Master

    End Sub

    Private Sub UpdateBldgInfoFromNotes()

        AssignListIndex_First(cboBuildingType, Contracts.BuildingType)
        AssignListIndex_First(cboSalesRep, Contracts.SalesRepName)
        AssignListIndex_First(cboSalesOffice, Contracts.SalesRepOffice)
        AssignListIndex_First(cboProbabilityOfSale, Contracts.ProbabilityOfSale)

        txtTaxRate.Text = GetTaxRate()

        If Contracts.NationalAccount Then
            cboNationalAccount.SelectedIndex = 1
        Else
            cboNationalAccount.SelectedIndex = 0
        End If

        txtEstimateNum.Text = Contracts.EstimateNum
        txtEstimator.Text = Contracts.Estimator
        txtJobName.Text = Contracts.JobName
        txtJobAddress.Text = Contracts.JobAddress
        txtJobAddress2.Text = Contracts.JobAddress2
        txtJobCity.Text = Contracts.JobCity
        txtJobState.Text = Contracts.JobState
        txtJobZip.Text = Contracts.JobZip


    End Sub


    Private Function GetTaxRate() As Object
        Dim sql_string As String
        Dim my_list As New List(Of String)()
        Dim tax_rate As Single

        Try
            If All_LocalCodeDep.CanadaJob Then
                sql_string = "SELECT PSTRate FROM [Rate (Canada Tax)] Where Province ='" & Contracts.JobState & "'"
            Else
                sql_string = "SELECT [Tax Rate] FROM [Rate (US Tax)] WHERE State = '" & Contracts.JobState & "'"
            End If

            my_list = GetDataFromOptions(sql_string)
            tax_rate = CSng(my_list(0))

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "GetTaxRate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return tax_rate

    End Function

    Private Sub SetSummaryC1Colors()

        ' I'm using the datatable as much as possible due to the fact that rows in the datatable
        ' are not always in the same order as the grid.  The grid gets sorted, the datatables are not.
        ' It's possible that the datatables can be re-sorted, but that's for another time.

        Dim i As Integer
        Dim budget_c1 As Decimal
        Dim speed As Integer
        Dim machine_model As String = ""
        Dim bank_type As String = ""
        Dim _id As String
        Dim _C1 As Decimal
        Try

            For i = 0 To FpSpread1.ActiveSheet.RowCount - 1
                _id = FpSpread1.ActiveSheet.Cells(i, 1).Value
                Dim baseRow() As Data.DataRow
                baseRow = dtSummaryGroup.Select("id = '" & _id & "'")

                If Not IsDBNull(baseRow(0).Item("speed")) Then
                    speed = baseRow(0).Item("speed")
                End If

                If Not IsDBNull(baseRow(0).Item("machine_model")) Then
                    machine_model = baseRow(0).Item("machine_model")
                End If

                If Not IsDBNull(baseRow(0).Item("Bank_Type")) Then
                    bank_type = baseRow(0).Item("Bank_Type")
                End If

                If Not IsDBNull(baseRow(0).Item("C1")) Then
                    _C1 = baseRow(0).Item("C1")
                End If

                budget_c1 = GetBudgetC1(speed, machine_model, bank_type)

                If _C1 < budget_c1 Then
                    FpSpread1.ActiveSheet.Cells(i, 21).BackColor = Color.Red
                ElseIf _C1 >= budget_c1 + 0.04 Then
                    FpSpread1.ActiveSheet.Cells(i, 21).BackColor = Color.Green
                Else
                    FpSpread1.ActiveSheet.Cells(i, 21).BackColor = Color.Yellow
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Setting Summary C1 Colors", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetBaseAltC1Colors()

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        Dim budget_c1 As Decimal
        Dim criteria As String
        Dim base_speed As Integer
        Dim base_model As String = String.Empty
        Dim base_bank_type As String = String.Empty
        Dim alt_speed As Integer
        Dim alt_model As String = String.Empty
        Dim alt_bank_type As String = String.Empty
        Try
            For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
                ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)

                If Not ChildSheetView1 Is Nothing Then
                    For i As Integer = 0 To ChildSheetView1.RowCount - 1
                        criteria = "id = '" & ChildSheetView1.Cells(i, 1).Value & "'"
                        Dim baseRow() As Data.DataRow
                        baseRow = dtSummaryGroup.Select(criteria)

                        If Not IsDBNull(baseRow(0).Item("speed")) Then
                            base_speed = baseRow(0).Item("speed")
                        End If

                        If Not IsDBNull(baseRow(0).Item("machine_model")) Then
                            base_model = baseRow(0).Item("machine_model")
                        End If

                        If Not IsDBNull(baseRow(0).Item("Bank_Type")) Then
                            base_bank_type = baseRow(0).Item("Bank_Type")
                        End If

                        budget_c1 = GetBudgetC1(base_speed, base_model, base_bank_type)
                        If ChildSheetView1.Cells(i, 20).Value < budget_c1 Then
                            ChildSheetView1.Cells(i, 20).BackColor = Color.Red
                        ElseIf ChildSheetView1.Cells(i, 20).Value > budget_c1 + 0.04 Then
                            ChildSheetView1.Cells(i, 20).BackColor = Color.Green
                        Else
                            ChildSheetView1.Cells(i, 20).BackColor = Color.Yellow
                        End If
                    Next

                    For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                        ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)

                        If Not ChildSheetView2 Is Nothing Then
                            For i As Integer = 0 To ChildSheetView2.RowCount - 1
                                criteria = "id = '" & ChildSheetView2.Cells(i, 1).Value & "'"
                                Dim altRow() As Data.DataRow
                                altRow = dtSummaryGroup.Select(criteria)

                                If Not IsDBNull(altRow(0).Item("speed")) Then
                                    alt_speed = altRow(0).Item("speed")
                                End If

                                If Not IsDBNull(altRow(0).Item("machine_model")) Then
                                    alt_model = altRow(0).Item("machine_model")
                                End If

                                If Not IsDBNull(altRow(0).Item("Bank_Type")) Then
                                    alt_bank_type = altRow(0).Item("Bank_Type")
                                End If
                                budget_c1 = GetBudgetC1(alt_speed, alt_model, alt_bank_type)
                                If ChildSheetView2.Cells(i, 21).Value < budget_c1 Then
                                    ChildSheetView2.Cells(i, 21).BackColor = Color.Red
                                ElseIf ChildSheetView2.Cells(i, 21).Value > budget_c1 + 0.04 Then
                                    ChildSheetView2.Cells(i, 21).BackColor = Color.Green
                                Else
                                    ChildSheetView2.Cells(i, 21).BackColor = Color.Yellow
                                End If
                            Next

                        End If
                    Next jindex

                End If
            Next iIndex
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in SetBaseAltC1Colors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New System.Exception("  An Error Occurred.  Processing Terminated")
        End Try

    End Sub

    Private Sub RefineMasterRow()

        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing
        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView Is Nothing Then
                For i As Integer = 0 To ChildSheetView.RowCount - 1
                    If ChildSheetView.Cells(i, 0).Value = "Master" Then
                        percentType.ReadOnly = True
                        ChildSheetView.Cells(0, 23).Locked = False
                    End If
                Next i
            End If
        Next iIndex

    End Sub

    Private Sub CopySummaryRow()
        ' copies the row of data from the summary table of which the cursor is currently positioned
        ' id_to_copy used later to create base and alt rows

        Dim criteria As String

        id_to_copy = FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 1).Value

        criteria = "id = '" & id_to_copy & "'"
        Dim baseRow() As Data.DataRow
        baseRow = dtSummaryGroup.Select(criteria)

        ' Copy existing  Row into a new row
        Dim newRow As DataRow = dtSummaryGroup.NewRow

        ' Add each column value from base to new row for master
        For i As Integer = 0 To dtSummaryGroup.Columns.Count - 1
            newRow.Item(i) = baseRow(0).Item(i)
        Next

        newRow("id") = GetRandom(10000000, 99999999).ToString
        newRow("bank") = ""
        dtSummaryGroup.Rows.Add(newRow)

    End Sub

    Private Sub AddCopiedBaseAndAlt()
        ' copies the rows in base and alt for the selected summary
        ' also enables bank_type, units, c1 etc.

        '   Stop
        Dim _currentRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex
        FpSpread1.ActiveSheet.Cells(_currentRow, 4).Locked = False
        FpSpread1.ActiveSheet.Cells(_currentRow, 5).Locked = False
        FpSpread1.ActiveSheet.Cells(_currentRow, 20).Locked = False

        CopyBaseRows()
        FpSpread1.ActiveSheet.SetRowExpandable(_currentRow, True)
        CopyAltRows()

        FpSpread1.Refresh()

        SetTitleInfo()
    End Sub

    Private Sub CopyBaseRows()
        Dim _foundRows() As Data.DataRow
        _foundRows = dtBaseGroup.Select("id = '" & id_to_copy & "'")

        For i As Integer = 0 To _foundRows.Count - 1
            Dim _newRow As DataRow = dtBaseGroup.NewRow
            ' Add each column value from base to new row  
            For j As Integer = 0 To dtBaseGroup.Columns.Count - 1
                _newRow.Item(j) = _foundRows(i).Item(j)
            Next

            _newRow("id") = FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 1).Value

            If _newRow("BaseGroup") = "Base" Then
                _newRow("alt_id") = _newRow("id")
            Else
                _newRow("alt_id") = ""
            End If
            dtBaseGroup.Rows.Add(_newRow)
            FpSpread1.Refresh()
        Next

    End Sub

    Private Sub CopyAltRows()
        Dim _foundRows() As Data.DataRow
        _foundRows = dtAltGroup.Select("id = '" & id_to_copy & "'")

        For i As Integer = 0 To _foundRows.Count - 1
            Dim _newRow As DataRow = dtAltGroup.NewRow

            ' Add each column value from base to new row  
            For j As Integer = 0 To dtAltGroup.Columns.Count - 1
                _newRow.Item(j) = _foundRows(i).Item(j)
            Next

            _newRow.Item("id") = FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 1).Value

            dtAltGroup.Rows.Add(_newRow)
            FpSpread1.Refresh()
        Next
        FpSpread1.Refresh()
    End Sub

    Private Sub SetTitleInfo()

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing

        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")

        FpSpread1.Visible = True
        FpSpread1.ActiveSheet.TitleInfo.Value = "Summary"

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                ChildSheetView1.TitleInfo.Value = "Child" & FpSpread1.ActiveSheet.Cells(iIndex, 3).Text
                If ChildSheetView1.RowCount = 0 Then
                    ChildSheetView1.SetRowExpandable(iIndex, False)
                End If
                For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                    If Not ChildSheetView2 Is Nothing Then
                        ChildSheetView2.TitleInfo.Value = "Grandchild" & FpSpread1.ActiveSheet.Cells(iIndex, 3).Text
                        ChildSheetView2.SetColumnVisible(1, False)
                    Else

                    End If
                Next jindex
                'Else
                '    ChildSheetView1.ColumnHeaderVisible = False
            End If
        Next iIndex
    End Sub

    Private Sub btnLaborRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaborRates.Click

        'Dim obj As New frmLaborRates
        If Me.cboInstallingOffice.Text = "" Then
            MessageBox.Show("Please select an Installing Office to calculate Labor Rates", "Missing Installing Office", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        Try
            Using obj As New frmLaborRates
                obj.localOffice = Me.cboInstallingOffice.Text
                obj.ShowDialog()
            End Using      ' calls dispose automatically

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Labor Rates Form", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub CalculateC1_FinalBankPrice()
        CalculateSummaryC1()
        CalculateBaseFinalBankPriceOrMasterC1()
        CalculateAltFinalBankPrice()
    End Sub

    Private Sub CalculateSummaryC1()

        Dim sales_commission As Double

        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) AndAlso row.Item("Total_Bank_Cost") <> 0 Then
                sales_commission = IIf(IsDBNull(row.Item("Sales_Commission")), 0, row.Item("Sales_Commission"))
                row.Item("C1") = (((row.Item("Bank_Final_Price") - sales_commission)) / (row.Item("Total_Bank_Cost"))) - 1.0
                row.Item("C1") = Math.Round(row.Item("C1"), 4)
            End If
        Next row

    End Sub

    Private Sub CalculateBaseFinalBankPriceOrMasterC1()

        Dim sales_commission As Double

        For Each row As DataRow In dtBaseGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) Then
                sales_commission = IIf(IsDBNull(row.Item("Sales_Commission")), 0, row.Item("Sales_Commission"))
                If row.Item(0) = "Master" Then
                    row.Item("C1") = (((row.Item("Bank_Final_Price") - sales_commission)) / (row.Item("Total_Bank_Cost"))) - 1.0
                    row.Item("C1") = Math.Round(row.Item("C1"), 4)
                Else
                    row.Item("Bank_Final_Price") = (row.Item("Total_Bank_Cost") * (1.0 + row.Item("C1"))) + sales_commission
                End If
            End If

        Next row

        UpdateSummary()

    End Sub

    Private Sub UpdateSummary(Optional ByVal merging As Boolean = False)
        Dim _id As String = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 1).Text
        Dim _level As String = String.Empty


        If CurrentGOData_Typ.EstimateLevel = "Master" Or merging Then
            _level = "Master"
        ElseIf CurrentGOData_Typ.EstimateLevel = "Base" Then
            _level = "Base"
        End If

        If _level <> String.Empty Then
            Dim _dataRow() As Data.DataRow
            _dataRow = dtBaseGroup.Select("id = '" & _id & "' and BaseGroup = '" & _level & "'")

            Dim _summaryRow() As Data.DataRow
            _summaryRow = dtSummaryGroup.Select("id = '" & _id & "'")
            If _dataRow.Length > 0 Then
                If _level = "Base" Then
                    _summaryRow(0)("C1") = _dataRow(0)("C1")
                    _summaryRow(0)("Bank_Final_Price") = _dataRow(0)("Bank_Final_Price")
                Else
                    Dim _columnName As String
                    For i As Integer = 5 To dtBaseGroup.Columns.Count - 1
                        _columnName = dtBaseGroup.Columns(i).ColumnName
                        If _columnName <> "Comment" Then
                            _summaryRow(0)(_columnName) = _dataRow(0)(_columnName)
                        End If
                    Next
                End If
            End If
        End If

        ProcessNegSummaryTotals()

    End Sub

    Private Sub CalculateAltFinalBankPrice()
        Dim sales_commission As Double

        For Each row As DataRow In dtAltGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) Then
                sales_commission = IIf(IsDBNull(row.Item("Sales_Commission")), 0, row.Item("Sales_Commission"))
                row.Item("Bank_Final_Price") = (row.Item("Total_Bank_Cost") * (1.0 + row.Item("C1"))) + sales_commission
            End If
        Next row

    End Sub

    Private Function SaveData_Contract() As Integer
        Dim result As Integer = 0
        '   Dim TempGO As Integer = GONumbers(CurrentGOSelection).GONumbersID

        Me.Cursor = Cursors.WaitCursor
        '      Fields2Type()
        '     result = Me.Validate_Renamed()
        'If result = MsgBoxStyle.Critical Then
        '    Me.Cursor = Cursors.Default
        '    Return result
        'End If
        'Load_Office_Dependents()
        'Write_CM()
        'If NewJob And GONumbers(0).Bank <> "" And GONumbers(0).Alt <> "" And GONumbers(0).Units <> "" Then
        '    Set_CurrentAddress()
        '    NewJob = False
        'End If
        ArchiveFiles()
        'Set_GO_Dependents(CurrentGOSelection)
        'gbMDIChildDirty = False
        'System_DataBaseSetup()
        Add_FeedBack_Doc()
        Me.Cursor = Cursors.Default
        StatusBar1.Items.Item(0).Text = "Contract Manager Data Has Been Saved!"
        'SortLogic()
        'CurrentGOSelection = Find_CurrentGoSelection(TempGO)
        Return System.Windows.Forms.DialogResult.OK

    End Function

    'Public Sub Load_Office_Dependents()
    '    'Dim OfficeRecordset As New ADODB.Recordset
    '    'Dim Where As String = String.Empty, IndexName As String = String.Empty

    '    'Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, 1, OPEN_RECORD, MOD_OFFICE_SQL, , , , , , ADOCatalogOptionDataBase)
    '    'Where = "[Office] = '" & Contracts.InstallingOffice & "'"
    '    'If Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, 1, FIND_FIRST, MOD_OFFICE_SQL, Where) = 0 Then
    '    '    Contracts.DistrictCode = OfficeRecordset("District").Value.ToString
    '    'Else
    '    '    Where = "[Office] = '" & Contracts.ServiceOffice & "'"
    '    '    If Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, 1, FIND_FIRST, MOD_OFFICE_SQL, Where) = 0 Then
    '    '        Contracts.DistrictCode = OfficeRecordset("District").Value.ToString
    '    '    End If
    '    'End If
    '    'Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, 1, CLOSE_RECORD)
    '    'Select Case Conversion.Val(Contracts.DistrictCode)
    '    '    Case 11, 16, 23, 25, 28, 29
    '    '        IsPilotOffice = True
    '    '    Case Else
    '    '        IsPilotOffice = False
    '    'End Select
    '    'If Contracts.InstallingOffice <> "" Then
    '    '    Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, ADODB.RecordTypeEnum.adCollectionRecord, OPEN_RECORD, "MOD Office")
    '    '    Where = Contracts.InstallingOffice
    '    '    IndexName = "Office"
    '    '    Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, ADODB.RecordTypeEnum.adCollectionRecord, SEEK_ME, "MOD Office", Where, IndexName)
    '    '    If Not Contracts.InstallingOffice.StartsWith("X") And Not Contracts.InstallingOffice.StartsWith("T") Then
    '    '        Contracts.Area = "" & OfficeRecordset("Area").Value
    '    '    End If
    '    '    If Not Contracts.InstallingOffice.StartsWith("X") And Not Contracts.InstallingOffice.StartsWith("T") Then
    '    '        If Not IsDBNull(OfficeRecordset("Pricing Territory").Value) Then
    '    '            Contracts.PricingTerritory = OfficeRecordset("Pricing Territory").Value
    '    '        End If
    '    '    End If
    '    '    Query_Execute(ADOConnectionOptionDataBase, OfficeRecordset, ADODB.RecordTypeEnum.adCollectionRecord, CLOSE_RECORD)
    '    'End If

    'End Sub

    Private Function GetBudgetC1(ByVal speed As Integer, ByVal machine_model As String, ByVal bank_type As String) As Decimal
        Dim sSQL As String = "SELECT C1_High_Rise, C1_Mid_Rise, C1_Low_Rise, C1_Destination FROM [MOD Office] "
        Dim myList As New List(Of String)()
        Dim budget_c1 As Decimal

        sSQL += "WHERE Office = '" & Me.cboSalesOffice.Text & "'"
        myList = GetDataFromOptions(sSQL, True)

        If myList.Count > 0 Then
            If bank_type = HYDRO_TYPE Then
                budget_c1 = myList(2)
            ElseIf speed >= 500 And machine_model <> MACHINE_FMM200 Then
                budget_c1 = myList(0)
            ElseIf speed < 500 Or machine_model = MACHINE_FMM200 Then
                budget_c1 = myList(1)
            Else    'C1 Destination
                budget_c1 = myList(3)
            End If
        End If

        Return budget_c1
    End Function

    Private Function CalculateDefaultC1() As Decimal
        Dim c1 As Decimal
        Dim myList As New List(Of String)()
        Dim sSQL As String = "SELECT C1_High_Rise FROM [MOD Office] WHERE Office = '" & Me.cboSalesOffice.Text & "'"

        myList = GetDataFromOptions(sSQL)
        If myList.Count > 0 Then
            c1 = myList(0)
            c1 += 0.06
        End If
        Return c1

    End Function
    Private Sub btn_Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Help.Click
        MessageBox.Show(VERSION_STAMP, Application.ProductName)
    End Sub
    Private Function CreateCombinedSheet() As FarPoint.Win.Spread.SheetView
        Dim CombinedSheet As New FarPoint.Win.Spread.SheetView
        Dim iIndex As Integer = 0, jIndex As Integer = 0, kIndex As Integer = 0
        Dim RowCount As Integer = 1, ColumnCount As Integer = 0
        Dim BaseView As FarPoint.Win.Spread.SheetView = Nothing, AltView As FarPoint.Win.Spread.SheetView = Nothing

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.DecimalPlaces = 2
        Try
            For jIndex = 0 To FpSpread1.ActiveSheet.ColumnCount - 1
                If FpSpread1.ActiveSheet.Columns(jIndex).Visible = True Then
                    ColumnCount += 1
                End If
            Next jIndex
            CombinedSheet.ColumnCount = ColumnCount
            For iIndex = 0 To FpSpread1.ActiveSheet.RowCount - 1
                CombinedSheet.RowCount = RowCount
                ColumnCount = 0
                For jIndex = 0 To FpSpread1.ActiveSheet.ColumnCount - 1
                    If FpSpread1.ActiveSheet.Columns(jIndex).Visible = True And FpSpread1.ActiveSheet.Columns(jIndex).Label <> "Include" Then
                        CombinedSheet.Cells(RowCount - 1, ColumnCount).Text = FpSpread1.ActiveSheet.Cells(iIndex, jIndex).Value
                        ColumnCount += 1
                    End If
                Next jIndex
                RowCount += 1
                BaseView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                If Not IsNothing(BaseView) Then
                    For baseRowIndex = 0 To BaseView.RowCount - 1
                        CombinedSheet.RowCount = RowCount
                        ColumnCount = 1
                        For jIndex = 0 To BaseView.ColumnCount - 1
                            If BaseView.Columns(jIndex).Visible = True And BaseView.Columns(jIndex).Label <> "Comments" Then
                                CombinedSheet.Cells(RowCount - 1, ColumnCount).Text = BaseView.Cells(baseRowIndex, jIndex).Value
                                If BaseView.Columns(jIndex).Label = "C1" Then
                                    CombinedSheet.Columns(jIndex).CellType = percentType
                                End If
                                If ColumnCount = 1 Then
                                    ColumnCount += 4
                                Else
                                    ColumnCount += 1
                                End If
                            End If
                        Next jIndex
                        RowCount += 1
                        AltView = BaseView.FindChildView(baseRowIndex, 0)
                        If Not IsNothing(AltView) Then
                            For altRowIndex As Integer = 0 To AltView.RowCount - 1
                                CombinedSheet.RowCount = RowCount
                                ColumnCount = 2
                                For altColumnIndex As Integer = 0 To AltView.ColumnCount - 1
                                    If AltView.Columns(altColumnIndex).Visible = True And AltView.Columns(altColumnIndex).Label <> "Comments" Then
                                        CombinedSheet.Cells(RowCount - 1, ColumnCount).Text = AltView.Cells(altRowIndex, altColumnIndex).Value
                                        ColumnCount += 1
                                    End If
                                Next altColumnIndex
                                RowCount += 1
                            Next altRowIndex
                        End If
                    Next baseRowIndex
                End If
            Next iIndex

            Return CombinedSheet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in CreateCombinedSheet", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception
        End Try
    End Function
    Private Sub SetCombinedSheetHeaders(ByRef combinedSheet As FarPoint.Win.Spread.SheetView)
        combinedSheet.Columns(0).Label = "Group"
        combinedSheet.Columns(1).Label = " "
        combinedSheet.Columns(2).Label = " "
        combinedSheet.Columns(3).Label = " "
        combinedSheet.Columns(4).Label = " "
        combinedSheet.Columns(5).Label = "HQ $"
        combinedSheet.Columns(6).Label = "RL $"
        combinedSheet.Columns(7).Label = "Tax $"
        combinedSheet.Columns(8).Label = "BDP Hrs"
        combinedSheet.Columns(9).Label = "Specl Hrs"
        combinedSheet.Columns(10).Label = "Labor Hrs"
        combinedSheet.Columns(11).Label = "OT Hrs"
        combinedSheet.Columns(12).Label = "Labor $"
        combinedSheet.Columns(13).Label = "SbCnrt $"
        combinedSheet.Columns(14).Label = "Exp $"
        combinedSheet.Columns(15).Label = "Eng $"
        combinedSheet.Columns(16).Label = "P/O/B"
        combinedSheet.Columns(17).Label = "Freight $"
        combinedSheet.Columns(18).Label = "NPS $"
        combinedSheet.Columns(19).Label = "Bank Cost"
        combinedSheet.Columns(20).Label = "C1 %"
        combinedSheet.Columns(21).Label = "Sales Comm"
        combinedSheet.Columns(22).Label = "Sell Price"
        combinedSheet.Columns(23).Label = "Labor Rate"
        combinedSheet.Columns(24).Label = "Prod Code"
        combinedSheet.Columns(25).Label = "Lead Time"
        combinedSheet.ColumnHeader.Rows(0).Height = 30
    End Sub

    Private Function PromptForSave() As DialogResult
        Dim response As DialogResult = MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will negate all changes.", "Please Confirm.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If response = DialogResult.Yes Then
            SaveAll()
        End If
        Return response

    End Function

    Private Sub btnGatewayReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGatewayReview.Click
        Dim sMsg As String
        If Me.txtGatewayStatus.Text = "Under Review" Then
            MessageBox.Show("Engineering is already reviewing this estimate.  It must be Approved or Rejected before an additional review can be requested.", Application.ProductName)
            Exit Sub
        ElseIf Me.txtGatewayStatus.Text = "Approved" Then
            sMsg = "The following estimate has already been approved by Engineering.  Another review is not required unless you have added additional information "
            sMsg += "in the Notes to Engineering screen.  "
            If MessageBox.Show(sMsg, "Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        If AllDocumentsExists() Then
        Else
            sMsg = "You have a bank marked for Gateway Review, but no document exists."
            MessageBox.Show(sMsg, "Missing Gateway Review Document", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        sMsg = "This will create an entry in the MDC Custom Quotes database.  Please verify that you have documented your questions or concerns on specification section(s) on the Notes to Engineer screen. "
        sMsg += Environment.NewLine & Environment.NewLine & "After the database entry is created, the Gateway group will be notified to review your request; they will evaluate your request and the bid proposal to provide engineered solutions to maximize value to Schindler and the customer.  Completion of the review can take up to 5 business days, and may be longer for very large projects."
        sMsg += Environment.NewLine & Environment.NewLine & "Please attach specifications, drawings or any other supporting documents to the database entry once it is created."
        sMsg += Environment.NewLine & Environment.NewLine & "If you have questions or concerns prior to a Gateway engineer being assigned please contact the FQE Operations Manager."
        sMsg += Environment.NewLine & Environment.NewLine & "Do you wish to continue?"
        If MessageBox.Show(sMsg, "MDC Custom Quote", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If isDirty Then
            If MessageBox.Show("Contract information has changed.  To proceed with MDC Review you must save, are you ready to save?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        MDC_Add_Doc()
        Me.txtGatewayStatus.Text = "Under Review"
        SaveAll()
    End Sub

    Public Sub MDC_Add_Doc()
        Dim Filesystem As New Scripting.FileSystemObject()
        Try
            Dim sRequestorNameKey As String = ""
            Dim sRequestorName As String = ""
            Dim sPhone As String = ""
            Dim sPhone_mobile As String = ""
            Dim sFax_requestor As String = ""
            Dim bNewDocument As Boolean = False
            Dim sOffice As String = ""
            Dim sDistrict As String = ""
            Dim sTerritory As String = ""
            Dim sArea As String = ""
            Dim skg As String = ""
            Dim sDueDate As String = ""
            Dim sDescriptionField As String = "description"

            If clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) Then
                If clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") Then
                    sRequestorNameKey = Microsoft.VisualBasic.Strings.Left(gsNotesLinkDataUserName, InStr(1, gsNotesLinkDataUserName, "/") - 1)
                    sRequestorName = clsNotes.CN_Username
                    If clsNotes.NotesDocKey(sRequestorNameKey) Then
                        sPhone = clsNotes.GetValue("Phone")
                        sFax_requestor = clsNotes.GetValue("Phone_1")           ' fax
                        sPhone_mobile = clsNotes.GetValue("Phone_2")            ' cell
                        sOffice = clsNotes.GetValue("officeNum")                ' Office
                        sDistrict = clsNotes.GetValue("districtNum")            ' District
                        sTerritory = clsNotes.GetValue("territory")             ' Territory
                        sArea = clsNotes.GetValue("area")                       ' Area
                        skg = clsNotes.GetValue("kg")                           ' kg
                    End If
                End If
            End If

            SetupMDCLink()

            If Not FindMDCDocument() Then
                clsNotes.CreateDOC("Quote Request")
                bNewDocument = True
            End If

            If bNewDocument Then
                clsNotes.SetValue("status", "New")
                clsNotes.SetValue("engineeringReviewStatus", "New")

                Select Case Format(Now, "dddd")
                    Case "Saturday"
                        clsNotes.SetValue("duedate", DateAdd("d", 6, Now))
                    Case "Sunday"
                        clsNotes.SetValue("duedate", DateAdd("d", 5, Now))
                    Case Else
                        clsNotes.SetValue("duedate", DateAdd("d", 7, Now))
                End Select

                clsNotes.SetValue("createdDate", CDate(Now))
                clsNotes.SetValue("quoteType", "Final Bid")
                clsNotes.SetValue("approvalDrawingsRequired", "")
                clsNotes.SetValue_Readers("creator", gsSalesRep)
            Else
                clsNotes.SetValue("flag_revised", "Yes")
                sDescriptionField = "description_revised"
            End If

            clsNotes.SetValue_Readers("requestor", sRequestorName)
            clsNotes.SetValue("phone_requestor", sPhone)
            clsNotes.SetValue("fax_requestor", sFax_requestor)
            clsNotes.SetValue("phone_mobile_requestor", sPhone_mobile)

            clsNotes.SetValue("office", sOffice)
            clsNotes.SetValue("district", sDistrict)
            clsNotes.SetValue("territory", sTerritory)
            clsNotes.SetValue("area", sArea)
            clsNotes.SetValue("kg", skg)

            clsNotes.SetValue("businessline", "MOD")
            clsNotes.SetValue("unique", HoldUniqueActivity)
            clsNotes.SetValue("proposal_num", HoldUniqueActivity)
            'If CurrentGOData_Typ. <> "0" Then
            '    clsNotes.SetValue("goNum", CurrentGOData_Typ.GONum)
            'End If
            'If Contracts.NegNum <> 0 Then
            '    clsNotes.SetValue("negNum", CStr(Contracts.NegNum))
            'End If
            clsNotes.SetValue("jobName", Contracts.JobName)
            'Select Case CurrentGOData_Typ.Type
            '    Case HYD_NI_PRODUCT_TYPE
            '        clsNotes.SetValue("productType", "330A")
            '    Case TRA_NI_PRODUCT_TYPE
            '        clsNotes.SetValue("productType", ProductApplication)
            '    Case ESC_NI_PRODUCT_TYPE
            '        ' kab not listed in file
            '        clsNotes.SetValue("productType", "9300")
            '    Case HYD_POH_PRODUCT_TYPE
            '        clsNotes.SetValue("productType", "POH")
            '    Case Else
            'End Select

            clsNotes.SetValue("hydroCars", CountCars(HYDRO_TYPE))
            clsNotes.SetValue("gearedCars", CountCars(GEARED_TYPE))
            clsNotes.SetValue("gearlessCars", CountCars(GEARLESS_TYPE))

            clsNotes.SetValue_Readers("salesRep", gsSalesRep)

            Dim Reader As String() = {"[Admin]", "[Approver]", "[Engineer]", "[Full Access]", "T_SEC_" & sOffice,
                                      "T_SEC_SMART_" & sOffice, "T_SEC_SMART_" & sDistrict, "T_SEC_SMART_" & sTerritory,
                                      "T_SEC_SMART_" & sArea}

            clsNotes.SetValue_Readers("Reader", Reader)
            clsNotes.SetValue("bank", CurrentGOData_Typ.Type & CurrentGOData_Typ.Bank & CurrentGOData_Typ.Alt & CurrentGOData_Typ.Units)

            clsNotes.DocSave()
        Catch
        End Try
    End Sub

    Public Function SetupMDCLink() As Boolean
        Dim DataBaseError As String = ""
        Dim MDC As String = ""
        Dim ComServerMDC As String = ""

        Try
            If TestVersion Then
                ComServerMDC = "USSECNE1"
                MDC = "sec\develop\Larry\MDC Custom Quotes_dev.nsf"
            Else
                ComServerMDC = "USSECNN4"
                MDC = "sec\engpro\MDCCustomQuotes.nsf"
            End If

            If Not clsNotes.NotesDBName(ComServerMDC, MDC) Then
                DataBaseError = DataBaseError & "Missing - MDC Custom Quotes_dev.nsf"
                Throw New Exception()
            End If

            If Not clsNotes.NotesDBView("(LU Unique)") Then
                MessageBox.Show("Could not find (LU opportunity id View", Application.ProductName)
                EndProgram()
            End If
        Catch
            MessageBox.Show("Error in Lotus Link, missing or corrupt local Notes CRM database." & Environment.NewLine & "Closing Cadre!", "Error")
            EndProgram()
        End Try

        Return clsNotes.NotesDocKey(Contracts.ProposalNum)

    End Function

    Function FindMDCDocument() As Boolean
        Dim result As Boolean = False

        Try
            ' Dim Bank, Alt, CarNo
            Dim b As Boolean

            If clsNotes.NotesDocKeyCollection(Contracts.ProposalNum) Then
                b = True
                Do While b
                    If OpportunityID = clsNotes.GetValue("proposal_num") Then
                        If clsNotes.GetValue("bank").ToString.Substring(0, 3) = CurrentGOData_Typ.Type Then
                            If clsNotes.GetValue("bank").ToString.Substring(3, 1) = CurrentGOData_Typ.Bank Then
                                If clsNotes.GetValue("bank").ToString.Substring(4, 1) = CurrentGOData_Typ.Alt Then
                                    If clsNotes.GetValue("bank").ToString.Substring(5) = CurrentGOData_Typ.Units Then
                                        Return True
                                    End If
                                End If
                            End If
                        End If
                    End If
                    b = clsNotes.GetNextDocumentFromCollection()
                Loop
            End If

            Return result

        Catch
            MessageBox.Show(Conversion.ErrorToString(), "FindDocumentBySixFields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return result
        End Try

    End Function

    Private Function AllDocumentsExists() As Boolean
        Dim filename As String
        For Each row In dtSummaryGroup.Rows
            If Not IsDBNull(row.item("gateway_review_required")) AndAlso row.item("gateway_review_required") Then
                filename = EstimatePath & Contracts.EstimateNum & CurrentGOData_Typ.Bank & "MODEST.json"
                If File.Exists(filename) = False Then
                    Return False
                End If
            Else
                If IsDBNull(row.item("gateway_review_required")) Then   'TODO:  put into deserialize once that proc revised for each datatable  AA
                    row.item("gateway_review_required") = False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub CreateNewDocument()
        Throw New NotImplementedException
    End Sub

    Private Function GetConsultantsName() As String
        Dim consultants_name As String = ""
        Dim _foundRows() As DataRow
        _foundRows = dtContactGroup.Select("contactType = 'consultant'")
        If _foundRows.Length > 0 Then
            consultants_name = _foundRows(0).Item("companyName")
        End If
        Return consultants_name
    End Function

    Private Function CountCars(ByVal bank_type As String) As Integer
        Dim number_of_cars As Integer = 0

        For Each row As DataRow In dtSummaryGroup.Rows
            If row.Item("gateway_review_required") Then
                If bank_type = (row.Item("Bank_Type")) Then
                    number_of_cars += CalculateNumberOfCarsInEstimate(row.Item("Units"))
                End If
            End If
        Next

        Return number_of_cars
    End Function

    Private Sub Populate_FieldSup()
        ' Private Sub Populate_FieldSup(ByRef ComboCntl As ComboBox, ByRef FilterNames As Boolean, ByRef AddZZZOther As Boolean)   
        ' Leaving in should user want to filter.  See Mod 1.0 for filtering
        Dim FieldSup_Field As String = ""
        Dim tempstore As String = ""

        If Me.cboSupt.Text <> "" Then
            tempstore = Me.cboSupt.Text
        End If

        Me.cboSupt.Items.Clear()
        If Not (Not clsNotes.NotesDBName(ComServer, HoldNotesFeedbackPath) OrElse Not clsNotes.NotesDocProfile("Names")) Then
            FieldSup_Field = IIf(All_LocalCodeDep.CanadaJob, "FieldSupervisorNames_TOR", "FieldSupervisorNames_SEC")
            If Not clsNotes.GetValue_Readers(FieldSup_Field) Then
                FieldSup_Field = "FieldSupervisorNames"
            End If
            clsNotes.GetArray(FieldSup_Field, Me.cboSupt)
            'If FilterNames Then
            '    FilterNamesByRegion(MComboCntl)
            'End If
        End If

        'If AddZZZOther Then
        '    [ComboCntl].Items.Add("ZZZ Other")
        'End If

        AssignListIndex(Me.cboSupt, tempstore)

    End Sub

    Private Sub btnSuptReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuptReview.Click

        Dim sSuptReview As String
        Dim sSuptStatus As String = ""
        Dim sSUPTFileName As String = ""
        Dim sMessage As String = ""

        sSuptReview = Get_SuptStatus("Decision")
        If sSuptStatus <> "" Then
            If sSuptStatus = "Rejected" Then
                sSuptReview = "Required"
            Else
                sSuptReview = sSuptStatus
            End If
        End If

        If sSuptReview = "Under Review" Then
            MessageBox.Show("Estimate is Under Supt Review - Cannot resend for Approval", "Supt Review Status ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Select Case sSuptReview
            Case "Approved"
                sMessage = "Estimate has already been " & sSuptReview & ". There is no need for further review.  "
                If MessageBox.Show(sMessage, "Superintendent Review", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            Case "Not Required"
                sMessage = "The estimate does not require Supt Review; do you still wish to submit? "
                If MessageBox.Show(sMessage, "Superintendent Review", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
        End Select

        If Me.cboSupt.Text = "ZZZ Other" Or Me.cboSupt.Text = "" Then
            MessageBox.Show("The Superintendent Name is required.", "Supt Review", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        If NoBanksIncluded() Then
            sMessage = "No Summary Items have been 'Included'.  Please check 'Included' for the bank(s) to process the Superintendent Review.  " & vbCrLf & vbCrLf & "Supt. Review Processing Terminated."
            MessageBox.Show(sMessage, "No Banks Included", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sMessage = "Please note that when Supt Approval is requested, you will not be able to make any further changes to the estimate."
        Cursor.Current = Cursors.Default
        If MessageBox.Show(sMessage, "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If isDirty Then
            sMessage = "Contract information has changed.  To proceed with the Superintendent Review, you must save.  Are you ready to save?"
            If MessageBox.Show(sMessage, "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Superintendent Review Process Terminated by User", "Processing Terminated", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

        SaveAll()

        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row("Include")) AndAlso row("Include") Then

                sSUPTFileName = OutputSuptFile(row("bank"), row("units"))

                'SUPT_Add_Doc(sSUPTFileName)
            End If
        Next


        MessageBox.Show("Supt Approval submitted", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Exit Sub

    End Sub

    Public Sub SUPT_Add_Doc(ByVal sSUPTFileName As String)

        'Dim sRequestorNameKey As String = ""
        'Dim sRequestorName As String = ""
        'Dim sFieldSuperintendentName As String = ""
        'Dim sPhone As String = ""
        'Dim sPhone_mobile As String = ""
        'Dim sFax_requestor As String = ""
        'Dim bNewDocument As Boolean = False
        'Dim sOffice As String = ""
        'Dim sDistrict As String = ""
        'Dim sTerritory As String = ""
        'Dim sArea As String = ""
        'Dim skg As String = ""
        'Dim sDueDate As String = ""
        'Dim Name As String = ""
        'Dim PowerUnitType As String = String.Empty
        'Dim MachineType As String = String.Empty
        'Dim Diameters As String = String.Empty
        'Dim MeasuredPressure As String = String.Empty
        'Dim MeasuredPressureType As String = String.Empty
        'Dim Filesystem As New Scripting.FileSystemObject()
        'Dim thisFolder As Scripting.Folder = Nothing
        'Dim theseFiles As Scripting.Files

        'Try
        '    If clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) Then
        '        If clsNotes.NotesDBView("(>LU Offices \ By Office Number No Sat)") Then
        '            sOffice = Contracts.SalesOffice
        '            If clsNotes.NotesDocKey(sOffice) Then
        '                sPhone = clsNotes.GetValue("Phone")
        '                sFax_requestor = clsNotes.GetValue("Fax")
        '                sPhone_mobile = clsNotes.GetValue("Phone_2")
        '                sDistrict = clsNotes.GetValue("DistrictNum")
        '                sTerritory = clsNotes.GetValue("Territory")
        '                sArea = clsNotes.GetValue("area")
        '                skg = clsNotes.GetValue("KG")
        '            End If
        '        End If
        '    End If

        '    If clsNotes.NotesDBName(ComServer, HoldNotesPhonebookPath) Then
        '        If clsNotes.NotesDBView("(>LU Employees \ By Notes Name)") Then
        '            sRequestorNameKey = Left$(gsNotesLinkDataUserName, InStr(1, gsNotesLinkDataUserName, "/") - 1)
        '            sRequestorName = clsNotes.CN_Username
        '        End If
        '    End If

        '    sFieldSuperintendentName = Screen_BOOK.SuperintendentName
        '    sFieldSuperintendentName = clsNotes.GetNotesCanonicalName(sFieldSuperintendentName)
        '    SetupSuptReviewLink()
        '    If Not clsNotes.FindSUPTDocument() Then
        '        clsNotes.CreateDOC("Booking Approval Review MOD")
        '        bNewDocument = True
        '    End If

        '    If bNewDocument Then
        '        '  Splash.Splash_lbl.Text = "Creating Superintendent Form for Approval"
        '        clsNotes.SetValue("reviewKey", Contracts.ProposalNum)
        '        clsNotes.SetValue("createdDate", CDate(Now))
        '        clsNotes.SetValue_Readers("creator", sRequestorName)
        '        clsNotes.SetValue("Status", "New")
        '    Else
        '        ' Splash.Splash_lbl.Text = "Updating Superintendent Form for Approval"
        '        clsNotes.SetValue("Status", "Resubmitted")
        '    End If

        '    clsNotes.SetValue_Readers("Estimator", sRequestorName)
        '    clsNotes.SetValue_Readers("SalesRep", gsSalesRep)
        '    clsNotes.SetValue_Readers("Superintendent", sFieldSuperintendentName)
        '    clsNotes.SetValue("office", sOffice)
        '    clsNotes.SetValue("district", sDistrict)
        '    clsNotes.SetValue("territory", sTerritory)
        '    clsNotes.SetValue("area", sArea)
        '    clsNotes.SetValue("kg", skg)
        '    clsNotes.SetValue("proposal_num", Contracts.ProposalNum)
        '    clsNotes.SetValue("jobName", Contracts.JobName)
        '    ' clsNotes.SetValue("units_bank", UnitsInBankFormat)
        '    clsNotes.SetValue("units_estimate", UnitsInEstimate)
        '    clsNotes.SetValue("product_line", GONumbers(CurrentGOSelection).Type)
        '    clsNotes.SetValue("product_code", GONumbers(CurrentGOSelection).ProductCode)
        '    clsNotes.SetValue("capacity", GONumbers(CurrentGOSelection).Capacity)
        '    clsNotes.SetValue("speed", GONumbers(CurrentGOSelection).Speed)
        '    clsNotes.SetValue("travel_rise", GONumbers(CurrentGOSelection).TravelFt + RoundToNextHigherOrEqualInteger(GONumbers(CurrentGOSelection).TravelIn / 12))
        '    clsNotes.SetValue("landings", GONumbers(CurrentGOSelection).TotalStops)
        '    clsNotes.SetValue("openings_front", GONumbers(CurrentGOSelection).FrontOpenings)
        '    clsNotes.SetValue("openings_rear", GONumbers(CurrentGOSelection).RearOpenings)
        '    clsNotes.SetValue("date_delivery", CDate(ME_ADM01Bnk_typ.DeliveryDate))
        '    clsNotes.SetValue("date_completion", CDate(ME_ADM01Bnk_typ.BankCompleteDate))
        '    clsNotes.SetValue("hours_standard", Val(Strings.Format(MOD_Cost_typ.BDP_Hrs, HOUR_MASK)))
        '    clsNotes.SetValue("hours_labor", Val(Strings.Format(MOD_Cost_typ.BDP_Hrs + MOD_Cost_typ.NonBDP_Hrs, HOUR_MASK)))
        '    clsNotes.SetValue("hours_special", Val(Strings.Format(MOD_Cost_typ.NonBDP_Hrs, HOUR_MASK)))
        '    clsNotes.SetValue("hours_overtime", Val(Strings.Format(MOD_Cost_typ.Overtime_Hrs, HOUR_MASK)))
        '    clsNotes.SetValue("unionLocalNumber", ME_ADM01Bnk_typ.UnionLocal)
        '    clsNotes.SetValue("seismicZone", ME_ADM01Bnk_typ.SeismicZone.ToString)
        '    clsNotes.SetValue("localCode", ME_ADM01Bnk_typ.LocalCode)
        '    clsNotes.SetValue("cost_foremanBonus", IIf(ME_ADM02Bnk_typ.ForemansBonus = CheckState.Checked, "Yes", "No"))
        '    clsNotes.SetValue("cost_regionLocal", MOD_Cost_typ.RLMaterial_Cost)
        '    clsNotes.SetValue("cost_expenses", MOD_Cost_typ.Expenses_Cost)
        '    clsNotes.SetValue("cost_subcontractor", MOD_Cost_typ.OtherSubcontract_Cost)
        '    clsNotes.SetValue("cost_permits", MOD_Cost_typ.Permits_Cost)
        '    clsNotes.SetValue("cost_bonds", MOD_Cost_typ.Bonds_Cost)
        '    clsNotes.SetValue("cost_projectManager", MOD_Cost_typ.ProjectManager_Cost)
        '    clsNotes.SetValue("ansiCode", ME_ADM01Bnk_typ.ANSICode)
        '    clsNotes.SetValue("blendedLaborRate", Math.Round(RATES.FieldLabor_Rate, 2))
        '    clsNotes.SetValue("businessLine", "MOD")
        '    clsNotes.SetValue("Form", "Booking Approval Review MOD")
        '    If GONumbers(CurrentGOSelection).MachineType = HYDRO_TYPE Then
        '        PowerUnitType = ME_HYDMRM01Car_typ.PowerUnit
        '        If Not String.IsNullOrEmpty(ME_HYDHSTPITCar_typ.ExistingPistonDiameterFirstStage) Then
        '            Diameters = ME_HYDHSTPITCar_typ.ExistingPistonDiameterFirstStage
        '        End If
        '        If Not String.IsNullOrEmpty(ME_HYDHSTPITCar_typ.ExistingPistonDiameterSecondStage) Then
        '            If String.IsNullOrEmpty(Diameters.Trim) Then
        '                Diameters = ME_HYDHSTPITCar_typ.ExistingPistonDiameterSecondStage
        '            Else
        '                Diameters = Diameters & Environment.NewLine & ME_HYDHSTPITCar_typ.ExistingPistonDiameterSecondStage
        '            End If
        '        End If
        '        If Not String.IsNullOrEmpty(ME_HYDHSTPITCar_typ.ExistingPistonDiameterThirdStage) Then
        '            If String.IsNullOrEmpty(Diameters.Trim) Then
        '                Diameters = ME_HYDHSTPITCar_typ.ExistingPistonDiameterThirdStage
        '            Else
        '                Diameters = Diameters & Environment.NewLine & ME_HYDHSTPITCar_typ.ExistingPistonDiameterThirdStage
        '            End If
        '        End If
        '        If ME_HYDHSTPITCar_typ.MeasuredPressure > 0 Then
        '            MeasuredPressure = ME_HYDHSTPITCar_typ.MeasuredPressure.ToString
        '        End If
        '        If Not String.IsNullOrEmpty(ME_HYDHSTPITCar_typ.MeasuredPressureType) Then
        '            MeasuredPressureType = ME_HYDHSTPITCar_typ.MeasuredPressureType
        '        End If
        '    Else
        '        MachineType = ME_MRM01Car_typ.Machine
        '    End If
        '    clsNotes.SetValue("powerUnitType", PowerUnitType)
        '    clsNotes.SetValue("machine_type", MachineType)
        '    clsNotes.SetValue("existingPistonsDiameters", Diameters)
        '    clsNotes.SetValue("measuredPressure", MeasuredPressure)
        '    clsNotes.SetValue("measurePressureType", MeasuredPressureType)
        '    clsNotes.SetValue("power", ME_COM01Car_typ.PowerSupply)
        '    clsNotes.SetValue("reason", SuptReviewMsg)
        '    clsNotes.SetValue("bank", GONumbers(CurrentGOSelection).Bank & " / " & GONumbers(CurrentGOSelection).Alt)
        '    bNewDocument = clsNotes.AttachSUPTFile(sSUPTFileName)
        '    If clsNotes.CADREFilePath(ReportsPath) Then
        '        If GONumbers(CurrentGOSelection).MachineType = HYDRO_TYPE Then
        '            Execute_Word_Report(REPORT_HXPressFieldData, True, True)
        '        Else
        '            Execute_Word_Report(REPORT_QUANTUMLEAP_FIELDSURVEY_DATAFORM, True, True)
        '        End If
        '        Execute_Excel_Report(REPORT_BDP_PERCENTCOMPLETE, True)
        '        thisFolder = MemoryHelper.ReleaseAndCleanObject(Of Scripting.Folder)(thisFolder, Filesystem.GetFolder(ReportsPath))
        '        theseFiles = thisFolder.Files
        '        For Each thisFile As Scripting.File In theseFiles
        '            Name = thisFile.Name.ToUpper()
        '            If (Name Like Contracts.EstimateNum.ToString() & GONumbers(CurrentGOSelection).Bank & GONumbers(CurrentGOSelection).Alt & REPORT_HXPressFieldData.ToUpper & "*") Or
        '               (Name Like Contracts.EstimateNum.ToString() & GONumbers(CurrentGOSelection).Bank & GONumbers(CurrentGOSelection).Alt & REPORT_QUANTUMLEAP_FIELDSURVEY_DATAFORM.ToUpper & "*") Or
        '               (Name Like Contracts.EstimateNum.ToString() & GONumbers(CurrentGOSelection).Bank & GONumbers(CurrentGOSelection).Alt & GONumbers(CurrentGOSelection).Units & REPORT_BDP_PERCENTCOMPLETE.ToUpper & "*") Then
        '                bNewDocument = clsNotes.AttachSUPTFile(ReportsPath & Name)
        '                thisFile.Delete(True)
        '            End If
        '        Next thisFile
        '    End If
        '    Dim Reader(0 To 8) As String
        '    Reader(0) = "[Admin]"
        '    Reader(1) = "[Approver]"
        '    Reader(2) = "[Engineer]"
        '    Reader(3) = "[Full Access]"
        '    Reader(4) = "T_SEC_" & sOffice
        '    Reader(5) = "T_SEC_SMART_" & sOffice
        '    Reader(6) = "T_SEC_SMART_" & sDistrict
        '    Reader(7) = "T_SEC_SMART_" & sTerritory
        '    Reader(8) = "T_SEC_SMART_" & sArea
        '    clsNotes.SetValue_Readers("Reader", Reader)
        '    clsNotes.DocSave()

        'Catch
        '    MessageBox.Show(Err.Description, "Error in creating Supt Approval Doc", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub

    Private Function NoBanksIncluded() As Boolean
        'Scroll through the dataset to determine if any summary items are included (include = true)
        ' Returns true if no banks marked as included.

        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row("Include")) AndAlso row("Include") Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub DeleteLaborAndOT(ByVal selected_bank As String)

        Try
            dtLaborRates.Columns.Remove("labor_ratio_" & selected_bank)
            dtOverTime.Columns.Remove("work_days_" & selected_bank)
            dtOverTime.Columns.Remove("work_hours_" & selected_bank)
            dtOverTime.Columns.Remove("#_teams_" & selected_bank)
            dtOverTime.Columns.Remove("ot%_" & selected_bank)
            dtOverTime.Columns.Remove("ot_labor_inefficiency_" & selected_bank)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Deleting Labor and OT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class
