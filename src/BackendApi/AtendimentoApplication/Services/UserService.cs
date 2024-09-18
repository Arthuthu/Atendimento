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

        public async Task<string?> Add(User user, CancellationToken ct)
        {
            try
            {
                string? resultado = await VerificaRegistroUsuario(user);
                if (resultado is not null) 
                { 
                    return resultado; 
                }

                await _repository.Add(user, ct);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<User?> Update(User user, CancellationToken ct)
        {
            return await _repository.Update(user, ct);
        }

        public async Task<bool> Delete(Guid userId, CancellationToken ct)
        {
            return await _repository.Delete(userId, ct);
        }
        
        private async Task<string?> VerificaRegistroUsuario(User user)
        {
            User? requestedUserByEmail = await _repository.GetUserByEmail(user);
            if (requestedUserByEmail is not null)
            {
                return "Ja existe um usuário cadastrado com esse email";
            }

            User? requestedUserByUsername = await _repository.GetUserByUsername(user);
            if (requestedUserByUsername is not null)
            {
                return "Ja existe um usuário cadastrado com esse username";
            }

            return null;
        }
    }
}
