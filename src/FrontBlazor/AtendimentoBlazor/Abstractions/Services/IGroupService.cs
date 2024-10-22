using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IGroupService
    {
        Task<string?> Add(GroupModel group);
        Task<string?> Delete(Guid id);
        Task<GroupModel?> GetById(Guid id);
    }
}