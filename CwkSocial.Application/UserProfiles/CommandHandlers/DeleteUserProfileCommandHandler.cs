using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.CommandHandlers {

    internal class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfile> {
        private readonly DataContext _ctx;

        public DeleteUserProfileCommandHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(DeleteUserProfile request, CancellationToken cancellationToken) {
            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

            _ctx.UserProfiles.Remove(userProfile);
            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}