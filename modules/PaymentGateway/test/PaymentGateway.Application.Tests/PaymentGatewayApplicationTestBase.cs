using Volo.Abp.Modularity;

namespace PaymentGateway;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class PaymentGatewayApplicationTestBase<TStartupModule> : PaymentGatewayTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
