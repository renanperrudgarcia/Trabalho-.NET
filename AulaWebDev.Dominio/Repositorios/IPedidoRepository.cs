using AulaWebDev.Dominio.Entidades;

namespace AulaWebDev.Dominio.Repositorios
{
    public interface IPedidoRepository
    {
        Task<Pedido> CriarAsync(Pedido pedido);
        Task<bool> DeletarAsync(Pedido pedido);
        Task<ICollection<Pedido>> ObterTodosAsync();
        Task<Pedido?> ObterPorIdAsync(Guid pedidoId);
    }
}
