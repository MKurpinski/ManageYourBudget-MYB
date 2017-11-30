var submitForm = function (event, action, id) {
    if ($(event).valid && $(event).valid()) {
        var formData = $(event).serialize();
        $.ajax({
            url: action,
            method: "POST",
            data: formData,
            success: function () {
                $("#" + id).val("Saved!");
                $("#" + id).prop("disabled", true);
                setTimeout(function () {
                    $("#" + id).val("Save");
                    $("#" + id).prop("disabled", false);
                },
                    2000);
            }
        });
    }
}