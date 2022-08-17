using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Dominio.Validacoes;
using AutoMapper;

namespace AulaWebDev.Aplicacao.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> AlterarAsync(ClienteDto clienteDto)
        {
            if (clienteDto.Id == Guid.Empty)
                return ResultService.Fail<ClienteDto>("ID precisa ser informado");

            var result = await new ClienteDtoValidator().ValidateAsync(clienteDto);
            if (!result.IsValid)
                return ResultService.RequestError<ClienteDto>("Um ou mais erros foram encontrados", result);

            var cliente = await _clienteRepository.ObterClientePorIdAsync(clienteDto.Id);
            if (cliente == null)
                return ResultService.Fail("Cliente nao encontrado");

            //Mapeando propriedades informadas para edição, na entidade ja existente no banco!
            var clienteAtualizado = _mapper.Map(clienteDto, cliente);

            if (await _clienteRepository.EditarAsync(clienteAtualizado))
                return ResultService.Ok("Cliente editado com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o Cliente");
        }

        public async Task<ResultService<ClienteDto>> CriarAsync(ClienteDto clienteDto)
        {
            if(clienteDto == null)
                return ResultService.Fail<ClienteDto>("Objeto nao pode ser nullo");

            var result = await new ClienteDtoValidator().ValidateAsync(clienteDto);
            if (!result.IsValid)
                return ResultService.RequestError<ClienteDto>("Um ou mais erros foram encontrados", result);

            var clientePersistido = await _clienteRepository.CriarAsync(_mapper.Map<Cliente>(clienteDto));
            var clienteDtoPersistido = _mapper.Map<ClienteDto>(clientePersistido);

            return ResultService.Ok(clienteDtoPersistido);
        }

        public async Task<ResultService> DeletarAsync(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
                return ResultService.Fail<ClienteDto>("Id do cliente deve ser informado");

            var cliente = await _clienteRepository.ObterClientePorIdAsync(clienteId);
            if (cliente == null)
                return ResultService.Fail("Cliente nao encontrado");

            if (await _clienteRepository.DeletarAsync(cliente))
                return ResultService.Ok("Cliente removido com sucesso");

            return ResultService.Fail("Ocorreu um erro ao remover o Cliente");
        }

        public async Task<ResultService<ClienteDto>> ObterPorIdAsync(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
                return ResultService.Fail<ClienteDto>("Id do cliente deve ser informado");

            var cliente = await _clienteRepository.ObterClientePorIdAsync(clienteId);
            if (cliente == null)
                return ResultService.Fail<ClienteDto>("Cliente nao encontrado");

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return ResultService.Ok(clienteDto);
        }

        public async Task<ResultService<ICollection<ClienteDto>>> ObterTodosAsync()
        {
            var clientes = await _clienteRepository.ObterTodosClientesAsync();
            var clientesMapeados = _mapper.Map<ICollection<ClienteDto>>(clientes);
            return ResultService.Ok(clientesMapeados);
        }
    }
}
