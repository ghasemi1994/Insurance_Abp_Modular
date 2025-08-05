using Localization.Resources.AbpUi;
using InsurancePolicy.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace InsurancePolicy;

[DependsOn(
    typeof(InsurancePolicyApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class InsurancePolicyHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(InsurancePolicyHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<InsurancePolicyResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
