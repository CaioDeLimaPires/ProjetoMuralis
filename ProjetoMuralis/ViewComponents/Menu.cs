using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoMuralis.Models;

namespace ProjetoMuralis.ViewComponents
{
    public class Menu:ViewComponent
    {
        //Metodo para limitar as vizualizações dos usuarios a partes restritas para o adm
        //Sem permitir que atravez da url ele encontre
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Cria a sessão
            string sessao = HttpContext.Session.GetString("funcionarioLogado");
            //caso seja vazia n retorna nada
            if (string.IsNullOrEmpty(sessao))
            {
                return null;
            }
            //Converte para json a sessão
            FuncionariosModel func = JsonConvert.DeserializeObject<FuncionariosModel>(sessao);
            return View(func);
        }
    }
}
