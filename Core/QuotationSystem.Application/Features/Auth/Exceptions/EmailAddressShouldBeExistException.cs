using System;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application.Features.Auth.Exceptions;

public class EmailAddressShouldBeExistException : BaseException
{
    public EmailAddressShouldBeExistException() : base("Email address should be exist")
    {
    }
}
