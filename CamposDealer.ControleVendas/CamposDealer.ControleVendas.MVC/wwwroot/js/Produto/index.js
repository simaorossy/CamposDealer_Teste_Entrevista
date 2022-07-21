var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableProduto").DataTable({
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

function editarProduto(element) {
    var idProduto = $(element).parent().parent().attr("data-idProduto")
    location.href = '/Produto/Edit?idProduto=' + idProduto;
}

function excluirProduto(element) {
    var idProduto = $(element).parent().parent().attr("data-idProduto")
    var nomeProduto = $(element).parent().parent().find(".td_nome").text();
    $("#modal_body").html('');
    $("#modal_body").append('<p>Deseja excluir o Cliente <b> ' + nomeProduto + '</b>.</p>');
    $("#modal_excluir").modal('show');
    $("#modal_ipt_id").val(idProduto);
}

function ConfirmarExclusao() {
    var idProduto = $("#modal_ipt_id").val();

    var formdata = new FormData();
    formdata.append("idProduto", idProduto);

    $.ajax({
        url: '/Produto/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            location.href = '/Produto/Index';
        },
        error: function (data) {
            $("#modal_excluir").modal('hide');
            $("#modal_body").html('');
            $("#modal_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_excluir").modal('show');
        }
    })
}

