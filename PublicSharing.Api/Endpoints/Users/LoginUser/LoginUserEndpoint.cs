
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicSharing.Api.Model;
using PublicSharing.Application.Commands.Users.RegisterUser;
using PublicSharing.Application.Queries.Users.Login;

namespace PublicSharing.Api.Endpoints.Users.LoginUser
{
    public class LoginUserEndpoint : IEndPoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/Login", async (
                  [FromBody] LoginUserQuery request,
                  IMediator mediator,
                  CancellationToken cancellationToken) =>
            {

                var result = await mediator.Send(request, cancellationToken);
                return new ApiResponse<LoginUserResponseQuery>(result);
            });
        }
    }
}
