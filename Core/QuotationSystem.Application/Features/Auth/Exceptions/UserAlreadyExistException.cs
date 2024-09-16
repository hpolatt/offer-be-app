using System;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseException
{
    public UserAlreadyExistException() : base("User already exist") { }
}
