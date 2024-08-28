using MediatR;
using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetTweets
{
    public class GetTweetsQueryHandler(ITweetRepository tweetRepository) : IRequestHandler<GetTweetsQuery, IReadOnlyCollection<GetTweetsQueryResponse>>
    {
        public async Task<IReadOnlyCollection<GetTweetsQueryResponse>> Handle(GetTweetsQuery request, CancellationToken cancellationToken)
        {
            var tweets = await tweetRepository.GetLatestTweetsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return [.. tweets.Select(x => (GetTweetsQueryResponse)x)];
        }
    }
}
