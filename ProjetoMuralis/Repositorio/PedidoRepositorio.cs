using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoMuralis.Auxiliares;
using ProjetoMuralis.Data;
using ProjetoMuralis.Models;
using System.Data;

namespace ProjetoMuralis.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly BancoContexto _contexto;
        private readonly ISessao _sessao;
        //Metodo de injeção para para atribuir e puxar dados do banco e modificalos
        public PedidoRepositorio(BancoContexto contexto,ISessao sessao)
        {
            this._contexto = contexto;
            this._sessao = sessao;
        }

        //Metodo para adicionar dados ao banco de dados
        public PedidosModel Adicionar(PedidosModel pedido)
        {           
            //Atribui a data a data de cadastro
            pedido.DataCadastro_prod = DateTime.Now.Date;           
            //Adiciona ao banco
            _contexto.Pediodos.Add(pedido);
            _contexto.SaveChanges();
            return pedido;
        }

        //Metodo para deletar os dados
        public bool Apagar(int id)
        {
            //Executa a busca do id do pedido
            PedidosModel pedido = BuscarPorId(id);

            //condição para caso o pedido n seja encontrado
            //Exibira mensagem de erro!!
            if (pedido == null) throw new Exception("Ocorreu um erro ao deletar os Dados!!");

            //Remove os dados do pedido do banco e salva a alteração
            _contexto.Pediodos.Remove(pedido);
            _contexto.SaveChanges();
            return true;
        }
        //Metodo para atualizar os dados
        public PedidosModel Atualizar(PedidosModel pedido)
        {
            // busca os dados do funcionario que quer alterar os dados
            PedidosModel pedidoDB = BuscarPorId(pedido.Id_prod);

            //Condição para caso n seja encontrado o pedido(mensagem de erro sera exibida!!)
            if (pedidoDB == null) throw new Exception("Houve um erro na atualização dos dados do pedido");

            //Chama os dados do pedido para permitir alteração
            pedidoDB.Nome_prod = pedido.Nome_prod;
            pedidoDB.Descricao_prod = pedido.Descricao_prod;
            pedidoDB.Marca_prod = pedido.Marca_prod;
            pedidoDB.Valor_prod = pedido.Valor_prod;
            pedidoDB.Quantidade_prod = pedido.Quantidade_prod;
            pedidoDB.DataAtualizacao_prod = DateTime.Now;

            //Altera os dados do pedido e salva no banco
            _contexto.Pediodos.Update(pedidoDB);
            _contexto.SaveChanges();
            return pedidoDB;
        }

        //Metodo para buscar os pedidos por id
        public PedidosModel BuscarPorId(int id)
        {
            //retorna o primeiro ou o que esta determinado
            return _contexto.Pediodos.FirstOrDefault(x => x.Id_prod == id);
        }
        //Retorna todos os dados da tabela pedidos do banco
        public List<PedidosModel> BuscarTodos()
        {
            return _contexto.Pediodos.ToList();
        }
        //Retorna todos os dados do banco expecificos atrelados ao funcionario em lista
        public List<PedidosModel> BuscarProdutoPeloIdFunc(int IdFunc)
        {
            return _contexto.Pediodos.Where(x => x.FuncionarioId == IdFunc).ToList();
        }
       
    }
}
