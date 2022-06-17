using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Gantt
{
    public class Gantt
    {
        public string BackGroundColorFill { get; set; }
        public Arrow Arrow { get; set; }
        public int BarCornerRadius { get; set; }
        public int? BarHeight { get; set; }
        public bool CriticalPathEnabled { get; set; }
        public CriticalPathStyle CriticalPathStyle { get; set; }
        public DateTime? DefaultStartDate { get; set; }
        public InnerGridHorizLine InnerGridHorizLine { get; set; }
        public double LabelMaxWidth { get; set; }
        public bool PercentEnabled { get; set; }
        public bool ShadowEnabled { get; set; }
        public string ShadowColor { get; set; }
        public int ShadowOffset { get; set; }
        public bool SortTasks { get; set; }
        public int? TrackHeight { get; set; }
    }
}
