using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;

namespace HttpApi.Host.HealthCheks;

public class ApplicationDatabaseCheck : IHealthCheck, ITransientDependency
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return new HealthCheckResult { };
    }
}
