namespace Mentis.Domain.Contas.Movimentacoes
{
    public interface IMovimentacaoRepository
    {
        Task<Movimentacao> ObtemMovimentacaoPeloId(Guid id);
        Task<List<Movimentacao>> ObtemMovimentacoes();
        Task<List<Movimentacao>> ObtemMovimentacoesEntradas();
        Task<List<Movimentacao>> ObtemMovimentacoesSaidas();
        Task<List<Movimentacao>> ObtemMovimentacoesBancarias();
        Task<List<Movimentacao>> ObtemMovimentacoesManuais();
        Task<Guid> Criar(Movimentacao movimentacao);
        Task Atualizar();
        Task Inativar();
    }
}
