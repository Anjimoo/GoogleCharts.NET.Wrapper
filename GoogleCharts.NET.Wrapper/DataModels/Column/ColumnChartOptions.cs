using GoogleCharts.NET.Wrapper.DataModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Column
{
    public class ColumnChartOptions
    {
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Animation Animation { get; set; }
        public Annotations Annotations { get; set; }
        public string AxisTitlesPosition { get; set; } = "out";
        public BackgroundColor BackgroundColor { get; set; }
        public Legend Legend { get; set; }
        public bool IsStacked { get; set; }
        public Bar Bar { get; set; }
    }
}
