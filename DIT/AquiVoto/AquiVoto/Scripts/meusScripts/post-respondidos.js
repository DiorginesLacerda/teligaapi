$(document).ready(function () {

    carregarAprovados();

    $("#tabRepetidosId").click(function () {
        carregarRepetidos();

    });

    $("#tabNegadosId").click(function () {
        carregarNegados();
    });

    //contadores nas tabs.
    carregarTotalRepetidos();
    carregarNegados();
});


function carregarTotalRepetidos() {

    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/CarregarTotalRepetidos",
        //data: { },
        beforeSend: function () { },
        complete: function () { },
        success: function (data) {

            if ((data == null) || (data.result != "OK")) {
                return;
            }

            $("#titleQuantidadeRepetidos").empty();
            $("#titleQuantidadeRepetidos").append(data.totalRepetidos);
        },
        error: function (data) {

            data.message = "Erro ocorreu na contagem dos contadores.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function carregarTotalNegados() {

    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/CarregarTotalNegados",
        //data: { },
        beforeSend: function () { },
        complete: function () { },
        success: function (data) {

            if ((data == null) || (data.result != "OK")) {
                return;
            }

            $("#titleQuantidadeNegados").empty();
            $("#titleQuantidadeNegados").append(data.totalNegados);
        },
        error: function (data) {

            data.message = "Erro ocorreu na contagem dos contadores.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function carregarAprovados() {

    var messageIds = new Object();
    messageIds.success = "resultSuccessTabAprovados";
    messageIds.failed = "resultFailedTabAprovados";

    var paginaAtual = ($("#paginaAtualAprovados").val() == "") || ($("#paginaAtualAprovados").val() <= 0) ?
                            1 : $("#paginaAtualAprovados").val();
    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/GetPostsAprovados",
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

            $("#divAprovadosPartialList").empty();
            $("#divAprovadosPartialList").append(data);
        },
        error: function (data) {

            data.message = "Erro ocorreu no carregamento dos dados. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function carregarRepetidos() {

    var messageIds = new Object();
    messageIds.success = "resultSuccessTabRepetidos";
    messageIds.failed = "resultFailedTabRepetidos";

    var paginaAtual = ($("#paginaAtualARepetidos").val() == "") || ($("#paginaAtualARepetidos").val() <= 0) ?
                        1 : $("#paginaAtualARepetidos").val();
    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/GetPostsRepetidos",
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

            $("#divRepetidosPartialList").empty();
            $("#divRepetidosPartialList").append(data);
        },
        error: function (data) {

            data.message = "Erro ocorreu no carregamento dos dados. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}

function carregarNegados() {

    var messageIds = new Object();
    messageIds.success = "resultSuccessTabNegados";
    messageIds.failed = "resultFailedTabNegados";

    var paginaAtual = ($("#paginaAtualNegados").val() == "") || ($("#paginaAtualNegados").val() <= 0) ?
                        1 : $("#paginaAtualNegados").val();
    $.ajax({
        type: 'GET',
        async: true,
        cache: false,
        url: "/Posts/GetPostsNegados",
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

            $("#divNegadosPartialList").empty();
            $("#divNegadosPartialList").append(data);
        },
        error: function (data) {

            data.message = "Erro ocorreu no carregamento dos dados. Tente mais tarde.";
            OnFailure(data, messageIds.success, messageIds.failed);
        }
    });
}