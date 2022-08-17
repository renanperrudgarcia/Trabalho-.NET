using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<ClienteRepository> _logger;

        public CategoriaRepository(AulaWebDevDbContext dbContext, ILogger<ClienteRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Add(categoria);
                await _dbContext.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return categoria;
            }
        }

        public async Task<bool> DeletarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Remove(categoria);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Update(categoria);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Categoria?> ObterPorCodigoAsync(int codigo)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<Categoria?> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Categoria>> ObterTodosAsync()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}
