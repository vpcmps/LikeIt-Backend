using Likeit.Backend.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Likeit.Backend.Data.Redis;

public class RedisRepository : IRedisRepository
{
    private readonly IDistributedCache _distributedCache;

    public RedisRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    public string GetByKey(string key)
    {
        return _distributedCache.GetString(key);
    }

    public void SetString(string key, string value)
    {
        _distributedCache.SetString(key, value);
    }
}