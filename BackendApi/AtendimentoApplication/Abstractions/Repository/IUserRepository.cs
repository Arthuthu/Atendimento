using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Repository
{
    public interface IUserRepository
    {
        Task<User> Add(User user, CancellationToken ct);
        Task<User?> Update(User user, CancellationToken ct);
        Task<bool> Delete(Guid id, CancellationToken ct);
        Task<User?> GetUserById(Guid id, CancellationToken ct);
    }
}