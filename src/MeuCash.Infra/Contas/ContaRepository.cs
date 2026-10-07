using Mentis.Domain.Contas;
using MeuCash.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infra.Contas
{
    public class ContaRepository : IContaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public ContaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> Criar(Conta conta)
        {
            await _dbContext.Contas.AddAsync(conta);
            await _dbContext.SaveChangesAsync();

            return conta.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Conta> ObtemContaPeloId(Guid id)
        {
            return await _dbContext.Contas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Conta>> ObtemContas()
        {
            return await _dbContext.Contas.ToListAsync();
        }
    }
}
