using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.BookStore.Data;
using Volo.Abp.DependencyInjection;
using PaymentGateway.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore;

public class EntityFrameworkCorePaymentGatewayDbSchemaMigrator
    : IPaymentGatewayDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePaymentGatewayDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookStoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PaymentGatewayDbContext>()
            .Database
            .MigrateAsync();
    }
}
