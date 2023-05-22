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
        private IJSRuntime _jSRuntime;

        private List<T> _dataTableRows;
        private List<Tuple<string, string>> _dataTableColumns;
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// returns true if chart was drawn
        /// </summary>
        public bool Drawn { get; private set; }

        private DataTable(IJSRuntime jSRuntime, string id)
        {
            _id = id;
            _jSRuntime = jSRuntime;
            _dataTableRows = new List<T>();
            _dataTableColumns = new List<Tuple<string, string>>();
        }

        /// <summary>
        /// Creates instance of DataTable with specified chart Type.
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="id">Chart ID</param>
        /// <returns></returns>
        public static Task<DataTable<T>> CreateAsync(IJSRuntime jSRuntime, string id)
        {
            var ret = new DataTable<T>(jSRuntime, id);
            return ret.InitializeAsync();
        }

        private async Task<DataTable<T>> InitializeAsync()
        {
            await _jSRuntime.InvokeVoidAsync("createChart", _id);
            return this;
        }

        /// <summary>
        /// Adds row of specific type to DataTable
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(T row)
        {
            _dataTableRows.Add(row);
        }

        /// <summary>
        /// Adds new column to DataTable. (Check official documentation of Google Charts to know which columns are supported)
        /// </summary>
        /// <param name="type">Type of a column</param>
        /// <param name="id">Id of a column</param>
        public void AddColumn(string type, string id)
        {
            _dataTableColumns.Add(new Tuple<string, string>(type, id));
        }

        public async Task DrawChart()
        {
            //var type = dataTableRaws.First().GetType().ToString();
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "GoogleCharts.NET.Wrapper.DataModels.Gantt.DataTableGanttRow":
                    await _jSRuntime.InvokeVoidAsync("drawGantt", new Tuple<string, object, object>(_id, _dataTableRows, _dataTableColumns));
                    Drawn = true;
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Common.CustomRow":
                case "GoogleCharts.NET.Wrapper.DataModels.Timeline.DataTableTimeLineRow":
                    await _jSRuntime.InvokeVoidAsync("drawTimeline", new Tuple<string, object, object>(_id, _dataTableRows, _dataTableColumns));
                    Drawn = true;
                    break;
                case "GoogleCharts.NET.Wrapper.DataModels.Column.DataTableColumnRow":
                    await _jSRuntime.InvokeVoidAsync("drawColumnChart", new Tuple<string, object, object>(_id, _dataTableRows, _dataTableColumns));
                    Drawn = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set options for a current chart
        /// </summary>
        /// <param name="options">GanttOptions/TimelineOptions/ColumnChartOptions</param>
        public async Task AddOptions(object options)
        {
            await _jSRuntime.InvokeVoidAsync("addChartOptions", new Tuple<string, object>(_id, options));
        }

        /// <summary>
        /// Set Callback function name with.
        /// </summary>
        /// <param name="obj">Dotnet reference to to object where is function present</param>
        /// <param name="name">Callback function.</param>
        /// <param name="dispose">Dispose object reference or no.</param>
        public async Task SetCallbackFunctionName(object obj, string name, bool dispose)
        {
            Tuple<string, object, string, bool> data = new Tuple<string, object, string, bool>(_id, obj, name, dispose);
            await _jSRuntime.InvokeVoidAsync("setFunctionName", data);
        }
    }
}
