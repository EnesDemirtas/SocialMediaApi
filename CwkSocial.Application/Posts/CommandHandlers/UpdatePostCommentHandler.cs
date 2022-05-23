using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.CommandHandlers {

    public class UpdatePostCommentHandler : IRequestHandler<UpdatePostComment, OperationResult<PostComment>> {
        private readonly DataContext _ctx;
        private readonly OperationResult<PostComment> _result;

        public UpdatePostCommentHandler(DataContext ctx) {
            _ctx = ctx;
            _result = new OperationResult<PostComment>();
        }

        public async Task<OperationResult<PostComment>> Handle(UpdatePostComment request, CancellationToken cancellationToken) {
            var post = await _ctx.Posts.Include(p => p.Comments)
    .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

            if (post == null) {
                _result.AddError(ErrorCode.NotFound, PostErrorMessages.PostNotFound);
                return _result;
            }

            var comment = post.Comments.FirstOrDefault(c => c.CommentId == request.CommentId);
            if (comment == null) {
                _result.AddError(ErrorCode.NotFound, PostErrorMessages.PostCommentNotFound);
                return _result;
            }

            if (comment.UserProfileId != request.UserProfileId) {
                _result.AddError(ErrorCode.CommentRemovalNotAuthorized, PostErrorMessages.CommentRemovalNotAuthorized);
                return _result;
            }

            comment.UpdateCommentText(request.UpdatedText);
            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync(cancellationToken);

            return _result;
        }
    }
}