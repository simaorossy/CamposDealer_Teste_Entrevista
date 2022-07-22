$(document).ready(function () {
    var data = new Date();
    var dia = ("0" + data.getDate()).slice(-2);
    var mes = ("0" + (data.getMonth() + 1)).slice(-2);
    var ano = data.getFullYear();
    $("#ipt_data").val(ano + "-" + mes + "-" + dia);

    $('.money').mask("##0,00", { reverse: true });
    Soma();
});

$("#slct_produto").change(function () {
    console.log($("#slct_produto option:selected").attr("data-valorProduto"))
    console.log("ok")
    $("#ipt_valor").val($("#slct_produto option:selected").attr("data-valorProduto"))
    Soma();
})


$("#ipt_quantidade").change(function () {
    Soma();
})

$("#ipt_valor").change(function () {
    Soma();
})

function Soma() {
    var quantidade = $("#ipt_quantidade").val();
    var valor = $("#ipt_valor").val();
    var resultado = 0;

    if (quantidade && valor) {
        resultado = parseInt(quantidade) * parseFloat(ConvertFloatCalc(valor));
        $("#ipt_total").val(ConvertFloatView(resultado.toFixed(2)))
    } else {
        $("#ipt_total").val(0)
    }
}


function validation() {

    $(".span_alert").addClass("d-none")
    $(".ipt_required").css("border", " 1px solid #ced4da")

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
    var cliente = $("#slct_cliente option:selected").val();
    var produto = $("#slct_produto option:selected").val();
    var quantidade = $("#ipt_quantidade").val();
    var valor = $("#ipt_valor").val();
    var data = $("#ipt_data").val();
    var total = $("#ipt_total").val();

    var formdata = new FormData();
    formdata.append("Id", id);
    formdata.append("IdCliente", cliente);
    formdata.append("IdProduto", produto);
    formdata.append("QuantidadeProduto", quantidade);
    formdata.append("ValorUnitario", valor);
    formdata.append("DataVenda", data);
    formdata.append("ValorVenda", total);

    $.ajax({
        url: '/Venda/Edit',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Venda/Index'
            }
        },
        error: function (data) {
            $("#modal_ex").modal('hide');
            $("#modal_ex_body").html('');
            $("#modal_ex_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_ex").modal('show');
        }

    })

}