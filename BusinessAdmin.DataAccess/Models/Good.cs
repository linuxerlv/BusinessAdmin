namespace BusinessAdmin.DataAccess.Models
{
    public sealed class Good
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImgPath { get; set; }
        public int Price { get; set; }  
        public int  SellCount { get; set; }
        public int Count { get; set; }
        public int Back { get; set; }
        public int BackPrice { get; set; }
        public string Owner { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
    }
}
