using Microsoft.AspNetCore.Mvc;
using ProjetoMuralis.Auxiliares;
using ProjetoMuralis.Data;
using ProjetoMuralis.Models;
using ProjetoMuralis.Repositorio;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoMuralis.Controllers
{
    public class PedidosController : Controller
    {
        // metodo de injeção 
        private readonly IPedidoRepositorio _pedidosRepositorio;
        private readonly ISessao _sessao;
        private readonly BancoContexto _contexto;
        public PedidosController(IPedidoRepositorio pedidosRepositorio, ISessao sessao, BancoContexto contexto)
        {
            _pedidosRepositorio = pedidosRepositorio;
            _sessao = sessao;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            //metodo para buscar a seção do usuario identificando se ele é adiministrador
            //ou funcionario
            FuncionariosModel func = _sessao.BuscarSessaoUser();

            //metodo para listar os pedidos de cada funcionario e apresentar na tela
            List<PedidosModel> pedidos = _pedidosRepositorio.BuscarProdutoPeloIdFunc(func.Id_func);

            return View(pedidos);
        }
        public IActionResult _PedidoFuncionario()
        {
            List<PedidosModel> pedidos = _pedidosRepositorio.BuscarTodos();
            return View(pedidos);
        }
        //Retorna a vizualização do metodo criar
        public IActionResult Criar()
        {
            return View();
        }

        // Edita os pedidos 
        public IActionResult Editar(int id)
        {
            //metodo para chamar apenas o produto selecionado para edição
            // atarves do Id do produto
            PedidosModel busca = _pedidosRepositorio.BuscarPorId(id);
            return View(busca);
        }

        //Metodo para criação dos pedidos
        // adiciona ao banco de dados
        [HttpPost]
        public IActionResult Criar(PedidosModel pedido)
        {
            try
            {
                //Condição para caso o funcionario esqueca de preencher alguma informação 
                if (pedido.Descricao_prod != null && pedido.Marca_prod != null && pedido.Nome_prod != null && pedido.Valor_prod != 0 && pedido.Quantidade_prod != 0)
                {
                    // metodoto para atribuir o id do funcionario ao produto
                    // impedindo  que ele tenha acesso aos pedidos de outros usuarios
                    // apenas o adiministrador te acesso
                    FuncionariosModel func = _sessao.BuscarSessaoUser();
                    pedido.FuncionarioId = func.Id_func;

                    //Condição Para Limitar a adição de mais de 10 produtos
                    var conn = _contexto.Pediodos.Where(d => d.DataCadastro_prod == DateTime.Now.Date).Where(d => d.FuncionarioId == func.Id_func).Count();
                    if (conn == 10) { TempData["MensagemErro"] = "Não é permitido adicionar mais de 10 produtos"; return RedirectToAction("Index"); }
                    else
                    {
                        //Adiciona o preduto ao banco de dados
                        pedido = _pedidosRepositorio.Adicionar(pedido);
                        //mensagem a ser exibida ao adicionar no banco levando o funcionario
                        //a pagina principal dos pedidos
                        TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!!";
                        return RedirectToAction("Index");
                    }

                }
                return View(pedido);



            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o produto,tente novamente, detalhes do erro:{erro}";
                return RedirectToAction("Index");
            }
        }

        //Confirmação para deleção do produto
        // apos selecionar a pagar ira ser redirecionado para uma tela de confirmação
        // para ter certeza se ele quer ou não deletar
        public IActionResult ApagarConfirmacao(int id)
        {
            PedidosModel pedido = _pedidosRepositorio.BuscarPorId(id);
            return View(pedido);
        }

        //Metodo para deletar os pedidos
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _pedidosRepositorio.Apagar(id);
                if (apagado) TempData["MensagemSucesso"] = "Dados apagados com sucesso!!"; else TempData["MensagemErro"] = "Não foi possivel apagar os dados do produto";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel apagar os dados do produto, tente novamente,Detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Metodo Para editar os pedidos
        [HttpPost]
        public IActionResult Editar(PedidosModel pedido)
        {
            try
            {
                //Condição para evitar do ususario não inserir alguma informação
                if (pedido.Descricao_prod != null && pedido.Marca_prod != null && pedido.Nome_prod != null && pedido.Valor_prod != 0 && pedido.Quantidade_prod != 0)
                {

                    FuncionariosModel func = _sessao.BuscarSessaoUser();
                    pedido.FuncionarioId = func.Id_func;

                    _pedidosRepositorio.Atualizar(pedido);
                    TempData["MensagemSucesso"] = "Dados editados com sucesso!!";
                    return RedirectToAction("Index");
                }
                return View(pedido);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel editar os dados do produto, tente novamente,Detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
       
    }
}
