using Localization.Resources.AbpUi;
using PaymentGateway.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PaymentGatewayHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentGatewayHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PaymentGatewayResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
