using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace CwkSocial.Application.Posts.Queries {

    public class GetAllPosts : IRequest<OperationResult<List<Post>>> {
    }
}