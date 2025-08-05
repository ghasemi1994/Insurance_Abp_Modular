
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Utility.Captcha;
using Application.Utility.DistributedCache;

namespace Application.Utility;

public static class DenpendencyInjection
{
    public static IServiceCollection AdAdAplicationUtility(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedCache(configuration);
        services.AddCaptcha();
        return services;
    }
}
