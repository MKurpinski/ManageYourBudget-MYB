var submitForm = function (event, action, id) {
    if ($(event).valid && $(event).valid()) {
        var formData = $(event).serialize();
        $.ajax({
            url: action,
            method: "POST",
            data: formData,
            success: function () {
                $("#" + id).val("Saved!");
                setTimeout(function () {
                        $("#" + id).val("Save");
                    },
                    2000);
            }
        });
    }
}