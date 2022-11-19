using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetoMuralis.Models;
using System.Text.Json.Serialization;

namespace ProjetoMuralis.Auxiliares
{
    public class Sessao : ISessao
    {
        //Metodo de injeção
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //Busca a sessão atraves de http
        public FuncionariosModel BuscarSessaoUser()
        {
            string sessaouser = _httpContext.HttpContext.Session.GetString("funcionarioLogado");
            if (string.IsNullOrEmpty(sessaouser))
            {
                return null;
            }
            //retorna uma converção de json
            return JsonConvert.DeserializeObject<FuncionariosModel>(sessaouser);
        }
        //Cria a sessão ataravez de http
        public void CriarSessaoUser(FuncionariosModel func)
        {
            string convert = JsonConvert.SerializeObject(func);
            _httpContext.HttpContext.Session.SetString("funcionarioLogado", convert);
        }

        //remove a sessão atravez de http
        public void RemoverSessaoUser()
        {
            _httpContext.HttpContext.Session.Remove("funcionarioLogado");
        }
    }
}
