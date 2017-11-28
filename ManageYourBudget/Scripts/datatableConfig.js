var table;
var initializeDataTable = function () {
    table = $('#table')
        .DataTable({
            "columnDefs": [
                { targets: [4, 5], sortable: false }
            ],
            "bStateSave": true,
            "fnStateSave": function (oSettings, oData) {
                localStorage.setItem('DataTables', JSON.stringify(oData));
            },
            "fnStateLoad": function () {
                return JSON.parse(localStorage.getItem('DataTables'));
            }
        });
}

var deleteExpenditure = function (expenditureId, row, action) {
        $.ajax({
            url: action + '/' + expenditureId,
            success: function (result) {
                console.log(result);
                table
                    .row($(row).parents('tr'))
                    .remove()
                    .draw();
            },
            method: "POST"
        });
}