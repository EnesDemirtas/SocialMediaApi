using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    result.IsError = true;
                    var error = new Error { Code = ErrorCode.NotFound, Message = $"No Post found with ID {request.PostId}" };
                    result.Errors.Add(error);
                    return result;
                }

                var comment = PostComment.CreatePostComment(request.PostId, request.CommentText, request.UserProfileId);

                post.AddPostComment(comment);

                _ctx.Posts.Update(post);
                await _ctx.SaveChangesAsync();
                result.Payload = comment;
            } catch (PostCommentNotValidException ex) {
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