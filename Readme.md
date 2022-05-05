<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581503/21.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1110)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WinAppCustomCellValue/Form1.cs) (VB: [Form1.vb](./VB/WinAppCustomCellValue/Form1.vb))
<!-- default file list end -->
# How to Use the Other Cell's Values in the Current Cell Value Calculation

This example calculates percentage based on the "Beverages" row value for each column.

![screenshot](./images/screenshot.png)

The application handles the [PivotGridControl.CustomCellValue](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomCellValue) event to display a calculated percentage value in the cell that belongs to the Percent column. The grand total values are hidden.

API in this example:

* [PivotGridControl.CustomCellValue](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomCellValue) event
* [e.GetRowFields](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.GetRowFields) method
* [e.GetColumnFields](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.GetColumnFields) method
* [e.GetFieldValue](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.GetFieldValue(-0)) method
* [e.GetCellValue](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.GetCellValue(System.Object---System.Object----0)) method
* [e.RowValueType](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.RowValueType) property
* [e.Value](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotCellEventArgsBase-3.Value) property

**See also:**

* [How to Display a Percent Difference from the Previous Parallel Period](https://github.com/DevExpress-Examples/getting-a-summary-value-for-a-previous-period-while-calculating-the-current-one-e2125)
