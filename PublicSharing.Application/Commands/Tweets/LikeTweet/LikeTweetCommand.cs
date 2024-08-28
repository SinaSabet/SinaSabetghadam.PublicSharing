using MediatR;
using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.LikeTweet
{
    public record LikeTweetCommand(TweetId TweetId):IRequest<bool>;
    
}
