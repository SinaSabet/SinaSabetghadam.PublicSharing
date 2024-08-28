using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicSharing.Api.Model;
using PublicSharing.Application.Commands.Tweets.CreateTweet;
using PublicSharing.Application.Queries.Users.Login;

namespace PublicSharing.Api.Endpoints.Tweets.CreateTweet
{
    public class CreateTweetEndpoint:IEndPoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/tweet/Create", async (
                  [FromBody] CreateTweetCommand request,
                  IMediator mediator,
                  CancellationToken cancellationToken) =>
            {

                var result = await mediator.Send(request, cancellationToken);
                return new ApiResponse<CreateTweetCommandResponse>(result);
            }).RequireAuthorization();
        }
    }
}
