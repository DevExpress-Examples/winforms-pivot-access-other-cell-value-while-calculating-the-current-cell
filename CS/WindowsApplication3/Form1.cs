using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace WindowsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Customer");
            dt.Columns.Add("Group");
            dt.Columns.Add("Amount", typeof(decimal));

            dt.Rows.Add(new object[] { "A", "Group1", 500 });
            dt.Rows.Add(new object[] { "B", "Group2", 200 });
            dt.Rows.Add(new object[] { "C", "Group3", 100 });
            dt.Rows.Add(new object[] { "D", "Group4", 300 });

            pivotGridControl1.Fields.Add("Customer", PivotArea.FilterArea);
            pivotGridControl1.Fields.Add("Group", PivotArea.RowArea);
            pivotGridControl1.Fields.Add("Amount", PivotArea.DataArea);
            PivotGridField f = pivotGridControl1.Fields.Add("Percent", PivotArea.DataArea);
            f.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;			
            f.Caption = "1st line percent";
            f.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            f.CellFormat.FormatString = "P";
			
            pivotGridControl1.CustomCellValue += new EventHandler<PivotCellValueEventArgs>(pivotGridControl1_CustomCellValue);

            pivotGridControl1.DataSource = dt;
        }

        void pivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            if (e.DataField.FieldName != "Percent") return;
            PivotGridField datafield = pivotGridControl1.Fields["Amount"];
            PivotGridField first = pivotGridControl1.Fields["Group"];
            try
            {
                decimal v = (decimal)(e.GetCellValue(datafield));
                decimal d = (decimal)e.GetCellValue(
                    GetValues(e.GetColumnFields(), e, first, "Group1"),
                    GetValues(e.GetRowFields(), e, first, "Group1"),
                    datafield);
                if (d == 0) 
                    e.Value =  null;
                else
                    e.Value = v / d;
            }
            catch { }
        }

        object[] GetValues(PivotGridField[] fields, PivotCellBaseEventArgs e, PivotGridField first, object value)
        {
            object[] v = new object[fields.Length];
            for (int i = 0; i < v.Length; i++)
            {
                if (fields[i] == first)
                    v[i] = value;
                else
                    v[i] = e.GetFieldValue(fields[i]);
            }
            return v;
        }

    }
}