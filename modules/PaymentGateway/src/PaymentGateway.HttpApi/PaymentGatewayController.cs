using PaymentGateway.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PaymentGateway;

public abstract class PaymentGatewayController : AbpControllerBase
{
    protected PaymentGatewayController()
    {
        LocalizationResource = typeof(PaymentGatewayResource);
    }
}
