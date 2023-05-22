using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Timeline
{
    public class DataTableTimeLineRow
    {
        public string LineName { get; set; }
        public string BarName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
