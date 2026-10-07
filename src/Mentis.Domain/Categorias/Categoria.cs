using Mentis.Domain.Constantes;
using Mentis.Domain.Contas.Movimentacoes;

namespace Mentis.Domain.Categorias
{
    public sealed class Categoria : BaseEntity
    {
        public Categoria() { }

        public Categoria(string nome, TipoMovimentacaoEnum tipoMovimentacao)
        {
            Nome = nome;
            TipoMovimentacao = tipoMovimentacao;
        }

        public string Nome { get; private set; }
        public TipoMovimentacaoEnum TipoMovimentacao { get; private set; }

        public ICollection<Movimentacao> Movimentacoes { get; private set; } = [];
        

        public static Result<Categoria> Criar(string nome, TipoMovimentacaoEnum tipoMovimentacao)
        {
            if (tipoMovimentacao != TipoMovimentacaoEnum.Entrada && tipoMovimentacao != TipoMovimentacaoEnum.Saida)
                return Result<Categoria>.Erro("Tipo de movimentação informada é inválida");

            var categoria = new Categoria(nome: nome, tipoMovimentacao: tipoMovimentacao);
            categoria.Ativar();

            return Result<Categoria>.Sucesso(categoria);
        }

        public Result Atualizar(string nome, TipoMovimentacaoEnum tipoMovimentacao)
        {
            if (!Ativo) return Result.Error(GenericConstantes.MensagensErros.RegistroInativoAtualizar);

            Nome = nome;
            TipoMovimentacao = tipoMovimentacao;

            return Result.Success();
        }
    }
}
