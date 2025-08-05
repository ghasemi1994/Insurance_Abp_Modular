using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Notification;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class NotificationInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<NotificationInstallerModule>();
        });
    }
}
