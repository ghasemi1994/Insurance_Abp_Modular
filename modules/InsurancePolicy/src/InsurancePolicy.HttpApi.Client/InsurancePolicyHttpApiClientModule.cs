using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace InsurancePolicy;

[DependsOn(
    typeof(InsurancePolicyApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class InsurancePolicyHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(InsurancePolicyApplicationContractsModule).Assembly,
            InsurancePolicyRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<InsurancePolicyHttpApiClientModule>();
        });

    }
}
