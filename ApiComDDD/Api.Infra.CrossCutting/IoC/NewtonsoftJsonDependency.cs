using Microsoft.Extensions.DependencyInjection;

public static class NewtonsoftJsonDependency
{
    public static void AddNewtonsoftJsonDependency(this IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(opt => 
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }
}
