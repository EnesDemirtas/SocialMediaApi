using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CwkSocial.Dal.Configurations {

    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile> {

        public void Configure(EntityTypeBuilder<UserProfile> builder) {
            builder.OwnsOne(up => up.BasicInfo);
        }
    }
}