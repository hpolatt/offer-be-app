using System;
using MediatR;

namespace QuotationSystem.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandRequest : IRequest<Unit>
{
    public string Email { get; set; }
}
