


using Application.Utility.DistributedCache;

namespace Application.Utility;

public class SampleDistributedCache
{

    private readonly IStaticCacheManagerService _staticCacheManagerService;
    public SampleDistributedCache(IStaticCacheManagerService staticCacheManagerService)
    {
        _staticCacheManagerService = staticCacheManagerService;
    }

    /// <summary>
    /// در اين تابع اگر ديتا كش نباشد كش ميشود اگر از قبل در كش وجود داشته باشد برگردانده می شود
    /// </summary>
    /// <returns></returns>
    public async Task<List<User>> GetFromCacheAsync()
    {

        //if you use 'PrepareKeyForDefaultCache' default cache time is 120 min.
        //if you use 'PrepareKeyForShortTermCache' default cache time is 3 min.
        var cacheKey = _staticCacheManagerService.PrepareKeyForDefaultCache(new CacheKey("Cache.User"));
        cacheKey.CacheTime = 100; //youc can set cache minute.

        List<User> users = new List<User>();
        users.Add(new User(1, "Ali"));
        users.Add(new User(2, "Hasan"));
        users.Add(new User(3, "Sara"));

        List<User> result = new();
        (result) = await _staticCacheManagerService.GetAsync<List<User>>(cacheKey, async () =>
         {
             return users;
         });

        return result;
    }

    public async Task<User> GetUserDataByUserIdAsync()
    {
        //اینجا یوزر براساس شناسه کش شده
        var cacheKey = _staticCacheManagerService.PrepareKeyForDefaultCache(new CacheKey("Cache.User.{0}", "1"));

        List<User> users = new();


        User result = new();
        (result) = await _staticCacheManagerService.GetAsync<User>(cacheKey, async () =>
        {
            var uuu = users.Where(c => c.Id == 1).First();
            return uuu;
        });

        return result;
    }



    public async Task RemoveFromCacheAsync()
    {
        //delete all data
        await _staticCacheManagerService.ClearAsync();

        //remove by prefix 
       await _staticCacheManagerService.RemoveByPrefixAsync("Cache.User");

        //remove by cahcekey
        var cacheKey = _staticCacheManagerService.PrepareKeyForDefaultCache(new CacheKey("Cache.User"));
        await _staticCacheManagerService.RemoveAsync(cacheKey);

    }







    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User()
        {

        }

        public User(int id, string name)
        {

        }
    }

}
