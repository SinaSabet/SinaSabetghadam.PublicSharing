using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.DomainItems
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is not null
                && obj is Entity<TId> entity &&
                obj.GetType() == GetType() &&
                 Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
            => left.Equals(right);
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
       => !left.Equals(right);

        public override int GetHashCode()
      => HashCode.Combine(GetType(), Id);

    }
}
