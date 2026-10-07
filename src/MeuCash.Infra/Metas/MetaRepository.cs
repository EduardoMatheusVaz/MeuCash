using Mentis.Domain.Metas;
using MeuCash.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infra.Metas
{
    public class MetaRepository : IMetaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public MetaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> Criar(Meta meta)
        {
            await _dbContext.Metas.AddAsync(meta);
            await _dbContext.SaveChangesAsync();

            return meta.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Meta>> ObtemMeta()
        {
            return await _dbContext.Metas.ToListAsync();
        }

        public async Task<Meta> ObtemMetaPeloId(Guid id)
        {
            return await _dbContext.Metas.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
