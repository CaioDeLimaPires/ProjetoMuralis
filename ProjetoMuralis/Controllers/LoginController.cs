using Microsoft.AspNetCore.Mvc;
using ProjetoMuralis.Auxiliares;
using ProjetoMuralis.Models;
using ProjetoMuralis.Repositorio;

namespace ProjetoMuralis.Controllers
{
    public class LoginController : Controller
    {
        //metodo de injeção
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly ISessao _sessao;        
        public LoginController(IFuncionarioRepositorio funcionarioRepositorio, ISessao sessao, IEmail email)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _sessao = sessao;            
        }

        //Retorna a vizualização do usuario da tela de login
        public IActionResult Index()
        {
            //Caso o usuario esteja logado,redirecionara para pagina HOME INDEX para inpedir que atarvez da url 
            // ele possa ter acesso as funçoes restritas
            if (_sessao.BuscarSessaoUser() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Metodo para permitir o acesso as funções do site
        [HttpPost]
        public IActionResult Entrar(LoginModel loginmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Metodo para buscar os dados de login dos funcionarios
                    FuncionariosModel log = _funcionarioRepositorio.BuscarLogin(loginmodel.Login);
                    //caso o login exista
                    if (log != null)
                    {
                        //caso a senha seja validada
                        if (log.SenhaValidada(loginmodel.Senha))
                        {
                            //cria uma sessão para o funcionario logado
                            _sessao.CriarSessaoUser(log);
                            //e direciona ele para o site
                            return RedirectToAction("Index", "Home");
                        }
                        //mensagem para caso a senha do usuario  n seja valida
                        TempData["MensagemErro"] = $"Senha do usuario invalida!!.Por favor, tente novamente!!";
                    }
                    //caso o usuario esteja invalido
                    TempData["MensagemErro"] = $"Usuario e/ou senha invalidos(s).Por favor, tente novamente!!";
                }
                //caso n seja validado o ususario retorna para a pgina de login
                return View("Index");
            }
            catch (Exception erro)
            {
                //caso de algum tipo de erro acontessa exibira a mensagem com o erro e mantem o usuario
                // na tela de login
                TempData["MensagemErro"] = $"Não foi possivel realizar o login,tente novamente, detalhes do erro:{erro}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Sair()
        {
            //Metodo para encerrar a sessao do usuario e finalizar o login dele
            _sessao.RemoverSessaoUser();
            //redireciona o usuario para a pagina principal de login
            return RedirectToAction("Index", "Login");
        }
    }
}
