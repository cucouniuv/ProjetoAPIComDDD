using Api.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces;

namespace Api.Infra.CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            //services.AddScoped<IRepositoryBase<Empresa>, RepositoryBase<Empresa>>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
