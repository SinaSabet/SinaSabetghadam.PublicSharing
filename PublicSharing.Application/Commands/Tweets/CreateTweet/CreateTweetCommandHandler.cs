using MediatR;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.CreateTweet
{
    public class CreateTweetCommandHandler(IUnitOfWork unitOfWork, IEventStore eventStore,ITweetRepository tweetRepository,ICurrentUserProvider currentUserProvider,IUserRepository userRepository) : IRequestHandler<CreateTweetCommand, CreateTweetCommandResponse>
    {
       
        public async Task<CreateTweetCommandResponse> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            var user = await GetCurrentUser(cancellationToken);
            Tweet tweet = Tweet.Create(request.Title,request.Content,request.HashTags,user.Id);
            await eventStore.SaveEventsAsync(tweet.Id.Value.ToString(), tweet.Events);
            tweetRepository.Add(tweet);
            await unitOfWork.CommitAsync(cancellationToken);

            return new CreateTweetCommandResponse(tweet.Title,tweet.Content);
           
        }

        private async Task<User> GetCurrentUser(CancellationToken cancellationToken)
        {
            var currentUser = currentUserProvider.GetCurrentUser();
            var user = await userRepository.GetUserByIdAsync(currentUser.Id, cancellationToken);
            if (user is null)
                throw new UserNotFoundWithIdException();

            return user;

        }
    }
}
