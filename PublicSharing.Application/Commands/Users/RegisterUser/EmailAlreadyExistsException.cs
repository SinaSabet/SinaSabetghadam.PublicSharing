using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Users.RegisterUser
{
    public class EmailAlreadyExistsException : DomainException
    {
        private const string _messages = "Email: `{0}` already exists.";
        public EmailAlreadyExistsException(string emailAddress)
            : base(string.Format(_messages, emailAddress))
        {
        }
    }
}
