using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotationSystem.Application.Features.Products.Commands.CreateProduct;
using QuotationSystem.Application.Features.Products.Commands.DeleteProduct;
using QuotationSystem.Application.Features.Products.Commands.UpdateProduct;
using QuotationSystem.Application.Features.Products.Queries.GetAllProducts;

namespace QuotationSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAlProduct ()
        {
            var response = await mediator.Send(new GetAllProductsRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}



