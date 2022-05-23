using CwkSocial.Domain.Aggregates.PostAggregate;
using FluentValidation;

namespace CwkSocial.Domain.Validators.PostValidators {

    public class PostCommentValidator : AbstractValidator<PostComment> {

        public PostCommentValidator() {
            RuleFor(pc => pc.Text)
                .NotNull().WithMessage("Comment text cannot be null.")
                .NotEmpty().WithMessage("Comment text cannot be empty.")
                .MaximumLength(1000)
                .MinimumLength(1);
        }
    }
}