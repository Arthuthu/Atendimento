using AtendimentoApplication.Abstractions.Repository;
using AtendimentoDomain.Entities;
using AtendimentoInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Repositories
{
    public sealed class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group?> GetGroupById(Guid id, CancellationToken ct)
        {
            Group? group = await _context.Group.FindAsync(id);
            return group;
        }

        public async Task<List<Group>?> GetGroupsByUserId(Guid id, CancellationToken ct)
        {
            List<Group>? groups = await _context.Group.Where(x => x.UsersId != null &&
            x.UsersId.Contains(id)).ToListAsync();

            return groups;
        }

        public async Task<Group?> Add(Group group, CancellationToken ct)
        {
            await _context.AddAsync(group, ct);
            await _context.SaveChangesAsync(ct);

            return null;
        }
        public async Task<Group?> Update(Group group, CancellationToken ct)
        {
            Group? requestedGroup = await _context.Group.SingleOrDefaultAsync(x => x.Id == group.Id);

            if (requestedGroup is null)
            {
                return null;
            }

            requestedGroup.Name = group.Name;

            _context.Group.Update(requestedGroup);
            await _context.SaveChangesAsync(ct);

            return requestedGroup;
        }

        public async Task<bool> Delete(Guid id, CancellationToken ct)
        {
            int affectedRows = await _context.Atendimento.Where(x => x.Id == id).ExecuteDeleteAsync(ct);
            return affectedRows > 0;
        }
    }
}
