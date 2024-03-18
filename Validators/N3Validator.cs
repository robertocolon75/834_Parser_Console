using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class N3Validator : AbstractValidator<MemPrvN3>
    {
        public N3Validator()
        {
            RuleFor(item => item.AddressLine1).NotEmpty().NotNull().WithErrorCode("N301");
        }
    }
}