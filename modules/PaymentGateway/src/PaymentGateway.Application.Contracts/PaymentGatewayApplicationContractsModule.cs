using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PaymentGatewayApplicationContractsModule : AbpModule
{

}
