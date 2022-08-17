using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(AulaWebDevDbContext dbContext, ILogger<ClienteRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente)
        {
            try
            {
                _dbContext.Add(cliente);
                await _dbContext.SaveChangesAsync();
                return cliente;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return cliente;
            }
        }

        public async Task<bool> DeletarAsync(Cliente cliente)
        {
            try
            {
                _dbContext.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditarAsync(Cliente cliente)
        {
            try
            {
                _dbContext.Update(cliente);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Cliente?> ObterClientePorIdAsync(Guid clienteId)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId);
        }

        public async Task<Cliente?> ObterClientePorDocumentoAsync(string documento)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Documento == documento);
        }

        public async Task<ICollection<Cliente>> ObterTodosClientesAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

    }
}
