using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.TweetAggregate.TweetEvents;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.TweetAggregate
{
    public class Tweet : AggregateRoot<TweetId>
    {
        private Tweet(TweetId id) : base(id)
        {

        }
        public UserId UserId { get; private set; } = null!;

        private List<Like> _likes = null!;
        public IReadOnlyCollection<Like> Likes => [.. _likes];

        private  List<HashTags> _hashTags = null!;
        public IReadOnlyCollection<HashTags> HashTags => [.. _hashTags];

        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool Published { get; set; }





        public static Tweet Create(string title, string content, IReadOnlyList<HashTags> hashTags, UserId userId)
        {
            var tweet = new Tweet(TweetId.CreateUniqueId()) { Content = content, Title = title, UserId = userId };
            tweet.AddHashTags(hashTags);
            tweet.Publish();
            tweet.AddEvent(new TweetCreatedEvent(tweet.Title, tweet.Content, tweet.HashTags, tweet.Id));
            return tweet;
        }
        private void Publish()
        {
            Published = true;
            PublishedAt = DateTime.UtcNow;
        }
        private void AddHashTags(IReadOnlyList<HashTags> hashTags)
        {
            if (_hashTags == null)
            {
                _hashTags = new List<HashTags>();
            }
            _hashTags.AddRange(hashTags);
        }
        public void Like(Like like)
        {
            var item = _likes.FirstOrDefault(x => x == like);

            if (item is null)
            {
                _likes.Add(like);
            }
        }


    }
}
