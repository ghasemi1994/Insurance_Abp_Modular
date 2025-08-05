using Microsoft.EntityFrameworkCore;
using PaymentGateway.EntityFrameworkCore;
using PaymentGateway.IGatewayServices;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PaymentGateway.GatewayServices;

internal class GatewayService : IGatewayService, ITransientDependency
{
    /*private readonly ICurrentUser _currentUser;
    private readonly GatewayDapperRepository _dapperRepository;
    private readonly IRepository<Gateway> _genericRepository;*/

    private readonly IPaymentGatewayDbContext _db;
    public GatewayService(
        IPaymentGatewayDbContext db
       /* 
        ICurrentUser currentUser,
        GatewayDapperRepository dapperRepository,
        IRepository<Gateway> genericRepository*/
        )
    {
        _db = db;
       /* 
        _currentUser = currentUser;
        _dapperRepository = dapperRepository;
        _genericRepository = genericRepository;*/
    }

    public async Task GetAsync(CancellationToken cancellationToken = default)
    {
        var getDirectFronDbContext = await _db.Gateways.ToListAsync();

       /* var getFromDapperRepo = await _dapperRepository.GetListAsync(cancellationToken);
        var getFromGenericRepository = await _genericRepository.GetListAsync();*/

    }
}
