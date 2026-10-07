using Mentis.Domain.Categorias;
using Mentis.Domain.Contas.Movimentacoes;
using MeuCash.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infra.Categorias
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public CategoriaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> Criar(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Categoria> ObtemCategoriaPeloId(Guid id)
        {
            return await _dbContext.Categorias.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Categoria>> ObtemCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<List<Categoria>> ObtemCategoriasDespesas()
        {
            return await _dbContext.Categorias
                .Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Saida).ToListAsync();
        }

        public async Task<List<Categoria>> ObtemCategoriasEntradas()
        {
            return await _dbContext.Categorias
                .Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Entrada).ToListAsync();
        }
    }
}
