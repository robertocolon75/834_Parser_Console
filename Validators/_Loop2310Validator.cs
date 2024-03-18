using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class _Loop2310Validator : AbstractValidator<_Loop2310>
    {
        public _Loop2310Validator()
        {
            RuleFor(item => item.NM1).SetValidator(new MemberProviderNameValidator());
            RuleFor(item => item.PLA).SetValidator(new ProviderChangeReasonValidator());
        }
    }
}