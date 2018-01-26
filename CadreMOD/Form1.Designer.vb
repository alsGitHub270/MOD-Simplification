<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BillOfMaterials_spr = New FarPoint.Win.Spread.FpSpread()
        Me.BillOfMaterials_spr_Sheet1 = New FarPoint.Win.Spread.SheetView()
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BillOfMaterials_spr
        '
        Me.BillOfMaterials_spr.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.BillOfMaterials_spr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BillOfMaterials_spr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillOfMaterials_spr.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.BillOfMaterials_spr.Location = New System.Drawing.Point(-21, 131)
        Me.BillOfMaterials_spr.Name = "BillOfMaterials_spr"
        Me.BillOfMaterials_spr.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.BillOfMaterials_spr_Sheet1})
        Me.BillOfMaterials_spr.Size = New System.Drawing.Size(1039, 301)
        Me.BillOfMaterials_spr.TabIndex = 65
        Me.BillOfMaterials_spr.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'BillOfMaterials_spr_Sheet1
        '
        Me.BillOfMaterials_spr_Sheet1.Reset()
        Me.BillOfMaterials_spr_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.BillOfMaterials_spr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.BillOfMaterials_spr_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.BillOfMaterials_spr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 525)
        Me.Controls.Add(Me.BillOfMaterials_spr)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.BillOfMaterials_spr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillOfMaterials_spr_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BillOfMaterials_spr As FarPoint.Win.Spread.FpSpread
    Friend WithEvents BillOfMaterials_spr_Sheet1 As FarPoint.Win.Spread.SheetView
End Class
