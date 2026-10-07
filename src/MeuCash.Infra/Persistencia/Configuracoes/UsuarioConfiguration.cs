using Mentis.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .ToTable("tb_Usuario");

            builder
                .Property(n => n.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder
                .Property(u => u.Username)
                .IsRequired()
                .HasColumnType("VARCHAR(30)");

            builder
                .Property(e => e.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(320)");

            builder
                .Property(t => t.Telefone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder
                .Property(t => t.Senha)
                .IsRequired()
                .HasColumnType("VARCHAR(255)");

            builder
                .Property(x => x.CriadoEm)
                .IsRequired();
        }
    }
}
