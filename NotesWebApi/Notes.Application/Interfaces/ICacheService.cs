namespace Notes.Application.Interfaces;

public interface ICacheService
{
    public Task<T> GetCachedValueAsync<T>(string key);

    public Task SetCachedValueAsync<T>(string key, T data, TimeSpan cacheDuration);
}

