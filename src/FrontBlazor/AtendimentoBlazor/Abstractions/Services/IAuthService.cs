using AtendimentoBlazor.Entities;
using System.Security.Claims;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedUserModel?> Login(AuthModel userForAuthentication);
        IEnumerable<Claim>? GetUserClaims();
        string? GetUserToken();
        Task LogoutAsync();
    }
}