
using MediatR;
using PublicSharing.Api.Model;
using PublicSharing.Application.Commands.Tweets.LikeTweet;
using PublicSharing.Application.Queries.Tweets;
using PublicSharing.Domain.TweetAggregate;

namespace PublicSharing.Api.Endpoints.Tweets.LikeTweet
{
    public partial class LikeTweetEndPoint : IEndPoint
    {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("/tweets/like/{tweet-id}", async (
                      [AsParameters] LikeTweetRequest request,
                      IMediator mediator,
                      CancellationToken cancellationToken) =>
                {


                    LikeTweetCommand command = new LikeTweetCommand
                    (new TweetId() { Value = Guid.Parse(request.TweetId) });

                    var result = await mediator.Send(command, cancellationToken);
                    return new ApiResponse<bool>(result);
                });
            }

    }
}
