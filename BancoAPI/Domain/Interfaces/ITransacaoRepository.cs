using BancoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<List<Transacao>> BuscarTransacoesPorClient(int clienteId);
        void CriarTransacao(Transacao transacao);
    }
}
