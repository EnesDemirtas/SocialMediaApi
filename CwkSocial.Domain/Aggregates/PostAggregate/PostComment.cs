using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        public Guid  CommentId { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public Guid UserProfileId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
