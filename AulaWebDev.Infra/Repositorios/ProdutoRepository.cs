using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<ClienteRepository> _logger;

        public ProdutoRepository(AulaWebDevDbContext dbContext, ILogger<ClienteRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            try
            {
                _dbContext.Add(produto);
                await _dbContext.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return produto;
            }
        }

        public async Task<bool> DeletarAsync(Produto produto)
        {
            try
            {
                _dbContext.Remove(produto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditarAsync(Produto produto)
        {
            try
            {
                _dbContext.Update(produto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Produto?> ObterPorCodigoAsync(int codigo)
        {
            return await _dbContext.Produtos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Produtos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Produto>> ObterTodosAsync()
        {
            return await _dbContext.Produtos.Include(x => x.Categoria).ToListAsync();
        }
    }
}
