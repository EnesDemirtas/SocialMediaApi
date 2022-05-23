using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.Commands {

    public class UpdatePostComment : IRequest<OperationResult<PostComment>> {
        public Guid UserProfileId { get; set; }
        public Guid PostId { get; set; }
        public Guid CommentId { get; set; }
        public string UpdatedText { get; set; }
    }
}