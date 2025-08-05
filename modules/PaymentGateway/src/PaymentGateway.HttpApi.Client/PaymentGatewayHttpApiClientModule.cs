using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class PaymentGatewayHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(PaymentGatewayApplicationContractsModule).Assembly,
            PaymentGatewayRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentGatewayHttpApiClientModule>();
        });

    }
}
