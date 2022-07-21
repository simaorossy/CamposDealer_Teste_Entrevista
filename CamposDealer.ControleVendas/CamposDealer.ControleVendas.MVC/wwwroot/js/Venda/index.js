var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableVenda").DataTable({
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

function editarVenda(element) {
    var idVenda = $(element).parent().parent().attr("data-idVenda")
    location.href = '/Venda/Edit?idVenda=' + idVenda;
}

function excluirVenda(element) {
    var idVenda = $(element).parent().parent().attr("data-idVenda")
    var nomeVenda = $(element).parent().parent().find(".td_nome").text();
    $("#modal_body").html('');
    $("#modal_body").append('<p>Deseja excluir a Venda do <b> ' + nomeVenda + '</b>.</p>');
    $("#modal_excluir").modal('show');
    $("#modal_ipt_id").val(idVenda);
}

function ConfirmarExclusao() {
    var idVenda = $("#modal_ipt_id").val();

    var formdata = new FormData();
    formdata.append("idVenda", idVenda);

    $.ajax({
        url: '/Venda/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            location.href = '/Venda/Index';
        },
        error: function (data) {
            $("#modal_excluir").modal('hide');
            $("#modal_body").html('');
            $("#modal_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_excluir").modal('show');
        }
    })
}

