

namespace Application.Utility.DistributedCache; 


public class DistributedCacheSettings
{
    /// <summary>
    /// redis connection (endpoint and port)
    /// </summary>
    public string ConnectionString { get; set; }
    /// <summary>
    /// Gets or sets the default cache time in minutes
    /// </summary>
    public int DefaultCacheTime { get; private set; } = 120;
    /// <summary>
    /// Gets or sets the short term cache time in minutes
    /// </summary>
    public int ShortTermCacheTime { get; private set; } = 3;
    /// <summary>
    /// Gets or sets the bundled files cache time in minutes
    /// </summary>
    public int BundledFilesCacheTime { get; private set; } = 120;
}
