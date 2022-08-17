using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebDev.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _clienteService.ObterTodosAsync();
            if (result.Sucesso)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet, Route("{clienteId}")]
        public async Task<IActionResult> GetAsync(Guid clienteId)
        {
            var result = await _clienteService.ObterPorIdAsync(clienteId);
            if (result.Sucesso)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClienteDto clienteDto)
        {
            var result = await _clienteService.CriarAsync(clienteDto);

            if(result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{clienteId}")]
        public async Task<IActionResult> PutAsync(Guid clienteId, [FromBody] ClienteDto clienteDto)
        {
            clienteDto.Id = clienteId;
            var result = await _clienteService.AlterarAsync(clienteDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{clienteId}")]
        public async Task<IActionResult> DeleteAsync(Guid clienteId)
        {
            var result = await _clienteService.DeletarAsync(clienteId);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
