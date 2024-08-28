using Microsoft.EntityFrameworkCore.Diagnostics;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence.EventStore
{
    public class MongoDbEventStore : IEventStore
    {
        private readonly IMongoCollection<EventData> _eventsCollection;
        public MongoDbEventStore(IMongoDatabase mongoDatabase)
        {
            _eventsCollection = mongoDatabase.GetCollection<EventData>("events");
        }
        public async Task<IEnumerable<IDomainEvent>> GetEventsAsync(string aggregateId)
        {
            var filter = Builders<EventData>.Filter.Eq(e => e.AggregateId, aggregateId);
            var eventDatas = await _eventsCollection.Find(filter).ToListAsync();
            return (IEnumerable<IDomainEvent>)eventDatas.Select(e => e.Event);
        }

        public async Task SaveEventsAsync(string aggregateId, IEnumerable<IDomainEvent> events)
        {
            var eventDataList = new List<EventData>();
         

            foreach (var @event in events)
            {
              


                var eventData = new EventData
                {
                    Id = ObjectId.GenerateNewId(),
                    AggregateId = aggregateId,
                    EventType = @event.GetType().Name,
                    Event = JsonSerializer.Serialize(@event), // Serialize the event as needed
                    OccurredOn = DateTime.UtcNow
                };
                eventDataList.Add(eventData);
            }
            if (eventDataList is not null)
                await _eventsCollection.InsertManyAsync(eventDataList);


        }
    }

}