using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<PedidoRepository> _logger;

        public PedidoRepository(AulaWebDevDbContext dbContext, ILogger<PedidoRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Pedido> CriarAsync(Pedido pedido)
        {
            try
            {
                _dbContext.Add(pedido);
                await _dbContext.SaveChangesAsync();
                return pedido;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return pedido;
            }
        }

        public async Task<bool> DeletarAsync(Pedido pedido)
        {
            try
            {
                _dbContext.Remove(pedido);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Pedido?> ObterPorIdAsync(Guid pedidoId)
        {
            return await _dbContext.Pedidos
                .Include(x => x.Produto)
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.Id == pedidoId);
        }

        public async Task<ICollection<Pedido>> ObterTodosAsync()
        {
            return await _dbContext.Pedidos
                .Include(x => x.Produto)
                .Include(x => x.Produto.Categoria)
                .Include(x => x.Cliente)
                .OrderBy(x => x.DataPedido)
                .ToListAsync();
        }
    }
}
