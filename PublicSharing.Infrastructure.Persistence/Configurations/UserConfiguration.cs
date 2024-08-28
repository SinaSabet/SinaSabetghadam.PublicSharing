using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .IsRequired()
               .HasConversion(
                 id => id.Value,
                      value => UserId.Create(value));

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(70);


            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(150);

            builder.OwnsMany(x => x.TweetIds, cb =>
            {

                cb.ToTable("UserTweetIds");
                cb.Property(x => x.Value)
                .HasColumnName("TweetId");

            }).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.TweetIds)
                .Metadata.SetField("_tweetIds");

        }
    }
}
