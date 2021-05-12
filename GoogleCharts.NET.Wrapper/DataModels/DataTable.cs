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

        public DataTable(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            dataTableRaws = new List<T>();
        }
        /// <summary>
        /// Add gantt row.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="resource"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="duration"></param>
        /// <param name="percentComplete"></param>
        /// <param name="dependencies"></param>
        public void AddRows(string taskId, string taskName, string resource = null, DateTime? startDate = null,
                            DateTime? endDate = null, double? duration = null, double? percentComplete = null, string dependencies = null)
        {
            //dataTableRaws.ConvertAll<T, DataTableGanttRow>()
            //dataTableRaws.Add(new DataTableGanttRow
            //{
            //    TaskId = taskId,
            //    TaskName = taskName,
            //    Resource = resource,
            //    StartDate = startDate,
            //    EndDate = endDate,
            //    Duration = duration,
            //    PercentComplete = percentComplete,
            //    Dependencies = dependencies
            //});
        }

        public void AddRow(T row)
        {
            dataTableRaws.Add(row);
        }

        public async void DrawChart()
        {
            var type = dataTableRaws.First().GetType().ToString();
            switch (type)
            {
                case "GoogleCharts.NET.Wrapper.DataModels.Gantt.DataTableGanttRow":
                    await _jSRuntime.InvokeVoidAsync("drawGantt", dataTableRaws);
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Timeline.DataTableTimeLineRow":
                    await _jSRuntime.InvokeVoidAsync("drawTimeline", dataTableRaws);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Set options for specific chart
        /// </summary>
        /// <param name="options">Can be either of type GanttOptions or TimelineOptions</param>
        public async void SetOptions(object options)
        {
            var type = options.GetType().ToString();
            switch (type)
            {
                case "GoogleCharts.NET.Wrapper.DataModels.Gantt.GanttOptions":
                    await _jSRuntime.InvokeVoidAsync("setGanttOptions", options);
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Timeline.TimelineOptions":
                    await _jSRuntime.InvokeVoidAsync("setTimelineOptions", options);
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
        public async void SetCallbackFunctionName(object obj, string name, bool dispose)
        {
            Tuple<object, string, bool> data = new Tuple<object, string, bool>(obj, name, dispose);
            await _jSRuntime.InvokeVoidAsync("setFunctionName", data);
        }
    }
}
