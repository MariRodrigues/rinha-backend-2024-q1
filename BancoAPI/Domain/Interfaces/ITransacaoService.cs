using BancoAPI.Requests;
using BancoAPI.Response;

namespace BancoAPI.Domain.Interfaces
{
    public interface ITransacaoService
    {
        Task<TransacaoResponse> CreateTransacao(TransacaoRequest request);
    }
}
