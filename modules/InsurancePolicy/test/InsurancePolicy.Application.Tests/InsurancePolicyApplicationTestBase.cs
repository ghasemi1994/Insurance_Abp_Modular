using Volo.Abp.Modularity;

namespace InsurancePolicy;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class InsurancePolicyApplicationTestBase<TStartupModule> : InsurancePolicyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
