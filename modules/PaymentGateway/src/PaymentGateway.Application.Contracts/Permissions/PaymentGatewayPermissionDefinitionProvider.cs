using PaymentGateway.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PaymentGateway.Permissions;

public class PaymentGatewayPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PaymentGatewayPermissions.GroupName, L("Permission:PaymentGateway"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PaymentGatewayResource>(name);
    }
}
