namespace Mentis.Domain.Categorias
{
    public interface ICategoriaRepository
    {
        Task<Categoria> ObtemCategoriaPeloId(Guid id);
        Task <List<Categoria>> ObtemCategorias();
        Task<List<Categoria>> ObtemCategoriasEntradas();
        Task<List<Categoria>> ObtemCategoriasDespesas();
        Task<Guid> Criar(Categoria categoria);
        Task Atualizar();
        Task Inativar();
    }
}
