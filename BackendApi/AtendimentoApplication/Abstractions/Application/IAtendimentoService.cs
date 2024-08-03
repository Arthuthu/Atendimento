using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Application
{
    public interface IAtendimentoService
    {
        Task<Atendimento> Add(Atendimento atendimento, CancellationToken ct);
        Task<bool> Delete(Guid atendimentoId, CancellationToken ct);
        Task<Atendimento?> GetAtendimentoById(Guid atendimentoId, CancellationToken ct);
        Task<List<Atendimento>?> GetAtendimentoByUserId(Guid userId, CancellationToken ct);
    }
}