using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Policy;

namespace BusinessAdmin.DataAccess.Models
{
    public sealed class OrderForm
    {
        
        public uint Id {  get; set; }
        public string Name { get; set; } = default(string)!;
        public double Price { get; set; }
        public string Buyer { get; set; }
        public DateTime Time { get; set; }
        public bool Role { get; set; }
        public bool State { get; set; }
        public bool PayType { get; set; }
        public string Source { get; set; } = default!;
        public string? Phone { get; set; }
    }
}