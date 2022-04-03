using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Common
{
    public class Legend
    {
        public string Position { get; set; } = "right";
        public int PageIndex { get; set; } = 0;
        public string Allignment { get; set; } = "automatic";
        public int? MaxLines { get; set; }
    }
}
