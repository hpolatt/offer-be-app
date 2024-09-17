using System;
using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : BaseHandler, IRequestHandler<CreateCustomerCommandRequest, Unit>
{
    public CreateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    // For testing purposes, we will create 1,000,000 customers.
    public async Task<Unit> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        Faker faker = new("tr");
        List<Customer> customers = new();

        for (int i = 0; i < 900000; i++)
        {
            string companyName = $"{faker.Name.LastName()} Company";
            customers.Add(new()
            {
                Name = companyName,
                CompanyName = companyName,
                Email = faker.Internet.Email(),
                ContactPerson = $"{faker.Name.FirstName()} {faker.Name.LastName()}",
                Address = $"{faker.Address.StreetAddress()} {faker.Address.City()} {faker.Address.Country()}"
            });

        }
        await unitOfWork.GetWriteRepository<Customer>().AddRangeAsync(customers);
        await unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
