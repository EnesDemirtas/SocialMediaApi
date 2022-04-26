using CwkSocial.Application.Models;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.Commands {

    public class AddPostComment : IRequest<OperationResult<PostComment>> {
        public Guid PostId { get; set; }
        public Guid UserProfileId { get; set; }
        public string CommentText { get; set; }
    }
}