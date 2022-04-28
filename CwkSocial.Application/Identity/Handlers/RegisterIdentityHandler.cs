using CwkSocial.Application.Enums;
using CwkSocial.Application.Identity.Commands;
using CwkSocial.Application.Models;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CwkSocial.Application.Identity.Handlers {

    public class RegisterIdentityHandler : IRequestHandler<RegisterIdentity, OperationResult<string>> {
        private readonly DataContext _ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterIdentityHandler(DataContext ctx, UserManager<IdentityUser> userManager) {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<OperationResult<string>> Handle(RegisterIdentity request, CancellationToken cancellationToken) {
            var result = new OperationResult<string>();

            try {
                var existingIdentity = await _userManager.FindByEmailAsync(request.Username);
                if (existingIdentity != null) {
                    result.IsError = true;
                    var error = new Error {
                        Code = ErrorCode.IdentityUserAlreadyExists,
                        Message = $"Provided email address already exists. Cannot register new user "
                    };
                    result.Errors.Add(error);
                    return result;
                }

                var identity = new IdentityUser {
                    Email = request.Username,
                    UserName = request.Username,
                };

                using var transaction = _ctx.Database.BeginTransaction();

                var createdIdentity = await _userManager.CreateAsync(identity, request.Password);

                if (!createdIdentity.Succeeded) {
                    result.IsError = true;

                    foreach (var identityError in createdIdentity.Errors) {
                        var error = new Error {
                            Code = ErrorCode.IdentityCreationFailed,
                            Message = identityError.Description
                        };
                        result.Errors.Add(error);
                    }

                    return result;
                }

                var profileInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.Username,
                    request.Phone, request.DateOfBirth, request.CurrentCity);

                var profile = UserProfile.CreateUserProfile(identity.Id, profileInfo);
            } catch (Exception e) {
                var error = new Error {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };

                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}