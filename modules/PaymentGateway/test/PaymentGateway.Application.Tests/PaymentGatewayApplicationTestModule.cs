using Volo.Abp.Modularity;

namespace PaymentGateway;

[DependsOn(
    typeof(PaymentGatewayApplicationModule),
    typeof(PaymentGatewayDomainTestModule)
    )]
public class PaymentGatewayApplicationTestModule : AbpModule
{

}
