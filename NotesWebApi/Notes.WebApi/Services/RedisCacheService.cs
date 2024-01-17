using Microsoft.Extensions.Caching.Distributed;
using Notes.Application.Interfaces;
using System.Text.Json;

namespace Notes.WebApi.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache distributedCache)
    {
        _cache = distributedCache;
    }
    
    public async Task<T> GetCachedValueAsync<T>(string key)
    {
        var data = await _cache.GetStringAsync(key);
        if (data == null) return default(T);
        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetCachedValueAsync<T>(string key, T data, TimeSpan cacheDuration)
    {
        var options = new DistributedCacheEntryOptions()
        {           
            AbsoluteExpiration = DateTime.Now.Add(cacheDuration),
            SlidingExpiration = TimeSpan.FromSeconds(30)
        };

        var jsonData = JsonSerializer.Serialize(data);
        await _cache.SetStringAsync(key, jsonData, options);
    }
}