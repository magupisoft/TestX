using FluentValidation;

using MovieTest.Common.DTO;

namespace MovieTest.API.Validators
{
    public class AddMovieRequestValidator : AbstractValidator<AddMovieRequest>
    {
        public AddMovieRequestValidator()
        {
            this.RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Title is required")
                .NotNull().WithMessage("Title can't be null")
                .Length(1, 50).WithMessage("Max length for Title is 50");

            this.RuleFor(product => product.Description)
                .Length(0, 500).WithMessage("Max length for Description is 500");

            this.RuleFor(product => product.Classification)
                .NotEmpty().WithMessage("Classification is required")
                .NotNull().WithMessage("Classification can't be null")
                .Length(1, 5).WithMessage("Max length for Classification is 5");

            this.RuleFor(product => product.Duration)
                .NotEmpty().WithMessage("Duration is required")
                .NotNull().WithMessage("Duration can't be null")
                .Length(1, 10).WithMessage("Max length for Duration is 10");

            this.RuleFor(product => product.Genres)
                .NotEmpty().WithMessage("Genres is required")
                .NotNull().WithMessage("Genres can't be null")
                .Length(1, 50).WithMessage("Max length for Genres is 50");
        }
    }
}
