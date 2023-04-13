using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class TradeInfoContext : DbContext
    {
        public TradeInfoContext (DbContextOptions<TradeInfoContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.TradeInfo> TradeInfo { get; set; } = default!;
    }
}
