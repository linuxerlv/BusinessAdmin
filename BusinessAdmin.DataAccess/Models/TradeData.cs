using System.Data;

namespace BusinessAdmin.DataAccess.Models
{
    public sealed class TradeData
    {
        public int Id { get; set; }
        public int AllTra { get; set; }
        public int SpeTra { get; set; }
        public int NorTra { get; set; }
        public int UserCount { get; set; }
        public int ManagerCount { get; set; }
        public DataSetDateTime Time { get; set; }
    }
}
