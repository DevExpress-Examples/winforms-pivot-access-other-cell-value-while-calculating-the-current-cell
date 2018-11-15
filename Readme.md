<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication3/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication3/Form1.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to access other cell value while calculating the current cell


<p>This example shows how to calculate a percent of a current cell related to the first row value, regardless of the current sorting.</p>
<p>To accomplish this task, handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomCellValuetopic">PivotGridControl.CustomCellValue</a> event. To obtain a cell value, address it. Create arrays of row and column values corresponding to the desired cell, and call the GetCellValue method, passing them in arguments.</p>
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/E2125">Get summary values for previous period while calculating the current one</a></p>

<br/>


