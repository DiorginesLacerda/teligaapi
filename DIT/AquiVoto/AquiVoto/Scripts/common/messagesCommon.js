function messageFieldsBlank(fieldsRequired, messageId) {

    for (var i = 0; i < fieldsRequired.length; i++) {
        $("#" + fieldsRequired[i].Id + "").css("background", "#f2dede");
    }

    if (fieldsRequired.length == 1) {

        $("#" + messageId).append("<div class='alert alert-danger fade in' style='margin-top:10px'>"
                     + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                     + "<strong>Inválido!</strong> Campo '" + fieldsRequired[0].Text + "' deve ser preenchido."
                     + "</div>");
    } else {

        var fieldsBlank = "";

        for (var i = 0; i < fieldsRequired.length; i++) {
            fieldsBlank += "<br/>- " + fieldsRequired[i].Text;
        }

        $("#" + messageId).append("<div class='alert alert-danger fade in' style='margin-top:10px'>"
                     + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                     + "<strong>Inválido!</strong> Campos abaixos devem ser preenchidos:"
                     + fieldsBlank + "</div>");
    }

    $("html, body").animate({ scrollTop: 0 }, "slow");
}

function OnSuccessNew(data, refresh, messageIdSucess, messageIdFailed) {

    $("#" + messageIdSucess).empty();
    $("#" + messageIdFailed).empty();

    if (data.result == "OK") {

        $("#" + messageIdSucess).append("<div class='alert alert-success fade in' style='margin-top:10px'>"
                             + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                             + "<strong>Sucesso!</strong> " + data.message + "<br/>"
                             + "</div>");

        $("html, body").animate({ scrollTop: 0 }, "slow");

        var url = window.location.href;

        if (refresh) {
            window.setTimeout(function () {
                location.reload();
            }, 2500);
        }

    } else {

        $("#" + messageIdFailed).append("<div class='alert alert-danger fade in' style='margin-top:10px'>"
                             + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                             + "<strong>Inválido!</strong> " + data.message
                             + "</div>");

        $("html, body").animate({ scrollTop: 0 }, "slow");
    }
}

function OnSuccess(data, refresh) {

    $("#resultSuccess").empty();
    $("#resultFailed").empty();

    if (data.result == "OK") {

        $("#resultSuccess").append("<div class='alert alert-success fade in' style='margin-top:10px'>"
                             + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                             + "<strong>Sucesso!</strong> " + data.message + "<br/>"
                             + "</div>");

        $("html, body").animate({ scrollTop: 0 }, "slow");

        var url = window.location.href;

        if (refresh) {
            window.setTimeout(function () {
                location.reload();
            }, 2500);
        }

    } else {

        $("#resultFailed").append("<div class='alert alert-danger fade in' style='margin-top:10px'>"
                             + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                             + "<strong>Inválido!</strong> " + data.message
                             + "</div>");

        $("html, body").animate({ scrollTop: 0 }, "slow");
    }
}

function OnFailure(data, messageSuccesId, messageFailedId) {

    $("#" + messageSuccesId).empty();
    $("#" + messageFailedId).empty();

    $("#" + messageFailedId).append("<div class='alert alert-danger fade in' style='margin-top:10px'>"
                         + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"
                         + "<strong>Ação Inválida!</strong> " + data.message
                         + "</div>");

    $("html, body").animate({ scrollTop: 0 }, "slow");
}
