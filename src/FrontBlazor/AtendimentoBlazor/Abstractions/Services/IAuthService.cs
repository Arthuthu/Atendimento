using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedUserModel?> Login(AuthModel userForAuthentication);
        string? GetUserToken();
        Task LogoutAsync();
    }
}