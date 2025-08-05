using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace InsurancePolicy;

[DependsOn(
    typeof(InsurancePolicyDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class InsurancePolicyApplicationContractsModule : AbpModule
{

}
