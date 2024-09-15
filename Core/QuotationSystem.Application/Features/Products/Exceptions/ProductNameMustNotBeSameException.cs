using System;
using QuotationSystem.Application.Base;

namespace QuotationSystem.Application.Features.Products.Exceptions;

public class ProductNameMustNotBeSameException : BaseException
{
    public ProductNameMustNotBeSameException(): base("Product name must not be same!") {  }

}
