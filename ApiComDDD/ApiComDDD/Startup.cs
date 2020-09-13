using Api.Infra.CrossCutting.IoC;
using Api.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiComDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContextDependency();
            services.AddRepositoryDependency();
            services.AddNewtonsoftJsonDependency();
            services.AddServiceDependency();
            services.AddSwaggerDependency();

            services.AddMvc(config =>
            {
                config.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                Api.Infra.Data.Startup.Seed<ContextInMemory>(app);
            }
            
            app.UseSwaggerDependency();
            app.UseMvc();
        }
    }
}
