namespace Mentis.Domain.Contas
{
    public interface IContaRepository
    {
        Task<Conta> ObtemContaPeloId(Guid id);
        Task<List<Conta>> ObtemContas();
        Task<Guid> Criar(Conta conta);
        Task Atualizar();
        Task Inativar();
    }
}
