using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotationSystem.Application.Features.Customers.Commands.CreateCustomer;
using QuotationSystem.Application.Features.Customers.Queries.GetAllCustomers;

namespace QuotationSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommandRequest request)
        {
            
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var start = DateTime.Now;
            var response = await mediator.Send(new GetAllCustomersQueryRequest());
            var end = DateTime.Now;
            var time = end - start;
            return Ok(response);
        }

    }
}
