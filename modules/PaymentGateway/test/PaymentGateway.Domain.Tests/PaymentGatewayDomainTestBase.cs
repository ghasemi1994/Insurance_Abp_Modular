using Volo.Abp.Modularity;

namespace PaymentGateway;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class PaymentGatewayDomainTestBase<TStartupModule> : PaymentGatewayTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
