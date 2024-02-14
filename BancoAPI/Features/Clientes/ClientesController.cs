using BancoAPI.Domain.Interfaces;
using BancoAPI.Filters.Exceptions;
using BancoAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BancoAPI.Features.Clientes
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(ITransacaoService transacaoService, IClienteRepository clienteRepository)
        {
            _transacaoService = transacaoService;
            _clienteRepository = clienteRepository;
        }

        [HttpPost("{id}/transacoes")]
        [SwaggerOperation(Summary = "Realiza nova transação",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CriaTransacoes(int id, [FromBody] TransacaoRequest request)
        {
            request.Id = id;
            var tipo = char.ToLower(request.Tipo);

            if (tipo != 'c' && tipo != 'd')
                throw new BadRequestException("Tipo precisa ser 'd' (depósito) ou 'c' (crédito).");

            var response = await _transacaoService.CreateTransacao(request);

            return Ok(response);
        }

        [HttpGet("{id}/extrato")]
        [SwaggerOperation(Summary = "Busca extrato por cliente",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscaExtratoPorCliente(int id)
        {
            var cliente = await _clienteRepository.GetById(id);

            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado.");

            var extrato = await _clienteRepository.GetExtratoCliente(id);

            return Ok(extrato);
        }
    }
}
