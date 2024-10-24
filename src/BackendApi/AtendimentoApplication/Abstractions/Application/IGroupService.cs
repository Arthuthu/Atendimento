using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Application
{
    public interface IGroupService
    {
        Task<string?> Add(Group user, CancellationToken ct);
        Task<bool> Delete(Guid id, CancellationToken ct);
        Task<List<Group>?> GetGroupsByUserId(Guid id, CancellationToken ct);
        Task<Group?> GetGroupById(Guid groupId, CancellationToken ct);
        Task<Group?> Update(Group group, CancellationToken ct);
    }
}