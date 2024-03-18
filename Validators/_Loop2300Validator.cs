using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class _Loop2300Validator : AbstractValidator<_Loop2300>
    {
        public _Loop2300Validator()
        {
            RuleFor(item => item.HealthCoverage).SetValidator(new HealthCoverageValidator());
            RuleForEach(item => item.HealthCoverageDates).SetValidator(new HealthCoveargeDateValidator());
        }
    }
}