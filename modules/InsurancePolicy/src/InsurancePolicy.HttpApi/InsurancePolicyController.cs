using InsurancePolicy.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace InsurancePolicy;

public abstract class InsurancePolicyController : AbpControllerBase
{
    protected InsurancePolicyController()
    {
        LocalizationResource = typeof(InsurancePolicyResource);
    }
}
