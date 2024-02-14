using BancoAPI.Domain;
using BancoAPI.Domain.Interfaces;
using BancoAPI.Filters.Exceptions;
using BancoAPI.Requests;
using BancoAPI.Response;

namespace BancoAPI.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(IClienteRepository clienteRepository, ITransacaoRepository transacaoRepository)
        {
            _clienteRepository = clienteRepository;
            _transacaoRepository = transacaoRepository;
        }

        public async Task<TransacaoResponse> CreateTransacao(TransacaoRequest request)
        {
            var usuario = await _clienteRepository.GetById(request.Id) ?? throw new NotFoundException("Usuário não encontrado");
            int novoSaldo;

            if (request.Tipo == 'c')
            {
                novoSaldo = usuario.Saldo + request.Valor;

            } else
            {
                novoSaldo = usuario.Saldo - request.Valor;

                if (novoSaldo < (usuario.Limite * -1))
                {
                    throw new SaldoInconsistenteException("Transação não pode ser completada: saldo ficará menor que o limite.");
                }
            }

            usuario.Saldo = novoSaldo;
            
            _clienteRepository.AtualizarCliente(usuario);
            CriarTransacao(usuario.Id, request);

            return new TransacaoResponse(usuario.Limite, usuario.Saldo);
        }

        private void CriarTransacao(int usuarioId, TransacaoRequest request)
        {
            var transacao = new Transacao(usuarioId, request.Valor, request.Tipo, request.Descricao);

            _transacaoRepository.CriarTransacao(transacao);
        }
    }
}
