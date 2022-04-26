using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Commands {

    public class CreatePost : IRequest<OperationResult<Post>> {
        public Guid UserProfileId { get; set; }
        public string TextContent { get; set; }
    }
}