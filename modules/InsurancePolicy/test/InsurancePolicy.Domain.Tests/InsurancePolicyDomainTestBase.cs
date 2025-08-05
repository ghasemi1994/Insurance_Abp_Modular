using Volo.Abp.Modularity;

namespace InsurancePolicy;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class InsurancePolicyDomainTestBase<TStartupModule> : InsurancePolicyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
