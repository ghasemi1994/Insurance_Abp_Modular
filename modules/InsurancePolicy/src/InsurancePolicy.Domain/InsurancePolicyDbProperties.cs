namespace InsurancePolicy;

public static class InsurancePolicyDbProperties
{
    public static string DbTablePrefix { get; set; } = "InsurancePolicy";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "InsurancePolicy";
}
