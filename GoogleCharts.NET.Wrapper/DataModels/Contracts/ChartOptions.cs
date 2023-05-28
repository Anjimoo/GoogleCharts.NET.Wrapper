namespace GoogleCharts.NET.Wrapper.DataModels.Interfaces
{
	public abstract class ChartOptions
	{
		/// <summary>
		/// Height of the chart, in pixels.
		/// Type: number
		/// Default: height of the containing element
		/// </summary>
		public double? Height { get; set; }
		/// <summary>
		/// Width of the chart, in pixels.
		/// Type: number
		/// Default: width of the containing element
		/// </summary>
		public double? Width { get; set; }
		/// <summary>
		/// Title of the chart
		/// Type: string
		/// Default: string.Empty
		/// </summary>
		public string Title { get; set; } = string.Empty;
	}
}
