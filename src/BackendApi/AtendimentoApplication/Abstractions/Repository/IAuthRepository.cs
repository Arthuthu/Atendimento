using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Repository
{
    public interface IAuthRepository
    {
        Task<User?> Login(User user, CancellationToken cancellationToken);
    }
}