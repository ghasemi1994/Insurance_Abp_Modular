using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InsurancePolicy.EntityFrameworkCore;

[ConnectionStringName(InsurancePolicyDbProperties.ConnectionStringName)]
public class InsurancePolicyDbContext : AbpDbContext<InsurancePolicyDbContext>, IInsurancePolicyDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public InsurancePolicyDbContext(DbContextOptions<InsurancePolicyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureInsurancePolicy();
    }
}
