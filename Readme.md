# How to access other cell value while calculating the current cell


<p>This example shows how to calculate a percent of a current cell related to the first row value, regardless of the current sorting.</p>
<p>To accomplish this task, handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomCellValuetopic">PivotGridControl.CustomCellValue</a> event. To obtain a cell value, address it. Create arrays of row and column values corresponding to the desired cell, and call the GetCellValue method, passing them in arguments.</p>
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/E2125">Get summary values for previous period while calculating the current one</a></p>

<br/>


