using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace PaymentGateway;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class PaymentGatewayInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentGatewayInstallerModule>();
        });
    }
}
