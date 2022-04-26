using System.ComponentModel.DataAnnotations;

namespace CwkSocial.Api.Contracts.Posts.Requests {

    public class PostCreate {

        [Required]
        public string UserProfileId { get; set; }

        [Required]
        [StringLength(1000)]
        public string TextContent { get; set; }
    }
}