using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(PLA))]
    [Table("stg.ProviderChangeReason")]
    [IncludeInTypeMapping]
    public class ProviderChangeReason : Base
    {
        [Key]
        public long ProviderChangeReasonId { get; set; }

        public long MemberProviderNameId { get; set; }

        [SourceMember(nameof(PLA.PLA01))]
        public string ActionCode { get; set; }

        [SourceMember(nameof(PLA.PLA02))]
        public string IdentifierCode { get; set; }

        [SourceMember(nameof(PLA.PLA03))]
        public string EffectiveDate { get; set; }

        [SourceMember(nameof(PLA.PLA05))]
        public string MaintenanceReasonCode { get; set; }
    }
}