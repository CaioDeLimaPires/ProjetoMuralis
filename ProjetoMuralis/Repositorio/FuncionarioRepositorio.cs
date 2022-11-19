using Microsoft.EntityFrameworkCore;
using ProjetoMuralis.Data;
using ProjetoMuralis.Models;

namespace ProjetoMuralis.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContexto _bancoContexto;
        //Metodo de injeção para para atribuir e puxar dados do banco e modificalos
        public FuncionarioRepositorio(BancoContexto bancocontexto)
        {
            this._bancoContexto = bancocontexto;
        }

        //Metodo para adicionar dados ao banco de dados
        public FuncionariosModel Adicionar(FuncionariosModel func)
        {
            //Seta a senha criptografada
            func.SetSenha();

            //Atribui a data e a hora atual do computador a data de cadastro
            func.DataCadastro_func = DateTime.Now;

            //Adiciona os dados e os salva no banco
            _bancoContexto.Funcionarios.Add(func);
            _bancoContexto.SaveChanges();
            return func;
        }

        //Metodo para deletar os dados
        public bool Apagar(int id)
        {
            //Executa a busca do id do funcionario
            FuncionariosModel funcDb = BuscarPorId(id);

            //condição para caso o funcionario n seja encontrado
            //Exibira mensagem de erro!!
            if (funcDb== null) throw new Exception("Ocorreu um erro ao deletar os Dados!!");

            //Remove os dados do funcionario do banco e salva a alteração
            _bancoContexto.Funcionarios.Remove(funcDb);
            _bancoContexto.SaveChanges();
            return true;
        }

        //Metodo para atualizar os dados
        public FuncionariosModel Atualizar(FuncionariosModel func)
        {
            // busca os dados do funcionario que quer alterar os dados
            FuncionariosModel funcDB = BuscarPorId(func.Id_func);

            //Condição para caso n seja encontrado o usuario(mensagem de erro sera exibida!!)
            if (funcDB == null) throw new Exception("Houve um erro na atualização dos dados do funcionario");

            //Chama os dados do funcionario para permitir alteração
            funcDB.Nome_func = func.Nome_func;
            funcDB.Email_func = func.Email_func;
            funcDB.Login_fuc = func.Login_fuc;
            funcDB.Perfil_func = func.Perfil_func;
            funcDB.DataAtualizacao_func = DateTime.Now;

            //Altera os dados do funcionario e salva no banco
            _bancoContexto.Funcionarios.Update(funcDB);
            _bancoContexto.SaveChanges();
            return funcDB;
        }

        

        //Busca os dados do login do usuario
        public FuncionariosModel BuscarLogin(string login)
        {
            return _bancoContexto.Funcionarios.FirstOrDefault(x => x.Login_fuc.ToUpper() == login.ToUpper());
        }

        //Metodo para buscar os funcionarios por id
        public FuncionariosModel BuscarPorId(int id)
        {
            //retorna o primeiro ou o que esta determinado
            return _bancoContexto.Funcionarios.FirstOrDefault(x => x.Id_func == id);
        }

        //Metodo de busca de funcionarios
        public List<FuncionariosModel> BuscarTodos()
        {
            //Busca os dados de todos funcionarios
            return _bancoContexto.Funcionarios.Include(x => x.Pedidos).ToList();
        }
    }   
}
