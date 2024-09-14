using System;
using Microsoft.Extensions.DependencyInjection;

namespace QuotationSystem.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<Application.Interfaces.AutoMapper.IMapper, AutoMapper.Mapper>();
    }
}
