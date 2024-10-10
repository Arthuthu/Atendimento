using AtendimentoBlazor.Entities;
using AtendimentoBlazor.Enums;
using System.Security.Claims;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedUserModel?> Login(AuthModel userForAuthentication);
        IEnumerable<Claim>? GetUserClaims();
        string? GetUserToken();
        string? GetTokenClaimValue(TokenClaimTypes tokenClaim);
        Task LogoutAsync();
    }
}