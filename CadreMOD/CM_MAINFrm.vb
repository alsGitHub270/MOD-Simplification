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


Partial Friend Class CM_MAIN_frm
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)

    Dim dsTemp As DataSet
    Dim isDirty As Boolean = False
    Dim addingNewRow As Boolean = False
    Dim initializing As Boolean
    Dim id_to_copy As String = ""


    Private CurrentBuildingInformationFrameHeight As Integer = 0, CurrentEquipmentFrameHeight As Integer = 0


    Const _BANK_COLUMN As Integer = 3

    Private UseCurRow As Integer = 0, UseCurCol As Integer = 0, CurSummaryRow As Integer = 0

    Private Sub CreateDataSet()


        dsCadre = New DataSet()
        dsCadre.EnforceConstraints = False

        dtSummaryGroup = dsCadre.Tables.Add("SummaryGroup")
        dtSummaryGroup.Columns.AddRange(New DataColumn() {New DataColumn("SummaryGroup", typeStr), _
                                                          New DataColumn("id", typeStr), _
                                                          New DataColumn("_", typeStr), _
                                                          New DataColumn("Bank", typeStr), _
                                                          New DataColumn("Bank_Type", typeStr), _
                                                          New DataColumn("Units", typeStr), _
                                                          New DataColumn("Material_HQ", typeInt), _
                                                          New DataColumn("Material_RL", typeInt), _
                                                          New DataColumn("Tax", typeInt), _
                                                          New DataColumn("BDP_Hours", typeInt), _
                                                          New DataColumn("Special_Hours", typeInt), _
                                                          New DataColumn("Labor_Hours", typeInt), _
                                                          New DataColumn("OT_Hours_Included", typeInt), _
                                                          New DataColumn("Labor_cost", typeInt), _
                                                          New DataColumn("SubContract_Work", typeInt), _
                                                          New DataColumn("misc_costs", typeInt), _
                                                          New DataColumn("expenses", typeInt), _
                                                          New DataColumn("freight", typeInt), _
                                                          New DataColumn("NPS_Cost", typeInt), _
                                                          New DataColumn("Total_Bank_Cost", typeInt), _
                                                          New DataColumn("C1", typeSingle), _
                                                          New DataColumn("bank_net_Price", typeInt), _
                                                          New DataColumn("sales_commission", typeInt), _
                                                          New DataColumn("bank_final_price", typeInt), _
                                                          New DataColumn("Labor_Rate", typeInt), _
                                                          New DataColumn("Include", typeBool)
                                                         })

        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "A1", "", "A", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "B1", "", "B", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "F1", "", "F", "Gearless", "01,03,04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})


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
                                                       New DataColumn("Labor_cost", typeInt), _
                                                       New DataColumn("SubContract_Work", typeInt), _
                                                       New DataColumn("Misc_Costs", typeInt), _
                                                       New DataColumn("expenses", typeInt), _
                                                       New DataColumn("Freight", typeInt), _
                                                       New DataColumn("NPS_Cost", typeInt), _
                                                       New DataColumn("Total_Bank_Cost", typeInt), _
                                                       New DataColumn("C1", typeSingle), _
                                                       New DataColumn("bank_net_Price", typeInt), _
                                                       New DataColumn("sales_commission", typeInt), _
                                                       New DataColumn("bank_final_price", typeInt), _
                                                       New DataColumn("Labor_Rate", typeInt), _
                                                       New DataColumn("Comment", typeStr)
                                                        })


        'dtBaseGroup.Rows.Add(New Object() {"Master", "A0", "A", "01-04", "Geared", 497250, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "A1", "A", "01-04", "Geared", 500000, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "B1", "B", "01-04", "Geared", 375000, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "F1", "F", "01,03-04", "Gearless", 0, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})

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
                                                      New DataColumn("Labor_cost", typeInt), _
                                                      New DataColumn("SubContract_Work", typeInt), _
                                                      New DataColumn("Misc_Costs", typeInt), _
                                                      New DataColumn("expenses", typeInt), _
                                                      New DataColumn("freight", typeInt), _
                                                      New DataColumn("NPS_Cost", typeInt), _
                                                      New DataColumn("Total_Bank_Cost", typeInt), _
                                                      New DataColumn("C1", typeSingle), _
                                                      New DataColumn("bank_net_price", typeInt), _
                                                      New DataColumn("sales_commission", typeInt), _
                                                      New DataColumn("bank_final_price", typeInt), _
                                                      New DataColumn("Labor_Rate", typeInt), _
                                                      New DataColumn("Comment", typeStr)
                                                     })


        'dtAltGroup.Rows.Add(New Object() {"Alt1", "A1", "01-04", "Geared", 25000, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry."})
        'dtAltGroup.Rows.Add(New Object() {"Alt2", "A1", "01-04", "Geared", -5000, -4000, "", True, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Lorem ipsam voluptatem quia volupta. "})
        'dtAltGroup.Rows.Add(New Object() {"Alt3", "A1", "01-04", "Geared", -2500, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Lorem ipsum dolor delectus error voluptatem neque."})
        'dtAltGroup.Rows.Add(New Object() {"Alt4", "A1", "01-04", "Geared", 1250, "", "", True, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit."})
        'dtAltGroup.Rows.Add(New Object() {"Alt1", "B1", "01-04", "Geared", 5000, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit."})
        'dtAltGroup.Rows.Add(New Object() {"Alt2", "B1", "01-04", "Geared", -2000, "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})

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
                                                          New DataColumn("major_project", typeBool), _
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

        ' dtBuildingInfo.Rows.Add(New Object() {"HOT - Hotel/Motel/Inn/Dorm/Casino", "ZZZ Other", "6122", "6122", "6122", "", "", "8/1/2017", "No", "Tax Exempt", "1", "", "", "", "", "", "", "", ""})


        Deserialize("C:\Temp\cadre.json", dsCadre, "Error Reading Input Json file", isDirty)            'Contracts.EstimateNum & ".json"
        '  Deserialize(Contracts.EstimateNum & ".json", dsCadre, "Error Reading Input Json file", isDirty)
        FpSpread1.ActiveSheet.SortRows(3, True, False)

        ' If there are no records after deserialization, then add a blank summary and base row, initializing the bank to 'A'
        If dtSummaryGroup.Rows.Count = 0 Then
            AddBankRow()
        End If

        If dtContactGroup.Rows.Count = 0 And Owner_Info.Name.Length > 0 Then
            UpdateContactGroupFromNotes()
        End If

        'Add the relations
        dsCadre.Relations.Add("Summary_Base_Relationship", dsCadre.Tables("SummaryGroup").Columns("id"), dsCadre.Tables("BaseGroup").Columns("id"))
        dsCadre.Relations.Add("Base_Alt_Relationship", dsCadre.Tables("BaseGroup").Columns("alt_id"), dsCadre.Tables("AltGroup").Columns("id"))

    End Sub


    Private Sub btnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex
        CurrentGOData_Typ.Units = FpSpread1.ActiveSheet.Cells(CurRow, 2).Text
        CurrentGOData_Typ.Bank = FpSpread1.ActiveSheet.Cells(CurRow, 3).Text
        MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case EstimateLevel
            Case "Summary"
            Case "Master", "Base"
                frmEstimatingBase.Show()
                Me.Hide()
            Case "Alt"
                frmEstimatingBase.Show()
                Me.Hide()
            Case Else
        End Select
    End Sub

    Private Sub CM_MAIN_frm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isDirty Then
            Dim response As DialogResult = MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will negate all changes.", "Please Confirm.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If response = DialogResult.Yes Then
                SaveAll()
            ElseIf response = DialogResult.Cancel Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        EndProgram()
    End Sub

    Private Sub CM_MAIN_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        Load_ListBoxes()



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
        percentType.DecimalPlaces = 1

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

        ' FpSpread1.Sheets(0).Rows(1).Locked = True
        'FpSpread1.Sheets(0).Rows(1).BackColor = Color.LightGray
        ' FpSpread1.Sheets(0).Rows(2).Locked = True
        'FpSpread1.Sheets(0).Rows(2).BackColor = Color.LightGray
        'FpSpread1.Sheets(0).SetRowExpandable(i, False)

        Dim cbstr_Machine As String()
        cbstr_Machine = New String() {"Geared", "Gearless", "Hydro"}
        Dim cmbocell_Machine As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell_Machine.Items = cbstr_Machine
        cmbocell_Machine.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell_Machine.Editable = False
        cmbocell_Machine.MaxDrop = 3

        'Dim cmbocell_Bank As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        'Dim cbstr_Bank() As String

        'cmbocell_Bank.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        'cmbocell_Bank.Editable = False
        'cmbocell_Bank.MaxDrop = 3

        For i As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1

            Dim cmbocell_Bank As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
            Dim cbstr_Bank() As String
            cmbocell_Bank.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
            cmbocell_Bank.Editable = False
            cmbocell_Bank.MaxDrop = 3

            cbstr_Bank = BuildBanks(FpSpread1.ActiveSheet.GetValue(i, 3))
            cmbocell_Bank.Items = cbstr_Bank

            FpSpread1.ActiveSheet.Rows(i).Locked = True
            FpSpread1.ActiveSheet.Cells(i, 3).Locked = False
            FpSpread1.ActiveSheet.Cells(i, 4).Locked = False
            FpSpread1.ActiveSheet.Cells(i, 5).Locked = False
            FpSpread1.ActiveSheet.Cells(i, 20).Locked = False
            FpSpread1.ActiveSheet.Cells(i, 25).Locked = False

            FpSpread1.ActiveSheet.Cells(i, 0).Column.Width = 75        'summary
            FpSpread1.ActiveSheet.Cells(i, 2).Column.Width = 20         'STATUS
            FpSpread1.ActiveSheet.Cells(i, 3).Column.Width = 35         'bank
            FpSpread1.ActiveSheet.Cells(i, 4).Column.Width = 75         'bank_type
            FpSpread1.ActiveSheet.Cells(i, 5).Column.Width = 60         'units
            FpSpread1.ActiveSheet.Cells(i, 6).Column.Width = 65         'material_HQ
            FpSpread1.ActiveSheet.Cells(i, 7).Column.Width = 63         'material_RL
            FpSpread1.ActiveSheet.Cells(i, 8).Column.Width = 60         'sales tax
            FpSpread1.ActiveSheet.Cells(i, 9).Column.Width = 60         'total BDP Hours
            FpSpread1.ActiveSheet.Cells(i, 10).Column.Width = 60        'total special hours
            FpSpread1.ActiveSheet.Cells(i, 11).Column.Width = 60        'total labor hours
            FpSpread1.ActiveSheet.Cells(i, 12).Column.Width = 60        'Overtime hours included
            FpSpread1.ActiveSheet.Cells(i, 13).Column.Width = 60        'labor $
            FpSpread1.ActiveSheet.Cells(i, 14).Column.Width = 70        'Subcontract work
            FpSpread1.ActiveSheet.Cells(i, 15).Column.Width = 60        'expenses
            FpSpread1.ActiveSheet.Cells(i, 16).Column.Width = 60        'misc costs
            FpSpread1.ActiveSheet.Cells(i, 17).Column.Width = 60        'freight
            FpSpread1.ActiveSheet.Cells(i, 18).Column.Width = 65        'NPS Cost
            FpSpread1.ActiveSheet.Cells(i, 19).Column.Width = 70        'total bank cost
            FpSpread1.ActiveSheet.Cells(i, 20).Column.Width = 50        'project c1
            FpSpread1.ActiveSheet.Cells(i, 21).Column.Width = 70        'bank net price
            FpSpread1.ActiveSheet.Cells(i, 22).Column.Width = 60        'sales commission
            FpSpread1.ActiveSheet.Cells(i, 23).Column.Width = 70        'bank final price
            FpSpread1.ActiveSheet.Cells(i, 24).Column.Width = 60        'Labor rate
            FpSpread1.ActiveSheet.Cells(i, 25).Column.Width = 45      'Include indicator

            FpSpread1.ActiveSheet.Cells(i, 3).CellType = cmbocell_Bank      ' bank
            FpSpread1.ActiveSheet.Cells(i, 4).CellType = cmbocell_Machine   ' machine/bank type

            FpSpread1.ActiveSheet.Cells(i, 6).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 7).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 8).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 13).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 14).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 15).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 16).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 17).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 18).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 19).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 21).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 22).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 23).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 24).CellType = currencyType

            FpSpread1.ActiveSheet.Cells(i, 9).CellType = numberType
            FpSpread1.ActiveSheet.Cells(i, 10).CellType = numberType
            FpSpread1.ActiveSheet.Cells(i, 11).CellType = numberType
            FpSpread1.ActiveSheet.Cells(i, 12).CellType = numberType

            percentType.ReadOnly = True
            FpSpread1.ActiveSheet.Cells(i, 20).CellType = percentType

            FpSpread1.ActiveSheet.Cells(i, 25).CellType = ckbxcell
            FpSpread1.ActiveSheet.Cells(i, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center

            FpSpread1.ActiveSheet.Columns(1).Visible = False
            FpSpread1.ActiveSheet.Columns(21).Visible = False
            FpSpread1.ActiveSheet.ColumnHeader.Rows(0).Height = 30

            ' Column Headers

            FpSpread1.Sheets(0).ColumnHeader.Columns(0).Label = "Group"
            FpSpread1.Sheets(0).ColumnHeader.Columns(6).Label = "Material HQ"
            FpSpread1.Sheets(0).ColumnHeader.Columns(7).Label = "Material RL"
            FpSpread1.Sheets(0).ColumnHeader.Columns(8).Label = "Sales Tax"
            FpSpread1.Sheets(0).ColumnHeader.Columns(9).Label = "BDP Hours"
            FpSpread1.Sheets(0).ColumnHeader.Columns(10).Label = "Special Hours"
            FpSpread1.Sheets(0).ColumnHeader.Columns(11).Label = "Labor Hours"
            FpSpread1.Sheets(0).ColumnHeader.Columns(12).Label = "OT Hrs Included"
            FpSpread1.Sheets(0).ColumnHeader.Columns(13).Label = "Labor"
            FpSpread1.Sheets(0).ColumnHeader.Columns(14).Label = "Subcontact Work"
            FpSpread1.Sheets(0).ColumnHeader.Columns(15).Label = "Expenses"
            FpSpread1.Sheets(0).ColumnHeader.Columns(16).Label = "P/O/B"
            FpSpread1.Sheets(0).ColumnHeader.Columns(17).Label = "Freight"
            FpSpread1.Sheets(0).ColumnHeader.Columns(18).Label = "NPS Cost"
            FpSpread1.Sheets(0).ColumnHeader.Columns(19).Label = "Total Bank Cost"
            FpSpread1.Sheets(0).ColumnHeader.Columns(20).Label = "C1"
            FpSpread1.Sheets(0).ColumnHeader.Columns(21).Label = "Bank Net Price"
            FpSpread1.Sheets(0).ColumnHeader.Columns(22).Label = "Sales Com"
            FpSpread1.Sheets(0).ColumnHeader.Columns(23).Label = "Sell Price"
            FpSpread1.Sheets(0).ColumnHeader.Columns(24).Label = "Labor Rate"
            FpSpread1.Sheets(0).ColumnHeader.Columns(25).Label = "Include"

        Next

        SetTitleInfo()        ' below code to the "next" now incorporated in SetTitleInfo

        'ExpandCollapseAll("Expand")
        'ExpandCollapseAll("Collapse")
        'FpSpread1.Visible = True
        'FpSpread1.ActiveSheet.TitleInfo.Value = "Summary"
        'Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        'For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
        '    ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
        '    If Not ChildSheetView1 Is Nothing Then
        '        ChildSheetView1.TitleInfo.Value = "Child" & FpSpread1.ActiveSheet.Cells(iIndex, 3).Text
        '        If ChildSheetView1.RowCount = 0 Then
        '            ChildSheetView1.SetRowExpandable(iIndex, False)
        '        End If
        '        For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
        '            ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
        '            If Not ChildSheetView2 Is Nothing Then
        '                ChildSheetView2.TitleInfo.Value = "Grandchild" & FpSpread1.ActiveSheet.Cells(iIndex, 3).Text
        '                ChildSheetView2.SetColumnVisible(1, False)
        '            Else

        '            End If
        '        Next jindex
        '        'Else
        '        '    ChildSheetView1.ColumnHeaderVisible = False
        '    End If
        'Next iIndex


        'Dim cModel As FarPoint.Win.Spread.Model.IChildModelSupport
        'Dim iModel As FarPoint.Win.Spread.Model.ISheetDataModel
        'Dim s As String
        'cModel = FpSpread1.ActiveSheet.Models.Data
        's = cModel.GetChildRelation(1)
        'iModel = cModel.GetChildDataModel(1, s)
        'MsgBox("The number of rows in the child model is " & iModel.RowCount.ToString)
        ''MasterGroup.Rows.Add(New Object() {"A Master", "A0", "A", "01-04", "Geared", "", "496,250", "", "", ""})
        'FpSpread1.ActiveSheet.AddRows(0, 1)

        '#  commented out   prototype data?
        ' Create an instance of a text cell.
        'Dim t As New FarPoint.Win.Spread.CellType.TextCellType
        'Dim t1 As New FarPoint.Win.Spread.CellType.TextCellType
        '' Load an image file and set it to BackgroundImage property.
        'Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)
        't.BackgroundImage = p
        'Dim p1 As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)

        ' Apply the text cell.   
        '##  commented out. was this used to hard code for prototypw?
        'FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
        't1.BackgroundImage = p1
        'FpSpread1.ActiveSheet.Cells(1, 2).CellType = t1
        ' Set the size of the cell so the image is displayed
        'FpSpread1.ActiveSheet.Rows(1).Height = 50
        'FpSpread1.ActiveSheet.Columns(1).Width = 150



        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        CurrentBuildingInformationFrameHeight = BuildingInformation_fra.Height
        CurrentEquipmentFrameHeight = Equipment_fra.Height

        Relocate_Equipment_Frame()
        SizeTotalsGrid()
        LoadTopOfForm()
        ProcessNegSummaryTotals()
        SetSummaryC1Colors()
        ' FpSpread1.ActiveSheet.Cells(0, 20).Locked = True

        initializing = False
    End Sub


    Private Sub FpSpread1_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick
        '    Dim thisRow As Integer
        '    Dim thisColumn As Integer
        '    Dim thisValue As String

        '    thisRow = e.Row
        '    thisColumn = e.Column
        '    thisValue = FpSpread1.ActiveSheet.GetValue(thisRow, thisColumn)

        ' MsgBox("row:  " & thisRow & "    column: " & thisColumn & " and it's value is: " & thisValue)

        Dim usex As FarPoint.Win.Spread.SheetView = e.View.GetSheetView
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing


        EstimateLevel = String.Empty
        CurrentGOData_Typ.Alt = "A"
        If usex.TitleInfo.Text.ToUpper.IndexOf("SUMMARY") > -1 Then
            EstimateLevel = "Summary"
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
                EstimateLevel = "Alt"
            Else
                ChildSheetView1 = FpSpread1.ActiveSheet.GetChildView(CurSummaryRow, 0)
                If Not IsNothing(ChildSheetView1) Then
                    If ChildSheetView1.RowCount > 0 Then
                        EstimateLevel = ChildSheetView1.Cells(e.Row, 0).Text
                    End If
                End If
            End If
        End If
        UseCurRow = e.Row
        UseCurCol = e.Column

        ProcessNegSummaryTotals()

    End Sub
    Private Sub FpSpread1_Change(sender As Object, e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        If Not initializing Then isDirty = True
        CalculateFinalBankPrice()
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

        Dim percentType As New FarPoint.Win.Spread.CellType.PercentCellType
        percentType.DecimalPlaces = 1

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
                .Columns(8).Width = 60

                .Columns(9).Label = "Special Hours"
                .Columns(9).Locked = True
                .Columns(9).CellType = numberType
                .Columns(9).Width = 60

                .Columns(10).Label = "Labor Hours"
                .Columns(10).Locked = True
                .Columns(10).CellType = numberType
                .Columns(10).Width = 60

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

                .Columns(15).Label = "P/O/B"
                .Columns(15).Locked = True
                .Columns(15).CellType = currencyType
                .Columns(15).Width = 60

                .Columns(16).Label = "Freight"
                .Columns(16).Locked = True
                .Columns(16).CellType = currencyType
                .Columns(16).Width = 60

                .Columns(17).Label = "NPS Cost"
                .Columns(17).Locked = True
                .Columns(17).CellType = currencyType
                .Columns(17).Width = 65

                .Columns(18).Label = "Total Bank Cost"
                .Columns(18).Locked = True
                .Columns(18).CellType = currencyType
                .Columns(18).Width = 70

                .Columns(19).Label = "C1"
                .Columns(19).Locked = False
                .Columns(19).CellType = percentType
                .Columns(19).Width = 50

                .Columns(20).Label = "Bank Net Price"
                .Columns(20).Locked = True
                .Columns(20).CellType = currencyType
                .Columns(20).Width = 70
                .Columns(20).Visible = False

                .Columns(21).Label = "Sales Com"
                .Columns(21).Locked = True
                .Columns(21).CellType = currencyType
                .Columns(21).Width = 60

                .Columns(22).Label = "Sell Price"
                .Columns(22).Locked = True
                .Columns(22).CellType = currencyType
                .Columns(22).Width = 70

                .Columns(23).Label = "Labor Rate"
                .Columns(23).Locked = True
                .Columns(23).CellType = currencyType
                .Columns(23).Width = 60

                .Columns(24).Label = "Comments"
                .Columns(24).Locked = False
                .Columns(24).Width = 100

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
                .Columns(9).Width = 60

                .Columns(10).Label = "Special Hours"
                .Columns(10).Locked = True
                .Columns(10).CellType = numberType
                .Columns(10).Width = 60

                .Columns(11).Label = "Labor Hours"
                .Columns(11).Locked = True
                .Columns(11).CellType = numberType
                .Columns(11).Width = 60

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

                .Columns(25).Label = "Comments"
                .Columns(25).Locked = False
                .Columns(25).Width = 100


                'dateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate
                '.Columns(1).CellType = dateType
                .HorizontalGridLine = gl
                .VerticalGridLine = gl

                'Dim acell As FarPoint.Win.Spread.Cell
                'Dim i, j, c As Integer
                'Dim iColorR, iColorG, iColorB As Integer
                'FpSpread1.ActiveSheet.ColumnCount = 20
                'FpSpread1.ActiveSheet.RowCount = 20
                'For i = 0 To FpSpread1.ActiveSheet.RowCount - 1
                '    For j = 0 To FpSpread1.ActiveSheet.ColumnCount - 1
                '        acell = FpSpread1.ActiveSheet.Cells(i, j)
                '        Randomize()
                '        iColorR = Int(255 * Rnd()) + 1
                '        iColorG = Int(255 * Rnd()) + 1
                '        iColorB = Int(255 * Rnd()) + 1
                '        acell.BackColor = Color.FromArgb(iColorR, iColorG, iColorB)
                '        acell.ForeColor = Color.FromArgb(iColorB, iColorR, iColorG)
                '    Next j
                'Next i

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

        MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case EstimateLevel
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
                        percentType.DecimalPlaces = 1
                        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(CurSummaryRow, 0)
                        ChildSheetView1.SortRows(1, True, True)
                        ChildSheetView1.SetRowExpandable(0, False)

                        percentType.ReadOnly = True
                        ChildSheetView1.Cells(0, 19).CellType = percentType

                        ChildSheetView1.Cells(0, 22).Locked = False
                        SetBaseAltC1Colors()


                        'ChildSheetView1.Cells(0, 7).Locked = False
                        ' ChildSheetView1.Cells(0, 7).BackColor = Color.White

                        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\circlechecked.png"), FarPoint.Win.RenderStyle.Normal)
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
        printset.PdfFileName = "c:\temp\results.pdf"
        printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        printset.ZoomFactor = 0.65
        printset.BestFitCols = True

        printset.PdfWriteMode = FarPoint.Win.Spread.PdfWriteMode.Append

        ' assign the printer settings and print
        'FpSpread1.Sheets().Printinfo = printset


        ' child view
        Dim ss As FarPoint.Win.Spread.SheetView
        ss = FpSpread1.Sheets(0).GetChildView(0, 0)
        FpSpread1.Sheets(0).PrintInfo = printset


        For Each sheet As FarPoint.Win.Spread.SheetView In FpSpread1.Sheets
            sheet.PrintInfo = printset

        Next

        'FpSpread1.PrintSheet(-1)
        FpSpread1.SafePrint(FpSpread1, -1)


        MsgBox("print to pdf completed!")


    End Sub

    Private Sub AddAlternateRow()

        'MsgBox(FpSpread1.ActiveSheet.ActiveRowIndex)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        Dim baseID As String, thisRowDescription As String
        Dim summaryRowIndex As Integer, baseRowIndex As Integer, altCount As Integer

        Dim activeRows As Array
        Dim activeRow As Integer
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
        'units = ChildSheetView.Cells(baseRowIndex, 3).Value
        'machine = ChildSheetView.Cells(baseRowIndex, 4).Value

        dsCadre.Tables("AltGroup").Rows.Add(New Object() {thisRowDescription, baseID, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DEFAULT_C1, 0, 0, 0, 0, ""})

        SetBaseAltC1Colors()

        FpSpread1.Refresh()

        MessageBox.Show("Alternate row added")
        isDirty = True
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
        percentType.DecimalPlaces = 1


        dsCadre.Tables("SummaryGroup").Rows.Add(New Object() {"GO Summary", _id, "", _bank, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DEFAULT_C1, 0, 0, 0, 0})

        FpSpread1.Refresh()
        FpSpread1.ActiveSheet.ActiveRowIndex = FpSpread1.ActiveSheet.RowCount - 1
        FpSpread1.ActiveSheet.ActiveRow.Locked = True

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 20).Locked = False

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

        dtBaseGroup.Rows.Add(New Object() {"Base", _id, "1", "", _id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DEFAULT_C1, 0, 0, 0, 0, ""})
        isDirty = True

        SetSummaryC1Colors()
        SetBaseAltC1Colors()

        FpSpread1.Refresh()
    End Sub

    Private Sub FpSpread1_ComboCloseUp(sender As Object, e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboCloseUp
        Select Case e.Column
            Case 3
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value = "" Then
                    MessageBox.Show("Please select a bank", "Bank ?", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                Else
                    If addingNewRow Then
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
            Case 3          ' bank
                '  
                If FpSpread1.ActiveSheet.Cells(e.Row, e.Column).Value = "" Then
                    MessageBox.Show("Please select a bank", "Bank ?", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    e.Cancel = True
                    'Else
                    '    If newRow Then
                    '        AddCopiedBaseAndAlt()
                    '    End If
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
        If activeRows(0) = -1 And EstimateLevel = "Summary" Then
            summary_row = FpSpread1.Sheets(0).ActiveRowIndex
        Else
            summary_row = activeRows(0)
        End If

        If EstimateLevel = "Alt" Then
            If MessageBox.Show("You are about to delete Alternate '" & (activeRows(2) + 1).ToString & "' for Bank '" & FpSpread1.ActiveSheet.Cells(summary_row, 3).Value & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                'If MessageBox.Show("Delete Alt '" & CInt(activeRows(2)) + 1 & "' from the Estimate?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DeleteAltRow(activeRows)
            End If
        ElseIf EstimateLevel = "Master" Then
            Dim selected_bank As String = FpSpread1.Sheets(0).Cells(summary_row, 3).Text
            If MessageBox.Show("Delete Master for Bank '" & selected_bank & "' from the Estimate?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ' DeleteAltRow(activeRows)
                DeleteMaster(activeRows)
            End If
        ElseIf EstimateLevel = "Summary" Then
            Dim selected_bank As String = FpSpread1.Sheets(0).Cells(summary_row, 3).Text
            If MessageBox.Show("You are about to delete all data for Bank '" & selected_bank & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DeleteBank(summary_row)
            End If
        ElseIf EstimateLevel = "Base" Then
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

    Private Sub btnDeleteBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim summaryRow As Integer
        Dim activeRows As Array

        activeRows = FindActiveRows()
        summaryRow = activeRows(0)
        If summaryRow = -1 Then
            summaryRow = FpSpread1.ActiveSheet.ActiveRowIndex
        End If

        Try
            If MessageBox.Show("You are about to delete all data for Bank '" & FpSpread1.ActiveSheet.Cells(summaryRow, 3).Value & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                FpSpread1.ActiveSheet.RemoveRows(summaryRow, 1)
                isDirty = True
            Else
                MessageBox.Show("Delete Canceled!", "Delete Canceled!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cannot Delete the Bank Row")
        End Try
    End Sub

    Private Sub AlsPrint()

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing

        Dim iIndex As Integer

        For iIndex = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not IsNothing(ChildSheetView1) Then

            End If
        Next
    End Sub

    Private Sub btnDeleteMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MessageBox.Show("You are about to delete the Master for this Summary Row.  Are you Sure", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(0, 0)
            If ChildSheetView1.RowCount > 1 Then
                ChildSheetView1.RemoveRows(0, 1)
            End If

            Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)
            Dim t As New FarPoint.Win.Spread.CellType.TextCellType
            t.BackgroundImage = p
            ' Apply the text cell.
            FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
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

        sSQL = "SELECT Office FROM [MOD OFFICE] WHERE Installing = True ORDER BY Office"
        myList = GetDataFromOptions(sSQL)
        For Each office In myList
            cboSalesOffice.Items.Add(office)
        Next

        'same query for installing office
        For Each office In myList
            cboInstallingOffice.Items.Add(office)
        Next

        sSQL = "SELECT Office FROM [MOD OFFICE] WHERE Service = True ORDER BY Office"
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
        AssignListIndex_First(cboStatus, Contracts.Status)

        Populate_SalesRep(Me.cboSalesRep)
        AssignListIndex(cboSalesRep, Contracts.SalesRepName)

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

        txtOwner.Text = Owner_Info.Name

        If Contracts.NationalAccount Then
            cboNationalAccount.SelectedItem = "Yes"
        Else
            cboNationalAccount.SelectedItem = "No"
        End If

        txtTaxRate.Text = GetTaxRate()

        AssignListIndex_First(cboBuildingType, Contracts.BuildingType)
        AssignListIndex_First(cboSalesOffice, Contracts.SalesRepOffice)
    End Sub

    Private Sub txtBidDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBidDate.Validating
        If IsDate(txtBidDate.Text) Then
        Else
            e.Cancel = True
            MessageBox.Show("Please enter a valid date in the format mm/dd/yy", "Invalid Date")
        End If
    End Sub

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click
        'Dim datatable As New DataTable
        'datatable = dtContactGroup
        'Dim f2 As frmAddresses = New frmAddresses(datatable)
        'f2.ShowDialog()

        frmContacts.ShowDialog()
    End Sub
    Private Sub cmbSeismicZone_Leave(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboSeismicZone.Leave, cboSeismicZone.SelectedIndexChanged
        ValidateTextBoxInput_Text(Me, cboSeismicZone, ENTRY_NOT_AN_INTEGER, True)
        If Not initializing Then isDirty = True
    End Sub

    Private Sub ExpandCollapseFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseFrame_btn.Click
        If BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            BuildingInformation_fra.Height = CurrentBuildingInformationFrameHeight
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
            For Each CurControl As Control In BuildingInformation_fra.Controls
                CurControl.Visible = True
            Next CurControl
            NewProductService_fra.Height = BuildingInformation_fra.Height
            For Each CurControl As Control In NewProductService_fra.Controls
                CurControl.Visible = True
            Next CurControl
            Me.txtOCPL.Visible = True
            Me.lblOCPL.Visible = True
            Me.Button1.Visible = True
        Else
            BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\add.png")
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
            Me.Button1.Visible = False
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveAll()
    End Sub


    Private Sub AddMasterRow(_id As String)

        Dim baseID As String
        Dim target As Integer = 0
        Dim criteria As String
        'Dim row As DataRow
        'Dim datarows() As DataRow
        'Dim mylist As List(Of Object)

        baseID = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 1).Text

        criteria = "id = '" & _id & "'"
        Dim baseRow() As Data.DataRow
        baseRow = dtBaseGroup.Select(criteria)

        ' Copy existing Bank Row data into a new row
        Dim _newRow As DataRow = dtBaseGroup.NewRow

        ' Add each column value from base to new row for master
        For i As Integer = 0 To dtBaseGroup.Columns.Count - 1
            _newRow.Item(i) = baseRow(0).Item(i)
        Next

        ' Update new row as Master.

        _newRow("id") = _id
        _newRow("sort_fld") = "0"
        _newRow("BaseGroup") = "Master"
        _newRow("alt_id") = ""

        dtBaseGroup.Rows.Add(_newRow)

        isDirty = True

    End Sub

    Private Sub DeleteMaster(activeRows() As String)

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(activeRows(0), 0)
        If ChildSheetView1.RowCount > 1 Then
            ChildSheetView1.RemoveRows(0, 1)
            isDirty = True
        End If

        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)
        Dim t As New FarPoint.Win.Spread.CellType.TextCellType
        t.BackgroundImage = p
        ' Apply the text cell.
        FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
        FpSpread1.Refresh()

    End Sub

    Private Sub DeleteBank(summaryRow As String)

        Try
            FpSpread1.ActiveSheet.RemoveRows(summaryRow, 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cannot Delete the Bank Row")
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim activeRows As Array
        activeRows = FindActiveRows()

        Dim summary_row As String
        If activeRows(0) = -1 And EstimateLevel = "Summary" Then
            summary_row = FpSpread1.Sheets(0).ActiveRowIndex
        Else
            summary_row = activeRows(0)
        End If

        If EstimateLevel = "Alt" Or EstimateLevel = "Base" Then
            AddAlternateRow()
        ElseIf EstimateLevel = "Summary" Then
            AddBankRow()
        ElseIf EstimateLevel = "Master" Then
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

                txtOwner.Text = Owner_Info.Name

                cboBuildingType.SelectedItem = row("building_type")
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

                If IsDBNull(row.Item("major_project")) Then
                    chkMajorProject.CheckState = CheckState.Unchecked
                Else
                    chkMajorProject.CheckState = IIf(row.Item("major_project"), CheckState.Checked, CheckState.Unchecked)
                End If

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

    Private Sub SaveTopOfForm()

        Try
            If dtBuildingInfo.Rows.Count = 0 Then
                Dim _newRow As DataRow = dtBuildingInfo.NewRow
                dtBuildingInfo.Rows.Add(_newRow)
            End If

            dtBuildingInfo.Rows(0)("building_type") = cboBuildingType.Text
            dtBuildingInfo.Rows(0)("major_project") = chkMajorProject.CheckState
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


    Private Sub CM_MAIN_frm_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        sprTotals.Refresh()
    End Sub

    Private Sub ProcessNegSummaryTotals()
        Dim dblC1 As Double
        Dim dblValue As Double
        Dim summaryColumn As Integer = 0

        If Not IsNothing(dtSummaryGroup) AndAlso dtSummaryGroup.Rows.Count > 0 Then

            For i As Integer = 6 To (dtSummaryGroup.Columns.Count - 2)  '# don't want the 'include' column
                dblValue = 0
                For Each row As DataRow In dtSummaryGroup.Rows
                    If Not IsDBNull(row.Item(i)) Then
                        dblValue += row.Item(i)
                    End If
                Next row
                Select Case i
                    Case 6 To 8, 13 To 19, 21 To 24
                        sprTotals.ActiveSheet.Cells(0, summaryColumn).Text = FormatCurrency(dblValue, 0)
                    Case 9 To 12
                        sprTotals.ActiveSheet.Cells(0, summaryColumn).Text = FormatNumber(dblValue, 0)
                    Case 20
                        'calculate after loop
                End Select

                summaryColumn += 1
            Next i
            dblC1 = (sprTotals.ActiveSheet.Cells(0, 17).Text - sprTotals.ActiveSheet.Cells(0, 16).Text) / (sprTotals.ActiveSheet.Cells(0, 13).Text) - 1.0
            sprTotals.ActiveSheet.Cells(0, 14).Text = Math.Round(dblC1, 3).ToString("P")

            sprTotals.Refresh()
        End If

    End Sub

    Private Sub SizeTotalsGrid()

        sprTotals.ActiveSheet.Cells(0, 0).Column.Width = 63         'material_HQ
        sprTotals.ActiveSheet.Cells(0, 1).Column.Width = 63         'material_RL
        sprTotals.ActiveSheet.Cells(0, 2).Column.Width = 60         'sales tax
        sprTotals.ActiveSheet.Cells(0, 3).Column.Width = 60         'total BDP Hours
        sprTotals.ActiveSheet.Cells(0, 4).Column.Width = 60        'total special hours
        sprTotals.ActiveSheet.Cells(0, 5).Column.Width = 60        'total labor hours
        sprTotals.ActiveSheet.Cells(0, 6).Column.Width = 60        'Overtime hours included
        sprTotals.ActiveSheet.Cells(0, 7).Column.Width = 60        'labor $
        sprTotals.ActiveSheet.Cells(0, 8).Column.Width = 70        'Subcontract work
        sprTotals.ActiveSheet.Cells(0, 9).Column.Width = 60        'expenses
        sprTotals.ActiveSheet.Cells(0, 10).Column.Width = 60        'misc costs
        sprTotals.ActiveSheet.Cells(0, 11).Column.Width = 60        'freight
        sprTotals.ActiveSheet.Cells(0, 12).Column.Width = 65        'NPS Cost
        sprTotals.ActiveSheet.Cells(0, 13).Column.Width = 70        'total bank cost
        sprTotals.ActiveSheet.Cells(0, 14).Column.Width = 50        'project c1
        sprTotals.ActiveSheet.Cells(0, 15).Column.Width = 70        'bank sell price
        sprTotals.ActiveSheet.Cells(0, 16).Column.Width = 60        'sales commission
        sprTotals.ActiveSheet.Cells(0, 17).Column.Width = 70        'bank final price
        sprTotals.ActiveSheet.Cells(0, 18).Column.Width = 60       'labor rate

        sprTotals.ActiveSheet.Rows(0).Locked = True

        sprTotals.ActiveSheet.Cells(0, 15).Column.Visible = False

    End Sub


    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        If isDirty Then
            Dim response As DialogResult = MessageBox.Show("Do you want to save all the changes?" & Environment.NewLine & "Selecting No will negate all changes.", "Please Confirm.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If response = DialogResult.Yes Then
                SaveAll()
            ElseIf response = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        EndProgram()
    End Sub
    Private Sub cboSalesOffice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSalesOffice.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub updateDtBuildingInfo(column_name As String, value As String)
        Dim row As DataRow
        row = dtBuildingInfo.Rows(0)
        row(column_name) = value
    End Sub


    Private Sub FpSpread1_SubEditorOpening(sender As Object, e As FarPoint.Win.Spread.SubEditorOpeningEventArgs) Handles FpSpread1.SubEditorOpening
        e.Cancel = True     ' to prevent calculator from automatically opening on number cell double click
    End Sub
    Private Sub cboBuildingType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBuildingType.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboSalesRep_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSalesRep.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboInstallingOffice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboInstallingOffice.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboServiceOffice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServiceOffice.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboProbabilityOfSale_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProbabilityOfSale.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtBidDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtBidDate.ValueChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboNationalAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNationalAccount.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtTaxRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTaxRate.TextChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboTaxCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTaxCode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboLocalCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLocalCode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboANSICode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboANSICode.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub cboNFPA13CodeYear_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNFPA13CodeYear.SelectedIndexChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub txtSDSlevel_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSDSlevel.TextChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkOSHPD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOSHPD.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkDSA_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDSA.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkHeadDetection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHeadDetection.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub
    Private Sub chkEngineeringSurvey_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEngineeringSurvey.CheckedChanged
        If Not initializing Then isDirty = True
    End Sub


    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        ' copy the selected summary, and copy, along with all base, master  and  alt data

        If EstimateLevel <> "Summary" Then
            MessageBox.Show("Please select the group column of the summary group that you wish to copy, then click on 'Copy'.", "Please Identify The Group to Copy", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        addingNewRow = True

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
        percentType.DecimalPlaces = 1

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

    Private Sub SaveAll()
        SaveTopOfForm()
        Serialize("C:\Temp\cadre.json", dsCadre, "Error Writing Cadre Json file", isDirty)           'Contracts.EstimateNum & ".json"
        ' Serialize(Contracts.EstimateNum & ".json", dsCadre, "Error Writing Cadre Json file", isDirty)           '
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
        AssignListIndex_First(cboSalesOffice, Contracts.SalesOffice)
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

        txtOwner.Text = Owner_Info.Name

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

        Dim i As Integer

        For i = 0 To dtSummaryGroup.Rows.Count - 1
            If dtSummaryGroup.Rows(i).Item("C1") < DEFAULT_C1 Then
                FpSpread1.ActiveSheet.Cells(i, 20).BackColor = Color.Red
            ElseIf dtSummaryGroup.Rows(i).Item("C1") >= DEFAULT_C1 + 0.02 Then
                FpSpread1.ActiveSheet.Cells(i, 20).BackColor = Color.Green
            Else
                FpSpread1.ActiveSheet.Cells(i, 20).BackColor = Color.Yellow
            End If
        Next

    End Sub

    Private Sub SetBaseAltC1Colors()

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                For i As Integer = 0 To ChildSheetView1.RowCount - 1
                    If ChildSheetView1.Cells(i, 19).Value < DEFAULT_C1 Then
                        ChildSheetView1.Cells(i, 19).BackColor = Color.Red
                    ElseIf ChildSheetView1.Cells(i, 19).Value > DEFAULT_C1 + 0.02 Then
                        ChildSheetView1.Cells(i, 19).BackColor = Color.Green
                    Else
                        ChildSheetView1.Cells(i, 19).BackColor = Color.Yellow
                    End If
                Next

                For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                    If Not ChildSheetView2 Is Nothing Then
                        For i As Integer = 0 To ChildSheetView2.RowCount - 1
                            If ChildSheetView2.Cells(i, 20).Value < DEFAULT_C1 Then
                                ChildSheetView2.Cells(i, 20).BackColor = Color.Red
                            ElseIf ChildSheetView2.Cells(i, 20).Value > DEFAULT_C1 + 0.02 Then
                                ChildSheetView2.Cells(i, 20).BackColor = Color.Green
                            Else
                                ChildSheetView2.Cells(i, 20).BackColor = Color.Yellow
                            End If
                        Next

                    End If
                Next jindex

            End If
        Next iIndex

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
                        ChildSheetView.Cells(0, 19).CellType = percentType
                        ChildSheetView.Cells(0, 22).Locked = False
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim obj As New frmLaborRates
        Try
            obj.localOffice = Me.cboSalesOffice.Text
            obj.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Labor Rates Form", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub CalculateFinalBankPrice()
        CalculateFinalBankPriceSummary()
        CalculateFinalBankPriceBase()
        CalculateFinalBankPriceAlt()

    End Sub

    Private Sub CalculateFinalBankPriceSummary()

        Dim sales_commission As Double

        For Each row As DataRow In dtSummaryGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) Then
                sales_commission = IIf(IsDBNull(row.Item("sales_commission")), 0, row.Item("sales_commission"))
                row.Item("C1") = (((row.Item("bank_final_price") - sales_commission)) / (row.Item("Total_Bank_Cost"))) - 1.0
                row.Item("C1") = Math.Round(row.Item("C1"), 3)
            End If
        Next row

    End Sub

    Private Sub CalculateFinalBankPriceBase()

        Dim sales_commission As Double

        For Each row As DataRow In dtBaseGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) Then
                sales_commission = IIf(IsDBNull(row.Item("sales_commission")), 0, row.Item("sales_commission"))
                If row.Item(0) <> "Master" Then
                    row.Item("bank_final_price") = (row.Item("Total_Bank_Cost") * (1.0 + row.Item("C1"))) + sales_commission
                Else
                    row.Item("C1") = (((row.Item("bank_final_price") - sales_commission)) / (row.Item("Total_Bank_Cost"))) - 1.0
                    row.Item("C1") = Math.Round(row.Item("C1"), 3)
                End If
            End If

        Next row

    End Sub

    Private Sub CalculateFinalBankPriceAlt()

        Dim sales_commission As Double

        For Each row As DataRow In dtAltGroup.Rows
            If Not IsDBNull(row.Item("Total_Bank_Cost")) Then
                sales_commission = IIf(IsDBNull(row.Item("sales_commission")), 0, row.Item("sales_commission"))
                row.Item("bank_final_price") = (row.Item("Total_Bank_Cost") * (1.0 + row.Item("C1"))) + sales_commission
            End If
        Next row

    End Sub
End Class
