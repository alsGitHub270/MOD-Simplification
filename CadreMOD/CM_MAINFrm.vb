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
   

    Private CurrentBuildingInformationFrameHeight As Integer = 0, CurrentEquipmentFrameHeight As Integer = 0
    Public DefaultTaxCode As String = ""

    Const _BANK_COLUMN As Integer = 3

    Private UseCurRow As Integer = 0, UseCurCol As Integer = 0, CurSummaryRow As Integer = 0

    Private Sub CreateDataSet()

        Dim typeStr As System.Type
        Dim typeInt As System.Type
        Dim typeBool As System.Type
        typeStr = System.Type.GetType("System.String")
        typeInt = System.Type.GetType("System.Int64")
        typeBool = System.Type.GetType("System.Boolean")

        dsCadre = New DataSet()
        dsCadre.EnforceConstraints = False

        dtSummaryGroup = dsCadre.Tables.Add("SummaryGroup")
        dtSummaryGroup.Columns.AddRange(New DataColumn() {New DataColumn("SummaryGroup", typeStr), _
                                                          New DataColumn("id", typeStr), _
                                                          New DataColumn("_", typeStr), _
                                                          New DataColumn("Bank", typeStr), _
                                                          New DataColumn("Bank Type", typeStr), _
                                                          New DataColumn("Units", typeStr), _
                                                          New DataColumn("Material HQ", typeInt), _
                                                          New DataColumn("Material RL", typeInt), _
                                                          New DataColumn("Sales Tax", typeInt), _
                                                          New DataColumn("Total BDP Hours", typeInt), _
                                                          New DataColumn("Total Special Hours", typeInt), _
                                                          New DataColumn("Total Labor Hours", typeInt), _
                                                          New DataColumn("Overtime Hours Included", typeInt), _
                                                          New DataColumn("Labor $", typeInt), _
                                                          New DataColumn("SubContract Work", typeInt), _
                                                          New DataColumn("Misc Costs", typeInt), _
                                                          New DataColumn("Freight", typeInt), _
                                                          New DataColumn("NPS Cost", typeInt), _
                                                          New DataColumn("Total Bank Cost", typeInt), _
                                                          New DataColumn("Project C1%", typeInt), _
                                                          New DataColumn("Bank Sell Price", typeInt), _
                                                          New DataColumn("Tax Rate", typeInt), _
                                                          New DataColumn("Labor Rate", typeInt)
                                                         })

        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "A1", "", "A", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "B1", "", "B", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        'dtSummaryGroup.Rows.Add(New Object() {"Summary", "F1", "", "F", "Gearless", "01,03,04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})


        dtBaseGroup = dsCadre.Tables.Add("BaseGroup")
        dtBaseGroup.Columns.AddRange(New DataColumn() {New DataColumn("BaseGroup", typeStr), _
                                                        New DataColumn("Id", typeStr), _
                                                        New DataColumn("Bank", typeStr), _
                                                        New DataColumn("Units", typeStr), _
                                                        New DataColumn("Machine", typeStr), _
                                                        New DataColumn("Target", typeInt), _
                                                        New DataColumn("Bid", typeStr), _
                                                        New DataColumn("Award", typeStr), _
                                                        New DataColumn("Material HQ", typeInt), _
                                                        New DataColumn("Material RL", typeInt), _
                                                        New DataColumn("Sales Tax", typeInt), _
                                                        New DataColumn("Total BDP Hours", typeInt), _
                                                        New DataColumn("Total Special Hours", typeInt), _
                                                        New DataColumn("Total Labor Hours", typeInt), _
                                                        New DataColumn("Overtime Hours Included", typeInt), _
                                                        New DataColumn("Labor $", typeInt), _
                                                        New DataColumn("SubContract Work", typeInt), _
                                                        New DataColumn("Misc Costs", typeInt), _
                                                        New DataColumn("Freight", typeInt), _
                                                        New DataColumn("NPS Cost", typeInt), _
                                                        New DataColumn("Total Bank Cost", typeInt), _
                                                        New DataColumn("Project C1%", typeInt), _
                                                        New DataColumn("Bank Sell Price", typeInt), _
                                                        New DataColumn("Tax Rate", typeInt), _
                                                        New DataColumn("Labor Rate", typeInt), _
                                                        New DataColumn("Comment", typeStr)
                                                        })
       
        dtBaseGroup.Columns("Material RL").DefaultValue = 0

        'dtBaseGroup.Rows.Add(New Object() {"Master", "A0", "A", "01-04", "Geared", 497250, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "A1", "A", "01-04", "Geared", 500000, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "B1", "B", "01-04", "Geared", 375000, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})
        'dtBaseGroup.Rows.Add(New Object() {"Base", "F1", "F", "01,03-04", "Gearless", 0, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""})

        dtAltGroup = dsCadre.Tables.Add("AltGroup")
        dtAltGroup.Columns.AddRange(New DataColumn() {New DataColumn("AltGroup", typeStr), _
                                                      New DataColumn("id", typeStr), _
                                                      New DataColumn("Units", typeStr), _
                                                      New DataColumn("Machine", typeStr), _
                                                      New DataColumn("Target", typeStr), _
                                                      New DataColumn("Bid", typeStr), _
                                                      New DataColumn("Offer", typeStr), _
                                                      New DataColumn("Merge", typeStr), _
                                                      New DataColumn("Material HQ", typeInt), _
                                                     New DataColumn("Material RL", typeInt), _
                                                     New DataColumn("Sales Tax", typeInt), _
                                                     New DataColumn("Total BDP Hours", typeInt), _
                                                     New DataColumn("Total Special Hours", typeInt), _
                                                     New DataColumn("Total Labor Hours", typeInt), _
                                                     New DataColumn("Overtime Hours Included", typeInt), _
                                                     New DataColumn("Labor $", typeInt), _
                                                     New DataColumn("SubContract Work", typeInt), _
                                                     New DataColumn("Misc Costs", typeInt), _
                                                     New DataColumn("Freight", typeInt), _
                                                     New DataColumn("NPS Cost", typeInt), _
                                                     New DataColumn("Total Bank Cost", typeInt), _
                                                     New DataColumn("Project C1%", typeInt), _
                                                     New DataColumn("Bank Sell Price", typeInt), _
                                                     New DataColumn("Tax Rate", typeInt), _
                                                     New DataColumn("Labor Rate", typeInt), _
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
                                                          New DataColumn("sales_rep", typeStr), _
                                                          New DataColumn("sales_office", typeStr), _
                                                          New DataColumn("installing_office", typeStr), _
                                                          New DataColumn("service_office", typeStr), _
                                                          New DataColumn("status", typeStr), _
                                                          New DataColumn("probability_of_sale", typeStr), _
                                                          New DataColumn("bid_date", typeStr), _
                                                          New DataColumn("national_account", typeStr), _
                                                          New DataColumn("tax_code", typeStr), _
                                                          New DataColumn("seismic_zone", typeStr), _
                                                          New DataColumn("local_code", typeStr), _
                                                          New DataColumn("ansi_csa_b44_code", typeStr), _
                                                          New DataColumn("nfpa_code", typeStr), _
                                                          New DataColumn("sds_level", typeStr), _
                                                          New DataColumn("ishpd", typeStr), _
                                                          New DataColumn("dsa", typeStr), _
                                                          New DataColumn("head_detection", typeStr), _
                                                          New DataColumn("engineering_survey", typeStr)
                                                         })

        ' dtBuildingInfo.Rows.Add(New Object() {"HOT - Hotel/Motel/Inn/Dorm/Casino", "ZZZ Other", "6122", "6122", "6122", "", "", "8/1/2017", "No", "Tax Exempt", "1", "", "", "", "", "", "", "", ""})


        Deserialize()

        'Add the relations
        dsCadre.Relations.Add("Summary_Base_Relationship", dsCadre.Tables("SummaryGroup").Columns("Bank"), dsCadre.Tables("BaseGroup").Columns("Bank"))
        dsCadre.Relations.Add("Base_Alt_Relationship", dsCadre.Tables("BaseGroup").Columns("id"), dsCadre.Tables("AltGroup").Columns("id"))

    End Sub


    Private Sub btnEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex
        MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case EstimateLevel
            Case "Summary"
            Case "Master", "Base", "Alt"
                frmEstimatingBase.Show()
                Me.Hide()
            Case Else
        End Select
    End Sub

    Private Sub CM_MAIN_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ShiftDist As Single = (Me.Width - BuildingInformation_fra.Width) / 2

        Load_ListBoxes()

        BuildingInformation_fra.Left = ShiftDist
        ' JobInformation_fra.Left = ShiftDist
        Equipment_fra.Left = ShiftDist

        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

        Dim gl As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, Color.Black)
        FpSpread1.ActiveSheet.HorizontalGridLine = gl
        FpSpread1.ActiveSheet.VerticalGridLine = gl

        FpSpread1.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        FpSpread1.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        FpSpread1.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        FpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off


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



        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True

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

            FpSpread1.ActiveSheet.Cells(i, 0).Column.Width = 100        'summary
            FpSpread1.ActiveSheet.Cells(i, 2).Column.Width = 25         'STATUS
            FpSpread1.ActiveSheet.Cells(i, 3).Column.Width = 50         'bank
            FpSpread1.ActiveSheet.Cells(i, 4).Column.Width = 75         'bank_type
            FpSpread1.ActiveSheet.Cells(i, 5).Column.Width = 60         'units
            FpSpread1.ActiveSheet.Cells(i, 6).Column.Width = 60         'material_HQ
            FpSpread1.ActiveSheet.Cells(i, 7).Column.Width = 60         'material_RL
            FpSpread1.ActiveSheet.Cells(i, 8).Column.Width = 60         'sales tax
            FpSpread1.ActiveSheet.Cells(i, 9).Column.Width = 60         'total BDP Hours
            FpSpread1.ActiveSheet.Cells(i, 10).Column.Width = 60        'total special hours
            FpSpread1.ActiveSheet.Cells(i, 11).Column.Width = 60        'total labor hours
            FpSpread1.ActiveSheet.Cells(i, 12).Column.Width = 60        'Overtime hours included
            FpSpread1.ActiveSheet.Cells(i, 13).Column.Width = 60        'labor $
            FpSpread1.ActiveSheet.Cells(i, 14).Column.Width = 70        'Subcontract work
            FpSpread1.ActiveSheet.Cells(i, 15).Column.Width = 60        'mics costs
            FpSpread1.ActiveSheet.Cells(i, 16).Column.Width = 60        'freight
            FpSpread1.ActiveSheet.Cells(i, 17).Column.Width = 60        'NPS Cost
            FpSpread1.ActiveSheet.Cells(i, 18).Column.Width = 60        'total bank cost
            FpSpread1.ActiveSheet.Cells(i, 19).Column.Width = 60        'project c1
            FpSpread1.ActiveSheet.Cells(i, 20).Column.Width = 60        'bank sell price
            FpSpread1.ActiveSheet.Cells(i, 21).Column.Width = 60        'tax rate
            FpSpread1.ActiveSheet.Cells(i, 22).Column.Width = 60        'Labor rate

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
            FpSpread1.ActiveSheet.Cells(i, 20).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 21).CellType = currencyType
            FpSpread1.ActiveSheet.Cells(i, 22).CellType = currencyType


            FpSpread1.ActiveSheet.Columns(1).Visible = False
            FpSpread1.ActiveSheet.ColumnHeader.Rows(0).Height = 40


            'FpSpread1.ActiveSheet.Cells(i, 25).BackColor = Color.LightGray
        Next

        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
        FpSpread1.ActiveSheet.TitleInfo.Value = "Summary"
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
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


        'Dim cModel As FarPoint.Win.Spread.Model.IChildModelSupport
        'Dim iModel As FarPoint.Win.Spread.Model.ISheetDataModel
        'Dim s As String
        'cModel = FpSpread1.ActiveSheet.Models.Data
        's = cModel.GetChildRelation(1)
        'iModel = cModel.GetChildDataModel(1, s)
        'MsgBox("The number of rows in the child model is " & iModel.RowCount.ToString)
        ''MasterGroup.Rows.Add(New Object() {"A Master", "A0", "A", "01-04", "Geared", "", "496,250", "", "", ""})
        'FpSpread1.ActiveSheet.AddRows(0, 1)


        ' Create an instance of a text cell.
        Dim t As New FarPoint.Win.Spread.CellType.TextCellType
        Dim t1 As New FarPoint.Win.Spread.CellType.TextCellType
        ' Load an image file and set it to BackgroundImage property.
        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)
        t.BackgroundImage = p
        Dim p1 As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\openned.png"), FarPoint.Win.RenderStyle.Normal)

        ' Apply the text cell.
        FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
        t1.BackgroundImage = p1
        FpSpread1.ActiveSheet.Cells(1, 2).CellType = t1
        ' Set the size of the cell so the image is displayed
        'FpSpread1.ActiveSheet.Rows(1).Height = 50
        'FpSpread1.ActiveSheet.Columns(1).Width = 150
        ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        CurrentBuildingInformationFrameHeight = BuildingInformation_fra.Height
        CurrentEquipmentFrameHeight = Equipment_fra.Height
        Relocate_Equipment_Frame()

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

        If e.SheetView.ParentRelationName = "Summary_Base_Relationship" Then
            With e.SheetView
                .RowHeader.AutoText = False
                .DataAutoCellTypes = False
                .DataAutoSizeColumns = False
                .ColumnHeader.Rows(0).Height = 40

                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False

                .Columns(0).Locked = True
                .Columns(5).Locked = True
                For i As Integer = 7 To 24
                    .Columns(i).Locked = True
                    .SetColumnWidth(i, 60)
                Next i

                .SetColumnWidth(0, 65)
                .SetColumnWidth(3, 75)
                .SetColumnWidth(4, 75)
                .SetColumnWidth(5, 60)
                .SetColumnWidth(6, 75)
                .SetColumnWidth(7, 75)
                .SetColumnWidth(16, 70)
                .SetColumnWidth(25, 200)

                .Columns(5).CellType = currencyType
                .Columns(6).CellType = currencyType
                .Columns(7).CellType = currencyType
                .Columns(8).CellType = currencyType
                .Columns(9).CellType = currencyType
                .Columns(10).CellType = currencyType
                .Columns(15).CellType = currencyType
                .Columns(16).CellType = currencyType
                .Columns(17).CellType = currencyType
                .Columns(18).CellType = currencyType
                .Columns(19).CellType = currencyType
                .Columns(20).CellType = currencyType
                .Columns(22).CellType = currencyType
                .Columns(23).CellType = currencyType
                .Columns(24).CellType = currencyType

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
                .ColumnHeader.Rows(0).Height = 40

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(2).Locked = True
                .Columns(3).Locked = True
                .Columns(4).Locked = True

                .SetColumnWidth(2, 50)
                .SetColumnWidth(3, 100)
                .SetColumnWidth(4, 75)
                .SetColumnWidth(5, 75)
                .SetColumnWidth(6, 50)
                .SetColumnWidth(7, 50)

                For i As Integer = 8 To 24
                    .Columns(i).Locked = True
                    .SetColumnWidth(i, 60)
                Next
                
                .SetColumnWidth(16, 70)
                .SetColumnWidth(25, 375)

                .Columns(4).CellType = currencyType
                .Columns(5).CellType = currencyType
                .Columns(6).CellType = ckbxcell
                .Columns(7).CellType = ckbxcell
                .Columns(8).CellType = currencyType
                .Columns(9).CellType = currencyType
                .Columns(10).CellType = currencyType
                .Columns(15).CellType = currencyType
                .Columns(16).CellType = currencyType
                .Columns(17).CellType = currencyType
                .Columns(18).CellType = currencyType
                .Columns(19).CellType = currencyType
                .Columns(20).CellType = currencyType
                .Columns(22).CellType = currencyType
                .Columns(23).CellType = currencyType
                .Columns(24).CellType = currencyType


                .Columns(5).BackColor = Color.LightGoldenrodYellow
                .Columns(6).BackColor = Color.LightGoldenrodYellow
                .Columns(7).BackColor = Color.LightGoldenrodYellow



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

    End Sub


    Private Sub _Menu_tlb_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _Menu_tlb_0.Click
        End
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


    Private Sub btnPreOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreOrder.Click

        Dim update_message As String
        Dim CurRow As Integer = FpSpread1.ActiveSheet.ActiveRowIndex

        MachineType = FpSpread1.ActiveSheet.Cells(CurRow, 4).Text
        CurrentUnits = FpSpread1.ActiveSheet.Cells(CurRow, 5).Text
        Select Case EstimateLevel
            Case "Summary"
            Case "Master"
            Case "Base", "Alt"
               
                Dim bank As String
                bank = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 3).Text

                Dim foundRows() As Data.DataRow
                Dim criteria As String
                criteria = "BaseGroup = 'Master' AND bank = '" & bank & "'"
                foundRows = dtBaseGroup.Select(criteria)
                If foundRows.Count = 0 Then

                    update_message = "You are about to create a 'Master' for Bank " & bank & ".  Are you sure?"

                    If MessageBox.Show(update_message, "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                        '  dsCadre.Tables("BaseGroup").Rows.Add((New Object() {"Master", altID, bank, "01-04", "Geared", target, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""}))
                        AddMasterRow(bank)

                        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
                        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(CurSummaryRow, 0)
                        ChildSheetView1.SortRows(1, True, True)
                        ChildSheetView1.SetRowExpandable(0, False)

                        ChildSheetView1.Cells(0, 6).Locked = True
                        ChildSheetView1.Cells(0, 6).BackColor = Color.LightGray

                        ChildSheetView1.Cells(0, 7).Locked = False
                        ' ChildSheetView1.Cells(0, 7).BackColor = Color.White

                        Dim p As New FarPoint.Win.Picture(Image.FromFile(ImageFileLocation & "\images\circlechecked.png"), FarPoint.Win.RenderStyle.Normal)
                        Dim t As New FarPoint.Win.Spread.CellType.TextCellType
                        t.BackgroundImage = p
                        ' Apply the text cell.
                        FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
                    End If
                Else
                    MessageBox.Show("A Master Has Already Been Created", "Cannot Create Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case Else
        End Select


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

    Private Sub btnAddAlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAlt.Click

        'MsgBox(FpSpread1.ActiveSheet.ActiveRowIndex)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        Dim baseID As String, thisID As String, units As String, machine As String
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
        baseID = ChildSheetView.Cells(baseRowIndex, 1).Value
        thisID = "Alt" + (altCount + 1).ToString
        units = ChildSheetView.Cells(baseRowIndex, 3).Value
        machine = ChildSheetView.Cells(baseRowIndex, 4).Value

        dsCadre.Tables("AltGroup").Rows.Add(New Object() {thisID, baseID, units, machine, 0, "", "", "", ""})

    End Sub

    Private Sub btnAddBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBank.Click
        ' Add a new summary row to the grid
        ' Add a new base row to the grid

        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True

        dsCadre.Tables("SummaryGroup").Rows.Add(New Object() {"Summary", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})

        FpSpread1.Refresh()
        FpSpread1.ActiveSheet.ActiveRowIndex = FpSpread1.ActiveSheet.RowCount - 1
        FpSpread1.ActiveSheet.ActiveRow.Locked = True

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Locked = False

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 6).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 7).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 8).CellType = currencyType
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 20).CellType = currencyType
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

        FpSpread1.Refresh()
    End Sub

    Private Sub FpSpread1_ComboDropDown(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboDropDown
        Dim thisValue As String

        thisValue = FpSpread1.ActiveSheet.GetValue(e.Row, e.Column)

    End Sub

    Private Sub FpSpread1_ComboSelChange(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpread1.ComboSelChange

        Debug.Print(e.Column)
        '  Debug.Printe.
    End Sub




    Private Sub FpSpread1_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpSpread1.LeaveCell

        Dim textBoxType As New FarPoint.Win.Spread.CellType.TextCellType()


        Select Case e.Column
            Case 3          ' bank
                '    If Not ValidBank() Then
                '        e.Cancel = True
                '    End If
                '    FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 4, False)
                Dim bank As String = FpSpread1.ActiveSheet.GetValue(e.Row, 3)
                Dim thisID As String = bank & "1"
                dtBaseGroup.Rows.Add(New Object() {"Base", thisID, bank, "", "", 0, "", "", ""})
            Case 4
                If IsNothing(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Value) Then
                    MessageBox.Show("Please select a machine.", "Missing Data")
                    e.Cancel = True
                End If
                FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 5, False)
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



    Private Sub btnDeleteAlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAlt.Click

        Dim activeRows As Array
        activeRows = FindActiveRows()

        'MsgBox("ActiveIndexRow: " & FpSpread1.ActiveSheet.ActiveRowIndex & vbCrLf & _
        '       "Summary Row:  " & activeRows(0) & vbCrLf & _
        '       "Base Row: " & activeRows(1) & vbCrLf & _
        '       "Alt row:  " & activeRows(2))

        If activeRows(2) = -1 Then
            MessageBox.Show("Please click on the Target Column of the  Alternate Row you wish to delete", "Cannot Determine Which Alternate Row Selected!")
        Else
            DeleteAltRow(activeRows)
        End If

    End Sub

    Private Sub DeleteAltRow(ByVal activeRows As Array)
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing

        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(activeRows(0), 0)
        If Not ChildSheetView1 Is Nothing Then
            ChildSheetView2 = ChildSheetView1.FindChildView(activeRows(1), 0)
            If Not IsNothing(ChildSheetView2) Then
                Try
                    If MessageBox.Show("You are about to delete Alternate '" & (activeRows(2) + 1).ToString & "' for Bank '" & FpSpread1.ActiveSheet.Cells(activeRows(0), 3).Value & "' from this Estimate.  Are you sure?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        ChildSheetView2.RemoveRows(activeRows(2), 1)
                    Else
                        MessageBox.Show("Delete Canceled!", "Delete Canceled!")
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Cannot Delete the Alt Row")
                End Try
            End If
        End If

    End Sub

    Private Sub btnDeleteBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBank.Click
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

    Private Sub btnDeleteMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteMaster.Click

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
        Next

        For Each dr As DataRow In dsCadre.Tables(0).Rows
            bank = dr("Bank")
            If bank <> "" Then
                i = myList.IndexOf(bank)
                If i > -1 Then
                    myList.RemoveAt(i)
                End If
            End If
        Next

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
        Dim where As String

        cboBuildingType.Items.Clear()

        Dim sSQL As String = "SELECT code & ' - ' &  Description AS BldgCode " & _
                    "FROM [Building Code] " & _
                    "ORDER BY Code;"

        myList = GetItemList(sSQL)
        For Each code In myList
            cboBuildingType.Items.Add(code)
        Next

        sSQL = "SELECT DISTINCTROW [Local Code] & ' - ' & IIf([City] Is Null,'',[City] & ',') & IIf([State] Is Null,' ',[State]) AS [Local Code/ID] FROM [Local Code] WHERE [State] = '" & JobState_txt.Text & "';"

        myList = GetItemList(sSQL)
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
        myList = GetItemList(sSQL)
        For Each office In myList
            cboSalesOffice.Items.Add(office)
        Next

        'same query for installing office
        For Each office In myList
            cboInstallingOffice.Items.Add(office)
        Next

        sSQL = "SELECT Office FROM [MOD OFFICE] WHERE Service = True ORDER BY Office"
        myList = GetItemList(sSQL)
        For Each office In myList
            cboServiceOffice.Items.Add(office)
        Next

        cboProbabilityOfSale.Items.Clear()
        cboProbabilityOfSale.Items.Add("0-25%")
        cboProbabilityOfSale.Items.Add("26-50%")
        cboProbabilityOfSale.Items.Add("51-75%")
        cboProbabilityOfSale.Items.Add("76-99%")
        cboProbabilityOfSale.Items.Add("100%")

    End Sub


    'Private Sub cmbBuildingType_DropDown(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdBuildingType.DropDown
    '    cmdBuildingType.Width = 267
    '    cmdBuildingType.Left = 40
    'End Sub


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
    End Sub

    Private Sub ExpandCollapseFrame_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandCollapseFrame_btn.Click
        If BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2 Then
            BuildingInformation_fra.Height = CurrentBuildingInformationFrameHeight
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
            For Each CurControl As Control In BuildingInformation_fra.Controls
                CurControl.Visible = True
            Next CurControl
        Else
            BuildingInformation_fra.Height = ExpandCollapseFrame_btn.Height + 2
            ExpandCollapseFrame_btn.Image = Image.FromFile(ImageFileLocation & "\images\add.png")
            For Each CurControl As Control In BuildingInformation_fra.Controls
                If CurControl.Name <> "ExpandCollapseFrame_btn" Then
                    CurControl.Visible = False
                End If
            Next CurControl
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

        e.Cancel = True

    End Sub

    Private Sub Serialize()
        Dim json As String = ""

        Try
            json = JsonConvert.SerializeObject(dsCadre, Formatting.Indented)

            Using sw As StreamWriter = New StreamWriter("C:\Temp\cadre.json")
                sw.Write(json)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Writing Cadre Json file")
        End Try
    End Sub

    Private Sub Deserialize()
        Dim json As String = ""

        Try
            Using sr As StreamReader = New StreamReader("C:\Temp\cadre.json")
                json = sr.ReadToEnd
            End Using
            dsTemp = JsonConvert.DeserializeObject(Of DataSet)(json)
            'JsonSerializerSettings()
            'NullValueHandling = NullValueHandling.Include
            dsCadre.Merge(dsTemp, True, MissingSchemaAction.Ignore)   'HACK:  may want to revise this to something like 
            '     dataset.Merge(JsonConvert.DeserializeObject(Of DataSet)(json), true, MissingSchemaAction.AddWithKey)
            FpSpread1.ActiveSheet.SortRows(3, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Reading Input File")
        End Try
    End Sub


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Serialize()
        ' frmAddresses.Save()
    End Sub

    Private Function GetItemList(sSQL As String) As List(Of String)
        Dim dataSource As String = "C:\Users\adolfsal\Documents\Visual Studio 2010\Projects\Mod Simplification - GIT\CadreMOD\bin\Debug\Options.accdb"
        Dim cnstr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dataSource & ";Jet OLEDB:Database Password=oscar"
        Dim result As String
        Dim myList As New List(Of String)()


        Using cn As New OleDb.OleDbConnection(cnstr)
            cn.Open()

            Dim cmd As New OleDb.OleDbCommand(sSQL, cn)
            Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader
            While reader.Read
                result = (reader(0).ToString)
                myList.Add(result)
            End While

        End Using

        Return myList
    End Function

    Private Sub AddMasterRow(bank As String)

        Dim baseID As String
        Dim target As Integer = 0
        Dim criteria As String
        Dim row As DataRow
        Dim datarows() As DataRow
        Dim mylist As List(Of Object)

        baseID = FpSpread1.ActiveSheet.Cells(CurSummaryRow, 1).Text

        ' dsCadre.Tables("BaseGroup").Rows.Add((New Object() {"Master", altID, bank, "01-04", "Geared", target, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""}))

        ' Build the target amount.  Bid overrides Target at Alt level
        criteria = "id = '" & baseID & "' and merge = 'True'"
        datarows = dtAltGroup.Select(criteria)

        For Each row In datarows
            If row("Bid") <> "" Then
                target += row("Bid")
            Else
                target += row("Target")
            End If
        Next

        criteria = "bank = '" & bank & "'"
        Dim baseRow() As Data.DataRow
        baseRow = dtBaseGroup.Select(criteria)
        target += baseRow(0).Item("Target")

        ' Copy existing Bank Row data into a new row
        Dim newRow As DataRow = dtBaseGroup.NewRow

        For i As Integer = 0 To dtBaseGroup.Columns.Count - 1
            newRow.Item(i) = baseRow(0).Item(i)
        Next

        ' Update new row as Master
        newRow("Target") = target
        newRow("Id") = bank.Trim & "0"
        newRow("BaseGroup") = "Master"

        dtBaseGroup.Rows.Add(newRow)

    End Sub



End Class
