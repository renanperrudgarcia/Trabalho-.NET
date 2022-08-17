using AulaWebDev.Dominio.Entidades;

namespace AulaWebDev.Dominio.Repositorios
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<bool> EditarAsync(Categoria categoria);
        Task<bool> DeletarAsync(Categoria categoria);
        Task<Categoria?> ObterPorIdAsync(Guid id);
        Task<Categoria?> ObterPorCodigoAsync(int codigo);
        Task<ICollection<Categoria>> ObterTodosAsync();
    }
}
