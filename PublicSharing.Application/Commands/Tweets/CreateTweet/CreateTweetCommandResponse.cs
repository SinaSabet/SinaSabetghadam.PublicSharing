using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.CreateTweet
{
    public record CreateTweetCommandResponse(string Title, string Content);
   
}
