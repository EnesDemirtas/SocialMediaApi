using CwkSocial.Api.Contracts.UserProfile.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.v1 {

    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : Controller {
        private readonly IMediator _mediator;

        public UserProfilesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllProfiles() {
            return (IActionResult)Task.FromResult(Ok());
        }

        [HttpPost]
        public IActionResult CreateUserProfile([FromBody] UserProfileCreate profile) {
            return (IActionResult)Task.FromResult(Ok());
        }
    }
}