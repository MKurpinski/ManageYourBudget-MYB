var table;

jQuery.fn.dataTableExt.oSort["duration-desc"] = function (x, y) {
    var xData = x.split("/");
    var yData = y.split("/");
    var xYear = parseInt(xData[2]);
    var yYear = parseInt(yData[2]);
    var xMonth = parseInt(xData[0]);
    var yMonth = parseInt(yData[0]);
    var xDay = parseInt(xData[1]);
    var yDay = parseInt(yData[1]);
    var result;

    if (xYear > yYear) {
        result = 1;
    }
    else if (xMonth > yMonth) {
        result= 1;
    }
    else if (xDay > yDay) {
        result = 1;
    } else {
        result = -1;
    }
    return result;
};

jQuery.fn.dataTableExt.oSort["duration-asc"] = function (x, y) {
    return jQuery.fn.dataTableExt.oSort["duration-desc"](y, x);
}

var initializeDataTable = function () {
    table = $('#table')
        .DataTable({
            "lengthMenu": [[10, 15], [10, 15]],
            "aoColumnDefs": [{
                "sType": "duration",
                "bSortable": true,
                "aTargets": [2]
            },
                {
                    "bSortable": false,
                    "aTargets": [4,5]
                }],
            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables', JSON.stringify(oData));
            },
            "fnStateLoad": function () {
                return JSON.parse(localStorage.getItem("DataTables"));
            }
        });
}

var deleteExpenditure = function (expenditureId, row, action) {
        $.ajax({
            url: action + "/" + expenditureId,
            success: function () {
                table
                    .row($(row).parents("tr"))
                    .remove()
                    .draw();
            },
            method: "POST"
        });
}