var addCategory = function (event, action) {
    var formData = $(event).serialize();
    $.ajax({
        url: action,
        method: "POST",
        data: formData,
        success: handleSuccess
    });
}

var handleSuccess = function (response) {
    $("#categories").append("<hr/> " + response);
    $("#categories").animate({ scrollTop: $("#categories")[0].scrollHeight }, "slow");
    $("#add").text("Added!");
    $("#plus").toggle();
    $("#addForm").trigger("reset");
    setTimeout(function () {
            $("#add").text("");
            $("#plus").toggle();
        },
        2000);
}