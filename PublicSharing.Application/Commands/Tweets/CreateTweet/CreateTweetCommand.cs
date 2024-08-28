using MediatR;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.CreateTweet
{
    public record CreateTweetCommand(string Title, string Content, IReadOnlyList<HashTags> HashTags) :IRequest<CreateTweetCommandResponse>;

   
}
