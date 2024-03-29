var charts = {}; //dictionary where key = chartId and value = chart Object

class Chart {
    options = {};
    chart;
    functionName;
    dotNetInstance;
    selectEventName;
    disposeDotNet;
    columns = [];
    data = [];

    constructor(id) {
        this.id = id;
    }
}

window.createChart = (id) => {
    charts[id] = new Chart(id);
};

window.addChartOptions = (data) => {
    charts[data.item1].options = data.item2;
};

window.setFunctionName = (data) => {
    charts[data.item1].dotNetInstance = data.item2;
    charts[data.item1].selectEventName = data.item3;
    charts[data.item1].disposeDotNet = data.item4;
};

//Gantt
window.drawGantt = (data) => {
    var chartId = data.item1;
    charts[chartId].data = data.item2;
    google.charts.load("current", { packages: ["gantt"] });
    google.charts.setOnLoadCallback(drawGanttChart);

    function drawGanttChart() {
        var dt = new google.visualization.DataTable();

        dt.addColumn("string", "Task ID");
        dt.addColumn("string", "Task Name");
        dt.addColumn("string", "Resource");
        dt.addColumn("date", "Start Date");
        dt.addColumn("date", "End Date");
        dt.addColumn("number", "Duration");
        dt.addColumn("number", "Percent Complete");
        dt.addColumn("string", "Dependencies");

        let receivedLine;
        let receivedLines = [];

        charts[chartId].data.forEach((item) => {
            let startDate = new Date(item.startDate);
            let endDate = new Date(item.endDate);
            receivedLine = [
                item.taskId,
                item.taskName,
                item.resource,
                startDate,
                endDate,
                item.duration,
                item.percentComplete,
                item.dependencies,
            ];
            receivedLines.push(receivedLine);
        });

        dt.addRows(receivedLines);

        var chart = new google.visualization.Gantt(
            document.getElementById(chartId)
        );
        charts[chartId].chart = chart;
        google.visualization.events.addListener(chart, "select", ganttClicked);

        chart.draw(dt, charts[chartId].options);

        function ganttClicked(e) {
            charts[chartId].dotNetInstance.invokeMethodAsync(
                charts[chartId].selectEventName
            );
            //charts[chartId].dotNetInstance.dispose();
        }
    }
};

//Timeline
window.drawTimeline = (data) => {
    var chartId = data.item1;
    charts[chartId].data = data.item2;
    google.charts.load("current", { packages: ["timeline"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var container = document.getElementById(chartId);
        var chart = new google.visualization.Timeline(container);
        var dataTable = new google.visualization.DataTable();

        data.item3.forEach((item) => {
            dataTable.addColumn({ type: item.item1, id: item.item2 });
        });

        let receivedLine;
        let receivedLines = [];
        //TODO refactor
        charts[data.item1].data.every((item) => {
            receivedLine = [];
            if (item['rows'] != undefined) {
                item['rows'].forEach((row) => {
                    receivedLine = [];
                    let counter = 0;
                    for (const property in row) {
                        if (row[property] === null) {
                            continue;
                        }
                        if (data.item3[counter].item1 == "date") {
                            receivedLine.push(new Date(row[property]));
                        } else {
                            receivedLine.push(row[property]);
                        }
                        counter++;
                    }
                    receivedLines.push(receivedLine);
                });
                return false;
            }
            let counter = 0;
            for (const property in item) {
                if (item[property] === null) {
                    continue;
                }
                if (data.item3[counter].item1 == "date") {
                    receivedLine.push(new Date(item[property]));
                } else {
                    receivedLine.push(item[property]);
                }
                counter++;
            }
            receivedLines.push(receivedLine);
            return true;
        });

        dataTable.addRows(receivedLines);

        charts[chartId].chart = chart;
        google.visualization.events.addListener(chart, "select", function (e) {
            var selected = chart.getSelection();
            for (var i = 0; i < selected.length; i++) {
                var item = dataTable.getValue(selected[i].row, 1);
            }

            if (charts[chartId].dotNetInstance != null) {
                charts[chartId].dotNetInstance.invokeMethodAsync(
                    charts[chartId].selectEventName,
                    item
                );
            } else {
                console.error("DotNet reference is null");
            }
        });

        chart.draw(dataTable, charts[chartId].options);
    }
};

//Columns Chart
window.drawColumnChart = (data) => {
    charts[data.item1].data = data.item2;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var rows = [];
        for (var i = 0; i < data.item2.length; i++) {
            rows.push(data.item2[i].columnsValues);
        }

        var dataTable = google.visualization.arrayToDataTable(rows);

        var chart = new google.visualization.ColumnChart(
            document.getElementById(data.item1)
        );
        chart.draw(dataTable, charts[data.item1].options);
    }
};

//Pie Chart
window.drawPieChart = (data) => {
    charts[data.item1].data = data.item2;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var rows = [];

        if (data.item3.length != 0) {
            rows.push([data.item3[0].item2, data.item3[1].item2]);
        }

        for (var i = 0; i < data.item2.length; i++) {
            rows.push([data.item2[i].label, data.item2[i].value]);
        }

        var dataTable = google.visualization.arrayToDataTable(rows);

        var chart = new google.visualization.PieChart(document.getElementById(data.item1));
        chart.draw(dataTable, charts[data.item1].options);
    }
};

//Custom row Pie Chart
window.drawCustomRowPieChart = (data) => {
    charts[data.item1].data = data.item2;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var rows = data.item2[0].rows;

        var dataTable = google.visualization.arrayToDataTable(rows);

        var chart = new google.visualization.PieChart(document.getElementById(data.item1));
        chart.draw(dataTable, charts[data.item1].options);
    }
};
