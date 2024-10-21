using Hidrolik.Core.Jwt.Abstract;
using Hidrolik.Core.Jwt.Concrete;

namespace Hidrolik.API.Configurations;

public static class JwtServiceCollectionExtension
{
    public static IServiceCollection JwtServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
