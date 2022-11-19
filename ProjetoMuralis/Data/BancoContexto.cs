using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoMuralis.Data.Map;
using ProjetoMuralis.Models;

namespace ProjetoMuralis.Data
{
    public class BancoContexto:DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }
        //Tabela dos funcionarios
        public DbSet<FuncionariosModel> Funcionarios { get; set; }  
        //Tabela dos pedidos
        public DbSet<PedidosModel> Pediodos { get; set; }
        
        //Configuração de relacionamento de tabela funcionario com pedido
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuração da Map de pedidos
            modelBuilder.ApplyConfiguration(new PedidosMap());
            //Passando para a classe base para usar as configs criadas e as de herença 
            base.OnModelCreating(modelBuilder);
        }
    }
}
