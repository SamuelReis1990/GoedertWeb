$(function () {
    $.ajaxSetup({
        beforeSend: function (jqXHR) {
            //jqXHR.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');
            //jqXHR.setRequestHeader('Accept', 'application/json');
        }
    });
});

$(document).ajaxStart(function () {
    $('body').loading({
        message: 'Carregando...',
    });
});

$(document).ajaxStop(function () {
    $('body').loading('stop');
});