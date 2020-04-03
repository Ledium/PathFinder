using FluentValidation;
using PathFinder.Presentation.Requests;

namespace PathFinder.Presentation.Validators
{
    public class PathCreateRequestValidator : AbstractValidator<PathCreateRequest>
    {
        public PathCreateRequestValidator()
        {
            RuleFor(pcr => pcr.Inputs)
                .NotNull();

            RuleFor(pcr => pcr.Inputs
                .ToString())
                .MinimumLength(1);
        }
    }
}
