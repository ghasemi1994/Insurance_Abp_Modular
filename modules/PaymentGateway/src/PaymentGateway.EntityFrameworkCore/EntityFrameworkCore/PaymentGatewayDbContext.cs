using Microsoft.EntityFrameworkCore;
using PaymentGateway.Aggregates.PaymentGatewayAggregate;
using Volo.Abp.EntityFrameworkCore;

namespace PaymentGateway.EntityFrameworkCore;

public class PaymentGatewayDbContext : AbpDbContext<PaymentGatewayDbContext>, IPaymentGatewayDbContext
{
    public DbSet<Gateway> Gateways { get; set; }

    public PaymentGatewayDbContext(DbContextOptions<PaymentGatewayDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePaymentGateway();
    }
}
