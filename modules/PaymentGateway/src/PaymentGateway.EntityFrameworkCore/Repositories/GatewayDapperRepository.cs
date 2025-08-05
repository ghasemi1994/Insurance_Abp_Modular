

using Dapper;
using PaymentGateway.Aggregates.PaymentGatewayAggregate;
using PaymentGateway.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace PaymentGateway.Repositories;

public class GatewayDapperRepository :
    DapperRepository<PaymentGatewayDbContext>,
    ITransientDependency
{

    public GatewayDapperRepository(IDbContextProvider<PaymentGatewayDbContext> dbContextProvider)
        : base(dbContextProvider)
    {

    }

    public async Task<List<Gateway>> GetListAsync(CancellationToken cancellationToken)
    {
        var dbConnection = await GetDbConnectionAsync();

        return (await dbConnection.QueryAsync<Gateway>(
            "select * from IPG.Gateways", 
            transaction: await GetDbTransactionAsync())).ToList();
    }



}
