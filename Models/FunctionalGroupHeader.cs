using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(GS))]
    [Table("stg.FunctionalGroupHeader")]
    [IncludeInTypeMapping]
    public class FunctionalGroupHeader : Base
    {
        [Key]
        [Ignore]
        public long FunctionalGroupHeaderId { get; set; }

        [SourceMember(nameof(GS.GS01))]
        public string FunctionalIDCode { get; set; }

        [SourceMember(nameof(GS.GS02))]
        public string ApplicationSendersCode { get; set; }

        [SourceMember(nameof(GS.GS03))]
        public string ApplicationReceiversCode { get; set; }

        [SourceMember(nameof(GS.GS04))]
        public string GSDate { get; set; }

        [SourceMember(nameof(GS.GS05))]
        public string GSTime { get; set; }

        [SourceMember(nameof(GS.GS06))]
        public string GroupControlNumber { get; set; }

        [SourceMember(nameof(GS.GS07))]
        public string ResponsibleAgencyCode { get; set; }

        [SourceMember(nameof(GS.GS08))]
        public string VersionCode { get; set; }

        [SourceMember(nameof(GS.GE01))]
        public string NumberOfTransactionSetsIncluded { get; set; }

        [SourceMember(nameof(GS.GE02))]
        public string GroupControlNumber2 { get; set; }

        [SourceMember(nameof(GS.Headers))]
        [Write(false)]
        public Headers Headers { get; set; }
    }
}