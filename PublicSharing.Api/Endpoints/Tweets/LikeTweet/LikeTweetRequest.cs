using Microsoft.AspNetCore.Mvc;

namespace PublicSharing.Api.Endpoints.Tweets.LikeTweet
{
    public partial class LikeTweetEndPoint
    {
        public record LikeTweetRequest([FromRoute(Name = "tweet-id")] string TweetId);

    }
}
