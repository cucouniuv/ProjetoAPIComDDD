using Api.Domain.Interfaces;
using Api.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.IoC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaService, EmpresaService>();
        }
    }
}
