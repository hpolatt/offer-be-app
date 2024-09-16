using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotationSystem.Application.Features.Customers.Commands.CreateCustomer;

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

    }
}
