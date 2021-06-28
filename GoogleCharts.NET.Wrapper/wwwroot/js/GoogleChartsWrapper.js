var height;
var ganttOptions;
var timelineOptions;
var selectEventName;
var TimelineDotNet;
var GanttDotNet;
var ganttId;
var timelineId;


window.setGanttOptions = (data) => {
    ganttOptions = {
        height: data
    }
}

window.setTimelineFunctionName = (data) => {
    TimelineDotNet = data.item1;
    selectEventName = data.item2;
}

window.setGanttFunctionName = (data) => {
    GanttDotNet = data.item1;
    selectEventName = data.item2;
}

window.setGanttId = (data) => {
    ganttId = data;
}

window.setTimelineId = (data) => {
    timelineId = data;
}

window.drawGantt = (data) => {
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

        for (var i = 0; i < data.length; i++) {
            receivedLine = [data[i].taskId, data[i].taskName, data[i].resource, new Date(data[i].startDate),
            new Date(data[i].endDate), data[i].duration, data[i].percentComplete, data[i].dependencies];
            receivedLines.push(receivedLine);
        }

        dt.addRows(receivedLines);

        var chart = new google.visualization.Gantt(document.getElementById(ganttId));

        google.visualization.events.addListener(chart, 'select', ganttClicked)

        chart.draw(dt, ganttOptions);

        function ganttClicked(e) {

            var selection = chart.getSelection();
            GanttDotNet.invokeMethodAsync(selectEventName);
            GanttDotNet.dispose();
        }
    }
}


window.setTimelineOptions = (data) => {
    if (data.hAxis != null && data.hAxis.minValue != null && data.hAxis.maxValue != null) {
        data.hAxis.minValue = new Date(data.hAxis.minValue);
        data.hAxis.maxValue = new Date(data.hAxis.maxValue);
    }
    timelineOptions = data;
}

window.drawTimeline = (data) => {
    google.charts.load("current", { packages: ["timeline"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var container = document.getElementById(timelineId);
        var chart = new google.visualization.Timeline(container);
        var dataTable = new google.visualization.DataTable();

        dataTable.addColumn({ type: 'string', id: 'Room' });
        dataTable.addColumn({ type: 'string', id: 'Name' });
        dataTable.addColumn({ type: 'date', id: 'Start' });
        dataTable.addColumn({ type: 'date', id: 'End' });

        let receivedLine;
        let receivedLines = [];

        for (var i = 0; i < data.length; i++) {
            receivedLine = [data[i].room, data[i].name, new Date(data[i].start), new Date(data[i].end)];
            receivedLines.push(receivedLine);
        }
        dataTable.addRows(receivedLines);

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

        chart.draw(dataTable, timelineOptions);
    }
}