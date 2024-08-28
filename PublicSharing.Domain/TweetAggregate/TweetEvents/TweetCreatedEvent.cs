using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate.TweetEvents
{
    public class TweetCreatedEvent :IDomainEvent
    {
        public TweetId TweetId { get;  }
        public string Content { get;  }
        public string Title { get;  }
        public IReadOnlyCollection<HashTags> HashTags { get;  }
        public DateTime PublishedAt { get;  }
        public DateTime CreatedAt { get; set; }

        public TweetCreatedEvent(string title, string content, IReadOnlyCollection<HashTags> hashTags, TweetId tweetId)
        {
            TweetId = tweetId;
            Content=content;
            Title = title;    
            HashTags= hashTags;
            PublishedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;    
        }
    };
   
}
