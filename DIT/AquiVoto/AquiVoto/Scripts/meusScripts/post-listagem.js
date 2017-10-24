$(document).ready(function () {

    carregarListagem();
});


function carregarListagem() {
    var messageIds = new Object();
    messageIds.success = "resultSuccess";
    messageIds.failed = "resultFailed";

    var paginaAtual = ($("#paginaAtual").val() == "") || ($("#paginaAtual").val() <= 0) ? 1 : $("#paginaAtual").val();

    enviarRequisicao(paginaAtual);    
}

function proximaPagina() {

    var paginaAtual = 1;

    if ($("#paginaAtual").val() != "")
        paginaAtual = parseInt($("#paginaAtual").val()) + 1;

    enviarRequisicao(paginaAtual);
}

function informarPagina(pagina) {

    enviarRequisicao(pagina);
}

function paginaAnterior() {

    var paginaAtual = 1;

    if ($("#paginaAtual").val() != "")
        paginaAtual = parseInt($("#paginaAtual").val()) - 1;

    enviarRequisicao(paginaAtual);
}

function enviarRequisicao(paginaAtual) {
   
    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/GetPosts",
        data: { paginaAtual: paginaAtual },
        beforeSend: function () {
            $('#loading').show();
        },
        complete: function () {
            $('#loading').hide();
        },
        success: function (data) {

            if (data == null) {
                data.statusCode = "ERROR";
                data.message = "Erro ocorreu no carregamento da listagem. Tente mais tarde.";

                OnFailure(data, messageIds.success, messageIds.failed);
                return;
            }

            $("#divPostsList").empty();
            $("#divPostsList").append(data);
        },
        error: function (data) {

            data.message = "Erro ocorreu no envio da requisição. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}