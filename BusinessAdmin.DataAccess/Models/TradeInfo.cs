namespace BusinessAdmin.DataAccess.Models
{
    public sealed class TradeInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string User { get; set; }
        public bool PayType { get; set; }
        public DateTime Time { get; set; }
    }
}
