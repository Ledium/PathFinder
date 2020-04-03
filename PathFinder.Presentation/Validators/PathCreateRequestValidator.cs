using FluentValidation;
using PathFinder.Presentation.Requests;

namespace PathFinder.Presentation.Validators
{
    public class PathCreateRequestValidator : AbstractValidator<PathCreateRequest>
    {
        public PathCreateRequestValidator()
        {
            RuleFor(pcr => pcr.Input)
                .NotNull();

            RuleFor(pcr => pcr.Input
                .ToString())
                .MinimumLength(1);
        }
    }
}
