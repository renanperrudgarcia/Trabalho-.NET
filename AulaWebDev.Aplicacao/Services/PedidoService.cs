using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Dominio.Validacoes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Aplicacao.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IMapper mapper,
            IPedidoRepository pedidoRepository, 
            IProdutoRepository produtoRepository, 
            IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultService<PedidoResponseDto>> CriarAsync(PedidoDto pedidoDto)
        {
            if (pedidoDto == null)
                return ResultService.Fail<PedidoResponseDto>("Pedido deve ser informado");

            var validationResult = await new PedidoDtoValidator().ValidateAsync(pedidoDto);
            if(!validationResult.IsValid)
                return ResultService.RequestError<PedidoResponseDto>("Um ou mais erros foram encontrados", validationResult);

            var cliente = await _clienteRepository.ObterClientePorDocumentoAsync(pedidoDto.DocumentoCliente);
            if (cliente == null)
                return ResultService.Fail<PedidoResponseDto>("Cliente nao encontrado");

            var produto = await _produtoRepository.ObterPorCodigoAsync(pedidoDto.CodigoProduto);
            if (produto == null)
                return ResultService.Fail<PedidoResponseDto>("Produto nao encontrado");

            var pedido = new Pedido(cliente.Id, produto.Id);
            var pedidoPersistido = await _pedidoRepository.CriarAsync(pedido);
            var pedidoMapeado = _mapper.Map<PedidoResponseDto>(pedidoPersistido);
            return ResultService.Ok(pedidoMapeado);
        }

        public async Task<ResultService> DeletarAsync(Guid pedidoId)
        {
            if (pedidoId == Guid.Empty)
                return ResultService.Fail<PedidoResponseDto>("Id deve ser informado");

            var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);
            if (pedido == null)
                return ResultService.Fail<PedidoResponseDto>("Pedido não encontrado");

            if (await _pedidoRepository.DeletarAsync(pedido))
                return ResultService.Ok("Pedido removido com sucesso");

            return ResultService.Fail<PedidoResponseDto>("Ocorreu um erro ao remover pedido");
        }

        public async Task<ResultService<PedidoResponseDto>> ObterPorIdAsync(Guid pedidoId)
        {
            if (pedidoId == Guid.Empty)
                return ResultService.Fail<PedidoResponseDto>("Id deve ser informado");

            var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);
            if (pedido == null)
                return ResultService.Fail<PedidoResponseDto>("Pedido não encontrado");

            var pedidoMapeado = _mapper.Map<PedidoResponseDto>(pedido);
            return ResultService.Ok(pedidoMapeado);
        }

        public async Task<ResultService<ICollection<PedidoResponseDto>>> ObterTodosAsync()
        {
            var pedidos = await _pedidoRepository.ObterTodosAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PedidoResponseDto>>(pedidos));
        }
    }
}
