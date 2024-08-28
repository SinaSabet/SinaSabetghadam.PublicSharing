using MediatR;
using PublicSharing.Application.Behaviors.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetPopularTweets
{
    public record GetPopularTweetsQuery(int PageNumber, int PageSize): IRequestWithCache<IReadOnlyCollection<GetPopularTweetsQueryResponse>>;
 
}
