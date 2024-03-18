using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class _Loop2000Validator : AbstractValidator<_Loop2000>
    {
        public _Loop2000Validator()
        {
            RuleFor(item => item.INS).SetValidator(new MemberValidator());
            RuleFor(item => item.REF).SetValidator(new RefValidator());
            RuleForEach(item => item.Loop2100s).SetValidator(new _Loop2100Validator());
            RuleForEach(item => item.Loop2300s).SetValidator(new _Loop2300Validator());
        }
    }
}