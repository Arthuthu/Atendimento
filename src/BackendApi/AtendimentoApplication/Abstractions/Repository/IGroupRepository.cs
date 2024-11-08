using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Abstractions.Repository
{
    public interface IGroupRepository
    {
        Task<Group?> Add(Group group, CancellationToken ct);
        Task<bool> Delete(Guid id, CancellationToken ct);
        Task<List<Group>?> GetGroupsByUserId(Guid id, CancellationToken ct);
        Task<Group?> GetGroupById(Guid id, CancellationToken ct);
        Task<Group?> Update(Group group, CancellationToken ct);
        Task<List<Group>?> GetAll();
    }
}