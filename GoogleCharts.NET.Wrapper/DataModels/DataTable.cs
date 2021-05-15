using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace GoogleCharts.NET.Wrapper.DataModels
{
    public class DataTable<T>
    {
        private readonly IJSRuntime _jSRuntime;

        private List<T> dataTableRaws;
        /// <summary>
        /// returns true if chart was drawn
        /// </summary>
        public bool Drawn { get; private set; }

        public DataTable(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            dataTableRaws = new List<T>();
        }
        /// <summary>
        /// Adds row of specific type to DataTable
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(T row)
        {
            dataTableRaws.Add(row);
        }
        /// <summary>
        /// Draws chart and returns bool that represents if chat was drawn
        /// </summary>
        /// <returns></returns>
        public async Task DrawChart()
        {
            //var type = dataTableRaws.First().GetType().ToString();
            switch (typeof(T).ToString())
            {
                case "GoogleCharts.NET.Wrapper.DataModels.Gantt.DataTableGanttRow":
                    await _jSRuntime.InvokeVoidAsync("drawGantt", dataTableRaws);
                    Drawn = true;
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Timeline.DataTableTimeLineRow":
                    await _jSRuntime.InvokeVoidAsync("drawTimeline", dataTableRaws);
                    Drawn = true;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Set options for specific chart
        /// </summary>
        /// <param name="options">Can be either of type GanttOptions or TimelineOptions</param>
        public async Task SetOptions(object options)
        {
            //var type = options.GetType().ToString();
            switch (typeof(T).ToString())
            {
                case "GoogleCharts.NET.Wrapper.DataModels.Gantt.DataTableGanttRow":
                    await _jSRuntime.InvokeVoidAsync("setGanttOptions", options);
                    Drawn = true;
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Timeline.DataTableTimeLineRow":
                    await _jSRuntime.InvokeVoidAsync("setTimelineOptions", options);
                    Drawn = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set Callback function name with.
        /// </summary>
        /// <param name="obj">Dotnet reference to to object where is function present</param>
        /// <param name="name">Callback function.</param>
        /// <param name="dispose">Dispose object reference or no.</param>
        public async Task SetCallbackFunctionName(object obj, string name, bool dispose)
        {
            Tuple<object, string, bool> data = new Tuple<object, string, bool>(obj, name, dispose);
            await _jSRuntime.InvokeVoidAsync("setFunctionName", data);
        }

        public async Task SetChartId(string id)
        {
            if (typeof(T).ToString() == "GoogleCharts.NET.Wrapper.DataModels.Gantt.DataTableGanttRow")
            {
                await _jSRuntime.InvokeVoidAsync("setGanttId", id);
            }
            else if (typeof(T).ToString() == "GoogleCharts.NET.Wrapper.DataModels.Timeline.DataTableTimeLineRow")
            {
                await _jSRuntime.InvokeVoidAsync("setTimelineId", id);
            }
        }
    }
}
