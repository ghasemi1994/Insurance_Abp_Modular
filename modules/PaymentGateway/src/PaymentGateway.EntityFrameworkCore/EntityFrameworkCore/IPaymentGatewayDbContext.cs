using Microsoft.EntityFrameworkCore;
using PaymentGateway.Aggregates.PaymentGatewayAggregate;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace PaymentGateway.EntityFrameworkCore;

public interface IPaymentGatewayDbContext : IEfCoreDbContext
{  
    DbSet<Gateway> Gateways { get; }
}
