using Api.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.Data
{
    public static class Startup
    {
        public static void Seed<T>(IApplicationBuilder app) where T : ContextInMemory
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                SeedingService seedingService = new SeedingService(context);
                seedingService.Seed();
            }
        }
    }
}
