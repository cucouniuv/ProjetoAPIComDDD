using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

public static class SwaggerDependency
{
    public static void AddSwaggerDependency(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Projeto Mentoria API",
                    Version = "v1",
                    Description = "API REST criada com ASP.NET Core 3.1",
                });
        });
    }

    public static void UseSwaggerDependency(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Mentoria API");
            c.DocumentTitle = "Projeto Mentoria API";
            c.DocExpansion(DocExpansion.List);
        });
    }
}
