using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class RefValidator : AbstractValidator<REFS>
    {
        public RefValidator()
        {
            RuleFor(item => item.Identifier).NotEmpty().NotNull().WithErrorCode("REF01").When(item => item.Qualifier == "0F");
            RuleFor(item => item.Qualifier).NotEmpty().NotNull().WithErrorCode("REF02").When(item => item.Qualifier == "0F");
        }
    }
}