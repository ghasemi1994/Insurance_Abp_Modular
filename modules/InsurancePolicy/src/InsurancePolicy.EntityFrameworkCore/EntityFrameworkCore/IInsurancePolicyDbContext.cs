using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InsurancePolicy.EntityFrameworkCore;

[ConnectionStringName(InsurancePolicyDbProperties.ConnectionStringName)]
public interface IInsurancePolicyDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
