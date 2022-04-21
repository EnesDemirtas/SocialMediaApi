using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Application.UserProfiles.CommandHandlers {

    internal class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfile, OperationResult<UserProfile>> {
        private readonly DataContext _ctx;

        public DeleteUserProfileCommandHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfile request, CancellationToken cancellationToken) {
            var result = new OperationResult<UserProfile>();
            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

            if (userProfile is null) {
                result.IsError = true;
                var error = new Error { Code = ErrorCode.NotFound, Message = $"No UserProfile found with ID {request.UserProfileId}" };
                result.Errors.Add(error);
                return result;
            }

            _ctx.UserProfiles.Remove(userProfile);
            await _ctx.SaveChangesAsync();

            result.Payload = userProfile;
            return result;
        }
    }
}