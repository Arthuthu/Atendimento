using AtendimentoApplication.Abstractions.Repository;
using AtendimentoDomain.Entities;
using AtendimentoInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserById(Guid id, CancellationToken ct)
        {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Add(User user, CancellationToken ct)
        {
            await _context.AddAsync(user, ct);
            await _context.SaveChangesAsync(ct);

            return user;
        }

        public async Task<bool> Delete(Guid id, CancellationToken ct)
        {
            int affectedRows = await _context.Atendimento.Where(x => x.Id == id).ExecuteDeleteAsync(ct);
            return affectedRows > 0;
        }
    }
}
