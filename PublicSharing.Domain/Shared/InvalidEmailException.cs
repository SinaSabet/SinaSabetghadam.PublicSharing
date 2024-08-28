using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.Shared
{
    public class InvalidEmailException: DomainException
    {

        public InvalidEmailException() : base("Invalid Email Address.") { }

        public static void Throw(string email)
        {
            if (!MailAddress.TryCreate(email, out _))
            {
                throw new InvalidEmailException();
            }
        }
    }
}
