using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.CreateTweet
{
    public class UserNotFoundWithIdException:DomainException
    {
        private const string _messages = "User notfound ";
        public UserNotFoundWithIdException()
            : base(string.Format(_messages))
        {
        }
    }
}
