using System;

namespace QuotationSystem.Infrastructure.Tokens;

public class TokenSettings
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    public int TokenValidtyInMinutes { get; set; }

}
