$("#btnModalAprovar").click(function () {

    var guid = $("#btnModalAprovar").attr("guidAprovar");

    if ((guid == undefined) || (guid == "")) {
        var data = new Object();
        data.message = "Falha ocorreu ao carregar o post para salvar. Tente mais tarde.";
        OnFailure(data, "resultSuccess", "resultFailed");
    }

    var messageIds = new Object();
    messageIds.success = "resultSuccess";
    messageIds.failed = "resultFailed";

    $.ajax({
        type: 'POST',
        async: true,
        cache: false,
        url: "/Posts/SalvarAprovarPost",
        data: { guid: guid },
        beforeSend: function () {
            $('#loading').show();

            $("#btnModalAprovar").text("Enviando...");
            $("#btnModalAprovar").attr('disabled', 'disabled');
            $("#btnModalNaoAprovar").attr('disabled', 'disabled');
        },
        complete: function () {
            $("#btnModalAprovar").text("Sim");
            $("#btnModalAprovar").removeAttr('disabled');
            $("#btnModalNaoAprovar").removeAttr('disabled');

            $("#modalAprovar").modal("hide");
            $('#loading').hide();
        },
        success: function (data) {
            $("#modalAprovar").modal("hide");

            if (data == null) {
                OnFailure(data, messageIds.success, messageIds.failed);
                return;
            }

            if (data.result == "OK") {
                desabilitarAcoesStatusPost();

                data.message += "<br/>Aguarde a página ser atualizada...";
                OnSuccess(data, false);

                if (REFRESH_PAGE) {
                    setTimeout(function () {
                        location.href = window.location.href;
                    }, 3000);
                }
                return;
            }

            OnFailure(data, messageIds.success, messageIds.failed);
        },
        error: function (data) {
            $("#modalAprovar").modal("hide");

            data.message = "Erro ao salvar a operação. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });

});

$("#btnModalRepetido").click(function () {

    var guid = $("#btnModalRepetido").attr("guidPostRepetido");

    if ((guid == undefined) || (guid == "")) {
        var data = new Object();
        data.message = "Falha ocorreu ao carregar o post para salvar. Tente mais tarde.";
        OnFailure(data, "resultSuccess", "resultFailed");
    }

    var messageIds = new Object();
    messageIds.success = "resultSuccess";
    messageIds.failed = "resultFailed";

    var observacaoModerador = $("#txtAreaObservacaoRepetido").val();

    $.ajax({
        type: 'POST',
        async: true,
        cache: false,
        url: "/Posts/SalvarPostRepetido",
        data: { guid: guid, leiRepetida: 0, observacaoModerador: observacaoModerador },
        beforeSend: function () {
            $('#loading').show();

            $("#btnModalRepetido").text("Enviando...");
            $("#btnModalRepetido").attr('disabled', 'disabled');
            $("#btnModalNaoRepetido").attr('disabled', 'disabled');
        },
        complete: function () {
            $("#btnModalRepetido").text("Sim");
            $("#btnModalRepetido").removeAttr('disabled');
            $("#btnModalNaoRepetido").removeAttr('disabled');

            $("#modalRepetido").modal("hide");
            $('#loading').hide();
        },
        success: function (data) {
            $("#modalRepetido").modal("hide");

            if (data == null) {
                OnFailure(data, messageIds.success, messageIds.failed);
                return;
            }

            if (data.result == "OK") {
                desabilitarAcoesStatusPost();

                data.message += "<br/>Aguarde a página ser atualizada...";
                OnSuccess(data, false);

                if (REFRESH_PAGE) {
                    setTimeout(function () {
                        location.href = window.location.href;
                    }, 3000);
                }
                return;
            }

            OnFailure(data, messageIds.success, messageIds.failed);
        },
        error: function (data) {
            $("#modalRepetido").modal("hide");

            data.message = "Erro ao salvar a operação. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
});

$("#btnModalNegar").click(function () {

    var guid = $("#btnModalNegar").attr("guidPostNegado");

    if ((guid == undefined) || (guid == "")) {
        var data = new Object();
        data.message = "Falha ocorreu ao carregar o post para salvar. Tente mais tarde.";
        OnFailure(data, "resultSuccess", "resultFailed");
    }

    var messageIds = new Object();
    messageIds.success = "resultSuccess";
    messageIds.failed = "resultFailed";

    var observacaoModerador = $("#txtAreaObservacaoNegar").val();

    $.ajax({
        type: 'POST',
        async: true,
        cache: false,
        url: "/Posts/SalvarNegarPost",
        data: { guid: guid, observacaoModerador: observacaoModerador },
        beforeSend: function () {
            $('#loading').show();

            $("#btnModalNegar").text("Enviando...");
            $("#btnModalNegar").attr('disabled', 'disabled');
            $("#btnModalNaoNegar").attr('disabled', 'disabled');
        },
        complete: function () {
            $("#btnModalNegar").text("Sim");
            $("#btnModalNegar").removeAttr('disabled');
            $("#btnModalNaoNegar").removeAttr('disabled');

            $("#modalNegar").modal("hide");
            $('#loading').hide();
        },
        success: function (data) {
            $("#modalNegar").modal("hide");

            if (data == null) {
                OnFailure(data, messageIds.success, messageIds.failed);
                return;
            }

            if (data.result == "OK") {
                desabilitarAcoesStatusPost();

                data.message += "<br/>Aguarde a página ser atualizada...";
                OnSuccess(data, false);

                if (REFRESH_PAGE) {
                    setTimeout(function () {
                        location.href = window.location.href;
                    }, 3000);
                }
                return;
            }

            OnFailure(data, messageIds.success, messageIds.failed);
        },
        error: function (data) {
            $("#modalNegar").modal("hide");

            data.message = "Erro ao salvar a operação. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
});

function desabilitarAcoesStatusPost() {

    var mensagem = "Este post já possui uma ação realizada.";

    $("#btnAprovar").attr('disabled', 'disabled').attr("title", mensagem);
    $("#btnRepetido").attr('disabled', 'disabled').attr("title", mensagem);
    $("#btnNegar").attr('disabled', 'disabled').attr("title", mensagem);
}

function aprovarPost(guid, titulo) {

    $("#lblTituloAprovar").text(titulo);
    $("#btnModalAprovar").attr("guidAprovar", guid);

    $("#modalAprovar").modal("show");
}

function postRepetido(guid, titulo) {
    $("#lblTituloRepetido").text(titulo);
    $("#btnModalRepetido").attr("guidPostRepetido", guid);

    $("#modalRepetido").modal("show");
}

function negarPost(guid, titulo) {
    $("#lblTituloNegar").text(titulo);
    $("#btnModalNegar").attr("guidPostNegado", guid);

    $("#modalNegar").modal("show");
}

