using InsurancePolicy.Localization;
using Volo.Abp.Application.Services;

namespace InsurancePolicy;

public abstract class InsurancePolicyAppService : ApplicationService
{
    protected InsurancePolicyAppService()
    {
        LocalizationResource = typeof(InsurancePolicyResource);
        ObjectMapperContext = typeof(InsurancePolicyApplicationModule);
    }
}
