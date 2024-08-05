using AtendimentoDomain.Entities;

namespace AtendimentoInfra.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> Add(Atendimento atendimento, CancellationToken ct);
        Task<bool> Delete(Guid id, CancellationToken ct);
        Task<Atendimento?> GetAtendimentoById(Guid atendimentoId, CancellationToken ct);
        Task<List<Atendimento>?> GetAtendimentosByUserId(Guid userId, CancellationToken ct);
    }
}