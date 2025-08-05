using Volo.Abp.Modularity;

namespace InsurancePolicy;

[DependsOn(
    typeof(InsurancePolicyDomainModule),
    typeof(InsurancePolicyTestBaseModule)
)]
public class InsurancePolicyDomainTestModule : AbpModule
{

}
