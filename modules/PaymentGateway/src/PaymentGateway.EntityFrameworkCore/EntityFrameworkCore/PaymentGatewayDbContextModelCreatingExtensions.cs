using Microsoft.EntityFrameworkCore;
using PaymentGateway.Aggregates.PaymentGatewayAggregate;
using Volo.Abp;

namespace PaymentGateway.EntityFrameworkCore;

public static class PaymentGatewayDbContextModelCreatingExtensions
{
    public static void ConfigurePaymentGateway(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Gateway>(b =>
        {
            b.ToTable("PaymentGateways", PaymentGatewayDbProperties.DbSchema);

            b.Property(c => c.Name)
             .IsRequired();

            b.Property(c => c.PaymentGatewayUrl)
             .IsRequired();

            b.Property(c => c.CallBackUrl)
             .IsRequired();

            b.Property(c => c.RedirectUrl)
                .IsRequired();
        });


    }
}
