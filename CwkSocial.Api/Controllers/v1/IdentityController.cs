using AutoMapper;
using CwkSocial.Api.Contracts.Identity;
using CwkSocial.Api.Filters;
using CwkSocial.Application.Identity.Commands;
using CwkSocial.Application.Identity.Dtos;
using CwkSocial.Application.Identity.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.v1 {

    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class IdentityController : BaseController {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IdentityController(IMediator mediator, IMapper mapper) {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Registration)]
        [ValidateModel]
        public async Task<IActionResult> Register(UserRegistration registration) {
            var command = _mapper.Map<RegisterIdentity>(registration);
            var result = await _mediator.Send(command);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return Ok(_mapper.Map<IdentityUserProfile>(result.Payload));
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Login)]
        [ValidateModel]
        public async Task<IActionResult> Login(Login login) {
            var command = _mapper.Map<LoginCommand>(login);
            var result = await _mediator.Send(command);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            return Ok(_mapper.Map<IdentityUserProfile>(result.Payload));

        }

        [HttpDelete]
        [Route(ApiRoutes.Identity.IdentityById)]
        [ValidateGuid("identityUserId")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteAccount(string identityUserId, CancellationToken token) {
            var identityUserGuid = Guid.Parse(identityUserId);
            var requestorGuid = HttpContext.GetIdentityIdClaimValue();
            var command = new RemoveAccount {
                IdentityUserId = identityUserGuid,
                RequestorGuid = requestorGuid
            };
            var result = await _mediator.Send(command, token);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }
        
        [HttpGet]
        [Route(ApiRoutes.Identity.CurrentUser)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CurrentUser(CancellationToken token) {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();
            var claimsPrincipal = HttpContext.User;
            var query = new GetCurrentUser { UserProfileId = userProfileId, ClaimsPrincipal = claimsPrincipal};
            var result = await _mediator.Send(query, token);
            if (result.IsError) HandleErrorResponse(result.Errors);
            
            return Ok(_mapper.Map<IdentityUserProfileDto>(result.Payload));
        }
    }
}