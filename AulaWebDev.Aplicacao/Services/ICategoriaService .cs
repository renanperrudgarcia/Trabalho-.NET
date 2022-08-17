using AulaWebDev.Dominio.DTOs;

namespace AulaWebDev.Aplicacao.Services
{
    public interface ICategoriaService
    {
        Task<ResultService<CategoriaDto>> CriarAsync(CategoriaDto categoriaDto);
        Task<ResultService> AlterarAsync(CategoriaDto categoriaDto);
        Task<ResultService> DeletarAsync(Guid categoriaId);
        Task<ResultService> ObterPorIdAsync(Guid categoriaId);
        Task<ResultService<ICollection<CategoriaDto>>> ObterTodosAsync();
    }
}
