using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebDev.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoriaService.ObterTodosAsync();
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{categoriaId}")]
        public async Task<IActionResult> GetAsync(Guid categoriaId)
        {
            var result = await _categoriaService.ObterPorIdAsync(categoriaId);
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoriaDto categoriaDto)
        {
            var result = await _categoriaService.CriarAsync(categoriaDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{categoriaId}")]
        public async Task<IActionResult> PutAsync(Guid categoriaId, [FromBody] CategoriaDto categoriaDto)
        {
            categoriaDto.Id = categoriaId;
            var result = await _categoriaService.AlterarAsync(categoriaDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{categoriaId}")]
        public async Task<IActionResult> DeleteAsync(Guid categoriaId)
        {
            var result = await _categoriaService.DeletarAsync(categoriaId);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
