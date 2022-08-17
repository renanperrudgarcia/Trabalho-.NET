using AulaWebDev.Dominio.Entidades;

namespace AulaWebDev.Dominio.Repositorios
{
    public interface IProdutoRepository
    {
        Task<Produto> CriarAsync(Produto produto);
        Task<bool> EditarAsync(Produto produto);
        Task<bool> DeletarAsync(Produto produto);
        Task<Produto> ObterPorIdAsync(Guid id);
        Task<Produto?> ObterPorCodigoAsync(int codigo);
        Task<ICollection<Produto>> ObterTodosAsync();
    }
}
