using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate
{
    public interface ITweetRepository
    {
        void Add(Tweet tweet);

        Task<IReadOnlyCollection<Tweet>> GetLatestTweetsAsync(int pageNumber,int pageSize, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Tweet>> GetPopularTweetsAsync(int pageNumber,int pageSize, CancellationToken cancellationToken);
        Task<Tweet?> GetTweetById(TweetId tweetId, CancellationToken cancellationToken);
    }
}
