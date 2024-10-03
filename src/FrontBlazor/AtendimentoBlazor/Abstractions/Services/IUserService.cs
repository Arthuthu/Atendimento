using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IUserService
    {
        Task<string?> Add(UserModel user);
        Task<string?> Delete(Guid id);
        Task<UserModel?> GetById(Guid id);
    }
}