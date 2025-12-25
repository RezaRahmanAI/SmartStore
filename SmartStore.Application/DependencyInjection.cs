using Microsoft.Extensions.DependencyInjection;
using SmartStore.Application.Services;

namespace SmartStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
