using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Application.Posts.CommandHandlers {

    public class UpdatePostTextHandler : IRequestHandler<UpdatePostText, OperationResult<Post>> {
        private readonly DataContext _ctx;

        public UpdatePostTextHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<Post>> Handle(UpdatePostText request, CancellationToken cancellationToken) {
            var result = new OperationResult<Post>();

            try {
                var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId);

                if (post is null) {
                    result.AddError(ErrorCode.NotFound, string.Format(PostErrorMessages.PostNotFound, request.PostId));
                    return result;
                }

                if (post.UserProfileId != request.UserProfileId) {
                    result.AddError(ErrorCode.PostUpdateNotPossible, PostErrorMessages.PostUpdateNotPossible);
                    return result;
                }

                post.UpdatePostText(request.NewText);
                await _ctx.SaveChangesAsync();
                result.Payload = post;
            } catch (PostNotValidException ex) {
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