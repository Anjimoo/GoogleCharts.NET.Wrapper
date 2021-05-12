using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCharts.NET.Wrapper.DataModels.Timeline
{
    public class TimelineOptions
    {
        /// <summary>
        /// Whether the chart should alternate background color by row index (i.e., tint background color of even-indexed rows a darker hue). 
        /// If false, chart background will be one uniform color. If true, chart background will alternate tint by row index. (Note: active v51+)
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool AlternatingRowStyle { get; set; }
        /// <summary>
        /// Whether display elements (e.g., the bars in a timeline) should obscure grid lines.
        /// If false, grid lines may be covered completely by display elements.
        /// If true, display elements may be altered to keep grid lines visible.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool AvoidOverlappingGridLines { get; set; }
        /// <summary>
        /// The background color for the main area of the chart. Can be either a simple HTML color string,
        /// for example: 'red' or '#00cc00', or an object with the following properties.
        /// Type: string or (object - not implemented yet)
        /// Default: 'white'
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// The colors to use for the chart elements. An array of strings, 
        /// where each element is an HTML color string, for example: colors:['red','#004411'].
        /// Type: Array of strings
        /// Default: default colors
        /// </summary>
        public List<string> Colors { get; set; }
        /// <summary>
        /// Whether the chart throws user-based events or reacts to user interaction. If false, the chart will not
        /// throw 'select' or other interaction-based events (but will throw ready or error events), and will not
        /// display hovertext or otherwise change depending on user input.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool EnableInteractivity { get; set; }
        /// <summary>
        /// The default font face for all text in the chart. You can override this using properties for specific chart elements.
        /// Type: string
        /// Default: 'Arial'
        /// </summary>
        public string FontName { get; set; }
        /// <summary>
        /// The default font size, in pixels, of all text in the chart. You can override this using properties for specific chart elements.
        /// Type: number
        /// Default: automatic
        /// </summary>
        public double FontSize { get; set; }
        /// <summary>
        /// Draws the chart inside an inline frame. (Note that on IE8, this option is ignored; all IE8 charts are drawn in i-frames.)
        /// Type: boolean
        /// Default: false
        /// </summary>
        public bool ForceFrame { get; set; }
        /// <summary>
        /// Height of the chart, in pixels.
        /// Type: number
        /// Default: height of the containing element
        /// </summary>
        public double Height { get; set; }
        //public object BarLabelStyle { get; set; }
        /// <summary>
        /// If set to true, colors every bar on the row the same. The default is to use one color per bar label.
        /// Type: boolean
        /// Default: false
        /// </summary>
        public Timeline Timeline { get; set; }
        
        /// <summary>
        /// Set to false to use SVG-rendered (rather than HTML-rendered) tooltips. See Customizing Tooltip Content for more details.
        /// Type: boolean
        /// Default: true
        /// </summary>
        public bool IsHtml { get; set; }
        /// <summary>
        /// The user interaction that causes the tooltip to be displayed:
        /// 'focus' - The tooltip will be displayed when the user hovers over the element.
        /// 'none' - The tooltip will not be displayed.
        /// Type: string
        /// Default: 'focus'
        /// </summary>
        public string TooltipTrigger { get; set; }
        /// <summary>
        /// Width of the chart, in pixels.
        /// Type: number
        /// Default: width of the containing element
        /// </summary>
        public double Width { get; set; }

    }
}
