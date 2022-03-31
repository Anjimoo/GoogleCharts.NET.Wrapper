var height;
var ganttOptions;
var timelineOptions;
var selectEventName;
var TimelineDotNet;
var GanttDotNet;
var ganttId;
var timelineId;

var charts = {}; //dictionary where key = chartId and value = chart Object
var chartsData = {}; //dictionary where key = chartId and value = chart data
var chartsOptions = {}; //dictionary where key = chartId and value = chart Options object

//common functions
window.addChartOptions = (data) => {
    chartsOptions[data.item1] = data.item2;
}

//Gantt

window.setGanttOptions = (data) => {
    ganttOptions = {
        height: data
    }
}

window.setGanttFunctionName = (data) => {
    GanttDotNet = data.item1;
    selectEventName = data.item2;
}

window.setGanttId = (data) => {
    ganttId = data;
}

window.drawGantt = (data) => {
    chartsData[data.item1] = data.item2;
    google.charts.load("current", { packages: ["gantt"] });
    google.charts.setOnLoadCallback(drawGanttChart);

    function drawGanttChart() {
        var dt = new google.visualization.DataTable();
        dt.addColumn('string', 'Task ID');
        dt.addColumn('string', 'Task Name');
        dt.addColumn('string', 'Resource');
        dt.addColumn('date', 'Start Date');
        dt.addColumn('date', 'End Date');
        dt.addColumn('number', 'Duration');
        dt.addColumn('number', 'Percent Complete');
        dt.addColumn('string', 'Dependencies');

        let receivedLine;
        let receivedLines = [];

        for (var i = 0; i < chartsData[data.item1].length; i++) {
            receivedLine = [chartsData[data.item1][i].taskId, chartsData[data.item1][i].taskName,
                chartsData[data.item1][i].resource, new Date(chartsData[data.item1][i].startDate),
                new Date(chartsData[data.item1][i].endDate), chartsData[data.item1][i].duration,
                chartsData[data.item1][i].percentComplete, chartsData[data.item1][i].dependencies];
            receivedLines.push(receivedLine);
        }

        dt.addRows(receivedLines);

        var chart = new google.visualization.Gantt(document.getElementById(data.item1));
        charts[data.item1] = chart;
        google.visualization.events.addListener(chart, 'select', ganttClicked)
        var options = {
            height: 500
        };
        chart.draw(dt, options);

        function ganttClicked(e) {

            var selection = chart.getSelection();
            GanttDotNet.invokeMethodAsync(selectEventName);
            GanttDotNet.dispose();
        }
    }
}

//Timeline
window.setTimelineFunctionName = (data) => {
    TimelineDotNet = data.item1;
    selectEventName = data.item2;
}

window.setTimelineId = (data) => {
    timelineId = data;
}

window.setTimelineOptions = (data) => {
    if (data.hAxis != null && data.hAxis.minValue != null && data.hAxis.maxValue != null) {
        data.hAxis.minValue = new Date(data.hAxis.minValue);
        data.hAxis.maxValue = new Date(data.hAxis.maxValue);
    }
    timelineOptions = data;
}

window.drawTimeline = (data) => {
    chartsData[data.item1] = data.item2;
    google.charts.load("current", { packages: ["timeline"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var container = document.getElementById(data.item1);
        var chart = new google.visualization.Timeline(container);
        var dataTable = new google.visualization.DataTable();

        dataTable.addColumn({ type: 'string', id: 'Room' });
        dataTable.addColumn({ type: 'string', id: 'Name' });
        dataTable.addColumn({ type: 'date', id: 'Start' });
        dataTable.addColumn({ type: 'date', id: 'End' });

        let receivedLine;
        let receivedLines = [];

        for (var i = 0; i < chartsData[data.item1].length; i++) {
            receivedLine = [chartsData[data.item1][i].room, chartsData[data.item1][i].name,
                new Date(chartsData[data.item1][i].start), new Date(chartsData[data.item1][i].end)];
            receivedLines.push(receivedLine);
        }
        dataTable.addRows(receivedLines);

        charts[data.item1] = chart;
        google.visualization.events.addListener(chart, 'select', function (e) {
            var selct = e;
            var selected = chart.getSelection();
            for (var i = 0; i < selected.length; i++) {
                var item = dataTable.getValue(selected[i].row, 1);
            }

            if (TimelineDotNet != null) {
                TimelineDotNet.invokeMethodAsync(selectEventName, item);
            } else {
                console.error("DotNet reference is null");
            }
        });

        chart.draw(dataTable, chartsOptions[data.item1]);
    }
}

window.drawColumnChart = (data) => {
    chartsData[data.item1] = data.item2;
    google.charts.load('current', { packages: ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var rows = [];
        for (var i = 0; i < data.item2.length; i++) {
            rows.push(data.item2[i].columnsValues)
        }

        var dataTable = google.visualization.arrayToDataTable(rows);
        var options = {
            title: "Density of Precious Metals, in g/cm^3",
            width: 600,
            height: 400,
            bar: { groupWidth: "95%" },
            legend: { position: "none" },
        };
        if (data.item1 === 'stacked') {
            options = {
                width: 600,
                height: 400,
                legend: { position: 'top', maxLines: 3 },
                bar: { groupWidth: '75%' },
                isStacked: true,
            };
        }
        var chart = new google.visualization.ColumnChart(document.getElementById(data.item1));
        chart.draw(dataTable, options);
    }
}