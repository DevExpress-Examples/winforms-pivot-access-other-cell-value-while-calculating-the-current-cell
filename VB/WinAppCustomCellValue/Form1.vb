Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace WinAppCustomCellValue
    Partial Public Class Form1
        Inherits Form

        Private fieldPercentOfBeverages As PivotGridField
        Private beveragesValue As Object = "Beverages"

        Public Sub New()
            InitializeComponent()
            salesPersonTableAdapter1.Fill(nwindDataSet1.SalesPerson)

            ' Creates and specifies a 'Percent' field.
            fieldPercentOfBeverages = pivotGridControl1.Fields.Add("Extended Price", PivotArea.DataArea)
            fieldPercentOfBeverages.Caption = "Percent"
            fieldPercentOfBeverages.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            fieldPercentOfBeverages.CellFormat.FormatString = "P"
        End Sub

        Private Sub pivotGridControl1_CustomCellValue(ByVal sender As Object,
                        ByVal e As PivotCellValueEventArgs) Handles pivotGridControl1.CustomCellValue
            ' Calculates 'Percent' field values.
            If Object.ReferenceEquals(e.DataField, fieldPercentOfBeverages) Then
                Dim columnPath() As Object = GetValues(e, True, fieldCategoryName, "Beverages")
                Dim rowPath() As Object = GetValues(e, False, fieldCategoryName, "Beverages")
                Dim beveragesValue As Decimal =
                    Convert.ToDecimal(e.GetCellValue(columnPath, rowPath, e.DataField))
                If beveragesValue = 0 Then
                    e.Value = Nothing
                Else
                    e.Value = Convert.ToDecimal(e.Value) / beveragesValue
                End If
            Else
                Return
            End If
        End Sub

        Private Function GetValues(ByVal e As PivotCellValueEventArgs,
                                   ByVal isColumn As Boolean,
                                   ByVal targetField As PivotGridField,
                                   ByVal targetValue As Object) As Object()
            Dim fields() As PivotGridField = If(isColumn, e.GetColumnFields(), e.GetRowFields())
            Dim targetPath(fields.Length - 1) As Object
            For i As Integer = 0 To targetPath.Length - 1
                If Object.ReferenceEquals(fields(i), targetField) Then
                    targetPath(i) = targetValue
                Else
                    targetPath(i) = e.GetFieldValue(fields(i))
                End If
            Next i
            Return targetPath
        End Function
    End Class
End Namespace
