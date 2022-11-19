using ProjetoMuralis.Auxiliares;
using ProjetoMuralis.Enumerador;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMuralis.Models
{
    public class FuncionariosModel
    {
        [Key]
        public int Id_func { get; set; }
        [Required(ErrorMessage ="Digite o nome do Funcionario")]
        public string Nome_func { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do Funcionario")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!!")]
        public string Email_func { get; set; }
        [Required(ErrorMessage = "Digite o login do Funcionario")]
        public string Login_fuc { get; set; }
        [Required(ErrorMessage = "Digite a senha do Funcionario")]
        public string Senha_func { get; set; }
        [Required(ErrorMessage = "Selecione o tipo de perfil do Funcionario")]
        public PerfilEnum? Perfil_func { get; set; }
        public DateTime DataCadastro_func { get; set; }
        public DateTime? DataAtualizacao_func { get; set; }       
        public virtual List<PedidosModel> Pedidos { get; set; }

        //Metodo para trnsformar a senha do usuario em hash
        public bool SenhaValidada(string senha)
        {
            return Senha_func == senha.GerarHash();
        }

        //Metodo que faz a senha do usuario ser igual a modificada
        public void SetSenha()
        {
            Senha_func = Senha_func.GerarHash();
        }

    }
}
