using BancoAPI.Domain;
using BancoAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transacao>> BuscarTransacoesPorClient(int clienteId)
        {
            return await _context.Transacoes.Where(t => t.ClienteId == clienteId).ToListAsync();
        }

        public void CriarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }
    }
}
