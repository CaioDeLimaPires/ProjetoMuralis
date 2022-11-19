using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMuralis.Models;

namespace ProjetoMuralis.Data.Map
{
    public class PedidosMap : IEntityTypeConfiguration<PedidosModel>
    {
        //Mapeamento do banco de dados atravez de EF 
        public void Configure(EntityTypeBuilder<PedidosModel> builder)
        {
            //Determina a chave primaria
            builder.HasKey(x => x.Id_prod);
            //Detemina a propriedade              Determina o nome da coluna
            builder.Property(x => x.FuncionarioId).HasColumnName("Func_id");
            //Determina 1 para n
            builder.HasOne(x => x.Funcionario);
        }
    }
}
