using Mentis.Domain.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .ToTable("tb_Categoria");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(n => n.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(60)");

            builder
                .Property(n => n.TipoMovimentacao)
                .IsRequired();
        }
    }
}
