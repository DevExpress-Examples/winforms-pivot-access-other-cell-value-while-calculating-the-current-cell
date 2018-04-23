Namespace WinAppCustomCellValue
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
            Me.nwindDataSet1 = New WinAppCustomCellValue.nwindDataSet()
            Me.fieldCountry = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldCategoryName = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldExtendedPrice = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.salesPersonTableAdapter1 = New WinAppCustomCellValue.nwindDataSetTableAdapters.SalesPersonTableAdapter()
            DirectCast(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' pivotGridControl1
            ' 
            Me.pivotGridControl1.DataMember = "SalesPerson"
            Me.pivotGridControl1.DataSource = Me.nwindDataSet1
            Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.fieldCountry, Me.fieldCategoryName, Me.fieldExtendedPrice})
            Me.pivotGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.pivotGridControl1.Name = "pivotGridControl1"
            Me.pivotGridControl1.OptionsView.ShowRowGrandTotals = False
            Me.pivotGridControl1.Size = New System.Drawing.Size(722, 259)
            Me.pivotGridControl1.TabIndex = 0
            ' 
            ' nwindDataSet1
            ' 
            Me.nwindDataSet1.DataSetName = "nwindDataSet"
            Me.nwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' fieldCountry
            ' 
            Me.fieldCountry.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
            Me.fieldCountry.AreaIndex = 0
            Me.fieldCountry.Caption = "Country"
            Me.fieldCountry.FieldName = "Country"
            Me.fieldCountry.Name = "fieldCountry"
            ' 
            ' fieldCategoryName
            ' 
            Me.fieldCategoryName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
            Me.fieldCategoryName.AreaIndex = 0
            Me.fieldCategoryName.Caption = "Category"
            Me.fieldCategoryName.FieldName = "CategoryName"
            Me.fieldCategoryName.Name = "fieldCategoryName"
            Me.fieldCategoryName.Width = 120
            ' 
            ' fieldExtendedPrice
            ' 
            Me.fieldExtendedPrice.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            Me.fieldExtendedPrice.AreaIndex = 0
            Me.fieldExtendedPrice.Caption = "Price"
            Me.fieldExtendedPrice.FieldName = "Extended Price"
            Me.fieldExtendedPrice.Name = "fieldExtendedPrice"
            ' 
            ' salesPersonTableAdapter1
            ' 
            Me.salesPersonTableAdapter1.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(722, 259)
            Me.Controls.Add(Me.pivotGridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
        Private nwindDataSet1 As nwindDataSet
        Private salesPersonTableAdapter1 As nwindDataSetTableAdapters.SalesPersonTableAdapter
        Private fieldCountry As DevExpress.XtraPivotGrid.PivotGridField
        Private fieldCategoryName As DevExpress.XtraPivotGrid.PivotGridField
        Private fieldExtendedPrice As DevExpress.XtraPivotGrid.PivotGridField
    End Class
End Namespace

