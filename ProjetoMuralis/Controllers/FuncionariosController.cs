using Microsoft.AspNetCore.Mvc;
using ProjetoMuralis.Auxiliares;
using ProjetoMuralis.Models;
using ProjetoMuralis.Repositorio;

namespace ProjetoMuralis.Controllers
{
    public class FuncionariosController : Controller
    {
        //metodo de injeção
        private readonly IPedidoRepositorio _pedido;       
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IEmail _email;
        public FuncionariosController(IFuncionarioRepositorio funcionarioRepositorio,IPedidoRepositorio pedidoRepositorio,IEmail email)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _pedido = pedidoRepositorio;
            _email=email;
        }

        //Pagina inicial com os dados dos usuarios
        public IActionResult Index()
        {
            //listagem dos funcionarios
            List<FuncionariosModel> funcionarios = _funcionarioRepositorio.BuscarTodos();

            //retorna os dados deles na tela
            return View(funcionarios);
        }

        //Cria a vizualização do metodo para criar novos usuarios
        public IActionResult Criar()
        {
            return View();
        }
        //Metodo de envio de e-mail
      /*  public IActionResult EnviarEmail()
        {
            var email = "caiolimapires61@outlook.com";
            string mensagem = "Novo Pedido solicitado";
            bool emailenviado=_email.Enviar(email, "Novo Pedido Solicitado",mensagem);
            if (emailenviado)
            {
                TempData["MensagemSucesso"] = "Pedido Solicitado com sucesso";
            }
            else
            {
                TempData["MensagemErro"] = $"Não foi possivel enviar o pedido";
            }
            return RedirectToAction("Index", "Pedidos");
        }
      */
        //metodo de edição dos dados dos funcionarios
        public IActionResult Editar(int id)
        {
            //Busca os dados do funcionario selecionado para ser editado
            FuncionariosModel busca = _funcionarioRepositorio.BuscarPorId(id);
            return View(busca);
        }

        public IActionResult ListarProdutosPorIdfunc(int id)
        {
            //Metodo de busca em lista dos dados do banco
            List<PedidosModel> pedidos = _pedido.BuscarProdutoPeloIdFunc(id);
            //retorno das informações recebidas pela variavel
            //retorna para java script via ajax
            return RedirectToAction("_PedidoFuncionario",pedidos);
        }

        //Cria os dados dos novos funcionarios
        [HttpPost]
        public IActionResult Criar(FuncionariosModel func)
        {
            try
            {
                if (func.Nome_func != null && func.Email_func != null && func.Login_fuc != null && func.Login_fuc != null && func.Perfil_func != 0 && func.Senha_func != null)
                {
                    //Adiciona no banco o novo funcionario cadastrado
                    func = _funcionarioRepositorio.Adicionar(func);
                    TempData["MensagemSucesso"] = "Funcionario cadastrado com sucesso!!";
                    //retorna para a pagina principal
                    return RedirectToAction("Index");
                }
                return View (func);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o funcionario,tente novamente, detalhes do erro:{erro}";
                return RedirectToAction("Index");
            }
        }
        
        //Metodo de confirmação para deletar funcionario
        public IActionResult ApagarConfirmacao(int id)
        {
            //Busca o funcionario atraves do id para deletalo
            FuncionariosModel func = _funcionarioRepositorio.BuscarPorId(id);
            return View(func);
        }
        //metodo para deletar dados do funcionario
        public IActionResult Apagar(int id)
        {
            try
            {
                //Apagar os dados e atribuir a uma variavel para verifica se é verdadeiro ou falso
                bool apagado = _funcionarioRepositorio.Apagar(id);
                //se for verdadeira a deleção exibira uma mensagem de sucesso
                if (apagado) TempData["MensagemSucesso"] = "Dados apagados com sucesso!!"; else TempData["MensagemErro"] = "Não foi possivel apagar os dados do funcionario";
                //e redirecionara ele par pagina principal com os dados dos funcionarios
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                //Mensagem exibida caso ocorra um erro
                TempData["MensagemErro"] = $"Ops, Não foi possivel apagar os dados do funcionario, tente novamente,Detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Metodo para edição dos dados do ususario sem a permisão de editar a senha
        [HttpPost]
        public IActionResult Editar(FuncionariosModelSemSenha funcSemSenha)
        {
            try
            {
               //funcionario entra sem valores
                FuncionariosModel func = null;

                //caso o estado da model seja valido
                if (ModelState.IsValid)
                {
                    //atribui valores aos dados do funcionario 
                    func = new FuncionariosModel()
                    {
                        Id_func = funcSemSenha.Id_func,
                        Nome_func = funcSemSenha.Nome_func,
                        Login_fuc = funcSemSenha.Login_fuc,
                        Email_func = funcSemSenha.Email_func,
                        Perfil_func = funcSemSenha.Perfil_func
                    };
                    //Metodo para atualizar os dados do banco
                    func = _funcionarioRepositorio.Atualizar(func);

                    TempData["MensagemSucesso"] = "Dados editados com sucesso!!";
                    return RedirectToAction("Index");
                }
                //caso seja invalido os dados de edição 
                return View(func);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel editar os dados do funcionario, tente novamente,Detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
