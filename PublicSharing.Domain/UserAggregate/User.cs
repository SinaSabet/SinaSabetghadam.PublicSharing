using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.Shared;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate.UserEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {
        public User(UserId id) : base(id)
        {

        }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        private readonly List<TweetId> _tweetIds = null!;
        public IReadOnlyCollection<TweetId> TweetIds => [.. _tweetIds];

        public static User Create(string firstName, string lastName, string email,string password)
        {
            InvalidEmailException.Throw(email);
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

            var user = new User(UserId.CreateUniqueId()) { Email = email, FirstName = firstName, LastName = lastName, Password = password };
            user.AddEvent(new UserCreatedEvent(user.Id.Value, user.FirstName, user.LastName, user.Email));

            return user;
        }

       
    }


}

