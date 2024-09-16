using System;
using MediatR;

namespace QuotationSystem.Application.Features.Auth.Command.Revoke;

public class RevokeCommandRequest : IRequest<Unit>
{
    public string Email { get; set; }
}
