using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate
{
    public class Like : ValueObject<Like>
    {
        public DateTime LikedAt { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return LikedAt;
        }
        public static Like Create(DateTime likedAt) => new Like() { LikedAt = likedAt };

    }
}
