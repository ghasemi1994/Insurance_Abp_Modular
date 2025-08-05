using InsurancePolicy.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace InsurancePolicy.Permissions;

public class InsurancePolicyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(InsurancePolicyPermissions.GroupName, L("Permission:InsurancePolicy"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<InsurancePolicyResource>(name);
    }
}
