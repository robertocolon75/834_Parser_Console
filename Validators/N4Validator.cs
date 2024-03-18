using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class N4Validator : AbstractValidator<MemPrvN4>
    {
        public N4Validator(string identifier)
        {
            RuleFor(item => item.CityName).NotEmpty().NotNull().WithErrorCode("N401");
            RuleFor(item => item.StateCode).NotEmpty().NotNull().WithErrorCode("N402");
            RuleFor(item => item.ZipCode).NotEmpty().NotNull().WithErrorCode("N403");
            RuleFor(item => item.LocationQualifier).NotEmpty().NotNull().WithErrorCode("N405").When(item => identifier == "74" || identifier == "IL");
            RuleFor(item => item.LocationIdentifier).NotEmpty().NotNull().WithErrorCode("N406").When(item => identifier == "74" || identifier == "IL");
        }
    }
}