Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)
    Dim myDataSet As System.Data.DataSet

    'Data Types
    Private dtStr As System.Type = System.Type.GetType("System.String")
    Private dtInt As System.Type = System.Type.GetType("System.Int32")

    Public Structure a_SheetHeaders_typ
        Dim HeaderDesc As String
        Dim HeaderType As System.Type
        Public Shared Function CreateInstance() As a_SheetHeaders_typ
            Dim result As New a_SheetHeaders_typ
            result.HeaderDesc = String.Empty
            Return result
        End Function
    End Structure
    Private SheetHeaders(,) As a_SheetHeaders_typ
    Public Const TotalMaterialColumns As Integer = 11
    Public Const MAIN_COL_MAIN_GROUP As Integer = 1
    Public Const MAIN_COL_MAIN_ID As Integer = 2
    Public Const MAT_COL_MATERIAL_DESC As Integer = 1
    Public Const MAT_COL_MAIN_ID As Integer = 2
    Public Const MAT_COL_MATERIAL_ID As Integer = 3
    Public Const MAT_COL_UNITS As Integer = 4
    Public Const MAT_COL_OPTION As Integer = 5
    Public Const MAT_COL_TYPE As Integer = 6
    Public Const MAT_COL_ORDER_BY As Integer = 7
    Public Const MAT_COL_QTY As Integer = 8
    Public Const MAT_COL_MATERIAL_COST As Integer = 9
    Public Const MAT_COL_STANDARD_HOURS As Integer = 10
    Public Const MAT_COL_SPECIAL_HOURS As Integer = 11

    Public Structure a_MainGroup_typ
        Dim MainID As String
        Dim Description As String
        Dim Units As String
        Public Shared Function CreateInstance() As a_MainGroup_typ
            Dim result As New a_MainGroup_typ
            result.MainID = String.Empty
            result.Description = String.Empty
            result.Units = String.Empty
            Return result
        End Function
    End Structure
    Public a_MainGroup() As a_MainGroup_typ

    Public Structure a_MaterialGroup_typ
        Dim Description As String
        Dim MainID As String
        Dim MaterialID As String
        Dim OptionStr As String
        Dim Type As String
        Dim OrderBy As String
        Dim Qty As Integer
        Dim Units As String
        Dim MaterialCost As Single
        Dim StandardHours As Integer
        Dim SpecialHours As Integer
        Public Shared Function CreateInstance() As a_MaterialGroup_typ
            Dim result As New a_MaterialGroup_typ
            result.MainID = String.Empty
            result.MaterialID = String.Empty
            result.Description = String.Empty
            result.OptionStr = String.Empty
            result.Type = String.Empty
            result.OrderBy = String.Empty
            result.Units = String.Empty
            Return result
        End Function
    End Structure
    Public a_MaterialGroup() As a_MaterialGroup_typ

    Public Const MAIN_GROUP As Integer = 1
    Public Const MATERIAL_GROUP As Integer = 2
    Private CurrentGenInfoFrameHeight As Integer = 0, CurrentBillofMaterialsandTaskListFrameHeight As Integer = 0

    Private Sub CreateDataSet()
        Dim MainGroups As DataTable = Nothing
        Dim SubGroups As DataTable = Nothing
        Dim iIndex As Integer = -1, jIndex As Integer = 0, kIndex As Integer
        Dim HeaderSetup() As System.Data.DataColumn = Nothing
        Dim MaterialItemRecordSet As New ADODB.Recordset
        Dim CurMainID As String = String.Empty

        DAO2ADO(ADOConnectionOptionDataBase, ADOCatalogOptionDataBase, My.Application.Info.DirectoryPath & "\", OPTION_DATABASE_NAME, True)
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, OPEN_RECORD, "GROUP_SETUP_QRY")

        myDataSet = New DataSet()
        myDataSet.EnforceConstraints = False

        Erase SheetHeaders
        ReDim SheetHeaders(MATERIAL_GROUP, TotalMaterialColumns)

        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderDesc = "Main Group"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderDesc = "MainID"
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_GROUP).HeaderType = dtStr
        SheetHeaders(MAIN_GROUP, MAIN_COL_MAIN_ID).HeaderType = dtStr

        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderDesc = "Material Description"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderDesc = "MainID"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderDesc = "MaterialID"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderDesc = "Units"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderDesc = "Option"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderDesc = "Type"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderDesc = "Order By"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderDesc = "Qty"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderDesc = "Material Cost"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderDesc = "Standard Hours"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderDesc = "Special Hours"
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_DESC).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MAIN_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_ID).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_UNITS).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_OPTION).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_TYPE).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_ORDER_BY).HeaderType = dtStr
        SheetHeaders(MATERIAL_GROUP, MAT_COL_QTY).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_MATERIAL_COST).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_STANDARD_HOURS).HeaderType = dtInt
        SheetHeaders(MATERIAL_GROUP, MAT_COL_SPECIAL_HOURS).HeaderType = dtInt

        Dim Action As Integer = MOVE_FIRST
        Do Until Query_Execute(ADOConnectionRPTDataDB, MaterialItemRecordSet, 1, Action) <> 0
            If MaterialItemRecordSet.Fields("MainID").Value.ToString.Trim <> CurMainID Then
                CurMainID = MaterialItemRecordSet.Fields("MainID").Value.ToString.Trim
                iIndex += 1
                ReDim Preserve a_MainGroup(iIndex)
            End If
            a_MainGroup(iIndex).MainID = CurMainID
            a_MainGroup(iIndex).Description = MaterialItemRecordSet.Fields("Main Group").Value.ToString.Trim
            a_MainGroup(iIndex).Units = "01-03"

            ReDim Preserve a_MaterialGroup(jIndex)
            a_MaterialGroup(jIndex).MainID = CurMainID
            a_MaterialGroup(jIndex).MaterialID = MaterialItemRecordSet.Fields("MaterialID").Value.ToString.Trim
            a_MaterialGroup(jIndex).Description = MaterialItemRecordSet.Fields("Material Description").Value.ToString.Trim
            a_MaterialGroup(jIndex).Units = "01-03"
            a_MaterialGroup(jIndex).OptionStr = String.Empty
            a_MaterialGroup(jIndex).Type = String.Empty
            a_MaterialGroup(jIndex).OrderBy = String.Empty
            a_MaterialGroup(jIndex).Qty = 0
            a_MaterialGroup(jIndex).MaterialCost = 0
            a_MaterialGroup(jIndex).StandardHours = 0
            a_MaterialGroup(jIndex).SpecialHours = 0
            jIndex += 1

            Action = MOVE_NEXT
        Loop
        Query_Execute(ADOConnectionOptionDataBase, MaterialItemRecordSet, 1, CLOSE_RECORD)

        For iIndex = 1 To SheetHeaders.GetUpperBound(0)
            Erase HeaderSetup
            kIndex = 0
            For jIndex = 1 To TotalMaterialColumns
                If Not String.IsNullOrEmpty(SheetHeaders(iIndex, jIndex).HeaderDesc) Then
                    ReDim Preserve HeaderSetup(kIndex)
                    HeaderSetup(kIndex) = New DataColumn(SheetHeaders(iIndex, jIndex).HeaderDesc, SheetHeaders(iIndex, jIndex).HeaderType)
                    kIndex += 1
                End If
            Next jIndex
            Select Case iIndex
                Case MAIN_GROUP
                    MainGroups = myDataSet.Tables.Add("EstMainGroup")
                    MainGroups.Columns.AddRange(HeaderSetup)
                    For jIndex = a_MainGroup.GetLowerBound(0) To a_MainGroup.GetUpperBound(0)
                        MainGroups.Rows.Add(New Object() {a_MainGroup(jIndex).Description, a_MainGroup(jIndex).MainID})
                    Next jIndex
                Case MATERIAL_GROUP
                    SubGroups = myDataSet.Tables.Add("EstMaterials")
                    SubGroups.Columns.AddRange(HeaderSetup)
                    For jIndex = a_MaterialGroup.GetLowerBound(0) To a_MaterialGroup.GetUpperBound(0)
                        SubGroups.Rows.Add(New Object() {a_MaterialGroup(jIndex).Description, a_MaterialGroup(jIndex).MainID, a_MaterialGroup(jIndex).MaterialID,
                                                         a_MaterialGroup(jIndex).Units, a_MaterialGroup(jIndex).OptionStr, a_MaterialGroup(jIndex).Type,
                                                         a_MaterialGroup(jIndex).OrderBy, a_MaterialGroup(jIndex).Qty, a_MaterialGroup(jIndex).MaterialCost,
                                                         a_MaterialGroup(jIndex).StandardHours, a_MaterialGroup(jIndex).SpecialHours})
                    Next jIndex
                    Exit For
                Case Else
            End Select
        Next iIndex

        myDataSet.Relations.Add("EstMaterials", MainGroups.Columns("MainID"), SubGroups.Columns("MainID"))

    End Sub
    Private Sub frmEstimatingBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

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
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            .RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
            .SheetCornerStyle.BackColor = Color.DarkGray
            .SetColumnWidth(0, 150)
            .SetColumnVisible(1, False)
            .GrayAreaBackColor = Color.White
        End With
        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - TabControl1.Left - 5
        GeneralInformation_fra.Left = 6
        GeneralInformation_fra.Width = GroupBox1.Width - GeneralInformation_fra.Left - 10
        CurrentGenInfoFrameHeight = GeneralInformation_fra.Height
        BillofMaterialsandTaskList_fra.Left = 6
        BillofMaterialsandTaskList_fra.Width = GroupBox1.Width - BillofMaterialsandTaskList_fra.Left - 10
        CurrentBillofMaterialsandTaskListFrameHeight = BillofMaterialsandTaskList_fra.Height
        Relocate_BillofMaterialsandTaskList_Frame()
        FpSpread1.Left = 6
        'FpSpread1.Width = GroupBox1.Width - FpSpread1.Left - 10
        FpSpread1.Visible = False
        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        Dim Options As String() = New String() {"Option1", "Option2", "Option3"}
        Dim Options_cmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Options_cmb.Items = Options
        Options_cmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        Options_cmb.Editable = False
        Options_cmb.MaxDrop = Options.Length

        Dim Types As String() = New String() {"Type1", "Type2", "Type3"}
        Dim Types_cmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        Types_cmb.Items = Types
        Types_cmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        Types_cmb.Editable = False
        Types_cmb.MaxDrop = Types.Length

        Dim OrderBys As String() = New String() {"HQ", "RL"}
        Dim OrderBys_cmb As New FarPoint.Win.Spread.CellType.ComboBoxCellType()
        OrderBys_cmb.Items = OrderBys
        OrderBys_cmb.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        OrderBys_cmb.Editable = False
        OrderBys_cmb.MaxDrop = OrderBys.Length

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                ChildSheetView1.SetColumnWidth(0, 200)
                ChildSheetView1.SetColumnVisible(1, False)
                ChildSheetView1.SetColumnVisible(2, False)
                ChildSheetView1.SetColumnVisible(3, False)

                ChildSheetView1.SetColumnWidth(4, 100)
                ChildSheetView1.SetColumnWidth(5, 100)
                ChildSheetView1.SetColumnWidth(6, 100)
                For jIndex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView1.Cells(jIndex, 4).CellType = Options_cmb
                    ChildSheetView1.Cells(jIndex, 5).CellType = Types_cmb
                    ChildSheetView1.Cells(jIndex, 6).CellType = OrderBys_cmb
                Next jIndex

                ChildSheetView1.SetColumnWidth(8, 100)
                ChildSheetView1.SetColumnWidth(9, 100)
                ChildSheetView1.SetColumnWidth(10, 100)

                'For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                '    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                '    If Not ChildSheetView2 Is Nothing Then

                '        ChildSheetView2.SetColumnVisible(1, False)
                '    End If
                'Next jindex
            End If
        Next iIndex
        Button1.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")

    End Sub
    Private Sub FpSpread1_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs)

        e.SheetView.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        e.SheetView.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        e.SheetView.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        'Display child
        'e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).Font = fpFont
        'e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).ForeColor = Color.Black
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).Font = fpFont
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).BackColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).BackColor
        'e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).ForeColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).ForeColor
        e.SheetView.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        'e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).BackColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).BackColor
        'e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).ForeColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).ForeColor
        e.SheetView.SheetCornerStyle.BackColor = FpSpread1.ActiveSheet.SheetCornerStyle.BackColor
        e.SheetView.GrayAreaBackColor = Color.Gray
        e.SheetView.LockBackColor = Color.DarkGray
        'e.SheetView.SetColumnWidth(1, 110)
        'e.SheetView.SetColumnWidth(2, 110)
        'e.SheetView.SetColumnVisible(3, False)
        svCollection.Add(e.SheetView)

    End Sub
    Private Sub _IconButton_cmd_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_0.Click
        End
    End Sub
    Private Sub _IconButton_cmd_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_6.Click
        CM_MAIN_frm.Show()
        Me.Dispose()
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If GeneralInformation_fra.Height = Button1.Height + 2 Then
            GeneralInformation_fra.Height = CurrentGenInfoFrameHeight
            Button1.Image = Image.FromFile(ImageFileLocation & "\images\delete.png")
        Else
            GeneralInformation_fra.Height = Button1.Height + 2
            Button1.Image = Image.FromFile(ImageFileLocation & "\images\add.png")
        End If
        Relocate_BillofMaterialsandTaskList_Frame()

    End Sub
    Private Sub Relocate_BillofMaterialsandTaskList_Frame()

        BillofMaterialsandTaskList_fra.Top = GeneralInformation_fra.Top + GeneralInformation_fra.Height + 6
        If GeneralInformation_fra.Height = Button1.Height + 2 Then
            BillofMaterialsandTaskList_fra.Height += CurrentGenInfoFrameHeight - 20
        Else
            BillofMaterialsandTaskList_fra.Height = CurrentBillofMaterialsandTaskListFrameHeight
        End If

    End Sub
End Class
