using AtendimentoApplication.Abstractions.Application;
using AtendimentoDomain.Entities;
using AtendimentoInfra.Repositories;

namespace AtendimentoApplication.Services
{
    public sealed class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _repository;

        public AtendimentoService(IAtendimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Atendimento?> GetAtendimentoById(Guid atendimentoId, CancellationToken ct)
        {
            return await _repository.GetAtendimentosById(atendimentoId, ct);
        }

        public async Task<List<Atendimento>?> GetAtendimentoByUserId(Guid userId, CancellationToken ct)
        {
            return await _repository.GetAtendimentosByUserId(userId, ct);
        }

        public async Task<Atendimento> Add(Atendimento atendimento, CancellationToken ct)
        {
            return await _repository.Add(atendimento, ct);
        }

        public async Task<bool> Delete(Guid atendimentoId, CancellationToken ct)
        {
            return await _repository.Delete(atendimentoId, ct);
        }
    }
}
