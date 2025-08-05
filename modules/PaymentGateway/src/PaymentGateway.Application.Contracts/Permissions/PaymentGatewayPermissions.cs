using Volo.Abp.Reflection;

namespace PaymentGateway.Permissions;

public class PaymentGatewayPermissions
{
    public const string GroupName = "PaymentGateway";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PaymentGatewayPermissions));
    }
}
