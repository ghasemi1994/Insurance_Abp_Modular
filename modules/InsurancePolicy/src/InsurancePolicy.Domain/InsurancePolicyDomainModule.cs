using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace InsurancePolicy;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(InsurancePolicyDomainSharedModule)
)]
public class InsurancePolicyDomainModule : AbpModule
{

}
