

using PaymentGateway.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace PaymentGateway.DbMigrator;


[DependsOn(
     typeof(AbpAutofacModule),
    typeof(PaymentGatewayEntityFrameworkCoreModule),
    typeof(PaymentGatewayApplicationContractsModule)

    )]
public class PaymentGatewayDbMigratorModule : AbpModule
{
}
