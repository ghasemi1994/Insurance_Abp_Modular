using Volo.Abp.Reflection;

namespace InsurancePolicy.Permissions;

public class InsurancePolicyPermissions
{
    public const string GroupName = "InsurancePolicy";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(InsurancePolicyPermissions));
    }
}
