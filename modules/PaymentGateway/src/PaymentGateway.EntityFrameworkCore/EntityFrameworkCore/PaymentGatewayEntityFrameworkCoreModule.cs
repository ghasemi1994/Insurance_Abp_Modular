using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PaymentGateway.EntityFrameworkCore;

[DependsOn(
    typeof(PaymentGatewayDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class PaymentGatewayEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(opts =>
            {
                // Configure for SQL Server (or your database provider)
                opts.UseSqlServer();

                // If you need to configure specific options:
                // opts.DbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        });

        context.Services.AddAbpDbContext<PaymentGatewayDbContext>(options =>
        {
            options.AddDefaultRepositories<IPaymentGatewayDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
