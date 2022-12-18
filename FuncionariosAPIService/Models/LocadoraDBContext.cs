using System.Data.Entity;

namespace Locadora.Models
{
    public class LocadoraDBContext : DbContext
    {
        public LocadoraDBContext() : base("name=LocadoraDBContext")
        {}

     

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Locacao> Locacoes { get; set; }


    }
}