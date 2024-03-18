using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(N1))]
    [Table("stg.SponsorPayer")]
    [IncludeInTypeMapping]
    public class SponsorPayer : Base
    {
        [Key]
        public long SponsorPayerId { get; set; }

        public long ParentId { get; set; }

        [SourceMember(nameof(N1.N101))]
        public string EntityIdentifierCode { get; set; }

        [SourceMember(nameof(N1.N102))]
        public string PlanSponsorName { get; set; }

        [SourceMember(nameof(N1.N103))]
        public string IdentificationCodeQualifier { get; set; }

        [SourceMember(nameof(N1.N104))]
        public string SponsorIdentifier { get; set; }
    }
}