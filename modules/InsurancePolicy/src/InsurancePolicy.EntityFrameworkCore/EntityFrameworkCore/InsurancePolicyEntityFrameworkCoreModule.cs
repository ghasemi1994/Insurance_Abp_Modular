using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace InsurancePolicy.EntityFrameworkCore;

[DependsOn(
    typeof(InsurancePolicyDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class InsurancePolicyEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<InsurancePolicyDbContext>(options =>
        {
            options.AddDefaultRepositories<IInsurancePolicyDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
