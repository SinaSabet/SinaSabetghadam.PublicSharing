using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate
{
    public class HashTags:ValueObject<HashTags>
    {
        public string Value { get; init; } = null!;
        public static HashTags Create(string hashTagValue)
        {
            return new HashTags
            {
                Value = hashTagValue
            };
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
