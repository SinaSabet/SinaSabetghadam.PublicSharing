using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Tweets.CreateTweet
{
    public class CreateTweetCommandValidator : AbstractValidator<CreateTweetCommand>
    {
        public CreateTweetCommandValidator()
        {
            RuleFor(command => command.Title)
          .NotEmpty().WithMessage("Title is required.")
          .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(command => command.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(280).WithMessage("Content must not exceed 280 characters.");

            RuleFor(command => command.HashTags)
                .NotNull().WithMessage("HashTags cannot be null.")
                .Must(h => h.Count > 0).WithMessage("At least one hashtag is required.");
        }
    }
}
