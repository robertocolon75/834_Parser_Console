using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(N3))]
    public class N3S : Base
    {
        [SourceMember(nameof(N3.N301))]
        public string AddressLine1 { get; set; }

        [SourceMember(nameof(N3.N302))]
        public string AddressLine2 { get; set; }
    }

    [AutoMap(typeof(N3))]
    [Table("stg.N3")]
    [IncludeInTypeMapping]
    public class MemPrvN3 : N3S
    {
        [Key]
        public long NS3Id { get; set; }

        public long MemberProviderNameId { get; set; }
    }

    [AutoMap(typeof(N3))]
    [Table("stg.CoordinationOfBenefitsN3")]
    [IncludeInTypeMapping]
    public class COBN3 : N3S
    {
        [Key]
        public long CoordinationOfBenefitsN3Id { get; set; }

        public long CoordinationOfBenefitsRefId { get; set; }
    }
}