using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AulaWebDev.Infra.Context
{
    public class AulaWebDevDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public AulaWebDevDbContext(DbContextOptions<AulaWebDevDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AulaWebDevDbContext).Assembly);
        }
    }
}
