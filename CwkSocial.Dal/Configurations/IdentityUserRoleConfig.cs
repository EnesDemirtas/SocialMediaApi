using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CwkSocial.Dal.Configurations {
    internal class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>> {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) {
            builder.HasKey(iur => iur.RoleId);
        }
    }
}
