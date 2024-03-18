using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(ISA))]
    [Table("stg.InterchangeControlHeader")]
    [IncludeInTypeMapping]
    public class InterchangeControlHeader : Base
    {
        [Key]
        public long InterchangeControlHeaderId { get; set; }

        [SourceMember(nameof(ISA.ISA01))]
        public string AuthorizationInformationQualifier { get; set; }

        [SourceMember(nameof(ISA.ISA02))]
        public string AuthorizationInformation { get; set; }

        [SourceMember(nameof(ISA.ISA03))]
        public string SecurityInformationQualifier { get; set; }

        [SourceMember(nameof(ISA.ISA04))]
        public string SecurityInformation { get; set; }

        [SourceMember(nameof(ISA.ISA05))]
        public string SenderInterchangeIDQualifier { get; set; }

        [SourceMember(nameof(ISA.ISA06))]
        public string InterchangeSenderID { get; set; }

        [SourceMember(nameof(ISA.ISA07))]
        public string ReceiverInterchangeIDQualifier { get; set; }

        [SourceMember(nameof(ISA.ISA08))]
        public string InterchangeReceiverID { get; set; }

        [SourceMember(nameof(ISA.ISA09))]
        public string InterchangeDate { get; set; }

        [SourceMember(nameof(ISA.ISA10))]
        public string InterchangeTime { get; set; }

        [SourceMember(nameof(ISA.ISA11))]
        public string RepetitionSeparator { get; set; }

        [SourceMember(nameof(ISA.ISA12))]
        public string InterchangeControlVersionNumber { get; set; }

        [SourceMember(nameof(ISA.ISA13))]
        public string InterchangeControlNumber { get; set; }

        [SourceMember(nameof(ISA.ISA14))]
        public string AcknowledgementRequested { get; set; }

        [SourceMember(nameof(ISA.ISA15))]
        public string UsageIdentifier { get; set; }

        [SourceMember(nameof(ISA.ISA16))]
        public string ComponentElementSeparator { get; set; }

        [SourceMember(nameof(ISA.IEA01))]
        public string NumberOfIncludedFunctionalGroups { get; set; }

        [SourceMember(nameof(ISA.IEA02))]
        public string InterchangeControlNumber2 { get; set; }

        [SourceMember(nameof(ISA.Groups))]
        [Write(false)]
        public FunctionalGroupHeader FGH { get; set; }
    }
}