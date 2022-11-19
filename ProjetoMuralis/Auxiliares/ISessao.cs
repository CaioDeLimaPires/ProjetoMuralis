using ProjetoMuralis.Models;

namespace ProjetoMuralis.Auxiliares
{
    public interface ISessao
    {
        //Cria a sessão do funcionario logado
        void CriarSessaoUser(FuncionariosModel func);
        //remove a sessão do funcionario ao sair da sua conta
        void RemoverSessaoUser();
        //metodo para busca da sessão
        FuncionariosModel BuscarSessaoUser();
    }
}
