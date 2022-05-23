using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Queries {

    public class GetPostById : IRequest<OperationResult<Post>> {
        public Guid PostId { get; set; }
    }
}