using System;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application.Features.Auth.Exceptions;

public class RefreshTokenExpiredException : BaseException
{
    public RefreshTokenExpiredException() : base("Refresh token has expired") { }

}
