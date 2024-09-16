using System;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Exceptions;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Rules;

public class AuthRules: BaseRules
{
    public Task UserShouldNotBeExist(User? user) {
        if (user is not null) throw new UserAlreadyExistException();
        
        return Task.CompletedTask;
    }
}
