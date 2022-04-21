using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CwkSocial.Dal.Configurations {

    internal class BasicInfoConfig : IEntityTypeConfiguration<BasicInfo> {

        public void Configure(EntityTypeBuilder<BasicInfo> builder) {
        }
    }
}