using CwkSocial.Domain.Aggregates.PostAggregate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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