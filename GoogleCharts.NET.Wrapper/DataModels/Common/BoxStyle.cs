using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Common
{
    public class BoxStyle
    {
        public string Stroke { get; set; }
        public int StrokeWidth { get; set; }
        public int Rx { get; set; }
        public int Ry { get; set; }
        public Gradient Gradient { get; set; }
    }
}
