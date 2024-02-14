using BancoAPI.Domain;
using BancoAPI.Domain.Interfaces;
using BancoAPI.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async void CadastrarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public async void AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public async Task<ExtratoViewModel> GetExtratoCliente(int id)
        {
            var extrato = await _context.Clientes
                .Where(c => c.Id == id)
                .Select(c => new ExtratoViewModel
                {
                    Saldo = new Saldo
                    {
                        Total = c.Saldo,
                        Data_extrato = DateTime.Now, 
                        Limite = c.Limite
                    },
                    Ultimas_transacoes = c.Transacoes
                        .OrderByDescending(t => t.Realizada_Em)
                        .Take(10)
                        .Select(t => new Transacoes
                        {
                            Valor = t.Valor,
                            Tipo = t.Tipo,
                            Descricao = t.Descricao,
                            Realizada_em = t.Realizada_Em
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return extrato;
        }
    }
}
