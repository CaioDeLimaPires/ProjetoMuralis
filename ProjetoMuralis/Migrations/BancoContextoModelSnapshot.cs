// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoMuralis.Data;

#nullable disable

namespace ProjetoMuralis.Migrations
{
    [DbContext(typeof(BancoContexto))]
    partial class BancoContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoMuralis.Models.FuncionariosModel", b =>
                {
                    b.Property<int>("Id_func")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_func"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacao_func")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro_func")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email_func")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login_fuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_func")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil_func")
                        .HasColumnType("int");

                    b.Property<string>("Senha_func")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_func");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ProjetoMuralis.Models.PedidosModel", b =>
                {
                    b.Property<int>("Id_prod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_prod"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacao_prod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro_prod")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao_prod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int")
                        .HasColumnName("Func_id");

                    b.Property<string>("Marca_prod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_prod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade_prod")
                        .HasColumnType("int");

                    b.Property<double>("Valor_prod")
                        .HasColumnType("float");

                    b.HasKey("Id_prod");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Pediodos");
                });

            modelBuilder.Entity("ProjetoMuralis.Models.PedidosModel", b =>
                {
                    b.HasOne("ProjetoMuralis.Models.FuncionariosModel", "Funcionario")
                        .WithMany("Pedidos")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ProjetoMuralis.Models.FuncionariosModel", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
