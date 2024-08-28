using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetPopularTweets
{
    public record GetPopularTweetsQueryResponse(TweetId TweetId, string Content, string Title,
       IReadOnlyCollection<HashTags> HashTags,
       DateTime?
       PublishedAt,
       int LikesCount)
    {


        public static explicit operator GetPopularTweetsQueryResponse(Tweet tweet)
            => new GetPopularTweetsQueryResponse(tweet.Id,
                tweet.Content,
                tweet.Title,
                tweet.HashTags,
                tweet.PublishedAt,
                tweet.Likes.Count());


    }
}
