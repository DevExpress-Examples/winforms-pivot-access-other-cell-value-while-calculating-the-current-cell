using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System.Linq;
using System;

namespace WinAppCustomCellValue
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            salesPersonTableAdapter1.Fill(nwindDataSet1.SalesPerson);

            PivotGridField fieldPercentOfBeverages = new PivotGridField()
            {
                FieldName = "Extended Price",
                Area = PivotArea.DataArea,
                Caption = "% Beverages",
                Name = "PercentOfBeverages"
            };

            fieldPercentOfBeverages.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldPercentOfBeverages.CellFormat.FormatString = "P";
            pivotGridControl1.Fields.Add(fieldPercentOfBeverages);
        }

        private void pivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            // Calculates the 'Percent' field values.
            if (e.DataField.Name == "PercentOfBeverages")
            {
                // Do not display grand total values.
                if (e.RowValueType == PivotGridValueType.GrandTotal)
                {
                    e.Value = null;
                    return;
                }

                var rowValues = e.GetRowFields().Select(f => f.FieldName == "CategoryName" ? "Beverages" : e.GetFieldValue(f)).ToArray();
                var columnValues = e.GetColumnFields().Select(f => f.FieldName == "CategoryName" ? "Beverages" : e.GetFieldValue(f)).ToArray();
                decimal beveragesValue = Convert.ToDecimal(e.GetCellValue(columnValues, rowValues, e.DataField));
                if (beveragesValue == 0)
                    e.Value = null;
                else
                    e.Value = Convert.ToDecimal(e.Value) / beveragesValue;
            }
            else return;
        }
    }
}
