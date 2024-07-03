using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Post;

namespace SimpleBlog.Infrastructure.Data.Configurations;

public class CommentsConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content)
            .HasColumnType("varchar(500)")
            .IsRequired();
    }
}
