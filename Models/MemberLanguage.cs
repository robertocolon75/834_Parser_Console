using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(LUI))]
    [Table("stg.MemberLanguage")]
    [IncludeInTypeMapping]
    public class MemberLanguage : Base
    {
        [Key]
        public long MemberLanguageId { get; set; }

        public long MemberProviderNameId { get; set; }

        [SourceMember(nameof(LUI.LUI01))]
        public string QualifierCode { get; set; }

        [SourceMember(nameof(LUI.LUI02))]
        public string Code { get; set; }

        [SourceMember(nameof(LUI.LUI03))]
        public string Description { get; set; }

        [SourceMember(nameof(LUI.LUI04))]
        public string UseIndicator { get; set; }
    }
}