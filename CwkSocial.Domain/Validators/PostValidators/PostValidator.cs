using CwkSocial.Domain.Aggregates.PostAggregate;
using FluentValidation;

namespace CwkSocial.Domain.Validators.PostValidators {

    public class PostValidator : AbstractValidator<Post> {

        public PostValidator() {
            RuleFor(p => p.TextContent)
                .NotNull().WithMessage("Post text content cannot be null.")
                .NotEmpty().WithMessage("Post text content cannot be empty.")
                ;
        }
    }
}