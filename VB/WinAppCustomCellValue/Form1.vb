Imports DevExpress.XtraEditors
Imports DevExpress.XtraPivotGrid
Imports System.Linq
Imports System

Namespace WinAppCustomCellValue
	Partial Public Class Form1
		Inherits XtraForm
	
		Public Sub New()
			InitializeComponent()
			salesPersonTableAdapter1.Fill(nwindDataSet1.SalesPerson)
			Dim fieldPercentOfBeverages As New PivotGridField() With {.FieldName = "Extended Price", .Area = PivotArea.DataArea, .Caption = "% Beverages", .Name = "PercentOfBeverages"}
			fieldPercentOfBeverages.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			fieldPercentOfBeverages.CellFormat.FormatString = "P"
			pivotGridControl1.Fields.Add(fieldPercentOfBeverages)
		End Sub

		Private Sub pivotGridControl1_CustomCellValue(ByVal sender As Object, ByVal e As PivotCellValueEventArgs) Handles pivotGridControl1.CustomCellValue
			' Calculates the 'Percent' field values.
			If e.DataField.Name = "PercentOfBeverages" Then
				' Do not display grand total values.
				If e.RowValueType = PivotGridValueType.GrandTotal Then
					e.Value = Nothing
					Return
				End If
				Dim rowValues = e.GetRowFields().Select(Function(f) If(f Is fieldCategoryName, "Beverages", e.GetFieldValue(f))).ToArray()
				Dim columnValues = e.GetColumnFields().Select(Function(f) If(f Is fieldCategoryName, "Beverages", e.GetFieldValue(f))).ToArray()
				Dim beveragesValue As Decimal = Convert.ToDecimal(e.GetCellValue(columnValues, rowValues, e.DataField))
				If beveragesValue = 0 Then
					e.Value = Nothing
				Else
					e.Value = Convert.ToDecimal(e.Value) / beveragesValue
				End If
			Else
				Return
			End If
		End Sub
	End Class
End Namespace
