using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;

namespace CwkSocial.Application.Posts.CommandHandlers {

    public class CreatePostHandler : IRequestHandler<CreatePost, OperationResult<Post>> {
        private readonly DataContext _ctx;

        public CreatePostHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<Post>> Handle(CreatePost request, CancellationToken cancellationToken) {
            var result = new OperationResult<Post>();

            try {
                var post = Post.CreatePost(request.UserProfileId, request.TextContent);
                _ctx.Posts.Add(post);
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