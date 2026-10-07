using Mentis.Domain.Contas.Movimentacoes;
using MeuCash.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infra.Contas.Movimentacoes
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public MovimentacaoRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> Criar(Movimentacao movimentacao)
        {
            await _dbContext.Movimentacoes.AddAsync(movimentacao);
            await _dbContext.SaveChangesAsync();

            return movimentacao.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Movimentacao> ObtemMovimentacaoPeloId(Guid id)
        {
            return await _dbContext.Movimentacoes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Movimentacao>> ObtemMovimentacoes()
        {
            return await _dbContext.Movimentacoes.ToListAsync();
        }

        public async Task<List<Movimentacao>> ObtemMovimentacoesBancarias()
        {
            return await _dbContext.Movimentacoes
                .Where(x => x.Origem == OrigemMovimentacaoEnum.Banco)
                .ToListAsync();
        }

        public async Task<List<Movimentacao>> ObtemMovimentacoesEntradas()
        {
            return await _dbContext.Movimentacoes
                .Where(x => x.Tipo == TipoMovimentacaoEnum.Entrada)
                .ToListAsync();
        }

        public async Task<List<Movimentacao>> ObtemMovimentacoesManuais()
        {
            return await _dbContext.Movimentacoes
                .Where(x => x.Origem == OrigemMovimentacaoEnum.Manual)
                .ToListAsync();
        }

        public async Task<List<Movimentacao>> ObtemMovimentacoesSaidas()
        {
            return await _dbContext.Movimentacoes
                .Where(x => x.Tipo == TipoMovimentacaoEnum.Saida)
                .ToListAsync();
        }
    }
}
