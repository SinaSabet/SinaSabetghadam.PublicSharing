
using MediatR;
using PublicSharing.Api.Model;
using PublicSharing.Application.Queries.Tweets.GetPopularTweets;
using PublicSharing.Application.Queries.Tweets.GetTweets;

namespace PublicSharing.Api.Endpoints.Tweets.GetPopularTweets
{
    public class GetPopularTweetsEndPoint : IEndPoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/tweets/popular", async (
                 [AsParameters] GetPopularTweetsQuery request,
                 IMediator mediator,
                 CancellationToken cancellationToken) =>
            {

                var result = await mediator.Send(request, cancellationToken);
                return new ApiResponse<IReadOnlyCollection<GetPopularTweetsQueryResponse>>(result);
            });
        }
    }
}
