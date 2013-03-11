$(document).ready(function () {
    $('.card-child').hover(function () {
        var thisBtns = $(this).find('.btn-group:first');
        thisBtns.show();
        var depth = thisBtns.parents('.card-child').size();
        $(this).find('.btn-group:first').show();
        /*var parent = $(this).parent();
        var parentBtns = parent.find('.btn-group:first');
        if (parentBtns.length != 0  && parentBtns[0] != thisBtns[0]) {
        parentBtns.hide();
        }*/
    }, function () {
        $(this).find('.btn-group:first').hide();
    });

    $('.btn-group').hide();
});