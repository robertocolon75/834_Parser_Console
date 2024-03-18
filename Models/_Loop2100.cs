using AptusEdiParser.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2100))]
    public class _Loop2100 : MemberProviderName
    {
        //[Ignore]
        public MemberProviderName MemberProviderName
        {
            get
            {
                return new MemberProviderName
                {
                    FirstName = base.FirstName,
                    LastName = base.LastName,
                    MiddleName = base.MiddleName,
                    Identifier = base.Identifier,
                    IdentifierCode = base.IdentifierCode,
                    IdentificationCodeQualifier = base.IdentificationCodeQualifier,
                    TypeQualifier = base.TypeQualifier,
                    File834Id = base.File834Id,
                };
            }
        }

        public MemPrvPer PER { get; set; }

        public MemPrvN3 N3 { get; set; }

        public MemPrvN4 N4 { get; set; }

        public MemberDemographics DMG { get; set; }

        public List<MemberPolicyAmount> AMT { get; set; }

        public List<MemberLanguage> LUI { get; set; }
    }
}