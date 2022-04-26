using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Queries;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.QueryHandlers {

    public class GetPostCommentsHandler : IRequestHandler<GetPostComments, OperationResult<List<PostComment>>> {
        private readonly DataContext _ctx;

        public GetPostCommentsHandler(DataContext ctx) {
            _ctx = ctx;
        }

        public async Task<OperationResult<List<PostComment>>> Handle(GetPostComments request, CancellationToken cancellationToken) {
            var result = new OperationResult<List<PostComment>>();
            try {
                var post = await _ctx.Posts.Include(p => p.Comments).
                    FirstOrDefaultAsync(p => p.PostId == request.PostId);

                result.Payload = post.Comments.ToList();
            } catch (Exception e) {
                var error = new Error { Code = ErrorCode.UnknownError, Message = $"{e.Message}" };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}