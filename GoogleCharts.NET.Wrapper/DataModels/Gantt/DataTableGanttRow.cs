using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Gantt
{
    public class DataTableGanttRow
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Resource { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Duration { get; set; }
        public double? PercentComplete { get; set; }
        public string Dependencies { get; set; }
    }
}
