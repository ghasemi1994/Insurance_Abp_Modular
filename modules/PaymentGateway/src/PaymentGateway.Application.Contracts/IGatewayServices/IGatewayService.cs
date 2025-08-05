

using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.IGatewayServices;

public interface IGatewayService
{
    Task GetAsync(CancellationToken cancellationToken = default);
}
