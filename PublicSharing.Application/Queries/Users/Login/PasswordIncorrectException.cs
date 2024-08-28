using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Users.Login
{
    public class PasswordIncorrectException:DomainException
    {
        private const string _messages = "The password is incorrect !";
        public PasswordIncorrectException()
            : base(string.Format(_messages))
        {
        }
    }
}
