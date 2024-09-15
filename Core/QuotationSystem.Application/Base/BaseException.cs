using System;

namespace QuotationSystem.Application.Base;

public class BaseException : ApplicationException
{
    public BaseException() { }

    public BaseException(string message) : base(message) { }
}
