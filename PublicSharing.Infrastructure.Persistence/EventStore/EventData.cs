using MongoDB.Bson;
using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence.EventStore
{
    public class EventData
    {
        public ObjectId Id { get; set; }
        public string AggregateId { get; set; }
        public string EventType { get; set; }
        public string Event { get; set; } 
        public DateTime OccurredOn { get; set; }
    }
}
