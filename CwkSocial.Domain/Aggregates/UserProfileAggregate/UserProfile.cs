using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        public string IdentityId { get; set; }
        public BasicInfo BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
