using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<MeuCashDbContext>
    {
        public MeuCashDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeuCashDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-BPQKIBEO\\SQLSERVER2022;Database=MeuCash;User Id=sa;Password=Mortadela1!;TrustServerCertificate=True");

            return new MeuCashDbContext(optionsBuilder.Options);
        }
    }
}
