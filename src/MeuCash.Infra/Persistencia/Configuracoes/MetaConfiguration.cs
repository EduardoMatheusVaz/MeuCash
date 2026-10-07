using Mentis.Domain.Metas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    public class MetaConfiguration : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder
                .ToTable("tb_Meta");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(n => n.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(40)");

            builder
                .Property(n => n.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(1000)");

            builder
                .Property(n => n.ValorMeta)
                .IsRequired()
                .HasPrecision(18, 2);

            builder
                .Property(x => x.Prazo)
                .IsRequired();

            builder
                .Property(x => x.CriadoEm)
                .IsRequired();

            builder
                .HasOne(u => u.Usuario)
                .WithMany(m => m.Metas)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Conta)
                .WithMany(m => m.Metas)
                .HasForeignKey(x => x.ContaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
