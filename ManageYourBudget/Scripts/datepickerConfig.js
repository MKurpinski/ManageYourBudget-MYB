$(function () {
    $(".datepicker")
        .datepicker({
        });

    $(function () {
        var dateFormat = "mm/dd/yy";
        var from = $("#from")
            .datepicker({
                dateFormat: dateFormat
            })
            .on("change",
                function () {
                    to.datepicker("option", "minDate", getDate(this));
                });

        var to = $("#to")
            .datepicker({
                dateFormat: dateFormat
            })
            .on("change",
                function () {
                    from.datepicker("option", "maxDate", getDate(this));
                });

        function getDate(element) {
            var date;
            try {
                date = $.datepicker.parseDate(dateFormat, element.value);
            } catch (error) {
                date = null;
            }
            return date;
        }
    });
});