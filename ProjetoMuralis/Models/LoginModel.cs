using System.ComponentModel.DataAnnotations;

namespace ProjetoMuralis.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Insira o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage ="Insira a senha")]
        public string Senha { get; set; }
    }
}
