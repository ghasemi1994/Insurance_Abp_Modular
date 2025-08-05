using Volo.Abp.Modularity;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayDomainModule),
    typeof(PaymentGatewayTestBaseModule)
)]
public class PaymentGatewayDomainTestModule : AbpModule
{

}
