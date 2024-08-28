using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate
{
    public class TweetId:ValueObject<TweetId>
    {
        public Guid Value { get; init; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static TweetId CreateUniqueId() => Create(
        Guid.NewGuid()
        );

        public static TweetId Create(Guid value) => new TweetId
        {
            Value = value
        };
    }
}
