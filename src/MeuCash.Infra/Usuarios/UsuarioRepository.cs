using Mentis.Domain.Usuarios;
using MeuCash.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infra.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public UsuarioRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> Criar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Usuario> ObtemUsuarioPeloId(Guid id)
        {
            return await _dbContext.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> ObtemUsuariosAtivos()
        {
            return await _dbContext.Usuarios
                .Where(x => x.Ativo)
                .ToListAsync();
        }

        public async Task<List<Usuario>> ObtemUsuariosInativos()
        {
            return await _dbContext.Usuarios
                .Where(x => !x.Ativo)
                .ToListAsync();
        }
    }
}
