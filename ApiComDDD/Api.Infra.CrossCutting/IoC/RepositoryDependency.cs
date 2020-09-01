using Api.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces;

namespace Api.Infra.CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICompraRepository, CompraRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutosDaCompraRepository, ProdutosDaCompraRepository>();
        }
    }
}
