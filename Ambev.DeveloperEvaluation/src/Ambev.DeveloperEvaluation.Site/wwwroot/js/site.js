$(document).ready(function () {
    $('.qtdeTxt').on('input', function () {
        // Remove qualquer coisa que não seja número
        $(this).val($(this).val().replace(/\D/g, ''));
    });

    $('.qtdeTxt').attr('maxlength', '3');
});