using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Application
{
    public interface IUserService
    {
        Task<User> Add(User atendimento, CancellationToken ct);
        Task<bool> Delete(Guid atendimentoId, CancellationToken ct);
        Task<User?> GetUserById(Guid userId, CancellationToken ct);
        Task<User?> Update(User atendimento, CancellationToken ct);
    }
}