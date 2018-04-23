Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication3
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim dt As New DataTable()
			dt.Columns.Add("Customer")
			dt.Columns.Add("Group")
			dt.Columns.Add("Amount", GetType(Decimal))

			dt.Rows.Add(New Object() { "A", "Group1", 500 })
			dt.Rows.Add(New Object() { "B", "Group2", 200 })
			dt.Rows.Add(New Object() { "C", "Group3", 100 })
			dt.Rows.Add(New Object() { "D", "Group4", 300 })

			pivotGridControl1.Fields.Add("Customer", PivotArea.FilterArea)
			pivotGridControl1.Fields.Add("Group", PivotArea.RowArea)
			pivotGridControl1.Fields.Add("Amount", PivotArea.DataArea)
			Dim f As PivotGridField = pivotGridControl1.Fields.Add("Percent", PivotArea.DataArea)
			f.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
			f.Caption = "1st line percent"
			f.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			f.CellFormat.FormatString = "P"

			AddHandler pivotGridControl1.CustomCellValue, AddressOf pivotGridControl1_CustomCellValue

			pivotGridControl1.DataSource = dt
		End Sub

		Private Sub pivotGridControl1_CustomCellValue(ByVal sender As Object, ByVal e As PivotCellValueEventArgs)
			If e.DataField.FieldName <> "Percent" Then
				Return
			End If
			Dim datafield As PivotGridField = pivotGridControl1.Fields("Amount")
			Dim first As PivotGridField = pivotGridControl1.Fields("Group")
			Try
				Dim v As Decimal = CDec(e.GetCellValue(datafield))
				Dim d As Decimal = CDec(e.GetCellValue(GetValues(e.GetColumnFields(), e, first, "Group1"), GetValues(e.GetRowFields(), e, first, "Group1"), datafield))
				If d = 0 Then
					e.Value = Nothing
				Else
					e.Value = v / d
				End If
			Catch
			End Try
		End Sub

		Private Function GetValues(ByVal fields() As PivotGridField, ByVal e As PivotCellBaseEventArgs, ByVal first As PivotGridField, ByVal value As Object) As Object()
			Dim v(fields.Length - 1) As Object
			For i As Integer = 0 To v.Length - 1
				If fields(i) Is first Then
					v(i) = value
				Else
					v(i) = e.GetFieldValue(fields(i))
				End If
			Next i
			Return v
		End Function

	End Class
End Namespace