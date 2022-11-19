using ProjetoMuralis.Models;

namespace ProjetoMuralis.Repositorio
{
    public interface IPedidoRepositorio
    {
        //Adiciona ao banco
        PedidosModel Adicionar(PedidosModel pedido);
        //Busca Todos
        List<PedidosModel> BuscarTodos();
        //Lista todos os dados
        List<PedidosModel> BuscarProdutoPeloIdFunc(int IdFunc);
        //Busca pelo Id
        PedidosModel BuscarPorId(int id);
        //Atualiza no banco os dados modificados
        PedidosModel Atualizar(PedidosModel func);
        //Apaga os dados do banco de dados
        bool Apagar(int id);
        

    }
}
