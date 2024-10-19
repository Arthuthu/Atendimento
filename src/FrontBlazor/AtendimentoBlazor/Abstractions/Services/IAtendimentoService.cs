using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Abstractions.Services
{
    public interface IAtendimentoService
    {
        Task<string?> Add(AtendimentoModel atendimento);
        Task<string?> Delete(Guid id);
        Task<AtendimentoModel?> GetById(Guid id);
        Task<List<AtendimentoModel>?> GetAtendimentosByUserId(Guid userId);
    }
}