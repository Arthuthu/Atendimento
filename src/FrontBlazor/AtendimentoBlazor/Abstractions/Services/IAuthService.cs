using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IAuthService
    {
        Task<string?> Login(Auth auth);
    }
}