using System;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Products.Exceptions;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Rules;

public class ProductRules : BaseRules
{
    public Task ProductNameMustNotBeSame(IList<Product> products, string productName)
    {
        if (products.Any(x=> x.Name == productName)) throw new ProductNameMustNotBeSameException();

        return Task.CompletedTask;
    }
}
