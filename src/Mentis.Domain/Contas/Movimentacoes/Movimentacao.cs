using Mentis.Domain.Categorias;
using Mentis.Domain.Constantes;

namespace Mentis.Domain.Contas.Movimentacoes
{
    public sealed class Movimentacao : BaseEntity
    {
        public Movimentacao() { }
        
        public Movimentacao(
            TipoMovimentacaoEnum tipo, 
            decimal valor, 
            DateTime data, 
            OrigemMovimentacaoEnum origem, 
            Guid categoriaId, 
            StatusEnum? status, 
            TipoDespesaEnum? tipoDespesa, 
            DateTime dataSistema)
        {
            Tipo = tipo;
            Valor = valor;
            Data = data;
            Origem = origem;
            CategoriaId = categoriaId;
            Status = status;
            TipoDespesa = tipoDespesa;
            DataSistema = dataSistema;
        }

        public TipoMovimentacaoEnum Tipo { get; private set; }
        public decimal Valor { get; private set; } 
        public DateTime Data { get; private set; }
        public OrigemMovimentacaoEnum Origem { get; private set; }
        public Guid CategoriaId { get; private set; }
        public StatusEnum? Status { get; private set; }
        public TipoDespesaEnum? TipoDespesa { get; private set; }
        public DadosParcelamento? Parcelamento{ get; private set; }
        public DadosRecorrencia? Recorrencia{ get; private set; }
        public DateTime DataSistema { get; private set; }

        public Categoria Categoria { get; private set; }

        
        //public static Result<Movimentacao> Criar()
        //{

        //}

        public Result Atualizar(TipoMovimentacaoEnum tipo, decimal valor, DateTime data, Guid categoriaId, StatusEnum? status, 
            TipoDespesaEnum? tipoDespesa, DadosParcelamento? dadosParcelamento, DadosRecorrencia? dadosRecorrencia)
        {
            if (!Ativo) return Result.Error(GenericConstantes.MensagensErros.RegistroInativoAtualizar);
            if (Origem != OrigemMovimentacaoEnum.Manual) return Result.Error("Somente movimentações MANUAIS podem ser alteradas!");
            
            if (Categoria.TipoMovimentacao == TipoMovimentacaoEnum.Saida)
            {
                Tipo = tipo;
                Valor = valor;
                Data = data;
                CategoriaId = categoriaId;
                Status = status;
                TipoDespesa = tipoDespesa;
                Parcelamento = dadosParcelamento;
                Recorrencia = dadosRecorrencia;
            }
            else if (Categoria.TipoMovimentacao == TipoMovimentacaoEnum.Entrada)
            {
                Tipo = tipo;
                Valor = valor;
                Data = data;
                CategoriaId = categoriaId;
            }

            return Result.Success();
        }
    }
}
