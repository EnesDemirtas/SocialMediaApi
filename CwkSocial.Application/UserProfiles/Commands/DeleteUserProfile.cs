using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.Commands {

    public class DeleteUserProfile : IRequest {
        public Guid UserProfileId { get; set; }
    }
}