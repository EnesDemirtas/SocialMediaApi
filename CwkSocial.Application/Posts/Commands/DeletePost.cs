using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Commands {

    public class DeletePost : IRequest<OperationResult<Post>> {
        public Guid PostId { get; set; }
        public Guid UserProfileId { get; set; }
    }
}