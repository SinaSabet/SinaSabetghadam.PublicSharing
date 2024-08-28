
using MediatR;
using PublicSharing.Api.Model;
using PublicSharing.Application.Queries.Tweets.GetTweets;
using PublicSharing.Application.Queries.Users.Login;

namespace PublicSharing.Api.Endpoints.Tweets.GetTweets
{
    public class GetTweetsEndPoint : IEndPoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/tweets/", async (
                  [AsParameters] GetTweetsQuery request,
                  IMediator mediator,
                  CancellationToken cancellationToken) =>
            {

                var result = await mediator.Send(request, cancellationToken);
                return new ApiResponse<IReadOnlyCollection<GetTweetsQueryResponse>>(result);
            });
        }
    }
}
