using System;

namespace QuotationSystem.Infrastructure.RedisCache;

public class RedisCacheSettings
{

    public string ConnectionString { get; set; }

    public string InstanceName { get; set; }

}
