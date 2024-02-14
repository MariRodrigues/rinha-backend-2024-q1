using BancoAPI.Domain.ViewModels;

namespace BancoAPI.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetById(int id);
        void CadastrarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        Task<ExtratoViewModel> GetExtratoCliente(int id);
    }
}
