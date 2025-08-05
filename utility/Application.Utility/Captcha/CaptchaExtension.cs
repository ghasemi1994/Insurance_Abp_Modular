using Microsoft.Extensions.DependencyInjection;

namespace Application.Utility.Captcha;

public static class CaptchaExtension
{

    public static IServiceCollection AddCaptcha(this IServiceCollection services)
    {

        services.AddScoped<ICaptchaService, CaptchaService>();

        return services;
    }
}
