using System;

namespace BusinessAdmin.DataAccess.Models
{
    public sealed class StoreManager
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ManagerName { get; set; } 
        public int Count { get; set; }
        public int Price { get; set; }
        public int Coin { get; set; }
        public DateTime Time { get; set; }
        public DateTime SendTime { get; set; }

    }
}
