using Microsoft.Extensions.DependencyInjection;

namespace BlazorUse;

public static class ServiceCollectionExtensions
{
    public static void AddBlazorUse(this IServiceCollection services)
    {
        services.AddScoped<BlazorUse>();
    }
}