using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Users.Login
{
    public class UserNotFoundWithEmailException : DomainException
    {
        private const string _messages = "User notfound with this Email: {0}";
        public UserNotFoundWithEmailException(string emailAddress)
            : base(string.Format(_messages, emailAddress))
        {
        }
    }
}
