using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IGroupService
    {
        Task<string?> Add(GroupModel group);
        Task<List<GroupModel>?> GetGroupsByUserId(Guid id);
        Task<string?> Delete(Guid id);
        Task<GroupModel?> GetById(Guid id);
    }
}