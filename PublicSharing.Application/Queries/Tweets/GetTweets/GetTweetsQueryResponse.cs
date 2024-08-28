using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Tweets.GetTweets
{
    public record GetTweetsQueryResponse(TweetId TweetId, string Content, string Title,
        IReadOnlyCollection<HashTags> HashTags,
        DateTime?
        PublishedAt,
        int LikesCount)
    {


        public static explicit operator GetTweetsQueryResponse(Tweet tweet)
            => new GetTweetsQueryResponse(tweet.Id,
                tweet.Content,
                tweet.Title,
                tweet.HashTags,
                tweet.PublishedAt,
                tweet.Likes.Count());


    }
}
