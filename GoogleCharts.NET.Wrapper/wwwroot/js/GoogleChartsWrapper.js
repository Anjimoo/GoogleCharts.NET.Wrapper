var height;
var ganttOptions;
var timelineOptions;
var selectEventName;
var DotNet;


window.setGanttOptions = (data) => {
    ganttOptions = data
}

window.setFunctionName = (data) => {
    DotNet = data.item1;
    selectEventName = data.item2;
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

        var chart = new google.visualization.Gantt(document.getElementById('gantt_chart'));

        google.visualization.events.addListener(chart, 'select', ganttClicked)

        chart.draw(dt, ganttOptions);

        function ganttClicked(e) {

            var selection = chart.getSelection();
            DotNet.invokeMethodAsync(selectEventName);
            DotNet.dispose();
        }
    }
}


window.setTimelineOptions = (data) => {
    timelineOptions = data;
}

window.drawTimeline = (data) => {
    google.charts.load("current", { packages: ["timeline"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var container = document.getElementById('timeline');
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
            var selected = chart.getSelection();
            if (DotNet != null) {
                DotNet.invokeMethodAsync(selectEventName);
                DotNet = null;
            } else {
                console.error("DotNet reference is null");
            }
        });

        chart.draw(dataTable, timelineOptions);
    }
}