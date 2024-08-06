using AtendimentoApplication.Abstractions.Application;
using AtendimentoApplication.Abstractions.Repository;
using AtendimentoDomain.Entities;

namespace AtendimentoApplication.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> GetUserById(Guid userId, CancellationToken ct)
        {
            return await _repository.GetUserById(userId, ct);
        }

        public async Task<User> Add(User atendimento, CancellationToken ct)
        {
            return await _repository.Add(atendimento, ct);
        }

        public async Task<User?> Update(User atendimento, CancellationToken ct)
        {
            return await _repository.Update(atendimento, ct);
        }

        public async Task<bool> Delete(Guid atendimentoId, CancellationToken ct)
        {
            return await _repository.Delete(atendimentoId, ct);
        }
    }
}
