using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.UserAggregate.UserEvents
{
    public class UserCreatedEvent : IDomainEvent
    {
        public string UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime CreatedAt { get ; set; }

        public UserCreatedEvent(Guid userId, string firstName, string lastName, string email)
        {
            UserId = userId.ToString();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = DateTime.Now;   
        }
    }
}
