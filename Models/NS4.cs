using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(N4))]
    public class N4S : Base
    {
        [SourceMember(nameof(N4.N401))]
        public string CityName { get; set; }

        [SourceMember(nameof(N4.N402))]
        public string StateCode { get; set; }

        [SourceMember(nameof(N4.N403))]
        public string ZipCode { get; set; }

        [SourceMember(nameof(N4.N405))]
        public string LocationQualifier { get; set; }

        [SourceMember(nameof(N4.N406))]
        public string LocationIdentifier { get; set; }
    }

    [AutoMap(typeof(N4))]
    [Table("stg.N4")]
    [IncludeInTypeMapping]
    public class MemPrvN4 : N4S
    {
        [Key]
        public long NS4Id { get; set; }

        public long MemberProviderNameId { get; set; }
    }

    [AutoMap(typeof(N4))]
    [Table("stg.CoordinationOfBenefitsN4")]
    [IncludeInTypeMapping]
    public class COBN4 : N4S
    {
        [Key]
        public long CoordinationOfBenefitsN4Id { get; set; }

        public long CoordinationOfBenefitsRefId { get; set; }
    }
}