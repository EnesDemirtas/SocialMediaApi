using CwkSocial.Domain.Aggregates.PostAggregate;
using System.ComponentModel.DataAnnotations;

namespace CwkSocial.Api.Contracts.Posts.Requests {

    public class PostInteractionCreate {

        [Required]
        public InteractionType Type { get; set; }
    }
}