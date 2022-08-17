using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.Mapeamentos;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using AulaWebDev.Infra.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AulaWebDev.Infra.Dependencias
{
    public static class InjecaoDependenciaExtension
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnectionString");
            services.AddSqlite<AulaWebDevDbContext>(connectionString);

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoParaEntidadeMapping));
            services.AddAutoMapper(typeof(EntidadeParaDtoMapping));

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}
