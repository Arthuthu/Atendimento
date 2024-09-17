using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IUserService
    {
        Task<string?> Add(User user);
        Task<string?> Delete(Guid id);
        Task<User?> GetById(Guid id);
    }
}