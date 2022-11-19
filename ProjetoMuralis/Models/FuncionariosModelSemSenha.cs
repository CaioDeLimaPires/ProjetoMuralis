using ProjetoMuralis.Enumerador;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMuralis.Models
{
    public class FuncionariosModelSemSenha
    {
        
        public int Id_func { get; set; }
        [Required(ErrorMessage ="Digite o nome do Funcionario")]
        public string Nome_func { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do Funcionario")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!!")]
        public string Email_func { get; set; }
        [Required(ErrorMessage = "Digite o login do Funcionario")]
        public string Login_fuc { get; set; }
        [Required(ErrorMessage = "Selecione o tipo de perfil do Funcionario")]        
        public PerfilEnum? Perfil_func { get; set; }
       


    }
}
