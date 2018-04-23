using System;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace WinAppCustomCellValue
{
    public partial class Form1 : Form
    {
        PivotGridField fieldPercentOfBeverages;
        object beveragesValue = "Beverages";

        public Form1()
        {
            InitializeComponent();
            salesPersonTableAdapter1.Fill(nwindDataSet1.SalesPerson);

            // Creates and specifies a 'Percent' field.
            fieldPercentOfBeverages = pivotGridControl1.Fields.Add("Extended Price", 
                PivotArea.DataArea);
            fieldPercentOfBeverages.Caption = "Percent";
            fieldPercentOfBeverages.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldPercentOfBeverages.CellFormat.FormatString = "P";  
        }

        private void pivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            // Calculates 'Percent' field values.
            if (Object.ReferenceEquals(e.DataField, fieldPercentOfBeverages))
            {
                object[] columnPath = GetValues(e, true, fieldCategoryName, "Beverages");
                object[] rowPath = GetValues(e, false, fieldCategoryName, "Beverages");
                decimal beveragesValue = Convert.ToDecimal(e.GetCellValue(columnPath, 
                    rowPath, e.DataField));
                if (beveragesValue == 0)
                    e.Value = null;
                else
                    e.Value = Convert.ToDecimal(e.Value) / beveragesValue;
            }
            else return;
        }

        object[] GetValues(PivotCellValueEventArgs e, bool isColumn, PivotGridField targetField, 
            object targetValue)
        {
            PivotGridField[] fields = isColumn ? e.GetColumnFields() : e.GetRowFields();
            object[] targetPath = new object[fields.Length];
            for (int i = 0; i < targetPath.Length; i++)
            {
                if (object.ReferenceEquals(fields[i], targetField))
                    targetPath[i] = targetValue;
                else
                    targetPath[i] = e.GetFieldValue(fields[i]);
            }
            return targetPath;
        }
    }
}
