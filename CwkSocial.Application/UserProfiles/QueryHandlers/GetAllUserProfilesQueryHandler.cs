using CwkSocial.Application.Models;
using CwkSocial.Application.UserProfiles.Queries;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Application.UserProfiles.QueryHandlers {

    internal class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>> {
        private readonly DataContext _ctx;

        public GetAllUserProfilesQueryHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken) {
            var result = new OperationResult<IEnumerable<UserProfile>>();
            result.Payload = await _ctx.UserProfiles.ToListAsync();
            return result;
        }
    }
}