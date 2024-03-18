using AptusEdiParser.Models;
using _834FileParserConsole.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2330))]
    public class _Loop2330 : CoordinationOfBenefitsRef
    {
        public CoordinationOfBenefitsRef NM1
        {
            get
            {
                return new CoordinationOfBenefitsRef
                {
                    FirstName = base.FirstName,
                    LastName = base.LastName,
                    Identifier = base.Identifier,
                    File834Id = base.File834Id,
                    IdentifierCode = base.IdentifierCode,
                    IdentificationCodeQualifier = base.IdentificationCodeQualifier,
                    CoordinationOfBenefitsRefId = base.CoordinationOfBenefitsRefId,
                    CoordinationOfBenefitsId = base.CoordinationOfBenefitsId,
                    MiddleName = base.MiddleName,
                    TypeQualifier = base.TypeQualifier,
                };
            }
        }

        public COBN3 N3 { get; set; }
        public COBN4 N4 { get; set; }

        // public MemPrvPer PER { get; set; }
    }
}