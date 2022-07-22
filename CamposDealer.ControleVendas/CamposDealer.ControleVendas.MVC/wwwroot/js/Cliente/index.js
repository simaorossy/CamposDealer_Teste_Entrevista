var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableCliente").DataTable({
        "paging": true,
        "ordering": false,
        "search": false,
        "pageLength": 5,
        "iDisplayLength": 5,
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]],
        "info": false,
        "order": [[1, "asc"]],
        "language": {
            "emptyTable": "Nenhum registro encontrado",
            "lengthMenu": "Mostrar _MENU_ registros",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum registros encontrado",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
        },
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }]
    });
}

function editarCliente(element) {
    var idCliente = $(element).parent().parent().attr("data-idCliente")
    location.href = '/Cliente/Edit?idCliente=' + idCliente;
}

function excluirCliente(element) {    
    var idCliente = $(element).parent().parent().attr("data-idCliente")
    var nomeCliente = $(element).parent().parent().find(".td_nome").text();
    $("#modal_body").html('');
    $("#modal_body").append('<p>Deseja excluir o Cliente <b> ' + nomeCliente + '</b>.</p>');
    $("#modal_excluir").modal('show');
    $("#modal_ipt_id").val(idCliente);    
}

function ConfirmarExclusao() {
    var idCliente = $("#modal_ipt_id").val();

    var formdata = new FormData();
    formdata.append("idCliente", idCliente);

    $.ajax({
        url: '/Cliente/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {            
            location.href = '/Cliente/Index';
        },    
        error: function (data) {
            $("#modal_ex").modal('hide');
            $("#modal_ex_body").html('');
            $("#modal_ex_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_ex").modal('show');
        }
    })
}

