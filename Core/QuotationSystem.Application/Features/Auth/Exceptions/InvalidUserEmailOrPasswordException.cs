using System;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application.Features.Auth.Exceptions;

public class InvalidUserEmailOrPasswordException : BaseException
{
    public InvalidUserEmailOrPasswordException() : base("Invalid email or password") { }

}
