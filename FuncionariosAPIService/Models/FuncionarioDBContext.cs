using System.Data.Entity;

namespace Locadora.Models
{
    public class FuncionarioDBContext : DbContext
    {
        public FuncionarioDBContext() : base("name=FuncionarioDBContext")
        {}

        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Locacao> Locacoes { get; set; }


    }
}