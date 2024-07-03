using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Post;

namespace SimpleBlog.Infrastructure.Data.Configurations;

public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts");

        builder.HasKey(bp => bp.Id);

        builder.Property(bp => bp.Title)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(bp => bp.Content)
            .HasColumnType("varchar(1000)")
            .IsRequired();

        builder.HasMany(bp => bp.Comments)
            .WithOne()
            .HasForeignKey(c => c.BlogPostId);
    }
}
