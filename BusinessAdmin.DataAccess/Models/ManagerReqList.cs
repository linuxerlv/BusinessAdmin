namespace BusinessAdmin.DataAccess.Models
{
    public sealed class ManagerReqList
    {
        public int Id { get; set; }
        public string PeoPle { get; set; }
        public bool State { get; set; }
        public DateTime ReqTime { get; set; }
        public DateTime Time { get; set; }
    }
}
