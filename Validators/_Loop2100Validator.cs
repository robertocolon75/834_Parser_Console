using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class _Loop2100Validator : AbstractValidator<_Loop2100>
    {
        public _Loop2100Validator()
        {
            RuleFor(item => item.MemberProviderName).SetValidator(new MemberProviderNameValidator());
            RuleFor(item => item.N4).SetValidator(item => new N4Validator(item.Identifier));
            RuleFor(item => item.N3).SetValidator(new N3Validator()).When(item => item.IdentifierCode == "31");
        }
    }
}