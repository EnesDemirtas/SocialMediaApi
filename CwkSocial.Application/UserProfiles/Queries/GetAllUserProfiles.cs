using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace CwkSocial.Application.UserProfiles.Queries {

    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>> {
    }
}