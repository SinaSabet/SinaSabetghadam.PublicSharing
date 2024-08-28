﻿using FluentAssertions;
using PublicSharing.Application.Queries.Tweets.GetPopularTweets;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using PublicSharing.Infrastructure.Persistence.Repositories;
using PublicSharing.IntegrationTests.DbSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.IntegrationTests.Tweets
{
    public class GetPopularTweetsQueryHandlerTests : IClassFixture<PublicSharingDbContextFixture>
    {
        private readonly PublicSharingDbContextFixture _fixture;

        public GetPopularTweetsQueryHandlerTests(PublicSharingDbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Return_Popular_Tweets_With_Pagination()
        {
            // Arrange
            var user = User.Create("Sina", "Sabetghadam", "test@example.com", "password123");
            _fixture.BuildDbContext("TestDatabase").users.Add(user);
            await _fixture.BuildDbContext("TestDatabase").SaveChangesAsync();

            var tweet1 = Tweet.Create("Tweet 1", "Content 1", new List<HashTags>(), user.Id);
            var tweet2 = Tweet.Create("Tweet 2", "Content 2", new List<HashTags>(), user.Id);
            var tweet3 = Tweet.Create("Tweet 3", "Content 3", new List<HashTags>(), user.Id);

            _fixture.BuildDbContext("TestDatabase").tweets.AddRange(tweet1, tweet2, tweet3);
            await _fixture.BuildDbContext("TestDatabase").SaveChangesAsync();

            var query = new GetPopularTweetsQuery(1, 2);
            var handler = new GetPopularTweetsQueryHandler(new TweetRepository(_fixture.BuildDbContext("TestDatabase")));

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().ContainEquivalentOf(tweet1);
            result.Should().ContainEquivalentOf(tweet2);
        }

        [Fact]
        public async Task Handle_Should_Return_Empty_Collection_When_No_Tweets()
        {
            // Arrange
            var query = new GetPopularTweetsQuery(1, 10);
            var handler = new GetPopularTweetsQueryHandler(new TweetRepository(_fixture.BuildDbContext("TestDatabase")));

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }


        [Fact]
        public async Task Handle_Should_Return_Tweets_Based_On_Pagination()
        {
            // Arrange
            var user = User.Create("Sina", "Sabetghadam", "test@example.com", "password123");
            _fixture.BuildDbContext("TestDatabase").users.Add(user);
            await _fixture.BuildDbContext("TestDatabase").SaveChangesAsync();

            var tweet1 = Tweet.Create("Tweet 1", "Content 1", new List<HashTags>(), user.Id);
            var tweet2 = Tweet.Create("Tweet 2", "Content 2", new List<HashTags>(), user.Id);
            var tweet3 = Tweet.Create("Tweet 3", "Content 3", new List<HashTags>(), user.Id);
            var tweet4 = Tweet.Create("Tweet 4", "Content 4", new List<HashTags>(), user.Id);
            var tweet5 = Tweet.Create("Tweet 5", "Content 5", new List<HashTags>(), user.Id);

            _fixture.BuildDbContext("TestDatabase").tweets.AddRange(tweet1, tweet2, tweet3, tweet4, tweet5);
            await _fixture.BuildDbContext("TestDatabase").SaveChangesAsync();

            var query1 = new GetPopularTweetsQuery(1, 3);
            var query2 = new GetPopularTweetsQuery(2, 3);
            var handler = new GetPopularTweetsQueryHandler(new TweetRepository(_fixture.BuildDbContext("TestDatabase")));

            // Act
            var result1 = await handler.Handle(query1, CancellationToken.None);
            var result2 = await handler.Handle(query2, CancellationToken.None);

            // Assert
            result1.Should().NotBeNull();
            result1.Should().HaveCount(3);
            result1.Should().ContainEquivalentOf(tweet1);
            result1.Should().ContainEquivalentOf(tweet2);
            result1.Should().ContainEquivalentOf(tweet3);

            result2.Should().NotBeNull();
            result2.Should().HaveCount(2);
            result2.Should().ContainEquivalentOf(tweet4);
            result2.Should().ContainEquivalentOf(tweet5);
        }

    }
}