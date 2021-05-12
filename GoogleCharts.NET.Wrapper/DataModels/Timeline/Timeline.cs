using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Timeline
{
    public class Timeline
    {
        public bool ColorByRowLabel { get; set; }
        /// <summary>
        /// If set to false, creates one row for every dataTable entry.
        /// The default is to collect bars with the same row label into one row.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool GroupByRowLabel { get; set; }

        //public object RowLabelStyle { get; set; }

        /// <summary>
        /// If set to false, omits bar labels. The default is to show them.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool ShowBarLabels { get; set; }
        /// <summary>
        /// If set to false, omits row labels. The default is to show them.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool ShowRowLabels { get; set; }
        /// <summary>
        /// Colors all bars the same. Specified as a hex value (e.g., '#8d8').
        /// Type: string
        /// Default: null
        /// </summary>
        public string SingleColor { get; set; }
    }
}
