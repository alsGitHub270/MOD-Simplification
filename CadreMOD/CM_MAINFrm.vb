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


Partial Friend Class CM_MAIN_frm
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)
    Dim myDataSet As System.Data.DataSet
    Dim LastRow As Integer
    Dim LastCol As Integer
    Dim SummaryGroup As DataTable
    Dim MainGroup As DataTable
    Dim SubGroup As DataTable


    Private Sub CreateDataSet()

        Dim dtStr As System.Type
        Dim dtInt As System.Type
        dtStr = System.Type.GetType("System.String")
        dtInt = System.Type.GetType("System.Int32")

        myDataSet = New DataSet()
        myDataSet.EnforceConstraints = False

        SummaryGroup = myDataSet.Tables.Add("SummaryGroup")
        SummaryGroup.Columns.AddRange(New DataColumn() {New DataColumn("Summary Group", dtStr), New DataColumn("id", dtStr), New DataColumn("_", dtStr), New DataColumn("Bank", dtStr), New DataColumn("Bank Type", dtStr), New DataColumn("Units", dtStr), New DataColumn("Material HQ", dtInt), New DataColumn("Material RL", dtInt), New DataColumn("Labor", dtInt), New DataColumn("Subcontracted Labor", dtInt), New DataColumn("Freight", dtInt), New DataColumn("NPS", dtInt), New DataColumn("Sales Commission", dtInt), New DataColumn("Project Manager", dtInt), New DataColumn("Expenses", dtInt), New DataColumn("Permits", dtInt), New DataColumn("Bonds", dtInt), New DataColumn("OCPL", dtInt), New DataColumn("Tax", dtInt), New DataColumn("Bank Cost", dtInt), New DataColumn("Project Markup", dtInt), New DataColumn("Bank Price", dtInt), New DataColumn("BDP Hours", dtInt), New DataColumn("Special Hours", dtInt), New DataColumn("Overtime Hours", dtInt), New DataColumn("Total Hours", dtInt), New DataColumn("Comment", dtStr)})

        SummaryGroup.Rows.Add(New Object() {"Summary", "A1", "", "A", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        SummaryGroup.Rows.Add(New Object() {"Summary", "B1", "", "B", "Geared", "01-04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        SummaryGroup.Rows.Add(New Object() {"Summary", "F1", "", "F", "Gearless", "01,03,04", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})


        MainGroup = myDataSet.Tables.Add("BaseGroup")
        MainGroup.Columns.AddRange(New DataColumn() {New DataColumn("Base Group", dtStr), New DataColumn("id", dtStr), New DataColumn("bank", dtStr), New DataColumn("units", dtStr), New DataColumn("machine", dtStr), New DataColumn("target", dtInt), New DataColumn("bid", dtStr), New DataColumn("award", dtStr), New DataColumn("comment", dtStr)})

        'MainGroup.Rows.Add(New Object() {"Master", "A0", "A", "01-04", "Geared", 497250, "", "", ""})
        MainGroup.Rows.Add(New Object() {"Base", "A1", "A", "01-04", "Geared", 500000, "", "", ""})
        MainGroup.Rows.Add(New Object() {"Base", "B1", "B", "01-04", "Geared", 375000, "", "", ""})
        MainGroup.Rows.Add(New Object() {"Base", "F1", "F", "01,03-04", "Gearless", 0, "", "", ""})

        SubGroup = myDataSet.Tables.Add("SubGroup")
        SubGroup.Columns.AddRange(New DataColumn() {New DataColumn("Sub Group", dtStr), New DataColumn("id", dtStr), New DataColumn("units", dtStr), New DataColumn("machine", dtStr), New DataColumn("target", dtStr), New DataColumn("bid", dtStr), New DataColumn("Bid", dtStr), New DataColumn("Offer", dtStr), New DataColumn("comment", dtStr)})
        SubGroup.Rows.Add(New Object() {"Alt1", "A1", "01-04", "Geared", 25000, "", "", "", "Lorem Ipsum is simply dummy text of the printing and typesetting industry."})
        SubGroup.Rows.Add(New Object() {"Alt2", "A1", "01-04", "Geared", -5000, -4000, True, "", "Lorem ipsam voluptatem quia volupta. "})
        SubGroup.Rows.Add(New Object() {"Alt3", "A1", "01-04", "Geared", -2500, "", "", "", "Lorem ipsum dolor delectus error voluptatem neque."})
        SubGroup.Rows.Add(New Object() {"Alt4", "A1", "01-04", "Geared", 1250, "", "True", "", "Lorem ipsum dolor sit amet, consectetur adipisicing elit."})
        SubGroup.Rows.Add(New Object() {"Alt1", "B1", "01-04", "Geared", 5000, "", "", "", "Lorem ipsum dolor sit amet, consectetur adipisicing elit."})
        SubGroup.Rows.Add(New Object() {"Alt2", "B1", "01-04", "Geared", -2000, "", "", "", ""})

        'Add the relations
        myDataSet.Relations.Add("MainGroup", SummaryGroup.Columns("Bank"), MainGroup.Columns("bank"))
        myDataSet.Relations.Add("BaseGroup", MainGroup.Columns("id"), SubGroup.Columns("id"))

    End Sub


    Private Sub _Forms_btn_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _Forms_btn_2.Click
        frmEstimatingBase.Show()
        Me.Hide()
    End Sub

    Private Sub CM_MAIN_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ShiftDist As Single = (Me.Width - BuildingInformation_fra.Width) / 2

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

        Dim cbstr As String()
        cbstr = New String() {"Geared", "Gearless", "Hydro"}
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell.Items = cbstr
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 3

        For i As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
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
            FpSpread1.ActiveSheet.Cells(i, 8).Column.Width = 60         'labor
            FpSpread1.ActiveSheet.Cells(i, 9).Column.Width = 80         'subcontracted_labor
            FpSpread1.ActiveSheet.Cells(i, 10).Column.Width = 60        'freight
            FpSpread1.ActiveSheet.Cells(i, 11).Column.Width = 60        'nps
            FpSpread1.ActiveSheet.Cells(i, 12).Column.Width = 70        'sales commission
            FpSpread1.ActiveSheet.Cells(i, 13).Column.Width = 60        'project manager
            FpSpread1.ActiveSheet.Cells(i, 14).Column.Width = 60        'expenses
            FpSpread1.ActiveSheet.Cells(i, 15).Column.Width = 70        'permits
            FpSpread1.ActiveSheet.Cells(i, 16).Column.Width = 60        'bonds
            FpSpread1.ActiveSheet.Cells(i, 17).Column.Width = 60        'ocpl
            FpSpread1.ActiveSheet.Cells(i, 18).Column.Width = 60        'tax
            FpSpread1.ActiveSheet.Cells(i, 19).Column.Width = 60        'bank cost
            FpSpread1.ActiveSheet.Cells(i, 20).Column.Width = 60        'project markup
            FpSpread1.ActiveSheet.Cells(i, 21).Column.Width = 60        'bank price
            FpSpread1.ActiveSheet.Cells(i, 22).Column.Width = 50        'bdp hours
            FpSpread1.ActiveSheet.Cells(i, 23).Column.Width = 50        'special hours
            FpSpread1.ActiveSheet.Cells(i, 24).Column.Width = 55        'overtime hours
            FpSpread1.ActiveSheet.Cells(i, 25).Column.Width = 50        'total hours
            FpSpread1.ActiveSheet.Cells(i, 26).Column.Width = 160        'comment

            FpSpread1.ActiveSheet.Cells(i, 4).CellType = cmbocell       ' machine/bank type

            For j As Integer = 6 To 21
                FpSpread1.ActiveSheet.Cells(i, j).CellType = currencyType
            Next

            FpSpread1.ActiveSheet.Columns(1).Visible = False
            FpSpread1.ActiveSheet.ColumnHeader.Rows(0).Height = 35


            'FpSpread1.ActiveSheet.Cells(i, 25).BackColor = Color.LightGray
        Next

        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If ChildSheetView1.RowCount = 0 Then
                ChildSheetView1.SetRowExpandable(iIndex, False)
            End If
            If Not ChildSheetView1 Is Nothing Then
                For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                    If Not ChildSheetView2 Is Nothing Then
                        ChildSheetView2.SetColumnVisible(1, False)
                        'If ChildSheetView2.RowCount = 0 Then
                        '    ChildSheetView1.SetRowExpandable(jindex, False)
                        'End If
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
        Dim p As New FarPoint.Win.Picture(Image.FromFile("\images\openned.png"), FarPoint.Win.RenderStyle.Normal)
        t.BackgroundImage = p
        Dim p1 As New FarPoint.Win.Picture(Image.FromFile("\images\openned.png"), FarPoint.Win.RenderStyle.Normal)

        ' Apply the text cell.
        FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
        t1.BackgroundImage = p1
        FpSpread1.ActiveSheet.Cells(1, 2).CellType = t1
        ' Set the size of the cell so the image is displayed
        'FpSpread1.ActiveSheet.Rows(1).Height = 50
        'FpSpread1.ActiveSheet.Columns(1).Width = 150


    End Sub

    Private Sub FpSpread1_ChildControlActivated(sender As Object, e As FarPoint.Win.Spread.ChildControlEventArgs) Handles FpSpread1.ChildControlActivated

        Stop

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

        If e.SheetView.ParentRelationName = "MainGroup" Then
            With e.SheetView
                .RowHeader.AutoText = False
                .DataAutoCellTypes = False
                .DataAutoSizeColumns = False
                '   .ColumnHeader.Rows(0).Height = 25

                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False

                .Columns(0).Locked = True
                .Columns(5).Locked = True
                .Columns(7).Locked = True

                .SetColumnWidth(0, 100)
                .SetColumnWidth(3, 75)
                .SetColumnWidth(4, 75)
                .SetColumnWidth(5, 75)
                .SetColumnWidth(6, 75)
                .SetColumnWidth(7, 75)
                .SetColumnWidth(8, 375)

                .Columns(5).CellType = currencyType
                .Columns(6).CellType = currencyType
                .Columns(7).CellType = currencyType


                .HorizontalGridLine = gl
                .VerticalGridLine = gl
            End With
        Else
            With e.SheetView

                .DataAutoCellTypes = False
                .DataAutoSizeColumns = False
                '   .ColumnHeader.Rows(0).Height = 25

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
                .SetColumnWidth(8, 375)

                .Columns(4).CellType = currencyType
                .Columns(5).CellType = currencyType
                .Columns(6).CellType = ckbxcell
                .Columns(7).CellType = ckbxcell

                .Columns(5).BackColor = Color.LightGoldenrodYellow
                .Columns(6).BackColor = Color.LightGoldenrodYellow
                .Columns(7).BackColor = Color.LightGoldenrodYellow
                .Columns(8).BackColor = Color.LightGoldenrodYellow


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


    Private Sub btnMerge_Click(sender As System.Object, e As System.EventArgs) Handles btnMerge.Click

        Dim active_row As Array
        Dim new_message As String = "You are about to merge data for Bank A."
        Dim update_message As String = "You are about to update 'Master' data for Bank A.  All current data for the Master will be overwritten."

        If MainGroup.Rows.Count < 4 Then
            If MessageBox.Show(new_message, "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                'active_row = FindActiveRows()
                MainGroup.Rows.Add(New Object() {"Master", "A0", "A", "01-04", "Geared", 496250, "", "", ""})
                Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
                ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(0, 0)
                ChildSheetView1.SortRows(1, True, True)
                ChildSheetView1.SetRowExpandable(0, False)

                ChildSheetView1.Cells(0, 6).Locked = True
                ChildSheetView1.Cells(0, 6).BackColor = Color.LightGray

                ChildSheetView1.Cells(0, 7).Locked = False
                ' ChildSheetView1.Cells(0, 7).BackColor = Color.White

                Dim p As New FarPoint.Win.Picture(Image.FromFile("\images\circlechecked.png"), FarPoint.Win.RenderStyle.Normal)
                Dim t As New FarPoint.Win.Spread.CellType.TextCellType
                t.BackgroundImage = p
                ' Apply the text cell.
                FpSpread1.ActiveSheet.Cells(0, 2).CellType = t
            End If
        Else
            MessageBox.Show(update_message, "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        End If

        'FpSpread1.ActiveSheet.LockBackColor = Color.LightCyan
        'FpSpread1.ActiveSheet.LockForeColor = Color.Green
        'FpSpread1.ActiveSheet.Columns[0, 3].Locked = True
        'FpSpread1.ActiveSheet.Cells[1,1,1,2].Locked = False


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


    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

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
        printset.orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        printset.zoomfactor = 0.65
        printset.BestFitCols = True

        printset.PdfWriteMode = FarPoint.Win.Spread.PdfWriteMode.Append

        ' assign the printer settings and print
        '''FpSpread1.Sheets().Printinfo = printset


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

    Private Sub btnAddAlt_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAlt.Click

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

        SubGroup.Rows.Add(New Object() {thisID, baseID, units, machine, 0, "", "", "", ""})

    End Sub

    Private Sub btnAddBank_Click(sender As System.Object, e As System.EventArgs) Handles btnAddBank.Click
        ' Add a new summary row to the grid
        ' Add a new base row to the grid

        Dim currencyType As New FarPoint.Win.Spread.CellType.CurrencyCellType()
        currencyType.Separator = ","
        currencyType.DecimalPlaces = 0
        currencyType.ShowSeparator = True
        currencyType.NegativeFormat = FarPoint.Win.Spread.CellType.CurrencyNegativeFormat.SignSymbolSpaceBefore
        currencyType.NegativeRed = True



        SummaryGroup.Rows.Add(New Object() {"Summary", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        FpSpread1.Refresh()
        FpSpread1.ActiveSheet.ActiveRowIndex = FpSpread1.ActiveSheet.RowCount - 1
        FpSpread1.ActiveSheet.ActiveRow.Locked = True

        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Locked = False
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 5).Locked = False

        For i As Integer = 6 To 21
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, i).CellType = currencyType
        Next

        Dim cbstr As String()
        cbstr = New String() {"Geared", "Gearless", "Hydro"}
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        cmbocell.Items = cbstr
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 3
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).CellType = cmbocell

        Dim valid As Boolean = False

        FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 3, False)


        FpSpread1.Refresh()
    End Sub

    Private Function ValidBank() As Boolean
        Dim valid As Boolean = False

        Dim cell_value As String
        cell_value = FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Value.ToString.ToUpper
        FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 3).Value = cell_value

        If cell_value = "" Then
            MessageBox.Show("You must enter a Bank", "Please enter the Bank")
            valid = False
        ElseIf BankExists(cell_value) Then
            MessageBox.Show("The Bank you entered already exists", "Duplicated Bank")
            valid = False
        Else
            FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 1).Value = cell_value + "1"
            valid = True
        End If

        Return valid
    End Function

    Private Function BankExists(cell_value As String) As Boolean

        Dim bank_exists As Boolean = False

        'With FpSpread1.ActiveSheet
        '    For i As Integer = 0 To .RowCount - 1 'Assuming the new row is on the last row, and should not be interrogated
        '        If .Cells(i, 3).Value = cell_value Then
        '            bank_exists = True
        '            Exit For
        '        End If
        '    Next
        'End With

        Return bank_exists
    End Function

    Private Sub FpSpread1_Click(sender As Object, e As System.EventArgs) Handles FpSpread1.Click

        Stop

    End Sub

    Private Sub FpSpread1_LeaveCell(sender As Object, e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpSpread1.LeaveCell

        Select e.Column
            Case 3          ' bank
                If Not ValidBank() Then
                    e.Cancel = True
                End If
                FpSpread1.ActiveSheet.SetActiveCell(FpSpread1.ActiveSheet.ActiveRowIndex, 4, False)
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
                    FpSpread1.ActiveSheet.SortRows(3, True, True)
                    FpSpread1.Refresh()
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

        If Not ValidBank() Then
            isValid = False
        End If

        If IsNothing(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Value) Or FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 4).Value.ToString.Trim = "" Then
            MessageBox.Show("Please select a machine.", "Missing Data")
            isValid = False
        End If

        If Not validUnits() Then
            isValid = False
        End If

        Return isValid

    End Function



    Private Sub btnDeleteAlt_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteAlt.Click

        Dim activeRows As Array
        activeRows = FindActiveRows()

        MsgBox("ActiveIndexRow: " & FpSpread1.ActiveSheet.ActiveRowIndex & vbCrLf & _
               "Summary Row:  " & activeRows(0) & vbCrLf & _
               "Base Row: " & activeRows(1) & vbCrLf & _
               "Alt row:  " & activeRows(2))

        If activeRows(2) = -1 Then
            MessageBox.Show("Please click on the Target Column of the  Alternate Row you wish to delete", "Cannot Determine Which Alternate Row Selected!")
        Else
            DeleteAltRow(activeRows)
        End If
        'Stop


    End Sub

    Private Sub DeleteAltRow(activeRows As Array)
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
                    MessageBox.Show(ex.Message, "Cannot Delete the Row")
                End Try
                End If
        End If

    End Sub

    Private Sub btnDeleteBank_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteBank.Click
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
            MessageBox.Show(ex.Message, "Cannot Delete the Row")
        End Try
    End Sub

    Private Sub AlsPrint()

        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        Dim ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing

        Dim iIndex As Integer
        Dim jIndex As Integer

        For iIndex = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not IsNothing(ChildSheetView1) Then

            End If

        Next
    End Sub

    Private Sub btnDeleteMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteMaster.Click
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing
        ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(0, 0)
        If ChildSheetView1.RowCount > 1 Then
            ChildSheetView1.RemoveRows(0, 1)
        End If

    End Sub
End Class
