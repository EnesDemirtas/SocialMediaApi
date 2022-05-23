using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Application.Posts.CommandHandlers {

    public class AddPostCommentHandler : IRequestHandler<AddPostComment, OperationResult<PostComment>> {
        private readonly DataContext _ctx;

        public AddPostCommentHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<PostComment>> Handle(AddPostComment request, CancellationToken cancellationToken) {
            var result = new OperationResult<PostComment>();

            try {
                var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId);

                if (post is null) {
                    result.AddError(ErrorCode.NotFound, string.Format(PostErrorMessages.PostNotFound, request.PostId));
                    return result;
                }

                var comment = PostComment.CreatePostComment(request.PostId, request.CommentText, request.UserProfileId);

                post.AddPostComment(comment);

                _ctx.Posts.Update(post);
                await _ctx.SaveChangesAsync();
                result.Payload = comment;
            } catch (PostCommentNotValidException ex) {
                ex.ValidationErrors.ForEach(e => {
                    result.AddError(ErrorCode.ValidationError, e);
                });
            } catch (Exception e) {
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}