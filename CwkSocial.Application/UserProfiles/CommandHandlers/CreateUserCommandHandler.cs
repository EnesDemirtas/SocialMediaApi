using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;

namespace CwkSocial.Application.UserProfiles.CommandHandlers {

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>> {
        private readonly DataContext _ctx;

        public CreateUserCommandHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
            var result = new OperationResult<UserProfile>();

            try {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone,
                    request.DateOfBirth, request.CurrentCity);

                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

                _ctx.UserProfiles.Add(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;

                return result;
            } catch (UserProfileNotValidException ex) {
                result.IsError = true;
                ex.ValidationErrors.ForEach(e => {
                    var error = new Error {
                        Code = ErrorCode.ValidationError,
                        Message = $"{ex.Message}"
                    };
                    result.Errors.Add(error);
                });
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