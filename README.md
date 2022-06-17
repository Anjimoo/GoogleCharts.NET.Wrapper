# GoogleCharts.NET.Wrapper 2.0.0

Available charts :
- Timeline
- Gantt
- Columns

## How to start :

### 1. Add scripts to head of index.html:
```
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript" src="/_content/GoogleCharts.NET.Wrapper/js/GoogleChartsWrapper.js"></script>
```
### 2. Add imports to _Imports.razor file
```
@using GoogleCharts.NET.Wrapper
@using GoogleCharts.NET.Wrapper.DataModels
@using GoogleCharts.NET.Wrapper.DataModels.Timeline
@using GoogleCharts.NET.Wrapper.DataModels.Gantt
@using GoogleCharts.NET.Wrapper.DataModels.Column
@using GoogleCharts.NET.Wrapper.Components
```
## How to use:

```
@if (@Gantt != null)
{
  <GoogleChart DataTable="@Gantt"></GoogleChart>
}

@code {
  public DataTable<DataTableGanttRow> Gantt { get; set; }
 
  protected override async Task OnInitializedAsync()
  {
    //create Instance of DataTable with provided ID
    Gantt = await DataTable<DataTableGanttRow>.CreateAsync(jsRuntime, "myid");
    //add specific options to current chart
	  await Gantt.AddOptions(new GanttOptions
		  {
			  Height = 300,
			  Gantt = new Gantt
			  {
				  TrackHeight = 50,
				  BarHeight = 48
			  }
		  }
		 );
    //add data to chart
	  Gantt.AddRow(new DataTableGanttRow
		  {
			  TaskId = "2014Spring",
			  TaskName = "Spring 2014",
			  Resource = "spring",
			  StartDate = new DateTime(2014, 2, 22),
			  EndDate = new DateTime(2014, 5, 20),
			  Duration = null,
			  PercentComplete = 100,
			  Dependencies = null
		  });
	  Gantt.AddRow(new DataTableGanttRow
		  {
			  TaskId = "2014Summer",
		  	TaskName = "Summer 2014",
		  	Resource = "summer",
				StartDate = new DateTime(2014, 5, 21),
				EndDate = new DateTime(2014, 8, 20),
				Duration = null,
				PercentComplete = 100,
				Dependencies = null
			});
		Gantt.AddRow(new DataTableGanttRow
			{
				TaskId = "2015Summer",
				TaskName = "Summer 2015",
				Resource = "summer",
				StartDate = new DateTime(2015, 5, 21),
				EndDate = new DateTime(2015, 8, 20),
				Duration = null,
				PercentComplete = 100,
				Dependencies = null
			});
		Gantt.AddRow(new DataTableGanttRow
			{
				TaskId = "2014Autumn",
				TaskName = "Autumn 2014",
				Resource = "autumn",
				StartDate = new DateTime(2014, 8, 21),
				EndDate = new DateTime(2014, 11, 20),
				Duration = null,
				PercentComplete = 100,
				Dependencies = null
			});
    //set call back function which will be called when you click on a chart
		await Gantt.SetCallbackFunctionName(DotNetObjectReference.Create(this), "ShowAlert", true);
    //draw the chart
		await Gantt.DrawChart();
	}

	[JSInvokable]
	public void ShowAlert()
	{
		Console.WriteLine("HOORAY");
	}
}
```

You can see more examples [here](https://github.com/Anjimoo/GoogleCharts.NET.Wrapper/tree/master/WrapperTest/Components)


