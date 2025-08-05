using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using PaymentGateway.EntityFrameworkCore;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayDomainModule),
    typeof(PaymentGatewayApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(PaymentGatewayEntityFrameworkCoreModule)
    )]
public class PaymentGatewayApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PaymentGatewayApplicationModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PaymentGatewayApplicationModule>(validate: true);
        });
    }
}
