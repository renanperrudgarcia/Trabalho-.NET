using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebDev.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _pedidoService.ObterTodosAsync();
            if (result.Sucesso)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet, Route("{pedidoId}")]
        public async Task<IActionResult> GetAsync(Guid pedidoId)
        {
            var result = await _pedidoService.ObterPorIdAsync(pedidoId);
            if (result.Sucesso)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PedidoDto pedidoDto)
        {
            var result = await _pedidoService.CriarAsync(pedidoDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{pedidoId}")]
        public async Task<IActionResult> DeleteAsync(Guid pedidoId)
        {
            var result = await _pedidoService.DeletarAsync(pedidoId);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
