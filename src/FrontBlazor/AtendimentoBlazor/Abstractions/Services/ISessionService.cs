namespace AtendimentoBlazor.Abstractions.Services
{
    public interface ISessionService
    {
        Task<Guid> GetLoggedInUserId();
    }
}