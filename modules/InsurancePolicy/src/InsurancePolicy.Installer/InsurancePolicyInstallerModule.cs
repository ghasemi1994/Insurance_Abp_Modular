using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace InsurancePolicy;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class InsurancePolicyInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<InsurancePolicyInstallerModule>();
        });
    }
}
