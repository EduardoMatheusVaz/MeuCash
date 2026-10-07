using Mentis.Domain.Categorias;
using Mentis.Domain.Contas;
using Mentis.Domain.Contas.Movimentacoes;
using Mentis.Domain.Metas;
using Mentis.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeuCash.Infra.Persistencia
{
    public class MeuCashDbContext : DbContext
    {
        public MeuCashDbContext(DbContextOptions<MeuCashDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Meta> Metas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder model = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
