using GoogleCharts.NET.Wrapper.DataModels.Common;
using GoogleCharts.NET.Wrapper.DataModels.Interfaces;

namespace GoogleCharts.NET.Wrapper.DataModels.Column
{
    public class ColumnChartOptions : ChartOptions
    {
        public string Title { get; set; }
        public Animation Animation { get; set; }
        public Annotations Annotations { get; set; }
        public string AxisTitlesPosition { get; set; } = "out";
        public BackgroundColor BackgroundColor { get; set; }
        public Legend Legend { get; set; }
        public bool IsStacked { get; set; }
        public Bar Bar { get; set; }
    }
}
