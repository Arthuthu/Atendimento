using AtendimentoDomain.Entities;
using AtendimentoInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Repositories
{
    public sealed class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Atendimento?> GetAtendimentoById(Guid atendimentoId, CancellationToken ct)
        {
            Atendimento? atendimento = await _context.Atendimento.FindAsync(atendimentoId, ct);
            return atendimento;
        }

        public async Task<List<Atendimento>?> GetAtendimentosByUserId(Guid userId, CancellationToken ct)
        {
            List<Atendimento> atendimentos = await _context.Atendimento.Where(x => x.UserId == userId).ToListAsync(ct);
            return atendimentos;
        }

        public async Task<Atendimento> Add(Atendimento atendimento, CancellationToken ct)
        {
            await _context.AddAsync(atendimento, ct);
            await _context.SaveChangesAsync(ct);

            return atendimento;
        }

        public async Task<Atendimento?> Update(Atendimento atendimento, CancellationToken ct)
        {
            Atendimento? requestedAtendimento = await _context.Atendimento.SingleOrDefaultAsync(x => x.Id == atendimento.Id);

            if (requestedAtendimento is null)
            {
                return null;
            }

            requestedAtendimento.Codigo = atendimento.Codigo;
            requestedAtendimento.Versao = atendimento.Versao;
            requestedAtendimento.Descricao = atendimento.Descricao;

            _context.Atendimento.Update(requestedAtendimento);
            await _context.SaveChangesAsync(ct);

            return requestedAtendimento;
        }

        public async Task<bool> Delete(Guid id, CancellationToken ct)
        {
            int affectedRows = await _context.Atendimento.Where(x => x.Id == id).ExecuteDeleteAsync(ct);
            return affectedRows > 0;
        }
    }
}
