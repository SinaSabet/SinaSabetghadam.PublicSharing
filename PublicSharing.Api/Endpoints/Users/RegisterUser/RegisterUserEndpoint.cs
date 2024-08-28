using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicSharing.Api.Model;
using PublicSharing.Application.Commands.Users.RegisterUser;

namespace PublicSharing.Api.Endpoints.Users.RegisterUser
{
    public class RegisterUserEndpoint : IEndPoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/", async (
                    [FromBody] RegisterUserCommand request,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {

                var result = await mediator.Send(request, cancellationToken);
                return new ApiResponse<RegisterUserCommandResponse>(result);
            });
        }
    }
}
