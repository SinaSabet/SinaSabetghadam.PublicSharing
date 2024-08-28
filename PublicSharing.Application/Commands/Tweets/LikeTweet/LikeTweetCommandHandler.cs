using MediatR;
using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.LikeTweet
{
    public class LikeTweetCommandHandler(ITweetRepository tweetRepository, IUnitOfWork unitOfWork) : IRequestHandler<LikeTweetCommand, bool>
    {
        public async Task<bool> Handle(LikeTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await tweetRepository.GetTweetById(request.TweetId, cancellationToken);
            if (tweet is null)
                throw new Exception();

            tweet.Like(new Like() { LikedAt = DateTime.UtcNow });
            await unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
