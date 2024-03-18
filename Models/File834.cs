namespace _834FilePareserControl.Models
{
    [Table("dbo.File834")]
    public class File834
    {
        public File834(string filepath)
        {
            FilePath = filepath;
        }

        [Key]
        public long File834Id { get; set; }

        public string FilePath { get; set; }

        public DateTime ProcessDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}