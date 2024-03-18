using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(PER))]
    public class PERS : Base
    {
        [SourceMember(nameof(PER.PER01))]
        public string ContactFunctionCode { get; set; }

        [SourceMember(nameof(PER.PER03))]
        public string PrimaryPhoneNumberQualifier { get; set; }

        [SourceMember(nameof(PER.PER04))]
        public string PrimaryPhoneNumber { get; set; }

        [SourceMember(nameof(PER.PER05))]
        public string SecondaryPhoneNumberQualifier { get; set; }

        [SourceMember(nameof(PER.PER06))]
        public string SecondaryPhoneNumber { get; set; }
    }

    [Table("stg.MemberContact")]
    [IncludeInTypeMapping]
    public class InsPer : PERS
    {
        [Key]
        public long MemberContactId { get; set; }

        public long MemberId { get; set; }
    }

    [Table("stg.MemberProviderNameContact")]
    [IncludeInTypeMapping]
    public class MemPrvPer : PERS
    {
        [Key]
        public long MemberProviderNameContactId { get; set; }

        public long MemberProviderNameId { get; set; }
    }
}