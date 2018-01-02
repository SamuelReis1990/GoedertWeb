$(function () {
    $.ajaxSetup({
        beforeSend: function (jqXHR) {
            //jqXHR.setRequestHeader('Content-Type', 'text/plain;charset=UTF-8');
            jqXHR.setRequestHeader('Accept', 'application/json');
        }
    });

    //$.delete = function (url, data, callback, type) {

    //    if ($.isFunction(data)) {
    //        type = type || callback,
    //            callback = data,
    //            data = {}
    //    }

    //    return $.ajax({
    //        url: url,
    //        type: 'DELETE',
    //        success: callback,
    //        data: data,
    //        contentType: type
    //    });
    //}
});

$(document).ajaxStart(function () {
    $('body').loading({
        message: 'Carregando...',
    });
});

$(document).ajaxStop(function () {
    $('body').loading('stop');
});