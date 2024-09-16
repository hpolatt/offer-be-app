using System;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Exceptions;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistException();

        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new InvalidUserEmailOrPasswordException();

        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldNotBeExpired(DateTime? refreshTokenExpiryTime)
    {
        if (refreshTokenExpiryTime <= DateTime.Now) throw new RefreshTokenExpiredException();

        return Task.CompletedTask;
    }

    public Task EmailAddressShouldBeExist(User? user)
    {
        if (user is null) throw new EmailAddressShouldBeExistException();

        return Task.CompletedTask;
    }
}
