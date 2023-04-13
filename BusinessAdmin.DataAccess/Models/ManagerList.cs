namespace BusinessAdmin.DataAccess.Models
{
    public sealed class ManagerList
    {
        public int id { get; set; }
        public string PeoPle { get; set; }
        public string WeChatInfo { get; set;}
        public bool State { get; set;}
        public int Income { get; set;}
        public int Back { get; set;}
        public int BackPrice { get; set;}
        public string Source { get; set;}
        public int CUstomer { get; set;}
        public DateTime Time { get; set;}
    }
}
