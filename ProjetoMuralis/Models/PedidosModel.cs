using System.ComponentModel.DataAnnotations;

namespace ProjetoMuralis.Models
{
    public class PedidosModel
    {
        [Key]
        public int Id_prod { get; set; }

        [Required(ErrorMessage = "Insira o nome do produto")]
        public string Nome_prod { get; set; }

        [Required(ErrorMessage = "Insira a descrição do produto")]
        public string Descricao_prod { get; set; }

        [Required(ErrorMessage = "Insira a marca do produto")]
        public string Marca_prod { get; set; }

        [Required(ErrorMessage = "Insira o valor do produto")]
        public double Valor_prod { get; set; }

        [Required(ErrorMessage = "Insira a quantidade do produto")]
        public int Quantidade_prod { get; set; }
        public DateTime DataCadastro_prod { get; set; }
        public DateTime? DataAtualizacao_prod { get; set; }
        public int? FuncionarioId { get; set; }
        public FuncionariosModel Funcionario { get; set; }
    }  
}