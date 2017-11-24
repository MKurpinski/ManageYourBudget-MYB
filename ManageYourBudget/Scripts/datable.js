$(document)
    .ready(function () {
        var table;
        if (!table) {
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
        }
    });