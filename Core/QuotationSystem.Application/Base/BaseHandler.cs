using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;

namespace QuotationSystem.Application.Base;

public class BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
{
    protected readonly IMapper mapper = mapper;
    protected readonly IUnitOfWork unitOfWork = unitOfWork;
    protected readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
    protected readonly string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
}
