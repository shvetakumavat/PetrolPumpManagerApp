











if ($('#ambarchart3').length) {

    const myArr = []
    $.get("/Home/GetLinearRateChartData", function (data) {

        $.each(data, function (index, row) {

            var d = {
                "date": row.SaleDate,
                "hsdrates": row.HSDSaleInAmt,
                "msdrates": row.MSDSaleInAmt,
                "color": "#7474f0",
                "color2": "#C5C5FD"
            }
            myArr.push(d)
        })

        var chart = AmCharts.makeChart("ambarchart3", {
            "type": "serial",
            "theme": "light",
            "categoryField": "date",
            "rotate": true,
            "startDuration": 1,
            "categoryAxis": {
                "gridPosition": "start",
                "position": "left"
            },
            "trendLines": [],
            "graphs": [{
                "balloonText": "MSD-[[value]]Rs",
                "fillAlphas": 0.8,
                "id": "AmGraph-1",
                "lineAlpha": 0.2,
                "title": "Hsd rates",
                "type": "column",
                "valueField": "hsdrates",
                "fillColorsField": "color"
            },
            {
                "balloonText": "HSD-[[value]]Rs",
                "fillAlphas": 0.8,
                "id": "AmGraph-2",
                "lineAlpha": 0.2,
                "title": "Msd rates",
                "type": "column",
                "valueField": "msdrates",
                "fillColorsField": "color2"
            }
            ],


            "guides": [],
            "valueAxes": [{
                "id": "ValueAxis-1",
                "position": "top",
                "axisAlpha": 0
            }],
            "allLabels": [],
            "balloon": {},
            "titles": [],
            "dataProvider": myArr,
            
        });
    })

 
}











/*--------------  Rates-chart start ------------*/
if ($('#verview-shart').length) {

    const myArr = []
    $.get("/Home/GetLinearRateChartData", function (data) {

        $.each(data, function (index, row) {
            myArr.push(row)
        })

        var myConfig = {
            "type": "line",

            "scale-x": { //X-Axis
                "labels": myArr[2],//date Lables
                "label": {
                    "font-size": 14,
                    "offset-x": 0,
                },

                "item": { //Scale Items (scale values or labels)
                    "font-size": 10,
                },
                "guide": { //Guides
                    "visible": false,
                    "line-style": "dotted", //"solid", "dotted", "dashed", "dashdot"
                    "alpha": 5
                }
            },


            "scale-y": { //X-Axis
                "min-value": 90,
                "max-value": 115
            },
           /* "plot": { "aspect": "spline", "monotone": "false", },*/
            "series": [{

                "values": myArr[0],//hsd Rates
                "line-color": "#C5C5FD",
                /* "dotted" | "dashed" */
                "label": "HSD Rates",
                "background-color": "#C5C5FD"
                //"marker": { /* Marker object */
                //    /* hexadecimal or RGB value */
                //    "size": 3,
                //    /* in pixels */
                //    "border-color": "#ffc107",
                //    /* hexadecimal or RBG value */
                //}
            },
            {

                "values": myArr[1],//Msd Rates
                "line-color": "#7474f0",
                /* "dotted" | "dashed" */
                "line-width": 3 /* in pixels */,
                "background-color": "#7474f0",
                //"marker": { /* Marker object */
                   
                //    /* hexadecimal or RGB value */
                //    "size": 3,
                //    /* in pixels */
                //    "border-color": "#6610f2",
                //    /* hexadecimal or RBG value */
                //},
                "label": "MSD Rates"
            }
            ]
        };

        zingchart.render({
            id: 'verview-shart',
            data: myConfig,
            height: "100%",
            width: "100%"
        });
    })

}


/*-------------- Sales Chart  ------------*/
if ($('#salesanalytic').length) {



    $.get("/Home/GetSalesChartData", function (data) {
        let datap = []
        $.each(data, function (index, row) {
            var d =
            {
                "date": row.SaleDate,
                "Msd": row.MSDSaleInAmt,
                "hsd": row.HSDSaleInAmt,
                "overallSale": row.OverAllSaleInAmt
            }
            datap.push(d);
        })



        if ($('#salesanalytic').length) {

            var chart = AmCharts.makeChart("salesanalytic", {
                "type": "serial",
                "theme": "light",
                "dataDateFormat": "YYYY-MM-DD",
                "precision": 2,
                "valueAxes": [{
                    "id": "v1",
                    "title": "Sales",
                    "position": "left",
                    "autoGridCount": false,
                    "labelFunction": function (value) {
                        return "Rs" + Math.round(value) + "K";
                    }
                }],
                "graphs": [{
                    "id": "g4",
                    "valueAxis": "v1",
                    "lineColor": "#5C6DF4",
                    "fillColors": "#5C6DF4",
                    "fillAlphas": 1,
                    "type": "column",
                    "title": "Day Sales",
                    "valueField": "overallSale",
                    "clustered": false,
                    "columnWidth": 0.4,
                    "legendValueText": "Rs [[value]]K",
                    "balloonText": "[[title]]<br /><small style='font-size: 130%'>Rs[[value]]K</small>"
                }, {
                    "id": "g1",
                    "valueAxis": "v1",
                    "bullet": "round",
                    "bulletBorderAlpha": 1,
                    "bulletColor": "#fff",
                    "bulletSize": 5,
                    "hideBulletsCount": 50,
                    "lineThickness": 2,
                    "lineColor": "#dc3545",
                    "type": "smoothedLine",
                    "title": "MS Sale",
                    "useLineColorForBulletBorder": true,
                    "valueField": "Msd",
                    "balloonText": "[[title]]<br /><small style='font-size: 130%'>Rs [[value]]K</small>"
                }, {
                    "id": "g2",
                    "valueAxis": "v1",
                    "bullet": "round",
                    "bulletBorderAlpha": 1,
                    "bulletColor": "#fff",
                    "bulletSize": 5,
                    "hideBulletsCount": 50,
                    "lineThickness": 2,
                    "lineColor": "#815FF6",
                    "type": "smoothedLine",
                    "title": "HSD Sale",
                    "useLineColorForBulletBorder": true,
                    "valueField": "hsd",
                    "balloonText": "[[title]]<br /><small style='font-size: 130%'>Rs [[value]]K</small>"
                }],
                "chartScrollbar": {

                    "oppositeAxis": false,
                    "offset": 50,
                    "scrollbarHeight": 45,
                    "backgroundAlpha": 0,
                    "selectedBackgroundAlpha": 0.5,
                    "selectedBackgroundColor": "#f9f9f9",
                    "graphFillAlpha": 0.1,
                    "graphLineAlpha": 0.4,
                    "selectedGraphFillAlpha": 0,
                    "selectedGraphLineAlpha": 1,
                    "autoGridCount": true,
                    "color": "#95a1f9"
                },
                "chartCursor": {
                    "pan": true,
                    "valueLineEnabled": true,
                    "valueLineBalloonEnabled": true,
                    "cursorAlpha": 0,
                    "valueLineAlpha": 0.2
                },
                "categoryField": "date",
                "categoryAxis": {
                    "parseDates": true,
                    "dashLength": 1,
                    "minorGridEnabled": true,
                    "color": "#5C6DF4"
                },
                "legend": {
                    "useGraphSettings": true,
                    "position": "top"

                },
                "balloon": {
                    "borderThickness": 1,
                    "shadowAlpha": 0
                },
                "export": {
                    "enabled": false
                },
                "dataProvider": datap
            });
        }
    }
    )


}


/*-------------- 11 line chart amchart end ------------*/

/*-------------- 6 line chart chartjs start ------------*/
if ($('#seolinechart1').length) {
    var ctx = document.getElementById("seolinechart1").getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'line',
        // The data for our dataset
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July", "January", "February", "March", "April", "May"],
            datasets: [{
                label: "Likes",
                backgroundColor: "rgba(104, 124, 247, 0.6)",
                borderColor: '#8596fe',
                data: [18, 41, 86, 49, 20, 35, 20, 50, 49, 30, 45, 25],
            }]
        },
        // Configuration options go here
        options: {
            legend: {
                display: false
            },
            animation: {
                easing: "easeInOutBack"
            },
            scales: {
                yAxes: [{
                    display: !1,
                    ticks: {
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold",
                        beginAtZero: !0,
                        maxTicksLimit: 5,
                        padding: 0
                    },
                    gridLines: {
                        drawTicks: !1,
                        display: !1
                    }
                }],
                xAxes: [{
                    display: !1,
                    gridLines: {
                        zeroLineColor: "transparent"
                    },
                    ticks: {
                        padding: 0,
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold"
                    }
                }]
            },
            elements: {
                line: {
                    tension: 0, // disables bezier curves
                }
            }
        }
    });
}
/*-------------- 6 line chart chartjs end ------------*/

/*-------------- 7 line chart chartjs start ------------*/
if ($('#seolinechart2').length) {
    var ctx = document.getElementById("seolinechart2").getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'line',
        // The data for our dataset
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July", "January", "February", "March", "April", "May"],
            datasets: [{
                label: "Share",
                backgroundColor: "rgba(96, 241, 205, 0.2)",
                borderColor: '#3de5bb',
                data: [18, 41, 86, 49, 20, 35, 20, 50, 49, 30, 45, 25],
            }]
        },
        // Configuration options go here
        options: {
            legend: {
                display: false
            },
            animation: {
                easing: "easeInOutBack"
            },
            scales: {
                yAxes: [{
                    display: !1,
                    ticks: {
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold",
                        beginAtZero: !0,
                        maxTicksLimit: 5,
                        padding: 0
                    },
                    gridLines: {
                        drawTicks: !1,
                        display: !1
                    }
                }],
                xAxes: [{
                    display: !1,
                    gridLines: {
                        zeroLineColor: "transparent"
                    },
                    ticks: {
                        padding: 0,
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold"
                    }
                }]
            },
            elements: {
                line: {
                    tension: 0, // disables bezier curves
                }
            }
        }
    });
}
/*-------------- 7 line chart chartjs end ------------*/




