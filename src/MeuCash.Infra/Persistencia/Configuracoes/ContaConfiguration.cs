using Mentis.Domain.Contas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder
                .ToTable("tb_Conta");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(a => a.NumeroConta)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder
                .Property(a => a.Agencia)
                .IsRequired()
                .HasColumnType("VARCHAR(10)");

            builder
                .Property(a => a.Banco)
                .IsRequired()
                .HasColumnType("VARCHAR(40)");

            builder
                .Property(s => s.Saldo)
                .IsRequired()
                .HasPrecision(18, 2);

            builder
                .HasOne(u => u.Usuario)
                .WithMany(c => c.Contas)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
