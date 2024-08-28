using Microsoft.EntityFrameworkCore;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence.Repositories
{
    public class TweetRepository(PublicSharingDbContext dbContext) : ITweetRepository
    {
        public void Add(Tweet tweet) => dbContext.
            tweets.Add(tweet);


        public async Task<IReadOnlyCollection<Tweet>> GetLatestTweetsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var tweets = await dbContext.tweets
                                    .Where(x => x.Published == true)
                                    .OrderByDescending(x => x.PublishedAt)
                                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);

            return [.. tweets];
        }

        public async Task<IReadOnlyCollection<Tweet>> GetPopularTweetsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var tweets = await dbContext.tweets
                                            .Where(x => x.Published == true)
                                            .OrderByDescending(x => x.PublishedAt)
                                            .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                            .AsNoTracking()
                                            .OrderByDescending(x=>x.Likes.Count())
                                            .ToListAsync(cancellationToken);

            return [.. tweets];
        }

        public async Task<Tweet?> GetTweetById(TweetId tweetId, CancellationToken cancellationToken)
        => await dbContext.tweets.FindAsync(tweetId);
    }
}
