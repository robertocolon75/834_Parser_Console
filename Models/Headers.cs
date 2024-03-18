using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(ST))]
    [Table("stg.Header")]
    [IncludeInTypeMapping]
    public class Headers : Base
    {
        [Ignore]
        [Key]
        public long HeaderId { get; set; }

        [SourceMember(nameof(ST.ST01))]
        public string TransactionSetIdentifierCode { get; set; }

        [SourceMember(nameof(ST.ST02))]
        public string TransactionSetControlNumber { get; set; }

        [SourceMember(nameof(ST.ST03))]
        public string ImplementationGuideVersionName { get; set; }

        [SourceMember(nameof(ST.SE01))]
        public string TransactionSegmentCount { get; set; }

        [SourceMember(nameof(ST.SE02))]
        public string TransactionSetControlNumber2 { get; set; }

        [SourceMember(nameof(ST.BGN01))]
        public string TransactionSetPurposeCode { get; set; }

        [SourceMember(nameof(ST.BGN02))]
        public string TransactionSetReferenceNumber { get; set; }

        [SourceMember(nameof(ST.BGN03))]
        public string TransactionSetCreationDate { get; set; }

        [SourceMember(nameof(ST.BGN04))]
        public string TransactionSetCreationTime { get; set; }

        [SourceMember(nameof(ST.BGN05))]
        public string TimeZoneCode { get; set; }

        [SourceMember(nameof(ST.BGN06))]
        public string OriginalTransactionSetReferenceNumber { get; set; }

        [SourceMember(nameof(ST.BGN08))]
        public string ActionCode { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [Write(false)]
        public HeaderRef TransactionSetPolicyNumber { get; set; }

        //[SourceMember(nameof(ST.TransactionSetPolicyNumber.REF02))]
        [Ignore]
        public string ReferenceIdentificationQualifier { get => TransactionSetPolicyNumber.Qualifier; }

        public string MasterPolicyNumber { get => TransactionSetPolicyNumber.Identifier; }

        [SourceMember(nameof(ST.FileEffectiveDate))]
        [Write(false)]
        public List<HeaderDate> Dates { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [Write(false)]
        public QTY QTY { get; set; }

        //[SourceMember(nameof(ST.TransactionSetPolicyNumber.REF02))]
        public string TraceTypeCode
        {
            get
            {
                if (QTY != null) return QTY.QTY01;
                return null;
            }
        }

        public string? RecordTotals
        {
            get
            {
                if (QTY != null) return QTY.QTY02;
                return null;
            }
        }

        [Write(false)]
        public SponsorPayer Sponsor { get; set; }

        [Write(false)]
        public SponsorPayer Payer { get; set; }

        [Write(false)]
        public List<_Loop2000> Loop2000 { get; set; }
    }
}