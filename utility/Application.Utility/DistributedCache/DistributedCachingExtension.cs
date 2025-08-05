using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


namespace Application.Utility.DistributedCache;

public static class DistributedCachingExtension
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        try
        {
            // Configure settings
            services.Configure<DistributedCacheSettings>(option => configuration.GetSection("DistributedCacheSettings").Bind(option));

            bool useRedis = configuration.GetValue<bool>("DistributedCacheSettings:UseRedis");

            if (useRedis)
            {
                ConfigureRedisCache(services, configuration);
            }
            else
            {
                ConfigureMemoryCache(services);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to configure distributed cache. Falling back to memory cache.");
            ConfigureMemoryCache(services);
        }

        return services;
    }

    private static void ConfigureRedisCache(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetValue<string>("DistributedCacheSettings:ConnectionString");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Redis connection string cannot be null or empty");

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = connectionString;
            // Consider adding InstanceName for key prefixing:
            // options.InstanceName = "YourAppPrefix:";
        });

        // Using Transient here since RedisCacheManager might need fresh connections
        services.AddScoped<ILocker, RedisCacheManager>();
        services.AddScoped<IStaticCacheManagerService, RedisCacheManager>();
    }

    private static void ConfigureMemoryCache(IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        // Using Singleton as MemoryDistributedCacheManager is lightweight
        services.AddSingleton<ILocker, MemoryDistributedCacheManager>();
        services.AddSingleton<IStaticCacheManagerService, MemoryDistributedCacheManager>();
    }
}