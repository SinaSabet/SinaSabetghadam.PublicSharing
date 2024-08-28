using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetTweets
{
    public record GetTweetsQuery(int PageNumber, int PageSize) : IRequest<IReadOnlyCollection<GetTweetsQueryResponse>>;

}
