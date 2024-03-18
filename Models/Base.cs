namespace _834FilePareserControl.Models
{
    public class Base : IMain
    {
        public Base()
        {
            File834Id = Global.File834Id;
        }

        public long File834Id { get; set; }
    }
}