using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Common
{
    public class Gradient
    {
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string X1 { get; set; }
        public string Y1 { get; set; }
        public string X2 { get; set; }
        public string Y2 { get; set; }
        public bool UseObjectBoundingBoxUnits { get; set; }
    }
}
