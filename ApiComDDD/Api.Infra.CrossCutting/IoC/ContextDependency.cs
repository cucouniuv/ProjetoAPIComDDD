using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.IoC
{
    public static class ContextDependency
    {
        public static void AddContextDependency(this IServiceCollection services)
        {
            services.AddDbContext<ContextInMemory>(opt =>
                            opt.UseInMemoryDatabase("ContextInMemory"));
        }
    }
}
