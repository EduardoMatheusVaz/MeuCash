namespace Mentis.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtemUsuarioPeloId(Guid id);
        Task<List<Usuario>> ObtemUsuariosAtivos();
        Task<List<Usuario>> ObtemUsuariosInativos();
        Task<Guid> Criar(Usuario usuario);
        Task Atualizar();
        Task Inativar();
    }
}
