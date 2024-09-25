using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Application
{
    public interface IAuthService
    {
        Task<string?> Login(User user, CancellationToken cancellationToken);
    }
}