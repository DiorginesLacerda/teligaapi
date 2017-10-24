$(document).ready(function () {

    $("#btnSalvar").click(function () {

        if (!validarCamposObrigatorios())
            return;

        salvar();
    });
});

function salvar() {
    var messageIds = new Object();
    messageIds.success = "resultSuccess";
    messageIds.failed = "resultFailed";

    $.ajax({
        type: "POST",
        dataType: 'json',
        async: true,
        contentyType: 'application/json',
        url: "/Usuario/Salvar",
        data: $("#formUsuario").serialize(),
        headers: { 'RequestVerificationToken': '@TokenHeaderValue()' },
        beforeSend: function () { $('#loading').show(); },
        complete: function () { $('#loading').hide(); },
        success: function (data) {

            alert("FOI!");
            //if (data.statusCode == "OK") {//200
            //    OnSuccess(data, false);
            //    nextStep();
            //}
            //else {
            //    OnFailure(data, messageIds.success, messageIds.failed);
            //}

        },
        error: function (data) {

            alert("ERRO!");

            data.message = "Não foi possível completar sua operação. Tente mais tarde.";
            //OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function validarCamposObrigatorios() {
    var objFields;
    var fieldsRequired = [];

    var messageId = "resultFailed";
    $("#" + messageId).empty();

    $("input").each(function (index) {
        $(this).css("background", "white");
    });

    if ($("#txtNome").val() == "") {
        objFields = new Object();
        objFields.Id = "txtNome";
        objFields.Text = "Nome";

        fieldsRequired.push(objFields);
    }

    if ($("#ddEstado").val() == "" || ($("#ddEstado").val() == null)) {
        objFields = new Object();
        objFields.Id = "ddEstado";
        objFields.Text = "Estado";

        fieldsRequired.push(objFields);
    }

    if ($("#ddCidade").val() == "" || ($("#ddCidade").val() == null)) {
        objFields = new Object();
        objFields.Id = "ddCidade";
        objFields.Text = "Cidade";

        fieldsRequired.push(objFields);
    }

    if ($("#txtEmail").val() == "") {
        objFields = new Object();
        objFields.Id = "txtEmail";
        objFields.Text = "Email";

        fieldsRequired.push(objFields);
    }

    if ($("#txtSenha").val() == "") {
        objFields = new Object();
        objFields.Id = "txtSenha";
        objFields.Text = "Senha";

        fieldsRequired.push(objFields);
    }

    if (fieldsRequired != null && fieldsRequired.length != 0) {

        messageFieldsBlank(fieldsRequired, messageId);
        return false;

    } else {
        return true;
    }
}

$('.form-control').on('click', function () {
    $(this).css("background", "white");
});

$('.form-control').on('focus', function () {
    $(this).css("background", "white");
});