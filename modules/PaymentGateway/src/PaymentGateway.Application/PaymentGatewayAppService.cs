using PaymentGateway.Localization;
using Volo.Abp.Application.Services;

namespace PaymentGateway;

public abstract class PaymentGatewayAppService : ApplicationService
{
    protected PaymentGatewayAppService()
    {
        LocalizationResource = typeof(PaymentGatewayResource);
        ObjectMapperContext = typeof(PaymentGatewayApplicationModule);
    }
}
