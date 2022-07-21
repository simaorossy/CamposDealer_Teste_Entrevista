$(document).ready(function () {
    $('.money').mask("##0,00", { reverse: true });
});

function validation() {
    $(".span_alert").addClass("d-none")
    $("input").css("border", " 1px solid #ced4da")

    var error = 0;

    $(".ipt_required").each(function () {
        if (!$(this).val()) {
            $(this).parent().find(".span_alert").removeClass("d-none")
            $(this).css("border", "1px solid red")
            error++;
        }
    })

    if (error == 0) {
        save()
    }
}

function save() {
    var id = $("#ipt_id").val();
    var nome = $("#ipt_descricao").val();
    var valor = $("#ipt_valor").val();

    var formdata = new FormData();
    formdata.append("Id", id);
    formdata.append("Nome", nome);
    formdata.append("Valor", valor);

    $.ajax({
        url: '/Produto/Edit',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Produto/Index'
            }
        }
    })
}