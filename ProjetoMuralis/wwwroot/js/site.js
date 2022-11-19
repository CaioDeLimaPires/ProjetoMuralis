
//Função para pegar as data table de cada funçao
$(document).ready(function () {

    getDatatable('#table-Funcionarios')
    getDatatable('#table-produtos')
    getDatatable('#table-produtos-geral')


    //Ao clicar no botão de html o botão dentro da lista dos pedidos
    // referencia: Quadrado verde na listado produtos
    $('.btn-total-produtos').click(function () {
        $('#modalPedidos').modal('show');
    });
});

//Gera a tabela configurada
//Retirei https://datatables.net/
function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
    //Permite o fechamento dos alertas de tela ex.Produto cadastrado com sucesso
    //.close-alert Criado em css
    $('.close-alert').click(function () {
        //esconde o alerta
        $('.alert').hide('hide');
    })

}
