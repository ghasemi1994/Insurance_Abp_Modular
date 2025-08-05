using Volo.Abp.Modularity;

namespace InsurancePolicy;

[DependsOn(
    typeof(InsurancePolicyApplicationModule),
    typeof(InsurancePolicyDomainTestModule)
    )]
public class InsurancePolicyApplicationTestModule : AbpModule
{

}
