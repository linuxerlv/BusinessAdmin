namespace BusinessAdmin.DataAccess.Models
{
    public sealed class TradeList
    {
        public int Id { get; set; }
        public String Info { get; set; }
        public int Income { get; set; }
        public int Expend { get; set; }
        public DateTime Time { get; set; }
    }
}
