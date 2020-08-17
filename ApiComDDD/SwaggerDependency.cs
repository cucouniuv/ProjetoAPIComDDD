using System;

public class SwaggerDependency
{
    public static void AdicionarSwaggerDependency(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Olivetti API",
                    Version = "v1",
                    Description = "API REST created on ASP.NET Core 3.1",
                });
        });
    }

    public static void UsarSwaggerDependency(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Olivetti API");
            c.DocumentTitle = "Olivetti API";
            c.DocExpansion(DocExpansion.List);
        });
    }
}
