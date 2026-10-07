namespace Mentis.Domain.Metas
{
    public interface IMetaRepository
    {
        Task<Meta> ObtemMetaPeloId(Guid id);
        Task<List<Meta>> ObtemMeta();
        Task<Guid> Criar(Meta meta);
        Task Atualizar();
        Task Inativar();
    }
}
