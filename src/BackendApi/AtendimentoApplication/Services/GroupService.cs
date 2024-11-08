using AtendimentoApplication.Abstractions.Application;
using AtendimentoApplication.Abstractions.Repository;
using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Services
{
    public sealed class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Group>?> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Group?> GetGroupById(Guid groupId, CancellationToken ct)
        {
            return await _repository.GetGroupById(groupId, ct);
        }

        public async Task<List<Group>?> GetGroupsByUserId(Guid id, CancellationToken ct)
        {
            return await _repository.GetGroupsByUserId(id, ct);
        }

        public async Task<string?> Add(Group user, CancellationToken ct)
        {
            try
            {

                await _repository.Add(user, ct);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Group?> Update(Group group, CancellationToken ct)
        {
            return await _repository.Update(group, ct);
        }

        public async Task<bool> Delete(Guid id, CancellationToken ct)
        {
            return await _repository.Delete(id, ct);
        }

    }
}
