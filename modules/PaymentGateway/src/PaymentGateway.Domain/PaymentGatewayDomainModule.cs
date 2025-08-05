using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace PaymentGateway;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PaymentGatewayDomainSharedModule)
)]
public class PaymentGatewayDomainModule : AbpModule
{

}
