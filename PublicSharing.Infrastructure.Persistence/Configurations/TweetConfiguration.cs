using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSharing.Domain.TweetAggregate;

namespace PublicSharing.Infrastructure.Persistence.Configurations
{
    internal class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedNever()
              .IsRequired()
              .HasConversion(
                id => id.Value,
                     value => TweetId.Create(value));


            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PublishedAt)
              .IsRequired(false);



            builder.OwnsMany(x => x.HashTags, tb =>
            {
                tb.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(30);
            }).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.HashTags).Metadata.SetField("_hashTags");

            builder.OwnsMany(x => x.Likes, tb =>
            {
                tb.Property(x => x.LikedAt)
                    .IsRequired(true);

            }).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Navigation(x => x.Likes)
                .Metadata.SetField("_likes");


            builder.OwnsOne(x => x.UserId, cb =>
            {
                cb.Property(c => c.Value)
                    .IsRequired()
                    .HasColumnName("UserId");
            });
          
        }
    }
}
