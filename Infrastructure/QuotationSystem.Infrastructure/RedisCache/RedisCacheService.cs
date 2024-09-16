using System;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuotationSystem.Application.Interfaces.RedisCache;
using StackExchange.Redis;

namespace QuotationSystem.Infrastructure.RedisCache;

public class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer redisConnection;
    private readonly IDatabase database;
    private readonly RedisCacheSettings settings;

    public RedisCacheService(IOptions<RedisCacheSettings> options)
    {
        this.settings = options.Value;
        var opt = ConfigurationOptions.Parse(settings.ConnectionString);
        redisConnection = ConnectionMultiplexer.Connect(opt);
        database = redisConnection.GetDatabase();

        
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var value = await database.StringGetAsync(key);

        if (value.HasValue)
            return JsonConvert.DeserializeObject<T>(value);

        return default;

    }

    public Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
    {
        var json = JsonConvert.SerializeObject(value);
        TimeSpan? expiration = expirationTime.HasValue ? expirationTime.Value - DateTime.Now : null;
        return database.StringSetAsync(key, json, expiration);
    }
}
