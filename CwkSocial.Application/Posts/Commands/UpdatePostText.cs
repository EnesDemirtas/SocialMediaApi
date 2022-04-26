using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Commands {

    public class UpdatePostText : IRequest<OperationResult<Post>> {
        public string NewText { get; set; }
        public Guid PostId { get; set; }
    }
}