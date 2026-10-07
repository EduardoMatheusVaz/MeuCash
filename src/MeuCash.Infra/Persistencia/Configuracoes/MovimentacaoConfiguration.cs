using Mentis.Domain.Contas.Movimentacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infra.Persistencia.Configuracoes
{
    public class MovimentacaoConfiguration : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder
                .ToTable("tb_Movimentacao");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(t => t.Tipo)
                .IsRequired();

            builder
                .Property(t => t.Valor)
                .IsRequired()
                .HasPrecision(18, 2);

            builder
                .Property(d => d.Data)
                .IsRequired();

            builder
                .Property(d => d.Origem)
                .IsRequired();

            builder
                .HasOne(c => c.Categoria)
                .WithMany(m => m.Movimentacoes)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(d => d.Status)
                .IsRequired();
            
            builder
                .Property(d => d.TipoDespesa)
                .IsRequired(false);

            builder
                .ComplexProperty(
                    x => x.Parcelamento,
                    complex =>
                    {
                        complex.Property(x => x.NumeroParcela)
                        .HasColumnName("NumeroParcela");

                        complex.Property(x => x.TotalParcelas)
                        .HasColumnName("TotalParcelas");
                    });


            builder
                .ComplexProperty(
                    x => x.Recorrencia,
                    complex =>
                    {
                        complex.Property(x => x.Periodicidade)
                        .HasColumnName("Periodicidade");
                    });

            builder
                .Property(d => d.DataSistema)
                .IsRequired();
        }
    }
}
