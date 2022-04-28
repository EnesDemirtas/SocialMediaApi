using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Queries {

    public class GetPostComments : IRequest<OperationResult<List<PostComment>>> {
        public Guid PostId { get; set; }
    }
}