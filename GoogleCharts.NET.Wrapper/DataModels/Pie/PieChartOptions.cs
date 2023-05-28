using GoogleCharts.NET.Wrapper.DataModels.Interfaces;

namespace GoogleCharts.NET.Wrapper.DataModels.Pie
{
	public class PieChartOptions : ChartOptions
	{
		public string Title { get; set; }
		public double SliceVisibilityThreshold { get; set; }
	}
}
