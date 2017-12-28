$(function () {
    $.ajaxSetup({
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