using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.DomainItems
{
    public interface IEventStore
    {
        Task SaveEventsAsync(string aggregateId, IEnumerable<IDomainEvent> events);
        Task<IEnumerable<IDomainEvent>> GetEventsAsync(string aggregateId);
    }
}
