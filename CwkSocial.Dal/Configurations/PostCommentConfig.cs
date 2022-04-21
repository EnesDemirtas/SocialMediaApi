using CwkSocial.Domain.Aggregates.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CwkSocial.Dal.Configurations {

    internal class PostCommentConfig : IEntityTypeConfiguration<PostComment> {

        public void Configure(EntityTypeBuilder<PostComment> builder) {
            builder.HasKey(pc => pc.CommentId);
        }
    }
}