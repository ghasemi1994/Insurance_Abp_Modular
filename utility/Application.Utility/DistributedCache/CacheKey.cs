

namespace Application.Utility.DistributedCache;
public partial class CacheKey
{
    public List<string> Prefixes { get; protected set; } = new List<string>();
    public string Key { get; protected set; }
    /// <summary>
    /// minute
    /// </summary>
    public int CacheTime { get; set; }

    public CacheKey(string key, params string[] prefixes)
    {
        Key = key;
        Prefixes.AddRange(prefixes.Where(prefix => !string.IsNullOrEmpty(prefix)));
    }

    public virtual CacheKey Create(Func<object, object> createCacheKeyParameters, params object[] keyObjects)
    {
        var cacheKey = new CacheKey(Key, Prefixes.ToArray());

        if (!keyObjects.Any()) return cacheKey;

        cacheKey.Key = string.Format(cacheKey.Key, keyObjects.Select(createCacheKeyParameters).ToArray());

        for (int i = 0; i < cacheKey.Prefixes.Count; i++)
            cacheKey.Prefixes[i] = string.Format(cacheKey.Prefixes[i], keyObjects.Select(createCacheKeyParameters));

        return cacheKey;

    }

    /// <summary>
    /// nested class
    /// </summary>
    public class CacheKeyEqualityComparer : IEqualityComparer<CacheKey>
    {
        public bool Equals(CacheKey x, CacheKey y)
        {
            if (x == null && y == null) return true;

            return x?.Key.Equals(y?.Key, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        public int GetHashCode(CacheKey obj)
        {
            return obj.Key.GetHashCode();
        }

    }
}
