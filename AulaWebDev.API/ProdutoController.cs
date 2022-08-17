using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebDev.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _produtoService.ObterTodosAsync();
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{produtoId}")]
        public async Task<IActionResult> GetAsync(Guid produtoId)
        {
            var result = await _produtoService.ObterPorIdAsync(produtoId);
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoDto produtoDto)
        {
            var result = await _produtoService.CriarAsync(produtoDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{produtoId}")]
        public async Task<IActionResult> PutAsync(Guid produtoId, [FromBody] ProdutoDto produtoDto)
        {
            produtoDto.Id = produtoId;
            var result = await _produtoService.AlterarAsync(produtoDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{produtoId}")]
        public async Task<IActionResult> DeleteAsync(Guid produtoId)
        {
            var result = await _produtoService.DeletarAsync(produtoId);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
