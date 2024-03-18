using AptusEdiParser.Attributes;

namespace _834FilePareserControl.Models
{
    [Table("stg.ValidationError")]
    [IncludeInTypeMapping]
    public class ValidationError : Base
    {
        [Key]
        public long ValidationErrorId { get; set; }

        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}