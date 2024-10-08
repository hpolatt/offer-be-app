using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuotationSystem.Application.Features.Auth.Commands.Login;
using QuotationSystem.Application.Features.Auth.Commands.RefreshToken;
using QuotationSystem.Application.Features.Auth.Commands.Register;
using QuotationSystem.Application.Features.Auth.Commands.Revoke;
using QuotationSystem.Application.Features.Auth.Commands.RevokeAll;

namespace QuotationSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            var response = await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
