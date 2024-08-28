using MediatR;
using PublicSharing.Application.Queries.Tweets.GetTweets;
using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetPopularTweets
{
    public class GetPopularTweetsQueryHandler(ITweetRepository tweetRepository) : IRequestHandler<GetPopularTweetsQuery, IReadOnlyCollection<GetPopularTweetsQueryResponse>>
    {
        public async Task<IReadOnlyCollection<GetPopularTweetsQueryResponse>> Handle(GetPopularTweetsQuery request, CancellationToken cancellationToken)
        {
            var tweets = await tweetRepository.GetPopularTweetsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return [.. tweets.Select(x => (GetPopularTweetsQueryResponse)x)];
        }
    }
}
