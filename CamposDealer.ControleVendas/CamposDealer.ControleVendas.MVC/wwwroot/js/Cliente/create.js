$(document).ready(function () {    
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

    //$("#alert_nome").removeClass("d-none");
    //$("#alert_cidade").removeClass("d-none");
    //var nome = $("#ipt_nome").val();
    //var cidade = $("#ipt_cidade").val();
    //var error = 0;
    //if (!nome) {
    //    $("#alert_nome").removeClass("d-none");
    //    return
    //}
    //if (!cidade) {
    //    $("#alert_cidade").removeClass("d-none");
    //    return
    //}
    //save()
}

function save() {

    var nome = $("#ipt_nome").val();
    var cidade = $("#ipt_cidade").val();


    var formdata = new FormData();
    formdata.append("Nome", nome);
    formdata.append("Cidade", cidade);

    $.ajax({
        url: '/Cliente/Save',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Cliente/Index'
            }
        }

    })

}