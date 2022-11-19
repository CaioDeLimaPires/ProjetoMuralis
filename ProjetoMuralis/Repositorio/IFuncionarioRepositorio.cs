using ProjetoMuralis.Models;

namespace ProjetoMuralis.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        //Busca os dados de login
        FuncionariosModel BuscarLogin(string login);
        //Lista todos os dados buscados do banco
        List<FuncionariosModel> BuscarTodos();
        //Busca pelo id o dados do funcionario
        FuncionariosModel BuscarPorId(int id);
        //Adiciona dados ao banco
        FuncionariosModel Adicionar(FuncionariosModel func);
        //Atualiza os dados no banco modificados pelos usuarios
        FuncionariosModel Atualizar(FuncionariosModel func);
        //Apaga os dados do banco
        bool Apagar(int id);        
    }
}
