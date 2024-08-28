using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.TweetAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.UserAggregate
{
    public class UserId : ValueObject<UserId>
    {
        public  Guid Value { get;  init; }

        public static UserId CreateUniqueId() => Create(
      Guid.NewGuid()
      );

        public static UserId Create(Guid value) => new UserId
        {
            Value = value
        };
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
