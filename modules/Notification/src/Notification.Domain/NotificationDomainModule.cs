using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Notification;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(NotificationDomainSharedModule)
)]
public class NotificationDomainModule : AbpModule
{

}
