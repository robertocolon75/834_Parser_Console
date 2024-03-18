using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class MemberProviderNameValidator : AbstractValidator<MemberProviderName>
    {
        public MemberProviderNameValidator()
        {
            var noValidationCodes = new[] { "QD", "31", "70" };
            var memberCodes = new[] { "74", "IL" };
            var providerCodes = new[] { "P3", "Y2" };

            RuleFor(item => item.IdentifierCode).NotEmpty().NotNull().WithErrorCode("NM101")
                .When(item => noValidationCodes.Any(x => x != item.IdentifierCode));
            RuleFor(item => item.TypeQualifier).NotEmpty().NotNull().WithErrorCode("NM102")
                .When(item => noValidationCodes.Any(x => x != item.IdentifierCode));

            RuleFor(item => item.LastName).NotEmpty().NotNull().WithErrorCode("NM103")
                .When(item => memberCodes.Any(x => x == item.IdentifierCode));
            RuleFor(item => item.FirstName).NotEmpty().NotNull().WithErrorCode("NM104")
                .When(item => memberCodes.Any(x => x == item.IdentifierCode));

            RuleFor(item => item.MiddleName).NotEmpty().NotNull().WithErrorCode("NM105")
              .When(item => providerCodes.Any(x => x == item.IdentifierCode));
            RuleFor(item => item.NamePrefix).NotEmpty().NotNull().WithErrorCode("NM106")
              .When(item => providerCodes.Any(x => x == item.IdentifierCode));
            RuleFor(item => item.IdentificationCodeQualifier).NotEmpty().NotNull().WithErrorCode("NM108")
            .When(item => providerCodes.Any(x => x == item.IdentifierCode));
            RuleFor(item => item.Identifier).NotEmpty().NotNull().WithErrorCode("NM109")
           .When(item => providerCodes.Any(x => x == item.IdentifierCode));
            RuleFor(item => item.EntityRelationshipCode).NotEmpty().NotNull().WithErrorCode("NM110")
         .When(item => providerCodes.Any(x => x == item.IdentifierCode));
        }
    }
}