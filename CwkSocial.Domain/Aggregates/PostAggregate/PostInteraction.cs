using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        public Guid InteractionId { get; set; }
        public Guid PostId { get; set; }

    }
}
