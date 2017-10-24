$(document).ready(function () {

    $("#btnSalvar").click(function () {

        if (!validarCamposObrigatorios())
            return;

        salvar();
    });
});

function salvar() {
    var messageIds = new Object();
    messageIds.success = "resultSuccessCadastro";
    messageIds.failed = "resultFailedCadastro";
    
    var antigoTextoNoBotao = $("#btnSalvar").text();

    $.ajax({
        type: "POST",
        dataType: 'json',
        async: true,
        contentyType: 'application/json',
        url: "/Usuario/Salvar",
        data: $("#formCadastro").serialize(),
        headers: { 'RequestVerificationToken': '@TokenHeaderValue()' },
        beforeSend: function () {
            $('#loading').show();
            $("#btnSalvar").text("Enviando...");
            $("#btnSalvar").attr('disabled', 'disabled');
        },
        complete: function () {
            $("#btnSalvar").text(antigoTextoNoBotao);
            $("#btnSalvar").removeAttr('disabled');
            $('#loading').hide();
        },
        success: function (data) {

            if (data.result == "OK") {//200
                
                //redirecionamento.
                setTimeout(function () {
                    location.href = data.url;
                }, 2000);                
            }
            else {
                OnFailure(data, messageIds.success, messageIds.failed);
            }

        },
        error: function (data) {

            data.message = "Não foi possível completar sua operação. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function validarCamposObrigatorios() {
    var objFields;
    var fieldsRequired = [];

    var messageId = "resultFailedCadastro";
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

    if ($("#txtEmailNovoCadastro").val() == "") {
        objFields = new Object();
        objFields.Id = "txtEmailNovoCadastro";
        objFields.Text = "Email";

        fieldsRequired.push(objFields);
    }

    if ($("#txtSenhaNovoCadastro").val() == "") {
        objFields = new Object();
        objFields.Id = "txtSenhaNovoCadastro";
        objFields.Text = "Senha";

        fieldsRequired.push(objFields);
    }

    if ($("#txtSenhaRepetidaNovoCadastro").val() == "") {
        objFields = new Object();
        objFields.Id = "txtSenhaRepetidaNovoCadastro";
        objFields.Text = "Senha";

        fieldsRequired.push(objFields);
    }

    if (($("#txtSenhaNovoCadastro").val() != "") && ($("#txtSenhaRepetidaNovoCadastro").val()) != "") {

        if ($("#txtSenhaNovoCadastro").val() != $("#txtSenhaRepetidaNovoCadastro").val()) {
            objFields = new Object();
            objFields.Id = "txtSenhaNovoCadastro";
            objFields.Text = "Senhas não estão idênticas";

            fieldsRequired.push(objFields);
        }
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